using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.Helper.ViewModel.Shipment;
namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_GridDisplay_ExternalUsers
{
    [Binding]
    public class ShipmentList_ShipmentListGridDisplay_ExternalUsersSteps : Shipmentlist
    {
        [Then(@"Displayed last thirty days shipments should match with API results '(.*)'")]
        public void ThenDisplayedLastThirtyDaysShipmentsShouldMatchWithAPIResults(string Account)
        {
            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", Account);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Account, "application/xml");


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

            }
            else
            {
                Report.WriteLine("Values does not exist in shipment list response");
            }

        }

    

        
    }
}
