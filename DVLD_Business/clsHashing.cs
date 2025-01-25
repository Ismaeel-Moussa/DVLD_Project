using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Business
{
    public class clsHashing
    {
        public static string ComputeHash(string Password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(Password));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();

            }
        }

        public static bool VerifyPassword(string EnteredPassword, string StoredHashPassword)
        {
            return clsHashing.ComputeHash(EnteredPassword) == StoredHashPassword;
        }
    }
}
