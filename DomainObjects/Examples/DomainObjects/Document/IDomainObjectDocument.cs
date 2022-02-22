using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document
{
    /// <summary>
    /// Документ.
    /// </summary>
    public interface IDomainObjectDocument : IDomainObject
    {
        /// <summary>
        /// Версия данных в БД.
        /// </summary>
        long Revision { get; }

        /// <summary>
        /// Дата-время создания.
        /// </summary>
        DateTime CreateDate { get; }

        /// <summary>
        /// Дата-время модификации.
        /// </summary>
        DateTime ModificationDate { get; }

        /// <summary>
        /// Доле документа - дата-время.
        /// </summary>
        DateTime Value_DateTime { get; set; }

        /// <summary>
        /// Доле документа - число.
        /// </summary>
        long Value_Long { get; set; }

        /// <summary>
        /// Доле документа - число с поддержкой null.
        /// </summary>
        int? Value_Int { get; set; }

        /// <summary>
        /// Метод доменного объекта с доменнной логикой.
        /// </summary>
        string Method(DateTime value_DateTime, long value_Long, int? value_Int);

        /// <summary>
        /// Удалить доменный объект.
        /// </summary>
        void Delete();

        /// <summary>
        /// Верификация версии данных в БД.
        /// </summary>
        void Version();
    }
}