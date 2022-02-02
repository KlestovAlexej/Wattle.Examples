using NUnit.Framework;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements;

[TestFixture]
public class ExamplesMapperObject_A : BaseExamplesMapper
{
    private Generated.Implements.Mappers m_mappers;
    private MapperObject_A m_mapper;
    private ITimeService m_timeService;

    [SetUp]
    public void SetUp()
    {
        m_timeService = new TimeService();
        m_mappers = new Generated.Implements.Mappers(new MappersExceptionPolicy(), m_dbConnectionString, m_timeService);
        m_mapper = (MapperObject_A)m_mappers.GetMapper<IMapperObject_A>();
    }

    [Test]
    [Description("Управление партициями БД.")]
    public void Test_GetEnumeratorTokenIdentities()
    {
    }
}

