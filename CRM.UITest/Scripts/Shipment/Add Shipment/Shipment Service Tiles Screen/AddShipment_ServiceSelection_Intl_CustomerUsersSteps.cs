using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;


namespace CRM.UITest.Scripts.Shipment.Add_Shipment.Shipment_Service_Tiles_Screen
{
    [Binding]
    public class AddShipment_ServiceSelection_Intl_CustomerUsersSteps : AddShipments
    {
        [When(@"I click on Add Shipment button")]
        public void WhenIClickOnAddShipmentButton()
        {
            Report.WriteLine("Click on Add shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            Thread.Sleep(5000);
        }

        [When(@"I will be navigated to Add Shipment Tiles page")]
        public void WhenIWillBeNavigatedToAddShipmentTilesPage()
        {
            WaitForElementVisible(attributeName_xpath, ShipmentServicePageTitle_Xpath, "Add Shipment");
            Verifytext(attributeName_xpath, ShipmentServicePageTitle_Xpath, "Add Shipment");
        }

        [When(@"I Click on the International Tiles")]
        public void WhenIClickOnTheInternationalTiles()
        {
            Click(attributeName_id, Shipment_International_Tile_Id);
            Thread.Sleep(1000);
        }

        [When(@"I will be able to see International Type PopUp Modal")]
        public void WhenIWillBeAbleToSeeInternationalTypePopUpModal()
        {
            VerifyElementPresent(attributeName_xpath, Shipment_InternationalTile_TypePopUP_Header_Xpath, "International Tile PopUp header");
        }

        [When(@"I click on the Close button")]
        public void WhenIClickOnTheCloseButton()
        {
            WaitForElementVisible(attributeName_xpath, Shipment_InternationalTile_Type_Closebutton_Xpath, "Close button");
            Click(attributeName_xpath, Shipment_InternationalTile_Type_Closebutton_Xpath);
            Thread.Sleep(1000);
        }

        [When(@"I Click on Continue button")]
        public void WhenIClickOnContinueButton()
        {
            WaitForElementVisible(attributeName_xpath, Shipment_InternationalTile_Type_Continuebutton_Xpath, "Continue button");
            Click(attributeName_xpath, Shipment_InternationalTile_Type_Continuebutton_Xpath);
        }

        [Then(@"I will be able to see service type dropdown Continue and Close button")]
        public void ThenIWillBeAbleToSeeServiceTypeDropdownContinueAndCloseButton()
        {
            VerifyElementPresent(attributeName_xpath, Shipment_InternationalTile_Type_dropdown_Xpath, "International Tile Type dropdown");
            VerifyElementPresent(attributeName_xpath, Shipment_InternationalTile_Type_Closebutton_Xpath, "International Tile Type Close button");
            VerifyElementPresent(attributeName_xpath, Shipment_InternationalTile_Type_Continuebutton_Xpath, "International Tile Type Continue button");
        }

        [Then(@"International Type PopUp Modal will be closed")]
        public void ThenInternationalTypePopUpModalWillBeClosed()
        {
            VerifyElementNotVisible(attributeName_xpath, Shipment_InternationalTile_TypePopUP_Header_Xpath, "International Tile Type PopUp Header");
        }

        [Then(@"the Message Please Enter All Required Information appears(.*) with Service Type Redhighlighted")]
        public void ThenTheMessagePleaseEnterAllRequiredInformationAppearsWithServiceTypeRedhighlighted(string _Message)
        {
            string actualtext_UI = Gettext(attributeName_xpath, Shipment_Tile_PleaseEnterrequired_Info_Text_Xpath);
            Assert.AreEqual(_Message, actualtext_UI);
            string ActualbackgroundColor = GetCSSValue(attributeName_xpath, ".//*[@id='shipment_international_type_chosen']/a", "background-image");
            string ExpectedbackgroundColor = "url(\"http://dlsww-test.rrd.com/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"I will be able to select Service Type (.*)and Service Level(.*) Combinations")]
        public void ThenIWillBeAbleToSelectServiceTypeAndServiceLevelCombinations(string _ServiceType, string _ServiceLevel)
        {
            WaitForElementVisible(attributeName_xpath, Shipment_InternationalTile_TypePopUP_Header_Xpath, "International Tile PopUp header");
            Click(attributeName_xpath, Shipment_InternationalTile_Type_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Shipment_InternationalTile_Type_dropdownValue_Xpath, _ServiceType);
            Thread.Sleep(1000);
            WaitForElementVisible(attributeName_xpath, Shipment_InternationalTile_Level_dropdown_Xpath, "International Level Dropdown");
            Click(attributeName_xpath, Shipment_InternationalTile_Level_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Shipment_InternationalTile_Level_dropdownValue_Xpath, _ServiceLevel);
            Thread.Sleep(700);
        }

        [Then(@"I Click on Continue button")]
        public void ThenIClickOnContinueButton()
        {
            Click(attributeName_xpath, Shipment_InternationalTile_Type_Continuebutton_Xpath);
            Thread.Sleep(2000);
        }

        [Then(@"I will be Navigated to the International Locations and Dates Page(.*)")]
        public void ThenIWillBeNavigatedToTheInternationalLocationsAndDatesPage(string _IntLocaAndDates_Header)
        {
            WaitForElementVisible(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_Header_Xpath, _IntLocaAndDates_Header);
            VerifyElementPresent(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_Header_Xpath, _IntLocaAndDates_Header);
        }

        [Then(@"I able to see Service Type and Service Level at Top of the page(.*)and(.*)")]
        public void ThenIAbleToSeeServiceTypeAndServiceLevelAtTopOfThePageand(string _ServiceType, string _ServiceLevel)
        {
            //string _ActualServiceType = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_ServiceType_Xpath);
            //_ActualServiceType.Contains(_ServiceType);

            //string _ActualServiceLevel = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_ServiceType_Xpath);
            //_ActualServiceLevel.Contains(_ServiceLevel);

            string service_Type_Level_UI = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_Service_Type_Level_Xpath);
            string _expected_Service_Type_Level = _ServiceType+ " - " +_ServiceLevel;
            Assert.AreEqual(_expected_Service_Type_Level, service_Type_Level_UI);
        }

        [Then(@"I Navigated to the International Locations and Dates Page(.*),(.*)")]
        public void ThenINavigatedToTheInternationalLocationsAndDatesPage(string service, string _IntLocaAndDates_Header)
        {
            string _InternationalText = Gettext(attributeName_xpath, Shipment_International_Locations_And_Dates_Page_International_Text_Xpath);
            string[] _InternationalText_Splitted = _InternationalText.Split(' ');
            string Actual_InternationalText = _InternationalText_Splitted[1];
            Assert.AreEqual(service, Actual_InternationalText);
        }

    }
}
