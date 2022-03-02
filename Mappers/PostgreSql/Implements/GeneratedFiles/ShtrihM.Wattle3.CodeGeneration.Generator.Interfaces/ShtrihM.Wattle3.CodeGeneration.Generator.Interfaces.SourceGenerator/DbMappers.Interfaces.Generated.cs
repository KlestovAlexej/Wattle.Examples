﻿/*
* Файл создан автоматически. Не редактировать вручную.
*
* Интерфейсы мапперов.
*
* Генератор - ShtrihM.Wattle3.CodeGeneration.Generators.Mappers.MappersInterfacesCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using System.Runtime.Serialization;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Interface
{
    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Object_ADtoNew : BaseMapperNewStateDto
    {
        /// <summary>
        /// Дата-время (DateTime). Обновляемое поле.
        /// </summary>
        public DateTime Value_DateTime;

        /// <summary>
        /// Дата-время (DateTime). Не обновляемое поле.
        /// </summary>
        public DateTime Value_DateTime_NotUpdate;

        /// <summary>
        /// Число (long). Поле обновляется только при изменении значения.
        /// </summary>
        public long Value_Long;

        /// <summary>
        /// Число с поддержкой null (int?). Обновляемое поле.
        /// </summary>
        public int? Value_Int;

        /// <summary>
        /// Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.
        /// </summary>
        public string Value_String;

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Object_BDtoNew : BaseMapperNewStateDto
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [DataContract]
    public sealed partial class Object_ADtoActual : BaseMapperActualStateDto
    {
        /// <summary>
        /// Дата-время (DateTime). Обновляемое поле.
        /// </summary>
        [DataMember(Order = 3)]
        public DateTime Value_DateTime;

        /// <summary>
        /// Дата-время (DateTime). Не обновляемое поле.
        /// </summary>
        [DataMember(Order = 4)]
        public DateTime Value_DateTime_NotUpdate;

        /// <summary>
        /// Число (long). Поле обновляется только при изменении значения.
        /// </summary>
        [DataMember(Order = 5)]
        public long Value_Long;

        /// <summary>
        /// Число с поддержкой null (int?). Обновляемое поле.
        /// </summary>
        [DataMember(Order = 6)]
        public int? Value_Int;

        /// <summary>
        /// Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.
        /// </summary>
        [DataMember(Order = 7)]
        public string Value_String;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [DataContract]
    public sealed partial class Object_BDtoActual : BaseMapperActualStateDto
    {
        /// <summary>
        /// Доступность.
        /// </summary>
        [DataMember(Order = 3)]
        public bool Available;

        /// <summary>
        /// Дата создания
        /// </summary>
        [DataMember(Order = 4)]
        public DateTime CreateDate;

    }

    /// <summary>
    /// Класс данных состояния изменённого доменного объекта.
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Object_ADtoChanged : BaseMapperChangedStateDto
    {
        /// <summary>
        /// Дата-время (DateTime). Обновляемое поле.
        /// </summary>
        public DateTime Value_DateTime;

        /// <summary>
        /// Дата-время (DateTime). Не обновляемое поле.
        /// </summary>
        public DateTime Value_DateTime_NotUpdate;

        /// <summary>
        /// Число (long). Поле обновляется только при изменении значения.
        /// </summary>
        public MapperChangedStateDtoField<long> Value_Long;

        /// <summary>
        /// Число с поддержкой null (int?). Обновляемое поле.
        /// </summary>
        public int? Value_Int;

        /// <summary>
        /// Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.
        /// </summary>
        public MapperChangedStateDtoField<string> Value_String;

    }

    /// <summary>
    /// Класс данных состояния изменённого доменного объекта.
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Object_BDtoChanged : BaseMapperChangedStateDto
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate;

    }

    /// <summary>
    /// Класс данных состояния удалённого доменного объекта.
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Object_ADtoDeleted : BaseMapperDeletedStateDto
    {
    }

    /// <summary>
    /// Класс данных состояния удалённого доменного объекта.
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class Object_BDtoDeleted : BaseMapperDeletedStateDto
    {
    }

    /// <summary>
    /// Идентификаторы мапперов в тектовом виде.
    /// </summary>
    public static class WellknownMappersAsText
    {
        /// <summary>
        /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
        /// </summary>
        public const string Object_A = "266032e5-19c6-434c-a521-d1d1c652edd1";

        /// <summary>
        /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
        /// </summary>
        public const string Object_B = "cb9a1909-a7b6-48a6-8fe5-7d714e0225ea";

    }

    /// <summary>
    /// Идентификаторы мапперов.
    /// </summary>
    public static class WellknownMappers
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly Dictionary<Guid, string> DisplayNames;

        static WellknownMappers()
        {
            DisplayNames = new Dictionary<Guid, string>
            {
                {new Guid(WellknownMappersAsText.Object_A), @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера"},
                {new Guid(WellknownMappersAsText.Object_B), @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)"},
            };
        }

        /// <summary>
        /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
        /// </summary>
        public static readonly Guid Object_A = new Guid(WellknownMappersAsText.Object_A);

        /// <summary>
        /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
        /// </summary>
        public static readonly Guid Object_B = new Guid(WellknownMappersAsText.Object_B);

        public static string GetDisplayName(Guid id)
        {
            if (DisplayNames.TryGetValue(id, out var result))
            {
                return (result);
            }

            return (id.ToString());
        }
    }

    /// <summary>
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    [MapperInterface(WellknownMappersAsText.Object_A)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperObject_A : IMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_Object_A".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRevision(IMappersSession session, long id, long revision);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        Object_ADtoActual Get(IHostMappersSession hostMappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<Object_ADtoActual> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        Object_ADtoActual GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<Object_ADtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        Object_ADtoActual Update(IMappersSession session, Object_ADtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<Object_ADtoActual> UpdateAsync(IMappersSession session, Object_ADtoChanged data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<Object_ADtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<Object_ADtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        Object_ADtoActual New(IMappersSession session, Object_ADtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<Object_ADtoActual> NewAsync(IMappersSession session, Object_ADtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        void Delete(IMappersSession session, Object_ADtoDeleted data);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask DeleteAsync(IMappersSession session, Object_ADtoDeleted data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<Object_ADtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<Object_ADtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<Object_ADtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter selectFilter = null);
    }

    /// <summary>
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    [MapperInterface(WellknownMappersAsText.Object_B)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperObject_B : IMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Получение максимального значение существующего идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает максимальное значение идентити или <see langword="null" /> если нет ни одной записи.</returns>
        long? GetMaxId(IMappersSession session);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует или скрыта возвращает <see langword="false" />.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует или скрыта возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        bool ExistsRaw(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если записи существует иначе если запись не существует или скрыта возвращает <see langword="null" />.</returns>
        Object_BDtoActual Get(IHostMappersSession hostMappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если записи существует иначе если запись не существует или скрыта возвращает <see langword="null" />.</returns>
        ValueTask<Object_BDtoActual> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        Object_BDtoActual GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<Object_BDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        Object_BDtoActual Update(IMappersSession session, Object_BDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<Object_BDtoActual> UpdateAsync(IMappersSession session, Object_BDtoChanged data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<Object_BDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<Object_BDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        Object_BDtoActual New(IMappersSession session, Object_BDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<Object_BDtoActual> NewAsync(IMappersSession session, Object_BDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Сокрытие записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для сокрытия записи.</param>
        void Hide(IMappersSession session, Object_BDtoDeleted data);

        /// <summary>
        /// Сокрытие записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для сокрытия записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask HideAsync(IMappersSession session, Object_BDtoDeleted data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        IEnumerable<Object_BDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<Object_BDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        IEnumerable<Object_BDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей кроме скрытых записей.</returns>
        IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
        long GetCount(IMappersSession session, IMapperSelectFilter selectFilter = null);
    }

}
