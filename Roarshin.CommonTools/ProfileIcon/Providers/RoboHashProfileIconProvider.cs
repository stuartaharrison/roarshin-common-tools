using Roarshin.CommonTools.Helpers;

namespace Roarshin.CommonTools.ProfileIcon.Providers {
    
    public class RoboHashProfileIconProvider : IProfileIconProvider {

        public string BaseUrl { get; } = ProfileIconConstants.RoboHashBaseUrl;

        public string DefaultIconSet { get; } = ProfileIconConstants.RoboHashDefaultIconSet;

        public string GetIconUrl(string emailAddress) {
            var emailMd5 = Utils.GenerateMd5(emailAddress);
            var url = $"{BaseUrl}{emailMd5}.png";

            if (!string.IsNullOrWhiteSpace(DefaultIconSet)) {
                url += $"?set={DefaultIconSet}";
            }

            return url;
        }

        public RoboHashProfileIconProvider() { }

        public RoboHashProfileIconProvider(string defaultIconSet, string baseUrl) {
            BaseUrl = baseUrl;
            DefaultIconSet = defaultIconSet;
        }
    }
}
