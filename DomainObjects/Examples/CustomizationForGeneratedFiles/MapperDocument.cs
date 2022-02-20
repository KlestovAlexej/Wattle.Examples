using System;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Implements;

public partial class MapperDocument
{
    public static MapperDocument NewWithCache(Mappers mappers, ITimeService timeService)
    {
        var actualDtoMemoryCache =
            new MemoryCacheMapperActualStateDto<DocumentDtoActual>(
                timeService,
                new MemoryCacheSettings
                {
                    ExpirationTimeout = TimeSpan.FromMinutes(10),
                    Enabled = true,
                    PollingInterval = TimeSpan.FromMinutes(5),
                    ActiveExpired = true,
                    ExpirationMode = MemoryCacheSettings.ExpirationTimeoutMode.Absolute,
                    FillFactor = 99,
                    FoundBehavior = MemoryCacheSettings.FoundBehaviorMode.None,
                    MaxItems = 1_000_000,
                },
                $"Кэш актуальных данных состояния объекта '{nameof(WellknownDomainObjects.Document)}' в БД.",
                new LocksPoolEx<long>(
                    Guid.NewGuid(),
                    "Пул лок-объектов.",
                    "Пул лок-объектов.",
                    timeService),
                new BinarySerializerAsMessagePack<DocumentDtoActual>());
        var result =
            new MapperDocument(
                mappers.ExceptionPolicy,
                mappers.SelectFilterFactory,
                new InfrastructureMonitorMapper(
                    timeService,
                    Guid.NewGuid(),
                    $"Маппер данных состояния объекта '{nameof(WellknownDomainObjects.Document)}' в БД.",
                    $"Маппер данных состояния объекта '{nameof(WellknownDomainObjects.Document)}' в БД.",
                    actualDtoMemoryCache.InfrastructureMonitor),
                actualDtoMemoryCache);

        return result;
    }
}

