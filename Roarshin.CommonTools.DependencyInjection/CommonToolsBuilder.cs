using System;
using Roarshin.CommonTools.Database;
using Roarshin.CommonTools.ProfileIcon;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public sealed class CommonToolsBuilder {

        private DataStoreConfigurationBuilder _dataStoreConfigurationBuilder = null;
        private ProfileIconProviderBuilder _profileIconProviderBuilder = null;

        public IDataStoreConfiguration DataStoreConfiguration => _dataStoreConfigurationBuilder?.Build();

        public IProfileIconConfiguration ProfileIconConfiguration => _profileIconProviderBuilder?.Build();
        
        public void AddDataProvider(DataProviders provider, Action<DataStoreConfigurationBuilder> builder) {
            _dataStoreConfigurationBuilder = new DataStoreConfigurationBuilder(provider);
            builder.Invoke(_dataStoreConfigurationBuilder);
        }

        public void AddProfileIconProvider() {
            _profileIconProviderBuilder = new ProfileIconProviderBuilder(ProfileIconProviders.Gravatar);
        }

        public void AddProfileIconProvider(ProfileIconProviders provider) {
            _profileIconProviderBuilder = new ProfileIconProviderBuilder(provider);
        }
        
        public void AddProfileIconProvider<T>(Func<T> cfg) where T : class, IProfileIconProvider {
            _profileIconProviderBuilder = new ProfileIconProviderBuilder(ProfileIconProviders.Custom);

            IProfileIconProvider provider = cfg.Invoke();
            _profileIconProviderBuilder.RegisterProvider(provider);
        }
    }
}
