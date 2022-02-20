namespace Roarshin.CommonTools.Database.Providers {
    
    /// <inheritdoc cref="IDataStoreConfiguration" />
    public sealed class MySqlDataStoreProvider : BaseDataStoreProvider {
        
        /// <inheritdoc cref="IDataStoreProvider.GetConnectionString" />
        public override string GetConnectionString() {
            return $"Server={Host};Port={Port};Database={Database};Uid={Username};Pwd={Password};";
        }
        
        public MySqlDataStoreProvider(
            DataProviders provider,
            string host,
            int port,
            string database,
            string username,
            string password
        ) : base(provider, host, port, database, username, password) { }
    }
}