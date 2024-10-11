using Acme.Wattle.Caching;
using Acme.Wattle.DomainObjects;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Examples.Mappers.SqlServer.Common;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.SqlServer;
using System;
using Acme.Wattle.Examples.Mappers.SqlServer.Implements.Generated.Interface;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.Mappers.SqlServer.Implements.Generated.SqlServer.Implements;

public partial class MapperObject_A
{
    public static MapperObject_A NewWithCache(
        Mappers mappers, 
        ITimeService timeService,
        IExceptionPolicy exceptionPolicy)
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
                exceptionPolicy);
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
