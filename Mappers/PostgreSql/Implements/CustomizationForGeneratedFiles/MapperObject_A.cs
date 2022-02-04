using System;
using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements;

public partial class MapperObject_A
{
    public static MapperObject_A NewWithCache(Mappers mappers, ITimeService timeService)
    {
        var actualDtoMemoryCache =
            new MemoryCacheMapperActualStateDto<Object_ADtoActual>(
                timeService,
                new MemoryCacheSettings
                {
                    ExpirationTimeout = TimeSpan.FromMinutes(2),
                    Enabled = true,
                    PollingInterval = TimeSpan.FromMinutes(5),
                    ActiveExpired = true,
                    ExpirationMode = MemoryCacheSettings.ExpirationTimeoutMode.Absolute,
                    FillFactor = 99,
                    FoundBehavior = MemoryCacheSettings.FoundBehaviorMode.None,
                    MaxItems = 1_000,
                },
                $"Кэш актуальных данных состояния объекта '{nameof(WellknownDomainObjects.Object_A)}' в БД.",
                new LocksPoolEx<long>(
                    Guid.NewGuid(),
                    "Пул лок-объектов.",
                    "Пул лок-объектов.",
                    timeService),
                new BinarySerializerAsMessagePack<Object_ADtoActual>());
        var result =
            new MapperObject_A(
                mappers.ExceptionPolicy,
                mappers.SelectFilterFactory,
                new InfrastructureMonitorMapper(
                    timeService,
                    Guid.NewGuid(),
                    $"Маппер данных состояния объекта '{nameof(WellknownDomainObjects.Object_A)}' в БД.",
                    $"Маппер данных состояния объекта '{nameof(WellknownDomainObjects.Object_A)}' в БД.",
                    actualDtoMemoryCache.InfrastructureMonitor),
                actualDtoMemoryCache);

        return result;
    }
}
