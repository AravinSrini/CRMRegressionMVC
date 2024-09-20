using System.Net.Http;

namespace CRM.UITest.Helper.Common
{
    public interface IBuildHttpClient
    {
        HttpClient BuildHttpClientWithHeaders(string customerName, string contentType);
    }
}
