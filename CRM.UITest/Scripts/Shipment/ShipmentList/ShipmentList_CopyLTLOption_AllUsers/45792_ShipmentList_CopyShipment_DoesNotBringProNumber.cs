using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_CopyLTLOption_AllUsers
{
    [Binding]
    public sealed class _45792_ShipmentList_CopyShipment_DoesNotBringProNumber : AddShipments
    {
        [Given(@"I click the copy shipment button on a shipment")]
        public void GivenIClickTheCopyShipmentButtonOnAShipment()
        {
            int shipmentlist = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (shipmentlist > 1)
            {
                Click(attributeName_xpath, ShipmentListGrid_CopyIcon_First_Xpath);
            }
            else
            {
                Report.WriteLine("No shipments found");
                Assert.Fail();
            }
        }

        [Given(@"I clicked the yes button in the copy shipment popup box")]
        public void GivenIClickedTheYesButtonInTheCopyShipmentPopupBox()
        {
            WaitForElementVisible(attributeName_id, ShipmentList_CopyIcon_Model_CopyShipmentButton_Id, "Copy shipment yes button");
            Report.WriteLine("Clicking on yes for copy shipment icon for LTL shipment");
            Click(attributeName_id, ShipmentList_CopyIcon_Model_CopyShipmentButton_Id);
        }

        [Given(@"I click the copy shipment button on a shipment (.*)")]
        public void GivenIClickTheCopyShipmentButtonOnAShipment(string refNumber)
        {
            Report.WriteLine("Searching for reference number " + refNumber);
            SendKeys(attributeName_id, "txtReferenceNumer", refNumber);
            Report.WriteLine("Clicking on the search button");
            Click(attributeName_cssselector, ShipmentList_ReferenceSearchButton_Selector);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on the copy shipment button");
            Click(attributeName_xpath, "//*[@id='ShipmentGrid']/tbody/tr/td[8]/a[2]");
            GlobalVariables.webDriver.WaitForPageLoad();
        }



        [Then(@"the PRO NUMBER fields will be blank")]
        public void ThenThePRONUMBERFieldsWillBeBlank()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the ProNumber field is blank");
            string proNumberField = GetValue(attributeName_id, ReferenceNumbers_PRONumber_Id, "value");
            Assert.AreEqual("", proNumberField);
        }

    }
}
