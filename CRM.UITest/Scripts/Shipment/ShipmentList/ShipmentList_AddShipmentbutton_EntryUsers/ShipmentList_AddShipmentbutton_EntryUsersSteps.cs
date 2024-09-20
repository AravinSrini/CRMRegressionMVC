using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_AddShipmentbutton_EntryUsers
{
    [Binding]
    public class ShipmentList_AddShipmentbutton_EntryUsersSteps : AddShipments
    {
        
        [Then(@"I click on Add Shipment button")]
        public void ThenIClickOnAddShipmentButton()
        {
            Report.WriteLine("Click on Add shipment button");
            Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
        }
        
        [Then(@"I should be displayed with Add Shipment button")]
        public void ThenIShouldBeDisplayedWithAddShipmentButton()
        {
            Report.WriteLine("I should be displayed with Add shipment button");
            VerifyElementVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");
        }
        
        [Then(@"I should navigate to Add Shipment page")]
        public void ThenIShouldNavigateToAddShipmentPage()
        {
            Report.WriteLine("I should navigate to Add shipment page");
            VerifyElementVisible(attributeName_xpath, ShipmentServicePageTitle_Xpath, "Add Shipment");
        }
    }
}
