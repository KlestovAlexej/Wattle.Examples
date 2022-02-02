using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable CheckNamespace

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests;

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

