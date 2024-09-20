using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class ShipmentList_MoreInformation_StationUsersSteps
    {
        [Given(@"I Log in as Opstage user")]
        public void GivenILogInAsOpstageUser()
        {
            string username = ConfigurationManager.AppSettings["username-OpStage"].ToString();
            string password = ConfigurationManager.AppSettings["password-OpStage"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }
    }
}
