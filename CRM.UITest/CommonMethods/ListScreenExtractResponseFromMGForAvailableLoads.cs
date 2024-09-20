using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.AvailableLoadsXML;
using CRM.UITest.Helper.ViewModel;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.CommonMethods
{
    class ListScreenExtractResponseFromMGForAvailableLoads
    {
        public List<AvailableLoadsViewModel> ListScreenExtractFromMGForAvailableLoads()
        {
            string uri = null;
            string errormessage;
            List<AvailableLoadsViewModel> availableModel;
            uri = $"MercuryGate/ListScreenExtract";

            //Building Request XML 
            AvailableLoadsRequestXml req = new AvailableLoadsRequestXml();
            XElement reqXML = req.GetAvailableLoadsRequestXml();

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("DLS Worldwide", "application/xml");

            AvailableLoadsResponseXML aXML = new AvailableLoadsResponseXML();
            availableModel = aXML.ResponseXml(uri, headers, reqXML, out errormessage);
            Report.WriteLine("Response from MG");
            return availableModel;
        }
    }
}
