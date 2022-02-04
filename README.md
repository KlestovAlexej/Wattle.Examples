# Wattle3.Examples

Примеры использования фреймворка для создания высокопроизводительных серверов с доменными объектами моделирующими предметную область.

Фреймворк кроссплатформенный, написан 100% на C# под .NET 6.

Пакеты **nuget** начинаются с префикса [ShtrihM.Wattle3](https://www.nuget.org/packages?q=ShtrihM.Wattle3)

# Содержание
- [Телеметрия приложения](#телеметрия-приложения)
- [Автогенерация мапперов на чистом ADO.NET для PostgreSQL и SQL Server](#автогенерация-мапперов-на-чистом-adonet)
    - [Определение для кодогенератора мапперов](#определение-для-кодогенератора-мапперов)
    - [Создание XML-схемы мапперов по определению](#создание-xml-схемы-мапперов-по-определению)

---

## Телеметрия приложения
Простая публикация и доступ по REST-интерфейсу к произвольной телеметрии приложения.

В проекте [InfrastructureMonitoring](/InfrastructureMonitoring) весь код примера.

---
Клаcc приложения с телеметрией для публикации по REST-интерфейсу:
```csharp
public class CustomClassA
{
    ...

    // Телеметрия.
    public long Count;
}
```


[Swagger](https://swagger.io/) документация REST-интерфейса доступа к телеметрии приложения:
```csharp
http://localhost:5601/swagger/index.html
```

---
Получение значение телеметрии через REST-интерфейс используя C# и готовый клиент:
```csharp
using var client = new InfrastructureMonitorClient("localhost", 5601);

var snapshot = client.GetInfrastructureMonitorSnapshot(WellknownCustomInfrastructureMonitors.CustomClassA);
var snapShotValue = snapshot.Values.Single(v => v.Id == WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count);
var count = (long)snapShotValue.Data.Value;

Console.WriteLine(count);
```

---
Получение значение телеметрии через REST-интерфейс используя PowerShell:
```ps1
# Идентификатор объекта приложения с телеметрией - WellknownCustomInfrastructureMonitors.CustomClassA
$MonitorId = "153C867D-A122-44BB-B689-949FB8C61B00"

# Идентификатор значения с телеметрией - WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count
$ValueId = "50FF7F28-582B-4297-93EE-323FB812880F"

$Result = Invoke-WebRequest -Uri "http://localhost:5601/api/1/InfrastructureMonitor/GetInfrastructureMonitorSnapshotValue?monitorId=$MonitorId&valueId=$ValueId" -Method Get

Write-Host ($Result)
```

Полученное значение телеметрии:
```json
{
  "Id": "153c867d-a122-44bb-b689-949fb8c61b00",
  "Name": "Класс CustomClassA",
  "Description": "Класс CustomClassA",
  "SnapShotTime": "2022-01-31T15:12:48.6279777+03:00",
  "Value": {
    "Id": "50ff7f28-582b-4297-93ee-323fb812880f",
    "Name": "Количество элементов",
    "Description": "Количество элементов",
    "Data": {
      "Value": 11,
      "Type": "long"
    },
    "Group": null,
    "Tags": [
      "COUNT"
    ]
  }
}
```

## Автогенерация мапперов на чистом ADO.NET

Примеры автогенерённых ADO.NET мапперов для [PostgreSQL](/Mappers/PostgreSql/Implements/).

Примеры автогенерённых ADO.NET мапперов для [SQL Server](/Mappers/SqlServer/Implements/).

### Определение для кодогенератора мапперов

Пример определения структуры записи БД и параметров маппера (весь код примера [WellknownDomainObjectFields.cs](/Mappers/PostgreSql/Common/WellknownDomainObjectFields.cs)):

```csharp
[Description("Объект Object_A")]
[SchemaMapper(MapperId = WellknownDomainObjects.Text.Object_A, IsPrepared = true, IsCached = true, DeleteMode = SchemaMapperDeleteMode.Delete)]
[SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = ComplexIdentity.Level.L1)]
[SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
[SchemaMapperRevisionField(IsVersion = true)]
public static class Object_A
{
    [Description("Дата-время (DateTime). Обновляемое поле.")]
    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
    public static readonly Guid Value_DateTime = new("DCE071BB-796E-4397-91B8-EAF116747880");

    [Description("Дата-время (DateTime). Не обновляемое поле.")]
    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.NotUpdate)]
    public static readonly Guid Value_DateTime_NotUpdate = new("273A65E2-7647-42DB-A15D-58B69A64C69D");

    [Description("Число (long). Поле обновляется только при изменении значения.")]
    [SchemaMapperField(typeof(long), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
    public static readonly Guid Value_Long = new("87A005ED-CA51-4C60-83EC-6540AC0823D6");

    [Description("Число с поддержкой null (int?). Обновляемое поле.")]
    [SchemaMapperField(typeof(int?), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
    public static readonly Guid Value_Int = new("198251EF-8183-4A09-A760-E5BAAFBBB6FF");

    [Description("Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.")]
    [SchemaMapperField(typeof(string), DbIsNull = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
    public static readonly Guid Value_String = new("100E6573-B387-4CB5-B3D6-45DF4CB2CC9C");
}
```

### Создание XML-схемы мапперов по определению

Пример создания  XML-схемы маппера (весь код примера [DbMappersSchemaXmlBuilder.cs](/Mappers/PostgreSql/Common/DbMappersSchemaXmlBuilder.cs)):

```csharp
var mappers =
    new SchemaMappers
    {
        Storage = SchemaMapperStorage.PostgreSql,
        CodeGeneration =
            new SchemaMappersCodeGeneration
            {
                MappersCommonNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Common",
                MappersIntefacesNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface",
                MappersImplementsNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements",
                MappersTestsNamespaceName = "ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests",
                UnitTestCategoryName = TestCategory.Unit,
                UnitTestTimeout = TestTimeout.Unit,
            },
    };

var schemaModel =
    new SchemaModel
    {
        Description = $"Генератор XML модели тут : {GetType().FullName}",
        Mappers = new List<SchemaMappers> { mappers }
    };

var type = typeof(Object_A);

var schemaMapperBuilder = SchemaMapperBuilder
    .New()
    .SetSchema(mappers.Storage)
    .Configure(type);
var schemaMapper = schemaMapperBuilder.CreateSchema(mappers.Storage);
mappers.Mappers.Add(schemaMapper);

var xml = schemaModel.ToXml();

var fileName = Path.Combine(ProviderProjectBasePath.ProjectPath, @"Mappers\PostgreSql\Implements\DbMappers.Schema.xml");
File.WriteAllText(fileName, xml);
```
