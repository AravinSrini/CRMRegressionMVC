using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations.StandardReport;
using System.Xml.Linq;
using System.Net.Http;
using CRM.UITest.Helper.Implementations.ShipmentList;
using System.Threading;

namespace CRM.UITest
{
    [Binding]
    public class FeatureRateRequest_AllowCustomerUsersAccessToSub_Accounts_NavigatedAwayAndReturnToQuoteListPageSteps:Quotelist
    {
        string errorMessage = string.Empty;
        [Given(@"I select primary-Customer from the customer drop down list")]
        public void GivenISelectPrimary_CustomerFromTheCustomerDropDownList()
        {
            Report.WriteLine("selecting primary-Customer from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath,CustomerDropdownValesExtuser_Xpath, "ZZZ - Czar Customer Test");
        }
        
        [Given(@"I have navigated away from the Quote List page")]
        public void GivenIHaveNavigatedAwayFromTheQuoteListPage()
        {
            Report.WriteLine("navigating away from the Quote List page");
            Click(attributeName_id,ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I select Customer from the customer drop down list")]
        public void GivenISelectCustomerFromTheCustomerDropDownList()
        {
            Report.WriteLine("selecting primary-Customer from the customer drop down list");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDropdownExtuser_Xpath);
            SelectDropdownValueFromList(attributeName_xpath,CustomerDropdownValesExtuser_Xpath, "ZZZ - Czar Customer Test");
        }
        
        [When(@"I return to the Quote List Page")]
        public void WhenIReturnToTheQuoteListPage()
        {
            Report.WriteLine("Returning to the Quote List Page");
            Click(attributeName_id,QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I navigate to the shipment List page")]
        public void WhenINavigateToTheShipmentListPage()
        {
            Report.WriteLine("navigating to the shipment List page");
            Click(attributeName_id, ShipmentIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"previously selected customer will be selected in the customer drop down list")]
        public void ThenPreviouslySelectedCustomerWillBeSelectedInTheCustomerDropDownList()
        {
            Report.WriteLine("previously selecting customer will be selected in the customer drop down list");
            Assert.AreEqual(Gettext(attributeName_xpath, CustomerDropdownExtuser_Xpath), "ZZZ - Czar Customer Test");
        }

        [Then(@"Quote List grid will refresh to display all quotes associated to previously selected customer for the past (.*) days")]
        public void ThenQuoteListGridWillRefreshToDisplayAllQuotesAssociatedToPreviouslySelectedCustomerForThePastDays(int p0)
        {
            string customerName = "ZZZ - Czar Customer Test";
            //Assert.AreEqual(Gettext(attributeName_id, QuoteList_CustomerDropdown_Xpath), customerName);
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

            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> quoteListUI = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberInternal_Values_Xpath));
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
                Report.WriteLine("No Quotes exists for the selected station");
                VerifyElementPresent(attributeName_xpath, QuoteList_NoResults_Xpath, "No Records Found");
            }
            Assert.AreEqual(quoteList.Count, actualQuoteList.Count);
           // Assert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
            //CollectionAssert.AreEqual(quoteList.OrderBy(q => q).ToList(), actualQuoteList.OrderBy(q => q).ToList());
            Report.WriteLine("Displaying quote list in the UI is matching with API results");
        }

        [Then(@"shipment List grid will refresh to display all shipments associated to previously selected customer for the past (.*) days")]
        public void ThenShipmentListGridWillRefreshToDisplayAllShipmentsAssociatedToPreviouslySelectedCustomerForThePastDays(int p0)
        {
            string Primary_AccountCustomer = "ZZZ - Czar Customer Test";
            int accID = DBHelper.GetAccountIdforAccountName(Primary_AccountCustomer);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", Primary_AccountCustomer);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Primary_AccountCustomer, "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<Helper.ViewModel.Shipment.ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            List<String> ShipmentList = new List<string>();

            if (Sdata != null)
            {

                for (int j = 0; j < Sdata.Count; j++)
                {
                    if (Sdata[j].CustomerName.Contains(Primary_AccountCustomer))
                    {
                        ShipmentList.Add(Sdata[j].ToString());
                    }
                }
            }
            else
            {
                Report.WriteLine("No Response from API");
            }
            Shipmentlist shipList = new Shipmentlist();
            Click(attributeName_xpath, shipList.ShipmentList_TopGrid_ViewDropdown_Xpath);
            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(shipList.ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerDropdown_List[i].Text == "ALL")
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            DefineTimeOut(4000);
            IList<IWebElement> UIShipmentVal = GlobalVariables.webDriver.FindElements(By.XPath(shipList.ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            if (ShipmentList.Count > 0)
            {
                for (int k = 0; k < UIShipmentVal.Count; k++)
                {
                    string UIShipNum = UIShipmentVal[k].Text;
                    UIValue.Add(UIShipNum);
                }

                Assert.AreEqual(ShipmentList.Count, UIValue.Count);

            }

            else
            {
                Report.WriteLine("Values does not exist in shipment list response");
            }
                      
        }
        
        [Then(@"customer previously selected will be selected in the customer drop down list of shipment list page")]
        public void ThenCustomerPreviouslySelectedWillBeSelectedInTheCustomerDropDownListOfShipmentListPage()
        {
            Report.WriteLine("previously selected will be selected in the customer drop down list of shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Shipmentlist shipmentListObject = new Shipmentlist();
            string expectedBindingValue = Gettext(attributeName_xpath, ".//*[@id='CustomerType_chosen']/a");
            Assert.AreEqual(expectedBindingValue, "ZZZ - Czar Customer Test");
        }
    }
}
