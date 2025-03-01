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
namespace Acme.Wattle.Examples.DomainObjects.Examples.Generated.Common
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public static class WellknownSchemaQueriesFields
    {
        /// <summary>
        /// Документ
        /// </summary>
        public static class Document
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("d70d5118-2c04-4a66-a5a1-4573b7f91631");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Дата-время создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("7ef5bc59-73ae-485f-a1d5-7a7cec7b691c");

                /// <summary>
                /// Дата-время модификации
                /// </summary>
                public static readonly Guid ModificationDate = new Guid("f1a9d132-e6b2-4c4c-96e7-bdfcb1e0a330");

                /// <summary>
                /// Доле документа - дата-время
                /// </summary>
                public static readonly Guid Value_DateTime = new Guid("31becbf5-304f-4e0b-9540-25efd7191f19");

                /// <summary>
                /// Доле документа - число
                /// </summary>
                public static readonly Guid Value_Long = new Guid("15713b81-57c2-4a29-a978-2f2ea00d4554");

                /// <summary>
                /// Доле документа - число с поддержкой null
                /// </summary>
                public static readonly Guid Value_Int = new Guid("c238f1b0-c802-41f3-a6f0-ae2b52a1598f");

                /// <summary>
                /// Идентити.
                /// </summary>
                public static readonly Guid Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

            }
        }

        /// <summary>
        /// Отслеживание изменений
        /// </summary>
        public static class ChangeTracker
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("67bf3734-17bb-4e9a-b0f1-b8f85382e690");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
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

            #region Объект Document
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Документ";
                schemaObjectQuey.Id = new Guid("d70d5118-2c04-4a66-a5a1-4573b7f91631");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время создания";
                    schemaObjectFieldQuey.Id = new Guid("7ef5bc59-73ae-485f-a1d5-7a7cec7b691c");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле ModificationDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время модификации";
                    schemaObjectFieldQuey.Id = new Guid("f1a9d132-e6b2-4c4c-96e7-bdfcb1e0a330");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                }
                #endregion Поле ModificationDate

                #region Поле Value_DateTime
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Доле документа - дата-время";
                    schemaObjectFieldQuey.Id = new Guid("31becbf5-304f-4e0b-9540-25efd7191f19");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_DateTime";
                }
                #endregion Поле Value_DateTime

                #region Поле Value_Long
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Доле документа - число";
                    schemaObjectFieldQuey.Id = new Guid("15713b81-57c2-4a29-a978-2f2ea00d4554");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Long";
                }
                #endregion Поле Value_Long

                #region Поле Value_Int
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Доле документа - число с поддержкой null";
                    schemaObjectFieldQuey.Id = new Guid("c238f1b0-c802-41f3-a6f0-ae2b52a1598f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Int";
                }
                #endregion Поле Value_Int

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Документ";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект Document

            #region Объект ChangeTracker
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Отслеживание изменений";
                schemaObjectQuey.Id = new Guid("67bf3734-17bb-4e9a-b0f1-b8f85382e690");

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Отслеживание изменений";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект ChangeTracker

        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов Document.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("d70d5118-2c04-4a66-a5a1-4573b7f91631")]
        public static QueryBuilder QueryForDocument(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("d70d5118-2c04-4a66-a5a1-4573b7f91631"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов Document.
        /// </summary>
        [MapperQueryBuilder("d70d5118-2c04-4a66-a5a1-4573b7f91631")]
        public static QueryBuilder QueryForDocument()
        {
            return QueryBuilder.New(Schema, new Guid("d70d5118-2c04-4a66-a5a1-4573b7f91631"));
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов ChangeTracker.
        /// </summary>
        /// <param name="query">Запрос.</param>
        [MapperQueryBuilder("67bf3734-17bb-4e9a-b0f1-b8f85382e690")]
        public static QueryBuilder QueryForChangeTracker(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("67bf3734-17bb-4e9a-b0f1-b8f85382e690"), query);
        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов ChangeTracker.
        /// </summary>
        [MapperQueryBuilder("67bf3734-17bb-4e9a-b0f1-b8f85382e690")]
        public static QueryBuilder QueryForChangeTracker()
        {
            return QueryBuilder.New(Schema, new Guid("67bf3734-17bb-4e9a-b0f1-b8f85382e690"));
        }
    }

}
