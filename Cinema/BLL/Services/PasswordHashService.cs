using BLL.Interfaces;
using System.Security.Cryptography;

namespace BLL.Services
{
    public class PasswordHashService : IPasswordHashService
    {
        private const int _saltSize = 64;
        private const int _keySize = 64;
        private const int _iterations = 50000;
        private readonly HashAlgorithmName _algorithm = HashAlgorithmName.SHA512;

        private const char segmentDelimiter = ':';

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(_saltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                _iterations,
                _algorithm,
                _keySize
            );

            return string.Join(
                segmentDelimiter,
                Convert.ToHexString(hash),
                Convert.ToHexString(salt),
                _iterations,
                _algorithm
            );
        }

        public bool Verify(string password, string passwordHash)
        {
            string[] segments = passwordHash.Split(segmentDelimiter);
            byte[] hash = Convert.FromHexString(segments[0]);
            byte[] salt = Convert.FromHexString(segments[1]);
            int iterations = int.Parse(segments[2]);
            HashAlgorithmName algorithm = new HashAlgorithmName(segments[3]);

            byte[] compareHash = Rfc2898DeriveBytes.Pbkdf2(
                password,
                salt,
                iterations,
                algorithm,
                hash.Length
            );

            return CryptographicOperations.FixedTimeEquals(compareHash, hash);
        }
    }
}
