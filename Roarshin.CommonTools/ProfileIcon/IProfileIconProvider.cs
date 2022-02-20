namespace Roarshin.CommonTools.ProfileIcon {
    
    public interface IProfileIconProvider {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <returns></returns>
        string GetIconUrl(string emailAddress);
    }
}
