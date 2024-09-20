using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations.QuoteList
{
    public class HttpClientHelperForCreateQuote
    {
        public HttpResponseMessage CreateQuote(HttpClient buildClient, string requestURI, XElement requestxml)
        {
            HttpResponseMessage response = null;
            response = buildClient.PostAsXmlAsync<XElement>(requestURI, requestxml).Result;
            return response;
        }
    }
}
