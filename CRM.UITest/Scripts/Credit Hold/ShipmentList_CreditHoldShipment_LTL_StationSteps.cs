using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
//comment

namespace CRM.UITest
{
    [Binding]
    public class ShipmentList_CreditHoldShipment_LTL_StationSteps : Shipmentlist
    {
        IList<IWebElement> stationValue;
        [Given(@"that I am a sales, sales management, operation, or station owner user")]
        public void GivenThatIAmASalesSalesManagementOperationOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-CreditHoldInternalUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-CreditHoldInternalUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the shipment List page")]
        public void GivenIAmOnTheShipmentListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigating to add shipment page");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }      

        [Given(@"I clicked in the Select drop down list")]
        public void GivenIClickedInTheSelectDropDownList()
        {
            Report.WriteLine("Clicking on drop down list");
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            
        }

        [Given(@"the Shipment List refreshed to display at least one shipment")]
        public void GivenTheShipmentListRefreshedToDisplayAtLeastOneShipment()
        {
            Report.WriteLine("Verifying one shipment present");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, "LTL");
            bool value = IsElementPresent(attributeName_xpath, ShipmentListGridNoResult_Xpath, "No Results Found");
            if (value == true)
            { Assert.Fail("No Shipment found for the selected Customer"); }

        }

        [When(@"any associated customer has been placed on credit Hold")]
        public void WhenAnyAssociatedCustomerHasBeenPlacedOnCreditHold()
        {
            Report.WriteLine("Selecting a Credit Hold Customer from dropdown list");
            stationValue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));
        }
        [Given(@"I Selected a customer that is on Credit Hold")]
        public void GivenISelectedACustomerthatIsOnCreditHold()
        {
            Report.WriteLine("Selecting a Credit Hold Customer from dropdown list");
            stationValue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerDropdownValues_xpath));
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == "July4 (credit hold)")
                {
                    stationValue[i].Click();
                    GlobalVariables.webDriver.WaitForPageLoad();
                    break;
                }
            }
        }
        [When(@"I clicked on the Add Shipment button")]
        public void WhenIClickedOnTheAddShipmentButton()
        {
            Report.WriteLine("Clicking on Add Shipment Button");
            Click(attributeName_xpath, ShipmentServicetype_INT_AddShipmentButton_Xpath);

        }

        [Then(@"I will receive a Message As The selected customer is on Credit Hold")]
        public void ThenIWillReceiveAMessageAsTheSelectedCustomerIsOnCreditHold()
        {
            WaitForElementVisibleVerifyTextContains(attributeName_xpath, CreditHoldpopup_Xpath, "Credit Hold", "Credit Hold");
            Report.WriteLine("Verifying the CreditHold message");
            Verifytext(attributeName_xpath, AddshipmentCreditHoldMessage_Xpath, "The selected customer is on Credit Hold.");
        }


        [When(@"I Click on the (.*) of a displayed shipment")]
        public void WhenIClickOnTheOfADisplayedShipment(string button)
        {
            Report.WriteLine("Clicking on copy Shipment and Return Shipment button ");
            if (button == "Copy Shipment")
            {
                Click(attributeName_xpath, ShipmentList_CopyShipIcon_Xpath);

            }
            else if (button == "Return Shipment")
            {
                Click(attributeName_xpath, ShipmentList_ReturnShipIcon_Xpath);
            }
        }


        [Then(@"I will see an indicator that the customer is on credit Hold")]
        public void ThenIWillSeeAnIndicatorThatTheCustomerIsOnCreditHold()
        {
            bool isCreditHold = false;

            for (int i = 0; i < stationValue.Count; i++)
            {
                Report.WriteLine(stationValue[i].Text);
                if (stationValue[i].Text == "July4 (credit hold)")
                {
                    Report.WriteLine("The  Selected customer is in credit hold");
                    isCreditHold = true;
                    break;
                }
            }
            if (isCreditHold == false)
            { Assert.Fail("The Selected customer is not in credit hold"); }

        }
    }
}
