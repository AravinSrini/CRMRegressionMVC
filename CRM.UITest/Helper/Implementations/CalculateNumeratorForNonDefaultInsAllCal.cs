using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CalculateNumeratorForNonDefaultInsAllCal : ICalculateNumeratorForNonDefaultInsAllCal
    {
        public int CalculateNumerator(int shipmentValue)
        {
            return (shipmentValue / 1000);
        }
    }
}
