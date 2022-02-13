using System;
using System.Reflection;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.DomainObjects.SystemMethods;
using ShtrihM.Wattle3.DomainObjects.UnitOfWorks;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Utils;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples;

public class ExampleEntryPoint : BaseEntryPoint
{
    #region Public Static Class

    public static class WellknownDomainObjectIntergratorContextObjectNames
    {
        public static readonly string TimeService = "TimeService";
        public static readonly string EntryPoint = "EntryPoint";
        public static readonly string ConnectionString = "ConnectionString";
    }

    #endregion

    private volatile bool m_stopping;
    private ProxyDomainObjectRegisterFactory m_proxyDomainObjectRegisterFactories;
    private UnitOfWorkContext m_unitOfWorkContext;
    private PartitionsSponsor m_prtitionsSponsor;
    private IMappers m_mappers;
    private IExceptionPolicy m_exceptionPolicy;
    private PartitionsDay m_partitionsDay;
    private InfrastructureMonitorRegisters m_infrastructureMonitorRegisters;
    private IQueueItemProcessor m_queueEmergencyDomainBehaviour;

    private ExampleEntryPoint(ITimeService timeService) 
        : base(timeService)
    {
        if (timeService == null)
        {
            throw new ArgumentNullException(nameof(timeService));
        }

        m_proxyDomainObjectRegisterFactories = new ProxyDomainObjectRegisterFactory();
        m_proxyDomainObjectRegisterFactories.AddFactories(GetType().Assembly);
        m_stopping = true;

    }

    public IQueueItemProcessor QueueEmergencyDomainBehaviour => m_queueEmergencyDomainBehaviour;
    public IMappers Mappers => m_mappers;
    public IExceptionPolicy ExceptionPolicy => m_exceptionPolicy;
    public PartitionsDay PartitionsDay => m_partitionsDay;
    public new WorkflowExceptionPolicy WorkflowExceptionPolicy => (WorkflowExceptionPolicy)m_workflowExceptionPolicy;
    public InfrastructureMonitorRegisters InfrastructureMonitorRegisters => m_infrastructureMonitorRegisters;
    public DomainObjectDataMappers DataMappers => (DomainObjectDataMappers)m_dataMappers;
    public DomainObjectRegisters ObjectRegisters => (DomainObjectRegisters)m_registers;

    public override void Start()
    {
        m_stopping = false;

        base.Start();

        m_prtitionsSponsor.Start();
        m_queueEmergencyDomainBehaviour.Start();
    }

    public override void Stop()
    {
        m_stopping = true;

        m_queueEmergencyDomainBehaviour.Stop();
        m_prtitionsSponsor.Stop();

        base.Stop();
    }

    public override void BeginStop()
    {
        m_stopping = true;

        m_queueEmergencyDomainBehaviour.BeginStop();
        m_prtitionsSponsor.BeginStop();

        base.BeginStop();
    }

    public override void WaitStop()
    {
        m_queueEmergencyDomainBehaviour.WaitStop();
        m_prtitionsSponsor.WaitStop();

        base.WaitStop();
    }

    public override bool GlobalIsReady
    {
        get
        {
            var result =
                (base.GlobalIsReady
                 && m_prtitionsSponsor.GlobalIsReady
                 && m_queueEmergencyDomainBehaviour.GlobalIsReady);

            return (result);
        }
    }

    public override bool IsReady
    {
        get
        {
            var result =
                (base.IsReady
                 && m_prtitionsSponsor.IsReady
                 && m_queueEmergencyDomainBehaviour.IsReady);

            return (result);
        }
    }

    public override IUnitOfWork CreateUnitOfWork(object context = null)
    {
        if (m_stopping)
        {
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, "Сервер в режиме остановки.");

            throw exception;
        }

        if (IsReady)
        {
            return base.CreateUnitOfWork(context);
        }

        {
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, "Сервер в режиме инициализации.");

            throw exception;
        }
    }

    protected override IUnitOfWork DoCreateUnitOfWork(IUnitOfWorkVisitor visitor, object context)
    {
        var registers = new ProxyDomainObjectRegisters(m_registers, m_proxyDomainObjectRegisterFactories);
        var result = new ExampleUnitOfWork(m_unitOfWorkContext, registers, visitor, false);

        return result;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

        {
            var temp = m_mappers;
            m_mappers = null;
            temp.SilentDispose();
        }

        {
            var temp = m_workflowExceptionPolicy;
            m_workflowExceptionPolicy = null;
            temp.SilentDispose();
        }

        {
            var temp = m_exceptionPolicy;
            m_exceptionPolicy = null;
            temp.SilentDispose();
        }

        {
            var temp = m_proxyDomainObjectRegisterFactories;
            m_proxyDomainObjectRegisterFactories = null;
            temp.SilentDispose();
        }

        {
            var temp = m_prtitionsSponsor;
            m_prtitionsSponsor = null;
            temp.SilentDispose();
        }

        {
            var temp = m_queueEmergencyDomainBehaviour;
            m_queueEmergencyDomainBehaviour = null;
            temp.SilentDispose();
        }

        {
            var temp = m_infrastructureMonitorRegisters;
            m_infrastructureMonitorRegisters = null;
            temp.SilentDispose();
        }
    }

    protected override string GetInitializeErrorMessage()
    {
        var text = new StringBuilder(base.GetInitializeErrorMessage());

        if (false == m_prtitionsSponsor.IsReady)
        {
            ApplyMessage(m_prtitionsSponsor.InfrastructureMonitor.GetSnapShot());
        }

        if (false == m_queueEmergencyDomainBehaviour.IsReady)
        {
            ApplyMessage(m_queueEmergencyDomainBehaviour.InfrastructureMonitor.GetSnapShot());
        }

        void ApplyMessage(ISnapShotInfrastructureMonitorDrivenObject snapShot)
        {
            if (snapShot.IsReady == false)
            {
                text.AppendLine(WellknownCommonInfrastructureMonitors.GetDisplayName(snapShot.Id));
                if (snapShot.InitializeErrorMessage != null)
                {
                    text.AppendLine(snapShot.InitializeErrorMessage);
                }

                text.AppendLine();
            }
        }

        return text.ToString();
    }

    public static ExampleEntryPoint New(DomainObjectIntergratorContext domainObjectIntergratorContext)
    {
        if (false == domainObjectIntergratorContext.TryGetObject<ITimeService>(WellknownDomainObjectIntergratorContextObjectNames.TimeService, out var timeService))
        {
            timeService = new TimeService();
            domainObjectIntergratorContext.AddObject(WellknownDomainObjectIntergratorContextObjectNames.TimeService, timeService);
        }

        var result = new ExampleEntryPoint(timeService);

        domainObjectIntergratorContext.AddObject(WellknownDomainObjectIntergratorContextObjectNames.EntryPoint, result);

        result.m_exceptionPolicy = new ExceptionPolicy(result.TimeService);
        result.m_partitionsDay = new PartitionsDay(timeService);
        result.m_infrastructureMonitorRegisters = new InfrastructureMonitorRegisters();

        var connectionString = domainObjectIntergratorContext.GetObject<string>(WellknownDomainObjectIntergratorContextObjectNames.ConnectionString);

        result.m_mappers =
            new Generated.Implements.Mappers(
                new MappersExceptionPolicy(),
                connectionString,
                timeService,
                TimeSpan.FromMinutes(30),
                0,
                domainObjectIntergratorContext);

        result.m_prtitionsSponsor = new PartitionsSponsor(result);
        result.m_workflowExceptionPolicy = new WorkflowExceptionPolicy();

        var dataMappers = new DomainObjectDataMappers();
        var registers = new DomainObjectRegisters(result.TimeService);

        var infrastructureMonitor = new InfrastructureMonitorEntryPoint(result, TimeSpan.FromMinutes(30), result.TimeService);

        result.Initialize(
            result.m_workflowExceptionPolicy,
            dataMappers,
            registers,
            new SystemMethodRegisters(),
            infrastructureMonitor);

        result.m_unitOfWorkContext = new UnitOfWorkContext(result,
                result.m_dataMappers,
                result.m_mappers,
                result.m_exceptionPolicy,
                result.m_workflowExceptionPolicy);

        result.m_queueEmergencyDomainBehaviour =
            new QueueItemProcessor(
                2,
                TimeSpan.FromSeconds(2),
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour),
                result.ExceptionPolicy,
                result.TimeService,
                WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour,
                TimeSpan.FromMinutes(30));

        var logger = ServiceProviderHolder.Instance.GetRequiredService<ILoggerFactory>().CreateLogger(result.GetType());
        var domainObjectIntergrators = new DefaultDomainObjectIntergrators(logger).Add(result.GetType().Assembly);
        foreach (var domainObjectIntergrator in domainObjectIntergrators)
        {
            domainObjectIntergrator.Run(domainObjectIntergratorContext);
        }

        infrastructureMonitor.AddSubMonitor(result.QueueEmergencyDomainBehaviour.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(result.m_prtitionsSponsor.InfrastructureMonitor);

        result.InfrastructureMonitorRegisters.AddMonitor(infrastructureMonitor);
        result.InfrastructureMonitorRegisters.AddFavorit(infrastructureMonitor.Id);

        result.m_prtitionsSponsor.Create();

        return (result);
    }
}
