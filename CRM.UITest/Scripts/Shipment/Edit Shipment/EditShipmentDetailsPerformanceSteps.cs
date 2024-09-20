using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Edit_Shipment
{
    [Binding]
    public sealed class EditShipmentDetailsPerformanceSteps : AddShipments
    {
        private string referenceNumber = "ZZX002016867";
        private string fromName = "Dc Bolingbrook";
        private string fromAddr1 = "1000 Win";
        private string fromPostalCode = "60606";
        private string fromCity = "CHICAGO";
        private string fromState = "IL";
        private string fromCountry = "United States";
        private string toName = "111111";
        private string toAddr1 = "Abcd";
        private string toPostalCode = "60606";
        private string toCity = "CHICAGO";
        private string toState = "IL";
        private string toCountry = "United States";

        [Given(@"I search for the shipment shipref using the shipment reference lookup")]
        public void GivenIFilterTheShipmentResultsByReferenceNumber()
        {
            Report.WriteLine("Filtering Shipment results for " + referenceNumber);
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referenceNumber);
            Report.WriteLine("Clicking  refernce number lookup search button");
            Click(attributeName_xpath, ShipmentList_ReferenceNumLookupButton_Xpath);
            WaitForElementNotVisible(attributeName_xpath, ShipmentList_LoadingIcon_Xpath, "loading icon");
        }

        [When(@"I go to edit a shipment")]
        public void WhenIGoToEditAShipment()
        {
            Report.WriteLine("Clicking Edit Shipment button");
            Click(attributeName_xpath, ShipmentList_FirstEditShipmentButton_Xpath);
            Report.WriteLine("Waiting for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"the existing information for that shipment will be displayed on the page")]
        public void ThenTheExistingInformationForThatShipmentWillBeDisplayedOnThePage()
        {
            string originName = GetValue(attributeName_id, ShippingFrom_LocationName_Id,"value");
            string originAddr1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            string originPostalCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            string originCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            string originCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath);
            string originState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath);
            string destName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            string destAddr1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            string destPostalCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            string destCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            string destCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath);
            string destState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath);
            Assert.AreEqual(originName,fromName);
            Assert.AreEqual(originAddr1, fromAddr1);
            Assert.AreEqual(originPostalCode, fromPostalCode);
            Assert.AreEqual(originCity, fromCity);
            Assert.AreEqual(originCountry, fromCountry);
            Assert.AreEqual(originState, fromState);
            Assert.AreEqual(destName, toName);
            Assert.AreEqual(destAddr1, toAddr1);
            Assert.AreEqual(destPostalCode, toPostalCode);
            Assert.AreEqual(destCity, toCity);
            Assert.AreEqual(destCountry, toCountry);
            Assert.AreEqual(destState, toState);
        }
    }
}
