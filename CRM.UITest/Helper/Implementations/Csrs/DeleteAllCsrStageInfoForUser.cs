using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces.Csrs;
using System.Collections.Generic;
using System.Linq;

namespace CRM.UITest.Helper.Implementations.Csrs
{
    public class DeleteAllCsrStageInfoForUser : IDeleteAllCsrStageInfoForUser
    {
        public void DeleteAllCsrStageInformation(string username)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                CsrSetup customerSetup = context.CsrSetups.FirstOrDefault(x => x.CustomerName == username);
                if (customerSetup != null)
                {
                    int customerSetupID = customerSetup.CustomerSetupId;
                    int customerAccountID = context.CsrCustomerAccounts.FirstOrDefault(x => x.CustomerSetUpId == customerSetupID).CustomerAccountId;

                    List<CsrActivityLog> activityLogs = context.CsrActivityLogs.Where(x => x.CustomerSetUpId == customerSetupID).ToList();
                    context.CsrActivityLogs.RemoveRange(activityLogs);

                    List<CsrAddress> csrAddresses = context.CsrAddresses.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrAddresses.RemoveRange(csrAddresses);

                    List<CsrContact> csrContacts = context.CsrContacts.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrContacts.RemoveRange(csrContacts);

                    List<CsrCorporateBillingReferenceNumber> csrCorporateBillingReferenceNumbers = context.CsrCorporateBillingReferenceNumbers.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrCorporateBillingReferenceNumbers.RemoveRange(csrCorporateBillingReferenceNumbers);

                    List<CsrCustomerAccountMapping> csrCustomerAccountMappings = context.CsrCustomerAccountMappings.Where(x => x.SubAccountId == customerAccountID).ToList();
                    context.CsrCustomerAccountMappings.RemoveRange(csrCustomerAccountMappings);

                    List<CsrCustomerServiceSpecificEmail> customerServiceSpecificEmails = context.CsrCustomerServiceSpecificEmails.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrCustomerServiceSpecificEmails.RemoveRange(customerServiceSpecificEmails);

                    List<CsrInvoicePreference> csrInvoicePreferences = context.CsrInvoicePreferences.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrInvoicePreferences.RemoveRange(csrInvoicePreferences);

                    List<CsrItem> csrItems = context.CsrItems.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrItems.RemoveRange(csrItems);

                    List<CsrLocation> csrLocations = context.CsrLocations.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrLocations.RemoveRange(csrLocations);

                    List<CsrPricingModel> csrPricingModels = context.CsrPricingModels.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrPricingModels.RemoveRange(csrPricingModels);

                    List<CsrStationCustomerAccountMapping> csrStationCustomerAccountMappings = context.CsrStationCustomerAccountMappings.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrStationCustomerAccountMappings.RemoveRange(csrStationCustomerAccountMappings);

                    CsrGainsharePricingModel gainsharePricingModel = context.CsrGainsharePricingModels.FirstOrDefault(x => x.CustomerAccountId == customerAccountID);
                    if (gainsharePricingModel != null)
                    {
                        List<CsrGainShareScacCode> csrGainShareScacCodes = context.CsrGainShareScacCodes.Where(x => x.GainsharePricingModelId == gainsharePricingModel.GainsharePricingModelId).ToList();
                        context.CsrGainShareScacCodes.RemoveRange(csrGainShareScacCodes);
                        List<CsrGainsharePricingModel> gainsharePricingModels = context.CsrGainsharePricingModels.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                        context.CsrGainsharePricingModels.RemoveRange(gainsharePricingModels);
                    }
                    
                    CsrTariffPricingModel tariffPricingModel = context.CsrTariffPricingModels.FirstOrDefault(x => x.CustomerAccountId == customerAccountID);
                    if (tariffPricingModel != null)
                    {
                        List<CsrFak> csrFaks = context.CsrFaks.Where(x => x.TariffPricingModelId == tariffPricingModel.TariffPricingModelId).ToList();
                        context.CsrFaks.RemoveRange(csrFaks);
                        List<CsrTariffPricingModel> csrTariffPricingModels = context.CsrTariffPricingModels.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                        context.CsrTariffPricingModels.RemoveRange(csrTariffPricingModels);
                    }

                    List<CsrAccessorialCarrierSetUp> csrAccessorialCarrierSetUps = context.CsrAccessorialCarrierSetUps.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrAccessorialCarrierSetUps.RemoveRange(csrAccessorialCarrierSetUps);

                    List<CsrAccessorialCustomerSetUp> csrAccessorialCustomerSetUps = context.CsrAccessorialCustomerSetUps.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CsrAccessorialCustomerSetUps.RemoveRange(csrAccessorialCustomerSetUps);

                    List<RmApprovalStatu> rmApprovalStatuses = context.RmApprovalStatus.Where(x => x.CustomerSetupId == customerSetupID).ToList();
                    context.RmApprovalStatus.RemoveRange(rmApprovalStatuses);

                    List<User> users = context.Users.Where(x => x.CustomerSetUpId == customerSetupID).ToList();
                    context.Users.RemoveRange(users);

                    List<CsrCustomerAccount> csrCustomerAccounts = context.CsrCustomerAccounts.Where(x => x.CustomerSetUpId == customerSetupID).ToList();
                    context.CsrCustomerAccounts.RemoveRange(csrCustomerAccounts);

                    List<CsrSetup> csrSetups = context.CsrSetups.Where(x => x.CustomerSetupId == customerSetupID).ToList();
                    context.CsrSetups.RemoveRange(csrSetups);
                    context.SaveChanges();
                }

            }
        }
    }
}
