using ShtrihM.Wattle3.DomainObjects.Interfaces;
using System;
using System.Diagnostics.CodeAnalysis;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects.Partitions;

/// <summary>
/// Индексатор дней по которым идёт партиционирование таблиц БД.
/// </summary>
[SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
[SuppressMessage("ReSharper", "UnusedMember.Global")]
public class PartitionsDay
{
    private static readonly DateTime DefaultStartDay = new(2022, 02, 11);

    private readonly ITimeService m_timeService;

    public PartitionsDay(ITimeService timeService)
    {
        m_timeService = timeService ?? throw new ArgumentNullException(nameof(timeService));
    }

    /// <summary>
    /// Получить день по его индексу.
    /// </summary>
    public DateTime GetDay(long dayIndex)
    {
        var result = StartDay.AddDays(dayIndex);

        return result;
    }

    /// <summary>
    /// Получить индекс дня.
    /// </summary>
    public long GetDayIndex(DateTime date)
    {
        var result = (long)(date.Date - StartDay).TotalDays;

        return result;
    }

    /// <summary>
    /// Начальный день индексирования.
    /// </summary>
    public DateTime StartDay => DefaultStartDay;

    /// <summary>
    /// Получить индекс текущего дня <seealso cref="ITimeService.NowDateTime"/>.
    /// </summary>
    public long NowDayIndex
    {
        get
        {
            var nowDateTime = m_timeService.NowDateTime;
            var result = (long)(nowDateTime.Date - StartDay).TotalDays;

            return result;
        }
    }
}