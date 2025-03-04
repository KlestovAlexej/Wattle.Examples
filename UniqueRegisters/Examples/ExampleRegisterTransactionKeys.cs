﻿using Microsoft.Extensions.Logging;
using Acme.Wattle.Common.Exceptions;
using Acme.Wattle.Common.Queries;
using Acme.Wattle.Containers;
using Acme.Wattle.DomainObjects.DomainBehaviours;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Primitives;
using Acme.Wattle.QueueProcessors;
using Acme.Wattle.QueueProcessors.Interfaces;
using Acme.Wattle.Triggers;
using Acme.Wattle.UniqueRegisters;
using Acme.Wattle.UniqueRegisters.Dictionaries;
using Acme.Wattle.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Acme.Wattle.Examples.UniqueRegisters.Examples.Generated.Common;
using Acme.Wattle.Examples.UniqueRegisters.Examples.Generated.Interface;

namespace Acme.Wattle.Examples.UniqueRegisters.Examples;

/// <summary>
/// Пример реестра уникальных ключей.
/// Все ключи хранятся в БД.
/// Ключи хранятся в партициях БД по дням их появления в реестре.
/// </summary>
public class ExampleRegisterTransactionKeys : UniqueRegisterWithScheduledCleanup<Guid, long, long, object, long>
{
    /// <summary>
    /// Количество дней в течении которых реестр помнит все ключи за эти дни и держит их в памяти.
    /// </summary>
    private static readonly int ActiveDays = 100;

    /// <summary>
    /// День с которого идёт нумерация дней.
    /// День с индексом ноль.
    /// </summary>
    private static readonly DateTime StartDay = new(2022, 12, 1);

    private static readonly int VariableGroupDays = 1;
    private static readonly int KeysRepairThreads = 2;
    private static readonly int KeysDeleteGroupThreads = 1;
    private static readonly TimeSpan KeysEmergencyTimeout = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan CleanupTimeoutKeys = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan InitializeThreadEmergencyTimeout = TimeSpan.FromSeconds(1);
    private static readonly string KeysFilePrefix = "TransactionKeys_";
    private static readonly string KeysDirectoryName = "TransactionKeys";

    private readonly ITimeService m_timeService;
    private readonly IMappers m_mappers;
    private readonly IWorkflowExceptionPolicy m_workflowExceptionPolicy;
    private readonly int m_activeDays;
    private readonly IMapperTransactionKey m_mapper;
    private readonly IIdentityCache m_identityCache;
    private readonly DateTime m_startDay;

    public ExampleRegisterTransactionKeys(
        IIdentityCache identityCache,
        string dataPath,
        IUnitOfWorkProvider unitOfWorkProvider,
        ILoggerFactory loggerFactory,
        IExceptionPolicy exceptionPolicy,
        ITimeService timeService,
        IMappers mappers,
        IWorkflowExceptionPolicy workflowExceptionPolicy)
        : base(
            exceptionPolicy,
            timeService,
            mappers,
            workflowExceptionPolicy,
            InitializeThreadEmergencyTimeout,
            new QueueItemProcessor(
                    KeysRepairThreads,
                    KeysEmergencyTimeout,
                    "Очередь восстановления реестра уникальных ключей транзакций.",
                    exceptionPolicy,
                    timeService,
                    new Guid("CBD01E52-4216-407C-9992-7EFBF3B76AE3"),
                    loggerFactory.CreateLogger<QueueItemProcessor>())
                .GetSmartDisposableReference<IQueueItemProcessor>(true),
            new CommandQueueProcessor(
                    KeysDeleteGroupThreads,
                    KeysEmergencyTimeout,
                    "Очередь удаления групп ключей в реестре уникальных ключей транзакций.",
                    exceptionPolicy,
                    timeService,
                    new Guid("DC36249F-38D0-4022-BE3E-AF95862C5696"),
                    loggerFactory.CreateLogger<CommandQueueProcessor>())
                .GetSmartDisposableReference<ICommandQueueProcessor>(true),
            "Реестр уникальных ключей транзакций.",
            new Guid("74230A27-D918-4655-81CA-BF866427CDD2"),
            new ScheduledService(
                    CleanupTimeoutKeys,
                    "Расписание очистки реестре уникальных ключей транзакций.",
                    exceptionPolicy,
                    timeService,
                    "Расписание очистки реестре уникальных ключей транзакций.",
                    new Guid("F1D06D78-F8F7-47F2-9442-522026203599"),
                    loggerFactory.CreateLogger<ScheduledService>())
                .GetSmartDisposableReference<ITrigger>(true),
            new SlimBytesUniqueRegisterDictionaryFactoryOfConcurrentDictionary(),
            unitOfWorkProvider,
            loggerFactory.CreateLogger<ExampleRegisterTransactionKeys>(),
            DomainBehaviourWithСonfirmation.DefaultMaxCountTryAndSkipVerify,
            CreateKeysPersistentStorage(dataPath))
    {
        m_timeService = timeService;
        m_mappers = mappers;
        m_workflowExceptionPolicy = workflowExceptionPolicy;
        m_activeDays = ActiveDays;
        m_mapper = m_mappers.GetMapper<IMapperTransactionKey>();
        m_startDay = StartDay;
        m_identityCache = identityCache;
    }

    public string DataPath => ((UniqueRegisterKeysPersistentStorageFileSystemGroupInt64)m_keysPersistentStorage!).BasePath;

    private static IUniqueRegisterKeysPersistentStorage<long> CreateKeysPersistentStorage(string dataPath)
    {
        var basePath = Path.Combine(dataPath, KeysDirectoryName);

        if (false == Directory.Exists(basePath))
        {
            Directory.CreateDirectory(basePath);
        }

        basePath = new DirectoryInfo(basePath).FullName;

        return new UniqueRegisterKeysPersistentStorageFileSystemGroupInt64(
            new UniqueRegisterKeysPersistentStorageFileSystemSettings
            {
                DeleteMode = UniqueRegisterKeysPersistentStorageFileSystemSettings.FilesDeleteMode.Rename,
                Enabled = true,
                BasePath = basePath,
            },
            new BaseUniqueRegisterKeysPersistentStorageFileSystem<long>.
                Description(
                    KeysFilePrefix,
                    new Guid("A2665BBA-BE84-414E-A1E9-0EC42F068079"),
                    new Guid("BED468F5-33F9-4784-8E93-9592B58C61FA")));
    }

    protected override WorkflowException CreateKeyNotFound(
        string details,
        Guid key)
    {
        var result = m_workflowExceptionPolicy.Create(
            CommonWorkflowException.ServiceTemporarilyUnavailable,
            details,
            $"Не найден ключ '{key}' транзакции.");

        return result;
    }

    protected override WorkflowException CreateKeyAlreadyRegistered(
        string details,
        Guid key,
        long actualTag,
        long existsTag,
        object context)
    {
        var result = m_workflowExceptionPolicy.Create(
            CommonWorkflowException.ServiceTemporarilyUnavailable,
            details,
            $"Ключ транзакции '{key}' уже зарегистрирован.");

        return result;
    }

    protected override WorkflowException CreateKeyAlreadyRegistered(
        string details,
        Guid key,
        long existsTag,
        object context)
    {
        var result = m_workflowExceptionPolicy.Create(
            CommonWorkflowException.ServiceTemporarilyUnavailable,
            details,
            $"Ключ транзакции '{key}' уже зарегистрирован.");

        return result;
    }

    protected override IEnumerable<(Guid Key, long Tag)> GetKeysEnumerator(
        CancellationToken cancellationToken,
        long goupId,
        object goupContext,
        out bool allowDuplicates,
        out long? countKeys)
    {
        allowDuplicates = false;
        countKeys = 0;

        return DoGetKeysEnumerator(cancellationToken, (PartitionInfo)goupContext);
    }

    private IEnumerable<(Guid Key, long Tag)> DoGetKeysEnumerator(
        CancellationToken cancellationToken,
        PartitionInfo partitionInfo)
    {
        using var session = m_mappers.OpenSession();

        var queryText = SchemaQueriesProvider
            .QueryForTransactionKey("WHERE (Id >= @MinId) AND (Id < @MaxId)")
            .AddParameter("MinId", QueryConstantTypes.Int64, partitionInfo.MinId)
            .AddParameter("MaxId", QueryConstantTypes.Int64, partitionInfo.MaxNotIncludeId)
            .GetQuery();
        var query = m_mapper.CreateSelectFilter(queryText);

        foreach (var dto in m_mapper.GetEnumerator(session, query))
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            yield return (dto.Key, dto.Tag);
        }

        session.Commit();
    }

    protected override IEnumerable<(long Goup, object GoupContext)> GetGoupsEnumerator(
        CancellationToken cancellationToken,
        out long? countGroups)
    {
        countGroups = 0;

        return DoGetGoupsEnumerator(cancellationToken);
    }

    private IEnumerable<(long Goup, object GoupContext)> DoGetGoupsEnumerator(CancellationToken cancellationToken)
    {
        using var session = m_mappers.OpenSession();
        foreach (var partition in m_mapper.Partitions.GetExistsPartitions(session))
        {
            if (cancellationToken.IsCancellationRequested)
            {
                break;
            }

            if (VerifyNeedDeleteGroup(partition.MinGroupId))
            {
                m_logger?.LogDebug($"Реестр уникальных ключей транзакуий. Партиция БД '{partition}' может быть удалена.");

                continue;
            }

            yield return (partition.MinGroupId, partition);
        }

        session.Commit();
    }

    protected override KeyIdentityInfo<long, long> NewKey(Guid key, long tag, object context)
    {
        var unitOfWork = m_unitOfWorkProvider.Instance;
        var mappersSession = unitOfWork.MappersSession;
        var identity = m_identityCache.GetNextIdentity(mappersSession);
        var dayIndex = GetDayIndex(m_timeService.NowDateTime);
        var instance =
            m_mapper.New(
                mappersSession,
                new TransactionKeyDtoNew
                {
                    Id = ComplexIdentity.Build(m_mapper.Partitions.Level, dayIndex, identity),
                    Key = key,
                    Tag = tag,
                });
        var result = new KeyIdentityInfo<long, long>(dayIndex, instance.Id);

        return result;
    }

    protected override async ValueTask<KeyIdentityInfo<long, long>> NewKeyAsync(Guid key, long tag, object context, CancellationToken token = default)
    {
        var unitOfWork = m_unitOfWorkProvider.Instance;
        var mappersSession = unitOfWork.MappersSession;
        var identity = await m_identityCache.GetNextIdentityAsync(mappersSession, token).ConfigureAwait(false);
        var dayIndex = GetDayIndex(m_timeService.NowDateTime);
        var instance =
            m_mapper.New(
                mappersSession,
                new TransactionKeyDtoNew
                {
                    Id = ComplexIdentity.Build(m_mapper.Partitions.Level, dayIndex, identity),
                    Key = key,
                    Tag = tag,
                });
        var result = new KeyIdentityInfo<long, long>(dayIndex, instance.Id);

        return result;
    }

    protected override UniqueRegisterExistsKeyResult ExistsKey(
        IMappersSession mappersSession,
        Guid key,
        long tag,
        object context,
        KeyIdentityInfo<long, long> keyIdentityInfo)
    {
        var resultExists = m_mapper.ExistsRaw(mappersSession, keyIdentityInfo.KeyIdentity);
        if (resultExists)
        {
            return (UniqueRegisterExistsKeyResult.Exists);
        }

        return (UniqueRegisterExistsKeyResult.NotExists);
    }

    protected override async ValueTask<UniqueRegisterExistsKeyResult> ExistsKeyAsync(
        IMappersSession mappersSession,
        Guid key,
        long tag,
        object context,
        KeyIdentityInfo<long, long> keyIdentityInfo)
    {
        var resultExists = await m_mapper.ExistsRawAsync(mappersSession, keyIdentityInfo.KeyIdentity).ConfigureAwait(false);
        if (resultExists)
        {
            return (UniqueRegisterExistsKeyResult.Exists);
        }

        return (UniqueRegisterExistsKeyResult.NotExists);
    }

    protected override bool VerifyNeedDeleteGroup(long goupId)
    {
        var nowDay = m_timeService.NowDateTime.Date;
        var minDay = nowDay.AddDays(-m_activeDays);
        var groupDay = GetDayByIndex(goupId);
        var result = (groupDay < minDay);

        return result;
    }

    protected override bool VerifyIsVariableGroup(long goupId)
    {
        var nowDay = m_timeService.NowDateTime.Date;
        var minDay = nowDay.AddDays(-VariableGroupDays);
        var groupDay = GetDayByIndex(goupId);
        var result = (groupDay >= minDay);

        return result;
    }

    protected override bool DeleteGoup(long goupId)
    {
        using var session = m_mappers.OpenSession();

        foreach (var partition in m_mapper.Partitions.GetExistsPartitions(session))
        {
            if (partition.MinGroupId == goupId)
            {
                m_logger?.LogDebug($"Реестр уникальных ключей операций. Удаление устаревшей партиции БД '{partition}'.");

                break;
            }
        }

        return true;
    }

    private DateTime GetDayByIndex(long dayIndex)
    {
        var result = m_startDay.AddDays(dayIndex);

        return result;
    }

    public long GetDayIndex(DateTime dateTime)
    {
        var result = (long)(dateTime - m_startDay).TotalDays;

        return result;
    }

    private class SlimBytesUniqueRegisterDictionaryFactoryOfConcurrentDictionary : BaseSlimBytesUniqueRegisterDictionaryFactoryOfConcurrentDictionary<Guid, long>
    {
        public SlimBytesUniqueRegisterDictionaryFactoryOfConcurrentDictionary()
            : base(
                new Guid("32DD4839-2E5B-47D0-9D19-BA2899CC91DE"),
                8,
                16,
                false)
        {
        }

        protected override byte[] KeyToBytes(Guid key)
        {
            return key.ToByteArray();
        }

        protected override byte[] ValueToBytes(long value)
        {
            return BitConverter.GetBytes(value);
        }

        protected override long ValueBytesToValue(ElementsFrame<byte> valueBytes)
        {
            var result = BitConverter.ToInt64(valueBytes.Elements, valueBytes.Index);

            return result;
        }
    }
}