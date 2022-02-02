﻿/*
* Файл создан автоматически. Не редактировать вручную.
*
* Тесты реализаций мапперов.
*
* Генератор - ShtrihM.Wattle3.CodeGeneration.Generators.Mappers.PostgreSqlMappersTestsCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using System.Data;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using NpgsqlTypes;
using System.Linq;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Utils;
using ShtrihM.Wattle3.DomainObjects.Common;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Testing;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.CodeGeneration.Generators;
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;
using __Mappers = ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements.Mappers;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Tests
{
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMappersContext : BaseAutoTestsMappersContext
    {
        /// <summary>
        /// Объект тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected Object_ADtoActual m_object_ADtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initObject_ADtoActual;

        public AutoTestsMappersContext(IMappers mappers) : base(mappers)
        {
            /* NONE */
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewObject_ADtoNew(Object_ADtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Системный лог
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual Object_ADtoActual Object_ADtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initObject_ADtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'Object_ADtoActual'.");
                    }

                    m_initObject_ADtoActual = true;
                    try
                    {
                        if (m_object_ADtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperObject_A.GetRandomNew(this);
                            DoGetRandomNewObject_ADtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperObject_A>();
                                m_object_ADtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_object_ADtoActual);
                    }
                    finally
                    {
                        m_initObject_ADtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_object_ADtoActual = value;
                }
            }
        }

    }

    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public abstract partial class BaseAutoTestsMapper
    {
        // ReSharper disable once UnusedMember.Global
        public static readonly ThreadLocal<Random> Random = new ThreadLocal<Random>(() => new Random(Guid.NewGuid().GetHashCode()));

        protected IMappers m_mappers;
        protected string m_dbConnectionString;
        protected IMappersExceptionPolicy m_mappersExceptionPolicy;
        protected ITimeService m_timeService;
        protected object m_context;

        [SetUp]
        public void Base_SetUp()
        {
            DoBase_BeginSetUp();
            if (m_timeService == null)
            {
                m_timeService = new TimeService();
            }
            if (m_mappersExceptionPolicy == null)
            {
                m_mappersExceptionPolicy = new MappersExceptionPolicy();
            }
            if (m_mappers == null)
            {
                m_mappers = new __Mappers(m_mappersExceptionPolicy, m_dbConnectionString, m_timeService);
            }
            (m_mappers as IMappersInitializer)?.Initialize();
            if (m_context == null)
            {
                m_context = new AutoTestsMappersContext(m_mappers);
            }
            DoBase_EndSetUp();
        }

        [TearDown]
        public void Base_TearDown()
        {
            DoBase_TearDown();
            (m_context as IDisposable).SilentDispose();
            m_context = null;
            m_mappers.SilentDispose();
            m_mappers = null;
            m_mappersExceptionPolicy.SilentDispose();
            m_mappersExceptionPolicy = null;
            m_timeService.SilentDispose();
            m_timeService = null;
        }

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoBase_BeginSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoBase_EndSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoBase_TearDown();
    }

    /// <summary>
    /// Системный лог
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperObject_A : BaseAutoTestsMapper
    {
        #region Private Class PostgreSqlColumnInfo

        private class PostgreSqlColumnInfo
        {
            public string ColumnName;
            public bool IsNullable;
            public int? MaxLength;
        }

        #endregion

        protected string m_tableName;
        protected IMapperObject_A m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperObject_A) m_mappers.GetMapper(WellknownMappers.Object_A);
            m_tableName = "object_a";
            DoSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(Object_ADtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<Object_ADtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(Object_ADtoNew expected, Object_ADtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(Object_ADtoActual expected, Object_ADtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoSetUp();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTearDown();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoTest_New_Get();

        // ReSharper disable once PartialMethodWithSinglePart
        partial void DoValidate_Columns(Dictionary<string, PostgreSqlColumnInfo> columns);

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [TestCase(0)]
        [TestCase(1)]
        [TestCase(3)]
        [TestCase(20)]
        [Description("Массовая вставка записей")]
        public void Test_BulkInsert(int size)
        {
            var templates = new List<Object_ADtoNew>();
            for (var i = 0; i < size; i++)
            {
                var template = GetRandomNew(m_context);
                template.Id = i + 1;
                templates.Add(template);
            }

            DoBulkInsert(templates, m_context);

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                m_mapper.BulkInsert(session, templates);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(session, template.Id);
                    AssertAreEqual(template, data, m_context);
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Создание и Получение")]
        public void Test_New_Get()
        {
            DoTest_New_Get();

            var template = GetRandomNew(m_context);
            Object_ADtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                var data = m_mapper.Get(session, template.Id);
                AssertAreEqual(template, data, m_context);
                AssertAreEqual(dataNew, data, m_context);
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Получение следующего значения идентити из последовательности")]
        public void Test_GetNextId()
        {
            long baseValue;
            using (var session = m_mappers.OpenSession())
            {
                baseValue = m_mapper.GetNextId(session);
            }

            for (var i = 0; i < 3; i++)
            {
                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 1 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 2 + i * 4, m_mapper.GetNextId(session));
                }

                using (var session = m_mappers.OpenSession())
                {
                    Assert.AreEqual(baseValue + 3 + i * 4, m_mapper.GetNextId(session));
                    Assert.AreEqual(baseValue + 4 + i * 4, m_mapper.GetNextId(session));

                    session.Commit();
                }
            }
        }

        [Test]
        [Category(@"Unit")]
        [Timeout(300000)]
        [Description("Проверка совпадения колонок маппера с реальной БД")]
        public void Test_Validate_Columns()
        {
            var columns = new Dictionary<string, PostgreSqlColumnInfo>();
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = (IPostgreSqlMappersSession) m_mappers.OpenSession())
            {
                using (var command = session.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = $@"SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{m_tableName}'";

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var indexMaxLength = reader.GetOrdinal(@"character_maximum_length");
                            var columnInfo =
                                new PostgreSqlColumnInfo
                                {
                                    ColumnName = reader.GetString(reader.GetOrdinal(@"column_name")),
                                    IsNullable = (reader.GetString(reader.GetOrdinal(@"is_nullable")) == @"YES"),
                                    MaxLength = reader.IsDBNull(indexMaxLength) ? (int?) null : reader.GetInt32(indexMaxLength),
                                };
                            columns.Add(columnInfo.ColumnName, columnInfo);
                        }
                    }
                }
            }

            DoValidate_Columns(columns);

            var columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";

            #region CreateDate

            {
                Assert.IsTrue(columns.ContainsKey(@"createdate"), @"CreateDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"createdate"];
                columns.Remove(@"createdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region ModificationDate

            {
                Assert.IsTrue(columns.ContainsKey(@"modificationdate"), @"ModificationDate" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"modificationdate"];
                columns.Remove(@"modificationdate");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region State

            {
                Assert.IsTrue(columns.ContainsKey(@"state"), @"State" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"state"];
                columns.Remove(@"state");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Id

            {
                Assert.IsTrue(columns.ContainsKey(@"id"), @"Id" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"id"];
                columns.Remove(@"id");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Revision

            {
                Assert.IsTrue(columns.ContainsKey(@"revision"), @"Revision" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"revision"];
                columns.Remove(@"revision");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static Object_ADtoNew GetRandomNew(object context)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_ADtoNew();
#pragma warning restore IDE0017 // Simplify object initialization

            result.CreateDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTime>(NpgsqlDbType.Timestamp);
            result.ModificationDate = PostgreSqlRandomValuesProvider.GetRandomValue<DateTime>(NpgsqlDbType.Timestamp);
            result.State = PostgreSqlRandomValuesProvider.GetRandomValue<short>(NpgsqlDbType.Smallint);

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(Object_ADtoNew expected, Object_ADtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.State, actual.State);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(Object_ADtoActual expected, Object_ADtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.CreateDate, actual.CreateDate);
            Assert.AreEqual(expected.ModificationDate, actual.ModificationDate);
            Assert.AreEqual(expected.State, actual.State);

            DoAssertAreEqual(expected, actual, context);
        }
    }

}