using ShtrihM.Wattle3.Mappers.PostgreSql;

namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.DomainObjects
{
    /// <summary>
    /// Интерфейс маппера с поддержкой партиционирования таблицы БД.
    /// </summary>
    public interface IPartitionsMapper
    {
        public IPartitionsManager Partitions { get; }
    }
}
