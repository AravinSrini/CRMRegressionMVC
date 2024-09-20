using System;
using System.IO;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.Shipment_Service_Tiles_Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding.Shipment
{
    [Binding]
    public class AddShipment_ReviewandSubmit_SubmitShipmentSteps : Mvc4Objects
    {

        [Given(@"I am on Review and Submit Page of Add Shipment process (.*), (.*), (.*),(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void GivenIAmOnReviewAndSubmitPageOfAddShipmentProcessAnd(string type, string oLocName, string oLocAdd, string oZip, string dLocName, string dLocAdd, string dZip, string pickReady,
            string pickClose, string delReady, string delClose, string quantity, string weight, string length,
            string width, string height, string itemDesc)
        {
            Report.WriteLine("Clicking on shipment icon");
            AddShipmentLTL ship = new AddShipmentLTL();
            ship.NaviagteToShipmentList();
            Click(attributeName_id, "add-shipment-btn");

            Report.WriteLine("Selecting domestic forwarding type");
            AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps steps = new AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps();
            steps.WhenIClickOnTheDomesticForwardingTileInAddShipmentPage();
            steps.WhenISelectAnyFromTheDropdown(type);
            steps.WhenIClickOnContinueButtonInServiceTypePopup();
            steps.ThenIShouldBeNavigatedToTheDomesticForwardingLocationsAndDatesPage();

            Report.WriteLine("Passing data in location and dates page");
            SendKeys(attributeName_id, ShipDF_OriginLocationName_Id, oLocName);
            SendKeys(attributeName_id, ShipDF_OriginAddress_Id, oLocAdd);
            SendKeys(attributeName_id, ShipDF_OriginZip_Id, oZip);
            SendKeys(attributeName_id, ShipDF_DestLocationName_Id, dLocName);
            SendKeys(attributeName_id, ShipDF_DestAddress_Id, dLocAdd);
            SendKeys(attributeName_id, ShipDF_DestZip_Id, dZip);

            scrollElementIntoView(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            Click(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_PickReady_DropdownValues_Xpath, "Pickup ready");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_PickReady_DropdownValues_Xpath, pickReady);

            Click(attributeName_xpath, ShipDF_PickClose_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_PickClose_DropdownValues_Xpath, "Pickup close");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_PickClose_DropdownValues_Xpath, pickClose);

            Click(attributeName_xpath, ShipDF_DelReady_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_DelReady_DropdownValues_Xpath, "Delivery ready");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DelReady_DropdownValues_Xpath, delReady);

            Click(attributeName_xpath, ShipDF_DelClose_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_DelClose_DropdownValues_Xpath, "Delivery close");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DelClose_DropdownValues_Xpath, delClose);

            scrollElementIntoView(attributeName_id, ShipDF_Quantity_Id);
            SendKeys(attributeName_id, ShipDF_Quantity_Id, quantity);
            SendKeys(attributeName_id, ShipDF_Weight_Id, weight);
            SendKeys(attributeName_id, ShipDF_Length_Id, length);
            SendKeys(attributeName_id, ShipDF_Width_Id, width);
            SendKeys(attributeName_id, ShipDF_Height_Id, height);
            SendKeys(attributeName_id, ShipDF_Desc_Id, itemDesc);

            scrollpagedown();
            Click(attributeName_id, ShipDF_SaveContinueButton_Id);

        }

        [Given(@"I am on Confirmation Page of Add Shipment process (.*), (.*), (.*),(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void GivenIAmOnConfirmationPageOfAddShipmentProcessAnd(string type, string oLocName, string oLocAdd, string oZip, string dLocName, string dLocAdd, string dZip, string pickReady,
            string pickClose, string delReady, string delClose, string quantity, string weight, string length,
            string width, string height, string itemDesc)
        {
            Report.WriteLine("Clicking on shipment icon");
            AddShipmentLTL ship = new AddShipmentLTL();
            ship.NaviagteToShipmentList();
            Click(attributeName_id, "add-shipment-btn");

            Report.WriteLine("Selecting domestic forwarding type");
            AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps steps = new AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps();
            steps.WhenIClickOnTheDomesticForwardingTileInAddShipmentPage();
            steps.WhenISelectAnyFromTheDropdown(type);
            steps.WhenIClickOnContinueButtonInServiceTypePopup();
            steps.ThenIShouldBeNavigatedToTheDomesticForwardingLocationsAndDatesPage();

            Report.WriteLine("Passing data in location and dates page");
            SendKeys(attributeName_id, ShipDF_OriginLocationName_Id, oLocName);
            SendKeys(attributeName_id, ShipDF_OriginAddress_Id, oLocAdd);
            SendKeys(attributeName_id, ShipDF_OriginZip_Id, oZip);
            SendKeys(attributeName_id, ShipDF_DestLocationName_Id, dLocName);
            SendKeys(attributeName_id, ShipDF_DestAddress_Id, dLocAdd);
            SendKeys(attributeName_id, ShipDF_DestZip_Id, dZip);

            scrollElementIntoView(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            Click(attributeName_xpath, ShipDF_PickReady_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_PickReady_DropdownValues_Xpath, "Pickup ready");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_PickReady_DropdownValues_Xpath, pickReady);

            Click(attributeName_xpath, ShipDF_PickClose_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_PickClose_DropdownValues_Xpath, "Pickup close");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_PickClose_DropdownValues_Xpath, pickClose);

            Click(attributeName_xpath, ShipDF_DelReady_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_DelReady_DropdownValues_Xpath, "Delivery ready");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DelReady_DropdownValues_Xpath, delReady);

            Click(attributeName_xpath, ShipDF_DelClose_Dropdown_Xpath);
            WaitForElementVisible(attributeName_xpath, ShipDF_DelClose_DropdownValues_Xpath, "Delivery close");
            SelectDropdownValueFromList(attributeName_xpath, ShipDF_DelClose_DropdownValues_Xpath, delClose);

            scrollElementIntoView(attributeName_id, ShipDF_Quantity_Id);
            SendKeys(attributeName_id, ShipDF_Quantity_Id, quantity);
            SendKeys(attributeName_id, ShipDF_Weight_Id, weight);
            SendKeys(attributeName_id, ShipDF_Length_Id, length);
            SendKeys(attributeName_id, ShipDF_Width_Id, width);
            SendKeys(attributeName_id, ShipDF_Height_Id, height);
            SendKeys(attributeName_id, ShipDF_Desc_Id, itemDesc);

            scrollpagedown();
            Click(attributeName_id, ShipDF_SaveContinueButton_Id);

            scrollElementIntoView(attributeName_id, ShipDF_SubmitButton_Id);
            Click(attributeName_id, ShipDF_SubmitButton_Id);

            WaitForElementVisible(attributeName_xpath, ShipDF_ConfirmationTitle_Xpath, "Confirmation page");

        }

        [When(@"I click on Submit button")]
        public void WhenIClickOnSubmitButton()
        {
            Report.WriteLine("Click on Submit button");
            scrollElementIntoView(attributeName_id, ShipDF_SubmitButton_Id);
            Click(attributeName_id, ShipDF_SubmitButton_Id);

            WaitForElementVisible(attributeName_xpath, ShipDF_ConfirmationTitle_Xpath, "Confirmation page");
        }

        [When(@"I Click on Start New Shipment Entry button")]
        public void WhenIClickOnStartNewShipmentEntryButton()
        {
            Report.WriteLine("Click on Start new shipment entry");
            scrollElementIntoView(attributeName_id, ShipDF_StartNewShipEntry_Id);
            Click(attributeName_id, ShipDF_StartNewShipEntry_Id);
        }

        [Then(@"I must be displayed with Service, Type, Pick up date, House bill number and status on confirmation page")]
        public void ThenIMustBeDisplayedWithServiceTypePickUpDateHouseBillNumberAndStatusOnConfirmationPage()
        {
            Report.WriteLine("Navigated to Confirmation page");
            VerifyElementVisible(attributeName_xpath, ShipDF_ConfirmationTitle_Xpath, "Confirmation page");
            VerifyElementVisible(attributeName_xpath, ShipDF_ServiceVerbiage_Xpath, "Service:");
            VerifyElementVisible(attributeName_xpath, ShipDF_ServiceType_Xpath, "Domestic Forwarding");
            VerifyElementVisible(attributeName_xpath, ShipDF_typeVerbiage_Xpath, "Type:");
            VerifyElementVisible(attributeName_xpath, PickupDateVerbiage_Xpath, "Pickup Date:");
            VerifyElementVisible(attributeName_xpath, ShipDF_HouseBillNumVerbiage_Xpath, "Housebill Number:");
            VerifyElementVisible(attributeName_xpath, ShipDF_statusVerbiage_Xpath, "Status:");
        }

        [Then(@"View Shipment details and House bill buttons must be displayed")]
        public void ThenViewShipmentDetailsAndHouseBillButtonsMustBeDisplayed()
        {
            Report.WriteLine("Verify View Shipment details and House bill buttons");
            scrollElementIntoView(attributeName_xpath, ShipDF_ViewShipmentDetail_Xpath);
            VerifyElementVisible(attributeName_xpath, ShipDF_ViewShipmentDetail_Xpath, "View Shipment Details");
            VerifyElementVisible(attributeName_id, ShipDF_HouseBill_Id, "Housebill");
        }

        [Then(@"I must be navigated to Add Shipment Shipment Service page")]
        public void ThenIMustBeNavigatedToAddShipmentShipmentServicePage()
        {
            Report.WriteLine("Navigated to Add Shipment - Service type selection page");
            WaitForElementVisible(attributeName_xpath, ShipDF_AddShipmentHeader_Xpath, "Add Shipment");
            VerifyElementVisible(attributeName_xpath, ShipDF_ShipmentService_Xpath, "Shipment Service");
        }
    }
}
