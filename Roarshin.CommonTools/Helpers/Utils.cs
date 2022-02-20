using System.Security.Cryptography;
using System.Text;

namespace Roarshin.CommonTools.Helpers {
    
    internal static class Utils {

        public static string GenerateMd5(string value) {
            using var md5 = MD5.Create();

            var emailToEncrypt = value.Trim().ToLower();
            var inputBytes = Encoding.ASCII.GetBytes(emailToEncrypt);
            var hashBytes = md5.ComputeHash(inputBytes);

            // Convert the byte array to hexadecimal string
            var sb = new StringBuilder();
            foreach (var t in hashBytes) {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
