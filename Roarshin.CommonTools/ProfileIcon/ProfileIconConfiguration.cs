using System;

namespace Roarshin.CommonTools.ProfileIcon {
    
    public sealed class ProfileIconConfiguration : IProfileIconConfiguration {
        
        public string BaseUrl { get; set; }

        public string DefaultIcon { get; set; }

        public IProfileIconProvider ConcreteProvider { get; set; }

        public ProfileIconProviders Provider { get; }

        public ProfileIconConfiguration(ProfileIconProviders provider) {
            Provider = provider;

            switch (provider) {
                case ProfileIconProviders.Gravatar:
                    BaseUrl = ProfileIconConstants.GravatarBaseUrl;
                    DefaultIcon = ProfileIconConstants.GravatarDefaultIcon;
                    break;
                case ProfileIconProviders.RoboHash:
                    BaseUrl = ProfileIconConstants.RoboHashBaseUrl;
                    DefaultIcon = ProfileIconConstants.RoboHashDefaultIconSet;
                    break;
                case ProfileIconProviders.Custom:
                    BaseUrl = null;
                    DefaultIcon = null;
                    break;
                default:
                    throw new Exception($"Unknown Profile Icon Provider: '{provider}'");
                        
            }
        }
    }
}