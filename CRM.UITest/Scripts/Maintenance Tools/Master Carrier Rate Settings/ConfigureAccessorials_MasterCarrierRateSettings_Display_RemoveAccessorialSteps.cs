using System.Configuration;
using System.Collections.Generic;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using System;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public class ConfigureAccessorials_MasterCarrierRateSettings_Display_RemoveAccessorialSteps : ConfigureAccessorial
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();        
        string userName = null;
        string password = null;
        string customerName = "ZZZ - Czar Customer Test";
        public WebElementOperations objWebElementOperations = new WebElementOperations();
        List<string> setAccessorialsDropdownValuesUI = null;
        string accessorialName = "46949Acc" + Guid.NewGuid().ToString();
        string accessorialServiceCode = "46949ServiceCode" + Guid.NewGuid().ToString();
        string accessorialMGDescription = "46949MGDescription" + Guid.NewGuid().ToString();
        string accessorialServiceType = "LTL";
        string accessorialDirection = "Both";        

        [Given(@"I am a pricing config or config manager user")]
        public void GivenIAmAPricingConfigOrConfigManagerUser()
        {
            userName = ConfigurationManager.AppSettings["username-SystemAdmin"].ToString();
            password = ConfigurationManager.AppSettings["password-SystemAdmin"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged in to CRM as a System Admin");
        }

        [Given(@"an accessorial was added on the Configure Accessorials page")]
        public void GivenAnAccessorialWasAddedOnTheConfigureAccessorialsPage()
        {            
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I am on the Configure Accessorials Page");
            Click(attributeName_id, configureAccessorialsButton_Id);                       
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, configureAccessorialsPageAddAccessorialButton_Id);
            Report.WriteLine("I cliked on Add Accessorial button and the Add modal is displayed");
            
            SendKeys(attributeName_id, nameTextbox_Accessorial_Id, accessorialName);
            SendKeys(attributeName_id, serviceCodeTextbox_Accessorial_Id, accessorialServiceCode);
            SendKeys(attributeName_xpath, firstMGDescriptionTextbox_Accessorial_Xpath, accessorialMGDescription);
            Click(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, serviceTypedropdown_Accessorial_Xpath, accessorialServiceType);

            if (accessorialDirection == "Ship To")
            {
                Click(attributeName_xpath, shipToRadiobutton_Xpath);
            }
            if (accessorialDirection == "Ship From")
            {
                Click(attributeName_xpath, shipFromRadiobutton_Xpath);
            }
            if (accessorialDirection == "Both")
            {
                Click(attributeName_xpath, bothRadiobutton_Xpath);
            }
            if (accessorialDirection == "None")
            {
                Click(attributeName_xpath, noneFromRadiobutton_Xpath);
            }

            Click(attributeName_id, savebutton_Accessorial_Id);
            Report.WriteLine("Accessorial " + accessorialName + " is added");
        }

        [Given(@"I am on the Master Carrier Rate Settings page")]
        public void GivenIAmOnTheMasterCarrierRateSettingsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, Pricing_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, MasterCarrierRatePage_Title_Xpath, "Master Carrier Rate Settings");
            Report.WriteLine("I am on Master Carrier Rate Settings page");
        }

        [Given(@"I selected a customer")]
        public void GivenISelectedACustomer()
        {
            Click(attributeName_xpath, CustomerSelection_DropdownBox_Xpath);
            SendKeys(attributeName_xpath, CustomerSelectionSearchField_TextBox_Xpath, "Ninjajuly");
            SelectDropdownValueFromList(attributeName_xpath, IndividualCustomers_DropdownFirstValue_Xpath, "Ninjajuly");
            GlobalVariables.webDriver.WaitForPageLoad();           
            Report.WriteLine("I selected a customer");
        }

        [Given(@"I selected one or more carriers (.*)")]
        public void GivenISelectedOneOrMoreCarriers(string numberOfCarriers)
        {
            if (numberOfCarriers.Contains("One"))
            {
                Click(attributeName_xpath, FirstCarrier_Xpath);
                Report.WriteLine("I selected a carrier");
            }
            else
            {
                Click(attributeName_xpath, SelectAllCarriers_Checkbox_Xpath);
                Report.WriteLine("I selected multiple carriers");
            }
        }

        [Given(@"I click on the Set Accessorials button")]
        public void GivenIClickOnTheSetAccessorialsButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SetAccessorial_Button_Id);           
            Report.WriteLine("I clicked on Set Accessorials button");
        }

        [Given(@"I clicked on the Add Another Accessorial button in the Set Individual Accessorials modal")]
        public void GivenIClickedOnTheAddAnotherAccessorialButtonInTheSetIndividualAccessorialsModal()
        {
            WaitForElementVisible(attributeName_xpath, Add_AnotherAccessorial_Button_Xpath, "ADD ANOTHER ACCESSORIAL");
            Click(attributeName_xpath, Add_AnotherAccessorial_Button_Xpath);
            Report.WriteLine("I clicked on the Add Another Accessorial link in the Set Individual Accessorials modal");
        }

        [Given(@"an accessorial was deleted on the Configure Accessorials page")]
        public void GivenAnAccessorialWasDeletedOnTheConfigureAccessorialsPage()
        {
            Click(attributeName_xpath, MaintenanceTools_Icon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, configureAccessorialsButton_Id);
            Report.WriteLine("I am on the Configure Accessorials Page");
            GlobalVariables.webDriver.WaitForPageLoad();
            accessorialName = Gettext(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]/td[1]");
            SendKeys(attributeName_xpath, configureAccessorialsSearchTexBox_Xpath, accessorialName);
            Click(attributeName_xpath, "//table[@id='Grid_ConfigureAccessorial']//tbody//tr[1]//div/a[2]/span");
            WaitForElementVisible(attributeName_id, deleteModalDeleteButton_Id, "Delete");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, deleteModalDeleteButton_Id);
            Report.WriteLine("I have deleted the first accessorial from the grid");
        }

        [When(@"I click in the Select Accessorial Type field of the Set Individual Accessorials modal")]
        public void WhenIClickInTheSelectAccessorialTypeFieldOfTheSetIndividualAccessorialsModal()
        {
            WaitForElementVisible(attributeName_xpath, Select_Accessorial_Type_DropDown_Xpath, "Select...");
            Click(attributeName_xpath, Select_Accessorial_Type_DropDown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Select Accessorial Type dropdown");
        }

        [When(@"I click in the second Select Accessorial Type dropdown of the Set Individual Accessorials modal")]
        public void WhenIClickInTheSecondSelectAccessorialTypeDropdownOfTheSetIndividualAccessorialsModal()
        {
            Click(attributeName_xpath, FirstAdditional_Select_Accessorial_Type_DropDown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on the Second Select Accessorial Type dropdown in the Set Individual Accessorials modal");
        }

        [Then(@"I should see the accessorial displayed in the drop down list")]
        public void ThenIShouldSeeTheAccessorialDisplayedInTheDropDownList()
        {
            IList<IWebElement> setAccessorialsDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialDropDownValues_Xpath));
            setAccessorialsDropdownValuesUI = objWebElementOperations.GetListFromIWebElement(setAccessorialsDropdownValues);
            GlobalVariables.webDriver.WaitForPageLoad();
            foreach (string accessorial in setAccessorialsDropdownValuesUI)
            {                
                if (accessorial.Contains(accessorialName))
                {                    
                    Report.WriteLine("Added Accessorial " + accessorialName + " is present in the accessorial drop down list");
                    break;
                }                
            }
        }        

        [Then(@"I will NOT see the deleted accessorial displayed in the drop down list")]
        public void ThenIWillNOTSeeTheDeletedAccessorialDisplayedInTheDropDownList()
        {
            IList<IWebElement> setAccessorialsDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(SetAccessorialDropDownValues_Xpath));
            setAccessorialsDropdownValuesUI = objWebElementOperations.GetListFromIWebElement(setAccessorialsDropdownValues);
            foreach (string accessorial in setAccessorialsDropdownValuesUI)
            {
                if (accessorial.Contains(accessorialName))
                {
                    Report.WriteFailure("Deleted Accessorial " + accessorialName + " is present in the accessorial drop down list");
                }
                else
                {
                    Report.WriteLine("Deleted Accessorial " + accessorialName + " is not present in the accessorial drop down list");
                }
            }
        }

        [Then(@"I should see the accessorial displayed in the drop down list of add another accessorial")]
        public void ThenIShouldSeeTheAccessorialDisplayedInTheDropDownListOfAddAnotherAccessorial()
        {
            IList<IWebElement> setAccessorialsDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(AdditionaldropdownOne_Value_Xpath));
            setAccessorialsDropdownValuesUI = objWebElementOperations.GetListFromIWebElement(setAccessorialsDropdownValues);
            GlobalVariables.webDriver.WaitForPageLoad();
            foreach (string accessorial in setAccessorialsDropdownValuesUI)
            {
                if (accessorial.Contains(accessorialName))
                {
                    Report.WriteLine("Added Accessorial " + accessorialName + " is present in the accessorial drop down list");
                    break;
                }                
            }
        }

        [Then(@"I will NOT see the deleted accessorial displayed in the drop down list for add another accessorial")]
        public void ThenIWillNOTSeeTheDeletedAccessorialDisplayedInTheDropDownListForAddAnotherAccessorial()
        {
            IList<IWebElement> setAccessorialsDropdownValues = GlobalVariables.webDriver.FindElements(By.XPath(AdditionaldropdownOne_Value_Xpath));
            setAccessorialsDropdownValuesUI = objWebElementOperations.GetListFromIWebElement(setAccessorialsDropdownValues);
            foreach (string accessorial in setAccessorialsDropdownValuesUI)
            {
                if (accessorial.Contains(accessorialName))
                {
                    Report.WriteFailure("Deleted Accessorial " + accessorialName + " is present in the accessorial drop down list");
                }
                else
                {
                    Report.WriteLine("Deleted Accessorial " + accessorialName + " is not present in the accessorial drop down list");
                }
            }
        }
    }
}
