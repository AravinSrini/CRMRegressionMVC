using CRM.UITest.Helper.Interfaces;
using System;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class GetRateResultsandCarriers : IGetRateResultsandCarriers
    {
        public XElement GetRateResultsandCarrier(XElement requestXml, string customerAccount, bool callProxyApiVersion2, out string errorMessage,
            bool applyGainShareGuaranteedCalculation)
        {
            XElement responseXml = default(XElement);
            errorMessage = string.Empty;
            string errorvalue = string.Empty;
            string proxyApiUrl = string.Empty;

            if (callProxyApiVersion2)
            {
                proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];
            }else
            {
                proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            }                
               
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            if (string.IsNullOrWhiteSpace(customerAccount))
            {
                customerAccount = string.Empty;
            }
            else
            {
                customerAccount = customerAccount.Trim();
            }

           

            HttpResponseMessage response = null;
            HttpClient client = new HttpClient();
            int mercuryGateTimeOut;
            int.TryParse("70000", out mercuryGateTimeOut);
            client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);
            client.BaseAddress = new Uri(proxyApiUrl);

            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));

            #region Assigning Credentials to Current user

            client.DefaultRequestHeaders.Add("CustomerName", customerAccount);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            #endregion

            if (applyGainShareGuaranteedCalculation)
            {
                client.DefaultRequestHeaders.Add("FeatureFlags", "ApplyGainShareGuaranteedCalculation");
            }
            // ***
            // *** Calling  Proxy API to get carriers and rate details.
            // ***
            response = client.PostAsXmlAsync<XElement>("MercuryGate/RateRequest?xmlRateRequest=", requestXml).Result;

            if (response.IsSuccessStatusCode)
            {
                responseXml = response.Content.ReadAsAsync<XElement>().Result;
            }
            else
            {
                errorMessage = response.Content.ReadAsStringAsync().Result;
                Trace.WriteLine(
                    string.Format("{0}{1}", "Error occurred while getting rate and carrier details.", errorMessage),
                    "Error");
            }

            return responseXml;
        }

    }
}
