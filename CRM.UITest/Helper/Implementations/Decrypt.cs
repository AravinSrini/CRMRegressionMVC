using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class Decrypt : IDecrypt
    {
        private const string saltKey = "44-99-A5-AE-64-4F-B5-93-AA-A7-30-01-8E-30-A9-77";
        private const string guid = "22f14338-e0dd-4a20-903c-ce133c886ec3";

        public string StringDecryption(string decryptString)
        {
            byte[] results;
            UTF8Encoding encoding = new UTF8Encoding();

            using (MD5 hashProvider = new MD5CryptoServiceProvider())
            {
                // *** 
                // ***Generates the MD5 Hashed key
                // *** 
                IHashKey hashKey = new HashKey();
                string hashedApiKey = hashKey.GenerateHashKey(saltKey, guid);

                byte[] tdesKey = hashProvider.ComputeHash(encoding.GetBytes(hashedApiKey));
                TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider
                {
                    Key = tdesKey,
                    Mode = CipherMode.ECB,
                    Padding = PaddingMode.PKCS7
                };

                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();

                byte[] dataToDecrypt = Convert.FromBase64String(decryptString);

                results = decryptor.TransformFinalBlock(dataToDecrypt, 0, dataToDecrypt.Length);
            }

            return encoding.GetString(results);

        }
    }
}
