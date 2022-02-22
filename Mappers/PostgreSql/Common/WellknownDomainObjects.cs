using ShtrihM.Wattle3.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common
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
            /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера.
            /// </summary>
            public const string Object_A = "266032E5-19C6-434C-A521-D1D1C652EDD1";

            /// <summary>
            /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД).
            /// </summary>
            public const string Object_B = "CB9A1909-A7B6-48A6-8FE5-7D714E0225EA";
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
        /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера.
        /// </summary>
        [Description("Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера")]
        public static readonly Guid Object_A = new(Text.Object_A);

        /// <summary>
        /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД).
        /// </summary>
        [Description("Объект с сокрытием записи при удалении (без фичического страниы записи в БД)")]
        public static readonly Guid Object_B = new(Text.Object_B);

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
