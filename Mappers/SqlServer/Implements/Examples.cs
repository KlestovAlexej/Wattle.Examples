using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Common;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Common;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Implements;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Interface;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Tests;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing.Databases.SqlServer;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements;

[TestFixture]
public class Examples
{
    /// <summary>
    /// Сокрытие записи, без её физического удаления из БД.
    /// </summary>
    [Test]
    public void Example_Hide()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = mappers.GetMapper<IMapperObject_B>();

        var id_1 = 1;

        // Создать запись.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto =
                mapper.New(
                    mappersSession,
                    new Object_BDtoNew
                    {
                        Id = id_1,
                        CreateDate = DateTime.Now,
                    });
            Console.WriteLine("Запись в БД до сокрытия :");
            Console.WriteLine(dbDto.ToJsonText(true));

            mappersSession.Commit();
        }

        // Скрыть запись.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDtoActual = mapper.Get(mappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            mapper.Hide(mappersSession,
                new Object_BDtoDeleted
                {
                    Id = dbDtoActual.Id,
                    Revision = dbDtoActual.Revision,
                });

            Assert.IsFalse(mapper.Exists(mappersSession, id_1));
            Assert.IsTrue(mapper.ExistsRaw(mappersSession, id_1));

            mappersSession.Commit();
        }

        // Проверить сокрытие записи.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto = mapper.Get(mappersSession, id_1);
            Assert.IsNull(dbDto);

            dbDto = mapper.GetRaw(mappersSession, id_1);
            Assert.IsNotNull(dbDto);
            Console.WriteLine("Запись в БД после скрытия :");
            Console.WriteLine(dbDto.ToJsonText(true));

            Assert.IsFalse(mapper.Exists(mappersSession, id_1));
            Assert.IsTrue(mapper.ExistsRaw(mappersSession, id_1));
        }
    }

    /// <summary>
    /// Асинхронное сокрытие записи, без её физического удаления из БД.
    /// </summary>
    [Test]
    public async ValueTask Example_Hide_Async()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = mappers.GetMapper<IMapperObject_B>();

        var id_1 = 1;

        // Создать запись.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDto =
                await mapper.NewAsync(
                    mappersSession,
                    new Object_BDtoNew
                    {
                        Id = id_1,
                        CreateDate = DateTime.Now,
                    });
            Console.WriteLine("Запись в БД до сокрытия :");
            Console.WriteLine(dbDto.ToJsonText(true));

            await mappersSession.CommitAsync();
        }

        // Скрыть запись.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDtoActual = await mapper.GetAsync(mappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            await mapper.HideAsync(mappersSession,
                new Object_BDtoDeleted
                {
                    Id = dbDtoActual.Id,
                    Revision = dbDtoActual.Revision,
                });

            Assert.IsFalse(await mapper.ExistsAsync(mappersSession, id_1));
            Assert.IsTrue(await mapper.ExistsRawAsync(mappersSession, id_1));

            await mappersSession.CommitAsync();
        }

        // Проверить сокрытие записи.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDto = await mapper.GetAsync(mappersSession, id_1);
            Assert.IsNull(dbDto);

            dbDto = await mapper.GetRawAsync(mappersSession, id_1);
            Assert.IsNotNull(dbDto);
            Console.WriteLine("Запись в БД после скрытия :");
            Console.WriteLine(dbDto.ToJsonText(true));

            Assert.IsFalse(await mapper.ExistsAsync(mappersSession, id_1));
            Assert.IsTrue(await mapper.ExistsRawAsync(mappersSession, id_1));
        }
    }

    /// <summary>
    /// Физическое удаление записи с оптимистической конкуренцией.
    /// </summary>
    [Test]
    public void Example_Delete_With_Optimistic_Concurrency()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;

        // Создать запись.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto =
                mapper.New(
                    mappersSession,
                    new Object_ADtoNew
                    {
                        Id = id_1,
                        Value_DateTime = DateTime.Now,
                        Value_DateTime_NotUpdate = DateTime.Now,
                        Value_Int = null,
                        Value_Long = 314,
                        Value_String = "Text 1",
                    });
            Console.WriteLine("Запись в БД до удаления :");
            Console.WriteLine(dbDto.ToJsonText(true));

            mappersSession.Commit();
        }

        // Удалить запись.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDtoActual = mapper.Get(mappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            try
            {
                mapper.Delete(mappersSession,
                    new Object_ADtoDeleted
                    {
                        Id = dbDtoActual.Id,
                        Revision = dbDtoActual.Revision + 1, // Неверная ожидаемая версия записи в БД.
                    });

                Assert.Fail();
            }
            catch (InvalidOperationException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Конкуренция при удалении записи"));
            }

            mappersSession.Commit();
        }

        // Проверить удаление записи.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto = mapper.Get(mappersSession, id_1);
            Console.WriteLine("Запись в БД без изменений :");
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Физическое удаление записи.
    /// </summary>
    [Test]
    public void Example_Delete()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;

        // Создать запись.
        using (var mappersSession = mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = id_1,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 314,
                    Value_String = "Text 1",
                });

            mappersSession.Commit();
        }

        // Удалить запись.
        using (var mappersSession = mappers.OpenSession())
        {
            var dbDtoActual = mapper.Get(mappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            mapper.Delete(mappersSession,
                new Object_ADtoDeleted
                {
                    Id = dbDtoActual.Id,
                    Revision = dbDtoActual.Revision,
                });

            Assert.IsFalse(mapper.Exists(mappersSession, id_1));

            mappersSession.Commit();
        }

        // Проверить удаление записи.
        using (var mappersSession = mappers.OpenSession())
        {
            Assert.IsFalse(mapper.Exists(mappersSession, id_1));
        }
    }

    /// <summary>
    /// Асинхронное физическое удаление записи.
    /// </summary>
    [Test]
    public async  ValueTask Example_Delete_Async()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;

        // Создать запись.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            await mapper.NewAsync(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = id_1,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 314,
                    Value_String = "Text 1",
                });

            await mappersSession.CommitAsync();
        }

        // Удалить запись.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDtoActual = await mapper.GetAsync(mappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            await mapper.DeleteAsync(mappersSession,
                new Object_ADtoDeleted
                {
                    Id = dbDtoActual.Id,
                    Revision = dbDtoActual.Revision,
                });

            Assert.IsFalse(await mapper.ExistsAsync(mappersSession, id_1));

            await mappersSession.CommitAsync();
        }

        // Проверить удаление записи.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            Assert.IsFalse(await mapper.ExistsAsync(mappersSession, id_1));
        }
    }

    /// <summary>
    /// Обновление записей с оптимистической конкуренцией.
    /// </summary>
    [Test]
    public void Example_Update_With_Optimistic_Concurrency()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto =
                mapper.New(
                    mappersSession,
                    new Object_ADtoNew
                    {
                        Id = id_1,
                        Value_DateTime = DateTime.Now,
                        Value_DateTime_NotUpdate = DateTime.Now,
                        Value_Int = null,
                        Value_Long = 314,
                        Value_String = "Text 1",
                    });
            Console.WriteLine("Запись в БД до изменения :");
            Console.WriteLine(dbDto.ToJsonText(true));

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDtoActual = mapper.Get(mappersSession, id_1);

            try
            {
                mapper.Update(
                    mappersSession,
                    new Object_ADtoChanged
                    {
                        Id = dbDtoActual.Id,
                        Revision = dbDtoActual.Revision + 1, // Неверная ожидаемая версия записи в БД.
                        Value_DateTime = DateTime.Now.AddHours(1),
                        Value_DateTime_NotUpdate = dbDtoActual.Value_DateTime_NotUpdate,
                        Value_Int = 6006,
                        Value_Long = new MapperChangedStateDtoField<long>(555, true),
                        Value_String = new MapperChangedStateDtoField<string>(null, true),
                    });

                Assert.Fail();
            }
            catch (InvalidOperationException exception)
            {
                Assert.IsTrue(exception.Message.Contains("Конкуренция при обновлении записи"));
            }

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto = mapper.Get(mappersSession, id_1);
            Console.WriteLine("Запись в БД без изменений :");
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Обновление записей.
    /// </summary>
    [Test]
    public void Example_Update()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto =
                mapper.New(
                    mappersSession,
                    new Object_ADtoNew
                    {
                        Id = id_1,
                        Value_DateTime = DateTime.Now,
                        Value_DateTime_NotUpdate = DateTime.Now,
                        Value_Int = null,
                        Value_Long = 314,
                        Value_String = "Text 1",
                    });
            Console.WriteLine("Запись в БД до изменения :");
            Console.WriteLine(dbDto.ToJsonText(true));

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDtoActual = mapper.Get(mappersSession, id_1);
            mapper.Update(
                mappersSession,
                new Object_ADtoChanged
                {
                    Id = dbDtoActual.Id,
                    Revision = dbDtoActual.Revision,
                    Value_DateTime = DateTime.Now.AddHours(1),
                    Value_DateTime_NotUpdate = dbDtoActual.Value_DateTime_NotUpdate,
                    Value_Int = 6006,
                    Value_Long = new MapperChangedStateDtoField<long>(555, true),
                    Value_String = new MapperChangedStateDtoField<string>(null, true),
                });

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto = mapper.Get(mappersSession, id_1);
            Console.WriteLine("Запись в БД после изменения :");
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Асинхронное обновление записей.
    /// </summary>
    [Test]
    public async ValueTask Example_Update_Async()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;

        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDto =
                await mapper.NewAsync(
                    mappersSession,
                    new Object_ADtoNew
                    {
                        Id = id_1,
                        Value_DateTime = DateTime.Now,
                        Value_DateTime_NotUpdate = DateTime.Now,
                        Value_Int = null,
                        Value_Long = 314,
                        Value_String = "Text 1",
                    });
            Console.WriteLine("Запись в БД до изменения :");
            Console.WriteLine(dbDto.ToJsonText(true));

            await mappersSession.CommitAsync();
        }

        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDtoActual = await mapper.GetAsync(mappersSession, id_1);
            await mapper.UpdateAsync(
                mappersSession,
                new Object_ADtoChanged
                {
                    Id = dbDtoActual.Id,
                    Revision = dbDtoActual.Revision,
                    Value_DateTime = DateTime.Now.AddHours(1),
                    Value_DateTime_NotUpdate = dbDtoActual.Value_DateTime_NotUpdate,
                    Value_Int = 6006,
                    Value_Long = new MapperChangedStateDtoField<long>(555, true),
                    Value_String = new MapperChangedStateDtoField<string>(null, true),
                });

            await mappersSession.CommitAsync();
        }

        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDto = await mapper.GetAsync(mappersSession, id_1);
            Console.WriteLine("Запись в БД после изменения :");
            Console.WriteLine(dbDto.ToJsonText(true));

            await mappersSession.CommitAsync();
        }
    }

    /// <summary>
    /// Выборка записей по первичному ключу с использовантием кеша в памяти.
    /// </summary>
    [Test]
    public void Example_Select_With_MemoryCache()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id_1 = 1;
        var id_2 = 2;

        // Заполнение таблицы.
        using (var mappersSession = mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = id_1,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 314,
                    Value_String = "Text 1",
                });
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = id_2,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 600,
                    Value_String = "Text 2",
                });

            mappersSession.Commit();
        }

        // Выборка записей по первичному ключу.
        Parallel.For(0, 1_000_000,
            _ =>
            {
                var mappersSession = mappers.OpenSession();

                mapper.Get(mappersSession, id_1);
                mapper.Get(mappersSession, id_2);
            });

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto_1 = mapper.Get(mappersSession, id_1);
            Console.WriteLine(dbDto_1.ToJsonText(true));

            var dbDto_2 = mapper.Get(mappersSession, id_2);
            Console.WriteLine(dbDto_2.ToJsonText(true));
        }

        {
            var snapShot = mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions}");
        }

        {
            var snapShot = mapper.InfrastructureMonitor.InfrastructureMonitorActualDtoCache.GetSnapShot();
            Console.WriteLine($"Количество объектов в памяти : {snapShot.Count}");
            Console.WriteLine($"Количество поисков объектов в памяти : {snapShot.CountFind}");
            Console.WriteLine($"Количество найденных объектов в памяти : {snapShot.CountFound}");
        }
    }

    /// <summary>
    /// Создание записей в таблице БД.
    /// </summary>
    [Test]
    public void Example_Insert()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id = 1;

        using (var mappersSession = mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = id,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 314,
                    Value_String = "Text",
                });

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var dbDto = mapper.Get(mappersSession, id);
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Асинхронное создание записей в таблице БД.
    /// </summary>
    [Test]
    public async ValueTask Example_Insert_Async()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var id = 1;

        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            await mapper.NewAsync(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = id,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 314,
                    Value_String = "Text",
                });

            await mappersSession.CommitAsync();
        }

        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            var dbDto = await mapper.GetAsync(mappersSession, id);

            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Выборка записей по условию.
    /// </summary>
    [Test]
    public void Example_Select()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        // Заполнение таблицы.
        using (var mappersSession = mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = 1,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 314,
                    Value_String = "Text",
                });
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = 2,
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 600,
                    Value_String = "Text",
                });

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var queryText =
                SchemaQueriesProvider
                    .QueryForObject_A("WHERE Value_Long = @Value_Long ORDER Id DESC")
                    .AddParameterInt64("Value_Long", 314)
                    .GetQuery();
            var selectFilter = mapper.CreateSelectFilter(queryText);

            var dbDtos = mapper.GetEnumerator(mappersSession, selectFilter).ToList();
            Assert.AreEqual(1, dbDtos.Count);

            Console.WriteLine(dbDtos[0].ToJsonText(true));
        }
    }

    /// <summary>
    /// Генератор уникальных первичных ключей с кешированием.
    /// </summary>
    [Test]
    public void Example_IdentityCache()
    {
        var cacheSize = 100_000;
        using var identityCache = CreateIdentityCache(cacheSize);

        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();

        var identites = new HashSet<long>();
        for (var count = 0; count < 5 * cacheSize; ++count)
        {
            using var mappersSession = mappers.OpenSession();

            // Получить идентити из генератора.
            var identity = identityCache.GetNextIdentity(mappersSession);

            Assert.IsFalse(identites.Contains(identity));
            identites.Add(identity);

            mappersSession.Commit();
        }

        Console.WriteLine($"Количество идентити : {identites.Count}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache}");
            Console.WriteLine($"Количество идентити полученных из БД : {snapShot.CountIdentityFromStorage}");
        }

        {
            var snapShot = mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions}");
        }
    }

    /// <summary>
    /// Асинхронный генератор уникальных первичных ключей с кешированием.
    /// </summary>
    [Test]
    public async ValueTask Example_IdentityCache_Async()
    {
        var cacheSize = 100_000;
        using var identityCache = CreateIdentityCache(cacheSize);

        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();

        var identites = new HashSet<long>();
        for (var count = 0; count < 5 * cacheSize; ++count)
        {
            await using var mappersSession = await mappers.OpenSessionAsync();

            // Получить идентити из генератора.
            var identity = await identityCache.GetNextIdentityAsync(mappersSession);

            Assert.IsFalse(identites.Contains(identity));
            identites.Add(identity);

            await mappersSession.CommitAsync();
        }

        Console.WriteLine($"Количество идентити : {identites.Count}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache}");
            Console.WriteLine($"Количество идентити полученных из БД : {snapShot.CountIdentityFromStorage}");
        }

        {
            var snapShot = mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions}");
        }
    }

    #region Enviroment

    private string m_dbName;

    [SetUp]
    public void SetUp()
    {
        BaseAutoTestsMapper.CreateDb(out m_dbName, out var dbConnectionString);

        // Настройка окружения.
        var timeService = new TimeService();
        var mappers = new Generated.Implements.Mappers(new MappersExceptionPolicy(), dbConnectionString, timeService);

        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()))
            .SetTimeService(timeService)
            .SetExceptionPolicy(new ExceptionPolicy(timeService))
            .SetMappers(mappers)
            .Build();

        // Object_A - Определение кэша записей БД в памяти на уровне маппера.
        var mapper = MapperObject_A.NewWithCache(mappers, timeService);
        mappers.ReplaceMapper(mapper);
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();

        SqlServerDbHelper.DropDb(m_dbName);
    }

    #endregion

    #region Helpers

    private IIdentityCache CreateIdentityCache(int cacheSize)
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = mappers.GetMapper<IMapperObject_A>();

        var result =
            new IdentityCache<IMapperObject_A>(
                Guid.NewGuid(),
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.Object_A)}'.",
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.Object_A)}'.",
                ServiceProviderHolder.Instance.GetRequiredService<ITimeService>(),
                ServiceProviderHolder.Instance.GetRequiredService<IExceptionPolicy>(),
                TimeSpan.FromMinutes(5),
                mapper,
                cacheSize,
                fillFactor: 0.4f,
                methodGetNextIdentity:
                new PairMethods<
                    Func<IMapperObject_A, IMappersSession, long>,
                    Func<IMapperObject_A, IMappersSession, CancellationToken, ValueTask<long>>>(
                    (mapperObjectA, mappersSession)
                        => mapperObjectA.GetNextId(mappersSession),
                    (mapperObjectA, mappersSession, cancellationToken)
                        => mapperObjectA.GetNextIdAsync(mappersSession, cancellationToken)),
                methodGetNextIdentityList: (m, session, count) => m.GetNextIds(session, count));

        // Прогрев кэша генератора.
        using var mappersSession = mappers.OpenSession();
        result.Initialize(mappersSession);
        mappersSession.Commit();

        return result;
    }

    #endregion
}

