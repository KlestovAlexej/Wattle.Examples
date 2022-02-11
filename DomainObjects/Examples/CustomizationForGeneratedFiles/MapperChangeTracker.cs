using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Implements;

public partial class MapperChangeTracker
{
    IPartitionsManager IPartitionsMapper.Partitions => Partitions;
}

