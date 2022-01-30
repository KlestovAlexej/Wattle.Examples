using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Infrastructures.Loggers;
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.Wattle3.Examples.QueueProcessors;

/// <summary>
/// Примеры многопоточной очереди.
/// </summary>
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
[TestFixture]
public class Examples
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

    [SetUp]
    public void SetUp()
    {
        var timeService = new TimeService();

        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()))
            .SetTimeService(new TimeService())
            .SetWorkflowExceptionPolicy(new WorkflowExceptionPolicy())
            .SetExceptionPolicy(new ExceptionPolicy(timeService))
            .Build();
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();
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
                ServiceProviderHolder.Instance.GetRequiredService<IExceptionPolicy>(),
                ServiceProviderHolder.Instance.GetRequiredService<ITimeService>(),
                Guid.NewGuid());

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
