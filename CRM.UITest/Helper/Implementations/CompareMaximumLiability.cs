using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CompareMaximumLiability : ICompareMaximumLiability
    {
        public string GetMaximumLiability(double calculatedLiability, string thresholdLiability)
        {
            double thresholdMaximumLiability = 0;

            double.TryParse(thresholdLiability, out thresholdMaximumLiability);

            string maximumLiability = (calculatedLiability < thresholdMaximumLiability ?
                calculatedLiability.ToString("#0.00") : thresholdMaximumLiability.ToString("#0.00"));

            return maximumLiability;
        }
    }
}
