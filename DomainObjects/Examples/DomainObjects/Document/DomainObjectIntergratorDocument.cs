using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using Unity;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document;

/// <summary>
/// Класс автоматической регистрации доменного объекта в точке входа в доменную область.
/// </summary>
[DomainObjectIntergrator]
[SuppressMessage("ReSharper", "UnusedType.Global")]
public class DomainObjectIntergratorDocument : BaseDomainObjectIntergrator<IUnityContainer>
{
    #region Activator - Создание экземпляра доменного объекта по шаблону создания

    /// <summary>
    /// Создание экземпляра доменного объекта по шаблону создания.
    /// </summary>
    private class DomainObjectActivatorDocument : BaseDomainObjectActivator<DomainObjectTemplateDocument>
    {
        private readonly ExampleEntryPoint m_entryPoint;

        public DomainObjectActivatorDocument(ExampleEntryPoint entryPoint)
            : base(
                WellknownDomainObjects.Document,

                // Для автоматической регистрации созданного экземпляра доменного объекта в текущем Unit Of Work.
                unitOfWorkProvider: entryPoint.UnitOfWorkProvider)
        {
            m_entryPoint = entryPoint;
        }

        /// <summary>
        /// Создание экземпляра доменного объекта.
        /// </summary>
        protected override IDomainObject DoCreate(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateDocument template)
        {
            // Создание первичного ключа БД (идентити доменного объекта).
            var identity = identityGenerator.GetNextIdentity();

            var result = DoCreate(identity, template);

            return (result);
        }

        /// <summary>
        /// Асинхронное создание экземпляра доменного объекта.
        /// </summary>
        protected override async ValueTask<IDomainObject> DoCreateAsync(
            IDomainObjectIdentityGenerator identityGenerator,
            DomainObjectTemplateDocument template,
            CancellationToken cancellationToken = default)
        {
            // Создание первичного ключа БД (идентити доменного объекта).
            var identity = await identityGenerator.GetNextIdentityAsync(cancellationToken).ConfigureAwait(false);

            var result = DoCreate(identity, template);

            return (result);
        }

        /// <summary>
        /// Создание экземпляра доменного объекта.
        /// </summary>
        private IDomainObject DoCreate(long identity, DomainObjectTemplateDocument template)
        {
            var result = new DomainObjectDocument(m_entryPoint, identity, m_entryPoint.TimeService.NowDateTime, template);

            return (result);
        }
    }

    #endregion

    #region DataActivator - Восстановление экземпляра доменного объекта по данным из БД

    /// <summary>
    /// Восстановление экземпляра доменного объекта по данным из БД.
    /// </summary>
    private class DomainObjectDataActivatorDocument : BaseDomainObjectDataActivatorForActualStateDto<DocumentDtoActual>
    {
        private readonly IEntryPoint m_entryPoint;

        public DomainObjectDataActivatorDocument(IEntryPoint entryPoint)
            : base(WellknownDomainObjects.Document)
        {
            m_entryPoint = entryPoint ?? throw new ArgumentNullException(nameof(entryPoint));
        }

        protected override IDomainObject DoLoadObject(DocumentDtoActual dataDto)
        {
            var result = new DomainObjectDocument(m_entryPoint, dataDto);

            return (result);
        }
    }

    #endregion

    #region DomainObjectRegister - Кастомный реестр доменных объектов

    /// <summary>
    /// Кастомный реестр доменных объектов.
    /// </summary>
    private class DomainObjectRegisterStatelessDocument : DomainObjectRegisterStateless, IDomainObjectRegisterDocument
    {
        public DomainObjectRegisterStatelessDocument(
            IDomainObjectDataMapper dataMapper,
            IDomainObjectDataActivator dataActivator,
            IDomainObjectActivator activator,
            IMappers mappers,
            ITimeService timeService,
            IWorkflowExceptionPolicy workflowExceptionPolicy,
            IExceptionPolicy exceptionPolicy,
            IUnitOfWorkProvider unitOfWorkProvider,
            ILogger logger)
            : base(
                WellknownDomainObjects.Document,
                WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.Document),
                dataMapper,
                dataActivator,
                activator,
                TimeSpan.FromSeconds(1),
                null,
                mappers,
                timeService,
                workflowExceptionPolicy,
                exceptionPolicy,
                unitOfWorkProvider,
                logger)
        {
        }

        /// <summary>
        /// Найти доменный объект по идентити.
        /// </summary>
        /// <param name="identity">Идентити объекта.</param>
        /// <param name="throwIfNotFound">Генерировать исключение <seealso cref="InvalidOperationException"/> если доменный объект не найден.</param>
        /// <returns>Доменный объект или <see langword="null" /> если объект не найден.</returns>
        public IDomainObjectDocument Find(long identity, bool throwIfNotFound = false)
        {
            var result = base.Find(identity);

            if (throwIfNotFound && (result is null))
            {
                throw new InvalidOperationException($"Не найден доменный объект '{typeof(IDomainObjectDocument)}' ({WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.Document)}) с идентити '{identity}'.");
            }

            return (IDomainObjectDocument)result;
        }

        /// <summary>
        /// Найти доменный объект по идентити.
        /// </summary>
        /// <param name="identity">Идентити объекта.</param>
        /// <param name="throwIfNotFound">Генерировать исключение <seealso cref="InvalidOperationException"/> если доменный объект не найден.</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Доменный объект или <see langword="null" /> если объект не найден.</returns>
        public async ValueTask<IDomainObjectDocument> FindAsync(long identity, bool throwIfNotFound = false, CancellationToken cancellationToken = default)
        {
            var result = await base.FindAsync(identity, cancellationToken).ConfigureAwait(false);

            if (throwIfNotFound && (result is null))
            {
                throw new InvalidOperationException($"Не найден доменный объект '{typeof(IDomainObjectDocument)}' ({WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.Document)}) с идентити '{identity}'.");
            }

            return (IDomainObjectDocument)result;
        }

        /// <summary>
        /// Создать доменный объект по шаблону.
        /// </summary>
        /// <param name="valueDateTime">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <param name="valueLong">Поле <see cref="IDomainObjectDocument.Value_Long"/>.</param>
        /// <param name="valueInt">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <returns>Созданный доменный объект.</returns>
        public IDomainObjectDocument New(DateTime valueDateTime, long valueLong, int? valueInt)
        {
            var result = New(new DomainObjectTemplateDocument(valueDateTime, valueLong, valueInt));

            return (IDomainObjectDocument)result;
        }

        /// <summary>
        /// Создать доменный объект по шаблону.
        /// </summary>
        /// <param name="valueDateTime">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <param name="valueLong">Поле <see cref="IDomainObjectDocument.Value_Long"/>.</param>
        /// <param name="valueInt">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Созданный доменный объект.</returns>
        public async ValueTask<IDomainObjectDocument> NewAsync(DateTime valueDateTime, long valueLong, int? valueInt, CancellationToken cancellationToken = default)
        {
            var result = await NewAsync(new DomainObjectTemplateDocument(valueDateTime, valueLong, valueInt), cancellationToken).ConfigureAwait(false);

            return (IDomainObjectDocument)result;
        }
    }

    /// <summary>
    /// Прокси уровня Unit Of Work для кастомного реестр доменных объектов <see cref="DomainObjectRegisterStatelessDocument"/>.
    /// </summary>
    [ProxyDomainObjectRegister(WellknownDomainObjects.Text.Document)]
    public class ProxyDomainObjectRegisterDocument : ProxyDomainObjectRegister, IDomainObjectRegisterDocument
    {
        /// <summary>
        /// Найти доменный объект по идентити.
        /// </summary>
        /// <param name="identity">Идентити объекта.</param>
        /// <param name="throwIfNotFound">Генерировать исключение <seealso cref="InvalidOperationException"/> если доменный объект не найден.</param>
        /// <returns>Доменный объект или <see langword="null" /> если объект не найден.</returns>
        public IDomainObjectDocument Find(long identity, bool throwIfNotFound = false)
        {
            var register = (IDomainObjectRegisterDocument)m_register;
            var result = register.Find(identity, throwIfNotFound);

            return result;
        }

        /// <summary>
        /// Найти доменный объект по идентити.
        /// </summary>
        /// <param name="identity">Идентити объекта.</param>
        /// <param name="throwIfNotFound">Генерировать исключение <seealso cref="InvalidOperationException"/> если доменный объект не найден.</param>
        /// <param name="cancellationToken">Токен отмены</param>
        /// <returns>Доменный объект или <see langword="null" /> если объект не найден.</returns>
        public ValueTask<IDomainObjectDocument> FindAsync(long identity, bool throwIfNotFound = false, CancellationToken cancellationToken = default)
        {
            var register = (IDomainObjectRegisterDocument)m_register;
            var result = register.FindAsync(identity, throwIfNotFound, cancellationToken);

            return result;
        }

        /// <summary>
        /// Создать доменный объект по шаблону.
        /// </summary>
        /// <param name="valueDateTime">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <param name="valueLong">Поле <see cref="IDomainObjectDocument.Value_Long"/>.</param>
        /// <param name="valueInt">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <returns>Созданный доменный объект.</returns>
        public IDomainObjectDocument New(DateTime valueDateTime, long valueLong, int? valueInt)
        {
            var register = (IDomainObjectRegisterDocument)m_register;
            var result = register.New(valueDateTime, valueLong, valueInt);

            return result;
        }

        /// <summary>
        /// Создать доменный объект по шаблону.
        /// </summary>
        /// <param name="valueDateTime">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <param name="valueLong">Поле <see cref="IDomainObjectDocument.Value_Long"/>.</param>
        /// <param name="valueInt">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Созданный доменный объект.</returns>
        public ValueTask<IDomainObjectDocument> NewAsync(DateTime valueDateTime, long valueLong, int? valueInt, CancellationToken cancellationToken = default)
        {
            var register = (IDomainObjectRegisterDocument)m_register;
            var result = register.NewAsync(valueDateTime, valueLong, valueInt, cancellationToken);

            return result;
        }
    }

    #endregion

    /// <summary>
    /// Метод автоматической регистрации доменного объекта в точке входа в доменную область.
    /// </summary>
    protected override void DoRun(IUnityContainer container)
    {
        var entryPoint = container.Resolve<ExampleEntryPoint>();
        var mapper = entryPoint.Mappers.GetMapper<IMapperDocument>();
        var loggerFactory = container.Resolve<ILoggerFactory>();

        var identityCache =
            new IdentityCache<IMapperDocument>(
                GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperDocument)}"),
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
                new PairMethods<Func<IMapperDocument, IMappersSession, long>, Func<IMapperDocument, IMappersSession,
                    CancellationToken, ValueTask<long>>>(
                    (m, session) => m.GetNextId(session),
                    (m, session, cancellationToken) => m.GetNextIdAsync(session, cancellationToken)),
                methodGetNextIdentityList: (m, session, count, cancellationToken) =>
                    m.GetNextIds(session, count, cancellationToken),
                logger: loggerFactory.CreateLogger<IdentityCache<IMapperDocument>>());

        var partitionsLevel = mapper.Partitions.Level;
        var partitionsDay = entryPoint.PartitionsDay;
        var dataMapper =
            new DomainObjectDataMapperFullDefault
                <IMapperDocument, DocumentDtoNew, DocumentDtoActual, DocumentDtoChanged, DocumentDtoDeleted>(
                    entryPoint.UnitOfWorkProvider,
                    entryPoint.TimeService,
                    mapper,
                    identityCache,
                    identityPrepare:
                    (_, identity) =>
                    {
                        // Создание первичного ключа БД (идентити доменного объекта) для партиционированной таблицы.
                        var nowDayIndex = partitionsDay.NowDayIndex;
                        identity = ComplexIdentity.Build(partitionsLevel, nowDayIndex, identity);

                        return identity;
                    });

        entryPoint.DataMappers.AddMapper(dataMapper);

        entryPoint.ObjectRegisters.AddRegister(
            new DomainObjectRegisterStatelessDocument(
                dataMapper,
                new DomainObjectDataActivatorDocument(entryPoint),
                new DomainObjectActivatorDocument(entryPoint),
                entryPoint.Mappers,
                entryPoint.TimeService,
                entryPoint.WorkflowExceptionPolicy,
                entryPoint.ExceptionPolicy,
                entryPoint.UnitOfWorkProvider,
                loggerFactory.CreateLogger<DomainObjectRegisterStatelessDocument>()));
    }
}