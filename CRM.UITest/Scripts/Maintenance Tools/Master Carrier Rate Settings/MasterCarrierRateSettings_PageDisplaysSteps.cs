using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class MasterCarrierRateSettings_PageDisplaysSteps : MaintenaceTools
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a system admin or pricing user (.*) and (.*)")]
        public void GivenIAmASystemAdminOrPricingUserAnd(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am on Master Carrier Rate Settings Page")]
        public void GivenIAmOnMasterCarrierRateSettingsPage()
        {
            //Click on maintenance tool
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            Thread.Sleep(1000);
            //click on pricing button
            Click(attributeName_xpath, Pricing_Button_Xpath);
            Thread.Sleep(1000);
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings");
            Report.WriteLine("I am on Master Carrier Rate Settings page");
        }
        
        [Given(@"I selected a customer (.*)")]
        public void GivenISelectedACustomer(string customerName)
        {
            Report.WriteLine("Select the Customer");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customerName);
        }

        [Given(@"selected a customer from the Select account to display\.\.\. drop down list as a external user")]
        public void GivenSelectedACustomerFromTheSelectAccountToDisplay_DropDownListAsAExternalUser()
        {
            Report.WriteLine("Select the Customer");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, "");
        }

        [Then(@"I am able to select one customer (.*)")]
        public void ThenIAmAbleToSelectOneCustomer(string customerName)
        {
            Report.WriteLine("Select one customer from customer dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customerName);
            Thread.Sleep(5000);
        }

        [When(@"I am on Master Carrier Rate Settings Page")]
        public void WhenIAmOnMasterCarrierRateSettingsPage()
        {
            //Click on maintenance tool
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            Thread.Sleep(1000);
            //click on pricing button
            Click(attributeName_xpath, Pricing_Button_Xpath);
            Thread.Sleep(3000);
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings");
            Report.WriteLine("I am on Mater carrier Rate settings page");
        }

        [When(@"I select the customer that does not have carrier specific pricing (.*)")]        
        public void WhenISelectTheCustomerThatDoesNotHaveCarrierSpecificPricing(string customerName)
        {
            Report.WriteLine("Select the customer that doesn't have carrier specific pricing");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customerName);
        }

        [When(@"I select the customer that has carrier specific pricing (.*)")]
        public void WhenISelectTheCustomerThatHasCarrierSpecificPricing(string customerName)
        {
            Report.WriteLine("Select the customer that have carrier specific pricing");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customerName);
        }

        [When(@"I selected the customer (.*) having one or more individual accessorials")]
        public void WhenISelectedTheCustomerHavingOneOrMoreIndividualAccessorials(string customerName)
        {
            Report.WriteLine("Select the customer");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customerName);
        }
        
        [When(@"I selected (.*) with excludedcarriers")]
        public void WhenISelectedWithExcludedcarriers(string customerName)
        {
            Report.WriteLine("Select the customer with excluded carriers");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customerName);
        }               

        [Then(@"the grid will display for all carriers")]
        public void ThenTheGridWillDisplayForAllCarriers()
        {
            //UI 
            Thread.Sleep(10000);
            IList<IWebElement> UIAccounts = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            int actualCount = UIAccounts.Count;            

            //DB            
            int expectedCount = DBHelper.GetAllCarriers().Count;
            Thread.Sleep(5000);
            Assert.AreEqual(actualCount, expectedCount);
        }

        [Then(@"the fields Gainshare, Minimum, Min Threshold, Min Amount and Master Accessorial Charge will update with the values submitted in CSR for the customer (.*)")]
        public void ThenTheFieldsGainshareMinimumMinThresholdMinAmountAndMasterAccessorialChargeWillUpdateWithTheValuesSubmittedInCSRForTheCustomer(string customerName)
        {
            int setupId = DBHelper.GetAccountIdforAccountName(customerName);
            int accountNumber = DBHelper.GetAccountNumber(setupId);
            int pricingModelId = DBHelper.GetGainsharePricingId(customerName);            
            List<InsuredRateCarrier> DBcarriers = DBHelper.GetAllCarriers();
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = new List<string>();
                foreach (IWebElement element in carriersUI)
                {
                    carrierListValues.Add((element.Text));
                }
                IList<IWebElement> UIGainshare = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_ColumnValues_Xpath));
                List<string> UIGainshareValues = new List<string>();
                foreach (IWebElement element in UIGainshare)
                {
                    UIGainshareValues.Add((element.Text));
                }
                IList<IWebElement> UIMinimum = GlobalVariables.webDriver.FindElements(By.XPath(Minimum_ColumnValues_Xpath));
                List<string> UIMinimumValues = new List<string>();
                foreach (IWebElement element in UIMinimum)
                {
                    UIMinimumValues.Add((element.Text));
                }
                IList<IWebElement> UIMinThreshold = GlobalVariables.webDriver.FindElements(By.XPath(MinThreshold_ColumnValues_Xpath));
                List<string> UIMinThresholdValues = new List<string>();
                foreach (IWebElement element in UIMinThreshold)
                {
                    UIMinThresholdValues.Add((element.Text));
                }
                IList<IWebElement> UIMinAmount = GlobalVariables.webDriver.FindElements(By.XPath(MinAmount_ColumnValues_Xpath));
                List<string> UIMinAmountValues = new List<string>();
                foreach (IWebElement element in UIMinAmount)
                {
                    UIMinAmountValues.Add((element.Text));
                }
                IList<IWebElement> UIMasterAccCharge = GlobalVariables.webDriver.FindElements(By.XPath(MasterAccCharge_ColumnValues_Xpath));
                List<string> UIMasterAccChargeValues = new List<string>();
                foreach (IWebElement element in UIMasterAccCharge)
                {
                    UIMasterAccChargeValues.Add((element.Text));
                }

                for (int i = 0; i < carrierListValues.Count; i++)
                {
                    if (carrierListValues.Contains(DBcarriers[i].CarrierName))
                    {
                        GainsharePricingModel value = DBHelper.GetPricingModelByAccountId(accountNumber);
                        Assert.AreEqual(UIGainshareValues[i], value.Percentage);
                        Assert.AreEqual(Convert.ToDecimal(UIMinimumValues[i]), value.Minimum);
                        Assert.AreEqual(UIMinThresholdValues[i], "$"+value.MinThresholdCharge);
                        Assert.AreEqual(UIMinAmountValues[i], "$"+value.MinAmountAdded);
                        Assert.AreEqual(Convert.ToDecimal(UIMasterAccChargeValues[i]), value.MasterAccessorialCharge);

                    }
                }
            }
        }

        [Then(@"the fields Gainshare, Minimum, Min Threshold, Min Amount and Master Accessorial Charge will update with the values submitted in CSR for carriers with carrier specific pricing (.*)")]
        public void ThenTheFieldsGainshareMinimumMinThresholdMinAmountAndMasterAccessorialChargeWillUpdateWithTheValuesSubmittedInCSRForCarriersWithCarrierSpecificPricing(string customerName)
        {            
            int pricingModelId = DBHelper.GetGainsharePricingId(customerName);            
            List<InsuredRateCarrier> DBcarriers = DBHelper.GetAllCarriers();
            IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (carriersUI.Count > 0)
            {
                List<string> carrierListValues = new List<string>();
                foreach (IWebElement element in carriersUI)
                {
                    carrierListValues.Add((element.Text));
                }
                IList<IWebElement> UIGainshare = GlobalVariables.webDriver.FindElements(By.XPath(Gainshare_ColumnValues_Xpath));
                List<string> UIGainshareValues = new List<string>();
                foreach (IWebElement element in UIGainshare)
                {
                    UIGainshareValues.Add((element.Text));
                }
                IList<IWebElement> UIMinimum = GlobalVariables.webDriver.FindElements(By.XPath(Minimum_ColumnValues_Xpath));
                List<string> UIMinimumValues = new List<string>();
                foreach (IWebElement element in UIMinimum)
                {
                    UIMinimumValues.Add((element.Text));

                }
                IList<IWebElement> UIMinThreshold = GlobalVariables.webDriver.FindElements(By.XPath(MinThreshold_ColumnValues_Xpath));
                List<string> UIMinThresholdValues = new List<string>();
                foreach (IWebElement element in UIMinThreshold)
                {
                    UIMinThresholdValues.Add((element.Text));
                }
                IList<IWebElement> UIMinAmount = GlobalVariables.webDriver.FindElements(By.XPath(MinAmount_ColumnValues_Xpath));
                List<string> UIMinAmountValues = new List<string>();
                foreach (IWebElement element in UIMinAmount)
                {
                    UIMinAmountValues.Add((element.Text));
                }
                IList<IWebElement> UIMasterAccCharge = GlobalVariables.webDriver.FindElements(By.XPath(MasterAccCharge_ColumnValues_Xpath));
                List<string> UIMasterAccChargeValues = new List<string>();
                foreach (IWebElement element in UIMasterAccCharge)
                {
                    UIMasterAccChargeValues.Add((element.Text));
                }

                for (int i = 0; i < carrierListValues.Count; i++)
                {
                    if (carrierListValues.Contains(DBcarriers[i].CarrierName))
                    {
                        GainShareScacCode value = DBHelper.GetGainshareScacByCarrierName(pricingModelId, carrierListValues[i]);

                        if (value == null)
                        {
                            GainsharePricingModel value1 = DBHelper.GetGainshareScacByCustomerlevel(pricingModelId);
                            Assert.AreEqual(UIGainshareValues[i], value1.Percentage);
                            Assert.AreEqual(Convert.ToDecimal(UIMinimumValues[i]), value1.Minimum);
                            Assert.AreEqual(UIMinThresholdValues[i], "$" + value1.MinThresholdCharge);
                            Assert.AreEqual(UIMinAmountValues[i], "$" + value1.MinAmountAdded);
                            Assert.AreEqual(Convert.ToDecimal(UIMasterAccChargeValues[i]), value1.MasterAccessorialCharge);
                        }
                        else
                        {
                            Assert.AreEqual(UIGainshareValues[i], value.GainsharePercentage);
                            Assert.AreEqual(Convert.ToDecimal(UIMinimumValues[i]), value.Minimum);
                            Assert.AreEqual(UIMinThresholdValues[i], "$"+value.CarrierSpecificMinimumThreshold);
                            Assert.AreEqual(UIMinAmountValues[i], "$"+value.CarrierSpecificMinimumAmount);
                            Assert.AreEqual(Convert.ToDecimal(UIMasterAccChargeValues[i]), value.MasterAccessorialCharge);
                        }
                    }
                }
            }
        }

        [Then(@"the grid must be updated with individual accessorials associated with selected customer (.*)")]
        public void ThenTheGridMustBeUpdatedWithIndividualAccessorialsAssociatedWithSelectedCustomer(string customerName)
        {
            IList<IWebElement> UIGridColumns = GlobalVariables.webDriver.FindElements(By.XPath(CarrierGridHeaderValues_Xpath));
            int accessorialsColumns = UIGridColumns.Count-9;
            int setupId = DBHelper.GetAccountIdforAccountName(customerName);
            int customerAccountId = DBHelper.GetAccountNumber(setupId);
            int actualAccessorials = DBHelper.GetAccessorials(customerAccountId).Count;
            Assert.AreEqual(accessorialsColumns, actualAccessorials);
        }

        [Then(@"the (.*) will be inactive in grid")]
        public void ThenTheWillBeInactive(string excludedCarriers)
        {
            Report.WriteLine("Excluded carrier is inactive");
            Thread.Sleep(5000);
            List<string> CarrierList_UI = IndividualColumnData(CarrierAllValues_Xpath);
            string[] excludedCarrier = excludedCarriers.Split(',');
            for(int i=0; i < CarrierList_UI.Count(); i++)
            {
                if (excludedCarrier.Contains(CarrierList_UI[i]))
                {
                    for(int j=0; j< excludedCarrier.Count(); j++)
                    {
                        IsElementDisabled(attributeName_xpath, CarrierAllValues_Xpath, excludedCarrier[j]);
                        break;
                    }
                }                           
            }            
        }

        [Then(@"carriers should be displayed in alphabetical order")]
        public void ThenCarriersShouldBeDisplayedInAlphabeticalOrder()
        {
            int i = 0;
            IList<IWebElement> CarrierList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (CarrierList_UI.Count > 0)
            {
                List<string> CarrierList = new List<string>();
                foreach (IWebElement element in CarrierList_UI)
                {
                    CarrierList.Add((element.Text).ToString());
                }
                CarrierList.Reverse();
                Click(attributeName_xpath, CarrierHeaderClick_Xpath);
                IList<IWebElement> CarrierListValues = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
                List<string> SortedCarrierValues = new List<string>();
                foreach (IWebElement element in CarrierListValues)
                {
                    SortedCarrierValues.Add((element.Text).ToString());
                }
                if (CarrierList[i].Equals(SortedCarrierValues[i]))
                {
                    Report.WriteLine("Carriers Column is in alphabetical Order");
                }
                else
                {
                    Report.WriteLine("Carriers Column is not in alphabetical order");
                }
            }
        }        
    }
}