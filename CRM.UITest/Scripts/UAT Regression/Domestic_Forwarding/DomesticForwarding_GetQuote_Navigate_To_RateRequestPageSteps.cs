using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding
{
    [Binding]
    public class DomesticForwarding_GetQuote_Navigate_To_RateRequestPageSteps : Mvc4Objects
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a sales, sales management or a station user")]
        public void GivenIAmASalesSalesManagementOrAStationUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I select Domestic Forwarding service(.*) and Click on Get Quote button from Dashboard page")]
        public void WhenISelectDomesticForwardingServiceAndClickOnGetQuoteButtonFromDashboardPage(string Type)
        {
            scrollElementIntoView(attributeName_id, Quote_DF_Radiobutton_Id);
            Click(attributeName_id, Quote_DF_Radiobutton_Id);
            WaitForElementVisible(attributeName_id, Quote_DF_SelectType_dropdown_Id, "Type Dropdown");
            Click(attributeName_id, Quote_DF_SelectType_dropdown_Id);
            SelectDropdownlistvalue(attributeName_xpath, Quote_DF_SelectType_dropdown_Values_Xpath, "Economy");
            Click(attributeName_xpath, GetQuoteButton_Xpath);
            

        }
        
        [When(@"I select Domestic Forwarding service(.*) from Get Quote page")]
        public void WhenISelectDomesticForwardingServiceFromGetQuotePage(string Type)
        {
            Report.WriteLine("Click on quotes module");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_id, QuoteIcon_Id);

            Report.WriteLine("Navigate to rate request service page");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            Click(attributeName_id, DomesticForwarding_TitleLabel_Id);
            WaitForElementVisible(attributeName_xpath, DomForwarding_TypeDropdown_Xpath, "Type Dropdown");
            Click(attributeName_xpath, DomForwarding_TypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DomForwarding_TypeDropdownValues_Xpath, "Economy");
            Click(attributeName_id, DomForwarding_ContinueButton_Id);
        }
        
        [Then(@"I will be Navigated to the Rate Request Shipment Locations and Dates Page for Domestic Forwarding")]
        public void ThenIWillBeNavigatedToTheRateRequestShipmentLocationsAndDatesPageForDomesticForwarding()
        {

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, DF_RateRequestHeader_ShpLoc_And_Dates_Page_Xpath, "Rate Request");
            Report.WriteLine("Verify the Navigation to ShipmentLocationAndDates Page for Domestic Forwarding");
            VerifyElementPresent(attributeName_xpath, DF_RateRequestHeader_ShpLoc_And_Dates_Page_Xpath, "Rate Request");
            VerifyElementPresent(attributeName_xpath, DF_ShipmentLocation_and_Dates_Header_Xpath, "Shipment Locations and Dates");
            string Service_UI = Gettext(attributeName_xpath, DF_Service_ShpLoc_And_Dates_Page_Xpath);
            string ActualService = Service_UI.Remove(0, 9);
            Assert.AreEqual("Domestic Forwarding", ActualService);
        }
    }
}
