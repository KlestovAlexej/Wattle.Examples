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
namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Common
{
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    public static class WellknownSchemaQueriesFields
    {
        /// <summary>
        /// Системный лог
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
                /// Дата создания
                /// </summary>
                public static readonly Guid CreateDate = new Guid("fabb42ed-5c3a-4234-8bf6-0cffa10baa18");

                /// <summary>
                /// Дата модификации
                /// </summary>
                public static readonly Guid ModificationDate = new Guid("cc4c135f-cd40-4380-9e39-6c1654352b19");

                /// <summary>
                /// Статус
                /// </summary>
                public static readonly Guid State = new Guid("196f6520-05e9-4412-8d85-0921588109f6");

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

                schemaObjectQuey.Description = @"Системный лог";
                schemaObjectQuey.Id = new Guid("266032e5-19c6-434c-a521-d1d1c652edd1");

                #region Поле CreateDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("fabb42ed-5c3a-4234-8bf6-0cffa10baa18");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                }
                #endregion Поле CreateDate

                #region Поле ModificationDate
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("cc4c135f-cd40-4380-9e39-6c1654352b19");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                }
                #endregion Поле ModificationDate

                #region Поле State
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Статус";
                    schemaObjectFieldQuey.Id = new Guid("196f6520-05e9-4412-8d85-0921588109f6");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"State";
                }
                #endregion Поле State

                #region Поле Id
                {
                    var schemaObjectFieldQuey = new SchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Системный лог";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                }
                #endregion Поле Id

            }
            #endregion Объект Object_A

        }

        /// <summary>
        /// Создание конструктора текста запроса доменных объектов Object_A.
        /// </summary>
        /// <param name="query">Запрос.</param>
        public static QueryBuilder QueryForObject_A(string query)
        {
            if (query == null)
            {
                throw new ArgumentNullException(nameof(query));
            }

            return QueryBuilder.New(Schema, new Guid("266032e5-19c6-434c-a521-d1d1c652edd1"), query);
        }
    }

}
