using System.Xml.Linq;

namespace CRM.UITest.Helper.Interfaces
{ 
    public interface ICheckForGuaranteedRateNodeInPriceSheet
    {
        bool CheckIfGuaranteedRateNodeExists(XElement priceSheetElement);
    }
}
