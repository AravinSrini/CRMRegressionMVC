using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class ReviewSubmitShipment_EditCarrierInfo_AllUsersSteps : AddShipments
    {
        int carrierCount = 0;

        [When(@"I click on edit icon in carrier info section")]
        public void WhenIClickOnEditIconInCarrierInfoSection()
        {
            Report.WriteLine("Clicking on edit icon in carrier info section");
            scrollElementIntoView(attributeName_xpath, ReviewSubmit_EditCarrier_Xpath);
            Click(attributeName_xpath, ReviewSubmit_EditCarrier_Xpath);
        }

        [Given(@"I click on create shipment button for any carrier (.*)")]
        public int GivenIClickOnCreateShipmentButtonForAnyCarrier(string userType)
        {
            Report.WriteLine("Getting the total count of carrier dispalying in results page");
            carrierCount = GetCount(attributeName_xpath, ShipResults_CarrierColumnValues_Xpath);
            AddShipmentLTL data = new AddShipmentLTL();
            data.ClickOnCreateShipmentButton(userType);
            return carrierCount;
        }

        [When(@"I will arrive on the Shipment Results page,")]
        public void WhenIWillArriveOnTheShipmentResultsPage()
        {
            Report.WriteLine("Verifying the results page");
            VerifyElementVisible(attributeName_xpath, ShipResults_PageHeaderText_xpath, "Results Page");
        }

        [Then(@"previously displayed carriers will be listed")]
        public void ThenPreviouslyDisplayedCarriersWillBeListed()
        {
            int actualCount = GetCount(attributeName_xpath, ShipResults_CarrierColumnValues_Xpath);
            Assert.AreEqual(actualCount, carrierCount);
            Report.WriteLine("All the carriers are displaying in shipment results page");
        }
    }
}
