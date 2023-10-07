using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects;

/// <summary>
/// Идентификаторы интерфейсов мониторинга инфраструктуры.
/// </summary>
public static class WellknownCommonInfrastructureMonitors
{
    private static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

    static WellknownCommonInfrastructureMonitors()
    {
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType);
    }

    /// <summary>
    /// Создатель патртиций БД.
    /// </summary>
    [Description("Создатель патртиций БД")]
    public static readonly Guid PartitionsSponsor = new("153EF7B4-AA4C-4EE4-B5A1-82CB5C4133A9");

    /// <summary>
    /// Расписание создания патртиций БД.
    /// </summary>
    [Description("Расписание создания патртиций БД")]
    public static readonly Guid ActivatePartitionsSponsor = new("90F72243-5419-4622-8EAF-C9100E18403F");

    /// <summary>
    /// Очередь обработки аварийных ситуаций доменного поведения.
    /// </summary>
    [Description("Очередь обработки аварийных ситуаций доменного поведения")]
    public static readonly Guid QueueEmergencyDomainBehaviour = new("2CBFDCD6-02FF-4F0E-8F7C-90C0D1670DBB");

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(Guid id)
    {
        return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
    }
}