namespace Roarshin.CommonTools.ProfileIconProviders {
    
    public class RoboHashProfileIconProvider : IProfileIconProvider {

        public string BaseUrl { get; protected set; } = Constants.RoboHashBaseUrl;

        public string DefaultIconSet { get; protected set; } = Constants.RoboHashDefaultIconSet;

        public string GetIconUrl(string emailAddress) {
            var emailMD5 = Utils.GenerateMd5(emailAddress);
            var url = $"{BaseUrl}{emailMD5}.png";

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
