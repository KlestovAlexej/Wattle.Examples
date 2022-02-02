using System;
using NUnit.Framework;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements;

/// <summary>
/// Базовый класс примеров использования мапперов
/// </summary>
[TestFixture]
public class BaseExamplesMapper
{
    protected string m_serverConnectionString;
    protected string m_dbConnectionString;
    protected string m_dbName;

    /// <summary>
    /// Создание тестовой БД.
    /// </summary>
    [SetUp]
    public void Base_SetUp()
    {
        m_dbName = "test_wattle3_" + DateTime.Now.ToString("yyyMMddhhmmss") + "_" + Guid.NewGuid().ToString("N");
        m_serverConnectionString = PostgreSqlDbHelper.GetServerConnectionString();
        m_dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(m_dbName);

        var sqlScript = typeof(WellknownDomainObjects).Assembly.GetResourceAsString("SqlScript.sql");
        PostgreSqlDbHelper.CreateDb(m_dbName, tag: TestContext.CurrentContext.Test.FullName, sqlScript: sqlScript);
    }

    /// <summary>
    /// Удаление тестовой БД.
    /// </summary>
    [TearDown]
    public void Base_TearDown()
    {
        PostgreSqlDbHelper.DropDb(m_dbName);
    }
}
