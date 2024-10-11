using Acme.Wattle.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Acme.Wattle.Examples.InfrastructureMonitoring.Models;

/// <summary>
/// Идентификаторы полей снимков интерфейсов мониторинга инфраструктуры.
/// </summary>
public static class WellknownCustomSnapShotInfrastructureMonitorValues
{
    private static readonly Dictionary<Guid, SnapShotInfrastructureMonitorValueDescription> DisplayDescriptions;

    static WellknownCustomSnapShotInfrastructureMonitorValues()
    {
        // ReSharper disable once PossibleNullReferenceException
        DisplayDescriptions = WellknownSnapShotInfrastructureMonitorValuesHelpers.CollectDescriptions(MethodBase.GetCurrentMethod().DeclaringType);
    }

    /// <summary>
    /// Идентификаторы полей снимков класса <see cref="CustomClassA"/>.
    /// </summary>
    public static class CustomClassA
    {
        [DisplayDescription("Количество элементов")]
        [Tags(WellknownCustomTags.Count)]
        public static readonly Guid Count = new("50FF7F28-582B-4297-93EE-323FB812880F");

        [DisplayDescription("Значение")]
        [DisplayGroup(WellknownCustomGroups.Value, WellknownCustomGroups.Names.Value)]
        public static readonly Guid Value = new("22113E9E-BCC8-4998-B312-B9C015E8CE1A");
    }

    /// <summary>
    /// Идентификаторы полей снимков класса <see cref="CustomClassB"/>.
    /// </summary>
    public static class CustomClassB
    {
        [DisplayDescription("Количество элементов")]
        [Tags(WellknownCustomTags.Count)]
        public static readonly Guid Count = new("0936D60E-8AE2-40CE-909A-951B032D2EE4");

        [DisplayDescription("Значение")]
        [DisplayGroup(WellknownCustomGroups.Value, WellknownCustomGroups.Names.Value)]
        public static readonly Guid Value = new("0462B7C4-6A27-4B52-BF05-7BDB1A6A2156");
    }

    /// <summary>
    /// Идентификаторы полей снимков класса <see cref="CustomClassC"/>.
    /// </summary>
    public static class CustomClassC
    {
        [DisplayDescription("Количество элементов")]
        [Tags(WellknownCustomTags.Count)]
        public static readonly Guid Count = new("D901E4E7-077C-44F9-ABB2-AC3104057469");

        [DisplayDescription("Значение")]
        [DisplayGroup(WellknownCustomGroups.Value, WellknownCustomGroups.Names.Value)]
        public static readonly Guid Value = new("4D864592-301F-4EB7-9F80-4B292FA619E5");
    }

    public static SnapShotInfrastructureMonitorValueDescription GetDescription(Guid id)
    {
        if (DisplayDescriptions.TryGetValue(id, out var result))
        {
            return (result);
        }

        throw new InvalidOperationException($"Описание '{id}' не найдено.");
    }
}