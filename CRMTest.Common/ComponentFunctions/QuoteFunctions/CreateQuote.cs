using CRMTest.Common.PageObjects;
using CRMTest.Common.CommonMethods.ApplicationCommon;

namespace CRMTest.Common.ComponentFunctions.QuoteFunctions
{
    public class CreateQuote : Quotelist
    {
        

        public void EnterOriginZip(string oZip)
        {
            WaitForElementVisible(attributeName_id, LTL_OriginZipPostal_Id, "Origin Zip");
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, oZip);
        }

        public void EnterDestinationZip(string dZip)
        {
            WaitForElementVisible(attributeName_id, LTL_DestinationZipPostal_Id, "Destination Zip");
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, dZip);
        }


        public void ClickViewRates()
        {
            WClickElement("id", LTL_ViewQuoteResults_Id,"View Quote Results", CommonMethod.driver);

        }
    }
}
