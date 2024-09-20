using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GenerateQuoteNumber
    {
        public string GetRandomQuoteNumber()
        {
            string newQuoteNumber = string.Empty;

            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            newQuoteNumber = "QTWB" + myRandomNo.ToString();

            return newQuoteNumber;
        }
    }
}
