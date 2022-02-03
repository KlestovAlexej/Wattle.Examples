using System;
using NUnit.Framework;
using ShtrihM.Wattle3.Examples.Common;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests;

public abstract partial class BaseAutoTestsMapper
{
    protected string m_serverConnectionString;
    protected string m_dbName;

    /// <summary>
    /// Создание тестовой БД.
    /// </summary>
    partial void DoBase_BeginSetUp()
    {
        Assert.IsTrue(DbCredentials.TryGetServerAdressForPostgreSql(out var serverAdress), "Определите адрес сервера с PostgreSQL.");
        Assert.IsTrue(DbCredentials.TryGetCredentialsForPostgreSql(out var credentials), "Определите параметры учётной записи подключения к PostgreSQL.");

        m_dbName = "examples_wattle3_" + DateTime.Now.ToString("yyyMMddhhmmss") + "_" + Guid.NewGuid().ToString("N");
        m_serverConnectionString = PostgreSqlDbHelper.GetServerConnectionString(serverAdress: serverAdress, userCredentials: credentials);
        m_dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(m_dbName, serverAdress: serverAdress, userCredentials: credentials);

        var sqlScript = typeof(WellknownDomainObjects).Assembly.GetResourceAsString("SqlScript.sql");
        PostgreSqlDbHelper.CreateDb(m_dbName, sqlScript: sqlScript);
    }

    /// <summary>
    /// Удаление тестовой БД.
    /// </summary>
    partial void DoBase_TearDown()
    {
        PostgreSqlDbHelper.DropDb(m_dbName);
    }
}
