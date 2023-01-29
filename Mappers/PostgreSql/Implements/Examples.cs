using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Common;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.PostgreSql.Implements;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests;
using ShtrihM.Wattle3.Json.Extensions;

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements;

[TestFixture]
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
public class Examples
{
    /// <summary>
    /// Сокрытие записи, без её физического удаления из БД.
    /// </summary>
    [Test]
    public void Example_Hide()
    {
        var mapper = m_mappers.GetMapper<IMapperObject_B>();

        var id_1 = 1;

        // Создать запись.
        using (var mappersSession = m_mappers.OpenSession())
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
        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = mapper.Get(hostMappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            var mappersSession = hostMappersSession.GetMappersSession();

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
        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = mapper.Get(hostMappersSession, id_1);
            Assert.IsNull(dbDto);

            var mappersSession = hostMappersSession.GetMappersSession();

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
        var mapper = m_mappers.GetMapper<IMapperObject_B>();

        var id_1 = 1;

        // Создать запись.
        await using (var mappersSession = await m_mappers.OpenSessionAsync())
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
        await using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = (Object_BDtoActual)await mapper.GetAsync(hostMappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            var mappersSession = await hostMappersSession.GetMappersSessionAsync();

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
        await using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = await mapper.GetAsync(hostMappersSession, id_1);
            Assert.IsNull(dbDto);

            var mappersSession = await hostMappersSession.GetMappersSessionAsync();

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
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);

        // Создать запись.
        using (var mappersSession = m_mappers.OpenSession())
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
        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = mapper.Get(hostMappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            var mappersSession = hostMappersSession.GetMappersSession();

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
        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = mapper.Get(hostMappersSession, id_1);
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
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);

        // Создать запись.
        using (var mappersSession = m_mappers.OpenSession())
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
        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = mapper.Get(hostMappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            var mappersSession = hostMappersSession.GetMappersSession();

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
        using (var mappersSession = m_mappers.OpenSession())
        {
            Assert.IsFalse(mapper.Exists(mappersSession, id_1));
        }
    }

    /// <summary>
    /// Асинхронное физическое удаление записи.
    /// </summary>
    [Test]
    public async ValueTask Example_Delete_Async()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        await using (var mappersSession = await m_mappers.OpenSessionAsync())
        {
            await mapper.Partitions.CreatedDefaultPartitionAsync(mappersSession);

            await mappersSession.CommitAsync();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);

        // Создать запись.
        await using (var mappersSession = await m_mappers.OpenSessionAsync())
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
        await using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = (Object_ADtoActual)await mapper.GetAsync(hostMappersSession, id_1);
            Assert.IsNotNull(dbDtoActual);

            var mappersSession = await hostMappersSession.GetMappersSessionAsync();

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
        await using (var mappersSession = await m_mappers.OpenSessionAsync())
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
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);

        using (var mappersSession = m_mappers.OpenSession())
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

        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = mapper.Get(hostMappersSession, id_1);

            var mappersSession = hostMappersSession.GetMappersSession();

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

        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = mapper.Get(hostMappersSession, id_1);
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
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);

        using (var mappersSession = m_mappers.OpenSession())
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

        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = mapper.Get(hostMappersSession, id_1);

            var mappersSession = hostMappersSession.GetMappersSession();

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

        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = mapper.Get(hostMappersSession, id_1);
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
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        await using (var mappersSession = await m_mappers.OpenSessionAsync())
        {
            await mapper.Partitions.CreatedDefaultPartitionAsync(mappersSession);

            await mappersSession.CommitAsync();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);

        await using (var mappersSession = await m_mappers.OpenSessionAsync())
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

        await using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDtoActual = (Object_ADtoActual)await mapper.GetAsync(hostMappersSession, id_1);

            var mappersSession = await hostMappersSession.GetMappersSessionAsync();

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

        await using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = await mapper.GetAsync(hostMappersSession, id_1);
            Console.WriteLine("Запись в БД после изменения :");
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Выборка записей по первичному ключу с использовантием кеша в памяти.
    /// </summary>
    [Test]
    public void Example_Select_With_MemoryCache()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        var id_1 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1);
        var id_2 = ComplexIdentity.Build(mapper.Partitions.Level, 0, 2);

        // Заполнение таблицы.
        using (var mappersSession = m_mappers.OpenSession())
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

        var stopwatch = Stopwatch.StartNew();

        // Выборка записей по первичному ключу.
        for (var index = 0; index < 1_000_000; index++)
        {
            var hostMappersSession = m_mappers.CreateHostMappersSession();

            mapper.Get(hostMappersSession, id_1);
            mapper.Get(hostMappersSession, id_2);
        }

        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto_1 = mapper.Get(hostMappersSession, id_1);
            Console.WriteLine(dbDto_1.ToJsonText(true));

            var dbDto_2 = mapper.Get(hostMappersSession, id_2);
            Console.WriteLine(dbDto_2.ToJsonText(true));
        }

        stopwatch.Stop();

        Console.WriteLine($"Время выборки : {stopwatch.Elapsed}");

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }

        {
            var snapShot = mapper.InfrastructureMonitor.InfrastructureMonitorActualDtoCache.GetSnapShot();
            Console.WriteLine($"Количество объектов в памяти : {snapShot.Count:##,###}");
            Console.WriteLine($"Количество поисков объектов в памяти : {snapShot.CountFind:##,###}");
            Console.WriteLine($"Количество найденных объектов в памяти : {snapShot.CountFound:##,###}");
        }
    }

    /// <summary>
    /// Выборка записей по первичному ключу с использовантием кеша в памяти в параллельном режиме.
    /// </summary>
    [Test]
    public void Example_Select_With_MemoryCache_Parallel()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        var ids = new List<long>();
        for (var index = 0; index < 1_000; index++)
        {
            var id = ComplexIdentity.Build(mapper.Partitions.Level, 0, index);
            ids.Add(id);
        }

        // Заполнение таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            foreach (var id in ids)
            {
                mapper.New(
                    mappersSession,
                    new Object_ADtoNew
                    {
                        Id = id,
                        Value_DateTime = DateTime.Now,
                        Value_DateTime_NotUpdate = DateTime.Now,
                        Value_Int = null,
                        Value_Long = id,
                        Value_String = $"Text {id}",
                    });
            }

            mappersSession.Commit();
        }

        var stopwatch = Stopwatch.StartNew();

        // Выборка записей по первичному ключу.
        Parallel.For(0, 10_000_000,
            _ =>
            {
                using var hostMappersSession = m_mappers.CreateHostMappersSession();

                var id = ProviderRandomValues.GetItem(ids);
                var dto = mapper.Get(hostMappersSession, id);
                Assert.IsNotNull(dto);
            });

        stopwatch.Stop();

        Console.WriteLine($"Время работы : {stopwatch.Elapsed}");

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }

        {
            var snapShot = mapper.InfrastructureMonitor.InfrastructureMonitorActualDtoCache.GetSnapShot();
            Console.WriteLine($"Количество объектов в памяти : {snapShot.Count:##,###}");
            Console.WriteLine($"Количество поисков объектов в памяти : {snapShot.CountFind:##,###}");
            Console.WriteLine($"Количество найденных объектов в памяти : {snapShot.CountFound:##,###}");
        }
    }

    /// <summary>
    /// Создание записей в таблице БД.
    /// </summary>
    [Test]
    public void Example_Insert()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        var partitionId = 67;

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatePartition(mappersSession, partitionId, partitionId + 1);

            mappersSession.Commit();
        }

        var id = ComplexIdentity.Build(mapper.Partitions.Level, partitionId, 1);

        using (var mappersSession = m_mappers.OpenSession())
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

        using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = mapper.Get(hostMappersSession, id);
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Асинхронное создание записей в таблице БД.
    /// </summary>
    [Test]
    public async ValueTask Example_Insert_Async()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        var partitionId = 67;

        // Создание партиции таблицы.
        await using (var mappersSession = await m_mappers.OpenSessionAsync())
        {
            await mapper.Partitions.CreatePartitionAsync(mappersSession, partitionId, partitionId + 1);

            await mappersSession.CommitAsync();
        }

        var id = ComplexIdentity.Build(mapper.Partitions.Level, partitionId, 1);

        await using (var mappersSession = await m_mappers.OpenSessionAsync())
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

        await using (var hostMappersSession = m_mappers.CreateHostMappersSession())
        {
            var dbDto = await mapper.GetAsync(hostMappersSession, id);
            Console.WriteLine(dbDto.ToJsonText(true));
        }
    }

    /// <summary>
    /// Выборка записей по условию.
    /// </summary>
    [Test]
    public void Example_Select()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        // Заполнение таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1),
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
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, 0, 2),
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 600,
                    Value_String = "Text",
                });

            mappersSession.Commit();
        }

        using (var mappersSession = m_mappers.OpenSession())
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

        Console.WriteLine("Все записи отсортированные по убыванию по колонке Value_Long :");

        using (var mappersSession = m_mappers.OpenSession())
        {
            var queryText =
                SchemaQueriesProvider
                    .QueryForObject_A("ORDER Value_Long DESC")
                    .GetQuery();
            var selectFilter = mapper.CreateSelectFilter(queryText);

            var dbDtos = mapper.GetEnumerator(mappersSession, selectFilter).ToList();
            Assert.AreEqual(2, dbDtos.Count);

            Console.WriteLine(dbDtos[0].ToJsonText(true));
            Console.WriteLine(dbDtos[1].ToJsonText(true));
        }
    }

    /// <summary>
    /// Постраниякая выборка записей.
    /// </summary>
    [Test]
    public void Example_Select_Paged()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        // Создание партиции таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        // Заполнение таблицы.
        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, 0, 1),
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
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, 0, 2),
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = null,
                    Value_Long = 600,
                    Value_String = "Text 2",
                });
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, 0, 3),
                    Value_DateTime = DateTime.Now,
                    Value_DateTime_NotUpdate = DateTime.Now,
                    Value_Int = 333,
                    Value_Long = 3003,
                    Value_String = "Text 3",
                });

            mappersSession.Commit();
        }

        using (var mappersSession = m_mappers.OpenSession())
        {
            var queryText =
                SchemaQueriesProvider
                    .QueryForObject_A("ORDER Id DESC")
                    .GetQuery();
            var selectFilter = mapper.CreateSelectFilter(queryText);

            var dbDtosPage1 = mapper.GetEnumeratorPage(mappersSession, pageIndex: 1, pageSize: 2, selectFilter).ToList();
            Assert.AreEqual(2, dbDtosPage1.Count);
            Console.WriteLine("Страника №1 :");
            Console.WriteLine(dbDtosPage1[0].ToJsonText(true));
            Console.WriteLine(dbDtosPage1[1].ToJsonText(true));

            var dbDtosPage2 = mapper.GetEnumeratorPage(mappersSession, pageIndex: 2, pageSize: 2, selectFilter).ToList();
            Assert.AreEqual(1, dbDtosPage2.Count);
            Console.WriteLine("Страника №2 :");
            Console.WriteLine(dbDtosPage2[0].ToJsonText(true));

            var dbDtosPage3 = mapper.GetEnumeratorPage(mappersSession, pageIndex: 3, pageSize: 2, selectFilter).ToList();
            Assert.AreEqual(0, dbDtosPage3.Count);
        }
    }

    /// <summary>
    /// Управление партициями таблицы БД.
    /// </summary>
    [Test]
    public void Example_Partitions()
    {
        var mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();

        using (var mappersSession = m_mappers.OpenSession())
        {
            Assert.AreEqual(0, mapper.Partitions.GetExistsPartitions(mappersSession).Count);
        }

        Console.WriteLine("Создание партиции для группы [1 ; 2).");

        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatePartition(mappersSession, 1, 2);

            mappersSession.Commit();
        }

        using (var mappersSession = m_mappers.OpenSession())
        {
            var existsPartitions = mapper.Partitions.GetExistsPartitions(mappersSession);
            Assert.AreEqual(1, existsPartitions.Count);

            Console.WriteLine(existsPartitions[0].ToJsonText(true));
        }

        Console.WriteLine("Создание партиции по умолчанию.");

        using (var mappersSession = m_mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        using (var mappersSession = m_mappers.OpenSession())
        {
            Console.WriteLine($"DefaultPartitionName : {mapper.Partitions.DefaultPartitionName}");

            var existsPartitions = mapper.Partitions.GetExistsPartitions(mappersSession);
            Assert.AreEqual(1, existsPartitions.Count);

            Console.WriteLine(existsPartitions[0].ToJsonText(true));
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

        var stopwatch = Stopwatch.StartNew();

        var identites = new HashSet<long>();
        for (var count = 0; count < 50 * cacheSize; ++count)
        {
            using var mappersSession = m_mappers.OpenSession();

            var identity = identityCache.GetNextIdentity(mappersSession);

            Assert.IsFalse(identites.Contains(identity));
            identites.Add(identity);

            mappersSession.Commit();
        }

        stopwatch.Stop();

        Console.WriteLine($"Время работы : {stopwatch.Elapsed}");
        Console.WriteLine($"Количество идентити : {identites.Count:##,###}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache:##,###}");
            Console.WriteLine($"Количество идентити полученных из БД : {snapShot.CountIdentityFromStorage:##,###}");
        }

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Генератор уникальных первичных ключей с кешированием в параллельном режиме.
    /// </summary>
    [Test]
    public void Example_IdentityCache_Parallel()
    {
        const int CacheSize = 100_000;
        using var identityCache = CreateIdentityCache(CacheSize);

        var stopwatch = Stopwatch.StartNew();

        var identites = new HashSet<long>();
        Parallel.For(0, 500 * CacheSize,
            _ =>
            {
                using var mappersSession = m_mappers.OpenSession();

                var identity = identityCache.GetNextIdentity(mappersSession);

                lock (identites)
                {
                    Assert.IsFalse(identites.Contains(identity));
                    identites.Add(identity);
                }

                mappersSession.Commit();
            });

        stopwatch.Stop();

        Console.WriteLine($"Время работы : {stopwatch.Elapsed}");
        Console.WriteLine($"Количество идентити : {identites.Count:##,###}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache:##,###}");
            Console.WriteLine($"Количество идентити полученных из БД : {snapShot.CountIdentityFromStorage:##,###}");
        }

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
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

        var stopwatch = Stopwatch.StartNew();

        var identites = new HashSet<long>();
        for (var count = 0; count < 50 * cacheSize; ++count)
        {
            await using var mappersSession = await m_mappers.OpenSessionAsync();

            // Получить идентити из генератора.
            var identity = await identityCache.GetNextIdentityAsync(mappersSession);

            Assert.IsFalse(identites.Contains(identity));
            identites.Add(identity);

            await mappersSession.CommitAsync();
        }

        stopwatch.Stop();

        Console.WriteLine($"Время работы : {stopwatch.Elapsed}");
        Console.WriteLine($"Количество идентити : {identites.Count:##,###}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache:##,###}");
            Console.WriteLine($"Количество идентити полученных из БД : {snapShot.CountIdentityFromStorage:##,###}");
        }

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    #region Enviroment

    private string m_dbName;
    private IMappers m_mappers;
    private ILoggerFactory m_loggerFactory;
    private ITimeService m_timeService;
    private IExceptionPolicy m_exceptionPolicy;
    private IWorkflowExceptionPolicy m_workflowExceptionPolicy;

    [SetUp]
    public void SetUp()
    {
        BaseAutoTestsMapper.CreateDb(out m_dbName, out var dbConnectionString);

        // Настройка окружения.
        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()), out m_loggerFactory, out _)
            .Build();

        m_timeService = new TimeService();

        var mappers = 
            new Generated.PostgreSql.Implements.Mappers(
                new MappersExceptionPolicy(), 
                dbConnectionString, 
                m_timeService, 
                WellknownInfrastructureMonitors.Mappers, 
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers), 
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers));
        m_mappers = mappers;

        m_workflowExceptionPolicy = new WorkflowExceptionPolicy();
        m_exceptionPolicy =
            new ExceptionPolicy(
                m_timeService,
                m_loggerFactory.CreateLogger<ExceptionPolicy>(),
                m_workflowExceptionPolicy);

        // Object_A - Определение кэша записей БД в памяти на уровне маппера.
        var mapper = MapperObject_A.NewWithCache(mappers, m_timeService, m_exceptionPolicy);
        mappers.ReplaceMapper(mapper);
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();

        PostgreSqlDbHelper.DropDb(m_dbName);
    }

    #endregion

    #region Helpers

    private IIdentityCache CreateIdentityCache(int cacheSize)
    {
        var mapper = m_mappers.GetMapper<IMapperObject_A>();
        var result =
            new IdentityCache<IMapperObject_A>(
                Guid.NewGuid(),
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.Object_A)}'.",
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.Object_A)}'.",
                m_timeService,
                m_exceptionPolicy,
                m_workflowExceptionPolicy,
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
                methodGetNextIdentityList: (m, session, count, cancellationToken) => m.GetNextIds(session, count, cancellationToken),
                logger: m_loggerFactory.CreateLogger<IdentityCache<IMapperObject_A>>());

        // Прогрев кэша генератора.
        using var mappersSession = m_mappers.OpenSession();
        result.Initialize(mappersSession, CancellationToken.None);
        mappersSession.Commit();

        return result;
    }

    #endregion
}
