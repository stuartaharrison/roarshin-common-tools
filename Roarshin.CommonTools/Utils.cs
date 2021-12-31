using System.Security.Cryptography;
using System.Text;

namespace Roarshin.CommonTools {
    
    internal static class Utils {

        public static string GenerateMd5(string value) {
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
