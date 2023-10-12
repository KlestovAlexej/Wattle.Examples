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
using ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.Interface;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Implements.Generated.PostgreSql.Implements
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

                schemaObjectQuey.Description = @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера";
                schemaObjectQuey.Id = new Guid("266032e5-19c6-434c-a521-d1d1c652edd1");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле Value_DateTime

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время (DateTime). Обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("dce071bb-796e-4397-91b8-eaf116747880");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_DateTime";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_DateTime

                #region Поле Value_DateTime_NotUpdate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время (DateTime). Не обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("273a65e2-7647-42db-a15d-58b69a64c69d");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_DateTime_NotUpdate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_DateTime_NotUpdate

                #region Поле Value_Long

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Число (long). Поле обновляется только при изменении значения.";
                    schemaObjectFieldQuey.Id = new Guid("87a005ed-ca51-4c60-83ec-6540ac0823d6");
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

                    schemaObjectFieldQuey.Description = @"Число с поддержкой null (int?). Обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("198251ef-8183-4a09-a760-e5baafbbb6ff");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Value_Int";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_Int

                #region Поле Value_String

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.";
                    schemaObjectFieldQuey.Id = new Guid("100e6573-b387-4cb5-b3d6-45df4cb2cc9c");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"Value_String";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_String

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект Object_A

            #region Объект Object_B

            {
                var schemaObjectQuey = new PostgreSqlSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)";
                schemaObjectQuey.Id = new Guid("cb9a1909-a7b6-48a6-8fe5-7d714e0225ea");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("92847c2c-e7b4-4ee1-a628-042b75aa9225");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"CreateDate";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new PostgreSqlSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"Id";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект Object_B

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

            AddMapper(new MapperObject_A(exceptionPolicy, m_selectFilterFactory));

            AddMapper(new MapperObject_B(exceptionPolicy, m_selectFilterFactory));

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
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    internal class BulkInsertDataReaderObject_A : BasePostgreSqlBulkInserter<Object_ADtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, Object_ADtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Value_DateTime, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.Value_DateTime_NotUpdate, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
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
            await binaryImport.WriteAsync(instance.Value_String, NpgsqlDbType.Text, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, Object_ADtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.Value_DateTime, NpgsqlDbType.Timestamp);
            binaryImport.Write(instance.Value_DateTime_NotUpdate, NpgsqlDbType.Timestamp);
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
            binaryImport.Write(instance.Value_String, NpgsqlDbType.Text);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY Object_A (Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.Object_A)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperObject_A : BasePostgreSqlMapper<Object_ADtoActual>, IPartitionsMapper, IMapperInitializer, IMapperObject_A, IMapperActualDtoCache
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperObject_A(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера" + "' в БД", WellknownMappers.Object_A, selectFilterFactory, exceptionPolicy)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
            Partitions = new PartitionsManager(exceptionPolicy, @"Object_A", ComplexIdentity.Level.L1, false);
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperObject_A(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper infrastructureMonitor = null, IMemoryCache<Object_ADtoActual, long> actualDtoMemoryCache = null)
           : base("Маппер данных состояния доменного объекта '" + @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера" + "' в БД", WellknownMappers.Object_A, selectFilterFactory, exceptionPolicy, infrastructureMonitor, actualDtoMemoryCache)
        {
            Options = Options | MapperOptions.OptimisticConcurrency;
            
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
                using (var command = typedSession.CreateCommand(true))
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
                    command.CommandText = @"SELECT NEXTVAL('Sequence_Object_A') AS Id FROM GENERATE_SERIES(1, @count);";
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
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) LIMIT 1";

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) LIMIT 1";

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

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
                    command.CommandText = @"SELECT 1 FROM Object_A WHERE (Id = @Id) AND (Revision = @Revision) LIMIT 1";

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
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_DateTime_NotUpdate">Индекс колонки 'Value_DateTime_NotUpdate'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        /// <param name="indexValue_String">Индекс колонки 'Value_String'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexValue_DateTime,
            out int indexValue_DateTime_NotUpdate,
            out int indexValue_Long,
            out int indexValue_Int,
            out int indexValue_String)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
            indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
            indexValue_Long = reader.GetOrdinal("Value_Long");
            indexValue_Int = reader.GetOrdinal("Value_Int");
            indexValue_String = reader.GetOrdinal("Value_String");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_DateTime_NotUpdate">Индекс колонки 'Value_DateTime_NotUpdate'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        /// <param name="indexValue_String">Индекс колонки 'Value_String'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexValue_DateTime,
            out int indexValue_DateTime_NotUpdate,
            out int indexValue_Long,
            out int indexValue_Int,
            out int indexValue_String)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
            indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
            indexValue_Long = reader.GetOrdinal("Value_Long");
            indexValue_Int = reader.GetOrdinal("Value_Int");
            indexValue_String = reader.GetOrdinal("Value_String");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_DateTime_NotUpdate">Индекс колонки 'Value_DateTime_NotUpdate'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        /// <param name="indexValue_String">Индекс колонки 'Value_String'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object_ADtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexValue_DateTime,
            int indexValue_DateTime_NotUpdate,
            int indexValue_Long,
            int indexValue_Int,
            int indexValue_String)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
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
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (reader.IsDBNull(indexValue_String))
            {
                result.Value_String = default;
            }
            else
            {
                result.Value_String = reader.GetString(indexValue_String);
            }

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexValue_DateTime">Индекс колонки 'Value_DateTime'.</param>
        /// <param name="indexValue_DateTime_NotUpdate">Индекс колонки 'Value_DateTime_NotUpdate'.</param>
        /// <param name="indexValue_Long">Индекс колонки 'Value_Long'.</param>
        /// <param name="indexValue_Int">Индекс колонки 'Value_Int'.</param>
        /// <param name="indexValue_String">Индекс колонки 'Value_String'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object_ADtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexValue_DateTime,
            int indexValue_DateTime_NotUpdate,
            int indexValue_Long,
            int indexValue_Int,
            int indexValue_String)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Revision = reader.GetInt64(indexRevision);
            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
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
            // ReSharper disable once ConvertIfStatementToConditionalTernaryExpression
            if (reader.IsDBNull(indexValue_String))
            {
                result.Value_String = default;
            }
            else
            {
                result.Value_String = reader.GetString(indexValue_String);
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
        public virtual Object_ADtoActual Get(IMappersSession mappersSession, long id)
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
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                                out var indexValue_DateTime,
                                out var indexValue_DateTime_NotUpdate,
                                out var indexValue_Long,
                                out var indexValue_Int,
                                out var indexValue_String);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                                out var indexValue_DateTime,
                                out var indexValue_DateTime_NotUpdate,
                                out var indexValue_Long,
                                out var indexValue_Int,
                                out var indexValue_String);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
                using (var command = typedSession.CreateCommand(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                                out var indexValue_DateTime,
                                out var indexValue_DateTime_NotUpdate,
                                out var indexValue_Long,
                                out var indexValue_Int,
                                out var indexValue_String);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                                out var indexValue_DateTime,
                                out var indexValue_DateTime_NotUpdate,
                                out var indexValue_Long,
                                out var indexValue_Int,
                                out var indexValue_String);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexRevision,
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
                    Value_DateTime = data.Value_DateTime,
                    Value_DateTime_NotUpdate = data.Value_DateTime_NotUpdate,
                    Value_Long = data.Value_Long.Value,
                    Value_Int = data.Value_Int,
                    Value_String = data.Value_String.Value,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE Object_A SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", Value_DateTime = @Value_DateTime");
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_Long.IsChanged)
                    {
                        commandText.AppendLine(@", Value_Long = @Value_Long");
                        var parameter = new NpgsqlParameter<long>("@Value_Long", NpgsqlDbType.Bigint) { TypedValue = result.Value_Long };
                        command.Parameters.Add(parameter);
                    }
                    commandText.AppendLine(@", Value_Int = @Value_Int");
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = result.Value_Int;
                    }
                    if (data.Value_String.IsChanged)
                    {
                        commandText.AppendLine(@", Value_String = @Value_String");
                        if (result.Value_String == null)
                        {
                            command.Parameters.Add("@Value_String", NpgsqlDbType.Text).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value_String", NpgsqlDbType.Text).Value = result.Value_String;
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
        public virtual async ValueTask<IMapperDto> UpdateAsync(IMappersSession session, Object_ADtoChanged data, CancellationToken cancellationToken = default)
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
                    Value_DateTime = data.Value_DateTime,
                    Value_DateTime_NotUpdate = data.Value_DateTime_NotUpdate,
                    Value_Long = data.Value_Long.Value,
                    Value_Int = data.Value_Int,
                    Value_String = data.Value_String.Value,
                };

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE Object_A SET ");
                    commandText.AppendLine(@"Revision = @New_Revision");
                    
                    commandText.AppendLine(@", Value_DateTime = @Value_DateTime");
                    {
                        var parameter = new NpgsqlParameter<DateTime>("@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    if (data.Value_Long.IsChanged)
                    {
                        commandText.AppendLine(@", Value_Long = @Value_Long");
                        var parameter = new NpgsqlParameter<long>("@Value_Long", NpgsqlDbType.Bigint) { TypedValue = result.Value_Long };
                        command.Parameters.Add(parameter);
                    }
                    commandText.AppendLine(@", Value_Int = @Value_Int");
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_Int", NpgsqlDbType.Integer).Value = result.Value_Int;
                    }
                    if (data.Value_String.IsChanged)
                    {
                        commandText.AppendLine(@", Value_String = @Value_String");
                        if (result.Value_String == null)
                        {
                            command.Parameters.Add("@Value_String", NpgsqlDbType.Text).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value_String", NpgsqlDbType.Text).Value = result.Value_String;
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
                    Value_DateTime = data.Value_DateTime,
                    Value_DateTime_NotUpdate = data.Value_DateTime_NotUpdate,
                    Value_Long = data.Value_Long,
                    Value_Int = data.Value_Int,
                    Value_String = data.Value_String,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Object_A
(
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
)
VALUES
(
@Id,
@New_Revision,
@Value_DateTime,
@Value_DateTime_NotUpdate,
@Value_Long,
@Value_Int,
@Value_String
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@Value_DateTime_NotUpdate", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime_NotUpdate };
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
                    if (result.Value_String == null)
                    {
                        command.Parameters.Add("@Value_String", NpgsqlDbType.Text).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add(@"@Value_String", NpgsqlDbType.Text).Value = result.Value_String;
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
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, Object_ADtoNew data, CancellationToken cancellationToken = default)
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
                    Value_DateTime = data.Value_DateTime,
                    Value_DateTime_NotUpdate = data.Value_DateTime_NotUpdate,
                    Value_Long = data.Value_Long,
                    Value_Int = data.Value_Int,
                    Value_String = data.Value_String,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Object_A
(
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
)
VALUES
(
@Id,
@New_Revision,
@Value_DateTime,
@Value_DateTime_NotUpdate,
@Value_Long,
@Value_Int,
@Value_String
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@Value_DateTime", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@Value_DateTime_NotUpdate", NpgsqlDbType.Timestamp) { TypedValue = result.Value_DateTime_NotUpdate };
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
                    if (result.Value_String == null)
                    {
                        command.Parameters.Add("@Value_String", NpgsqlDbType.Text).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add(@"@Value_String", NpgsqlDbType.Text).Value = result.Value_String;
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
        partial void CatchExceptionOnDelete(IMappersSession session, Exception exception, Object_ADtoDeleted data);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        public virtual void Delete(IMappersSession session, Object_ADtoDeleted data)
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
                    command.CommandText = @"DELETE FROM Object_A WHERE (Id = @Id) AND (Revision = @Revision)";
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
        public virtual async ValueTask DeleteAsync(IMappersSession session, Object_ADtoDeleted data, CancellationToken cancellationToken = default)
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
                    command.CommandText = @"DELETE FROM Object_A WHERE (Id = @Id) AND (Revision = @Revision)";
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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                    int indexValue_DateTime;
                    int indexValue_DateTime_NotUpdate;
                    int indexValue_Long;
                    int indexValue_Int;
                    int indexValue_String;
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexValue_DateTime,
                            out indexValue_DateTime_NotUpdate,
                            out indexValue_Long,
                            out indexValue_Int,
                            out indexValue_String);
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
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
        public virtual async IAsyncEnumerable<Object_ADtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
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
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                    int indexValue_DateTime;
                    int indexValue_DateTime_NotUpdate;
                    int indexValue_Long;
                    int indexValue_Int;
                    int indexValue_String;
                    try
                    {
                        command.Prepare();

                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexValue_DateTime,
                            out indexValue_DateTime_NotUpdate,
                            out indexValue_Long,
                            out indexValue_Int,
                            out indexValue_String);
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
                        Object_ADtoActual result;
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
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                    int indexValue_DateTime;
                    int indexValue_DateTime_NotUpdate;
                    int indexValue_Long;
                    int indexValue_Int;
                    int indexValue_String;
                    try
                    {
                        command.Prepare();

                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexValue_DateTime,
                            out indexValue_DateTime_NotUpdate,
                            out indexValue_Long,
                            out indexValue_Int,
                            out indexValue_String);
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
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
                    command = typedSession.CreateCommand(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
Id,
Revision,
Value_DateTime,
Value_DateTime_NotUpdate,
Value_Long,
Value_Int,
Value_String
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
                    int indexValue_DateTime;
                    int indexValue_DateTime_NotUpdate;
                    int indexValue_Long;
                    int indexValue_Int;
                    int indexValue_String;
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
                            out indexValue_DateTime,
                            out indexValue_DateTime_NotUpdate,
                            out indexValue_Long,
                            out indexValue_Int,
                            out indexValue_String);
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
                                indexValue_DateTime,
                                indexValue_DateTime_NotUpdate,
                                indexValue_Long,
                                indexValue_Int,
                                indexValue_String);

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
                using (var command = typedSession.CreateCommand(false))
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
                    command.CommandText = @"SELECT COUNT(*) FROM Object_A";

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
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    internal class BulkInsertDataReaderObject_B : BasePostgreSqlBulkInserter<Object_BDtoNew>
    {
        protected override async ValueTask DoInsertObjectAsync(NpgsqlBinaryImporter binaryImport, Object_BDtoNew instance, CancellationToken cancellationToken = default)
        {
            await binaryImport.WriteAsync(instance.Id, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(true, NpgsqlDbType.Boolean, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(Constants.StartRevision, NpgsqlDbType.Bigint, cancellationToken).ConfigureAwait(false);
            await binaryImport.WriteAsync(instance.CreateDate, NpgsqlDbType.Timestamp, cancellationToken).ConfigureAwait(false);
        }

        protected override void DoInsertObject(NpgsqlBinaryImporter binaryImport, Object_BDtoNew instance)
        {
            binaryImport.Write(instance.Id, NpgsqlDbType.Bigint);
            binaryImport.Write(true, NpgsqlDbType.Boolean);
            binaryImport.Write(Constants.StartRevision, NpgsqlDbType.Bigint);
            binaryImport.Write(instance.CreateDate, NpgsqlDbType.Timestamp);
        }

        protected override string GetImportCommand()
        {
            var result = @"COPY Object_B (Id,
Available,
Revision,
CreateDate) FROM STDIN (FORMAT BINARY)
";

            return (result);
        }
    }

    /// <summary>
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    [MapperImplementation(WellknownMappersAsText.Object_B)]
    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    [SuppressMessage("ReSharper", "UnusedMember.Global")]
    [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
    public partial class MapperObject_B : BasePostgreSqlMapper<Object_BDtoActual>, IMapperInitializer, IMapperObject_B
    {
        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperObject_B(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory)
           : base("Маппер данных состояния доменного объекта '" + @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)" + "' в БД", WellknownMappers.Object_B, selectFilterFactory, exceptionPolicy)
        {
        }

        [SuppressMessage("ReSharper", "RedundantArgumentDefaultValue")]
        public MapperObject_B(IMappersExceptionPolicy exceptionPolicy, IPostgreSqlMapperSelectFilterFactory selectFilterFactory, IInfrastructureMonitorMapper infrastructureMonitor = null)
           : base("Маппер данных состояния доменного объекта '" + @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)" + "' в БД", WellknownMappers.Object_B, selectFilterFactory, exceptionPolicy, infrastructureMonitor)
        {
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"Object_B";

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
        /// Обработка исключения мапппера в методе <see cref="GetMaxId"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        partial void CatchExceptionOnGetMaxId(IMappersSession session, Exception exception);

        /// <summary>
        /// Получение максимального значение существующего идентити.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает максимальное значение идентити или <see langword="null" /> если нет ни одной записи.</returns>
        public virtual long? GetMaxId(IMappersSession session)
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
                    command.CommandText = @"SELECT MAX(Id) AS Id FROM Object_B";

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");

                        if (reader.Read() && (reader.IsDBNull(indexId) == false))
                        {
                            var result = reader.GetInt64(indexId);

                            return (result);
                        }
                    }
                }

                return (null);
            }
            catch (Exception exception)
            {
                CatchExceptionOnGetMaxId(session, exception);
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
        /// Обработка исключения мапппера в методе <see cref="Exists"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnExists(IMappersSession session, Exception exception, long id);

        /// <summary>
        /// Проверка существования записис с указаным идентити.
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует или скрыта.</returns>
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
                    command.CommandText = @"SELECT 1 FROM Object_B WHERE (Id = @Id) AND (Available = @Available) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

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
        /// ВАЖНО : Проверка не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если запись существует иначе возвращает <see langword="false" /> если запись не существует или скрыта.</returns>
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
                    command.CommandText = @"SELECT 1 FROM Object_B WHERE (Id = @Id) AND (Available = @Available) LIMIT 1";

                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

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
                using (var command = typedSession.CreateCommand(false)) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Object_B WHERE (Id = @Id) LIMIT 1";

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

                var command = await typedSession.CreateCommandAsync(false, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT 1 FROM Object_B WHERE (Id = @Id) LIMIT 1";

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
        /// <param name="indexAvailable">Индекс колонки 'Available'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexesRaw(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexAvailable,
            out int indexRevision,
            out int indexCreateDate)
        {
            indexId = reader.GetOrdinal("Id");
            indexAvailable = reader.GetOrdinal("Available");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
        }

        /// <summary>
        /// Получить индексы колонок таблицы.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void GetColumnIndexes(
            NpgsqlDataReader reader,
            out int indexId,
            out int indexRevision,
            out int indexCreateDate)
        {
            indexId = reader.GetOrdinal("Id");
            indexRevision = reader.GetOrdinal("Revision");
            indexCreateDate = reader.GetOrdinal("CreateDate");
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexAvailable">Индекс колонки 'Available'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object_BDtoActual ReadRaw(
            NpgsqlDataReader reader,
            int indexId,
            int indexAvailable,
            int indexRevision,
            int indexCreateDate)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Available = reader.GetBoolean(indexAvailable);
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);

            return result;
        }

        /// <summary>
        /// Прочитать запись.
        /// </summary>
        /// <param name="reader">Читатель данных БД.</param>
        /// <param name="indexId">Индекс колонки 'Id'.</param>
        /// <param name="indexRevision">Индекс колонки 'Revision'.</param>
        /// <param name="indexCreateDate">Индекс колонки 'CreateDate'.</param>
        /// <returns>Созданная и прочитанная запись.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Object_BDtoActual Read(
            NpgsqlDataReader reader,
            int indexId,
            int indexRevision,
            int indexCreateDate)
        {
#pragma warning disable IDE0017 // Simplify object initialization
            // ReSharper disable once UseObjectOrCollectionInitializer
            var result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization

            result.Id = reader.GetInt64(indexId);
            result.Available = true;
            result.Revision = reader.GetInt64(indexRevision);
            result.CreateDate = reader.GetDateTime(indexCreateDate);

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
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual Object_BDtoActual Get(IMappersSession mappersSession, long id)
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
Id,
Revision,
CreateDate
FROM Object_B WHERE
(Id = @Id)
AND (Available = @Old_Available)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            GetColumnIndexes(
                                reader,
                                out var indexId,
                                out var indexRevision,
                                out var indexCreateDate);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate);

                            SeedRevision(result.Revision);

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
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="mappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
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
Id,
Revision,
CreateDate
FROM Object_B WHERE
(Id = @Id)
AND (Available = @Old_Available)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = id };
                        command.Parameters.Add(parameter);
                    }

                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
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
                                out var indexRevision,
                                out var indexCreateDate);

                            var result = Read(
                                reader,
                                indexId,
                                indexRevision,
                                indexCreateDate);

                            SeedRevision(result.Revision);

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
        public virtual Object_BDtoActual GetRaw(IMappersSession session, long id)
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
Available,
Revision,
CreateDate
FROM Object_B WHERE (Id = @Id)";

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
                                out var indexAvailable,
                                out var indexRevision,
                                out var indexCreateDate);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexAvailable,
                                indexRevision,
                                indexCreateDate);

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
        public virtual async ValueTask<Object_BDtoActual> GetRawAsync(IMappersSession session, long id, CancellationToken cancellationToken = default)
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
Available,
Revision,
CreateDate
FROM Object_B WHERE (Id = @Id)";

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
                                out var indexAvailable,
                                out var indexRevision,
                                out var indexCreateDate);

                            var result = ReadRaw(
                                reader,
                                indexId,
                                indexAvailable,
                                indexRevision,
                                indexCreateDate);

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
        partial void CatchExceptionOnUpdate(IMappersSession session, Exception exception, Object_BDtoChanged data);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual Object_BDtoActual Update(IMappersSession session, Object_BDtoChanged data)
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
                new Object_BDtoActual
                {
                    Id = data.Id,
                    Available = true,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Object_B SET
Revision = @New_Revision
WHERE
(Id = @Id) AND (Revision < @New_Revision)
AND (Available = @Old_Available)";
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

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
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual async ValueTask<IMapperDto> UpdateAsync(IMappersSession session, Object_BDtoChanged data, CancellationToken cancellationToken = default)
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
                new Object_BDtoActual
                {
                    Id = data.Id,
                    Available = true,
                    Revision = NewRevision(),
                    CreateDate = data.CreateDate,
                };

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Object_B SET
Revision = @New_Revision
WHERE
(Id = @Id) AND (Revision < @New_Revision)
AND (Available = @Old_Available)";
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = result.Revision };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

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
            IEnumerable<Object_BDtoNew> data)
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderObject_B();
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
            IEnumerable<Object_BDtoNew> data,
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

                var postgreSqlBulkInserter = new BulkInsertDataReaderObject_B();
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
        partial void CatchExceptionOnNew(IMappersSession session, Exception exception, Object_BDtoNew data);

        /// <summary>
        /// Создать запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Новая запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual Object_BDtoActual New(IMappersSession session, Object_BDtoNew data)
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
                new Object_BDtoActual
                {
                    Id = data.Id,
                    Available = true,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Object_B
(
Id,
Available,
Revision,
CreateDate
)
VALUES
(
@Id,
@New_Available,
@New_Revision,
@CreateDate
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@CreateDate", NpgsqlDbType.Timestamp) { TypedValue = result.CreateDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
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
        public virtual async ValueTask<IMapperDto> NewAsync(IMappersSession session, Object_BDtoNew data, CancellationToken cancellationToken = default)
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
                new Object_BDtoActual
                {
                    Id = data.Id,
                    Available = true,
                    Revision = Constants.StartRevision,
                    CreateDate = data.CreateDate,
                };

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO Object_B
(
Id,
Available,
Revision,
CreateDate
)
VALUES
(
@Id,
@New_Available,
@New_Revision,
@CreateDate
)";
                    {
                        var parameter = new NpgsqlParameter<DateTime>(@"@CreateDate", NpgsqlDbType.Timestamp) { TypedValue = result.CreateDate };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = Constants.StartRevision };
                        command.Parameters.Add(parameter);
                    }
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
        /// Обработка исключения мапппера в методе <see cref="Hide"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="data">Данные достаточные для сокрытия записи.</param>
        partial void CatchExceptionOnHide(IMappersSession session, Exception exception, Object_BDtoDeleted data);

        /// <summary>
        /// Сокрытие записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для сокрытия записи.</param>
        public virtual void Hide(IMappersSession session, Object_BDtoDeleted data)
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

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand(true))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Object_B SET
Available = @New_Available,
Revision = @New_Revision
WHERE
(Id = @Id)
AND (Available = @Old_Available)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = false };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = NewRevision() };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при сокрытие записи с идентификатором '{data.Id}' маппером '{MapperId}'.");
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnHide(session, exception, data);
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
        /// Сокрытие записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для сокрытия записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        public virtual async ValueTask HideAsync(IMappersSession session, Object_BDtoDeleted data, CancellationToken cancellationToken = default)
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

                var command = await typedSession.CreateCommandAsync(true, cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE Object_B SET
Available = @New_Available,
Revision = @New_Revision
WHERE
(Id = @Id)
AND (Available = @Old_Available)";

                    {
                        var parameter = new NpgsqlParameter<long>("@Id", NpgsqlDbType.Bigint) { TypedValue = data.Id };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@New_Available", NpgsqlDbType.Boolean) { TypedValue = false };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<long>("@New_Revision", NpgsqlDbType.Bigint) { TypedValue = NewRevision() };
                        command.Parameters.Add(parameter);
                    }

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        throw new InvalidOperationException($"Конкуренция при сокрытие записи с идентификатором '{data.Id}' маппером '{MapperId}'.");
                    }
                }
            }
            catch (Exception exception)
            {
                CatchExceptionOnHide(session, exception, data);
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
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<Object_BDtoActual> GetEnumerator(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
CreateDate
FROM Object_B";
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
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
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate);
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
                        Object_BDtoActual result;
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
                                indexCreateDate);

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
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async IAsyncEnumerable<Object_BDtoActual> GetEnumeratorAsync(IMappersSession session, IMapperSelectFilter selectFilter = null, [EnumeratorCancellation] CancellationToken cancellationToken = default)
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
CreateDate
FROM Object_B";
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
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
                    try
                    {
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate);
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
                        Object_BDtoActual result;
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
                                indexCreateDate);

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
        public virtual IEnumerable<Object_BDtoActual> GetEnumeratorRaw(IMappersSession session, IMapperSelectFilter selectFilter = null)
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
Available,
Revision,
CreateDate
FROM Object_B";

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
                    int indexAvailable;
                    int indexCreateDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexesRaw(
                            reader,
                            out indexId,
                            out indexAvailable,
                            out indexRevision,
                            out indexCreateDate);
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
                        Object_BDtoActual result;
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
                                indexAvailable,
                                indexRevision,
                                indexCreateDate);

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
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных записей кроме скрытых записей.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual IEnumerable<Object_BDtoActual> GetEnumeratorPage(IMappersSession session, int pageIndex, int pageSize, IMapperSelectFilter selectFilter = null)
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
CreateDate
FROM Object_B";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
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
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);

                        GetColumnIndexes(
                            reader,
                            out indexId,
                            out indexRevision,
                            out indexCreateDate);
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
                        Object_BDtoActual result;
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
                                indexCreateDate);

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
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="pageIndex">Индекс выбираемой страницы. Первая страница имеет индекс 1.</param>
        /// <param name="pageSize">Размер страницы. Минимальный размер страницы 1. Максимальный размер страницы 1000.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает итератор всех выбраных идентити записей кроме скрытых записей.</returns>
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
                    command.CommandText = @"SELECT Id FROM Object_B";
                    {
                        var parameter = new NpgsqlParameter<long>("@__SkipCount", NpgsqlDbType.Bigint) { TypedValue = (pageIndex - 1L) * pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<int>("@__PageSize", NpgsqlDbType.Integer) { TypedValue = pageSize };
                        command.Parameters.Add(parameter);
                    }
                    {
                        var parameter = new NpgsqlParameter<bool>("@Old_Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

                    ExpandCommand(
                        command,
                        @"(Available = @Old_Available)",
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
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
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
                    command.CommandText = @"SELECT COUNT(*) FROM Object_B";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), @"(Available = @Available)");
                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

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
        /// ВАЖНО : Выбор не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="selectFilter">Фильтр выбора записий. Если указан <see langword="null" /> то выбираются все записи.</param>
        /// <param name="cancellationToken">Кокен отмены.</param>
        /// <returns>Возвращает количество записей удовлетворяющих фильтру выборки кроме скрытых записей.</returns>
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
                    command.CommandText = @"SELECT COUNT(*) FROM Object_B";

                    ExpandCommand(command, (selectFilter as IPostgreSqlMapperSelectFilter), @"(Available = @Available)");
                    {
                        var parameter = new NpgsqlParameter<bool>("@Available", NpgsqlDbType.Boolean) { TypedValue = true };
                        command.Parameters.Add(parameter);
                    }

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
