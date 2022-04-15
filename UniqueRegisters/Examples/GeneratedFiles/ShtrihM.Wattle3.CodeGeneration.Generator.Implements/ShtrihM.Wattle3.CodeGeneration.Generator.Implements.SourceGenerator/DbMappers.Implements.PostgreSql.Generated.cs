/*
* Файл создан автоматически. Не редактировать вручную.
*
* Реализации мапперов.
*
* Генератор - ShtrihM.Wattle3.CodeGeneration.Generators.Mappers.PostgreSqlMappersImplementsCodeGenerator
*
*/
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Runtime.ExceptionServices;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using NpgsqlTypes;
using Npgsql;
using System.Diagnostics.CodeAnalysis;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.PostgreSql;
using ShtrihM.Wattle3.Mappers.PostgreSql.Schema;
using ShtrihM.Wattle3.Utils;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Caching.Interfaces;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Mappers.Primitives;
using ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.Interface;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.UniqueRegisters.Examples.Generated.PostgreSql.Implements
{
    public static class PostgreSqlSchemaQueriesProvider
    {
        public static readonly PostgreSqlSchemaQueries Schema;

        static PostgreSqlSchemaQueriesProvider()
        {
            Schema = new PostgreSqlSchemaQueries();

            #region Объект TransactionKey

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Уникальный ключ транзакции";
                schemaObjectQuey.Id = new Guid("52af162d-5f87-4c74-965f-eefc9850c088");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле Tag

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Произвольные данные транзакции";
                    schemaObjectFieldQuey.Id = new Guid("9d0ff6d9-4059-4db8-9b58-883707710026");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Tag";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Tag

                #region Поле Key

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Ключ транзакции";
                    schemaObjectFieldQuey.Id = new Guid("7e371548-201d-463f-85ff-95e1741ac449");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Key";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Key

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Уникальный ключ транзакции";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект TransactionKey

        }
    }

    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    public partial class Mappers : BasePostgreSqlMappers
    {
        private readonly IPostgreSqlMapperSelectFilterFactory m_selectFilterFactory;
        private readonly Func<Guid, string> m_getMapperDisplayName;

        [SuppressMessage("ReSharper", "RedundantCast")]
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        [SuppressMessage("ReSharper", "InvocationIsSkipped")]
        public Mappers(IMappersExceptionPolicy exceptionPolicy, string connectionString, ITimeService timeService, TimeSpan? timeStatisticsStep = null, int commandTimeout = CommandTimeoutInfinity, object context = null)
            : base(exceptionPolicy, connectionString, timeService, timeStatisticsStep, commandTimeout)
        {
            m_getMapperDisplayName = null;

            OnEnterConstructor(context);

            if (m_selectFilterFactory == null)
            {
                var selectFilterContext = new PostgreSqlMapperSelectFilterContext(PostgreSqlSchemaQueriesProvider.Schema);
                m_selectFilterFactory = new PostgreSqlMapperSelectFilterFactory(selectFilterContext);
            }

            AddMapper(new MapperTransactionKey(exceptionPolicy, m_selectFilterFactory));

            OnExitConstructor(context);
        }

        [SuppressMessage("ReSharper", "InvertIf")]
        protected override string GetMapperDisplayName(Guid mapperId)
        {
            var result = m_getMapperDisplayName?.Invoke(mapperId);

            if (result == null)
            {
                result = WellknownMappers.GetDisplayName(mapperId);

                return (result);
            }

            return (result);
        }

        /// <summary>
        /// Начало конструктора реестра маппперов.
        /// </summary>
        partial void OnEnterConstructor(object context);

        /// <summary>
        /// Конец конструктора реестра маппперов.
        /// </summary>
        partial void OnExitConstructor(object context);
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Уникальный ключ транзакции
    /// </summary>
    internal class BulkInsertDataReaderTransactionKey : BasePostgreSqlBulkInserter<TransactionKeyDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, TransactionKeyDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Tag, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Key, NpgsqlDbType.Uuid, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, TransactionKeyDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.Tag, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.Key, NpgsqlDbType.Uuid);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY TransactionKey (Id,
Tag,
Key) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Уникальный ключ транзакции
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.TransactionKey)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperTransactionKey : BasePostgreSqlMapper<TransactionKeyDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperTransactionKey
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperTransactionKey(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Уникальный ключ транзакции" + "' в БД", WellknownMappers.TransactionKey, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"TransactionKey", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperTransactionKey(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Уникальный ключ транзакции" + "' в БД", WellknownMappers.TransactionKey, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"TransactionKey", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"TransactionKey";

        /// <summary>
        /// Интерфейс управления партициями.
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        public IPartitionsManager Partitions { get; private set; }

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IMappersSession session, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchException(IHostMappersSession hostMappersSession, Exception exception);

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Initialize"/>.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnInitialize(IMappers mappers, Exception exception);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        partial void DoInitialize(IMappers mappers);

        /// <summary>
        /// Инициализация маппера.
        /// </summary>
        /// <param name="mappers">Реестр мапперов которому принадлежит маппер.</param>
        public virtual void Initialize(IMappers mappers)
        {
            if (mappers == null)
            {
                throw new ArgumentNullException(nameof(mappers));
            }
            try
            {
                DoInitialize(mappers);
            }
            catch (Exception exception)
            {

                CatchExceptionOnInitialize(mappers, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TransactionKey".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_TransactionKey');";
                    var temp = command.ExecuteScalar();
                    // ReSharper disable once PossibleNullReferenceException
                    var result = (long)temp;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetNextIds"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetNextIds(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение следующих значений идентити из последовательности "Sequence_TransactionKey".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count, CancellationToken cancellationToken)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (count <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                cancellationToken.ThrowIfCancellationRequested();

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_TransactionKey') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            var id = reader.GetInt64(indexId);
                            result.Add(id);
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextIds(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получение следующего значения идентити из последовательности "Sequence_TransactionKey".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="cancellationToken" >Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(IMappersSession session, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_TransactionKey');";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    // ReSharper disable once PossibleNullReferenceException
                    var result = (long)temp;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetNextId(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool Exists(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TransactionKey WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TransactionKey WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExists(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="ExistsRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TransactionKey WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM TransactionKey WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexTag">Индекс колонки 'Tag'.</param>
        /// <param name="indexKey">Индекс колонки 'Key'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexTag,
            out int indexKey)
        {
            indexId = reader.GetOrdinal("Id");
            indexTag = reader.GetOrdinal("Tag");
            indexKey = reader.GetOrdinal("Key");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexTag">Индекс колонки 'Tag'.</param>
        /// <param name="indexKey">Индекс колонки 'Key'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexTag,
            out int indexKey)
        {
            indexId = reader.GetOrdinal("Id");
            indexTag = reader.GetOrdinal("Tag");
            indexKey = reader.GetOrdinal("Key");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexTag">Индекс колонки 'Tag'.</param>
        /// <param name="indexKey">Индекс колонки 'Key'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TransactionKeyDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexTag,
            int indexKey)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new TransactionKeyDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Tag = reader.GetInt64(indexTag);
            result.Key = reader.GetGuid(indexKey);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexTag">Индекс колонки 'Tag'.</param>
        /// <param name="indexKey">Индекс колонки 'Key'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TransactionKeyDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexTag,
            int indexKey)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new TransactionKeyDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Tag = reader.GetInt64(indexTag);
            result.Key = reader.GetGuid(indexKey);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IHostMappersSession hostMappersSession, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual TransactionKeyDtoActual Get(IHostMappersSession hostMappersSession, long id)
        {
            if (hostMappersSession == null)
            {
                throw new ArgumentNullException(nameof(hostMappersSession));
            }

            try
            {
                var tempSession = hostMappersSession.GetMappersSession();
                var typedSession = (IPostgreSqlMappersSession)tempSession;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexTag,
                                out var indexKey);

                            var result = Read(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(hostMappersSession, exception, id);
                CatchException(hostMappersSession, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<TransactionKeyDtoActual> GetAsync(IHostMappersSession hostMappersSession, long id, CancellationToken cancellationToken = default)
        {
            if (hostMappersSession == null)
            {
                throw new ArgumentNullException(nameof(hostMappersSession));
            }

            try
            {
                var tempSession = await hostMappersSession.GetMappersSessionAsync(cancellationToken).ConfigureAwait(false);
                var typedSession = (IPostgreSqlMappersSession)tempSession;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexTag,
                                out var indexKey);

                            var result = Read(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(hostMappersSession, exception, id);
                CatchException(hostMappersSession, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGetRaw(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual TransactionKeyDtoActual GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexTag,
                                out var indexKey);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<TransactionKeyDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexTag,
                                out var indexKey);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetRaw(session, exception, id);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="BulkInsert"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnBulkInsert(IMappersSession session, Exception exception);

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        public virtual void BulkInsert(
            IMappersSession session,
            IEnumerable<TransactionKeyDtoNew> data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderTransactionKey();
                postgreSqlBulkInserter.Insert(typedSession, data);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask BulkInsertAsync(
            IMappersSession session,
            IEnumerable<TransactionKeyDtoNew> data,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var postgreSqlBulkInserter = new BulkInsertDataReaderTransactionKey();
                await postgreSqlBulkInserter.InsertAsync(typedSession, data, cancellationToken).ConfigureAwait(false);
            }
            catch (Exception exception)
            {
                CatchExceptionOnBulkInsert(session, exception);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="New"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Новая запись.</param>
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, TransactionKeyDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual TransactionKeyDtoActual New(IMappersSession session, TransactionKeyDtoNew data)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new TransactionKeyDtoActual
                {
                    Id = data.Id,
                    Tag = data.Tag,
                    Key = data.Key,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO TransactionKey
(
Id,
Tag,
Key
)
VALUES
(
@Id,
@Tag,
@Key
)";
                    {
                        var parameter = new NpgsqlParameter<long>(@"@Tag", NpgsqlDbType.Bigint) { TypedValue = result.Tag };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<Guid>(@"@Key", NpgsqlDbType.Uuid) { TypedValue = result.Key };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<TransactionKeyDtoActual> NewAsync(IMappersSession session, TransactionKeyDtoNew data, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;
                
                var result =
                new TransactionKeyDtoActual
                {
                    Id = data.Id,
                    Tag = data.Tag,
                    Key = data.Key,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO TransactionKey
(
Id,
Tag,
Key
)
VALUES
(
@Id,
@Tag,
@Key
)";
                    {
                        var parameter = new NpgsqlParameter<long>(@"@Tag", NpgsqlDbType.Bigint) { TypedValue = result.Tag };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<Guid>(@"@Key", NpgsqlDbType.Uuid) { TypedValue = result.Key };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnNew(session, exception, data);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumerator"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumerator(IMappersSession session, Exception exception, IMapperSelectFilter selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<TransactionKeyDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        (IPostgreSqlMapperSelectFilter) selectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexTag;
                    int indexKey;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexTag,
                            out indexKey);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TransactionKeyDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorRaw"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorRaw(IMappersSession session, Exception exception, IMapperSelectFilter selectFilter);

        /// <summary>
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<TransactionKeyDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            NpgsqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey";

                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        (IPostgreSqlMapperSelectFilter) selectFilter)
                    ;
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexTag;
                    int indexKey;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexTag,
                            out indexKey);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TransactionKeyDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorRaw(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter selectFilter);

        /// <summary>
        /// Получить итератор записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<TransactionKeyDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Tag,
Key
FROM TransactionKey";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        (IPostgreSqlMapperSelectFilter) selectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexTag;
                    int indexKey;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexTag,
                            out indexKey);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        TransactionKeyDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId,
                                indexTag,
                                indexKey);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (result);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetEnumeratorIdentitiesPage"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы {schemaMapper.MaxPageSize.AsLiteral()}.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetEnumeratorIdentitiesPage(IMappersSession session, Exception exception, int pageIndex, int pageSize, IMapperSelectFilter selectFilter);

        /// <summary>
        /// Получить итератор идентити записей выбранных с учётом фильтра для заданной страницы указанного размера.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей.</returns>
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if (((pageSize < 1) || (pageSize > 1000)))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }

            NpgsqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (IPostgreSqlMappersSession) session;

                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM TransactionKey";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        null,
                        @" Id DESC ",
                        @" LIMIT @__PageSize OFFSET @__SkipCount ",
                        (IPostgreSqlMapperSelectFilter) selectFilter);
                }
                catch (Exception exception)
                {
                    CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                    CatchException(session, exception);

                    var targetException = m_exceptionPolicy.Apply(exception);
                    if (ReferenceEquals(targetException, exception))
                    {
                        ExceptionDispatchInfo.Capture(exception).Throw();
                    }

                    throw targetException;
                }

                NpgsqlDataReader reader = null;
                try
                {
                    int indexId;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                        CatchException(session, exception);

                        var targetException = m_exceptionPolicy.Apply(exception);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        long item;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            item = reader.GetInt64(indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumeratorIdentitiesPage(session, exception, pageIndex, pageSize, selectFilter);
                            CatchException(session, exception);

                            var targetException = m_exceptionPolicy.Apply(exception);
                            if (ReferenceEquals(targetException, exception))
                            {
                                ExceptionDispatchInfo.Capture(exception).Throw();
                            }

                            throw targetException;
                        }

                        yield return (item);
                    }
                }
                finally
                {
                    reader.SilentDispose();
                }
            }
            finally
            {
                command.SilentDispose();
            }
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="GetCount"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        partial void CatchExceptionOnGetCount(IMappersSession session, Exception exception, IMapperSelectFilter selectFilter);

        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual long GetCount(IMappersSession session, IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM TransactionKey";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    var temp = command.ExecuteScalar();
                    // ReSharper disable once PossibleNullReferenceException
                    var result = (long)temp;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = m_exceptionPolicy.Apply(exception);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

}
