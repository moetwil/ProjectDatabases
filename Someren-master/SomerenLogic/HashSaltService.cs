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
        public static HashSalt GenerateSaltedHash(int length, string password)
        {
            byte[] saltInBytes = new byte[length];
            RNGCryptoServiceProvider converter = new RNGCryptoServiceProvider();
            converter.GetNonZeroBytes(saltInBytes);
            string salt = Convert.ToBase64String(saltInBytes);

            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltInBytes, 10000);
            string hashPassword = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            HashSalt hashSalt = new HashSalt(hashPassword, salt);
            return hashSalt;
        }

        // checks if the given password is the same as the hashsalt password from the datbase
        public  bool VerifyPassword(string enteredPassword, HashSalt hashSalt)
        {
            byte[] saltInBytes = Convert.FromBase64String(hashSalt.Salt);
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(enteredPassword, saltInBytes, 10000);
            return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256)) == hashSalt.Hash;
        }



    }
}
