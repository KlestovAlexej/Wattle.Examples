using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers.SqlServer;
using ShtrihM.Wattle3.Utils;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.SqlServer.Implements;

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
