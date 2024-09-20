using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Maintenance_Tools.Master_Carrier_Rate_Settings
{
    [Binding]
    public sealed class _75178_Accessorial_Gainshare_Type___Overlength___Retain_Values_Steps: AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"that I am a pricing config or config manager user ""(.*)"", ""(.*)""")]
        public void GivenThatIAmAPricingConfigOrConfigManagerUser(string user, string pass)
        {
            string username = ConfigurationManager.AppSettings[user].ToString();
            string password = ConfigurationManager.AppSettings[pass].ToString();
            Report.WriteLine("Logging in as " + username);
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I have navigated to the Master Carrier Rate Settings page")]
        public void GivenIHaveNavigatedToTheMasterCarrierRateSettingsPage()
        {
            Report.WriteLine("Naviagting to Master Carrier Rate Settings page");
            GlobalVariables.webDriver.WaitForPageLoad();
            string pricingUrl = ConfigurationManager.AppSettings["BaseUrl"];
            pricingUrl += "MasterCarrierRateSettings/Index";
            GlobalVariables.webDriver.Navigate().GoToUrl(pricingUrl);

        }

        [Given(@"I select ""(.*)"" from the customer dropdown")]
        public void GivenISelectFromTheCustomerDropdown(string customer)
        {
            Report.WriteLine("Selecting the customer " + customer + " from customer dropdown");
            Click(attributeName_xpath, MasterCarrier_CustomerDropdown_Xpath);
            SendKeys(attributeName_xpath, MasterCarrier_CustomerDropdown_Input_Xpath, customer);
            Click(attributeName_xpath, MasterCarrier_CustomerDropdown_FirstItem_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I select a carrier from the Carrier List")]
        public void GivenISelectACarrierFromTheCarrierList()
        {
            Report.WriteLine("Selecting a carrier from Carrier List");
            Click(attributeName_xpath, MasterCarrier_CarrierList_CarrierABFL_CheckBox_Xpath);
        }

        [Given(@"I select the Set Accessorials button")]
        public void GivenISelectTheSetAccessorialsButton()
        {
            WaitForElementPresent(attributeName_id, "setAccessorials", "Set Accessorials Button");
            Click(attributeName_id, "setAccessorials");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"the accessorial Overlength is selected")]
        public void WhenTheAccessorialOverlengthIsSelected()
        {
            WaitForElementVisible(attributeName_xpath, MasterCarrier_SetAccessorial_AccessorialDropdown_Xpath, "Accessorial Dropdown");
            Click(attributeName_xpath, MasterCarrier_SetAccessorial_AccessorialDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, MasterCarrier_SetAccessorial_AccessorialItems_Xpath, "Overlength");
        }

        [When(@"I enter the value ""(.*)"" up to and including the Overlength ""(.*)"" textbox")]
        public void WhenIEnterTheValueUpToAndIncludingTheOverlengthTextbox(string value, int overlengthNum)
        {
            Report.WriteLine("Adding the value " + value + " to the Overlength text areas");
            for(int i = 8; i <= overlengthNum; i++)
            {
                string className = "Over" + i.ToString();
                SendKeys(attributeName_classname, className, value);
            }
        }

        [When(@"the gainshare type ""(.*)"" is selected")]
        public void WhenTheGainshareTypeIsSelected(string type)
        {
            Report.WriteLine("Selecting the Gainshare Type " + type);
            Click(attributeName_xpath, MasterCarrier_SetAccessorial_GainshareTypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, MasterCarrier_SetAccessorial_GainshareTypeItems_Xpath, type);
        }

        [Then(@"the values up to and including Overlength ""(.*)"" textbox should not be empty")]
        public void ThenTheValuesUpToAndIncludingOverlengthTextboxShouldNotBeEmpty(int overlengthNum)
        {
            for(int i = 8; i <= overlengthNum; i++)
            {
                string className = "Over" + i.ToString();
                string textValue = GlobalVariables.webDriver.FindElement(By.ClassName(className)).GetAttribute("value");
                if(textValue == "")
                {
                    Report.WriteFailure("Textbox for " + className + " had value removed");
                }
            }

            Report.WriteLine("Overlength textboxes retained their values");
        }

    }
}
