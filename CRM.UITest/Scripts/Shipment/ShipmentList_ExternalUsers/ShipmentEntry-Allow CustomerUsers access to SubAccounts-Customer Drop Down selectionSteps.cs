using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_ExternalUsers 
{
    [Binding]
    public class ShipmentEntry_Allow_CustomerUsers_access_to_SubAccounts_Customer_Drop_Down_selectionSteps : Shipmentlist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        AddShipmentLTL ltl = new AddShipmentLTL();
        WebElementOperations getListfromWebElement = new WebElementOperations();

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates users")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesUsers()
        {
            string username = ConfigurationManager.AppSettings["username-ExtuserCustDropdown"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExtuserCustDropdown"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I arrive on the Shipment List page associated to a primary account that has sub accounts")]
        public void WhenIArriveOnTheShipmentListPageAssociatedToAPrimaryAccountThatHasSubAccounts()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on shipment icon");
            ltl.NaviagteToShipmentList();
        }

        [Then(@"the grid should be empty and display the following - Please select a customer to view Shipments")]
        public void ThenTheGridShouldBeEmptyAndDisplayTheFollowing_PleaseSelectACustomerToViewShipments()
        {
            string expectedMessage = "Please select a customer to view Shipments";
            string actualGridMessage = Gettext(attributeName_xpath, ShipmentList_EmptyGrid_xpath);
            Assert.AreEqual(actualGridMessage, expectedMessage);
        }

        [Then(@"the customer drop down will be set to Select\.\.\.")]
        public void ThenTheCustomerDropDownWillBeSetToSelect_()
        {
            string defaultSelection = "Select...";
            string actualSelection = Gettext(attributeName_xpath, ShipmentList_CustomerDropdown_Xpath);
            Assert.AreEqual(defaultSelection, actualSelection);

        }

        [Then(@"Verify the options on the customer drop down list for the user")]
        public void ThenVerifyTheOptionsOnTheCustomerDropDownListForTheUser()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the Customer drop down list will be displayed with options Select, All Customers, primary account and mapped subaccounts")]
        public void ThenTheCustomerDropDownListWillBeDisplayedWithOptionsSelectAllCustomersPrimaryAccountAndMappedSubaccounts()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            //Customer dropdown default to Select
            string actualSelectOption = Gettext(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            Assert.AreEqual(actualSelectOption, "Select...");
            GlobalVariables.webDriver.WaitForPageLoad();
            //Customer Drop down displaying with Select, All Customers,Primary account and mapped subaccounts
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> CustomerAllUI = GlobalVariables.webDriver.FindElements(By.XPath(CustomerDropdownValesExtuser_Xpath));
            List<string> dropdownOptions = getListfromWebElement.GetListFromIWebElement(CustomerAllUI);
            Report.WriteLine("Customer Dropdown displaying with " + dropdownOptions.Contains("Select..."));
            Report.WriteLine("Customer Dropdown displaying with " + dropdownOptions.Contains("All Customers"));
            Report.WriteLine("Customer Dropdown displaying with " + dropdownOptions.Contains(customerNameActual));

            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));
            List<string> primarySubAccountsUI = getListfromWebElement.GetListFromIWebElement(subAccounts);
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);

            Assert.AreEqual(customerNamesList.Count, primarySubAccountsUI.Count);
            Report.WriteLine("Customer Dropdown displayed with Sub accounts");
        }


        [Then(@"ADD Shipment button will be hidden")]
        public void ThenADDShipmentButtonWillBeHidden()
        {
            Report.WriteLine("Visibility of Submit Rate Request button");
            VerifyElementNotVisible(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment Button");
            
        }

        [Given(@"I arrive on the Shipment List page associated to a primary account that has sub accounts")]
        public void GivenIArriveOnTheShipmentListPageAssociatedToAPrimaryAccountThatHasSubAccounts()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on shipment icon");
            ltl.NaviagteToShipmentList();
        }

        [When(@"I click on the Customer drop down list")]
        public void WhenIClickOnTheCustomerDropDownList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentList_CustomerDropdown_Xpath);
        }

        [Then(@"the customers will be displayed in hierarchy format")]
        public void ThenTheCustomersWillBeDisplayedInHierarchyFormat()
        {
            string customerNameActual = "ZZZ - Czar Customer Test";
            List<string> customerNamesList = DBHelper.GetCustomerNameOfSubAccountUnderPrimaryAccount(customerNameActual);

            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            IList<IWebElement> subAccounts = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));
            List<string> SubAccountListValues = getListfromWebElement.GetListFromIWebElement(subAccounts);

            Assert.AreEqual(customerNamesList.Count, SubAccountListValues.Count);
            Report.WriteLine("Displayed sub accounts mapped to the chosen primary account");

        }

        [Then(@"Sub accounts associated to primary account are displayed in alphabetical order")]
        public void ThenSubAccountsAssociatedToPrimaryAccountAreDisplayedInAlphabeticalOrder()
        {
            IList<IWebElement> dropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FirstlevelSubAccountsDropdownValues_Xpath));
            List<string> actualDropdownlist = getListfromWebElement.GetListFromIWebElement(dropDownList);

            List<string> alphabeticalArray = new List<string>();
            for (int i = 0; i < actualDropdownlist.Count; i++)
            {
                alphabeticalArray.Add(actualDropdownlist[i]);
            }
            actualDropdownlist.Sort();
            CollectionAssert.AreEqual(actualDropdownlist, alphabeticalArray);
            Report.WriteLine("Displayed Customers are sorted in alphabetical order");
        }


    }
}
