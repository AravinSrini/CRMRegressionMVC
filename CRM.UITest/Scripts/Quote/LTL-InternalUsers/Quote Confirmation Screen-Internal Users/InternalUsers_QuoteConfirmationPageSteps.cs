using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.Quote_Confirmation_Screen
{
    [Binding]
    public class InternalUsers_QuoteConfirmationPageSteps : ObjectRepository
    {

        string carrierName = null;
        string carrierStandardAmount = null;
        string carrierInsuredAmount = null;
        string Shipment_Value = null;
        string Additional_Services = null;


        [Then(@"I will see the name of the (.*) associated to the quote displayed")]
        public void ThenIWillSeeTheNameOfTheAssociatedToTheQuoteDisplayed(string CustomerName)
        {
            Report.WriteLine("Verify the LTL quote Confirmation header");
            


           
            Thread.Sleep(25000);

            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            //string CustomerNameLabel_UI = Gettext(attributeName_id, LTL_QC_ServiceText_Xpath);
            Verifytext(attributeName_xpath, LTL_QC_ServiceText_Xpath, "STATION/CUSTOMER NAME :");
            


            WaitForElementVisible(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath, "confirmpage");
            string CustomerName_UI = Gettext(attributeName_id, LTL_StationCustomerName_Label_id);
            Assert.AreEqual(CustomerName, CustomerName_UI);
        }


        [When(@"I click on save rate as quote link  for selected carrier in results page for station users")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierInResultsPageForStationUsers()
        {
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierStandardAmount = Gettext(attributeName_xpath, ltlstdRateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaverateasquotelnkStationUsers_xpath);
            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierStandardAmount = "N/A";
                carrierInsuredAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }

        [When(@"I click on save insured rate as quote link  for carrier '(.*)' for station users")]
        public void WhenIClickOnSaveInsuredRateAsQuoteLinkForCarrierForStationUsers(string ShipmentValue)
        {
            string configURL = launchUrl;

            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {


                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

                Report.WriteLine("Enter the Insured Rate");
                SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, ShipmentValue);

                Report.WriteLine("Enter the Insured Rate");
                Click(attributeName_xpath, ltlShowInsuredRateBtn_xpath);

                carrierName = Gettext(attributeName_xpath, ltlCarrierName_xpath);
                carrierInsuredAmount = Gettext(attributeName_xpath, ltlinsrateamount_xpath);
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaveinsrateasquotelnkStationUsers_xpath);
            }
            else
            {

                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierInsuredAmount = "N/A";
                carrierStandardAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
            }
        }


    }
}
