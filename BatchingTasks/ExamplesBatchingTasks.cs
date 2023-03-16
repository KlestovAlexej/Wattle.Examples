using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.BatchingTasks;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Testing.DomainObjects;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.Wattle3.Examples.BatchingTasks;

/// <summary>
/// Примеры использования процессора пакетных задача.
/// </summary>
[TestFixture]
[SuppressMessage("ReSharper", "AccessToDisposedClosure")]
public class ExamplesBatchingTasks
{
    /// <summary>
    /// Многопоточное создание задач.
    /// </summary>
    [Test]
    public void Example_Threads()
    {
        #region Создание и запуск процессора пакетных задача

        var settings =
            new BatchingTasksProcessorSettings
            {
                // Интервал формирования пакета задач.
                CollectTasksTimeout =
                {
                    Value = TimeSpan.FromSeconds(3)
                },

                // Интервал ожидания конца выполнения пакета задач.
                ProcessTasksTimeout =
                {
                    Value = TimeSpan.FromSeconds(5)
                },

                // Максимальное количество пакетов задач в обрабаотке.
                MaxSizeBatchs =
                {
                    Value = 1_00
                }
            };

        // Максимальное количество задач в пакете.
        var maxSizeBatch = 2;

        // Создание и запуск процессора пакетных задача.
        using var processor = NewBatchingTasksProcessor(settings, maxSizeBatch);
        processor.Start();
        WaitHelpers.TimeOut(() => processor.GlobalIsReady, TimeSpan.FromMinutes(1));

        #endregion

        Parallel.For(0, maxSizeBatch * settings.MaxSizeBatchs.Value,
            _ =>
            {
                var task =
                    new BatchingTask
                    {
                        Timeout = null,
                    };

                var waitHandle = processor.Process(task);
                waitHandle.Wait();

                Assert.IsTrue(task.Processed);
            });

        var snapShot = processor.InfrastructureMonitor.GetSnapShot();

        Assert.AreEqual(snapShot.CountBatches, settings.MaxSizeBatchs.Value);
        Assert.AreEqual(snapShot.CountTasks, maxSizeBatch * settings.MaxSizeBatchs.Value);
        Assert.AreEqual(0, snapShot.CountActiveBatches);
        Assert.AreEqual(0, snapShot.CountActiveTasks);
    }

    /// <summary>
    /// Исполнение задач с ошибой.
    /// </summary>
    [Test]
    public void Example_Exception()
    {
        #region Создание и запуск процессора пакетных задача

        var settings =
            new BatchingTasksProcessorSettings
            {
                // Интервал формирования пакета задач.
                CollectTasksTimeout =
                {
                    Value = TimeSpan.FromSeconds(3)
                },

                // Интервал ожидания конца выполнения пакета задач.
                ProcessTasksTimeout =
                {
                    Value = TimeSpan.FromSeconds(30)
                },

                // Максимальное количество пакетов задач в обрабаотке.
                MaxSizeBatchs =
                {
                    Value = 1_00
                }
            };

        // Максимальное количество задач в пакете.
        var maxSizeBatch = 2;

        // Создание и запуск процессора пакетных задача.
        using var processor = NewBatchingTasksProcessor(settings, maxSizeBatch);
        processor.Start();
        WaitHelpers.TimeOut(() => processor.GlobalIsReady, TimeSpan.FromMinutes(1));

        #endregion

        // Задача без ошибки.
        var task_1 =
            new BatchingTask
            {
                Timeout = TimeSpan.FromSeconds(5),
                HasException = false,
            };

        // Задача с ошибкой исполнения.
        var task_2 =
            new BatchingTask
            {
                Timeout = TimeSpan.FromSeconds(5),
                HasException = true,
            };

        var waitHandle_1 = processor.Process(task_1);
        var waitHandle_2 = processor.Process(task_2);

        var exception = Assert.Throws<ApplicationException>(() => waitHandle_1.Wait());
        Assert.AreEqual("Ошибка исполнения задачи", exception!.Message);
        Assert.IsTrue(task_1.Processed);

        exception = Assert.Throws<ApplicationException>(() => waitHandle_2.Wait());
        Assert.AreEqual("Ошибка исполнения задачи", exception!.Message);
        Assert.IsFalse(task_2.Processed);

        {
            var snapShot = processor.InfrastructureMonitor.GetSnapShot();
            Assert.AreEqual(1, snapShot.CountBatches);
            Assert.AreEqual(2, snapShot.CountTasks);
            Assert.AreEqual(0, snapShot.CountActiveBatches);
            Assert.AreEqual(0, snapShot.CountActiveTasks);
        }
    }

    /// <summary>
    /// Исполнение задач в режиме Fire And Forget.
    /// </summary>
    [Test]
    public void Example_FireAndForget()
    {
        #region Создание и запуск процессора пакетных задача

        var settings =
            new BatchingTasksProcessorSettings
            {
                // Интервал формирования пакета задач.
                CollectTasksTimeout =
                {
                    Value = TimeSpan.FromSeconds(3)
                },

                // Интервал ожидания конца выполнения пакета задач - бесконечно.
                ProcessTasksTimeout =
                {
                    Value = null
                },

                // Максимальное количество пакетов задач в обрабаотке.
                MaxSizeBatchs =
                {
                    Value = 1_00
                }
            };

        // Максимальное количество задач в пакете.
        var maxSizeBatch = 3;

        // Создание и запуск процессора пакетных задача.
        using var processor = NewBatchingTasksProcessor(settings, maxSizeBatch);
        processor.Start();
        WaitHelpers.TimeOut(() => processor.GlobalIsReady, TimeSpan.FromMinutes(1));

        #endregion

        var task_1 =
            new BatchingTask
            {
                Timeout = TimeSpan.FromMinutes(1),
                FireAndForget = true,
            };
        var task_2 =
            new BatchingTask
            {
                Timeout = TimeSpan.FromMinutes(1),
                FireAndForget = true,
            };
        var task_3 =
            new BatchingTask
            {
                Timeout = TimeSpan.FromMinutes(1),
                FireAndForget = true,
            };

        var stopwatch = Stopwatch.StartNew();

        var waitHandle_1 = processor.Process(task_1);
        var waitHandle_2 = processor.Process(task_2);
        var waitHandle_3 = processor.Process(task_3);

        waitHandle_1.Wait();
        waitHandle_2.Wait();
        waitHandle_3.Wait();

        // Ожидание конца исполнения задач не было.
        stopwatch.Stop();
        Assert.Less(stopwatch.Elapsed, 2 * settings.CollectTasksTimeout.Value);

        Assert.IsFalse(task_1.Processed);
        Assert.IsFalse(task_2.Processed);
        Assert.IsFalse(task_3.Processed);

        {
            var snapShot = processor.InfrastructureMonitor.GetSnapShot();
            Assert.AreEqual(1, snapShot.CountBatches);
            Assert.AreEqual(3, snapShot.CountTasks);
            Assert.AreEqual(1, snapShot.CountActiveBatches);
            Assert.AreEqual(3, snapShot.CountActiveTasks);
            Assert.AreEqual(1, snapShot.CountNotifyEndProcessBatch);
        }

        // Ожидание конца исполнения задач.
        WaitHelpers.TimeOut(
            () => task_1.Processed,
            2 * task_1.Timeout.Value);

        WaitHelpers.TimeOut(
            () => task_2.Processed,
            2 * task_2.Timeout.Value);

        WaitHelpers.TimeOut(
            () => task_3.Processed,
            2 * task_3.Timeout.Value);

        WaitHelpers.TimeOut(
            () => processor.InfrastructureMonitor.GetSnapShot().CountActiveBatches == 0,
            TimeSpan.FromMinutes(1));

        {
            var snapShot = processor.InfrastructureMonitor.GetSnapShot();
            Assert.AreEqual(1, snapShot.CountBatches);
            Assert.AreEqual(3, snapShot.CountTasks);
            Assert.AreEqual(0, snapShot.CountActiveBatches);
            Assert.AreEqual(0, snapShot.CountActiveTasks);
            Assert.AreEqual(1, snapShot.CountNotifyEndProcessBatch);
        }
    }

    #region Enviroment

    private ILoggerFactory m_loggerFactory;
    private IExceptionPolicy m_exceptionPolicy;
    private WorkflowExceptionPolicy m_workflowExceptionPolicy;
    private ManagedTimeService m_timeService;

    [SetUp]
    public void SetUp()
    {
        // Настройка окружения.
        DomainEnviromentConfigurator
            .Begin(LoggerFactory.Create(builder => builder.AddConsole()), out m_loggerFactory, out _)
            .Build();

        m_timeService = new ManagedTimeService();
        m_workflowExceptionPolicy = new WorkflowExceptionPolicy();
        m_exceptionPolicy = new ExceptionPolicy(m_timeService, m_loggerFactory.CreateLogger<ExceptionPolicy>(), m_workflowExceptionPolicy);
    }

    [TearDown]
    public void TearDown()
    {
        DomainEnviromentConfigurator.DisposeAll();
    }

    private BatchingTasksProcessor NewBatchingTasksProcessor(
        BatchingTasksProcessorSettings settings,
        int maxSizeBatch)
        => new(
            maxSizeBatch,
            settings,
            m_exceptionPolicy,
            m_workflowExceptionPolicy,
            new TimeService(),
            TimeSpan.FromMinutes(20),
            new Guid("2443ED85-041B-4221-B744-D6DF2AA41386"),
            "Тест",
            "Тест",
            new QueueItemProcessor(
                    10,
                    TimeSpan.FromSeconds(1),
                    "Тест",
                    m_exceptionPolicy,
                    new TimeService(),
                    new Guid("6EEC2A9B-EFA6-46FD-B82E-B1E5C859EDDB"),
                    m_loggerFactory.CreateLogger(MethodBase.GetCurrentMethod()!.DeclaringType!))
                .GetSmartDisposableReference<IQueueItemProcessor>(true));

    #region Private Class BatchingTasksProcessor

    private class BatchingTasksProcessor : BaseBatchingTasksProcessor<BatchingTask>
    {
        #region Private Class BatchingTasksBatch

        private sealed class BatchingTasksBatch : IBatchingTasksBatch
        {
            private readonly object m_lockObject;
            private readonly int m_maxSizeBatch;
            private bool m_isReadOnly;
            private int m_countTasks;

            public BatchingTasksBatch(int maxSizeBatch)
            {
                m_maxSizeBatch = maxSizeBatch;
                m_lockObject = new object();
            }

            public void SetIsReadOnly()
            {
                lock (m_lockObject)
                {
                    m_isReadOnly = true;
                }
            }

            public bool TryAdd(BatchingTask task)
            {
                lock (m_lockObject)
                {
                    if (m_isReadOnly)
                    {
                        return false;
                    }

                    if (Tasks == null)
                    {
                        Tasks = new List<BatchingTask>();
                    }
                    else
                    {
                        if ((Tasks.Count + 1) > m_maxSizeBatch)
                        {
                            return false;
                        }

                    }

                    Tasks.Add(task);

                    ++m_countTasks;

                    return true;
                }
            }

            public bool IsReadOnly
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    lock (m_lockObject)
                    {
                        return m_isReadOnly;
                    }
                }
            }

            public int Count
            {
                [MethodImpl(MethodImplOptions.AggressiveInlining)]
                get
                {
                    lock (m_lockObject)
                    {
                        return m_countTasks;
                    }
                }
            }

            public List<BatchingTask> Tasks;
        }

        #endregion

        private readonly int m_maxSizeBatch;
        private readonly WorkflowExceptionPolicy m_workflowExceptionPolicy;

        public BatchingTasksProcessor(
            int maxSizeBatch,
            BatchingTasksProcessorSettings settings,
            IExceptionPolicy exceptionPolicy,
            WorkflowExceptionPolicy workflowExceptionPolicy,
            ITimeService timeService,
            TimeSpan stepTimeStatistics,
            Guid id,
            string name,
            string description,
            SmartDisposableReference<IQueueItemProcessor> queue)
            : base(
                settings, 
                exceptionPolicy, 
                workflowExceptionPolicy, 
                timeService, 
                stepTimeStatistics, 
                id, 
                name, 
                description, 
                queue)
        {
            m_maxSizeBatch = maxSizeBatch;
            m_workflowExceptionPolicy = workflowExceptionPolicy;
        }

        protected override WorkflowException DoCreateWorkflowExceptionTooManyBatches()
        {
            return m_workflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, "Cлишком много активных пакетов пакетных задач");
        }

        protected override void DoProcessBatch(
            IBatchingTasksBatch batch,
            Action notifyEndProcessBatch,
            CancellationToken cancellationToken)
        {
            var typedBatch = (BatchingTasksBatch)batch;

            if (typedBatch.Tasks.Count > 0)
            {
                if (typedBatch.Tasks.Any(t => t.FireAndForget))
                {
                    // Уведомить всех ожидающих конца исполнения пакета, что пакет исполнен.
                    // Режим исполнения пакета задач - Fire And Forget.
                    notifyEndProcessBatch();
                }

                foreach (var task in typedBatch.Tasks)
                {
                    if (task.Timeout.HasValue)
                    {
                        Thread.Sleep(task.Timeout.Value);
                    }

                    if (task.HasException)
                    {
                        throw new ApplicationException("Ошибка исполнения задачи");
                    }

                    task.Processed = true;
                }
            }
        }

        protected override IBatchingTasksBatch DoCreateBatch()
        {
            return new BatchingTasksBatch(m_maxSizeBatch);
        }
    }

    #endregion

    #region Private Class BatchingTask

    private class BatchingTask
    {
        public BatchingTask()
        {
            Timeout = TimeSpan.FromSeconds(1);
        }

        /// <summary>
        /// Признак того что задача исполнена успешно.
        /// </summary>
        public volatile bool Processed;

        /// <summary>
        /// Интервал задержки - исполнение задачи.
        /// </summary>
        public TimeSpan? Timeout;

        /// <summary>
        /// Генерировать ишибку при сиполнении ззадачи.
        /// </summary>
        public bool HasException;

        /// <summary>
        /// Уведомить всех ожидающих конца исполнения пакета, что пакет исполнен.
        /// Режим исполнения пакета задач - Fire And Forget.
        /// </summary>
        public bool FireAndForget;
    }

    #endregion

    #endregion
}
