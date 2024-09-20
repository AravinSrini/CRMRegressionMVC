using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.CustomerDetails
{
    [Binding]
    public class CustomerDetailsPageLoadSteps : Submit_CSR
    {
        string getAccountName = string.Empty;
        string accountName = "jan142019";
        string accountNameInternal = "2018 Agent Meeting";

        [Given(@"I am a user who have access to Account Management module '(.*)' , '(.*)'")]
        public void GivenIAmAUserWhoHaveAccessToAccountManagementModule(string Username, string Password)
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            string username = ConfigurationManager.AppSettings[Username].ToString();
            string password = ConfigurationManager.AppSettings[Password].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on Customer Profiles page")]
        public void GivenIAmOnCustomerProfilesPage()
        {
            Click(attributeName_xpath, UserManagementIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, AccountManagementPage_Header_Xpath, "Account Management");
            Report.WriteLine("Navigated to Customer Profiles section of Account Management page");
        }

        [When(@"I click on Account Management icon")]
        public void WhenIClickOnAccountManagementIcon()
        {
            Click(attributeName_xpath, UserManagementIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Account Managemnet icon");
        }

        [When(@"I click on any account from the customer Profiles page")]
        public void WhenIClickOnAnyAccountFromTheCustomerProfilesPage()
        {
            SendKeys(attributeName_id, SearchCustomer_id, accountName);
            AccountSelection();

        }

        [When(@"I click on an account from the Customer Profiles page")]
        public void WhenIClickOnAnAccountFromTheCustomerProfilesPage()
        {
            SendKeys(attributeName_id, SearchCustomer_id, accountNameInternal);//OperationUserAccount
            AccountSelection();
        }

        [Then(@"I should be navigated to the Customer Details page")]
        public void ThenIShouldBeNavigatedToTheCustomerDetailsPage()
        {
            Verifytext(attributeName_xpath, CustomerDetailspageHeader_Xpath, "Customer Details");
            Report.WriteLine("Navigated to Customer Details page");
            string getCustomerNameUI = Gettext(attributeName_id, CustomerDetails_CustomerName_Id);
            Assert.AreEqual("ZZZ - GS Customer Test", getCustomerNameUI);
            Report.WriteLine("Customer details page is opened for the account selected");
        }


        [Then(@"I should be navigated to Customer Details page")]
        public void ThenIShouldBeNavigatedToCustomerDetailsPage()
        {
            Verifytext(attributeName_xpath, CustomerDetailspageHeader_Xpath, "Customer Details");
            Report.WriteLine("Navigated to Customer Details page");
            string getCustomerNameUI = Gettext(attributeName_id, CustomerDetails_CustomerName_Id);
            Assert.AreEqual(getAccountName, getCustomerNameUI);
            Report.WriteLine("Customer details page is opened for the account selected");
        }

        public void AccountSelection()
        {
            getAccountName = Gettext(attributeName_xpath, SearchedCustomer_Xpath);
            Click(attributeName_linktext, getAccountName);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on an account from the customer Profiles page");
        }
    }
}
