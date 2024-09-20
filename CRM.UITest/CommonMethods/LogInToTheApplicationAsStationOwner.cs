using CRM.UITest.CommonMethods;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class LogInToTheApplicationAsStationOwner
    {
        [Given(@"I  login into application as StationOwner")]
        public void GivenILoginIntoApplicationAsStationOwner()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
