using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class ConvertToTwoPlaceOfDecimal : IConvertToTwoPlaceOfDecimal
    {
        public string ConvertToTwoPlace(string value)
        {
            double values = 0.00;
            double.TryParse(value, out values);
            string convertedString = string.Format("{0:0.00}", values);

            return convertedString;
        }
    }
}
