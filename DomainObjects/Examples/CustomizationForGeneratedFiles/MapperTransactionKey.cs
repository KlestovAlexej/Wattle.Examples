﻿using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using ShtrihM.Wattle3.Mappers.PostgreSql;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Implements;

public partial class MapperTransactionKey
{
    IPartitionsManager IMapperTransactionKey.Partitions => Partitions;
}
