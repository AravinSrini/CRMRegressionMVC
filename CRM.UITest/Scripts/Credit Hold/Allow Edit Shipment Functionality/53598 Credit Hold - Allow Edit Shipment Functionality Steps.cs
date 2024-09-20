using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold.Allow_Edit_Shipment_Functionality
{
    [Binding]
    public class _53598_Credit_Hold___Allow_Edit_Shipment_Functionality_Steps : Shipmentlist
    {
        [Given(@"I am a sales sales management operations or station owner user ""(.*)"" ""(.*)""")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwnerUser(string username, string password)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

            string Username = ConfigurationManager.AppSettings[username];
            string Password = ConfigurationManager.AppSettings[password];

            Report.WriteLine("Logging in as " + username);
            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I search for a shipment using a reference number ""(.*)""")]
        public void GivenISearchForAShipmentUsingAReferenceNumber(string referenceNumber)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Searching for the report " + referenceNumber);
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referenceNumber);
            Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click on the edit shipment button of a shipment")]
        public void WhenIClickOnTheEditShipmentButtonOfAShipment()
        {
            Report.WriteLine("Clicking the edit shipment button");
            Click(attributeName_cssselector, ShipmentList_EditShipmentButton_Selector);
        }

        [Then(@"I will be taken to the Add Shipment page")]
        public void ThenIWillBeTakenToTheAddShipmentPage()
        {
            Report.WriteLine("Verifying that I am on the add shipment page");
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Add shipment title");
        }

        [Then(@"I will not receive a message indicating that the customer is on Credit Hold")]
        public void ThenIWillNotReceiveAMessageIndicatingThatTheCustomerIsOnCreditHold()
        {
            Report.WriteLine("Verifying whether credit hold modal is displayed");
            VerifyElementNotVisible(attributeName_cssselector, AddShipment_CreditHoldModalLTL_Selector, "Credit Hold Modal");
        }
    }
}
