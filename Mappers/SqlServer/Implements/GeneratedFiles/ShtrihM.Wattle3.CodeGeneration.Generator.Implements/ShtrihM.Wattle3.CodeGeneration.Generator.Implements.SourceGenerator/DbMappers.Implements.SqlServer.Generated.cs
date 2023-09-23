/*
* Файл создан автоматически. Не редактировать вручную.
*
* Реализации мапперов.
*
* Генератор - ShtrihM.Wattle3.CodeGeneration.Generators.Mappers.SqlServerMappersImplementsCodeGenerator
*/
// ReSharper disable RedundantUsingDirective
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.ExceptionServices;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using Microsoft.Data.SqlClient;
using ShtrihM.Wattle3.DomainObjects.Interfaces;
using ShtrihM.Wattle3.Mappers;
using ShtrihM.Wattle3.Mappers.SqlServer;
using ShtrihM.Wattle3.Mappers.SqlServer.Schema;
using ShtrihM.Wattle3.Utils;
using ShtrihM.Wattle3.Infrastructures.Interfaces.Monitors;
using ShtrihM.Wattle3.Mappers.Interfaces;
using ShtrihM.Wattle3.Caching.Interfaces;
using ShtrihM.Wattle3.Primitives;
using ShtrihM.Wattle3.Mappers.Primitives;
using Constants = ShtrihM.Wattle3.Mappers.Constants;
using ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.Interface;

#pragma warning disable 1591

// ReSharper disable once CheckNamespace
namespace ShtrihM.Wattle3.Examples.Mappers.SqlServer.Implements.Generated.SqlServer.Implements
{
    public static class SqlServerSchemaQueriesProvider
    {
        public static readonly SqlServerSchemaQueries Schema;

        static SqlServerSchemaQueriesProvider()
        {
            Schema = new SqlServerSchemaQueries();

            #region Объект Object_A

            {
                var schemaObjectQuey = new SqlServerSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера";
                schemaObjectQuey.Id = new Guid("266032e5-19c6-434c-a521-d1d1c652edd1");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле Value_DateTime

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время (DateTime). Обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("dce071bb-796e-4397-91b8-eaf116747880");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[Value_DateTime]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_DateTime

                #region Поле Value_DateTime_NotUpdate

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата-время (DateTime). Не обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("273a65e2-7647-42db-a15d-58b69a64c69d");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[Value_DateTime_NotUpdate]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_DateTime_NotUpdate

                #region Поле Value_Long

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Число (long). Поле обновляется только при изменении значения.";
                    schemaObjectFieldQuey.Id = new Guid("87a005ed-ca51-4c60-83ec-6540ac0823d6");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[Value_Long]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_Long

                #region Поле Value_Int

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Число с поддержкой null (int?). Обновляемое поле.";
                    schemaObjectFieldQuey.Id = new Guid("198251ef-8183-4a09-a760-e5baafbbb6ff");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[Value_Int]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_Int

                #region Поле Value_String

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.";
                    schemaObjectFieldQuey.Id = new Guid("100e6573-b387-4cb5-b3d6-45df4cb2cc9c");
                    schemaObjectFieldQuey.Order = false;
                    schemaObjectFieldQuey.Where = false;
                    schemaObjectFieldQuey.Name = @"[Value_String]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Value_String

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[Id]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект Object_A

            #region Объект Object_B

            {
                var schemaObjectQuey = new SqlServerSchemaObjectQuey();
                Schema.Objects.Add(schemaObjectQuey);

                schemaObjectQuey.Description = @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)";
                schemaObjectQuey.Id = new Guid("cb9a1909-a7b6-48a6-8fe5-7d714e0225ea");
                schemaObjectQuey.IdentityFieldId = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");

                #region Поле CreateDate

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Дата создания";
                    schemaObjectFieldQuey.Id = new Guid("92847c2c-e7b4-4ee1-a628-042b75aa9225");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[CreateDate]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле CreateDate

                #region Поле Id

                {
                    var schemaObjectFieldQuey = new SqlServerSchemaObjectFieldQuey();
                    schemaObjectQuey.Fields.Add(schemaObjectFieldQuey);

                    schemaObjectFieldQuey.Description = @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)";
                    schemaObjectFieldQuey.Id = new Guid("4f414fbb-4b25-4691-80c3-9897fc5be61b");
                    schemaObjectFieldQuey.Order = true;
                    schemaObjectFieldQuey.Where = true;
                    schemaObjectFieldQuey.Name = @"[Id]";
                    schemaObjectFieldQuey.EvaluatedValue = null;
                }

                #endregion Поле Id

            }

            #endregion Объект Object_B

        }
    }

    [SuppressMessage("ReSharper", "PartialTypeWithSinglePart")]
    [SuppressMessage("ReSharper", "PartialMethodWithSinglePart")]
    public partial class Mappers : BaseSqlServerMappers
    {
        private readonly ISqlServerMapperSelectFilterFactory m_selectFilterFactory;
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
                var selectFilterContext = new SqlServerMapperSelectFilterContext(SqlServerSchemaQueriesProvider.Schema);
                m_selectFilterFactory = new SqlServerMapperSelectFilterFactory(selectFilterContext);
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
    public class BulkInsertDataReaderObject_A : BaseBulkInsertDataReader<Object_ADtoNew>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly Dictionary<string, int> OrdinalMap =
            new Dictionary<string, int>
            {
                ["Id"] = 0,
                ["Revision"] = 1,
                ["Value_DateTime"] = 2,
                ["Value_DateTime_NotUpdate"] = 3,
                ["Value_Long"] = 4,
                ["Value_Int"] = 5,
                ["Value_String"] = 6,
            };

        private static readonly Func<Object_ADtoNew, object>[] FuncGetValues =
        {
            (instance) => instance.Id,
            (instance) => Constants.StartRevision,
            (instance) => instance.Value_DateTime,
            (instance) => instance.Value_DateTime_NotUpdate,
            (instance) => instance.Value_Long,
            (instance) => instance.Value_Int,
            (instance) => instance.Value_String,
        };

        public BulkInsertDataReaderObject_A(IEnumerable<Object_ADtoNew> collection)
            : base(collection, FuncGetValues.Length)
        {
        }

        public override object GetValue(int i)
        {
            var result = FuncGetValues[i](m_enumerator.Current);

            return (result);
        }

        public override int GetOrdinal(string name)
        {
            var result = OrdinalMap[name];

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
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public partial class MapperObject_A : BaseSqlServerMapper<Object_ADtoActual>, IMapperInitializer, IMapperObject_A, IMapperActualDtoCache
    {
        public MapperObject_A(
            IMappersExceptionPolicy exceptionPolicy,
            ISqlServerMapperSelectFilterFactory selectFilterFactory)
            : base(
                "Маппер данных состояния доменного объекта '" + @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера" + "' в БД",
                WellknownMappers.Object_A,
                selectFilterFactory,
                exceptionPolicy)
        {
        }

        public MapperObject_A(
            IMappersExceptionPolicy exceptionPolicy,
            ISqlServerMapperSelectFilterFactory selectFilterFactory,
            IInfrastructureMonitorMapper infrastructureMonitor = null,
            IMemoryCache<Object_ADtoActual, long> actualDtoMemoryCache = null)
            : base(
                "Маппер данных состояния доменного объекта '" + @"Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера" + "' в БД",
                WellknownMappers.Object_A,
                selectFilterFactory,
                exceptionPolicy,
                infrastructureMonitor,
                actualDtoMemoryCache)
        {
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"[Object_A]";

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
        /// Получение следующего значения идентити из последовательности "Sequence_Object_A".
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual long GetNextId(
            IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXT VALUE FOR Sequence_Object_A";
                    var temp = command.ExecuteScalar();
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
        public virtual IList<long> GetNextIds(
            IMappersSession session,
            int count,
            CancellationToken cancellationToken)
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
                var typedSession = (ISqlServerMappersSession) session;
                
                cancellationToken.ThrowIfCancellationRequested();
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"WITH SERIES(ID) AS (SELECT 1 UNION ALL SELECT ID + 1 AS NEXTID FROM SERIES WHERE ID < @count) SELECT NEXT VALUE FOR Sequence_Object_A As Id FROM SERIES OPTION (MAXRECURSION 0)";
                    command.Parameters.Add("@count", SqlDbType.Int).Value = count;
                    
                    var result = new List<long>(count);
                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");
                        
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
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает следующего значение идентити.</returns>
        public virtual async ValueTask<long> GetNextIdAsync(
            IMappersSession session,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT NEXT VALUE FOR Sequence_Object_A";
                    var temp = await command.ExecuteScalarAsync(cancellationToken).ConfigureAwait(false);
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
        public virtual bool Exists(
            IMappersSession session,
            long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_A] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual async ValueTask<bool> ExistsAsync(
            IMappersSession session,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_A] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual bool ExistsRaw(
            IMappersSession session,
            long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_A] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual async ValueTask<bool> ExistsRawAsync(
            IMappersSession session,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_A] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual bool ExistsRevision(
            IMappersSession session,
            long id,
            long revision)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_A] WHERE ([Id] = @Id)AND ([Revision] = @Revision)";
                    command.Parameters.Add("@Revision", SqlDbType.BigInt).Value = revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual async ValueTask<bool> ExistsRevisionAsync(
            IMappersSession session,
            long id,
            long revision,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_A] WHERE ([Id] = @Id) AND ([Revision] = @Revision)";
                    command.Parameters.Add("@Revision", SqlDbType.BigInt).Value = revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual Object_ADtoActual Get(
            IHostMappersSession hostMappersSession,
            long id)
        {
            if (hostMappersSession == null)
            {
                throw new ArgumentNullException(nameof(hostMappersSession));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var tempSession = hostMappersSession.GetMappersSession();
                var typedSession = (ISqlServerMappersSession)tempSession;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A] WHERE
([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                            var indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                            var indexValue_Long = reader.GetOrdinal("Value_Long");
                            var indexValue_Int = reader.GetOrdinal("Value_Int");
                            var indexValue_String = reader.GetOrdinal("Value_String");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }

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
        /// <param name="hostMappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает значение если запись существует иначе возвращает <see langword="null" /> если запись не существует.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> GetAsync(
            IHostMappersSession hostMappersSession,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (hostMappersSession == null)
            {
                throw new ArgumentNullException(nameof(hostMappersSession));
            }

            try
            {
                if (TryGetFromCache(id, out var cacheResult))
                {
                    return (cacheResult);
                }

                var tempSession = await hostMappersSession.GetMappersSessionAsync(cancellationToken).ConfigureAwait(false);
                var typedSession = (ISqlServerMappersSession)tempSession;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A] WHERE
([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                            var indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                            var indexValue_Long = reader.GetOrdinal("Value_Long");
                            var indexValue_Int = reader.GetOrdinal("Value_Int");
                            var indexValue_String = reader.GetOrdinal("Value_String");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }

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
        public virtual Object_ADtoActual GetRaw(
            IMappersSession session,
            long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                            var indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                            var indexValue_Long = reader.GetOrdinal("Value_Long");
                            var indexValue_Int = reader.GetOrdinal("Value_Int");
                            var indexValue_String = reader.GetOrdinal("Value_String");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }

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
        public virtual async ValueTask<Object_ADtoActual> GetRawAsync(
            IMappersSession session,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                            var indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                            var indexValue_Long = reader.GetOrdinal("Value_Long");
                            var indexValue_Int = reader.GetOrdinal("Value_Int");
                            var indexValue_String = reader.GetOrdinal("Value_String");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }

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
        /// Обработка конкуренции при обновлении записи в методе <see cref="Update"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        partial void ConcurrencyOnUpdate(IMappersSession session, long id);

        /// <summary>
        /// Обновить запись.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual Object_ADtoActual Update(
            IMappersSession session,
            Object_ADtoChanged data)
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
                var typedSession = (ISqlServerMappersSession) session;
                
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
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE [Object_A] SET ");
                    commandText.AppendLine(@"[Revision] = @New_Revision");
                    
                    commandText.AppendLine(@", [Value_DateTime] = @Value_DateTime");
                    command.Parameters.Add("@Value_DateTime", SqlDbType.DateTime).Value = result.Value_DateTime;
                    if (data.Value_Long.IsChanged)
                    {
                        commandText.AppendLine(@", [Value_Long] = @Value_Long");
                        command.Parameters.Add("@Value_Long", SqlDbType.BigInt).Value = result.Value_Long;
                    }
                    commandText.AppendLine(@", [Value_Int] = @Value_Int");
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = result.Value_Int;
                    }
                    if (data.Value_String.IsChanged)
                    {
                        commandText.AppendLine(@", [Value_String] = @Value_String");
                        if (result.Value_String == null)
                        {
                            command.Parameters.Add("@Value_String", SqlDbType.NText).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value_String", SqlDbType.NText).Value = result.Value_String;
                        }
                    }
                    commandText.Append(@" WHERE ([Id] = @Id) AND ([Revision] = @Old_Revision)");
                    
                    command.CommandText = commandText.ToString();
                    command.Parameters.Add("@Old_Revision", SqlDbType.BigInt).Value = data.Revision;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        ConcurrencyOnUpdate(session, result.Id);

                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                AddActualState(typedSession, result);

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
        public virtual async ValueTask<IMapperDto> UpdateAsync(
            IMappersSession session,
            Object_ADtoChanged data,
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
                var typedSession = (ISqlServerMappersSession) session;
                
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
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    var commandText = new StringBuilder();
                    commandText.Append(@"UPDATE [Object_A] SET ");
                    commandText.AppendLine(@"[Revision] = @New_Revision");
                    
                    commandText.AppendLine(@", [Value_DateTime] = @Value_DateTime");
                    command.Parameters.Add("@Value_DateTime", SqlDbType.DateTime).Value = result.Value_DateTime;
                    if (data.Value_Long.IsChanged)
                    {
                        commandText.AppendLine(@", [Value_Long] = @Value_Long");
                        command.Parameters.Add("@Value_Long", SqlDbType.BigInt).Value = result.Value_Long;
                    }
                    commandText.AppendLine(@", [Value_Int] = @Value_Int");
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = result.Value_Int;
                    }
                    if (data.Value_String.IsChanged)
                    {
                        commandText.AppendLine(@", [Value_String] = @Value_String");
                        if (result.Value_String == null)
                        {
                            command.Parameters.Add("@Value_String", SqlDbType.NText).Value = DBNull.Value;
                        }
                        else
                        {
                            command.Parameters.Add("@Value_String", SqlDbType.NText).Value = result.Value_String;
                        }
                    }
                    commandText.Append(@" WHERE ([Id] = @Id) AND ([Revision] = @Old_Revision)");
                    
                    command.CommandText = commandText.ToString();
                    command.Parameters.Add("@Old_Revision", SqlDbType.BigInt).Value = data.Revision;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        ConcurrencyOnUpdate(session, result.Id);

                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
                    }
                }

                AddActualState(typedSession, result);

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
                var typedSession = (ISqlServerMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var dataReader = new BulkInsertDataReaderObject_A(data))
                {
                    DoBulkInsert(typedSession, dataReader);
                }
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
        /// <param name="dataReader">Поточный читатель данных записей для массовой вставки записей в БД.</param>
        protected virtual void DoBulkInsert(
            ISqlServerMappersSession session,
            IDataReader dataReader)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (var sqlBulkCopy = session.CreateSqlBulkCopy())
            {
                sqlBulkCopy.DestinationTableName = "[Object_A]";

                sqlBulkCopy.ColumnMappings.Add("[Id]", "[Id]");
                sqlBulkCopy.ColumnMappings.Add("[Revision]", "[Revision]");
                sqlBulkCopy.ColumnMappings.Add("[Value_DateTime]", "[Value_DateTime]");
                sqlBulkCopy.ColumnMappings.Add("[Value_DateTime_NotUpdate]", "[Value_DateTime_NotUpdate]");
                sqlBulkCopy.ColumnMappings.Add("[Value_Long]", "[Value_Long]");
                sqlBulkCopy.ColumnMappings.Add("[Value_Int]", "[Value_Int]");
                sqlBulkCopy.ColumnMappings.Add("[Value_String]", "[Value_String]");

                sqlBulkCopy.WriteToServer(dataReader);
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
                var typedSession = (ISqlServerMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var dataReader = new BulkInsertDataReaderObject_A(data))
                {
                    await DoBulkInsertAsync(typedSession, dataReader, cancellationToken).ConfigureAwait(false);
                }
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
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="dataReader">Поточный читатель данных записей для массовой вставки записей в БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        protected virtual async ValueTask DoBulkInsertAsync(
            ISqlServerMappersSession session,
            IDataReader dataReader,
            CancellationToken cancellationToken = default)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (var sqlBulkCopy = await session.CreateSqlBulkCopyAsync(cancellationToken).ConfigureAwait(false))
            {
                sqlBulkCopy.DestinationTableName = "[Object_A]";

                sqlBulkCopy.ColumnMappings.Add("[Id]", "[Id]");
                sqlBulkCopy.ColumnMappings.Add("[Revision]", "[Revision]");
                sqlBulkCopy.ColumnMappings.Add("[Value_DateTime]", "[Value_DateTime]");
                sqlBulkCopy.ColumnMappings.Add("[Value_DateTime_NotUpdate]", "[Value_DateTime_NotUpdate]");
                sqlBulkCopy.ColumnMappings.Add("[Value_Long]", "[Value_Long]");
                sqlBulkCopy.ColumnMappings.Add("[Value_Int]", "[Value_Int]");
                sqlBulkCopy.ColumnMappings.Add("[Value_String]", "[Value_String]");

                await sqlBulkCopy.WriteToServerAsync(dataReader, cancellationToken).ConfigureAwait(false);
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
        public virtual Object_ADtoActual New(
            IMappersSession session,
            Object_ADtoNew data)
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
                var typedSession = (ISqlServerMappersSession) session;
                
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
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [Object_A]
(
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String])
VALUES
(
@Id,
@New_Revision,
@Value_DateTime,
@Value_DateTime_NotUpdate,
@Value_Long,
@Value_Int,
@Value_String)";
                    command.Parameters.Add("@Value_DateTime", SqlDbType.DateTime).Value = result.Value_DateTime;
                    command.Parameters.Add("@Value_DateTime_NotUpdate", SqlDbType.DateTime).Value = result.Value_DateTime_NotUpdate;
                    command.Parameters.Add("@Value_Long", SqlDbType.BigInt).Value = result.Value_Long;
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = result.Value_Int;
                    }
                    if (result.Value_String == null)
                    {
                        command.Parameters.Add("@Value_String", SqlDbType.NText).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_String", SqlDbType.NText).Value = result.Value_String;
                    }
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
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
        public virtual async ValueTask<IMapperDto> NewAsync(
            IMappersSession session,
            Object_ADtoNew data,
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
                var typedSession = (ISqlServerMappersSession) session;
                
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
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [Object_A]
(
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String])
VALUES
(
@Id,
@New_Revision,
@Value_DateTime,
@Value_DateTime_NotUpdate,
@Value_Long,
@Value_Int,
@Value_String)";
                    command.Parameters.Add("@Value_DateTime", SqlDbType.DateTime).Value = result.Value_DateTime;
                    command.Parameters.Add("@Value_DateTime_NotUpdate", SqlDbType.DateTime).Value = result.Value_DateTime_NotUpdate;
                    command.Parameters.Add("@Value_Long", SqlDbType.BigInt).Value = result.Value_Long;
                    if (result.Value_Int == null)
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_Int", SqlDbType.Int).Value = result.Value_Int;
                    }
                    if (result.Value_String == null)
                    {
                        command.Parameters.Add("@Value_String", SqlDbType.NText).Value = DBNull.Value;
                    }
                    else
                    {
                        command.Parameters.Add("@Value_String", SqlDbType.NText).Value = result.Value_String;
                    }
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
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
        /// Обработка конкуренции при удалении записи в методе <see cref="Delete"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        partial void ConcurrencyOnDelete(IMappersSession session, long id);

        /// <summary>
        /// Удаление записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для удаления записи.</param>
        public virtual void Delete(
            IMappersSession session,
            Object_ADtoDeleted data)
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
                var typedSession = (ISqlServerMappersSession) session;

                RemoveActualState(typedSession, data.Id);

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM [Object_A] WHERE ([Id] = @Id) AND ([Revision] = @Revision)";
                    command.Parameters.Add("@Revision", SqlDbType.BigInt).Value = data.Revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = data.Id;
                    
                    var deleteCount = command.ExecuteNonQuery();
                    if (deleteCount != 1)
                    {
                        ConcurrencyOnDelete(session, data.Id);

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
        public virtual async ValueTask DeleteAsync(
            IMappersSession session,
            Object_ADtoDeleted data,
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
                var typedSession = (ISqlServerMappersSession) session;

                RemoveActualState(typedSession, data.Id);

                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"DELETE FROM [Object_A] WHERE ([Id] = @Id) AND ([Revision] = @Revision)";
                    command.Parameters.Add("@Revision", SqlDbType.BigInt).Value = data.Revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = data.Id;
                    
                    var deleteCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (deleteCount != 1)
                    {
                        ConcurrencyOnDelete(session, data.Id);

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
        [SuppressMessage("ReSharper", "RedundantCast")]
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
        public virtual IEnumerable<Object_ADtoActual> GetEnumerator(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A]";
                    
                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
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
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                        indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                        indexValue_Long = reader.GetOrdinal("Value_Long");
                        indexValue_Int = reader.GetOrdinal("Value_Int");
                        indexValue_String = reader.GetOrdinal("Value_String");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }
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
        public virtual async IAsyncEnumerable<Object_ADtoActual> GetEnumeratorAsync(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A]";
                    
                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
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
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                        indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                        indexValue_Long = reader.GetOrdinal("Value_Long");
                        indexValue_Int = reader.GetOrdinal("Value_Int");
                        indexValue_String = reader.GetOrdinal("Value_String");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }
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
        public virtual IEnumerable<Object_ADtoActual> GetEnumeratorRaw(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A]";
                    
                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
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
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                        indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                        indexValue_Long = reader.GetOrdinal("Value_Long");
                        indexValue_Int = reader.GetOrdinal("Value_Int");
                        indexValue_String = reader.GetOrdinal("Value_String");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }
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
        [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
        public virtual IEnumerable<Object_ADtoActual> GetEnumeratorPage(
            IMappersSession session,
            int pageIndex,
            int pageSize,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if ((pageSize < 1) || (pageSize > 1000))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[Value_DateTime],
[Value_DateTime_NotUpdate],
[Value_Long],
[Value_Int],
[Value_String]
FROM [Object_A]";
                    command.Parameters.Add("@__PageIndex", SqlDbType.Int).Value = pageIndex;
                    command.Parameters.Add("@__PageSize", SqlDbType.Int).Value = pageSize;
                    
                    ExpandCommand(
                        command,
                        null,
                        @" [Id] DESC ",
                        @" OFFSET((@__PageIndex - 1) * @__PageSize) ROWS FETCH NEXT @__PageSize ROWS ONLY ",
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexValue_DateTime;
                    int indexValue_DateTime_NotUpdate;
                    int indexValue_Long;
                    int indexValue_Int;
                    int indexValue_String;
                    ISqlServerMappersSession typedSession;
                    try
                    {
                        typedSession = (ISqlServerMappersSession) session;
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexValue_DateTime = reader.GetOrdinal("Value_DateTime");
                        indexValue_DateTime_NotUpdate = reader.GetOrdinal("Value_DateTime_NotUpdate");
                        indexValue_Long = reader.GetOrdinal("Value_Long");
                        indexValue_Int = reader.GetOrdinal("Value_Int");
                        indexValue_String = reader.GetOrdinal("Value_String");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_ADtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.Value_DateTime = reader.GetDateTime(indexValue_DateTime);
                            result.Value_DateTime_NotUpdate = reader.GetDateTime(indexValue_DateTime_NotUpdate);
                            result.Value_Long = reader.GetInt64(indexValue_Long);
                            if (reader.IsDBNull(indexValue_Int))
                            {
                                result.Value_Int = default;
                            }
                            else
                            {
                                result.Value_Int = reader.GetInt32(indexValue_Int);
                            }
                            if (reader.IsDBNull(indexValue_String))
                            {
                                result.Value_String = default;
                            }
                            else
                            {
                                result.Value_String = reader.GetString(indexValue_String);
                            }
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
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(
            IMappersSession session,
            int pageIndex,
            int pageSize,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if ((pageSize < 1) || (pageSize > 1000))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT [Id] FROM [Object_A] WITH(NOLOCK)";
                    command.Parameters.Add("@__PageIndex", SqlDbType.Int).Value = pageIndex;
                    command.Parameters.Add("@__PageSize", SqlDbType.Int).Value = pageSize;
                    
                    ExpandCommand(
                        command,
                        null,
                        @" [Id] DESC ",
                        @" OFFSET((@__PageIndex - 1) * @__PageSize) ROWS FETCH NEXT @__PageSize ROWS ONLY ",
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
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
                        long id;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            id = reader.GetInt64(indexId);
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
                        
                        yield return (id);
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
        public virtual long GetCount(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM [Object_A] WITH(NOLOCK)";
                    
                    ExpandCommand(command, (selectFilter as ISqlServerMapperSelectFilter), null);
                    
                    var result = (int) command.ExecuteScalar();
                    
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

    /// <summary>
    /// Поточный читатель данных записей для массовой вставки записей в БД.
    ///
    /// Объект с сокрытием записи при удалении (без фичического страниы записи в БД)
    /// </summary>
    public class BulkInsertDataReaderObject_B : BaseBulkInsertDataReader<Object_BDtoNew>
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public static readonly Dictionary<string, int> OrdinalMap =
            new Dictionary<string, int>
            {
                ["Id"] = 0,
                ["Revision"] = 1,
                ["Available"] = 2,
                ["CreateDate"] = 3,
            };

        private static readonly Func<Object_BDtoNew, object>[] FuncGetValues =
        {
            (instance) => instance.Id,
            (instance) => Constants.StartRevision,
            (instance) => true,
            (instance) => instance.CreateDate,
        };

        public BulkInsertDataReaderObject_B(IEnumerable<Object_BDtoNew> collection)
            : base(collection, FuncGetValues.Length)
        {
        }

        public override object GetValue(int i)
        {
            var result = FuncGetValues[i](m_enumerator.Current);

            return (result);
        }

        public override int GetOrdinal(string name)
        {
            var result = OrdinalMap[name];

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
    // ReSharper disable once ClassWithVirtualMembersNeverInherited.Global
    public partial class MapperObject_B : BaseSqlServerMapper<Object_BDtoActual>, IMapperInitializer, IMapperObject_B
    {
        public MapperObject_B(
            IMappersExceptionPolicy exceptionPolicy,
            ISqlServerMapperSelectFilterFactory selectFilterFactory)
            : base(
                "Маппер данных состояния доменного объекта '" + @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)" + "' в БД",
                WellknownMappers.Object_B,
                selectFilterFactory,
                exceptionPolicy)
        {
        }

        public MapperObject_B(
            IMappersExceptionPolicy exceptionPolicy,
            ISqlServerMapperSelectFilterFactory selectFilterFactory,
            IInfrastructureMonitorMapper infrastructureMonitor = null)
            : base(
                "Маппер данных состояния доменного объекта '" + @"Объект с сокрытием записи при удалении (без фичического страниы записи в БД)" + "' в БД",
                WellknownMappers.Object_B,
                selectFilterFactory,
                exceptionPolicy,
                infrastructureMonitor)
        {
        }

        /// <summary>
        /// Имя таблицы БД.
        /// </summary>
        public string TableName => @"[Object_B]";

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
        public virtual long? GetMaxId(
            IMappersSession session)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT MAX([Id]) AS Id FROM [Object_B]";
                    
                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        var indexId = reader.GetOrdinal("Id");
                        
                        if (reader.Read() && (reader.IsDBNull(indexId) == false))
                        {
                            var result = reader.GetInt64(indexId);
                            
                            return (result);
                        }
                    }
                    
                    return (null);
                }
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
        public virtual bool Exists(
            IMappersSession session,
            long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_B] WHERE ([Id] = @Id) AND ([Available] = @Available)";
                    command.Parameters.Add("@Available", SqlDbType.Bit).Value = true;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual async ValueTask<bool> ExistsAsync(
            IMappersSession session,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_B] WHERE ([Id] = @Id) AND ([Available] = @Available)";
                    command.Parameters.Add("@Available", SqlDbType.Bit).Value = true;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual bool ExistsRaw(
            IMappersSession session,
            long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand()) 
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_B] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        public virtual async ValueTask<bool> ExistsRawAsync(
            IMappersSession session,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT TOP 1 1 FROM [Object_B] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
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
        /// Обработка исключения мапппера в методе <see cref="Get"/>.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="exception">Исключение мапппера.</param>
        /// <param name="id">Идентити записи.</param>
        partial void CatchExceptionOnGet(IHostMappersSession hostMappersSession, Exception exception, long id);

        /// <summary>
        /// Получить запись с указаным идентити.
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="hostMappersSession">Хост сессии БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <returns>Возвращает <see langword="true" /> если записи существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual Object_BDtoActual Get(
            IHostMappersSession hostMappersSession,
            long id)
        {
            if (hostMappersSession == null)
            {
                throw new ArgumentNullException(nameof(hostMappersSession));
            }

            try
            {
                var tempSession = hostMappersSession.GetMappersSession();
                var typedSession = (ISqlServerMappersSession)tempSession;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;

                    command.CommandText = @"SELECT
[Id],
[Revision],
[CreateDate]
FROM [Object_B] WHERE
([Id] = @Id)AND ([Available] = @Old_Available)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    
                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexCreateDate = reader.GetOrdinal("CreateDate");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = true;
                            result.Revision = reader.GetInt64(indexRevision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);

                            SeedRevision(result.Revision);
                            
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
        /// ВАЖНО : Получение не учитывает скрытые записи.
        /// </summary>
        /// <param name="hostMappersSession">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает <see langword="true" /> если записи существует иначе возвращает <see langword="null" /> если запись не существует или скрыта.</returns>
        [SuppressMessage("ReSharper", "UseObjectOrCollectionInitializer")]
        [SuppressMessage("ReSharper", "ConvertIfStatementToConditionalTernaryExpression")]
        [SuppressMessage("ReSharper", "RedundantCast")]
        public virtual async ValueTask<IMapperDto> GetAsync(
            IHostMappersSession hostMappersSession,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (hostMappersSession == null)
            {
                throw new ArgumentNullException(nameof(hostMappersSession));
            }

            try
            {
                var tempSession = await hostMappersSession.GetMappersSessionAsync(cancellationToken).ConfigureAwait(false);
                var typedSession = (ISqlServerMappersSession)tempSession;

                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;

                    command.CommandText = @"SELECT
[Id],
[Revision],
[CreateDate]
FROM [Object_B] WHERE
([Id] = @Id)AND ([Available] = @Old_Available)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    
                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexCreateDate = reader.GetOrdinal("CreateDate");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = true;
                            result.Revision = reader.GetInt64(indexRevision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);

                            SeedRevision(result.Revision);
                            
                            return ((IMapperDto)result);
                        }
                    }
                    
                    return ((IMapperDto)null);
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
        public virtual Object_BDtoActual GetRaw(
            IMappersSession session,
            long id)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Available],
[Revision],
[CreateDate]
FROM [Object_B] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
                    using (var reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult))
                    {
                        if (reader.Read())
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexAvailable = reader.GetOrdinal("Available");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexCreateDate = reader.GetOrdinal("CreateDate");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = reader.GetBoolean(indexAvailable);
                            result.Revision = reader.GetInt64(indexRevision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);

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
        public virtual async ValueTask<Object_BDtoActual> GetRawAsync(
            IMappersSession session,
            long id,
            CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Available],
[Revision],
[CreateDate]
FROM [Object_B] WHERE ([Id] = @Id)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = id;
                    
                    var reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                    await using (reader.ConfigureAwait(false))
                    {
                        if (await reader.ReadAsync(cancellationToken).ConfigureAwait(false))
                        {
                            var indexId = reader.GetOrdinal("Id");
                            var indexAvailable = reader.GetOrdinal("Available");
                            var indexRevision = reader.GetOrdinal("Revision");
                            var indexCreateDate = reader.GetOrdinal("CreateDate");

#pragma warning disable IDE0017 // Simplify object initialization
                            var result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = reader.GetBoolean(indexAvailable);
                            result.Revision = reader.GetInt64(indexRevision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);

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
        /// Обработка конкуренции при обновлении записи в методе <see cref="Update"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        partial void ConcurrencyOnUpdate(IMappersSession session, long id);

        /// <summary>
        /// Обновить запись.
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual Object_BDtoActual Update(
            IMappersSession session,
            Object_BDtoChanged data)
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
                var typedSession = (ISqlServerMappersSession) session;
                
                var result =
                new Object_BDtoActual
                    {
                        Id = data.Id,
                        Available = true,
                        Revision = NewRevision(),
                        CreateDate = data.CreateDate,
                    };
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE [Object_B] SET
[Revision] = @New_Revision
WHERE
([Id] = @Id) AND ([Revision] < @New_Revision)AND ([Available] = @Old_Available)";
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;

                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        ConcurrencyOnUpdate(session, result.Id);

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
        /// ВАЖНО : Обновление не учитывает скрытые записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Измененная запись.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns>Возвращает актуальное состояние записи.</returns>
        public virtual async ValueTask<IMapperDto> UpdateAsync(
            IMappersSession session,
            Object_BDtoChanged data,
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
                var typedSession = (ISqlServerMappersSession) session;
                
                var result =
                new Object_BDtoActual
                    {
                        Id = data.Id,
                        Available = true,
                        Revision = NewRevision(),
                        CreateDate = data.CreateDate,
                    };
                
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE [Object_B] SET
[Revision] = @New_Revision
WHERE
([Id] = @Id) AND ([Revision] < @New_Revision)AND ([Available] = @Old_Available)";
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;

                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        ConcurrencyOnUpdate(session, result.Id);

                        throw new InvalidOperationException($"Конкуренция при обновлении записи с идентификатором '{result.Id}' маппером '{MapperId}'.");
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
                var typedSession = (ISqlServerMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var dataReader = new BulkInsertDataReaderObject_B(data))
                {
                    DoBulkInsert(typedSession, dataReader);
                }
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
        /// <param name="dataReader">Поточный читатель данных записей для массовой вставки записей в БД.</param>
        protected virtual void DoBulkInsert(
            ISqlServerMappersSession session,
            IDataReader dataReader)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (var sqlBulkCopy = session.CreateSqlBulkCopy())
            {
                sqlBulkCopy.DestinationTableName = "[Object_B]";

                sqlBulkCopy.ColumnMappings.Add("[Id]", "[Id]");
                sqlBulkCopy.ColumnMappings.Add("[Available]", "[Available]");
                sqlBulkCopy.ColumnMappings.Add("[Revision]", "[Revision]");
                sqlBulkCopy.ColumnMappings.Add("[CreateDate]", "[CreateDate]");

                sqlBulkCopy.WriteToServer(dataReader);
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
                var typedSession = (ISqlServerMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var dataReader = new BulkInsertDataReaderObject_B(data))
                {
                    await DoBulkInsertAsync(typedSession, dataReader, cancellationToken).ConfigureAwait(false);
                }
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
        /// Массовое создание записей.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="dataReader">Поточный читатель данных записей для массовой вставки записей в БД.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        protected virtual async ValueTask DoBulkInsertAsync(
            ISqlServerMappersSession session,
            IDataReader dataReader,
            CancellationToken cancellationToken = default)
        {
            // ReSharper disable once ConvertToUsingDeclaration
            using (var sqlBulkCopy = await session.CreateSqlBulkCopyAsync(cancellationToken).ConfigureAwait(false))
            {
                sqlBulkCopy.DestinationTableName = "[Object_B]";

                sqlBulkCopy.ColumnMappings.Add("[Id]", "[Id]");
                sqlBulkCopy.ColumnMappings.Add("[Available]", "[Available]");
                sqlBulkCopy.ColumnMappings.Add("[Revision]", "[Revision]");
                sqlBulkCopy.ColumnMappings.Add("[CreateDate]", "[CreateDate]");

                await sqlBulkCopy.WriteToServerAsync(dataReader, cancellationToken).ConfigureAwait(false);
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
        public virtual Object_BDtoActual New(
            IMappersSession session,
            Object_BDtoNew data)
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
                var typedSession = (ISqlServerMappersSession) session;
                
                var result =
                new Object_BDtoActual
                    {
                        Id = data.Id,
                        Available = true,
                        Revision = Constants.StartRevision,
                        CreateDate = data.CreateDate,
                    };
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [Object_B]
(
[Id],
[Available],
[Revision],
[CreateDate])
VALUES
(
@Id,
@New_Available,
@New_Revision,
@CreateDate)";
                    command.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = result.CreateDate;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;
                    command.Parameters.Add("@New_Available", SqlDbType.Bit).Value = true;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
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
        public virtual async ValueTask<IMapperDto> NewAsync(
            IMappersSession session,
            Object_BDtoNew data,
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
                var typedSession = (ISqlServerMappersSession) session;
                
                var result =
                new Object_BDtoActual
                    {
                        Id = data.Id,
                        Available = true,
                        Revision = Constants.StartRevision,
                        CreateDate = data.CreateDate,
                    };
                
                // ReSharper disable once ConvertToUsingDeclaration
                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                await using(command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"INSERT INTO [Object_B]
(
[Id],
[Available],
[Revision],
[CreateDate])
VALUES
(
@Id,
@New_Available,
@New_Revision,
@CreateDate)";
                    command.Parameters.Add("@CreateDate", SqlDbType.DateTime).Value = result.CreateDate;
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = result.Id;
                    command.Parameters.Add("@New_Available", SqlDbType.Bit).Value = true;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = result.Revision;
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
        /// <param name="data">Данные достаточные для удаления записи.</param>
        partial void CatchExceptionOnHide(IMappersSession session, Exception exception, Object_BDtoDeleted data);

        /// <summary>
        /// Обработка конкуренции при сокрытие записи в методе <see cref="Hide"/>.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="id">Идентити записи.</param>
        partial void ConcurrencyOnHide(IMappersSession session, long id);

        /// <summary>
        /// Сокрытие записи.
        /// </summary>
        /// <param name="session">Сессия БД.</param>
        /// <param name="data">Данные достаточные для сокрытия записи.</param>
        public virtual void Hide(
            IMappersSession session,
            Object_BDtoDeleted data)
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
                var typedSession = (ISqlServerMappersSession) session;

                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE [Object_B] SET
[Available] = @New_Available,
[Revision] = @New_Revision
WHERE
([Id] = @Id)
AND ([Available] = @Old_Available)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = data.Id;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    command.Parameters.Add("@New_Available", SqlDbType.Bit).Value = false;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = NewRevision();
                    
                    var updateCount = command.ExecuteNonQuery();
                    if (updateCount != 1)
                    {
                        ConcurrencyOnHide(session, data.Id);

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
        public virtual async ValueTask HideAsync(
            IMappersSession session,
            Object_BDtoDeleted data,
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
                var typedSession = (ISqlServerMappersSession) session;

                var command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                // ReSharper disable once ConvertToUsingDeclaration
                await using (command.ConfigureAwait(false))
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"UPDATE [Object_B] SET
[Available] = @New_Available,
[Revision] = @New_Revision
WHERE
([Id] = @Id)
AND ([Available] = @Old_Available)";
                    command.Parameters.Add("@Id", SqlDbType.BigInt).Value = data.Id;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    command.Parameters.Add("@New_Available", SqlDbType.Bit).Value = false;
                    command.Parameters.Add("@New_Revision", SqlDbType.BigInt).Value = NewRevision();
                    
                    var updateCount = await command.ExecuteNonQueryAsync(cancellationToken).ConfigureAwait(false);
                    if (updateCount != 1)
                    {
                        ConcurrencyOnHide(session, data.Id);

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
        [SuppressMessage("ReSharper", "RedundantCast")]
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
        public virtual IEnumerable<Object_BDtoActual> GetEnumerator(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[CreateDate]
FROM [Object_B]";
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    
                    ExpandCommand(
                        command,
                        @"([Available] = @Old_Available)",
                        null,
                        null,
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexCreateDate = reader.GetOrdinal("CreateDate");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = true;
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);
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
        public virtual async IAsyncEnumerable<Object_BDtoActual> GetEnumeratorAsync(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = await typedSession.CreateCommandAsync(cancellationToken).ConfigureAwait(false);
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[CreateDate]
FROM [Object_B]";
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    
                    ExpandCommand(
                        command,
                        @"([Available] = @Old_Available)",
                        null,
                        null,
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    try
                    {
                        reader = await command.ExecuteReaderAsync(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult, cancellationToken).ConfigureAwait(false);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexCreateDate = reader.GetOrdinal("CreateDate");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = true;
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);
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
        public virtual IEnumerable<Object_BDtoActual> GetEnumeratorRaw(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Available],
[Revision],
[CreateDate]
FROM [Object_B]";
                    
                    ExpandCommand(
                        command,
                        null,
                        null,
                        null,
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexAvailable;
                    int indexRevision;
                    int indexCreateDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                        indexAvailable = reader.GetOrdinal("Available");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexCreateDate = reader.GetOrdinal("CreateDate");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = reader.GetBoolean(indexAvailable);
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);
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
        [SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
        public virtual IEnumerable<Object_BDtoActual> GetEnumeratorPage(
            IMappersSession session,
            int pageIndex,
            int pageSize,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if ((pageSize < 1) || (pageSize > 1000))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT
[Id],
[Revision],
[CreateDate]
FROM [Object_B]";
                    command.Parameters.Add("@__PageIndex", SqlDbType.Int).Value = pageIndex;
                    command.Parameters.Add("@__PageSize", SqlDbType.Int).Value = pageSize;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    
                    ExpandCommand(
                        command,
                        @"([Available] = @Old_Available)",
                        @" [Id] DESC ",
                        @" OFFSET((@__PageIndex - 1) * @__PageSize) ROWS FETCH NEXT @__PageSize ROWS ONLY ",
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
                try
                {
                    int indexId;
                    int indexRevision;
                    int indexCreateDate;
                    try
                    {
                        reader = command.ExecuteReader(CommandBehavior.SequentialAccess | CommandBehavior.SingleResult);
                        indexId = reader.GetOrdinal("Id");
                        indexRevision = reader.GetOrdinal("Revision");
                        indexCreateDate = reader.GetOrdinal("CreateDate");
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
#pragma warning disable IDE0017 // Simplify object initialization
                            result = new Object_BDtoActual();
#pragma warning restore IDE0017 // Simplify object initialization
                            
                            result.Id = reader.GetInt64(indexId);
                            result.Available = true;
                            result.Revision = reader.GetInt64(indexRevision);
                            SeedRevision(result.Revision);
                            result.CreateDate = reader.GetDateTime(indexCreateDate);
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
        public virtual IEnumerable<long> GetEnumeratorIdentitiesPage(
            IMappersSession session,
            int pageIndex,
            int pageSize,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }
            if (pageIndex < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex));
            }
            if ((pageSize < 1) || (pageSize > 1000))
            {
                throw new ArgumentOutOfRangeException(nameof(pageSize));
            }
            
            SqlCommand command = null;
            try
            {
                try
                {
                    var typedSession = (ISqlServerMappersSession) session;
                    
                    // ReSharper disable once PossibleNullReferenceException
                    command = typedSession.CreateCommand();
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT [Id] FROM [Object_B] WITH(NOLOCK)";
                    command.Parameters.Add("@__PageIndex", SqlDbType.Int).Value = pageIndex;
                    command.Parameters.Add("@__PageSize", SqlDbType.Int).Value = pageSize;
                    command.Parameters.Add("@Old_Available", SqlDbType.Bit).Value = true;
                    
                    ExpandCommand(
                        command,
                        @"([Available] = @Old_Available)",
                        @" [Id] DESC ",
                        @" OFFSET((@__PageIndex - 1) * @__PageSize) ROWS FETCH NEXT @__PageSize ROWS ONLY ",
                        (ISqlServerMapperSelectFilter) selectFilter);
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
                
                SqlDataReader reader = null;
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
                        long id;
                        try
                        {
                            var hasRecord = reader.Read();
                            if (hasRecord == false)
                            {
                                break;
                            }
                            id = reader.GetInt64(indexId);
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
                        
                        yield return (id);
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
        public virtual long GetCount(
            IMappersSession session,
            IMapperSelectFilter selectFilter = null)
        {
            if (session == null)
            {
                throw new ArgumentNullException(nameof(session));
            }

            try
            {
                var typedSession = (ISqlServerMappersSession) session;
                
                // ReSharper disable once ConvertToUsingDeclaration
                using (var command = typedSession.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = @"SELECT COUNT(*) FROM [Object_B] WITH(NOLOCK)";
                    
                    ExpandCommand(command, (selectFilter as ISqlServerMapperSelectFilter), "([Available] = @Available)");
                    command.Parameters.Add("@Available", SqlDbType.Bit).Value = true;
                    
                    var result = (int) command.ExecuteScalar();
                    
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
