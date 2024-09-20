using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class Quotes_EstimateClassModal_Verbiage_EditSteps
    {
        [Given(@"I logIn as Nat@Ext")]
        public void GivenILogInAsNatExt()
        {
            string username = ConfigurationManager.AppSettings["username-shipentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shipentry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
