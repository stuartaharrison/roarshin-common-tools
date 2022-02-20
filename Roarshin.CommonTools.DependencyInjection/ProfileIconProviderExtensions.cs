using System;
using Microsoft.Extensions.DependencyInjection;
using Roarshin.CommonTools.ProfileIcon;
using Roarshin.CommonTools.ProfileIcon.Providers;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public static class ProfileIconProviderExtensions {

        public static IServiceCollection RegisterProfileIconProvider(this IServiceCollection services, IProfileIconConfiguration configuration) {

            switch (configuration.Provider) {
                case ProfileIconProviders.Custom:
                    if (configuration.ConcreteProvider is null) {
                        throw new Exception("Unable to register custom Profile Icon Provider. Concrete definition is not set.");
                    }
                    
                    services.AddSingleton(_ => configuration.ConcreteProvider);
                    break;
                case ProfileIconProviders.Gravatar:
                    services.AddSingleton<IProfileIconProvider, GravatarProfileIconProvider>(
                        _ => new GravatarProfileIconProvider(
                            configuration.DefaultIcon, 
                            configuration.BaseUrl
                        )
                    );
                    break;
                case ProfileIconProviders.RoboHash:
                    services.AddSingleton<IProfileIconProvider, RoboHashProfileIconProvider>(
                        _ => new RoboHashProfileIconProvider(
                            configuration.DefaultIcon, 
                            configuration.BaseUrl
                        )
                    );
                    break;
                default:
                    throw new Exception($"Unknown Profile Icon Provider: '{configuration.Provider}'");
            }
            
            return services;
        }
    }
}