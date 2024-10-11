using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Mappers.PostgreSql;
using Acme.Wattle.Utils;
using Unity;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.DomainObjects.Examples.Generated.PostgreSql.Implements;

public partial class Mappers
{
    // ReSharper disable once ConvertToAutoProperty
    public IPostgreSqlMapperSelectFilterFactory SelectFilterFactory => m_selectFilterFactory;

    partial void OnExitConstructor(object context)
    {
        var intergratorContext = (IUnityContainer)context;
        var timeService = intergratorContext.Resolve<ITimeService>();
        var exceptionPolicy = intergratorContext.Resolve<IExceptionPolicy>();

        var mapper = MapperDocument.NewWithCache(this, timeService, exceptionPolicy);
        RemoveMapper(mapper.MapperId).SilentDispose();
        AddMapper(mapper);
    }
}

