using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class LTLTileOnShipmentServicesScreenInRateRequestProcess_DesktopSteps : ObjectRepository

    {

        [Given(@"I am on the (.*) page of the rate request process")]
        public void GivenIAmOnThePageOfTheRateRequestProcess(string ShipmentServices)
        {
            Report.WriteLine("Shipment Service Screen");
            Verifytext(attributeName_xpath, ShipmentServiceScreenTitle_Xpath, ShipmentServices);
            string ServiceScreen = Gettext(attributeName_xpath, ShipmentServiceScreenTitle_Xpath);
            Assert.AreEqual(ShipmentServices, ServiceScreen);
        }

        [When(@"I Click on Quotes icon from the navigation bar")]
        public void WhenIClickOnQuotesIconFromTheNavigationBar()
        {
            Report.WriteLine("Click on quote icon");
            Click(attributeName_id, QuoteIconClick_Id);
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
        }

        [When(@"I click on Submit a rate request")]
        public void WhenIClickOnSubmitARateRequest()
        {
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);
        }

        [When(@"I click on the LTL Tile")]
        public void WhenIClickOnTheLTLTile()
        {
            Report.WriteLine("Click on LTL Tile");
            Click(attributeName_id, LTL_TileLabel_Id);
        }


        [Then(@"I must be navigated to the (.*) Screen in the rate request process")]
        public void ThenIMustBeNavigatedToTheScreenInTheRateRequestProcess(string ShipmentServices)
        {
            Report.WriteLine("Shipment Service Screen");
            Verifytext(attributeName_xpath, ShipmentServiceScreenTitle_Xpath, ShipmentServices);
            string ServiceScreen = Gettext(attributeName_xpath, ShipmentServiceScreenTitle_Xpath);
            Assert.AreEqual(ShipmentServices, ServiceScreen);
        }


        [Then(@"I must be able to see (.*) service option in a tile view of the Shipment Services screen")]
        public void ThenIMustBeAbleToSeeServiceOptionInATileViewOfTheShipmentServicesScreen(string LTL)
        {
            Report.WriteLine("LTL Service option");
            VerifyElementPresent(attributeName_id, LTL_TileLabel_Id, LTL);
        }


        [Then(@"I must be navigated to the new (.*) Shipment information screen")]
        public void ThenIMustBeNavigatedToTheNewShipmentInformationScreen(string ResponsiveLTL)
        {
            Report.WriteLine("LTL Shipment Information Screen");
            Verifytext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath, ResponsiveLTL);
            string LTLPageHeader = Gettext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath);
            Assert.AreEqual(ResponsiveLTL, LTLPageHeader);
        }

   

        [Then(@"I must be navigated to the new responsive LTL Shipment information screen and header should display (.*) with back to (.*)")]
        public void ThenIMustBeNavigatedToTheNewResponsiveLTLShipmentInformationScreenAndHeaderShouldDisplayWithBackTo(string GetQuote, string QuoteListButton)
        {
            Report.WriteLine("LTL Shipment Information Screen Header with Back to quote Button");
            Verifytext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath, GetQuote);
            string LTL_PageHeader = Gettext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath);
            Assert.AreEqual(GetQuote, LTL_PageHeader);
            VerifyElementPresent(attributeName_id, BackToQuoteButton_Id, QuoteListButton);

        }

    }
}