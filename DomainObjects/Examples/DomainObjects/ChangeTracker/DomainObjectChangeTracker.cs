using ShtrihM.Wattle3.DomainObjects.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using System;
using System.Runtime.CompilerServices;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker
{
    [DomainObjectDataTargetAsCreate(typeof(ChangeTrackerDtoNew))]
    public class DomainObjectChangeTracker : BaseDomainObject<DomainObjectChangeTracker>, IDomainObjectChangeTracker
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DomainObjectChangeTracker(ChangeTrackerDtoActual data)
            : base(data.Id)
        {
            /* NONE */
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public DomainObjectChangeTracker(long identity)
            : base(identity)
        {
            /* NONE */
        }

        public override Guid TypeId => WellknownDomainObjects.ChangeTracker;
    }
}
