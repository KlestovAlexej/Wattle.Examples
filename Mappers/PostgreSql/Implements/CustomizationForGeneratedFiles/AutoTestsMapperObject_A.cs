using Acme.Wattle.Examples.Mappers.PostgreSql.Implements.Generated.PostgreSql.Implements;
using Acme.Wattle.Mappers.Interfaces;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.Mappers.PostgreSql.Implements.Generated.Tests;

public partial class AutoTestsMapperObject_A
{
    private IPartitionsManager m_partitions;

    partial void DoSetUp()
    {
        m_partitions = ((MapperObject_A)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }
}

