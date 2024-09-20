using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteDetails_RequoteButtonSteps : Quotelist
    {

        string QuoteList_StationCustomerName = null;

        [When(@"I click on Expired quote radio button"),Scope(Feature = "QuoteDetails_RequoteButton")]
        public void WhenIClickOnExpiredQuoteRadioButton()
        {
            Report.WriteLine("I click on Expired quote radio button");
            Click(attributeName_xpath, QuoteList_ExpiredLabel_Xpath);      
        }

        [When(@"I click on expand button of any expired quote from quote list")]
        public void WhenIClickOnExpandButtonOfAnyExpiredQuoteFromQuoteList()
        {
            Report.WriteLine("Click on Toggle arrow button");
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
            Report.WriteLine("I click on Clear all button from toggle popup");
            WaitForElementVisible(attributeName_id, QuoteList_ClearAll_Id, "Clear All");
            Click(attributeName_id, QuoteList_ClearAll_Id);
            Report.WriteLine("I select the Service option from Popup window");
            Click(attributeName_xpath, QuoteList_Service_Option_Xpath);
            Report.WriteLine("Click on Toggle arrow button");
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
            Report.WriteLine("Type the service type as LTL in search box");
            SendKeys(attributeName_id, QuoteList_Search_Box_Id, "LTL");
            int rowcount = GetCount(attributeName_xpath, QuoteList_AllNoOfRecords_xpath);
            if (rowcount > 1)
            {
                Report.WriteLine("Click on expand button from Quote List of first expired quote");
                Click(attributeName_xpath, QuoteDetails_Expand_FirstRecord_Xpath);
                Thread.Sleep(12000);

                string QuoteList_StationName = Gettext(attributeName_xpath, QuoteList_FirstQuote_StationName_xpath);
                string QuoteList_CustomerName = Gettext(attributeName_xpath, QuoteList_FirstQuote_CustomerName_xpath);
                QuoteList_StationCustomerName = (QuoteList_StationName + " - " + QuoteList_CustomerName);

            }
            else
            {
                Report.WriteLine("No Records found for the LTL expired quotes ");
            }
            

        }


        [Then(@"I must be able to see the (.*) button in quote detail section")]
        public void ThenIMustBeAbleToSeeTheButtonInQuoteDetailSection(string Re_quote)
        {
            Report.WriteLine("I must be able to see the Re-quote button in quote detail sectino");
            String RequoteButtonPresent = Gettext(attributeName_id, QuoteDetails_RequoteButton_id);
            Assert.AreEqual(Re_quote, RequoteButtonPresent);
        }


        [When(@"I click on Re-Quote button from quote details section")]
        public void WhenIClickOnRe_QuoteButtonFromQuoteDetailsSection()
        {
            Report.WriteLine("Click on Requote button of any expired quote");
            Click(attributeName_id, QuoteDetails_RequoteButton_id);
        }

        [When(@"I must able to see the (.*) page")]
        public void WhenIMustAbleToSeeThePage(string GetQuoteService)
        {
            Report.WriteLine("I should see the Get Quote (LTL) page");
            String GetQuote_LTL = Gettext(attributeName_xpath, LTLpagetitle_xpath);
            Assert.AreEqual(GetQuoteService, GetQuote_LTL);
        }


        [Then(@"I must be able to see the Stationname CustomerName Label on page and field are non editable")]
        public void ThenIMustBeAbleToSeeTheStationnameCustomerNameLabelOnPageAndFieldAreNonEditable()
        {
            Report.WriteLine("Verify the Station Name and Customer Name label is exists");
            VerifyElementPresent(attributeName_id, GetQuote_LTL_StationCustomerName_Label_id, "");
        }

        [Then(@"Page should be navigated the (.*) page")]
        public void ThenPageShouldBeNavigatedThePage(string QuoteResultsService)
        {
            Report.WriteLine("Page should be naviagted to the Quote Result (LTL)");
            String QuoteResult_LTL = Gettext(attributeName_xpath, ltlQuoteResultsheader_xpath);
            Assert.AreEqual(QuoteResultsService, QuoteResult_LTL);

        }

        [Then(@"I should see the Stationname CustomerName Label on page and field are non editable")]
        public void ThenIShouldSeeTheStationnameCustomerNameLabelOnPageAndFieldAreNonEditable()
        { 
            Report.WriteLine("Verify the Station Name and Customer Name label is exists and field is not editable in Quote result(LTL) page");
            VerifyElementPresent(attributeName_id, GetQuote_LTL_StationCustomerName_Label_id, "");
        }

  
        [Then(@"The Selected Station and Customer Name should  match with Station and Customer Label on Get Quote\(LTL\) page")]
        public void ThenTheSelectedStationAndCustomerNameShouldMatchWithStationAndCustomerLabelOnGetQuoteLTLPage()
        {
            Report.WriteLine("The Selected Station and Customer Name form expired Quote list should be shown on Get Quote (LTL) page and match with label");
            string GetQuote_LTL_StationCustomerNameLabel = Gettext(attributeName_id, GetQuote_LTL_StationCustomerName_Label_id);
            Assert.AreEqual(QuoteList_StationCustomerName, GetQuote_LTL_StationCustomerNameLabel);
        }

        [Then(@"The Selected Station and Customer Name should  match with Station and Customer Label on Quote Results\(LTL\) page")]
        public void ThenTheSelectedStationAndCustomerNameShouldMatchWithStationAndCustomerLabelOnQuoteResultsLTLPage()
        {
            Report.WriteLine("The Selected Station and Customer Name form expired Quote list should be shown on Quote Result (LTL) page and match with label");
            string QuoteResult_LTL_StationCustomerNameLabel = Gettext(attributeName_id, GetQuote_LTL_StationCustomerName_Label_id);
            Assert.AreEqual(QuoteList_StationCustomerName, QuoteResult_LTL_StationCustomerNameLabel);
        }

    }
}
