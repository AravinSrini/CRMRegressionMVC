using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    class DecodeToBase64 : IDecodeToBase64
    {
        public string DecodeBase64String(string priceSheet)
        {
            string returnValue = string.Empty;

            if (!string.IsNullOrWhiteSpace(priceSheet))
            {
                byte[] encodedDataAsBytes = Convert.FromBase64String(priceSheet);
                returnValue = Encoding.UTF8.GetString(encodedDataAsBytes);
            }

            return returnValue;
        }
    }
}
