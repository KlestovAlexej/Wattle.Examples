using ShtrihM.Wattle3.Examples.DomainObjects.Examples.PostgreSql.Implements;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Tests;

public partial class AutoTestsMapperDocument
{
    private IPartitionsManager m_partitions;

    partial void DoSetUp()
    {
        m_partitions = ((MapperDocument)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }
}

