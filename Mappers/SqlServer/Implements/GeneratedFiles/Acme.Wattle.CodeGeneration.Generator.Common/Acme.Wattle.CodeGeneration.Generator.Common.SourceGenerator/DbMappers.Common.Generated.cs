/*
* Файл создан автоматически. Не редактировать вручную.
*
* Общий код мапперов.
*
* Генератор - Acme.Wattle.CodeGeneration.Generators.Mappers.MappersCommonCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using Acme.Wattle.Common.Queries;
using Acme.Wattle.Common.Queries.Schema;
using Acme.Wattle.Mappers.Primitives;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace Acme.Wattle.Examples.Mappers.SqlServer.Implements.Generated.Common
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public static class WellknownSchemaQueriesFields
    {
        /// <summary>
        /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
        /// </summary>
        public static class Object_A
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("266032e5-19c6-434c-a521-d1d1c652edd1");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата-время (DateTime). Обновляемое поле.
                /// </summary>
                public static readonly Guid Value_DateTime = new Guid("dce071bb-796e-4397-91b8-eaf116747880");

                /// <summary>
                /// Дата-время (DateTime). Не обновляемое поле.
                /// </summary>
                public static readonly Guid Value_DateTime_NotUpdate = new Guid("273a65e2-7647-42db-a15d-58b69a64c69d");

                /// <summary>
                /// Число (long). Поле обновляется только при изменении значения.
                /// </summary>
                public static readonly Guid Value_Long = new Guid("87a005ed-ca51-4c60-83ec-6540ac0823d6");

                /// <summary>
                /// Число с поддержкой null (int?). Обновляемое поле.
                /// </summary>
                public static readonly Guid Value_Int = new Guid("198251ef-8183-4a09-a760-e5baafbbb6ff");

                /// <summary>
                /// Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.
                /// </summary>
                public static readonly Guid Value_String = new Guid("100e6573-b387-4cb5-b3d6-45df4cb2cc9c");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

        /// <summary>
        /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
        /// </summary>
        public static class Object_B
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("cb9a1909-a7b6-48a6-8fe5-7d714e0225ea");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("92847c2c-e7b4-4ee1-a628-042b75aa9225");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

    }

    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class SchemaQueriesProvider
    {
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public static SchemaQueries Schema;

        static SchemaQueriesProvider()
        {
            Schema = new SchemaQueries();

            #region Объект Object_A
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера";
                schemaObjectQuey.Id = new Guid("266032e5-19c6-434c-a521-d1d1c652edd1");

                #region Поле Value_DateTime
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время (DateTime). Обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("dce071bb-796e-4397-91b8-eaf116747880");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_DateTime";
                }
                #endregion Поле Value_DateTime

                #region Поле Value_DateTime_NotUpdate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время (DateTime). Не обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("273a65e2-7647-42db-a15d-58b69a64c69d");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_DateTime_NotUpdate";
                }
                #endregion Поле Value_DateTime_NotUpdate

                #region Поле Value_Long
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Число (long). Поле обновляется только при изменении значения.";
                    schemaObjectFieldQuey.Id = new Guid("87a005ed-ca51-4c60-83ec-6540ac0823d6");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Long";
                }
                #endregion Поле Value_Long

                #region Поле Value_Int
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Число с поддержкой null (int?). Обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("198251ef-8183-4a09-a760-e5baafbbb6ff");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Int";
                }
                #endregion Поле Value_Int

                #region Поле Value_String
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.";
                    schemaObjectFieldQuey.Id = new Guid("100e6573-b387-4cb5-b3d6-45df4cb2cc9c");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"Value_String";
                }
                #endregion Поле Value_String

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект Object_A

            #region Объект Object_B
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)";
                schemaObjectQuey.Id = new Guid("cb9a1909-a7b6-48a6-8fe5-7d714e0225ea");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("92847c2c-e7b4-4ee1-a628-042b75aa9225");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект Object_B

        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов Object_A.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("266032e5-19c6-434c-a521-d1d1c652edd1")]
        public static QueryBuilder QueryForObject_A(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("266032e5-19c6-434c-a521-d1d1c652edd1"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов Object_B.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("cb9a1909-a7b6-48a6-8fe5-7d714e0225ea")]
        public static QueryBuilder QueryForObject_B(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("cb9a1909-a7b6-48a6-8fe5-7d714e0225ea"), query);
        }
    }

}
