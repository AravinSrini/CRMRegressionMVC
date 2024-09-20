using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class HashKey : IHashKey
    {
        public string GenerateHashKey(string salt, string apiKey)
        {
            string returnValue;

            // *** 
            // *** MD5 Cryptography hashing mechanism
            // *** 
            using (MD5 cryptographyProvider = new MD5CryptoServiceProvider())
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(apiKey);
                byte[] saltBytes = Encoding.UTF8.GetBytes(salt);
                byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

                // *** 
                // *** Copy the plain text bytes into the resulting array
                // *** 
                for (int i = 0; i < plainTextBytes.Length; i++)
                {
                    plainTextWithSaltBytes[i] = plainTextBytes[i];
                }

                // *** 
                // *** Appending the salt bytes to the resulting array
                // *** 
                for (int i = 0; i < saltBytes.Length; i++)
                {
                    plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
                }

                // *** 
                // *** Get the Hashed ApiKey
                // *** 
                byte[] hashedApiKey = cryptographyProvider.ComputeHash(plainTextWithSaltBytes);

                returnValue = BitConverter.ToString(hashedApiKey);
            }

            return returnValue;
        }
    }
}
