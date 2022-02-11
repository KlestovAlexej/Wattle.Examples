using System;
using System.Threading;
using System.Threading.Tasks;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Examples.DomainObjects.Common;

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
    /// Создать доменный объект по шаблону.
    /// </summary>
    /// <returns>Созданный доменный объект.</returns>
    IDomainObjectDocument New(DateTime valueDateTime, long valueLong, int? valueInt);
}