using CRM.UITest.Helper.Interfaces;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class CheckForGuaranteedRateNodeInPriceSheet : ICheckForGuaranteedRateNodeInPriceSheet
    {
        public bool CheckIfGuaranteedRateNodeExists(XElement priceSheetElement)
        {
            bool isGuaranteedRateNodeAvailable = false;

            foreach (XElement charge in priceSheetElement.Element("Charges").Elements("Charge"))
            {
                if (charge.Element("Description").Value == "Guaranteed Rate")
                {
                    isGuaranteedRateNodeAvailable = true;

                    break;
                }
            }

            return isGuaranteedRateNodeAvailable;
        }
    }
}
