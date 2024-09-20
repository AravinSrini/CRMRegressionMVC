using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations.StandardReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class GetShipmentFromMG
    {
        public static XDocument getShipment(string refNumber)
        {
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            string oid = string.Empty;

            XElement oidRequestXML = data.GetOidNumberFromReferenceNumber(refNumber);
            XDocument pricesheetResponse;

            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("ZZZ Sandbox DLS Worldwide", "application/xml");
            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();
            ShipmentListViewModel shipment = new ShipmentListViewModel();

            string uri = $"MercuryGate/OidLookup";
            HttpResponseMessage response = headers.PostAsXmlAsync(uri, oidRequestXML).Result;

            if (response != null)
            {
                if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
                {
                    XElement responseData = response.Content.ReadAsAsync<XElement>().Result;
                    oid = responseData.Value;

                    uri = $"MercuryGate/ShipmentExtract";

                    XElement shimentRequestXML = data.GetShipmentFromOID(oid);

                    response = headers.PostAsXmlAsync(uri, shimentRequestXML).Result;

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
                        {
                            responseData = response.Content.ReadAsAsync<XElement>().Result;
                            pricesheetResponse = XDocument.Parse(responseData.ToString());

                            return pricesheetResponse;
                        }
                    }
                }
            }

            return null;
        }
    }
}
