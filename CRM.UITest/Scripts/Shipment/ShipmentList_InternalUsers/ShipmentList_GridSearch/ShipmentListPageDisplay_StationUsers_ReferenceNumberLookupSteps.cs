using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_GridSearch
{
    [Binding]
    public class ShipmentListPageDisplay_StationUsers_ReferenceNumberLookupSteps : AddShipments
{
        [When(@"I have searched (.*) in the Reference Number Lookup field on shipmentlist page")]
        public void WhenIHaveSearchedInTheReferenceNumberLookupFieldOnShipmentlistPage(string referencenumbers)
        {
            Report.WriteLine("Navigate to MVC5 Shipment list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Report.WriteLine("Enter Reference Numbers");
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referencenumbers);
            Report.WriteLine("I click on search arrow of reference number lookup");
            Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I searched (.*) of Inactivecustomer in the Reference Number Lookup field on shipmentlist page")]
        public void WhenISearchedOfInactivecustomerInTheReferenceNumberLookupFieldOnShipmentlistPage(string referencenumbers)
        {
            Report.WriteLine("Navigate to MVC5 Shipment list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Report.WriteLine("Enter Reference Numbers");
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referencenumbers);
            Report.WriteLine("I click on search arrow of reference number lookup");
            Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"customer dropdown selection will be set to Select")]
        public void ThenCustomerDropdownSelectionWillBeSetToSelect()
        {
            Report.WriteLine("Navigate to MVC5 Shipment list");
            GlobalVariables.webDriver.WaitForPageLoad();
            string dropDownValue = Gettext(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);
            Assert.AreEqual(dropDownValue, "Select");
        }

        [Then(@"I should displayed with shipments(.*) mapped to the user")]
        public void ThenIShouldDisplayedWithShipmentsMappedToTheUser(string referencenumbers)
        {
            Report.WriteLine("I should see the results for the entered valid reference numbers in grid");
            GlobalVariables.webDriver.WaitForPageLoad();
            List<string> referenceNumberList = IndividualColumnData(ShipmentList_Referencenumbersgrid_Xpath);
            string[] ShipmentListRefNumberFromUI = referencenumbers.Split(',');
            for (int i = 0; i < referenceNumberList.Count; i++)
            {
                if (ShipmentListRefNumberFromUI.Contains(referenceNumberList[i]))
                {
                    Report.WriteLine("Entered valid Reference values and Reference values appearing in the grid are same");
                }
                else
                {
                    throw new System.Exception("Entered valid Reference values and Reference values appearing in the grid are not same");
                }
            }
        }

        [Then(@"Copy Shipment icon,Create Return Shipment icon,Edit Shipment icon will be disabled")]
        public void ThenCopyShipmentIconCreateReturnShipmentIconEditShipmentIconWillBeDisabled()
        {
            IList<IWebElement> ShipmentValueFromUI = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefValues_Xpath));
            if (ShipmentValueFromUI.Count > 0)
            {
                for (int i = 1; i <= ShipmentValueFromUI.Count; i++)
                {
                    IsElementDisabled(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[11]/a[2]", "Copy Icon");
                    Report.WriteLine("Copy Icon is disabled for inactive customer");
                    IsElementDisabled(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[11]/a[3]", "Return Icon");
                    Report.WriteLine("Return Icon is disabled for inactive customer");
                    IsElementDisabled(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[10]/button", "Edit Icon");
                    Report.WriteLine("Edit Icon is disabled for inactive customer");
                }
            }
        }
    }
}
