# Wattle3.Examples

Примеры использования фреймворка для создания высокопроизводительных серверов с доменными объектами моделирующими предметную область.

Написано 100% на C# под .NET 6

Пакеты **nuget** начинаются с префикса [ShtrihM.Wattle3](https://www.nuget.org/packages?q=ShtrihM.Wattle3)

## Содержание
- [Телеметрия приложени](#телеметрия-приложени)

### Телеметрия приложени
Простая публикация и доступ по REST-интерфейсу к произвольной телеметрии приложения.

В проекте [InfrastructureMonitoring](/InfrastructureMonitoring) весь код примера.

Клаcc приложения с телеметрией для публикации по REST-интерфейсу:
```csharp
public class CustomClassA
{
    ...

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
# Идентификатор объекта приложения с телеметрией - WellknownCustomInfrastructureMonitors.CustomClassA
$MonitorId = "153C867D-A122-44BB-B689-949FB8C61B00"

# Идентификатор значения с телеметрией - WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count
$ValueId = "50FF7F28-582B-4297-93EE-323FB812880F"

$Result = Invoke-WebRequest -Uri "http://localhost:5601/api/1/InfrastructureMonitor/GetInfrastructureMonitorSnapshotValue?monitorId=$MonitorId&valueId=$ValueId" -Method Get

Write-Host ($Result)
```
