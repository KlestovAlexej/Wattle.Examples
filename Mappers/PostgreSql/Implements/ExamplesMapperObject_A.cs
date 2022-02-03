using System;
using System.Linq;
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
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Common;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Primitives;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements;

[TestFixture]
public class ExamplesMapperObject_A : BaseExamplesMapper
{
    /// <summary>
    /// Создание записей в таблице БД.
    /// </summary>
    [Test]
    public void Example_Insert()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        var groupId = 1;

        // Создание партиции таблицы.
        using (var mappersSession = mappers.OpenSession())
        {
            mapper.Partitions.CreatePartition(mappersSession, groupId, groupId + 1);

            mappersSession.Commit();
        }

        var id = ComplexIdentity.Build(mapper.Partitions.Level, groupId, 1);

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

        var groupId = 1;

        // Создание партиции таблицы.
        await using (var mappersSession = await mappers.OpenSessionAsync())
        {
            await mapper.Partitions.CreatePartitionAsync(mappersSession, groupId, groupId + 1);

            await mappersSession.CommitAsync();
        }

        var id = ComplexIdentity.Build(mapper.Partitions.Level, groupId, 1);

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

        var groupId = 1;

        // Создание партиции таблицы.
        using (var mappersSession = mappers.OpenSession())
        {
            mapper.Partitions.CreatePartition(mappersSession, groupId, groupId + 1);

            mappersSession.Commit();
        }

        // Заполнение таблицы.
        using (var mappersSession = mappers.OpenSession())
        {
            mapper.New(
                mappersSession,
                new Object_ADtoNew
                {
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, groupId, 1),
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
                    Id = ComplexIdentity.Build(mapper.Partitions.Level, groupId, 2),
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

        Console.WriteLine("Все записи отсортированные по убыванию по колонке Value_Long :");

        using (var mappersSession = mappers.OpenSession())
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
    /// Управление партициями таблицы БД.
    /// </summary>
    [Test]
    public void Example_Partitions()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        using (var mappersSession = mappers.OpenSession())
        {
            Assert.AreEqual(0, mapper.Partitions.GetExistsPartitions(mappersSession).Count);
        }

        Console.WriteLine("Создание партиции для группы [1 ; 2).");

        using (var mappersSession = mappers.OpenSession())
        {
            mapper.Partitions.CreatePartition(mappersSession, 1, 2);

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
        {
            var existsPartitions = mapper.Partitions.GetExistsPartitions(mappersSession);
            Assert.AreEqual(1, existsPartitions.Count);

            Console.WriteLine(existsPartitions[0].ToJsonText(true));
        }

        Console.WriteLine("Создание партиции по умолчанию.");

        using (var mappersSession = mappers.OpenSession())
        {
            mapper.Partitions.CreatedDefaultPartition(mappersSession);

            mappersSession.Commit();
        }

        using (var mappersSession = mappers.OpenSession())
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

        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();

        var identitesCount = 50 * cacheSize;
        for (var count = 0; count < identitesCount; ++count)
        {
            using var mappersSession = mappers.OpenSession();

            // Получить идентити из генератора.
            var identity = identityCache.GetNextIdentity(mappersSession);

            Assert.AreEqual(count + 1, identity);

            mappersSession.Commit();
        }

        Console.WriteLine($"Количесто идентити  : {identitesCount}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количесто идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache}");
            Console.WriteLine($"Количесто идентити полученных из БД : {snapShot.CountIdentityFromStorage}");
        }

        {
            var snapShot = mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количесто подключений к БД : {snapShot.CountDbConnections}");
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

        var identitesCount = 50 * cacheSize;
        for (var count = 0; count < identitesCount; ++count)
        {
            await using var mappersSession = await mappers.OpenSessionAsync();

            // Получить идентити из генератора.
            var identity = await identityCache.GetNextIdentityAsync(mappersSession);

            Assert.AreEqual(count + 1, identity);

            await mappersSession.CommitAsync();
        }

        Console.WriteLine($"Количесто идентити  : {identitesCount}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количесто идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache}");
            Console.WriteLine($"Количесто идентити полученных из БД : {snapShot.CountIdentityFromStorage}");
        }

        {
            var snapShot = mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количесто подключений к БД : {snapShot.CountDbConnections}");
        }
    }

    #region Enviroment

    [SetUp]
    public void SetUp()
    {
        var timeService = new TimeService();
        var mappers = new Generated.Implements.Mappers(new MappersExceptionPolicy(), m_dbConnectionString, timeService);

        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()))
            .SetTimeService(timeService)
            .SetExceptionPolicy(new ExceptionPolicy(timeService))
            .SetMappers(mappers)
            .Build();
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();
    }

    #endregion

    #region Helpers

    private IIdentityCache CreateIdentityCache(int cacheSize)
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = mappers.GetMapper<IMapperObject_A>();

        var result =
            new IdentityCache<IMapperObject_A>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperObject_A)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
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
                    (mapper, mappersSession)
                        => mapper.GetNextId(mappersSession),
                    (mapper, mappersSession, cancellationToken)
                        => mapper.GetNextIdAsync(mappersSession, cancellationToken)),
                methodGetNextIdentityList: (m, session, count) => m.GetNextIds(session, count));

        // Прогрев кэша генератора.
        using (var mappersSession = mappers.OpenSession())
        {
            result.Initialize(mappersSession);

            mappersSession.Commit();
        }

        return result;
    }

    #endregion
}

