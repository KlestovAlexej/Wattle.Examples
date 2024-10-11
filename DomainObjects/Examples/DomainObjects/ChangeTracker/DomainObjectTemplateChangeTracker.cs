using Acme.Wattle.DomainObjects.Interfaces;

namespace Acme.Wattle.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;

public class DomainObjectTemplateChangeTracker : IDomainObjectTemplate
{
    private DomainObjectTemplateChangeTracker()
    {
        /* NONE */
    }

    public static readonly DomainObjectTemplateChangeTracker Instance = new();
}