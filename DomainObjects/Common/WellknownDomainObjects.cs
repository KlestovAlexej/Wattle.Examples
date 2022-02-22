using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using ShtrihM.Wattle3.Primitives;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Common
{
    /// <summary>
    /// Идентификаторы объектов.
    /// </summary>
    [SuppressMessage("ReSharper", "MemberHidesStaticFromOuterClass")]
    [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
    public static class WellknownDomainObjects
    {
        /// <summary>
        /// Идентификаторы объектов в текстовом виде.
        /// </summary>
        public static class Text
        {
            /// <summary>
            /// Отслеживание изменений.
            /// </summary>
            public const string ChangeTracker = "67BF3734-17BB-4E9A-B0F1-B8F85382E690";

            /// <summary>
            /// Документ.
            /// </summary>
            public const string Document = "D70D5118-2C04-4A66-A5A1-4573B7F91631";
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
        /// Отслеживание изменений.
        /// </summary>
        [Description("Отслеживание изменений")]
        public static readonly Guid ChangeTracker = new(Text.ChangeTracker);

        /// <summary>
        /// Документ.
        /// </summary>
        [Description("Документ")]
        public static readonly Guid Document = new(Text.Document);

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
