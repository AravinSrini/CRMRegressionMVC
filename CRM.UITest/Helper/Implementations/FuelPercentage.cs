using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class FuelPercentage : IFuelPercentage
    {
        private const string amountValue = "Rate";
        private readonly IElementNullCheck _elementNullCheck;

        public FuelPercentage(IElementNullCheck elementNullCheck)
        {
            _elementNullCheck = elementNullCheck;
        }
        public decimal GetFuelPercentage(XElement priceSheetElement)
        {
            decimal fuelPercentage = 0;

            if (priceSheetElement != null)
            {
                foreach (XElement charge in priceSheetElement.Elements("AssociatedCarrierPricesheet").Elements("PriceSheet").Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        && charge.Element("Description").Value.ToUpper().Contains("FUEL") || charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL_FUEL"))
                    {
                        decimal amount = 0;
                        decimal.TryParse(_elementNullCheck.ReadElementWithNullCheck(charge, amountValue), out amount);
                        fuelPercentage = amount;
                    }
                }
            }

            return fuelPercentage;
        }
    }
}
