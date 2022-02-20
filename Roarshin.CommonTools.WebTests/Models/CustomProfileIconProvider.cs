using System.Security.Cryptography;
using System.Text;
using Roarshin.CommonTools.ProfileIcon;

namespace Roarshin.CommonTools.WebTests.Models {

    public class CustomProfileIconProvider : IProfileIconProvider {

        private readonly string _baseUrl = "https://avatars.dicebear.com/api";
        private readonly string _defaultIconSet = "avataaars";

        public string GetIconUrl(string emailAddress) {
            var emailMD5 = GenerateMd5(emailAddress);
            return $"{_baseUrl}/{_defaultIconSet}/{emailMD5}.svg";
        }

        private static string GenerateMd5(string value) {
            using var md5 = MD5.Create();

            var emailToEncrypt = value.Trim().ToLower();
            byte[] inputBytes = Encoding.ASCII.GetBytes(emailToEncrypt);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            var sb = new StringBuilder();
            for (int i = 0; i < hashBytes.Length; i++) {
                sb.Append(hashBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
