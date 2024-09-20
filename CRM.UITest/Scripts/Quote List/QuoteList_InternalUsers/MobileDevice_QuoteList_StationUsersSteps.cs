using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class MobileDevice_QuoteList_StationUsersSteps : Quotelist
    {
        ShippingInformationScreenForMobileSteps mobilesteps = new ShippingInformationScreenForMobileSteps();

        string userName = string.Empty;
        string password = string.Empty;
        GenerateQuoteNumber getQuotenumber = new GenerateQuoteNumber();
        
        [Given(@"that I am a sales, sales management, operations, or station owner user(.*)")]
        public void GivenThatIAmASalesSalesManagementOperationsOrStationOwnerUser(string usertype)
        {
            if (usertype == "Internaluser")
            {
                userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
                password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            }
            else if(usertype == "Sales")
            {
                userName = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            }
        }

        [Given(@"I am on a mobile device(.*) and (.*)")]
        public void GivenIAmOnAMobileDeviceAnd(string width, string height)
        {
            mobilesteps.GivenIRe_SizeTheBrowserToMobileDeviceAnd(Convert.ToInt32(width), Convert.ToInt32(height));
        }

        [Given(@"I logged into CRM")]
        public void GivenILoggedIntoCRM()
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application");
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementVisible(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard Page");
            Verifytext(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard");
        }
        
        [When(@"I click on the Quote navigation pane")]
        public void WhenIClickOnTheQuoteNavigationPane()
        {
            Click(attributeName_xpath, hamburgermenuIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_cssselector, QuotesIcon_css, "Quote icon");
            Click(attributeName_cssselector, QuotesIcon_css);
        }
        
        [Then(@"I will navigate to the Quote List page")]
        public void ThenIWillNavigateToTheQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, "//div[@id='page-content-wrapper']//h1[@class='quotes-header']", "Quote List Page");
            Verifytext(attributeName_xpath, ".//*[@id='page-content-wrapper']//h1", "Quote List");
        }
    }
}
