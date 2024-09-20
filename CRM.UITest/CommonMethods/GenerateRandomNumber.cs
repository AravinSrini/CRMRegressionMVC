using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GenerateRandomNumber
    {
        public string Randomnumber(string value)
        {
            string textWithrandomNumber = string.Empty;

            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            textWithrandomNumber = value + myRandomNo.ToString();

            return textWithrandomNumber;
        }
    }
}