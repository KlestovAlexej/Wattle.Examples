using ShtrihM.Wattle3.DomainObjects.Interfaces;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.ChangeTracker;

public class DomainObjectTemplateChangeTracker : IDomainObjectTemplate
{
    private DomainObjectTemplateChangeTracker()
    {
        /* NONE */
    }

    public static readonly DomainObjectTemplateChangeTracker Instance = new();
}