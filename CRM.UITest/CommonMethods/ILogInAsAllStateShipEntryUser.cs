using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class AddShipment_LTL_CustomerSpecificReferencesSteps
    {
        [Given(@"I logIn as AllStaeShipeEntery user")]
        public void GivenILogInAsAllStaeShipeEnteryUser()
        {
            string username = ConfigurationManager.AppSettings["username-Allstateshipentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-Allstateshipentry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
