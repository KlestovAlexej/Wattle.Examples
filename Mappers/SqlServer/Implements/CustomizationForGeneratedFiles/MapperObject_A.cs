using ShtrihM.Wattle3.Caching;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Common;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.SqlServer;
using System;
using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Interface;
using ShtrihM.Wattle3.Primitives;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.SqlServer.Implements;

public partial class MapperObject_A
{
    public static MapperObject_A NewWithCache(Mappers mappers, ITimeService timeService)
    {
        var actualDtoMemoryCache =
            new MemoryCacheMapperActualStateDto<Object_ADtoActual>(
                timeService,
                new MemoryCacheSettings
                {
                    ExpirationTimeout =
                    {
                        Value = TimeSpan.FromMinutes(2)
                    },
                    Enabled =
                    {
                        Value = true
                    },
                    PollingInterval =
                    {
                        Value = TimeSpan.FromMinutes(5)
                    },
                    ActiveExpired =
                    {
                        Value = true
                    },
                    ExpirationMode =
                    {
                        Value = MemoryCacheSettings.ExpirationTimeoutMode.Absolute
                    },
                    FillFactor =
                    {
                        Value = 99
                    },
                    FoundBehavior =
                    {
                        Value = MemoryCacheSettings.FoundBehaviorMode.None
                    },
                    MaxItems =
                    {
                        Value = 1_000
                    },
                },
                $"Кэш актуальных данных состояния объекта '{nameof(WellknownDomainObjects.Object_A)}' в БД.",
                new LocksPoolEx<long>(
                    Guid.NewGuid(),
                    "Пул лок-объектов.",
                    "Пул лок-объектов.",
                    timeService),
                new BinarySerializerAsMessagePack<Object_ADtoActual>(),
                ServiceProviderHolder.Instance.GetRequiredService<IExceptionPolicy>());
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
