using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.SystemMethods;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Interface;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Tests;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using ShtrihM.Wattle3.Testing.DomainObjects;
using ShtrihM.Wattle3.Utils;

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
        using var registerTransactionKeys = CreateRegisterTransactionKeys();

        var key = Guid.NewGuid();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            Assert.AreEqual(UniqueRegisterRegisterKeyResult.Registered, registerTransactionKeys.TryRegisterKey(key, 1));

            unitOfWork.Commit();
        }

        Parallel.For(0, 1_000_000,
            _ =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    Assert.AreEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, 2));

                    unitOfWork.Commit();
                }
            });

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions}");
        }

        {
            var snapShot = registerTransactionKeys.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Число зарегестрированных ключей : {snapShot.CountKeys}");
            Console.WriteLine($"Число регистраций ключей : {snapShot.CountRegisterKey}");
        }
    }

    #region Enviroment

    private string m_dbName;
    private TestDirectory m_directory;
    private IIdentityCache m_identityCache;
    private IEntryPoint m_entryPoint;
    private IMappers m_mappers;
    private ManagedTimeService m_timeService;
    private IMapperTransactionKey m_mapper;

    [SetUp]
    public void SetUp()
    {
        BaseAutoTestsMapper.CreateDb(out m_dbName, out var dbConnectionString);

        // Настройка окружения.
        var configurator = 
            DomainEnviromentConfigurator
                .Begin(LoggerFactory.Create(builder => builder.AddConsole()));

        m_timeService = new ManagedTimeService();
        m_mappers = new Generated.Implements.Mappers(new MappersExceptionPolicy(), dbConnectionString, m_timeService);
        var workflowExceptionPolicy = new WorkflowExceptionPolicy();
        var exceptionPolicy = new ExceptionPolicy(m_timeService);
        m_entryPoint = new ExampleEntryPoint(m_timeService, workflowExceptionPolicy, m_mappers, exceptionPolicy);
        m_mapper = m_mappers.GetMapper<IMapperTransactionKey>();

        configurator
            .SetTimeService(m_timeService)
            .SetExceptionPolicy(exceptionPolicy)
            .SetMappers(m_mappers)
            .SetWorkflowExceptionPolicy(workflowExceptionPolicy)
            .SetUnitOfWorkProvider()
            .SetEntryPoint(m_entryPoint)
            .Build();

        m_directory = new TestDirectory("Data");
        m_identityCache = CreateIdentityCache();
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();

        PostgreSqlDbHelper.DropDb(m_dbName);
        m_directory.SilentDispose();
        m_identityCache.SilentDispose();
    }

    public class ExampleUnitOfWork : BaseUnitOfWork
    {
        public ExampleUnitOfWork(
            UnitOfWorkContext unitOfWorkContext,
            ProxyDomainObjectRegisters registers,
            IUnitOfWorkVisitor visitor,
            bool addStackTrace)
            : base(
                unitOfWorkContext,
                registers,
                visitor,
                addStackTrace)
        {
        }
    }

    public class ExampleEntryPoint : BaseEntryPoint
    {
        private readonly ProxyDomainObjectRegisterFactory m_proxyDomainObjectRegisterFactories;
        private readonly UnitOfWorkContext m_unitOfWorkContext;

        public ExampleEntryPoint(
            ITimeService timeService,
            IWorkflowExceptionPolicy workflowExceptionPolicy,
            IMappers mappers,
            IExceptionPolicy exceptionPolicy)
            : base(timeService)
        {
            Initialize(
                workflowExceptionPolicy,
                new DomainObjectDataMappers(),
                new DomainObjectRegisters(timeService),
                new UnitOfWorkServiceFactoriesRegister().Add(GetType().Assembly),
                new SystemMethodRegisters(),
                new InfrastructureMonitorEntryPoint(this, TimeSpan.FromMinutes(15), timeService));

            m_proxyDomainObjectRegisterFactories = new ProxyDomainObjectRegisterFactory();
            m_proxyDomainObjectRegisterFactories.AddFactories(GetType().Assembly);

            m_unitOfWorkContext =
                new UnitOfWorkContext(
                    this,
                    m_dataMappers,
                    m_unitOfWorkServiceFactoriesRegister,
                    mappers,
                    exceptionPolicy,
                    workflowExceptionPolicy);
        }

        protected override IUnitOfWork DoCreateUnitOfWork(IUnitOfWorkVisitor visitor, object context)
        {
            var registers = new ProxyDomainObjectRegisters(m_registers, m_proxyDomainObjectRegisterFactories);
            var result = new ExampleUnitOfWork(m_unitOfWorkContext, registers, visitor, true);

            return result;
        }
    }
    #endregion

    #region Helpers

    private ExampleRegisterTransactionKeys CreateRegisterTransactionKeys()
    {
        var result = new ExampleRegisterTransactionKeys(m_identityCache, m_directory.BasePath);

        // Создать партицию БД для хранения ключей за текущий день.
        using (var mappersSession = m_mappers.OpenSession())
        {
            var nowDayIndex = result.GetDayIndex(m_timeService.NowDateTime.Date);
            m_mapper.Partitions.CreatePartition(mappersSession, nowDayIndex, nowDayIndex + 1);

            mappersSession.Commit();
        }

        // Запуск реестра и лжидание его полной инициализации.
        result.Start();
        WaitHelpers.TimeOut(() => result.IsReady, TimeSpan.FromMinutes(1));

        return result;
    }

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
