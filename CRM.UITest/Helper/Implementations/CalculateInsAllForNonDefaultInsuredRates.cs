using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class CalculateInsAllForNonDefaultInsuredRates : ICalculateInsAllForNonDefaultInsuredRates
    {
        private readonly ICalculateNumeratorForNonDefaultInsAllCal _calculateNumeratorForNonDefaultInsAllCal;
        private readonly ICalculateInsAllCost _calculateInsAllCost;

        public CalculateInsAllForNonDefaultInsuredRates(ICalculateNumeratorForNonDefaultInsAllCal calculateNumeratorForNonDefaultInsAllCal, ICalculateInsAllCost calculateInsAllCost)
        {
            _calculateNumeratorForNonDefaultInsAllCal = calculateNumeratorForNonDefaultInsAllCal;
            _calculateInsAllCost = calculateInsAllCost;
        }

        public decimal NonDefaultInsAllCalculation(double shipmentvalue)
        {
            decimal insAllCost = 0;
            if (shipmentvalue <= 500)
            {
                insAllCost = Convert.ToDecimal("8.00");
            }
            else if (shipmentvalue <= 750)
            {
                insAllCost = Convert.ToDecimal("11.00");
            }
            else if (shipmentvalue <= 1000)
            {
                insAllCost = Convert.ToDecimal("11.20");
            }
            else if (shipmentvalue <= 1500)
            {
                insAllCost = Convert.ToDecimal("14.25");
            }
            else if (shipmentvalue <= 2000)
            {
                insAllCost = Convert.ToDecimal("19.00");
            }
            else if (shipmentvalue <= 2500)
            {
                insAllCost = Convert.ToDecimal("23.75");
            }
            else if (shipmentvalue <= 3000)
            {
                insAllCost = Convert.ToDecimal("28.50");
            }
            else if (shipmentvalue <= 5000)
            {
                insAllCost = Convert.ToDecimal("37.50");
            }
            else if (shipmentvalue <= 7000)
            {
                insAllCost = Convert.ToDecimal("45.50");
            }
            else if (shipmentvalue <= 10000)
            {
                insAllCost = Convert.ToDecimal("65.00");
            }
            else if (shipmentvalue <= 15000)
            {
                insAllCost = Convert.ToDecimal("90.00");
            }
            else if (shipmentvalue <= 20000)
            {
                insAllCost = Convert.ToDecimal("110.00");
            }
            else if (shipmentvalue <= 25000)
            {
                insAllCost = Convert.ToDecimal("137.50");
            }
            else if (shipmentvalue <= 30000)
            {
                insAllCost = Convert.ToDecimal("150.00");
            }
            else if (shipmentvalue > 30000)
            {
                insAllCost = Convert.ToDecimal("150.00");
            }

            return insAllCost;
        }
    }
}
