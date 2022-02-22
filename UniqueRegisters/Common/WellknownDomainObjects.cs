using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Common
{
    /// <summary>
    /// Идентификаторы объектов.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    public static class WellknownDomainObjects
    {
        /// <summary>
        /// Идентификаторы объектов в текстовом виде.
        /// </summary>
        public static class Text
        {
            /// <summary>
            /// Уникальный ключ транзакции.
            /// </summary>
            public const string TransactionKey = "52AF162D-5F87-4C74-965F-EEFC9850C088";
        }

        /// <summary>
        /// Все идентификаторы объектов и их описание.
        /// </summary>
        public static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

        static WellknownDomainObjects()
        {
            WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod()!.DeclaringType);
        }

        /// <summary>
        /// Уникальный ключ транзакции.
        /// </summary>
        [Description("Уникальный ключ транзакции")]
        public static readonly Guid TransactionKey = new(Text.TransactionKey);

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
