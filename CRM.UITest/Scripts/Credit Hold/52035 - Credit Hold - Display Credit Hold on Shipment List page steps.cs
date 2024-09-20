using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold.Display_Credit_Hold_Verbiage
{
    [Binding]
    public sealed class _52035___Credit_Hold___Display_Credit_Hold_on_Shipment_List_page_steps : Shipmentlist
    {
        [Given(@"I Navigate to the Shipment List page")]
        [When(@"I arrive on the Shipment List page")]
        [When(@"I Navigate to the Shipment List page")]
        public void WhenIArriveOnTheShipmentListPage()
        {
            CloseCreditHoldWarningPopUp closeCreditHoldWarning = new CloseCreditHoldWarningPopUp();

            closeCreditHoldWarning.CloseCreditHoldPopUp();

            //if (GlobalVariables.webDriver.FindElement(By.XPath(CreditHoldCloseButton_Xpath)).Displayed)
            //{
            //    Report.WriteLine("Closing Credit Hold Modal");
            //    Click(attributeName_xpath, CreditHoldCloseButton_Xpath);
            //}

            Report.WriteLine("Navigating to add shipment page");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I've selected a customer that is on Credit Hold from the shipment customer drop down list ""(.*)""")]
        [When(@"I choose a shipment customer that is on Credit Hold ""(.*)""")]
        
        public void GivenIVeSelectedACustomerThatIsOnCreditHoldFromTheShipmentCustomerDropDownList(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerOrStationDropdown_Xpath);
            try
            {
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, customerName);
            }
            catch (ArgumentOutOfRangeException)
            {
                Report.WriteLine("Customer does not exist in the customer list");
                Assert.Fail();
            }            
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I choose a customer that is not on Credit Hold from the shipment customer drop down list ""(.*)""")]
        [When(@"I choose no customer from the shipment customer drop down list ""(.*)""")]
        public void WhenISelectNoCustomerFromShipmentCustomerDropDownList(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, "//*[@id='CustomerType_chosen']/a");
            try
            {
                SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, customerName);
            }
            catch (ArgumentOutOfRangeException)
            {
                Report.WriteLine("Customer does not exist in the customer list");
                Assert.Fail();
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"The verbiage Account currently on credit hold will be displayed beneath the Shipment List label on the Shipment List Page")]
        public void ThenIWillSeeTheVerbiageAccountCurrentlyOnCreditHoldDisplayedBeneathTheShipmentListLabel()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementVisible(attributeName_id, "CreditHoldAccount", "Shipment List verbiage");
        }



        [Then(@"I will no longer see the verbiage Account currently on credit hold displayed beneath the Shipment List label on the Shipment List Page")]
        [Then(@"I will not see the verbiage Account currently on credit hold displayed beneath the Shipment List label on the Shipment List Page")]
        public void ThenIWillNoLongerSeeTheVerbiageAccountCurrentlyOnCreditHoldDisplayedBeneathTheShipmentListLabel()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementNotVisible(attributeName_id, "CreditHoldAccount", "Shipment List verbiage");
        }

        [Then(@"The verbiage Account currently on credit hold will not be present beneath the Shipment List label on the Shipment List Page")]
        public void ThenTheVerbiageAccountCurrentlyOnCreditHoldWillNotBePresentBeneathTheShipmentListLabelOnTheShipmentListPage()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementNotPresent(attributeName_id, "CreditHoldAccount", "Shipment List verbiage");
        }
    }
}