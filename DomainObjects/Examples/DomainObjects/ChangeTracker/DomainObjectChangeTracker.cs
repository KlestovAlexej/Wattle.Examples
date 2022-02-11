using System;
using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker
{
    public class DomainObjectChangeTracker : BaseDomainObject, IDomainObjectChangeTracker
    {
        public DomainObjectChangeTracker(ChangeTrackerDtoActual data)
            : base(data.Id)
        {
            /* NONE */
        }

        public DomainObjectChangeTracker(long identity)
            : base(identity)
        {
            /* NONE */
        }

        public override Guid TypeId => WellknownDomainObjects.ChangeTracker;

        /// <summary>
        /// Метод сбора данных доменного объекта для их отправки в БД.
        /// </summary>
        public override IDomainObjectData GetData(DomainObjectDataTarget target)
        {
            // Создание объекта.
            if (target == DomainObjectDataTarget.Create)
            {
                var data =
                    new ChangeTrackerDtoNew
                    {
                        Id = Identity,
                    };
                var result = new DomainObjectData(data);

                return (result);
            }

            return base.GetData(target);
        }
    }
}
