using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class DeleteCustomerFromDb : IDeleteCustomerFromDb
    {
        public void DeleteCustomerDetails(string customerName)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                CustomerSetup customerSetup = context.CustomerSetups.FirstOrDefault(x => x.CustomerName == customerName);
                if(customerSetup != null)
                {
                    int setupID = customerSetup.CustomerSetupId;

                    int customerAccountID = context.CustomerAccounts.FirstOrDefault(x => x.CustomerSetUpId == setupID).CustomerAccountId;

                    List<ActivityLog> csrActivityLogs = context.ActivityLogs.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.ActivityLogs.RemoveRange(csrActivityLogs);

                    List<Address> addresses = context.Addresses.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.Addresses.RemoveRange(addresses);

                    List<Contact> csrContacts = context.Contacts.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.Contacts.RemoveRange(csrContacts);

                    List<CorporateBillingReferenceNumber> csrCorporateBillingReferenceNumbers = context.CorporateBillingReferenceNumbers.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CorporateBillingReferenceNumbers.RemoveRange(csrCorporateBillingReferenceNumbers);

                    List<CustomerAccountMapping> customerAccountMappings = context.CustomerAccountMappings.Where(x => x.SubAccountId == customerAccountID).ToList();
                    context.CustomerAccountMappings.RemoveRange(customerAccountMappings);

                    List<CustomerServiceSpecificEmail> customerServiceSpecificEmails = context.CustomerServiceSpecificEmails.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CustomerServiceSpecificEmails.RemoveRange(customerServiceSpecificEmails);

                    List<InvoicePreference> invoicePreferences = context.InvoicePreferences.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.InvoicePreferences.RemoveRange(invoicePreferences);
                    
                    List<Item> items = context.Items.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.Items.RemoveRange(items);

                    List<Location> csrLocations = context.Locations.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.Locations.RemoveRange(csrLocations);

                    List<PricingModel> csrPricingModels = context.PricingModels.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.PricingModels.RemoveRange(csrPricingModels);

                    List<UserAutoLogin> userAutoLogins = context.UserAutoLogins.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.UserAutoLogins.RemoveRange(userAutoLogins);

                    GainsharePricingModel gainsharePricingModel = context.GainsharePricingModels.FirstOrDefault(x => x.CustomerAccountId == customerAccountID);
                    if (gainsharePricingModel != null)
                    {
                        List<GainShareScacCode> csrGainShareScacCodes = context.GainShareScacCodes.Where(x => x.GainsharePricingModelId == gainsharePricingModel.GainsharePricingModelId).ToList();
                        context.GainShareScacCodes.RemoveRange(csrGainShareScacCodes);
                        List<GainsharePricingModel> gainsharePricingModels = context.GainsharePricingModels.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                        context.GainsharePricingModels.RemoveRange(gainsharePricingModels);
                    }

                    TariffPricingModel tariffPricingModel = context.TariffPricingModels.FirstOrDefault(x => x.CustomerAccountId == customerAccountID);
                    if (tariffPricingModel != null)
                    {
                        List<Fak> csrFaks = context.Faks.Where(x => x.TariffPricingModelId == tariffPricingModel.TariffPricingModelId).ToList();
                        context.Faks.RemoveRange(csrFaks);
                        List<TariffPricingModel> csrTariffPricingModels = context.TariffPricingModels.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                        context.TariffPricingModels.RemoveRange(csrTariffPricingModels);
                    }

                    List<CustomerSpecificReference> customerSpecificReferences = context.CustomerSpecificReferences.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CustomerSpecificReferences.RemoveRange(customerSpecificReferences);

                    List<CustomerSpecificBranding> customerSpecificBrandings = context.CustomerSpecificBrandings.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CustomerSpecificBrandings.RemoveRange(customerSpecificBrandings);

                    List<BumpSurgeCustomerSetUp> bumpSurgeCustomerSetUps = context.BumpSurgeCustomerSetUps.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.BumpSurgeCustomerSetUps.RemoveRange(bumpSurgeCustomerSetUps);

                    List<AccessorialCarrierSetUp> accessorialCarrierSetUps = context.AccessorialCarrierSetUps.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.AccessorialCarrierSetUps.RemoveRange(accessorialCarrierSetUps);

                    List<AccessorialCustomerSetUp> accessorialCustomerSetUps = context.AccessorialCustomerSetUps.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.AccessorialCustomerSetUps.RemoveRange(accessorialCustomerSetUps);

                    List<CustomerApiKey> customerApiKeys = context.CustomerApiKeys.Where(x => x.CustomerSetupId == setupID).ToList();
                    context.CustomerApiKeys.RemoveRange(customerApiKeys);

                    List<CustomerEmail> customerEmails = context.CustomerEmails.Where(x => x.CustomerSetupId == setupID).ToList();
                    context.CustomerEmails.RemoveRange(customerEmails);

                    List<CustomerEndPointMapping> customerEndPointMappings = context.CustomerEndPointMappings.Where(x => x.CustomerSetupId == setupID).ToList();
                    context.CustomerEndPointMappings.RemoveRange(customerEndPointMappings);

                    List<CustomerRateOptionsMapping> customerRateOptionsMappings = context.CustomerRateOptionsMappings.Where(x => x.CustomerSetupId == setupID).ToList();
                    context.CustomerRateOptionsMappings.RemoveRange(customerRateOptionsMappings);

                    List<UserCustomerAccountMapping> userCustomerAccountMappings = context.UserCustomerAccountMappings.Where(x => x.CustomerSetupId == setupID).ToList();
                    context.UserCustomerAccountMappings.RemoveRange(userCustomerAccountMappings);

                    List<CustomerAccount> csrCustomerAccounts = context.CustomerAccounts.Where(x => x.CustomerAccountId == customerAccountID).ToList();
                    context.CustomerAccounts.RemoveRange(csrCustomerAccounts);

                    List<CustomerSetup> customerSetups = context.CustomerSetups.Where(x => x.CustomerSetupId == setupID).ToList();
                    context.CustomerSetups.RemoveRange(customerSetups);

                    context.SaveChanges();
                }
            }
        }
    }
}
