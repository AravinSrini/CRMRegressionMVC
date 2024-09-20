using CRM.UITest.CommonMethods;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class ShipEntryNoRateUser
    {
        [Given(@"I am shp\.entryNorates")]
        public void GivenIAmShp_EntryNorates()
        {
            string username = ConfigurationManager.AppSettings["username-Entyrnorates"].ToString();
            string password = ConfigurationManager.AppSettings["password-Entyrnorates"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
