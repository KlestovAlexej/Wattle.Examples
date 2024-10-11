using Acme.Wattle.Caching;
using Acme.Wattle.DomainObjects;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Examples.DomainObjects.Common;
using Acme.Wattle.Mappers;
using Acme.Wattle.Mappers.PostgreSql;
using System;
using Acme.Wattle.Examples.DomainObjects.Examples.Generated.Interface;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.DomainObjects.Examples.Generated.PostgreSql.Implements;

public partial class MapperDocument
{
    public static MapperDocument NewWithCache(
        Mappers mappers, 
        ITimeService timeService,
        IExceptionPolicy exceptionPolicy)
    {
        var actualDtoMemoryCache =
            new MemoryCacheMapperActualStateDto<DocumentDtoActual>(
                timeService,
                new MemoryCacheSettings
                {
                    ExpirationTimeout =
                    {
                        Value = TimeSpan.FromMinutes(10)
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
                        Value = 1_000_000
                    },
                },
                $"Кэш актуальных данных состояния объекта '{nameof(WellknownDomainObjects.Document)}' в БД.",
                new LocksPoolEx<long>(
                    Guid.NewGuid(),
                    "Пул лок-объектов.",
                    "Пул лок-объектов.",
                    timeService),
                new BinarySerializerAsMessagePack<DocumentDtoActual>(),
                exceptionPolicy);
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

