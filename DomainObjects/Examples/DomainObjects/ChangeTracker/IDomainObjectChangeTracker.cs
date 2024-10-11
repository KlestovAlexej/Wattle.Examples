using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Examples.DomainObjects.Common;

namespace Acme.Wattle.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;

/// <summary>
/// Отслеживание изменений.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.ChangeTracker)]
public interface IDomainObjectChangeTracker : IDomainObject
{
    /* NONE */
}