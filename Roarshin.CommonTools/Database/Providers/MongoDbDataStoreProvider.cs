namespace Roarshin.CommonTools.Database.Providers {
    
    /// <inheritdoc cref="IDataStoreConfiguration" />
    public sealed class MongoDbDataStoreProvider : BaseDataStoreProvider {
        
        /// <inheritdoc cref="IDataStoreProvider.GetConnectionString" />
        public override string GetConnectionString() {
            if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password)) {
                return $"mongodb://{Username}:{Password}@{Host}:{Port}/{Database}";
            }
            else {
                return $"mongodb://{Host}:{Port}/{Database}";
            }
        }

        public MongoDbDataStoreProvider(
            DataProviders provider,
            string host,
            int port,
            string database,
            string username,
            string password
        ) : base(provider, host, port, database, username, password) { }
    }
}