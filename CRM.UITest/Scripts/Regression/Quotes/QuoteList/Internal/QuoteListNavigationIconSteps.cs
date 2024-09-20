using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest.Scripts.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteListNavigationIconSteps : Quotelist
    {
        [When(@"I am navigated to the dashboard page (.*)")]
        public void WhenIAmNavigatedToTheDashboardPage(string DashboardTitle)
        {
            
            Report.WriteLine("Verifying the Dashboard title");
            Verifytext(attributeName_xpath, Dashboard_pagetitle_xpath, DashboardTitle);      

        }

       [Then(@"I must be able to see the (.*) module in icon navbar")]
      public void ThenIMustBeAbleToSeeTheModuleInIconNavbar(string Icontext)
       {
            Report.WriteLine("Verify the Quote module is present in icon navbar");
            VerifyElementVisible(attributeName_xpath, Deshboard_QuoteText_xpath, Icontext);

        }

        [When(@"I click on the Quote Icon")]
        public void WhenIClickOnTheQuoteIcon()
        {
           
            Report.WriteLine("Clicking on quote module icon");
            
            Click(attributeName_xpath, QuoteModule_Xpath);
                
           
               
        }

        [Then(@"I should be navigated to the Quote List (.*)page")]
        public void ThenIShouldBeNavigatedToTheQuoteListPage(string QuoteList_Header)
        {
            Report.WriteLine("Verfy the header text from quote list page");
            Verifytext(attributeName_xpath, QuoteList_HeaderText_xpath, QuoteList_Header);

        }

    }
}
