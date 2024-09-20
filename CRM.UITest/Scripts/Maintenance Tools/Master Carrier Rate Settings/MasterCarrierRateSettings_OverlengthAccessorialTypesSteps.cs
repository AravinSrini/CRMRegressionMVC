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
    public class MasterCarrierRateSettings_OverlengthAccessorialTypesSteps : MaintenaceTools
    {
        CommonmethodFocus Focus = new CommonmethodFocus();
        string OverLVal = "12.00";
        string CustomerCarrier = "ZZZ - GS Customer Test";
        List<string> overLengthValueUI = new List<string>();
      //  MasterCarrierRateSettings_OverlengthAccessorialTypesSteps OVLVal = new MasterCarrierRateSettings_OverlengthAccessorialTypesSteps();


        [Given(@"I am a pricing configuration or config manager user")]
        public void GivenIAmAPricingConfigurationOrConfigManagerUser()
        {
            string username = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            string password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"A Gainshare customer has been selected on Master Carrier Rate settings page")]
        public void GivenAGainshareCustomerHasBeenSelectedOnMasterCarrierRateSettingsPage()
        {
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, Pricing_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings page");
            Report.WriteLine("I am on Master Carrier Rate Settings page");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, CustomerCarrier);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected a Gainshare Customer from Customer Dropdown");
        }

        [Given(@"Set Accessorials button has been clicked by selecting one or more carriers")]
        public void GivenSetAccessorialsButtonHasBeenClickedBySelectingOneOrMoreCarriers()
        {
            Click(attributeName_xpath, FirstCarrierSelect_Xpath);
            Report.WriteLine("Carrier is selected");
            Click(attributeName_id, SetAccessorials_Button_Id);
            Report.WriteLine("Set accessorials button is been clicked");
        }
        
        [Given(@"Overlength has been selected as Set Accessorial Type field")]
        public void GivenOverlengthHasBeenSelectedAsSetAccessorialTypeField()
        {
            Thread.Sleep(3000);
            Click(attributeName_xpath, AccessorialType_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AccessorialType_DropdownValues_Xpath, "Overlength");
            Report.WriteLine("Overlength is selected as Accessorial Type");

        }

        [Given(@"Valid data has been passed to Overlength type fields")]
        public void GivenValidDataHasBeenPassedToOverlengthTypeFields()
        {
            PassOverlengthVal();
            Report.WriteLine("Data is passed to Overlength fields");
        }
        
        [Given(@"One or more Carriers has been selected which has accessorial Overlength associated")]
        public void GivenOneOrMoreCarriersHasBeenSelectedWhichHasAccessorialOverlengthAssociated()
        {
            Click(attributeName_xpath, ThirdCarrier_Checkbox_Xpath);
            Report.WriteLine("Carrier is selected");
            Click(attributeName_id, SetAccessorials_Button_Id);
            Thread.Sleep(3000);
            Click(attributeName_xpath, AccessorialType_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AccessorialType_DropdownValues_Xpath, "Overlength");
            PassOverlengthVal();
            Click(attributeName_id, AccessorialSave_Id);
            Thread.Sleep(3000);
            Click(attributeName_xpath, ThirdCarrier_Checkbox_Xpath);
            Thread.Sleep(3000);

        }

        [Given(@"Overlength accessorial has been selected from the list of Delete Individual Accessorials modal by clicking on Delete Accessorials button")]
        public void GivenOverlengthAccessorialIsBeenSelectedFromTheListOfDeleteIndividualAccessorialsModalByClickingOnDeleteAccessorialsButton()
        {
            Thread.Sleep(3000);
            Click(attributeName_id, DeleteAccessorialButton_Id);
            Thread.Sleep(3000);
            Click(attributeName_xpath, DeleteOverlengthOption_Xpath);
            Report.WriteLine("Overlength Type is chosen to delete");
           
        }

        [When(@"I click on Delete button")]
        public void WhenIClickOnDeleteButton()
        {
            Thread.Sleep(3000);
            Click(attributeName_xpath, DeleteAccessButtonModal_Xpath);
            Report.WriteLine("Accessorial Delete button is clicked from the modal");
        }


        [When(@"I select Overlength in the Set Accessorial Type field")]
        public void WhenISelectOverlengthInTheSetAccessorialTypeField()
        {
            Thread.Sleep(2000);
            Click(attributeName_xpath, AccessorialType_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AccessorialType_DropdownValues_Xpath, "Overlength");
            Report.WriteLine("Overlength is selected as Accessorial Type");
        }
        
        [When(@"I Click on Save button without passing values to Overlength types fields")]
        public void WhenIClickOnSaveButtonWithoutPassingValuesToOverlengthTypesFields()
        {
            Click(attributeName_id, AccessorialSave_Id);
            Report.WriteLine("Clicked save button without passing values to Overlength type fields");
        }

        [When(@"I click on save button")]
        public void WhenIClickOnSaveButton()
        {
            Click(attributeName_id, AccessorialSave_Id);
            Report.WriteLine("Clicked save button");

        }

        [When(@"The selected customer has individual accessorial Overlength associated at the customer level")]
        public void WhenTheSelectedCustomerHasIndividualAccessorialOverlengthAssociatedAtTheCustomerLevel()
        {
            List<AccessorialCustomerSetUpViewModal> OverLengthCustomerValue = DBHelper.GetAccessorialOverlengthCustomerVal("testOVLSwa1");
            foreach (var v in OverLengthCustomerValue)
            {
                if (v.AccessorialCode.Contains("OVL"))
                {
                    Report.WriteLine("selected customer has individual accessorial Overlength associated at the customer level");
                }
                else
                {
                    Assert.Fail();
                }
            }



        }

        [When(@"The selected customer has individual accessorial Overlength associated at the carrier level")]
        public void WhenTheSelectedCustomerHasIndividualAccessorialOverlengthAssociatedAtTheCarrierLevel()
        {
            List<AccessorialCarrierSetUpViewModal> OverLengthCarrierValue = DBHelper.GetAccessorialOverlengthVal("AAA Cooper Transportation", "ZZZ - GS Customer Test");
            for(int i = 0; i< OverLengthCarrierValue.Count;i++)
            { 
                if (OverLengthCarrierValue[i].AccessorialCode.Contains("OVL"))
                {
                    Report.WriteLine("Selected customer has individual accessorial Overlength associated at the carrier level");
                }
                else
                {
                    Assert.Fail();
                }
            }
                
        }
        
        [Then(@"I should be able to view a list of expected Overlenth types")]
        public void ThenIShouldBeAbleToViewAListOfExpectedOverlenthTypes()
        {
            List<string> overLengthModalType = new List<string>();
            List<string> ExpectedOverlengthTypes = new List<string>(new string[] { "OVER 8", "OVER 9", "OVER 10", "OVER 11", "OVER 12", "OVER 13", "OVER 14", "OVER 15", "OVER 16", "OVER 17", "OVER 18", "OVER 19", "OVER 20", "OVER 21", "OVER 22", "OVER 23", "OVER 24", "OVER 25", "OVER 26", "OVER 27", "OVER 28", "OVER 29", "OVER 30"});
            IList<IWebElement> OverlengthTypes = GlobalVariables.webDriver.FindElements(By.XPath(OverlenthTypes_Xpath));
            foreach(IWebElement OVL in OverlengthTypes)
            {
                if(OVL.Text.Contains("OVER "))
                {
                    overLengthModalType.Add(OVL.Text);
                }
                else
                {
                    Report.WriteLine("Header values");
                }
            }

            if(overLengthModalType.ToString() == ExpectedOverlengthTypes.ToString())
            {
                Report.WriteLine("Expected Overlength types are present");
            }
            else
            {
                Assert.Fail();
            }
           
        }
        
        [Then(@"Next to each Overlength types there should be a Set Gainshare field")]
        public void ThenNextToEachOverlengthTypesThereShouldBeASetGainshareField()
        {
            VerifyElementVisible(attributeName_xpath, OverlenthGainshareInput_Xpath, "Gainshare field");
            Report.WriteLine("Set Gainshare field exists next to each overlength fields");
        }
        
        [Then(@"Each Set Gainshare field should be blank")]
        public void ThenEachSetGainshareFieldShouldBeBlank()
        {
            string GainshareFieldVal = GetValue(attributeName_xpath, OverlenthGainshareInput_Xpath, "value");
            if(GainshareFieldVal == string.Empty)
            {
                Report.WriteLine("Set Gainshare field is blank");
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Then(@"I should be able to pass values to Set Gainshare fields")]
        public void ThenIShouldBeAbleToPassValuesToSetGainshareFields()
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "11");
            Report.WriteLine("Able to pass values to Set Gainshare fields");
        }
        
        [Then(@"I should be able to enter a whole value up to (.*) numbers")]
        public void ThenIShouldBeAbleToEnterAWholeValueUpToNumbers(int p0)
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "999");
            string GetWholeNum = GetAttribute(attributeName_xpath,OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreEqual(GetWholeNum, "999");
            Report.WriteLine("Able to enter a whole value of upto 3 to Set Gainshare fields");
        }
        
        [Then(@"I should be able to enter a decimal after the whole number")]
        public void ThenIShouldBeAbleToEnterADecimalAfterTheWholeNumber()
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "12.2");
            Click(attributeName_xpath, AccessorialGainshareSymbol_Xpath);
            string GetDecimalNum = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreEqual(GetDecimalNum, "12.20");
            Report.WriteLine("Able to enter a decimal after whole number to Set Gainshare fields");
        }
        
        [Then(@"I should be able to enter upto (.*) decimal places")]
        public void ThenIShouldBeAbleToEnterUptoDecimalPlaces(int p0)
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "12.22");
            Click(attributeName_xpath, AccessorialGainshareSymbol_Xpath);
            string GetDecimalNum = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreEqual(GetDecimalNum, "12.22");
            Report.WriteLine("Able to enter 2 decimal places to Set Gainshare fields");
        }

        [Then(@"CRM will add a zero to the value when I enter only (.*) value after the decimal place")]
        public void ThenCRMWillAddAZeroToTheValueWhenIEnterOnlyValueAfterTheDecimalPlace(int p0)
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "12.2");
            Click(attributeName_xpath, AccessorialGainshareSymbol_Xpath);
            string GetDecimalNum = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreEqual(GetDecimalNum, "12.20");
            Report.WriteLine("CRM added zero to the value after decimal place when only one value is added after decimal");
        }

        [Then(@"I should be able to enter zero as a value")]
        public void ThenIShouldBeAbleToEnterZeroAsAValue()
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "0");
            Click(attributeName_xpath, AccessorialGainshareSymbol_Xpath);
            string GetZeroVal = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreEqual(GetZeroVal, "0.00");
            Report.WriteLine("Able to enter zero to Set Gainshare field");

        }

        [Then(@"I should not be able to enter a value between (.*) and (.*)")]
        public void ThenIShouldNotBeAbleToEnterAValueBetweenAnd(int p0, int p1)
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "0.11");
            string GetZeroVal = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreNotEqual(GetZeroVal, "0.11");
            Report.WriteLine("Not able to enter value between 0 and 1 to Set Gainshare field");
        }
        
        [Then(@"I should not be able to enter a negative value")]
        public void ThenIShouldNotBeAbleToEnterANegativeValue()
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "-12");
            string GetNegativeVal = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath,"value");
            Assert.AreNotEqual(GetNegativeVal, "-12");
            Report.WriteLine("Not able to enter a negative value to Set Gainshare field");

        }

        [Then(@"CRM will recognize the value as currency")]
        public void ThenCRMWillRecognizeTheValueAsCurrency()
        {
            IList<IWebElement> UIOverlengthVal = GlobalVariables.webDriver.FindElements(By.XPath(FirstCarrierOverlengthVal_Xpath));

            for (int i = 9; i < UIOverlengthVal.Count; i++)
            {
                IList<IWebElement> UIOverlengthType = GlobalVariables.webDriver.FindElements(By.XPath(FirstCarrierOverlengthVal_Xpath));
                int Count = i + 1;
                string headervalue = Gettext(attributeName_xpath, "//*[@id='CustomerTable_wrapper']/table/thead/tr/th[" + Count + "]");
                if (headervalue.Contains("OVER"))
                {
                    string UIAccess = GlobalVariables.webDriver.FindElement(By.XPath("//tr[1]//td[" + Count + "]")).Text;
                    if(UIAccess.Contains("$"))
                    {
                        Report.WriteLine("Value is currency");
                    }
                    else
                    {
                        Assert.Fail();
                    }

                }
                else
                {
                    Report.WriteLine("Accessorial Type is not Overlength");
                }


            }

        }

        [Then(@"I should see a message in red font ""(.*)""")]
        public void ThenIShouldSeeAMessageInRedFont(string p0)
        {
            Verifytext(attributeName_xpath, OverlenthValidationMessage_Xpath, "All Overlength fields required");
            string GetValidationMessageColour = GetCSSValue(attributeName_xpath, OverlenthValidationMessage_Xpath, "color");
            Assert.AreEqual("rgba(255, 0, 0, 1)", GetValidationMessageColour);
            Report.WriteLine("Validation message is displayed in red");
        }
        
        [Then(@"I should see a message stating - Please complete all required fields")]
        public void ThenIShouldSeeAMessageStating_PleaseCompleteAllRequiredFields()
        {
            Verifytext(attributeName_xpath, AccessorialValidationError_Xpath, "Please complete all required fields");
            Report.WriteLine("Validation error message is displayed");
        }
        
        [Then(@"Each field should get highlighted in red")]
        public void ThenEachFieldShouldGetHighlightedInRed()
        {
            string GetHighlightColour = GetCSSValue(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "background-color");
            string ExpecColour = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(GetHighlightColour, ExpecColour);
            Report.WriteLine("Each Gainshare field is higlighted in Red");
        }
        
        [Then(@"The focus should be to the first field that is missing data\.")]
        public void ThenTheFocusShouldBeToTheFirstFieldThatIsMissingData_()
        {
            string GainshareAccess = GetAttribute(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, "value");
            Focus.VerifyFocus(OverlenthGainshareFirstInput_Xpath, GainshareAccess);
            Report.WriteLine("Focus is to the first field that is missing data");

        }

        [Then(@"The value for each Overlength Type will be saved\.")]
        public void ThenTheValueForEachOverlengthTypeWillBeSaved_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            List<decimal> overLengthValue = new List<decimal>();
            List<AccessorialCarrierSetUpViewModal> OverLengthValue = DBHelper.GetAccessorialOverlengthVal("A&B Freight Line Inc", "ZZZ - GS Customer Test");
            foreach(var v in OverLengthValue)
            {    if (v.AccessorialCode.Contains("OVL"))
                {
                    overLengthValue.Add(v.AccessorialValue);
                }
                 else
                {
                    Report.WriteLine("AccessorialCode is not of Type Overlength");
                }
            }
            
            for(int i = 0; i< overLengthValue.Count;i++)
            {
                if(overLengthValue[i].ToString() == OverLVal)
                {
                    Report.WriteLine("Entered Overlength value is stored in DB");
                }
                else
                {
                    Assert.Fail();
                }
            }                        
        }
        
        [Then(@"I should see each overlength accessorial type displayed for each carrier")]
        public void ThenIShouldSeeEachOverlengthAccessorialTypeDisplayedForEachCarrier()
        {
            List<string> DisplayedOverlengthTypes = new List<string>();
            List<string> ExpectedOverlengthTypes = new List<string>(new string[] { "OVER 8" , "OVER 9", "OVER 10", "OVER 11", "OVER 12", "OVER 13", "OVER 14", "OVER 15", "OVER 16", "OVER 17", "OVER 18", "OVER 19", "OVER 20", "OVER 21", "OVER 22", "OVER 23", "OVER 24", "OVER 25", "OVER 26", "OVER 27", "OVER 28", "OVER 29", "OVER 30" });
            IList<IWebElement> OverlengthTypes = GlobalVariables.webDriver.FindElements(By.XPath(AccessorialOverlengthType_Xpath));
            foreach (IWebElement element in OverlengthTypes)
            {
                DisplayedOverlengthTypes.Add(element.Text);
            }
            if(DisplayedOverlengthTypes.ToString().Equals(ExpectedOverlengthTypes.ToString()))
            {
                Report.WriteLine("Overlength type is displayed for each carrier");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"I should see each overlength accessorial type value displayed for each carrier\.")]
        public void ThenIShouldSeeEachOverlengthAccessorialTypeValueDisplayedForEachCarrier_()
        {
            UIOverlengthVal();
            List<string> overLengthCarrierValue = new List<string>();
            List<AccessorialCarrierSetUpViewModal> OverLengthCarrierValue = DBHelper.GetAccessorialOverlengthVal("AAA Cooper Transportation", "ZZZ - GS Customer Test");
            foreach (var v in OverLengthCarrierValue)
            {
                if (v.AccessorialCode.Contains("OVL"))
                {
                    overLengthCarrierValue.Add(v.AccessorialValue.ToString());
                }
                else
                {
                    Assert.Fail();
                }
            }


            if (overLengthValueUI.ToString() == overLengthCarrierValue.ToString())
            {
                Report.WriteLine("Overlength values are displayed in UI");
            }
            else
            {
                Assert.Fail();
            }


        }

        [Then(@"I should see each overlength accessorial type value displayed for each carrier")]
        public void ThenIShouldSeeEachOverlengthAccessorialTypeValueDisplayedForEachCarrier()
        {
            UIOverlengthVal();
            List<string> overLengthCustomerValue = new List<string>();
            List<AccessorialCustomerSetUpViewModal> OverLengthCustomerValue = DBHelper.GetAccessorialOverlengthCustomerVal("testOVLSwa1");
            foreach (var v in OverLengthCustomerValue)
            {
                if (v.AccessorialCode.Contains("OVL"))
                {
                    overLengthCustomerValue.Add(v.AccessorialValue.ToString());
                }
                else
                {
                    Assert.Fail();

                }
            }

            if (overLengthValueUI.ToString() == overLengthCustomerValue.ToString())
            {
                Report.WriteLine("Overlength values are displayed in UI");
            }
            else
            {
                Assert.Fail();
            }

        }


        [Then(@"All Overlength accessorial types associated to the customer should be deleted\.")]
        public void ThenAllOverlengthAccessorialTypesAssociatedToTheCustomerShouldBeDeleted_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> UIOverlengthVal = GlobalVariables.webDriver.FindElements(By.XPath(ThirdCarrierOverlengthVal_Xpath));
            List<string> overLengthDelValueUI = new List<string>();
            for (int i = 9; i < UIOverlengthVal.Count; i++)
            {
                IList<IWebElement> UIOverlengthType = GlobalVariables.webDriver.FindElements(By.XPath(ThirdCarrierOverlengthVal_Xpath));
                int Count = i + 1;
                string headervalue = Gettext(attributeName_xpath, "//*[@id='CustomerTable_wrapper']/table/thead/tr/th[" + Count + "]");
                if (headervalue.Contains("OVER"))
                {
                    string UIAccess = GlobalVariables.webDriver.FindElement(By.XPath("//tr[3]//td[" + Count + "]")).Text;
                    overLengthDelValueUI.Add(UIAccess.ToString());

                }
                else
                {
                    Report.WriteLine("Accessorial Type is not Overlength");
                }


            }
            List<string> overLengthCarrierValue = new List<string>();
            List<AccessorialCarrierSetUpViewModal> OverLengthCarrierValue = DBHelper.GetAccessorialOverlengthVal("Averitt Express", "ZZZ - GS Customer Test");
            foreach (var v in OverLengthCarrierValue)
            {
                if (v.AccessorialCode.Contains("OVL"))
                {
                    overLengthCarrierValue.Add(v.AccessorialValue.ToString());
                }
                else
                {
                    Report.WriteLine("AccessorialCode is not of Type Overlength");
                }
            }
            for (int i = 0; i < overLengthDelValueUI.Count; i++)
            {
                if (overLengthDelValueUI[i].ToString() == "N/A" && overLengthCarrierValue.Count == 0)
                {
                    Report.WriteLine("All Overlength accessorial types associated to the customer is deleted");
                }
                else
                {
                    Assert.Fail();
                }
            }

        }

        [Given(@"A Gainshare customer has been selected on Master Carrier Rate settings page\.")]
        public void GivenAGainshareCustomerHasBeenSelectedOnMasterCarrierRateSettingsPage_()
        {
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, Pricing_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings page");
            Report.WriteLine("I am on Master Carrier Rate Settings page");
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerSelection_DropdownList_Xpath, "testOVLSwa1");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected a Gainshare Customer from Customer Dropdown");

        }

        public void PassOverlengthVal()
        {
            SendKeys(attributeName_xpath, OverlenthGainshareFirstInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareSecondInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareThirdInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareFourthInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareFifthInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareSixthInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareSeventhInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareEighthInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareNinethInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshareTenthInput_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare11Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare12Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare13Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare14Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare15Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare16Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare17Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare18Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare19Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare20Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare21Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare22Input_Xpath, OverLVal);
            SendKeys(attributeName_xpath, OverlenthGainshare23Input_Xpath, OverLVal);
        }


        public void UIOverlengthVal()
        {
            IList<IWebElement> UIOverlengthVal = GlobalVariables.webDriver.FindElements(By.XPath(FirstCarrierOverlengthVal_Xpath));

            for (int i = 9; i < UIOverlengthVal.Count; i++)
            {
                IList<IWebElement> UIOverlengthType = GlobalVariables.webDriver.FindElements(By.XPath(FirstCarrierOverlengthVal_Xpath));
                int Count = i + 1;
                    string headervalue = Gettext(attributeName_xpath, "//*[@id='CustomerTable_wrapper']/table/thead/tr/th[" + Count + "]");
                    if (headervalue.Contains("OVER"))
                    {
                        string UIAccess = GlobalVariables.webDriver.FindElement(By.XPath("//tr[1]//td[" + Count + "]")).Text;
                        string UIAccessVal = UIAccess.Remove(0, 1);
                        overLengthValueUI.Add(UIAccessVal.ToString());
                       
                    }
                    else
                    {
                        Report.WriteLine("Accessorial Type is not Overlength");
                    }
                

            }
        }
    }
}
