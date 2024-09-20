using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_NavigationIconSteps: Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"that I am any user")]
        public void GivenThatIAmAnyUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();            
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I am an " + userName + " user of CRM with claim");
        }

        [Given(@"I have been given access to view the Customer Invoice feature")]
        public void GivenIHaveBeenGivenAccessToViewTheCustomerInvoiceFeature()
        {
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string userName = ConfigurationManager.AppSettings["username-crmOperation"];            
            var Claim_TableauUrl = idp.VerifyIfUserHasClaim(userName, "dlscrm-role", "ShowCustomerInvoiceIcon");
            if (Claim_TableauUrl == true)
            {
                Report.WriteLine("User have access to view the Customer Invoice Icon");
            }
            else
            {
                Report.WriteLine("User doesn't have access to view the Customer Invoice Icon");
            }
        }

        [When(@"I log into CRM")]
        public void WhenILogIntoCRM()
        {
            Report.WriteLine("I have logged into CRM application");
            VerifyElementVisible(attributeName_xpath, DashboardText_Xpath, "Dashboard");
        }

        [Then(@"I can view the Customer Invoice Icon in the left navigation pane")]
        public void ThenICanViewTheCustomerInvoiceIconInTheLeftNavigationPane()
        {            
            VerifyElementVisible(attributeName_xpath, customerInvoiceIcon_xpath, "CustomerInvoice");
            Report.WriteLine("Customer Invoice Icon visible in th left navigation pane");
        }

        [Given(@"that I am any user without claim")]
        public void GivenThatIAmAnyUserWithoutClaim()
        {
            string userNameWithOutClaim = ConfigurationManager.AppSettings["username-SalesManager"].ToString();
            string passwordWithOutClaim = ConfigurationManager.AppSettings["password-SalesManager"].ToString();
            CrmLogin.LoginToCRMApplication(userNameWithOutClaim, passwordWithOutClaim);
            Report.WriteLine("I am an " + userNameWithOutClaim + " user of CRM with out customer invoice claim");
        }

        [Given(@"I have been not given access to view the Customer Invoice feature")]
        public void GivenIHaveBeenNotGivenAccessToViewTheCustomerInvoiceFeature()
        {
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string userNameWithOutClaim = ConfigurationManager.AppSettings["username-SalesManager"].ToString();            
            var Claim_TableauUrl = idp.VerifyIfUserHasClaim(userNameWithOutClaim, "dlscrm-role", "ShowCustomerInvoiceIcon");
            if (Claim_TableauUrl == false)
            {
                Report.WriteLine("User doesn't have access to view the Customer Invoice Icon");
            }
            else
            {
                Report.WriteLine("User have access to view the Customer Invoice Icon");
            }
        }

        [Then(@"I should not view the Customer Invoice Icon in the left navigation pane")]
        public void ThenIShouldNotViewTheCustomerInvoiceIconInTheLeftNavigationPane()
        {            
            VerifyElementNotPresent(attributeName_xpath, customerInvoiceIcon_xpath, "CustomerInvoice");
            Report.WriteLine("Customer Invoice Icon not displaying in th left navigation pane");
        }        

    }
}
