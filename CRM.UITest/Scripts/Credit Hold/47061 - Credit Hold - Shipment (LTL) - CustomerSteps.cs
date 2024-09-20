using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class _47061___Credit_Hold___Shipment__LTL____CustomerSteps : ObjectRepository
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        Shipmentlist shipmentsListObjects = new Shipmentlist();
        public string Act_Inactivemessage;
       


        [Given(@"I am a shp\.entry or shp\.entrynorates user associated to a customer that is on Credit Hold")]
        public void GivenIAmAShp_EntryOrShp_EntrynoratesUserAssociatedToACustomerThatIsOnCreditHold()
        {
            string username = ConfigurationManager.AppSettings["username-CreditHoldShipEntry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CreditHoldShipEntry"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Logged in with user associated to a customer that is on credit hold");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CreditHold_OKButton_Id);
            Report.WriteLine("Clicked on the Credit Hold modal pop up Ok button");
            Verifytext(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");

        }

        [When(@"I arrive on Dashboard page")]
        public void WhenIArriveOnDashboardPage()
        {
            Verifytext(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
        }
        
        [Then(@"the Create Shipment button should be Inactive")]
        public void ThenTheCreateShipmentButtonShouldBeInactive()
        {
            scrollElementIntoView(attributeName_id, Dashboard_CreateShipmentButton_Id);
            bool inactiveButton  = IsElementDisabled(attributeName_id, Dashboard_CreateShipmentButton_Id, "CreateShipment");
            Assert.IsTrue(inactiveButton);
        }

        [Given(@"I am on the Dashboard page")]
        public void GivenIAmOnTheDashboardPage()
        {
            Verifytext(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
        }

        [When(@"I hover over the inactive Create Shipment button")]
        public void WhenIHoverOverTheInactiveCreateShipmentButton()
        {
            OnMouseOver(attributeName_id, Dashboard_CreateShipmentButton_Id);
            Act_Inactivemessage = Gettext(attributeName_classname, "tooltipWithoutTextTransform");
            
        }

        [Then(@"I will see a hover over message as '(.*)' on Dashboard Page")]
        public void ThenIWillSeeAHoverOverMessageAsOnDashboardPage(string Exp_Inactivemessage)
        {
            Assert.AreEqual(Exp_Inactivemessage, Act_Inactivemessage);
        }

        [Then(@"the Add Shipment button should be Inactive")]
        public void ThenTheAddShipmentButtonShouldBeInactive()
        {
            WaitForElementVisible(attributeName_xpath, shipmentsListObjects.ShipmentList_Title_Xpath, "Shipment List");
            bool inactiveButton = IsElementDisabled(attributeName_id, shipmentsListObjects.ShipmentList_AddShipmentButton_Id, "CreateShipment");
            Assert.IsTrue(inactiveButton);
        }

        [Then(@"I will not see the Copy Shipment button for any displayed LTL shipment")]
        public void ThenIWillNotSeeTheCopyShipmentButtonForAnyDisplayedLTLShipment()
        {
            SendKeys(attributeName_id, shipmentsListObjects.ShipmentListSearchBox_Id, "LTL");
            VerifyElementNotPresent(attributeName_xpath, shipmentsListObjects.ShipmentListGrid_CopyIcons_Xpath, "Copy Icon");
            
        }

        [Then(@"I will not see the Return Shipment button for any displayed LTL shipment")]
        public void ThenIWillNotSeeTheReturnShipmentButtonForAnyDisplayedLTLShipment()
        {
            VerifyElementNotPresent(attributeName_xpath, shipmentsListObjects.ShipmentListGrid_RetrunShipmentIcon_First_Xpath, "Return Icon");
        }

        [When(@"I hover over the inactive Add Shipment button")]
        public void WhenIHoverOverTheInactiveAddShipmentButton()
        {
            OnMouseOver(attributeName_id, shipmentsListObjects.ShipmentList_AddShipmentButton_Id);
            Act_Inactivemessage = Gettext(attributeName_classname, "tooltipWithoutTextTransform");
        }

        [Then(@"I will see a hover over message as '(.*)' on Shipment List page")]
        public void ThenIWillSeeAHoverOverMessageAsOnShipmentListPage(string Exp_Inactivemessage)
        {
            Assert.AreEqual(Exp_Inactivemessage, Act_Inactivemessage);
        }

        [Given(@"I am a ship\.entry or ship\.entrynorates user associated to a customer that is not on Credit Hold")]
        public void GivenIAmAShip_EntryOrShip_EntrynoratesUserAssociatedToACustomerThatIsNotOnCreditHold()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Logged in with user associated to a customer that is not on credit hold");
        }

        [When(@"I hover over the active Create Shipment button")]
        public void WhenIHoverOverTheActiveCreateShipmentButton()
        {
            OnMouseOver(attributeName_id, Dashboard_CreateShipmentButton_Id);
        }

        [Then(@"I should not see a hover over message as '(.*)' on Dashboard Page")]
        public void ThenIShouldNotSeeAHoverOverMessageAsOnDashboardPage(string InactiveMessage)
        {
            VerifyElementNotPresent(attributeName_classname, "tooltipWithoutTextTransform", "CreateShipmentMessage");
        }

        [When(@"I hover over the active Add Shipment button")]
        public void WhenIHoverOverTheActiveAddShipmentButton()
        {
            OnMouseOver(attributeName_id, shipmentsListObjects.ShipmentList_AddShipmentButton_Id);
        }

        [Then(@"I should not see a hover over message as '(.*)' on Shipment List page")]
        public void ThenIShouldNotSeeAHoverOverMessageAsOnShipmentListPage(string InactiveMessage)
        {
            VerifyElementNotPresent(attributeName_classname, "tooltipWithoutTextTransform", "AddShipmentMessage");
        }

    }
}
