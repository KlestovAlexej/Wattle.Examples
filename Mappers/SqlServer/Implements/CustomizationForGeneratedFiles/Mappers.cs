using Acme.Wattle.Mappers.Interfaces;
using Acme.Wattle.Mappers.SqlServer;
using Acme.Wattle.Utils;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.Mappers.SqlServer.Implements.Generated.SqlServer.Implements;

public partial class Mappers
{
    // ReSharper disable once ConvertToAutoProperty
    public ISqlServerMapperSelectFilterFactory SelectFilterFactory => m_selectFilterFactory;

    public void ReplaceMapper(IMapper mapper)
    {
        RemoveMapper(mapper.MapperId).SilentDispose();
        AddMapper(mapper);
    }
}
