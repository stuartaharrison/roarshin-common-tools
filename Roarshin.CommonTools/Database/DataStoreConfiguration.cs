using System;

namespace Roarshin.CommonTools.Database {
    
    /// <inheritdoc cref="IDataStoreConfiguration" />
    public sealed class DataStoreConfiguration : IDataStoreConfiguration {

        /// <inheritdoc cref="IDataStoreConfiguration.Database" />
        public string Database { get; set; } = string.Empty;

        /// <inheritdoc cref="IDataStoreConfiguration.Host" />
        public string Host { get; set; } = "localhost";

        /// <inheritdoc cref="IDataStoreConfiguration.Password" />
        public string Password { get; set; } = string.Empty;
        
        /// <inheritdoc cref="IDataStoreConfiguration.Port" />
        public int Port { get; set; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Provider" />
        public DataProviders Provider { get; }

        /// <inheritdoc cref="IDataStoreConfiguration.Username" />
        public string Username { get; set; } = string.Empty;
        
        /// <summary>
        /// Assigns the default properties for MongoDB connection.
        /// </summary>
        private void ConstructMongoDbDefaults() {
            Port = DataStoreConstants.DefaultMongoDbPort;
        }

        /// <summary>
        /// Assigns the default properties for a MySQL connection.
        /// </summary>
        private void ConstructMySqlDefaults() {
            Port = DataStoreConstants.DefaultMySqlPort;
        }

        /// <summary>
        /// Assigns the default properties for a PostgresSQL connection.
        /// </summary>
        private void ConstructPostgresSqlDefaults() {
            Port = DataStoreConstants.DefaultPostgressSqlPort;
        }
        
        public DataStoreConfiguration(DataProviders provider) {
            // assign the provider (used to get the correct connection string)
            Provider = provider;
            
            // based on provider, assign the default values
            switch (provider) {
                case DataProviders.MongoDb:
                    ConstructMongoDbDefaults();
                    break;
                case DataProviders.MySql:
                    ConstructMySqlDefaults();
                    break;
                case DataProviders.PostgresSql:
                    ConstructPostgresSqlDefaults();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(provider), provider, null);
            }
        }
        
    }
}