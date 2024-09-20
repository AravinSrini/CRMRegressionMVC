using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_CustomerSelection
{
    [Binding]
    public class ShipmentList_CustomerSearchOption_StationUsersSteps : Shipmentlist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am an operations, sales, sales management, or station owner user (.*) and (.*)")]
        public void GivenIAmAnOperationsSalesSalesManagementOrStationOwnerUserAnd(string userName, string password)
        {
            crm.LoginToCRMApplication(userName, password);
        }
        
        [When(@"I am on the Shipment List page,")]
        public void WhenIAmOnTheShipmentListPage()
        {
            Report.WriteLine("Navigating to the shipment list");
            AddShipmentLTL ltl = new AddShipmentLTL();
            ltl.NaviagteToShipmentList();
        }
        
        [Then(@"I have the option to search for customers (.*) in which I am associated from the customer drop down list")]
        public void ThenIHaveTheOptionToSearchForCustomersInWhichIAmAssociatedFromTheCustomerDropDownList(string searchOption)
        {
            Report.WriteLine("Clicking on station customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            int cusValues = GetCount(attributeName_xpath, ".//*[contains(@class,'active-result')]");
            if (cusValues > 10)
            {
                WaitForElementVisible(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, "Dropdown Search");
                SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, searchOption);
                int totalResult = GetCount(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath);
                Assert.AreEqual(2, totalResult);
                Report.WriteLine("Customer dropdown is displaying only matching result");
                string actText = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='CustomerType_chosen']/div/ul/li[2]")).Text;
                Assert.AreEqual(actText, searchOption);
                Report.WriteLine("Passed customer " + searchOption + " is displaying customer dropdown" + actText);
            }
            else
            {
                Report.WriteLine("Unable to see search dropdown as the number of customer accounts is less than 10");
            }
        }

        [Then(@"I have the option to search for station (.*) in which I am associated from the customer drop down list")]
        public void ThenIHaveTheOptionToSearchForStationInWhichIAmAssociatedFromTheCustomerDropDownList(string searchOption)
        {

            Report.WriteLine("Clicking on station customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            int cusValues = GetCount(attributeName_xpath, ".//*[contains(@class,'active-result')]");
            if (cusValues > 10)
            {
                WaitForElementVisible(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, "Dropdown Search");
                SendKeys(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, searchOption);
                Report.WriteLine("Station Customer dropdown is displaying only matching result");
                string actText = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='CustomerType_chosen']/div/ul/li[2]")).Text;
                Assert.AreEqual(actText, searchOption);
                Report.WriteLine("Passed station " + searchOption + " is displaying customer dropdown" + actText);
            }
            else
            {
                Report.WriteLine("Unable to see search dropdown as the number of customer accounts is less than 10");
            }
        }

        [Then(@"I will not see search box when number of customers is less than (.*)")]
        public void ThenIWillNotSeeSearchBoxWhenNumberOfCustomersIsLessThan(int p0)
        {
            Report.WriteLine("Clicking on station customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            int cusValues = GetCount(attributeName_xpath, ".//*[contains(@class,'active-result')]");
            if (cusValues < 10)
            {
                Report.WriteLine("Search box is not visible as number of customer accounts is less than 10");
            }
            else
            {
                WaitForElementVisible(attributeName_xpath, ShipmentList_CustomerSelection_DropdownSearch_Xpath, "Dropdown Search");
                Report.WriteLine("Search box is visible as number of customer accounts is more than 10");
            }
        }
    }
}
