/*
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
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Interface;
using __Mappers = ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.PostgreSql.Implements.Mappers;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Tests
{
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMappersContext : BaseAutoTestsMappersContext
    {
        /// <summary>
        /// Объект тестовой среды.
        /// Уникальный ключ транзакции
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected TransactionKeyDtoActual m_transactionKeyDtoActual;

        /// <summary>
        /// Признак процесса создания объекта тестовой среды.
        /// Уникальный ключ транзакции
        /// </summary>
        // ReSharper disable once InconsistentNaming
        protected bool m_initTransactionKeyDtoActual;

        public AutoTestsMappersContext(IMappers mappers) : base(mappers)
        {
            /* NONE */
        }

        /// <summary>
        /// Cтратегия обработки параметров создания объекта тестовой среды.
        /// Уникальный ключ транзакции
        /// </summary>
        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNewTransactionKeyDtoNew(TransactionKeyDtoNew dto, AutoTestsMappersContext context);

        /// <summary>
        /// Получение/Установка объекта тестовой среды.
        /// Уникальный ключ транзакции
        /// </summary>
        // ReSharper disable once UnusedMember.Global
        public virtual TransactionKeyDtoActual TransactionKeyDtoActual
        {
            get
            {
                lock (m_lockObject)
                {
                    if (m_initTransactionKeyDtoActual)
                    {
                        throw new InvalidOperationException("Рекуcия для 'TransactionKeyDtoActual'.");
                    }

                    m_initTransactionKeyDtoActual = true;
                    try
                    {
                        if (m_transactionKeyDtoActual == null)
                        {
                            var dtoNew = AutoTestsMapperTransactionKey.GetRandomNew(this);
                            DoGetRandomNewTransactionKeyDtoNew(dtoNew, this);
                            // ReSharper disable once ConvertToUsingDeclaration
                            using (var session = Mappers.OpenSession())
                            {
                                var mapper = Mappers.GetMapper<IMapperTransactionKey>();
                                m_transactionKeyDtoActual = mapper.New(session, dtoNew);
                                
                                session.Commit();
                            }
                        }

                        return (m_transactionKeyDtoActual);
                    }
                    finally
                    {
                        m_initTransactionKeyDtoActual = false;
                    }
                }
            }
            set
            {
                lock (m_lockObject)
                {
                    m_transactionKeyDtoActual = value;
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
        protected object m_contextMappers;

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
                m_mappers = new __Mappers(m_mappersExceptionPolicy, m_dbConnectionString, m_timeService, context: m_contextMappers);
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
    /// Уникальный ключ транзакции
    /// </summary>
    [TestFixture]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial class AutoTestsMapperTransactionKey : BaseAutoTestsMapper
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
        protected IMapperTransactionKey m_mapper;

        [SetUp]
        public void SetUp()
        {
            m_mapper = (IMapperTransactionKey) m_mappers.GetMapper(WellknownMappers.TransactionKey);
            m_tableName = "transactionkey";
            DoSetUp();
        }

        [TearDown]
        public void TearDown()
        {
            DoTearDown();
        }

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoGetRandomNew(TransactionKeyDtoNew dto, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoBulkInsert(List<TransactionKeyDtoNew> dtos, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(TransactionKeyDtoNew expected, TransactionKeyDtoActual actual, object context);

        // ReSharper disable once PartialMethodWithSinglePart
        static partial void DoAssertAreEqual(TransactionKeyDtoActual expected, TransactionKeyDtoActual actual, object context);

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
            var templates = new List<TransactionKeyDtoNew>();
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
            using (var hostMappersSession = m_mappers.CreateHostMappersSession())
            {
                foreach (var template in templates)
                {
                    var data = m_mapper.Get(hostMappersSession, template.Id);
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
            TransactionKeyDtoActual dataNew;
            // ReSharper disable once ConvertToUsingDeclaration
            using (var session = m_mappers.OpenSession())
            {
                dataNew = m_mapper.New(session, template);
                AssertAreEqual(template, dataNew, m_context);

                session.Commit();
            }

            // ReSharper disable once ConvertToUsingDeclaration
            using (var hostMappersSession = m_mappers.CreateHostMappersSession())
            {
                var data = m_mapper.Get(hostMappersSession, template.Id);
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

            #region Tag

            {
                Assert.IsTrue(columns.ContainsKey(@"tag"), @"Tag" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"tag"];
                columns.Remove(@"tag");
                Assert.IsFalse(columnInfo.IsNullable, columnsText);
                Assert.IsNull(columnInfo.MaxLength, columnsText);
            }

            #endregion

            #region Key

            {
                Assert.IsTrue(columns.ContainsKey(@"key"), @"Key" + Environment.NewLine + columnsText);
                var columnInfo = columns[@"key"];
                columns.Remove(@"key");
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

            columnsText = "{" + Environment.NewLine + columns.Count + Environment.NewLine + columns.Aggregate("", (current, entry) => current + ($"[{entry.Key}] = [{entry.Value.ColumnName} , {entry.Value.IsNullable} , ({entry.Value.MaxLength})]" + Environment.NewLine)) + "}";
            Assert.AreEqual(0, columns.Count, columnsText);
        }

        public static TransactionKeyDtoNew GetRandomNew(object context)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new TransactionKeyDtoNew();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Tag = PostgreSqlRandomValuesProvider.GetRandomValue<long>(NpgsqlDbType.Bigint);
            result.Key = PostgreSqlRandomValuesProvider.GetRandomValue<Guid>(NpgsqlDbType.Uuid);

            DoGetRandomNew(result, context);

            return (result);
        }

        public static void AssertAreEqual(TransactionKeyDtoNew expected, TransactionKeyDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Tag, actual.Tag);
            Assert.AreEqual(expected.Key, actual.Key);

            DoAssertAreEqual(expected, actual, context);
        }

        public static void AssertAreEqual(TransactionKeyDtoActual expected, TransactionKeyDtoActual actual, object context)
        {
            Assert.IsNotNull(expected);
            Assert.IsNotNull(actual);

            Assert.AreEqual(expected.Tag, actual.Tag);
            Assert.AreEqual(expected.Key, actual.Key);

            DoAssertAreEqual(expected, actual, context);
        }
    }

}
