using Microsoft.Extensions.Logging;
using ShtrihM.Wattle3.Common.Interfaces;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.DomainBehaviours;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.EntryPoints;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.QueueProcessors;
using ShtrihM.Wattle3.QueueProcessors.Interfaces;
using ShtrihM.Wattle3.Utils;
using System;
using System.Text;
using Unity;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples;

public class ExampleEntryPoint : BaseEntryPointEx
{
    private PartitionsSponsor m_prtitionsSponsor;
    private IQueueItemProcessor m_queueEmergencyDomainBehaviour;
    private InfrastructureMonitorRegisters m_infrastructureMonitorRegisters;

    #region Public Static Class

    public static class WellknownDomainObjectIntergratorContextObjectNames
    {
        public static readonly string ConnectionString = "ConnectionString";
    }

    #endregion

    private ExampleEntryPoint(
        IDomainObjectDataMappers dataMappers,
        IDomainObjectRegisters registers,
        IMappers mappers,
        IExceptionPolicy exceptionPolicy,
        IWorkflowExceptionPolicy workflowExceptionPolicy,
        ITimeService timeService,
        ILoggerFactory loggerFactory)
        : base(
            new UnitOfWorkProviderCallContext(),
            new InfrastructureMonitorEntryPoint(null, TimeSpan.FromMinutes(15), timeService),
            dataMappers,
            registers,
            mappers,
            exceptionPolicy,
            workflowExceptionPolicy,
            timeService,
            true,
            loggerFactory)
    {
        ((InfrastructureMonitorEntryPoint)InfrastructureMonitor).Owner = this;

        m_prtitionsSponsor = new PartitionsSponsor(this, loggerFactory);
        m_queueEmergencyDomainBehaviour =
            new QueueItemProcessor(
                2,
                TimeSpan.FromSeconds(2),
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour),
                m_exceptionPolicy,
                m_timeService,
                WellknownCommonInfrastructureMonitors.QueueEmergencyDomainBehaviour,
                loggerFactory.CreateLogger<QueueItemProcessor>(),
                TimeSpan.FromMinutes(30));
        PartitionsDay = new PartitionsDay(m_timeService);
        m_infrastructureMonitorRegisters = new InfrastructureMonitorRegisters();
        m_proxyDomainObjectRegisterFactories.AddFactories(GetType().Assembly);
    }

    public ITimeService TimeService => m_timeService;
    public IMappers Mappers => m_mappers;
    public IExceptionPolicy ExceptionPolicy => m_exceptionPolicy;
    public PartitionsDay PartitionsDay { get; }
    public WorkflowExceptionPolicy WorkflowExceptionPolicy => (WorkflowExceptionPolicy)m_workflowExceptionPolicy;
    public DomainObjectDataMappers DataMappers => (DomainObjectDataMappers)m_dataMappers;
    public DomainObjectRegisters ObjectRegisters => (DomainObjectRegisters)m_registers;

    /// <summary>
    /// Создание стратегии слежения за результатом исполнения Unit of Work.
    /// </summary>
    public DomainBehaviourWithСonfirmation CreateDomainBehaviourWithСonfirmation()
    {
        var unitOfWork = m_unitOfWorkProvider.Instance;
        var result =
            new DomainBehaviourWithСonfirmation(
                ExceptionPolicy,
                Mappers,
                m_queueEmergencyDomainBehaviour,
                unitOfWork.CommitVerifying);

        return result;
    }

    public override void Start()
    {
        base.Start();

        m_prtitionsSponsor.Start();
        m_queueEmergencyDomainBehaviour.Start();
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

    public override IUnitOfWork CreateUnitOfWork(object context = null)
    {
        if (IsReady)
        {
            return base.CreateUnitOfWork(context);
        }

        {
            var exception = WorkflowExceptionPolicy.Create(CommonWorkflowException.ServiceTemporarilyUnavailable, "Сервер в режиме инициализации.");

            throw exception;
        }
    }

    protected override bool GetIsReady()
    {
        var result =
            (base.GetIsReady()
             && m_prtitionsSponsor.IsReady
             && m_queueEmergencyDomainBehaviour.IsReady);

        return (result);
    }

    protected override void DoStop(bool isBackgroundStopping)
    {
        base.DoStop(isBackgroundStopping);

        if (isBackgroundStopping)
        {
            m_queueEmergencyDomainBehaviour.BeginStop();
            m_prtitionsSponsor.BeginStop();
        }
        else
        {
            m_queueEmergencyDomainBehaviour.Stop();
            m_prtitionsSponsor.Stop();
        }
    }

    protected override IUnitOfWork DoCreateUnitOfWork(IUnitOfWorkVisitor visitor, object context)
    {
        var result = new ExampleUnitOfWork(m_unitOfWorkContext, () => new ProxyDomainObjectRegisters(m_registers, m_proxyDomainObjectRegisterFactories), visitor);

        return result;
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);

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

    public static ExampleEntryPoint New(IUnityContainer container)
    {
        var timeService = container.ResolveWithDefault<ITimeService>(() => new TimeService());
        var loggerFactory = container.Resolve<ILoggerFactory>();
        var connectionString = container.Resolve<string>(WellknownDomainObjectIntergratorContextObjectNames.ConnectionString);
        var workflowExceptionPolicy = new WorkflowExceptionPolicy();
        var exceptionPolicy = new ExceptionPolicy(timeService, loggerFactory.CreateLogger<ExceptionPolicy>(), workflowExceptionPolicy);

        container.RegisterInstance(timeService, InstanceLifetime.External);
        container.RegisterInstance<IExceptionPolicy>(exceptionPolicy, InstanceLifetime.External);

        var result = new ExampleEntryPoint(
            new DomainObjectDataMappers(timeService),
            new DomainObjectRegisters(timeService),
            new Generated.PostgreSql.Implements.Mappers(
                new MappersExceptionPolicy(),
                connectionString,
                timeService,
                WellknownInfrastructureMonitors.Mappers,
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                WellknownInfrastructureMonitors.GetDisplayName(WellknownInfrastructureMonitors.Mappers),
                0,
                container),
            exceptionPolicy,
            workflowExceptionPolicy,
            timeService,
            loggerFactory);

        container.RegisterInstance(result, InstanceLifetime.External);

        var domainObjectIntergrators =
            new DefaultDomainObjectIntergrators<IUnityContainer>(loggerFactory.CreateLogger<DefaultDomainObjectIntergrators<IUnityContainer>>())
                .Add(result.GetType().Assembly);
        foreach (var domainObjectIntergrator in domainObjectIntergrators)
        {
            domainObjectIntergrator.Run(container);
        }

        var infrastructureMonitor = (InfrastructureMonitorEntryPoint)result.InfrastructureMonitor;
        infrastructureMonitor.AddSubMonitor(result.m_queueEmergencyDomainBehaviour.InfrastructureMonitor);
        infrastructureMonitor.AddSubMonitor(result.m_prtitionsSponsor.InfrastructureMonitor);

        result.m_infrastructureMonitorRegisters.AddMonitor(infrastructureMonitor);
        result.m_infrastructureMonitorRegisters.AddFavorit(infrastructureMonitor.Id);

        result.m_prtitionsSponsor.Create();

        result.SetInitialized();

        return (result);
    }
}
