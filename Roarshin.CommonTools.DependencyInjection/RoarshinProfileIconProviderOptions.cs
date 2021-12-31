namespace Roarshin.CommonTools.DependencyInjection {
    
    public interface IRoarshinProfileIconProviderOptions {
        string BaseUrl { get; }
        string DefaultIcon { get; }
        IProfileIconProvider ConcreteProvider { get; }
        ProfileIconProvider Provider { get; }
    }

    public sealed class RoarshinProfileIconProviderOptions : IRoarshinProfileIconProviderOptions {

        public string BaseUrl { get; set; } = null;

        public string DefaultIcon { get; set; } = null;

        public IProfileIconProvider ConcreteProvider { get; set; } = null;

        public ProfileIconProvider Provider { get; set; }
    }
}
