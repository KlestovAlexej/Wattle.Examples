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
using MessagePack;
using MessagePack.Formatters;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using System.Runtime.Serialization;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Interface
{
    /// <summary>
    /// Класс данных состояния нового доменного объекта.
    /// Уникальный ключ транзакции
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoCreate(WellknownMappersAsText.TransactionKey)]
    public sealed partial class TransactionKeyDtoNew : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Произвольные данные транзакции
        /// </summary>
        public long Tag;

        /// <summary>
        /// Ключ транзакции
        /// </summary>
        public Guid Key;

    }

    /// <summary>
    /// Класс актуальных данных состояния доменного объекта в БД.
    /// Уникальный ключ транзакции
    /// </summary>
    // ReSharper disable once PartialTypeWithSinglePart
    [MapperDtoSelect(WellknownMappersAsText.TransactionKey)]
    [DataContract]
    public sealed partial class TransactionKeyDtoActual : IMapperDto
    {
        /// <summary>
        /// Идентити.
        /// </summary>
        [DataMember(Order = 1)]
        public long Id { get; set; }

        /// <summary>
        /// Произвольные данные транзакции
        /// </summary>
        [DataMember(Order = 2)]
        public long Tag;

        /// <summary>
        /// Ключ транзакции
        /// </summary>
        [DataMember(Order = 3)]
        public Guid Key;

    }

    /// <summary>
    /// Идентификаторы мапперов в тектовом виде.
    /// </summary>
    public static class WellknownMappersAsText
    {
        /// <summary>
        /// Уникальный ключ транзакции
        /// </summary>
        public const string TransactionKey = "52af162d-5f87-4c74-965f-eefc9850c088";

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
                {new Guid(WellknownMappersAsText.TransactionKey), @"Уникальный ключ транзакции"},
            };
        }

        /// <summary>
        /// Уникальный ключ транзакции
        /// </summary>
        public static readonly Guid TransactionKey = new Guid(WellknownMappersAsText.TransactionKey);

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
    /// Уникальный ключ транзакции
    /// </summary>
    [MapperInterface(WellknownMappersAsText.TransactionKey)]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    // ReSharper disable once PartialTypeWithSinglePart
    public partial interface IMapperTransactionKey : IMapper, IPartitionsMapper
    {
        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        string TableName { get; }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TransactionKey".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        long GetNextId(IMappersSession session);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_TransactionKey".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TransactionKey".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default);

        /// <summary>
        /// Проверка существования записи с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        bool Exists(IMappersSession session, long id);

        /// <summary>
        /// Проверка существования записи с указаным идентити..
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
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
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        TransactionKeyDtoActual Get(IHostMappersSession hostMappersSession, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        ValueTask<IMapperDto> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        TransactionKeyDtoActual GetRaw(IMappersSession session, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        ValueTask<TransactionKeyDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        void BulkInsert(IMappersSession session, IEnumerable<TransactionKeyDtoNew> data);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        ValueTask BulkInsertAsync(IMappersSession session, IEnumerable<TransactionKeyDtoNew> data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        TransactionKeyDtoActual New(IMappersSession session, TransactionKeyDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        ValueTask<IMapperDto> NewAsync(IMappersSession session, TransactionKeyDtoNew data, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TransactionKeyDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IAsyncEnumerable<TransactionKeyDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TransactionKeyDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        IEnumerable<TransactionKeyDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null);

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
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, CancellationToken cancellationToken = default);
    }

}
