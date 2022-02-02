using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Testing.Databases.PostgreSql;

// ReSharper disable CheckNamespace

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
        m_dbName = "test_wattle3_" + DateTime.Now.ToString("yyyMMddhhmmss") + "_" + Guid.NewGuid().ToString("N");
        m_serverConnectionString = PostgreSqlDbHelper.GetServerConnectionString();
        m_dbConnectionString = PostgreSqlDbHelper.GetDatabaseConnectionString(m_dbName);

        var sqlScript = typeof(WellknownDomainObjects).Assembly.GetResourceAsString("SqlScript.sql");
        PostgreSqlDbHelper.CreateDb(m_dbName, tag: TestContext.CurrentContext.Test.FullName, sqlScript: sqlScript);
    }

    /// <summary>
    /// Удаление тестовой БД.
    /// </summary>
    partial void DoBase_TearDown()
    {
        PostgreSqlDbHelper.DropDb(m_dbName);
    }
}
