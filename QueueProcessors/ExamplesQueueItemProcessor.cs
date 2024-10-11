using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Acme.Wattle.DomainObjects.Common;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Examples.Common;
using Acme.Wattle.QueueProcessors;
using Acme.Wattle.QueueProcessors.Interfaces;
using Acme.Wattle.Testing;
using System;
using Acme.Wattle.Utils;

namespace Acme.Wattle.Examples.QueueProcessors;

/// <summary>
/// Примеры многопоточной очереди.
/// </summary>
[TestFixture]
public class ExamplesQueueItemProcessor
{
    /// <summary>
    /// Добавить и обработать элемент.
    /// </summary>
    [Test]
    public void Example_Add()
    {
        using var queue = CreateQueue();

        queue.Start();

        queue.Add(new QueueItem());

        WaitItems(queue);

        queue.Stop();
    }

    /// <summary>
    /// Добавить и обработать элемент с предварительным помещением в карантин на интервал времени.
    /// </summary>
    [Test]
    public void Example_AddEmergency()
    {
        using var queue = CreateQueue();

        queue.Start();

        queue.AddEmergency(new QueueItem());

        WaitItems(queue);

        queue.Stop();
    }

    /// <summary>
    /// Добавить и обработать элемент с исключением при обработке.
    /// Элемент с исключением перед повторной обработкой помещается в карантин на интервал времени.
    /// </summary>
    [Test]
    public void Example_Add_Exception()
    {
        using var queue = CreateQueue();

        queue.Start();

        queue.Add(new QueueItemWithException());

        WaitItems(queue);

        queue.Stop();
    }

    /// <summary>
    /// Добавить и обработать отравленного элемент.
    /// Отравленный элемент это элемент при обработке которого принято решение что его оюраюотку надо повторить по неизвестной ошибке при обработке.
    /// Отравленный элемент перед повторной обработкой помещается в карантин на интервал времени.
    /// </summary>
    [Test]
    public void Example_Add_Poisoned()
    {
        using var queue = CreateQueue();

        queue.Start();

        queue.Add(new QueueItemPoisoned());

        WaitItems(queue);

        queue.Stop();
    }

    /// <summary>
    /// Добавить и обработать элемент требующий повторной обработки.
    /// Элемент будет повторно обработат немедленно как придёт его очередь.
    /// </summary>
    [Test]
    public void Example_Add_Repeat()
    {
        using var queue = CreateQueue();

        queue.Start();

        queue.Add(new QueueItemRepeat());

        WaitItems(queue);

        queue.Stop();
    }

    #region Enviroment

    private ITimeService m_timeService;
    private ILoggerFactory m_loggerFactory;
    private IExceptionPolicy m_exceptionPolicy;

    [SetUp]
    public void SetUp()
    {
        // Создание фабрики логгеров к консольк NUnit в режиме не писать - true.
        m_loggerFactory = LoggerFactory.Create(builder => new NUnitConsoleLoggerProvider(true).Add(builder));

        m_timeService = new TimeService();
        m_exceptionPolicy =
            new ExceptionPolicy(
                m_timeService,
                m_loggerFactory.CreateLogger<ExceptionPolicy>(),
                new WorkflowExceptionPolicy());
    }

    [TearDown]
    public void TearDown()
    {
        m_loggerFactory.SilentDispose();
    }

    #endregion

    #region QueueItems

    private class QueueItem : IQueueItem
    {
        public QueueItemProcessResult Process(IQueueItemProcessor queueProcessor)
        {
            Console.WriteLine("QueueItem.Process");

            return QueueItemProcessResult.Remove;
        }
    }

    private class QueueItemWithException : IQueueItem
    {
        private bool m_exception;

        public QueueItemWithException()
        {
            m_exception = true;
        }

        public QueueItemProcessResult Process(IQueueItemProcessor queueProcessor)
        {
            Console.WriteLine("QueueItem.Process");

            if (m_exception)
            {
                m_exception = false;

                throw new ApplicationException("QueueItemWithException");
            }

            return QueueItemProcessResult.Remove;
        }
    }

    private class QueueItemPoisoned : IQueueItem
    {
        private bool m_poisoned;

        public QueueItemPoisoned()
        {
            m_poisoned = true;
        }

        public QueueItemProcessResult Process(IQueueItemProcessor queueProcessor)
        {
            Console.WriteLine("QueueItem.Process");

            if (m_poisoned)
            {
                m_poisoned = false;

                return QueueItemProcessResult.Poisoned;
            }

            return QueueItemProcessResult.Remove;
        }
    }

    private class QueueItemRepeat : IQueueItem
    {
        private bool m_repeat;

        public QueueItemRepeat()
        {
            m_repeat = true;
        }

        public QueueItemProcessResult Process(IQueueItemProcessor queueProcessor)
        {
            Console.WriteLine("QueueItem.Process");

            if (m_repeat)
            {
                m_repeat = false;

                return QueueItemProcessResult.Repeat;
            }

            return QueueItemProcessResult.Remove;
        }
    }

    #endregion

    #region Helpers

    private IQueueItemProcessor CreateQueue()
    {
        var result =
            new QueueItemProcessor(
                10,
                TimeSpan.FromSeconds(4),
                "Queue",
                m_exceptionPolicy,
                m_timeService,
                Guid.NewGuid(),
                m_loggerFactory.CreateLogger<QueueItemProcessor>());

        return result;
    }

    private void WaitItems(IQueueItemProcessor queue)
    {
        WaitHelpers.TimeOut(
            () =>
            {
                var snapShot = queue.InfrastructureMonitor.GetSnapShot();
                var isEnd = snapShot.CountAddedItems == snapShot.CountRemovedItems;

                return isEnd;
            },
            TimeSpan.FromMinutes(1));

        var snapShot = queue.InfrastructureMonitor.GetSnapShot();

        Console.WriteLine("");
        Console.WriteLine("Queue:");
        Console.WriteLine($"CountAddedItems = {snapShot.CountAddedItems}");
        Console.WriteLine($"CountRemovedItems = {snapShot.CountRemovedItems}");
        Console.WriteLine($"CountProcessedItems = {snapShot.CountProcessedItems}");
        Console.WriteLine($"CountProcessingErrors = {snapShot.CountProcessingErrors}");
    }

    #endregion
}
