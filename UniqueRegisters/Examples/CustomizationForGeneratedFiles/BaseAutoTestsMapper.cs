using NUnit.Framework;
using Acme.Wattle.Examples.Common;
using Acme.Wattle.Examples.UniqueRegisters.Common;
using Acme.Wattle.Primitives;
using Acme.Wattle.Testing.Databases.PostgreSql;
using System;

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.UniqueRegisters.Examples.Generated.Tests;

public abstract partial class BaseAutoTestsMapper
{
    private string m_dbName;

    /// <summary>
    /// Создание тестовой БД.
    /// </summary>
    partial void DoBase_BeginSetUp()
    {
        CreateDb(out m_dbName, out m_dbConnectionString);
    }

    /// <summary>
    /// Удаление тестовой БД.
    /// </summary>
    partial void DoBase_TearDown()
    {
        PostgreSqlDbHelper.DropDb(m_dbName);
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
