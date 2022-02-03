using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using ShtrihM.Wattle3.Primitives;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common
{
    /// <summary>
    /// Идентификаторы объектов.
    /// </summary>
    public static class WellknownDomainObjects
    {
        /// <summary>
        /// Идентификаторы объектов в текстовом виде.
        /// </summary>
        public static class Text
        {
            /// <summary>
            /// Объект с партиционированием таблицы БД и ключём из последовательности БД.
            /// </summary>
            public const string Object_A = "266032E5-19C6-434C-A521-D1D1C652EDD1";

            /// <summary>
            /// Объект с оптимистической конкуренцией на уровне БД и условным изменением колонок БД.
            /// </summary>
            public const string Object_B = "2A54A071-C4F7-47A6-B802-CC8CFA0F1C5F";

            /// <summary>
            /// Объект с кешированием записей БД в памяти на уровне маппера и сокрытием записи при удалении (без фичического страниы записи в БД).
            /// </summary>
            public const string Object_C = "CB9A1909-A7B6-48A6-8FE5-7D714E0225EA";
        }

        /// <summary>
        /// Все идентификаторы объектов и их описание.
        /// </summary>
        public static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

        static WellknownDomainObjects()
        {
            WellknowConstantsHelper.CollectDisplayNames(out DisplayNames, MethodBase.GetCurrentMethod().DeclaringType);
        }

        /// <summary>
        /// Объект с партиционированием таблицы БД и ключём из последовательности БД.
        /// </summary>
        [Description("Объект с партиционированием таблицы БД и ключём из последовательности БД")]
        public static readonly Guid Object_A = new(Text.Object_A);

        /// <summary>
        /// Объект с оптимистической конкуренцией на уровне БД и условным изменением колонок БД.
        /// </summary>
        [Description("Объект с оптимистической конкуренцией на уровне БД и условным изменением колонок БД")]
        public static readonly Guid Object_B = new(Text.Object_B);

        /// <summary>
        /// Объект с кешированием записей БД в памяти на уровне маппера и сокрытием записи при удалении (без фичического страниы записи в БД).
        /// </summary>
        [Description("Объект с кешированием записей БД в памяти на уровне маппера и сокрытием записи при удалении (без фичического страниы записи в БД)")]
        public static readonly Guid Object_C = new(Text.Object_C);

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
