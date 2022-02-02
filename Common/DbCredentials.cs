using ShtrihM.Wattle3.Testing;

namespace ShtrihM.Wattle3.Examples.Common
{
    /// <summary>
    /// Параметры учётных записей подключения к БД.
    /// </summary>
    public static class DbCredentials
    {
        /// <summary>
        /// Пример реестра Windows.
        /// </summary>
        public static readonly string RegistryFile = @"Windows Registry Editor Version 5.00

[HKEY_LOCAL_MACHINE\SOFTWARE\Shtrih-M\Testing]
""PostgreSqlUserID""=""postgres""
""PostgreSqlPassword""=""PostgreSqlPassword""
""SqlServerUserID""=""sa""
""SqlServerPassword""=""SqlServerPassword""
""SqlServerAdress""=""localhost""
""PostgreSqlAdress""=""localhost""

[HKEY_LOCAL_MACHINE\SOFTWARE\WOW6432Node\Shtrih-M\Testing]
""PostgreSqlUserID""=""postgres""
""PostgreSqlPassword""=""PostgreSqlPassword""
""SqlServerUserID""=""sa""
""SqlServerPassword""=""SqlServerPassword""
""SqlServerAdress""=""localhost""
""PostgreSqlAdress""=""localhost""";

        /// <summary>
        /// Адрес сервера с SQL Server.
        /// По умолчанию адрес читается из реестра Windows;
        /// Пример реестра Windows <see cref="RegistryFile"/>.
        /// </summary>
        public static bool TryGetServerAdressForSqlServer(out string serverAdress)
        {
            /*
            serverAdress = "localhost";

            return true;
            */

            var result = WindowsRegistryHelpers.SqlServerTryGetServerAdress(out serverAdress);

            return result;
        }

        /// <summary>
        /// Адрес сервера с PostgreSQL.
        /// По умолчанию адрес читается из реестра Windows;
        /// Пример реестра Windows <see cref="RegistryFile"/>.
        /// </summary>
        public static bool TryGetServerAdressForPostgreSql(out string serverAdress)
        {
            /*
            serverAdress = "localhost";

            return true;
            */

            var result = WindowsRegistryHelpers.PostgreSqlTryGetServerAdress(out serverAdress);

            return result;
        }

        /// <summary>
        /// Параметры учётной записи подключения к SQL Server.
        /// По умолчанию параметры читаются из реестра Windows;
        /// Пример реестра Windows <see cref="RegistryFile"/>.
        /// </summary>
        public static bool TryGetCredentialsForSqlServer(out (string UserName, string UserPassword) credentials)
        {
            /*
            credentials = ("sa", "password");

            return true;
            */

            var result = WindowsRegistryHelpers.SqlServerTryGetUserCredentials(out credentials);

            return result;
        }

        /// <summary>
        /// Параметры учётной записи подключения к PostgreSQL.
        /// По умолчанию параметры читаются из реестра Windows;
        /// Пример реестра Windows <see cref="RegistryFile"/>.
        /// </summary>
        public static bool TryGetCredentialsForPostgreSql(out (string UserName, string UserPassword) credentials)
        {
            /*
            credentials = ("postgres", "password");

            return true;
            */

            var result = WindowsRegistryHelpers.PostgreSqlTryGetUserCredentials(out credentials);

            return result;
        }
    }
}
