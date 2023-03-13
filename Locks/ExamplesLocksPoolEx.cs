using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.Wattle3.Examples.Locks;

/// <summary>
/// Примеры пула лок-объектов ассоциированных с идентификаторами.
/// </summary>
[TestFixture]
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
public class ExamplesLocksPoolEx
{
    /// <summary>
    /// Основные функции.
    /// </summary>
    [Test]
    public void Example()
    {
        using var locks = 
            new LocksPoolEx<int>(
                Guid.NewGuid(), 
                "Тест", 
                "Тест", 
                new TimeService(), 
                TimeSpan.FromSeconds(2)); // Ожидание монопольной блокировки 2 секунды.

        // Монитор инфраструктуры лок-объектов.
        var infrastructureMonitor = ((ILocksPool<int>)locks).InfrastructureMonitor;

        // Получаем монопольную блокировку
        using (var lockObject = locks.GetLock(123))
        {
            if (lockObject.TryEnter())
            {
                Console.WriteLine("Enter");
            }
            else
            {
                Assert.Fail();
            }
        }

        // Проверяем число успешных блокировок.
        var snapShot = infrastructureMonitor.GetSnapShot();
        Assert.AreEqual(1, snapShot.CountEnter);
        Assert.AreEqual(0, snapShot.CountNotEnter);

        // Получаем монопольную блокировку на длительное время
        var task = Task.Factory.StartNew(
            () =>
            {
                Console.WriteLine("Task - Start");

                using (var lockObject = locks.GetLock(123))
                {
                    if (lockObject.TryEnter())
                    {
                        Console.WriteLine("Task Enter");

                        Thread.Sleep(TimeSpan.FromSeconds(10));
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }

                Console.WriteLine("Task - End");
            });

        Thread.Sleep(TimeSpan.FromSeconds(5));

        // Попытка получения монопольной блокировки с ожиданием 2-х секунд
        using (var lockObject = locks.GetLock(123))
        {
            if (false == lockObject.TryEnter())
            {
                Console.WriteLine("Not Enter");
            }
            else
            {
                Assert.Fail();
            }
        }

        task.Wait();

        // Проверяем число успешных блокировок.
        snapShot = infrastructureMonitor.GetSnapShot();
        Assert.AreEqual(2, snapShot.CountEnter);
        Assert.AreEqual(1, snapShot.CountNotEnter);
    }

    /// <summary>
    /// Основные функции.
    /// Ожидание монопольной блокировки бесконечно.
    /// </summary>
    [Test]
    public void Example_WaitInitity()
    {
        using var locks =
            new LocksPoolEx<int>(
                Guid.NewGuid(),
                "Тест",
                "Тест",
                new TimeService(),
                null); // Ожидание монопольной блокировки бесконечно.

        // Монитор инфраструктуры лок-объектов.
        var infrastructureMonitor = ((ILocksPool<int>)locks).InfrastructureMonitor;

        // Получаем монопольную блокировку
        using (var lockObject = locks.GetLock(123))
        {
            if (lockObject.TryEnter())
            {
                Console.WriteLine("Enter");
            }
            else
            {
                Assert.Fail();
            }
        }

        // Проверяем число успешных блокировок.
        var snapShot = infrastructureMonitor.GetSnapShot();
        Assert.AreEqual(1, snapShot.CountEnter);
        Assert.AreEqual(0, snapShot.CountNotEnter);

        // Получаем монопольную блокировку на длительное время
        var task = Task.Factory.StartNew(
            () =>
            {
                Console.WriteLine("Task - Start");

                using (var lockObject = locks.GetLock(123))
                {
                    if (lockObject.TryEnter())
                    {
                        Console.WriteLine("Task Enter");

                        Thread.Sleep(TimeSpan.FromSeconds(10));
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }

                Console.WriteLine("Task - End");
            });

        Thread.Sleep(TimeSpan.FromSeconds(5));

        // Попытка получения монопольной блокировки с ожиданием 2-х секунд
        using (var lockObject = locks.GetLock(123))
        {
            if (lockObject.TryEnter())
            {
                Console.WriteLine("Enter");
            }
            else
            {
                Assert.Fail();
            }
        }

        task.Wait();

        // Проверяем число успешных блокировок.
        snapShot = infrastructureMonitor.GetSnapShot();
        Assert.AreEqual(3, snapShot.CountEnter);
        Assert.AreEqual(0, snapShot.CountNotEnter);
    }
}
