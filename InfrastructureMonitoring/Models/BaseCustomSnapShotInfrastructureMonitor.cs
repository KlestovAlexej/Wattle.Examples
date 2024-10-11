using Acme.Wattle.Infrastructures.Interfaces.Monitors;
using Acme.Wattle.Infrastructures.Monitors;
using System;

namespace Acme.Wattle.Examples.InfrastructureMonitoring.Models;

/// <summary>
/// Базовый снимок.
/// </summary>
public abstract class BaseCustomSnapShotInfrastructureMonitor : BaseSnapShotInfrastructureMonitor
{
    protected BaseCustomSnapShotInfrastructureMonitor(
        IInfrastructureMonitor monitor,
        DateTimeOffset snapShotTime)
        : base(monitor, snapShotTime)
    {
    }

    protected void AddCustomWellknownValue<T>(Guid id, T value)
    {
        var description = WellknownCustomSnapShotInfrastructureMonitorValues.GetDescription(id);

        AddValue(id, value, description);
    }
}