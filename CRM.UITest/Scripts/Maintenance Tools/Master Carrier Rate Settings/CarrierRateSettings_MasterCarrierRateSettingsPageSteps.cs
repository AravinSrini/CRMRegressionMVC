using System;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;
using System.Threading;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class CarrierRateSettings_MasterCarrierRateSettingsPageSteps : MaintenaceTools
    {
        [Given(@"I have access to (.*) page")]
        public void GivenIHaveAccessToPage(string MaintenanceTools)
        {
            Report.WriteLine("Click on Maintenance Tools icon");
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            Verifytext(attributeName_xpath, MaintenanceToolsPage_Title_Xpath, MaintenanceTools);
            
        }
        
        [When(@"I click on (.*) from the Maintenance Tools page")]
        public void WhenIClickOnFromTheMaintenanceToolsPage(string PricingButton)
        {
            Report.WriteLine("Click on pricing button");
            VerifyElementPresent(attributeName_xpath, Pricing_Button_Xpath, PricingButton);
            try
            {
                Click(attributeName_xpath, Pricing_Button_Xpath);
            }
            catch (Exception)
            {
                Thread.Sleep(40000);
            } 
        }
        
        [Then(@"I must be navigated to (.*) Page")]
        public void ThenIMustBeNavigatedToPage(string MasterCarrierRateSettings)
        {
            Report.WriteLine("Navigation to Master Carrier Rate settings page");
            VerifyElementPresent(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, MasterCarrierRateSettings);
        }

        [Then(@"The '(.*)' of the page should read Master Carrier Rate Settings Page")]
        public void ThenTheOfThePageShouldReadMasterCarrierRateSettingsPage(string title)
        {
            Report.WriteLine("Master carrier rate settings page title");
            Verifytext(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, title);
        }

        [Then(@"The '(.*)' of the page must read Adjust the rate settings for carriers")]
        public void ThenTheOfThePageMustReadAdjustTheRateSettingsForCarriers(string subtitle)
        {
            Report.WriteLine("Subtitle of Master carrier rate settings page");
            Verifytext(attributeName_xpath, MasterCarrierRatePage_SubTitle_Xpath, subtitle);
        }

        [Then(@"I must be able able to view Back to Maintenance Tools (.*) in the Master Carrier Rate Settings Page")]
        public void ThenIMustBeAbleAbleToViewBackToMaintenanceToolsInTheMasterCarrierRateSettingsPage(string Button)
        {
            Report.WriteLine("Back to Maintenance Tools button");
            VerifyElementPresent(attributeName_xpath, BackToMaintenanceTools_Button_Xpath, Button);
        }

        [Then(@"Onclick of Back to Maintenence Tools button i must be navigated back to (.*) page")]
        public void ThenOnclickOfBackToMaintenenceToolsButtonIMustBeNavigatedBackToPage(string MaintenanceTools)
        {
            Report.WriteLine("Click on Back to Maintenance Tools button");
            Click(attributeName_xpath, BackToMaintenanceTools_Button_Xpath);
            Verifytext(attributeName_xpath, MaintenanceToolsPage_Title_Xpath, MaintenanceTools);
        }

        [Then(@"I must be able to select one (.*) from the stations multi select dropdown box")]
        public void ThenIMustBeAbleToSelectOneFromTheStationsMultiSelectDropdownBox(string station)
        {
            Report.WriteLine("Click on Stations dropdown");
            Click(attributeName_xpath, StationTypeSelection_DropdownBox_Xpath);
            IList<IWebElement> StationdropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(StationTypeSelection_DropdownList_Xpath));
            for (int i = 0; i <= StationdropdownValues.Count; i++)
            {
                if (StationdropdownValues[i].Text == station)
                {
                    SelectDropdownValueFromList(attributeName_xpath, StationTypeSelection_DropdownList_Xpath, station);
                    break;
                }
                else
                {
                    Report.WriteLine("Station value does not exists");
                }
            }
        }

        [Then(@"I click on Stations multi select dropdown box")]
        public void ThenIClickOnStationsMultiSelectDropdownBox()
        {
            Report.WriteLine("Click on Multi select station dropdown");
            Click(attributeName_xpath, StationTypeSelection_DropdownBox_Xpath);
        }

        [Then(@"I click on Customers multi select dropdown box")]
        public void ThenIClickOnCustomersMultiSelectDropdownBox()
        {
            Report.WriteLine("Click on Multi select customer dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
        }

        [Then(@"I must be able to select multiple stations (.*) and (.*) from  multi select dropdown box")]
        public void ThenIMustBeAbleToSelectMultipleStationsAndFromMultiSelectDropdownBox(string Station1, string station2)
        {
            SelectDropdownValueFromList(attributeName_xpath, StationTypeSelection_DropdownList_Xpath, Station1);
            Click(attributeName_xpath, StationTypeSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, StationTypeSelection_DropdownList_Xpath, station2);
        }

        [Then(@"I must be able to select one (.*) from the customers multi select dropdown box")]
        public void ThenIMustBeAbleToSelectOneFromTheCustomersMultiSelectDropdownBox(string customer)
        {
            Report.WriteLine("Click on Customers dropdown");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            IList<IWebElement> CustomerdropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerSelection_DropdownList_Xpath));
            for (int i = 0; i <= CustomerdropdownValues.Count; i++)
            {
                if (CustomerdropdownValues[i].Text == customer)
                {
                    SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customer);
                    break;
                }
                else
                {
                    Report.WriteLine("Customer value does not exists");
                }
            }
        }

        [Then(@"I must be able to select multiple customers (.*) and (.*) from  multi select dropdown box")]
        public void ThenIMustBeAbleToSelectMultipleCustomersAndFromMultiSelectDropdownBox(string Customer1, string customer2)
        {
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, Customer1);
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, customer2);
        }

        [Then(@"The default value for stations multi select dropdown must read All Stations")]
        public void ThenTheDefaultValueForStationsMultiSelectDropdownMustReadAllStations()
        {
            Report.WriteLine("Verifying the default text present inside the All stations dropdown");
            string actualText = GetAttribute(attributeName_xpath, StationDefaultValue_Xpath, "value");
            Assert.AreEqual(actualText, "ALL STATIONS");

        }

        [Then(@"The default value for customers multi select dropdown box must read All customers")]
        public void ThenTheDefaultValueForCustomersMultiSelectDropdownBoxMustReadAllCustomers()
        {
            Report.WriteLine("Default Customer dropdown value");
            string actualText = GetAttribute(attributeName_xpath, CustomerDefaultValue_Xpath, "value");
            Assert.AreEqual(actualText, "ALL CUSTOMERS");
        }

        [Then(@"I must be able to enter Surge value with validations")]
        public void ThenIMustBeAbleToEnterSurgeValueWithValidations()
        {
            Report.WriteLine("Surge value textbox");
            SendKeys(attributeName_xpath, SurgeValue_Textbox_Xpath, "10.05");
        }


        [Then(@"I must be able to view % (.*) as Surge value format")]
        public void ThenIMustBeAbleToViewAsSurgeValueFormat(string symbolSurge)
        {
            Report.WriteLine("Verification of percentage symbol");
            VerifyElementPresent(attributeName_xpath, SurgeValueSymbol_Xpath, symbolSurge);
        }

        [Then(@"I must be able to view a (.*) in the Master Carrier Rate Settings Page")]
        public void ThenIMustBeAbleToViewAInTheMasterCarrierRateSettingsPage(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I must be able to enter value to Bump textbox")]
        public void ThenIMustBeAbleToEnterValueToBumpTextbox()
        {
            Report.WriteLine("Bump value textbox");
            SendKeys(attributeName_xpath, BumpValue_Textbox_Xpath, "99.00");
        }

        [Then(@"I must be able to view surge '(.*)' in the Master Carrier Rate Settings Page")]
        public void ThenIMustBeAbleToViewSurgeInTheMasterCarrierRateSettingsPage(string SButton)
        {
            Report.WriteLine("Surge button");
            VerifyElementPresent(attributeName_xpath, SurgeButton_Xpath, SButton);
        }

        [Then(@"I must be able to view % (.*) as Bump value format")]
        public void ThenIMustBeAbleToViewAsBumpValueFormat(string symbolBump)
        {
            Report.WriteLine("Bump value format");
            VerifyElementPresent(attributeName_xpath, BumpValueSymbol_Xpath, symbolBump);
        }

        [Then(@"I must be able to view Bump (.*) in the Master Carrier Rate Settings Page")]
        public void ThenIMustBeAbleToViewBumpInTheMasterCarrierRateSettingsPage(string BButton)
        {
            Report.WriteLine("Bump button");
            VerifyElementPresent(attributeName_xpath, BumpButton_Xpath, BButton);
        }

        [Then(@"I must be able to view master carrier rate grid with expected headers")]
        public void ThenIMustBeAbleToViewMasterCarrierRateGridWithExpectedHeaders()
        {
            for(int i = 2; i <= 4; i++)
            {
                IList<IWebElement> ActualGridValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CustomerTable']/thead/tr/th[" + i + "]"));
                List<string> ExpectedHeaderValues = new List<string>(new string[] { "CARRIER", "SURGE", "BUMP" });

                foreach (var val in ActualGridValues)
                {
                    if (ExpectedHeaderValues.Contains(val.Text))
                    {
                        Report.WriteLine("Display" + val.Text + "is the master carrier rate grid value");
                    }
                    else
                    {
                        Report.WriteLine("does not exists");
                    }
                }
            } 
        }

        [Then(@"I must have an option to select all carriers")]
        public void ThenIMustHaveAnOptionToSelectAllCarriers()
        {
            Report.WriteLine("Selection of all carriers");
            Click(attributeName_xpath, SelectAllCarriers_Checkbox_Xpath);
        }

        [Then(@"I must be able to unselect all the selected carriers")]
        public void ThenIMustBeAbleToUnselectAllTheSelectedCarriers()
        {
            Report.WriteLine("Unselect the selected carriers");
            Click(attributeName_xpath, UnSelectAllCarriers_Checkbox_Xpath);
        }


        [Then(@"I must have an option to choose selected carriers")]
        public void ThenIMustHaveAnOptionToChooseSelectedCarriers()
        {
            Report.WriteLine("Select Specified carrier Selection");
            Click(attributeName_xpath, SelectSpecifiedCarrier_Xpath);
        }
        
        [Then(@"I must be able to unselect selected carriers")]
        public void ThenIMustBeAbleToUnselectSelectedCarriers()
        {
            Report.WriteLine("Unselect Specified carrier Selection");
            Click(attributeName_xpath, UnSelectSpecifiedCarrier_Xpath);
        }
        
        [Then(@"I must be able to view carrier names sorted in ascending order")]
        public void ThenIMustBeAbleToViewCarrierNamesSortedInAscendingOrder()
        {
            IList<IWebElement> CarrierListOnPageLoad = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
            if (CarrierListOnPageLoad.Count > 0)
            {
                List<string> InitialListValues = new List<string>();
                foreach (IWebElement element in CarrierListOnPageLoad)
                {
                    InitialListValues.Add((element.Text).ToString());
                }

                Click(attributeName_xpath, CarrierHeaderClick_Xpath);
                IList<IWebElement> CarrierListOnSorting = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
                List<string> SortedListValues = new List<string>();
                foreach (IWebElement element in CarrierListOnSorting)
                {
                    SortedListValues.Add((element.Text).ToString());
                }

                SortedListValues.Sort();

                for (int i = 0; i <= InitialListValues.Count; i++)
                {
                        if (InitialListValues[i].Equals(SortedListValues[i]))
                        {
                            Report.WriteLine("Carrier List is in ascending Order");
                            break;
                        }
                        else
                        {
                            Report.WriteLine("Carrier List is not in ascending order");
                            break;
                        }
                }
            }
            else
            {
                Report.WriteLine("Carrier List is empty");
            }

        }

        [Then(@"I select a carrier")]
        public void ThenISelectACarrier()
        {
            Report.WriteLine("Select a carrier");
            Click(attributeName_xpath, SelectSpecifiedCarrier_Xpath);
        }

        [Then(@"I must be able to enter Surge value - (.*)")]
        public void ThenIMustBeAbleToEnterSurgeValue_(string Surge)
        {
            Report.WriteLine("Surge value");
            SendKeys(attributeName_xpath, SurgeValue_Textbox_Xpath, Surge);
        }

        [Then(@"I Click on Surge button")]
        public void ThenIClickOnSurgeButton()
        {
            Report.WriteLine("Click on Surge button");
            Click(attributeName_xpath, SurgeButton_Xpath);
        }

        [Then(@"The value passed from the surge textbox should be applied to surge column fields - (.*)")]
        public void ThenTheValuePassedFromTheSurgeTextboxShouldBeAppliedToSurgeColumnFields_(string Surge)
        {
            Report.WriteLine("Surge column value");
            string actualSurge = Gettext(attributeName_xpath, SurgeColumnValue_Xpath);
            Assert.AreEqual(Surge,actualSurge.Replace("%", null));
        }

        [Then(@"I must be able to enter Bump value - (.*)")]
        public void ThenIMustBeAbleToEnterBumpValue_(string Bump)
        {
            Report.WriteLine("Bump value");
            SendKeys(attributeName_xpath, BumpValue_Textbox_Xpath, Bump);
        }

        [Then(@"I Click on Bump button")]
        public void ThenIClickOnBumpButton()
        {
            Report.WriteLine("Click on bump button");
            Click(attributeName_xpath, BumpButton_Xpath);
        }

        [Then(@"The value passed from the Bump textbox should be applied to Bump column fields - (.*)")]
        public void ThenTheValuePassedFromTheBumpTextboxShouldBeAppliedToBumpColumnFields_(string Bump)
        {
            Report.WriteLine("Bump column value");
            string actualBump = Gettext(attributeName_xpath, BumpColumnValue_Xpath);
            Assert.AreEqual(Bump, actualBump.Replace("%", null));
        }
    }
}
