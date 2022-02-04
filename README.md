# Wattle3.Examples

Примеры использования фреймворка для создания высокопроизводительных серверов с доменными объектами моделирующими предметную область.

Фреймворк кроссплатформенный, написан 100% на C# под .NET 6.

Пакеты **nuget** начинаются с префикса [ShtrihM.Wattle3](https://www.nuget.org/packages?q=ShtrihM.Wattle3)

# Содержание
- [Телеметрия приложения](#телеметрия-приложения)
- [Автогенерация мапперов на чистом ADO.NET для PostgreSQL и SQL Server](#автогенерация-мапперов-на-чистом-adonet)
    - [Определение для кодогенератора мапперов](#определение-для-кодогенератора-мапперов)
    - [Создание XML-схемы мапперов по определению](#создание-xml-схемы-мапперов-по-определению)
    - [Кодогенерация мапперов](#кодогенерация-мапперов)
    - [Основные возможности кодогенерированных мапперов](#основные-возможности-кодогенерированных-мапперов)
	- [Генерация уникального значения первичного ключа с минимальным обращением к БД](#генерация-уникального-значения-первичного-ключа-с-минимальным-обращением-к-бд)

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

### Кодогенерация мапперов

Пример проектного файла (весь примера в файле [Mappers.PostgreSql.Implements.csproj](/Mappers/PostgreSql/Implements/Mappers.PostgreSql.Implements.csproj)):

```xml
<Project Sdk="Microsoft.NET.Sdk">

	<ItemGroup>
		<AdditionalFiles Include="DbMappers.Schema.xml" />
	</ItemGroup>

	<ItemGroup>
		<PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.0.0" />
		<PackageReference Include="Npgsql" Version="6.0.3" />
		<PackageReference Include="NUnit" Version="3.13.2" />
		<PackageReference Include="NUnit3TestAdapter" Version="4.2.1" />
		<PackageReference Include="ShtrihM.Wattle3.CodeGeneration.Generators" Version="3.0.0.35768" />
		<PackageReference Include="ShtrihM.Wattle3.Common" Version="3.0.0.35768" />
		<PackageReference Include="ShtrihM.Wattle3.Mappers" Version="3.0.0.35768" />
		<PackageReference Include="ShtrihM.Wattle3.Mappers.PostgreSql" Version="3.0.0.35768" />
		<PackageReference Include="ShtrihM.Wattle3.Testing" Version="3.0.0.35768" />
		<PackageReference Include="ShtrihM.Wattle3.Testing.Databases.PostgreSql" Version="3.0.0.35768" />

		<!-- Кодогенератор общих определений для мапперов -->
		<PackageReference Include="ShtrihM.Wattle3.CodeGeneration.Generator.Common" Version="3.0.0.35768">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>

		<!-- Кодогенератор интерфейсов мапперов -->
		<PackageReference Include="ShtrihM.Wattle3.CodeGeneration.Generator.Interfaces" Version="3.0.0.35768">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>

		<!-- Кодогенератор реализаций мапперов -->
		<PackageReference Include="ShtrihM.Wattle3.CodeGeneration.Generator.Implements" Version="3.0.0.35768">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>

		<!-- Кодогенератор автоматических NUnit-тестов мапперов -->
		<PackageReference Include="ShtrihM.Wattle3.CodeGeneration.Generator.Tests" Version="3.0.0.35768">
			<PrivateAssets>all</PrivateAssets>
			<IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
		</PackageReference>
	</ItemGroup>

</Project>
```

Пример сгенерированного интерфейса маппера (весь примера в файле [DbMappers.Interfaces.Generated.cs](/Mappers/PostgreSql/Implements/GeneratedFiles/ShtrihM.Wattle3.CodeGeneration.Generator.Interfaces/ShtrihM.Wattle3.CodeGeneration.Generator.Interfaces.SourceGenerator/DbMappers.Interfaces.Generated.cs)):

```csharp
/// <summary>
/// Объект Object_A
/// </summary>
[MapperInterface(WellknownMappersAsText.Object_A)]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
// ReSharper disable once PartialTypeWithSinglePart
public partial interface IMapperObject_A : IMapper
{
    /// <summary>
    /// Имя таблицы БД.
    /// </summary>
    string TableName { get; }

    /// <summary>
    /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <returns>Возвращает следующего значение идентити.</returns>
    long GetNextId(IMappersSession session);

    /// <summary>
    /// Получение следующих значений идентити из последовательности "Sequence_Object_A".
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
    /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
    IList<long> GetNextIds(IMappersSession session, int count);

    /// <summary>
    /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает следующего значение идентити.</returns>
    ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка существования записис с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
    bool Exists(IMappersSession session, long id);

    /// <summary>
    /// Проверка существования записис с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
    ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка существования записис с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
    bool ExistsRaw(IMappersSession session, long id);

    /// <summary>
    /// Проверка существования записис с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
    ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Проверка существования записис с указаным идентити и указаной версией данных.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="revision">Ожидаемая версия данных записи.</param>
    /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
    bool ExistsRevision(IMappersSession session, long id, long revision);

    /// <summary>
    /// Проверка существования записис с указаным идентити и указаной версией данных.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="revision">Ожидаемая версия данных записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
    ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить запись с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
    Object_ADtoActual Get(IMappersSession session, long id);

    /// <summary>
    /// Получить запись с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
    ValueTask<Object_ADtoActual> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить запись с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
    Object_ADtoActual GetRaw(IMappersSession session, long id);

    /// <summary>
    /// Получить запись с указаным идентити.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
    ValueTask<Object_ADtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Обновить запись.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Измененная запись.</param>
    /// <returns>Возвращает актуальное состояние записи.</returns>
    Object_ADtoActual Update(IMappersSession session, Object_ADtoChanged data);

    /// <summary>
    /// Обновить запись.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Измененная запись.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает актуальное состояние записи.</returns>
    ValueTask<Object_ADtoActual> UpdateAsync(IMappersSession session, Object_ADtoChanged data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Массовое создание записей.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Записи.</param>
    void BulkInsert(IMappersSession session, IEnumerable<Object_ADtoNew> data);

    /// <summary>
    /// Массовое создание записей.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<Object_ADtoNew> data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создать запись.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Новая запись.</param>
    /// <returns>Возвращает актуальное состояние записи.</returns>
    Object_ADtoActual New(IMappersSession session, Object_ADtoNew data);

    /// <summary>
    /// Создать запись.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Новая запись.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает актуальное состояние записи.</returns>
    ValueTask<Object_ADtoActual> NewAsync(IMappersSession session, Object_ADtoNew data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Удаление записи.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Данные достаточные для удаления записи.</param>
    void Delete(IMappersSession session, Object_ADtoDeleted data);

    /// <summary>
    /// Удаление записи.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="data">Данные достаточные для удаления записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    ValueTask DeleteAsync(IMappersSession session, Object_ADtoDeleted data, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить итератор всех записей выбранных с учётом фильтра.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
    /// <returns>Возвращает итератор всех выбраных записей.</returns>
    IEnumerable<Object_ADtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null);

    /// <summary>
    /// Получить итератор всех записей выбранных с учётом фильтра.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
    /// <returns>Возвращает итератор всех выбраных записей.</returns>
    IEnumerable<Object_ADtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null);

    /// <summary>
    /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
    /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
    /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
    /// <returns>Возвращает итератор всех выбраных записей.</returns>
    IEnumerable<Object_ADtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

    /// <summary>
    /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
    /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
    /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
    /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
    IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

    /// <summary>
    /// Получить количество записей удовлетворяющих фильтру выборки.
    /// </summary>
    /// <param name="session">Сессия БД.</param>
    /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
    /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
    long GetCount(IMappersSession session, IMapperSelectFilter selectFilter = null);
}
```

### Основные возможности кодогенерированных мапперов

#### Генерация уникального значения первичного ключа с минимальным обращением к БД

Генератор уникальных первичных ключей работает на базе последовательностей БД.
Генератор позволяет получать уникальные значения без необходимости реального обращения к БД в момент генерации.

В файле [Examples.cs](/Mappers/PostgreSql/Implements/Examples.cs) весь код примера.

Пример последовательного создания 50.000.000 уникальных первичных ключей :

```csharp
        using IIdentityCache identityCache = CreateIdentityCache(100_000);

        var stopwatch = Stopwatch.StartNew();

        var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
        var identites = new HashSet<long>();
        for (var count = 0; count < 50_000_000; ++count)
        {
            using var mappersSession = mappers.OpenSession();

            var identity = identityCache.GetNextIdentity(mappersSession);

            Assert.IsFalse(identites.Contains(identity));
            identites.Add(identity);

            mappersSession.Commit();
        }

        stopwatch.Stop();

        Console.WriteLine($"Время работы : {stopwatch.Elapsed}");
        Console.WriteLine($"Количество идентити : {identites.Count}");

        {
            var snapShot = identityCache.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество идентити полученных из кэша в памяти (без обращения к БД) : {snapShot.CountIdentityFromCache}");
            Console.WriteLine($"Количество идентити полученных из БД : {snapShot.CountIdentityFromStorage}");
        }

        {
            var snapShot = mappers.InfrastructureMonitor.GetSnapShot();
            Console.WriteLine($"Количество реальных подключений к БД : {snapShot.CountDbConnections}");
            Console.WriteLine($"Количество сессий мапперов : {snapShot.CountSessions}");
        }
```

Результат последовательного создания 50.000.000 уникальных первичных ключей :

```
Время работы : 00:00:30.1632266
Количество идентити : 50000000
Количество идентити полученных из кэша в памяти (без обращения к БД) : 49999522
Количество идентити полученных из БД : 478
Количество реальных подключений к БД : 1311
Количество сессий мапперов : 50000834
```
