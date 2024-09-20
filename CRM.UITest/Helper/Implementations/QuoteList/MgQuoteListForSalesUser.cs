using System.Collections.Generic;
using System.Net.Http;
using CRM.UITest.Helper.Interfaces.Quote;
using System;
using System.Net.Http.Headers;
using CRM.UITest.Helper.ViewModel.RateModel;
using System.Configuration;
using System.Net;

namespace CRM.UITest.Helper.Implementations.QuoteList
{
    public class MgQuoteListForSalesUser : IMgQuoteListForSalesUser
    {
        public List<QuoteListExtractModel> GetMgQuoteList(string customers,bool isSalesUser)
        {
            string uri = string.Empty;
            HttpClient client = new HttpClient();
            List<QuoteListExtractModel> quoteList = null;

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];

            int mercuryGateTimeOut = 700000;
            client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);

            client.BaseAddress = new Uri(proxyApiUrl);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            client.DefaultRequestHeaders.Add("CustomerName", "Admin");
            client.DefaultRequestHeaders.Add("Username", proxyUserName);
            client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);

            if (isSalesUser)
            {
                uri = $"Rateshop/GetQuoteListByCustomer?type={"Shipment"}&customer={customers}";
            }
            else
            {
                uri = $"Rateshop/GetQuoteListByStation?type={"Shipment"}&station={customers}";
            }
            HttpResponseMessage response = client.GetAsync(uri).Result;

            if (response.IsSuccessStatusCode && HttpStatusCode.NoContent != response.StatusCode)
            {
                quoteList = response.Content.ReadAsAsync<List<QuoteListExtractModel>>().Result;
                
            }
            else
            {
                string error = response.Content.ReadAsStringAsync().Result;
                string errorvalue = "Quote list not found for the" + customers;
               
            }
            return quoteList;

        }
    }
}
