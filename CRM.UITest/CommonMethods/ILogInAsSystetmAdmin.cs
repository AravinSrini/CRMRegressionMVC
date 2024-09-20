using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class RevisedCSR_AdditionsSavedAddressesOnly_BypassapprovalSteps
    {
        [Given(@"I LogIn to the application as SystemAdmin")]
        public void GivenILogInToTheApplicationAsSystemAdmin()
        {
            string username = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
