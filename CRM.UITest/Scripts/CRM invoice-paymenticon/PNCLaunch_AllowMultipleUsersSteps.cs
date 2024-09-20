using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.CRM_invoice_paymenticon
{
    [Binding]
    public class PNCLaunch_AllowMultipleUsersSteps : ObjectRepository
    {
        [Given(@"I am any user access to PNC Icon")]
        public void GivenIAmAnyUserAccessToPNCIcon()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("I have logged into CRM application");

            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_id, paymentsicon_id, "paymentsicon");
        }

        [Given(@"I am any user access to PNC Icon without claim")]
        public void GivenIAmAnyUserAccessToPNCIconWithoutClaim()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("I have logged into CRM application");
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_id, paymentsicon_id, "paymentsicon");
        }


        [When(@"I Launch PNC portal")]
        public void WhenILaunchPNCPortal()
        {
            Report.WriteLine("I click on Payments icon");
            Click(attributeName_id, paymentsicon_id);

            string url = "https://pncdemo.payerexpress.net/ebp/RRDONNELLEY/BillPay";            
            GlobalVariables.webDriver.WaitForPageLoad();
            bool val = WindowHandling(url);
            if (val == true)
            {
                Report.WriteLine("I will be displaying with PNC portal in New Tab");
            }
        }
        
        [Then(@"I should able to login to PNC portal with my CRM Email (.*) as PNC user")]
        public void ThenIShouldAbleToLoginToPNCPortalWithMyCRMEmailAsPNCUser(string userName)
        {            
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var Claim_TableauUrl = IDP.VerifyIfUserHasClaim(userName, "dlscrm-PncUserName", "Darshan.Kirani");
            if (Claim_TableauUrl == true)
            {
                Report.WriteLine("User have access to log into PNC url as CRM external userid with claim");
            }
            else
            {
                Report.WriteLine("User have access to log into PNC url as CRM external userid without claim");
            }

        }
    }
}
