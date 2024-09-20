using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.Truckload
{
    [Binding]
    public class Truckload_tile_on_Shipment_Service_screen_in_rate_request_processSteps : ObjectRepository
    {

        [Given(@"I am able to see the '(.*)' in the Dashboard page")]
        public void GivenIAmAbleToSeeTheInTheDashboardPage(string UserDropdown)
        {
            Report.WriteLine("User can see UserDropdown");
            Verifytext(attributeName_id, UserDropdown_id, UserDropdown.ToUpper());
        }


        [When(@"I Click on Quotes icon from the navigation bar user should be navigated to the Quote list page")]
        public void WhenIClickOnQuotesIconFromTheNavigationBarUserShouldBeNavigatedToTheQuoteListPage()
        {
            Report.WriteLine("Click on Quote Module");
            WaitForElementVisible(attributeName_cssselector, Quotesmenu_css, "Quotes");
            Click(attributeName_xpath, QuoteModule_Xpath);
        }

        [When(@"I Click on Submit Rate Request button")]
        public void WhenIClickOnSubmitRateRequestButton()
        {
            Report.WriteLine("Click on the Submit rate request Button");
            Click(attributeName_id, SubmitRateRequestButton_Id);
        }

        [When(@"user should be navigated to the Shipment Services Screen in the rate request process (.*)")]
        public void WhenUserShouldBeNavigatedToTheShipmentServicesScreenInTheRateRequestProcess(string ServicesPageHeader)
        {
            Report.WriteLine("Shipment Services Screen page Header ");
            Verifytext(attributeName_xpath, ShipmentInformationText_Xpath, ServicesPageHeader);
        }

        [Then(@"user should be able to see (.*) service option in a tile view of the Shipment Services screen")]
        public void ThenUserShouldBeAbleToSeeServiceOptionInATileViewOfTheShipmentServicesScreen(string ServiceTile)
        {
            Report.WriteLine("Service Tile Element");

            switch (ServiceTile)
            {
                case "Truckload":

                    {
                        Report.WriteLine("Service Tile Element");
                        VerifyElementPresent(attributeName_id, TL_TileLabel_Id, ServiceTile);
                        break;
                    }

                case "Partial Truckload":

                    {
                        Report.WriteLine("Service Tile Element");
                        VerifyElementPresent(attributeName_id, Partial_TL_TileLabel_Id, ServiceTile);
                        break;
                    }

                case "Domestic Forwarding":

                    {
                        Report.WriteLine("Service Tile Element");
                        VerifyElementPresent(attributeName_id, DomesticForwarding_TitleLabel_Id, ServiceTile);
                        break;
                    }


            }

        }

        [Then(@"User should be navigated to the Old Truckload Shipment Information Page and able to see '(.*)' , '(.*)'\tand '(.*)'")]
        public void ThenUserShouldBeNavigatedToTheOldTruckloadShipmentInformationPageAndAbleToSeeAnd(string RateRequestPageHeader, string RateRequestSubHeadingText, string BacktoQuoteList)
        {

            Report.WriteLine("Rate request page header");
            Verifytext(attributeName_cssselector, RateRequestHeading_css, RateRequestPageHeader);

            VerifyElementPresent(attributeName_xpath, TL_RateRequestHeadingSubText, RateRequestSubHeadingText);
            string subheadingOfRateRequest = Gettext(attributeName_xpath, TL_RateRequestHeadingSubText);
            string Subheading_UI = subheadingOfRateRequest.Remove(subheadingOfRateRequest.Length - 20);
            Assert.AreEqual(RateRequestSubHeadingText, Subheading_UI);
            Verifytext(attributeName_id, RateBacktoQuoteListBtn_id, BacktoQuoteList);
        }


        [Then(@"User should be navigated to the Legacy Shipment Information Page and able to see '(.*)' , '(.*)'\tand '(.*)'")]
        public void ThenUserShouldBeNavigatedToTheLegacyShipmentInformationPageAndAbleToSeeAnd(string RateRequestPageHeader, string RateRequestSubHeadingText, string BacktoQuoteList)
        {
            Report.WriteLine("Rate request page header");
            Verifytext(attributeName_cssselector, RateRequestHeading_css, RateRequestPageHeader);

            VerifyElementPresent(attributeName_xpath, TL_RateRequestHeadingSubText, RateRequestSubHeadingText);
            string subheadingOfRateRequest = Gettext(attributeName_xpath, TL_RateRequestHeadingSubText);
            string Subheading_UI = subheadingOfRateRequest.Remove(subheadingOfRateRequest.Length - 20);
            Assert.AreEqual(RateRequestSubHeadingText, Subheading_UI);
            Verifytext(attributeName_id, RateBacktoQuoteListBtn_id, BacktoQuoteList);
        }

        [Then(@"User should be navigated to the Old Truckload Shipment Information section header as (.*) with service as (.*)")]
        public void ThenUserShouldBeNavigatedToTheOldTruckloadShipmentInformationSectionHeaderAsWithServiceAs(string SectionHeader, string Service)
        {
            Report.WriteLine("Verify the Rate request Section header");
            Verifytext(attributeName_xpath, ShipmentInformationSectionHeader_xpath, SectionHeader);

            Report.WriteLine("I should able to see the Service Type as Truckload");
            VerifyElementPresent(attributeName_id, RateServiceType_id, Service);
            string Sevicetype_UI = Gettext(attributeName_id, RateServiceType_id);
            string ser = Sevicetype_UI.Remove(0, 9);
            Assert.AreEqual(ser, Service);
        }

        [Then(@"user should be able to see the Back to Quote List button")]
        public void ThenUserShouldBeAbleToSeeTheBackToQuoteListButton()
        {
            Report.WriteLine("Service Tile Element");
            VerifyElementPresent(attributeName_id, GetQuoteBacktoQuoteListBtn_id, "Back to Quote List");
        }

        [When(@"I Select the (.*) type from the shipment services screen")]
        public void WhenISelectTheTypeFromTheShipmentServicesScreen(string Service)
        {
            switch (Service)
            {
                case "Truckload":

                    {
                        Report.WriteLine("Selecting service from shipment service screen");
                        Click(attributeName_xpath, TL_TileLabel_xpath);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;
                    }

                case "Partial Truckload":

                    {
                        Report.WriteLine("Selecting service from shipment service screen");
                        Click(attributeName_id, Partial_TL_TileLabel_Id);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;
                    }

                case "Intermodal":

                    {
                        Report.WriteLine("Selecting service from shipment service screen");
                        Click(attributeName_id, Intermodal_TileLabel_Id);
                        WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
                        break;

                    }

                case "Domestic Forwarding":

                    {
                        Report.WriteLine("Selecting service from shipment service screen");
                        Click(attributeName_id, DomesticForwarding_TitleLabel_Id);                        
                        break;

                    }

            }


        }

    }

}
