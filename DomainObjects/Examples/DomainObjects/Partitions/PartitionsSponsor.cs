using Microsoft.Extensions.Logging;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Services;
using ShtrihM.Wattle3.Triggers;
using ShtrihM.Wattle3.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Threading;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;

/// <summary>
/// Автоматический создатель партиция таблиц БД.
/// </summary>
public class PartitionsSponsor : BaseServiceScheduled
{
    private readonly ExampleEntryPoint m_entryPoint;
    private readonly List<IPartitionsManager> m_managers;

    public PartitionsSponsor(
        ExampleEntryPoint entryPoint,
        ILoggerFactory loggerFactory)
        : base(
            entryPoint.ExceptionPolicy,
            TimeSpan.FromSeconds(1),
            WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
            owner => new InfrastructureMonitorDrivenObject(
                WellknownCommonInfrastructureMonitors.PartitionsSponsor,
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.PartitionsSponsor),
                entryPoint.TimeService,
                owner),
            new ScheduledService(
                    TimeSpan.FromSeconds(1),
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor),
                    entryPoint.ExceptionPolicy,
                    entryPoint.TimeService,
                    WellknownCommonInfrastructureMonitors.GetDisplayName(WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor),
                    WellknownCommonInfrastructureMonitors.ActivatePartitionsSponsor,
                    loggerFactory.CreateLogger<ScheduledService>())
                .GetSmartDisposableReference<ITrigger>(true),
            loggerFactory.CreateLogger<PartitionsSponsor>())
    {
        m_entryPoint = entryPoint;
        m_managers = new List<IPartitionsManager>();
        foreach (var manager in GetAllPartitionsManagers(m_entryPoint.Mappers))
        {
            m_managers.Add(manager.PartitionsManager);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<(IMapper Mapper, IPartitionsManager PartitionsManager)> GetAllPartitionsManagers(IMappers mappers)
    {
        if (mappers == null)
        {
            throw new ArgumentNullException(nameof(mappers));
        }

        foreach (var mapper in mappers)
        {
            if (mapper is IPartitionsMapper partitionsMapper)
            {
                yield return (mapper, partitionsMapper.Partitions);
            }
        }
    }

    public void Create()
    {
        foreach (var manager in m_managers)
        {
            var nowDateTime = m_entryPoint.TimeService.NowDateTime;
            var nowDayPartitionInfo = manager.CreatePartitionInfo(m_entryPoint.PartitionsDay.GetDayIndex(nowDateTime), m_entryPoint.PartitionsDay.GetDayIndex(nowDateTime.AddDays(1)));
            var nextDayPartitionInfo = manager.CreatePartitionInfo(m_entryPoint.PartitionsDay.GetDayIndex(nowDateTime.AddDays(1)), m_entryPoint.PartitionsDay.GetDayIndex(nowDateTime.AddDays(2)));

            using var session = m_entryPoint.Mappers.OpenSession();
            var existsPartitions = manager.GetExistsPartitions(session);

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nowDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nowDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                var partitionInfo = manager.CreatePartition(
                    session,
                    nowDayPartitionInfo.MinGroupId,
                    nowDayPartitionInfo.MaxNotIncludeGroupId);

                m_logger.LogDebug($"Создана партиция БД '{partitionInfo}'.");
            }

            if (false == existsPartitions.Any(pi =>
                    (pi.MinGroupId == nextDayPartitionInfo.MinGroupId)
                    && (pi.MaxNotIncludeGroupId == nextDayPartitionInfo.MaxNotIncludeGroupId)))
            {
                var partitionInfo = manager.CreatePartition(
                    session,
                    nextDayPartitionInfo.MinGroupId,
                    nextDayPartitionInfo.MaxNotIncludeGroupId);

                m_logger.LogDebug($"Создана партиция БД '{partitionInfo}'.");
            }

            session.Commit();
        }
    }

    protected override bool DoInitialize(CancellationToken cancellationToken, out string retryReason)
    {
        retryReason = null;

        return true;
    }

    protected override void DoWork(CancellationToken cancellationToken)
    {
        try
        {
            Create();
        }
        catch (Exception exception)
        {
            if (m_logger.IsErrorEnabled())
            {
                m_logger.LogError(exception, "Ошибка создания партиций БД.");
            }

            ExceptionDispatchInfo.Capture(exception).Throw();
        }
    }
}