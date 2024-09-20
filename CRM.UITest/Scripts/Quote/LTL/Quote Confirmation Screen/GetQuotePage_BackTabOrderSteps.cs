using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Quote.LTL.Quote_Confirmation_Screen
{
    [Binding]
    public class GetQuotePage_BackTabOrderSteps : Quotelist
    {
        [Given(@"I have logged in as a ShipEntry user")]
        public void GivenIHaveLoggedInAsAShipEntryUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have logged in as a station owner")]
        public void GivenIHaveLoggedInAsAStationOwner()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have logged in as a sales management")]
        public void GivenIHaveLoggedInAsASalesManagement()
        {
            string username = ConfigurationManager.AppSettings["username-SalesManager"].ToString();
            string password = ConfigurationManager.AppSettings["password-SalesManager"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have logged in as a shpInquiry user")]
        public void GivenIHaveLoggedInAsAShpInquiryUser()
        {
            string username = ConfigurationManager.AppSettings["username-shpInquiry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shpInquiry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        [Given(@"I have logged in as a sales operations")]
        public void GivenIHaveLoggedInAsASalesOperations()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I am in Get quote page")]
        public void GivenIAmInGetQuotePage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteIconModule_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, GetQuote_Ltlimage_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        

        [Given(@"I am in Get quote page as a internal user")]
        public void GivenIAmInGetQuotePageAsAInternalUser()
        {
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            string customerName = "ZZZ - GS Customer Test";
        
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, customerName);

            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            Click(attributeName_id, GetQuote_Ltlimage_id);
        }

        [When(@"focus on '(.*)' and I do back tab")]
        public void WhenFocusOnAndIDoBackTab(string p0)
        {
            IWebElement _SelectQuoteRequestButton = GlobalVariables.webDriver.FindElement(By.Id(GetQuote_ViewQuoteResult_Button_Id));
            _SelectQuoteRequestButton.SendKeys(Keys.Shift + Keys.Tab);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"the tab order will be from View Quote Results button to Enter zip/postal code")]
        public void ThenTheTabOrderWillBeFromViewQuoteResultsButtonToEnterZipPostalCode()
        {
            IWebElement _SelectFreightWeight = GlobalVariables.webDriver.FindElement(By.Id(QuoteDetails_FreightInfo_Weightfield_id));
            _SelectFreightWeight.SendKeys(Keys.Shift + Keys.Tab);


            IWebElement _SelectSaveItem = GlobalVariables.webDriver.FindElement(By.Id(SelectSavedItem_Id));
            _SelectSaveItem.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement _SelectDestinationZip = GlobalVariables.webDriver.FindElement(By.Id(QuoteDetails_Destination_AddressZip_Id));
            _SelectDestinationZip.SendKeys(Keys.Shift + Keys.Tab);

            IWebElement _SelectOriginZip = GlobalVariables.webDriver.FindElement(By.Id(QuoteDetails_Origin_AddressZip_Id));
            _SelectOriginZip.SendKeys(Keys.Shift + Keys.Tab);

            
        }
    }
}
