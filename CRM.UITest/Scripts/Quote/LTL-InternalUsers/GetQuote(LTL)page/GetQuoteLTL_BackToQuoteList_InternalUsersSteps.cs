using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using System.Configuration;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.GetQuote_LTL_page
{
    [Binding]
    public class GetQuoteLTL_BackToQuoteList_InternalUsersSteps: Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        [Given(@"I am a DLS user and login into an application with valid Username and Password")]
        public void GivenIAmADLSUserAndLoginIntoAnApplicationWithValidUsernameAndPassword()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I have clicked on Submit Rate Request button")]
        public void GivenIHaveClickedOnSubmitRateRequestButton()
        {
            Report.WriteLine("I have clicked on Submit Rate Request button");
            Click(attributeName_id, SubmitRateRequestBtn_id);
        }

        [Given(@"I should be navigated to the Quote List (.*)page")]
        public void GivenIShouldBeNavigatedToTheQuoteListPage(string QuoteList_Header)
        {
            Report.WriteLine("Verify the Quote List header");
           // WaitForElementNotVisible(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
            WaitForElementVisible(attributeName_xpath, QuoteList_HeaderText_xpath, "Quotes");
            string QuoteList_Header_UI = Gettext(attributeName_xpath, QuoteList_HeaderText_xpath);
            Assert.AreEqual(QuoteList_Header, QuoteList_Header_UI);
        }

        [Given(@"I have select the (.*) from customer dropdown list")]
        public void GivenIHaveSelectTheFromCustomerDropdownList(string Customer_Name)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Select Customer Name from the dropdown list");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {                    
                    DropDownList[i].Click();
                    break;
                }
            }            
        }
        [Given(@"I have clicked on LTL Tile of rate request process")]
        public void GivenIHaveClickedOnLTLTileOfRateRequestProcess()
        {
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);
        }
                
        [When(@"I click on Back to Quote List button"), Scope(Feature = "Get Quote (LTL)_Back to Quote List_InternalUsers")]
        public void WhenIClickOnBackToQuoteListButton()
        {
            Report.WriteLine("Click on Back to Quote List button");
            Click(attributeName_id, BacktoQuoteListBtn_id);
        }
        
        [Then(@"I should be displayed with Back to Quote List button")]
        public void ThenIShouldBeDisplayedWithBackToQuoteListButton()
        {
            Report.WriteLine("Displayed with Back to Quote List button in Shipment Information Page");
            VerifyElementVisible(attributeName_id, BacktoQuoteListBtn_id, "Back to Quote List");
        }
        
        [Then(@"I should be navigated back to quote list page")]
        public void ThenIShouldBeNavigatedBackToQuoteListPage()
        {
            Report.WriteLine("I should be navigated back to Quote List Page");
            WaitForElementVisible(attributeName_xpath, QuoteList_HeaderText_xpath, "Quotes");
            VerifyElementVisible(attributeName_id, SubmitRateRequestBtn_id, "Submit Rate Request");
            //VerifyElementVisible(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath, "All Customers"); --all customers was removed now
        }      
       
    }
}
