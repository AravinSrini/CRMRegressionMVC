using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_DisplayShipmentsbyStation
{
    [Binding]
    public class ShipmentList_MVC5_DisplayShipmentsbyStation_StationUsersSteps : AddShipments
    {
        string errorMessage = null;
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am sales user (.*), (.*)")]
        public void GivenIAmSalesUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }


        [When(@"I click on Customer List dropdown arrow")]
        public void WhenIClickOnCustomerListDropdownArrow()
        {
            Click(attributeName_xpath, ShipmentList_CustomerSelection_Xpath);
        }

        [When(@"I select a station (.*)")]
        public void WhenISelectAStation(string stationName)
        {
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, stationName);
            Thread.Sleep(80000);
            //WaitForElementNotVisible(attributeName_xpath, ShipmentListGrid_loadingIcon_Xpath, "loading icon");
        }

        [Then(@"I have the option to select station (.*)")]
        public void ThenIHaveTheOptionToSelectStation(string station)
        {
            Report.WriteLine("Select station from dropdown");
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerSelection_Dropdown_Values_Xpath, station);
        }

        [Then(@"Add shipment button is not visible")]
        public void ThenAddShipmentButtonIsNotVisible()
        {
            Report.WriteLine("Add Shipment button is not visible");
            VerifyElementNotVisible(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id, "Add Shipment");
        }

        [Then(@"shipment list page will be refreshed to display shipments for the past (.*)days for the customers associated to the selected station (.*)")]
        public void ThenShipmentListPageWillBeRefreshedToDisplayShipmentsForThePastDaysForTheCustomersAssociatedToTheSelectedStation(int p0, string stationName)
        {
            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(stationName);
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
            Report.WriteLine("MG API values are: " + Sdata);
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

            //Getting UI Shipment List3            
            SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            Thread.Sleep(10000);
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            Report.WriteLine("UI values count are: "+UIShipments);

            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipValues = UIShipments[k].Text;
                    UIValue.Add(UIShipValues);
                }                             
                
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }

            CustomerAccount val = DBHelper.GetStationDetailsByStationName(stationName);

            string DBdetails = DBHelper.GetStationNameonStationID(val.StationId);
            List<CustomerAccount> listvalue = DBHelper.GetAccountsMappedforStation(DBdetails);
                        
            for (int k = 0; k < listvalue.Count; k++)
            {
                if (listvalue[k].TmsSystem == "CSA" || listvalue[k].TmsSystem == "BOTH")
                {
                    ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
                    ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(Convert.ToInt32(listvalue[k].CsaCustomerNumber), out errorMessage);
                    Report.WriteLine("CSA API values are: "+APIShipments);
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

            Assert.AreEqual(ShipList.Count, UIValue.Count);
            CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
            Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
        }

        [Then(@"shipment list page will refresh to display shipments for the past (.*)days for the customers associated to (.*)")]
        public void ThenShipmentListPageWillRefreshToDisplayShipmentsForThePastDaysForTheCustomersAssociatedTo(int p0, string mappedCustomers)
        {
            List<String> ShipList = new List<string>();
            int accID = DBHelper.GetAccountIdforAccountName(mappedCustomers);
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
            Report.WriteLine("MG API values are: " + Sdata);
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
            SelectDropdownlistvalue(attributeName_xpath, ShipmentList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            Thread.Sleep(10000);
            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            List<string> UIValue = new List<string>();
            Report.WriteLine("UI values Count are: "+UIShipments);
            if (ShipList.Count > 1)
            {

                for (int k = 0; k < UIShipments.Count; k++)
                {
                    string UIShipValues = UIShipments[k].Text;
                    UIValue.Add(UIShipValues);
                }
                
            }
            else
            {
                Report.WriteLine("No shipment exists for the selected account");
                VerifyElementPresent(attributeName_xpath, ShipmentList_NoRecords_Xpath, "No Records Found");
            }           
            Assert.AreEqual(ShipList.Count, UIValue.Count);
            CollectionAssert.AreEqual(ShipList.OrderBy(q => q).ToList(), UIValue.OrderBy(q => q).ToList());
            Report.WriteLine("Displaying default shipment list in the UI is matching with API results");
        }

    }
}
