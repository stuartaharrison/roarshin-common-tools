namespace Roarshin.CommonTools.Database {
    
    /// <inheritdoc cref="IDataStoreConfiguration" />
    public interface IDataStoreProvider {
        
        /// <inheritdoc cref="IDataStoreConfiguration.Database" />
        string Database { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Host" />
        string Host { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Port" />
        int Port { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Provider" />
        DataProviders Provider { get; }
        
        /// <inheritdoc cref="IDataStoreConfiguration.Username" />
        string Username { get; }

        /// <summary>
        /// Creates a connection string value that is valid based on the chosen data provider.
        /// </summary>
        /// <returns>connection string</returns>
        string GetConnectionString();
    }
}