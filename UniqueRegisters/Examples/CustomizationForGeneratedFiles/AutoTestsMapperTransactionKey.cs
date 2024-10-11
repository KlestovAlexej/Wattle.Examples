using Acme.Wattle.Examples.UniqueRegisters.Examples.Generated.PostgreSql.Implements;
using Acme.Wattle.Mappers.Interfaces;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.UniqueRegisters.Examples.Generated.Tests;

public partial class AutoTestsMapperTransactionKey
{
    private IPartitionsManager m_partitions;

    partial void DoSetUp()
    {
        m_partitions = ((MapperTransactionKey)m_mapper).Partitions;

        using var session = m_mappers.OpenSession();
        m_partitions.CreatedDefaultPartition(session);
        session.Commit();
    }
}

