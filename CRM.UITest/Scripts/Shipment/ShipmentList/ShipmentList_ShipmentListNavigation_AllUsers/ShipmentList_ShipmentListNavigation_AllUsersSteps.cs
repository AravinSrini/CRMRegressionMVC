using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ShipmentListNavigation_AllUsers
{
    [Binding]
    public class ShipmentList_ShipmentListNavigation_AllUsersSteps : Shipmentlist
    {        
        [Then(@"I should be displayed with Shipments Icon in leftwizard")]
        public void ThenIShouldBeDisplayedWithShipmentsIconInLeftwizard()
        {            
            Report.WriteLine("Displayed with Shipment icon in navigation bar");
            VerifyElementVisible(attributeName_xpath, ShipmentIcon_Xpath, "Shipments");
        }

        [Then(@"I click on the Shipment icon")]
        public void ThenIClickOnTheShipmentIcon()
        {
            Report.WriteLine("I click on Shipment icon");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
        }

        [Then(@"I should be navigated to Shipment List page")]
        public void ThenIShouldBeNavigatedToShipmentListPage()
        {
            Report.WriteLine("I should be navigated to shipment list page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

        [Then(@"I will be navigated to new shipment list screen")]
        public void ThenIWillBeNavigatedToNewShipmentListScreen()
        {
            Report.WriteLine("MVC5 Shipment list screen is visible");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

        [Then(@"I will be navigated to legacy shipment list screen")]
        public void ThenIWillBeNavigatedToLegacyShipmentListScreen()
        {
            Report.WriteLine("MVC4 Shipment list screen is visible");
            VerifyElementVisible(attributeName_xpath, ShipmentList_TitleLegacy_Xpath, "Shipment List");
        }

        [Then(@"I click on the Shipment icon for external users")]
        public void ThenIClickOnTheShipmentIconForExternalUsers()
        {
            string ErrorPopupValues = Gettext(attributeName_xpath, ErrorMessage_Xpath);
            if (ErrorPopupValues == "Error")
            {
                Click(attributeName_xpath, ErrorPopUpClose_Button_Xpath);
                Thread.Sleep(2000);
                Click(attributeName_xpath, ShipmentIcon_Xpath);

            }
            else
            {
                Click(attributeName_xpath, ShipmentIcon_Xpath);
            }
        }

    }
}
