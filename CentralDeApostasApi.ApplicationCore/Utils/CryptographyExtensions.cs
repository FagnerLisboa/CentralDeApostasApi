using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace CentralDeApostasApi.Infrastructure.Configuration
{
    public static class CryptographyExtensions
    {

        // https://www.md5decrypt.org/

        public static string MD5Cryptography(this string text)
        {
            var x = new MD5CryptoServiceProvider();
            var bs = Encoding.UTF8.GetBytes(text);
            var s = new StringBuilder();

            bs = x.ComputeHash(bs);

            foreach (var b in bs)
                s.Append(b.ToString("x2").ToLower());

            return s.ToString();
        }

        public static string MD5decryption(this string text)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }

                return sBuilder.ToString();
            }
        }
    }
}
