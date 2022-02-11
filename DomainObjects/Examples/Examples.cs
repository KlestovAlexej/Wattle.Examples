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
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.SystemMethods;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Tests;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using ShtrihM.Wattle3.Testing.DomainObjects;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples;

[TestFixture]
public class Examples
{
    /// <summary>
    /// Создать доменный объект в БД и прочитать его.
    /// </summary>
    [Test]
    public void Example_Create()
    {
        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444);

            id = instance.Identity;

            unitOfWork.Commit();
        }

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            Assert.AreEqual(1, instance.Revision);
            Assert.AreEqual(new DateTime(2022, 1, 2, 3, 4, 5, 6), instance.Value_DateTime);
            Assert.AreEqual(1002, instance.Value_Long);
            Assert.AreEqual(444, instance.Value_Int);

            unitOfWork.Commit();
        }

        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Создание доменнного объекта и его массовое чтение из БД.
    /// Демострация работы кэша на уровне мапперов.
    /// </summary>
    [Test]
    public void Example_Read_Cache()
    {
        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444);

            id = instance.Identity;

            unitOfWork.Commit();
        }

        Console.WriteLine("После создания доменного объекта.");
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }

        Parallel.For(
            0, 1_000_000,
            _ =>
            {
                using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
                {
                    var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
                    var instance = register.Find(id, true);

                    Assert.AreEqual(1, instance.Revision);
                    Assert.AreEqual(new DateTime(2022, 1, 2, 3, 4, 5, 6), instance.Value_DateTime);
                    Assert.AreEqual(1002, instance.Value_Long);
                    Assert.AreEqual(444, instance.Value_Int);

                    unitOfWork.Commit();
                }
            });

        Console.WriteLine("");
        Console.WriteLine("После массового чтения доменного объекта.");
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    #region Enviroment

    private string m_dbName;
    private ExampleEntryPoint m_entryPoint;
    private ManagedTimeService m_timeService;

    [SetUp]
    public void SetUp()
    {
        BaseAutoTestsMapper.CreateDb(out m_dbName, out var dbConnectionString);

        // Настройка окружения.
        var configurator =
            DomainEnviromentConfigurator
                .Begin(LoggerFactory.Create(builder => builder.AddConsole()));

        var domainObjectIntergratorContext = new DomainObjectIntergratorContext();
        domainObjectIntergratorContext.AddObject(ExampleEntryPoint.WellknownDomainObjectIntergratorContextObjectNames.ConnectionString, dbConnectionString);

        m_timeService = new ManagedTimeService();
        domainObjectIntergratorContext.AddObject(ExampleEntryPoint.WellknownDomainObjectIntergratorContextObjectNames.TimeService, m_timeService);

        var entryPoint = ExampleEntryPoint.New(domainObjectIntergratorContext);

        configurator
            .SetTimeService(entryPoint.TimeService)
            .SetExceptionPolicy(entryPoint.ExceptionPolicy)
            .SetMappers(entryPoint.Mappers)
            .SetWorkflowExceptionPolicy(entryPoint.WorkflowExceptionPolicy)
            .SetUnitOfWorkProvider()
            .SetInfrastructureMonitorRegisters(entryPoint.InfrastructureMonitorRegisters)
            .SetEntryPoint(m_entryPoint = entryPoint)
            .Build();

        // Запуск точки входа в доменную область.
        m_entryPoint.Start();

        // Ожидаем инициализации точки входа.
        WaitHelpers.TimeOut(
            () => m_entryPoint.IsReady,
            TimeSpan.FromMinutes(1));
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();

        PostgreSqlDbHelper.DropDb(m_dbName);
    }

    #endregion
}
