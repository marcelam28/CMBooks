using System.Security.Cryptography;
using System.Text;

namespace CMBooks.Web.Helpers
{
    public class Md5Helper
    {
        private static string GetMd5Hash(byte[] data)
        {
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }

        public static string Hash(string data)
        {
            using (var md5 = MD5.Create())
                return GetMd5Hash(md5.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }

        public static bool VerifyPassword(string pass, string passHash)
        {
            if(string.IsNullOrWhiteSpace(pass) || string.IsNullOrWhiteSpace(passHash))
            {
                return false;
            }
            var hasshedPass = Hash(pass);
            return string.Equals(hasshedPass.ToLower(), passHash.ToLower());
        }
    }
}