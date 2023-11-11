using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Testing;
using System;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.Wattle3.Examples.QueueProcessors;

/// <summary>
/// Примеры многопоточной очереди с равноприоритетными подочередями (слоты).
/// </summary>
[TestFixture]
public class ExamplesSlotsQueueItemProcessor
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

    private class QueueItem : ISlotsQueueItem
    {
        private byte m_slotsIndex;

        public QueueItem()
        {
            m_slotsIndex = 1;
        }

        public QueueItemProcessResult Process(ISlotsQueueItemProcessor queueProcessor)
        {
            Console.WriteLine($"QueueItem.Process , SlotsIndex [{m_slotsIndex}]");

            if (m_slotsIndex >= SlotsSize)
            {
                return QueueItemProcessResult.Remove;
            }

            ++m_slotsIndex;

            return QueueItemProcessResult.Repeat;
        }

        public byte GetItemSlotIndex(ISlotsQueueItemProcessor queueProcessor)
        {
            return m_slotsIndex;
        }
    }

    private class QueueItemWithException : ISlotsQueueItem
    {
        private bool m_exception;
        private byte m_slotsIndex;

        public QueueItemWithException()
        {
            m_slotsIndex = 1;
            m_exception = true;
        }

        public QueueItemProcessResult Process(ISlotsQueueItemProcessor queueProcessor)
        {
            Console.WriteLine($"QueueItem.Process , SlotsIndex [{m_slotsIndex}]");

            if (m_exception)
            {
                m_exception = false;

                throw new ApplicationException("QueueItemWithException , SlotsIndex [{m_slotsIndex}]");
            }

            if (m_slotsIndex >= SlotsSize)
            {
                return QueueItemProcessResult.Remove;
            }

            ++m_slotsIndex;
            m_exception = true;

            return QueueItemProcessResult.Repeat;
        }

        public byte GetItemSlotIndex(ISlotsQueueItemProcessor queueProcessor)
        {
            return m_slotsIndex;
        }
    }

    private class QueueItemPoisoned : ISlotsQueueItem
    {
        private bool m_poisoned;
        private byte m_slotsIndex;

        public QueueItemPoisoned()
        {
            m_slotsIndex = 1;
            m_poisoned = true;
        }

        public QueueItemProcessResult Process(ISlotsQueueItemProcessor queueProcessor)
        {
            Console.WriteLine($"QueueItem.Process , SlotsIndex [{m_slotsIndex}]");

            if (m_poisoned)
            {
                m_poisoned = false;

                return QueueItemProcessResult.Poisoned;
            }

            if (m_slotsIndex >= SlotsSize)
            {
                return QueueItemProcessResult.Remove;
            }

            ++m_slotsIndex;
            m_poisoned = true;

            return QueueItemProcessResult.Repeat;
        }

        public byte GetItemSlotIndex(ISlotsQueueItemProcessor queueProcessor)
        {
            return m_slotsIndex;
        }
    }

    private class QueueItemRepeat : ISlotsQueueItem
    {
        private bool m_repeat;
        private byte m_slotsIndex;

        public QueueItemRepeat()
        {
            m_slotsIndex = 1;
            m_repeat = true;
        }

        public QueueItemProcessResult Process(ISlotsQueueItemProcessor queueProcessor)
        {
            Console.WriteLine($"QueueItem.Process , SlotsIndex [{m_slotsIndex}]");

            if (m_repeat)
            {
                m_repeat = false;

                return QueueItemProcessResult.Repeat;
            }

            if (m_slotsIndex >= SlotsSize)
            {
                return QueueItemProcessResult.Remove;
            }

            ++m_slotsIndex;
            m_repeat = true;

            return QueueItemProcessResult.Repeat;
        }

        public byte GetItemSlotIndex(ISlotsQueueItemProcessor queueProcessor)
        {
            return m_slotsIndex;
        }
    }

    #endregion

    #region Helpers

    private const byte SlotsSize = 3;

    private ISlotsQueueItemProcessor CreateQueue()
    {
        var result =
            new SlotsQueueItemProcessor(
                10,
                TimeSpan.FromSeconds(4),
                "Queue",
                m_exceptionPolicy,
                m_timeService,
                Guid.NewGuid(),
                SlotsSize,
                m_loggerFactory.CreateLogger<QueueItemProcessor>());

        return result;
    }

    private void WaitItems(ISlotsQueueItemProcessor queue)
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
        Console.WriteLine($"Слотов = {snapShot.SlotStatistics.Length}");
        for (var i = 0; i < snapShot.SlotStatistics.Length; i++)
        {
            Console.WriteLine("");
            Console.WriteLine($"SlotIndex = {snapShot.SlotStatistics[i].SlotIndex}");
            Console.WriteLine($"CountAddedItems = {snapShot.SlotStatistics[i].CountAddedItems}");
            Console.WriteLine($"CountRemovedItems = {snapShot.SlotStatistics[i].CountRemovedItems}");
            Console.WriteLine($"CountProcessedItems = {snapShot.SlotStatistics[i].CountProcessedItems}");
            Console.WriteLine($"CountProcessingErrors = {snapShot.SlotStatistics[i].CountProcessingErrors}");
        }
    }

    #endregion
}
