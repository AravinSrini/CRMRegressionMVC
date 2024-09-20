using System.Configuration;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Helper.Common
{
    public class UserTypeLoginCredentials
    {
        public UserCredentialsModel GetCredentials(string userType)
        {
            UserCredentialsModel usermodel = new UserCredentialsModel();
            string userNameConfigTag = string.Empty;
            string passwordConfigTag = string.Empty;

            if (userType.Equals("internal", System.StringComparison.InvariantCultureIgnoreCase))
            {
                userNameConfigTag = "InternalUserLogin";
                passwordConfigTag = "InternalUserPassword";
            }
            else if (userType.Equals("external", System.StringComparison.InvariantCultureIgnoreCase))
            {
                userNameConfigTag = "ExternalUserLogin";
                passwordConfigTag = "ExternalUserPassword";
            }
            else if (userType.Equals("stationowner", System.StringComparison.InvariantCultureIgnoreCase))
            {
                userNameConfigTag = "InternalUserLogin";
                passwordConfigTag = "InternalUserPassword";
            }
            else if (userType.Equals("shipentry", System.StringComparison.InvariantCultureIgnoreCase))
            {
                userNameConfigTag = "ExternalUserLogin";
                passwordConfigTag = "ExternalUserPassword";
            }
            else if (userType.Equals("Operations", System.StringComparison.InvariantCultureIgnoreCase))
            {
                userNameConfigTag = "username-crmOperation";
                passwordConfigTag = "password-crmOperation";
            }
            else if (userType.Equals("ClaimSpecialistUser", System.StringComparison.InvariantCultureIgnoreCase))
            {
                userNameConfigTag = "username-claimspecialistClaim";
                passwordConfigTag = "password-claimspecialistClaim";
            }
            else if (userType == "both")
            {
                userNameConfigTag = "username-Both";
                passwordConfigTag = "password-Both";
            }

            usermodel.UserName = ConfigurationManager.AppSettings[userNameConfigTag];
            usermodel.Password = ConfigurationManager.AppSettings[passwordConfigTag];

            return usermodel;
        }
    }
}

//use below 2 lines to call GetCredentials methods for UserCredentialsModel model
//UserTypeLoginCredentials userModel = new UserTypeLoginCredentials();
//UserCredentialsModel userdetails = userModel.GetCredentials("internal");
