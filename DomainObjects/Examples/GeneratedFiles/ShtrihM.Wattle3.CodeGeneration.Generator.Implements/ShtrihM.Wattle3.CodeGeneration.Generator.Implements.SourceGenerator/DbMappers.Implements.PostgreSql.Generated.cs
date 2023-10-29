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
using ShtrihM.Wattle3.Json.Extensions;
using ShtrihM.Wattle3.Common.Exceptions;
using ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.Interface;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.DomainObjects.Examples.Generated.PostgreSql.Implements
{
    public static class PostgreSqlSchemaQueriesProvider
    {
        public static readonly PostgreSqlSchemaQueries Schema;

        static PostgreSqlSchemaQueriesProvider()
        {
            Schema = new PostgreSqlSchemaQueries();

            #region Объект Document

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Документ";
                schemaObjectQuey.Id = new Guid("d70d5118-2c04-4a66-a5a1-4573b7f91631");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время создания";
                    schemaObjectFieldQuey.Id = new Guid("7ef5bc59-73ae-485f-a1d5-7a7cec7b691c");
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

                    schemaObjectFieldQuey.Description = @"Дата-время модификации";
                    schemaObjectFieldQuey.Id = new Guid("f1a9d132-e6b2-4c4c-96e7-bdfcb1e0a330");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"ModificationDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле ModificationDate

                #region Поле Value_DateTime

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Доле документа - дата-время";
                    schemaObjectFieldQuey.Id = new Guid("31becbf5-304f-4e0b-9540-25efd7191f19");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_DateTime";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_DateTime

                #region Поле Value_Long

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Доле документа - число";
                    schemaObjectFieldQuey.Id = new Guid("15713b81-57c2-4a29-a978-2f2ea00d4554");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Long";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_Long

                #region Поле Value_Int

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Доле документа - число с поддержкой null";
                    schemaObjectFieldQuey.Id = new Guid("c238f1b0-c802-41f3-a6f0-ae2b52a1598f");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Int";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_Int

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Документ";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект Document

            #region Объект ChangeTracker

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Отслеживание изменений";
                schemaObjectQuey.Id = new Guid("67bf3734-17bb-4e9a-b0f1-b8f85382e690");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Отслеживание изменений";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект ChangeTracker

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
        public Mappers(IMappersExceptionPolicy exceptionPolicy, string connectionString, ITimeService timeService, Guid id, string name, string description, int commandTimeout = CommandTimeoutInfinity, object context = null)
            : base(exceptionPolicy, connectionString, timeService, id, name, description, commandTimeout)
        {
            m_getMapperDisplayName = null;

            OnEnterConstructor(context);

            if (m_selectFilterFactory == null)
            {
                var selectFilterContext = new PostgreSqlMapperSelectFilterContext(PostgreSqlSchemaQueriesProvider.Schema);
                m_selectFilterFactory = new PostgreSqlMapperSelectFilterFactory(selectFilterContext);
            }

            AddMapper(new MapperDocument(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperChangeTracker(exceptionPolicy, m_selectFilterFactory));

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
    /// Документ
    /// </summary>
    internal class BulkInsertDataReaderDocument : BasePostgreSqlBulkInserter<DocumentDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, DocumentDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.ModificationDate, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Value_DateTime, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Value_Long, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            {
                var value = instance.Value_Int;
                if (value.HasValue == false)
                {
                    await binaryImport.WriteNullAsync(cancellationToken).ConfigureAwait(false);
                }
                else
                {
                    await binaryImport.WriteAsync(value.Value, NpgsqlDbType.Integer, cancellationToken).ConfigureAwait(false);
                }
            }
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, DocumentDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate, NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.ModificationDate, NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.Value_DateTime, NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.Value_Long, NpgsqlDbType.Bigint);
            {
                var value = instance.Value_Int;
                if (value.HasValue == false)
                {
                    binaryImport.WriteNull();
                }
                else
                {
                    binaryImport.Write(value.Value, NpgsqlDbType.Integer);
                }
            }
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY Document (Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Документ
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.Document)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperDocument : BasePostgreSqlMapper<DocumentDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperDocument, IMapperActualDtoCache
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDocument(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Документ" + "' в БД", WellknownMappers.Document, selectFilterFactory, exceptionPolicy)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Options = Options | MapperOptions.Delete;
            
            Partitions = new PartitionsManager(exceptionPolicy, @"Document", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperDocument(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper infrastructureMonitor = null, IMemoryCache<DocumentDtoActual, long> actualDtoMemoryCache = null)
           : base("Маппер данных состояния доменного объекта '" + @"Документ" + "' в БД", WellknownMappers.Document, selectFilterFactory, exceptionPolicy, infrastructureMonitor, actualDtoMemoryCache)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Options = Options | MapperOptions.Delete;
            
            Partitions = new PartitionsManager(exceptionPolicy, @"Document", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"Document";

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
        /// Получение следующего значения идентити из последовательности "Sequence_Document".
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
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Document');";

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
        /// Получение следующих значений идентити из последовательности "Sequence_Document".
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
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Document') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    command.Prepare();

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
        /// Получение следующего значения идентити из последовательности "Sequence_Document".
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
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Document');";

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
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
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
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Document WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

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
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Document WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

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
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Document WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

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

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Document WHERE (Id = @Id) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (false == result)
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
                        }

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
        /// Обработка исключения мапппера в методе <see cref="ExistsRevision"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExistsRevision(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual bool ExistsRevision(IMappersSession session, long id, long revision)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Document WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = revision };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult)) 
                    {
                        var result = reader.Read();

                        if (result)
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto.Revision != revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }
                        else
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto.Revision == revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRevision(session, exception, id);
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
        /// Проверка существования записис с указаным идентити и указаной версией данных.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="revision">Ожидаемая версия данных записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе если запись не существует возвращает <see langword="false" />.</returns>
        public virtual async ValueTask<bool> ExistsRevisionAsync(IMappersSession session, long id, long revision, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Document WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = revision };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        var result = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);

                        if (result)
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto.Revision != revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }
                        else
                        {
                            if (TryGetFromCache(id, out var dto))
                            {
                                if (dto.Revision == revision)
                                {
                                    Remove(id);
                                    RemoveActualState(typedSession, id);
                                }
                            }
                        }

                        return (result);
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnExistsRevision(session, exception, id);
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
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexValue_DateTime,
            out int indexValue_Long,
            out int indexValue_Int)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
            indexValue_Long = reader.GetOrdinal("Value_Long");
            indexValue_Int = reader.GetOrdinal("Value_Int");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate,
            out int indexModificationDate,
            out int indexValue_DateTime,
            out int indexValue_Long,
            out int indexValue_Int)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
            indexModificationDate = reader.GetOrdinal("ModificationDate");
            indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
            indexValue_Long = reader.GetOrdinal("Value_Long");
            indexValue_Int = reader.GetOrdinal("Value_Int");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <param name="indexModificationDate">Индекс колонки 'ModificationDate'.</param>
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DocumentDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexValue_DateTime,
            int indexValue_Long,
            int indexValue_Int)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DocumentDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);
            result.ModificationDate = reader.GetDateTime(indexModificationDate);
            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
            result.Value_Long = reader.GetInt64(indexValue_Long);
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (reader.IsDBNull(indexValue_Int))
            {
                result.Value_Int = default;
            }
            else
            {
                result.Value_Int = reader.GetInt32(indexValue_Int);
            }

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
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static DocumentDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate,
            int indexModificationDate,
            int indexValue_DateTime,
            int indexValue_Long,
            int indexValue_Int)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new DocumentDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);
            result.ModificationDate = reader.GetDateTime(indexModificationDate);
            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
            result.Value_Long = reader.GetInt64(indexValue_Long);
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (reader.IsDBNull(indexValue_Int))
            {
                result.Value_Int = default;
            }
            else
            {
                result.Value_Int = reader.GetInt32(indexValue_Int);
            }

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession mappersSession, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DocumentDtoActual Get(IMappersSession mappersSession, long id)
        {
            if (mappersSession == null)
            {
                throw new ArgumentNullException(nameof(mappersSession));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var typedSession = (IPostgreSqlMappersSession)mappersSession;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document WHERE
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
                                out var indexValue_DateTime,
                                out var indexValue_Long,
                                out var indexValue_Int);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(mappersSession, exception, id);
                CatchException(mappersSession, exception);

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
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default)
        {
            if (mappersSession == null)
            {
                throw new ArgumentNullException(nameof(mappersSession));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var typedSession = (IPostgreSqlMappersSession)mappersSession;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document WHERE
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
                                out var indexValue_DateTime,
                                out var indexValue_Long,
                                out var indexValue_Int);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

                            SeedRevision(result.Revision);

                            AddActualState(typedSession, result);

                            return ((IMapperDto)result);
                        }
                    }

                    return ((IMapperDto)null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(mappersSession, exception, id);
                CatchException(mappersSession, exception);

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
        public virtual DocumentDtoActual GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document WHERE (Id = @Id)";

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
                                out var indexValue_DateTime,
                                out var indexValue_Long,
                                out var indexValue_Int);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

                            SeedRevision(result.Revision);
                            AddActualState(typedSession, result);

                            return (result);
                        }
                        else
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
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
        public virtual async ValueTask<DocumentDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document WHERE (Id = @Id)";

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
                                out var indexValue_DateTime,
                                out var indexValue_Long,
                                out var indexValue_Int);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate,
                                indexModificationDate,
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

                            SeedRevision(result.Revision);
                            AddActualState(typedSession, result);

                            return (result);
                        }
                        else
                        {
                            Remove(id);
                            RemoveActualState(typedSession, id);
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
        partial void CatchExceptionOnUpdate(IMappersSession session, Exception exception, DocumentDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual DocumentDtoActual Update(IMappersSession session, DocumentDtoChanged data)
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
                new DocumentDtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Value_DateTime = data.Value_DateTime.Value,
                    Value_Long = data.Value_Long.Value,
                    Value_Int = data.Value_Int.Value,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE Document SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", ModificationDate = @ModificationDate");
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_DateTime.IsChanged)
                    {
                        commandText.AppendLine(@", Value_DateTime = @Value_DateTime");
                        var parameter = new NpgsqlParameter<DateTime>("@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_Long.IsChanged)
                    {
                        commandText.AppendLine(@", Value_Long = @Value_Long");
                        var parameter = new NpgsqlParameter<long>("@Value_Long", NpgsqlDbType.Bigint) { TypedValue = result.Value_Long };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_Int.IsChanged)
                    {
                        commandText.AppendLine(@", Value_Int = @Value_Int");
                        if (result.Value_Int == null)
                        {
                            command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = result.Value_Int;
                        }
                    }
                    commandText.Append(@" WHERE (Id = @Id) AND (Revision = @Old_Revision)");

                    command.CommandText = commandText.ToString();

                    {
                        var parameter = new NpgsqlParameter<long>("@Old_Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
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

                AddActualState(typedSession, result);

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
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
        public virtual async ValueTask<IMapperDto> UpdateAsync(IMappersSession session, DocumentDtoChanged data, CancellationToken cancellationToken = default)
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
                new DocumentDtoActual
                {
                    Id = data.Id,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Value_DateTime = data.Value_DateTime.Value,
                    Value_Long = data.Value_Long.Value,
                    Value_Int = data.Value_Int.Value,
                };

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE Document SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", ModificationDate = @ModificationDate");
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@ModificationDate", NpgsqlDbType.Timestamp) { TypedValue = result.ModificationDate };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_DateTime.IsChanged)
                    {
                        commandText.AppendLine(@", Value_DateTime = @Value_DateTime");
                        var parameter = new NpgsqlParameter<DateTime>("@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_Long.IsChanged)
                    {
                        commandText.AppendLine(@", Value_Long = @Value_Long");
                        var parameter = new NpgsqlParameter<long>("@Value_Long", NpgsqlDbType.Bigint) { TypedValue = result.Value_Long };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_Int.IsChanged)
                    {
                        commandText.AppendLine(@", Value_Int = @Value_Int");
                        if (result.Value_Int == null)
                        {
                            command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = result.Value_Int;
                        }
                    }
                    commandText.Append(@" WHERE (Id = @Id) AND (Revision = @Old_Revision)");

                    command.CommandText = commandText.ToString();

                    {
                        var parameter = new NpgsqlParameter<long>("@Old_Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
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

                AddActualState(typedSession, result);

                if (MappersFeatures.ValidateUpdateResults)
                {
                    var realDto = GetRaw(session, result.Id);
                    var realDtoText = realDto.ToJsonText(true);
                    var resultText = result.ToJsonText(true);
                    if (MappersFeatures.ValidateUpdateAction != null)
                    {
                        if (false == MappersFeatures.ValidateUpdateAction(realDto, result))
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                    else
                    {
                        if (realDtoText != resultText)
                        {
                            throw new InternalException($"Маппер '{GetType().FullName}' : Данные в БД{Environment.NewLine}'{realDtoText}'{Environment.NewLine}не совпадают с данными в памяти{Environment.NewLine}'{resultText}'.");
                        }
                    }
                }

                return ((IMapperDto)result);
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
            IEnumerable<DocumentDtoNew> data)
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderDocument();
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
            IEnumerable<DocumentDtoNew> data,
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderDocument();
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
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, DocumentDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual DocumentDtoActual New(IMappersSession session, DocumentDtoNew data)
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
                new DocumentDtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Value_DateTime = data.Value_DateTime,
                    Value_Long = data.Value_Long,
                    Value_Int = data.Value_Int,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Document
(
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@Value_DateTime,
@Value_Long,
@Value_Int
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
                        var parameter = new NpgsqlParameter<DateTime>(@"@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@Value_Long", NpgsqlDbType.Bigint) { TypedValue = result.Value_Long };
                        command.Parameters.Add(parameter);
                    }
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add(@"@Value_Int", NpgsqlDbType.Integer).Value = result.Value_Int;
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

                AddActualState(typedSession, result);

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
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, DocumentDtoNew data, CancellationToken cancellationToken = default)
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
                new DocumentDtoActual
                {
                    Id = data.Id,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                    ModificationDate = data.ModificationDate,
                    Value_DateTime = data.Value_DateTime,
                    Value_Long = data.Value_Long,
                    Value_Int = data.Value_Int,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Document
(
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
)
VALUES
(
@Id,
@New_Revision,
@CreateDate,
@ModificationDate,
@Value_DateTime,
@Value_Long,
@Value_Int
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
                        var parameter = new NpgsqlParameter<DateTime>(@"@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>(@"@Value_Long", NpgsqlDbType.Bigint) { TypedValue = result.Value_Long };
                        command.Parameters.Add(parameter);
                    }
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add(@"@Value_Int", NpgsqlDbType.Integer).Value = result.Value_Int;
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

                AddActualState(typedSession, result);

                return ((IMapperDto)result);
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
        /// Обработка исключения мапппера в методе <see cref="Delete"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        partial void CatchExceptionOnDelete(IMappersSession session, Exception exception, DocumentDtoDeleted data);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        public virtual void Delete(IMappersSession session, DocumentDtoDeleted data)
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

                RemoveActualState(typedSession, data.Id);

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM Document WHERE (Id = @Id) AND (Revision = @Revision)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    command.Prepare();

                    var deleteCount = command.ExecuteNonQuery();
                    if (deleteCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при удалении записи с идентификатором '{data.Id}' маппером '{MapperId}'.");
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnDelete(session, exception, data);
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
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask DeleteAsync(IMappersSession session, DocumentDtoDeleted data, CancellationToken cancellationToken = default)
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

                RemoveActualState(typedSession, data.Id);

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM Document WHERE (Id = @Id) AND (Revision = @Revision)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Revision", NpgsqlDbType.Bigint) { TypedValue = data.Revision };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var deleteCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (deleteCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при удалении записи с идентификатором '{data.Id}' маппером '{MapperId}'.");
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnDelete(session, exception, data);
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
        public virtual IEnumerable<DocumentDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document";

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
                    int indexValue_DateTime;
                    int indexValue_Long;
                    int indexValue_Int;
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
                            out indexValue_DateTime,
                            out indexValue_Long,
                            out indexValue_Int);
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
                        DocumentDtoActual result;
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
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

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
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<DocumentDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
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
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document";

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

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
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
                    int indexValue_DateTime;
                    int indexValue_Long;
                    int indexValue_Int;
                    try
                    {
                        command.Prepare();

                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexValue_DateTime,
                            out indexValue_Long,
                            out indexValue_Int);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        DocumentDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
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
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

                            SeedRevision(result.Revision);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
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
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
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
        public virtual IEnumerable<DocumentDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document";

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
                    int indexValue_DateTime;
                    int indexValue_Long;
                    int indexValue_Int;
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
                            out indexValue_DateTime,
                            out indexValue_Long,
                            out indexValue_Int);
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
                        DocumentDtoActual result;
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
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

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
        public virtual IEnumerable<DocumentDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null)
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
CreateDate,
ModificationDate,
Value_DateTime,
Value_Long,
Value_Int
FROM Document";
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
                    int indexValue_DateTime;
                    int indexValue_Long;
                    int indexValue_Int;
                    IPostgreSqlMappersSession typedSession;
                    try
                    {
                        command.Prepare();

                        typedSession = (IPostgreSqlMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate,
                            out indexModificationDate,
                            out indexValue_DateTime,
                            out indexValue_Long,
                            out indexValue_Int);
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
                        DocumentDtoActual result;
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
                                indexValue_DateTime,
                                indexValue_Long,
                                indexValue_Int);

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

                        AddActualState(typedSession, result);

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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM Document";
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
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM Document";

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
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM Document";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    // ReSharper disable once PossibleNullReferenceException
                    var result = (long)temp;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    /// 
    /// Отслеживание изменений
    /// </summary>
    internal class BulkInsertDataReaderChangeTracker : BasePostgreSqlBulkInserter<ChangeTrackerDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, ChangeTrackerDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, ChangeTrackerDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY ChangeTracker (Id) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Отслеживание изменений
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.ChangeTracker)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperChangeTracker : BasePostgreSqlMapper<ChangeTrackerDtoActual>, IPartitionsMapper, IMapperInitializer, IMapperChangeTracker
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperChangeTracker(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Отслеживание изменений" + "' в БД", WellknownMappers.ChangeTracker, selectFilterFactory, exceptionPolicy)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"ChangeTracker", ComplexIdentity.Level.L2, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperChangeTracker(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Отслеживание изменений" + "' в БД", WellknownMappers.ChangeTracker, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
            Partitions = new PartitionsManager(exceptionPolicy, @"ChangeTracker", ComplexIdentity.Level.L2, false);
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"ChangeTracker";

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
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
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
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_ChangeTracker');";

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
        /// Получение следующих значений идентити из последовательности "Sequence_ChangeTracker".
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
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_ChangeTracker') AS Id FROM GENERATE_SERIES(1, @count);";
                    command.Parameters.Add("@count", NpgsqlDbType.Integer).Value = count;

                    command.Prepare();

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
        /// Получение следующего значения идентити из последовательности "Sequence_ChangeTracker".
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
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXTVAL('Sequence_ChangeTracker');";

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
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
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
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

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
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует.</returns>
        public virtual async ValueTask<bool> ExistsAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

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
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

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

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM ChangeTracker WHERE (Id = @Id) LIMIT 1";

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId)
        {
            indexId = reader.GetOrdinal("Id");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId)
        {
            indexId = reader.GetOrdinal("Id");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ChangeTrackerDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new ChangeTrackerDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static ChangeTrackerDtoActual Read(
            NpgsqlDataReader reader,
            int indexId)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new ChangeTrackerDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);

            return result;
        }

        /// <summary>
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IMappersSession mappersSession, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual ChangeTrackerDtoActual Get(IMappersSession mappersSession, long id)
        {
            if (mappersSession == null)
            {
                throw new ArgumentNullException(nameof(mappersSession));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)mappersSession;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE
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
                                out var indexId);

                            var result = Read(
                                reader,
                                indexId);

                            return (result);
                        }
                    }

                    return (null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(mappersSession, exception, id);
                CatchException(mappersSession, exception);

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
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> GetAsync(IMappersSession mappersSession, long id, CancellationToken cancellationToken = default)
        {
            if (mappersSession == null)
            {
                throw new ArgumentNullException(nameof(mappersSession));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession)mappersSession;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE
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
                                out var indexId);

                            var result = Read(
                                reader,
                                indexId);

                            return ((IMapperDto)result);
                        }
                    }

                    return ((IMapperDto)null);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGet(mappersSession, exception, id);
                CatchException(mappersSession, exception);

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
        public virtual ChangeTrackerDtoActual GetRaw(IMappersSession session, long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE (Id = @Id)";

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
                                out var indexId);

                            var result = ReadRaw(
                                reader,
                                indexId);

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
        public virtual async ValueTask<ChangeTrackerDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker WHERE (Id = @Id)";

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
                                out var indexId);

                            var result = ReadRaw(
                                reader,
                                indexId);

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
            IEnumerable<ChangeTrackerDtoNew> data)
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderChangeTracker();
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
            IEnumerable<ChangeTrackerDtoNew> data,
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderChangeTracker();
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
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, ChangeTrackerDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual ChangeTrackerDtoActual New(IMappersSession session, ChangeTrackerDtoNew data)
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
                new ChangeTrackerDtoActual
                {
                    Id = data.Id,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO ChangeTracker
(
Id
)
VALUES
(
@Id
)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
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
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, ChangeTrackerDtoNew data, CancellationToken cancellationToken = default)
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
                new ChangeTrackerDtoActual
                {
                    Id = data.Id,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO ChangeTracker
(
Id
)
VALUES
(
@Id
)";
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                }

                return ((IMapperDto)result);
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
        public virtual IEnumerable<ChangeTrackerDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";

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
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId);
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
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId);
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
        /// Получить итератор всех записей выбранных с учётом фильтра.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<ChangeTrackerDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
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
                    command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";

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

                    var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
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

                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId);
                    }
                    catch (Exception exception)
                    {
                        CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                        CatchException(session, exception);

                        var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                        if (ReferenceEquals(targetException, exception))
                        {
                            ExceptionDispatchInfo.Capture(exception).Throw();
                        }

                        throw targetException;
                    }

                    while (true)
                    {
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = await reader.ReadAsync(cancellationToken).ConfigureAwait(false);
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId);
                        }
                        catch (Exception exception)
                        {
                            CatchExceptionOnGetEnumerator(session, exception, selectFilter);
                            CatchException(session, exception);

                            var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
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
                    await reader.SilentDisposeAsync().ConfigureAwait(false);
                }
            }
            finally
            {
                await command.SilentDisposeAsync().ConfigureAwait(false);
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
        public virtual IEnumerable<ChangeTrackerDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";

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
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId);
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
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = ReadRaw(
                                reader,
                                indexId);
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
        public virtual IEnumerable<ChangeTrackerDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null)
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id
FROM ChangeTracker";
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
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId);
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
                        ChangeTrackerDtoActual result;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }

                            result = Read(
                                reader,
                                indexId);
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT Id FROM ChangeTracker";
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
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM ChangeTracker";

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
        /// <summary>
        /// Получить количество записей удовлетворяющих фильтру выборки.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки.</returns>
        public virtual async ValueTask<long> GetCountAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (IPostgreSqlMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                await using (var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM ChangeTracker";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), null);

                    await command.PrepareAsync(cancellationToken).ConfigureAwait(false);

                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
                    // ReSharper disable once PossibleNullReferenceException
                    var result = (long)temp;

                    return (result);
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetCount(session, exception, selectFilter);
                CatchException(session, exception);

                var targetException = await m_exceptionPolicy.ApplyAsync(exception, cancellationToken).ConfigureAwait(false);
                if (ReferenceEquals(targetException, exception))
                {
                    ExceptionDispatchInfo.Capture(exception).Throw();
                }

                throw targetException;
            }
        }
    }

}
