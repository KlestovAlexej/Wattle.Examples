using System;
using System.Diagnostics.CodeAnalysis;
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
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Utils;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements;

[TestFixture]
public class ExamplesMapperObject_A : BaseExamplesMapper
{
    //private MapperObject_A m_mapper;
    //m_mapper = (MapperObject_A) mappers.GetMapper<IMapperObject_A>();

    /// <summary>
    /// Генератор уникальных первичных ключей с кешированием.
    /// </summary>
    [Test]
    public void Example_IdentityCache()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

        using var identityCache =
            new IdentityCache<IMapperObject_A>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperObject_A)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                ServiceProviderHolder.Instance.GetRequiredService<ITimeService>(),
                ServiceProviderHolder.Instance.GetRequiredService<IExceptionPolicy>(),
                TimeSpan.FromMinutes(5),
                mapper,
                100_000,
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
            identityCache.Initialize(mappersSession);

            mappersSession.Commit();
        }

        for (var count = 0; count < 100_000; ++count)
        {
            // Получить идентити из генератора.
            using (var mappersSession = mappers.OpenSession())
            {
                var identity = identityCache.GetNextIdentity(mappersSession);
                Assert.AreEqual(count + 1, identity);

                mappersSession.Commit();
            }
        }

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
}

