using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;

/// <summary>
/// Отслеживание изменений.
/// </summary>
[DomainObjectInterface(WellknownDomainObjects.Text.ChangeTracker)]
public interface IDomainObjectChangeTracker : IDomainObject
{
    /* NONE */
}