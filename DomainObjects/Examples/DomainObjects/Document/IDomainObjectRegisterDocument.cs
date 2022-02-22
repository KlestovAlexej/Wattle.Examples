using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Document;

/// <summary>
/// Кастомный реестр доменных объектов.
/// </summary>
[DomainObjectRegistersInterface(WellknownDomainObjects.Text.Document)]
public interface IDomainObjectRegisterDocument : IDomainObjectRegister
{
    /// <summary>
    /// Найти доменный объект по идентити.
    /// </summary>
    /// <param name="identity">Идентити объекта.</param>
    /// <param name="throwIfNotFound">Генерировать исключение <seealso cref="InvalidOperationException"/> если доменный объект не найден.</param>
    /// <returns>Доменный объект или <see langword="null" /> если объект не найден.</returns>
    IDomainObjectDocument Find(long identity, bool throwIfNotFound = false);

    /// <summary>
    /// Найти доменный объект по идентити.
    /// </summary>
    /// <param name="identity">Идентити объекта.</param>
    /// <param name="throwIfNotFound">Генерировать исключение <seealso cref="InvalidOperationException"/> если доменный объект не найден.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Доменный объект или <see langword="null" /> если объект не найден.</returns>
    ValueTask<IDomainObjectDocument> FindAsync(long identity, bool throwIfNotFound = false, CancellationToken cancellationToken = default);

    /// <summary>
    /// Создать доменный объект по шаблону.
    /// </summary>
    /// <param name="valueDateTime">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
    /// <param name="valueLong">Поле <see cref="IDomainObjectDocument.Value_Long"/>.</param>
    /// <param name="valueInt">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
    /// <returns>Созданный доменный объект.</returns>
    IDomainObjectDocument New(DateTime valueDateTime, long valueLong, int? valueInt);

    /// <summary>
    /// Создать доменный объект по шаблону.
    /// </summary>
    /// <param name="valueDateTime">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
    /// <param name="valueLong">Поле <see cref="IDomainObjectDocument.Value_Long"/>.</param>
    /// <param name="valueInt">Поле <see cref="IDomainObjectDocument.Value_DateTime"/>.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Созданный доменный объект.</returns>
    ValueTask<IDomainObjectDocument> NewAsync(DateTime valueDateTime, long valueLong, int? valueInt, CancellationToken cancellationToken = default);
}