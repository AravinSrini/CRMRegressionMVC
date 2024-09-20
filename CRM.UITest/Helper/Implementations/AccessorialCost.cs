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
    public class AccessorialCost : IAccessorialCost
    {
        private const string amount = "Amount";

        private readonly IElementNullCheck _elementNullCheck;

        public AccessorialCost(IElementNullCheck elementNullCheck)
        {
            _elementNullCheck = elementNullCheck;
        }

        public CostComponents GetAccessorialCost(XElement priceSheetElement, CostComponents costComponents)
        {
            decimal accessorial = 0;

            if (priceSheetElement != null)
            {
                // Get Accessorial Cost
                foreach (XElement charge in priceSheetElement.Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        && !charge.Element("Description").Value.ToUpper().Contains("FUE"))
                    {
                        decimal.TryParse(_elementNullCheck.ReadElementWithNullCheck(charge, amount), out accessorial);
                        costComponents.Assessorial += accessorial;
                    }
                }
            }

            return costComponents;
        }
    }
}
