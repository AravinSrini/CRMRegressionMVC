using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;

using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.AspNet.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.StandardReports
{
    [Binding]
    public class Standard_Reports_Station_UsersSteps : Shipmentlist
    {


        [Then(@"the shipment list will update to only display the standard report from MG for the selected customer(.*),(.*),(.*)")]
        public void ThenTheShipmentListWillUpdateToOnlyDisplayTheStandardReportFromMGForTheSelectedCustomer(string StationData, string Standard_ReportNameMG, string CustomerName)
        {
            Thread.Sleep(6000);
            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
            // SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "ALL")
                {
                    DropDownList[i].Click();
                    break;
                }

                int accID = DBHelper.GetAccountIdforAccountName(CustomerName);
                CustomerSetup value = DBHelper.GetSetupDetails(accID);

                // Building request xml
                ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, Standard_ReportNameMG, CustomerName);

                //Building Client
                BuildHttpClient client = new BuildHttpClient();
                HttpClient headers = client.BuildHttpClientWithHeaders(CustomerName, "application/xml");


                string uri = $"MercuryGate/ListScreenExtract";
                ShipmentListScreen Slist = new ShipmentListScreen();
                List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

                List<String> ShipmentList = new List<string>();

                if (Sdata != null)
                {

                    for (int j = 1; j < Sdata.Count; j++)
                    {
                        ShipmentList.Add(Sdata[j].PrimaryReference);
                    }
                }
                else
                {
                    Report.WriteLine("No Response from API");
                }

                IList<IWebElement> UIShipmentVal = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
                List<string> UIValue = new List<string>();
                if (ShipmentList.Count > 1)
                {
                    for (int k = 0; k < UIShipmentVal.Count; k++)
                    {
                        string UIShipNum = UIShipmentVal[k].Text;
                        UIValue.Add(UIShipNum);
                    }

                    Assert.AreEqual(ShipmentList.Count, UIValue.Count);
                    //UIValue.Reverse();//reversed code
                    //CollectionAssert.AreEqual(ShipmentList, UIValue);

                }
                else
                {
                    Report.WriteLine("Values does not exists in shipment list response");
                }
            }
        }


        [Then(@"I select SELECT A REPORT option from the report drop down list")]
        public void ThenISelectSELECTAREPORTOptionFromTheReportDropDownList()
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, "Select a Report");

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[1]");
        }



        [Then(@"the shipment list will update to only display the standard report from MG and CSA\(Both\) for the selected customer (.*),(.*)")]
        public void ThenTheShipmentListWillUpdateToOnlyDisplayTheStandardReportFromMGAndCSABothForTheSelectedCustomer(string Customer_Name, string Standard_MGReportName)
        {
            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
            SelectDropdownlistvalue(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select", "ALL");
            Click(attributeName_xpath, "//*[@id='ShipmentGrid']/thead/tr/th[1]");

            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(Customer_Name);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, Standard_MGReportName, Customer_Name);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Customer_Name, "application/xml");



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
                Report.WriteLine("Not received any reposnse from API");
            }


            int SetUpID = DBHelper.GetAccountIdforAccountName(Customer_Name);
            CustomerAccount valueList = DBHelper.GetAccountDetails(SetUpID);
            string TMSType = valueList.TmsSystem;
            // int _number = Convert.ToInt32(Num);


            //string DBdetails = DBHelper.GetStationNameonStationID(StatID[i]);
            //        List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(DBdetails);


            if (TMSType == "CSA" || TMSType == "BOTH")
            {
                CSAShipmentListReports CSAShip = new CSAShipmentListReports();
                ShipmentListReponse APIShipments = CSAShip.GetCSAShipmentListStandardReport(Convert.ToInt32(valueList.CsaCustomerNumber), out errorMessage, Standard_MGReportName);
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
                    Report.WriteLine("Data not found for the CSA station account number");
                }

            }

            //Getting UI Shipment List
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIQuoteNumber = UIShipments[k].Text;
                    UIValue.Add(UIQuoteNumber);
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


        [Then(@"the shipment list will update to only display the standard report from CSA for the selected customer(.*),(.*)")]
        public void ThenTheShipmentListWillUpdateToOnlyDisplayTheStandardReportFromCSAForTheSelectedCustomer(string Customer_Name, string Standard_ReportName)
        {
            string errorMessage = "errorMessage";
            CSAShipmentListReports CSAShipments = new CSAShipmentListReports();
           // ShipmentListReponse APIQuotes = CSAShipments.GetCsaShipmentListReport(123, out errorMessage, "CRM-ShpPrev30Days", "pickupDate", "dropoffDate", false, "srviceType", " ServiceLevel", "refNo", "status", "originCity", "destCity");

        }

        [Then(@"the default customer selection will be All Customers")]
        public void ThenTheDefaultCustomerSelectionWillBeAllCustomers()
        {
            string ActualTextUI = Gettext(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            string allCutomer = "All Customers";
            Assert.AreEqual(allCutomer, ActualTextUI);
        }


        [Then(@"I will not get any report")]
        public void ThenIWillNotGetAnyReport()
        {
            string ActualTextUI = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            string NoResults = "No Results Found";
            Assert.AreEqual(NoResults, ActualTextUI);
        }

        [Then(@"the shipment list will update to display message no results found in the shipment list grid")]
        public void ThenTheShipmentListWillUpdateToDisplayMessageNoResultsFoundInTheShipmentListGrid()
        {
            string ActualTextUI = Gettext(attributeName_xpath, ShipmentList_NoRecords_Xpath);
            string NoResults = "No Results Found";
            Assert.AreEqual(NoResults, ActualTextUI);
        }




        [Then(@"I select ALL CUSTOMER from the report drop down list")]
        public void ThenISelectALLCUSTOMERFromTheReportDropDownList()
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            Click(attributeName_xpath, ".//*[@id='CustomerType_chosen']/div/ul/li[1]");
        }



        string errorMessage = null;

        [Then(@"the shipment list display will default to the shipments for the previous thirty days(.*),(.*),(.*)")]
        public void ThenTheShipmentListDisplayWillDefaultToTheShipmentsForThePreviousThirtyDays(string stationData, string Standard_report, string CustomerName)
        {

            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
           // SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, "ALL");

            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "ALL")
                {
                    DropDownList[i].Click();
                    break;
                }
            }


            if (CustomerName == "Admin")
            {


                string[] values = stationData.Split(',');
                List<string> StatID = new List<string>();
                List<String> ShipList = new List<string>();

                foreach (var v in values)
                {
                    StatID.Add(v);
                }
                for (int i = 0; i < StatID.Count; i++)
                {
                    //Calling db to get account number for the mapped station 
                    CustomerSetup value = DBHelper.GetStationDetailsById(StatID[i]);

                    // Building request xml
                    ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
                    XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, Standard_report);

                    //Building Client
                    BuildHttpClient client = new BuildHttpClient();
                    HttpClient headers = client.BuildHttpClientWithHeaders(CustomerName, "application/xml");


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
                        Report.WriteLine("Not received any reposnse from API for Station ID: " + StatID[i]);
                    }

                    string DBdetails = DBHelper.GetStationNameonStationID(StatID[i]);
                    List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(DBdetails);

                    for (int k = 0; k < listvalue.Count; k++)
                    {
                        if (listvalue[k].TmsSystem == "CSA" || listvalue[k].TmsSystem == "BOTH")
                        {
                            ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
                            ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(Convert.ToInt32(listvalue[k].CsaCustomerNumber), out errorMessage);
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
                                Report.WriteLine("Data not found for the CSA station account number" + listvalue[k].CsaCustomerNumber);
                            }

                        }
                    }
                }

                //Getting UI Shipment List
                IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
                List<string> UIValue = new List<string>();

                if (ShipList.Count > 1)
                {

                    for (int k = 0; k < UIShipments.Count; k++)
                    {
                        string UIQuoteNumber = UIShipments[k].Text;
                        UIValue.Add(UIQuoteNumber);
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

        }

        [When(@"I have selected MG Customer from the drop down (.*)")]
        public void WhenIHaveSelectedMGCustomerFromTheDropDown(string Customer_Name)
        {

            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"I have selected standard report type of MG and CSA \(BOth\) (.*)")]
        public void ThenIHaveSelectedStandardReportTypeOfMGAndCSABOth(string Standard_ReportNameDropDown)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportNameDropDown);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }

        [Then(@"I have selected standard report type of MG only (.*)")]
        public void ThenIHaveSelectedStandardReportTypeOfMGOnly(string Standard_ReportNameDropDown)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportNameDropDown);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }

        [When(@"I have selected CSA Customer from the drop down (.*)")]
        public void WhenIHaveSelectedCSACustomerFromTheDropDown(string Customer_Name)
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }


        [Then(@"I have selected standard report type of MG and CSA \(Both\) (.*)")]
        public void ThenIHaveSelectedStandardReportTypeOfMGAndCSABoth(string Standard_ReportNameDropDown)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportNameDropDown);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }


        [When(@"I have selected MG and CSA \(Both\) Customer from the drop down (.*)")]
        public void WhenIHaveSelectedMGAndCSABothCustomerFromTheDropDown(string Customer_Name)
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }


        [When(@"I have selected Standard report (.*)")]
        public void WhenIHaveSelectedStandardReport(string Standard_ReportNameDropDown)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportNameDropDown);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }


        [Then(@"I have a MG customer (.*)")]
        public void ThenIHaveAMGCustomer(string Customer_Name)
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"I have selected MG and CSA \(Both\) customer (.*)")]
        public void ThenIHaveSelectedMGAndCSABothCustomer(string Customer_Name)
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }



        [When(@"I have selected any customer from drop down (.*)")]
        public void WhenIHaveSelectedAnyCustomerFromDropDown(string Customer_Name)
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, ShipmentList_Customer_dropdownValue_Xpath, Customer_Name);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Customer_Name)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }


        [When(@"I have selected any standard report  (.*)")]
        public void WhenIHaveSelectedAnyStandardReport(string Standard_ReportNameDropDown)
        {
            Click(attributeName_xpath, ShipmentList_FilteredReports_Xpath);
            SendKeys(attributeName_xpath, SelectAReportSearchBoxnShipmentList_Xpath, Standard_ReportNameDropDown);

            Click(attributeName_xpath, "//*[@id='ReportType_chosen']/div/ul/li[2]");
        }

        [When(@"my selection criteria does not return any records")]
        public void WhenMySelectionCriteriaDoesNotReturnAnyRecords()
        {
            Report.WriteLine("my selection criteria does not return any records");
        }



    }
}









