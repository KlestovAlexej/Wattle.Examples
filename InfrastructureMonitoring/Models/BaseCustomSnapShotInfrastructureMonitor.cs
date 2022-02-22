using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using System;

namespace ShtrihM.Wattle3.Examples.InfrastructureMonitoring.Models;

/// <summary>
/// Базовый снимок.
/// </summary>
public abstract class BaseCustomSnapShotInfrastructureMonitor : BaseSnapShotInfrastructureMonitor
{
    protected BaseCustomSnapShotInfrastructureMonitor(
        IInfrastructureMonitor monitor,
        DateTimeOffset snapShotTime,
        string stackTrace)
        : base(monitor, snapShotTime, stackTrace)
    {
    }

    protected void AddCustomWellknownValue<T>(Guid id, T value)
    {
        var description = WellknownCustomSnapShotInfrastructureMonitorValues.GetDescription(id);

        AddValue(id, value, description);
    }
}