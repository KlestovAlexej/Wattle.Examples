using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.Common;
using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Common
{
    /// <summary>
    /// Поля доменных объектов.
    /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
    /// </summary>
    [SuppressMessage("ReSharper", "UnusedType.Global")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
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

        #region Document - Документ.

        /// <summary>
        /// Документ.
        /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
        /// </summary>
        [Description("Документ")]
        [SchemaMapper(MapperId = WellknownDomainObjects.Text.Document, IsPrepared = true, IsCached = true, DeleteMode = SchemaMapperDeleteMode.Delete)]
        [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = ComplexIdentity.Level.L2, PartitionsExpandInterface = true)]
        [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
        [SchemaMapperRevisionField(IsVersion = true)]
        public static class Document
        {
            /// <summary>
            /// Дата-время создания.
            /// </summary>
            [Description("Дата-время создания")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
            public static readonly Guid CreateDate = new("7EF5BC59-73AE-485F-A1D5-7A7CEC7B691C");

            /// <summary>
            /// Дата-время модификации.
            /// </summary>
            [Description("Дата-время модификации")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
            public static readonly Guid ModificationDate = new("F1A9D132-E6B2-4C4C-96E7-BDFCB1E0A330");

            /// <summary>
            /// Доле документа - дата-время.
            /// </summary>
            [Description("Доле документа - дата-время")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_DateTime = new("31BECBF5-304F-4E0B-9540-25EFD7191F19");

            /// <summary>
            /// Доле документа - число.
            /// </summary>
            [Description("Доле документа - число")]
            [SchemaMapperField(typeof(long), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_Long = new("15713B81-57C2-4A29-A978-2F2EA00D4554");

            /// <summary>
            /// Доле документа - число с поддержкой null.
            /// </summary>
            [Description("Доле документа - число с поддержкой null")]
            [SchemaMapperField(typeof(int?), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_Int = new("C238F1B0-C802-41F3-A6F0-AE2B52A1598F");
        }

        #endregion

        #region ChangeTracker - Отслеживание изменений.

        /// <summary>
        /// Отслеживание изменений.
        /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
        /// </summary>
        [Description("Отслеживание изменений")]
        [SchemaMapper(MapperId = WellknownDomainObjects.Text.ChangeTracker, IsPrepared = true)]
        [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = ComplexIdentity.Level.L2, PartitionsExpandInterface = true)]
        [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
        public static class ChangeTracker
        {
            /* NONE */
        }

        #endregion

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
