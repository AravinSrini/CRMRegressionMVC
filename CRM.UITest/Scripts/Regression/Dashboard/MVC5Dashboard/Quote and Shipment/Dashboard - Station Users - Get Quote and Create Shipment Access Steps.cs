using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using System.Threading;
using CRM.UITest.Helper.Common;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Dashboard.Quote_and_Shipment
{
    [Binding]
    public class Dashboard___Station_Users___Get_Quote_and_Create_Shipment_Access_Steps : AddShipments
    {
        [Then(@"the Create Shipment or Quote section banner will be visible")]
        public void ThenTheCreateShipmentOrQuoteSectionBannerWillBeVisible()
        {
            Report.WriteLine("Verifying the Create Shipment or Quote banner is visible");
            VerifyElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_Banner_Xpath, "Create Shipment or Quote Banner");
        }

        [Then(@"the Select an account dropdown will be visible")]
        public void ThenTheSelectAnAccountDropdownWillBeVisible()
        {
            Report.WriteLine("Verifying the Select an account dropdown is visible");
            VerifyElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath, "Select an account dropdown");
        }

        [Then(@"the Mode dropdown will be visble")]
        public void ThenTheModeDropdownWillBeVisble()
        {
            Report.WriteLine("Verifying the Mode dropdown is visible");
            VerifyElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_Mode_Dropdown_Xpath, "Mode Dropdown");
        }

        [Then(@"the default Mode will be LTL")]
        public void ThenTheDefaultModeWillBeLTL()
        {
            Report.WriteLine("Verifying LTL is the default Mode");
            IWebElement modeDropdown = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_Mode_Dropdown_Xpath));
            if(modeDropdown.Text != "LTL")
            {
                Report.WriteFailure("LTL is not the default Mode selection. Default selection is " + modeDropdown.Text);
            }
        }

        [Then(@"the Shipment button is visible")]
        public void ThenTheShipmentButtonIsVisible()
        {
            Report.WriteLine("Verifying the Shipment button is visible");
            VerifyElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_Shipment_Button_Xpath, "Shipment Button");
        }

        [Then(@"the Quote button is visible")]
        public void ThenTheQuoteButtonIsVisible()
        {
            Report.WriteLine("Verifying the Quote button is visible");
            VerifyElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_Quote_Button_Xpath, "Quote Button");
        }

        [Then(@"the Create Shipment or Quote section banner is above Station Summary section")]
        public void ThenTheCreateShipmentOrQuoteSectionBannerIsAboveStationSummarySection()
        {
            Report.WriteLine("Verifying the Create Shipment or Quote banner is above the Station Summary Banner");
            int shipmentBannerPosition = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_Banner_Xpath)).Location.Y;
            int stationSummaryPosition = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_StationSummary_Banner_Xpath)).Location.Y;

            if(shipmentBannerPosition > stationSummaryPosition)
            {
                Report.WriteFailure("The Station Summary banner is above the Created Shipment or Quote banner");
            }
        }

        [Then(@"the default Select an account option is ""(.*)""")]
        public void ThenTheDefaultSelectAnAccountOptionIs(string defaultAccountSelection)
        {
            Report.WriteLine("Verifying the default Customer Account selection is " + defaultAccountSelection);
            IWebElement customerAccountDropdown = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath));
            if(customerAccountDropdown.Text != defaultAccountSelection)
            {
                Report.WriteFailure(defaultAccountSelection + " is not the default customer selection. Default selection is " + customerAccountDropdown.Text);
            }
        }


        [When(@"I click the Mode dropdown")]
        public void WhenIClickTheModeDropdown()
        {
            Report.WriteLine("Clicking the Mode dropdown");
            Click(attributeName_xpath, GetQuoteAndCreateShipment_Mode_Dropdown_Xpath);
        }

        [Then(@"the only option is LTL")]
        public void ThenTheOnlyOptionIsLTL()
        {
            WaitForElementVisible(attributeName_xpath, Chart_TotalCount_Xpath, "Pie Chart Total");
            IList<IWebElement> modeOptions = GlobalVariables.webDriver.FindElements(By.XPath(GetQuoteAndCreateShipment_Mode_Dropdown_Xpath));
            Click(attributeName_xpath, GetQuoteAndCreateShipment_Mode_Dropdown_Xpath);
            Report.WriteLine("Verifying there is only one option in the Mode dropdown");
            Assert.AreEqual(1, modeOptions.Count);
            Report.WriteLine("Verifying the option is LTL");
            Assert.AreEqual("LTL", modeOptions[0].Text);
        }

        [Given(@"I click the Select an account dropdown")]
        [When(@"I click the Select an account dropdown")]
        public void WhenIClickTheSelectAnAccountDropdown()
        {
            Report.WriteLine("Clicking the Select an account dropdown");
            Click(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath);
        }

        [Then(@"the customer names will be listed in hierarchy format")]
        public void ThenTheCustomerNamesWillBeListedInHierarchyFormat()
        {
            VerifyHierarchyOfCustomers();
        }

        [Then(@"the stations ""(.*)"" will be displayed numerically, then alphabetically")]
        public void ThenTheStationsWillBeDisplayedNumericallyThenAlphabetically(string stationNames)
        {
            Report.WriteLine("Verifying stations are displayed numerically, then alphabetically");
            IList<IWebElement> stationsFromDropdown = GlobalVariables.webDriver.FindElements(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Elements_Xpath));
            List<string> stations = new List<string>();
            for (int i = 0; i < stationsFromDropdown.Count; i++)
            {
                if (stationsFromDropdown[i].GetAttribute("class").Contains("group-result"))
                {
                    string stationName = stationsFromDropdown[i].Text;
                    stations.Add(stationName);
                }
            }
            List<string> expectedStationsOrder = stationNames.Split(',').ToList();
            expectedStationsOrder.Sort();
            Assert.IsTrue(stations.SequenceEqual(expectedStationsOrder));
        }

        [Then(@"I cannot select a station")]
        public void ThenICannotSelectAStation()
        {
            Report.WriteLine("Verifying that a station cannot be selected from Select an account dropdown");
            WaitForElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Search_Xpath, "Customer Search Box");
            IList<IWebElement> stationsFromDropdown = GlobalVariables.webDriver.FindElements(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Elements_Xpath));
            for (int i = 0; i < stationsFromDropdown.Count; i++)
            {
                if (stationsFromDropdown[i].GetAttribute("class").Contains("group-result"))
                {
                    WebDriverHelpers.ClickElement(stationsFromDropdown[i]);
                    if(!stationsFromDropdown[i].Displayed)
                    {
                        Report.WriteFailure("Station " + stationsFromDropdown[i].Text + " is a selectable option");
                    }
                }
            }
        }

        [Given(@"I choose the customer ""(.*)""")]
        [When(@"I choose the customer ""(.*)""")]
        public void WhenIChooseTheCustomer(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Search_Xpath, "Select an Account search box");
            SendKeys(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Search_Xpath, customerName);
            Click(attributeName_xpath, GetQuoteAndCreateShipment_FirstAccountOption_Xpath);
        }

        [When(@"I search for the customer ""(.*)""")]
        public void WhenISearchForTheCustomer(string customerName)
        {
            Report.WriteLine("Searching for " + customerName + " from the dropdown");
            Click(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Search_Xpath, "Select an Account search box");
            SendKeys(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Search_Xpath, customerName);
        }

        [Then(@"the customer ""(.*)"" will be displayed in the correct format with (.*) sub-accounts and station ""(.*)"" and primary account ""(.*)""")]
        public void ThenTheCustomerWillBeDisplayedInTheCorrectFormatWithSub_AccountsAndStationAndPrimaryAccount(string customerName, int subAccountNum, string station, string primaryAccount)
        {
            Report.WriteLine("Verifying the correct displayed format for the selected customer");
            IWebElement selectAnAccountDropdown = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath));
            string expectedDisplayedName = string.Empty;
            if(subAccountNum == 0)
            {
                expectedDisplayedName = station + " - " + primaryAccount;
            }
            else if (subAccountNum == 1)
            {
                expectedDisplayedName = station + " - " + primaryAccount + " - " + customerName;
            }
            else if (subAccountNum > 1)
            {
                expectedDisplayedName = station + " - " + primaryAccount + "..." + customerName;
            }
            Assert.AreEqual(expectedDisplayedName, selectAnAccountDropdown.Text);
        }

        [When(@"I hover over the customer in the Select an account field")]
        public void WhenIHoverOverTheCustomerInTheSelectAnAccountField()
        {
            Report.WriteLine("Hovering over the Select an account field");
            Thread.Sleep(500);
            GlobalVariables.webDriver.WaitForPageLoad();
            IWebElement customerDropdown = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath));
            WebDriverHelpers.HoverOverElement(customerDropdown);
        }

        [Then(@"the entire station, hierarchies, and customer name ""(.*)"" will be displayed in the hover over message for Select an account field with station ""(.*)"" and primary account ""(.*)""")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageForSelectAnAccountFieldWithStationAndPrimaryAccount(string selectedCustomer, string station, string primary)
        {
            Report.WriteLine("Verifying the entire hierarchy is shown in the hover message");
            Thread.Sleep(500);
            string hoverOverMessageText = GlobalVariables.webDriver.FindElement(By.ClassName(GetQuoteAndCreateShipment_SelectAnAccount_Hover_Message_ClassName)).Text;
            string expectedHoverMessage = station + " - " + primary;
            if (selectedCustomer != primary)
            {
                List<string> subAccounts = DBHelper.GetAllAccountsUnderPrimaryAccount(primary);
                foreach (string subAccount in subAccounts)
                {
                    expectedHoverMessage += (" - " + subAccount);
                    if (subAccount == selectedCustomer)
                    {
                        break;
                    }
                }
            }
            Assert.AreEqual(expectedHoverMessage, hoverOverMessageText);
        }


        [Given(@"the selected Mode field is ""(.*)""")]
        public void GivenTheSelectedModeFieldIs(string modeValue)
        {
            Report.WriteLine("Setting the Mode field to " + modeValue + " if not already set");
            IWebElement modeDropdown = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_Mode_Dropdown_Xpath));
            if(modeDropdown.Text != modeValue)
            {
                SelectDropdownValueFromList(attributeName_xpath, GetQuoteAndCreateShipment_Mode_Default_Option_Xpath, modeValue);
            }
        }

        [When(@"I click the Shipment button in the Create Shipment or Quote field")]
        public void WhenIClickTheShipmentButtonInTheCreateShipmentOrQuoteField()
        {
            Report.WriteLine("Clicking the Shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(1000);
            Click(attributeName_xpath, GetQuoteAndCreateShipment_Shipment_Button_Xpath);
        }

        [Then(@"I will be navigated to the Add Shipment \(LTL\) page for the customer ""(.*)""")]
        public void ThenIWillBeNavigatedToTheAddShipmentLTLPageForTheCustomer(string customerName)
        {
            Report.WriteLine("Verifying successful navigation to Add Shipment (LTL) screen for customer");
            WaitForElementVisible(attributeName_xpath, AddShipmentStationCustomerDisplay_Xpath, "Customer Header");
            VerifyElementVisible(attributeName_xpath, AddShipment_CustomerName_Header_Xpath, "Add Shipment LTL Header");
            string customerNameHeader = GlobalVariables.webDriver.FindElement(By.XPath(AddShipmentStationCustomerDisplay_Xpath)).Text;
            Assert.IsTrue(customerNameHeader.Contains(customerName));
        }

        [When(@"I click the Quote button in the Create Shipment or Quote field")]
        public void WhenIClickTheQuoteButtonInTheCreateShipmentOrQuoteField()
        {
            Report.WriteLine("Clicking the Quote button");
            if (GlobalVariables.webDriver.FindElements(By.Id("dv-loader")).Count > 0)
                WaitForElementNotVisible(attributeName_id, "dv-loader", "Loading Icon");
            Click(attributeName_xpath, GetQuoteAndCreateShipment_Quote_Button_Xpath);
        }

        [Then(@"I will be navigated to the Get Quote \(LTL\) page for the customer ""(.*)""")]
        public void ThenIWillBeNavigatedToTheGetQuoteLTLPageForTheCustomer(string customerName)
        {
            Report.WriteLine("Verifying successful navigation to Get Quote (LTL) screen for customer");
            WaitForElementVisible(attributeName_id, LTL_StationCustomerName_Label_id, "Customer Header");
            VerifyElementVisible(attributeName_xpath, LTL_GetQuoteLTL_Header_Xpath, "Get Quote LTL Header");
            string customerHeaderName = GlobalVariables.webDriver.FindElement(By.Id(LTL_StationCustomerName_Label_id)).Text;
            Assert.IsTrue(customerHeaderName.Contains(customerName));
        }

        [Given(@"I have not selected a customer account")]
        public void GivenIHaveNotSelectedACustomerAccount()
        {
            Report.WriteLine("Ensuring a customer account has not been selected");
            IWebElement customerAccountDropdown = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath));
            if(customerAccountDropdown.Text != "Select an account...")
            {
                Click(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Xpath);
                SendKeys(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_Search_Xpath, "Select an account...");
                Click(attributeName_xpath, GetQuoteAndCreateShipment_FirstAccountOption_Xpath);
            }
        }

        [Then(@"the Select an account field will be highlighted")]
        public void ThenTheSelectAnAccountFieldWillBeHighlighted()
        {
            Report.WriteLine("Verfying the Select an account field is highlighted");
            IWebElement selectAnAccountDropdown = GlobalVariables.webDriver.FindElement(By.Id(GetQuoteAndCreateShipment_SelectAnAccount_Dropdown_Id));
            Assert.IsTrue(selectAnAccountDropdown.GetAttribute("class").Contains("required"));

            string highlightColor = GetCSSValue(attributeName_xpath, GetQuoteAndCreateShipment_SelectAnAccount_RequiredHighlight_Xpath, "border-top-color");
            if (highlightColor.Contains('#'))
            {
                Assert.AreEqual(GetQuoteAndCreateShipment_RequiredField_Highlight_Color_Hex, highlightColor);
            }
            else if (highlightColor.Contains("rgba"))
            {
                Assert.AreEqual(GetQuoteAndCreateShipment_RequiredField_Highlight_Color_Rgba, highlightColor);
            }
            else
            {
                Assert.AreEqual(GetQuoteAndCreateShipment_RequiredField_Highlight_Color_Rgb, highlightColor);
            }
        }

        [Then(@"the Shipment button for Create Shipment or Quote field will be inactive")]
        public void ThenTheShipmentButtonForCreateShipmentOrQuoteFieldWillBeInactive()
        {
            Report.WriteLine("Verifying the Shipment button is inactive");
            IWebElement shipmentButton = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_Shipment_Button_Xpath));
            Assert.IsFalse(shipmentButton.Enabled);
        }

        [Then(@"the Quote button for Create Shipment or Quote field will be inactive")]
        public void ThenTheQuoteButtonForCreateShipmentOrQuoteFieldWillBeInactive()
        {
            Report.WriteLine("Verifying the Quote button will be inactive");
            IWebElement quoteButton = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_Quote_Button_Xpath));
            Assert.IsFalse(quoteButton.Enabled);
        }

        [Then(@"I will see a ""(.*)"" indicator for the customer")]
        public void ThenIWillSeeAIndicatorForTheCustomer(string indicator)
        {
            IWebElement customerDropdownElement = GlobalVariables.webDriver.FindElement(By.XPath(GetQuoteAndCreateShipment_FirstAccountOption_Xpath));
            string customerText = customerDropdownElement.Text;
            if(indicator == "Credit Hold")
            {
                Report.WriteLine("Verifying that credit hold indicator is present next to customer name");
                Assert.IsTrue(customerDropdownElement.GetAttribute("class").Contains("option-credit-hold"));
            }
            else
            {
                Report.WriteLine("Verifying that customer is active and name is grayed out");
                Assert.IsTrue(customerDropdownElement.GetAttribute("class").Contains("InActiveUsersList"));
            }
        }


        private void VerifyHierarchyOfCustomers()
        {
            Report.WriteLine("Verifying the Hierarchy of the Customers");
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(GetQuoteAndCreateShipment_SelectAnAccount_Elements_Xpath));

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
                if(elementText.Contains("(credit hold)"))
                {
                    elementText = elementText.Substring(0, elementText.Length - 14);
                }
                // skipping default 'select' option and any empty options
                if (elementText.Length != 0 && !elementText.Equals("Select"))
                {
                    // Fetching the class attribute, which will help to identify the element type
                    List<string> elementClassList = new List<string>(element.GetAttribute("class").Split(' '));
                    {
                        // station
                        if (elementClassList.Contains("group-result"))
                        {
                            lastSeenStation = elementText;

                            Dictionary<string, List<string>> primarySubDic = new Dictionary<string, List<string>>();
                            dict.Add(elementText, primarySubDic);
                        }
                        // primary
                        else if (elementClassList.Contains("primary-account"))
                        {
                            lastSeenPrimaryAccount = elementText;

                            Dictionary<string, List<string>> primarySubDic = dict[lastSeenStation];
                            primarySubDic.Add(elementText, new List<string>());
                        }
                        // sub
                        else if (!elementClassList.Contains("primary-account") && !elementClassList.Contains("result-selected") && !elementClassList.Contains("optiondisabled"))
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

                DBHelper dbHelper = new DBHelper();
                List<CodeTableViewModel> primaryAccountsFromDB = dbHelper.GetCustomersIncludingInactive(stationName);
                List<string> primaryAccountsFromdb = new List<string>();
                for(int i = 0; i < primaryAccountsFromDB.Count; i++)
                {
                    primaryAccountsFromdb.Add(primaryAccountsFromDB[i].Name);
                }
                primaryAccountsFromdb.Sort();

                // station name has no entries in dB
                Report.WriteLine("primaryAccounts : ");
                foreach (string s in primaryAccounts)
                {
                    Report.WriteLine("1 :" + s);
                }
                Report.WriteLine("primaryAccountsFromDB : ");
                foreach (CodeTableViewModel s in primaryAccountsFromDB)
                {
                    Report.WriteLine("2 :" + s.Name);
                }
                if (primaryAccountsFromdb.Count != primaryAccounts.Count)
                {
                    Report.WriteFailure("Primary accounts in database and primary accounts in dropdown mismatch for station " + stationName);
                }
                else
                {
                    for (int j = 0; j < primaryAccountsFromdb.Count; j++)
                    {
                        if(primaryAccountsFromdb[j].Replace("  ", " ") != primaryAccounts[j])
                        {
                            Report.WriteFailure("The primary accounts are not sorted correctly");
                        }
                    }
                }

                foreach (string primaryAccount in primaryAccounts)
                {
                    List<string> subAccounts = dict[stationName][primaryAccount];

                    List<string> subAccountsFromDB = DBHelper.GetAllAccountsUnderPrimaryAccount(primaryAccount);
                    subAccountsFromDB.Sort();

                    // primary account has no entries in dB
                    if (subAccountsFromDB.Count() != subAccounts.Count)
                    {
                        Report.WriteFailure("Number of sub accounts in DB don't match number of sub accounts in dropdown for " + primaryAccount);
                    }
                    else
                    {
                        for(int k = 0; k < subAccountsFromDB.Count; k++)
                        {
                            if (subAccountsFromDB[k] != subAccounts[k])
                            {
                                Report.WriteLine("Sub accounts in drop down are not sorted properly");
                            }
                        }
                    }

                }
            }
        }
    }
}
