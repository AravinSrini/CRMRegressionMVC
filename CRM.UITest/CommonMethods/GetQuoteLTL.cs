using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class GetQuoteLTL : Quotelist
    {
       
        public void GetQuoteLTL_Navigation(string Account)
        {
            Report.WriteLine("Click on the Quote Module");
            Click(attributeName_xpath, QuoteIconModule_Xpath);

            Report.WriteLine("Select Customer Name from the dropdown list");
                        
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteList_CustomerDrpdown_Search_Xpath, Account);
            Click(attributeName_xpath, QuoteList_CustomerDrpdown_SearchedValue_Xpath);
            Thread.Sleep(2000);
            Report.WriteLine("Click on the Submit Rate Request Button");
            Click(attributeName_id, SubmitRateRequestBtn_id);
            Thread.Sleep(2000);
            Report.WriteLine("Click on the LTL Tile");
            Click(attributeName_id, GetQuote_Ltlimage_id);
            Report.WriteLine("I am on the Get Quote LTL Page");
            VerifyElementPresent(attributeName_xpath, LTLpagetitle_xpath, "Get Quote (LTL)");
        }

    }
}
