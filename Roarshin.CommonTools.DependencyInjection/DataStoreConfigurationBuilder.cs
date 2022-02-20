using Microsoft.Extensions.Configuration;
using Roarshin.CommonTools.Database;

namespace Roarshin.CommonTools.DependencyInjection {

    internal static class DataStoreConfigurationConstants {

        public const string DatabaseConfigurationKey = "DB_DATABASE";

        public const string HostConfigurationKey = "DB_HOST";

        public const string PasswordConfigurationKey = "DB_PASSWORD";

        public const string PortConfigurationKey = "DB_PORT";

        public const string UsernameConfigurationKey = "DB_USER";
    }
    
    /// <summary>
    /// Builder for building up a 'IDataStoreConfiguration' object that instructs the project to inject an
    /// IDataStoreProvider singleton.
    /// </summary>
    public sealed class DataStoreConfigurationBuilder {
        
        private readonly DataStoreConfiguration _dataStoreConfiguration;

        /// <summary>
        /// Builds the 'IDataStoreConfiguration' options that is used by the Service Engine to setup how the data
        /// store provider should be configured and a connection string displayed.
        /// </summary>
        /// <returns></returns>
        public IDataStoreConfiguration Build() {
            return _dataStoreConfiguration;
        }

        /// <summary>
        /// Set the name of the database/data-collection to connect too.
        /// </summary>
        /// <param name="database">Database name</param>
        public void Database(string database) {
            _dataStoreConfiguration.Database = database;
        }
        
        /// <summary>
        /// Set the host label or ipv4 address.
        /// </summary>
        /// <param name="host"></param>
        public void Host(string host) {
            _dataStoreConfiguration.Host = host;
        }

        /// <summary>
        /// Set the password for the database/data-collection login.
        /// </summary>
        /// <param name="password"></param>
        public void Password(string password) {
            _dataStoreConfiguration.Password = password;
        }
        
        /// <summary>
        /// Set the port that the data-source host is listening on.
        /// </summary>
        /// <param name="port"></param>
        public void Port(int port) {
            _dataStoreConfiguration.Port = port;
        }

        /// <summary>
        /// Set the username for the database/data-collection login.
        /// </summary>
        /// <param name="username"></param>
        public void Username(string username) {
            _dataStoreConfiguration.Username = username;
        }

        /// <summary>
        /// Sets the Database, Host, Password, Port and Username values using the Net Core WebAPI IConfiguration section
        /// which looks at the AppSettings.{*}.json file and/or environment variables.
        /// </summary>
        /// <param name="configuration"></param>
        public void WithConfiguration(IConfiguration configuration) {
            _dataStoreConfiguration.Database =
                configuration.GetSection(DataStoreConfigurationConstants.DatabaseConfigurationKey).Value;

            _dataStoreConfiguration.Host =
                configuration.GetSection(DataStoreConfigurationConstants.HostConfigurationKey).Value;

            _dataStoreConfiguration.Password =
                configuration.GetSection(DataStoreConfigurationConstants.PasswordConfigurationKey).Value;

            _dataStoreConfiguration.Port =
                int.Parse(configuration.GetSection(DataStoreConfigurationConstants.PortConfigurationKey).Value);

            _dataStoreConfiguration.Username =
                configuration.GetSection(DataStoreConfigurationConstants.UsernameConfigurationKey).Value;
        }
        
        public DataStoreConfigurationBuilder(DataProviders provider) {
            _dataStoreConfiguration = new DataStoreConfiguration(provider);
        }
    }
}