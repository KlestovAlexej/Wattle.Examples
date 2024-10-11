using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Mappers.PostgreSql;
using Acme.Wattle.Utils;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.Mappers.PostgreSql.Implements.Generated.PostgreSql.Implements;

public partial class Mappers
{
    // ReSharper disable once ConvertToAutoProperty
    public IPostgreSqlMapperSelectFilterFactory SelectFilterFactory => m_selectFilterFactory;

    public void ReplaceMapper(IMapper mapper)
    {
        RemoveMapper(mapper.MapperId).SilentDispose();
        AddMapper(mapper);
    }
}
