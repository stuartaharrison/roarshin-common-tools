using Microsoft.Extensions.DependencyInjection;
using Roarshin.CommonTools.ProfileIconProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public static class Extensions {
    
        public static IServiceCollection AddRoarshinCommonTools(this IServiceCollection services, Action<RoarshinCommonToolOptions> config) {
            // register the RoarshinCommonToolOptions configuration/options
            services.Configure(config);

            // get the registered options out so we can check what tools we want to enable
            var options = new RoarshinCommonToolOptions();
            config.Invoke(options);

            if (options.IsProfileIconProviderEnabled) {
                switch (options.ProfileIconProviderOptions.Provider) {
                    case ProfileIconProvider.Custom:
                        services.AddSingleton(cfg => {
                            return options.ProfileIconProviderOptions.ConcreteProvider;
                        });
                        break;
                    case ProfileIconProvider.Gravatar:
                        services.AddSingleton<IProfileIconProvider, GravatarProfileIconProvider>(cfg => {
                            return new GravatarProfileIconProvider(options.ProfileIconProviderOptions.DefaultIcon, options.ProfileIconProviderOptions.BaseUrl);
                        });
                        break;
                    case ProfileIconProvider.RoboHash:
                        services.AddSingleton<IProfileIconProvider, RoboHashProfileIconProvider>(cfg => {
                            return new RoboHashProfileIconProvider(options.ProfileIconProviderOptions.DefaultIcon, options.ProfileIconProviderOptions.BaseUrl);
                        });
                        break;
                    default:
                        throw new Exception($"Invalid Profile Icon Provider Type: '{options.ProfileIconProviderOptions.Provider}'");
                }
            }

            return services;
        }
    }
}
