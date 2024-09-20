using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.Intermodal
{
    [Binding]
    public sealed class IntermodaltileOnShipmentServiceScreenInRateRequestProcessSteps_Mobile : ObjectRepository
    {
        [When(@"I should see the text '(.*)' and should see '(.*)' button in the Quotes landing page")]
        public void WhenIShouldSeeTheTextAndShouldSeeButtonInTheQuotesLandingPage(string GetQuotetext, string BacktoQuoteListBtn)
        {
            Report.WriteLine("Landing on the Shipment Services screen in rate request process");
            Verifytext(attributeName_cssselector, GetQuotespagetext_css, GetQuotetext);
            VerifyElementVisible(attributeName_id, BacktoQuoteListBtn_id, BacktoQuoteListBtn);
        }

        [Given(@"I re-size the browser to the mobile device '(.*)' and  '(.*)'")]
        public void GivenIRe_SizeTheBrowserToTheMobileDeviceAnd(int WindowWidth, int WindowHeight)
        {
            setBrowserSize(WindowWidth, WindowHeight);
        }

        [Then(@"I should see the text '(.*)' and should see '(.*)' button in the Quotes landing page")]
        public void ThenIShouldSeeTheTextAndShouldSeeButtonInTheQuotesLandingPage(string Quotestext, string BacktoQuoteList)
        {
            Report.WriteLine("Landing on the Shipment Services screen in rate request process");
            Verifytext(attributeName_cssselector, GetQuotespagetext_css, Quotestext);
            VerifyElementVisible(attributeName_id, BacktoQuoteListBtn_id, BacktoQuoteList);
        }

    }
}
