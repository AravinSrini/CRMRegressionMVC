using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTL_RemoveUploadShipmentDocumentsSectionSteps :AddShipments
    {

        [When(@"I arrive on the Shipment Confirmation page in the shipment process")]
        public void WhenIArriveOnTheShipmentConfirmationPageInTheShipmentProcess()
        {
            Report.WriteLine("arrived on confimration page");
            WaitForElementPresent(attributeName_xpath, confirmation_pageheader, "PageHeader");
        }
      
        [Then(@"I should not be displayed with Upload Shipment Documents Section")]
        public void ThenIShouldNotBeDisplayedWithUploadShipmentDocumentsSection()
        {
            Report.WriteLine("upload Shipment Documents Section should be removed");
            VerifyElementNotVisible(attributeName_xpath, ConfrimationFileUpload_Xpath, "Uploadsection");
        }
    }
}
