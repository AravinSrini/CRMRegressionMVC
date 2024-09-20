using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.International
{
    [Binding]
    public class InternationalShipment_AirType_SetDefaultLevelSteps : Mvc4Objects
    {
        [Given(@"I am Shipment Entry User")]
        public void GivenIAmShipmentEntryUser()
        {
            string Username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string Password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am Shipment Entry No Rates User")]
        public void GivenIAmShipmentEntryNoRatesUser()
        {
            string Username = ConfigurationManager.AppSettings["username-EntrynoratesCrmdelta"].ToString();
            string Password = ConfigurationManager.AppSettings["password-EntrynoratesCrmdelta"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [When(@"I selected International Shipment Service Type as Air Import from Add Shipment Tiles Page(.*)")]
        public void WhenISelectedInternationalShipmentServiceTypeAsAirImportFromAddShipmentTilesPage(string ServiceType)
        {
            
            Click(attributeName_id, ShipmentModule_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Text_Xpath, "Shipment List");

            WaitForElementVisible(attributeName_id, AddShipment_button_Id, "Add Shipment button");
            Click(attributeName_id, AddShipment_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementVisible(attributeName_xpath, AddShipmentTiles_Page_Header_Xpath, "Add Shipment Tiles Page");
            Click(attributeName_id, Int_Shipment_Tile_Id);
            WaitForElementVisible(attributeName_xpath, Int_ServiceType_Modal_Verbiage, "International Type Verbiage");
            Click(attributeName_xpath, Int_Shipment_Type_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_Type_dropdown_Value_Xpath, ServiceType);
            
        }
        [When(@"I selected International Shipment Service Type as Air Export from Add Shipment Tiles Page(.*)")]
        public void WhenISelectedInternationalShipmentServiceTypeAsAirExportFromAddShipmentTilesPage(string ServiceType)
        {
            Click(attributeName_id, ShipmentModule_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Text_Xpath, "Shipment List");

            WaitForElementVisible(attributeName_id, AddShipment_button_Id, "Add Shipment button");
            Click(attributeName_id, AddShipment_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementVisible(attributeName_xpath, AddShipmentTiles_Page_Header_Xpath, "Add Shipment Tiles Page");
            Click(attributeName_id, Int_Shipment_Tile_Id);
            WaitForElementVisible(attributeName_xpath, Int_ServiceType_Modal_Verbiage, "International Type Verbiage");
            Click(attributeName_xpath, Int_Shipment_Type_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Int_Shipment_Type_dropdown_Value_Xpath, ServiceType);
        }
        
        [Then(@"the Service Level will be defaulted to Air Direct")]
        public void ThenTheServiceLevelWillBeDefaultedToAirDirect()
        {
            WaitForElementVisible(attributeName_xpath, Int_Shipment_level_dropdown_Xpath, "International service level dropdown");
            Verifytext(attributeName_xpath, Int_Shipment_level_dropdown_Xpath, "Air Direct");
        }
        
        [Then(@"the select level option should not be present")]
        public void ThenTheSelectLevelOptionShouldNotBePresent()
        {
            WaitForElementVisible(attributeName_xpath, Int_Shipment_level_dropdown_Xpath, "International service level dropdown");
            List<string> serviceLevel = new List<string>();

            Click(attributeName_xpath, Int_Shipment_level_dropdown_Xpath);

            Report.WriteLine("Reading the Service level drop down values");
            IList<IWebElement> serviceLevelDropdownValue = GlobalVariables.webDriver.FindElements(By.XPath(Int_Shipment_level_dropdown_value_Xpath));

            List<string> _serviceLevelDropdownValue = serviceLevelDropdownValue.Select(s => s.Text).ToList();

            Report.WriteLine("Verifying the absence of Service level Verbiage from the Service Level drop down");
            bool _serviceLevelValues = _serviceLevelDropdownValue.Any(a => a == "Select Level...");
            Assert.IsFalse(_serviceLevelValues);
        }
    }
}
