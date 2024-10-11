using Acme.Wattle.DomainObjects.DomainObjects;
using Acme.Wattle.Examples.DomainObjects.Common;
using System;
using System.Runtime.CompilerServices;
using Acme.Wattle.Examples.DomainObjects.Examples.Generated.Interface;

namespace Acme.Wattle.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;

[DomainObjectDataMapper]
public class DomainObjectChangeTracker : BaseDomainObject<DomainObjectChangeTracker>, IDomainObjectChangeTracker
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectChangeTracker(ChangeTrackerDtoActual data)
        : base(data.Id, false)
    {
        /* NONE */
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public DomainObjectChangeTracker(long identity)
        : base(identity, true)
    {
        /* NONE */
    }

    public override Guid TypeId => WellknownDomainObjects.ChangeTracker;
}