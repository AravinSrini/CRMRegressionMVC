using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class LiabilityCoverage_RateRequest_DisplayLiabilityCostPerPoundSteps
    {
        [Given(@"I login as Ship entry user")]
        public void GivenILoginAsShipEntryUser()
        {
            string username = ConfigurationManager.AppSettings["username-shipentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shipentry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
