using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.Partial_Truckload
{
    [Binding]


    public class Partial_Truckload_tile_on_Shipment_Service_screen_in_rate_request_processSteps_Desktop : ObjectRepository
    {

        [Given(@"I am a DLS user with Customer dropdown and login into application")]
        public void GivenIAmADLSUserWithCustomerDropdownAndLoginIntoApplication()
        {
            string userName = ConfigurationManager.AppSettings["username-TestingTesting"].ToString();
            string password = ConfigurationManager.AppSettings["password-TestingTesting"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application as a Ship Entry user with access to Customer");
        }

        [Then(@"User should be navigated to the Old Partial Truckload Shipment Information Page and able to see '(.*)' , '(.*)'\tand '(.*)'")]
        public void ThenUserShouldBeNavigatedToTheOldPartialTruckloadShipmentInformationPageAndAbleToSeeAnd(string RateRequestPageHeader, string RateRequestSubHeadingText, string BacktoQuoteList)
        {
            
            Report.WriteLine("User should navigate to the Intermodel shipment information screen");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Verifytext(attributeName_cssselector, RateRequestHeading_css, RateRequestPageHeader);

            VerifyElementPresent(attributeName_xpath, PTL_RateRequestHeadingSubText, RateRequestSubHeadingText);
            string subheadingOfRateRequest = Gettext(attributeName_xpath, PTL_RateRequestHeadingSubText);
            string Subheading_UI = subheadingOfRateRequest.Remove(subheadingOfRateRequest.Length - 20);
            Assert.AreEqual(RateRequestSubHeadingText, Subheading_UI);
            
            Verifytext(attributeName_id, RateBacktoQuoteListBtn_id, BacktoQuoteList);
        }



        [Then(@"User should be navigated to the Old Partial Truckload Shipment Information section header as (.*) with service as (.*)")]
        public void ThenUserShouldBeNavigatedToTheOldPartialTruckloadShipmentInformationSectionHeaderAsWithServiceAs(string SectionHeader, string Service)
        {
            Report.WriteLine("Verify the Rate request Section header");
            Verifytext(attributeName_xpath, ShipmentInformationSectionHeader_xpath, SectionHeader);


            Report.WriteLine("I should able to see the Service Type as Truckload");
            VerifyElementPresent(attributeName_id, RateServiceType_id, Service);
            string Sevicetype_UI = Gettext(attributeName_id, RateServiceType_id);
            string ser = Sevicetype_UI.Remove(0, 9);
            Assert.AreEqual(ser, Service);
        }

        [Then(@"I should see the text '(.*)', '(.*)' in the Quotes landing page")]
        public void ThenIShouldSeeTheTextInTheQuotesLandingPage(string QuotespageTitle, string QuotespageSubtitle)
        {
            Report.WriteLine("User should navigate to the Quotes landing page");
            Verifytext(attributeName_cssselector, QuotespageHeading_css, QuotespageTitle);
            Verifytext(attributeName_xpath, QuotesPageSubheading_xpath, QuotespageSubtitle);            
        }

    }
}
