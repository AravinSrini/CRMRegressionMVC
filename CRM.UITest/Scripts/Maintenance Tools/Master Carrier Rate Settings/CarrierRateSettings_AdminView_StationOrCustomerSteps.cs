using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using System.Linq;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class CarrierRateSettings_AdminView_StationOrCustomerSteps : MaintenaceTools
    {
        [Given(@"I Click on the Maintenance tool icon in the navigation menu")]
        public void GivenIClickOnTheMaintenanceToolIconInTheNavigationMenu()
        {
            Report.WriteLine("Click on Maintenance Tools icon");
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            Verifytext(attributeName_xpath, MaintenanceToolsPage_Title_Xpath, "Maintenance Tools");
        }

        [When(@"I click on Pricing button from Maintenance tool page")]
        public void WhenIClickOnPricingButtonFromMaintenanceToolPage()
        {
            Report.WriteLine("Click on pricing button");
            VerifyElementPresent(attributeName_xpath, Pricing_Button_Xpath, "Pricing");
            Click(attributeName_xpath, Pricing_Button_Xpath);
        }
        
        [Then(@"I should see all stations and select individual customers dropdown")]
        public void ThenIShouldSeeAllStationsAndSelectIndividualCustomersDropdown()
        {
            Report.WriteLine("Verifying the display of all stations and individual customers dropdowns");
            VerifyElementPresent(attributeName_id, AllStations_Id, "All Stations Dropdown");
            VerifyElementPresent(attributeName_id, IndividualCustomers_Id, "Individual Customers Dropdown");
        }
        
        [Then(@"I should see all the stations exists in the database under all stations dropdown (.*)")]
        public void ThenIShouldSeeAllTheStationsExistsInTheDatabaseUnderAllStationsDropdown(string Username)
        {
            List<CustomerAccount> Stationdetails = DBHelper.GetAllStationList();
            Click(attributeName_id, AllStations_Id);
            int UIStationCount = GetCount(attributeName_xpath, AllStations_DropdownValues_Xpath);
            Assert.AreEqual(Stationdetails.Count, UIStationCount);
            Report.WriteLine("Displaying station count in UI " + UIStationCount + "is matching with database count" + Stationdetails.Count);
        }

        [Then(@"displaying accounts for a selected station (.*) should match with the database")]
        public void ThenDisplayingAccountsForASelectedStationShouldMatchWithTheDatabase(string stationName)
        {
            Click(attributeName_id, IndividualCustomers_Id);
            SendKeys(attributeName_xpath, IndividualCustomers_SelectedValue_Xpath, stationName);
            List<CustomerAccount> records = DBHelper.GetAccountsMappedforStation(stationName);
            List<int> setupid = records.Select(s => s.CustomerSetUpId).ToList();

            IList<IWebElement> UIAccounts = GlobalVariables.webDriver.FindElements(By.XPath(IndividualCustomers_DropdownValues_Xpath));

            List<string> options = new List<string>();
            foreach (var s in setupid)
            {
                CustomerSetup account = DBHelper.GetSetupDetails(s);
                options.Add(account.CustomerName);
            }

            for (int i = 2; i <= UIAccounts.Count; i++)
            {
                string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li[" +i+ "]")).Text;
                if (options.Contains(value))
                {
                    Report.WriteLine("Displaying Account in UI is mapped for the selected station");
                }
                else
                {
                    Report.WriteLine("Displaying accounts are not mapped to the selected station");
                    Assert.IsTrue(false);
                }
            }
        }

        [Then(@"All stations should be selected by default in all stations dropdown")]
        public void ThenAllStationsShouldBeSelectedByDefaultInAllStationsDropdown()
        {
            Report.WriteLine("Verifying the default text present inside the All stations dropdown");
            string actualText = GetAttribute(attributeName_xpath, AllStations_SelectedValue_Xpath, "value");
            Assert.AreEqual(actualText, "ALL STATIONS");
            Report.WriteLine("All stations option is selected by default");
        }
        
        [Then(@"I should be able to select multiple stations (.*), (.*) and (.*)")]
        public void ThenIShouldBeAbleToSelectMultipleStationsAnd(string Station1, string Station2, string Station3)
        {
            Report.WriteLine("Selecting "+ Station1 +" from All stations dropdown");
            Click(attributeName_id, AllStations_Id);
            SendKeys(attributeName_xpath, AllStations_SelectedValue_Xpath, Station1);
            Click(attributeName_xpath, AllStations_DropdownFirstValue_Xpath);

            Report.WriteLine("Selecting " + Station2 + " from All stations dropdown");
            SendKeys(attributeName_xpath, AllStations_SelectedValue_Xpath, Station2);
            Click(attributeName_xpath, AllStations_DropdownFirstValue_Xpath);

            Report.WriteLine("Selecting " + Station3 + " from All stations dropdown");
            SendKeys(attributeName_xpath, AllStations_SelectedValue_Xpath, Station3);
            Click(attributeName_xpath, AllStations_DropdownFirstValue_Xpath);
        }
        
        [Then(@"I should be able to select multiple accounts (.*), (.*) and (.*)")]
        public void ThenIShouldBeAbleToSelectMultipleAccountsAnd(string Acc1, string Acc2, string Acc3)
        {
            Report.WriteLine("Selecting " + Acc1 + " from All stations dropdown");
            Click(attributeName_id, IndividualCustomers_Id);
            SendKeys(attributeName_xpath, IndividualCustomers_SelectedValue_Xpath, Acc1);
            Click(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath);

            Report.WriteLine("Selecting " + Acc2 + " from All stations dropdown");
            SendKeys(attributeName_xpath, IndividualCustomers_SelectedValue_Xpath, Acc2);
            Click(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath);

            Report.WriteLine("Selecting " + Acc3 + " from All stations dropdown");
            SendKeys(attributeName_xpath, IndividualCustomers_SelectedValue_Xpath, Acc3);
            Click(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath);
        }
        
        [Then(@"Individual customers dropdown should be disabled")]
        public void ThenIndividualCustomersDropdownShouldBeDisabled()
        {
            string value = GetAttribute(attributeName_xpath, IndividualCustomers_SelectedValue_Xpath, "disabled");
            Assert.AreEqual(value, "true");
            Report.WriteLine("Individual customers dropdown is disabled when any station is selected from all stations dropdown");
        }
        
        [Then(@"All stations dropdown should be disabled")]
        public void ThenAllStationsDropdownShouldBeDisabled()
        {
            string value = GetAttribute(attributeName_xpath, AllStations_SelectedValue_Xpath, "disabled");
            Assert.AreEqual(value, "true");
            Report.WriteLine("All stations dropdown is disabled when any customers is selected from Individual customers dropdown");
        }

        [Then(@"I should be able to see these options within grid - Gainshare, Minimum, Min Threshold, Min Amount, Master Accessorial charge")]
        public void ThenIShouldBeAbleToSeeTheseOptionsWithinGrid_GainshareMinimumMinThresholdMinAmountMasterAccessorialCharge()
        {
            Report.WriteLine("Verifying the columns displayin the grid on selecting any station or customers");
            VerifyElementPresent(attributeName_xpath, Gainshare_Column_Xpath, "Gainshare Column");
            string ActColumn1 = Gettext(attributeName_xpath, Gainshare_Column_Xpath);
            Assert.AreEqual(ActColumn1, "GAINSHARE");
            Report.WriteLine("Gainshare column is displaying in table");

            VerifyElementPresent(attributeName_xpath, Mininum_Column_Xpath, "Minimum Column");
            string ActColumn2 = Gettext(attributeName_xpath, Mininum_Column_Xpath);
            Assert.AreEqual(ActColumn2, "MINIMUM");
            Report.WriteLine("Minimum column is displaying in table");

            VerifyElementPresent(attributeName_xpath, MininumThreshold_Column_Xpath, "Minimum Threshold Column");
            string ActColumn3 = Gettext(attributeName_xpath, MininumThreshold_Column_Xpath);
            Assert.AreEqual(ActColumn3, "MIN THRESHOLD");
            Report.WriteLine("Minimum Threshold column is displaying in table");

            VerifyElementPresent(attributeName_xpath, MininumAmount_Column_Xpath, "Minimum Amount Column");
            string ActColumn4 = Gettext(attributeName_xpath, MininumAmount_Column_Xpath);
            Assert.AreEqual(ActColumn4, "MIN AMOUNT");
            Report.WriteLine("Minimum Amount column is displaying in table");

            VerifyElementPresent(attributeName_xpath, MasterAccCharge_Column_Xpath, "Master Accesorial Charge Column");
            string ActColumn5 = Gettext(attributeName_xpath, MasterAccCharge_Column_Xpath);
            Assert.AreEqual(ActColumn5, "MASTER ACCESSORIAL CHARGE");
            Report.WriteLine("Master Accesorial Charge Column is displaying in table");
        }
        
        [Then(@"I should be able to see following text boxes - Minimum, Min Threshold, Min Amount and Set Accessorials")]
        public void ThenIShouldBeAbleToSeeFollowingTextBoxes_MinimumMinThresholdMinAmountAndSetAccessorials()
        {
            VerifyElementPresent(attributeName_id, Mininum_Textbox_Id, "Minimum Text box");
            Report.WriteLine("Minimum Text box is displaying in page");

            VerifyElementPresent(attributeName_id, MininumThreshold_Textbox_Id, "Minimum Threshold Text box");
            Report.WriteLine("Minimum Threshold Text box is displaying in page");

            VerifyElementPresent(attributeName_id, MininumAmount_Textbox_Id, "Minimum Amount Text box");
            Report.WriteLine("Minimum Amount Text box is displaying in page");
        }

        [Then(@"and Minimum, Min Threshold and Min Amount buttons should be disabled")]
        public void ThenAndMinimumMinThresholdAndMinAmountButtonsShouldBeDisabled()
        {
            string Minvalue = GetAttribute(attributeName_id, Mininum_Button_Id, "disabled");
            Assert.AreEqual(Minvalue, "true");
            Report.WriteLine("Minimum button is disabled");

            string MinThresholdValue = GetAttribute(attributeName_id, MininumThreshold_Button_Id, "disabled");
            Assert.AreEqual(MinThresholdValue, "true");
            Report.WriteLine("Minimum threshold button is disabled");

            string MinAmountValue = GetAttribute(attributeName_id, MininumThreshold_Button_Id, "disabled");
            Assert.AreEqual(MinAmountValue, "true");
            Report.WriteLine("Minimum amount button is disabled");
        }

        [Then(@"I should be able to see following buttons - Minimum, Min Threshold, Min Amount and Set Accessorials")]
        public void ThenIShouldBeAbleToSeeFollowingButtons_MinimumMinThresholdMinAmountAndSetAccessorials()
        {
            VerifyElementPresent(attributeName_id, Mininum_Button_Id, "Minimum Button");
            string actMinButton = Gettext(attributeName_id, Mininum_Button_Id);
            Assert.AreEqual(actMinButton, "Min");
            Report.WriteLine("Minimum button is displaying in page");

            VerifyElementPresent(attributeName_id, MininumThreshold_Button_Id, "Minimum Threshold Button");
            string actThresholdButton = Gettext(attributeName_id, MininumThreshold_Button_Id);
            Assert.AreEqual(actThresholdButton, "Min Threshold");
            Report.WriteLine("Minimum Threshold button is displaying in page");

            VerifyElementPresent(attributeName_id, MininumAmount_Button_Id, "Minimum Amount Button");
            string actAmtButton = Gettext(attributeName_id, MininumAmount_Button_Id);
            Assert.AreEqual(actAmtButton, "Min Amount");
            Report.WriteLine("Minimum Amount buttonis displaying in page");
        }


        [Then(@"I should be able enter the data in text boxes - (.*), (.*) and (.*)")]
        public void ThenIShouldBeAbleEnterTheDataInTextBoxes_And(string Minimum, string MinThreshold, string MinAmount)
        {
            SendKeys(attributeName_id, Mininum_Textbox_Id, Minimum);
            string actualMin = GetAttribute(attributeName_id, Mininum_Textbox_Id, "value");
            Assert.AreEqual(actualMin, Minimum);
            Report.WriteLine("Passed mininum value is displaying in text box");

            SendKeys(attributeName_id, MininumThreshold_Textbox_Id, MinThreshold);
            string actualMinThreshold = GetAttribute(attributeName_id, MininumThreshold_Textbox_Id, "value");
            Assert.AreEqual(actualMinThreshold, MinThreshold);
            Report.WriteLine("Passed mininum threshold value is displaying in text box");

            SendKeys(attributeName_id, MininumAmount_Textbox_Id, MinAmount);
            string actualMinAmount = GetAttribute(attributeName_id, MininumAmount_Textbox_Id,"value");
            Assert.AreEqual(actualMinAmount, MinAmount);
            Report.WriteLine("Passed mininum amount value is displaying in text box");
        }
        
        [Then(@"and Minimum, Min Threshold and Min Amount buttons should be enabled")]
        public void ThenAndMinimumMinThresholdAndMinAmountButtonsShouldBeEnabled()
        {
            string Minvalue = GetAttribute(attributeName_id, Mininum_Button_Id, "disabled");
            Assert.AreEqual(Minvalue, null);
            Report.WriteLine("Minimum button is enabled on entering data in text box");

            string MinThresholdValue = GetAttribute(attributeName_id, MininumThreshold_Button_Id, "disabled");
            Assert.AreEqual(MinThresholdValue, null);
            Report.WriteLine("Minimum threshold button is enabled on entering data in text box");

            string MinAmountValue = GetAttribute(attributeName_id, MininumThreshold_Button_Id, "disabled");
            Assert.AreEqual(MinAmountValue, null);
            Report.WriteLine("Minimum amount button is enabled on entering data in text box");
        }

        [Then(@"Minimum text box format should be currency or percentage")]
        public void ThenMinimumTextBoxFormatShouldBeCurrencyOrPercentage()
        {
            Report.WriteLine("Verifying the minimum text box format values");
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(Mininum_FormatDropdownValues_Xpath));
            for (int i = 0; i < values.Count; i++)
            {
                if(values[i].Text == "$" || values[i].Text == "%" )
                {
                    Report.WriteLine(values[i].Text + " is displaying under minimum data formant dropdown");
                }
                else
                {
                    Report.WriteLine("Displaying minimum data format is not matching with expected values");
                    Assert.IsTrue(false);
                }
            }
        }
        
        [Then(@"MinThreshold text box format should be currency")]
        public void ThenMinThresholdTextBoxFormatShouldBeCurrency()
        {
            string actual = GetAttribute(attributeName_id, MininumThreshold_FormatDropdown_Id, "value");
            Assert.AreEqual(actual, "$");
            Report.WriteLine("Minimum threshold data format is $");
        }
        
        [Then(@"MinAmount text box format should be currency")]
        public void ThenMinAmountTextBoxFormatShouldBeCurrency()
        {
            string actual = GetAttribute(attributeName_id, MininumAmount_FormatDropdown_Id, "value");
            Assert.AreEqual(actual, "$");
            Report.WriteLine("Minimum Amount data format is $");
        }

        [Then(@"I should be able enter the data in (.*) and click on Min button")]
        public void ThenIShouldBeAbleEnterTheDataInAndClickOnMinButton(string Minimum)
        {
            SendKeys(attributeName_id, Mininum_Textbox_Id, Minimum);
            Report.WriteLine("CLicking on Minimum button");
            Click(attributeName_id, Mininum_Button_Id);
        }

        [Then(@"Passed data in min text box should be applied for Minimum column fields (.*)")]
        public void ThenPassedDataInMinTextBoxShouldBeAppliedForMinimumColumnFields(string MinValue)
        {
            Report.WriteLine("Comparing the passed data with UI data");
            string actualValue = Gettext(attributeName_xpath, FirstCarrier_MinColumnValue_Xpath);
            Assert.AreEqual(MinValue, actualValue.Replace("$", null));
            Report.WriteLine("Displaying data in UI is matching with passed data");
        }

        [Then(@"I select any carrier")]
        public void ThenISelectAnyCarrier()
        {
            Thread.Sleep(3000);
            Report.WriteLine("Selecting any carrier");
            Click(attributeName_xpath, FirstCarrier_Checkbox_Xpath);

        }

        [Then(@"I should be able enter the data in (.*) and click on Minimum threshold button")]
        public void ThenIShouldBeAbleEnterTheDataInAndClickOnMinimumThresholdButton(string MinThreshold)
        {
            SendKeys(attributeName_id, MininumThreshold_Textbox_Id, MinThreshold);
            Report.WriteLine("CLicking on Minimum threshold button");
            Click(attributeName_id, MininumThreshold_Button_Id);
        }

        [Then(@"Passed data in min text box should be applied for Minimum Threshold column fields (.*)")]
        public void ThenPassedDataInMinTextBoxShouldBeAppliedForMinimumThresholdColumnFields(string MinThreshold)
        {
            Report.WriteLine("Comparing the passed data with UI data");
            string actualValue = Gettext(attributeName_xpath, FirstCarrier_MinThresholdColumnValue_Xpath);
            Assert.AreEqual(MinThreshold, actualValue.Replace("$", null));
            Report.WriteLine("Displaying data in UI is matching with passed data");
        }

        [Then(@"I should be able enter the data in (.*) and click on Minimum ammount button")]
        public void ThenIShouldBeAbleEnterTheDataInAndClickOnMinimumAmmountButton(string MinAmount)
        {
            SendKeys(attributeName_id, MininumAmount_Textbox_Id, MinAmount);
            Report.WriteLine("CLicking on Minimum amount button");
            Click(attributeName_id, MininumAmount_Button_Id);
        }

        [Then(@"Passed data in min text box should be applied for Minimum amount column fields (.*)")]
        public void ThenPassedDataInMinTextBoxShouldBeAppliedForMinimumAmountColumnFields(string MinAmount)
        {
            Report.WriteLine("Comparing the passed data with UI data");
            string actualValue = Gettext(attributeName_xpath, FirstCarrier_MinAmountColumnValue_Xpath);
            Assert.AreEqual(MinAmount, actualValue.Replace("$", null));
            Report.WriteLine("Displaying data in UI is matching with passed data");
        }

    }
}
