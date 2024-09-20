using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace CRM.UITest
{
    [Binding]
    public class ShipmentList_PageDisplayfeatureSteps:Shipmentlist
    {
        [When(@"I select the option Select from the customer drop down")]
        public void WhenISelectTheOptionSelectFromTheCustomerDropDown()
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, "Select");
            Thread.Sleep(2000);
        }

        [Then(@"the Add Shipment button should be hidden(.*)")]
        public void ThenTheAddShipmentButtonShouldBeHidden(string AddShipment)
        {
            Report.WriteLine("Visibility of Add to Shipment button");
            bool a = IsElementPresent(attributeName_id, AddShipmentButton_id, AddShipment);
            if (a == false)
            {
                Report.WriteLine("Add to Shipment button is not available");
            }
            else
            {
                throw new System.Exception("Add to Shipment button is available");
            }
        }

        [Then(@"I should not see the message (.*) beside the customer drop down")]
        public void ThenIShouldNotSeeTheMessageBesideTheCustomerDropDown(string shipmentMessage)
        {
            Report.WriteLine("Visibility of shipment Message");
            VerifyElementNotVisible(attributeName_xpath, ShipmentMessage_xpath, shipmentMessage);
        }


        [Then(@"the grid should be empty and displayed with the (.*) for shipment display")]
        public void ThenTheGridShouldBeEmptyAndDisplayedWithTheForShipmentDisplay(string expectedMessage)
        {
            string actualGridMessage = Gettext(attributeName_xpath, gridMessageDisplay);
            Assert.AreEqual(actualGridMessage, expectedMessage);
        }

        [Then(@"I should be able to See the customer drop down is set to new option Select(.*)")]
        public void ThenIShouldBeAbleToSeeTheCustomerDropDownIsSetToNewOptionSelect(string expectedSelectOption)
        {
            string actualSelectOption = Gettext(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
               Assert.AreEqual(actualSelectOption, expectedSelectOption);
        }


        [Then(@"the customer drop down should not have All Customer option")]
        public void ThenTheCustomerDropDownShouldNotHaveAllCustomerOption()
        {
            Report.WriteLine("Customer drop down should no longer have All customer option");
            bool a = IsElementPresent(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "All Customers" );
            // VerifyElementNotVisible(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, "All customers");
            if (a == false)
            {
                Report.WriteLine("Add to Shipment button is not available");
            }
            else
            {
                throw new System.Exception("Add to Shipment button is available");
            }
        }
        
       
    }
}
