using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.Implementations.ShipmentImportThirdparty;
using CRM.UITest.Helper.ViewModel;
using Newtonsoft.Json;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml;
using System.Xml.Linq;

namespace CRM.UITest.CommonMethods
{
    public class MgCalls
    {
        public string CreateMGShipment(string customerName, string mgVersion, string serviceCode, string status, string consigneeName,
            string consigneeAddressLine1, string consigneePostalCode, string consigneeCity, string consigneeStateProvince,
            string consigneeCountryCode, string shipperName, string shipperAddressLine1, string shipperPostalCode,
            string shipperCity, string shipperStateProvince, string shipperCountryCode, int itemClass)
        {
            ShipmentImportMockDataViewModel _shipmentImportMockDataViewModel = new ShipmentImportMockDataViewModel();
            ShipmentImportViewModel shipmentModel = _shipmentImportMockDataViewModel.GenerateModel(customerName, 
                serviceCode, status, consigneeName,
            consigneeAddressLine1, consigneePostalCode, consigneeCity, consigneeStateProvince,
            consigneeCountryCode, shipperName, shipperAddressLine1, shipperPostalCode,
            shipperCity, shipperStateProvince, shipperCountryCode, itemClass);
            string referenceNumber = string.Empty;
            HttpClient client = new HttpClient();

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            if (mgVersion == "v2")
                proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];

            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            client.Timeout = TimeSpan.FromSeconds(700000);
            client.BaseAddress = new Uri(proxyApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("CustomerName", customerName);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            var rateRequestJson = JsonConvert.SerializeObject(shipmentModel);
            HttpResponseMessage response = client.PostAsync("Shipment/Import", new StringContent(
            new JavaScriptSerializer().Serialize(shipmentModel), Encoding.UTF8, "application/json")).Result;
            var responseString = response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString.Result);
            if (responseJson != null)
            {
                referenceNumber = responseJson["PrimaryReference"];
            }
            else
            {
                Report.WriteFailure("No Response recieved from MG");
            }

            return referenceNumber;
        }

        public string GetShipmentExtractViewModelFromMG(string customerName, string shipmentMethod, string mgVersion)
        {
            ShipmentImportMockDataViewModel _shipmentImportMockDataViewModel = new ShipmentImportMockDataViewModel();
            ShipmentImportViewModel shipmentModel = _shipmentImportMockDataViewModel.GenerateModel();
            string referenceNumber = string.Empty;
            HttpClient client = new HttpClient();

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            if (mgVersion == "v2")
                proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];

            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            client.Timeout = TimeSpan.FromSeconds(700000);
            client.BaseAddress = new Uri(proxyApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("CustomerName", customerName);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            var rateRequestJson = JsonConvert.SerializeObject(shipmentModel);
            HttpResponseMessage response = client.PostAsync("Shipment/" + shipmentMethod, new StringContent(
            new JavaScriptSerializer().Serialize(shipmentModel), Encoding.UTF8, "application/json")).Result;
            var responseString = response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString.Result);
            if (responseJson != null)
            {
                referenceNumber = responseJson["PrimaryReference"];
            }
            else
            {
                Report.WriteFailure("No Response recieved from MG");
            }

            return referenceNumber;
        }

        public HttpClient BuildHttpClient(string mgVersion, string username, string apiKey, string customerName)
        {
            HttpClient client = new HttpClient();

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            if (mgVersion == "v2")
                proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];
            string proxyUserName = username;
            string proxyApiKey = apiKey;

            int mercuryGateTimeOut;
            int.TryParse(ConfigurationManager.AppSettings["MercuryGateTimeOut"], out mercuryGateTimeOut);
            client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);

            client.BaseAddress = new Uri(proxyApiUrl);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            client.DefaultRequestHeaders.Add("CustomerName", customerName);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            return client;
        }


        public ShipmentExtractViewModel GetShipmentFromReferenceNumber(string referenceNumber)
        {
            string uri = $"MercuryGate/OidLookup";
            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");

            ShipmentExtract ext = new ShipmentExtract();
            return ext.getShipmentData(uri, headers, referenceNumber, "Admin");
        }

        public string getRequestXmlResponse(string user, string method, string apiKey, string customerName, string mgVersion)
        {
            string uri = $"MercuryGate/" + method;
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = BuildHttpClient(mgVersion, user, apiKey, customerName);

            string errorMessage = string.Empty;
            string errorvalue = string.Empty;
            string oidNumber = string.Empty;

            XElement requestXml = getRequestXml(method);
            XmlDocument requestXmlDoc = new XmlDocument();
            requestXmlDoc.LoadXml(requestXml.ToString());

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            HttpResponseMessage response = headers.PostAsXmlAsync(uri, requestXml).Result;

            int status = (int)response.StatusCode;

            return status.ToString();
        }


        public XElement getRequestXml(string method)
        {
            string path = Environment.CurrentDirectory + @"\Helper\Xmls\" + method + "Request.xml";
            XElement requestXml = XElement.Load(path);
            return requestXml;

        }
    }
}
