using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.ViewModel.Shipment;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;


namespace CRM.UITest.Helper.Common
{
    public  class GetListScreenDetails
    {
        public List<ShipmentListViewModel> GetListScreenDetailsMG(string station) {

            List<String> QuoteList = new List<string>();

            int accountID = DBHelper.GetAccountIdforAccountName(station);
            CustomerSetup customerSetUp = DBHelper.GetSetupDetails(accountID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListStationUser(customerSetUp.MgAccountNumber, "CRM-QtsPrev30Days");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen quoteList = new ShipmentListScreen();
            List<ShipmentListViewModel> quoteData = quoteList.CallListScreen(uri, headers, reqXML);
            Report.WriteLine("MG API values are: " + quoteData);

            return quoteData;
        }
        public List<ShipmentListViewModel> GetListScreenDetailsMGForCustomerUsers(string Customer)
        {

            List<String> QuoteList = new List<string>();

            int accountID = DBHelper.GetAccountIdforAccountName(Customer);
            CustomerSetup customerSetUp = DBHelper.GetSetupDetails(accountID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListCustomerUser(Customer, "CRM-QtsPrev30DaysByOwner");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen quoteList = new ShipmentListScreen();
            List<ShipmentListViewModel> quoteData = quoteList.CallListScreen(uri, headers, reqXML);
            Report.WriteLine("MG API values are: " + quoteData);

            return quoteData;
        }
    }
}
