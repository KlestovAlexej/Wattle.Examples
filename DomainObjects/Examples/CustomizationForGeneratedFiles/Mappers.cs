using System;
using ShtrihM.Wattle3.DomainObjects;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Utils;

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Implements;

public partial class Mappers
{
    public IPostgreSqlMapperSelectFilterFactory SelectFilterFactory => m_selectFilterFactory;

    partial void OnExitConstructor(object context)
    {
        var intergratorContext = (DomainObjectIntergratorContext)context;
        var entryPoint = intergratorContext.GetObject<ExampleEntryPoint>(ExampleEntryPoint.WellknownDomainObjectIntergratorContextObjectNames.EntryPoint);

        var mapper = MapperDocument.NewWithCache(this, entryPoint.TimeService);
        RemoveMapper(mapper.MapperId).SilentDispose();
        AddMapper(mapper);
    }
}

