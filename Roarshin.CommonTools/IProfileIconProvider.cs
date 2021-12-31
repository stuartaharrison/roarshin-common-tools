namespace Roarshin.CommonTools {
    
    public enum ProfileIconProvider {
        Custom,
        Gravatar,
        RoboHash
    }

    public interface IProfileIconProvider {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        string GetIconUrl(string emailAddress);
    }
}
