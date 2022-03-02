/*
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
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Interface
{
    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Документ
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class DocumentDtoNew : BaseMapperNewStateDto
    {
        /// <summary>
        /// Дата-время создания
        /// </summary>
        public DateTime CreateDate;

        /// <summary>
        /// Дата-время модификации
        /// </summary>
        public DateTime ModificationDate;

        /// <summary>
        /// Доле документа - дата-время
        /// </summary>
        public DateTime Value_DateTime;

        /// <summary>
        /// Доле документа - число
        /// </summary>
        public long Value_Long;

        /// <summary>
        /// Доле документа - число с поддержкой null
        /// </summary>
        public int? Value_Int;

    }

    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Отслеживание изменений
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class ChangeTrackerDtoNew : BaseMapperNewStateDto
    {
    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Документ
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [DataContract]
    public sealed partial class DocumentDtoActual : BaseMapperActualStateDto
    {
        /// <summary>
        /// Дата-время создания
        /// </summary>
        [DataMember(Order = 3)]
        public DateTime CreateDate;

        /// <summary>
        /// Дата-время модификации
        /// </summary>
        [DataMember(Order = 4)]
        public DateTime ModificationDate;

        /// <summary>
        /// Доле документа - дата-время
        /// </summary>
        [DataMember(Order = 5)]
        public DateTime Value_DateTime;

        /// <summary>
        /// Доле документа - число
        /// </summary>
        [DataMember(Order = 6)]
        public long Value_Long;

        /// <summary>
        /// Доле документа - число с поддержкой null
        /// </summary>
        [DataMember(Order = 7)]
        public int? Value_Int;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Отслеживание изменений
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [DataContract]
    public sealed partial class ChangeTrackerDtoActual : BaseMapperActualStateDto
    {
    }

    /// <summary>
    /// Класс данных состояния изменённого доменного объекта.
    /// Документ
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class DocumentDtoChanged : BaseMapperChangedStateDto
    {
        /// <summary>
        /// Дата-время создания
        /// </summary>
        public DateTime CreateDate;

        /// <summary>
        /// Дата-время модификации
        /// </summary>
        public DateTime ModificationDate;

        /// <summary>
        /// Доле документа - дата-время
        /// </summary>
        public MapperChangedStateDtoField<DateTime> Value_DateTime;

        /// <summary>
        /// Доле документа - число
        /// </summary>
        public MapperChangedStateDtoField<long> Value_Long;

        /// <summary>
        /// Доле документа - число с поддержкой null
        /// </summary>
        public MapperChangedStateDtoField<int?> Value_Int;

    }

    /// <summary>
    /// Класс данных состояния удалённого доменного объекта.
    /// Документ
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    public sealed partial class DocumentDtoDeleted : BaseMapperDeletedStateDto
    {
    }

    /// <summary>
    /// Идентификаторы мапперов в тектовом виде.
    /// </summary>
    public static class WellknownMappersAsText
    {
        /// <summary>
        /// Документ
        /// </summary>
        public const string Document = "d70d5118-2c04-4a66-a5a1-4573b7f91631";

        /// <summary>
        /// Отслеживание изменений
        /// </summary>
        public const string ChangeTracker = "67bf3734-17bb-4e9a-b0f1-b8f85382e690";

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
                {new Guid(WellknownMappersAsText.Document), @"Документ"},
                {new Guid(WellknownMappersAsText.ChangeTracker), @"Отслеживание изменений"},
            };
        }

        /// <summary>
        /// Документ
        /// </summary>
        public static readonly Guid Document = new Guid(WellknownMappersAsText.Document);

        /// <summary>
        /// Отслеживание изменений
        /// </summary>
        public static readonly Guid ChangeTracker = new Guid(WellknownMappersAsText.ChangeTracker);

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
    /// Документ
    /// </summary>
    [MapperInterface(WellknownMappersAsText.Document)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperDocument : IMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_Document".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_Document".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_Document".
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
        DocumentDtoActual Get(IHostMappersSession hostMappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<DocumentDtoActual> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        DocumentDtoActual GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<DocumentDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DocumentDtoActual Update(IMappersSession session, DocumentDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<DocumentDtoActual> UpdateAsync(IMappersSession session, DocumentDtoChanged data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<DocumentDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<DocumentDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        DocumentDtoActual New(IMappersSession session, DocumentDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<DocumentDtoActual> NewAsync(IMappersSession session, DocumentDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        void Delete(IMappersSession session, DocumentDtoDeleted data);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask DeleteAsync(IMappersSession session, DocumentDtoDeleted data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DocumentDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DocumentDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<DocumentDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

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
    /// Отслеживание изменений
    /// </summary>
    [MapperInterface(WellknownMappersAsText.ChangeTracker)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperChangeTracker : IMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_ChangeTracker".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
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
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ChangeTrackerDtoActual Get(IHostMappersSession hostMappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<ChangeTrackerDtoActual> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ChangeTrackerDtoActual GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<ChangeTrackerDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<ChangeTrackerDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<ChangeTrackerDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ChangeTrackerDtoActual New(IMappersSession session, ChangeTrackerDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<ChangeTrackerDtoActual> NewAsync(IMappersSession session, ChangeTrackerDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<ChangeTrackerDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<ChangeTrackerDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<ChangeTrackerDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

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

}
