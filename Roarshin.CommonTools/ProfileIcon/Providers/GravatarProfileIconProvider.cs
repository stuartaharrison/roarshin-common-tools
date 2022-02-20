using Roarshin.CommonTools.Helpers;

namespace Roarshin.CommonTools.ProfileIcon.Providers {
    
    public class GravatarProfileIconProvider : IProfileIconProvider {

        public string BaseUrl { get; } = ProfileIconConstants.GravatarBaseUrl;

        public string DefaultIcon { get; } = ProfileIconConstants.GravatarDefaultIcon;

        public string GetIconUrl(string emailAddress) {
            var emailMd5 = Utils.GenerateMd5(emailAddress);
            var url = $"{BaseUrl}{emailMd5}";

            if (!string.IsNullOrWhiteSpace(DefaultIcon)) {
                url += $"?d={DefaultIcon}";
            }

            return url;
        }

        public GravatarProfileIconProvider() { }

        public GravatarProfileIconProvider(string defaultIcon, string baseUrl) {
            BaseUrl = baseUrl;
            DefaultIcon = defaultIcon;
        }
    }
}
