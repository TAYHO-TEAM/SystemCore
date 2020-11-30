using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace Services.Common.Security
{
    public class Cryptography
    {
        private static string _hmac_sha256_secretkey_default = null;

        public static string EncryptWithPublic(string pCleartext)
        {
            RSACryptoServiceProvider rsaCryp = new RSACryptoServiceProvider();
            rsaCryp.FromXmlString(KeyEncrypt.PUBLIC_KEY_XML);

            byte[] plainbytes = Encoding.Unicode.GetBytes(pCleartext);
            byte[] cipherbytes = rsaCryp.Encrypt(plainbytes, false);

            return Convert.ToBase64String(cipherbytes);
        }

        public static string Sha256(string data, string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                key = _hmac_sha256_secretkey_default;
            }
            byte[] keyByte = Encoding.UTF8.GetBytes(key);
            byte[] messageBytes = Encoding.UTF8.GetBytes(data);
            using (var hmacsha256 = new HMACSHA256(keyByte))
            {
                byte[] hashmessage = hmacsha256.ComputeHash(messageBytes);
                string hex = BitConverter.ToString(hashmessage);
                hex = hex.Replace("-", "").ToLower();
                return hex;
            }
        }

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system !");
        }
    }
}