using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Infrastructures.Monitors;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.Wattle3.Examples.InfrastructureMonitoring.Models;

[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "FieldCanBeMadeReadOnly.Global")]
public class CustomClassA
{
    #region Infrastructure Monitor

    public class SnapShotInfrastructureMonitor : BaseCustomSnapShotInfrastructureMonitor
    {
        public SnapShotInfrastructureMonitor(
            IInfrastructureMonitor monitor,
            DateTimeOffset snapShotTime,
            long count,
            CustomValue value)
            : base(monitor, snapShotTime)
        {
            Count = count;
            Value = value;

            AddCustomWellknownValue(WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count, Count);
            AddCustomWellknownValue(WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Value, Value);
        }

        public long Count { get; }
        public CustomValue Value { get; }
    }

    public class InfrastructureMonitor : BaseInfrastructureMonitor
    {
        private readonly CustomClassA m_onwer;

        public InfrastructureMonitor(CustomClassA onwer)
            : base(
                WellknownCustomInfrastructureMonitors.CustomClassA,
                WellknownCustomInfrastructureMonitors.GetDisplayName(WellknownCustomInfrastructureMonitors
                    .CustomClassA),
                WellknownCustomInfrastructureMonitors.GetDisplayName(WellknownCustomInfrastructureMonitors
                    .CustomClassA))
        {
            m_onwer = onwer;
        }

        protected override ISnapShotInfrastructureMonitor DoGetSnapShot()
        {
            var result =
                new SnapShotInfrastructureMonitor(
                    this,
                    DateTimeOffset.Now,
                    m_onwer.Count,
                    m_onwer.Value);

            return (result);
        }
    }

    #endregion Infrastructure Monitor

    public CustomClassA()
    {
        Count = 1;
        Value =
            new CustomValue
            {
                Value1 = 2,
                Value2 = "3",
                Value3 = new byte[] { 4 },
            };
        ClassB = new CustomClassB();
        ClassC = new CustomClassC();

        Monitor = new InfrastructureMonitor(this);
        Monitor.AddSubMonitor(ClassB.Monitor);
        Monitor.AddSubMonitor(ClassC.Monitor);
    }

    public InfrastructureMonitor Monitor { get; }
    public CustomClassB ClassB { get; }
    public CustomClassC ClassC { get; }

    /// <summary>
    /// Телеметрия.
    /// <see cref="WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count"/>
    /// </summary>
    public long Count;

    public CustomValue Value;
}
