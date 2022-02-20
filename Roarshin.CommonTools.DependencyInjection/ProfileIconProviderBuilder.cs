using Roarshin.CommonTools.ProfileIcon;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public sealed class ProfileIconProviderBuilder {

        private readonly ProfileIconConfiguration _profileIconConfiguration;

        public IProfileIconConfiguration Build() {
            return _profileIconConfiguration;
        }

        public void BaseUrl(string baseUrl) {
            _profileIconConfiguration.BaseUrl = baseUrl;
        }

        public void DefaultIcon(string defaultIcon) {
            _profileIconConfiguration.DefaultIcon = defaultIcon;
        }

        public void RegisterProvider<T>(T provider) where T : class, IProfileIconProvider {
            _profileIconConfiguration.ConcreteProvider = provider;
        }

        public ProfileIconProviderBuilder(ProfileIconProviders provider) {
            _profileIconConfiguration = new ProfileIconConfiguration(provider);
        }
    }
}
