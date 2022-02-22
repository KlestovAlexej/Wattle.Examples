using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace ShtrihM.Wattle3.Examples.InfrastructureMonitoring.Models;

/// <summary>
/// Идентификаторы интерфейсов мониторинга инфраструктуры.
/// </summary>
public static class WellknownCustomInfrastructureMonitors
{
    private static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

    static WellknownCustomInfrastructureMonitors()
    {
        // ReSharper disable once PossibleNullReferenceException
        WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod().DeclaringType);
    }

    /// <summary>
    /// Класс <see cref="CustomClassA"/>.
    /// </summary>
    [Description($"Класс {nameof(CustomClassA)}")]
    public static readonly Guid CustomClassA = new("153C867D-A122-44BB-B689-949FB8C61B00");

    /// <summary>
    /// Класс <see cref="CustomClassB"/>.
    /// </summary>
    [Description($"Класс {nameof(CustomClassB)}")]
    public static readonly Guid CustomClassB = new("D2826393-1619-4F02-ADB9-20B1FA4C31A9");

    /// <summary>
    /// Класс <see cref="CustomClassC"/>.
    /// </summary>
    [Description($"Класс {nameof(CustomClassC)}")]
    public static readonly Guid CustomClassC = new("169E750A-C384-47A1-8348-E81639409E54");

    public static string GetDisplayName(Guid id)
    {
        return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
    }
}