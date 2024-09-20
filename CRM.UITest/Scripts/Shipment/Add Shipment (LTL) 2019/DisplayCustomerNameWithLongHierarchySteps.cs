using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class DisplayCustomerNameWithLongHierarchySteps : AddShipments2019
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string actualMessage = null;
        string statioName = null;
        int subAccountId;
        int primaryAccountId;
        string primaryAccountName = null;
        string expectedCustomerNameonCustomerLabel = null;

        [Given(@"I am a sales user,")]
        public void GivenIAmASalesUser()
        {
            string username = ConfigurationManager.AppSettings["username-NewScreenSalesUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenSalesUser"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Logged into CRM application with Sales user credentials");
        }

        [StepDefinition(@"I am a sales management, operations, or station owner user,")]
        public void GivenIAmASalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-NewScreenCrmOperationUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenCrmOperationUser"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Logged into CRM application with Operations user credentials");
        }

        [Given(@"I am creating an LTL shipment"), Scope(Tag = "76522")]
        public void GivenIAmCreatingAnLTLShipment()
        {
            Click(attributeName_id, ShipmentIcon_Id);
            Report.WriteLine("Creating and LTL Shipment via Shipment List");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected a (.*) that is more than one level"), Scope(Tag = "76522")]
        public void GivenISelectedAThatIsMoreThanOneLevel(string customerName)
        {
            Report.WriteLine("Selecting customer from customer drop down on shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, customerName);
            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == customerName)
                {
                    stationValue[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected a one level primary (.*)"), Scope(Tag = "76522")]
        public void GivenISelectedAOneLevelPrimary(string customerName)
        {
            Report.WriteLine("Selecting customer from customer drop down on shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, customerName);
            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == customerName)
                {
                    stationValue[i].Click();
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [StepDefinition(@"I am on the Add Shipment \(LTL\) page"), Scope(Tag = "76522")]
        public void WhenIAmOnTheAddShipmentLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            Report.WriteLine("Clicked on Add shipment button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentList_LTLtile_Id);
            Report.WriteLine("Clicked on LTL tile on Add shipment page");
            Verifytext(attributeName_xpath, AddShipment_PageTitle_xpath, "Add Shipment (LTL)");
            Report.WriteLine("Navigated to Add Shipment (LTL) page");
        }

        [When(@"I hover over the customer name on Add Shipment LTL page")]
        public void WhenIHoverOverTheCustomerNameOnAddShipmentLTLPage()
        {
            OnMouseOver(attributeName_xpath, AddShipmentCustomerLabel_Xpath);
            Report.WriteLine("I hover over the Customer name on add shipment ltl page");
        }

        [Then(@"I will display with a customer label below the header")]
        public void ThenIWillDisplayWithACustomerLabelBelowTheHeader()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string actualCustomerName = Gettext(attributeName_xpath, AddShipmentCustomerLabel_Xpath);
            VerifyElementPresent(attributeName_xpath, AddShipmentCustomerLabel_Xpath, "Select an account to display");
            Report.WriteLine("Verifying Customer drop down label");
        }

        [Then(@"the customer label will now display Station ID - Primary Account\.\.\.Final Customer Name (.*) on Add Shipment LTL page")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccount_FinalCustomerNameOnAddShipmentLTLPage(string customerName)
        {
            actualMessage = Gettext(attributeName_xpath, AddShipmentCustomerLabel_Xpath);
            statioName = DBHelper.GetStationName(customerName);
            subAccountId = DBHelper.GetCustomerId(customerName);
            primaryAccountId = DBHelper.GetPrimaryAccId(subAccountId);
            primaryAccountName = DBHelper.GetPrimaryAcc(primaryAccountId);
            expectedCustomerNameonCustomerLabel = statioName + " - " + primaryAccountName + "..." + customerName;
            Assert.AreEqual(expectedCustomerNameonCustomerLabel, actualMessage);
            Report.WriteLine("Customer label displayed with station name - primary customer - ...Final Customer");
        }

        [Then(@"the entire station, hierarchies, and customer name (.*) will be displayed in the hover over message on Add Shipment LTL page")]
        public void ThenTheEntireStationHierarchiesAndCustomerNameWillBeDisplayedInTheHoverOverMessageOnAddShipmentLTLPage(string popOverText)
        {
            Click(attributeName_xpath, AddShipmentCustomerLabel_Xpath);
            OnMouseOver(attributeName_xpath, AddShipmentCustomerLabel_Xpath);
            actualMessage = Gettext(attributeName_xpath, AddShipmentPopOverMessage_Xpath);
            Assert.AreEqual(popOverText, actualMessage);
            Report.WriteLine("Entire station, hierarchies and customer name displayed in the hover over message on Add Shipment LTL page");
        }

        [Then(@"the customer label will now display Station ID - Primary Account (.*) on Add Shipment LTL page")]
        public void ThenTheCustomerLabelWillNowDisplayStationID_PrimaryAccountOnAddShipmentLTLPage(string customerName)
        {
            actualMessage = Gettext(attributeName_xpath, AddShipmentCustomerLabel_Xpath);
            statioName = DBHelper.GetStationName(customerName);
            subAccountId = DBHelper.GetCustomerId(customerName);
            primaryAccountId = DBHelper.GetPrimaryAccId(subAccountId);
            primaryAccountName = DBHelper.GetPrimaryAcc(primaryAccountId);
            expectedCustomerNameonCustomerLabel = statioName + " - " + primaryAccountName;
            Assert.AreEqual(expectedCustomerNameonCustomerLabel, actualMessage);
            Report.WriteLine("Customer label displayed with station name - primary customer");
        }

    }
}
