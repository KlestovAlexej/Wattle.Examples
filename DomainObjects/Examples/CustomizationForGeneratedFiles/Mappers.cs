using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Utils;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Implements;

public partial class Mappers
{
    public IPostgreSqlMapperSelectFilterFactory SelectFilterFactory => m_selectFilterFactory;

    partial void OnExitConstructor(object context)
    {
        var intergratorContext = (DomainObjectIntergratorContext)context;
        var timeService = intergratorContext.GetObject<ITimeService>(ExampleEntryPoint.WellknownDomainObjectIntergratorContextObjectNames.TimeService);

        var mapper = MapperDocument.NewWithCache(this, timeService);
        RemoveMapper(mapper.MapperId).SilentDispose();
        AddMapper(mapper);
    }
}

