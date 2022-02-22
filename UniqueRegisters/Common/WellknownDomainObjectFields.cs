using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.Common;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Common
{
    /// <summary>
    /// Поля доменных объектов.
    /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
    /// </summary>
    public static class WellknownDomainObjectFields
    {
        /// <summary>
        /// Все поля доменных объектов и их описание.
        /// </summary>
        public static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

        static WellknownDomainObjectFields()
        {
            var mainType = MethodBase.GetCurrentMethod().DeclaringType;
            var types = mainType.GetNestedTypes();
            var displayNames = new Dictionary<Guid, string>(CommonDomainObjectValues.DisplayNames);
            foreach (var type in types)
            {
                WellknowConstantsHelper.CollectDisplayNames(displayNames, type);
            }
            DisplayNames = displayNames;
        }

        #region TransactionKey - Уникальный ключ транзакции.

        /// <summary>
        /// Уникальный ключ транзакции.
        /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
        /// </summary>
        [Description("Уникальный ключ транзакции")]
        [SchemaMapper(MapperId = WellknownDomainObjects.Text.TransactionKey)]
        [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = ComplexIdentity.Level.L2, PartitionsExpandInterface = true)]
        [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
        public static class TransactionKey
        {
            /// <summary>
            /// Произвольные данные транзакции.
            /// </summary>
            [Description("Произвольные данные транзакции")]
            [SchemaMapperField(typeof(long), Where = true, Order = true)]
            public static readonly Guid Tag = new("9D0FF6D9-4059-4DB8-9B58-883707710026");

            /// <summary>
            /// Ключ транзакции.
            /// </summary>
            [Description("Ключ транзакции")]
            [SchemaMapperField(typeof(Guid), Where = true, Order = true)]
            public static readonly Guid Key = new("7E371548-201D-463F-85FF-95E1741AC449");
        }

        #endregion

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
