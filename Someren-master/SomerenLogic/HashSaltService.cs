using SomerenDAL;
using SomerenModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SomerenLogic
{
    public class HashSaltService
    {

        // creates hash and salt from the password
        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            byte[] saltBytes = new byte[size];
            RNGCryptoServiceProvider provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltBytes);
            string salt = Convert.ToBase64String(saltBytes);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, 10000);
            string hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }

        // checks if the given password is the same as the hashsalt password from the datbase
        public static bool VerifyPassword(string enteredPassword, string storedHash, string storedSalt)
        {
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == storedHash;
        }



    }
}
