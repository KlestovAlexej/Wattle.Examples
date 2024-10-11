using NUnit.Framework;
using Acme.Wattle.DomainObjects.Common;
using Acme.Wattle.Examples.Common;
using Acme.Wattle.Examples.DomainObjects.Common;
using Acme.Wattle.Primitives;
using Acme.Wattle.Testing.Databases.PostgreSql;
using System;
using Microsoft.Extensions.Logging;
using Acme.Wattle.DomainObjects.Interfaces;
using Acme.Wattle.Utils;
using Unity;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.DomainObjects.Examples.Generated.Tests;

public abstract partial class BaseAutoTestsMapper
{
    private string m_dbName;

    /// <summary>
    /// Создание тестовой БД.
    /// </summary>
    partial void DoBase_BeginSetUp()
    {
        CreateDb(out m_dbName, out m_dbConnectionString);

        m_timeService = new TimeService();

        var container = new UnityContainer();
        container.RegisterInstance(m_timeService, InstanceLifetime.External);

        var exceptionPolicy =
            new ExceptionPolicy(
                m_timeService,
                LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger(GetType()),
                new WorkflowExceptionPolicy());
        container.RegisterInstance<IExceptionPolicy>(exceptionPolicy, InstanceLifetime.External);

        m_contextMappers = container;
    }

    /// <summary>
    /// Удаление тестовой БД.
    /// </summary>
    partial void DoBase_TearDown()
    {
        PostgreSqlDbHelper.DropDb(m_dbName);
        (m_contextMappers as IDisposable).SilentDispose();
    }

    public static void CreateDb(out string dbName, out string dbConnectionString)
    {
        Assert.IsTrue(DbCredentials.TryGetServerAdressForPostgreSql(out var serverAdress), "Определите адрес сервера с PostgreSQL.");
        Assert.IsTrue(DbCredentials.TryGetCredentialsForPostgreSql(out var credentials), "Определите параметры учётной записи подключения к PostgreSQL.");

        dbName = "examples_wattle_" + DateTime.Now.ToString("yyyMMddhhmmss") + "_" + Guid.NewGuid().ToString("N");
        dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(dbName, serverAdress: serverAdress, userCredentials: credentials);

        var sqlScript = typeof(WellknownDomainObjects).Assembly.GetResourceAsString("SqlScript.sql");
        PostgreSqlDbHelper.CreateDb(dbName, sqlScript: sqlScript);
    }
}
