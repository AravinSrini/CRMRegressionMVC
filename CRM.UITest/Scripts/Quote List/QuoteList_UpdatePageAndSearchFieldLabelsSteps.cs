using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote_List
{
    [Binding]
    public class QuoteList_UpdatePageAndSearchFieldLabelsSteps : Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        [Given(@"I am a shp\.inquiry, shp\.entry, operations, sales, sales management, or station owner user (.*)")]
        public void GivenIAmAShp_InquiryShp_EntryOperationsSalesSalesManagementOrStationOwnerUser(string userType)
        {
            if (userType == "Internal")
            {
                string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                Report.WriteLine("I logged into CRM application with internal user");
            }
            else
            {
                string userName = ConfigurationManager.AppSettings["username-shpentry"].ToString();
                string password = ConfigurationManager.AppSettings["password-shpentry"].ToString();
                CrmLogin.LoginToCRMApplication(userName, password);
                Report.WriteLine("I logged into CRM application with external user");
            }
        }

        [When(@"I arrive on the Quotes page")]
        public void WhenIArriveOnTheQuotesPage()
        {
            Report.WriteLine("Clicking on quote module icon");
            Click(attributeName_xpath, QuoteModule_Xpath);
        }

        [When(@"I arrive on the Quote List page"), Scope(Tag = "50644")]
        public void WhenIArriveOnTheQuoteListPage()
        {
            Report.WriteLine("Navigating to the Quote List page");
            Click(attributeName_xpath, Deshboard_QuoteText_xpath);            
        }

        [Then(@"the page label will be (.*)")]
        public void ThenThePageLabelWillBe(string QuoteList)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string quotelistHeader = Gettext(attributeName_xpath, QuoteList_HeaderText_xpath);
            Assert.AreNotEqual("Quotes", quotelistHeader);
            Assert.AreEqual(QuoteList, quotelistHeader);
            Report.WriteLine("Quotes header renamed to Quote List");
        }

        [Then(@"the (.*) field will be renamed (.*)\.")]
        public void ThenTheFieldWillBeRenamed_(string p0, string p1)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string searchFieldWatermark = GetValue(attributeName_id, QuoteList_Search_Box_Id, "placeholder");
            Assert.AreNotEqual("Search invoices...", searchFieldWatermark);
            Assert.AreEqual("Search quotes...", searchFieldWatermark);
            Report.WriteLine("search invoices renamed to search quotes");
        }
    }
}
