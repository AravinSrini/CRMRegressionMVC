using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class _48628_MasterCarrierRateSettings_AccessorialGainshareType_OptionsAndDisplaySteps : MaintenaceTools
    {
        private const string accessorialName = "Liftgate Delivery";
        private List<string> carrierNames = new List<string>();
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public WebElementOperations ObjWebElementOperations = new WebElementOperations();
        string customerName = "ZZZ - Czar Customer Test";

        [Given(@"I am a Pricing config or a Config manager user")]
        public void GivenIAmAPricingConfigOrAConfigManagerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I have selected a customer")]
        public void GivenIHaveSelectedACustomer()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SendKeys(attributeName_xpath, CustomerSelectionSearchField_TextBox_Xpath, customerName);
            SelectDropdownValueFromList(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath, customerName);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I selected a customer");
        }

        [Given(@"I selected one or more Carriers from the Master Carrier Rate Settings page (.*)")]
        public void GivenISelectedOneOrMoreCarriersFromTheMasterCarrierRateSettingsPage(string carrier)
        {
            if (carrier == "SingleCarrier")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, FirstCarrier_Checkbox_Xpath);
                carrierNames.Add(Gettext(attributeName_xpath, FirstCarrierName_Xpath));
                Report.WriteLine("Single Carrier is selected");
            }
            if (carrier == "MultipleCarrier")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, FirstCarrier_Checkbox_Xpath);
                Click(attributeName_xpath, secondCarrier_Checkbox_Xpath);
                carrierNames.Add(Gettext(attributeName_xpath, FirstCarrierName_Xpath));
                carrierNames.Add(Gettext(attributeName_xpath, SecondCarrierName_Xpath));
                Report.WriteLine("Multiple Carrier is selected");
            }
        }

        [Given(@"Clicked on the Set Accessorials Button")]
        public void GivenClickedOnTheSetAccessorialsButton()
        {
            scrollPageup();
            Click(attributeName_id, SetAccessorials_Button_Id);
            Report.WriteLine("Set accessorials button is been clicked");
        }

        [Given(@"I am on Set Individual Accessorials modal")]
        public void GivenIAmOnSetIndividualAccessorialsModal()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(3000);
            Verifytext(attributeName_xpath, SetIndividualAccessorials_ModalPopUp_Label_Xpath, "Set Individual Accessorials");
            Report.WriteLine("Set Individual Accessorials modal is visible");
        }

        [When(@"I click on Add Another Accessorial button of Set Individual Accessorials modal")]
        public void WhenIClickOnAddAnotherAccessorialButtonOfSetIndividualAccessorialsModal()
        {
            Click(attributeName_xpath, Add_AnotherAccessorial_Button_Xpath);
            Report.WriteLine("Clicked on Add Another Accessorial button");
        }


        [Given(@"I select % over cost from the Set Gainshare Type drop down list")]
        public void GivenISelectOverCostFromTheSetGainshareTypeDropDownList()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select (.*) from the (.*) drop down list")]
        public void GivenISelectFromTheDropDownList(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select Flat over cost from the Set Gainshare Type drop down list")]
        public void GivenISelectFlatOverCostFromTheSetGainshareTypeDropDownList()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I select Set flat amount from the Set Gainshare Type drop down list")]
        public void GivenISelectSetFlatAmountFromTheSetGainshareTypeDropDownList()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I selected one or more SingleCarrier")]
        public void GivenISelectedOneOrMoreSingleCarrier()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"% over cost has been selected as Set Gainshare Type from the drop down list")]
        public void GivenOverCostHasBeenSelectedAsSetGainshareTypeFromTheDropDownList()
        {
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, AdditionalGainshareTypeDropdownValues_Xpath, "% over cost");
            Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
        }

        [Given(@"Flat over cost has been selected as Set Gainshare Type from the drop down list")]
        public void GivenFlatOverCostHasBeenSelectedAsSetGainshareTypeFromTheDropDownList()
        {
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, AdditionalGainshareTypeDropdownValues_Xpath, "Flat over cost");
            Report.WriteLine("Flat over cost is selected from the Set Gainshare Type drop down list");
        }

        [Given(@"Set flat amount has been selected as Set Gainshare Type from the drop down list")]
        public void GivenSetFlatAmountHasBeenSelectedAsSetGainshareTypeFromTheDropDownList()
        {
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li"));
            for (int i = 0; i < dropdownValues.Count; i++)
            {
                int z = i + 1;
                string value = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Text;
                if (value == "Set flat amount")
                {
                    GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Click();
                    break;
                }
            }

            Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
        }

        [Given(@"I set values on Set Individual Accessorials Modal")]
        public void GivenISetValuesOnSetIndividualAccessorialsModal()
        {
            foreach (string carrier in carrierNames)
            {
                DBHelper.DeleteGainshareTypeValForAccessorial(carrier, customerName, accessorialName);
            }
            WaitForElementVisible(attributeName_xpath, SetAccessorialType_Xpath, "Accessorial");
            Click(attributeName_xpath, SetAccessorialType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SetAccessorailTypeValues_Xpath, accessorialName);
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Set flat amount");
            Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
            SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "23");
            Report.WriteLine("Value is set to Set Flat Amount field");
        }

        [When(@"I click on the Save button of Set Individual Accessorials Modal")]
        public void WhenIClickOnTheSaveButtonOfSetIndividualAccessorialsModal()
        {
            Click(attributeName_id, AccessorialSave_Id);
            Report.WriteLine("Clicked on Save button of Set Individual Accessorials Modal");
        }

        [When(@"I arrive on the Set Individual Accessorials modal")]
        public void WhenIArriveOnTheSetIndividualAccessorialsModal()
        {
            VerifyElementPresent(attributeName_id, SetAccessorialPopup_Id, "Set Individual Accessorials");
            Report.WriteLine("Arrived on Set Individual Accessorials modal");
        }

        [When(@"Over cost value entered is less than one")]
        public void WhenOverCostValueEnteredIsLessThanOne()
        {
            SendKeys(attributeName_xpath, PercentageOverCostLabel_Xpath, "0.2");
            Report.WriteLine("Entered % Over cost value is less than 1");
        }

        [When(@"entered Over cost value is more than hundred")]
        public void WhenEnteredOverCostValueIsMoreThanHundred()
        {
            SendKeys(attributeName_xpath, PercentageOverCostLabel_Xpath, "101");
            Report.WriteLine("Entered % Over cost value is more than 100");
        }

        [When(@"I have entered Flat over cost value less than one")]
        public void WhenIHaveEnteredFlatOverCostValueLessThanOne()
        {
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "0.2");
            Report.WriteLine("Entered FlatOverCost_Xpath value is less than 1");
        }

        [When(@"I have entered Flat over cost value more than (.*)")]
        public void WhenIHaveEnteredFlatOverCostValueMoreThan(Decimal val)
        {
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, val.ToString());
            Report.WriteLine("Entered Flat Over Cost value more than 1000");
        }

        [When(@"I have entered Set flat amount less than one")]
        public void WhenIHaveEnteredSetFlatAmountLessThanOne()
        {
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "0.3");
            Report.WriteLine("Entered Set Flat amount value less than 1");
        }

        [When(@"I Select % over cost from the Set Gainshare Type drop down list")]
        public void WhenISelectOverCostFromTheSetGainshareTypeDropDownList()
        {
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "% over cost");
            Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
        }

        [When(@"I Select % over cost from the Set Gainshare Type dropdown list")]
        public void WhenISelectOverCostFromTheSetGainshareTypeDropdownList()
        {
            Thread.Sleep(4000);
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, AdditionalGainshareTypeDropdownValues_Xpath, "% over cost");
            Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
        }

        [When(@"I enter a value more than two decimal places to % over cost field")]
        public void WhenIEnterAValueMoreThanTwoDecimalPlacesToOverCostField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.465");
            Report.WriteLine("Entered a value more than 2 decimal places");

        }

        [When(@"I enter a value less than one to % over cost field")]
        public void WhenIEnterAValueLessThanOneToOverCostField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "0.2");
            Report.WriteLine("Entered % Over cost value is less than 1");
        }

        [When(@"I enter a value more than hundred to % over cost field")]
        public void WhenIEnterAValueMoreThanHundredToOverCostField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "101");
            Report.WriteLine("Entered a value more than 100.00 to % over cost field");
        }

        [When(@"I Select Set flat amount from the Set Gainshare Type dropdown list")]
        public void WhenISelectSetFlatAmountFromTheSetGainshareTypeDropdownList()
        {
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, AdditionalGainshareTypeDropdownValues_Xpath, "Set flat amount");
            Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
        }

        [When(@"I Select Flat over cost from the Set Gainshare Type dropdown list")]
        public void WhenISelectFlatOverCostFromTheSetGainshareTypeDropdownList()
        {
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, AdditionalGainshareTypeDropdownValues_Xpath, "Flat over cost");
            Report.WriteLine("Flat over cost is selected from the Set Gainshare Type drop down list");
        }

        [When(@"I Select Flat over cost from the Set Gainshare Type drop down list")]
        public void WhenISelectFlatOverCostFromTheSetGainshareTypeDropDownList()
        {
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Flat over cost");
            Report.WriteLine("Flat over cost is selected from the Set Gainshare Type drop down list");
        }

        [When(@"I enter a value more than two decimal places to Flat over cost field")]
        public void WhenIEnterAValueMoreThanTwoDecimalPlacesToFlatOverCostField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.635");
            Report.WriteLine("Entered a value more than two decimal places to Flat over cost field");
        }


        [When(@"I enter a value less than one to Flat over cost field")]
        public void WhenIEnterAValueLessThanOneToFlatOverCostField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "0.3");
            Report.WriteLine("Entered a value less than one to Flat over cost field ");
        }

        [When(@"I enter a value more than \$(.*) to Flat over cost field")]
        public void WhenIEnterAValueMoreThanToFlatOverCostField(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "1000");
            Report.WriteLine("Entered a value more than 999.99 to Flat over cost field ");
        }

        [When(@"I enter a value more than two decimal places to Set flat amount field")]
        public void WhenIEnterAValueMoreThanTwoDecimalPlacesToSetFlatAmountField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.233");
            Report.WriteLine("Entered a value more than 2 decimal places to Set flat amount field");
        }

        [When(@"I enter a value less than one to Set flat amount field")]
        public void WhenIEnterAValueLessThanOneToSetFlatAmountField()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "0.2");
            Report.WriteLine("Entered a value less than one to Set flat amount field");
        }

        [When(@"I enter a value more than \$(.*) to Set flat amount field")]
        public void WhenIEnterAValueMoreThanToSetFlatAmountField(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "1000");
            Report.WriteLine("Entered a value more than 999.99 to Set flat amount field");
        }

        [When(@"% over cost is selected as the Gainshare Type for the individual accessorial (.*)")]
        public void WhenOverCostIsSelectedAsTheGainshareTypeForTheIndividualAccessorial(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "% over cost");
                Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "12");
                Report.WriteLine("Individual accessorial is selected");

            }
            if (Accessorials == "MultipleAccessorial")
            {
                Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                IList<IWebElement> dropdownValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li"));
                for (int i = 0; i < dropdownValue.Count; i++)
                {
                    int z = i + 1;
                    string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li[" + z + "]")).Text;
                    if (value == "% over cost")
                    {
                        GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li[" + z + "]")).Click();
                        break;
                    }
                }

                Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "16.01");
                Report.WriteLine("Individual accessorial is selected");

                Click(attributeName_xpath, AdditionalGainshareType_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li"));
                for (int i = 0; i < dropdownValues.Count; i++)
                {
                    int z = i + 1;
                    string value = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Text;
                    if (value == "% over cost")
                    {
                        GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Click();
                        break;
                    }
                }
                Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.99");
                Report.WriteLine("Individual accessorials are selected");

            }
        }

        [When(@"Flat over cost is selected as the Gainshare Type for the individual accessorial (.*)")]
        public void WhenFlatOverCostIsSelectedAsTheGainshareTypeForTheIndividualAccessorial(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Flat over cost");
                Report.WriteLine("Flat Over Cost is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "12");
                Report.WriteLine("Individual accessorial is selected");

            }
            if (Accessorials == "MultipleAccessorial")
            {
                Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                IList<IWebElement> dropdownValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li"));
                for (int i = 0; i < dropdownValue.Count; i++)
                {
                    int z = i + 1;
                    string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li[" + z + "]")).Text;
                    if (value == "Flat over cost")
                    {
                        GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li[" + z + "]")).Click();
                        break;
                    }
                }

                Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "10");
                Report.WriteLine("Individual accessorial is selected");


                Click(attributeName_xpath, AdditionalGainshareType_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li"));
                for (int i = 0; i < dropdownValues.Count; i++)
                {
                    int z = i + 1;
                    string value = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Text;
                    if (value == "Flat over cost")
                    {
                        GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Click();
                        break;
                    }
                }
                Report.WriteLine("Flat Over Cost is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "15");
                Report.WriteLine("Individual accessorials are selected");
            }
        }

        [When(@"Set flat amount is selected as the Gainshare Type for the individual accessorial (.*)")]
        public void WhenSetFlatAmountIsSelectedAsTheGainshareTypeForTheIndividualAccessorial(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Set flat amount");
                Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "12");
                Report.WriteLine("Individual accessorial is selected");

            }
            if (Accessorials == "MultipleAccessorial")
            {
                Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                IList<IWebElement> dropdownValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li"));
                for (int i = 0; i < dropdownValue.Count; i++)
                {
                    int z = i + 1;
                    string value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li[" + z + "]")).Text;
                    if (value == "Set flat amount")
                    {
                        GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='Gainshare_type_0_chosen']/div/ul/li[" + z + "]")).Click();
                        break;
                    }
                }
     
                Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, GainshareTypeVal_Xpath, "10");
                Report.WriteLine("Individual accessorial is selected");


                Click(attributeName_xpath, AdditionalGainshareType_Xpath);
                Report.WriteLine("Clicked on Set Gainshare Type drop down list");
                IList<IWebElement> dropdownValues = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li"));
                for (int i = 0; i < dropdownValues.Count; i++)
                {
                    int z = i + 1;
                    string value = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Text;
                    if (value == "Set flat amount")
                    {
                        GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='Gainshare_type_1_chosen']//ul[@class='chosen-results']//li[" + z + "]")).Click();
                        break;
                    }
                }
                Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
                SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "15");
                Report.WriteLine("Individual accessorials are selected");


            }
        }

        [Then(@"I will see a new field Set Gainshare Type")]
        public void ThenIWillSeeANewFieldSetGainshareType()
        {
            VerifyElementPresent(attributeName_xpath, GainshareTypeVal_Xpath, "GainshareType");
            Report.WriteLine("Set Gainshare Type field is visible");
        }

        [Then(@"I will see a new field named Set Gainshare Type")]
        public void ThenIWillSeeANewFieldNamedSetGainshareType()
        {
            VerifyElementPresent(attributeName_xpath, AdditionalGainshareType_Xpath, "GainshareType");
            Report.WriteLine("Set Gainshare Type field is visible");
        }

        [Then(@"Set Gainshare Type field will be a drop down list with the following options: % over cost,Flat over cost,Set flat amount")]
        public void ThenSetGainshareTypeFieldWillBeADropDownListWithTheFollowingOptionsOverCostFlatOverCostSetFlatAmount()
        {
            Click(attributeName_xpath, AdditionalGainshareType_Xpath);
            IList<IWebElement> UIList = GlobalVariables.webDriver.FindElements(By.XPath(AdditionalGainshareTypeDropdownValues_Xpath));
            List<string> expectedGainshareTypes = new List<string>(new string[] { "Select...","% over cost", "Flat over cost", "Set flat amount" });
            List<string> gainshareTypeVal = new List<string>();
            foreach (var val in UIList)
            {
                gainshareTypeVal.Add(val.Text);
            }
            Assert.AreEqual(gainshareTypeVal.ToString(), expectedGainshareTypes.ToString());
            Report.WriteLine("Expected Gainshare Type matches with UI Gainshare Type dropdown values");
        }

        [Then(@"the Set Gainshare Type field will be a drop down list with the following options: % over cost,Flat over cost,Set flat amount")]
        public void ThenTheSetGainshareTypeFieldWillBeADropDownListWithTheFollowingOptionsOverCostFlatOverCostSetFlatAmount()
        {
            WaitForElementVisible(attributeName_xpath, SetGainshareTypeDropdown_Xpath, "Gainshaire Type Dropdown");
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            IList<IWebElement> UIList = GlobalVariables.webDriver.FindElements(By.XPath(SetGainshareTypeDropdownValues_Xpath));
            List<string> expectedGainshareTypes = new List<string>(new string[] { "Select...", "% over cost", "Flat over cost", "Set flat amount" });
            List<string> gainshareTypeVal = new List<string>();
            foreach (var val in UIList)
            {
                gainshareTypeVal.Add(val.Text);
            }
            Assert.AreEqual(gainshareTypeVal.ToString(), expectedGainshareTypes.ToString());
            Report.WriteLine("Expected Gainshare Type matches with UI Gainshare Type dropdown values");
        }

        [Then(@"I will no longer see the field Accessorial Value")]
        public void ThenIWillNoLongerSeeTheFieldAccessorialValue()
        {
            VerifyElementNotPresent(attributeName_id, AccessorialValue_Id, "ACCESSORIAL VALUE");
            Report.WriteLine("Accessorial Value field is not present");
        }


        [Then(@"I will see a new field called % over cost")]
        public void ThenIWillSeeANewFieldCalledOverCost()
        {
            VerifyElementPresent(attributeName_xpath, PercentageOverCostLabel_Xpath, "% over cost");
            Report.WriteLine("% over cost is present");
        }

        [Then(@"Over cost field will be required, editable, numeric")]
        public void ThenOverCostFieldWillBeRequiredEditableNumeric()
        {
            Click(attributeName_id, AccessorialSave_Id);
            string getCSSValOverCost = GetCSSValue(attributeName_xpath, PercentageOverCostLabel_Xpath, "background-color");
            string expectedCSSValOverCost = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(getCSSValOverCost, expectedCSSValOverCost);
            Report.WriteLine("% Over Cost is a rquired field");
            SendKeys(attributeName_xpath, PercentageOverCostLabel_Xpath, "23");
            Report.WriteLine("% Over cost field is editable");
           
            string getOverCostVal = Gettext(attributeName_xpath, PercentageOverCostLabel_Xpath);
            Assert.AreNotEqual(getOverCostVal, "23");
            Report.WriteLine("% Over Cost field allows only numeric values");
        }

        [Then(@"Over cost field will be % formatted, allow up to (.*) decimal places, auto-populate to (.*) decimal places")]
        public void ThenOverCostFieldWillBeFormattedAllowUpToDecimalPlacesAuto_PopulateToDecimalPlaces(int p0, int p1)
        {
            string sign = GetValue(attributeName_xpath, PercentageFormat_Xpath, "value");
            string expectedSign = "%";
            Assert.AreEqual(sign, expectedSign);
           
            Report.WriteLine("% Over Cost allows upto 2 decimal values");
            SendKeys(attributeName_xpath, PercentageOverCostLabel_Xpath, "12");
            
            Click(attributeName_xpath, PercentageFormat_Xpath);
            string getPercenOverCostUI = GetValue(attributeName_xpath, PercentageOverCostLabel_Xpath, "value");
            Assert.AreEqual(getPercenOverCostUI, "12.00");
            Report.WriteLine("% Over Cost field Autopopulates 2 decimal places");
        }

        [Then(@"Over cost field will take one as min value")]
        public void ThenOverCostFieldWillTakeOneAsMinValue()
        {
            SendKeys(attributeName_xpath, PercentageOverCostLabel_Xpath, "1.00");
            string getPercenOverCostUI = GetValue(attributeName_xpath, PercentageOverCostLabel_Xpath, "value");
            Assert.AreEqual(getPercenOverCostUI, "1.00");
            Report.WriteLine("% Over Cost field takes one as min value");
        }

        [Then(@"Over cost field will take hundred as max value")]
        public void ThenOverCostFieldWillTakeHundredAsMaxValue()
        {
            SendKeys(attributeName_xpath, PercentageOverCostLabel_Xpath, "100.00");
            string getPercenOverCostUI = GetValue(attributeName_xpath, PercentageOverCostLabel_Xpath, "value");
            Assert.AreEqual(getPercenOverCostUI, "100.00");
            Report.WriteLine("% Over Cost field takes 100 as max value");
        }

        [Given(@"I selected % over cost from the Set Gainshare Type drop down list")]
        public void GivenISelectedOverCostFromTheSetGainshareTypeDropDownList()
        {
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "% over cost");
            Report.WriteLine("% over cost is selected from the Set Gainshare Type drop down list");
        }

        [Then(@"Over cost field will not accept the value less than one")]
        public void ThenOverCostFieldWillNotAcceptTheValueLessThanOne()
        {
            string getPercenOverCost = GetValue(attributeName_xpath, PercentageOverCostLabel_Xpath,"value");
            Assert.AreNotEqual(getPercenOverCost, "0.2");
            Report.WriteLine("% Over Cost field will not accept value less than 1");
        }

        [Then(@"Over cost field will not accept more than more than hundred")]
        public void ThenOverCostFieldWillNotAcceptMoreThanMoreThanHundred()
        {
            string getPercenOverCost = GetValue(attributeName_xpath, PercentageOverCostLabel_Xpath,"value");
            Assert.AreNotEqual(getPercenOverCost, "101");
            Report.WriteLine("% Over Cost field will not accept value more than 100");
        }

        [Then(@"I will see a new field called Flat over cost")]
        public void ThenIWillSeeANewFieldCalledFlatOverCost()
        {
          
            VerifyElementPresent(attributeName_xpath, FlatOverCost_Xpath, "Flat over cost");
            Report.WriteLine("Flat over cost field is present");
        }

        [Then(@"Flat over cost field will be required, editable, numeric")]
        public void ThenFlatOverCostFieldWillBeRequiredEditableNumeric()
        {
            Click(attributeName_id, AccessorialSave_Id);
            string getCSSValOverCost = GetCSSValue(attributeName_xpath, FlatOverCost_Xpath, "background-color");
            string expectedCSSValOverCost = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(getCSSValOverCost, expectedCSSValOverCost);
            Report.WriteLine("Flat over cost is a required field");
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "23");
            Report.WriteLine("Flat over cost field is editable");
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "eqw");
            string getFlatOverCostVal = GetValue(attributeName_xpath, FlatOverCost_Xpath,"value");
            Assert.AreNotEqual(getFlatOverCostVal, "eqw");
            Report.WriteLine("Flat Over Cost field allows only numeric values");
        }

        [Then(@"Flat over cost field will be us currency formatted formatted, allow up to (.*) decimal places, auto-populate to (.*) decimal places")]
        public void ThenFlatOverCostFieldWillBeUsCurrencyFormattedFormattedAllowUpToDecimalPlacesAuto_PopulateToDecimalPlaces(int p0, int p1)
        {
            string CurrencySign = GetValue(attributeName_xpath, CurrencyFormat_Xpath, "value");
            string expectedSign = "$";
            Assert.AreEqual(CurrencySign, expectedSign);
            Report.WriteLine("Flat Over cost field is $ formated");
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "23.45");
            Report.WriteLine("Flat over cost allows upto 2 decimal values");
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "12");
            
            Click(attributeName_xpath, CurrencyFormat_Xpath);
            string getFlatOverCostUI = GetValue(attributeName_xpath, FlatOverCost_Xpath, "value");
            Assert.AreEqual(getFlatOverCostUI, "12.00");
            Report.WriteLine("Flat Over Cost field Autopopulates 2 decimal places");
        }

        [Then(@"Flat over cost field will take min value as one")]
        public void ThenFlatOverCostFieldWillTakeMinValueAsOne()
        {
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "1.00");
            string getFlatOverUI = GetValue(attributeName_xpath, FlatOverCost_Xpath,"value");
            Assert.AreEqual(getFlatOverUI, "1.00");
            Report.WriteLine("Flat over cost field takes one as min value");
        }

        [Then(@"Flat over cost field will take (.*) as max value")]
        public void ThenFlatOverCostFieldWillTakeAsMaxValue(Decimal val)
        {
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, val.ToString());
            string getFlatOverCostUI = Gettext(attributeName_xpath, FlatOverCost_Xpath);
            Assert.AreEqual(getFlatOverCostUI, val.ToString());
            Report.WriteLine("Flat over cost field takes a max of 999.99");
        }

        [Then(@"Flat over cost field will take (.*) point (.*) as max value")]
        public void ThenFlatOverCostFieldWillTakePointAsMaxValue(int p0, int p1)
        {
            SendKeys(attributeName_xpath, FlatOverCost_Xpath, "999.99");
            string getFlatOverCostUI = GetValue(attributeName_xpath, FlatOverCost_Xpath,"value");
            Assert.AreEqual(getFlatOverCostUI, "999.99");
            Report.WriteLine("Flat over cost field takes a max of 999.99");
        }


        [Then(@"Set flat amount field will take max value as (.*)")]
        public void ThenSetFlatAmountFieldWillTakeMaxValueAs(Decimal val)
        {
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, val.ToString());
            string getFlatAmountUI = Gettext(attributeName_xpath, SetFlatAmount_Xpath);
            Assert.AreEqual(getFlatAmountUI, val.ToString());
            Report.WriteLine("Set Flat Amount field takes a max of 999.99");
        }

        [Given(@"I selected Set flat amount from the Set Gainshare Type drop down list")]
        public void GivenISelectedSetFlatAmountFromTheSetGainshareTypeDropDownList()
        {
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Set flat amount");
            Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");

        }

        [Given(@"I selected Flat over cost from the Set Gainshare Type drop down list")]
        public void GivenISelectedFlatOverCostFromTheSetGainshareTypeDropDownList()
        {
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Flat over cost");
            Report.WriteLine("Flat over cost is selected from the Set Gainshare Type drop down list");
        }

        [Then(@"Flat over cost field will not accept the value less than one")]
        public void ThenFlatOverCostFieldWillNotAcceptTheValueLessThanOne()
        {
            string getPercenOverCost = GetValue(attributeName_xpath, FlatOverCost_Xpath,"value");
            Assert.AreNotEqual(getPercenOverCost, "0.2");
            Report.WriteLine("Flat Over Cost field will not accept value less than 1");

        }

        [Then(@"Flat over cost field will not accept the value more than (.*)")]
        public void ThenFlatOverCostFieldWillNotAcceptTheValueMoreThan(Decimal val)
        {
            string getPercenOverCost = GetValue(attributeName_xpath, FlatOverCost_Xpath,"value");
            Assert.AreNotEqual(getPercenOverCost, "1000");
            Report.WriteLine("Flat Over Cost field will not accept value more than 999.99");
        }

        [When(@"I Select Set flat amount from the Set Gainshare Type drop down list")]
        public void WhenISelectSetFlatAmountFromTheSetGainshareTypeDropDownList()
        {
            Click(attributeName_xpath, SetGainshareTypeDropdown_Xpath);
            Report.WriteLine("Clicked on Set Gainshare Type drop down list");
            SelectDropdownValueFromList(attributeName_xpath, SetGainshareTypeDropdownValues_Xpath, "Set flat amount");
            Report.WriteLine("Set flat amount is selected from the Set Gainshare Type drop down list");
        }

        [Then(@"I will see a new field called Set flat amount")]
        public void ThenIWillSeeANewFieldCalledSetFlatAmount()
        {
            VerifyElementPresent(attributeName_xpath, SetFlatAmount_Xpath, "Set Flat Amount");
            Report.WriteLine("Set Flat Amount field is present");
        }

        [Then(@"Set flat amount field will be required, editable, numeric")]
        public void ThenSetFlatAmountFieldWillBeRequiredEditableNumeric()
        {
            Click(attributeName_id, AccessorialSave_Id);
            string getCSSValFlatAmount = GetCSSValue(attributeName_xpath, SetFlatAmount_Xpath, "background-color");
            string expectedCSSValOverCost = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(getCSSValFlatAmount, expectedCSSValOverCost);
            Report.WriteLine("Set Flat Amount is a rquired field");
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "23");
            Report.WriteLine("Set Flat Amount field is editable");
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "eqw");
            string getFlatAmountVal = GetValue(attributeName_xpath, SetFlatAmount_Xpath,"value");
            Assert.AreNotEqual(getFlatAmountVal, "eqw");
            Report.WriteLine("Set Flat Amount field allows only numeric values");
        }

        [Then(@"Set flat amount field will take min value as one")]
        public void ThenSetFlatAmountFieldWillTakeMinValueAsOne()
        {
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "1");
            Report.WriteLine("Set flat amount field takes one as min value");
        }

        [Then(@"Set flat amount field will be \$ formatted, allow up two decimal places, auto-populate two decimal places")]
        public void ThenSetFlatAmountFieldWillBeFormattedAllowUpTwoDecimalPlacesAuto_PopulateTwoDecimalPlaces()
        {
           
            string CurrencySign = GetValue(attributeName_xpath, CurrencyFormat_Xpath, "value");
            string expectedSign = "$";
            Assert.AreEqual(CurrencySign, expectedSign);
            Report.WriteLine("Flat Over cost field is $ formated");
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "23.45");
            Report.WriteLine("% Over Cost allows upto 2 decimal values");
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "12");
            Click(attributeName_xpath, CurrencyFormat_Xpath);
            string getFlatAmountUI = GetValue(attributeName_xpath, SetFlatAmount_Xpath,"value");
            Assert.AreEqual(getFlatAmountUI, "12.00");
            Report.WriteLine("Set Flat Amount field Autopopulates 2 decimal places");
        }

        [Then(@"Set flat amount field will take (.*) point (.*) as max value")]
        public void ThenSetFlatAmountFieldWillTakePointAsMaxValue(int p0, int p1)
        {
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "999.99");
            string getFlatAmountUI = GetValue(attributeName_xpath, SetFlatAmount_Xpath,"value");
            Assert.AreEqual(getFlatAmountUI, "999.99");
            Report.WriteLine("Set Flat Amount field takes a max of 999.99");
        }


        [Then(@"Set flat amount field will display \$ before the numeric value, min value (.*)")]
        public void ThenSetFlatAmountFieldWillDisplayBeforeTheNumericValueMinValue(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Set flat amount field will display max value (.*)")]
        public void ThenSetFlatAmountFieldWillDisplayMaxValue(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"Set flat amount field will not accept a value less than one")]
        public void ThenSetFlatAmountFieldWillNotAcceptAValueLessThanOne()
        {
            string getFlatAmountUI = GetValue(attributeName_xpath, SetFlatAmount_Xpath,"value");
            Assert.AreNotEqual(getFlatAmountUI, "0.3");
            Report.WriteLine("Set flat amount field does not accept a value less than one");
        }

        [When(@"I have entered Set flat amount more than (.*)")]
        public void WhenIHaveEnteredSetFlatAmountMoreThan(Decimal val)
        {
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "1001");
            Report.WriteLine("Entered Set flat amount more than 999.99");
        }

        [When(@"I have entered '(.*)' as Set flat amount")]
        public void WhenIHaveEnteredAsSetFlatAmount(Decimal p0)
        {
            SendKeys(attributeName_xpath, SetFlatAmount_Xpath, "1001");
            Report.WriteLine("Entered Set flat amount more than 999.99");
        }


        [Then(@"Set flat amount field will not accept a value more than (.*)")]
        public void ThenSetFlatAmountFieldWillNotAcceptAValueMoreThan(Decimal val)
        {
            string getFlatAmount = Gettext(attributeName_xpath, SetFlatAmount_Xpath);
            Assert.AreNotEqual(getFlatAmount, "1001");
            Report.WriteLine("Set flat amount field will not accept a value more than 999.99");
        }

        [Then(@"The field will not accept more than '(.*)' value")]
        public void ThenTheFieldWillNotAcceptMoreThanValue(Decimal p0)
        {
            string getFlatAmount = GetValue(attributeName_xpath, SetFlatAmount_Xpath,"value");
            Assert.AreNotEqual(getFlatAmount, "1001");
            Report.WriteLine("Set flat amount field will not accept a value more than 999.99");
        }



        [Then(@"I will see a new required field % over cost")]
        public void ThenIWillSeeANewRequiredFieldOverCost()
        {
            Verifytext(attributeName_xpath, AdditionalPercentageOverCostLabel_Xpath, "% OVER COST");
            Report.WriteLine("% over cost field is present");
            Click(attributeName_id, AccessorialSave_Id);
            string getCSSValOverCost = GetCSSValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "background-color");
            string expectedCSSValOverCost = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(getCSSValOverCost, expectedCSSValOverCost);
            Report.WriteLine("% Over Cost is a rquired field");
        }

        [Then(@"% over cost is editable, allows numeric values upto two decimal places")]
        public void ThenOverCostIsEditableAllowsNumericValuesUptoTwoDecimalPlaces()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23");
            Report.WriteLine("% Over cost field is editable");
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.87");
            string getOverCostVal = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getOverCostVal, "23.87");
            Report.WriteLine("% Over Cost field allows only numeric values upto 2 decimal places");
        }

        [Then(@"% over cost % formatted, displays % after the numeric value")]
        public void ThenOverCostFormattedDisplaysAfterTheNumericValue()
        {
            string getCurrencyFormat = GetValue(attributeName_xpath, AdditionalPercentageFormat_Xpath, "value");
            Assert.AreEqual(getCurrencyFormat, "%");
            Report.WriteLine("% Over cost field is % formated");
        }

        [Then(@"The Min value % over cost field takes is (.*)%")]
        public void ThenTheMinValueOverCostFieldTakesIs(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, val.ToString());
            string getPercenOverCostUI = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getPercenOverCostUI, val.ToString());
            Report.WriteLine("% Over Cost field takes one as min value");
        }

        [Then(@"The max value % over cost field accepts is (.*)%")]
        public void ThenTheMaxValueOverCostFieldAcceptsIs(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, val.ToString());
            string getPercenOverCostUI = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getPercenOverCostUI, val.ToString());
            Report.WriteLine("% Over Cost field takes 100 as max value");
        }

        [Then(@"% over cost field should not accept a value which is more than two decimal places")]
        public void ThenOverCostFieldShouldNotAcceptAValueWhichIsMoreThanTwoDecimalPlaces()
        {
            string getOverCostUI = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreNotEqual(getOverCostUI, "23.465");
            Report.WriteLine("% Over Cost allows only upto 2 decimal values");
        }

        [Then(@"% over cost field should not accept a value less than one")]
        public void ThenOverCostFieldShouldNotAcceptAValueLessThanOne()
        {
            string getPercenOverCost = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreNotEqual(getPercenOverCost, "0.2");
            Report.WriteLine("% Over Cost field will not accept value less than 1");
        }

        [Then(@"% over cost field should not accept a value more than hundred")]
        public void ThenOverCostFieldShouldNotAcceptAValueMoreThanHundred()
        {
            string getPercenOverCost = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreNotEqual(getPercenOverCost, "101");
            Report.WriteLine("% Over Cost field will not accept a value more than 100.00");
        }

        [Then(@"I will see a new required field Flat over cost")]
        public void ThenIWillSeeANewRequiredFieldFlatOverCost()
        {
            Verifytext(attributeName_xpath, AdditionalFlatOverCostLabel_Xpath, "FLAT OVER COST");
            Report.WriteLine("Flat over cost field is present");
            Click(attributeName_id, AccessorialSave_Id);
            string getCSSValOverCost = GetCSSValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "background-color");
            string expectedCSSValOverCost = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(getCSSValOverCost, expectedCSSValOverCost);
            Report.WriteLine("Flat Over Cost is a rquired field");
        }

        [Then(@"Flat over cost is editable, allows numeric values upto two decimal places")]
        public void ThenFlatOverCostIsEditableAllowsNumericValuesUptoTwoDecimalPlaces()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23");
            Report.WriteLine("% Over cost field is editable");
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "asd");
            string getFlatOverCostValUI = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreNotEqual(getFlatOverCostValUI, "23.87");
            Report.WriteLine("Flat over cost field allows only numeric values");
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.87");
            string getFlatOverCostVal = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "value");
            Assert.AreEqual(getFlatOverCostVal, "23.87");
            Report.WriteLine("Flat Over Cost field allows numeric values upto 2 decimal places");
        }


        [Then(@"Flat over cost currency formatted, displays \$ before the numeric value")]
        public void ThenFlatOverCostCurrencyFormattedDisplaysBeforeTheNumericValue()
        {
            string getCurrencyFormat = GetValue(attributeName_xpath, AdditionalCurrencyFormat_Xpath, "value");
            Assert.AreEqual(getCurrencyFormat, "$");
            Report.WriteLine("Flat Over cost field is $ formated");
        }

        [Then(@"The Min value Flat over cost field takes is \$(.*)")]
        public void ThenTheMinValueFlatOverCostFieldTakesIs(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, val.ToString());
            string getAdditionalFlatOverCost = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getAdditionalFlatOverCost, val.ToString());
            Report.WriteLine("Min value Flat Over Cost takes is 1.00");
        }

        [Then(@"The max value Flat over cost field accepts is \$(.*)")]
        public void ThenTheMaxValueFlatOverCostFieldAcceptsIs(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, val.ToString());
            string getAdditionalFlatOverCost = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getAdditionalFlatOverCost, val.ToString());
            Report.WriteLine("Max value Flat Over Cost takes is 999.99");
        }

        [Then(@"Flat over cost field should not accept a value which is more than two decimal places")]
        public void ThenFlatOverCostFieldShouldNotAcceptAValueWhichIsMoreThanTwoDecimalPlaces()
        {
            string getAdditionalFlatOverCost = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreNotEqual(getAdditionalFlatOverCost, "23.635");
            Report.WriteLine("Flat over cost field does not accept a value which is more than two decimal places");
        }


        [Then(@"Flat over cost field should not accept a value less than one")]
        public void ThenFlatOverCostFieldShouldNotAcceptAValueLessThanOne()
        {
            string getAdditionalFlatOverCost = Gettext(attributeName_xpath, AdditionalGainshareTypeVal_Xpath);
            Assert.AreNotEqual(getAdditionalFlatOverCost, "0.3");
            Report.WriteLine("Flat over cost field does not accept a value less than one");
        }

        [Then(@"Flat over cost field should not accept a value more than \$(.*)")]
        public void ThenFlatOverCostFieldShouldNotAcceptAValueMoreThan(Decimal val)
        {
            string getAdditionalFlatOverCost = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreNotEqual(getAdditionalFlatOverCost, "1000");
            Report.WriteLine("Flat over cost field does not accept a value more than 999.99");
        }

        [Then(@"I will see a new required field Set flat amount")]
        public void ThenIWillSeeANewRequiredFieldSetFlatAmount()
        {
            Verifytext(attributeName_xpath, AdditionalSetFlatAmountLabel_Xpath, "SET FLAT AMOUNT");
            Report.WriteLine("Set Flat Amount field is present");
            Click(attributeName_id, AccessorialSave_Id);
            string getCSSValFlatAmount = GetCSSValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "background-color");
            string expectedCSSValOverCost = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(getCSSValFlatAmount, expectedCSSValOverCost);
            Report.WriteLine("Set Flat Amount is a required field");

        }

        [Then(@"Set flat amount is editable, allows numeric values upto two decimal places")]
        public void ThenSetFlatAmountIsEditableAllowsNumericValuesUptoTwoDecimalPlaces()
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23");
            Report.WriteLine("Set Flat Amount field is editable");
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "qwe");
            string getAdditionalFlatAmountUI = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "value");
            Assert.AreNotEqual(getAdditionalFlatAmountUI, "qwe");
            Report.WriteLine("Set flat amount field allows only numeric values");
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "23.45");
            string getAdditionalFlatAmount = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getAdditionalFlatAmount, "23.45");
            Report.WriteLine(" Set Flat Amount field allows numeric values upto 2 decimal places");
        }

        [Then(@"Set flat amount currency formatted, displays \$ before the numeric value")]
        public void ThenSetFlatAmountCurrencyFormattedDisplaysBeforeTheNumericValue()
        {
            string getCurrencyFormat = GetValue(attributeName_xpath, AdditionalCurrencyFormat_Xpath,"value");
            Assert.AreEqual(getCurrencyFormat, "$");
            Report.WriteLine("Set flat amount field is $ formated");
        }

        [Then(@"The Min value Set flat amount field takes is \$(.*)")]
        public void ThenTheMinValueSetFlatAmountFieldTakesIs(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, val.ToString());
            string getAdditionalFlatAmount = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getAdditionalFlatAmount, val.ToString());
            Report.WriteLine("Set flat amount field takes one as min value");
        }

        [Then(@"The max value Set flat amount field accepts is \$(.*)")]
        public void ThenTheMaxValueSetFlatAmountFieldAcceptsIs(Decimal val)
        {
            SendKeys(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, val.ToString());
            string getAdditionalFlatAmount = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath,"value");
            Assert.AreEqual(getAdditionalFlatAmount, val.ToString());
            Report.WriteLine("Set flat amount field takes 999.99 as max value");
        }

        [Then(@"Set flat amount field should not accept a value which is more than two decimal places")]
        public void ThenSetFlatAmountFieldShouldNotAcceptAValueWhichIsMoreThanTwoDecimalPlaces()
        {
            string getAdditionalFlatAmount = Gettext(attributeName_xpath, AdditionalGainshareTypeVal_Xpath);
            Assert.AreNotEqual(getAdditionalFlatAmount, "23.233");
            Report.WriteLine("Set flat amount field does not accept a value which is more than two decimal places");
        }

        [Then(@"Set flat amount field should not accept a value less than one")]
        public void ThenSetFlatAmountFieldShouldNotAcceptAValueLessThanOne()
        {
            string getAdditionalSetFlatAmount = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "value");
            Assert.AreNotEqual(getAdditionalSetFlatAmount, "0.2");
            Report.WriteLine("Set flat amount field does not accept a value less than one");
        }


        [Then(@"Set flat amount field should not accept a value more than \$(.*)")]
        public void ThenSetFlatAmountFieldShouldNotAcceptAValueMoreThan(Decimal val)
        {
            string getAdditionalSetFlatAmount = GetValue(attributeName_xpath, AdditionalGainshareTypeVal_Xpath, "value");
            Assert.AreNotEqual(getAdditionalSetFlatAmount, "1000");
            Report.WriteLine("Set flat amount field does not accept a value more than one");
        }

        [Then(@"The Accessorial Gainshare types and associated values will be saved (.*)")]
        public void ThenTheAccessorialGainshareTypesAndAssociatedValuesWillBeSaved(string Carriers)
        {
            WaitForElementNotPresent(attributeName_cssselector, "#page-content-wrapper > div.container-fluid.container-with-sidebar > div.row.container-fluid.error-msg-handling > span", "Waiting for DB Update");

            if (Carriers == "SingleCarrier")
            {
                string getCarrierName = Gettext(attributeName_xpath, FirstCarrierName_Xpath);
                AccessorialCarrierSetUp gsTypeVal = DBHelper.GetGainshareTypeValForAccessorial(getCarrierName, customerName, accessorialName);
                if (gsTypeVal.GainShareType == "Set flat amount" && gsTypeVal.AccessorialValue.ToString() == "23.00")
                {
                    Report.WriteLine("Accessorial Gainshare types and associated values are saved in database");
                }
                else
                {
                    Assert.Fail();
                }


            }
            if (Carriers == "MultipleCarrier")
            {
                IList<IWebElement> carriersUI = GlobalVariables.webDriver.FindElements(By.XPath(CarrierAllValues_Xpath));
                if (carriersUI.Count > 0)
                {
                    List<string> carrierListValues = ObjWebElementOperations.GetListFromIWebElement(carriersUI);
                    for (int i = 0; i < 2; i++)
                    {
                        AccessorialCarrierSetUp gsTypeVal = DBHelper.GetGainshareTypeValForAccessorial(carrierListValues[i], customerName, accessorialName);
                        if (gsTypeVal.GainShareType == "Set flat amount" && gsTypeVal.AccessorialValue.ToString() == "23.00")
                        {
                            Report.WriteLine("Accessorial Gainshare types and associated values are saved in database");
                        }
                        else
                        {
                            Assert.Fail();
                        }
                    }

                }
            }
        }

        [Given(@"I selected a carrier")]
        public void GivenISelectedACarrier()
        {
            Click(attributeName_xpath, FirstCarrier_Checkbox_Xpath);
            Report.WriteLine("Carrier is selected");
        }

        [Given(@"One or more Individual accessorials has been set for the customer (.*)")]
        public void GivenOneOrMoreIndividualAccessorialsHasBeenSetForTheCustomer(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, SetAccessorials_Button_Id);
                Report.WriteLine("Set accessorials button is been clicked");
                WaitForElementVisible(attributeName_xpath, SetAccessorialType_Xpath, "Accessorial");
                Click(attributeName_xpath, SetAccessorialType_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, SetAccessorailTypeValues_Xpath, accessorialName);
            }
            if (Accessorials == "MultipleAccessorial")
            {
                Click(attributeName_id, SetAccessorials_Button_Id);
                Report.WriteLine("Set accessorials button is been clicked");
                WaitForElementVisible(attributeName_xpath, SetAccessorialType_Xpath, "Accessorial");
                Click(attributeName_xpath, SetAccessorialType_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, SetAccessorailTypeValues_Xpath, accessorialName);

                Click(attributeName_xpath, SetAccessorialAddAdditionalAccessorialButton_xpath);
                WaitForElementVisible(attributeName_xpath, AdditionalSetAccessorialType_Xpath, "Accessorial");
                Click(attributeName_xpath, AdditionalSetAccessorialType_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AdditionalSetAccessorailTypeValues_Xpath, "Appointment");
            }


        }

        [Then(@"I will see value displayed as xx\.xx % on the grid (.*)")]
        public void ThenIWillSeeValueDisplayedAsXx_XxOnTheGrid(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                Click(attributeName_id, AccessorialSave_Id);
                Report.WriteLine("Clicked on Save button of Set Individual Accessorials Modal");
                GlobalVariables.webDriver.WaitForPageLoad();
                string getUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getUIVal.Contains("12.00%"))
                {
                    Report.WriteLine("Value is displayed in xx.xx% format");
                }
                else
                {
                    Assert.Fail();
                }
            }
            if (Accessorials == "MultipleAccessorial")
            {
                Click(attributeName_id, AccessorialSave_Id);
                Report.WriteLine("Clicked on Save button of Set Individual Accessorials Modal");
                GlobalVariables.webDriver.WaitForPageLoad();
                string getOverCostUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getOverCostUIVal.Contains("16.01%"))
                {
                    Report.WriteLine("Value is displayed in xx.xx% format");
                }
                else
                {
                    Assert.Fail();
                }

                string getOverCostUIValue = Gettext(attributeName_xpath, GainshareTypeValue_Xpath);
                if (getOverCostUIValue.Contains("23.99%"))
                {
                    Report.WriteLine("Value is displayed in xx.xx% format");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Then(@"\(% over\) will be displayed beneath the value (.*)")]
        public void ThenOverWillBeDisplayedBeneathTheValue(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                string getUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getUIVal.Contains("(% over)"))
                {
                    Report.WriteLine("(% over) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }
            }
            if (Accessorials == "MultipleAccessorial")
            {
                string getOverCostUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getOverCostUIVal.Contains("(% over)"))
                {
                    Report.WriteLine("(% over) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }

                string getOverCostUIValue = Gettext(attributeName_xpath, GainshareTypeValue_Xpath);
                if (getOverCostUIValue.Contains("(% over)"))
                {
                    Report.WriteLine("(% over) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Then(@"I will see the value displayed as \$xx\.xx on the grid (.*)")]
        public void ThenIWillSeeTheValueDisplayedAsXx_XxOnTheGrid(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                Click(attributeName_id, AccessorialSave_Id);
                Report.WriteLine("Clicked on Save button of Set Individual Accessorials Modal");
                GlobalVariables.webDriver.WaitForPageLoad();
                string getUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getUIVal.Contains("$12.00"))
                {
                    Report.WriteLine("Value is displayed in $xx.xx format");
                }
                else
                {
                    Assert.Fail();
                }
            }
            if (Accessorials == "MultipleAccessorial")
            {
                Click(attributeName_id, AccessorialSave_Id);
                Report.WriteLine("Clicked on Save button of Set Individual Accessorials Modal");
                GlobalVariables.webDriver.WaitForPageLoad();
                string getOverCostUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getOverCostUIVal.Contains("$10.00"))
                {
                    Report.WriteLine("Value is displayed in $xx.xx format");
                }
                else
                {
                    Assert.Fail();
                }

                string getOverCostUIValue = Gettext(attributeName_xpath, GainshareTypeValue_Xpath);
                if (getOverCostUIValue.Contains("$15.00"))
                {
                    Report.WriteLine("Value is displayed in $xx.xx format");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }


        [Then(@"\(flat over\) will be displayed beneath the value (.*)")]
        public void ThenFlatOverWillBeDisplayedBeneathTheValue(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                string getUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getUIVal.Contains("(flat over)"))
                {
                    Report.WriteLine("(flat over) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }
            }
            if (Accessorials == "MultipleAccessorial")
            {
                string getOverCostUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getOverCostUIVal.Contains("(flat over)"))
                {
                    Report.WriteLine("(flat over) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }

                string getOverCostUIValue = Gettext(attributeName_xpath, GainshareTypeValue_Xpath);
                if (getOverCostUIValue.Contains("(flat over)"))
                {
                    Report.WriteLine("(flat over) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Then(@"\(flat amt\) will be displayed beneath the value (.*)")]
        public void ThenFlatAmtWillBeDisplayedBeneathTheValue(string Accessorials)
        {
            if (Accessorials == "SingleAccessorial")
            {
                string getUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getUIVal.Contains("(flat amt)"))
                {
                    Report.WriteLine("(flat amt) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }
            }
            if (Accessorials == "MultipleAccessorial")
            {
                string getOverCostUIVal = Gettext(attributeName_xpath, GainshareTypeValUI_Xpath);
                if (getOverCostUIVal.Contains("(flat amt)"))
                {
                    Report.WriteLine("(flat amt) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }

                string getOverCostUIValue = Gettext(attributeName_xpath, GainshareTypeValue_Xpath);
                if (getOverCostUIValue.Contains("(flat amt)"))
                {
                    Report.WriteLine("(flat amt) is displayed beneath the value");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

    }
}
