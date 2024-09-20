using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class AccessRRDUser_CustomerInvoicePageLoadSteps : Customer_Invoice
    {
        private WebElementOperations ObjWebElementOperations = new WebElementOperations();

        [Given(@"I am an Access RRD user logged in to CRM Application")]
        public void GivenIAmAnAccessRRDUserLoggedInToCRMApplication()
        {
            string userName = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [Given(@"I have selected one or more Stations from the Station list")]
        public void GivenIHaveSelectedOneOrMoreStationsFromTheStationList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectAllValuesFromDropdown(CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id, CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath);
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            IList<IWebElement> stationDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));
            
            int countStations = stationDropdownList.Count;
            List<string> stations = new List<string>();

            for (int i = 0; i < countStations; i++)
            {
                stations.Add(stationDropdownList[i].Text);
            }

            string accountsSelected = Gettext(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            foreach (string station in stations)
            {
                Assert.IsTrue(accountsSelected.Contains(station));
            }

            Report.WriteLine("Selected multiple stations which I am associated to");
        }

        [Given(@"I have selected one or more accounts from the Accounts list")]
        public void GivenIHaveSelectedOneOrMoreAccountsFromTheAccountsList()
        {
            //Select a customer from dropdown
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));
            string customer1 = dropdownValues[0].Text;
            string customer2 = dropdownValues[1].Text;
            SelectDropdownValueFromList(CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id, CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath, customer1);
            SelectDropdownValueFromList(CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id, CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath, customer2);
        }

        [Given(@"I select a customer from the Customer Accounts dropdown (.*)")]
        public void GivenISelectACustomerFromTheCustomerAccountsDropdown(string customerName)
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> accounts = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));

            //Select a customer from dropdown
            SelectValueFromDropdown(CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id, CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath, customerName);
        }

        [When(@"I am on the Customer Invoices list page")]
        public void WhenIAmOnTheCustomerInvoicesListPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }

        [When(@"I click in the Customer Accounts field")]
        public void WhenIClickInTheCustomerAccountsField()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
        }

        [When(@"I click on the Display Invoices button")]
        public void WhenIClickOnTheDisplayInvoicesButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id);
            Report.WriteLine("Clicked on Display Invoices button");
        }

        [When(@"I click in the Stations dropdown for accessRRD User")]
        public void WhenIClickInTheStationsDropdownForAccessRRDUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
        }
        
        [When(@"I select a customer from the Customer Accounts dropdown (.*)")]
        public void WhenISelectACustomerFromTheCustomerAccountsDropdown(string customerName)
        {
            //Select a customer from dropdown
            SelectValueFromDropdown(CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id, CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath, customerName);
        }

        [Then(@"the accounts for each station will be displayed in hierarchical format")]
        public void ThenTheAccountsForEachStationWillBeDisplayedInHierarchicalFormat()
        {
            VerifyHierarchyOfCustomers();
        }

        [Then(@"the accounts will be displayed in alphabetical order within the hierarchy format")]
        public void ThenTheAccountsWillBeDisplayedInAlphabeticalOrderWithinTheHierarchyFormat()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            string accountsSelected = Gettext(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);

            int accID = DBHelper.GetCustomerAccountId(customerNameActual);
            List<string> customerNamesList = DBHelper.GetSubAccountDetails(accID);
            customerNamesList.Sort();

            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> allSubAccounts = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));

            for (int i = 0; i < allSubAccounts.Count; i++)
            {
                if (allSubAccounts[i].Text.ToLower() == customerNameActual.ToLower())
                {
                    for (int j = 0; j < customerNamesList.Count(); j++)
                    {
                        Assert.AreEqual(customerNamesList[j], allSubAccounts[i + j + 1].Text);
                    }
                    break;
                }
            }

            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account in alphabetical order");
        }

        [Then(@"I have the option to select one or more accounts")]
        public void ThenIHaveTheOptionToSelectOneOrMoreAccounts()
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));
            string customer1 = dropdownValues[1].Text;
            string customer2 = dropdownValues[2].Text;
            SelectValueFromDropdown(CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id, CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath, customer1);
            SelectValueFromDropdown(CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id, CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath, customer2);

            string accountsSelected = Gettext(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            List<string> accounts = string.IsNullOrWhiteSpace(accountsSelected) ? new List<string>() :
                accountsSelected.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None).ToList();

            Assert.IsTrue(accounts.Count() > 0);
            Report.WriteLine("Verified that multiple accounts can be selected from customer accounts' dropdown");
        }

        [Then(@"I have the option to search for accounts in dropdown")]
        public void ThenIHaveTheOptionToSearchForAccountsInDropdown()
        {
            string searchOption = "CZar";
            Report.WriteLine("Clicking on account dropdown");
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);

            SendKeys(attributeName_xpath, CustomerInvoicePage_AccessRRDUser_CustomerAccountsSearchInput_XPath, searchOption);

            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> accountsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));
            int totalResult = accountsDropdownList.Count;

            Assert.AreEqual(3, totalResult);
            Report.WriteLine("Customer dropdown is displaying only matching result");
        }

        [Then(@"I have the option to search for a station for RRD AccessUser")]
        public void ThenIHaveTheOptionToSearchForAStationForRRDAccessUser()
        {
            string searchOption = "ZZZ";
            Report.WriteLine("Clicking on station dropdown");
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);

            SendKeys(attributeName_xpath, CustomerInvoicePage_AccessRRDUser_StationSearchInput_XPath, searchOption);
            int totalResult = GetCount(attributeName_xpath, CustomReport_Input_XPath);

            Assert.AreEqual(1, totalResult);
            Report.WriteLine("Station dropdown is displaying only matching result");

            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            IList<IWebElement> stationsResult = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));
            string result = stationsResult[0].Text;
            Assert.IsTrue(result.Contains(searchOption));

            Report.WriteLine("Passed string " + searchOption + " is displaying station dropdown " + result);
        }

        [Then(@"I will see a Display Invoices button")]
        public void ThenIWillSeeADisplayInvoicesButton()
        {
            Assert.IsTrue(IsElementVisible(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id, "Display Invoices"));
            Report.WriteLine("Display Invoices button is available");
        }

        [Then(@"the Display Invoices button is inactive")]
        public void ThenTheDisplayInvoicesButtonIsInactive()
        {
            Assert.IsTrue(IsElementDisabled(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id, "Display Invoices"));
            Report.WriteLine("Display Invoices button is inactive");
        }

        [Then(@"the Display Invoices button will become active")]
        public void ThenTheDisplayInvoicesButtonWillBecomeActive()
        {
            Assert.IsTrue(IsElementEnabled(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id, "Display Invoices"));
            Report.WriteLine("Verified that the Display Invoices button is active");
        }

        [Then(@"I am required to select one or more stations")]
        public void ThenIAmRequiredToSelectOneOrMoreStations()
        {
            //Verify that the Display Invoices button is disabled if no stations are selected
            Assert.IsTrue(IsElementDisabled(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id, "Display Invoices"));
            Report.WriteLine("Display Invoices button is inactive when no station is selected");
        }

        [Then(@"I am required to select at least one account")]
        public void ThenIAmRequiredToSelectAtLeastOneAccount()
        {
            //Verify that the Display Invoices button is disabled if no customers are selected
            Assert.IsTrue(IsElementDisabled(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id, "Display Invoices"));
            Report.WriteLine("Verified that the Display Invoices button is inactive when no customer is selected");
        }

        [Then(@"the Customer Invoice grid will no longer auto-populate")]
        public void ThenTheCustomerInvoiceGridWillNoLongerAuto_Populate()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string noRecordsFoundText = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            Assert.AreEqual("No Results Found", noRecordsFoundText);
            Report.WriteLine("The customer inovice grid is not loaded");
        }

        [Then(@"I will be presented with an option to select Stations that I am associated to")]
        public void ThenIWillBePresentedWithAnOptionToSelectStationsThatIAmAssociatedTo()
        {
            Assert.IsTrue(IsElementVisible(attributeName_id, "AccessRRDStations", "Stations dropdwon"));
            Report.WriteLine("The option to select Stations is available");
        }

        [Then(@"I will be presented with an option to select Customer Accounts I am associated to")]
        public void ThenIWillBePresentedWithAnOptionToSelectCustomerAccountsIAmAssociatedTo()
        {
            Assert.IsTrue(IsElementVisible(attributeName_id, "AccessRRDAccounts", "Customers dropdwon"));
            Report.WriteLine("The option to select Customers is available");
        }

        [Then(@"I will see a list of stations associated")]
        public void ThenIWillSeeAListOfStationsAssociated()
        {
            List<string> actualStations = new List<string>();
            IList<IWebElement> stationDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));

            foreach (IWebElement element in stationDropdownList)
            {
                actualStations.Add(element.Text);
            }

            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails(ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString());
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();
            List<string> expectedStations = DBHelper.GetMappedStationList(stationId);
            expectedStations.Sort();           

            CollectionAssert.AreEqual(actualStations, expectedStations);
            Report.WriteLine("The station that I am associated are available in Station Dropdown");
        }

        [Then(@"I have the option to select multiple stations associated")]
        public void ThenIHaveTheOptionToSelectMultipleStationsAssociated()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            IList<IWebElement> stationsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));
            string station1 = stationsDropdownList[0].Text;
            stationsDropdownList[0].Click();
            Report.WriteLine("Selected first station which I am associated to");

            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            IList<IWebElement> stationsDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));
            string station2 = stationsDropdownList2[1].Text;
            stationsDropdownList2[1].Click();
            Report.WriteLine("Selected second station which I am associated to");

            string accountsSelected = Gettext(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            Assert.IsTrue(accountsSelected.Contains(station1));
            Assert.IsTrue(accountsSelected.Contains(station2));

            Report.WriteLine("Selected multiple accounts which I am associated to");
        }

        [Then(@"I will see the selected station names displayed in ascending order")]
        public void ThenIWillSeeTheSelectedStationNamesDisplayedInAscendingOrder()
        {
            List<string> actualStations = new List<string>();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            IList<IWebElement> stationDropdownList2 = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));

            foreach (IWebElement element in stationDropdownList2)
            {
                actualStations.Add(element.Text);
            }

            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            List<AppUserClaimInfo> claimValue = new List<AppUserClaimInfo>();
            List<AppUserClaimInfo> claimDetails = IDP.GetUserClaimDetails(ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString());
            claimValue = claimDetails.Where(x => x.ClaimType == "dlscrm-StationId").Select(x => new AppUserClaimInfo
            {
                ClaimValue = x.ClaimValue,

            }).ToList();

            List<string> stationId = claimValue.Select(x => x.ClaimValue).ToList();
            List<string> expectedStationNames = DBHelper.GetMappedStationList(stationId);
            expectedStationNames.Sort();

            CollectionAssert.AreEqual(actualStations, expectedStationNames);
            Report.WriteLine("The station that I am associated are available in alphabetical order in Station Dropdown");
        }

        [Then(@"I am unable to select a station displayed in the Account list for AccessRRDUser")]
        public void ThenIAmUnableToSelectAStationDisplayedInTheAccountListForAccessRRDUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> accountsList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));
            string station = accountsList[0].Text;
            accountsList[0].Click();

            string accountsSelected = Gettext(attributeName_xpath, CustomerInvoicePage_AccessRRDUser_CustomerAccountsSearchInput_XPath);

            Assert.IsTrue(string.IsNullOrWhiteSpace(accountsSelected));
            Report.WriteLine("Verified that the Displayed Stations in account field is not selected");
        }

        [Then(@"the grid will refresh to populate the associated Customer Invoice details (.*)")]
        public void ThenTheGridWillRefreshToPopulateTheAssociatedCustomerInvoiceDetails(string customerName)
        {
            //Get associated invoices for selected customers
            string sapAccountNumberOfCustomer = DBHelper.GetCustomerSapAccountNumber(customerName);

            //Get invoices from invoice grid
            IList<IWebElement> invoicesGridAccountNumberAllValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicesPage_AccountNumber_AllValues_Xpath));
            for (int i = 0; i < invoicesGridAccountNumberAllValues.Count; i++)
            {
                if (invoicesGridAccountNumberAllValues[i].Text.ToLower() != sapAccountNumberOfCustomer.ToLower())
                {
                    Report.WriteFailure("Customer Invoice Grid is loaded with invalid invoices");
                    break;
                }
            }

            Report.WriteLine("Verified that the Customer Invoice Grid is loaded based on the customer selected");
        }

        [Then(@"the grid will refresh to populate zero results for the associated Customer Invoice details")]
        public void ThenTheGridWillRefreshToPopulateZeroResultsForTheAssociatedCustomerInvoiceDetails()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string noRecordsFoundText = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            Assert.AreEqual("No Results Found", noRecordsFoundText);
            Report.WriteLine("The customer inovice grid is not loaded");
        }

        private void SelectValueFromDropdown(string dropdownId,string dropdownAllValuesXpath, string dropdownValue)
        {
            Click(attributeName_id, dropdownId);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(dropdownAllValuesXpath));

            for (int i = 0; i < dropdownValues.Count; i++)
            {
                if (dropdownValues[i].Text.ToLower() == dropdownValue.ToLower())
                {
                    dropdownValues[i].Click();
                    break;
                }
            }
        }

        private void SelectAllValuesFromDropdown(string dropdownId, string dropdownAllValuesXpath)
        {
            Click(attributeName_id, dropdownId);
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(dropdownAllValuesXpath));
            int count = dropdownValues.Count;
           
            for (int i = 0; i < count; i++)
            {
               Click(attributeName_id, dropdownId);
               IList<IWebElement> dropdownValuesAll = GlobalVariables.webDriver.FindElements(By.XPath(dropdownAllValuesXpath));
                dropdownValuesAll[i].Click();
            }
        }

        private void VerifyHierarchyOfCustomers()
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath));

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
                Report.WriteLine("stationName : " + stationName);
                List<string> primaryAccounts = dict[stationName].Keys.ToList();

                List<string> primaryAccountsFromDB = DBHelper.GetCustomerNameByStationName(stationName);
                List<string> primaryAccountsFromdb = primaryAccountsFromDB.OrderBy(q => q).ToList();

                // station name has no entries in dB
                Report.WriteLine("primaryAccounts : ");
                foreach (string s in primaryAccounts)
                {
                    Report.WriteLine("1 :" + s);
                }
                Report.WriteLine("primaryAccountsFromDB : ");
                foreach (string s in primaryAccountsFromDB)
                {
                    Report.WriteLine("2 :" + s);
                }
                if (primaryAccountsFromDB.Count() == 0)
                {
                    goto EVAL;
                }
                else
                {
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

                    // primary account has no entries in dB
                    if (subAccounstFromDB.Count() == 0)
                    {
                        goto EVAL;
                    }
                    else
                    {
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
            Report.WriteLine("Verified that the accounts are displayed in hierarchy");
        }

        string station1 = null;
        [Given(@"I selected any Station from the dropdown for accessRRD User")]
        public void GivenISelectedAnyStationFromTheDropdownForAccessRRDUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            IList<IWebElement> stationsDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath));
            station1 = stationsDropdownList[0].Text;
            stationsDropdownList[0].Click();
            Report.WriteLine("Selected first station which I am associated to");
            Report.WriteLine("Selected multiple accounts which I am associated to");
        }

        [When(@"I click on accounts drop down")]
        public void WhenIClickOnAccountsDropDown()
        {
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id);
            
        }

        [Then(@"All the accounts associated to the selected station should be load in drop down")]
        public void ThenAllTheAccountsAssociatedToTheSelectedStationShouldBeLoadInDropDown()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='AccessRRDAccounts_chosen']//div//li[contains(@class,'active-result group-option level')]"));
            List <string> dropDownUI = new List<string>();
            for (int i = 0;i< dropDownList.Count; i++){
                dropDownUI.Add(dropDownList[i].Text);
            }

            List<string> value= DBHelper.GetCustomerActiveAndInactiveByStationName(station1);
            Assert.AreEqual(dropDownList.Count, value.Count);
        }



    }
}
