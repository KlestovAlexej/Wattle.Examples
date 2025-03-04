﻿using Microsoft.Extensions.Logging;
using NUnit.Framework;
using Acme.Wattle.Common.Interfaces;
using Acme.Wattle.DomainObjects;
using Acme.Wattle.Examples.InfrastructureMonitoring.Models;
using Acme.Wattle.Infrastructures.Monitors;
using Acme.Wattle.Infrastructures.Rest.Clients.Monitors;
using Acme.Wattle.Infrastructures.Rest.Controllers.Monitors;
using Acme.Wattle.Json.Extensions;
using Acme.Wattle.Json.ValueData;
using Acme.Wattle.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using Acme.Wattle.Examples.Common;

namespace Acme.Wattle.Examples.InfrastructureMonitoring;

/// <summary>
/// Примеры сервера с REST-интерфейсом публикующего телеметрию объектов приложения.
/// </summary>
[TestFixture]
public class Examples
{
    private CustomClassA m_classA;

    /// <summary>
    /// Получение телеметрии объектов приложения по REST-интерфейсу.
    /// </summary>
    [Test]
    public void Example()
    {
        using var client = new InfrastructureMonitorClient("localhost", 5601);

        m_classA.Count = 11;

        {
            // Получение по REST значение телеметриии Count класса CustomClassA
            var snapShotValue = client.GetInfrastructureMonitorSnapshotValue(WellknownCustomInfrastructureMonitors.CustomClassA, WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count);
            var count = (long)snapShotValue.Value.Data.Value;

            Console.WriteLine("");
            Console.WriteLine($"CustomClassA.Count = {m_classA.Count}");
            Console.WriteLine($"CustomClassA.Count (REST) = {count}");
            Console.WriteLine($"CustomClassA.Count JSON : {Environment.NewLine + snapShotValue.ToJsonText(true)}");
        }

        m_classA.Count = 22;

        {
            // Получение по REST снимка с телеметрией класса CustomClassA
            var snapshot = client.GetInfrastructureMonitorSnapshot(WellknownCustomInfrastructureMonitors.CustomClassA);

            // Значение Count из телеметриии класса CustomClassA
            var snapShotValue = snapshot.Values.Single(v => v.Id == WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count);
            var count = (long)snapShotValue.Data.Value;

            Console.WriteLine("");
            Console.WriteLine($"CustomClassA.Count = {m_classA.Count}");
            Console.WriteLine($"CustomClassA.Count (REST) = {count}");
            Console.WriteLine($"CustomClassA.Count JSON : {Environment.NewLine + snapShotValue.ToJsonText(true)}");
        }

        m_classA.Count = 33;

        {
            // Получение по REST снимка с телеметрией класса CustomClassA
            var snapshot = client.GetInfrastructureMonitorSnapshot(WellknownCustomInfrastructureMonitors.CustomClassA);

            // Значение Count из телеметриии класса CustomClassA
            var snapShotValue = snapshot.Values.Single(v => v.Id == WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassA.Count);
            var count = (long)snapShotValue.Data.Value;

            Console.WriteLine("");
            Console.WriteLine($"CustomClassA.Count = {m_classA.Count}");
            Console.WriteLine($"CustomClassA.Count (REST) = {count}");
            Console.WriteLine($"CustomClassA.Count JSON : {Environment.NewLine + snapShotValue.ToJsonText(true)}");
        }

        m_classA.ClassB.Value.Value1 = 44;
        m_classA.ClassB.Value.Value2 = "Тест";

        {
            // Получение по REST снимка с телеметрией класса CustomClassB
            var snapshot = client.GetInfrastructureMonitorSnapshot(WellknownCustomInfrastructureMonitors.CustomClassB);

            // Значение Value из телеметриии класса CustomClassB
            var snapShotValue = snapshot.Values.Single(v => v.Id == WellknownCustomSnapShotInfrastructureMonitorValues.CustomClassB.Value);
            var customValue = (CustomValue)snapShotValue.Data.Value;

            Console.WriteLine("");
            Console.WriteLine($"CustomClassB.Value.Value1 = {m_classA.ClassB.Value.Value1}");
            Console.WriteLine($"CustomClassB.Value.Value1 (REST) = {customValue.Value1}");
            Console.WriteLine($"CustomClassB.Value.Value2 = {m_classA.ClassB.Value.Value2}");
            Console.WriteLine($"CustomClassB.Value.Value2 (REST) = {customValue.Value2}");
            Console.WriteLine($"CustomClassB.Value JSON : {Environment.NewLine + snapShotValue.ToJsonText(true)}");
        }
    }

    #region Enviroment

    private MonitorsHostApplet m_monitorsHostApplet;

    [SetUp]
    public void SetUp()
    {
        // Для десериализации произвольных типов телеметрии из текста JSON в тип C#
        JsonConverterCustomEx<BaseValueData, UnknownValueData>.AddType(typeof(CustomValue.ValueData));

        var infrastructureMonitorRegisters = new InfrastructureMonitorRegisters();

        // Создание фабрики логгеров к консольк NUnit в режиме не писать - true.
        var loggerFactory = LoggerFactory.Create(builder => new NUnitConsoleLoggerProvider(true).Add(builder));

        DomainEnviromentConfigurator
            .Begin(loggerFactory, out _, out _)
            .SetInfrastructureMonitorRegisters(infrastructureMonitorRegisters)
            .Build();

        m_classA = new CustomClassA();
        infrastructureMonitorRegisters.AddMonitor(m_classA.Monitor);
        infrastructureMonitorRegisters.AddFavorit(m_classA.Monitor.Id);

        m_monitorsHostApplet =
            new MonitorsHostApplet(
                () =>
                    new MetaServerDescription
                    {
                        DateTime = DateTimeOffset.Now,
                        InstallationId = new Guid("D70C9A84-1EAF-4AF7-A9A7-6D0D7C5021EC"),
                        InstallationName = "Тест",
                        ProductBuildVersion = new Version(1, 0),
                        ProductId = Guid.Empty,
                        ProductVersion = new Version(1, 0),
                        Properties = new Dictionary<string, string>()
                    },
                "http://localhost:5601");

        m_monitorsHostApplet.Start();
    }

    [TearDown]
    public void TearDown()
    {
        m_monitorsHostApplet?.Stop();
        m_monitorsHostApplet.SilentDispose();

        DomainEnviromentConfigurator.DisposeAll();
    }

    #endregion
}
