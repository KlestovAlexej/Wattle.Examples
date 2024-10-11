using Acme.Wattle.Examples.DomainObjects.Examples.Generated.PostgreSql.Implements;
using Acme.Wattle.Mappers.Interfaces;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.DomainObjects.Examples.Generated.Tests;

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

