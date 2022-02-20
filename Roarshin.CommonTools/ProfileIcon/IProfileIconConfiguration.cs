namespace Roarshin.CommonTools.ProfileIcon {
    
    public interface IProfileIconConfiguration {
        string BaseUrl { get; }
        string DefaultIcon { get; }
        ProfileIconProviders Provider { get; }
        IProfileIconProvider ConcreteProvider { get; }
    }
}