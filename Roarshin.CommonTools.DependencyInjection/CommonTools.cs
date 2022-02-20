using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Roarshin.CommonTools.ProfileIcon;
using Roarshin.CommonTools.ProfileIcon.Providers;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public static class CommonTools {
    
        public static IServiceCollection AddRoarshinCommonTools(this IServiceCollection services, Action<CommonToolsBuilder> config) {
            // get the registered options out so we can check what tools we want to enable
            var options = new CommonToolsBuilder();
            config.Invoke(options);

            // check for the data-provider
            if (options.DataStoreConfiguration != null) {
                services.RegisterDataStoreProvider(options.DataStoreConfiguration);
            }
            
            // check for profile icon provider configuration
            if (options.ProfileIconConfiguration != null) {
                services.RegisterProfileIconProvider(options.ProfileIconConfiguration);
            }

            return services;
        }
    }
}
