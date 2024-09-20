using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Dashboard.Shipment.LTL.ShipmentInformationScreen
{
    [Binding]
    public class DashboardAddShipmentLTLMVC5CustomerUserSteps : AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am shp\.entry, shp\.entrynorates(.*) (.*)")]
        public void GivenIAmShp_EntryShp_Entrynorates(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I have selected LTL service in the create a Shipment section of the dashboard page")]
        public void WhenIHaveSelectedLTLServiceInTheCreateAShipmentSectionOfTheDashboardPage()
        {
            scrollElementIntoView(attributeName_id, "shipment-1");
            Thread.Sleep(500);
            Click(attributeName_id, "shipment-1");
            Thread.Sleep(500);
            Click(attributeName_id, "createShipment");
            Thread.Sleep(2000);
        }

        [Then(@"I will be navigated to Add Shipment\(LTL\) page(.*)")]
        public void ThenIWillBeNavigatedToAddShipmentLTLPage(string AddShipmentHeader)
        {
            WaitForElementVisible(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment(LTL) header");
            VerifyElementPresent(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment(LTL) header");
        }
    }
}
