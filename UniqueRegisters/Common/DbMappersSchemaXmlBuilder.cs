using NUnit.Framework;
using Acme.Wattle.CodeGeneration.Generators.Schem;
using Acme.Wattle.Examples.Common;
using Acme.Wattle.Testing;
using System;
using System.IO;

namespace Acme.Wattle.Examples.UniqueRegisters.Common;

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
