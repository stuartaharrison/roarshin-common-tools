namespace Roarshin.CommonTools.Database.Providers {
    
    /// <inheritdoc cref="IDataStoreConfiguration" />
    public abstract class BaseDataStoreProvider : IDataStoreProvider {

        protected readonly string Password;

        /// <inheritdoc cref="IDataStoreConfiguration.Database" />
        public string Database { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Host" />
        public string Host { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Port" />
        public int Port { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Provider" />
        public DataProviders Provider { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Username" />
        public string Username { get; }
        
        /// <inheritdoc cref="IDataStoreProvider.GetConnectionString" />
        public virtual string GetConnectionString() {
            return string.Empty;
        }

        protected BaseDataStoreProvider(
            DataProviders provider,
            string host,
            int port,
            string database,
            string username,
            string password
        ) {
            Password = password;
            Database = database;
            Host = host;
            Port = port;
            Provider = provider;
            Username = username;
        }
    }
}