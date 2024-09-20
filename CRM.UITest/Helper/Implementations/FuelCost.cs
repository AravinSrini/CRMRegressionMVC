using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class FuelCost : IFuelCost
    {
        private const string amountValue = "Amount";
        private readonly IElementNullCheck _elementNullCheck;

        public FuelCost(IElementNullCheck elementNullCheck)
        {
            _elementNullCheck = elementNullCheck;
        }

        public decimal GetFuelCost(XElement priceSheetElement)
        {
            decimal fuelCost = 0;
            if (priceSheetElement != null)
            {
                foreach (XElement charge in priceSheetElement.Elements("Charges").Elements("Charge"))
                {
                    if (charge.Element("Description").Value.ToUpper().Contains("FUE"))
                    {
                        decimal amount = 0;
                        decimal.TryParse(_elementNullCheck.ReadElementWithNullCheck(charge, amountValue), out amount);
                        fuelCost = amount;
                    }
                }
            }

            return fuelCost;
        }
    }
}
