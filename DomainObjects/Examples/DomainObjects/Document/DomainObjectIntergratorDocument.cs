using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.DomainObjects.DomainObjectActivators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectDataMappers;
using ShtrihM.Wattle3.DomainObjects.DomainObjectIntergrators;
using ShtrihM.Wattle3.DomainObjects.DomainObjectsRegisters;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document
{
    /// <summary>
    /// Класс автоматической регистрации доменного объекта в точке входа в доменную область.
    /// </summary>
    [DomainObjectIntergrator]
    public class DomainObjectIntergratorDocument : BaseDomainObjectIntergrator
    {
        #region Activator - Создание экземпляра доменного объекта по шаблону создания

        /// <summary>
        /// Создание экземпляра доменного объекта по шаблону создания.
        /// </summary>
        private class DomainObjectActivatorDocument : BaseDomainObjectActivator<DomainObjectTemplateDocument>
        {
            private readonly ComplexIdentity.Level m_complexIdentityLevel;
            private readonly PartitionsDay m_partitionsDay;

            public DomainObjectActivatorDocument(
                ComplexIdentity.Level complexIdentityLevel,
                PartitionsDay partitionsDay)
                : base(WellknownDomainObjects.Document)
            {
                m_complexIdentityLevel = complexIdentityLevel;
                m_partitionsDay = partitionsDay ?? throw new ArgumentNullException(nameof(partitionsDay));
            }

            /// <summary>
            /// Создание экземпляра доменного объекта.
            /// </summary>
            protected override IDomainObject DoCreate(
                IDomainObjectIdentityGenerator identityGenerator, 
                DomainObjectTemplateDocument template)
            {
                // Получить текущий Unit Of Work для данного потока.
                var unitOfWork = ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().Instance;

                // Получить точку входа в доменную область.
                var entryPoint = (ExampleEntryPoint)unitOfWork.EntryPoint;

                // Создание первичного ключа БД (идентити доменного объекта) для партиционированной таблицы.
                var nowDayIndex = m_partitionsDay.NowDayIndex;
                var identity = identityGenerator.GetNextIdentity(unitOfWork.GetMappersSession());
                identity = ComplexIdentity.Build(m_complexIdentityLevel, nowDayIndex, identity);

                // Создание экземпляра доменного объккта.
                var result = new DomainObjectDocument(identity, entryPoint.TimeService.NowDateTime, template);

                // Регистрация созданного экземпляра доменного объекта в текущем Unit Of Work.
                unitOfWork.AddNew(result);

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
                // Получить текущий Unit Of Work для данного потока.
                var unitOfWork = ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().Instance;

                // Получить точку входа в доменную область.
                var entryPoint = (ExampleEntryPoint)unitOfWork.EntryPoint;

                // Создание первичного ключа БД (идентити доменного объекта) для партиционированной таблицы.
                var nowDayIndex = m_partitionsDay.NowDayIndex;
                var mappersSession = await unitOfWork.GetMappersSessionAsync(cancellationToken).ConfigureAwait(false);
                var identity = await identityGenerator.GetNextIdentityAsync(mappersSession, cancellationToken).ConfigureAwait(false);
                identity = ComplexIdentity.Build(m_complexIdentityLevel, nowDayIndex, identity);

                // Создание экземпляра доменного объккта.
                var result = new DomainObjectDocument(identity, entryPoint.TimeService.NowDateTime, template);

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
        private class DomainObjectDataActivatorDocument : BaseDomainObjectDataActivatorForActualStateDto<DocumentDtoActual>
        {
            public DomainObjectDataActivatorDocument()
                : base(WellknownDomainObjects.Document)
            {
            }

            protected override IDomainObject DoLoadObject(DocumentDtoActual dataDto)
            {
                var result = new DomainObjectDocument(dataDto);

                return (result);
            }
        }

        #endregion

        #region DataMapper - Работа с БД.

        private class DomainObjectDataMapperDocument : BaseDomainObjectDataMapperFull<IMapperDocument, DocumentDtoNew, DocumentDtoActual, DocumentDtoChanged, DocumentDtoDeleted>
        {
            public DomainObjectDataMapperDocument(
                ITimeService timeService,
                IMapperDocument mapper,
                IIdentityCache identityCache)
                : base(
                    timeService,
                    mapper,
                    WellknownDomainObjects.Document,
                    nameMethodMappperNew: new PairMethodsNames(nameof(IMapperDocument.New)),
                    nameMethodMappperExists: new PairMethodsNames(nameof(IMapperDocument.Exists)),
                    nameMethodMappperFind: new PairMethodsNames(nameof(IMapperDocument.Get)),
                    nameMethodMappperGetObjectCollectionPage: nameof(IMapperDocument.GetEnumeratorPage),
                    nameMethodMappperGetObjectEnumerator: nameof(IMapperDocument.GetEnumerator),
                    nameMethodMappperGetObjectsCount: nameof(IMapperDocument.GetCount),
                    nameMethodMappperGetObjectIdentitiesCollectionPage: nameof(IMapperDocument.GetEnumeratorIdentitiesPage),
                    nameMethodMappperUpdate: new PairMethodsNames(nameof(IMapperDocument.Update)),
                    nameMethodMappperDelete: new PairMethodsNames(nameof(IMapperDocument.Delete)),
                    nameMethodMappperExistsRevision: new PairMethodsNames(nameof(IMapperDocument.ExistsRevision)),
                    identityCache: identityCache)
            {
            }
        }
        #endregion

        /// <summary>
        /// Метод автоматической регистрации доменного объекта в точке входа в доменную область.
        /// </summary>
        /// <param name="context"></param>
        protected override void DoRun(DomainObjectIntergratorContext context)
        {
            var entryPoint = context.GetObject<ExampleEntryPoint>(ExampleEntryPoint.WellknownDomainObjectIntergratorContextObjectNames.EntryPoint);
            var mapper = entryPoint.Mappers.GetMapper<IMapperDocument>();

            var dataMapper = 
                new DomainObjectDataMapperDocument(
                    entryPoint.TimeService,
                    mapper,
                    new IdentityCache<IMapperDocument>(
                        GuidGenerator.New($"{mapper.MapperId} {nameof(IMapperDocument)}"),
                        $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                        $"Кэширующий провайдер идентити доменных объектов '{mapper.MapperId}'.",
                        entryPoint.TimeService,
                        entryPoint.ExceptionPolicy,
                        TimeSpan.FromMinutes(30), 
                        mapper,
                        10_000,
                        fillFactor: 0.4f,
                        timeoutWaitCacheReady: 100,
                        methodGetNextIdentity: 
                        new PairMethods<Func<IMapperDocument, IMappersSession, long>, Func<IMapperDocument, IMappersSession, CancellationToken, ValueTask<long>>>(
                            (m, session) => m.GetNextId(session),
                            (m, session, cancellationToken) => m.GetNextIdAsync(session, cancellationToken)),
                        methodGetNextIdentityList: (m, session, count) => m.GetNextIds(session, count)));
            entryPoint.DataMappers.AddMapper(dataMapper);

            entryPoint.ObjectRegisters.AddRegister(
                new DomainObjectRegisterStateless(
                    WellknownDomainObjects.Document,
                    WellknownDomainObjects.GetDisplayName(WellknownDomainObjects.Document),
                    dataMapper,
                    new DomainObjectDataActivatorDocument(),
                    new DomainObjectActivatorDocument(mapper.Partitions.Level, entryPoint.PartitionsDay),
                    TimeSpan.FromSeconds(1),
                    null,
                    entryPoint.Mappers,
                    entryPoint.TimeService,
                    entryPoint.WorkflowExceptionPolicy,
                    entryPoint.ExceptionPolicy));
        }
    }
}
