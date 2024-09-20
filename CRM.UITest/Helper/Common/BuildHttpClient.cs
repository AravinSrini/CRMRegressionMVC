using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CRM.UITest.Helper.Common
{
    public class BuildHttpClient : IBuildHttpClient
    {
        public HttpClient BuildHttpClientWithHeaders(string customerName, string contentType)
        {
            HttpClient client = new HttpClient();

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            int mercuryGateTimeOut;
            int.TryParse(ConfigurationManager.AppSettings["MercuryGateTimeOut"], out mercuryGateTimeOut);
            client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);

            client.BaseAddress = new Uri(proxyApiUrl);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            client.DefaultRequestHeaders.Add("CustomerName", customerName);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            return client;
        }
        public HttpClient BuildHttpClientWithHeadersForVersion2(string customerName, string contentType)
        {
            HttpClient client = new HttpClient();

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrlVersion2"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            int mercuryGateTimeOut;
            int.TryParse(ConfigurationManager.AppSettings["MercuryGateTimeOut"], out mercuryGateTimeOut);
            client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);

            client.BaseAddress = new Uri(proxyApiUrl);
            ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(contentType));

            client.DefaultRequestHeaders.Add("CustomerName", customerName);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            return client;
        }
    }
}
