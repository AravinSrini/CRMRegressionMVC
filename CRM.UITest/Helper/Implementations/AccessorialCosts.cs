using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.UITest.Helper.ViewModel;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class AccessorialCosts : IAccessorialCosts
    {
        private readonly IReadElementWithNullCheck _readElementWithNullCheck;

        public AccessorialCosts(IReadElementWithNullCheck readElementWithNullCheck)
        {
            _readElementWithNullCheck = readElementWithNullCheck;
        }

        public CostComponents GetAccessorialCosts(XElement priceSheetElement, CostComponents costComponents, string nodeValue)
        {
            decimal accessorial = 0;
            if (priceSheetElement != null)
            {
                foreach (XElement charge in priceSheetElement.Elements("Charges").Elements("Charge"))
                {
                    if (charge.Attribute("type").Value.ToUpper().Contains("ACCESSORIAL")
                        && !charge.Element("Description").Value.ToUpper().Contains("FUE"))
                    {
                        accessorial = _readElementWithNullCheck.ReadXmlElement(charge, "Amount", out nodeValue)
                            ? decimal.TryParse(nodeValue, out accessorial) ? accessorial : 0
                            : 0;
                        costComponents.Assessorial += accessorial;
                    }
                }
            }
            return costComponents;
        }
    }
}
