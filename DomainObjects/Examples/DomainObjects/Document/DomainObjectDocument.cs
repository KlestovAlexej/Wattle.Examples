using Microsoft.Extensions.DependencyInjection;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Mappers.Primitives.MutableFields;
using System;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Interface;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document
{
    public class DomainObjectDocument : BaseDomainObject, IDomainObjectDocument
    {
        public long Revision { get; }
        public DateTime CreateDate { get; }
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

        private MutableField<DateTime> m_value_DateTime;
        private MutableField<long> m_value_Long;
        private MutableFieldNullable<int> m_value_Int;

        /// <summary>
        /// Восстановить экземпляр из данных БД.
        /// </summary>
        public DomainObjectDocument(DocumentDtoActual data)
            : base(data.Id)
        {
            Revision = data.Revision;
            CreateDate = data.CreateDate;
            ModificationDate = data.ModificationDate;
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

        /// <summary>
        /// Сбор данных доменного объекта для их отправки в БД.
        /// </summary>
        public override IDomainObjectData GetData(DomainObjectDataTarget target)
        {
            // Создание объекта.
            if (target == DomainObjectDataTarget.Create)
            {
                var data =
                    new DocumentDtoNew
                    {
                        Id = Identity,
                        ModificationDate = ModificationDate,
                        CreateDate = CreateDate,
                        Value_DateTime = m_value_DateTime,
                        Value_Int = m_value_Int,
                        Value_Long = m_value_Long,
                    };
                var result = new DomainObjectData(data);

                return (result);
            }

            // Удаление объекта.
            if (target == DomainObjectDataTarget.Delete)
            {
                var data =
                    new DocumentDtoDeleted
                    {
                        Id = Identity,
                        Revision = Revision,
                    };
                var result = new DomainObjectData(data);

                return (result);
            }

            // Обновление объекта.
            if (target == DomainObjectDataTarget.Update)
            {
                var data =
                    new DocumentDtoChanged
                    {
                        Id = Identity,
                        Revision = Revision,
                        ModificationDate = ModificationDate,
                        CreateDate = CreateDate,
                        Value_DateTime = m_value_DateTime,
                        Value_Int = m_value_Int,
                        Value_Long = m_value_Long,
                    };
                var result = new DomainObjectData(data);

                return (result);
            }

            // Проверка ревизии объекта в БД.
            if (target == DomainObjectDataTarget.Version)
            {
                var result = new DomainObjectDataRevision(Identity, Revision);

                return (result);
            }

            return base.GetData(target);
        }

        #endregion
    }
}
