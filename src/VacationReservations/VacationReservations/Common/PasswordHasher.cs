using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace VacationReservations.Common
{
    public static class PasswordHasher
    {
        private static SHA1Managed hasher = new SHA1Managed();
        public static string Hash(string password)
        {
            // convert password to byte array
            byte[] passwordBytes =
            System.Text.ASCIIEncoding.ASCII.GetBytes(password);
            // generate hash from byte array of password
            byte[] passwordHash = hasher.ComputeHash(passwordBytes);
            // convert hash to string
            return Convert.ToBase64String(passwordHash, 0, passwordHash.Length);
        }
    }
}