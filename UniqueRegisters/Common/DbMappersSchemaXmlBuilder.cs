using NUnit.Framework;
using ShtrihM.Wattle3.CodeGeneration.Generators.Schem;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Testing;
using System;
using System.IO;

namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Common;

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
        var schemaModel = SchemaModel.FromType(typeof(WellknownDomainObjectFields));
        var xml = schemaModel.ToXml();
        var fileName = Path.Combine(ProviderProjectBasePath.ProjectPath, @"UniqueRegisters\Examples\DbMappers.Schema.xml");
        Console.WriteLine(fileName);
        File.WriteAllText(fileName, xml);
    }
}
