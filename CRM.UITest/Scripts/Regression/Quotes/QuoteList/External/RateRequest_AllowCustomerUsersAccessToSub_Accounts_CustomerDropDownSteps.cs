using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Quote_List.QuoteList_ExternalUsers
{
    [Binding]
    public class RateRequest_AllowCustomerUsersAccessToSub_Accounts_CustomerDropDownSteps : Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        AddQuoteLTL quoteLtl = new AddQuoteLTL();
        WebElementOperations getListfromWebElement = new WebElementOperations();

        [Given(@"I am a shp\.inquiry or shp\.entry user associated to a primary account that has sub-accounts")]
        public void GivenIAmAShp_InquiryOrShp_EntryUserAssociatedToAPrimaryAccountThatHasSub_Accounts()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [When(@"I arrive on Quote List page")]
        public void WhenIArriveOnQuoteListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.NaviagteToQuoteList();
        }
        
        [When(@"I click on the customer list drop down")]
        public void WhenIClickOnTheCustomerListDropDown()
        {
            quoteLtl.NaviagteToQuoteList();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
        }

        [Then(@"the grid will be displayed with the message Please select a customer to view Quotes")]
        public void ThenTheGridWillBeDisplayedWithTheMessagePleaseSelectACustomerToViewQuotes()
        {
            string expectedMessage = "Please select a customer to view Quotes";
            string actualGridMessage = Gettext(attributeName_xpath, QuoteList_NoResults_Xpath);
            Assert.AreEqual(actualGridMessage, expectedMessage);            
        }

        [Then(@"the customer drop down will be displayed with Select")]
        public void ThenTheCustomerDropDownWillBeDisplayedWithSelect()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string actualSelectOption = Gettext(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Assert.AreEqual(actualSelectOption, "Select...");
        }

        [Then(@"the Customer drop down list will be displayed with options Select All Customers, primary account and mapped subaccounts")]
        public void ThenTheCustomerDropDownListWillBeDisplayedWithOptionsSelectAllCustomersPrimaryAccountAndMappedSubaccounts()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            //Customer dropdown default to Select
            string actualSelectOption = Gettext(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Assert.AreEqual(actualSelectOption, "Select...");
            GlobalVariables.webDriver.WaitForPageLoad();
            //Customer Drop down displaying with Select, All Customers,Primary account and mapped subaccounts
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> CustomerAllUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            List<string> dropdownOptions = getListfromWebElement.GetListFromIWebElement(CustomerAllUI);
            Report.WriteLine("Customer Dropdown displaying with " + dropdownOptions.Contains("Select..."));
            Report.WriteLine("Customer Dropdown displaying with " + dropdownOptions.Contains("All Customers"));
            Report.WriteLine("Customer Dropdown displaying with " + dropdownOptions.Contains(customerNameActual));            

            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));
            List<string> primarySubAccountsUI = getListfromWebElement.GetListFromIWebElement(subAccounts);
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);            
            
            Assert.AreEqual(customerNamesList.Count, primarySubAccountsUI.Count);
            Report.WriteLine("Customer Dropdown displayed with Sub accounts");                              
        }
        
        [Then(@"the Submit Rate Request button will be hidden")]
        public void ThenTheSubmitRateRequestButtonWillBeHidden()
        {
            Report.WriteLine("Visibility of Submit Rate Request button");
            bool rateRequestVisibility = ElementNotPresent(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath, "Submit Rate Request");
            if (rateRequestVisibility == false)
            {
                Report.WriteLine("Submit Rate Request button is not available");
            }
            else
            {
                throw new System.Exception("Submit Rate Request button is available");
            }
        }

        [Then(@"the customers will be displayd in hierarchy format")]
        public void ThenTheCustomersWillBeDisplaydInHierarchyFormat()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";            
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);
                        
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);            
            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));
            List<string> SubAccountListValues = getListfromWebElement.GetListFromIWebElement(subAccounts);

            Assert.AreEqual(customerNamesList.Count, SubAccountListValues.Count);          
            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account");              
        }

        [Then(@"the sub-accounts will be displayed in alphabetical order")]
        public void ThenTheSub_AccountsWillBeDisplayedInAlphabeticalOrder()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));
            List<string> actualDropdownlist = getListfromWebElement.GetListFromIWebElement(dropDownList);         
                        
            List<string> alphabeticalArray = new List<string>();
            for (int i = 0; i < actualDropdownlist.Count; i++)
            {
                alphabeticalArray.Add(actualDropdownlist[i]);
            }
            actualDropdownlist.Sort();
            CollectionAssert.AreEqual(actualDropdownlist, alphabeticalArray);
            Report.WriteLine("Displayed Customers are sorted in alphabetical order");
        }
    }
}
