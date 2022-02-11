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
    /// Создать доменный объект по шаблону.
    /// </summary>
    /// <returns>Созданный доменный объект.</returns>
    IDomainObjectDocument New(DateTime valueDateTime, long valueLong, int? valueInt);
}