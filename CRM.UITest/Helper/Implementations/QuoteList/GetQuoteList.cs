using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CRM.UITest.Helper.Interfaces.Quote;
using System;
using System.Net.Http.Headers;
using CRM.UITest.Helper.ViewModel.RateModel;
using System.Configuration;

namespace CRM.UITest.Helper.Implementations.QuoteList
{
    public class GetQuoteList : IGetQuoteList
    {
        public List<QuoteListExtractModel> GetMgQuotes(string customerName, out string errorMessage)
        {
            errorMessage = string.Empty;


            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            HttpClient client = new HttpClient();

            int mercuryGateTimeOut = 700000;
            client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);

            client.BaseAddress = new Uri(proxyApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            client.DefaultRequestHeaders.Add("CustomerName", customerName);
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            string uri = $"Rateshop/QuoteList?type={"Shipment"}";
            HttpResponseMessage response = client.GetAsync(uri).Result; ;

            List<QuoteListExtractModel> quoteList = response.Content.ReadAsAsync<List<QuoteListExtractModel>>().Result;

            return quoteList;
        }
    }
}
