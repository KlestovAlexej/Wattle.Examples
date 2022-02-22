using System;
using System.Diagnostics.CodeAnalysis;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Infrastructures.Monitors;

namespace ShtrihM.Wattle3.Examples.InfrastructureMonitoring.Models;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
public class CustomClassC
{
    #region Infrastructure Monitor

    public class SnapShotInfrastructureMonitor : BaseCustomSnapShotInfrastructureMonitor
    {
        public SnapShotInfrastructureMonitor(
            IInfrastructureMonitor monitor,
            DateTimeOffset snapShotTime,
            string stackTrace,
            long count,
            CustomValue value)
            : base(monitor, snapShotTime, stackTrace)
        {
            Count = count;
            Value = value;

            AddCustomWellknownValue(WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassC.Count, Count);
            AddCustomWellknownValue(WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassC.Value, Value);
        }

        public long Count { get; }
        public CustomValue Value { get; }
    }

    public class InfrastructureMonitor : BaseInfrastructureMonitor
    {
        private readonly CustomClassC m_onwer;

        public InfrastructureMonitor(CustomClassC onwer)
            : base(
                WellknownCustomInfrastructureMonitors.CustomClassC,
                WellknownCustomInfrastructureMonitors.GetDisplayName(WellknownCustomInfrastructureMonitors.CustomClassC),
                WellknownCustomInfrastructureMonitors.GetDisplayName(WellknownCustomInfrastructureMonitors.CustomClassC))
        {
            m_onwer = onwer;
        }

        protected override ISnapShotInfrastructureMonitor DoGetSnapShot()
        {
            var result =
                new SnapShotInfrastructureMonitor(
                    this,
                    DateTimeOffset.Now,
                    StackTrace,
                    m_onwer.Count,
                    m_onwer.Value);

            return (result);
        }
    }

    #endregion Infrastructure Monitor

    public CustomClassC()
    {
        Count = 1;
        Value =
            new CustomValue
            {
                Value1 = 2,
                Value2 = "3",
                Value3 = new byte[] { 4 },
            };
        Monitor = new InfrastructureMonitor(this);
    }

    public InfrastructureMonitor Monitor { get; }
    public long Count;
    public CustomValue Value;

}