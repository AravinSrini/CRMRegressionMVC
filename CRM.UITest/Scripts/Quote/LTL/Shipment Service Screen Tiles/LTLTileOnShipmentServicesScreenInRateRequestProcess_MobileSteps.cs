using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class LTLTileOnShipmentServicesScreenInRateRequestProcess_MobileSteps : ObjectRepository
    {
        //[Given(@"I re-size the browser to mobile device (.*) and  (.*)")]
        //public void GivenIRe_SizeTheBrowserToMobileDeviceAnd(int WindowWidth, int WindowHeight)
        //{
        //    setBrowserSize(WindowWidth, WindowHeight);

        //}

        [Given(@"I click on Submit a rate request")]
        public void GivenIClickOnSubmitARateRequest()
        {
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);
        }


        [Then(@"I must be navigated to the new responsive LTL Shipment information screen and header should display (.*) without back to (.*)")]
        public void ThenIMustBeNavigatedToTheNewResponsiveLTLShipmentInformationScreenAndHeaderShouldDisplayWithoutBackTo(string GetQuote, string QuoteListButton)
        {
            Report.WriteLine("LTL Shipment Information Screen Header without Back to quote Button");
            Verifytext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath, GetQuote);
            string LTL_PageHeader = Gettext(attributeName_xpath, LTL_shipmentinformationpageheader_Xpath);
            Assert.AreEqual(GetQuote, LTL_PageHeader);
            VerifyElementNotVisible(attributeName_id, BackToQuoteButton_Id, QuoteListButton);
           
        }

    }
}
