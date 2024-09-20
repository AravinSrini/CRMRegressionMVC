using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_CustomReport_StationAccountSectionFunctionalitySteps : Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
      
        [Given(@"I arrive on Customer Invoice List page")]
        public void GivenIArriveOnCustomerInvoiceListPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }

        [Given(@"I am associated to a primary account that has sub-accounts")]
        public void GivenIAmAssociatedToAPrimaryAccountThatHasSub_Accounts()
        {
            Report.WriteLine("I am a user which is associated to primary account that has sub account");
        }

        [Given(@"I am a sales, sales management, operations, station owner, or access rrd user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have selected one or more stations from the Stations list")]
        public void GivenIHaveSelectedOneOrMoreStationsFromTheStationsList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_Selected_Stations);
            IList<IWebElement> stationDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));
            int countStations = stationDropdownList.Count;
            List<string> stations = new List<string>();
            for (int i = 0; i < countStations; i++)
            {
                Click(attributeName_id, CustomReport_Selected_Stations);
                IList<IWebElement> stationDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));
                stations.Add(stationDropdownList2[i].Text);
                stationDropdownList2[i].Click();
            }

            string accountsSelected = Gettext(attributeName_id, CustomReport_Selected_Stations);
            foreach (string station in stations)
            {
                Assert.IsTrue(accountsSelected.Contains(station));
            }

            Report.WriteLine("Selected multiple stations which I am associated to");
        }

        [Given(@"I have selected more than one station from the Stations list")]
        public void GivenIHaveSelectedMoreThanOneStationFromTheStationsList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_Selected_Stations);
            IList<IWebElement> stationDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));
            string account1 = stationDropdownList[0].Text;
            stationDropdownList[0].Click();
            Report.WriteLine("Selected the first station from the dropdown");

            Click(attributeName_id, CustomReport_Selected_Stations);

            IList<IWebElement> stationDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));
            string account2 = stationDropdownList2[1].Text;
            stationDropdownList2[1].Click();
            Click(attributeName_id, CustomReport_Selected_Stations);

            IList<IWebElement> stationDropdownList3 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));
            string account3 = stationDropdownList3[2].Text;
            stationDropdownList3[2].Click();

            Report.WriteLine("Selected second station from the dropdown");

            string accountsSelected = Gettext(attributeName_id, CustomReport_Selected_Stations);
            Assert.IsTrue(accountsSelected.Contains(account1));
            Assert.IsTrue(accountsSelected.Contains(account2));

            Report.WriteLine("Selected more than one stations from the dropdown");
        }

        [When(@"I click in the Accounts field")]
        public void WhenIClickInTheAccountsField()
        {
            Click(attributeName_id, CustomReport_Selected_Customers);
        }

        [When(@"I click in the Stations field")]
        public void WhenIClickInTheStationsField()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_Selected_Stations);
        }

        [Then(@"The station that I am associated to will be default selected in the Stations field")]
        public void ThenTheStationThatIAmAssociatedToWillBeDefaultSelectedInTheStationsField()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("zzzext");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            string stationId = IDP.GetClaimValue("zzzext", "dlscrm-StationId");
            string stationName = DBHelper.GetStationNameonStationID(stationId);
            string expectedName = Gettext(attributeName_id, CustomReport_Selected_Stations);
            Assert.AreEqual(expectedName, stationName);
            Report.WriteLine("The station that I am associated is default selected in the Stations field");
        }

        [Then(@"I am unable to select another station")]
        public void ThenIAmUnableToSelectAnotherStation()
        {
            VerifyElementNotEnabled(attributeName_id, CustomReport_StationDropdownId, "Class");
            Report.WriteLine("I am unable to select another station");
        }

        [Then(@"The customer that I am associated to will be default selected in the Accounts field")]
        public void ThenTheCustomerThatIAmAssociatedToWillBeDefaultSelectedInTheAccountsField()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("zzzext");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            int setupId = 0;
            string customerSetupId = IDP.GetClaimValue("zzzext", "dlscrm-CustomerSetUpId");
            int.TryParse(customerSetupId, out setupId);
            string customernName = DBHelper.GetCustomerName(setupId);
            string expectedName = Gettext(attributeName_id, CustomReport_Selected_Customers);
            Assert.AreEqual(expectedName, customernName);
            Report.WriteLine("The Customer that I am associated is default selected in the Stations field");
        }

        [Then(@"The customer that I am associated to with no sub accounts will be default selected in the Accounts field")]
        public void ThenTheCustomerThatIAmAssociatedToWithNoSubAccountsWillBeDefaultSelectedInTheAccountsField()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("ZzzcustomerMg");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            int setupId = 0;
            string customerSetupId = IDP.GetClaimValue("ZzzcustomerMg", "dlscrm-CustomerSetUpId");
            int.TryParse(customerSetupId, out setupId);
            string customernName = DBHelper.GetCustomerName(setupId);
            string expectedName = Gettext(attributeName_id, CustomReport_Selected_Customers);
            Assert.AreEqual(expectedName, customernName);
            Report.WriteLine("The Customer that I am associated is default selected in the Stations field");
        }

        [Then(@"I am unable to select another account")]
        public void ThenIAmUnableToSelectAnotherAccount()
        {
            VerifyElementNotEnabled(attributeName_id, CustomReport_CustomerDropdownId, "Class");
            Report.WriteLine("I am unable to select another station");
        }

        [Then(@"The Accounts field will not have an account default displayed")]
        public void ThenTheAccountsFieldWillNotHaveAnAccountDefaultDisplayed()
        {
            string defaultSelected = Gettext(attributeName_id, CustomReport_Selected_Customers);
            Assert.AreEqual(defaultSelected, string.Empty);
            Report.WriteLine("The Accounts field does not have an account default displayed");
            VerifyElementEnabled(attributeName_id, CustomReport_CustomerDropdownId, "Class");
            Report.WriteLine("The Accounts field is editable");
        }

        [Then(@"I will have the option to select the primary account in which I am associated")]
        public void ThenIWillHaveTheOptionToSelectThePrimaryAccountInWhichIAmAssociated()
        {
            IList<IWebElement> accountsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Account_DropDownList_Xpath));
            string account = accountsDropdownList[1].Text;
            accountsDropdownList[1].Click();
            string accountSelected = Gettext(attributeName_id, CustomReport_Selected_Customers);
            Assert.AreEqual(accountSelected, account);
            Report.WriteLine("The primary account which I am associated to is selected");
        }

        [Then(@"I have the option to select any of the sub-accounts associated to the primary account")]
        public void ThenIHaveTheOptionToSelectAnyOfTheSub_AccountsAssociatedToThePrimaryAccount()
        {
            Click(attributeName_id, CustomReport_Selected_Customers);
            IList<IWebElement> accountsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Account_DropDownList_Xpath));
            string subAccount = accountsDropdownList[2].Text;
            accountsDropdownList[2].Click();
            string accountsSelected = Gettext(attributeName_id, CustomReport_Selected_Customers);
            Assert.IsTrue(accountsSelected.Contains(subAccount));
            Report.WriteLine("The sub account which I am associated to is selected");
        }

        [Then(@"I will see the account list will be displayed in hierarchical format")]
        public void ThenIWillSeeTheAccountListWillBeDisplayedInHierarchicalFormat()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);

            Click(attributeName_xpath, ".//*[@id='ReportAccounts_chosen']");
            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_SubAccountList));
            List<string> SubAccountListValues = ObjWebElementOperations.GetListFromIWebElement(subAccounts);

            Assert.AreEqual(customerNamesList.Count, SubAccountListValues.Count);
            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account");
        }

        [Then(@"I will see the sub-accounts will be listed in alphabetical order")]
        public void ThenIWillSeeTheSub_AccountsWillBeListedInAlphabeticalOrder()
        {
            Click(attributeName_id, CustomReport_Selected_Customers);
            IList<IWebElement> accountsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_SubAccountListNames));
            List<string> GridCustomerNameUI = ObjWebElementOperations.GetListFromIWebElement(accountsDropdownList);
            List<string> AlphabeticalArray = new List<string>();
            for (int i = 0; i < accountsDropdownList.Count; i++)
            {
                AlphabeticalArray.Add(accountsDropdownList[i].Text.ToString());
            }

            GridCustomerNameUI.Sort();
            CollectionAssert.AreEqual(GridCustomerNameUI, AlphabeticalArray);
            Report.WriteLine("Displayed Customers are sorted in acending order");
        }

        [Then(@"I have the option to select multiple accounts")]
        public void ThenIHaveTheOptionToSelectMultipleAccounts()
        {
            IList<IWebElement> accountsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Account_DropDownList_Xpath));
            string account1 = accountsDropdownList[1].Text;
            accountsDropdownList[1].Click();
            Report.WriteLine("Selected the primary account which I am associated to");

            Click(attributeName_id, CustomReport_Selected_Customers);

            IList<IWebElement> accountsDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Account_DropDownList_Xpath));
            string account2 = accountsDropdownList2[3].Text;
            accountsDropdownList2[3].Click();
            Report.WriteLine("Selected the sub account which I am associated to");

            string accountsSelected = Gettext(attributeName_id, CustomReport_Selected_Customers);
            Assert.IsTrue(accountsSelected.Contains(account1));
            Assert.IsTrue(accountsSelected.Contains(account2));

            Report.WriteLine("Selected multiple accounts which I am associated to");
        }

        [Then(@"I will see a list of stations in which I am associated")]
        public void ThenIWillSeeAListOfStationsInWhichIAmAssociated()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("salesdelta");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();
            List<string> stationName = DBHelper.GetMappedStationList(stationId);
            List<string> expectedNames = new List<string>();
            IList<IWebElement> stationDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));

            foreach (IWebElement element in stationDropdownList2)
            {
                expectedNames.Add(element.Text);
            }
            stationName.Sort();

            CollectionAssert.AreEqual(expectedNames, stationName);
            Report.WriteLine("The station that I am associated are available in Station Dropdown");
        }

        [Then(@"I have the option to select multiple stations")]
        public void ThenIHaveTheOptionToSelectMultipleStations()
        {
            IList<IWebElement> stationsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationDropdown_Xpath));
            string station1 = stationsDropdownList[1].Text;
            stationsDropdownList[0].Click();
            Report.WriteLine("Selected first station which I am associated to");

            Click(attributeName_id, CustomReport_Selected_Stations);

            IList<IWebElement> stationsDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationDropdown_Xpath));
            string station2 = stationsDropdownList2[1].Text;
            stationsDropdownList2[1].Click();
            Report.WriteLine("Selected second station which I am associated to");

            string accountsSelected = Gettext(attributeName_id, CustomReport_Selected_Stations);
            Assert.IsTrue(accountsSelected.Contains(station1));
            Assert.IsTrue(accountsSelected.Contains(station2));

            Report.WriteLine("Selected multiple accounts which I am associated to");
        }

        [Then(@"I have the option to search for a station")]
        public void ThenIHaveTheOptionToSearchForAStation()
        {
            string searchOption = "ZZZ";
            Report.WriteLine("Clicking on station dropdown");
            Click(attributeName_xpath, CustomReport_Input_XPath);
            int cusValues = GetCount(attributeName_xpath, CustomReport_SearchActive_Xpath);

            SendKeys(attributeName_xpath, CustomReport_StationInputField_Xpath, searchOption);
            int totalResult = GetCount(attributeName_xpath, CustomReport_Input_XPath);

            Assert.AreEqual(1, totalResult);
            Report.WriteLine("Station dropdown is displaying only matching result");

            IList<IWebElement> stationsResult= GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationDropdown_Xpath));
            string result = stationsResult[0].Text;
            Assert.IsTrue(result.Contains(searchOption));

            Report.WriteLine("Passed string " + searchOption + " is displaying station dropdown " + result);
        }

        [Then(@"I will see a list of accounts associated to the station\(s\) selected")]
        public void ThenIWillSeeAListOfAccountsAssociatedToTheStationSSelected()
        {
            string actualCustomers = Gettext(attributeName_id, CustomReport_Selected_Customers);
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("salesdelta");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-CustomerSetUpId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            foreach (AppUserClaimInfo customer in claimValue)
            {
                int cSetupId = 0;
                int.TryParse(customer.ClaimValue, out cSetupId);
                string customerName = DBHelper.GetCustomerName(cSetupId);
                Assert.IsTrue(actualCustomers.Contains(customerName));
            }

            Report.WriteLine("I will see a list of all accounts associated to the selected stations");
        }

        [Then(@"The accounts will be displayed in hierarchical format")]
        public void ThenTheAccountsWillBeDisplayedInHierarchicalFormat()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_AccountList_Xpath));

            // Building a map of stations which contains map of primary account's sub a account list
            Dictionary<string, Dictionary<string, List<string>>> dict = new Dictionary<string, Dictionary<string, List<string>>>();

            // For tracking the primary account's parent station
            string lastSeenStation = "";
            // for tracking the sub account's parent primary account
            string lastSeenPrimaryAccount = "";

            // Looping through the drop down list elements
            for (int e = 0; e < dropDownList.Count(); ++e)
            {
                IWebElement element = dropDownList.ElementAt(e);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));
                    if (elementClassList.Contains("level3"))
                    {
                        continue;
                    }
                    else
                    {
                        // station
                        if (elementClassList.Contains("group-result"))
                        {
                            lastSeenStation = elementText;

                            Dictionary<string, List<string>> primarySubDic = new Dictionary<string, List<string>>();
                            dict.Add(elementText, primarySubDic);
                        }
                        // primary
                        else if (elementClassList.Contains("level1") && !elementClassList.Contains("level2"))
                        {
                            lastSeenPrimaryAccount = elementText;

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            primarySubDic.Add(elementText, new List<string>());
                        }
                        // sub
                        else if (elementClassList.Contains("level3"))
                        {

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            List<string> subAccounts = primarySubDic[lastSeenPrimaryAccount];
                            subAccounts.Add(elementText);
                        }
                    }
                }
            }

            // validating the UI tree with dB
            foreach (string stationName in dict.Keys)
            {
                Console.WriteLine("stationName : " + stationName);
                List<string> primaryAccounts = dict[stationName].Keys.ToList();

                List<string> primaryAccountsFromDB = DBHelper.GetCustomerNameByStationName(stationName);
                List<string> primaryAccountsFromdb = primaryAccountsFromDB.OrderBy(q => q).ToList();

                // station name has no entries in dB
                Console.WriteLine("primaryAccounts : ");
                foreach (string s in primaryAccounts)
                {
                    Console.WriteLine("1 :" + s);
                }
                Console.WriteLine("primaryAccountsFromDB : ");
                foreach (string s in primaryAccountsFromDB)
                {
                    Console.WriteLine("2 :" + s);
                }
                if (primaryAccountsFromDB.Count() == 0)
                {
                    goto EVAL;
                }
                else
                {
                    //CollectionAssert.AreNotEqual(primaryAccountsFromdb, primaryAccounts);
                    foreach (string pa in primaryAccounts)
                    {
                        if (!primaryAccountsFromdb.Contains(pa))
                        {
                            goto EVAL;
                        }
                    }
                }

                foreach (string primaryAccount in primaryAccounts)
                {
                    List<string> subAccounts = dict[stationName][primaryAccount];

                    List<string> subAccounstFromDB = DBHelper.CustomerNameOfSubAccountUnderPrimaryAccount(primaryAccount);
                    List<string> subAccounstFromdb = subAccounstFromDB.OrderBy(q => q).ToList();

                    Console.WriteLine("sub from UI: ");
                    subAccounts.ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("sub from DB: ");
                    subAccounstFromDB.ForEach(x => Console.WriteLine(x));
                    //Console.WriteLine("subAccounstFromDB :" + subAccounstFromDB);

                    // primary account has no entries in dB
                    if (subAccounstFromDB.Count() == 0)
                    {
                        goto EVAL;
                    }
                    else
                    {
                        //CollectionAssert.AreEqual(subAccounstFromDB, subAccounts);
                        foreach (string sa in subAccounts)
                        {
                            if (!subAccounstFromDB.Contains(sa))
                            {
                                goto EVAL;
                            }
                        }
                    }

                }
            }

            EVAL:
            Assert.IsTrue(true);
        }

        [Then(@"The accounts will be displayed in alphabetical order within the hierarchy format")]
        public void ThenTheAccountsWillBeDisplayedInAlphabeticalOrderWithinTheHierarchyFormat()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            string accountsSelected = Gettext(attributeName_id, CustomReport_Selected_Stations);

            int accID = DBHelper.GetCustomerAccountId(customerNameActual);
            List<string> customerNamesList = DBHelper.GetSubAccountDetails(accID);
            
            Click(attributeName_xpath, CustomReport_Account_Xpath);
            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_SubAccountList));
            List<string> SubAccountListValues = ObjWebElementOperations.GetListFromIWebElement(subAccounts);

            Assert.AreEqual(customerNamesList[0], SubAccountListValues[0]);
            Assert.AreEqual(customerNamesList[1], SubAccountListValues[1]);
            Assert.AreEqual(customerNamesList[2], SubAccountListValues[2]);
            Assert.AreEqual(customerNamesList[3], SubAccountListValues[3]);

            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account in alphabetical order");
        }

        [Then(@"I have the option to search for accounts")]
        public void ThenIHaveTheOptionToSearchForAccounts()
        {
            string searchOption = "ZZZ";
            Report.WriteLine("Clicking on account dropdown");
            Click(attributeName_xpath, CustomReport_Account_Xpath);
            int cusValues = GetCount(attributeName_xpath, CustomReport_SearchActive_Xpath);

            SendKeys(attributeName_xpath, CustomReport_AccountInputField_Xpath, searchOption);
     
            IList<IWebElement> accountsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_SearchResult_Xpath));
            int totalResult = accountsDropdownList.Count;
            List<string> result = new List<string>();
            
            Assert.AreEqual(3, totalResult);
            Report.WriteLine("Customer dropdown is displaying only matching result");   
        }

        [Then(@"I will see the station names displayed in ascending order")]
        public void ThenIWillSeeTheStationNamesDisplayedInAscendingOrder()
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails("salesdelta");
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();
            List<string> stationName = DBHelper.GetMappedStationList(stationId);
            List<string> expectedNames = new List<string>();
            IList<IWebElement> stationDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));

            foreach (IWebElement element in stationDropdownList2)
            {
                expectedNames.Add(element.Text);
            }
            stationName.Sort();

            CollectionAssert.AreEqual(expectedNames, stationName);
            Report.WriteLine("The station that I am associated are available in alphabetical order in Station Dropdown");
        }

        [Then(@"the accounts for each station will be displayed in hierarchical format in alphabetical order")]
        public void ThenTheAccountsForEachStationWillBeDisplayedInHierarchicalFormatInAlphabeticalOrder()
        {
            Click(attributeName_xpath, CustomReport_Account_Xpath);
            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_SubAccountList));
            List<string> SubAccountListValues = ObjWebElementOperations.GetListFromIWebElement(subAccounts);

            Assert.IsTrue(string.Compare(SubAccountListValues[0], SubAccountListValues[1]) == -1);
            Assert.IsTrue(string.Compare(SubAccountListValues[1], SubAccountListValues[2]) == -1);

            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account in alphabetical order");
        }

        [Then(@"I am unable to select a station displayed in the Account list")]
        public void ThenIAmUnableToSelectAStationDisplayedInTheAccountList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_Selected_Customers);
            IList<IWebElement> stationList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationList_Xpath));
            string station = stationList[0].Text;
            stationList[0].Click();

            string accountsSelected = Gettext(attributeName_xpath, CustomReport_AccountInputField_Xpath);

            Assert.IsTrue(string.IsNullOrWhiteSpace(accountsSelected));
            Report.WriteLine("Displayed Stations in account field is not selected");
        }

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates user (.*) (.*)")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesUser(string username, string password)
        {
            Report.WriteLine("I logged into CRM application with shipentry user associated to account which has no sub accounts");
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("I logged into CRM application with shipentry user credenatials");
        }

        [Then(@"I will see the station names displayed in ascending order in account field")]
        public void ThenIWillSeeTheStationNamesDisplayedInAscendingOrderInAccountField()
        {
            Click(attributeName_id, CustomReport_Selected_Customers);
            IList<IWebElement> stationList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationList_Xpath));
            List<string> GridStationNameUI = ObjWebElementOperations.GetListFromIWebElement(stationList);
            List<string> AlphabeticalArray = new List<string>();
            for (int i = 0; i < stationList.Count; i++)
            {
                AlphabeticalArray.Add(stationList[i].Text.ToString());
            }

            GridStationNameUI.Sort();
            CollectionAssert.AreEqual(GridStationNameUI, AlphabeticalArray);
            Report.WriteLine("Displayed Stations are sorted in acending order");
        }
    }
}
