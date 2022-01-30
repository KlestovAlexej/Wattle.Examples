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
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;

namespace ShtrihM.Wattle3.Examples.QueueProcessors;

[TestFixture]
public class Examples
{
    [SetUp]
    public void SetUp()
    {
        var timeService = new TimeService();
        var workflowExceptionPolicy = new WorkflowExceptionPolicy();
        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()))
            .SetTimeService(timeService)
            .SetWorkflowExceptionPolicy(workflowExceptionPolicy)
            .SetExceptionPolicy(new ExceptionPolicy(timeService, workflowExceptionPolicy))
            .Build();
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();
    }


    [Test]
    public void Test_Start_Stop()
    {
        using var queue = 
            new QueueItemProcessor(
                1, 
                TimeSpan.FromSeconds(1), 
                "Queue",
                ServiceProviderHolder.Instance.GetRequiredService<IExceptionPolicy>(),
                ServiceProviderHolder.Instance.GetRequiredService<ITimeService>(), 
                Guid.NewGuid());

            queue.Start();

            Thread.Sleep(TimeSpan.FromSeconds(10));

            queue.Stop();
    }

/*
        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка запуска и асинхронная остановка.")]
        public void Test_Start_WaitStop()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                Thread.Sleep(TimeSpan.FromSeconds(10));

                queue.BeginStop();
                queue.WaitStop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка добавление сообщений.")]
        public void Test_Add()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var items = new List<QueueProcessorItem>();
                for (var i = 0; i < 4; i++)
                {
                    items.Add(
                        new QueueProcessorItem(
                            _ => QueueItemProcessResult.Remove));
                }

                foreach (var testQueueProcessorItem in items)
                {
                    queue.Add(testQueueProcessorItem);
                }

                while (QueueProcessorItem.GlobalProcessCount < items.Count)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                foreach (var testQueueProcessorItem in items)
                {
                    Assert.AreEqual(1, testQueueProcessorItem.ProcessCount);
                }

                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(0, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка добавление сообщений универсальным методом (нормальная обработка).")]
        public void Test_Add_Normal()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var items = new List<QueueProcessorItem>();
                for (var i = 0; i < 4; i++)
                {
                    items.Add(
                        new QueueProcessorItem(
                            _ => QueueItemProcessResult.Remove));
                }

                foreach (var testQueueProcessorItem in items)
                {
                    queue.Add(testQueueProcessorItem, QueueItemAddMode.Normal);
                }

                while (QueueProcessorItem.GlobalProcessCount < items.Count)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                foreach (var testQueueProcessorItem in items)
                {
                    Assert.AreEqual(1, testQueueProcessorItem.ProcessCount);
                }

                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(0, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка добавление сообщений сразу в карантин универсальным методом (обработка через карантин).")]
        public void Test_Add_Emergency()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var items = new List<QueueProcessorItem>();
                for (var i = 0; i < 4; i++)
                {
                    items.Add(
                        new QueueProcessorItem(
                            _ => QueueItemProcessResult.Remove));
                }

                foreach (var testQueueProcessorItem in items)
                {
                    queue.Add(testQueueProcessorItem, QueueItemAddMode.Emergency);
                }

                while (QueueProcessorItem.GlobalProcessCount < items.Count)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                foreach (var testQueueProcessorItem in items)
                {
                    Assert.AreEqual(1, testQueueProcessorItem.ProcessCount);
                }

                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка добавление сообщений сразу в карантин.")]
        public void Test_AddEmergency()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var items = new List<QueueProcessorItem>();
                for (var i = 0; i < 4; i++)
                {
                    items.Add(
                        new QueueProcessorItem(
                            _ => QueueItemProcessResult.Remove));
                }

                foreach (var testQueueProcessorItem in items)
                {
                    queue.AddEmergency(testQueueProcessorItem);
                }

                while (QueueProcessorItem.GlobalProcessCount < items.Count)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                foreach (var testQueueProcessorItem in items)
                {
                    Assert.AreEqual(1, testQueueProcessorItem.ProcessCount);
                }

                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка добавление сообщений сразу в карантин с проверкой? что время каратина не меньше ожидаемого.")]
        public void Test_AddEmergency_VarifyEmergencyTimeout()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();
            var emergencyTimeout = TimeSpan.FromSeconds(3);
            var timeService = new TimeService();

            using (var queue = new QueueProcessor(1, emergencyTimeout, "Test", exceptionPolicy, timeService, Guid.NewGuid()))
            {
                queue.Start();

                var items = new List<QueueProcessorItem>();
                for (var i = 0; i < 100; i++)
                {
                    var item = new QueueProcessorItem(
                        (self, processCount) =>
                        {
                            var times = (List<DateTimeOffset>)self.Tag;
                            times.Add(timeService.Now);

                            if (processCount <= 4)
                            {
                                return (QueueItemProcessResult.Poisoned);
                            }

                            return (QueueItemProcessResult.Remove);
                        })
                    {
                        Tag = new List<DateTimeOffset> { timeService.Now }
                    };
                    queue.AddEmergency(item);
                    items.Add(item);
                    Thread.Sleep(100);
                }

                foreach (var item in items)
                {
                    while (item.ProcessCount < 5)
                    {
                        Thread.Sleep(TimeSpan.FromMilliseconds(100));
                    }
                }
                Thread.Sleep(TimeSpan.FromSeconds(3));

                foreach (var item in items)
                {
                    Assert.AreEqual(5, item.ProcessCount);
                    var times = (List<DateTimeOffset>)item.Tag;
                    Assert.AreEqual(6, times.Count);

                    for (int i = 0; i < (times.Count - 1); i++)
                    {
                        var itemEemergencyTimeout = times[i + 1] - times[i];
                        Assert.GreaterOrEqual(itemEemergencyTimeout, emergencyTimeout);
                    }
                }

                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(5 * items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(items.Count, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(5 * items.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка обработки сообщения с исключением.")]
        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        public void Test_Process_Exception()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var item = new QueueProcessorItem(
                    processCount =>
                    {
                        if (processCount <= 4)
                        {
                            throw new ApplicationException("Test Exception");
                        }

                        return (QueueItemProcessResult.Remove);
                    });

                queue.Add(item);

                while (item.ProcessCount < 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Assert.AreEqual(5, item.ProcessCount);

                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(4, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(5, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(4).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка обработки отравленного сообщения.")]
        public void Test_Process_Poisoned()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var item = new QueueProcessorItem(
                    processCount =>
                    {
                        if (processCount <= 4)
                        {
                            return (QueueItemProcessResult.Poisoned);
                        }

                        return (QueueItemProcessResult.Remove);
                    });

                queue.Add(item);

                while (item.ProcessCount < 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Assert.AreEqual(5, item.ProcessCount);

                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(4, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(5, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка обработки сообщения требующего повторной обработки.")]
        public void Test_Process_Repeat()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var item = new QueueProcessorItem(
                    processCount =>
                    {
                        if (processCount <= 4)
                        {
                            return (QueueItemProcessResult.Repeat);
                        }

                        return (QueueItemProcessResult.Remove);
                    });

                queue.Add(item);

                while (item.ProcessCount < 5)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Assert.AreEqual(5, item.ProcessCount);

                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(0, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(5, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Unit)]
        [Timeout(TestTimeout.Unit)]
        [Description("Проверка обработки сообщения.")]
        public void Test_Process_Remove()
        {
            var exceptionPolicy = Substitute.For<IExceptionPolicy>();

            using (var queue = new QueueProcessor(1, TimeSpan.FromSeconds(1), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid()))
            {
                queue.Start();

                var item =
                    new QueueProcessorItem(
                        _ => QueueItemProcessResult.Remove);

                queue.Add(item);

                while (item.ProcessCount < 1)
                {
                    Thread.Sleep(TimeSpan.FromMilliseconds(100));
                }
                Thread.Sleep(TimeSpan.FromSeconds(1));

                Assert.AreEqual(1, item.ProcessCount);

                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(0, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(1, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                queue.Stop();
            }

            exceptionPolicy.Received(0).Apply(Arg.Any<Exception>());
            exceptionPolicy.Received(0).Notfy(Arg.Any<Exception>());
        }

        [Test]
        [Category(TestCategory.Long)]
        [Timeout(TestTimeout.Long)]
        [Description("Проверка многопоточной массоввой обработки сообщений.")]
        [SuppressMessage("ReSharper", "ParameterOnlyUsedForPreconditionCheck.Local")]
        public void Test_Process_Many()
        {
            var exceptionPolicy = new StubExceptionPolicy();

            var itemsException = new List<QueueProcessorItem>();
            var itemsPoisoned = new List<QueueProcessorItem>();
            var itemsRepeat = new List<QueueProcessorItem>();
            var itemsRemove = new List<QueueProcessorItem>();

            using (var queue = new QueueProcessor(8, TimeSpan.FromMilliseconds(100), "Test", exceptionPolicy, new TimeService(), Guid.NewGuid(), TimeSpan.FromSeconds(1)))
            {
                queue.Start();

                const int Size = 100_000;

                #region Exception

                for (var i = 0; i < Size; i++)
                {
                    var item = new QueueProcessorItem(
                        processCount =>
                        {
                            if (processCount <= 4)
                            {
                                throw new ApplicationException("Test Exception");
                            }

                            return (QueueItemProcessResult.Remove);
                        });
                    itemsException.Add(item);
                }

                #endregion

                #region Poisoned

                for (var i = 0; i < 2 * Size; i++)
                {
                    var item = new QueueProcessorItem(
                        processCount =>
                        {
                            if (processCount <= 4)
                            {
                                return (QueueItemProcessResult.Poisoned);
                            }

                            return (QueueItemProcessResult.Remove);
                        });
                    itemsPoisoned.Add(item);
                }

                #endregion

                #region Repeat

                for (var i = 0; i < 3 * Size; i++)
                {
                    var item = new QueueProcessorItem(
                        processCount =>
                        {
                            if (processCount <= 4)
                            {
                                return (QueueItemProcessResult.Repeat);
                            }

                            return (QueueItemProcessResult.Remove);
                        });
                    itemsRepeat.Add(item);
                }

                #endregion

                #region Remove

                for (var i = 0; i < 4 * Size; i++)
                {
                    var item =
                        new QueueProcessorItem(
                            _ => QueueItemProcessResult.Remove);
                    itemsRemove.Add(item);
                }

                #endregion

                #region Add

                var po =
                    new ParallelOptions
                    {
                        MaxDegreeOfParallelism = Environment.ProcessorCount,
                    };
                // ReSharper disable once AccessToDisposedClosure
                Parallel.ForEach(itemsException, po, queueProcessorItem => queue.Add(queueProcessorItem));
                // ReSharper disable once AccessToDisposedClosure
                Parallel.ForEach(itemsPoisoned, po, queueProcessorItem => queue.Add(queueProcessorItem));
                // ReSharper disable once AccessToDisposedClosure
                Parallel.ForEach(itemsRepeat, po, queueProcessorItem => queue.Add(queueProcessorItem));
                // ReSharper disable once AccessToDisposedClosure
                Parallel.ForEach(itemsRemove, po, queueProcessorItem => queue.Add(queueProcessorItem));

                #endregion

                #region Wait

                foreach (var queueProcessorItem in itemsException)
                {
                    while (queueProcessorItem.ProcessCount < 5)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
                foreach (var queueProcessorItem in itemsPoisoned)
                {
                    while (queueProcessorItem.ProcessCount < 5)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
                foreach (var queueProcessorItem in itemsRepeat)
                {
                    while (queueProcessorItem.ProcessCount < 5)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }
                foreach (var queueProcessorItem in itemsRemove)
                {
                    while (queueProcessorItem.ProcessCount < 1)
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));
                    }
                }

                Thread.Sleep(TimeSpan.FromSeconds(1));

                #endregion

                #region Validate

                foreach (var queueProcessorItem in itemsException)
                {
                    Assert.AreEqual(5, queueProcessorItem.ProcessCount);
                }
                foreach (var queueProcessorItem in itemsPoisoned)
                {
                    Assert.AreEqual(5, queueProcessorItem.ProcessCount);
                }
                foreach (var queueProcessorItem in itemsRepeat)
                {
                    Assert.AreEqual(5, queueProcessorItem.ProcessCount);
                }
                foreach (var queueProcessorItem in itemsRemove)
                {
                    Assert.AreEqual(1, queueProcessorItem.ProcessCount);
                }

                Assert.AreEqual(itemsException.Count + itemsPoisoned.Count + itemsRepeat.Count + itemsRemove.Count, queue.InfrastructureMonitor.GetSnapShot().CountAddedItems);
                Assert.AreEqual(4 * itemsException.Count + 4 * itemsPoisoned.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessingErrors);
                Assert.AreEqual(itemsException.Count + itemsPoisoned.Count + itemsRepeat.Count + itemsRemove.Count, queue.InfrastructureMonitor.GetSnapShot().CountRemovedItems);
                Assert.AreEqual(5 * itemsException.Count + 5 * itemsPoisoned.Count + 5 * itemsRepeat.Count + itemsRemove.Count, queue.InfrastructureMonitor.GetSnapShot().CountProcessedItems);

                #endregion

                queue.Stop();

                Console.WriteLine(queue.InfrastructureMonitor.GetSnapShot().ToJsonText(true));
            }

            Assert.AreEqual(0, exceptionPolicy.CallCountApply);
            Assert.AreEqual(4 * itemsException.Count, exceptionPolicy.CallCountNotfy);
        }
*/
}
