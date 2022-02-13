using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Tests;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;
using ShtrihM.Wattle3.Testing.DomainObjects;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples;

[TestFixture]
[SuppressMessage("ReSharper", "PossibleNullReferenceException")]
public class Examples
{
    /// <summary>
    /// Демонстрация работы стратегии слежения за результатом исполнения Unit of Work.
    /// В пределах Unit of Work произошло исключение.
    /// </summary>
    [Test]
    public void Example_UnitOfWork_Сonfirmation_Fail()
    {
        // Создание
        var id = long.MinValue;
        try
        {
            using var unitOfWork = m_entryPoint.CreateUnitOfWork();

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(DomainObjectTemplateDocument.GetRandomTemplate());
            id = instance.Identity;

            // Добавление в Unit of Work стратегии слежения за результатом исполнения Unit of Work.
            var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();
            domainBehaviour
                // Реакция на успешное завершение Unit of Work. Вызван Commit и от успешно отработал. Данные гарантированно ушли в БД.
                .SetSuccessful(
                    () =>
                        Console.WriteLine("UnitOfWork - Successful"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Successful");

                        return ValueTask.CompletedTask;
                    })
                // Реакция отмену или ошибку завершения Unit of Work. Данные гарантированно не ушли в БД.
                .SetFail(
                    () =>
                        Console.WriteLine("UnitOfWork - Fail"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Fail");

                        return ValueTask.CompletedTask;
                    });
            unitOfWork.AddBehaviour(domainBehaviour);

            throw new ApplicationException("Test");
        }
        catch (ApplicationException exception)
        {
            Assert.AreEqual("Test", exception.Message);
        }

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id);

            Assert.IsNull(instance);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронная демонстрация работы стратегии слежения за результатом исполнения Unit of Work.
    /// В пределах Unit of Work произошло исключение.
    /// </summary>
    [Test]
    public async ValueTask Example_UnitOfWork_Сonfirmation_Fail_Async()
    {
        // Создание
        var id = long.MinValue;
        try
        {
            await using var unitOfWork = m_entryPoint.CreateUnitOfWork();

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.NewAsync(DomainObjectTemplateDocument.GetRandomTemplate());
            id = instance.Identity;

            // Добавление в Unit of Work стратегии слежения за результатом исполнения Unit of Work.
            var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();
            domainBehaviour
                // Реакция на успешное завершение Unit of Work. Вызван Commit и от успешно отработал. Данные гарантированно ушли в БД.
                .SetSuccessful(
                    () =>
                        Console.WriteLine("UnitOfWork - Successful"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Successful");

                        return ValueTask.CompletedTask;
                    })
                // Реакция отмену или ошибку завершения Unit of Work. Данные гарантированно не ушли в БД.
                .SetFail(
                    () =>
                        Console.WriteLine("UnitOfWork - Fail"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Fail");

                        return ValueTask.CompletedTask;
                    });
            unitOfWork.AddBehaviour(domainBehaviour);

            throw new ApplicationException("Test");
        }
        catch (ApplicationException exception)
        {
            Assert.AreEqual("Test", exception.Message);
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id);

            Assert.IsNull(instance);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Демонстрация работы стратегии слежения за результатом исполнения Unit of Work.
    /// Unit of Work успешно завершён.
    /// </summary>
    [Test]
    public void Example_UnitOfWork_Сonfirmation_Successful()
    {
        // Создание
        long id;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(template);
            id = instance.Identity;

            // Добавление в Unit of Work стратегии слежения за результатом исполнения Unit of Work.
            var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();
            domainBehaviour
                // Реакция на успешное завершение Unit of Work. Вызван Commit и от успешно отработал. Данные гарантированно ушли в БД.
                .SetSuccessful(
                    () => 
                        Console.WriteLine("UnitOfWork - Successful"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Successful");

                        return ValueTask.CompletedTask;
                    })
                // Реакция отмену или ошибку завершения Unit of Work. Данные гарантированно не ушли в БД.
                .SetFail(
                    () =>
                        Console.WriteLine("UnitOfWork - Fail"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Fail");

                        return ValueTask.CompletedTask;
                    });
            unitOfWork.AddBehaviour(domainBehaviour);

            unitOfWork.Commit();
        }

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            AssertAreEqual(1, template, instance);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронная демонстрация работы стратегии слежения за результатом исполнения Unit of Work.
    /// Unit of Work успешно завершён.
    /// </summary>
    [Test]
    public async ValueTask Example_UnitOfWork_Сonfirmation_Successful_Async()
    {
        // Создание
        long id;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.NewAsync(template);
            id = instance.Identity;

            // Добавление в Unit of Work стратегии слежения за результатом исполнения Unit of Work.
            var domainBehaviour = m_entryPoint.CreateDomainBehaviourWithСonfirmation();
            domainBehaviour
                // Реакция на успешное завершение Unit of Work. Вызван Commit и от успешно отработал. Данные гарантированно ушли в БД.
                .SetSuccessful(
                    () =>
                        Console.WriteLine("UnitOfWork - Successful"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Successful");

                        return ValueTask.CompletedTask;
                    })
                // Реакция отмену или ошибку завершения Unit of Work. Данные гарантированно не ушли в БД.
                .SetFail(
                    () =>
                        Console.WriteLine("UnitOfWork - Fail"),
                    () =>
                    {
                        Console.WriteLine("UnitOfWork - async Fail");

                        return ValueTask.CompletedTask;
                    });
            unitOfWork.AddBehaviour(domainBehaviour);

            await unitOfWork.CommitAsync();
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            AssertAreEqual(1, template, instance);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Создать доменный объект в БД.
    /// </summary>
    [Test]
    public void Example_DomainObject_Create()
    {
        // Создание
        long id;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(template);

            id = instance.Identity;

            unitOfWork.Commit();
        }

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            AssertAreEqual(1, template, instance);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронное создание доменного объекта в БД.
    /// </summary>
    [Test]
    public async ValueTask Example_DomainObject_Create_Async()
    {
        // Создание
        long id;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.NewAsync(template);

            id = instance.Identity;

            await unitOfWork.CommitAsync();
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            AssertAreEqual(1, template, instance);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Массовое чтение доменнного объекта из БД.
    /// Демострация работы кэша на уровне мапперов.
    /// </summary>
    [Test]
    public void Example_DomainObject_Read()
    {
        // Создание
        long id;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(template);

            id = instance.Identity;

            unitOfWork.Commit();
        }

        Console.WriteLine("После создания доменного объекта.");

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }

        // Чтение
        var stopwatch = Stopwatch.StartNew();

        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            AssertAreEqual(1, template, instance);

            unitOfWork.Commit();
        }

        Parallel.For(
            0, 1_000_000,
            _ =>
            {
                using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
                var instance = register.Find(id, true);

                AssertAreEqual(1, template, instance);

                unitOfWork.Commit();
            });

        stopwatch.Stop();

        Console.WriteLine("");
        Console.WriteLine("После массового чтения доменного объекта.");
        Console.WriteLine($"Время чтения : {stopwatch.Elapsed}");

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронное массовое чтение доменнного объекта из БД.
    /// Демострация работы кэша на уровне мапперов.
    /// </summary>
    [Test]
    public async ValueTask Example_DomainObject_Read_Async()
    {
        // Создание
        long id;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.NewAsync(template);

            id = instance.Identity;

            await unitOfWork.CommitAsync();
        }

        Console.WriteLine("После создания доменного объекта.");

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }

        // Чтение
        var stopwatch = Stopwatch.StartNew();

        async void Read(int _)
        {
            await using var unitOfWork = m_entryPoint.CreateUnitOfWork();

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            AssertAreEqual(1, template, instance);

            await unitOfWork.CommitAsync();
        }

        Read(0);

        Parallel.For(0, 1_000_000, Read);

        stopwatch.Stop();

        Console.WriteLine("");
        Console.WriteLine("После массового чтения доменного объекта.");
        Console.WriteLine($"Время чтения : {stopwatch.Elapsed}");

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Изменение доменного объекта в БД.
    /// </summary>
    [Test]
    public void Example_DomainObject_Update()
    {
        // Создание
        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.New(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444);

            id = instance.Identity;

            unitOfWork.Commit();
        }

        // Изменение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            Assert.AreEqual(1, instance.Revision);
            Assert.AreEqual(new DateTime(2022, 1, 2, 3, 4, 5, 6), instance.Value_DateTime);
            Assert.AreEqual(1002, instance.Value_Long);
            Assert.AreEqual(444, instance.Value_Int);

            instance.Value_DateTime = new DateTime(2022, 5, 6, 7, 8, 9, 10);
            instance.Value_Long = 303;
            instance.Value_Int = 999;

            unitOfWork.Commit();
        }

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            Assert.AreEqual(2, instance.Revision);
            Assert.AreEqual(new DateTime(2022, 5, 6, 7, 8, 9, 10), instance.Value_DateTime);
            Assert.AreEqual(303, instance.Value_Long);
            Assert.AreEqual(999, instance.Value_Int);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронное изменение доменного объекта в БД.
    /// </summary>
    [Test]
    public async ValueTask Example_DomainObject_Update_Async()
    {
        // Создание
        long id;
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.NewAsync(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444);

            id = instance.Identity;

            await unitOfWork.CommitAsync();
        }

        // Изменение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            Assert.AreEqual(1, instance.Revision);
            Assert.AreEqual(new DateTime(2022, 1, 2, 3, 4, 5, 6), instance.Value_DateTime);
            Assert.AreEqual(1002, instance.Value_Long);
            Assert.AreEqual(444, instance.Value_Int);

            instance.Value_DateTime = new DateTime(2022, 5, 6, 7, 8, 9, 10);
            instance.Value_Long = 303;
            instance.Value_Int = 999;

            await unitOfWork.CommitAsync();
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            Assert.AreEqual(2, instance.Revision);
            Assert.AreEqual(new DateTime(2022, 5, 6, 7, 8, 9, 10), instance.Value_DateTime);
            Assert.AreEqual(303, instance.Value_Long);
            Assert.AreEqual(999, instance.Value_Int);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Удаление доменного объекта в БД.
    /// </summary>
    [Test]
    public void Example_DomainObject_Delete()
    {
        // Создание
        long id_1;
        long id_2;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            id_1 = register.New(DomainObjectTemplateDocument.GetRandomTemplate()).Identity;
            id_2 = register.New(template).Identity;

            unitOfWork.Commit();
        }

        // Удаление
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id_1, true);

            instance.Delete();

            unitOfWork.Commit();
        }

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();

            var instance = register.Find(id_1);
            Assert.IsNull(instance);

            instance = register.Find(id_2);
            Assert.IsNotNull(instance);

            AssertAreEqual(1, template, instance);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронное удаление доменного объекта в БД.
    /// </summary>
    [Test]
    public async ValueTask Example_DomainObject_Delete_Async()
    {
        // Создание
        long id_1;
        long id_2;
        var template = DomainObjectTemplateDocument.GetRandomTemplate();
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            id_1 = (await register.NewAsync(DomainObjectTemplateDocument.GetRandomTemplate())).Identity;
            id_2 = (await register.NewAsync(template)).Identity;

            await unitOfWork.CommitAsync();
        }

        // Удаление
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id_1, true);

            instance.Delete();

            await unitOfWork.CommitAsync();
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();

            var instance = await register.FindAsync(id_1);
            Assert.IsNull(instance);

            instance = await register.FindAsync(id_2);
            Assert.IsNotNull(instance);

            AssertAreEqual(1, template, instance);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Верификация версии данных в БД.
    /// </summary>
    [Test]
    public void Example_DomainObject_Version()
    {
        // Создание
        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            id = register.New(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444).Identity;

            unitOfWork.Commit();
        }

        // Верификация версии данных в БД - без изменения доменного объекта
        var workflowException =
            Assert.Throws<WorkflowException>(
                () =>
                {
                    using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                    var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
                    var instance = register.Find(id, true);

                    // Параллельное изменение данных в БД
                    ChangeDocument(id, new DateTime(2023, 4, 5, 6, 7, 8, 9), 303, 999);

                    instance.Version();

                    unitOfWork.Commit();
                });
        Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, workflowException.Code);
        Assert.AreEqual("Доменный объект не найден или версия его данных изменилась.", workflowException.Details);

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id);

            Assert.AreEqual(2, instance.Revision);
            Assert.AreEqual(new DateTime(2023, 4, 5, 6, 7, 8, 9), instance.Value_DateTime);
            Assert.AreEqual(303, instance.Value_Long);
            Assert.AreEqual(999, instance.Value_Int);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронная верификация версии данных в БД.
    /// </summary>
    [Test]
    public async ValueTask Example_DomainObject_Version_Async()
    {
        // Создание
        long id;
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            id = (await register.NewAsync(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444)).Identity;

            await unitOfWork.CommitAsync();
        }

        // Верификация версии данных в БД - без изменения доменного объекта
        try
        {
            await using var unitOfWork = m_entryPoint.CreateUnitOfWork();

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            // Параллельное изменение данных в БД
            ChangeDocument(id, new DateTime(2023, 4, 5, 6, 7, 8, 9), 303, 999);

            instance.Version();

            await unitOfWork.CommitAsync();
        }
        catch (WorkflowException exception)
        {
            Assert.AreEqual(CommonWorkflowExceptionErrorCodes.ServiceTemporarilyUnavailable, exception.Code);
            Assert.AreEqual("Доменный объект не найден или версия его данных изменилась.", exception.Details);
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id);

            Assert.AreEqual(2, instance.Revision);
            Assert.AreEqual(new DateTime(2023, 4, 5, 6, 7, 8, 9), instance.Value_DateTime);
            Assert.AreEqual(303, instance.Value_Long);
            Assert.AreEqual(999, instance.Value_Int);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Оптимистическая конкуренция на уровне БД.
    /// </summary>
    [Test]
    public void Example_DomainObject_OptimisticConcurrency()
    {
        // Создание
        long id;
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            id = register.New(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444).Identity;

            unitOfWork.Commit();
        }

        // Верификация версии данных в БД - без изменения доменного объекта
        var exception =
            Assert.Throws<InvalidOperationException>(
                () =>
                {
                    using var unitOfWork = m_entryPoint.CreateUnitOfWork();

                    var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
                    var instance = register.Find(id, true);

                    // Параллельное изменение данных в БД
                    ChangeDocument(id, new DateTime(2023, 4, 5, 6, 7, 8, 9), 303, 999);

                    instance.Method(new DateTime(2024, 7, 8, 9, 10, 11, 12), 77, 44);

                    unitOfWork.Commit();
                });
        Assert.IsTrue(exception.Message.Contains("Конкуренция при обновлении записи"));

        // Чтение
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id);

            Assert.AreEqual(2, instance.Revision);
            Assert.AreEqual(new DateTime(2023, 4, 5, 6, 7, 8, 9), instance.Value_DateTime);
            Assert.AreEqual(303, instance.Value_Long);
            Assert.AreEqual(999, instance.Value_Int);

            unitOfWork.Commit();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    /// <summary>
    /// Асинхронная оптимистическая конкуренция на уровне БД.
    /// </summary>
    [Test]
    public async ValueTask Example_DomainObject_OptimisticConcurrency_Async()
    {
        // Создание
        long id;
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            id = (await register.NewAsync(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444)).Identity;

            await unitOfWork.CommitAsync();
        }

        // Верификация версии данных в БД - без изменения доменного объекта
        try
        {
            await using var unitOfWork = m_entryPoint.CreateUnitOfWork();

            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id, true);

            // Параллельное изменение данных в БД
            ChangeDocument(id, new DateTime(2023, 4, 5, 6, 7, 8, 9), 303, 999);

            instance.Method(new DateTime(2024, 7, 8, 9, 10, 11, 12), 77, 44);

            await unitOfWork.CommitAsync();
        }
        catch (InvalidOperationException exception)
        {
            Assert.IsTrue(exception.Message.Contains("Конкуренция при обновлении записи"));
        }

        // Чтение
        await using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = await register.FindAsync(id);

            Assert.AreEqual(2, instance.Revision);
            Assert.AreEqual(new DateTime(2023, 4, 5, 6, 7, 8, 9), instance.Value_DateTime);
            Assert.AreEqual(303, instance.Value_Long);
            Assert.AreEqual(999, instance.Value_Int);

            await unitOfWork.CommitAsync();
        }

        // Мониторинг инфраструктуры
        {
            var snapShot = m_entryPoint.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество Unit of Works : {snapShot.CountUnitOfWorks:##,###}");
        }
        {
            var snapShot = m_entryPoint.Mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections:##,###}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions:##,###}");
        }
    }

    #region Helpers

    private void AssertAreEqual(long expectedRevision, DomainObjectTemplateDocument template, IDomainObjectDocument document)
    {
        Assert.AreEqual(expectedRevision, document.Revision);
        Assert.AreEqual(template.Value_DateTime, document.Value_DateTime);
        Assert.AreEqual(template.Value_Long, document.Value_Long);
        Assert.AreEqual(template.Value_Int, document.Value_Int);
    }

    private void ChangeDocument(long id, DateTime value_DateTime, long value_Long, int? value_Int)
    {
        var oldUnitOfWork = ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().SetCurrentUnitOfWork(null); // Отключение для потока Unit of Work
        using (var unitOfWork = m_entryPoint.CreateUnitOfWork())
        {
            var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
            var instance = register.Find(id, true);

            var result = instance.Method(value_DateTime, value_Long, value_Int);
            Assert.AreEqual("Test", result);

            unitOfWork.Commit();
        }
        ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().SetCurrentUnitOfWork(oldUnitOfWork); // Вернуть для потока Unit of Work
    }

    #endregion

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
