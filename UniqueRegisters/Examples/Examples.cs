using System;
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
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Interface;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Tests;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Examples;

[TestFixture]
public class Examples
{
    /// <summary>
    /// Сокрытие записи, без её физического удаления из БД.
    /// </summary>
    [Test]
    public void Example_Hide()
    {
        using var directory = new TestDirectory("Data");
        using var identityCache = CreateIdentityCache();
        using var registerTransactionKeys = new ExampleRegisterTransactionKeys(identityCache, directory.BasePath);

        registerTransactionKeys.Start();
        WaitHelpers.TimeOut(() => registerTransactionKeys.IsReady, TimeSpan.FromMinutes(1));

        registerTransactionKeys.Stop();
    }

    #region Enviroment

    private string m_dbName;

    [SetUp]
    public void SetUp()
    {
        BaseAutoTestsMapper.CreateDb(out m_dbName, out var dbConnectionString);

        // Настройка окружения.
        var timeService = new TimeService();
        var mappers = new UniqueRegisters.Examples.Generated.Implements.Mappers(new MappersExceptionPolicy(), dbConnectionString, timeService);

        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()))
            .SetTimeService(timeService)
            .SetExceptionPolicy(new ExceptionPolicy(timeService))
            .SetMappers(mappers)
            .SetWorkflowExceptionPolicy(new WorkflowExceptionPolicy())
            .SetUnitOfWorkProvider()
            .Build();
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();

        PostgreSqlDbHelper.DropDb(m_dbName);
    }

    #endregion

    #region Helpers

    private IIdentityCache CreateIdentityCache()
    {
        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var mapper = mappers.GetMapper<IMapperTransactionKey>();

        var result =
            new IdentityCache<IMapperTransactionKey>(
                Guid.NewGuid(),
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.TransactionKey)}'.",
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.TransactionKey)}'.",
                ServiceProviderHolder.Instance.GetRequiredService<ITimeService>(),
                ServiceProviderHolder.Instance.GetRequiredService<IExceptionPolicy>(),
                TimeSpan.FromMinutes(5),
                mapper,
                100_000,
                fillFactor: 0.4f,
                methodGetNextIdentity:
                new PairMethods<
                    Func<IMapperTransactionKey, IMappersSession, long>,
                    Func<IMapperTransactionKey, IMappersSession, CancellationToken, ValueTask<long>>>(
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
