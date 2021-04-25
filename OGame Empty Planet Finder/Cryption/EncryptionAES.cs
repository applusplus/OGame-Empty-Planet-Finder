using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace OGameEmptyPlanetFinder.Cryption
{
    public class EncryptionAES
    {
        private static byte[] key = { 42, 217, 19, 16, 24, 26, 32, 45, 16, 184, 27, 162, 37, 112, 222, 209, 231, 6, 175, 144, 173, 53, 196, 16, 24, 26, 137, 218, 131, 236, 61, 209 };
        private static byte[] vector = { 21, 64, 191, 16, 23, 31, 254, 119, 231, 121, 132, 112, 79, 32, 114, 89 };
        private readonly ICryptoTransform encryptor;
        private readonly ICryptoTransform decryptor;
        private readonly UTF8Encoding encoder;

        public EncryptionAES()
        {
        RijndaelManaged rm = new RijndaelManaged();
        encryptor = rm.CreateEncryptor(key, vector);
        decryptor = rm.CreateDecryptor(key, vector);
        encoder = new UTF8Encoding();
        }

        public string Encrypt(string unencrypted)
        {
            return Convert.ToBase64String(Encrypt(encoder.GetBytes(unencrypted)));
        }

        public string Decrypt(string encrypted)
        {
            return encoder.GetString(Decrypt(Convert.FromBase64String(encrypted)));
        }

        public byte[] Encrypt(byte[] buffer)
        {
            return Transform(buffer, encryptor);
        }

        public byte[] Decrypt(byte[] buffer)
        {
            return Transform(buffer, decryptor);
        }

        protected byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }
            return stream.ToArray();
        }
    }
}
