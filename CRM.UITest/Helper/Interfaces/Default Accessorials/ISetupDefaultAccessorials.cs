using CRM.UITest.Entities.Proxy;
using System.Collections.Generic;

namespace CRM.UITest.Helper.Interfaces.Default_Accessorials
{
    public interface ISetupDefaultAccessorials
    {
        bool SetupCustomersDefaultAccessorials(string customerName, List<AccessorialCustomerSetUp> accessorialsToAdd, List<AccessorialCarrierSetUp> carrierAccessorialsToAdd);
        bool SetupPrimaryLevelAccessorialsForSubCustomer(string subCustomerName, string primaryCustomerName, List<AccessorialCustomerSetUp> individualAccessorialsToAdd, List<AccessorialCarrierSetUp> carrierAccessorialsToAdd);
        bool SetupStationLevelAccessorialsForCustomer(string customerName, List<DefaultAccessorialSetup> accessorialsToAdd);
        bool SetupCorporateLevelAccessorialsForCustomer(string customerName, List<DefaultAccessorialSetup> accessorialsToAdd);

        bool SetupStationAccessorialsForSubCustomer(string subCustomerName, string primaryCustomerName, List<DefaultAccessorialSetup> accessorialsToAdd);

        bool SetupCorporateAccessorialsForSubCustomer(string subCustomerName, string primaryCustomerName, List<DefaultAccessorialSetup> accessorialsToAdd);
    }
}
