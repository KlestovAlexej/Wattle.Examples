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
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Implements
{
    public static class PostgreSqlSchemaQueriesProvider
    {
        public static readonly PostgreSqlSchemaQueries Schema;

        static PostgreSqlSchemaQueriesProvider()
        {
            Schema = new PostgreSqlSchemaQueries();

            #region Объект Object_A

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Системный лог";
                schemaObjectQuey.Id = new Guid("266032e5-19c6-434c-a521-d1d1c652edd1");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("fabb42ed-5c3a-4234-8bf6-0cffa10baa18");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле ModificationDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата модификации";
                    schemaObjectFieldQuey.Id = new Guid("cc4c135f-cd40-4380-9e39-6c1654352b19");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле ModificationDate

                #region Поле State

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Статус";
                    schemaObjectFieldQuey.Id = new Guid("196f6520-05e9-4412-8d85-0921588109f6");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"State";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле State

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Системный лог";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект Object_A

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

            AddMapper(new MapperObject_A(exceptionPolicy, m_selectFilterFactory));

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
    /// Системный лог
    /// </summary>
    internal class BulkInsertDataReaderObject_A : BasePostgreSqlBulkInserter<Object_ADtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, Object_ADtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint).ConfigureAwait(false);
            await binaryImport.WriteAsync(TypeCorrectors.DateTime(instance.CreateDate), NpgsqlDbType.Timestamp).ConfigureAwait(false);
            await binaryImport.WriteAsync(TypeCorrectors.DateTime(instance.ModificationDate), NpgsqlDbType.Timestamp).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.State, NpgsqlDbType.Smallint).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, Object_ADtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(TypeCorrectors.DateTime(instance.CreateDate), NpgsqlDbType.Timestamp);
            binaryImport.Write(TypeCorrectors.DateTime(instance.ModificationDate), NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.State, NpgsqlDbType.Smallint);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY Object_A (Id,
Revision,
CreateDate,
ModificationDate,
State) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Системный лог
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.Object_A)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperObject_A : BasePostgreSqlMapper<Object_ADtoActual>, IMapperInitializer, IMapperObject_A
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperObject_A(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Системный лог" + "' в БД", WellknownMappers.Object_A, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"Object_A", ComplexIdentity.Level.L1, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperObject_A(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Системный лог" + "' в БД", WellknownMappers.Object_A, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"Object_A", ComplexIdentity.Level.L1, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"Object_A";

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
        /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
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
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Object_A');";

                    command.Prepare();

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
        /// Получение следующих значений идентити из последовательности "Sequence_Object_A".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="count">Количество следующийх значений идентити из последовательности.</param>
        /// <returns>Возвращает коллекцию следующих значений идентити.</returns>
        public virtual IList<long> GetNextIds(IMappersSession session, int count)
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

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Object_A') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    command.Prepare();

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        var result = new List<long>(count);
                        while (reader.Read())
                        {
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
        /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
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
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Object_A');";

                    command.Prepare();

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

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
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexState">Индекс колонки 'State'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexState)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexState = reader.GetOrdinal("State");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexState">Индекс колонки 'State'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexState)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexState = reader.GetOrdinal("State");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexState">Индекс колонки 'State'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object_ADtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexState)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);
            result.ModificationDate = reader.GetDateTime(indexModificationDate);
            result.State = reader.GetInt16(indexState);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexState">Индекс колонки 'State'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object_ADtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexState)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);
            result.ModificationDate = reader.GetDateTime(indexModificationDate);
            result.State = reader.GetInt16(indexState);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе если запись не существует возвращает <see langword="null" />.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual Object_ADtoActual Get(IMappersSession session, long id)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexState);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
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
        public virtual async ValueTask<Object_ADtoActual> GetAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A WHERE
(Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexState);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(session, exception, id);
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
        public virtual Object_ADtoActual GetRaw(IMappersSession session, long id)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexState);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);

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
        public virtual async ValueTask<Object_ADtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A WHERE (Id = @Id)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            GetColumnIndexesRaw(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate,
                                out var indexModificationDate,
                                out var indexState);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);

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
        /// Обработка исключения мапппера в методе <see cref="Update"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Измененная запись.</param>
        partial void CatchExceptionOnUpdate(IMappersSession session, Exception exception, Object_ADtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual Object_ADtoActual Update(IMappersSession session, Object_ADtoChanged data)
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
                new Object_ADtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = TypeCorrectors.DateTime(data.CreateDate),
                    ModificationDate = TypeCorrectors.DateTime(data.ModificationDate),
                    State = data.State,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Object_A SET
Revision = @New_Revision,
ModificationDate = @ModificationDate,
State = @State
WHERE
(Id = @Id) AND (Revision < @New_Revision)";
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<short>("@State", NpgsqlDbType.Smallint) { TypedValue = result.State };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
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
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual async ValueTask<Object_ADtoActual> UpdateAsync(IMappersSession session, Object_ADtoChanged data, CancellationToken cancellationToken = default)
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
                new Object_ADtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = TypeCorrectors.DateTime(data.CreateDate),
                    ModificationDate = TypeCorrectors.DateTime(data.ModificationDate),
                    State = data.State,
                };

                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Object_A SET
Revision = @New_Revision,
ModificationDate = @ModificationDate,
State = @State
WHERE
(Id = @Id) AND (Revision < @New_Revision)";
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<short>("@State", NpgsqlDbType.Smallint) { TypedValue = result.State };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                return (result);
            }
            catch (Exception exception)
            {
                CatchExceptionOnUpdate(session, exception, data);
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
            IEnumerable<Object_ADtoNew> data)
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderObject_A();
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
            IEnumerable<Object_ADtoNew> data,
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderObject_A();
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
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, Object_ADtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual Object_ADtoActual New(IMappersSession session, Object_ADtoNew data)
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
                new Object_ADtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = TypeCorrectors.DateTime(data.CreateDate),
                    ModificationDate = TypeCorrectors.DateTime(data.ModificationDate),
                    State = data.State,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Object_A
(
Id,
Revision,
CreateDate,
ModificationDate,
State
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@State
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@CreateDate", NpgsqlDbType.Timestamp) { TypedValue = result.CreateDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<short>(@"@State", NpgsqlDbType.Smallint) { TypedValue = result.State };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    command.Prepare();

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
        public virtual async ValueTask<Object_ADtoActual> NewAsync(IMappersSession session, Object_ADtoNew data, CancellationToken cancellationToken = default)
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
                new Object_ADtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = TypeCorrectors.DateTime(data.CreateDate),
                    ModificationDate = TypeCorrectors.DateTime(data.ModificationDate),
                    State = data.State,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Object_A
(
Id,
Revision,
CreateDate,
ModificationDate,
State
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@State
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@CreateDate", NpgsqlDbType.Timestamp) { TypedValue = result.CreateDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<short>(@"@State", NpgsqlDbType.Smallint) { TypedValue = result.State };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

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
        public virtual IEnumerable<Object_ADtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A";

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
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexState;
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexState);
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
                        Object_ADtoActual result;
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
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);
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
        public virtual IEnumerable<Object_ADtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A";

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
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexState;
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexState);
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
                        Object_ADtoActual result;
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
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);
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
        public virtual IEnumerable<Object_ADtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null)
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
Revision,
CreateDate,
ModificationDate,
State
FROM Object_A";
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
                    int indexRevision;
                    int indexCreateDate;
                    int indexModificationDate;
                    int indexState;
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexState);
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
                        Object_ADtoActual result;
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
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexState);

                            SeedRevision(result.Revision);
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
                    command.CommandText = @"SELECT Id FROM Object_A";
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
                        command.Prepare();

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
                    command.CommandText = @"SELECT COUNT(*) FROM Object_A";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    command.Prepare();

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
