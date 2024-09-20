using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Dashboard.Dashboard_Create_Quote_Shipment
{
    [Binding]
    public sealed class _109018___Dashboard___Station_Users___Filtered_Customer_Functionality_Steps : ObjectRepository
    {
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();

        [Given(@"I selected the customer ""(.*)"" from the account drop down in the Create Shipment or Quote section")]
        public void GivenISelectedTheCustomerFromTheAccountDropDownInTheCreateShipmentOrQuoteSection(string customerName)
        {
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "loading icon");
            Report.WriteLine("Selecting " + customerName + " from the account drop down");
            Click(attributeName_id, Dashboard_Select_Customer_DropDown_Id);
            SelectDropdownValueFromList(attributeName_id, Dashboard_Select_Customer_DropDown_Id, customerName);
        }

        [Given(@"I navigate to the Quote List page")]
        [When(@"I navigate to the Quote List page")]
        public void WhenINavigateToTheQuoteListPage()
        {
            Report.WriteLine("Navigating to the quote list page");
            clickMethods.ClickAndWait(attributeName_id, QuoteIcon_Id);
        }

        [Given(@"I select the station ""(.*)"" from the shipment list account drop down")]
        [Given(@"I select the customer ""(.*)"" from the shipment list account drop down")]
        public void GivenISelectTheCustomerFromTheShipmentListAccountDropDown(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the account drop down");
            Click(attributeName_id, ShipmentList_Selected_Customer_DropDown_Id);
            SelectDropdownValueFromList(attributeName_id, ShipmentList_Selected_Customer_DropDown_Id, customerName);
        }

        [Given(@"I select the station ""(.*)"" from the quote list account drop down")]
        [Given(@"I select the customer ""(.*)"" from the quote list account drop down")]
        public void GivenISelectTheCustomerFromTheQuoteListAccountDropDown(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the account drop down");
            Click(attributeName_id, QuoteList_Customer_DropDown_Id);
            SelectDropdownValueFromList(attributeName_id, QuoteList_Customer_DropDown_Id, customerName);
        }

        [Given(@"I navigate to the tracking page")]
        public void GivenINavigateToTheUserManagementPage()
        {
            Report.WriteLine("Navigating to the user management page");
            clickMethods.ClickAndWait(attributeName_id, TrackingIcon_Id);
        }

        [Given(@"I select the customer ""(.*)"" from the dashboard account drop down")]
        public void GivenISelectTheCustomerFromTheDashboardAccountDropDown(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the account drop down");
            Click(attributeName_id, Dashboard_Select_Customer_DropDown_Id);
            SelectDropdownValueFromList(attributeName_id, Dashboard_Select_Customer_DropDown_Id, customerName);
        }

        [When(@"I navigate to the Dashboard page")]
        public void GivenIAmOnTheDashboardPage()
        {
            Report.WriteLine("Navigating to the dashboard page");
            clickMethods.ClickAndWait(attributeName_id, Dashboard_Icon_Anchor_Id);
            Thread.Sleep(500);
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading icon");
        }

        [When(@"I navigate to the Shipment List page")]
        public void WhenINavigateToTheShipmentListPage()
        {
            Report.WriteLine("Navigating to the shipment list page");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading icon");
            clickMethods.ClickAndWait(attributeName_id, ShipmentIcon_Id);
        }

        [Then(@"the customer ""(.*)"" will be selected on the quote list page")]
        public void ThenTheCustomerWillBeSelectedOnTheQuoteListPage(string customerName)
        {
            WaitForElementVisible(attributeName_xpath, QuoteList_Selected_DropDown_Span_Xpath, "Selected customer");
            Report.WriteLine("Verifying that the customer " + customerName + " was selected on the quote list page");
            IWebElement selectedCustomer = GlobalVariables.webDriver.FindElement(By.XPath(QuoteList_Selected_DropDown_Span_Xpath));
            if (customerName != "87-Fargo ND")
            {
                Assert.AreEqual(GetCustomerStation(customerName) + " - " + customerName, selectedCustomer.Text);
            }
            else
            {
                Assert.AreEqual(customerName, selectedCustomer.Text);
            }
        }

        [Then(@"the customer ""(.*)"" will be selected on the shipment list page")]
        public void ThenTheCustomerWillBeSelectedOnTheShipmentListPage(string customerName)
        {
            Thread.Sleep(500);
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentList_Selected_Customer_Span_Xpath, "Selected customer");
            Report.WriteLine("Verifying that the customer " + customerName + " was selected on the shipment list page");
            Thread.Sleep(500);
            IWebElement selectedCustomer = GlobalVariables.webDriver.FindElement(By.XPath(ShipmentList_Selected_Customer_Span_Xpath));
            if (customerName != "87-Fargo ND")
            {
                Assert.AreEqual(GetCustomerStation(customerName) + " - " + customerName, selectedCustomer.Text);
            }
            else
            {
                Assert.AreEqual(customerName, selectedCustomer.Text);
            }
        }

        [Then(@"""(.*)"" will be selected on the dashboard")]
        [Then(@"The customer ""(.*)"" will be selected on the dashboard")]
        public void ThenTheCustomerWillBeSelectedOnTheDashboard(string customerName)
        {
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading icon");
            Report.WriteLine("Verifying that the customer " + customerName + " was selected on the shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Dashboard_Selected_Customer_Account_Span_Xpath, "Account Drop Down");
            Thread.Sleep(1000);
            IWebElement selectedCustomer = GlobalVariables.webDriver.FindElement(By.XPath(Dashboard_Selected_Customer_Account_Span_Xpath));
            if (customerName != "Select an account..." && customerName != "87-Fargo ND")
            {
                Assert.AreEqual(GetCustomerStation(customerName) + " - " + customerName, selectedCustomer.Text);
            }
            else
            {
                Assert.AreEqual(customerName, selectedCustomer.Text);
            }
        }

        [Then(@"the quote list will display any quotes associated to the customer for the previous 30 days ""(.*)""")]
        public void ThenTheQuoteListWillDisplayAnyQuotesAssociatedToTheCustomerForThePreviousDays(string customerName)
        {
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_s = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_TopGrid_DisplayListDropdownOptions_Xpath));
            int CustomerDropdown_ship = CustomerDropdown_s.Count;
            for (int i = 0; i < CustomerDropdown_ship; i++)
            {
                if (CustomerDropdown_s[i].Text == "ALL")
                {
                    CustomerDropdown_s[i].Click();
                    break;
                }
            }

            GetListScreenDetails getListScreenDetails = new GetListScreenDetails();
            IList<ShipmentListViewModel> quoteData = getListScreenDetails.GetListScreenDetailsMGForCustomerUsers(customerName);
            List<String> quoteList = new List<string>();
            if (quoteData != null)
            {
                for (int j = 1; j < quoteData.Count; j++)
                {
                    quoteList.Add(quoteData[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("Not received any response from API for selected Customer ");
            }

            IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteGridRefVlaues_Xpath));
            List<string> actualQuoteList = new List<string>();
            Report.WriteLine("UI values count are: " + quoteListUI);

            if (quoteList.Count > 1)
            {
                for (int k = 0; k < quoteListUI.Count; k++)
                {
                    string UIShipValues = quoteListUI[k].Text;
                    actualQuoteList.Add(UIShipValues);
                }

            }
            else
            {
                Report.WriteLine("No Quotes exists for the selected customer");
            }
            Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
            Report.WriteLine("Displaying quote list in the UI is matching with API results");

        }

        [Then(@"the shipment list will display any shipments associated to the customer for the previous 30 days ""(.*)""")]
        public void ThenTheShipmentListWillDisplayAnyShipmentsAssociatedToTheCustomerForThePreviousDays(string customerName)
        {

            List<string> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(customerName);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(customerName, "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            if (Sdata != null)
            {
                for (int j = 1; j < Sdata.Count; j++)
                {
                    if (Sdata[j].CustomerName.Contains(customerName))
                    {
                        ShipList.Add(Sdata[j].PrimaryReference);


                    }

                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
            }

            //Getting UI Shipment List
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotPresent(attributeName_xpath, ShipmentList_Overlay_Xpath, "Loading overlay");
            Click(attributeName_xpath, ShipmentList_TopGrid_ViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_s = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int CustomerDropdown_ship = CustomerDropdown_s.Count;
            for (int i = 0; i < CustomerDropdown_ship; i++)
            {
                if (CustomerDropdown_s[i].Text == "ALL")
                {
                    CustomerDropdown_s[i].Click();
                    break;
                }
            }
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipValues = UIShipments[k].Text;
                    UIValue.Add(UIShipValues);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");

            }
        }

        public string GetCustomerStation(string customerName)
        {
            return DBHelper.GetStationName(customerName);
        }

    }
}
