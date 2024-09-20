
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class ShipEntryRatesUser
    {
        [Given(@"I am shp entry Rate user")]
        public void GivenIAmShpEntryRateUser()
        {
            string username = ConfigurationManager.AppSettings["username-DefaultShipOrigi"].ToString();
            string password = ConfigurationManager.AppSettings["password-DefaultShipOrigi"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
