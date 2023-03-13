# Wattle3.Examples

Примеры использования фреймворка для создания высокопроизводительных серверов с доменными объектами предметной области.

Фреймворк кроссплатформенный, написан 100% на [C#](https://ru.wikipedia.org/wiki/C_Sharp) под [.NET 7](https://devblogs.microsoft.com/dotnet/announcing-dotnet-7/).

Пакеты **nuget** начинаются с префикса [ShtrihM.Wattle3](https://www.nuget.org/packages?q=ShtrihM.Wattle3)

# Содержание
- [**Как запускать примеры**](#как-запускать-примеры)
- [**Идемпотентность**](#идемпотентность)
    - [Пример старта реестра на *500.000.000* уникальных ключей *(13.5 секунд)*](#пример-старта-реестра-на-500000000-уникальных-ключей-135-секунд)
- [**Контейнеры**](#контейнеры)
    - [**Массивы бесконечной длины**](#массивы-бесконечной-длины)
- [**Лок-объекты**](#лок-объекты)
- [**Телеметрия** приложения](#телеметрия-приложения)
- [**Доменные объекты**](#доменные-объекты)
    - [Паттерн **Unit of Work**](#паттерн-unit-of-work)
- [**Автогенерация мапперов** на чистом ADO.NET для PostgreSQL и SQL Server](#автогенерация-мапперов-на-чистом-adonet)
    - [Кодогенерация мапперов](#кодогенерация-мапперов)
    - [Основные возможности](#основные-возможности)
        - [**Генерация уникального** персистентного в БД значения **первичного ключа** с минимальным обращением к БД](#генерация-уникального-персистентного-в-бд-значения-первичного-ключа-с-минимальным-обращением-к-бд)
            - [Результат параллельного создания *50.000.000* уникальных первичных ключей *(33,7 секунд)*](#результат-параллельного-создания-50000000-уникальных-первичных-ключей-337-секунд)
        - [**Кэширование записей** по первичну ключу](#кэширование-записей-по-первичну-ключу)
            - [Результат параллельного чтения *10.000.000* записей БД по первичному ключу *(9,3 секунд)*](#результат-параллельного-чтения-10000000-записей-бд-по-первичному-ключу-93-секунд)
        - [**Поддержка партиционирования PostgreSQL** из коробки](#поддержка-партиционирования-postgresql-из-коробки)
---
## Как запускать примеры
Все примеры оформлены как [NUnit](https://nunit.org/)-тесты для запуска в ОС Windows из-под [Visual Studio 2022](https://visualstudio.microsoft.com/ru/vs/).

Все БД в примерах создаются и уничтожаются автоматически при запуске теста.

Параметры подключения к серверу БД надо настроить в файле [DbCredentials.cs](/Common/DbCredentials.cs) и примеры 100% готовы к запуску.

Базы данных на которых проверялись примеры [PostgreSQL 15.1](https://www.postgresql.org/) и [SQL Server 2019 Standard](https://www.microsoft.com/ru-ru/sql-server/sql-server-2019).

---
## Идемпотентность

[Идемпотентность](https://ru.wikipedia.org/wiki/%D0%98%D0%B4%D0%B5%D0%BC%D0%BF%D0%BE%D1%82%D0%B5%D0%BD%D1%82%D0%BD%D0%BE%D1%81%D1%82%D1%8C) поддерживается готовыми компонентами - *реестры уникальных ключей* из nuget пакета [ShtrihM.Wattle3.UniqueRegisters](https://www.nuget.org/packages/ShtrihM.Wattle3.UniqueRegisters/).

Реестры уникальных ключей реализуют:
- Хранение ключей в оперативной памяти и персистентно в БД.
- Ключи могут быть ассоциированы с произвольными данными, тоже хранимыми в памяти.
- Поиск ключа или данных по ключу происходит только в оперативной памяти и не задействует БД.
- Параллельная регистрация одного и того же уникального ключа не приводит к задвоениям или рассинхронизациям с БД.
- Есть сборка мусора - устаревшие ключи и данные автоматически удаляются из оперативной памяти по критерию заданным программистом.
- Адаптирован для применения партиционирования PostgreSQL таблицы ключей для изятия устаревших ключей из памяти и БД.
- Хранение ключей и данных в оперативной памяти оптимизировано и не нагружает сборщик мусора.
- Ключи и данные в оперативной памяти занимают места *O(_Число ключей * (размер ключа + размер данных)_)* и не расходуют память на служебную информацию CLR.
- Регистрация нового ключа задействует БД только в момент подтверждения [Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html).
- Регистрация нового ключа отменяется автоматически в аварийных ситуациях работы Unit of Work.
 
В проекте [UniqueRegisters.Examples](https://github.com/KlestovAlexej/Wattle3.Examples/tree/master/UniqueRegisters/Examples) весь код примеров.

### Пример старта реестра на **500.000.000** уникальных ключей *(13.5 секунд)*

В данном примере в БД создано 500.000.000 условных ключей транзакци и полезной нагрузки.
<br> На данной БД запускается реестр уникальных ключей для загрузки всех ключей в память.
<br>
Ключ : 16 байт [Guid](https://docs.microsoft.com/ru-ru/dotnet/api/system.guid?view=net-6.0)
<br>Данные : 8 байт [Long](https://docs.microsoft.com/ru-ru/dotnet/api/system.int64?view=net-6.0)
<br>Тест [Example_Start](https://github.com/KlestovAlexej/Wattle3.Examples/blob/master/UniqueRegisters/Examples/Examples.cs#L67) из примеров [Examples.cs](https://github.com/KlestovAlexej/Wattle3.Examples/blob/master/UniqueRegisters/Examples/Examples.cs).
<br>
| --------------------------------------- | ------------------- |
| Среднее время поиска данных по ключу    | 14,93 микросекунды  |
| Занято памяти                           | 12.000.534.024 байт |
| Время создания и инициализации реестра  | 13,4731972 секунды  |
<br>
<details><summary>Полный лог примера:</summary>

```
Текущее время тестов : 13.03.2023 1:00:00
Настройки сервера PostgreSQL (файл 'postgresql.conf').
max_connections = 500 # должно быть от '300'
enable_partition_pruning = on # должно быть 'on'

----------------------------------------------------------------------
Создание ключей в БД.

Время создания ключей : 00:18:21.2311782
Всего ключей : 500 000 000

----------------------------------------------------------------------
Старт реестра на '500 000 000' ключах в БД без файлового кэша.
Время старта и инициализации реестра : 00:53:10.1577561

Всего занято памяти тестом   : 12 008 085 976 байт
Занято памяти реестром       : 12 002 029 616 байт
Количество созданных Unit of Works : 0
Количество реальных подключений к БД : 8 364
Количество реальных транзакций БД    : 8 353
Количество сессий мапперов           : 8 364
Число зарегестрированных ключей : 500 000 000
Число регистраций ключей        : 
Количество загрузок групп ключей из персистентного хранилища : 0
Количество сохранений групп ключей в персистентное хранилище : 10

Содержимого файлового кэша для быстрого старта 'C:\Dev\Wattle3.Examples\UniqueRegisters\Examples\bin\Release\net7.0-windows\win-x64\Data\TransactionKeys' (файлов 10) :
gkeys_TransactionKeys_102.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_103.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_104.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_105.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_106.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_107.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_108.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_109.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_110.gkeys - размер 1 200 001 958
gkeys_TransactionKeys_111.gkeys - размер 1 200 001 958

----------------------------------------------------------------------
Старт реестра на '500 000 000' ключах в БД и файловом кэше.
Время создания и инициализации реестра : 00:00:13.4731972

Время поиска всех ключей                 : 02:04:29.1948556
Среднее время поиска ключа (микросекунд) : 14,938389711200001
Всего занято памяти тестом : 12 008 588 720 байт
Занято памяти реестром     : 12 000 534 024 байт
Количество созданных Unit of Works : 500 000 000
Количество реальных подключений к БД : 1
Количество реальных транзакций БД    : 0
Количество сессий мапперов           : 1
Число зарегестрированных ключей : 500 000 000
Число регистраций ключей        : 0
Количество загрузок групп ключей из персистентного хранилища : 10
Количество сохранений групп ключей в персистентное хранилище : 0

----------------------------------------------------------------------
Полное время теста : 03:16:41.5037651
```

</details>

Параметры ПК :<br>_OS Windows 11 Pro x64, CPU Intel Core i9-9900KS, RAM 48GB, SSD Samsung 970 Evo Plus 2Tb, DB PostgreSQL 15.1_

---
## Лок-объекты

В проекте [Locks](/Locks) весь код примеров.
<br>
<br> Лок-объекты позволяют получать монопольную блокировку используя для блокировки любой объект примпенимый в каченстве ключа [Dictionary](https://learn.microsoft.com/ru-ru/dotnet/api/system.collections.generic.dictionary-2?view=net-7.0).
<br>
<br> К примеру, на C# так блокировку получить нельзя :

```csharp
lock(123)
{
    ...
}
```
<br> Лок-объекты позволяют это делать :

```csharp
using var lockObject = locks.GetLock(123);
if (lockObject.TryEnter())
{
    ...
}
```
<br> Лок-объекты позволяют получать монопольную блокировку используя конструкцию [await](https://learn.microsoft.com/ru-ru/dotnet/csharp/language-reference/operators/await) :

```csharp

using var lockObject = locks.GetLock(123);
if (await lockObject.TryEnterAsync(cancellationToken))
{
    ...
}
```

---
## Контейнеры

В проекте [Containers](/Containers) весь код примеров.

---
### Массивы бесконечной длины

Массивы бесконечной длины позволяют создавать массивы (любых элементов) неограниченной длинны, на **всю доступную** оперативную память.

---
Тест [Example_Byte_Compare](/Containers/ExamplesFlexIncrementArrayElements.cs#L87) из примеров [ExamplesFlexIncrementArrayElements.cs](/Containers/ExamplesFlexIncrementArrayElements.cs).
<br>Сравнивает работу **массива бесконечной длины** с **[byte](https://learn.microsoft.com/ru-ru/dotnet/api/system.byte?view=net-7.0)[]**.
<details><summary>Полный лог теста :</summary>

```
Тест FlexIncrementArrayElements

Элементов массива      : 100 000 000
Выделено памяти (байт) : 100 000 000
Время                  : 00:00:00.0042149

Время заполнения памяти : 00:00:00.2242565

Время проверки памяти : 00:00:20.1773304
Время проверки памяти : 00:01:28.1654554

----------------------------------------------------------------------

Эталонный тест byte[]

Элементов массива      : 100 000 000
Выделено памяти (байт) : 100 000 000
Время                  : 00:00:00.0001068

Время заполнения памяти : 00:00:00.0519848

Время проверки памяти : 00:00:22.0954823
Время проверки памяти : 00:01:27.0711296
```

</details>

---
Тест [Example_Byte_Expand](/Containers/ExamplesFlexIncrementArrayElements.cs#L31) из примеров [ExamplesFlexIncrementArrayElements.cs](/Containers/ExamplesFlexIncrementArrayElements.cs).
<br>Cоздание массив из **30.000.000.000** элементов типа [byte](https://learn.microsoft.com/ru-ru/dotnet/api/system.byte?view=net-7.0).
<details><summary>Полный лог теста :</summary>

```
Элементов массива типа byte : 30 000 000 000
Выделено памяти (байт)      : 30 001 001 616
Время                       : 00:00:01.1994014
```

</details>

Параметры ПК :<br>_OS Windows 11 Pro x64, CPU Intel Core i9-9900KS, RAM 48GB, SSD Samsung 970 Evo Plus 2Tb_

---
## Телеметрия приложения

Простая публикация и доступ по REST-интерфейсу к произвольной телеметрии приложения.

Это не замена и не конкурент [OpenTelemetry](https://opentelemetry.io/).

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

---
## Доменные объекты
Фреймворк позволяет программировать [доменные объекты](https://en.wikipedia.org/wiki/Business_object) и максимально сосредоточиться на бизнес-значимых понятиях не в ущерб производительности.

В проекте [DomainObjects](/DomainObjects) весь код примеров.

---
### Паттерн Unit of Work
Работа с доменными объектами идёт в пределах [Unit of Work](https://martinfowler.com/eaaCatalog/unitOfWork.html) с контраком *IUnitOfWork*.
<br/>Сам Unit of Work создаётся точкой входа в доменную область с контраком *IEntryPoint*.

Весь код примеров в файле [Examples.cs](DomainObjects/Examples/Examples.cs).

<details>
<summary>Контракт IEntryPoint :</summary>

```csharp
/// <summary>
/// Точка входа в доменную область.
/// </summary>
public interface IEntryPoint : IDisposable, IDrivenObject
{
    /// <summary>
    /// Монитор инфраструктуры.
    /// </summary>
    new IInfrastructureMonitorEntryPoint InfrastructureMonitor { get; }

    /// <summary>
    /// Провайдер экземпляра <see cref="IUnitOfWork"/> для вызывающего потока.
    /// </summary>
    IUnitOfWorkProvider UnitOfWorkProvider { get; }

    /// <summary>
    /// Создание <see cref="IUnitOfWork"/> для вызывающего потока. 
    /// </summary>
    /// <param name="context">Конекст сосздания <see cref="IUnitOfWork"/>.</param>
    /// <returns>Созданный <see cref="IUnitOfWork"/>.</returns>
    /// <exception cref="InternalException">Если для вызывающего потока уже определён <see cref="IUnitOfWork"/>.</exception>
    IUnitOfWork CreateUnitOfWork(object context = null);

    /// <summary>
    /// Создание <see cref="IUnitOfWork"/> для вызывающего потока. 
    /// </summary>
    /// <param name="context">Конекст сосздания <see cref="IUnitOfWork"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный <see cref="IUnitOfWork"/>.</returns>
    /// <exception cref="InternalException">Если для вызывающего потока уже определён <see cref="IUnitOfWork"/>.</exception>
    ValueTask<IUnitOfWork> CreateUnitOfWorkAsync(object context = null, CancellationToken cancellationToken = default);
}
```

</details>

<details>
<summary>Контракт IUnitOfWork :</summary>

```csharp
/// <summary>
/// Сессия доменной области.
/// </summary>
public interface IUnitOfWork : IHostMappersSession, IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Признак уничтожения <see cref="IUnitOfWork"/>.
    /// </summary>
    bool IsDisposed { get; }

    /// <summary>
    /// Статус <see cref="IUnitOfWork"/>.
    /// </summary>
    UnitOfWorkState State { get; }

    /// <summary>
    /// Произвольные ассоциированные данные.
    /// </summary>
    IDictionary<Guid, object> Tags { get; }

    /// <summary>
    /// Точка входа в доменную область.
    /// </summary>
    IEntryPoint EntryPoint { get; }

    /// <summary>
    /// Реест локальных изменяемых состояний доменных объектов использованных в <see cref="IUnitOfWork"/>. 
    /// </summary>
    IDomainObjectMutableStatesRegister DomainObjectMutableStates { get; }

    /// <summary>
    /// Реестры доменных объектов. 
    /// </summary>
    IDomainObjectRegisters Registers { get; }

    /// <summary>
    /// Стратегия проверки успешности завершения <see cref="IUnitOfWork"/>.
    /// </summary>
    IUnitOfWorkCommitVerifying CommitVerifying { get; set; }

    /// <summary>
    /// Стратегия проверки успешности завершения <see cref="IUnitOfWork"/> определена.
    /// </summary>
    bool IsDefinedCommitVerifying { get; }

    /// <summary>
    /// Добавить доменное поведение в <see cref="IUnitOfWork"/>.
    /// </summary>
    /// <param name="domainBehaviour">Доменное поведение.</param>
    void AddBehaviour(IDomainBehaviour domainBehaviour);

    /// <summary>
    /// Добавить новый доменный объект в <see cref="IUnitOfWork"/> (<see cref="IDomainObject.GetData"/>, <see cref="DomainObjectDataTarget.Create"/>).
    /// </summary>
    /// <param name="domainObject">Доменный объект.</param>
    void AddNew(IDomainObject domainObject);

    /// <summary>
    /// Добавить изменённый доменный объект в <see cref="IUnitOfWork"/> (<see cref="IDomainObject.GetData"/>, <see cref="DomainObjectDataTarget.Update"/>).
    /// </summary>
    /// <param name="domainObject">Доменный объект.</param>
    void AddUpdate(IDomainObject domainObject);

    /// <summary>
    /// Добавить удалённый доменный объект в <see cref="IUnitOfWork"/> (<see cref="IDomainObject.GetData"/>, <see cref="DomainObjectDataTarget.Delete"/>).
    /// </summary>
    /// <param name="domainObject">Доменный объект.</param>
    void AddDelete(IDomainObject domainObject);

    /// <summary>
    /// Добавить проверку верси данных доменного объект в <see cref="IUnitOfWork"/> (<see cref="IDomainObject.GetData"/>, <see cref="DomainObjectDataTarget.Version"/>).
    /// </summary>
    /// <param name="domainObject">Доменный объект.</param>
    void AddVersion(IDomainObject domainObject);

    /// <summary>
    /// Подтвердить <see cref="IUnitOfWork"/>.
    /// Вызов может быть только один.
    /// </summary>
    /// <returns><see langword="true" /> - если были изменения. <see langword="false" /> - если изменений не было или <see cref="IUnitOfWork"/> был отменён.</returns>
    bool Commit();

    /// <summary>
    /// Подтвердить <see cref="IUnitOfWork"/>.
    /// Вызов может быть только один.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns><see langword="true" /> - если были изменения. <see langword="false" /> - если изменений не было или <see cref="IUnitOfWork"/> был отменён.</returns>
    ValueTask<bool> CommitAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Отменить <see cref="IUnitOfWork"/>.
    /// Вызывать можно неограниченное количество раз.
    /// </summary>
    void Rollback();

    /// <summary>
    /// Пометить <see cref="IUnitOfWork"/> как подозрительный для принудительного восстановления всех доменных объектов задействованных в <see cref="IUnitOfWork"/>.
    /// Вызывать можно неограниченное количество раз.
    /// </summary>
    void Suspect();
}
```

</details>

Пример создания доменного объекта :
```csharp
IEntryPoint entryPoint;

...

using (IUnitOfWork unitOfWork = entryPoint.CreateUnitOfWork())
{
    var register = unitOfWork.Registers.GetRegister<IDomainObjectRegisterDocument>();
    var instance = register.New(new DateTime(2022, 1, 2, 3, 4, 5, 6), 1002, 444);

    unitOfWork.Commit();
}
```

---
## Автогенерация мапперов на чистом ADO.NET

Примеры автогенерённых ADO.NET мапперов для [PostgreSQL](/Mappers/PostgreSql/Implements/).

Примеры автогенерённых ADO.NET мапперов для [SQL Server](/Mappers/SqlServer/Implements/).

---
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

SQL-скрипт создания таблицы и последовательности PostgreSQL для объекта Object_A (весь скрипт [SqlScript.sql](/Mappers/PostgreSql/Common/SqlScripts/SqlScript.sql)):

```sql
CREATE SEQUENCE Sequence_Object_A START WITH 1 INCREMENT BY 1;

CREATE TABLE object_a(
  id bigint NOT NULL,
  revision bigint NOT NULL,
  value_datetime timestamp NOT NULL,
  value_long bigint NOT NULL,
  value_int integer,
  value_string text,
  value_datetime_notupdate timestamp NOT NULL,
  PRIMARY KEY(id)
) PARTITION BY RANGE (id);
```

---
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

---
### Кодогенерация мапперов

Пример проектного файла (весь примера в файле [Mappers.PostgreSql.Implements.csproj](/Mappers/PostgreSql/Implements/Mappers.PostgreSql.Implements.csproj)):

```xml
<Project Sdk="Microsoft.NET.Sdk">

	...
	
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
    /// <param name="hostMappersSession">Хост сессии БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
    Object_ADtoActual Get(IHostMappersSession hostMappersSession, long id);

    /// <summary>
    /// Получить запись с указаным идентити.
    /// </summary>
    /// <param name="hostMappersSession">Хост сессии БД.</param>
    /// <param name="id">Идентити записи.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
    ValueTask<Object_ADtoActual> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default);

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

---
### Основные возможности

Для PostgreSQL в файле [Examples.cs](/Mappers/PostgreSql/Implements/Examples.cs) весь код примеров работы с мапперами.

Для SQL Server в файле [Examples.cs](/Mappers/SqlServer/Implements/Examples.cs) весь код примеров работы с мапперами.

---
#### Генерация уникального персистентного в БД значения первичного ключа с минимальным обращением к БД

Генератор уникальных первичных ключей работает на базе последовательностей БД.

Генератор позволяет получать уникальные значения без необходимости реального обращения к БД в момент генерации.

Пример параллельного создания **50.000.000** уникальных первичных ключей :

Весь код примеров в файле [Examples.cs](Mappers/PostgreSql/Implements/Examples.cs) в тесте **Example_IdentityCache_Parallel**.

```csharp
const int CacheSize = 100_000;
using var identityCache = CreateIdentityCache(CacheSize);

var identites = new HashSet<long>();
Parallel.For(0, 500 * CacheSize,
    _ =>
    {
        using var mappersSession = m_mappers.OpenSession();

        var identity = identityCache.GetNextIdentity(mappersSession);

        lock (identites)
        {
            Assert.IsFalse(identites.Contains(identity));
            identites.Add(identity);
        }

        mappersSession.Commit();
    });
```

##### Результат параллельного создания **50.000.000** уникальных первичных ключей *(33,7 секунд)*

```
Время работы : 00:00:33.7722060
Количество идентити : 50 000 000
Количество идентити полученных из кэша в памяти (без обращения к БД) : 49 990 310
Количество идентити полученных из БД : 9 690
Количество реальных подключений к БД : 10 454
Количество сессий мапперов : 50 000 764
```
Параметры ПК :<br>_OS Windows 11 Pro x64, CPU Intel Core i9-9900KS, RAM 48GB, SSD Samsung 970 Evo Plus 2Tb, DB PostgreSQL 15.1_

---
#### Кэширование записей по первичну ключу

Кэширование записей по первичну ключу происходит автоматически (если это наcтроено для маппера).

У каждого маппера свой кэш.

Кэш обновляется и очищается автоматически при создании, чтении, обновлении или удалении записи.

Пример параллельного чтения **10.000.000** записей БД по первичному ключу :

Весь код примеров в файле [Examples.cs](Mappers/PostgreSql/Implements/Examples.cs) в тесте **Example_Select_With_MemoryCache_Parallel**.

```csharp
var ids = new List<long>();

...

// Заполнение таблицы.
using (var mappersSession = m_mappers.OpenSession())
{
    foreach (var id in ids)
    {
        mapper.New(
            mappersSession,
            new Object_ADtoNew
            {
                Id = id,
                Value_DateTime = DateTime.Now,
                Value_DateTime_NotUpdate = DateTime.Now,
                Value_Int = null,
                Value_Long = id,
                Value_String = $"Text {id}",
            });
    }

    mappersSession.Commit();
}

// Выборка записей по первичному ключу.
Parallel.For(0, 10_000_000,
    _ =>
    {
        using var hostMappersSession = m_mappers.CreateHostMappersSession();

        var id = ProviderRandomValues.GetItem(ids);
        var dto = mapper.Get(hostMappersSession, id);
        Assert.IsNotNull(dto);
    });
```

##### Результат параллельного чтения **10.000.000** записей БД по первичному ключу *(9,3 секунд)*

```
Время работы : 00:00:09.3343538
Количество реальных подключений к БД : 2
Количество сессий мапперов : 2
Количество объектов в памяти : 1 000
Количество поисков объектов в памяти : 10 000 000
Количество найденных объектов в памяти : 10 000 000
```
Параметры ПК :<br>_OS Windows 11 Pro x64, CPU Intel Core i9-9900KS, RAM 48GB, SSD Samsung 970 Evo Plus 2Tb, DB PostgreSQL 15.1_

---
#### Поддержка партиционирования PostgreSQL из коробки

Мапперы для PostgreSQL имеют готовый компонент управлениями партициями (если это настроено для маппера) таблицы которую они обслуживают.

Пример создания партиции и записи в неё :

```csharp
var mappers = ServiceProviderHolder.Instance.GetRequiredService<IMappers>();
var mapper = (MapperObject_A)mappers.GetMapper<IMapperObject_A>();

var partitionId = 67;

// Создание партиции таблицы.
using (var mappersSession = mappers.OpenSession())
{
    mapper.Partitions.CreatePartition(mappersSession, partitionId, partitionId + 1);

    mappersSession.Commit();
}

using (var mappersSession = mappers.OpenSession())
{
    // Запись в партицию таблицы.
    mapper.New(
        mappersSession,
        new Object_ADtoNew
        {
            Id = ComplexIdentity.Build(mapper.Partitions.Level, partitionId, 1),
            Value_DateTime = DateTime.Now,
            Value_DateTime_NotUpdate = DateTime.Now,
            Value_Int = null,
            Value_Long = 314,
            Value_String = "Text",
        });

    mappersSession.Commit();
}
```
