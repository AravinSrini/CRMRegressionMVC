using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CalculateMaximumLiabilityCoverage : ICalculateMaximumLiabilityCoverage
    {
        public double CalculateMaximumLiability(double weight, string costPerPound)
        {
            double rate = 0;
            double calculateLiability = 0;

            double.TryParse(costPerPound, out rate);
            calculateLiability = weight * rate;

            return calculateLiability;
        }
    }
}
