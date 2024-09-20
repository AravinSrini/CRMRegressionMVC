using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class TrackingLandingPage_DesktopSteps
    {
        [Given(@"I log in to the application as user zzzz")]
        public void GivenILogInToTheApplicationAsUserZzzz()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
