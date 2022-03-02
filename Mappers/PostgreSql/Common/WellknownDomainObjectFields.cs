using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.Common;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common
{
    /// <summary>
    /// Поля доменных объектов.
    /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [Description("Примеры мапперов")]
    [SchemaMappers(SchemaMapperStorage.PostgreSql, Namespace = "ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements")]
    public static class WellknownDomainObjectFields
    {
        /// <summary>
        /// Все поля доменных объектов и их описание.
        /// </summary>
        public static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

        static WellknownDomainObjectFields()
        {
            var mainType = MethodBase.GetCurrentMethod()!.DeclaringType;
            var types = mainType!.GetNestedTypes();
            var displayNames = new Dictionary<Guid, string>(CommonDomainObjectValues.DisplayNames);
            foreach (var type in types)
            {
                WellknowConstantsHelper.CollectDisplayNames(displayNames, type);
            }
            DisplayNames = displayNames;
        }

        #region Object_A - Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера.

        /// <summary>
        /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера.
        /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
        /// </summary>
        [Description("Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера")]
        [SchemaMapper(MapperId = WellknownDomainObjects.Text.Object_A, IsPrepared = true, IsCached = true, DeleteMode = SchemaMapperDeleteMode.Delete)]
        [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = ComplexIdentity.Level.L1, PartitionsExpandInterface = true)]
        [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
        [SchemaMapperRevisionField(IsVersion = true)]
        public static class Object_A
        {
            /// <summary>
            /// Дата-время (DateTime). Обновляемое поле.
            /// </summary>
            [Description("Дата-время (DateTime). Обновляемое поле.")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
            public static readonly Guid Value_DateTime = new("DCE071BB-796E-4397-91B8-EAF116747880");

            /// <summary>
            /// Дата-время (DateTime). Не обновляемое поле.
            /// </summary>
            [Description("Дата-время (DateTime). Не обновляемое поле.")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.NotUpdate)]
            public static readonly Guid Value_DateTime_NotUpdate = new("273A65E2-7647-42DB-A15D-58B69A64C69D");

            /// <summary>
            /// Число (long). Поле обновляется только при изменении значения.
            /// </summary>
            [Description("Число (long). Поле обновляется только при изменении значения.")]
            [SchemaMapperField(typeof(long), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_Long = new("87A005ED-CA51-4C60-83EC-6540AC0823D6");

            /// <summary>
            /// Число с поддержкой null (int?). Обновляемое поле.
            /// </summary>
            [Description("Число с поддержкой null (int?). Обновляемое поле.")]
            [SchemaMapperField(typeof(int?), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
            public static readonly Guid Value_Int = new("198251EF-8183-4A09-A760-E5BAAFBBB6FF");

            /// <summary>
            /// Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.
            /// </summary>
            [Description("Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.")]
            [SchemaMapperField(typeof(string), DbIsNull = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_String = new("100E6573-B387-4CB5-B3D6-45DF4CB2CC9C");
        }

        #endregion

        #region Object_B - Объект с сокрытием записи при удалении (без фичического страниы записи в БД).

        /// <summary>
        /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД).
        /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
        /// </summary>
        [Description("Объект с сокрытием записи при удалении (без фичического страниы записи в БД)")]
        [SchemaMapper(MapperId = WellknownDomainObjects.Text.Object_B, DeleteMode = SchemaMapperDeleteMode.Hide)]
        [SchemaMapperRevisionField]
        [SchemaMapperAvailableField]
        public static class Object_B
        {
            /// <summary>
            /// Дата создания.
            /// </summary>
            [Description("Дата создания")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
            public static readonly Guid CreateDate = new("92847C2C-E7B4-4EE1-A628-042B75AA9225");
        }

        #endregion

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
