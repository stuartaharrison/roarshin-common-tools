using System;
using Microsoft.Extensions.DependencyInjection;
using Roarshin.CommonTools.Database;
using Roarshin.CommonTools.Database.Providers;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public static class DataStoreConfigurationExtensions {

        public static IServiceCollection RegisterDataStoreProvider(this IServiceCollection services, IDataStoreConfiguration configuration) {
            switch (configuration.Provider) {
                case DataProviders.MongoDb:
                    services.AddSingleton<IDataStoreProvider, MongoDbDataStoreProvider>(
                        _ => new MongoDbDataStoreProvider(
                            configuration.Provider,
                            configuration.Host,
                            configuration.Port,
                            configuration.Database,
                            configuration.Username,
                            configuration.Password
                        )
                    );
                    break;
                case DataProviders.MySql:
                    services.AddSingleton<IDataStoreProvider, MySqlDataStoreProvider>(
                        _ => new MySqlDataStoreProvider(
                            configuration.Provider,
                            configuration.Host,
                            configuration.Port,
                            configuration.Database,
                            configuration.Username,
                            configuration.Password
                        )
                    );
                    break;
                case DataProviders.PostgresSql:
                    services.AddSingleton<IDataStoreProvider, PostgresSqlDataStoreProvider>(
                        _ => new PostgresSqlDataStoreProvider(
                            configuration.Provider,
                            configuration.Host,
                            configuration.Port,
                            configuration.Database,
                            configuration.Username,
                            configuration.Password
                        )
                    );
                    break;
                default:
                    throw new Exception($"Unknown Data Provider: '{configuration.Provider}'");
            }

            return services;
        }
    }
}