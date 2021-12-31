using System;

namespace Roarshin.CommonTools.DependencyInjection {
    
    public sealed class RoarshinCommonToolOptions {

        private RoarshinProfileIconProviderOptions _profileIconProviderOptions = new();

        public bool IsProfileIconProviderEnabled { get; private set; } = false;

        public IRoarshinProfileIconProviderOptions ProfileIconProviderOptions { get { return _profileIconProviderOptions; } }

        public void EnableGravatarProfileIconProvider(string defaultIcon = Constants.GravatarDefaultIcon, string baseUrl = Constants.GravatarBaseUrl) {
            IsProfileIconProviderEnabled = true;
            _profileIconProviderOptions.BaseUrl = baseUrl;
            _profileIconProviderOptions.DefaultIcon = defaultIcon;
            _profileIconProviderOptions.Provider = ProfileIconProvider.Gravatar;
        }

        public void EnableProfileIconProvider<T>(Func<T> cfg) where T : class, IProfileIconProvider {
            IsProfileIconProviderEnabled = true;
            _profileIconProviderOptions.ConcreteProvider = cfg.Invoke();
            _profileIconProviderOptions.Provider = ProfileIconProvider.Custom;
        }

        public void EnableRoboHashProfileIconProvider(string defaultIconSet = Constants.RoboHashDefaultIconSet, string baseUrl = Constants.RoboHashBaseUrl) {
            IsProfileIconProviderEnabled = true;
            _profileIconProviderOptions.BaseUrl = baseUrl;
            _profileIconProviderOptions.DefaultIcon = defaultIconSet;
            _profileIconProviderOptions.Provider = ProfileIconProvider.RoboHash;
        }
    }
}
