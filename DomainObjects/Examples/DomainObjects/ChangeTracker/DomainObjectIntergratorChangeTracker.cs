using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using Unity;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;

/// <summary>
/// Класс автоматической регистрации доменного объекта в точке входа в доменную область.
/// </summary>
[DomainObjectIntergrator]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public class DomainObjectIntergratorChangeTracker : BaseDomainObjectIntergrator<IUnityContainer>
{
    #region Activator - Создание экземпляра доменного объекта по шаблону создания

    /// <summary>
    /// Создание экземпляра доменного объекта по шаблону создания.
    /// </summary>
    private class DomainObjectActivatorChangeTracker : BaseDomainObjectActivator<DomainObjectTemplateChangeTracker>
    {
        private readonly ComplexIdentity.Level m_complexIdentityLevel;
        private readonly PartitionsDay m_partitionsDay;
        private readonly IEntryPoint m_entryPoint;

        public DomainObjectActivatorChangeTracker(
            ComplexIdentity.Level complexIdentityLevel,
            PartitionsDay partitionsDay,
            IEntryPoint entryPoint)
            : base(WellknownDomainObjects.ChangeTracker)
        {
            m_complexIdentityLevel = complexIdentityLevel;
            m_partitionsDay = partitionsDay ?? throw new ArgumentNullException(nameof(partitionsDay));
            m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
        }

        /// <summary>
        /// Создание экземпляра доменного объекта.
        /// </summary>
        protected override IDomainObject DoCreate(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateChangeTracker template)
        {
            // Получить текущий Unit Of Work для данного потока.
            var unitOfWork = m_entryPoint.UnitOfWorkProvider.Instance;

            // Создание первичного ключа БД (идентити доменного объекта) для партиционированной таблицы.
            var nowDayIndex = m_partitionsDay.NowDayIndex;
            var identity = identityGenerator.GetNextIdentity(unitOfWork.GetMappersSession());
            identity = ComplexIdentity.Build(m_complexIdentityLevel, nowDayIndex, identity);

            // Создание экземпляра доменного объккта.
            var result = new DomainObjectChangeTracker(identity);

            // Регистрация созданного экземпляра доменного объекта в текущем Unit Of Work.
            unitOfWork.AddNew(result);

            return (result);
        }

        /// <summary>
        /// Асинхронное создание экземпляра доменного объекта.
        /// </summary>
        protected override async ValueTask<IDomainObject> DoCreateAsync(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateChangeTracker template,
            CancellationToken cancellationToken = default)
        {
            // Получить текущий Unit Of Work для данного потока.
            var unitOfWork = m_entryPoint.UnitOfWorkProvider.Instance;

            // Создание первичного ключа БД (идентити доменного объекта) для партиционированной таблицы.
            var nowDayIndex = m_partitionsDay.NowDayIndex;
            var mappersSession = await unitOfWork.GetMappersSessionAsync(cancellationToken).ConfigureAwait(false);
            var identity = await identityGenerator.GetNextIdentityAsync(mappersSession, cancellationToken).ConfigureAwait(false);
            identity = ComplexIdentity.Build(m_complexIdentityLevel, nowDayIndex, identity);

            // Создание экземпляра доменного объккта.
            var result = new DomainObjectChangeTracker(identity);

            // Регистрация созданного экземпляра доменного объекта в текущем Unit Of Work.
            unitOfWork.AddNew(result);

            return (result);
        }
    }

    #endregion

    #region DataActivator - Восстановление экземпляра доменного объекта по данным из БД

    /// <summary>
    /// Восстановление экземпляра доменного объекта по данным из БД.
    /// </summary>
    private class DomainObjectDataActivatorChangeTracker : BaseDomainObjectDataActivatorForActualStateDto<ChangeTrackerDtoActual>
    {
        public DomainObjectDataActivatorChangeTracker()
            : base(WellknownDomainObjects.ChangeTracker)
        {
        }

        protected override IDomainObject DoLoadObject(ChangeTrackerDtoActual dataDto)
        {
            var result = new DomainObjectChangeTracker(dataDto);

            return (result);
        }
    }

    #endregion

    /// <summary>
    /// Метод автоматической регистрации доменного объекта в точке входа в доменную область.
    /// </summary>
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ExampleEntryPoint>();
        var mapper = entryPoint.Mappers.GetMapper<IMapperChangeTracker>();
        var loggerFactory = container.Resolve<ILoggerFactory>();

        var identityCache =
            new IdentityCache<IMapperChangeTracker>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperChangeTracker)}"),
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                entryPoint.TimeService,
                entryPoint.ExceptionPolicy,
                entryPoint.WorkflowExceptionPolicy,
                TimeSpan.FromMinutes(30),
                mapper,
                10_000,
                fillFactor: 0.4f,
                timeoutWaitCacheReady: 100,
                methodGetNextIdentity:
                new PairMethods<Func<IMapperChangeTracker, IMappersSession, long>, Func<IMapperChangeTracker,
                    IMappersSession, CancellationToken, ValueTask<long>>>(
                    (m, session) => m.GetNextId(session),
                    (m, session, cancellationToken) => m.GetNextIdAsync(session, cancellationToken)),
                methodGetNextIdentityList: (m, session, count, cancellationToken) =>
                    m.GetNextIds(session, count, cancellationToken),
                logger: loggerFactory.CreateLogger<IdentityCache<IMapperChangeTracker>>());
        var dataMapper =
            new DomainObjectDataMapperNoDeleteUpdateDefault<IMapperChangeTracker, ChangeTrackerDtoNew, ChangeTrackerDtoActual>(
                entryPoint.TimeService,
                mapper,
                identityCache);
        entryPoint.DataMappers.AddMapper(dataMapper);

        entryPoint.ObjectRegisters.AddRegister(
            new DomainObjectRegisterStateless(
                WellknownDomainObjects.ChangeTracker,
                WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.ChangeTracker),
                dataMapper,
                new DomainObjectDataActivatorChangeTracker(),
                new DomainObjectActivatorChangeTracker(mapper.Partitions.Level, entryPoint.PartitionsDay, entryPoint),
                TimeSpan.FromSeconds(1),
                null,
                entryPoint.Mappers,
                entryPoint.TimeService,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.ExceptionPolicy,
                entryPoint.UnitOfWorkProvider,
                loggerFactory.CreateLogger<DomainObjectRegisterStateless>()));
    }
}