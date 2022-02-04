using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using ShtrihM.Wattle3.CodeGeneration.Common;
using ShtrihM.Wattle3.Common;
using ShtrihM.Wattle3.Primitives;

// ReSharper disable All

namespace ShtrihM.Wattle3.Examples.Mappers.PostgreSql.Common
{
    /// <summary>
    /// Поля доменных объектов.
    /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
    /// </summary>
    public static class WellknownDomainObjectFields
    {
        /// <summary>
        /// Все поля доменных объектов и их описание.
        /// </summary>
        public static readonly IReadOnlyDictionary<Guid, string> DisplayNames;

        static WellknownDomainObjectFields()
        {
            var mainType = MethodBase.GetCurrentMethod().DeclaringType;
            var types = mainType.GetNestedTypes();
            var displayNames = new Dictionary<Guid, string>(CommonDomainObjectValues.DisplayNames);
            foreach (var type in types)
            {
                WellknowConstantsHelper.CollectDisplayNames(displayNames, type);
            }
            DisplayNames = displayNames;
        }

        #region Object_A - Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера.

        /// <summary>
        /// Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера.
        /// При любом изменении надо руками запустить тест <see cref="DbMappersSchemaXmlBuilder.Test"/>.
        /// </summary>
        [Description("Объект с партиционированием таблицы БД, первичным ключём из последовательности БД, с оптимистической конкуренцией на уровне БД, с кешированием записей БД в памяти на уровне маппера")]
        [SchemaMapper(MapperId = WellknownDomainObjects.Text.Object_A, IsPrepared = true, IsCached = true, DeleteMode = SchemaMapperDeleteMode.Delete)]
        [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = ComplexIdentity.Level.L1)]
        [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
        [SchemaMapperRevisionField(IsVersion = true)]
        public static class Object_A
        {
            /// <summary>
            /// Дата-время (DateTime). Обновляемое поле.
            /// </summary>
            [Description("Дата-время (DateTime). Обновляемое поле.")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
            public static readonly Guid Value_DateTime = new("DCE071BB-796E-4397-91B8-EAF116747880");

            /// <summary>
            /// Дата-время (DateTime). Не обновляемое поле.
            /// </summary>
            [Description("Дата-время (DateTime). Не обновляемое поле.")]
            [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.NotUpdate)]
            public static readonly Guid Value_DateTime_NotUpdate = new("273A65E2-7647-42DB-A15D-58B69A64C69D");

            /// <summary>
            /// Число (long). Поле обновляется только при изменении значения.
            /// </summary>
            [Description("Число (long). Поле обновляется только при изменении значения.")]
            [SchemaMapperField(typeof(long), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_Long = new("87A005ED-CA51-4C60-83EC-6540AC0823D6");

            /// <summary>
            /// Число с поддержкой null (int?). Обновляемое поле.
            /// </summary>
            [Description("Число с поддержкой null (int?). Обновляемое поле.")]
            [SchemaMapperField(typeof(int?), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
            public static readonly Guid Value_Int = new("198251EF-8183-4A09-A760-E5BAAFBBB6FF");

            /// <summary>
            /// Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.
            /// </summary>
            [Description("Строка без ограничения размера с поддержкой null. Поле обновляется только при изменении значения.")]
            [SchemaMapperField(typeof(string), DbIsNull = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
            public static readonly Guid Value_String = new("100E6573-B387-4CB5-B3D6-45DF4CB2CC9C");
        }

        #endregion

        /*        
                #region Задание
                /// <summary>
                /// Задание.
                /// </summary>
                [Description("Задание")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.Task, MaxPageSize = Emerald.Common.Constants.MaxPageSize, DeleteMode = SchemaMapperDeleteMode.HideUpdate, IsCached = true, IsPrepared = true)]
                [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                [SchemaMapperRevisionField(IsVersion = true)]
                [SchemaMapperAvailableField]
                public static class Task
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("9841BECD-DD27-49A1-8CEE-7734C66B32CA");

                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("CC4C135F-CD40-4380-9E39-6C1654352B19");

                    /// <summary>
                    /// Статус <seealso cref="WellknownTaskStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid State = new("70FDFF4E-F512-49D1-AD9E-43ABFC43ED83");

                    /// <summary>
                    /// Детали статуса <seealso cref="WellknownTaskStateDetails"/>.
                    /// </summary>
                    [Description("Детали статуса")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid StateDetails = new("AEA03C64-0710-400E-BA9F-C81168C71375");

                    /// <summary>
                    /// Данные.
                    /// </summary>
                    [Description("Данные")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Data = new("15D5764A-0001-4634-ABE9-90AFE72210C0");

                    /// <summary>
                    /// Детали.
                    /// </summary>
                    [Description("Детали")]
                    [SchemaMapperField(typeof(string), Where = true, Order = true, DbIsNull = true, UpdateMode = SchemaMapperFieldUpdateMode.Update, DbSize = Emerald.Common.Constants.MaxSizeDetails)]
                    public static readonly Guid Details = new("0853236A-8EC7-4123-8DEB-AA52351C5584");

                    /// <summary>
                    /// Счётчик попыток исполнения.
                    /// </summary>
                    [Description("Счётчик попыток исполнения")]
                    [SchemaMapperField(typeof(int), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid Count = new("88AB9C10-2C54-4730-BA32-C52A6FAFFE10");

                    /// <summary>
                    /// Тип данных данных <seealso cref="WellknownTaskDataTypes"/>.
                    /// </summary>
                    [Description("Тип данных данных")]
                    [SchemaMapperField(typeof(int), Where = true, Order = true)]
                    public static readonly Guid DataType = new("559342F0-AA96-4857-94AE-29606940B279");

                    /// <summary>
                    /// ID родительской задачи.
                    /// </summary>
                    [Description("ID родительской задачи")]
                    [SchemaMapperField(typeof(long?), Where = true, Order = true)]
                    public static readonly Guid ParentTaskId = new("5B3AEC44-4550-4095-BEC8-C46F63F25044");

                    /// <summary>
                    /// ID календарного дня.
                    /// </summary>
                    [Description("ID календарного дня")]
                    [SchemaMapperField(typeof(long?), Where = true, Order = true)]
                    public static readonly Guid DayId = new("C7619271-30E8-4FF5-87A4-B264FF3A05BF");
                }
                #endregion

                #region Операция
                /// <summary>
                /// Операция.
                /// </summary>
                [Description("Операция")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.Operation, MaxPageSize = Emerald.Common.Constants.MaxPageSize, IsCached = true, IsPrepared = true)]
                [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                [SchemaMapperRevisionField(IsVersion = true)]
                public static class Operation
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("92847C2C-E7B4-4EE1-A628-042B75AA9225");

                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("FACE44D8-2C12-4592-8B46-418517FF5F85");

                    /// <summary>
                    /// Статус <seealso cref="WellknownOperationStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid State = new("5FB7154A-ACAC-41BE-8652-DB2859CF3553");

                    /// <summary>
                    /// Данные.
                    /// </summary>
                    [Description("Данные")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Data = new("C350CBCE-307D-421B-B07B-02FE75BE1DA1");

                    /// <summary>
                    /// Результат исполнения.
                    /// </summary>
                    [Description("Результат исполнения")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Result = new("3AB00AA4-C607-44BF-BDB3-EBD4CD301725");
                }
                #endregion

                #region Календарный день
                /// <summary>
                /// Календарный день.
                /// </summary>
                [Description("Календарный день")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.Day, MaxPageSize = Emerald.Common.Constants.MaxPageSize, IsPrepared = true)]
                [SchemaMapperRevisionField(IsVersion = true)]
                public static class Day
                {
                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("D2E95013-78C3-49C0-A9CE-8A32526C2D1B");

                    /// <summary>
                    /// Статус <seealso cref="WellknownDayStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid State = new("196F6520-05E9-4412-8D85-0921588109F6");

                    /// <summary>
                    /// Дата.
                    /// </summary>
                    [Description("Дата")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, DbColumnTypeName = nameof(NpgsqlDbType.Date))]
                    public static readonly Guid Date = new("B461B01E-52DC-4064-AAFA-645C366E8420");
                }
                #endregion

                #region Ключ операции
                /// <summary>
                /// Ключ операции.
                /// </summary>
                [Description("Ключ операции")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.OperationKey, MaxPageSize = Emerald.Common.Constants.MaxPageSize, IsPrepared = true)]
                [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                public static class OperationKey
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("D2C6B51E-EA8A-4D05-8FDA-607AD0D54998");

                    /// <summary>
                    /// ID операции.
                    /// </summary>
                    [Description("ID операции")]
                    [SchemaMapperField(typeof(long), Where = true, Order = true)]
                    public static readonly Guid OperationId = new("255747B3-018B-4218-B4B7-C0492AC94DE2");

                    /// <summary>
                    /// Ключ.
                    /// </summary>
                    [Description("Ключ")]
                    [SchemaMapperField(typeof(Guid), Where = true, Order = true)]
                    public static readonly Guid Key = new("BE519752-4577-4991-965A-7CCD0DDF361F");
                }
                #endregion

                #region Закрытие партиции БД
                /// <summary>
                /// Закрытие партиции БД.
                /// </summary>
                [Description("Закрытие партиции БД")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.ClosedPartition, MaxPageSize = Emerald.Common.Constants.MaxPageSize, IsPrepared = true)]
                [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                public static class ClosedPartition
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("99443F0F-7ADA-4A01-89E8-15E5208448CC");

                    /// <summary>
                    /// Имя партиции БД.
                    /// </summary>
                    [Description("Имя партиции БД")]
                    [SchemaMapperField(typeof(string), Where = true, Order = true, DbSize = Emerald.Common.Constants.ClosedPartitionFieldMaxSizePartitionName)]
                    public static readonly Guid PartitionName = new("9A7C01A3-FA4F-4972-9A1F-FA74F3E93CEB");

                    /// <summary>
                    /// Имя таблицы БД.
                    /// </summary>
                    [Description("Имя таблицы БД")]
                    [SchemaMapperField(typeof(string), Where = true, Order = true, DbSize = Emerald.Common.Constants.ClosedPartitionFieldMaxSizeTableName)]
                    public static readonly Guid TableName = new("AEF6CD6D-154E-478E-9823-47C237E7683A");

                    /// <summary>
                    /// ID календарного дня.
                    /// </summary>
                    [Description("ID календарного дня")]
                    [SchemaMapperField(typeof(long), Where = true, Order = true)]
                    public static readonly Guid DayId = new("7D50F575-C2AC-4053-84C6-70B9250F958A");

                    /// <summary>
                    /// Идентификатор типа объекта.
                    /// </summary>
                    [Description("Идентификатор типа объекта")]
                    [SchemaMapperField(typeof(Guid), Where = true, Order = true)]
                    public static readonly Guid Type = new("8D64DAFB-0976-43B3-867A-46D717CDF290");
                }
                #endregion

                #region Токен доступа к счёту
                /// <summary>
                /// Токен доступа к счёту.
                /// </summary>
                [Description("Токен доступа к счёту")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.Token, MaxPageSize = Emerald.Common.Constants.MaxPageSize, IsPrepared = true)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                [SchemaMapperRevisionField(IsVersion = true)]
                public static class Token
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("CA92D0AE-0C2E-4253-8909-D922735A0B7A");

                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("6EEF41D3-E2BD-4228-A57F-19A9DE6231F2");

                    /// <summary>
                    /// Дата истечение срока доступности.
                    /// </summary>
                    [Description("Дата истечение срока доступности")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid ExpirationDate = new("B584A7BA-77D1-4226-8C40-2F98649F3678");

                    /// <summary>
                    /// Статус <seealso cref="WellknownTokenStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid State = new("7B393DDD-E817-4109-B8B9-8298C70152E0");

                    /// <summary>
                    /// ID клиента.
                    /// </summary>
                    [Description("ID клиента")]
                    [SchemaMapperField(typeof(long), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
                    public static readonly Guid ClientId = new("0759DEC8-8E21-4014-B316-73EC85E51848");

                    /// <summary>
                    /// Данные.
                    /// </summary>
                    [Description("Данные")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Data = new("8C1CAAD2-C17A-41C6-990B-FACF3D261FE5");

                    /// <summary>
                    /// ID родительского токена доступа к счёту.
                    /// </summary>
                    [Description("ID родительского токена доступа к счёту")]
                    [SchemaMapperField(typeof(long?), Where = true, Order = true)]
                    public static readonly Guid ParentTokenId = new("EB500252-28CB-4358-A231-EC9FF40FB89C");

                    /// <summary>
                    /// Идентити токена с доступа к счёту.
                    /// </summary>
                    [Description("Идентити токена с доступа к счёту")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Identity = new("38158849-19A7-46AD-84E3-F4AD094F68D6");
                }
                #endregion

                #region Клиент
                /// <summary>
                /// Клиент.
                /// </summary>
                [Description("Клиент")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.Client, MaxPageSize = Emerald.Common.Constants.MaxPageSize, IsCached = true, IsPrepared = true)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                [SchemaMapperRevisionField(IsVersion = true)]
                public static class Client
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("1EE5645C-BC60-44F0-907E-FCD20FAF3B74");

                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("7295FE1B-4420-4CE2-B771-6A9008E7CF9A");

                    /// <summary>
                    /// Статус <seealso cref="WellknownClientStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
                    public static readonly Guid State = new("AFCF3B31-8C87-446D-81B9-6B3476D4D4B3");

                    /// <summary>
                    /// Категория <seealso cref="WellknownClientCategories"/>.
                    /// </summary>
                    [Description("Категория")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true)]
                    public static readonly Guid Category = new("F90D80AA-9503-4DE6-AB5E-F3D5EACBC32C");

                    /// <summary>
                    /// Данные.
                    /// </summary>
                    [Description("Данные")]
                    [SchemaMapperField(typeof(byte[]), UpdateMode = SchemaMapperFieldUpdateMode.Update)]
                    public static readonly Guid Data = new("E2B0199C-FF4A-473D-B1BF-8C168B208A3D");

                    /// <summary>
                    /// Счета.
                    /// </summary>
                    [Description("Счета")]
                    [SchemaMapperField(typeof(byte[]), UpdateMode = SchemaMapperFieldUpdateMode.Update)]
                    public static readonly Guid Accounts = new("766456FD-2A4D-4EA7-9157-EB691C0AAF27");

                    /// <summary>
                    /// Порядковый номер ревизии снимка состояния.
                    /// </summary>
                    [Description("Порядковый номер ревизии снимка состояния")]
                    [SchemaMapperField(typeof(long), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid SnapshotRevision = new("10061DD9-4A07-4409-A12E-236B6F49D2A6");

                    /// <summary>
                    /// Дата истечение срока доступности.
                    /// </summary>
                    [Description("Дата истечение срока доступности")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
                    public static readonly Guid ExpirationDate = new("9CF139A0-B75B-465A-8B8A-776947F59B79");

                    /// <summary>
                    /// Последнее событие в снимке состояния <seealso cref="WellknownClientStateSnapshotEventTypes"/>.
                    /// </summary>
                    [Description("Последнее событие в снимке состояния")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid SnapshotEvent = new("A8D5EB68-3264-4F01-A6D7-8A5AE24D04E4");

                    /// <summary>
                    /// Системный ID клиента получившего счета при перемещении счетов.
                    /// </summary>
                    [Description("Системный ID клиента получившего счета при перемещении счетов")]
                    [SchemaMapperField(typeof(long?), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.Update)]
                    public static readonly Guid TargetClientId = new("956B3959-9CF9-44BB-A576-91884430CE89");
                }
                #endregion

                #region Снимок состояния клиента
                /// <summary>
                /// Снимок состояния клиента.
                /// </summary>
                [Description("Снимок состояния клиента")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.ClientSnapshot, MaxPageSize = Emerald.Common.Constants.MaxPageSize, DeleteMode = SchemaMapperDeleteMode.HideUpdate, IsCached = true, IsPrepared = true)]
                [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                [SchemaMapperRevisionField(IsVersion = true)]
                [SchemaMapperAvailableField]
                public static class ClientSnapshot
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("B4020F55-2BF9-47EF-9904-FBAAB784C3F1");

                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("DD31768B-6A30-4CA5-A7AE-0F5F1EF20A38");

                    /// <summary>
                    /// Статус <seealso cref="WellknownClientSnapshotStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid State = new("573C0E5A-CA6C-4112-A1F2-A80161233F07");

                    /// <summary>
                    /// Детали статуса <seealso cref="WellknownClientSnapshotStateDetails"/>.
                    /// </summary>
                    [Description("Детали статуса")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid StateDetails = new("BE8CCC49-3B34-4065-81AC-3509EDB40CF2");

                    /// <summary>
                    /// Данные.
                    /// </summary>
                    [Description("Данные")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Data = new("664460A0-AABC-405C-80D7-2413115AE083");

                    /// <summary>
                    /// Детали.
                    /// </summary>
                    [Description("Детали")]
                    [SchemaMapperField(typeof(string), Where = true, Order = true, DbIsNull = true, UpdateMode = SchemaMapperFieldUpdateMode.Update, DbSize = Emerald.Common.Constants.MaxSizeDetails)]
                    public static readonly Guid Details = new("039EA3E5-28A7-4EFD-94DB-C65FC1096559");

                    /// <summary>
                    /// Счётчик попыток исполнения.
                    /// </summary>
                    [Description("Счётчик попыток исполнения")]
                    [SchemaMapperField(typeof(int), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid Count = new("40C7E54B-552B-4B66-BFF3-8D8F5DAC1FA4");
                }
                #endregion

                #region Задание экспорта
                /// <summary>
                /// Задание экспорта.
                /// </summary>
                [Description("Задание экспорта")]
                [SchemaMapper(MapperId = WellknownDomainObjects.Text.TaskExport, MaxPageSize = Emerald.Common.Constants.MaxPageSize, DeleteMode = SchemaMapperDeleteMode.HideUpdate, IsCached = true, IsPrepared = true)]
                [SchemaMapperIdentityFieldPostgreSql(PartitionsLevel = Constants.MappersComplexIdentityLevel)]
                [SchemaMapperIdentityField(DbSequenceName = "Sequence_%ObjectName%")]
                [SchemaMapperRevisionField(IsVersion = true)]
                [SchemaMapperAvailableField]
                public static class TaskExport
                {
                    /// <summary>
                    /// Дата создания.
                    /// </summary>
                    [Description("Дата создания")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true)]
                    public static readonly Guid CreateDate = new("22461F19-DFDE-4B55-9BB3-C2C879EB97F5");

                    /// <summary>
                    /// Дата модификации.
                    /// </summary>
                    [Description("Дата модификации")]
                    [SchemaMapperField(typeof(DateTime), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid ModificationDate = new("BE49C373-0923-40CE-B963-FCF338458079");

                    /// <summary>
                    /// Статус <seealso cref="WellknownTaskExportStates"/>.
                    /// </summary>
                    [Description("Статус")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid State = new("90596E36-C678-4FB1-91CD-B9C020705524");

                    /// <summary>
                    /// Детали статуса <seealso cref="WellknownTaskExportStateDetails"/>.
                    /// </summary>
                    [Description("Детали статуса")]
                    [SchemaMapperField(typeof(short), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid StateDetails = new("4020D91E-AF7B-47F5-AE2F-9E2BFD20454C");

                    /// <summary>
                    /// Данные.
                    /// </summary>
                    [Description("Данные")]
                    [SchemaMapperField(typeof(byte[]))]
                    public static readonly Guid Data = new("CDBEA554-638B-416C-9B91-51A29396734F");

                    /// <summary>
                    /// Детали.
                    /// </summary>
                    [Description("Детали")]
                    [SchemaMapperField(typeof(string), Where = true, Order = true, DbIsNull = true, UpdateMode = SchemaMapperFieldUpdateMode.Update, DbSize = Emerald.Common.Constants.MaxSizeDetails)]
                    public static readonly Guid Details = new("AD66B266-C857-4022-8544-54CB011C63AD");

                    /// <summary>
                    /// Счётчик попыток исполнения.
                    /// </summary>
                    [Description("Счётчик попыток исполнения")]
                    [SchemaMapperField(typeof(int), Where = true, Order = true, UpdateMode = SchemaMapperFieldUpdateMode.UpdateDirect)]
                    public static readonly Guid Count = new("B977888A-949E-41BA-B03D-21923DA14C11");

                    /// <summary>
                    /// ID календарного дня.
                    /// </summary>
                    [Description("ID календарного дня")]
                    [SchemaMapperField(typeof(long?), Where = true, Order = true)]
                    public static readonly Guid DayId = new("C7619271-30E8-4FF5-87A4-B264FF3A05BF");
                }
                #endregion
        */

        public static string GetDisplayName(Guid id)
        {
            return DisplayNames.TryGetValue(id, out var result) ? result : id.ToString();
        }
    }
}
