using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote
{
    [Binding]
    public class DisplayCustomerNameOnAllPages_StationUsersSteps : Quotelist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        CommonQuoteNavigations quoteNavigations = new CommonQuoteNavigations();
        string selectedCustomerNameIdForRequote = string.Empty;

        [Given(@"that I am a sales, sales management, operations, or station owner user,")]
        public void GivenThatIAmASalesSalesManagementOperationsOrStationOwnerUser()
        {
            string Username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string Password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Quote List page,")]
        public void GivenIAmOnTheQuoteListPage()
        {
            Report.WriteLine("Click on Quotes button");
            Click(attributeName_xpath, QuoteList_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected a customer,")]
        public void GivenISelectedACustomer()
        {
            Report.WriteLine("Click on a customer from the dropdown");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteListDropdownXpath));
            if (dropDownList.Count > 3)
            {
                dropDownList[3].Click();
            }
        }

        [Given(@"I clicked on the Submit Rate Request button,")]
        public void GivenIClickedOnTheSubmitRateRequestButton()
        {
            Report.WriteLine("Click on submit rate request button");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
        }

        [Given(@"I clicked on the LTL tile on the Get Quote page,")]
        public void GivenIClickedOnTheLTLTileOnTheGetQuotePage()
        {
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
        }

        [Given(@"I expanded the quote details of an expired LTL quote,")]
        public void GivenIExpandedTheQuoteDetailsOfAnExpiredLTLQuote()
        {
            Click(attributeName_id, QuoteList_ExpiredButton_Id);
            Report.WriteLine("Click on a customer from the dropdown");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));
            for (int i = 0; i < dropDownList.Count; i++)
            {
                if (dropDownList[i].Text == "ZZZ - GS Customer Test")
                {
                    dropDownList[i].Click();
                    break;
                }
            }
            Thread.Sleep(2000);
            GlobalVariables.webDriver.WaitForPageLoad();
            selectedCustomerNameIdForRequote = Gettext(attributeName_xpath, QuoteListRequoteCustomerName);
        }

        [Given(@"I clicked on the Re-quote button,")]
        public void GivenIClickedOnTheRe_QuoteButton()
        {
            Thread.Sleep(3000);
            Click(attributeName_xpath, ReQuoteButtonExpand);
            Report.WriteLine("Clicking on requote icon for expired quote");
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(3000);
            Click(attributeName_xpath, ReQuoteButtonId);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Quote List page,")]
        public void WhenIArriveOnTheQuoteListPage()
        {
            Report.WriteLine("Click on Quotes button");
            Click(attributeName_xpath, QuoteList_Icon_Xpath);
        }

        [When(@"I click in the customer list selection field,")]
        public void WhenIClickInTheCustomerListSelectionField()
        {
            Report.WriteLine("Click on Customer dropdown button");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
        }

        [When(@"I select a customer from the customer drop down list,")]
        public void WhenISelectACustomerFromTheCustomerDropDownList()
        {
            Report.WriteLine("Click on a customer from the dropdown");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));
            for (int i = 0; i < dropDownList.Count; i++)
            {
                dropDownList[i].Click();
                break;
            }
        }

        [When(@"I arrive on the Get Quote selection page,")]
        public void WhenIArriveOnTheGetQuoteSelectionPage()
        {
            Report.WriteLine("Get Quote landing page have service type as LTL tiles");
            String GetQuoteServiceLTLtilesText = Gettext(attributeName_id, LTL_TileLabel_Id);
            Assert.AreEqual("LTL", GetQuoteServiceLTLtilesText);
        }

        [When(@"I arrive on the Get Quote \(LTL\) page,")]
        public void WhenIArriveOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("I arrived on Get Quote LTL Page");
        }

        [When(@"I am on the Quote Results \(LTL\) page,")]
        public void WhenIAmOnTheQuoteResultsLTLPage()
        {
            AddQuoteLTL quoteLtl = new AddQuoteLTL();
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.NaviagteToQuoteList();
            quoteNavigations.SelectCustomerFromDropdown("ZZZ - GS Customer Test");
            quoteLtl.Add_QuoteLTL("Internal", "ZZZ - GS Customer Test");
            quoteLtl.EnterOriginZip("60606");
            quoteLtl.EnterDestinationZip("33126");
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteLtl.selectShippingToServices("LTL");
            quoteLtl.selectShippingfromServices("LTL");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            quoteLtl.EnterItemdata("65", "1200");
            quoteLtl.EnterLWH("1", "1", "1", "LTL");
            try
            {
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
            }
            catch { }
        }

        [When(@"I am on the Quote Confirmation \(LTL\) page,")]
        public void WhenIAmOnTheQuoteConfirmationLTLPage()
        {
            quoteNavigations.NavigatetoQuoteConfirmationFromQuoteListWithServices("Internal", "ZZZ - GS Customer Test", "crmOperation", "10", "10", "10", "LTL");
        }

        [Then(@"I will see the customer list selection field positioned centered at the top of the Quote List page,")]
        public void ThenIWillSeeTheCustomerListSelectionFieldPositionedCenteredAtTheTopOfTheQuoteListPage()
        {
            Report.WriteLine("Visibility of customer list selection drop down");
            VerifyElementPresent(attributeName_xpath, QuoteList_CustomerDropdown_Xpath, "Customer Dropdown");
        }

        [Then(@"the customer list is positioned centered beneath the rrd dls world wide banner,")]
        public void ThenTheCustomerListIsPositionedCenteredBeneathTheRrdDlsWorldWideBanner()
        {
            Report.WriteLine("Customer Dropdown displayed below the rrd dls world wide banner");
            VerifyElementVisible(attributeName_xpath, QuoteList_CustomerDropdown_Xpath, "Customer Dropdown");
        }

        [Then(@"the customer list selection field will be defaulted to ""(.*)"",")]
        public void ThenTheCustomerListSelectionFieldWillBeDefaultedTo(string defaultDropdownText)
        {
            Report.WriteLine("Verify that we get the correct default text for dropdown");
            defaultDropdownText = "Select an account to display...";
            string ActualMessage = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            Assert.AreEqual(ActualMessage, defaultDropdownText);
        }

        [Then(@"I will see the following verbiage in the Quote List grid: ""(.*)""\.")]
        public void ThenIWillSeeTheFollowingVerbiageInTheQuoteListGrid_(string defaultGridVerbiage)
        {
            Report.WriteLine("Verify that we get the correct default text for dropdown");
            defaultGridVerbiage = "Please select a station or customer to view quotes";
            string ActualMessage = Gettext(attributeName_xpath, QuoteList_NoResults_Xpath);
            Assert.AreEqual(ActualMessage, defaultGridVerbiage);
        }

        [Then(@"the customers will be listed in hierarchy format,\(Station -> Primary Account -> Sub Account\)")]
        public void ThenTheCustomersWillBeListedInHierarchyFormatStation_PrimaryAccount_SubAccount()
        {
            bool isValid = true;

            // options under station-primary-sub drop down web element
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));

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
                    if (elementClassList.Contains("level2"))
                    {
                        continue;
                    }
                    else
                    {
                        // station
                        if (elementClassList.Contains("optiondisabled"))
                        {
                            lastSeenStation = elementText;

                            Dictionary<string, List<string>> primarySubDic = new Dictionary<string, List<string>>();
                            dict.Add(elementText, primarySubDic);
                        }
                        // primary
                        else if (elementClassList.Contains("level0") && !elementClassList.Contains("level1"))
                        {
                            lastSeenPrimaryAccount = elementText;

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            primarySubDic.Add(elementText, new List<string>());
                        }
                        // sub
                        else if (elementClassList.Contains("level0") && elementClassList.Contains("level1"))
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
                    isValid = false;
                    goto EVAL;
                }
                else
                {
                    //CollectionAssert.AreNotEqual(primaryAccountsFromdb, primaryAccounts);
                    foreach (string pa in primaryAccounts)
                    {
                        if (!primaryAccountsFromdb.Contains(pa))
                        {
                            isValid = false;
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
                        isValid = false;
                        goto EVAL;
                    }
                    else
                    {
                        //CollectionAssert.AreEqual(subAccounstFromDB, subAccounts);
                        foreach (string sa in subAccounts)
                        {
                            if (!subAccounstFromDB.Contains(sa))
                            {
                                isValid = false;
                                goto EVAL;
                            }
                        }
                    }

                }
            }

            EVAL:
            Assert.IsTrue(true);
        }

        [Then(@"the customers will be listed alphabetically\.")]
        public void ThenTheCustomersWillBeListedAlphabetically_()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));

            // sub accounts
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
                    if (elementClassList.Contains("ActiveUsersList") && elementClassList.Contains("SubAccountList"))
                    {
                        List<string> subAccList = new List<string>();
                        subAccList.Add(elementText);

                        int s = 0;
                        for (s = e + 1; s < dropDownList.Count(); ++s)
                        {
                            IWebElement nestedElement = dropDownList.ElementAt(s);
                            string nestedElementText = nestedElement.Text.ToString().Trim();
                            List<string> nestedElementClassList = new List<string>(nestedElement.GetAttribute("class").Split(' '));
                            if (nestedElementClassList.Contains("ActiveUsersList") && nestedElementClassList.Contains("SubAccountList"))
                            {
                                subAccList.Add(nestedElementText);
                            }
                            else
                            {
                                break;
                            }
                        }

                        List<string> copiedList = new List<string>(subAccList);
                        copiedList.Sort();
                        for (int i = 0; i < subAccList.Count(); ++i)
                        {
                            Assert.Equals(subAccList.ElementAt(i), copiedList.ElementAt(i));
                        }

                        e = ++s;
                    }
                }
            }

            // primary accounts
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
                    if (elementClassList.Contains("ActiveUsersList") && !elementClassList.Contains("SubAccountList"))
                    {
                        List<string> primaryAccList = new List<string>();
                        primaryAccList.Add(elementText);

                        int s = 0;
                        for (s = e + 1; s < dropDownList.Count(); ++s)
                        {
                            IWebElement nestedElement = dropDownList.ElementAt(s);
                            string nestedElementText = nestedElement.Text.ToString().Trim();
                            List<string> nestedElementClassList = new List<string>(nestedElement.GetAttribute("class").Split(' '));
                            if (nestedElementClassList.Contains("ActiveUsersList") && !nestedElementClassList.Contains("SubAccountList"))
                            {
                                primaryAccList.Add(nestedElementText);
                            }
                            else
                            {
                                break;
                            }
                        }

                        List<string> copiedList = new List<string>(primaryAccList);
                        copiedList.Sort();
                        primaryAccList.Sort();
                        CollectionAssert.AreEqual(copiedList, primaryAccList);

                        e = ++s;
                    }
                }
            }

            //station
            List<string> stationList = new List<string>();
            for (int e = 0; e < dropDownList.Count(); ++e)
            {
                IWebElement element = dropDownList.ElementAt(e);
                string elementText = element.Text.ToString().Trim();
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));

                    if (elementClassList.Contains("optiondisabled"))
                    {
                        stationList.Add(elementText);
                    }
                }
            }

            List<string> copiedList1 = new List<string>(stationList);
            copiedList1.Sort();
            CollectionAssert.AreEqual(copiedList1, stationList);
        }

        [Then(@"I will no longer have the option to select All Customers\.")]
        public void ThenIWillNoLongerHaveTheOptionToSelectAllCustomers_()
        {
            Report.WriteLine("Customer drop down should no longer have All customer option");
            bool allAccountsThere = false;
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));
            foreach (IWebElement s in dropDownList)
            {
                if (s.ToString() == "All Customers")
                {
                    allAccountsThere = true;
                    break;
                }
            }

            Assert.IsFalse(allAccountsThere);
        }

        [Then(@"I will see the following verbiage displayed directly beneath the customer list: ""(.*)""")]
        public void ThenIWillSeeTheFollowingVerbiageDisplayedDirectlyBeneathTheCustomerList(string verbiageBelowDropdown)
        {
            verbiageBelowDropdown = "Submitted rate requests within the past 30 days are shown.";
            string subTitle_UI = Gettext(attributeName_xpath, QuoteList_SubtitleInternalUser_Xpath);
            Assert.AreEqual(verbiageBelowDropdown, subTitle_UI);
        }

        [Then(@"I will see the Station-Primary Account-Customer Name displayed,")]
        public void ThenIWillSeeTheStation_PrimaryAccount_CustomerNameDisplayed()
        {
            bool isValid = true;

            // options under station-primary-sub drop down web element
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));

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
                    if (elementClassList.Contains("level2"))
                    {
                        continue;
                    }
                    else
                    {
                        // station
                        if (elementClassList.Contains("optiondisabled"))
                        {
                            lastSeenStation = elementText;

                            Dictionary<string, List<string>> primarySubDic = new Dictionary<string, List<string>>();
                            dict.Add(elementText, primarySubDic);
                        }
                        // primary
                        else if (elementClassList.Contains("level0") && !elementClassList.Contains("level1"))
                        {
                            lastSeenPrimaryAccount = elementText;

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            primarySubDic.Add(elementText, new List<string>());
                        }
                        // sub
                        else if (elementClassList.Contains("level0") && elementClassList.Contains("level1"))
                        {

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            List<string> customers = primarySubDic[lastSeenPrimaryAccount];
                            customers.Add(elementText);
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
                    isValid = false;
                    goto EVAL;
                }
                else
                {
                    //CollectionAssert.AreNotEqual(primaryAccountsFromdb, primaryAccounts);
                    foreach (string pa in primaryAccounts)
                    {
                        if (!primaryAccountsFromdb.Contains(pa))
                        {
                            isValid = false;
                            goto EVAL;
                        }
                    }
                }

                foreach (string primaryAccount in primaryAccounts)
                {
                    List<string> customers = dict[stationName][primaryAccount];

                    List<string> customersFromDB = DBHelper.CustomerNameOfSubAccountUnderPrimaryAccount(primaryAccount);
                    List<string> customerFromdb = customersFromDB.OrderBy(q => q).ToList();

                    Console.WriteLine("sub from UI: ");
                    customers.ForEach(x => Console.WriteLine(x));
                    Console.WriteLine("sub from DB: ");
                    customersFromDB.ForEach(x => Console.WriteLine(x));
                    //Console.WriteLine("subAccounstFromDB :" + subAccounstFromDB);

                    // primary account has no entries in dB
                    if (customersFromDB.Count() == 0)
                    {
                        isValid = false;
                        goto EVAL;
                    }
                    else
                    {
                        //CollectionAssert.AreEqual(subAccounstFromDB, subAccounts);
                        foreach (string sa in customers)
                        {
                            if (!customersFromDB.Contains(sa))
                            {
                                isValid = false;
                                goto EVAL;
                            }
                        }
                    }

                }
            }

            EVAL:
            Assert.IsTrue(true);
        }

        [Then(@"the Station-Primary Account-Customer Name is not editable for get quote selection page\.")]
        public void ThenTheStation_PrimaryAccount_CustomerNameIsNotEditableForGetQuoteSelectionPage_()
        {
            IsElementDisabled(attributeName_xpath, StationCustomerName, "StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Then(@"the Station-Primary Account-Customer Name is not editable for get quote page\.")]
        public void ThenTheStation_PrimaryAccount_CustomerNameIsNotEditableForGetQuotePage_()
        {
            IsElementDisabled(attributeName_xpath, StationCustomerNameLabel, "StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Then(@"the Station-Primary Account-Customer Name is not editable for quote results page\.")]
        public void ThenTheStation_PrimaryAccount_CustomerNameIsNotEditableForQuoteResultsPage_()
        {
            IsElementDisabled(attributeName_xpath, StationCustomerNameLabel, "StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Then(@"the Station-Primary Account-Customer Name is not editable for quote confirmation page\.")]
        public void ThenTheStation_PrimaryAccount_CustomerNameIsNotEditableForQuoteConfirmationPage_()
        {
            IsElementDisabled(attributeName_xpath, StationCustomerNameLabelConfirmationPage, "StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Then(@"I will see the Station - Primary Account - Customer Name of the expired quote displayed on the page,")]
        public void ThenIWillSeeTheStation_PrimaryAccount_CustomerNameOfTheExpiredQuoteDisplayedOnThePage()
        {
            IsElementDisabled(attributeName_xpath, StationCustomerNameLabel, "StationCustomerName");
            string customername = Gettext(attributeName_xpath, StationCustomerNameLabel);
            Assert.IsTrue(customername.Contains(customername));
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Then(@"the displayed Station - Primary Account - Customer Name is not editable\.")]
        public void ThenTheDisplayedStation_PrimaryAccount_CustomerNameIsNotEditable_()
        {
            IsElementDisabled(attributeName_xpath, StationCustomerNameLabel, "StationCustomerName");
            Report.WriteLine("Station-Primary Account-Customer Name is not editable");
        }

        [Given(@"I clicked on the Create Shipment Page")]
        public void GivenIClickedOnTheCreateShipmentPage()
        {
            Quotelist quoteList = new Quotelist();
            Click(attributeName_id, quoteList.QuoteDetails_CreateShipmentButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

    }
}