using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Mappers.Primitives.MutableFields;
using System;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document
{
    [DomainObjectDataTargetAsCreate(typeof(DocumentDtoNew))]
    [DomainObjectDataTargetAsUpdate(typeof(DocumentDtoChanged))]
    [DomainObjectDataTargetAsDelete(typeof(DocumentDtoDeleted))]
    [DomainObjectDataTargetAsVersion]
    public class DomainObjectDocument : BaseDomainObject<DomainObjectDocument>, IDomainObjectDocument
    {
        [DomainObjectFieldValue(DomainObjectDataTarget.Update, DomainObjectDataTarget.Delete, DomainObjectDataTarget.Version)]
        public long Revision { get; }

        [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
        public DateTime CreateDate { get; }

        [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update)]
        public DateTime ModificationDate { get; private set; }

        public DateTime Value_DateTime
        {
            get => m_value_DateTime.Value;
            set
            {
                if (m_value_DateTime.SetValue(value))
                {
                    DoUpdated();
                }
            }
        }

        public long Value_Long
        {
            get => m_value_Long.Value;
            set
            {
                if (m_value_Long.SetValue(value))
                {
                    DoUpdated();
                }
            }
        }

        public int? Value_Int
        {
            get => m_value_Int.Value;
            set
            {
                if (m_value_Int.SetValue(value))
                {
                    DoUpdated();
                }
            }
        }

        public void Version()
        {
            var unitOfWork = ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().Instance;

            unitOfWork.AddVersion(this);
        }

        public void Delete()
        {
            var unitOfWork = ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().Instance;

            unitOfWork.AddDelete(this);
        }

        public string Method(DateTime value_DateTime, long value_Long, int? value_Int)
        {
            var changed = m_value_DateTime.SetValue(value_DateTime);
            changed = m_value_Long.SetValue(value_Long) || changed;
            changed = m_value_Int.SetValue(value_Int) || changed;

            if (changed)
            {
                DoUpdated();
            }

            return "Test";
        }

        private void DoUpdated()
        {
            var unitOfWork = ServiceProviderHolder.Instance.GetRequiredService<IUnitOfWorkProvider>().Instance;
            var entryPoint = (ExampleEntryPoint)unitOfWork.EntryPoint;
            ModificationDate = entryPoint.TimeService.NowDateTime;

            unitOfWork.AddUpdate(this);
        }

        #region Ритуальный код

        [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(WellknownDomainObjectFields.Document.Value_DateTime))]
        private MutableField<DateTime> m_value_DateTime;

        [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(WellknownDomainObjectFields.Document.Value_Long))]
        private MutableField<long> m_value_Long;

        [DomainObjectFieldValue(DomainObjectDataTarget.Create, DomainObjectDataTarget.Update, DtoFiledName = nameof(WellknownDomainObjectFields.Document.Value_Int))]
        private MutableFieldNullable<int> m_value_Int;

        /// <summary>
        /// Восстановить экземпляр из данных БД.
        /// </summary>
        public DomainObjectDocument(DocumentDtoActual data)
            : base(data.Id)
        {
            Revision = data.Revision;
            CreateDate = data.CreateDate.SpecifyKindLocal();
            ModificationDate = data.ModificationDate.SpecifyKindLocal();
            m_value_DateTime = data.Value_DateTime;
            m_value_Long = data.Value_Long;
            m_value_Int = data.Value_Int;
        }

        /// <summary>
        /// Создать экземпляр по данным шаблона.
        /// </summary>
        public DomainObjectDocument(
            long identity,
            DateTime createDate,
            DomainObjectTemplateDocument template)
            : base(identity)
        {
            CreateDate = createDate;
            ModificationDate = createDate;
            m_value_DateTime = template.Value_DateTime;
            m_value_Long = template.Value_Long;
            m_value_Int = template.Value_Int;
        }

        public override Guid TypeId => WellknownDomainObjects.Document;

        #endregion
    }
}
