using System.Security.Cryptography;
using System.Text;

namespace Roarshin.CommonTools.ProfileIconProviders {
    
    public class GravatarProfileIconProvider : IProfileIconProvider {

        public string BaseUrl { get; protected set; } = Constants.GravatarBaseUrl;

        public string DefaultIcon { get; protected set; } = Constants.GravatarDefaultIcon;

        public string GetIconUrl(string emailAddress) {
            var emailMD5 = Utils.GenerateMd5(emailAddress);
            var url = $"{BaseUrl}{emailMD5}";

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
