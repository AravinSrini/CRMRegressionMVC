using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Xml.Linq;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using System.Net.Http;
using CRM.UITest.Helper.ViewModel.Shipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.CsaServiceReference;
using System.Linq;
using System.Threading;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers
{
    [Binding]
    public class ShipmentList_GridDisplay_InternalUsersSteps : Shipmentlist
    {
        string errorMessage = null;

        [When(@"I click on the Shipment Icon")]
        public void WhenIClickOnTheShipmentIcon()
        {
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            DefineTimeOut(2000);
        }

        [When(@"I arrive on shipment list page")]
        public void WhenIArriveOnShipmentListPage()
        {
            Report.WriteLine("Verifying shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListInternal_CustDropdownVal_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                int j = i - 1;
                if (DropDownList[i].Text == "ZZZ - Czar Customer Test")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Report.WriteLine("Customer is chosen");
        }

        [When(@"I arrive on shipment list page of externaluser")]
        public void WhenIArriveOnShipmentListPageOfExternaluser()
        {
            Report.WriteLine("Verifying shipment list page");
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }


        [Then(@"displaying last (.*)days shipments should match with API results (.*)")]
        public void ThenDisplayingLastDaysShipmentsShouldMatchWithAPIResults(int p0, string stationData)
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
}
