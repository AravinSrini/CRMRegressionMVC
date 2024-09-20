using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Objects;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class ReviewAndSubmitShipmentLTL_EditShippingInfo_AllUsersSteps :AddShipments
    {
        [When(@"I click on Edit buttton of ShipInfo section")]
        public void WhenIClickOnEditButttonOfShipInfoSection()
        {
            Report.WriteLine("Click on Edit button");
            Click(attributeName_xpath, ReviewSubmit_EditInfoButton_Xpath);
        }

        [When(@"I am on the Review and Submit page")]
        public void WhenIAmOnTheReviewAndSubmitPage()
        {
            Report.WriteLine("Review and Submit page");
            Verifytext(attributeName_xpath, ReviewAndSubmit_Title_Xpath, "Review and Submit Shipment (LTL)");
        }


        [Then(@"I must be navigated to Add Shipment \(LTL\) page")]
        public void ThenIMustBeNavigatedToAddShipmentLTLPage()
        {
            Report.WriteLine("Navigation to Add shipment page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
        }

        [Then(@"All of the previously entered Shipping Information and Freight Description information should be populated - (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenAllOfThePreviouslyEnteredShippingInformationAndFreightDescriptionInformationShouldBePopulated_(string originName, string originAddr1, string originZipcode, string destinationName, string destinationAddr1, string destinationZipcode, string classification, string nmfc, string quantity, string weight, string itemdesc)
        {
            Report.WriteLine("Data Binding for Shipping Information and Freight Description section");
            string LocName = GetValue(attributeName_id, ShippingFrom_LocationName_Id,"value");
            Assert.AreEqual(LocName, originName);
            string LocAddress = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Assert.AreEqual(LocAddress, originAddr1);
            string OriginZip = GetValue(attributeName_id, ShippingFrom_zipcode_Id,"value");
            Assert.AreEqual(OriginZip, originZipcode);
            string DesName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            Assert.AreEqual(DesName, destinationName);
            string DesAddress = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            Assert.AreEqual(DesAddress, destinationAddr1);
            string DestinationZip = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            Assert.AreEqual(DestinationZip, destinationZipcode);
            scrollpagedown();
            Thread.Sleep(2000);
            scrollpagedown();
            Thread.Sleep(2000);
            string Classification = GetValue(attributeName_id, FreightDesp_FirstItem_SavedClassItem_DropDown_Id, "value");
            Assert.AreEqual(Classification, classification);
            string Nmfc = GetValue(attributeName_id, FreightDesp_FirstItem_NMFC_Id, "value");
            Assert.AreEqual(Nmfc, nmfc);
            string Quantity = GetValue(attributeName_id, FreightDesp_FirstItem_Quantity_Id, "value");
            Assert.AreEqual(Quantity, quantity);
            string Weight = GetValue(attributeName_id, FreightDesp_FirstItem_Weight_Id, "value");
            Assert.AreEqual(Weight, weight);
            string Desc = GetValue(attributeName_id, FreightDesp_FirstItem_ItemDescription_Id, "value");
            Assert.AreEqual(Desc, itemdesc);
        }

    }
}
