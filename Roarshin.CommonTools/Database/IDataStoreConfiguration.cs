namespace Roarshin.CommonTools.Database {
    
    /// <summary>
    /// Provider that returns a connection string for the configured data-store provider.
    /// </summary>
    public interface IDataStoreConfiguration {
        
        /// <summary>
        /// The name of the database/data-collection to connect too.
        /// </summary>
        string Database { get; }
        
        /// <summary>
        /// The ipv4 address or label that points to the data source/provider.
        /// </summary>
        string Host { get; }
        
        /// <summary>
        /// The password to use alongside the 'Username' when authenticating against the data source/provider.
        /// </summary>
        string Password { get; }
        
        /// <summary>
        /// The specific port that the data source/provider hosts is listening on.
        /// </summary>
        int Port { get; }
        
        /// <summary>
        /// The type of Provider being used for the Microservice.
        /// </summary>
        DataProviders Provider { get; }
        
        /// <summary>
        /// The username to use in authentication against the data source/provider.
        /// </summary>
        string Username { get; }
    }
}