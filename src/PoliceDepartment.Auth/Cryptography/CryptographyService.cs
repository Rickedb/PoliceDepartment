using PoliceDepartment.Domain.Interfaces.Services;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PoliceDepartment.Auth.Cryptography
{
    public class CryptographyService : ICryptographyService
    {
        private readonly Rijndael _algorithm;

        public CryptographyService(CryptographyOptions options)
        {
            _algorithm = CreateAlgorithmInstance(options.Key, options.InitializationVector);
        }

        public async Task<string> EncryptAsync(string value)
        {
            if(string.IsNullOrEmpty(value))
            {
                return value;
            }

            var encryptor = _algorithm.CreateEncryptor(_algorithm.Key, _algorithm.IV);
            using var memoryStream = new MemoryStream();
            using (var csStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                using var writer = new StreamWriter(csStream);
                await writer.WriteAsync(value);
            }

            var bytes = memoryStream.ToArray();
            return ConvertByteArrayToHexString(bytes);
        }

        public async Task<string> DecryptAsync(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return value;
            }

            if (value.Length % 2 != 0)
            {
                throw new ArgumentException("Invalid string for decryption", value);
            }

            var decryptor = _algorithm.CreateDecryptor(_algorithm.Key, _algorithm.IV);
            var bytes = ConvertHexStringToByteArray(value);

            using var memoryStream = new MemoryStream(bytes);
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            using var reader = new StreamReader(cryptoStream);
            return await reader.ReadToEndAsync();
        }

        private Rijndael CreateAlgorithmInstance(string key, string initializationVector)
        {
            if (string.IsNullOrEmpty(key) || (key.Length != 16 && key.Length != 24 && key.Length != 32))
            {
                throw new ArgumentException("Cryptography key must have 16, 24 or 32 characters.", key);
            }

            if (string.IsNullOrEmpty(initializationVector) || initializationVector.Length != 16)
            {
                throw new ArgumentException("Initialization Vector must have 16 characters.", initializationVector);
            }

            var algorithm = Rijndael.Create();
            algorithm.Key = Encoding.ASCII.GetBytes(key);
            algorithm.IV = Encoding.ASCII.GetBytes(initializationVector);

            return algorithm;
        }

        private string ConvertByteArrayToHexString(byte[] value)
        {
            var hexArray = Array.ConvertAll(value, b => b.ToString("X2"));
            return string.Concat(hexArray);
        }

        private byte[] ConvertHexStringToByteArray(string value)
        {
            var totalEncryptedBytes = value.Length / 2;
            var encryptedBytes = new byte[totalEncryptedBytes];
            for (var i = 0; i < totalEncryptedBytes; i++)
            {
                encryptedBytes[i] = Convert.ToByte(value.Substring(i * 2, 2), 16);
            }

            return encryptedBytes;
        }

        public void Dispose()
        {
            _algorithm.Dispose();
        }
    }
}
