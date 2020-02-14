using PeTelecom.Modules.UserAccess.Application.Authentication;
using System;
using System.Security.Cryptography;

namespace PeTelecom.Modules.UserAccess.Infrastructure.Authentication
{
    public sealed class PasswordManager : IPasswordManager
    {
        private const int _saltByteSize = 24;
        private const int _hashByteSize = 24;
        private const int _hostingIterationsCount = 10101;

        private byte[] GenerateSalt()
        {
            using RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            byte[] salt = new byte[_saltByteSize];
            saltGenerator.GetBytes(salt);
            return salt;
        }

        private byte[] ComputeHash(string password, byte[] salt)
        {
            using Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(password, salt, _hostingIterationsCount);
            return hashGenerator.GetBytes(_hashByteSize);
        }

        public string HashPassword(string password)
        {
            var salt = GenerateSalt();
            var hash = ComputeHash(password, salt);

            byte[] hashBytes = new byte[_saltByteSize + _hashByteSize];
            Array.Copy(salt, 0, hashBytes, 0, _saltByteSize);
            Array.Copy(hash, 0, hashBytes, _saltByteSize, _hashByteSize);

            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string hashedPassword, string password)
        {
            var hashBytes = Convert.FromBase64String(hashedPassword);
            var salt = new byte[_saltByteSize];

            Array.Copy(hashBytes, 0, salt, 0, _saltByteSize);

            var hash = ComputeHash(password, salt);

            for (int i = 0; i < _hashByteSize; i++)
                if (hashBytes[i + _saltByteSize] != hash[i])
                    return false;

            return true;
        }
    }
}
