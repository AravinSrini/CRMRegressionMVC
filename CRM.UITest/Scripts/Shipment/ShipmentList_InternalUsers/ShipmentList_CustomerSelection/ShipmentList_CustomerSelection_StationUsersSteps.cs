using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers
{
    [Binding]
    public class ShipmentList_CustomerSelection_StationUsersSteps : Shipmentlist
    {
        string errorMessage = null;

        [When(@"I click on customer drop down in shipment list page")]
        public void WhenIClickOnCustomerDropDownInShipmentListPage()
        {
            Report.WriteLine("Clicking on customer dropdown");
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
        }
        
        [When(@"I select any customer account (.*) from the customer dropdown in shipment list")]
        public void WhenISelectAnyCustomerAccountFromTheCustomerDropdownInShipmentList(string account)
        {
            Report.WriteLine("Clicking on customer dropdown");
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, account);
            WaitForElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
        }
        
        [When(@"I select any (.*) from view dropdown present in top grid of shipment list page")]
        public void WhenISelectAnyFromViewDropdownPresentInTopGridOfShipmentListPage(string option)
        {
            Report.WriteLine("Selecting value from view dropdown");
            SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, option);
        }
        
        [When(@"I select All customers from the dropdown in shipment list page")]
        public void WhenISelectAllCustomersFromTheDropdownInShipmentListPage()
        {
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath,"All Customers");
            VerifyElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
        }
        
        [When(@"I select any customeraccount (.*) from the customer dropdown in shipment list")]
        public void WhenISelectAnyCustomeraccountFromTheCustomerDropdownInShipmentList(string Account)
        {
            Report.WriteLine("Selecting account from station customer dropdown");
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, Account);
        }
        
        [Then(@"list of customers to which I am associated will be displayed and should match with database (.*)")]
        public void ThenListOfCustomersToWhichIAmAssociatedWillBeDisplayedAndShouldMatchWithDatabase(string stationData)
        {
            string[] values = stationData.Split(',');
            List<string> StatID = new List<string>();
            List<string> ExpAcc = new List<string>();
            foreach (var v in values)
            {
                StatID.Add(v);
            }
            for (int i = 0; i < StatID.Count; i++)
            {
                string setupId = StatID[i];
                List<CustomerSetup> value = DBHelper.GetRecordsMappedforStationID(setupId);

                for (int j = 0; j < value.Count; j++)
                {
                    string custname = value[j].CustomerName;
                    ExpAcc.Add(custname);
                }
            }

            int UICount = GetCount(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath);
            Assert.AreEqual(ExpAcc.Count + 1, UICount);
            Report.WriteLine("Displaying Customer account list count is matching with DB count");

            IList<IWebElement> UIvalue = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerSelection_Dropdown_Values_Xpath));

            for (int k = 1; k < UIvalue.Count; k++)
            {
                if (ExpAcc.Contains(UIvalue[k].Text))
                {
                    Report.WriteLine("Displaying Customer account " + UIvalue[k].Text + " is mapped to logged in user");
                }
                else
                {
                    Report.WriteLine("Displaying Customer account " + UIvalue[k].Text + " is not mapped to logged in user");
                    Assert.IsTrue(false);
                }
            }
        }
        
        [Then(@"All Customers option should be selected by default in shipment list page")]
        public void ThenAllCustomersOptionShouldBeSelectedByDefaultInShipmentListPage()
        {
            Report.WriteLine("Verifying the default selected value in customer dropdown");
            string value = Gettext(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            Assert.AreEqual(value, "All Customers");
        }

        [Then(@"all the associated past (.*)days MG shipments for the selected customer should be displayed and should match with API (.*)")]
        public void ThenAllTheAssociatedPastDaysMGShipmentsForTheSelectedCustomerShouldBeDisplayedAndShouldMatchWithAPI(int p0, string Account)
        {
            
            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");


                string uri = $"MercuryGate/ListScreenExtract";
                ShipmentListScreen Slist = new ShipmentListScreen();
                List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

                if (Sdata != null)
                {
                    for (int j = 1; j < Sdata.Count; j++)
                    {
                        ShipList.Add(Sdata[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
                }

            //Getting UI Shipment List
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipValues = UIShipments[k].Text;
                    UIValue.Add(UIShipValues);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }
        
        [Then(@"all the associated past (.*)days CSA shipments for the selected customer should be displayed and should match with API (.*)")]
        public void ThenAllTheAssociatedPastDaysCSAShipmentsForTheSelectedCustomerShouldBeDisplayedAndShouldMatchWithAPI(int p0, string Account)
        {
            int accID = DBHelper.GetAccountIdforAccountName(Account.Trim());
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);
            List<string> ShipList = new List<string>();

            ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
            ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(csaNumb, out errorMessage);

            if (APIShipments != null)
            {
                List<string> ShipValue = APIShipments.Shipments.Select(a => a.Housebill).ToList();
                foreach (var t in ShipValue)
                {
                    ShipList.Add(t);
                }
            }
            else
            {
                Report.WriteLine("Data not found for the CSA station account number" + value.CsaCustomerNumber);
            }

            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipNumber = UIShipments[k].Text;
                    UIValue.Add(UIShipNumber);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }
        
        [Then(@"all the associated past (.*)days MG and CSA shipments for the selected customer should be displayed and should match with API (.*)")]
        public void ThenAllTheAssociatedPastDaysMGAndCSAShipmentsForTheSelectedCustomerShouldBeDisplayedAndShouldMatchWithAPI(int p0, string Account)
        {
            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            if (Sdata != null)
            {
                for (int j = 1; j < Sdata.Count; j++)
                {
                    ShipList.Add(Sdata[j].PrimaryReference);
                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
            }

            CustomerAccount valued = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(valued.CsaCustomerNumber);

            ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
            ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(csaNumb, out errorMessage);
            if (APIShipments != null)
            {
                List<string> ShipValue = APIShipments.Shipments.Select(a => a.Housebill).ToList();
                foreach (var t in ShipValue)
                {
                    ShipList.Add(t);
                }
            }
            else
            {
                Report.WriteLine("Data not found for the CSA station account number" + csaNumb);
            }

            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipNumber = UIShipments[k].Text;
                    UIValue.Add(UIShipNumber);
                }

                Assert.AreEqual(ShipList.Count, UIValue.Count);
                CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
                Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }
        }
        
        [Then(@"recently selected (.*) should be binded in shipment list page")]
        public void ThenRecentlySelectedShouldBeBindedInShipmentListPage(string account)
        {
            Report.WriteLine("Verifying the selected account from the dropdown");
            string actselValue = Gettext(attributeName_xpath, ShipmentList_CustomerDropdown_SelectedValue_Xpath);
            if(actselValue.Contains(account))
            {
                Report.WriteLine("Able to select only one account from the dropdown");
            }
            else
            {
                Report.WriteFailure("Selected account is not displaying in the account dropdown");
                Assert.IsTrue(false);
            }
        }
        
        [Then(@"shipment list grid should be empty")]
        public void ThenShipmentListGridShouldBeEmpty()
        {
            Report.WriteLine("Verifying the shipment list grid");
            VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records");
        }
        
        [Then(@"message will be displayed in shipment list grid section along with (.*) name")]
        public void ThenMessageWillBeDisplayedInShipmentListGridSectionAlongWithName(string accountName)
        {
            Report.WriteLine("Verifying no records found for the selected account");
            string actualmessage = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            Assert.AreEqual(actualmessage, "There are no shipments within the past 30 days for the selected customer_" + accountName);
        }
    }
}
