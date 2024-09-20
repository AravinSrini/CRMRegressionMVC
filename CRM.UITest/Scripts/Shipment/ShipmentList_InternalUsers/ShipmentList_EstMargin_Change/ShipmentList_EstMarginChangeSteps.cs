using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
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

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_EstMargin_Change
{
    [Binding]
    public class ShipmentList_EstMarginChangeSteps : Shipmentlist
    {
        [Then(@"EstMargin should be read as N/A for the Est Revenue is zero or N/A")]
        public void ThenEstMarginShouldBeReadAsNAForTheEstRevenueIsZeroOrNA()
        {
            Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");

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

            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr/td[9]"));
            if (UIShipments.Count > 0)
            {
                for (int i = 1; i <= UIShipments.Count; i++)
                {
                    string EstReveValue = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[9]/span[2]");
                    if (EstReveValue == "$0.00")
                    {
                        string EstMargin = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[9]/span[6]");
                        Assert.AreEqual(EstMargin, "N/A");
                        break;
                    }
                }
            }
        }


        //[Then(@"I should get results from API(.*),(.*),(.*)")]
        //public void ThenIShouldGetResultsFromAPI(string stationData, string Standard_report, string CustomerName)
        //{
        //    string errorMessage = string.Empty;
        //    Click(attributeName_xpath, "//*[@id='ShipmentGrid_length']/label/select");
        //    IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_TopGrid_ViewDropdownValues_Xpath));
        //    if(DropDownList.Count>0)
        //    { 
        //    int DropDownCount = DropDownList.Count;
        //    for (int i = 0; i < DropDownCount; i++)
        //    {
        //        if (DropDownList[i].Text == "ALL")
        //        {
        //            DropDownList[i].Click();
        //            break;
        //        }
        //    }


        //        if (CustomerName == "Admin")
        //        {


        //            string[] values = stationData.Split(',');
        //            List<string> StatID = new List<string>();
        //            List<String> ShipList = new List<string>();

        //            foreach (var v in values)
        //            {
        //                StatID.Add(v);
        //            }
        //            for (int i = 0; i < StatID.Count; i++)
        //            {
        //                CustomerSetup value = DBHelper.GetStationDetailsById(StatID[i]);
        //                ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
        //                XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, Standard_report);
                        
        //                BuildHttpClient client = new BuildHttpClient();
        //                HttpClient headers = client.BuildHttpClientWithHeaders(CustomerName, "application/xml");


        //                string uri = $"MercuryGate/ListScreenExtract";
        //                ShipmentListScreen Slist = new ShipmentListScreen();
        //                List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);
        //                List<ShipmentListViewModel> Sdata1 = new List<ShipmentListViewModel>();

        //                if (Sdata != null && Sdata.Any())
        //                {
        //                    for (int j = 1; j <= Sdata.Count; j++)
        //                    {
        //                        if (Sdata[j].EstRevenue == "0.00" || Sdata[j].EstRevenue == "0")
        //                        {
        //                            Sdata1.Add(Sdata[j]);
        //                        }
        //                    }

        //                    for (int p = 0; p < Sdata1.Count; p++)
        //                    {
        //                        string sd = Sdata1[p].PrimaryReference;
        //                        SendKeys(attributeName_id, "searchbox", sd);
        //                        Thread.Sleep(2000);
                                
        //                            string EstMargin = Gettext(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[1]/td[9]/span[6]");
        //                            Assert.AreEqual(EstMargin, "N/A");
                                
        //                        break;
        //                    }

        //                }

        //                else
        //                {
        //                    Report.WriteLine("by Default CSA has no Rates and hence it will be always N/A");
        //                }
        //            }
        //        }

        //        }
        //    else
        //    {
        //        Report.WriteLine("No Shipments Found for the Logged in User");
        //    }

        //    }
                  
    }

}