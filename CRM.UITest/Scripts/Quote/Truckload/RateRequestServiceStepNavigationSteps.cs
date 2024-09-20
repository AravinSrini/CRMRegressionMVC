using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.Truckload
{
    [Binding]
    public class RateRequestServiceStepNavigationSteps : ObjectRepository
    {

        [Given(@"User click on the Quote module will be redirected to Quote list page and upon click on submit rate request button Will be Navigated to new Shipment service tile page")]
        public void GivenUserClickOnTheQuoteModuleWillBeRedirectedToQuoteListPageAndUponClickOnSubmitRateRequestButtonWillBeNavigatedToNewShipmentServiceTilePage()
        {
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_xpath, QuoteModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            // WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            MoveToElementClick(attributeName_id, SubmitRateRequestButton_Id);
        }

        [Given(@"User selects services '(.*)' type '(.*)' level '(.*)' will be Navigated to Shipment Information page '(.*)'")]
        public void GivenUserSelectsServicesTypeLevelWillBeNavigatedToShipmentInformationPage(string Service, string Type, string Level, string ShipmentInformationPageText)
        {
            switch (Service)
            {
                case "Truckload":

                    {
                        Click(attributeName_id, TL_TileLabel_Id);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;
                    }

                case "Partial Truckload":

                    {
                        Click(attributeName_id, Partial_TL_TileLabel_Id);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;
                    }

                case "Intermodal":

                    {
                        Click(attributeName_id, Intermodal_TileLabel_Id);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;

                    }

                case "International":
                    {
                        Click(attributeName_id, International_TileLabel_Id);
                        WaitForElementVisible(attributeName_xpath, International_TypeDropdown_Xpath, "Type Dropdown");
                        Click(attributeName_xpath, International_TypeDropdown_Xpath);
                        SelectDropdownValueFromList(attributeName_xpath, International_TypeDropdownValues_Xpath, Type);
                        WaitForElementVisible(attributeName_xpath, International_LevelDropdown_Xpath, "Level Dropdown");
                        Click(attributeName_xpath, International_LevelDropdown_Xpath);
                        SelectDropdownValueFromList(attributeName_xpath, International_LevelDropdownValues_Xpath, Level);
                        Click(attributeName_id, International_ContinueButton_Id);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;
                    }
            }
            Report.WriteLine("Verify the Navigation to Shipment Information Page by HeaderName");
            VerifyElementPresent(attributeName_xpath, ShipmentInformationTextUI_Xpath, ShipmentInformationPageText);
        }

        [Given(@"User selects Domestic Forwarding service with type '(.*)' will be Navigated to Shipment Location and Dates page '(.*)'")]
        public void GivenUserSelectsDomesticForwardingServiceWithTypeWillBeNavigatedToShipmentLocationAndDatesPage(string Type, string ShipmentLocationAndDatesPageText)
        {
            Click(attributeName_id, DomesticForwarding_TitleLabel_Id);
            WaitForElementVisible(attributeName_xpath, DomForwarding_TypeDropdown_Xpath, "Type Dropdown");
            Click(attributeName_xpath, DomForwarding_TypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DomForwarding_TypeDropdownValues_Xpath, Type);
            Click(attributeName_id, DomForwarding_ContinueButton_Id);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Report.WriteLine("Verify the Navigation to Shipment ShipmentLocationAndDates Page by HeaderName");
            VerifyElementPresent(attributeName_xpath, ShipmentLocationAndDatesText_Xpath, ShipmentLocationAndDatesPageText);
        }

        [When(@"User Clicks on service bubble in the step wizard")]
        public void WhenUserClicksOnServiceBubbleInTheStepWizard()
        {
            Click(attributeName_xpath, ServiceBubble_Xpath);
        }

        [When(@"User Clicks on service Navigation bar")]
        public void WhenUserClicksOnServiceNavigationBar()
        {
            Click(attributeName_xpath, ServiceNavigationBar_Xpath);
        }

        [Then(@"User should be Navigated to new Shipment service tile page '(.*)'")]
        public void ThenUserShouldBeNavigatedToNewShipmentServiceTilePage(string GetQuoteText)
        {
            Report.WriteLine("Verify the Navigation back to the New Shipment Service Tile Page by Header name");
            string GetQuoteText_UI = Gettext(attributeName_xpath, GetQuote_Text_Xpath);
            Assert.AreEqual(GetQuoteText, GetQuoteText_UI);
        }
    }
}
