using System;
using System.Collections.Generic;
using System.Linq;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces.Default_Accessorials;

namespace CRM.UITest.Helper.Implementations.Default_Accessorials
{
    public class SetupDefaultAccessoirals : ISetupDefaultAccessorials
    {
        public bool SetupCustomersDefaultAccessorials(string customerName, List<AccessorialCustomerSetUp> individualAccessorialsToAdd, List<AccessorialCarrierSetUp> carrierAccessorialsToAdd)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int customerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == customerName).CustomerAccountId;

                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == customerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == customerAccountId));

                foreach (AccessorialCustomerSetUp accessorial in individualAccessorialsToAdd)
                {
                    accessorial.CustomerAccountId = customerAccountId;
                }

                context.AccessorialCustomerSetUps.AddRange(individualAccessorialsToAdd);

                foreach (AccessorialCarrierSetUp accessorial in carrierAccessorialsToAdd)
                {
                    accessorial.CustomerAccountId = customerAccountId;
                }

                context.AccessorialCarrierSetUps.AddRange(carrierAccessorialsToAdd);

                int changes = context.SaveChanges();
                return changes > 0;
            }
        }

        public bool SetupPrimaryLevelAccessorialsForSubCustomer(string subCustomerName, string primaryCustomerName, List<AccessorialCustomerSetUp> individualAccessorialsToAdd, List<AccessorialCarrierSetUp> carrierAccessorialsToAdd)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int subCustomerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == subCustomerName).CustomerAccountId;
                int primaryCustomerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == primaryCustomerName).CustomerAccountId;

                context.CustomerAccountMappings.RemoveRange(context.CustomerAccountMappings.Where(x => x.SubAccountId == subCustomerAccountId));

                context.CustomerAccountMappings.Add(new CustomerAccountMapping()
                {
                    PrimaryAccountId = primaryCustomerAccountId,
                    SubAccountId = subCustomerAccountId,
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                });

                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == primaryCustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == primaryCustomerAccountId));
                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == subCustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == subCustomerAccountId));

                foreach (AccessorialCustomerSetUp accessorial in individualAccessorialsToAdd)
                {
                    accessorial.CustomerAccountId = primaryCustomerAccountId;
                }

                context.AccessorialCustomerSetUps.AddRange(individualAccessorialsToAdd);

                foreach (AccessorialCarrierSetUp accessorial in carrierAccessorialsToAdd)
                {
                    accessorial.CustomerAccountId = primaryCustomerAccountId;
                }

                context.AccessorialCarrierSetUps.AddRange(carrierAccessorialsToAdd);

                int changes = context.SaveChanges();
                return changes > 0;
            }
        }

        public bool SetupStationLevelAccessorialsForCustomer(string customerName, List<DefaultAccessorialSetup> accessorialsToAdd)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomerAccount customerAccount = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == customerName);
                context.CustomerAccountMappings.RemoveRange(context.CustomerAccountMappings.Where(x => x.SubAccountId == customerAccount.CustomerAccountId));

                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == customerAccount.CustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == customerAccount.CustomerAccountId));

                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == customerAccount.StationId));

                foreach (DefaultAccessorialSetup accessorial in accessorialsToAdd)
                {
                    accessorial.StationId = customerAccount.StationId;
                }

                context.DefaultAccessorialSetups.AddRange(accessorialsToAdd);

                int changes = context.SaveChanges();
                return changes > 0;
            }
        }

        public bool SetupCorporateLevelAccessorialsForCustomer(string customerName, List<DefaultAccessorialSetup> accessorialsToAdd)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomerAccount customerAccount = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == customerName);
                context.CustomerAccountMappings.RemoveRange(context.CustomerAccountMappings.Where(x => x.SubAccountId == customerAccount.CustomerAccountId));

                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == customerAccount.CustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == customerAccount.CustomerAccountId));

                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == customerAccount.StationId));
                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == null));

                context.DefaultAccessorialSetups.AddRange(accessorialsToAdd);

                int changes = context.SaveChanges();
                return changes > 0;
            }
        }

        public bool SetupStationAccessorialsForSubCustomer(string subCustomerName, string primaryCustomerName, List<DefaultAccessorialSetup> accessorialsToAdd)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int subCustomerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == subCustomerName).CustomerAccountId;
                int primaryCustomerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == primaryCustomerName).CustomerAccountId;

                context.CustomerAccountMappings.RemoveRange(context.CustomerAccountMappings.Where(x => x.SubAccountId == subCustomerAccountId));

                context.CustomerAccountMappings.Add(new CustomerAccountMapping()
                {
                    PrimaryAccountId = primaryCustomerAccountId,
                    SubAccountId = subCustomerAccountId,
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                });

                CustomerAccount customerAccount = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == subCustomerName);

                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == primaryCustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == primaryCustomerAccountId));
                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == subCustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == subCustomerAccountId));

                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == customerAccount.StationId));
                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == null));

                foreach (DefaultAccessorialSetup accessorial in accessorialsToAdd)
                {
                    accessorial.StationId = customerAccount.StationId;
                }

                context.DefaultAccessorialSetups.AddRange(accessorialsToAdd);

                int changes = context.SaveChanges();
                return changes > 0;
            }
        }

        public bool SetupCorporateAccessorialsForSubCustomer(string subCustomerName, string primaryCustomerName, List<DefaultAccessorialSetup> accessorialsToAdd)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int subCustomerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == subCustomerName).CustomerAccountId;
                int primaryCustomerAccountId = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == primaryCustomerName).CustomerAccountId;

                context.CustomerAccountMappings.RemoveRange(context.CustomerAccountMappings.Where(x => x.SubAccountId == subCustomerAccountId));

                context.CustomerAccountMappings.Add(new CustomerAccountMapping()
                {
                    PrimaryAccountId = primaryCustomerAccountId,
                    SubAccountId = subCustomerAccountId,
                    CreatedBy = "Automation  108081",
                    CreatedDate = DateTime.UtcNow,
                    ModifiedBy = "Automation  108081",
                    ModifiedDate = DateTime.UtcNow,
                });

                CustomerAccount customerAccount = context.CustomerAccounts.Single(x => x.CustomerSetup.CustomerName == subCustomerName);

                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == primaryCustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == primaryCustomerAccountId));
                context.AccessorialCustomerSetUps.RemoveRange(context.AccessorialCustomerSetUps.Where(x => x.CustomerAccount.CustomerAccountId == subCustomerAccountId));
                context.AccessorialCarrierSetUps.RemoveRange(context.AccessorialCarrierSetUps.Where(x => x.CustomerAccount.CustomerAccountId == subCustomerAccountId));
                
                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == customerAccount.StationId));
                context.DefaultAccessorialSetups.RemoveRange(context.DefaultAccessorialSetups.Where(x => x.StationId == null));

                context.DefaultAccessorialSetups.AddRange(accessorialsToAdd);

                int changes = context.SaveChanges();
                return changes > 0;
            }
        }
    }
}
