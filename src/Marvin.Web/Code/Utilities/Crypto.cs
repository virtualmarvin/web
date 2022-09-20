using System.Security.Cryptography;
using System.Text;

namespace Marvin.Web
{
    // Collection of cryptographic methods

    public static class Crypto
    {
        // private key and initialization vector. use different ones in your own work. 
        private static readonly byte[] key = HexToBytes("C152AA1E5FC0EC53E84F30AAA46139EEBAFF8A9B7463DE5F");
        private static readonly byte[] iv = HexToBytes("3BB17E9111E4F651");

        private static readonly TripleDES des3;

        static Crypto()
        {
            des3 = TripleDES.Create();
            des3.Mode = CipherMode.CBC;
        }

        public static string? Encrypt(string data)
        {
            if (data == null) return null;

            byte[] bytes = Encoding.ASCII.GetBytes(data);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                des3.CreateEncryptor(key, iv), CryptoStreamMode.Write);

            encStream.Write(bytes, 0, bytes.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return BytesToHex(stream.ToArray());
        }

        public static string? Decrypt(string data)
        {
            if (data == null) return null;

            byte[] bytes = HexToBytes(data);

            var stream = new MemoryStream();
            var encStream = new CryptoStream(stream,
                des3.CreateDecryptor(key, iv), CryptoStreamMode.Write);

            encStream.Write(bytes, 0, bytes.Length);
            encStream.FlushFinalBlock();
            encStream.Close();

            return Encoding.ASCII.GetString(stream.ToArray());
        }

        public static string RandomString(int length)  // lowercase string
        {
            string c = "abcdefghjklmnopqrstuvwxyz0123456789";
            var random = new Random(Environment.TickCount);
            char[] chars = new char[length];

            for (int i = 0; i < length; i++)
            {
                chars[i] = c[(int)((c.Length) * random.NextDouble())];
            }

            return new string(chars);
        }

        #region Helpers

        public static byte[] HexToBytes(string hex)
        {
            byte[] bytes = new byte[hex.Length / 2];

            for (int i = 0; i < hex.Length / 2; i++)
            {
                string code = hex.Substring(i * 2, 2);
                bytes[i] = byte.Parse(code, System.Globalization.NumberStyles.HexNumber);
            }
            return bytes;
        }

        public static string BytesToHex(byte[] bytes)
        {
            var hex = new StringBuilder();

            for (int i = 0; i < bytes.Length; i++)
                hex.AppendFormat("{0:X2}", bytes[i]);

            return hex.ToString();
        }

        #endregion
    }
}
