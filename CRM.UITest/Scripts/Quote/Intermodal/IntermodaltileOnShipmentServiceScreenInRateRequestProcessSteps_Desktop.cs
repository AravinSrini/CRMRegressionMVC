using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.Intermodal
{
    [Binding]
    public class IntermodaltileOnShipmentServiceScreenInRateRequestProcessSteps_Desktop : ObjectRepository
    {
        [When(@"I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page")]
        public void WhenIClickOnTheQuotesMenuAvailableInTheLandingPageNavigateToQuotesLandingPage()
        {
            Report.WriteLine("click on the Quotes Menu");
            WaitForElementVisible(attributeName_cssselector, Quotesmenu_css, "Quote List");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_cssselector, Quotesmenu_css);
        }

        [When(@"I click on Submit Rate Request button in Quotes page")]
        public void WhenIClickOnSubmitRateRequestButtonInQuotesPage()
        {
            Report.WriteLine("click on the Submit Rate Request button");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol"); ---> Loading symbol is not present & this step fails. So, commenting out.
            Click(attributeName_id, SubmitRateRequestBtn_id);
        }

        [When(@"I must see the Intermodel '(.*)' tile in the Quotes landing page")]
        public void WhenIMustSeeTheIntermodelTileInTheQuotesLandingPage(string Intermodel)
        {
            Report.WriteLine("User must see International tile");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            VerifyElementPresent(attributeName_id, IntermodelTile_id, Intermodel);
        }

        [When(@"I click on the Intermodel tile")]
        public void WhenIClickOnTheIntermodelTile()
        {
            Report.WriteLine("click on the Intermodel tile");
            Click(attributeName_id, IntermodelTile_id);
        }

        [Then(@"I should navigate to the shipment information screen and can able to see the '(.*)','(.*)','(.*)' and '(.*)'")]
        public void ThenIShouldNavigateToTheShipmentInformationScreenAndCanAbleToSeeTheAnd(string RateRequestHeading, string RateRequestSubheading, string ShipmentInformation, string RateBacktoQuoteList)
        {
            Report.WriteLine("User should navigate to the Intermodel shipment information screen");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Verifytext(attributeName_cssselector, RateRequestHeading_css, RateRequestHeading);
            
            VerifyElementPresent(attributeName_cssselector, Subheading_css, RateRequestSubheading);
            string subheading_UI = Gettext(attributeName_cssselector, Subheading_css);
            string Subheading_UI = subheading_UI.Remove(subheading_UI.Length - 20);
            Assert.AreEqual(RateRequestSubheading, Subheading_UI);

            string Shipmentinfo_UI = Gettext(attributeName_cssselector, ShipmentInformation_css);
            Verifytext(attributeName_cssselector, ShipmentInformation_css, ShipmentInformation);
            string Rate_UI = Gettext(attributeName_id, RateBacktoQuoteListBtn_id);
            Verifytext(attributeName_id, RateBacktoQuoteListBtn_id, RateBacktoQuoteList);
        }

        [Then(@"I should able to see the '(.*)'")]
        public void ThenIShouldAbleToSeeThe(string ServiceType)
        {
            Report.WriteLine("I should able to see the Service Type as Intermodel");
            VerifyElementPresent(attributeName_id, RateServiceType_id, ServiceType);
            string Sevicetype_UI = Gettext(attributeName_id, RateServiceType_id);
            string service = Sevicetype_UI.Substring(9, Sevicetype_UI.Length - 9);
            Assert.AreEqual(ServiceType, service);
        }

        [Then(@"I should see the text '(.*)', '(.*)' and '(.*)'  in the Quotes landing page")]
        public void ThenIShouldSeeTheTextAndInTheQuotesLandingPage(string QuotespageTitle, string QuotespageSubtitle, string SubmitRateRequestBtn)
        {
            Report.WriteLine("User should navigate to the Quotes landing page");
            Verifytext(attributeName_cssselector, QuotespageHeading_css, QuotespageTitle);
            Verifytext(attributeName_cssselector, Quotespagesubheading_css, QuotespageSubtitle);            
            Verifytext(attributeName_id, SubmitRateRequestButton_Id, SubmitRateRequestBtn);
        }
    }
}
