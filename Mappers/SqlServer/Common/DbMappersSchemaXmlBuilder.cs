using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.CodeGeneration.Generators.Schem;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Common;
using ShtrihM.Wattle3.Testing;

namespace ShtrihM.Wattle3.Examples.Mappers.SqlServer.Common;

/// <summary>
/// Создание XML-схемы мапперов по которой будет идти кодогенерация.
/// </summary>
[TestFixture]
[Explicit]
public class DbMappersSchemaXmlBuilder
{
    [Test]
    [Timeout(TestTimeout.Unit)]
    [Description("Генератор XML модели")]
    public void Test()
    {
        var mappers =
            new SchemaMappers
            {
                Storage = SchemaMapperStorage.SqlServer,
                CodeGeneration =
                    new SchemaMappersCodeGeneration
                    {
                        MappersCommonNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Common",
                        MappersIntefacesNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Interface",
                        MappersImplementsNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Implements",
                        MappersTestsNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Tests",
                        UnitTestCategoryName = TestCategory.Unit,
                        UnitTestTimeout = TestTimeout.Unit,
                    },
            };

        var schemaModel =
            new SchemaModel
            {
                Description = $"Генератор XML модели тут : {GetType().FullName}.{nameof(Test)}",
                Mappers = new List<SchemaMappers> { mappers }
            };

        foreach (var type in typeof(WellknownDomainObjectFields).GetNestedTypes())
        {
            if (type.IsDefined(typeof(SchemaMapperAttribute)))
            {
                var schemaMapperBuilder = SchemaMapperBuilder
                    .New()
                    .SetSchema(mappers.Storage)
                    .Configure(type);
                var schemaMapper = schemaMapperBuilder.CreateSchema(mappers.Storage);
                mappers.Mappers.Add(schemaMapper);
            }
        }

        var xml = schemaModel.ToXml();
        var fileName = Path.Combine(ProviderProjectBasePath.ProjectPath, @"Mappers\SqlServer\Implements\DbMappers.Schema.xml");
        Console.WriteLine(fileName);
        File.WriteAllText(fileName, xml);
    }
}
