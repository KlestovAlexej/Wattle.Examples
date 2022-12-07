using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Common;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using ShtrihM.Wattle3.Testing.DomainObjects;
using ShtrihM.Wattle3.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Interface;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Tests;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Mappers.PostgreSql;

namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Examples;

[TestFixture]
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
[SuppressMessage("ReSharper", "AccessToModifiedClosure")]
public class Examples
{
    /// <summary>
    /// Создание миллионов ключей в БД и почти мгновенный холодный старт рееста с 100% ключами в памяти.
    ///
    /// Для стабильной работы.
    /// 
    /// В файле : postgresql.conf
    /// Установить параметр : max_connections = 300
    ///
    /// Параметры ПК для приблизительного определения времени теста :
    ///    OS Windows 11 Pro x64, CPU Intel Core i9-9900KS, RAM 48GB, SSD Samsung 970 Evo Plus 2Tb, DB PostgreSQL 15.1
    /// </summary>
    /// <param name="сountKeysPerDay">Количество ключей за один день.</param>
    /// <param name="days">Количество дней.</param>
    [Test]
    [Explicit]
    [TestCase(1_000, 10, Description = "Создать 10.000 ключей - время теста примерно менее 15 секунд")]
    [TestCase(100_000, 10, Description = "Создать 1 000 000 ключей - время теста примерно 3 минуты")]
    [TestCase(10_000_000, 10, Description = "Создать 100 000 000 ключей - время теста примерно 3 часа")]
    [TestCase(10_000_000, 30, Description = "Создать 300 000 000 ключей - время теста примерно 9 часов")]
    public void Example_Start(int сountKeysPerDay, int days)
    {
        var totalStopwatch = Stopwatch.StartNew();
        var keys = new List<(Guid Key, long Tag)>();

        #region Создание миллионов ключей в БД.

        var startMappersSnapShot = m_mappers.InfrastructureMonitor.GetSnapShot();

        Console.WriteLine("Создание миллионов ключей в БД.");
        Console.WriteLine("");

        var stopwatch = Stopwatch.StartNew();

        var registerTransactionKeys = CreateRegisterTransactionKeys();

        BaseTests.GcCollectMemory();
        var startMemory = GC.GetTotalMemory(true);

        var daysOffeset = TimeSpan.Zero;
        for (var dayIndex = 0; dayIndex < days; dayIndex++)
        {
            // Создать партицию БД для хранения ключей за текущий день.
            using (var mappersSession = m_mappers.OpenSession())
            {
                var nowDayIndex = registerTransactionKeys.GetDayIndex(m_timeService.NowDateTime.Date);
                if (false == m_mapper.Partitions.GetExistsPartitions(mappersSession).Any(p => p.MinGroupId == nowDayIndex))
                {
                    m_mapper.Partitions.CreatePartition(mappersSession, nowDayIndex, nowDayIndex + 1);
                }

                mappersSession.Commit();
            }

            var dayKeys = new List<(Guid Key, long Tag)>();
            for (var keyIndex = 0; keyIndex < сountKeysPerDay; keyIndex++)
            {
                var key = (Guid.NewGuid(), ProviderRandomValues.GetInt64());
                dayKeys.Add(key);
            }
            keys.AddRange(dayKeys);

            Parallel.ForEach(dayKeys,
                key =>
                {
                    using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                    Assert.AreEqual(UniqueRegisterRegisterKeyResult.Registered, registerTransactionKeys.TryRegisterKey(key.Key, key.Tag));

                    unitOfWork.Commit();
                });

            // Смещение времени на 1 день вперёд.
            daysOffeset += TimeSpan.FromDays(1);
            m_timeService.SetOffeset(daysOffeset);
        }

        BaseTests.GcCollectMemory();
        var step1Memory = GC.GetTotalMemory(true);

        // Смещение времени на 2 дня вперёд.
        daysOffeset += TimeSpan.FromDays(2);
        m_timeService.SetOffeset(daysOffeset);

        // Ожидание пока реестр оптимизирует свою память и сохранить оптимизированные ключи в файловый кэш.
        WaitHelpers.TimeOut(
            () => registerTransactionKeys.InfrastructureMonitor.GetSnapShot().CountPersistentStorageGroupSaves == days,
            TimeSpan.FromHours(1),
            () => registerTransactionKeys.InfrastructureMonitor.GetSnapShot().ToJsonText(true));

        BaseTests.GcCollectMemory();
        var step2Memory = GC.GetTotalMemory(true);

        stopwatch.Stop();

        Console.WriteLine($"Время заполнения реестра : {stopwatch.Elapsed}");
        Console.WriteLine($"Занято памяти (до оптимизации)    : {(step1Memory - startMemory):##,###} байт");
        Console.WriteLine($"Занято памяти (после оптимизации) : {(step2Memory - startMemory):##,###} байт");

        Parallel.ForEach(keys,
            key =>
            {
                using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                Assert.IsTrue(registerTransactionKeys.TryGetTag(key.Key, out var tag));
                Assert.AreEqual(key.Tag, tag);

                unitOfWork.Commit();
            });

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {(snapShot.CountDbConnections - startMappersSnapShot.CountDbConnections):##,###}");
            Console.WriteLine($"Количество реальных транзакций БД : {(snapShot.CountDbTransactions - startMappersSnapShot.CountDbTransactions):##,###}");
            Console.WriteLine($"Количество сессий мапперов : {(snapShot.CountSessions - startMappersSnapShot.CountSessions):##,###}");
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
        Console.WriteLine($"Содержимого файлового кэша для быстрого старта '{registerTransactionKeys.DataPath}' :");
        foreach (var fileName in Directory.GetFiles(registerTransactionKeys.DataPath))
        {
            Console.WriteLine(Path.GetFileName(fileName));
        }

        CommonWattleExtensions.SilentDisposeAndFree(ref registerTransactionKeys);

        #endregion

        BaseTests.GcCollectMemory();
        startMemory = GC.GetTotalMemory(true);

        Console.WriteLine("");
        Console.WriteLine($"Старт рееста на '{keys.Count:##,###}' ключах в БД и файловом кэше.");
        Console.WriteLine("");

        stopwatch = Stopwatch.StartNew();

        var registerTransactionKeys2 = 
            new ExampleRegisterTransactionKeys(
                m_identityCache, 
                m_directory.BasePath,
                m_entryPoint.UnitOfWorkProvider,
                m_loggerFactory,
                m_exceptionPolicy,
                m_timeService,
                m_mappers,
                m_workflowExceptionPolicy);

        // Запуск реестра и ожидание его полной инициализации.
        registerTransactionKeys2.Start();
        WaitHelpers.TimeOut(() => registerTransactionKeys2.IsReady, TimeSpan.FromMinutes(5));

        stopwatch.Stop();

        Console.WriteLine($"Время создания и 100% инициализации реестра : {stopwatch.Elapsed}");

        stopwatch = Stopwatch.StartNew();

        // Поиск всех ключей.
        Parallel.ForEach(keys,
            key =>
            {
                using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                Assert.IsTrue(registerTransactionKeys2.TryGetTag(key.Key, out var tag));
                Assert.AreEqual(key.Tag, tag);

                unitOfWork.Commit();
            });

        stopwatch.Stop();
        Console.WriteLine($"Время поиска всех ключей : {stopwatch.Elapsed}");

        BaseTests.GcCollectMemory();
        var step3Memory = GC.GetTotalMemory(true);
        Console.WriteLine($"Занято памяти : {(step3Memory - startMemory):##,###} байт");

        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество созданных Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }

        {
            var snapShot = m_mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {(snapShot.CountDbConnections - startMappersSnapShot.CountDbConnections):##,###}");
            Console.WriteLine($"Количество реальных транзакций БД : {snapShot.CountDbTransactions - startMappersSnapShot.CountDbTransactions}");
            Console.WriteLine($"Количество сессий мапперов : {(snapShot.CountSessions - startMappersSnapShot.CountSessions):##,###}");
        }

        {
            var snapShot = registerTransactionKeys2.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Число зарегестрированных ключей : {snapShot.CountKeys:##,###}");
            Console.WriteLine($"Число регистраций ключей : {snapShot.CountRegisterKey}");
            Console.WriteLine($"Количество загрузок групп ключей из персистентного хранилища : {snapShot.CountPersistentStorageGroupLoads}");
            Console.WriteLine($"Количество сохранений групп ключей в персистентное хранилище : {snapShot.CountPersistentStorageGroupSaves}");
        }

        CommonWattleExtensions.SilentDisposeAndFree(ref registerTransactionKeys2);

        totalStopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Полное время теста : {totalStopwatch.Elapsed}");
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
                using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                Assert.AreEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, tag));

                unitOfWork.Commit();
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
                using var unitOfWork = m_entryPoint.CreateUnitOfWork();

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
                using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                Assert.AreNotEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, 1));

                unitOfWork.Rollback();
            });

        // Регистрация ключа без подтверждения UnitOfWork из-за исклоючения.
        // Регистрация ключа автоматически отменяется.
        Parallel.For(0, 100_000,
            _ =>
            {
                try
                {
                    using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                    Assert.AreNotEqual(UniqueRegisterRegisterKeyResult.AlreadyExists, registerTransactionKeys.TryRegisterKey(key, 1));

                    throw new ApplicationException();
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
    private ILoggerFactory m_loggerFactory;
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

        m_timeService = new ManagedTimeService();
        
        // Время тестов всегда 1-н час ночи.
        m_timeService.SetStart(DateTime.Now.Date.AddHours(1));

        m_mappers = new Generated.PostgreSql.Implements.Mappers(new MappersExceptionPolicy(), dbConnectionString, m_timeService);
        m_workflowExceptionPolicy = new WorkflowExceptionPolicy();
        m_exceptionPolicy = new ExceptionPolicy(m_timeService, m_loggerFactory.CreateLogger<ExceptionPolicy>(), m_workflowExceptionPolicy);
        m_entryPoint = new ExampleEntryPoint(m_timeService, m_workflowExceptionPolicy, m_mappers, m_exceptionPolicy, m_loggerFactory);
        m_mapper = m_mappers.GetMapper<IMapperTransactionKey>();
        m_directory = new TestDirectory("Data");
        m_identityCache = CreateIdentityCache();

        Console.WriteLine($"Текущее время тестов : {m_timeService.NowDateTime}");

        using var mappersSession = (IPostgreSqlMappersSession)m_mappers.OpenSession();
        using var command = mappersSession.CreateCommand(false);
        command.CommandText = @"SELECT setting FROM pg_settings WHERE (name = 'max_connections')";
        command.CommandType = CommandType.Text;
        var setting = command.ExecuteScalar()!.ToString();
        Console.WriteLine("Настройки сервера PostgreSQL.");
        Console.WriteLine($"max_connections = {setting}");
        Console.WriteLine();
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();

        PostgreSqlDbHelper.DropDb(m_dbName);
        m_identityCache.SilentDispose();
        m_directory.SilentDispose();
    }

    private class ExampleUnitOfWork : BaseUnitOfWork
    {
        public ExampleUnitOfWork(
            UnitOfWorkContext unitOfWorkContext,
            Func<ProxyDomainObjectRegisters> registersFactory,
            IUnitOfWorkVisitor visitor)
            : base(
                unitOfWorkContext,
                registersFactory,
                visitor)
        {
        }
    }

    private class ExampleEntryPoint : BaseEntryPointEx
    {
        public ExampleEntryPoint(
            ITimeService timeService,
            IWorkflowExceptionPolicy workflowExceptionPolicy,
            IMappers mappers,
            IExceptionPolicy exceptionPolicy,
            ILoggerFactory loggerFactory)
            : base(
                new UnitOfWorkProviderCallContext(),
                new InfrastructureMonitorEntryPoint(null, TimeSpan.FromMinutes(15), timeService),
                new DomainObjectDataMappers(timeService),
                new DomainObjectRegisters(timeService),
                mappers,
                exceptionPolicy,
                workflowExceptionPolicy,
                timeService,
                true,
                loggerFactory)
        {
            ((InfrastructureMonitorDrivenObject)InfrastructureMonitor).Owner = this;
            m_proxyDomainObjectRegisterFactories.AddFactories(GetType().Assembly);
        }

        protected override IUnitOfWork DoCreateUnitOfWork(IUnitOfWorkVisitor visitor, object context)
        {
            var result = new ExampleUnitOfWork(m_unitOfWorkContext, m_registersFactory, visitor);

            return result;
        }
    }
    #endregion

    #region Helpers

    private ExampleRegisterTransactionKeys CreateRegisterTransactionKeys()
    {
        var result = new ExampleRegisterTransactionKeys(
            m_identityCache, 
            m_directory.BasePath,
            m_entryPoint.UnitOfWorkProvider,
            m_loggerFactory,
            m_exceptionPolicy,
            m_timeService,
            m_mappers,
            m_workflowExceptionPolicy);

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
        var mapper = m_mappers.GetMapper<IMapperTransactionKey>();

        var result =
            new IdentityCache<IMapperTransactionKey>(
                Guid.NewGuid(),
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.TransactionKey)}'.",
                $"Кэширующий провайдер идентити доменных объектов '{nameof(WellknownDomainObjects.TransactionKey)}'.",
                m_timeService,
                m_exceptionPolicy,
                m_workflowExceptionPolicy,
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
                methodGetNextIdentityList: (m, session, count, cancellationToken) => m.GetNextIds(session, count, cancellationToken),
                logger: m_loggerFactory.CreateLogger<IdentityCache<IMapperTransactionKey>>());

        // Прогрев кэша генератора.
        using var mappersSession = m_mappers.OpenSession();
        result.Initialize(mappersSession, CancellationToken.None);
        mappersSession.Commit();

        return result;
    }

    #endregion
}
