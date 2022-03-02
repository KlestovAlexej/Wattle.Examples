/*
* Файл создан автоматически. Не редактировать вручную.
*
* Общий код мапперов.
*
* Генератор - ShtrihM.Wattle3.CodeGeneration.Generators.Mappers.MappersCommonCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using ShtrihM.Wattle3.Common.Queries;
using ShtrihM.Wattle3.Common.Queries.Schema;
using System.Diagnostics.CodeAnalysis;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Common
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public static class WellknownSchemaQueriesFields
    {
        /// <summary>
        /// Уникальный ключ транзакции
        /// </summary>
        public static class TransactionKey
        {
            /// <summary>
            /// Идентификатр объекта.
            /// </summary>
            public static readonly Guid ObjectId = new Guid("52af162d-5f87-4c74-965f-eefc9850c088");

            /// <summary>
            /// Идентификатр полей объекта доступные для формирования фильтра.
            /// </summary>
            public static class Fields
            {
                /// <summary>
                /// Произвольные данные транзакции
                /// </summary>
                public static readonly Guid Tag = new Guid("9d0ff6d9-4059-4db8-9b58-883707710026");

                /// <summary>
                /// Ключ транзакции
                /// </summary>
                public static readonly Guid Key = new Guid("7e371548-201d-463f-85ff-95e1741ac449");

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

            #region Объект TransactionKey
            {
                var schemaObjectQuey = new SchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Уникальный ключ транзакции";
                schemaObjectQuey.Id = new Guid("52af162d-5f87-4c74-965f-eefc9850c088");

                #region Поле Tag
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Произвольные данные транзакции";
                    schemaObjectFieldQuey.Id = new Guid("9d0ff6d9-4059-4db8-9b58-883707710026");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Tag";
                }
                #endregion Поле Tag

                #region Поле Key
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Ключ транзакции";
                    schemaObjectFieldQuey.Id = new Guid("7e371548-201d-463f-85ff-95e1741ac449");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Key";
                }
                #endregion Поле Key

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Уникальный ключ транзакции";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект TransactionKey

        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов TransactionKey.
        /// </summary>
        /// <param name="query">Запрос.</param>
        public static QueryBuilder QueryForTransactionKey(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("52af162d-5f87-4c74-965f-eefc9850c088"), query);
        }
    }

}
