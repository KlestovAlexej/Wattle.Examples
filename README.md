# Wattle3.Examples

Примеры использования фреймворка для создания высокопроизводительных серверов с доменными объектами моделирующими предметную область.

Написано 100% на C# под .NET 6

Пакеты **nuget** начинаются с префикса [ShtrihM.Wattle3](https://www.nuget.org/packages?q=ShtrihM.Wattle3)

## Содержание
- [Телеметрия приложени](#телеметрия-приложени)

### Телеметрия приложени
Простая публикация и доступ по REST-интерфейсу к произвольной телеметрии приложени.

В проекте [InfrastructureMonitoring](/InfrastructureMonitoring) весь код примера.

Клаcc приложения с телеметрией для публикации по REST-интерфейсу:
```csharp
public class CustomClassA
{
    // Телеметрия.
    public long Count;
}
```

Получение значение телеметрии через REST-интерфейс используя C# и готовый клиент:
```csharp
using var client = new InfrastructureMonitorClient("localhost", 5601);

var snapshot = client.GetInfrastructureMonitorSnapshot(WellknownCustomInfrastructureMonitors.CustomClassA);
var snapShotValue = snapshot.Values.Single(v => v.Id == WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count);
var count = (long)snapShotValue.Data.Value;

Console.WriteLine(count);
```

Получение значение телеметрии через REST-интерфейс используя PowerShell:
```ps1
Install-Package MessagePack.ReactiveProperty
Install-Package MessagePack.UnityShims
Install-Package MessagePack.AspNetCoreMvcFormatter
```
