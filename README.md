# Wattle3.Examples

Примеры использования фреймворка для создания высокопроизводительных серверов с доменными объектами моделирующими предметную область.

Написано 100% на C# под .NET 6

Пакеты **nuget** начинаются с префикса [ShtrihM.Wattle3](https://www.nuget.org/packages?q=ShtrihM.Wattle3)

# InfrastructureMonitoring
Простая публикация и доступ по REST-интерфейсу к произвольной телеметрии приложени.

Пример.

Клаcc приложения с телеметрией :
```csharp
public class CustomClassA
{
    // Телеметрия.
    public long Count;
}
```

Получение значения с телеметрией :
```csharp
using var client = new InfrastructureMonitorClient("localhost", 5601);

var snapshot = client.GetInfrastructureMonitorSnapshot(WellknownCustomInfrastructureMonitors.CustomClassA);
var snapShotValue = snapshot.Values.Single(v => v.Id == WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count);
var count = (long)snapShotValue.Data.Value;

Console.WriteLine(count);
```
