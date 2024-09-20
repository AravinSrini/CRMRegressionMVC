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
    public class FuelCosts : IFuelCosts
    {
        private readonly IReadElementWithNullCheck _readElementWithNullCheck;

        public FuelCosts(IReadElementWithNullCheck readElementWithNullCheck)
        {
            _readElementWithNullCheck = readElementWithNullCheck;
        }
        public decimal GetFuelCosts(XElement priceSheetElement, CostComponents costComponents, string nodeValue)
        {
            decimal fuelCost = 0;
            if (priceSheetElement != null)
            {
                foreach (XElement charge in priceSheetElement.Elements("Charges").Elements("Charge"))
                {
                    if (charge.Element("Description").Value.ToUpper().Contains("FUE"))
                    {
                        decimal amount = 0;
                        costComponents.FuelCost = _readElementWithNullCheck.ReadXmlElement(charge, "Amount", out nodeValue)
                            ? decimal.TryParse(nodeValue, out amount) ? amount : 0
                            : 0;
                        fuelCost = amount;
                    }
                }
            }
            return fuelCost;
        }
    }
}
