using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.DataModels;
using System.Configuration;

namespace CRM.UITest.Helper
{
    public class ExtractShipment : IExtractShipment
    {
        public IEnumerable<ShipmentExtractViewModel> ShipmentExtract(
            List<UploadTemplateViewModel> primaryReferenceBol,
            string customerName,
            out string errorMessage)
        {
            List<ShipmentExtractBusinessModel> shipmentExtractViewModels = new List<ShipmentExtractBusinessModel>();
            errorMessage = string.Empty;
            string errorvalue = string.Empty;

            string proxyApiUrl = ConfigurationManager.AppSettings["ProxyWebApiUrl"];
            string proxyUserName = ConfigurationManager.AppSettings["ProxyUserName"];
            string proxyApiKey = ConfigurationManager.AppSettings["ProxyApiKey"];
            IEnumerable<ShipmentExtractViewModel> shipmentDetails = null;

            primaryReferenceBol.AsParallel().ForAll(
                shipmentExtractInputViewModel =>
                {
                    HttpResponseMessage response = null;
                    HttpClient client = new HttpClient();
                    int mercuryGateTimeOut;
                    int.TryParse("70000", out mercuryGateTimeOut);
                    client.Timeout = TimeSpan.FromSeconds(mercuryGateTimeOut);
                    client.BaseAddress = new Uri(proxyApiUrl);
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    #region Assigning Credentials to Current user

                    client.DefaultRequestHeaders.Add("Username", proxyUserName);
                    client.DefaultRequestHeaders.Add("apiKey", proxyApiKey);
                    client.DefaultRequestHeaders.Add("CustomerName", customerName);

                    #endregion

                    // ***
                    // *** Call the Proxy ShipmentExtract method
                    // ***
                    response =
                        client.GetAsync(
                            string.Format(
                                "Shipment/ShipmentExtract?referenceNumber={0}",
                                shipmentExtractInputViewModel.PrimaryReferenceBol)).Result;

                    if (response.IsSuccessStatusCode && HttpStatusCode.NoContent != response.StatusCode)
                    {
                        // ***
                        // ***If response is success read the response and return the model
                        //***
                        ShipmentExtractBusinessModel shipmentExtractBusinessViewModels =
                            response.Content.ReadAsAsync<ShipmentExtractBusinessModel>().Result;
                        shipmentExtractViewModels.Add(shipmentExtractBusinessViewModels);
                    }
                    else
                    {
                        string error = response.Content.ReadAsStringAsync().Result;
                        errorvalue = string.Format(
                            "{0}{1}",
                            errorvalue,
                            string.IsNullOrWhiteSpace(errorvalue)
                                ? string.Format(
                                    "{0} : {1}",
                                    "Shipment details were not found for the following shipment numbers",
                                    shipmentExtractInputViewModel.PrimaryReferenceBol)
                                : string.Format(", {0}", shipmentExtractInputViewModel.PrimaryReferenceBol));
                        Trace.WriteLine(
                            string.Format(
                                "{0} Details: {1} for Reference Number:{2}",
                                "Shipment details were not found for the following shipment numbers",
                                error,
                                shipmentExtractInputViewModel.PrimaryReferenceBol),
                            "Error");
                    }
                });

            errorMessage = errorvalue;

            if (shipmentExtractViewModels != null && shipmentExtractViewModels.Any())
            {
                IExtractShipments extractShipments = new ExtractShipments();
                shipmentDetails = extractShipments.ShipmentExtract(shipmentExtractViewModels, customerName);
            }

            return shipmentDetails;
        }
    }
}
