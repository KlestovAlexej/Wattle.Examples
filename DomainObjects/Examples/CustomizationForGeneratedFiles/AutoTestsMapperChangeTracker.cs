using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Implements;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Tests;

public partial class AutoTestsMapperChangeTracker
{
    private IPartitionsManager m_partitions;

    partial void DoSetUp()
    {
        m_partitions = ((MapperChangeTracker)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }
}

