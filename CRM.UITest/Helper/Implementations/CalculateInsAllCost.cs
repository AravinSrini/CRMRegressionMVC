using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CalculateInsAllCost : ICalculateInsAllCost
    {
        public int CalculateInsuredRates(int numerator)
        {
            int insuredRate = int.Parse(ConfigurationHelper.InsuredBaseCost) + (numerator - 1) * 10;

            return insuredRate;
        }
    }
}
