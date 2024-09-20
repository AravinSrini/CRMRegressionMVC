using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public class DomesticForwarding_AddShipment_SelectSavedData_Review_And_SubmitSteps : Mvc4Objects
    {

        [Given(@"I shp\.entry user or shp\.entryNorates (.*),(.*)")]
        public void GivenIShp_EntryUserOrShp_EntryNorates(string Username, string Password)
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I select Domestic Forwarding service(.*) and Click on Create Shipment button from Dashboard page")]
        public void WhenISelectDomesticForwardingServiceAndClickOnCreateShipmentButtonFromDashboardPage(string Type)
        {
            scrollElementIntoView(attributeName_id, Ship_DF_Radiobutton_DashboardPage_ID);
            Click(attributeName_id, Ship_DF_Radiobutton_DashboardPage_ID);
            WaitForElementVisible(attributeName_id, Ship_DF_SelectType_dropdown_DashboardPage_Id, "Type Dropdown");
            Click(attributeName_id, Ship_DF_SelectType_dropdown_DashboardPage_Id);
            SelectDropdownlistvalue(attributeName_xpath, Ship_DF_SelectType_dropdown_Values_DashboardPage_Xpath, Type);
            Thread.Sleep(400);
            Click(attributeName_id, "createShipment");
        }

        [When(@"I select Domestic Forwarding service(.*) from Add Shipment page")]
        public void WhenISelectDomesticForwardingServiceFromAddShipmentPage(string Type)
        {
            Click(attributeName_xpath, ShipmentModule_Xpath);
            WaitForElementVisible(attributeName_xpath, ".//h1[contains(text(), 'Shipment List')]", "Shipment List Header");
            Click(attributeName_id, AddShipmentbtn_Id);
            Click(attributeName_id, DomesticForwarding_TitleLabel_Id);
            WaitForElementVisible(attributeName_xpath, ShipDF_SelectType_Xpath, "Type Dropdown");
            Click(attributeName_xpath, ShipDF_SelectType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_SelectTypeValues_Xpath, Type);
            Thread.Sleep(400);
            Click(attributeName_id, ShipDF_Continuebutton_ID);
        }


        [When(@"I click on Save and Continue button from Shipment Locations And Dates page(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIClickOnSaveAndContinueButtonFromShipmentLocationsAndDatesPage(string oAccessorial, string dAccessorial, string pickUpReadyTime, string pickUpCloseTime, string deliveryReadyTime, string deliveryCloseTime, string Item)
        {
            Thread.Sleep(6000); 
            WaitForElementVisible(attributeName_xpath, DF_ShipmentLocation_and_Dates_Header_Xpath, "Shipments Locations and Dates");
            Click(attributeName_id, ShipDF_OrgClearAddressButton_ID);
            Thread.Sleep(1500);
            Click(attributeName_id, ShipDF_DestClearAddressButton_ID);
            Thread.Sleep(1500);
            Click(attributeName_xpath, ShipDF_OriginAddressDropdown_Xpath);
            Click(attributeName_xpath, ShipDF_FirstOriginAddressFromDropdown_Xpath);
            Thread.Sleep(2000);

            Click(attributeName_xpath, ShipDF_DestAddressDropdown_Xpath);
            Click(attributeName_xpath, ShipDF_FirstDestAddressFromDropdown_Xpath);
            Thread.Sleep(2000);

            scrollElementIntoView(attributeName_xpath, ShipDF_OrgAccessorial_Dropdown_Xpath);
            Thread.Sleep(800);
            Click(attributeName_xpath, ShipDF_OrgAccessorial_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_OrgAccessorial_DropdownValue_Xpath, oAccessorial);
            Thread.Sleep(800);

            Click(attributeName_xpath, ShipDF_DestAccessorial_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DestAccessorial_DropdownValue_Xpath, dAccessorial);
            Thread.Sleep(800);

            Click(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, "//div[@class='k-animation-container km-popup']/div[@id = 'ready-origin-select-list']/ul/li", pickUpReadyTime);
            Thread.Sleep(200);

            Click(attributeName_xpath, ShipDF_PickClose_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, "//div[@class='k-animation-container km-popup']/div[@id = 'close-origin-select-list']/ul/li", pickUpCloseTime);
            Thread.Sleep(200);

            Click(attributeName_xpath, ShipDF_DelReady_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, "//div[@class='k-animation-container km-popup']/div[@id = 'ready-delivery-select-list']/ul/li", deliveryReadyTime);
            Thread.Sleep(200);

            Click(attributeName_xpath, ShipDF_DelClose_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, "//div[@class='k-animation-container km-popup']/div[@id = 'close-delivery-select-list']/ul/li", deliveryCloseTime);
            Thread.Sleep(200);

            Click(attributeName_xpath, ShipDF_ItemDropdown_Xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_xpath, ".//*[@id='saved_item_select_chosen']/div/div/input", Item);
            Click(attributeName_xpath, ".//*[@id='saved_item_select_chosen']/div/ul/li");
            Thread.Sleep(800);

            scrollElementIntoView(attributeName_id, ShipDF_SaveContinueButton_Id);
            Thread.Sleep(400);
            Click(attributeName_id, ShipDF_SaveContinueButton_Id);
            Thread.Sleep(10000);
            
        }
        
        [Then(@"I will be navigated to Review and Submit page")]
        public void ThenIWillBeNavigatedToReviewAndSubmitPage()
        {
            Thread.Sleep(4000);
            WaitForElementVisible(attributeName_xpath, ShipDFReview_And_SubmitPage_Header_Xpath, "Review And Submit Page Header");
            VerifyElementPresent(attributeName_xpath, ShipDFReview_And_SubmitPage_Header_Xpath, "Review And Submit Page");
            string Service_UI = Gettext(attributeName_id, ShipDF_Service_ReviewAndSubmitPage_Id);
            string ActualService = Service_UI.Remove(0, 9);
            Assert.AreEqual("Domestic Forwarding", ActualService);

        }
    }
}
