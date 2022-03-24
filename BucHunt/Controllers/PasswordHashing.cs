using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace BucHunt.Controllers
{
    public static class PasswordHashing
    {

        /// <summary>Hashes the password for security.</summary>
        /// <param name="passwd">The password.</param>
        /// <returns>
        ///   The hashed and salted string <br />
        /// </returns>
        public static string HashPassword(string passwd)
        {
            byte[] salt;
            new RNGCryptoServiceProvider().GetBytes(salt = new byte[20]);

            var pbkdf2 = new Rfc2898DeriveBytes(passwd, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashedPW = new byte[40];
            Array.Copy(salt, 0, hashedPW, 0, 20);
            Array.Copy(hash, 0, hashedPW, 20, 40);

            return Convert.ToBase64String(hashedPW);
        }

        /// <summary>Checks inputted password to see if input is correct.</summary>
        /// <param name="TryPassWd">The attempted password.</param>
        /// <param name="hashPWD">The hashed password.</param>
        /// <returns>Returns to see if the attempted password is the correct one.</returns>
        public static bool CheckPassword(string TryPassWd, string hashPWD)
        {
            byte[] hashes = Convert.FromBase64String(hashPWD);
            byte[] salt = new byte[20];
            Array.Copy(hashes, 0, salt, 0, 20);

            var pbkdf2 = new Rfc2898DeriveBytes(TryPassWd, salt, 100000);
            byte[] hash = pbkdf2.GetBytes(20);

            for(int x = 0; x < 20; x++)
            {
                if (hashes[x + 20] != hash[x])
                    return false;
            }
            return true;

        }
    }
}