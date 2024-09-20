using CRM.UITest.Entities.DocRepo;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.DataModels.CustomerInvoice;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CRM.UITest.Entities
{
    class DBHelper
    {
        public static int GetAccountNumber(int setupID)
        {
            int AccNumb = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                AccNumb = (from value in context.CustomerAccounts
                           where value.CustomerSetUpId == setupID
                           select value.CustomerAccountId).FirstOrDefault();
            }

            return AccNumb;
        }

        public static List<int> GetCustomerAccountNumber(List<int> custSetupId)
        {
            List<int> value = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from set in context.CustomerAccounts
                         where custSetupId.Contains(set.CustomerSetUpId)
                         select set.CustomerAccountId).ToList();
            }
            return value;
        }


        public static List<int> GetClaimNumberforAssociatedCustomers(List<int> custSetupId)
        {
            List<int> value = new List<int>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from set in context.InsuranceClaims
                         join a in custSetupId
                         on set.CustomerSetUpId equals a
                         where a == (set.CustomerSetUpId)
                         select set.ClaimNumber).ToList();
            }
            return value;
        }


        public static List<string> CustomerNameOfSubAccountUnderPrimaryAccount(List<int> custAccId)
        {
            List<string> CustomerNameList = new List<string>();
            using (WWProxyEntities context = new WWProxyEntities())
            {


                List<int> SubAccounts = (from cus in context.CustomerAccountMappings
                                         where custAccId.Contains(cus.PrimaryAccountId)
                                         select cus.SubAccountId).ToList();

                foreach (int SubAccount in SubAccounts)
                {
                    int CustomerSetupId = (from cus in context.CustomerAccounts
                                           where cus.CustomerAccountId == SubAccount
                                           select cus.CustomerSetUpId).First();

                    string CustomerName = (from cus in context.CustomerSetups
                                           where cus.CustomerSetupId == CustomerSetupId
                                           select cus.CustomerName).First();

                    CustomerNameList.Add(CustomerName);

                }

            }

            return CustomerNameList;
        }



        public static string CustomerName(int setupID)
        {
            string custName = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                custName = (from value in context.CustomerSetups
                            where value.CustomerSetupId == setupID
                            select value.CustomerName).FirstOrDefault();
            }

            return custName;
        }


        public static List<string> CustomerNameOfPrimaryAccount(List<int> custSetupId)
        {
            List<string> CustomerNames = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                CustomerNames = (from cus in context.CustomerSetups
                                 where custSetupId.Contains(cus.CustomerSetupId)
                                 select cus.CustomerName).ToList();

            }
            return CustomerNames;
        }


        public static Address GetShipperAddressforAccount(List<int> customerAcctId)
        {
            Address addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where customerAcctId.Contains(add.CustomerAccountId) && add.AddressTypeId == 3
                            select add).FirstOrDefault();
            }

            return addvalue;
        }

        public static Address GetConsigneeAddressforAccount(List<int> customerAcctId)
        {
            Address addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where customerAcctId.Contains(add.CustomerAccountId) && add.AddressTypeId == 4
                            select add).FirstOrDefault();
            }

            return addvalue;
        }

        public static List<string> Get_CustomerNameOfPrimaryAccount(int custSetupId)
        {
            List<string> CustomerNames = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                CustomerNames = (from cus in context.CustomerSetups
                                 where cus.CustomerSetupId == custSetupId
                                 select cus.CustomerName).ToList();

            }
            return CustomerNames;
        }

        public static List<int> Get_AssociatedClaimNumber(int custSetupId)
        {
            List<int> ClaimNumbers = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                ClaimNumbers = (from cus in context.InsuranceClaims
                                where cus.CustomerSetUpId == custSetupId
                                select cus.ClaimNumber).Distinct().ToList();

            }
            return ClaimNumbers;
        }





        public static List<string> GetCustomerNameOfSubAccountUnderPrimaryAccount(string CustomerNameFromDD)
        {
            List<string> CustomerNameList = new List<string>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int setUpId = (from cus in context.CustomerSetups
                               where cus.CustomerName == CustomerNameFromDD
                               select cus.CustomerSetupId).First();
                int acctId = (from cus in context.CustomerAccounts
                              where cus.CustomerSetUpId == setUpId
                              select cus.CustomerAccountId).First();

                List<int> SubAccounts = (from cus in context.CustomerAccountMappings
                                         where cus.PrimaryAccountId == acctId
                                         select cus.SubAccountId).ToList();

                foreach (int SubAccount in SubAccounts)
                {
                    int CustomerSetupId = (from cus in context.CustomerAccounts
                                           where cus.CustomerAccountId == SubAccount
                                           select cus.CustomerSetUpId).First();

                    string CustomerName = (from cus in context.CustomerSetups
                                           where cus.CustomerSetupId == CustomerSetupId
                                           select cus.CustomerName).First();

                    CustomerNameList.Add(CustomerName);

                }

            }

            return CustomerNameList;
        }


        public static List<string> GetCustomerNameFromCustomerInvoice()
        {
            List<string> CustomerNameList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                CustomerNameList = (from cus in context.CustomerInvoices
                                    select cus.CustomerName).ToList();

            }
            return CustomerNameList;
        }

        public static string GetCustomerSapAccountNumber(string customerName)
        {
            string sapAccountnumber = string.Empty;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                sapAccountnumber = (from reference in context.CorporateBillingReferenceNumbers
                                    where reference.CustomerAccount.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                                    select reference.SAPAccountNumber).FirstOrDefault();
            }

            return sapAccountnumber;
        }

        public static List<string> GetAddressesforAccount(int accountID)
        {
            List<string> addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID
                            select add.Name + " " + add.Address1 + "  " + add.City + " " + add.State + "  " + add.Country + " " + add.Zip).Take(100).ToList();
            }

            return addvalue;
        }



        public static List<string> GetAddressesforAccount_withSearchCriteria(int accountID, string searchText)
        {
            List<string> addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID
                            && add.Name.StartsWith(searchText)
                            select add.Name + ", " + add.Address1 + ", " + add.City + ", " + add.State + "," + add.Country + ", " + add.Zip).Take(100).ToList();
            }

            return addvalue;
        }
        public static List<Address> GetAddressesforAccountonName(int accountID, string name)
        {
            List<Address> addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.Name.Contains(name)
                            select add).Take(100).ToList();
            }

            return addvalue;
        }

        public static List<Address> GetAddressesforAccountName(int accountID, string name)
        {
            List<Address> addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.Name == name
                            select add).Take(100).ToList();
            }

            return addvalue;
        }

        public static Address GetShipperAddressforAccount(int accountID)
        {
            Address addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.AddressTypeId == 3
                            select add).FirstOrDefault();
            }

            return addvalue;
        }






        public static Address Get_ShipperAddressInternalUsers(string accountName)
        {
            Address addvalue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int accountID = (from value in context.CustomerAccounts
                                 where value.CustomerSetUpId == id
                                 select value.CustomerAccountId).FirstOrDefault();


                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.AddressTypeId == 3
                            select add).FirstOrDefault();

            }
            return addvalue;
        }


        public static List<string> Get_Addresses(string accountName)
        {
            List<string> Address = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int _accountId = (from value in context.CustomerAccounts
                                  where value.CustomerSetUpId == id
                                  select value.CustomerAccountId).FirstOrDefault();

                Address = (from data in context.Addresses
                           where data.CustomerAccountId == _accountId
                           orderby data.Name
                           select data.Name + " " + data.Address1 + " " + data.Address2 + " " + data.City + " " + data.State + "  " + data.Country + " " + data.Zip + " " + data.ContactName + " " + data.PhoneNumber + " " + data.EmailId + " " + data.FaxNumber).ToList();

            }
            return Address;
        }

        public static Address Get_Addresses_Name(string accountName, string selectedAddress)
        {
            Address _addressDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int _accountId = (from value in context.CustomerAccounts
                                  where value.CustomerSetUpId == id
                                  select value.CustomerAccountId).FirstOrDefault();

                _addressDetails = (from data in context.Addresses
                                   orderby data.Name
                                   where data.CustomerAccountId == _accountId
                                     && (data.Name.ToUpper() + " " + data.Address1.ToUpper() + " " + data.Address2.ToUpper() + " " + data.City.ToUpper() + " " + data.State.ToUpper() + "  " + data.Country.ToUpper() + " " + data.Zip.ToUpper() + " " + data.ContactName.ToUpper() + " " + data.PhoneNumber.ToUpper() + " " + data.EmailId.ToUpper() + " " + data.FaxNumber.ToUpper()).Contains(selectedAddress)
                                   select data).FirstOrDefault();
            }
            return _addressDetails;
        }

        public static Address Get_AddressesNameNewScreen(string accountName, string selectedAddress, string originName)
        {
            Address _addressDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int _accountId = (from value in context.CustomerAccounts
                                  where value.CustomerSetUpId == id
                                  select value.CustomerAccountId).FirstOrDefault();

                _addressDetails = (from data in context.Addresses
                                   where data.CustomerAccountId == _accountId && (data.Name) == originName
                                   select data).FirstOrDefault();
            }
            return _addressDetails;
        }

        public static List<string> GetTop100Address_By_searchedhName(string accountName, string SearchName)
        {
            List<string> _address = new List<string>();
            using (WWProxyEntities context = new WWProxyEntities())
            {

                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int _accountId = (from value in context.CustomerAccounts
                                  where value.CustomerSetUpId == id
                                  select value.CustomerAccountId).FirstOrDefault();

                _address = (from data in context.Addresses
                            where data.CustomerAccountId == _accountId && data.Name.Contains(SearchName)
                            orderby data.Name
                            select (data.Name.ToUpper() + " " + data.Address1.ToUpper() + " " + data.Address2.ToUpper() + " " + data.City.ToUpper() + " " + data.State.ToUpper() + " " + data.Country.ToUpper() + " " + data.Zip.ToUpper() + " " + data.ContactName.ToUpper() + " " + data.PhoneNumber.ToUpper() + " " + data.EmailId.ToUpper() + " " + data.FaxNumber.ToUpper())).Take(100).ToList();
            }
            return _address;
        }

        public static Address GetAddress_By_searchedhName(string accountName, string SearchName)
        {
            Address _address = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int _accountId = (from value in context.CustomerAccounts
                                  where value.CustomerSetUpId == id
                                  select value.CustomerAccountId).FirstOrDefault();

                _address = (from data in context.Addresses
                            where data.CustomerAccountId == _accountId && data.Name.StartsWith(SearchName)
                            orderby data.Name
                            select data).FirstOrDefault();
            }
            return _address;
        }

        //Initially Submitted and updated in Stage Table Verification
        public static bool _CheckSubmittedCSR_CSRSetups_Table(string SubmittedCustomerAccount)
        {
            bool CSR;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                CSR = (from proxy in context.CsrSetups
                       where proxy.CustomerName == SubmittedCustomerAccount
                       select proxy).Any();

            }
            return CSR;
        }

        public static string Check_CustomerName_Duplicate(string _accountName)
        {
            List<string> CSR = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CSR = (from proxy in context.CsrSetups
                       select proxy.CustomerName).ToList();
            }
            if (_accountName.Length >= 50)
            {
                _accountName = _accountName.Substring(0, 1);
            }
            for (int i = 0; i < CSR.Count; i++)
            {
                //Verifying for the Duplicate Account name
                if (string.Equals(CSR[i], _accountName, StringComparison.OrdinalIgnoreCase))
                {
                    _accountName = _accountName + i;//Incrementing AccName
                    if (_accountName.Length >= 50)//Verifying if AccName length is greater than 50
                    {
                        _accountName = _accountName.Substring(0, 1);//taking first character of AccName
                    }
                    i = i - i - 1;//set index always  -1
                }
            }
            return _accountName;
        }
        public static string Check_AddressName_Duplicate(int accId, string addName)
        {
            List<string> add = null;

            Random random = new Random();
            int randonNumber = random.Next(1, 9999);
            string addressName = addName + (randonNumber.ToString());

            using (WWProxyEntities context = new WWProxyEntities())
            {
                add = (from proxy in context.Addresses
                       where proxy.Name.Contains(addressName) && proxy.CustomerAccountId == accId
                       select proxy.Name).ToList();
            }

            return addressName;
        }
        public static int Check_CSANumber_Duplicate(int _cSANumber)
        {
            List<int> _Csr = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                _Csr = (from proxy in context.CsrCustomerAccounts
                        where proxy.CsaCustomerNumber.HasValue
                        select proxy.CsaCustomerNumber.Value).ToList();
            }
            for (int i = 0; i < _Csr.Count; i++)
            {
                if (_Csr[i] == Convert.ToInt32(_cSANumber))//Verifying for the Duplicate CSA Number
                {
                    _cSANumber = _cSANumber + i;//Incrementing CSA Number
                    i = i - i - 1;//set index always  -1
                }
            }
            return _cSANumber;
        }

        internal static string GetCustomerSpecificBrandingsAccountId(int v, object customeraccountid)
        {
            throw new NotImplementedException();
        }

        internal static string GetCustomerSpecificBrandingsAccountId(object customeraccountid)
        {
            throw new NotImplementedException();
        }

        public static Address GetConsigneeAddressforAccount(int accountID)
        {
            Address addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.AddressTypeId == 4
                            select add).FirstOrDefault();
            }

            return addvalue;
        }



        public static Address Get_ConsigneeAddressInternalUsers(string accountName)
        {
            Address addvalue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int accountID = (from value in context.CustomerAccounts
                                 where value.CustomerSetUpId == id
                                 select value.CustomerAccountId).FirstOrDefault();


                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.AddressTypeId == 4
                            select add).FirstOrDefault();

            }
            return addvalue;
        }

        public static List<Item> GetItemsforAccount(int accountID)
        {
            List<Item> addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Items
                            where add.CustomerAccountId == accountID
                            select add).ToList();
            }

            return addvalue;
        }

        public static Item GetItemDetails(int accountID, string itemDescription)
        {
            Item value = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from add in context.Items
                         where add.CustomerAccountId == accountID && add.ItemDescription == itemDescription
                         select add).FirstOrDefault();
            }

            return value;
        }


        public static Item GetItem(string _accountName, string _item)
        {
            Item _itemDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == _accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int _accountId = (from value in context.CustomerAccounts
                                  where value.CustomerSetUpId == id
                                  select value.CustomerAccountId).FirstOrDefault();

                _itemDetails = (from data in context.Items
                                where data.CustomerAccountId == _accountId
                                  && data.ItemDescription == _item
                                select data).FirstOrDefault();
            }
            return _itemDetails;
        }


        public static string GetQuoteNumber()
        {
            string quoteNumber = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                quoteNumber = (from WWProxy in context.QuoteReferenceNumbers
                               select WWProxy.QuoteNumber).FirstOrDefault();
            }

            return quoteNumber;
        }

        public static bool UserEmailexistsinDB(string Email)
        {
            bool IsUserEmailexistsinDB = false;
            List<string> UserEmailList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                UserEmailList = (from tblRatingApiExceptionUser in context.RatingApiExceptionUsers
                                 select tblRatingApiExceptionUser.UserEmail).ToList();
                IsUserEmailexistsinDB = UserEmailList.Contains(Email);
            }
            return IsUserEmailexistsinDB;
        }

        public static CustomerAccount GetAccountDetails(int accNumb)
        {
            CustomerAccount Accvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                Accvalue = (from value in context.CustomerAccounts
                            where value.CustomerSetUpId == accNumb
                            select value).FirstOrDefault();
            }

            return Accvalue;
        }

        public static CustomerSetup GetSetupDetails(int setupId)
        {
            CustomerSetup value = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from set in context.CustomerSetups
                         where set.CustomerSetupId == setupId
                         select set).FirstOrDefault();
            }

            return value;
        }

        public static List<CustomerAccount> GetAllStationList()
        {
            List<CustomerAccount> addvalue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                //var asg = context.CustomerAccounts.Where(a => a.IsStation == false).ToList(); //to get accounts
                addvalue = context.CustomerAccounts.Where(a => a.IsStation).ToList();
            }

            return addvalue;
        }

        public static List<string> GetMappedStationList(List<string> StationId)
        {
            List<string> value = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                value = (from set in context.CustomerAccounts
                         where StationId.Contains(set.StationId) && set.IsStation == true
                         select set.StationName).ToList();
            }
            return value;
        }



        public List<CodeTableViewModel> GetCustomerAccountList(string stationName)
        {
            List<CodeTableViewModel> CustomerAccountList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomerAccountList = (from ca in context.CustomerAccounts
                                       where ca.StationName == stationName && ca.IsStation == false && ca.IsActive == true && ca.EnterpriseType == "Customer"
                                       select new CodeTableViewModel
                                       {
                                           Name = ca.CustomerSetup.CustomerName,
                                           Value = ca.CustomerAccountId.ToString()
                                       }).Distinct().ToList();
            }
            return CustomerAccountList;
        }

        public List<CodeTableViewModel> GetCustomerAccountListWithInactive(string stationName)
        {
            List<CodeTableViewModel> CustomerAccountList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomerAccountList = (from ca in context.CustomerAccounts
                                       where ca.StationName == stationName && ca.IsStation == false
                                       select new CodeTableViewModel
                                       {
                                           Name = ca.CustomerSetup.CustomerName,
                                           Value = ca.CustomerAccountId.ToString()
                                       }).Distinct().ToList();
            }
            return CustomerAccountList;
        }


        public static List<string> GetIntegrationCustomerAccountList(string stationName)
        {
            List<string> CustomerAccountList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomerAccountList = (from ca in context.IntegrationRequests
                                       where ca.StationName == stationName
                                       select ca.CompanyName).ToList();
            }
            return CustomerAccountList;
        }

        //public List<CodeTableViewModel> GetCustSubAccountList(string stationName)
        //{
        //    List<CodeTableViewModel> CustSubAccountList = null;
        //    using (WWProxyEntities context = new WWProxyEntities())
        //    {
        //        CustSubAccountList = (from ca in context.CustomerAccounts
        //                              join cs in context.CustomerAccountMappings on ca.CustomerAccountId equals cs.SubAccountId
        //                              where ca.StationName == stationName && ca.IsStation == false && ca.IsActive == true
        //                              select new CodeTableViewModel
        //                              {
        //                                  Name = ca.CustomerSetup.CustomerName,
        //                                  Value = ca.CustomerAccountId.ToString()
        //                              }).Distinct().ToList();
        //    }
        //    return CustSubAccountList;
        //}

        public List<CodeTableViewModel> GetCustSubAccountList(string stationName)
        {
            List<CodeTableViewModel> CustSubAccountList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustSubAccountList = (from pca in context.CustomerAccounts
                                      join cam in context.CustomerAccountMappings on pca.CustomerAccountId equals cam.PrimaryAccountId
                                      join sca in context.CustomerAccounts on cam.SubAccountId equals sca.CustomerAccountId
                                      where pca.StationName == stationName && pca.IsStation == false && pca.IsActive == true && pca.EnterpriseType == "Customer"
                                      select new CodeTableViewModel
                                      {
                                          Name = sca.CustomerSetup.CustomerName,
                                          Value = sca.CustomerAccountId.ToString()
                                      }).Distinct().ToList();
            }
            return CustSubAccountList;
        }

        public List<CodeTableViewModel> GetCustSubAccountListWithInactive(string stationName)
        {
            List<CodeTableViewModel> CustSubAccountList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustSubAccountList = (from pca in context.CustomerAccounts
                                      join cam in context.CustomerAccountMappings on pca.CustomerAccountId equals cam.PrimaryAccountId
                                      join sca in context.CustomerAccounts on cam.SubAccountId equals sca.CustomerAccountId
                                      where pca.StationName == stationName && pca.IsStation == false
                                      select new CodeTableViewModel
                                      {
                                          Name = sca.CustomerSetup.CustomerName,
                                          Value = sca.CustomerAccountId.ToString()
                                      }).Distinct().ToList();
            }
            return CustSubAccountList;
        }
        public List<CodeTableViewModel> GetCustomers(string stationName)
        {
            List<CodeTableViewModel> customersList = GetCustomerAccountList(stationName);
            List<CodeTableViewModel> subAccountList = GetCustSubAccountList(stationName);
            List<CodeTableViewModel> resultList = new List<CodeTableViewModel>();
            resultList = customersList.Except(subAccountList, new CodeTableModelComparer()).ToList();
            return resultList;
        }

        public List<CodeTableViewModel> GetCustomersIncludingInactive(string stationName)
        {
            List<CodeTableViewModel> customersList = GetCustomerAccountListWithInactive(stationName);
            List<CodeTableViewModel> subAccountList = GetCustSubAccountListWithInactive(stationName);
            List<CodeTableViewModel> resultList = new List<CodeTableViewModel>();
            resultList = customersList.Except(subAccountList, new CodeTableModelComparer()).ToList();
            return resultList;
        }

        public static List<string> GetAllDefaultaccountListBasedOnStation(string stationName)
        {
            List<string> customerAccounts = new List<string>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                customerAccounts = (from x in context.CustomerAccounts.Where(x =>
                                    x.StationName.Equals(stationName, StringComparison.CurrentCultureIgnoreCase)
                                   && !x.IsStation && x.IsActive && x.IsDefaultInsAll && x.CostPerHundred == 0 && x.MinimumInsCost == null)
                                    select (x.CustomerSetup.CustomerName)).ToList();
            }

            return customerAccounts;
        }

        public static List<string> GetAllNonDefaultaccountListBasedOnStation()
        {
            List<string> addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from x in context.CustomerAccounts.Where(x => x.IsDefaultInsAll == false && x.IsStation == false && x.IsActive)
                            select (x.CustomerSetup.CustomerName)).ToList();

            }

            return addvalue;
        }

        public static CustomerAccount IsDefaultInsAll(string accountName)
        {
            CustomerAccount _IsDefaultInsAll = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                _IsDefaultInsAll = (from value in context.CustomerAccounts
                                    where value.CustomerSetUpId == id
                                    select value).FirstOrDefault();

                //_IsDefaultInsAll = (from proxy in context.CustomerSetups
                //                    join value in context.CustomerAccounts
                //                    on proxy.CustomerSetupId equals value.CustomerSetUpId
                //                    where proxy.CustomerName.ToUpper() == accountName.ToUpper()
                //                    select value).FirstOrDefault();
            }
            return _IsDefaultInsAll;
        }

        public static List<int> GetAccountsMappedforStations(List<string> stationid)
        {

            List<int> records = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                records = (from val in context.CsrCustomerAccounts
                           where stationid.Contains(val.StationId)
                           select val.CustomerSetUpId).ToList();
            }
            return records;
        }

        public static List<CustomerAccount> GetAccountsMappedforStation(string stationname)
        {

            List<CustomerAccount> records = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                records = (from val in context.CustomerAccounts
                           where stationname.Contains(val.StationName) && val.IsStation == false
                           select val).ToList();
            }
            return records;
        }

        public static List<CustomerSpecificReference> GetCustomerRefernce(int accountnumber)
        {

            List<CustomerSpecificReference> records = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                records = (from val in context.CustomerSpecificReferences
                           where val.CustomerAccountId == accountnumber
                           select val).ToList();
            }
            return records;
        }

        public static CustomerSpecificReference GetCustomerRefernce1(int accountnumber)
        {
            CustomerSpecificReference addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from val in context.CustomerSpecificReferences
                            where val.CustomerAccountId == accountnumber && val.ReferenceTypeName == "Move Type"
                            select val).FirstOrDefault();
            }

            return addvalue;
        }

        public static CustomerSpecificReference GetCustomerRefernce2(int accountnumber)
        {
            CustomerSpecificReference addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from val in context.CustomerSpecificReferences
                            where val.CustomerAccountId == accountnumber && val.ReferenceTypeName == "Move Type"
                            select val).FirstOrDefault();
            }

            return addvalue;
        }




        public static string GetStationNameonStationID(string statID)
        {

            string record = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                record = (from val in context.CustomerAccounts
                          where val.StationId == statID && val.IsStation == true
                          select val.StationName).FirstOrDefault();
            }
            return record;
        }

        public static string GetStationID(string StationName)
        {

            string record = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                record = (from val in context.CustomerAccounts
                          where val.StationName == StationName && val.IsStation == true
                          select val.StationId).FirstOrDefault();
            }
            return record;
        }



        public static List<string> GetAllStationName()
        {
            List<string> stationname = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                stationname = (from val in context.CustomerAccounts
                               where val.IsStation == true
                               select val.StationName).ToList();
            }
            return stationname;
        }

        public static List<string> GetAllDagrtNumberForALLStations(List<string> StationId)
        {
            List<string> AllDagrtNumber = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                AllDagrtNumber = (from val in context.CustomerAccounts
                                  where StationId.Contains(val.StationId) && val.IsStation == true && val.DagrtNumber != null
                                  select val.DagrtNumber).Distinct().ToList();
            }
            return AllDagrtNumber;


        }

        public static List<string> GetAllDagrtNumberForALLStations(string StationId)
        {
            List<string> AllDagrtNumber = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                AllDagrtNumber = (from val in context.CustomerAccounts
                                  where StationId.Contains(val.StationId) && val.IsStation == true && val.DagrtNumber != null
                                  select val.DagrtNumber).Distinct().ToList();
            }
            return AllDagrtNumber;


        }

        public static List<string> GetAllMatchingDAGRTCustomerOpenInvoices(List<string> dagrtNum)
        {
            List<string> matchingOpenInvoices = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                matchingOpenInvoices = (from val in context.CustomerInvoices
                                        where dagrtNum.Contains(val.DAGRT) && val.InvoiceStatus == "O"
                                        select val.InvoiceNumber).ToList();
            }
            return matchingOpenInvoices;

        }

        public static List<string> GetAllMatchingDAGRTCustomerClosedInvoices(List<string> dagrtNumber)
        {
            List<string> matchingClosedInvoices = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                matchingClosedInvoices = (from val in context.CustomerInvoices
                                          where dagrtNumber.Contains(val.DAGRT) && val.InvoiceStatus == "C" && (DbFunctions.DiffYears(val.LastActivityDate, DateTime.UtcNow) <= 2)
                                          select val.InvoiceNumber).ToList();
            }
            return matchingClosedInvoices;

        }

        public static List<CustomerSetup> GetAllCustomersForAllStations(string StationName)
        {
            List<CustomerSetup> AllCustomers = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                AllCustomers = (from cs in context.CustomerSetups
                                join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                where ca.StationName == StationName
                                select cs).ToList();

            }
            return AllCustomers;
        }

        public static List<CustomerSetup> GetAllCustomersForAllTheStations(List<string> StationId)
        {
            List<CustomerSetup> AllCustomers = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                AllCustomers = (from cs in context.CustomerSetups
                                join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                where ca.IsStation == false && StationId.Contains(ca.StationId)
                                select cs).ToList();

            }
            return AllCustomers;
        }




        public static List<CustomerSetup> GetAllCustomersForTheStations(string StationId)
        {
            List<CustomerSetup> AllCustomers = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                AllCustomers = (from cs in context.CustomerSetups
                                join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                where ca.IsStation == false && ca.StationId == StationId
                                select cs).ToList();

            }
            return AllCustomers;
        }

        public static List<CustomerSetup> GetRecordsMappedforStationID(string stationId)
        {

            List<CustomerSetup> records = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                records = (from cs in context.CustomerSetups
                           join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                           where ca.StationId == stationId
                           select cs).ToList();
            }
            return records;
        }

        public static bool GetInactiveCustomer(string customerName)
        {
            bool InactiveVal;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                InactiveVal = (from cs in context.CustomerSetups
                               join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                               where cs.CustomerName.ToUpper() == customerName.ToUpper() && ca.IsActive == cs.IsActive
                               select ca.IsActive).FirstOrDefault();

            }
            return InactiveVal;
        }
        public static List<CsrSetup> GetCSRList_NonadminInternalUser(List<int> setupid, List<int> StatusIds)
        {
            List<CsrSetup> records = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                records = GetCSRListForStatusIds(StatusIds).Where(proxy => setupid.Contains(proxy.CustomerSetupId)).ToList();
            }
            return records;
        }
        public static List<CsrSetup> GetCSRListForStatusIds(List<int> listStatusIds)
        {
            List<CsrSetup> records = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                records = (from proxy in context.CsrSetups
                           join cc in context.CsrCustomerAccounts on proxy.CustomerSetupId equals cc.CustomerSetUpId
                           where listStatusIds.Contains(proxy.StatusId)
                           select proxy).ToList();
            }
            return records;
        }

        public static List<string> GetCSRStageCustomerName_based_on_StationId(List<string> id)
        {
            List<string> _CSRStageCustomerNameBasedOnStationId = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                _CSRStageCustomerNameBasedOnStationId = (from name in context.CsrCustomerAccounts
                                                         join B in context.CsrSetups
                                                         on name.CustomerSetUpId equals B.CustomerSetupId
                                                         where (id.Contains(name.StationId)) && (name.CsrSetup.StatusId == 1 || name.CsrSetup.StatusId == 2 || name.CsrSetup.StatusId == 3 || name.CsrSetup.StatusId == 5 || name.CsrSetup.StatusId == 11 || name.CsrSetup.StatusId == 13)
                                                         select B.CustomerName).ToList();

            }
            return _CSRStageCustomerNameBasedOnStationId;
        }

        public static List<string> GetCSRStageCustomerName()
        {
            List<string> _StageCustomer = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                _StageCustomer = (from name in context.CsrCustomerAccounts
                                  join B in context.CsrSetups
                                  on name.CustomerSetUpId equals B.CustomerSetupId
                                  where (B.StatusId == 1 || B.StatusId == 2 || B.StatusId == 3 || B.StatusId == 5 || B.StatusId == 11 || B.StatusId == 13)
                                  select B.CustomerName).OrderBy(a => a).Take(100).ToList();

            }
            return _StageCustomer;
        }

        public static InsuredRateCarrier GetnewCostperPound(string carriername)
        {
            InsuredRateCarrier newvalue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                newvalue = (from row in context.InsuredRateCarriers
                            join B in context.CarrierDetails
                            on row.CarrierCode equals B.SCAC
                            where B.Carrier == carriername
                            select row).FirstOrDefault();

            }
            return newvalue;

        }



        public static bool GetCustomerLogoAlignment(int customeraccountid)
        {
            bool _CustomerLogoAligned = false;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                var branding = context.CustomerSpecificBrandings.Where(a => a.CustomerAccountId == customeraccountid).FirstOrDefault();
                _CustomerLogoAligned = branding.IsLogoCentreAligned;
            }
            return _CustomerLogoAligned;
        }
        public static int GetAccountIdforAccountName(string accountName)

        {
            int value = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from set in context.CustomerSetups
                         where set.CustomerName == accountName
                         select set.CustomerSetupId).FirstOrDefault();
            }
            return value;

        }

        public static Item GetDefaultItem(int accountID)
        {
            Item data = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                data = (from set in context.Items
                        where set.CustomerAccountId == accountID && set.IsDefaultItem == true
                        select set).FirstOrDefault();
            }

            return data;

        }

        public static Item GetDefaultItem(List<int> customerAcctId)
        {
            Item data = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                data = (from set in context.Items
                        where customerAcctId.Contains(set.CustomerAccountId) && set.IsDefaultItem == true
                        select set).FirstOrDefault();
            }

            return data;

        }

        public static Address Get_DefaultShipperAddressExternalUsers(int accountID)
        {
            Address addvalue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.AddressTypeId == 3
                            select add).FirstOrDefault();

            }
            return addvalue;
        }

        public static Address Get_DefaultConsigneeExternalUsers(int accountID)
        {
            Address addvalue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                addvalue = (from add in context.Addresses
                            where add.CustomerAccountId == accountID && add.AddressTypeId == 4
                            select add).FirstOrDefault();
            }
            return addvalue;
        }


        public static CustomerSetup GetStationDetailsById(string StationID)
        {
            CustomerSetup value = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from cs in context.CustomerSetups
                         join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                         where ca.StationId == StationID && ca.IsStation == true
                         select cs).FirstOrDefault();
            }

            return value;
        }

        public static string GetCustomerName(int customerId)
        {
            string CustomerName;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                CustomerName = (from custAcct in context.CustomerSetups
                                where custAcct.CustomerSetupId == customerId
                                select custAcct.CustomerName).ToList().FirstOrDefault();
            }

            return CustomerName;
        }

        public static string GetStationName(string customerName)
        {
            string stationName = string.Empty;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                stationName = (from customer in context.CustomerAccounts
                               where customer.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                               select customer.StationName).FirstOrDefault();
            }

            return stationName;
        }


        public static int GetCustomerId(string subaccName)
        {
            int customeraccId = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                customeraccId = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == subaccName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();
            }
            return customeraccId;
        }

        public static int GetPrimaryAccId(int customeraccId)
        {
            int primaryaccId = customeraccId;
            int currentId = customeraccId;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                while (currentId != 0)
                {
                    currentId = (from val in context.CustomerAccountMappings
                                 join v in context.CustomerAccounts on val.PrimaryAccountId equals v.CustomerAccountId
                                 where val.SubAccountId == currentId
                                 select val.PrimaryAccountId).FirstOrDefault();

                    if (currentId != 0)
                    {
                        primaryaccId = currentId;
                    }
                }



            }

            return primaryaccId;
        }

        public static string GetPrimaryAcc(int PrimaryAccountId)
        {
            string PrimaryAccName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                PrimaryAccName = (from val in context.CustomerAccounts
                                  join v in context.CustomerSetups on val.CustomerSetUpId equals v.CustomerSetupId
                                  where val.CustomerAccountId == PrimaryAccountId
                                  select v.CustomerName).FirstOrDefault();

            }

            return PrimaryAccName;
        }

        public static string GetPrimaryAccountName(string SubaccountName)
        {
            string PrimaryAccountName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int SubaccountID = (from cs in context.CustomerSetups
                                    join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                    where cs.CustomerName.ToUpper() == SubaccountName.ToUpper()
                                    select ca.CustomerAccountId).FirstOrDefault();

                int PrimaryAccountId = (from val in context.CustomerAccountMappings
                                        join v in context.CustomerAccounts on val.PrimaryAccountId equals v.CustomerAccountId
                                        where val.SubAccountId == SubaccountID
                                        select val.PrimaryAccountId).FirstOrDefault();

                PrimaryAccountName = (from val in context.CustomerAccounts
                                      join v in context.CustomerSetups on val.CustomerSetUpId equals v.CustomerSetupId
                                      where val.CustomerAccountId == PrimaryAccountId
                                      select v.CustomerName).FirstOrDefault();

            }
            return PrimaryAccountName;
        }

        public static string _checkDuplicate_CustomReportName(string CustomReport)
        {
            List<string> _CustReport = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                _CustReport = (from CR in context.CustomReports
                               select CR.CustomReportName).ToList();
            }

            for (int i = 0; i < _CustReport.Count; i++)
            {

                if (_CustReport[i] == CustomReport)
                {
                    CustomReport = CustomReport + i;

                    i = -1;
                }
            }
            return CustomReport;
        }

        public static CustomerAccount GetAccountDetails_By_CustomerName(string Customer_AccountName)
        {
            CustomerAccount _accountDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == Customer_AccountName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                _accountDetails = (from value in context.CustomerAccounts
                                   where value.CustomerSetUpId == id
                                   select value).FirstOrDefault();
            }
            return _accountDetails;
        }


        public static List<string> _customReport_Mapped_to_UserEmail(string _userEmail)
        {
            List<string> _CustomReport = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                _CustomReport = (from CR in context.CustomReports
                                 join UCRM in context.UserCustomReportsMappings on CR.CustomReportId equals UCRM.CustomReportId
                                 where UCRM.UserEmail == _userEmail
                                 select CR.CustomReportName).ToList();
            }
            return _CustomReport;
        }

        public static CustomReport _CustomReport_Data(string CustomReport)
        {
            CustomReport _CustomReport = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                _CustomReport = (from CR in context.CustomReports
                                 where CR.CustomReportName == CustomReport
                                 select CR).FirstOrDefault();
            }
            return _CustomReport;
        }




        public static List<string> Get_serviceType_for_CustomReport(string ReportName)
        {
            List<string> f = null;
            List<int> id = null;


            using (WWProxyEntities context = new WWProxyEntities())
            {
                //id = (from CR in context.CustomReports
                //               where CR.CustomReportName == ReportName
                //               select CR.CustomReportId).ToList();

                id = (from CRSM in context.CustomReportServicesMappings
                      join j in context.CustomReports
                      on CRSM.CustomReportId equals j.CustomReportId
                      where j.CustomReportName == ReportName
                      select CRSM.ServiceId).ToList();

                f = (from SS in context.ShipmentServices
                     where id.Contains(SS.ServiceId)
                     select SS.ShipmentService1).ToList();


            }

            return f;
        }


        public static List<string> GetCustomers_TMS(List<string> stationIds)
        {

            List<string> tms;


            using (WWProxyEntities context = new WWProxyEntities())
            {

                tms = (from customer in context.CustomerAccounts
                       where stationIds.Contains(customer.StationId) && customer.IsStation == false
                       select customer.TmsSystem).ToList();

            }

            return tms;
        }
        public static List<string> GetCustomReportName(string Customreport)
        {
            List<string> report;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                report = (from customreport in context.CustomReports
                          where customreport.CustomReportName == Customreport
                          select customreport.CustomReportName).ToList();
            }

            return report;
        }

        public static int? GetExistingCustomReport_DaysPastDueDays(string ExistingReportName)
        {
            int? DaysPastDueDays = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                DaysPastDueDays = (from value in context.InvoiceCustomReports
                                   where value.CustomReportName == ExistingReportName
                                   select (value.DaysPastDue)).FirstOrDefault();
            }

            return DaysPastDueDays;
        }

        public static bool GetReport_Not_created_by_LoggedInUser(string Reportname, string UserEmail)
        {
            bool value;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from CR in context.CustomReports
                         where CR.CustomReportName == Reportname && CR.CreatedBy == UserEmail
                         select CR).Any();
            }
            return value;
        }

        public static List<string> GetGuranteedCarrierName()
        {
            List<string> carriers;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                carriers = (from carrier in context.GuaranteedCarriers
                            where carrier.IsActive == true
                            select carrier.CarrierName).ToList();
            }

            return carriers;

        }


        public static InsuredRateCarrier insuredCarrier(string CarrierName)
        {
            InsuredRateCarrier carriers;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                carriers = (from carrier in context.InsuredRateCarriers
                            where carrier.CarrierName == CarrierName
                            select carrier).FirstOrDefault();
            }

            return carriers;

        }


        public static string fileinsertcheck(string filename)
        {
            string value = null;
            using (DocRepositoryEntities doc = new DocRepositoryEntities())
            {
                value = (from file in doc.FileInfoes
                         where file.FileName == filename
                         select file.FileName).FirstOrDefault();


            }
            return value;


        }


        public static void removefile(string filename)
        {

            using (DocRepositoryEntities doc = new DocRepositoryEntities())
            {

                int fileid = (from file in doc.FileInfoes where file.FileName == filename select file.FileInfoId).FirstOrDefault();
                var rowChild = (from appfile in doc.AppMetaDataFileMappings where appfile.FileInfoId == fileid select appfile).ToList();
                var rowParent = (from fileInfo in doc.FileInfoes where fileInfo.FileInfoId == fileid select fileInfo).ToList();
                doc.AppMetaDataFileMappings.RemoveRange(rowChild);
                doc.FileInfoes.RemoveRange(rowParent);
                doc.SaveChanges();

            }
        }


        public static GuaranteedCarrier guaranteedCarrier(string CarrierName)

        {
            GuaranteedCarrier carriers;


            using (WWProxyEntities context = new WWProxyEntities())
            {

                carriers = (from carrier in context.GuaranteedCarriers
                            where carrier.CarrierName == CarrierName && carrier.IsActive == true
                            select carrier).FirstOrDefault();

            }

            return carriers;

        }

        public static CustomerAccount GetStationDetailsByStationName(string stationName)
        {
            CustomerAccount value = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                value = (from cs in context.CustomerAccounts
                         where cs.StationName == stationName && cs.IsStation == true
                         select cs).FirstOrDefault();
            }

            return value;
        }

        public static int GetResubmittedClaimNumber()
        {
            int claimNum = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                claimNum = (from cn in context.InsuranceClaimHistories
                            where cn.Comments == "Claim was resubmitted"
                            orderby cn.CreatedDate descending
                            select cn.ClaimNumber).FirstOrDefault();
            }
            return claimNum;
        }


        public static int GetCustomerSetupId(string Account)
        {
            int setupid = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                setupid = (from value in context.CustomerSetups
                           where value.CustomerName == Account
                           select value.CustomerSetupId).FirstOrDefault();
            }

            return setupid;
        }

        public static int GetCustomerAccountId(int setupid)
        {
            int accountid = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                accountid = (from value in context.CustomerAccounts
                             where value.CustomerSetUpId == setupid
                             select value.CustomerAccountId).FirstOrDefault();
            }

            return accountid;
        }

        public static List<Address> GetAddress(int accountid, string OriginZip)
        {
            List<Address> list = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                list = context.Addresses.Where(a => a.CustomerAccountId == accountid && a.Zip == OriginZip).ToList();

            }

            return list;
        }

        public static CarrierWebsite GetCarrierDetails(string scac)
        {
            CarrierWebsite cvalue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                cvalue = (from value in context.CarrierWebsites
                          where value.Scac == scac
                          select value).FirstOrDefault();

            }
            return cvalue;

        }




        public static List<GainShareScacCode> GetGainsharePricingDataByPID(int PricingModelId)
        {
            List<GainShareScacCode> record = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                record = (from value in context.GainShareScacCodes
                          where value.GainsharePricingModelId == PricingModelId
                          select value).ToList();
            }
            return record;

        }

        public static List<string> GetDocTypeVal()
        {
            List<string> DocType = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                DocType = (from dt in context.DocumentTypes
                           select dt.DocumentType1).ToList();
            }

            return DocType;
        }

        public static GainsharePricingModel GetGainsharePricingDataByAID(int accountid)
        {
            GainsharePricingModel record = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                record = context.GainsharePricingModels.Where(a => a.CustomerAccountId == accountid).FirstOrDefault();

            }

            return record;

        }


        public static List<IndividualAccessorialModel> CarrierAcc(string Custome_rName, string SCACs)
        {
            List<IndividualAccessorialModel> accessorialModelByCarrier = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                accessorialModelByCarrier = (from c in context.AccessorialCarrierSetUps
                                             where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == Custome_rName.ToLower()
                                             && c.CustomerAccount.CustomerSetup.IsActive
                                             && c.CarrierSCAC.ToLower() == SCACs.ToLower()
                                             select new IndividualAccessorialModel
                                             {
                                                 CustomerName = Custome_rName,
                                                 //ScacCode = SCACs,
                                                 AccessorialCode = c.AccessorialCode,
                                                 AccessorialValue = c.AccessorialValue
                                             }).ToList();
            }

            return accessorialModelByCarrier;

        }


        public static List<IndividualAccessorialModel> CustAccessor(string Customer_Name)
        {
            List<IndividualAccessorialModel> accessorialModelByCustomer = null;



            using (WWProxyEntities context = new WWProxyEntities())
            {
                accessorialModelByCustomer = (from c in context.AccessorialCustomerSetUps
                                              where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == Customer_Name.ToLower()
                                              && c.CustomerAccount.CustomerSetup.IsActive
                                              select new IndividualAccessorialModel
                                              {
                                                  //CustomerName = Customer_Name,
                                                  AccessorialCode = c.AccessorialCode,
                                                  AccessorialValue = c.AccessorialValue
                                              }).ToList();
            }

            return accessorialModelByCustomer;
        }

        public static List<string> GetOpenDAGRTCustomerInvoices(string stationName)
        {
            List<string> DAGRTInvoice = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string DAGRTNum = (from val in context.CustomerAccounts
                                   where val.StationName == stationName && val.IsStation == true && val.DagrtNumber != null
                                   select val.DagrtNumber).FirstOrDefault();

                DAGRTInvoice = (from val in context.CustomerInvoices
                                where val.DAGRT == DAGRTNum && val.InvoiceStatus == "O"
                                select val.CustomerNumber).ToList();
            }
            return DAGRTInvoice;
        }



        public static List<string> GetClosedDAGRTCustomerInvoices(string stationName)
        {

            List<string> DAGRTInvoice = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string DAGRTNum = (from a in context.CustomerAccounts
                                   where a.StationName == stationName && a.IsStation == true && a.DagrtNumber != null
                                   select a.DagrtNumber).FirstOrDefault();

                DAGRTInvoice = (from a in context.CustomerInvoices
                                where a.DAGRT == DAGRTNum && a.InvoiceStatus == "C" && (DbFunctions.DiffYears(a.LastActivityDate, DateTime.UtcNow) <= 2)
                                select a.CustomerNumber).ToList();
            }
            return DAGRTInvoice;
        }


        public static List<CustomerInvoice> GetClosedCustomerInvoices(string stationName)
        {

            List<CustomerInvoice> DAGRTInvoice = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string DAGRTNum = (from a in context.CustomerAccounts
                                   where a.StationName == stationName && a.IsStation == true && a.DagrtNumber != null
                                   select a.DagrtNumber).FirstOrDefault();

                DAGRTInvoice = (from a in context.CustomerInvoices
                                where a.InvoiceStatus == "C" && a.DAGRT == DAGRTNum
                                select a
                                ).ToList();
            }
            return DAGRTInvoice;
        }

        public static List<string> GetMultipleCustomerInvoices(string stationName)
        {

            List<string> CustomerInvoices = new List<string>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string DAGRTNum = (from a in context.CustomerAccounts
                                   where a.StationName == stationName && a.DagrtNumber != null
                                   select a.DagrtNumber).FirstOrDefault();

                string[] values = DAGRTNum.Split(',');
                foreach (string DagrtNum in values)
                {
                    (from ci in context.CustomerInvoices
                     where ci.InvoiceStatus == "C" && ci.DAGRT == DagrtNum && DbFunctions.DiffYears(ci.LastActivityDate, DateTime.UtcNow) <= 2
                     select ci
                        ).ToList().ForEach(e =>
                        {
                            CustomerInvoices.Add(e.InvoiceNumber);
                        });
                }
            }
            return CustomerInvoices;
        }


        public static List<string> GetClosedDAGRTCustomerInvoicesDateRange(string stationName, DateTime StartDate, DateTime Enddate)
        {

            List<string> DAGRTInvoice = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string DAGRTNum = (from a in context.CustomerAccounts
                                   where a.StationName == stationName && a.IsStation == true && a.DagrtNumber != null
                                   select a.DagrtNumber).FirstOrDefault();

                DAGRTInvoice = (from a in context.CustomerInvoices
                                where a.EmployeeId == DAGRTNum && a.InvoiceStatus == "C" && a.LastActivityDate >= StartDate && a.LastActivityDate <= Enddate
                                select a.CustomerNumber).ToList();
            }
            return DAGRTInvoice;
        }

        public static InvoiceCustomReport GetCustomReportDetails(string StationName, int SetupId)
        {
            InvoiceCustomReport DBCustomReport = new InvoiceCustomReport();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                string StationIdVal = (from val in context.CustomerAccounts
                                       where val.StationName == StationName && val.IsStation == true
                                       select val.StationId).FirstOrDefault();

                DBCustomReport = (from a in context.InvoiceCustomReports
                                  join b in context.CustomReportStationMappings on a.InvoiceCustomReportId equals b.InvoiceCustomReportId
                                  join c in context.CustomReportCustomerMappings on a.InvoiceCustomReportId equals c.InvoiceCustomReportId
                                  where b.StationId == StationIdVal && c.CustomerSetupId == SetupId
                                  orderby a.CreatedDate descending
                                  select a).FirstOrDefault();
            }

            return DBCustomReport;

        }

        public static List<string> GetAllCustomReports(string email)
        {
            List<string> DBCustomReportNames = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                DBCustomReportNames = (from InvoiceCustomReport in context.InvoiceCustomReports
                                       where InvoiceCustomReport.UserEmail == email && InvoiceCustomReport.IsScheduled == false
                                       select InvoiceCustomReport.CustomReportName).ToList();

            }
            return DBCustomReportNames;
        }


        public static List<InsuranceClaimViewModel> GetInsuranceClaimVal(int ClaimNum)
        {
            List<InsuranceClaimViewModel> DBClaimVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                DBClaimVal = (from a in context.InsuranceClaims
                              join b in context.InsuranceClaimCarriers on a.ClaimNumber equals b.ClaimNumber
                              join c in context.InsuranceClaimShipperAddresses on a.ClaimNumber equals c.ClaimNumber
                              join d in context.InsuranceClaimConsigneeAddresses on a.ClaimNumber equals d.ClaimNumber
                              join e in context.InsuranceClaimPayableToes on a.ClaimNumber equals e.ClaimNumber
                              join f in context.InsuranceClaimItems on a.ClaimNumber equals f.ClaimNumber
                              join g in context.InsuranceClaimFreights on a.ClaimNumber equals g.ClaimNumber
                              join h in context.InsuranceCarrierOsdActions on a.ClaimNumber equals h.ClaimNumber
                              join i in context.InsuranceClaimCarriers on a.ClaimNumber equals i.ClaimNumber
                              join j in context.InsuranceDlswOsdActions on a.ClaimNumber equals j.ClaimNumber

                              where a.ClaimNumber == ClaimNum
                              select new InsuranceClaimViewModel
                              {
                                  DlswRefNumber = b.DlswRefNumber,
                                  ActualDeliveryDate = b.DeliveryDate.ToString(),
                                  CarrierName = b.CarrierName,
                                  CarrierProNumber = b.CarrierProNumber,
                                  ShipperName = c.Name,
                                  ShipperAddress = c.Address,
                                  ShipperAdd2 = c.Address2,
                                  ShipperZip = c.Zip,
                                  ShipperCountry = c.Country.CountryName,
                                  ShipperCity = c.CityName,
                                  ShipperState = c.StateName,
                                  DateAckToClaimant = j.DateAckToClaimant.ToString(),
                                  DateFiledWCarrier = j.DateFiledWithCarrier.ToString(),
                                  InsuranceClaimProgramId = a.InsuranceClaimProgramId.ToString(),
                                  InsuranceClaimCompanyId = a.InsuranceClaimCompanyId.ToString(),
                                  ConsigneName = d.Name,
                                  ConsigneAddress = d.Address,
                                  ConsigneAdd2 = d.Address2,
                                  ConsigneZip = d.Zip,
                                  ConsigneCountry = d.Country.CountryName,
                                  ConsigneCity = d.CityName,
                                  ConsigneState = d.StateName,
                                  ClaimCompanyName = e.CompanyName,
                                  ClaimAddress = e.Address,
                                  ClaimAdd2 = e.Address2,
                                  ClaimZip = e.Zip,
                                  ClaimCity = e.CityName,
                                  ClaimCountry = e.Country.CountryName,
                                  ClaimContactName = e.ContactName,
                                  ClaimContactPhone = e.ContactPhone,
                                  ClaimContactEmail = e.ContactEmail,
                                  ClaimWebsite = e.CompanyWebsite,
                                  IsArticlesIns = a.IsArticlesInsured,
                                  InsuredValAmount = a.InsuredValueAmount,
                                  ClaimTypeId = f.InsuranceClaimTypeId,
                                  AritcleTypeId = f.InsuranceClaimArticleTypeId,
                                  ItemNum = f.ItemNumber,
                                  UnitVal = f.UnitValue,
                                  Quantity = f.Quantity,
                                  Weight = f.Weight,
                                  Description = f.description,
                                  OriginalFreightCharge = g.OriginalFreightChargesValue,
                                  OriginalCarrierChargesToDLSWValue = g.OriginalCarrierChargesToDlswValue,
                                  OriginalDLSWChargesToCustomerValue = g.OriginalDlswChargesToCustomerValue,
                                  ReturnFreightCharge = g.ReturnFreightChargesValue,
                                  ReturnCarrierChargesToDLSWValue = g.ReturnCarrierChargesToDlswValue,
                                  ReturnDLSWChargesToCustomerValue = g.ReturnDlswChargesToCustomerValue,
                                  ReturnDLSRefNum = g.ReturnFreightChargesDlswRefNumber,
                                  ReplacementFreightCharge = g.ReplacementFreightChargesValue,
                                  ReplacementCarrierChargesToDLSWValue = g.ReplacementCarrierChargesToDlswValue,
                                  ReplacementDLSWChargesToCustomerValue = g.ReplacementDlswChargesToCustomerValue,
                                  ReplaceDLSWRefNum = g.ReplacementFreightDlswRefNumber,
                                  Comments = g.Comments,
                                  SubTotalClaimVal = g.SubTotalClaimValue,
                                  Remarks = a.Remarks,
                                  CreatedBy = a.CreatedBy,
                                  FirstName = a.FirstName,
                                  LastName = a.LastName,
                                  ShipmentMode = a.ShipmentMode,
                                  CarrierAck = h.CarrierAck.ToString(),
                                  CarrierAckDate = h.CarrierAckDate.ToString(),
                                  CarrierClaimNumber = h.CarrierClaimNumber,
                                  CarriePRODate = i.CarrierProDate.ToString(),
                                  ShipDate = i.DlswShipDate.ToString(),
                                  DeliveryDate = i.DeliveryDate.ToString(),
                              }).ToList();
            }
            return DBClaimVal;
        }

        public static string GetInsuranceClaimProgramName(int programid)
        {
            string programname = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                programname = (from a in context.InsuranceClaimPrograms
                               where a.InsuranceClaimProgramId == programid
                               select a.InsuranceClaimProgramName).FirstOrDefault();
            }
            return programname;
        }

        public static string GetInsuranceClaimCompanyName(int companyid)
        {
            string companyname = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                companyname = (from a in context.InsuranceClaimCompanies
                               where a.InsuranceClaimCompanyId == companyid
                               select a.InsuranceClaimCompanyName).FirstOrDefault();
            }
            return companyname;
        }



        public static int GetInsuranceStatus(int claimNumber)
        {
            int status = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                status = (from Status in context.InsuranceClaims
                          where Status.ClaimNumber == claimNumber
                          select Status.InsuranceClaimStatusId).FirstOrDefault();
            }
            return status;
        }

        public static int GetClaimNumber()
        {
            int ClaimNum = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                ClaimNum = (from cn in context.InsuranceClaims
                            orderby cn.CreateDateTime descending
                            select cn.ClaimNumber).FirstOrDefault();
            }

            return ClaimNum;
        }

        public static decimal GetSubTotalValFreight(int ClaimNum)
        {
            decimal subtotal = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                subtotal = (from a in context.InsuranceClaims
                            join b in context.InsuranceClaimFreights on a.ClaimNumber equals b.ClaimNumber
                            where a.ClaimNumber == ClaimNum
                            select b.SubTotalClaimValue).FirstOrDefault();

            }
            return subtotal;
        }

        public static int GetClaimNumberByUsername(string Username)
        {
            int ClaimNum = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                ClaimNum = (from cn in context.InsuranceClaims
                            where cn.CreatedBy == Username
                            orderby cn.CreateDateTime descending
                            select cn.ClaimNumber).FirstOrDefault();
            }

            return ClaimNum;

        }

        public static string GetInsuranceStatusCode(int ClaimNum)
        {
            string StatusCode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                StatusCode = (from st in context.InsuranceClaims
                              join statuscode in context.InsuranceClaimStatusCodes on st.InsuranceClaimStatusCodeId equals statuscode.InsuranceClaimStatusCodeId
                              where st.ClaimNumber == ClaimNum
                              select statuscode.StatusCode).FirstOrDefault();
            }
            return StatusCode;
        }


        public static Common_BumpSurgeStationSetUp_CT GetBumpSurgeCTOldDetailsStation(string OneCarrierUI, string StationName, DateTime UpdatedDate)
        {
            Common_BumpSurgeStationSetUp_CT CTValOld = new Common_BumpSurgeStationSetUp_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string stationId = (from cs in context.CustomerSetups
                                    join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                    where ca.StationName.ToUpper() == StationName.ToUpper()
                                    select ca.StationId).FirstOrDefault();

                CTValOld = (from b in context.Common_BumpSurgeStationSetUp_CT
                            join i in context.InsuredRateCarriers
                                on b.CarrierSCAC equals i.CarrierCode
                            where b.StationId == stationId
                            && i.CarrierName == OneCarrierUI && b.C___operation == 3
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();
            }
            return CTValOld;
        }

        public static Csr_GainShareScacCode_CT GetGainShareValues(string OneCarrierUI, string CustomerName)
        {
            Csr_GainShareScacCode_CT CTValOld = new Csr_GainShareScacCode_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                var GainsharepricingId = (from c in context.Csr_GainsharePricingModel_CT
                                          where c.CustomerAccountId == accountID
                                          select c.GainsharePricingModelId).FirstOrDefault();

                CTValOld = (from b in context.Csr_GainShareScacCode_CT
                            join i in context.InsuredRateCarriers
                             on b.ScacCode equals i.CarrierCode
                            where b.GainsharePricingModelId == GainsharepricingId
                            && i.CarrierName == OneCarrierUI && b.C___operation == 3
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();

            }
            return CTValOld;
        }

        public static Csr_GainShareScacCode_CT GetGainShareNewValues(string OneCarrierUI, string CustomerName)
        {
            Csr_GainShareScacCode_CT CTValNew = new Csr_GainShareScacCode_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                var GainsharepricingId = (from c in context.Csr_GainsharePricingModel_CT
                                          where c.CustomerAccountId == accountID
                                          select c.GainsharePricingModelId).FirstOrDefault();

                CTValNew = (from b in context.Csr_GainShareScacCode_CT
                            join i in context.InsuredRateCarriers
                             on b.ScacCode equals i.CarrierCode
                            where b.GainsharePricingModelId == GainsharepricingId
                            && i.CarrierName == OneCarrierUI && b.C___operation == 4
                            orderby b.ModifiedDate
                            select b).FirstOrDefault();

            }
            return CTValNew;
        }



        public static Common_BumpSurgeStationSetUp_CT GetBumpSurgeCTNewDetailsStation(string OneCarrierUI, string StationName, DateTime UpdatedDate)
        {
            Common_BumpSurgeStationSetUp_CT CTValNew = new Common_BumpSurgeStationSetUp_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string stationId = (from cs in context.CustomerSetups
                                    join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                    where ca.StationName.ToUpper() == StationName.ToUpper()
                                    select ca.StationId).FirstOrDefault();

                CTValNew = (from b in context.Common_BumpSurgeStationSetUp_CT
                            join i in context.InsuredRateCarriers
                                on b.CarrierSCAC equals i.CarrierCode
                            where b.StationId == stationId
                            && i.CarrierName == OneCarrierUI && b.C___operation == 4
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();
            }
            return CTValNew;
        }

        public static Common_BumpSurgeCustomerSetUp_CT GetBumpSurgeCTNewDetails(string OneCarrierUI, string CustomerName, DateTime UpdatedDate)
        {
            Common_BumpSurgeCustomerSetUp_CT CTValNew = new Common_BumpSurgeCustomerSetUp_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                CTValNew = (from b in context.Common_BumpSurgeCustomerSetUp_CT
                            join i in context.InsuredRateCarriers
                             on b.CarrierSCAC equals i.CarrierCode
                            where b.CustomerAccountId == accountID
                            && i.CarrierName == OneCarrierUI && b.C___operation == 4
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();
            }
            return CTValNew;
        }

        public static List<AccessorialCarrierSetUpViewModal> GetAccessorialOverlengthVal(string OneCarrierUI, string CustomerName)
        {
            List<AccessorialCarrierSetUpViewModal> OverlengthAccessVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                OverlengthAccessVal = (from b in context.AccessorialCarrierSetUps
                                       join i in context.InsuredRateCarriers
                                        on b.CarrierSCAC equals i.CarrierCode
                                       where b.CustomerAccountId == accountID
                                       && i.CarrierName == OneCarrierUI
                                       && b.AccessorialCode.Contains("OVL")
                                       orderby b.ModifiedDate descending
                                       select new AccessorialCarrierSetUpViewModal
                                       {
                                           AccessorialCode = b.AccessorialCode,
                                           AccessorialValue = b.AccessorialValue,
                                       }).ToList();
            }
            return OverlengthAccessVal;


        }

        public static List<AccessorialCustomerSetUpViewModal> GetAccessorialOverlengthCustomerVal(string CustomerName)
        {
            List<AccessorialCustomerSetUpViewModal> OverlengthAccessVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                OverlengthAccessVal = (from b in context.AccessorialCustomerSetUps
                                       where b.CustomerAccountId == accountID
                                       && b.AccessorialCode.Contains("OVL")
                                       orderby b.ModifiedDate descending
                                       select new AccessorialCustomerSetUpViewModal
                                       {
                                           AccessorialCode = b.AccessorialCode,
                                           AccessorialValue = b.AccessorialValue,
                                       }).ToList();
            }
            return OverlengthAccessVal;


        }

        public static Csr_AccessorialCarrierSetUp_CT GetAccessorialVal(string OneCarrierUI, string CustomerName)
        {
            Csr_AccessorialCarrierSetUp_CT CTValOld = new Csr_AccessorialCarrierSetUp_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                CTValOld = (from b in context.Csr_AccessorialCarrierSetUp_CT
                            join i in context.InsuredRateCarriers
                             on b.CarrierSCAC equals i.CarrierCode
                            where b.CustomerAccountId == accountID
                            && i.CarrierName == OneCarrierUI && b.C___operation == 3
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();
            }
            return CTValOld;

        }
        public static Csr_AccessorialCarrierSetUp_CT GetAccessorialNewVal(string OneCarrierUI, string CustomerName)
        {
            Csr_AccessorialCarrierSetUp_CT CTValNew = new Csr_AccessorialCarrierSetUp_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                CTValNew = (from b in context.Csr_AccessorialCarrierSetUp_CT
                            join i in context.InsuredRateCarriers
                             on b.CarrierSCAC equals i.CarrierCode
                            where b.CustomerAccountId == accountID
                            && i.CarrierName == OneCarrierUI && b.C___operation == 4
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();
            }
            return CTValNew;

        }


        public static Common_BumpSurgeCustomerSetUp_CT GetBumpSurgeCTOldDetails(string OneCarrierUI, string CustomerName)
        {
            Common_BumpSurgeCustomerSetUp_CT CTValOld = new Common_BumpSurgeCustomerSetUp_CT();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                CTValOld = (from b in context.Common_BumpSurgeCustomerSetUp_CT
                            join i in context.InsuredRateCarriers
                             on b.CarrierSCAC equals i.CarrierCode
                            where b.CustomerAccountId == accountID
                            && i.CarrierName == OneCarrierUI && b.C___operation == 3
                            orderby b.ModifiedDate descending
                            select b).FirstOrDefault();
            }
            return CTValOld;
        }



        public static BumpSurgeCustomerSetUp GetBumpSurgeDetails(string scac, string customerName)
        {

            BumpSurgeCustomerSetUp cvalue = new BumpSurgeCustomerSetUp();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int id = (from proxy in context.CustomerSetups
                          where proxy.CustomerName.ToUpper() == customerName.ToUpper()
                          select proxy.CustomerSetupId).FirstOrDefault();

                int accountID = (from value in context.CustomerAccounts
                                 where value.CustomerSetUpId == id
                                 select value.CustomerAccountId).FirstOrDefault();

                cvalue.Bump = (from c in context.BumpSurgeCustomerSetUps
                               where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                               && c.CustomerAccount.CustomerSetup.IsActive
                               && c.CarrierSCAC.ToLower() == scac.ToLower()
                               select c.Bump).FirstOrDefault();

                cvalue.Surge = (from c in context.BumpSurgeCustomerSetUps
                                where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                                && c.CustomerAccount.CustomerSetup.IsActive
                                && c.CarrierSCAC.ToLower() == scac.ToLower()
                                select c.Surge).FirstOrDefault();


            }
            return cvalue;

        }

        public static bool IsCustomerGainShareCustomer(string customerName)
        {
            bool isGainShareCustomer = false;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                isGainShareCustomer = (from c in context.PricingModels
                                       where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                                       && c.CustomerAccount.CustomerSetup.IsActive
                                       && c.PricingType.PricingModelName.ToLower() == "gainshare"
                                       select c).Any();
            }

            return isGainShareCustomer;
        }

        public static int GetGainsharePricingId(string customerName)
        {
            int gainshareId = '0';

            using (WWProxyEntities context = new WWProxyEntities())
            {
                gainshareId = (from v in context.GainsharePricingModels
                               where v.CustomerAccount.CustomerSetup.CustomerName == customerName
                               select v.GainsharePricingModelId).FirstOrDefault();

            }

            return gainshareId;
        }
        public static List<GainShareScacCode> GetGainshareScacByPricingId(int pricingModelId)
        {
            List<GainShareScacCode> gainshareScacList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                gainshareScacList = (from row in context.GainShareScacCodes
                                     join B in context.InsuredRateCarriers
                                     on row.ScacCode equals B.CarrierCode
                                     where row.GainsharePricingModelId == pricingModelId
                                     select row).Distinct().ToList();

            }

            return gainshareScacList;
        }


        public static List<InsuredRateCarrier> GetCarriers(int pricingModelId)
        {
            List<InsuredRateCarrier> carrierNameForScacCode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                carrierNameForScacCode = (from row in context.GainShareScacCodes
                                          join B in context.InsuredRateCarriers
                                          on row.ScacCode equals B.CarrierCode
                                          where row.GainsharePricingModelId == pricingModelId
                                          select B).ToList();

            }

            return carrierNameForScacCode;
        }

        public static GainShareScacCode GetGainshareScacByCarrierName(int pricingModelId, string carrierName)
        {
            GainShareScacCode gainsharePricingValuesForCarrier = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                gainsharePricingValuesForCarrier = (from row in context.GainShareScacCodes
                                                    join B in context.InsuredRateCarriers
                                                    on row.ScacCode equals B.CarrierCode
                                                    where row.GainsharePricingModelId == pricingModelId && B.CarrierName == carrierName
                                                    select row).FirstOrDefault();

            }

            return gainsharePricingValuesForCarrier;
        }

        public static BumpSurgeStationSetUp GetSurgeBumpStationDB(string OneCarrierUI, string StationName)
        {
            BumpSurgeStationSetUp cvalue = new BumpSurgeStationSetUp();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                string stationId = (from cs in context.CustomerSetups
                                    join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                    where ca.StationName.ToUpper() == StationName.ToUpper()
                                    select ca.StationId).FirstOrDefault();

                cvalue.Bump = (from b in context.BumpSurgeStationSetUps
                               join i in context.InsuredRateCarriers
                                on b.CarrierSCAC equals i.CarrierCode
                               where b.StationId == stationId
                               && i.CarrierName == OneCarrierUI
                               select b.Bump).FirstOrDefault();

                cvalue.Surge = (from b in context.BumpSurgeStationSetUps
                                join i in context.InsuredRateCarriers
                                 on b.CarrierSCAC equals i.CarrierCode
                                where b.StationId == stationId
                                && i.CarrierName == OneCarrierUI
                                select b.Surge).FirstOrDefault();
            }
            return cvalue;
        }

        public static AccessorialCarrierSetUp GetGainshareTypeVal(string CarrierName, string CustomerName)
        {
            AccessorialCarrierSetUp gainshareVal = new AccessorialCarrierSetUp();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                string carrierSCAC = (from cs in context.InsuredRateCarriers
                                      where cs.CarrierName == CarrierName
                                      select cs.CarrierCode).FirstOrDefault();

                gainshareVal = (from gs in context.AccessorialCarrierSetUps
                                join ac in context.AccessorialSetUps on gs.AccessorialCode equals ac.AccessorialCode
                                where gs.CustomerAccountId == accountID && gs.CarrierSCAC == carrierSCAC
                                orderby gs.CreatedDate descending
                                select gs).FirstOrDefault();
            }

            return gainshareVal;

        }

        public static AccessorialCarrierSetUp GetGainshareTypeValForAccessorial(string CarrierName, string CustomerName, string accessorialName)
        {
            AccessorialCarrierSetUp gainshareVal = new AccessorialCarrierSetUp();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                string carrierSCAC = (from cs in context.InsuredRateCarriers
                                      where cs.CarrierName == CarrierName
                                      select cs.CarrierCode).FirstOrDefault();

                gainshareVal = (from gs in context.AccessorialCarrierSetUps
                                join ac in context.AccessorialSetUps on gs.AccessorialCode equals ac.AccessorialCode
                                where gs.CustomerAccountId == accountID && gs.CarrierSCAC == carrierSCAC && ac.AccessorialName == accessorialName
                                orderby gs.CreatedDate descending
                                select gs).FirstOrDefault();
            }

            return gainshareVal;
        }

        public static void DeleteGainshareTypeValForAccessorial(string CarrierName, string CustomerName, string accessorialName)
        {
            AccessorialCarrierSetUp gainshareVal = new AccessorialCarrierSetUp();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                string carrierSCAC = (from cs in context.InsuredRateCarriers
                                      where cs.CarrierName == CarrierName
                                      select cs.CarrierCode).FirstOrDefault();

                gainshareVal = (from gs in context.AccessorialCarrierSetUps
                                join ac in context.AccessorialSetUps on gs.AccessorialCode equals ac.AccessorialCode
                                where gs.CustomerAccountId == accountID && gs.CarrierSCAC == carrierSCAC && ac.AccessorialName == accessorialName
                                orderby gs.CreatedDate descending
                                select gs).FirstOrDefault();

                try
                {
                    context.AccessorialCarrierSetUps.Remove(gainshareVal);
                    context.SaveChanges();
                }
                catch (Exception)
                {
                }
            }
        }

        public static BumpSurgeCustomerSetUp GetBumpSurgeFromDB(string OneCarrierUI, string CustomerName)
        {
            BumpSurgeCustomerSetUp cvalue = new BumpSurgeCustomerSetUp();
            using (WWProxyEntities context = new WWProxyEntities())
            {

                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == CustomerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();

                cvalue.Bump = (from b in context.BumpSurgeCustomerSetUps
                               join i in context.InsuredRateCarriers
                                on b.CarrierSCAC equals i.CarrierCode
                               where b.CustomerAccountId == accountID
                               && i.CarrierName == OneCarrierUI
                               select b.Bump).FirstOrDefault();

                cvalue.Surge = (from b in context.BumpSurgeCustomerSetUps
                                join i in context.InsuredRateCarriers
                                on b.CarrierSCAC equals i.CarrierCode
                                where b.CustomerAccountId == accountID
                                && i.CarrierName == OneCarrierUI
                                select b.Surge).FirstOrDefault();

            }
            return cvalue;
        }




        public static List<AccessorialCustomerSetUp> GetAccessorials(int customerAccountId)
        {
            List<AccessorialCustomerSetUp> accessorialValues = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                accessorialValues = (from row in context.AccessorialCustomerSetUps
                                     where row.CustomerAccountId == customerAccountId
                                     select row).ToList();


            }

            return accessorialValues;
        }

        public static List<AccessorialCarrierSetUp> GetCarrierAccessorials(int customerAccountId)
        {
            List<AccessorialCarrierSetUp> accessorialValues = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                accessorialValues = (from row in context.AccessorialCarrierSetUps
                                     where row.CustomerAccountId == customerAccountId
                                     select row).ToList();
            }
            return accessorialValues;
        }


        public static GainsharePricingModel GetPricingModelByAccountId(int accountNumber)
        {
            GainsharePricingModel gainsharePricingValuesForCustomer = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                gainsharePricingValuesForCustomer = (from row in context.GainsharePricingModels
                                                     where row.CustomerAccountId == accountNumber
                                                     select row).FirstOrDefault();

            }

            return gainsharePricingValuesForCustomer;
        }

        public static List<InsuredRateCarrier> GetAllCarriers()
        {
            List<InsuredRateCarrier> carrierNameForScacCode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                carrierNameForScacCode = (from b in context.InsuredRateCarriers
                                          select b).Distinct().ToList();

            }

            return carrierNameForScacCode;
        }

        public static GainsharePricingModel GetGainshareScacByCustomerlevel(int pricingModelId)
        {
            GainsharePricingModel gainsharePricingModel = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                gainsharePricingModel = (from row in context.GainsharePricingModels
                                         where row.GainsharePricingModelId == pricingModelId
                                         select row).FirstOrDefault();

            }

            return gainsharePricingModel;
        }

        //public static List<IndividualAccessorialModel> CarrierAcc(string Custome_rName, string SCACs)
        //{
        //    List<IndividualAccessorialModel> accessorialModelByCarrier = null;

        //    using (WWProxyEntities context = new WWProxyEntities())
        //    {
        //        accessorialModelByCarrier = (from c in context.AccessorialCarrierSetUps
        //                                     where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == Custome_rName.ToLower()
        //                                     && c.CustomerAccount.CustomerSetup.IsActive
        //                                     && c.CarrierSCAC.ToLower() == SCACs.ToLower()
        //                                     select new IndividualAccessorialModel
        //                                     {
        //                                         CustomerName = Custome_rName,
        //                                         //ScacCode = SCACs,
        //                                         AccessorialCode = c.AccessorialCode,
        //                                         AccessorialValue = c.AccessorialValue
        //                                     }).ToList();
        //    }

        //    return accessorialModelByCarrier;

        ////}


        //public static List<IndividualAccessorialModel> CustAccessor(string Customer_Name)
        //{
        //    List<IndividualAccessorialModel> accessorialModelByCustomer = null;



        //    using (WWProxyEntities context = new WWProxyEntities())
        //    {
        //        accessorialModelByCustomer = (from c in context.AccessorialCustomerSetUps
        //                                      where c.CustomerAccount.CustomerSetup.CustomerName.ToLower() == Customer_Name.ToLower()
        //                                      && c.CustomerAccount.CustomerSetup.IsActive
        //                                      select new IndividualAccessorialModel
        //                                      {
        //                                          //CustomerName = Customer_Name,
        //                                          AccessorialCode = c.AccessorialCode,
        //                                          AccessorialValue = c.AccessorialValue
        //                                      }).ToList();
        //    }

        //    return accessorialModelByCustomer;
        //}

        public static string AccessorialName_to_Code(string Name)
        {
            string AccCode = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                (from c in context.AccessorialSetUps
                 where c.AccessorialName.ToLower() == Name.ToLower()
                 select c.AccessorialCode).FirstOrDefault();
            }

            return AccCode;
        }

        public static CodeTable AccessorialNameToCode(string Name)
        {
            CodeTable GetAccessorialCode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                GetAccessorialCode = (from value in context.CodeTables
                                      where value.Name == Name
                                      select value)?.FirstOrDefault();
            }
            return GetAccessorialCode;
        }

        public static AccessorialSetUp AccessorialName_to_Acc_Code(string Name)
        {
            AccessorialSetUp accCode = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                //context.AccessorialMGDescriptions
                accCode = (from value in context.AccessorialSetUps
                           where value.AccessorialName.ToLower() == Name.ToLower()
                           select value).FirstOrDefault();
            }

            return accCode;
        }

        public static AccessorialSetUp AccessorialNameToCodeUsingMgDescription(string mgDescription)
        {

            AccessorialSetUp gettheAccCode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                gettheAccCode = (from value in context.AccessorialSetUps
                                 join d in context.AccessorialMGDescriptions on value.AccessorialSetupId equals d.AccessorialSetupId
                                 where d.MGDescription.Contains(mgDescription)
                                 select value)?.FirstOrDefault();
            }
            return gettheAccCode;
        }

        public static GainShareScacCode GetCarrierSpecificScacCode(int GainSharePricingmodel_Id, string Scac_API)
        {
            GainShareScacCode GetCarrierSpecificScaccode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                GetCarrierSpecificScaccode = (from var in context.GainShareScacCodes
                                              where var.GainsharePricingModelId == GainSharePricingmodel_Id && var.ScacCode == Scac_API
                                              select var)?.FirstOrDefault();
            }
            return GetCarrierSpecificScaccode;


        }

        public static InsuredRateCarrier GetCarrierScacCodeGivenCarrierName(string carrierName)
        {
            InsuredRateCarrier insuredRateCarrier = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                insuredRateCarrier = (from carrier in context.InsuredRateCarriers
                                      where carrier.CarrierName.ToLower() == carrierName.ToLower().Trim()
                                      select carrier)?.FirstOrDefault();
            }

            return insuredRateCarrier;
        }

        public static bool CheckNewCrmRatingLogic(string customerName)
        {
            bool CrmRatingLogic;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                CrmRatingLogic = (from value in context.GainsharePricingModels
                                  where value.CustomerAccount.CustomerSetup.CustomerName.ToUpper() == customerName.ToUpper()
                                  && value.IsCrmRatingLogic == true
                                  select value).Any();

            }

            return CrmRatingLogic;
        }

        public static void ChangeCRMRatingLogicToFalse(string customerName)
        {
            GainsharePricingModel pricingModel;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                pricingModel = (from value in context.GainsharePricingModels
                                where value.CustomerAccount.CustomerSetup.CustomerName.ToUpper() == customerName.ToUpper()
                                select value).FirstOrDefault();

                pricingModel.IsCrmRatingLogic = false;

                context.SaveChanges();
            }
        }

        public static void ChangeCRMRatingLogicToTrue(string customerName)
        {
            GainsharePricingModel pricingModel;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                pricingModel = (from value in context.GainsharePricingModels
                                where value.CustomerAccount.CustomerSetup.CustomerName.ToUpper() == customerName.ToUpper()
                                select value).FirstOrDefault();

                pricingModel.IsCrmRatingLogic = true;

                context.SaveChanges();
            }
        }

        public static string GetExcludedCarriersforCustomer(int pricingModelId)
        {
            string excludedCarriersforCustomer = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                excludedCarriersforCustomer = (from row in context.GainsharePricingModels
                                               where row.GainsharePricingModelId == pricingModelId
                                               select row.ExcludedCarriers).FirstOrDefault();

            }

            return excludedCarriersforCustomer;
        }

        public static string Carriernameforscac(string CarrierCodes)
        {
            string carriername = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                carriername = (from carrier in context.InsuredRateCarriers
                               where carrier.CarrierCode == CarrierCodes
                               select carrier.CarrierName).FirstOrDefault();
            }

            return carriername;
        }

        public static CustomerAccount GetIsActiveIdStatus(int CustomerId)
        {
            CustomerAccount GetIsActiveId = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                GetIsActiveId = (from row in context.CustomerAccounts
                                 where row.CustomerSetUpId == CustomerId
                                 select row).FirstOrDefault();

            }
            return GetIsActiveId;
        }

        public static InusranceFtlMode GetFTLFieldsValClaimDetails(string ClaimNumber)
        {
            InusranceFtlMode GetFTLValues = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                GetFTLValues = (from val in context.InusranceFtlModes
                                where val.ClaimNumber.ToString() == ClaimNumber
                                select val).FirstOrDefault();
            }
            return GetFTLValues;
        }

        public static bool AccountStatus(string Customer_AccountName)
        {
            bool _accountDetails;

            using (WWProxyEntities context = new WWProxyEntities())
            {

                _accountDetails = (from value in context.CustomerAccounts
                                   join data in context.CustomerSetups
                                   on value.CustomerSetUpId equals data.CustomerSetupId
                                   where value.IsActive == true
                                   && data.IsActive == true
                                   select value).Any();
            }
            return _accountDetails;
        }

        public static List<IntegrationRequestComment> GetPublicCommentsForIntegrationRequest(string StationName, String companyName)
        {
            List<IntegrationRequestComment> comments = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                comments = (from A in context.IntegrationRequestComments
                            join B in context.IntegrationRequests
                           on A.IntegrationRequestId equals B.IntegrationRequestId
                            where B.StationName == StationName && B.CompanyName == companyName && A.IsPrivate == false
                            select A).ToList();
            }

            return comments;
        }
        public static IntegrationRequestComment GetPrivateCommentsValue(string Stationname, string Comment)
        {
            IntegrationRequestComment comments = new IntegrationRequestComment();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                comments = (from a in context.IntegrationRequestComments
                            join b in context.IntegrationRequests
                            on a.IntegrationRequestId equals b.IntegrationRequestId
                            where a.IsPrivate == true && a.Comment == Comment
                            select a).FirstOrDefault();
            }
            return comments;
        }
        public static List<IntegrationRequestComment> GetAllCommentsForIntegrationRequest(string StationName, String companyName)
        {
            List<IntegrationRequestComment> comments = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                comments = (from B in context.IntegrationRequestComments
                            join A in context.IntegrationRequests
                           on B.IntegrationRequestId equals A.IntegrationRequestId
                            where A.StationName == StationName && A.CompanyName == companyName
                            select B).ToList();
            }

            return comments;
        }

        public static DateTime GetIntegrationRequestStartDate()
        {
            DateTime startDate = DateTime.Now;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                startDate = (from date in context.IntegrationRequests
                             where date.IntegrationRequestId == 1
                             select date.StartDate).SingleOrDefault();
            }
            return startDate;
        }
        public static bool IsInsuredCarrierExcluded(string carriername)
        {
            bool isExcluded;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                isExcluded = (from proxy in context.InsuredRateCarriers
                              where proxy.CarrierName == carriername && proxy.IsExcluded == true
                              select proxy.IsExcluded).Any();

            }

            return isExcluded;
        }

        public static List<string> CustomerNameOfSubAccountUnderPrimaryAccount(string CustomerNameFromDD)
        {
            List<string> CustomerNameList = new List<string>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int PrimaryAccountId = (from cus in context.CustomerSetups
                                        where cus.CustomerName == CustomerNameFromDD
                                        select cus.CustomerSetupId).First();

                List<int> SubAccounts = (from cus in context.CustomerAccountMappings
                                         where cus.PrimaryAccountId == PrimaryAccountId
                                         select cus.SubAccountId).ToList();

                foreach (int SubAccount in SubAccounts)
                {
                    int CustomerSetupId = (from cus in context.CustomerAccounts
                                           where cus.CustomerAccountId == SubAccount
                                           select cus.CustomerAccountId).First();

                    string CustomerName = (from cus in context.CustomerSetups
                                           where cus.CustomerSetupId == CustomerSetupId
                                           select cus.CustomerName).First();

                    CustomerNameList.Add(CustomerName);

                }

            }

            return CustomerNameList;
        }

        public static List<string> GetCustomerNameByStationName(string stationName)
        {
            List<string> subAccountNameList = new List<string>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                List<int> accountList = (from cus in context.CustomerAccounts
                                         where cus.StationName == stationName && cus.IsActive == true && cus.IsStation == false
                                         select cus.CustomerAccountId).ToList();

                //foreach(int a in accountList) {
                //    string customerName = (from cus in context.CustomerSetups
                //                           where cus.CustomerSetupId == a
                //                           select cus.CustomerName).First();

                //    list.Add(customerName);
                //}
                //List<int> accountList = (from a in context.CustomerAccounts
                //                         where !context.CustomerAccountMappings.Any(m => a.CustomerAccountId.Equals(m.SubAccountId)) && a.IsStation == false && a.StationName == "01-Pittsburgh PA"
                //                         select a).ToList();
                subAccountNameList = (from account in context.CustomerAccounts
                                      where accountList.Contains(account.CustomerAccountId)
                                      select account.CustomerSetup.CustomerName).ToList();


            }

            return subAccountNameList;
        }

        public static List<string> GetCustomerActiveAndInactiveByStationName(string stationName)
        {
            List<string> subAccountNameList = new List<string>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                List<int> accountList = (from cus in context.CustomerAccounts
                                         where cus.StationName == stationName && cus.IsStation == false
                                         select cus.CustomerAccountId).ToList();

                subAccountNameList = (from account in context.CustomerAccounts
                                      where accountList.Contains(account.CustomerAccountId)
                                      select account.CustomerSetup.CustomerName).ToList();


            }

            return subAccountNameList;
        }

        public static List<CustomerSetup> GetAllDefaultActiveCustomers(string StationName)
        {
            List<CustomerSetup> AllCustomers = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                AllCustomers = (from cs in context.CustomerSetups
                                join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                where ca.StationName == StationName && cs.IsActive == true && ca.IsDefaultInsAll == true
                                orderby cs.CustomerName ascending
                                select cs).ToList();

            }
            return AllCustomers;
        }



        public static List<string> GetSubAccountDetails(int accid)
        {
            List<string> subAccountNameList = new List<string>();
            List<int> SubaccountIdList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                SubaccountIdList = (from a in context.CustomerAccountMappings
                                    where a.PrimaryAccountId == accid
                                    select a.SubAccountId).Distinct().ToList();

                subAccountNameList = (from account in context.CustomerAccounts
                                      where SubaccountIdList.Contains(account.CustomerAccountId)
                                      select account.CustomerSetup.CustomerName).ToList();
            }
            return subAccountNameList;
        }


        public static int GetCustomerAccountId(string customerName)
        {
            int customerAccountId = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                customerAccountId = (from cs in context.CustomerSetups
                                     join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                     where cs.CustomerName.ToUpper() == customerName.ToUpper()
                                     select ca.CustomerAccountId).FirstOrDefault();
            }

            return customerAccountId;
        }


        public static bool DefaultInsuredRates(string customerName)
        {
            bool isDefaultInsAll = true;

            using (WWProxyEntities entity = new WWProxyEntities())
            {
                entity.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                isDefaultInsAll = (from a in entity.CustomerAccounts
                                   where a.CustomerSetup.CustomerName.ToLower() == customerName.ToLower()
                                   select a.IsDefaultInsAll).FirstOrDefault();
            }

            return isDefaultInsAll;
        }

        public static InsAllRiskViewModel GetCustomerInsuranceAllRisk(int customerAccountId)
        {
            InsAllRiskViewModel SpecificInsAllRisk = new InsAllRiskViewModel();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                SpecificInsAllRisk = (from ca in context.CustomerAccounts
                                      where ca.CustomerAccountId == customerAccountId
                                      select new InsAllRiskViewModel
                                      {
                                          CustomerSpecificInsAllRisk = new List<CustomerSpecificInsAllRiskViewModel>
                                          {
                                              new CustomerSpecificInsAllRiskViewModel()
                                              {
                                              CustomerSpecificInsAllRiskDetails = new List<CustomerSpecificInsAllRiskDetailsViewModel>
                                              {
                                                   new CustomerSpecificInsAllRiskDetailsViewModel()
                                                   {
                                                  CostPerHundered = ca.CostPerHundred.ToString(),
                                                  MinimumCost = ca.MinimumInsCost!= null ? ca.MinimumInsCost.ToString() : string.Empty,
                                                  MaximumCost = ca.MaximumInsCost != null ? ca.MaximumInsCost.ToString() : string.Empty
                                                  }

                                              }
                                              }
                                          }
                                      }).FirstOrDefault();
            }
            return SpecificInsAllRisk;

        }

        public static int MinClaimNumberOfYear(int Year)
        {
            int MinClaimNumber = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {

                // MinClaimNumber = context.InsuranceClaims.Where(i => (i.ClaimNumber / 1000000) == Year).Select(i => Convert.ToInt32(i.ClaimNumber)).Select(x => x).Min();

                MinClaimNumber = context.InsuranceClaims.Where(x => x.ClaimNumber.ToString().Substring(0, 4) == Year.ToString()).OrderBy(m => m.ClaimNumber).Select(m => m.ClaimNumber).FirstOrDefault();
                // MinClaimNumber = context.InsuranceClaims.Where(x => x.ClaimNumber.ToString().Substring(0, 4) == year.ToString()).Min(x => x.ClaimNumber);
            }
            return MinClaimNumber;
        }

        public static List<int> LastNClaimNumber(int n)
        {
            List<int> ClaimNumberList = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                ClaimNumberList = (from a in context.InsuranceClaims orderby a.ClaimNumber descending select a.ClaimNumber).Take(n).ToList();
            }
            return ClaimNumberList;

        }

        public static InsuranceClaim ListOfDatesBasedonClaimNo(int claimnumber)
        {
            InsuranceClaim Getdate;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                // ClaimNumberList = (from a in context.InsuranceClaims select a.ClaimNumber).ToList();
                Getdate = (from date in context.InsuranceClaims
                           where date.ClaimNumber == claimnumber
                           select date).FirstOrDefault();

            }
            return Getdate;
        }
        public static string GetOustandingAmount(string GetClaimNumber)
        {
            string OutstandingAmount = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                OutstandingAmount = (from val in context.InsuranceClaims
                                     where val.ClaimNumber.ToString() == GetClaimNumber.ToString()
                                     select val.OutstandingAmount.ToString()).FirstOrDefault();
            }

            return OutstandingAmount;
        }



        public static int LatestClaimNumber()
        {
            int ClaimNumber = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                ClaimNumber = context.InsuranceClaims.Select(m => m.ClaimNumber).Max();
            }
            return ClaimNumber;
        }

        public static string ConfirmationOfAccuracySectionVerbiage()
        {
            string accuracyVerbiage = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                accuracyVerbiage = (from value in context.ApplicationConfigurations

                                    select value.FieldValue).FirstOrDefault();
            }

            return accuracyVerbiage;
        }

        public static InsuranceClaim GetInsuranceClaimDetails(int claimNumber)
        {
            InsuranceClaim _insclaim = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                _insclaim = (from proxy in context.InsuranceClaims
                             where proxy.ClaimNumber == claimNumber
                             select proxy).FirstOrDefault();

            }

            return _insclaim;

        }

        public static InsuranceClaimCarrier GetInsuranceClaimCarrierDetails(int claimNumber)
        {
            InsuranceClaimCarrier _insclaimCarrier = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                _insclaimCarrier = (from proxy in context.InsuranceClaimCarriers
                                    where proxy.ClaimNumber == claimNumber
                                    select proxy).FirstOrDefault();

            }
            return _insclaimCarrier;

        }
        public static IList<string> UserSpecificCustomReportList(string email)
        {

            IList<string> CustomReportNames = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomReportNames = (from a in context.InvoiceCustomReports where a.UserEmail == email select a.CustomReportName).ToList();
            }
            return CustomReportNames;
        }

        public static List<CustomReport> OnlyCustomReport(string email)
        {
            List<CustomReport> CustomReports = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomReports = (from a in context.CustomReports where a.IsSharedReport == false select a).ToList();
            }
            return CustomReports;
        }

        public static List<string> GetPaymentTypes()
        {
            List<string> PaymentTypeValues = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                PaymentTypeValues = (from val in context.InsuranceClaimPaymentTypes
                                     select val.PaymentType).ToList();
            }
            return PaymentTypeValues;
        }

        public static string GetWeeklyActiveCustomReportName(string email)
        {
            string weeklyActiveScheduledCustomReportName = null;
            using (WWProxyEntities invoice = new WWProxyEntities())
            {
                weeklyActiveScheduledCustomReportName = (from InvoiceCustomReport in invoice.InvoiceCustomReports
                                                         join ScheduledReport in invoice.ScheduledReports
                                                         on InvoiceCustomReport.InvoiceCustomReportId equals ScheduledReport.InvoiceCustomReportId
                                                         join WeeklyScheduledReport in invoice.WeeklyScheduledReports
                                                         on ScheduledReport.ScheduledReportId equals WeeklyScheduledReport.ScheduledReportId
                                                         join ReportFrequency in invoice.ReportFrequencies
                                                         on ScheduledReport.ReportFrequencyId equals ReportFrequency.ReportFrequencyId
                                                         where InvoiceCustomReport.UserEmail == email && InvoiceCustomReport.IsScheduled == true && ReportFrequency.ReportFrequencyValue == "Weekly"
                                                         select InvoiceCustomReport.CustomReportName).FirstOrDefault();
            }

            return weeklyActiveScheduledCustomReportName;
        }



        public static string GetMonthlyActiveCustomReportName(string email)
        {
            string monthlyActiveScheduledCustomReportName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                monthlyActiveScheduledCustomReportName = (from InvoiceCustomReport in context.InvoiceCustomReports
                                                          join ScheduledReport in context.ScheduledReports
                                                          on InvoiceCustomReport.InvoiceCustomReportId equals ScheduledReport.InvoiceCustomReportId
                                                          join MonthlyScheduledReport in context.MonthlyScheduledReports
                                                          on ScheduledReport.ScheduledReportId equals MonthlyScheduledReport.ScheduledReportId
                                                          join ReportFrequency in context.ReportFrequencies
                                                          on ScheduledReport.ReportFrequencyId equals ReportFrequency.ReportFrequencyId
                                                          where InvoiceCustomReport.UserEmail == email && InvoiceCustomReport.IsScheduled == true && ReportFrequency.ReportFrequencyValue == "Monthly"
                                                          select InvoiceCustomReport.CustomReportName).FirstOrDefault();
            }

            return monthlyActiveScheduledCustomReportName;
        }



        public static MonthyScheduledReportViewModel GetMonthlyCustomReportDetails(string customReportName)
        {
            MonthyScheduledReportViewModel monthlyScheduledCustomReportDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                monthlyScheduledCustomReportDetails = (from InvoiceCustomReport in context.InvoiceCustomReports
                                                       join ScheduledReport in context.ScheduledReports
                                                       on InvoiceCustomReport.InvoiceCustomReportId equals ScheduledReport.InvoiceCustomReportId
                                                       join monthlyScheduledReport in context.MonthlyScheduledReports
                                                       on ScheduledReport.ScheduledReportId equals monthlyScheduledReport.ScheduledReportId
                                                       join ReportFrequency in context.ReportFrequencies
                                                       on ScheduledReport.ReportFrequencyId equals ReportFrequency.ReportFrequencyId
                                                       where InvoiceCustomReport.CustomReportName == customReportName
                                                       select new MonthyScheduledReportViewModel()
                                                       {
                                                           // MonthlyScheduledReportId = monthlyScheduledReport.ScheduledReportId,
                                                           // ScheduledReportId = monthlyScheduledReport.ScheduledReportId,
                                                           Months = monthlyScheduledReport.Months,
                                                           Week = monthlyScheduledReport.Week,
                                                           WeekDay = monthlyScheduledReport.WeekDay,
                                                           DayOfMonth = monthlyScheduledReport.DayOfMonth,
                                                           MonthlyReportTime = monthlyScheduledReport.MonthlyReportTime,
                                                           CreatedBy = monthlyScheduledReport.CreatedBy,
                                                           CreatedDate = monthlyScheduledReport.CreatedDate,
                                                           ModifiedBy = monthlyScheduledReport.ModifiedBy,
                                                           ModifiedDate = monthlyScheduledReport.ModifiedDate,
                                                           // ScheduledReport= monthlyScheduledReport.ScheduledReport,
                                                           EmailTo = ScheduledReport.EmailTo,
                                                           EmailCC = ScheduledReport.EmailCC,
                                                           EmailReplyTo = ScheduledReport.EmailReplyTo,
                                                           ReportFormat = ScheduledReport.ReportFormat,
                                                           EmailSubject = ScheduledReport.EmailSubject,
                                                           Comment = ScheduledReport.EmailBody,
                                                           CustomReportName = InvoiceCustomReport.CustomReportName,
                                                           IsScheduled = InvoiceCustomReport.IsScheduled,
                                                           ReportFrequencyVal = ReportFrequency.ReportFrequencyValue

                                                       }).FirstOrDefault();
            }

            return monthlyScheduledCustomReportDetails;


        }

        public static string GetNotScheduledCustomReportName(string email)
        {
            string CustomReportName = null;
            using (WWProxyEntities invoice = new WWProxyEntities())
            {
                CustomReportName = (from InvoiceCustomReport in invoice.InvoiceCustomReports
                                    where InvoiceCustomReport.UserEmail == email && InvoiceCustomReport.IsScheduled == false
                                    select InvoiceCustomReport.CustomReportName).FirstOrDefault();
            }

            return CustomReportName;
        }

        public static WeeklyScheduleReportViewModel GetWeeklyCustomReportDetails(string customReportName)
        {
            WeeklyScheduleReportViewModel weeklyScheduledCustomReportDetails = null;
            using (WWProxyEntities invoice = new WWProxyEntities())
            {
                weeklyScheduledCustomReportDetails = (from InvoiceCustomReport in invoice.InvoiceCustomReports
                                                      join ScheduledReport in invoice.ScheduledReports
                                                      on InvoiceCustomReport.InvoiceCustomReportId equals ScheduledReport.InvoiceCustomReportId
                                                      join WeeklyScheduledReport in invoice.WeeklyScheduledReports
                                                      on ScheduledReport.ScheduledReportId equals WeeklyScheduledReport.ScheduledReportId
                                                      join ReportFrequency in invoice.ReportFrequencies
                                                      on ScheduledReport.ReportFrequencyId equals ReportFrequency.ReportFrequencyId
                                                      where InvoiceCustomReport.CustomReportName == customReportName
                                                      select new WeeklyScheduleReportViewModel
                                                      {
                                                          WeekDay = WeeklyScheduledReport.WeekDay,
                                                          WeeklyReportTime = WeeklyScheduledReport.WeeklyReportTime,
                                                          EmailTo = ScheduledReport.EmailTo,
                                                          EmailCC = ScheduledReport.EmailCC,
                                                          EmailReplyTo = ScheduledReport.EmailReplyTo,
                                                          ReportFormat = ScheduledReport.ReportFormat,
                                                          EmailSubject = ScheduledReport.EmailSubject,
                                                          Comment = ScheduledReport.EmailBody,
                                                          CustomReportName = InvoiceCustomReport.CustomReportName,
                                                          IsScheduled = InvoiceCustomReport.IsScheduled,
                                                          ReportFrequencyVal = ReportFrequency.ReportFrequencyValue

                                                      }).FirstOrDefault();
            }

            return weeklyScheduledCustomReportDetails;


        }



        public static InvoiceCustomReport InvoiceCustomReportId(string customReportName)
        {
            InvoiceCustomReport invoiceCustomReportId = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                invoiceCustomReportId = (from InvoiceCustomReport in context.InvoiceCustomReports
                                         join scheduledReport in context.ScheduledReports on InvoiceCustomReport.InvoiceCustomReportId equals scheduledReport.ScheduledReportId
                                         where InvoiceCustomReport.CustomReportName == customReportName
                                         select InvoiceCustomReport).FirstOrDefault();
            }

            return invoiceCustomReportId;
        }

        public static ScheduledReport ScheduledReportId(string customReportName)
        {
            ScheduledReport ScheduledReportId = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                ScheduledReportId = (from InvoiceCustomReport in context.InvoiceCustomReports
                                     join scheduledReport in context.ScheduledReports on InvoiceCustomReport.InvoiceCustomReportId equals scheduledReport.InvoiceCustomReportId
                                     where InvoiceCustomReport.CustomReportName == customReportName
                                     select scheduledReport).FirstOrDefault();
            }

            return ScheduledReportId;
        }

        public static WeeklyScheduledReport WScheduledReportId(int ScheduledReportId)
        {
            WeeklyScheduledReport WScheduledReportId = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                WScheduledReportId = (from WeeklyScheduledReport in context.WeeklyScheduledReports
                                      where WeeklyScheduledReport.ScheduledReportId == ScheduledReportId
                                      select WeeklyScheduledReport).FirstOrDefault();
            }

            return WScheduledReportId;
        }

        public static WeeklyScheduledReport WScheduledReport(int WScheduledReportId)
        {
            WeeklyScheduledReport WScheduledReport = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                WScheduledReport = (from WeeklyScheduledReport in context.WeeklyScheduledReports
                                    where WeeklyScheduledReport.WeeklyScheduledReportId == WScheduledReportId
                                    select WeeklyScheduledReport).FirstOrDefault();
            }

            return WScheduledReport;
        }


        public static InvoiceCustomReport InvoiceCustomReporttableRow(int invoiceCustomReportId)
        {
            InvoiceCustomReport invoiceCustomReportid = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                invoiceCustomReportid = (from InvoiceCustomReport in context.InvoiceCustomReports
                                         where InvoiceCustomReport.InvoiceCustomReportId == invoiceCustomReportId
                                         select InvoiceCustomReport).FirstOrDefault();
            }

            return invoiceCustomReportid;
        }

        public static ScheduledReport ScheduledReporttableRow(int ScheduledReportId)
        {
            ScheduledReport scheduledReportId = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                scheduledReportId = (from scheduledReport in context.ScheduledReports
                                     where scheduledReport.ScheduledReportId == ScheduledReportId
                                     select scheduledReport).FirstOrDefault();
            }

            return scheduledReportId;
        }


        public static IQueryable<CustomerInvoice> FilterCustomGridData(string daysPastDue, string invoiceValue, string InvoiveType, string stationName, string startDate, string endDate, string status, string accountName)
        {
            IQueryable<CustomerInvoice> CustomGridData = null;


            using (WWProxyEntities context = new WWProxyEntities())
            {
                DateTime StartDate = Convert.ToDateTime(startDate);
                DateTime EndDate = Convert.ToDateTime(endDate);

                //first filter invoice status
                CustomGridData = (from m in context.CustomerInvoices where m.InvoiceStatus == status select m);

                //filter start and end date which is optional field
                CustomGridData = context.CustomerInvoices.AsParallel().Where(m => m.InvoiceDate >= Convert.ToDateTime(startDate) && m.InvoiceDate <= Convert.ToDateTime(endDate)).AsQueryable();

                // filter greater than invoice value which is optional field
                CustomGridData = context.CustomerInvoices.AsParallel().Where(m => m.InvoiceAmount > Convert.ToDecimal(invoiceValue)).AsQueryable();

                //filter less than invoice value which is optional
                CustomGridData = context.CustomerInvoices.AsParallel().Where(m => m.InvoiceAmount < Convert.ToDecimal(invoiceValue)).AsQueryable();

                // filter station name which is mandatory field
                // CustomGridFilterStationNameValue = context.CustomerInvoices.AsParallel().Where(m => m.)

                //filter account name which is mandatory field
                // CustomGridData = context.CustomerInvoices.AsParallel().Where(m => m.CustomerNumber == accountName)).AsQueryable();

                //filter dayspastdue which is optional
                CustomGridData = context.CustomerInvoices.AsParallel().Where(m => m.DueDate == Convert.ToDateTime(daysPastDue)).AsQueryable();
            }
            return CustomGridData;
        }

        public static InvoiceCustomReport GetCustomReportDataBasedOnReport(string CustomReport_Name)
        {
            InvoiceCustomReport GetReocrds = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                GetReocrds = (from proxy in context.InvoiceCustomReports
                              where proxy.CustomReportName == CustomReport_Name
                              select proxy).FirstOrDefault();

            }

            return GetReocrds;

        }

        public static InvoiceType GetStatusof_InvoiceType(int InvoiceType_Id)
        {
            InvoiceType GetReocrds = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                GetReocrds = (from proxy in context.InvoiceTypes
                              where proxy.InvoiceTypeId == InvoiceType_Id
                              select proxy).FirstOrDefault();

            }

            return GetReocrds;

        }

        public static List<CustomReportStationMapping> ToGetStationID(int CustomReport_Id)
        {
            List<CustomReportStationMapping> StationsID_List = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                StationsID_List = (from a in context.CustomReportStationMappings where a.InvoiceCustomReportId == CustomReport_Id select a).ToList();
            }
            return StationsID_List;
        }

        public static List<CustomReportCustomerMapping> ToGetCustomerSetupID(int CustomReport_Id)
        {
            List<CustomReportCustomerMapping> CustomerSetUpID_List = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                CustomerSetUpID_List = (from a in context.CustomReportCustomerMappings where a.InvoiceCustomReportId == CustomReport_Id select a).ToList();
            }
            return CustomerSetUpID_List;
        }

        public static bool isReportDeleted(int CustomReport_Id)
        {
            int reportDeleted = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                reportDeleted = (from a in context.InvoiceCustomReports where a.InvoiceCustomReportId == CustomReport_Id select a).Count();
            }
            return reportDeleted == 0;
        }

        public static List<InvoiceCustomReport> GetMonthlyActiveCustomReportName_All(string email)
        {
            List<InvoiceCustomReport> monthlyActiveScheduledCustomReportName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                monthlyActiveScheduledCustomReportName = (from InvoiceCustomReport in context.InvoiceCustomReports
                                                          join ScheduledReport in context.ScheduledReports
                                                          on InvoiceCustomReport.InvoiceCustomReportId equals ScheduledReport.InvoiceCustomReportId
                                                          join MonthlyScheduledReport in context.MonthlyScheduledReports
                                                          on ScheduledReport.ScheduledReportId equals MonthlyScheduledReport.ScheduledReportId
                                                          join ReportFrequency in context.ReportFrequencies
                                                          on ScheduledReport.ReportFrequencyId equals ReportFrequency.ReportFrequencyId
                                                          where InvoiceCustomReport.UserEmail == email && InvoiceCustomReport.IsScheduled == true && ReportFrequency.ReportFrequencyValue == "Monthly"
                                                          select InvoiceCustomReport).ToList();
            }

            return monthlyActiveScheduledCustomReportName;
        }


        public static InvoiceCustomReport GetInvoiceCustomReportId(string customReportName, string email)
        {
            InvoiceCustomReport invoiceCustomReportId = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                invoiceCustomReportId = (from i in context.InvoiceCustomReports
                                         where i.CustomReportName == customReportName && i.UserEmail == email
                                         select i).FirstOrDefault();
            }

            return invoiceCustomReportId;
        }
        public static Boolean GetScheduledReporMonthlyorWeekly(string reportName)
        {
            bool GetReocrds;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int v = (from invoiceCustomerReport in context.InvoiceCustomReports
                         join scheduledReport in context.ScheduledReports
                         on invoiceCustomerReport.InvoiceCustomReportId equals scheduledReport.InvoiceCustomReportId
                         where scheduledReport.ReportFrequencyId == 2 && reportName == invoiceCustomerReport.CustomReportName
                         select scheduledReport.ReportFrequencyId).FirstOrDefault();
                if (v == 2)
                {
                    GetReocrds = true;
                }
                else
                {
                    GetReocrds = false;
                }
            }
            return GetReocrds;
        }

        public static List<InvoiceCustomReport> GetWeeklyActiveCustomReportName_All(string email)
        {
            List<InvoiceCustomReport> monthlyActiveScheduledCustomReportName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                monthlyActiveScheduledCustomReportName = (from InvoiceCustomReport in context.InvoiceCustomReports
                                                          join ScheduledReport in context.ScheduledReports
                                                          on InvoiceCustomReport.InvoiceCustomReportId equals ScheduledReport.InvoiceCustomReportId
                                                          join WeeklyScheduledReport in context.WeeklyScheduledReports
                                                          on ScheduledReport.ScheduledReportId equals WeeklyScheduledReport.ScheduledReportId
                                                          join ReportFrequency in context.ReportFrequencies
                                                          on ScheduledReport.ReportFrequencyId equals ReportFrequency.ReportFrequencyId
                                                          where InvoiceCustomReport.UserEmail == email && InvoiceCustomReport.IsScheduled == true && ReportFrequency.ReportFrequencyValue == "Weekly"
                                                          select InvoiceCustomReport).ToList();
            }

            return monthlyActiveScheduledCustomReportName;
        }

        public static DefaultAccessorialSetup getdefaultAccessorials()
        {
            DefaultAccessorialSetup DefaultAccessorial = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                DefaultAccessorial = (from AccessorialSetups in context.DefaultAccessorialSetups
                                      where AccessorialSetups.CarrierSCAC == null
                                      select AccessorialSetups).FirstOrDefault();
            }

            return DefaultAccessorial;
        }

        public static bool isScheduleReportDeleted(string customReportName)
        {
            int reportDeleted = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                reportDeleted = (from i in context.InvoiceCustomReports
                                 join s in context.ScheduledReports on i.InvoiceCustomReportId equals s.InvoiceCustomReportId
                                 where i.CustomReportName == customReportName
                                 select s).Count();
            }
            return reportDeleted == 0;
        }



        public static Address FirstAddress(string accountName)
        {
            Address address = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                address = (from add in context.Addresses
                           join customerAccount in context.CustomerAccounts
                           on add.CustomerAccountId equals customerAccount.CustomerAccountId
                           join customerSetup in context.CustomerSetups
                           on customerAccount.CustomerSetUpId equals customerSetup.CustomerSetupId
                           where customerSetup.CustomerName == accountName
                           select add).FirstOrDefault();

            }
            return address;
        }

        public static Item GetItemDetailsBasedDimension(string accountName, string dimensionType)
        {
            Item itemValue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                itemValue = (from item in context.Items
                             join customerAccount in context.CustomerAccounts
                             on item.CustomerAccountId equals customerAccount.CustomerAccountId
                             join customersetup in context.CustomerSetups
                             on customerAccount.CustomerSetUpId equals customersetup.CustomerSetupId
                             where customersetup.CustomerName == accountName && item.DimensionUnit == dimensionType
                             select item).FirstOrDefault();
            }


            return itemValue;
        }


        public static Item GetDefaultItemDetailsBasedDimension(string accountName)
        {

            Item itemValue = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                itemValue = (from item in context.Items
                             join account in context.CustomerAccounts
                             on item.CustomerAccountId equals account.CustomerAccountId
                             join setup in context.CustomerSetups
                             on account.CustomerSetUpId equals setup.CustomerSetupId
                             where setup.CustomerName == accountName && item.IsDefaultItem
                             select item).FirstOrDefault();
            }
            return itemValue;
        }

        public static InsuranceClaimConsigneeAddress GetConsigneeAddress(int ClaimNumber)
        {
            InsuranceClaimConsigneeAddress AddressDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                AddressDetails = (from a in context.InsuranceClaimConsigneeAddresses
                                  where a.ClaimNumber == ClaimNumber
                                  select a).FirstOrDefault(null);
            }

            return AddressDetails;
        }

        public static InsuranceForwardingMode GetForwardingModeDetails(int claimNumber)
        {
            InsuranceForwardingMode InsuranceForwardingMode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                InsuranceForwardingMode = (from x in context.InsuranceForwardingModes
                                           where x.ClaimNumber == claimNumber
                                           select x).FirstOrDefault();
            }

            return InsuranceForwardingMode;
        }

        public static InsuranceClaim GetFtlClaimNumber()
        {
            InsuranceClaim claimNumber = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimNumber = (from x in context.InsuranceClaims
                               where x.ShipmentMode.Equals("ftl") && x.InsuranceClaimStatusId == 4
                               orderby x.CreateDateTime
                               select x).FirstOrDefault();
            }
            return claimNumber;
        }

        public static int GetRecentClaimNumber()
        {
            int claimNumber = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimNumber = (from x in context.InsuranceClaims
                               where x.InsuranceClaimStatusId == 4
                               orderby x.CreateDateTime descending
                               select x.ClaimNumber).FirstOrDefault();
            }
            return claimNumber;
        }

        public static int GetRecentClaimNumberWithPayment()
        {
            int claimNumber = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                claimNumber = (from x in context.InsuranceClaimPayments
                               orderby x.CreateDateTime descending
                               select x.ClaimNumber).FirstOrDefault();
            }
            return claimNumber;
        }
        public static int GetForwardingClaimNumber()
        {
            int claimNumber = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimNumber = (from x in context.InsuranceClaims
                               where x.ShipmentMode.Equals("forwarding") && x.InsuranceClaimStatusId == 4
                               orderby x.CreateDateTime descending
                               select x.ClaimNumber).FirstOrDefault();
            }
            return claimNumber;
        }

        public static string GetClaimStatus(int claimNumber)
        {
            string updatedClaimStatus = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                updatedClaimStatus = (from x in context.InsuranceClaimHistories
                                      where x.ClaimNumber == claimNumber
                                      orderby x.CreatedDate descending
                                      select x.Comments).FirstOrDefault();
            }
            return updatedClaimStatus;

        }
        public static InsuranceClaim GetShipmentMode(int claimNumber)
        {
            InsuranceClaim claimMode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                //  context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimMode = (from x in context.InsuranceClaims
                             where x.ClaimNumber == claimNumber
                             select x).FirstOrDefault();
            }
            return claimMode;
        }

        public static InsuranceClaim GetInsuranceClaimDetails(string claimNumber)
        {
            InsuranceClaim insuranceClaimsDetails = new InsuranceClaim();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                insuranceClaimsDetails = (from claimsList in context.InsuranceClaims
                                          where claimsList.ClaimNumber.ToString() == claimNumber
                                          select claimsList).FirstOrDefault();
            }

            return insuranceClaimsDetails;
        }

        public static InsuranceClaimDetailsHeaderViewModel GetInsuranceClaimDetailsHeader(int claimNumber)
        {
            InsuranceClaimDetailsHeaderViewModel insuranceClaimDetailsHeadervalues = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                insuranceClaimDetailsHeadervalues = (from claim in context.InsuranceClaims
                                                     join carrierClaim in context.InsuranceClaimCarriers
                                                     on claim.ClaimNumber equals carrierClaim.ClaimNumber
                                                     into Insclaimcarrier
                                                     from dataClaimCarrier in Insclaimcarrier.DefaultIfEmpty()
                                                     join claimPayable in context.InsuranceClaimPayableToes
                                                     on claim.ClaimNumber equals claimPayable.ClaimNumber
                                                     into InsclaimPayableTo
                                                     from dataclaimPayableTo in InsclaimPayableTo.DefaultIfEmpty()
                                                     join claimRep in context.InsuranceClaimReps
                                                     on claim.InsuranceClaimRepId equals claimRep.InsuranceClaimRepId
                                                     into InsClaimRep
                                                     from dataclaimRep in InsClaimRep.DefaultIfEmpty()
                                                     join claimReason in context.InsuranceClaimReasonCodes
                                                     on claim.InsuranceClaimReasonCodeId equals claimReason.InsuranceClaimReasonCodeId
                                                     into InsClaimReasonCodes
                                                     from dataInsClaimReasonCodes in InsClaimReasonCodes.DefaultIfEmpty()
                                                     where claim.ClaimNumber == claimNumber
                                                     select new InsuranceClaimDetailsHeaderViewModel
                                                     {
                                                         ClaimNumber = claim.ClaimNumber,
                                                         Claimant = dataclaimPayableTo.CompanyName,
                                                         Carriername = dataClaimCarrier.CarrierName,
                                                         CarrierPro = dataClaimCarrier.CarrierProNumber,
                                                         ClaimRep = dataclaimRep.InsuranceClaimRepName,
                                                         ClaimReason = dataInsClaimReasonCodes.InsuranceClaimReasonCode1,
                                                         ClaimCreatedDate = claim.CreateDateTime,
                                                         DLSWReferenceNumber = dataClaimCarrier.DlswRefNumber,
                                                         IsClaimInsured = claim.IsArticlesInsured
                                                     }).FirstOrDefault();
            }
            return insuranceClaimDetailsHeadervalues;
        }

        public static IList<CustomerAccount> GetAllStationDetails()
        {
            IList<CustomerAccount> stationDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                //stationDetails = context.CustomerAccounts.Where(a => !a.IsActive).FirstOrDefault();
                stationDetails = (from data in context.CustomerAccounts
                                  where data.IsStation
                                  select data).ToList();


            }
            return stationDetails;
        }

        public static InsuranceClaimPayableTo GetInsuranceClaimPayableToDetails(int ClaimNumber)
        {
            InsuranceClaimPayableTo InsuranceClaimPayableTo = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                InsuranceClaimPayableTo = (from data in context.InsuranceClaimPayableToes

                                           where data.ClaimNumber == ClaimNumber
                                           select data).FirstOrDefault();
            }
            return InsuranceClaimPayableTo;
        }

        public static List<InsuredRateCarrier> GetAllCarrierDetails()
        {
            List<InsuredRateCarrier> insuredRateCarrierDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                insuredRateCarrierDetails = (from data in context.InsuredRateCarriers
                                             select data).ToList();
            }

            return insuredRateCarrierDetails;
        }

        public static CustomerAccount GetCustAccountDetails(int customerSetUpId)
        {
            CustomerAccount customerDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerDetails = context.CustomerAccounts.Where(a => a.CustomerSetUpId == customerSetUpId && a.IsActive).FirstOrDefault();


            }
            return customerDetails;
        }




        public static List<InsuranceClaimFreight> GetOriginalFreightCharges()
        {
            List<InsuranceClaimFreight> orginalFreightCharges = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                orginalFreightCharges = (from data in context.InsuranceClaimFreights
                                         where data.IsOriginalFreightCharges == true
                                         select data).ToList();


            }

            return orginalFreightCharges;
        }

        public static List<InsuranceClaimFreight> GetReturnFreightCharges()
        {
            List<InsuranceClaimFreight> returnFreightCharges = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                returnFreightCharges = (from data in context.InsuranceClaimFreights
                                        where data.IsReturnFreightCharges == true
                                        select data).ToList();


            }

            return returnFreightCharges;
        }

        public static List<InsuranceClaimFreight> GetReplacementFreightCharges()
        {
            List<InsuranceClaimFreight> replacementFreightCharges = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                replacementFreightCharges = (from data in context.InsuranceClaimFreights
                                             where data.IsReplacementFreightCharges == true
                                             select data).ToList();


            }

            return replacementFreightCharges;
        }

        public static List<int> GetAllClaimNumbersOfFreightCalculation()
        {
            List<int> claimNumbersWithFreight = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimNumbersWithFreight = (from data in context.InsuranceClaimFreights
                                           select data.ClaimNumber).ToList();
            }

            return claimNumbersWithFreight;
        }

        public static List<int> GetAllClaimNumbersWith_Original_Return_Replacement_Freight()
        {
            List<int> claimNumbersOriginalReturnReplacementFreight = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimNumbersOriginalReturnReplacementFreight = (from data in context.InsuranceClaimFreights
                                                                where ((data.IsOriginalFreightCharges == true) && (data.IsReturnFreightCharges == true) && (data.IsReplacementFreightCharges == true))
                                                                select data.ClaimNumber).ToList();
            }

            return claimNumbersOriginalReturnReplacementFreight;
        }

        public static InsuranceClaimShipperAddress GetShipperInformation_DetailsTabBy_ClaimNumber(int Claim_Number)
        {
            InsuranceClaimShipperAddress Information = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");


                Information = (from InsuranceClaimShipperAddress in context.InsuranceClaimShipperAddresses
                               join Country in context.Countries on InsuranceClaimShipperAddress.CountryId equals Country.CountryId
                               join InsuranceClaimCarrier in context.InsuranceClaimCarriers
                               on InsuranceClaimShipperAddress.ClaimNumber equals InsuranceClaimCarrier.ClaimNumber
                               join InsuranceClaim in context.InsuranceClaims
                               on InsuranceClaimCarrier.ClaimNumber equals InsuranceClaim.ClaimNumber
                               where InsuranceClaim.ClaimNumber == Claim_Number
                               select InsuranceClaimShipperAddress).FirstOrDefault();

            }
            return Information;
        }

        public static string GetPPP_Customer(string Station_Name)
        {
            string PPP_Customer = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                PPP_Customer = (from data in context.CustomerAccounts
                                join value in context.CustomerSetups on data.CustomerSetUpId equals value.CustomerSetupId
                                where data.StationName == Station_Name && data.IsDefaultInsAll == false && value.IsActive == true && (data.TmsSystem == "MG" || data.TmsSystem == "BOTH") && data.IsStation == false
                                select value.CustomerName).FirstOrDefault();
            }

            return PPP_Customer;
        }

        public static string GetStandard_Customer(string Station_Name)
        {
            string Standard_Customer = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                Standard_Customer = (from data in context.CustomerAccounts
                                     join value in context.CustomerSetups on data.CustomerSetUpId equals value.CustomerSetupId
                                     where data.StationName == Station_Name && data.IsDefaultInsAll == true && value.IsActive == true && (data.TmsSystem == "MG" || data.TmsSystem == "BOTH") && data.IsStation == false
                                     select value.CustomerName).FirstOrDefault();
            }

            return Standard_Customer;
        }



        public static List<string> GetStationNames(List<string> stationId)
        {
            List<string> StationNames = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {

                StationNames = (from cus in context.CustomerAccounts
                                where (stationId.Contains(cus.StationId)) && cus.IsStation == true
                                select cus.StationName).ToList();

            }
            return StationNames;
        }

        public static List<string> GetStationList()
        {
            List<string> StationName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                StationName = (from acc in context.CustomerAccounts
                               select acc.StationName).Distinct().ToList();
            }

            return StationName;
        }

        public static List<string> StationList()
        {
            List<string> StationName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                StationName = (from acc in context.CustomerAccounts
                               where acc.IsStation == true
                               select acc.StationName).Distinct().ToList();
            }

            return StationName;
        }
        public static List<string> GetAllClaimReasonCodes()
        {
            List<string> claimReasons = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimReasons = (from data in context.InsuranceClaimReasonCodes

                                select data.InsuranceClaimReasonCode1).ToList();
            }

            return claimReasons;

        }


        public static List<string> GetAllClaimSalesRep()
        {
            List<string> claimAllSalesRep = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimAllSalesRep = (from data in context.InsuranceClaimReps

                                    select data.InsuranceClaimRepName).ToList();
            }

            return claimAllSalesRep;

        }

        public static List<CookieModel> GetAllCookiesfromDb()
        {
            List<CookieModel> cookies = new List<CookieModel>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                cookies = (from cookie in context.Cookies
                           select new CookieModel()
                           {
                               CookieName = cookie.CookieName,
                               LifeSpan = cookie.Lifespan,
                               PartType = cookie.PartType.PartTypeName,
                               Purpose = cookie.Purpose,
                               CookieCategory = cookie.CookieCategory.CookieCategoryName,
                               ModifiedDate = cookie.ModifiedDate
                           }).OrderBy(m => m.CookieCategory).ToList();
            }

            return cookies;
        }

        public static List<CookieCategoryModel> GetAllCookieCategories()
        {
            List<CookieCategoryModel> cookieCategories = new List<CookieCategoryModel>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                cookieCategories = (from category in context.CookieCategories
                                    select new CookieCategoryModel()
                                    {
                                        CookieCategoryDescription = category.Description,
                                        CookieCategoryName = category.CookieCategoryName
                                    }).OrderBy(m => m.CookieCategoryName).ToList();
            }

            return cookieCategories;
        }

        public static int GetNewlySubmittedClaimNumber()
        {
            int ClaimNum = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                ClaimNum = (from cn in context.InsuranceClaims
                            orderby cn.CreateDateTime descending
                            select cn.ClaimNumber).Skip(1).First();
            }

            return ClaimNum;
        }


        public static List<string> GetGainshareCustomer()
        {
            List<string> customerName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerName = (from a in context.GainsharePricingModels
                                join b in context.CustomerAccounts
                                on a.CustomerAccountId equals b.CustomerAccountId
                                where b.IsStation == false
                                join c in context.CustomerSetups
                                on b.CustomerSetUpId equals c.CustomerSetupId
                                select c.CustomerName).ToList();
            }

            return customerName;
        }


        public static List<string> GetCustomers()
        {
            List<string> customers = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                customers = (from name in context.CustomerSetups
                             join B in context.CustomerAccounts
                             on name.CustomerSetupId equals B.CustomerSetUpId
                             where B.IsStation == false
                             select name.CustomerName).ToList();

            }
            return customers;
        }



        public static InsuranceClaimConsigneeAddress GetInsuranceClaimConsigneeAddresses(string claimNumber)
        {
            InsuranceClaimConsigneeAddress consigneeAddress = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                consigneeAddress = (from address in context.InsuranceClaimConsigneeAddresses
                                    join carrier in context.InsuranceClaimCarriers on address.ClaimNumber equals carrier.ClaimNumber
                                    where carrier.ClaimNumber.ToString() == claimNumber
                                    select address).FirstOrDefault();
            }

            return consigneeAddress;
        }

        public static InsuranceCarrierOsdAction GetCarrierOsdActionsdetails(string claimNumber)
        {
            InsuranceCarrierOsdAction carrierOsdactions = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                carrierOsdactions = (from CarrierOsdActions in context.InsuranceCarrierOsdActions
                                     join carrier in context.InsuranceClaims on CarrierOsdActions.ClaimNumber equals carrier.ClaimNumber
                                     where carrier.ClaimNumber.ToString() == claimNumber
                                     select CarrierOsdActions).FirstOrDefault();
            }

            return carrierOsdactions;
        }


        public static InsuranceClaimFreight GetInsuranceClaimFrieghtCalculationsDetails(string claimNumber)
        {
            int claimNo = Convert.ToInt32(claimNumber);
            InsuranceClaimFreight frieghtDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                frieghtDetails = (from frieght in context.InsuranceClaimFreights
                                  where frieght.ClaimNumber == claimNo
                                  select frieght).FirstOrDefault();
            }

            return frieghtDetails;
        }



        public static InsuranceClaimCarrier GetInsuranceCarrierDetails(string claimNumber)
        {
            InsuranceClaimCarrier carrierDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                carrierDetails = (from ClaimCarrier in context.InsuranceClaimCarriers
                                  where ClaimCarrier.ClaimNumber.ToString() == claimNumber
                                  select ClaimCarrier).FirstOrDefault();
            }

            return carrierDetails;
        }

        public static InsuranceClaim GetInsuranceCliamDetails(string claimNumber)
        {
            InsuranceClaim insuranceDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                insuranceDetails = (from InsuranceDetails in context.InsuranceClaims
                                    join carrier in context.InsuranceClaimCarriers on InsuranceDetails.ClaimNumber equals carrier.ClaimNumber
                                    where carrier.ClaimNumber.ToString() == claimNumber
                                    select InsuranceDetails).FirstOrDefault();
            }

            return insuranceDetails;
        }
        public static InsuranceClaimRep GetInsuranceClaimRep(string claimNumber)
        {
            InsuranceClaimRep insuranceClaimRep = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                insuranceClaimRep = (from claimRep in context.InsuranceClaimReps
                                     join carrier in context.InsuranceClaims on claimRep.InsuranceClaimRepId equals carrier.InsuranceClaimRepId
                                     where carrier.ClaimNumber.ToString() == claimNumber
                                     select claimRep).FirstOrDefault();
            }

            return insuranceClaimRep;
        }

        public static CustomerAccount GetClaimStationDetails(string claimNumber)
        {
            CustomerAccount stationDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                stationDetails = (from account in context.CustomerAccounts
                                  join claimStation in context.InsuranceClaims on account.CustomerSetUpId equals claimStation.CustomerSetUpId
                                  where claimStation.ClaimNumber.ToString() == claimNumber
                                  select account).FirstOrDefault();
            }

            return stationDetails;
        }

        public static InsuranceClaimReasonCode GetInsuranceClaimReason(string claimNumber)
        {
            InsuranceClaimReasonCode claimReason = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimReason = (from reason in context.InsuranceClaimReasonCodes
                               join carrier in context.InsuranceClaims on reason.InsuranceClaimReasonCodeId equals carrier.InsuranceClaimReasonCodeId
                               where carrier.ClaimNumber.ToString() == claimNumber
                               select reason).FirstOrDefault();
            }

            return claimReason;
        }

        public static InsuranceClaimPayableTo GetClaimantDetails(string claimNumber)
        {
            InsuranceClaimPayableTo claimDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                claimDetails = (from ClaimCarrier in context.InsuranceClaimPayableToes
                                where ClaimCarrier.ClaimNumber.ToString() == claimNumber
                                select ClaimCarrier).FirstOrDefault();
            }

            return claimDetails;
        }
        public static InsuranceClaimShipperAddress GetInsuranceClaimShipperAddresses(string ClaimNumber)
        {
            InsuranceClaimShipperAddress shipperAddress = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                shipperAddress = (from address in context.InsuranceClaimShipperAddresses
                                  join carrier in context.InsuranceClaimCarriers on address.ClaimNumber equals carrier.ClaimNumber
                                  where carrier.ClaimNumber.ToString() == ClaimNumber
                                  select address).FirstOrDefault();
            }

            return shipperAddress;
        }

        public static InsuranceDlswOsdAction GetDlswOsdActionsdetails(string ClaimNumber)
        {
            InsuranceDlswOsdAction DlswOsdactions = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                DlswOsdactions = (from DlswOsdActions in context.InsuranceDlswOsdActions
                                  join carrier in context.InsuranceClaims on DlswOsdActions.ClaimNumber equals carrier.ClaimNumber
                                  where carrier.ClaimNumber.ToString() == ClaimNumber
                                  select DlswOsdActions).FirstOrDefault();
            }

            return DlswOsdactions;
        }

        public static InsuranceClaim GetInsurancedetails(string ClaimNumber)
        {
            InsuranceClaim insuranceClaims = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                insuranceClaims = (from InsuranceDetails in context.InsuranceClaims
                                   join carrier in context.InsuranceClaimCarriers on InsuranceDetails.ClaimNumber equals carrier.ClaimNumber
                                   where carrier.ClaimNumber.ToString() == ClaimNumber
                                   select InsuranceDetails).FirstOrDefault();
            }

            return insuranceClaims;
        }


        public static InsuranceClaimItem GetInsuranceClaimItemdetails(string ClaimNumber)
        {
            InsuranceClaimItem insuranceClaimItems = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                insuranceClaimItems = (from InsuranceDetails in context.InsuranceClaimItems
                                       join carrier in context.InsuranceClaims on InsuranceDetails.ClaimNumber equals carrier.ClaimNumber
                                       where carrier.ClaimNumber.ToString() == ClaimNumber
                                       select InsuranceDetails).FirstOrDefault();
            }

            return insuranceClaimItems;
        }

        public static string GetInsuranceClaimType(int clmtypId)
        {
            string clmTyp = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                clmTyp = (from a in context.InsuranceClaimTypes
                          where a.InsuranceClaimTypeId == clmtypId
                          select a.Claimtype).FirstOrDefault();
            }
            return clmTyp;
        }

        public static string GetInsuranceArtType(int arttypId)
        {
            string artTyp = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                artTyp = (from a in context.InsuranceClaimArticleTypes
                          where a.InsuranceClaimArticleTypeId == arttypId
                          select a.ArticleType).FirstOrDefault();
            }
            return artTyp;
        }

        public static string GetInsuranceClaimCategory(int categoryId)
        {
            string categoryName = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                categoryName = (from a in context.Categories
                                where a.CategoryId == categoryId
                                select a.CategoryName).FirstOrDefault();
            }
            return categoryName;
        }

        public static Country GetCountryNameDetails(string claimNumber)
        {
            Country countryDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                countryDetails = (from consignee in context.InsuranceClaimConsigneeAddresses
                                  join address in context.Countries on consignee.CountryId equals address.CountryId
                                  where consignee.ClaimNumber.ToString() == claimNumber
                                  select address).FirstOrDefault();
            }

            return countryDetails;
        }

        public static Country GetShipperCountryNameDetails(string claimNumber)
        {
            Country countryDetails = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                countryDetails = (from shipper in context.InsuranceClaimShipperAddresses
                                  join address in context.Countries on shipper.CountryId equals address.CountryId
                                  where shipper.ClaimNumber.ToString() == claimNumber
                                  select address).FirstOrDefault();
            }

            return countryDetails;
        }

        public static InsuranceClaimHistory GetInsuranceClaimHistorydetails(string ClaimNumber)
        {
            InsuranceClaimHistory insuranceClaimHistory = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                insuranceClaimHistory = (from HistoryDetails in context.InsuranceClaimHistories
                                         join carrier in context.InsuranceClaims on HistoryDetails.ClaimNumber equals carrier.ClaimNumber
                                         where carrier.ClaimNumber.ToString() == ClaimNumber
                                         orderby HistoryDetails.ModifiedDate descending
                                         select HistoryDetails).FirstOrDefault();
            }

            return insuranceClaimHistory;
        }

        public static List<InsuranceClaimHistory> GetClaimHistoryOfUpdatedDateClaim(string ClaimNumber)
        {
            List<InsuranceClaimHistory> insClaimHistory = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                insClaimHistory = (from HistoryDetails in context.InsuranceClaimHistories
                                   join carrier in context.InsuranceClaims on HistoryDetails.ClaimNumber equals carrier.ClaimNumber
                                   where carrier.ClaimNumber.ToString() == ClaimNumber
                                   orderby HistoryDetails.ModifiedDate descending
                                   select HistoryDetails).ToList();

            }
            return insClaimHistory;
        }

        public static List<string> GetInsuranceCategoryList()
        {
            List<string> categoryList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                categoryList = (from category in context.Categories
                                where category.IsConfigurable == true
                                select category.CategoryName).ToList();
            }
            return categoryList;
        }

        public static List<string> GetInsuranceClaimStatusCode()
        {
            List<string> statusCode = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                statusCode = (from x in context.InsuranceClaimStatusCodes
                              select x.StatusCode).ToList();
            }
            return statusCode;
        }

        public static List<CustomerInvoiceListViewModel> GetInvoicesForCustomerName(string customerName, string status)
        {
            List<CustomerInvoiceListViewModel> customerOpenInvoiceDetails = new List<CustomerInvoiceListViewModel>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerOpenInvoiceDetails = (from customerInvoice in context.CustomerInvoices
                                              join customer in context.CustomerSetups
                                              on customerInvoice.CustomerName equals customer.CustomerName into cusSetUp
                                              from customerSetup in cusSetUp.DefaultIfEmpty()
                                              join customerAccount in context.CustomerAccounts
                                              on customerSetup.CustomerSetupId equals customerAccount.CustomerSetUpId into AccSetUp
                                              from Accounts in AccSetUp.DefaultIfEmpty()
                                              where customerInvoice.CustomerName.Contains(customerName)
                                              && customerInvoice.InvoiceStatus == status
                                              select new CustomerInvoiceListViewModel()
                                              {
                                                  SalesRep = customerInvoice.SalesRepName,
                                                  AccountNumber = customerInvoice.SapCustomerNumber,
                                                  CustomerNumber = customerInvoice.CustomerNumber,
                                                  CustomerName = customerInvoice.CustomerName,
                                                  InvoiceNumber = customerInvoice.InvoiceNumber,
                                                  ReferenceIdNumber = customerInvoice.RefKey3,
                                                  InvoiceDate = customerInvoice.InvoiceDate,
                                                  Current = customerInvoice.OpenBalance,
                                                  DueDate = customerInvoice.DueDate,
                                                  OriginalAmount = customerInvoice.InvoiceAmount,
                                                  InvoiceStatus = customerInvoice.InvoiceStatus,
                                                  DisputeCode = customerInvoice.ReasonCode,
                                                  StationName = Accounts.StationName
                                              }).ToList();
            }
            return customerOpenInvoiceDetails;
        }

        public static List<InsuranceClaimHistory> GetClaimHistoryOfCategoryDLSWSubmittedClaim()
        {
            List<InsuranceClaimHistory> insClaimHistory = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                insClaimHistory = (from HistoryDetails in context.InsuranceClaimHistories
                                   join categorydetails in context.Categories on HistoryDetails.CategoryId equals categorydetails.CategoryId
                                   where categorydetails.CategoryName.ToString() == "DLSW Submitted Claim"
                                   orderby HistoryDetails.ModifiedDate descending
                                   select HistoryDetails).ToList();

            }
            return insClaimHistory;
        }




        public static List<CustomerInvoiceListViewModel> GetInvoicesForDagrt(string dagrtNumber, string status)
        {
            List<CustomerInvoiceListViewModel> customerOpenInvoiceDetails = new List<CustomerInvoiceListViewModel>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerOpenInvoiceDetails = (from customerInvoice in context.CustomerInvoices
                                              join customer in context.CustomerSetups
                                              on customerInvoice.CustomerName equals customer.CustomerName into cusSetUp
                                              from customerSetup in cusSetUp.DefaultIfEmpty()
                                              join customerAccount in context.CustomerAccounts
                                              on customerSetup.CustomerSetupId equals customerAccount.CustomerSetUpId into AccSetUp
                                              from Accounts in AccSetUp.DefaultIfEmpty()
                                              where Accounts.DagrtNumber.Contains(dagrtNumber)
                                              && customerInvoice.InvoiceStatus == status
                                              select new CustomerInvoiceListViewModel()
                                              {
                                                  SalesRep = customerInvoice.SalesRepName,
                                                  AccountNumber = customerInvoice.SapCustomerNumber,
                                                  CustomerNumber = customerInvoice.CustomerNumber,
                                                  CustomerName = customerInvoice.CustomerName,
                                                  InvoiceNumber = customerInvoice.InvoiceNumber,
                                                  ReferenceIdNumber = customerInvoice.RefKey3,
                                                  InvoiceDate = customerInvoice.InvoiceDate,
                                                  Current = customerInvoice.OpenBalance,
                                                  DueDate = customerInvoice.DueDate,
                                                  OriginalAmount = customerInvoice.InvoiceAmount,
                                                  InvoiceStatus = customerInvoice.InvoiceStatus,
                                                  DisputeCode = customerInvoice.ReasonCode,
                                                  StationName = Accounts.StationName
                                              }).ToList();
            }
            return customerOpenInvoiceDetails;
        }

        public static List<CustomerInvoiceListViewModel> GetInvoicesForCustomerNumber(string CustomerNumber, string status)
        {
            List<CustomerInvoiceListViewModel> customerOpenInvoiceDetails = new List<CustomerInvoiceListViewModel>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerOpenInvoiceDetails = (from customerInvoice in context.CustomerInvoices
                                              join customer in context.CustomerSetups
                                              on customerInvoice.CustomerName equals customer.CustomerName into cusSetUp
                                              from customerSetup in cusSetUp.DefaultIfEmpty()
                                              join customerAccount in context.CustomerAccounts
                                              on customerSetup.CustomerSetupId equals customerAccount.CustomerSetUpId into AccSetUp
                                              from Accounts in AccSetUp.DefaultIfEmpty()
                                              where customerInvoice.CustomerNumber.Contains(CustomerNumber)
                                              && customerInvoice.InvoiceStatus == status
                                              select new CustomerInvoiceListViewModel()
                                              {
                                                  SalesRep = customerInvoice.SalesRepName,
                                                  AccountNumber = customerInvoice.SapCustomerNumber,
                                                  CustomerNumber = customerInvoice.CustomerNumber,
                                                  CustomerName = customerInvoice.CustomerName,
                                                  InvoiceNumber = customerInvoice.InvoiceNumber,
                                                  ReferenceIdNumber = customerInvoice.RefKey3,
                                                  InvoiceDate = customerInvoice.InvoiceDate,
                                                  Current = customerInvoice.OpenBalance,
                                                  DueDate = customerInvoice.DueDate,
                                                  OriginalAmount = customerInvoice.InvoiceAmount,
                                                  InvoiceStatus = customerInvoice.InvoiceStatus,
                                                  DisputeCode = customerInvoice.ReasonCode,
                                                  StationName = Accounts.StationName
                                              }).ToList();
            }
            return customerOpenInvoiceDetails;
        }

        public static List<CustomerInvoiceListViewModel> GetInvoicesForInvoiceNumber(string invoiceNumber, string status)
        {
            List<CustomerInvoiceListViewModel> customerOpenInvoiceDetails = new List<CustomerInvoiceListViewModel>();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerOpenInvoiceDetails = (from customerInvoice in context.CustomerInvoices

                                              join customer in context.CustomerSetups
                                              on customerInvoice.CustomerName equals customer.CustomerName into cusSetUp
                                              from customerSetup in cusSetUp.DefaultIfEmpty()
                                              join customerAccount in context.CustomerAccounts
                                              on customerSetup.CustomerSetupId equals customerAccount.CustomerSetUpId into AccSetUp
                                              from Accounts in AccSetUp.DefaultIfEmpty()
                                              where customerInvoice.InvoiceNumber.Contains(invoiceNumber) && customerInvoice.InvoiceStatus == status
                                              select new CustomerInvoiceListViewModel()
                                              {
                                                  SalesRep = customerInvoice.SalesRepName,
                                                  AccountNumber = customerInvoice.SapCustomerNumber,
                                                  CustomerNumber = customerInvoice.CustomerNumber,
                                                  CustomerName = customerInvoice.CustomerName,
                                                  InvoiceNumber = customerInvoice.InvoiceNumber,
                                                  ReferenceIdNumber = customerInvoice.RefKey3,
                                                  InvoiceDate = customerInvoice.InvoiceDate,
                                                  Current = customerInvoice.OpenBalance,
                                                  DueDate = customerInvoice.DueDate,
                                                  OriginalAmount = customerInvoice.InvoiceAmount,
                                                  InvoiceStatus = customerInvoice.InvoiceStatus,
                                                  DisputeCode = customerInvoice.ReasonCode,
                                                  StationName = Accounts.StationName
                                              }).ToList();
            }
            return customerOpenInvoiceDetails;
        }

        public static List<string> InvoiceCopydata()
        {
            List<string> categoryList = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                categoryList = (from category in context.Categories
                                where category.IsConfigurable == true
                                select category.CategoryName).ToList();
            }
            return categoryList;
        }

        public static List<InsuranceClaimViewModel> GetInsuranceClaimSavedCopy_val(int claimNumber)
        {
            List<InsuranceClaimViewModel> DBClaimVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                DBClaimVal = (from a in context.InsuranceClaimCopies
                              join b in context.InsuranceClaimCarrierCopies on a.ClaimNumber equals b.ClaimNumber
                              join c in context.InsuranceClaimShipperAddressCopies on a.ClaimNumber equals c.ClaimNumber
                              join d in context.InsuranceClaimConsigneeAddressCopies on a.ClaimNumber equals d.ClaimNumber
                              join e in context.InsuranceClaimPayableToCopies on a.ClaimNumber equals e.ClaimNumber
                              join f in context.InsuranceClaimItemsCopies on a.ClaimNumber equals f.ClaimNumber
                              join g in context.InsuranceClaimFreightCopies on a.ClaimNumber equals g.ClaimNumber
                              where a.ClaimNumber == claimNumber
                              select new InsuranceClaimViewModel
                              {
                                  DlswRefNumber = b.DlswRefNumber,
                                  ActualDeliveryDate = b.DeliveryDate.ToString(),
                                  CarrierName = b.CarrierName,
                                  CarrierProNumber = b.CarrierProNumber,
                                  ShipperName = c.Name,
                                  ShipperAddress = c.Address,
                                  ShipperAdd2 = c.Address2,
                                  ShipperZip = c.Zip,
                                  ShipperCountry = c.Country.CountryName,
                                  ShipperCity = c.CityName,
                                  ShipperState = c.StateName,
                                  ConsigneName = d.Name,
                                  ConsigneAddress = d.Address,
                                  ConsigneAdd2 = d.Address2,
                                  ConsigneZip = d.Zip,
                                  ConsigneCountry = d.Country.CountryName,
                                  ConsigneCity = d.CityName,
                                  ConsigneState = d.StateName,
                                  ClaimCompanyName = e.CompanyName,
                                  ClaimAddress = e.Address,
                                  ClaimAdd2 = e.Address2,
                                  ClaimZip = e.Zip,
                                  ClaimCity = e.CityName,
                                  ClaimCountry = e.Country.CountryName,
                                  ClaimContactName = e.ContactName,
                                  ClaimContactPhone = e.ContactPhone,
                                  ClaimContactEmail = e.ContactEmail,
                                  ClaimWebsite = e.CompanyWebsite,
                                  IsArticlesIns = a.IsArticlesInsured,
                                  InsuredValAmount = a.InsuredValueAmount,
                                  ClaimTypeId = f.InsuranceClaimTypeId,
                                  AritcleTypeId = f.InsuranceClaimArticleTypeId,
                                  ItemNum = f.ItemNumber,
                                  UnitVal = f.UnitValue,
                                  Quantity = f.Quantity,
                                  Weight = f.Weight,
                                  Description = f.description,
                                  OriginalFreightCharge = g.OriginalFreightChargesValue,
                                  ReturnFreightCharge = g.ReturnFreightChargesValue,
                                  ReplacementFreightCharge = g.ReplacementFreightChargesValue,
                                  ReturnDLSRefNum = g.ReturnFreightChargesDlswRefNumber,
                                  ReplaceDLSWRefNum = g.ReplacementFreightDlswRefNumber,
                                  Remarks = a.Remarks,
                                  CreatedBy = a.CreatedBy,
                                  FirstName = a.FirstName,
                                  LastName = a.LastName,
                                  ShipmentMode = a.ShipmentMode,
                              }).ToList();
            }
            return DBClaimVal;
        }

        public static int GetSecondLatestClaimNumber()
        {
            int ClaimNum = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                ClaimNum = (from cn in context.InsuranceClaims
                            orderby cn.CreateDateTime descending
                            select cn.ClaimNumber).Skip(1).First();
            }
            return ClaimNum;
        }

        public static List<FileInfo> GetMetaDateFile(string CLAIMNUMBER, string metaDataValue)
        {
            List<FileInfo> details = null;
            List<int> details1 = null;

            using (DocRepositoryEntities context = new DocRepositoryEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                details1 = (from value in context.AppMetaDataFileMappings
                            where value.MetaDataName == CLAIMNUMBER && value.MetaDataValue == metaDataValue
                            select value.FileInfoId).ToList();

                details = (from value in context.FileInfoes
                           where details1.Contains(value.FileInfoId)
                           select value).ToList();
            }

            return details;
        }





        public static List<string> GetAccessorialMGDescriptions(string accessorialName)
        {
            List<string> mgDescriptions = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                mgDescriptions = (from setup in context.AccessorialSetUps
                                  join description in context.AccessorialMGDescriptions
                                  on setup.AccessorialSetupId equals description.AccessorialSetupId
                                  where setup.AccessorialName == accessorialName
                                  select description.MGDescription).ToList();
            }

            return mgDescriptions;
        }

        public static List<ConfigureAccessorialViewModel> AccessorialList()
        {
            List<ConfigureAccessorialViewModel> accValue = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                accValue = (from accessorial in context.AccessorialSetUps

                            select new ConfigureAccessorialViewModel
                            {
                                AccessorialName = accessorial.AccessorialName,
                                AccessorialCode = accessorial.AccessorialCode,
                                MG_Description = accessorial.AccessorialMGDescriptions.Select(a => a.MGDescription).ToList(),
                                ShipmentServiceName = accessorial.AccessorialServiceTypeMappings.Select(a => a.ShipmentService.ShipmentService1).ToList(),
                                AccessorialDirectionName = accessorial.AccessorialDirection.Direction,

                            }).OrderBy(x => x.AccessorialName).ToList();
            }

            return accValue;
        }


        public static ConfigureAccessorialViewModel GetAccessorialDetails(string accessorial)
        {
            ConfigureAccessorialViewModel createdConfigureAccessorial = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                createdConfigureAccessorial = (from tempAccesorialSetup in context.AccessorialSetUps
                                               join tempAccessorialDirections in context.AccessorialDirections on tempAccesorialSetup.AccessorialDirectionId equals tempAccessorialDirections.AccessorialDirectionId
                                               into tbltempAccessorialDirections
                                               from tblfinalAccessorialDirections in tbltempAccessorialDirections.DefaultIfEmpty()
                                               join tempteAccessorialServiceTypeMappings in context.AccessorialServiceTypeMappings
                                               on tempAccesorialSetup.AccessorialSetupId equals tempteAccessorialServiceTypeMappings.AccessorialSetupId
                                               into tblAccessorialServiceTypeMappings
                                               from tblfinalAccessorialServiceTypeMappings in tblAccessorialServiceTypeMappings.DefaultIfEmpty()
                                               join tempShipemntService in context.ShipmentServices
                                               on tblfinalAccessorialServiceTypeMappings.ServiceId equals tempShipemntService.ServiceId
                                               into tblShipemntService
                                               join tempAccessorialMGDescriptions in context.AccessorialMGDescriptions
                                               on tempAccesorialSetup.AccessorialSetupId equals tempAccessorialMGDescriptions.AccessorialSetupId
                                               into tblAccessorialMGDescriptions
                                               where tempAccesorialSetup.AccessorialName == accessorial
                                               select new ConfigureAccessorialViewModel
                                               {
                                                   AccessorialDirectionName = tblfinalAccessorialDirections.Direction,
                                                   ShipmentServiceName = tblShipemntService.Select(m => m.ShipmentService1).ToList(),
                                                   MG_Description = tblAccessorialMGDescriptions.Select(n => n.MGDescription).ToList(),
                                                   AccessorialName = tempAccesorialSetup.AccessorialName,
                                                   AccessorialCode = tempAccesorialSetup.AccessorialCode
                                               }).FirstOrDefault();
            }
            return createdConfigureAccessorial;
        }

        public static Address GetShipFromAddressDetails(string customerName)
        {
            Address shipFromAddressDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == customerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();


                shipFromAddressDetails = (from address in context.Addresses
                                          where address.CustomerAccountId == accountID
                                          orderby address.CreatedDate descending
                                          select address).FirstOrDefault();
            }

            return shipFromAddressDetails;
        }

        public static Address GetShipToAddressDetails(string customerName)
        {
            Address shipToAddressDetails = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == customerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();


                shipToAddressDetails = (from address in context.Addresses
                                        where address.CustomerAccountId == accountID
                                        orderby address.CreatedDate descending
                                        select address).FirstOrDefault();
            }

            return shipToAddressDetails;
        }

        public static List<Address> CheckDuplicateAddressShipFrom(string customerName, string locationName, string address1, string address2,
            string zip, string city, string stateProvince, string contactName, string contactPhone, string contactPhoneExt,
            string contactEmail, string contactFax, string contactFaxExt, string comments)
        {
            List<Address> getShipFromAddresSVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == customerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();


                getShipFromAddresSVal = (from address in context.Addresses
                                         where address.CustomerAccountId == accountID && address.Name.ToString() == locationName
                                         && address.Address1.ToString() == address1 && address.Address2.ToString() == address2 && address.Zip.ToString() == zip
                                         && address.City.ToString() == city && address.State.ToString() == stateProvince && address.ContactName.ToString() == contactName
                                         && address.PhoneNumber == contactPhone && address.PhoneExt == contactPhoneExt && address.EmailId == contactEmail
                                         && address.FaxNumber.ToString() == contactFax && address.FaxExt.ToString() == contactFaxExt && address.Comment.ToString() == comments
                                         orderby address.CreatedDate descending
                                         select address).ToList();
            }
            return getShipFromAddresSVal;

        }

        public static List<Address> CheckDuplicateAddressShipTo(string customerName, string locationName, string address1, string address2,
            string zip, string city, string stateProvince, string contactName, string contactPhone, string contactPhoneExt,
            string contactEmail, string contactFax, string contactFaxExt, string comments)
        {
            List<Address> getShipToAddresSVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                int accountID = (from cs in context.CustomerSetups
                                 join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                 where cs.CustomerName.ToUpper() == customerName.ToUpper()
                                 select ca.CustomerAccountId).FirstOrDefault();


                getShipToAddresSVal = (from address in context.Addresses
                                       where address.CustomerAccountId == accountID && address.Name == locationName
                                       && address.Address1 == address1 && address.Address2 == address2 && address.Zip == zip
                                       && address.City == city && address.State == stateProvince && address.ContactName == contactName
                                       && address.PhoneNumber == contactPhone && address.EmailId == contactEmail
                                       && address.FaxNumber == contactFax && address.FaxExt == contactFaxExt && address.Comment == comments
                                       orderby address.CreatedDate descending
                                       select address).ToList();
            }
            return getShipToAddresSVal;

        }
        public static CustomerInvoice GetCustomerInvoiceDetails(string invoiceNumber)
        {
            CustomerInvoice customerInvoiceDetails = new CustomerInvoice();

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");

                customerInvoiceDetails = (from a in context.CustomerInvoices
                                          where a.InvoiceNumber == invoiceNumber
                                          select a).FirstOrDefault();
            }

            return customerInvoiceDetails;
        }

        public static int PendingCSRCount(string userName)
        {
            int CSRcount = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                List<int> Status = (from account in context.CsrCustomerAccounts
                                    where account.SalesRep == userName
                                    select account.CsrSetup.StatusId).ToList();

                // Dictionary<int, string> csrnameAndStatus = new Dictionary<int, string>();
                CSRcount = (from abc in Status
                            where abc == 1
                            select abc).Count();
            }

            return CSRcount;
        }

        public static int InProgressCSRCount(string userName)
        {
            int CSRcount = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                List<int> Status = (from account in context.CsrCustomerAccounts
                                    where account.SalesRep == userName
                                    select account.CsrSetup.StatusId).ToList();


                CSRcount = (from abc in Status
                            where abc == 2 || abc == 3 || abc == 6 || abc == 7 || abc == 8
                            select abc).Count();
            }

            return CSRcount;
        }

        public static int DeniedCSRCount(string userName)
        {
            int CSRcount = 0;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                List<int> Status = (from account in context.CsrCustomerAccounts
                                    where account.SalesRep == userName
                                    select account.CsrSetup.StatusId).ToList();


                CSRcount = (from abc in Status
                            where abc == 5
                            select abc).Count();
            }

            return CSRcount;
        }

        public static List<TimeSpan> GetShippingHoursForCustomer(string customerName)
        {
            List<TimeSpan> customerShippingHour = new List<TimeSpan>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                var customerShippingHours = (from ca in context.CustomerAccounts
                                             where ca.CustomerSetup.CustomerName == customerName
                                             select new
                                             {
                                                 ShippingOpenHours = ca.ShippingOpenTime,
                                                 ShippingCloseHours = ca.ShippingCloseTime
                                             }).FirstOrDefault();
                customerShippingHour.Add(customerShippingHours.ShippingOpenHours);
                customerShippingHour.Add(customerShippingHours.ShippingCloseHours);

            }

            return customerShippingHour;
        }

        public static List<TimeSpan> GetShippingHoursForSavedAddress(int addressID, string customerName)
        {
            List<TimeSpan> savedAddressShippingHour = new List<TimeSpan>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                var addressShippingHours = (from address in context.Addresses
                                            where address.AddressId == addressID && address.CustomerAccount.CustomerSetup.CustomerName == customerName
                                            select new
                                            {
                                                ShippingOpenHours = address.ShippingOpenTime,
                                                ShippingCloseHours = address.ShippingCloseTime
                                            }).FirstOrDefault();

                savedAddressShippingHour.Add(addressShippingHours.ShippingOpenHours);
                savedAddressShippingHour.Add(addressShippingHours.ShippingCloseHours);
            }

            return savedAddressShippingHour;
        }

        public static List<TimeSpan> GetShippingHoursForDefaultShipperAddress(string customerName)
        {
            List<TimeSpan> defaultAddressShippingHour = new List<TimeSpan>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                var addressShippingHours = (from address in context.Addresses
                                            where address.AddressTypeId == 3 && address.CustomerAccount.CustomerSetup.CustomerName == customerName
                                            select new
                                            {
                                                ShippingOpenHours = address.ShippingOpenTime,
                                                ShippingCloseHours = address.ShippingCloseTime
                                            }).FirstOrDefault();

                defaultAddressShippingHour.Add(addressShippingHours.ShippingOpenHours);
                defaultAddressShippingHour.Add(addressShippingHours.ShippingCloseHours);
            }

            return defaultAddressShippingHour;
        }

        public static AccessorialMGDescription GetMGDescriptionData(string accessorialCode)
        {
            AccessorialMGDescription mgDescriptionTableData = null;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                mgDescriptionTableData = (from data in context.AccessorialMGDescriptions
                                          join value in context.AccessorialSetUps on data.AccessorialSetupId equals value.AccessorialSetupId
                                          where value.AccessorialCode == accessorialCode
                                          select data).FirstOrDefault();
            }

            return mgDescriptionTableData;
        }
        public static List<string> GetCustomerShippingReferencedata(string customer)
        {
            List<string> customerRef = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                customerRef = (from data in context.ReferenceTypeValues
                               join value in context.CustomerShippingReferences on data.ReferenceTypeValueId equals value.ReferenceTypeValueId
                               join test in context.CustomerSetups on value.CustomerSetUpId equals test.CustomerSetupId
                               where test.CustomerName == customer && test.IsActive == true
                               select data.ReferenceValue).ToList();


            }
            return customerRef;
        }


        public static Address GetShippingToData(int accountNumber)
        {
            Address shippingToInfos = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                shippingToInfos = (from data in context.Addresses
                                   where data.CustomerAccountId == accountNumber
                                   where data.AddressTypeId == 4
                                   select data).First();
            }
            return shippingToInfos;
        }

        public static Address GetShippingFromData(int accountNumber)
        {
            Address shippingFromInfos = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                shippingFromInfos = (from data in context.Addresses
                                     where data.CustomerAccountId == accountNumber
                                     where data.AddressTypeId == 3
                                     select data).First();
            }
            return shippingFromInfos;
        }


        public static List<string> GetAllCustomerofShippingReference()
        {
            List<string> allcustomer = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                allcustomer = (from data in context.CustomerSetups
                               join value in context.CustomerShippingReferences on data.CustomerSetupId equals value.CustomerSetUpId
                               where data.IsActive == true
                               select data.CustomerName).ToList();
            }
            return allcustomer;
        }

        public static string GetContactPhoneOnAvailableLoadPage(string carrierSCAC)
        {
            string contactPhone = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                contactPhone = (from a in context.CustomerAccounts
                                where a.AvailableLoadScac == carrierSCAC
                                select a.AvailableLoadPhone).FirstOrDefault();
            }

            return contactPhone;
        }

        public static bool GetCreditHoldCustomerDetails(string customerName)
        {
            bool customerOnCreditHold;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                customerOnCreditHold = (from cs in context.CustomerSetups
                                        join ca in context.CustomerAccounts on cs.CustomerSetupId equals ca.CustomerSetUpId
                                        where cs.CustomerName.ToUpper() == customerName.ToUpper()
                                        select ca.IsCreditHold).FirstOrDefault();
            }

            return customerOnCreditHold;
        }

        public static string GetToEmail(string carrierSCAC)
        {
            string emailTo = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                emailTo = (from a in context.CustomerAccounts
                           where a.AvailableLoadScac == carrierSCAC
                           select a.AvailableLoadEmail).FirstOrDefault();
            }

            return emailTo;
        }

        public static string GetCustomerNameForTheClaimNumber(int claimnumber)
        {
            string customerName = string.Empty;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                customerName = (from _customerAccount in context.CustomerSetups
                                join a in context.InsuranceClaims on _customerAccount.CustomerSetupId equals a.CustomerSetUpId
                                where a.ClaimNumber == claimnumber && _customerAccount.IsActive == true
                                select _customerAccount.CustomerName).FirstOrDefault();
            }
            return customerName;
        }

        public static InsuranceClaimViewModel GetInsuranceClaimValues(int ClaimNum)
        {
            InsuranceClaimViewModel DBClaimVal = null;
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                DBClaimVal = (from claim in context.InsuranceClaims
                              join carrierClaim in context.InsuranceClaimCarriers
                              on claim.ClaimNumber equals carrierClaim.ClaimNumber
                              into Insclaimcarrier
                              from dataClaimCarrier in Insclaimcarrier.DefaultIfEmpty()

                              join claimPayable in context.InsuranceClaimPayableToes
                              on claim.ClaimNumber equals claimPayable.ClaimNumber
                              into InsclaimPayableTo
                              from dataclaimPayableTo in InsclaimPayableTo.DefaultIfEmpty()

                              join shipperAddress in context.InsuranceClaimShipperAddresses
                              on claim.ClaimNumber equals shipperAddress.ClaimNumber
                              into InsshipperAddress
                              from datashipperAddress in InsshipperAddress.DefaultIfEmpty()

                              join consigneeAddress in context.InsuranceClaimConsigneeAddresses
                              on claim.ClaimNumber equals consigneeAddress.ClaimNumber
                              into InsconsigneeAddress
                              from dataconsigneeAddress in InsconsigneeAddress.DefaultIfEmpty()

                              join claimItem in context.InsuranceClaimItems
                              on claim.ClaimNumber equals claimItem.ClaimNumber
                              into InsClaimItem
                              from dataClaimItem in InsClaimItem.DefaultIfEmpty()

                              join claimFreight in context.InsuranceClaimFreights
                              on claim.ClaimNumber equals claimFreight.ClaimNumber
                              into InsClaimFreight
                              from dataClaimFreight in InsClaimFreight.DefaultIfEmpty()

                              where claim.ClaimNumber == ClaimNum
                              select new InsuranceClaimViewModel
                              {

                                  DlswRefNumber = dataClaimCarrier.DlswRefNumber,
                                  ShipDate = dataClaimCarrier.DlswShipDate.ToString(),
                                  CarrierName = dataClaimCarrier.CarrierName,
                                  CarrierProNumber = dataClaimCarrier.CarrierProNumber,
                                  CarriePRODate = dataClaimCarrier.CarrierProDate.ToString(),

                                  ShipperName = datashipperAddress.Name,
                                  ShipperAddress = datashipperAddress.Address,
                                  ShipperAdd2 = datashipperAddress.Address2,
                                  ShipperZip = datashipperAddress.Zip,
                                  ShipperCountry = datashipperAddress.Country.CountryName,
                                  ShipperCity = datashipperAddress.CityName,
                                  ShipperState = datashipperAddress.StateName,

                                  ConsigneName = dataconsigneeAddress.Name,
                                  ConsigneAddress = dataconsigneeAddress.Address,
                                  ConsigneAdd2 = dataconsigneeAddress.Address2,
                                  ConsigneZip = dataconsigneeAddress.Zip,
                                  ConsigneCountry = dataconsigneeAddress.Country.CountryName,
                                  ConsigneCity = dataconsigneeAddress.CityName,
                                  ConsigneState = dataconsigneeAddress.StateName,

                                  ClaimCompanyName = dataclaimPayableTo.CompanyName,
                                  ClaimAddress = dataclaimPayableTo.Address,
                                  ClaimAdd2 = dataclaimPayableTo.Address2,
                                  ClaimZip = dataclaimPayableTo.Zip,
                                  ClaimCity = dataclaimPayableTo.CityName,
                                  ClaimCountry = dataclaimPayableTo.Country.CountryName,
                                  ClaimState = dataclaimPayableTo.StateName,
                                  ClaimContactName = dataclaimPayableTo.ContactName,
                                  ClaimContactPhone = dataclaimPayableTo.ContactPhone,
                                  ClaimContactEmail = dataclaimPayableTo.ContactEmail,
                                  Quantity = dataClaimItem.Quantity,
                                  Description = dataClaimItem.description,
                                  Weight = dataClaimItem.Weight,
                                  UnitVal = dataClaimItem.UnitValue,
                                  ClaimWebsite = dataclaimPayableTo.CompanyWebsite,

                                  IsArticlesIns = claim.IsArticlesInsured,
                                  InsuredValAmount = claim.InsuredValueAmount,
                                  Remarks = claim.Remarks,
                                  CustomerClaimReferenceNumber = claim.CustomerClaimReferenceNumber,

                                  InsuranceclaimItem = claim.InsuranceClaimItems.Select(a => new InsuranceClaimItems
                                  {

                                      claimTypeId = a.InsuranceClaimTypeId,
                                      aritcleTypeId = a.InsuranceClaimArticleTypeId,
                                      itemNum = a.ItemNumber,
                                      unitVal = a.UnitValue,
                                      quantity = a.Quantity,
                                      weight = a.Weight,
                                      description = a.description,
                                  }).ToList(),
                                  IsOriginalFreightCharge = dataClaimFreight.IsOriginalFreightCharges,
                                  OriginalFreightCharge = dataClaimFreight.OriginalFreightChargesValue,
                                  IsReturnFreightCharge = dataClaimFreight.IsReturnFreightCharges,
                                  ReturnFreightCharge = dataClaimFreight.ReturnFreightChargesValue,
                                  ReturnDLSRefNum = dataClaimFreight.ReturnFreightChargesDlswRefNumber,
                                  IsReplacementFreightCharge = dataClaimFreight.IsReplacementFreightCharges,
                                  ReplacementFreightCharge = dataClaimFreight.ReplacementFreightChargesValue,
                                  ReplaceDLSWRefNum = dataClaimFreight.ReplacementFreightDlswRefNumber,
                              }).FirstOrDefault();
            }
            return DBClaimVal;
        }

        public static void SetGainsharePercentage(int customerAccountId)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                GainsharePricingModel gainsharePricingModel = context.GainsharePricingModels.FirstOrDefault(x => x.CustomerAccountId == customerAccountId);
                gainsharePricingModel.Percentage = "50.00";
                context.SaveChanges();
            }
        }

        public static void RevertCsrAuditInfoForUser(string customerAccountName)
        {
            int customerSetupId = DBHelper.GetCustomerSetupId(customerAccountName);
            int customerAccountId = DBHelper.GetCustomerAccountId(customerSetupId);

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                List<CustomerRatingLogicAudit> customerRatingLogicAudit = context.CustomerRatingLogicAudits.Where(x => x.CustomerAccountId == customerAccountId).ToList();
                context.CustomerRatingLogicAudits.RemoveRange(customerRatingLogicAudit);

                context.SaveChanges();
            }
        }

        public static void DeleteDefaultCorporateAccessorials()
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                List<DefaultAccessorialSetup> defaultCorporateAccessorials = context.DefaultAccessorialSetups.Where(x => x.StationId == null).ToList();
                context.DefaultAccessorialSetups.RemoveRange(defaultCorporateAccessorials);

                context.SaveChanges();
            }
        }

        public static void InsertDefaultAccessorials(List<DefaultAccessorialSetup> defaultAccessorials)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                context.DefaultAccessorialSetups.AddRange(defaultAccessorials);

                context.SaveChanges();
            }
        }

        public static void DeleteDefaultStationAccessorials(string stationId)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                List<DefaultAccessorialSetup> defaultCorporateAccessorials = context.DefaultAccessorialSetups.Where(x => x.StationId == stationId).ToList();
                context.DefaultAccessorialSetups.RemoveRange(defaultCorporateAccessorials);

                context.SaveChanges();
            }
        }

        public static void AddCustomReportToDb(CustomReport report)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                context.CustomReports.Add(report);
                context.SaveChanges();
            }
        }

        public static int GetCustomReportId(string createdBy, string reportName)
        {
            int reportId = 0;

            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                reportId = (from report in context.CustomReports
                            where report.CustomReportName == reportName
                            && report.CreatedBy == createdBy
                            select report.CustomReportId).FirstOrDefault();
            }

            return reportId;
        }

        public static void AddUserCustomReportsMappingToDB(UserCustomReportsMapping userCustomReportMapping)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");
                context.UserCustomReportsMappings.Add(userCustomReportMapping);
                context.SaveChanges();
            }
        }

        public static void RemoveCustomReportsFromDB(string reportName)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;");

                List<CustomReport> customReports = context.CustomReports.Where(x => x.CustomReportName == reportName).ToList();
                List<int> reportIds = new List<int>();

                foreach (CustomReport reports in customReports)
                {
                    reportIds.Add(reports.CustomReportId);
                }

                List<CustomReportServicesMapping> reportServiceMapping = new List<CustomReportServicesMapping>();
                foreach (int id in reportIds)
                {
                    reportServiceMapping.AddRange(context.CustomReportServicesMappings.Where(x => x.CustomReportId == id).ToList());
                }
                context.CustomReportServicesMappings.RemoveRange(reportServiceMapping);

                List<CustomReport> report = context.CustomReports.Where(x => x.CustomReportName == reportName).ToList();
                context.CustomReports.RemoveRange(report);
                context.SaveChanges();
            }
        }

        public static void RemoveUserCustomReportMappingFromDB(string reportName)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                List<CustomReport> customReports = context.CustomReports.Where(x => x.CustomReportName == reportName).ToList();
                List<int> reportIds = new List<int>();

                foreach(CustomReport report in customReports)
                {
                    reportIds.Add(report.CustomReportId);
                }
                List<UserCustomReportsMapping> reportsMapping = new List<UserCustomReportsMapping>();
                foreach (int id in reportIds)
                {
                    reportsMapping.AddRange(context.UserCustomReportsMappings.Where(x => x.CustomReportId == id).ToList());
                }
                context.UserCustomReportsMappings.RemoveRange(reportsMapping);
                context.SaveChanges();
            }
        }

        public static List<string> GetAllAccountsUnderPrimaryAccount(string primaryAccount)
        {
            List<string> subAccounts = new List<string>();
            List<string> additionalAccounts = new List<string>();
            List<int> primaryAccountId = new List<int>();
            using (WWProxyEntities context = new WWProxyEntities())
            {
                primaryAccountId = (from ca in context.CustomerAccounts
                                        where ca.CustomerSetup.CustomerName.Equals(primaryAccount)
                                        select ca.CustomerAccountId).ToList();
            }
            subAccounts.AddRange(CustomerNameOfSubAccountUnderPrimaryAccount(primaryAccountId));
            foreach (string subAccount in subAccounts)
            {
                additionalAccounts.AddRange(GetAllAccountsUnderPrimaryAccount(subAccount));
            }
            subAccounts.AddRange(additionalAccounts);


            return subAccounts;
        }

        public static void UpdateClaimStatusAsSubmitted(int claimnumber)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                InsuranceClaim _claimNumber = (from a in context.InsuranceClaims
                                               where a.ClaimNumber == claimnumber
                                               select a).FirstOrDefault();

                if (_claimNumber != null)
                {

                    _claimNumber.InsuranceClaimStatusId = 4;
                }

                context.SaveChanges();

            }
        }

        public static void updateClaimStatusAsAmend(int claimnumber)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                InsuranceClaim _claimNumber = (from a in context.InsuranceClaims
                                               where a.ClaimNumber == claimnumber
                                               select a).FirstOrDefault();

                if (_claimNumber != null)
                {

                    _claimNumber.InsuranceClaimStatusId = 6;
                }

                context.SaveChanges();

            }
        }

        public static void UpdateCustomerClaimReferenceValueByClaimNumber(int claimNumber, string customerClaimReferenceNumber)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                InsuranceClaim insuranceClaim = (from claim in context.InsuranceClaims
                                                 where claim.ClaimNumber == claimNumber
                                                 select claim).FirstOrDefault();

                if(insuranceClaim != null)
                {
                    insuranceClaim.CustomerClaimReferenceNumber = customerClaimReferenceNumber;
                }
                context.SaveChanges();
            }
        }

        public static void UpdatingOriginalstatusOfClaim(int claimnumber, int originalclaimstatusid)
        {
            using (WWProxyEntities context = new WWProxyEntities())
            {
                context.Database.ExecuteSqlCommand("SET TRANSACTION ISOLATION LEVEL READ COMMITTED;");
                InsuranceClaim _claimNumber = (from a in context.InsuranceClaims
                                               where a.ClaimNumber == claimnumber
                                               select a).FirstOrDefault();

                if (_claimNumber != null)
                {

                    _claimNumber.InsuranceClaimStatusId = originalclaimstatusid;
                }

                context.SaveChanges();

            }
        }
    }
}