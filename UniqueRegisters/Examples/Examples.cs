using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects;
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
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
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
    /// Создание миллионов ключей в БД и почти мгновенный холодный старт рееста с 100% ключами в памяти.
    /// </summary>
    [Test]
    [Explicit]
    [TestCase(1_000_000)]
    [TestCase(5_000_000)]
    [TestCase(10_000_000)]
    [TestCase(50_000_000)]
    [TestCase(100_000_000)]
    public void Example_Start(int сountKeys)
    {
        var keys = new List<(Guid Key, long Tag)>();

        #region Создание миллионов ключей в БД.

        var startMappersSnapShot = m_mappers.InfrastructureMonitor.GetSnapShot();

        Console.WriteLine($"Создание миллионов ключей в БД.");
        Console.WriteLine("");

        var stopwatch = Stopwatch.StartNew();

        for (int i = 0; i < сountKeys; i++)
        {
            var key = (Guid.NewGuid(), ProviderRandomValues.GetInt64());
            keys.Add(key);
        }

        using var registerTransactionKeys = CreateRegisterTransactionKeys();

        BaseTests.GcCollectMemory();
        var startMemory = GC.GetTotalMemory(true);

        Parallel.ForEach(keys,
            key =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    Assert.AreEqual(UniqueRegisterRegisterKeyResult.Registered, registerTransactionKeys.TryRegisterKey(key.Item1, key.Item2));

                    unitOfWork.Commit();
                }
            });

        BaseTests.GcCollectMemory();
        var step1Memory = GC.GetTotalMemory(true);

        // Смещение времени на 2 дня вперёд.
        m_timeService.SetOffeset(TimeSpan.FromDays(2));

        // Ожидание пока реестр оптимизирует свою память и сохранить оптимизированные ключи в файловый кэш.
        WaitHelpers.TimeOut(
            () => registerTransactionKeys.InfrastructureMonitor.GetSnapShot().CountPersistentStorageGroupSaves == 1,
            TimeSpan.FromHours(1));

        BaseTests.GcCollectMemory();
        var step2Memory = GC.GetTotalMemory(true);

        stopwatch.Stop();

        Console.WriteLine($"Время заполнения реестра : {stopwatch.Elapsed}");
        Console.WriteLine($"Занято памяти (до оптимизации)    : {step1Memory - startMemory:##,###} байт");
        Console.WriteLine($"Занято памяти (после оптимизации) : {step2Memory - startMemory:##,###} байт");

        Parallel.ForEach(keys,
            key =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    Assert.IsTrue(registerTransactionKeys.TryGetTag(key.Key, out var tag));
                    Assert.AreEqual(key.Tag, tag);

                    unitOfWork.Commit();
                }
            });

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections - startMappersSnapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions - startMappersSnapShot.CountSessions:##,###}");
            startMappersSnapShot = snapShot;
        }

        {
            var snapShot = registerTransactionKeys.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Число зарегестрированных ключей : {snapShot.CountKeys:##,###}");
            Console.WriteLine($"Число регистраций ключей : {snapShot.CountRegisterKey:##,###}");
            Console.WriteLine($"Количество загрузок групп ключей из персистентного хранилища : {snapShot.CountPersistentStorageGroupLoads}");
            Console.WriteLine($"Количество сохранений групп ключей в персистентное хранилище : {snapShot.CountPersistentStorageGroupSaves}");
        }

        Console.WriteLine("");
        Console.WriteLine($"Содержимого файлового кэша для быстрого холодного старта '{registerTransactionKeys.DataPath}' :");
        foreach (var fileName in Directory.GetFiles(registerTransactionKeys.DataPath))
        {
            Console.WriteLine(Path.GetFileName(fileName));
        }

        #endregion

        Console.WriteLine("");
        Console.WriteLine($"Старт рееста на '{keys.Count:##,###}' ключах в БД и файловом кэше.");
        Console.WriteLine("");

        BaseTests.GcCollectMemory();
        startMemory = GC.GetTotalMemory(true);

        stopwatch = Stopwatch.StartNew();

        var registerTransactionKeys_2 = new ExampleRegisterTransactionKeys(m_identityCache, m_directory.BasePath);

        // Запуск реестра и ожидание его полной инициализации.
        registerTransactionKeys_2.Start();
        WaitHelpers.TimeOut(() => registerTransactionKeys_2.IsReady, TimeSpan.FromMinutes(1));

        stopwatch.Stop();

        BaseTests.GcCollectMemory();
        var step3Memory = GC.GetTotalMemory(true);

        Console.WriteLine($"Время создания и 100% инициализации реестра : {stopwatch.Elapsed}");
        Console.WriteLine($"Занято памяти : {step3Memory - startMemory:##,###} байт");

        Parallel.ForEach(keys,
            key =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    Assert.IsTrue(registerTransactionKeys_2.TryGetTag(key.Key, out var tag));
                    Assert.AreEqual(key.Tag, tag);

                    unitOfWork.Commit();
                }
            });

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections - startMappersSnapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions - startMappersSnapShot.CountSessions:##,###}");
        }

        {
            var snapShot = registerTransactionKeys_2.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Число зарегестрированных ключей : {snapShot.CountKeys:##,###}");
            Console.WriteLine($"Число регистраций ключей : {snapShot.CountRegisterKey}");
            Console.WriteLine($"Количество загрузок групп ключей из персистентного хранилища : {snapShot.CountPersistentStorageGroupLoads}");
            Console.WriteLine($"Количество сохранений групп ключей в персистентное хранилище : {snapShot.CountPersistentStorageGroupSaves}");
        }
    }

    /// <summary>
    /// Пример попытки регистрации ключа.
    /// </summary>
    [Test]
    public void Example_TryRegisterKey()
    {
        using var registerTransactionKeys = CreateRegisterTransactionKeys();

        var key = Guid.NewGuid();
        var tag = 111;

        Assert.IsFalse(registerTransactionKeys.ContainsKey(key));

        // Регистрация ключа.
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            // Ключ предварительно зарегистрирован. Для окончательной регистрации UnitOfWork должен быть подтверждён.
            Assert.AreEqual(UniqueRegisterRegisterKeyResult.Registered, registerTransactionKeys.TryRegisterKey(key, tag));

            // Ключ не зарегистрирован т.к. ключ находится в процессе регистрации в текущем или параллельнорм не подтверждёном UnitOfWork.
            Assert.AreEqual(UniqueRegisterRegisterKeyResult.Locked, registerTransactionKeys.TryRegisterKey(key, tag));

            // Ключ не существует т.к. UnitOfWork с регистрацией ключа не подтверждён.
            Assert.IsFalse(registerTransactionKeys.ContainsKey(key));

            // Тэг не получен т.к. UnitOfWork с регистрацией ключа не подтверждён.
            Assert.IsFalse(registerTransactionKeys.TryGetTag(key, out _));

            unitOfWork.Commit();
        }

        // Проверка регистрации ключа.
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            Assert.IsTrue(registerTransactionKeys.ContainsKey(key));

            Assert.AreEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, tag));

            Assert.IsTrue(registerTransactionKeys.TryGetTag(key, out var registerTag));
            Assert.AreEqual(tag, registerTag);

            unitOfWork.Commit();
        }

        Console.WriteLine("После регистрации ключа :");
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

        // Массовая и параллельная попытка регистрации ключа.
        Parallel.For(0, 500_000,
            _ =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    Assert.AreEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, tag));

                    unitOfWork.Commit();
                }
            });

        Console.WriteLine("После попыток регистрации ключа :");
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

    /// <summary>
    /// Пример регистрации ключа.
    /// </summary>
    [Test]
    public void Example_RegisterKey()
    {
        using var registerTransactionKeys = CreateRegisterTransactionKeys();

        var key = Guid.NewGuid();
        var tag = 111;

        Assert.IsFalse(registerTransactionKeys.ContainsKey(key));

        // Регистрация ключа.
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            // Ключ предварительно зарегистрирован. Для окончательной регистрации UnitOfWork должен быть подтверждён.
            registerTransactionKeys.RegisterKey(key, tag);

            // Ключ не зарегистрирован т.к. ключ находится в процессе регистрации в текущем или параллельнорм не подтверждёном UnitOfWork.
            try
            {
                registerTransactionKeys.RegisterKey(key, tag);
                Assert.Fail();
            }
            catch (WorkflowException exception)
            {
                Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, exception.Code);
                Assert.IsTrue(exception.Details.Contains($@"Ключ '{key}' в неопределённом состоянии."));
            }

            // Ключ не существует т.к. UnitOfWork с регистрацией ключа не подтверждён.
            Assert.IsFalse(registerTransactionKeys.ContainsKey(key));

            // Тэг не получен т.к. UnitOfWork с регистрацией ключа не подтверждён.
            Assert.IsFalse(registerTransactionKeys.TryGetTag(key, out _));

            unitOfWork.Commit();
        }

        // Проверка регистрации ключа.
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            Assert.IsTrue(registerTransactionKeys.ContainsKey(key));

            Assert.IsTrue(registerTransactionKeys.TryGetTag(key, out var registerTag));
            Assert.AreEqual(tag, registerTag);

            unitOfWork.Commit();
        }

        Console.WriteLine("После регистрации ключа :");
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

        // Массовая и параллельная попытка регистрации ключа.
        Parallel.For(0, 500_000,
            _ =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    try
                    {
                        registerTransactionKeys.RegisterKey(key, tag);
                        Assert.Fail();
                    }
                    catch (WorkflowException exception)
                    {
                        Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, exception.Code);
                        Assert.IsTrue(exception.Details.Contains($@"Ключ '{key}' уже зарегистрирован."), exception.Details);
                    }

                    unitOfWork.Commit();
                }
            });

        Console.WriteLine("После попыток регистрации ключа :");
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

    /// <summary>
    /// Пример попытки регистрации с исключениями в рамках UnitOfWork.
    /// </summary>
    [Test]
    public void Example_TryRegisterKey_With_Exceptions()
    {
        using var registerTransactionKeys = CreateRegisterTransactionKeys();

        Console.WriteLine("До попыток регистрации ключа :");

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

        var key = Guid.NewGuid();

        // Регистрация ключа без подтверждения UnitOfWork.
        // Регистрация ключа автоматически отменяется.
        Parallel.For(0, 100_000,
            _ =>
            {
                using (m_entryPoint.CreateUnitOfWork())
                {
                    Assert.AreNotEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, 1));
                }
            });

        // Регистрация ключа без подтверждения UnitOfWork.
        // Регистрация ключа автоматически отменяется.
        Parallel.For(0, 100_000,
            _ =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    Assert.AreNotEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, 1));

                    unitOfWork.Rollback();
                }
            });

        // Регистрация ключа без подтверждения UnitOfWork из-за исклоючения.
        // Регистрация ключа автоматически отменяется.
        Parallel.For(0, 100_000,
            _ =>
            {
                try
                {
                    using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                    {
                        Assert.AreNotEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, 1));

                        throw new ApplicationException();
                    }
                }
                catch (ApplicationException)
                {
                    /* NONE */
                }
            });

        Assert.IsFalse(registerTransactionKeys.ContainsKey(key));

        Console.WriteLine("После попыток регистрации ключа :");

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

        // Запуск реестра и ожидание его полной инициализации.
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
