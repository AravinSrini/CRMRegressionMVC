using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using CRM.UITest.Helper.ViewModel.Shipment;
using System.Net.Http;
using System.Net;

namespace CRM.UITest.Helper.Implementations.ShipmentList
{
    public class ShipmentListScreen
    {
        public List<ShipmentListViewModel> CallListScreen(string uri, HttpClient client, XElement requestXmlc)
        {

            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();

            HttpResponseMessage response = client.PostAsXmlAsync(uri, requestXmlc).Result;

            if (response != null)
            {
                if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
                {
                    XElement responseData = response.Content.ReadAsAsync<XElement>().Result;
                    shipments = ReadXmlGenerateModel(responseData);
                }
            }

  

            return shipments;
        }


        //added new method
        public List<ShipmentListViewModel> CallListScreenAutopopulate(string uri, HttpClient client, XElement requestXml)
        {
            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();

            HttpResponseMessage response = client.PostAsXmlAsync(uri, requestXml).Result;

            if (response != null)
            {
                if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
                {
                    XElement responseData = response.Content.ReadAsAsync<XElement>().Result;
                    shipments = ReadListExtractXmlGenerateModel(responseData);
                }
            }

            return shipments;
           
        }

        public static IEnumerable<XElement> GetPricesheetsListFromXML(XElement responseXml)
        {
            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();
            var data = responseXml.Element("Shipment").Element("PriceSheets").Elements("PriceSheet");
            string test = data.ToString();
            return data;
        }

        public static List<ShipmentListViewModel> ReadXmlGenerateModel(XElement responseXml)
        {
            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();
            string data = responseXml.Element("Data").Value;

            if (!string.IsNullOrWhiteSpace(data))
            {
                string[] rows = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                rows[0] = rows[0].Replace(", ", ",");
                rows[0] = rows[0].Replace(" ,", ",");
                string headerRow = rows[0];
                foreach (string row in rows)
                {
                    string[] attributes = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    ShipmentListViewModel model = null;

                    model = new ShipmentListViewModel();

                    model.PrimaryReference = GetFieldValue("Primary Reference", headerRow, attributes).Split(' ')[0];
                    model.ReferenceType = GetFieldValue("Primary Reference", headerRow, attributes).Split(' ')[1];
                    model.Status = GetFieldValue("Status", headerRow, attributes) ?? string.Empty;
                    model.PickupEarliest = GetFieldValue("Target Ship (Early)", headerRow, attributes);
                    model.PickupLatest = GetFieldValue("Target Ship (Late)", headerRow, attributes);
                    model.ActualPickup = GetFieldValue("Actual Ship", headerRow, attributes);
                    model.DeliveryEarliest = GetFieldValue("Target Delivery (Early)", headerRow, attributes);
                    model.DeliveryLatest = GetFieldValue("Target Delivery (Late)", headerRow, attributes);
                    model.ActualDelivery = GetFieldValue("Actual Delivery", headerRow, attributes);
                    model.OriginName = GetFieldValue("Origin Name", headerRow, attributes) ?? string.Empty;
                    model.OriginAddress =
                                      string.Format(
                                          "{0}, {1} {2}", GetFieldValue("Origin City", headerRow, attributes) ?? string.Empty,
                                        GetFieldValue("Origin State", headerRow, attributes) ?? string.Empty,
                                       GetFieldValue("Origin zip", headerRow, attributes) ?? string.Empty);
                    model.DestinationName = GetFieldValue("Dest Name", headerRow, attributes) ?? string.Empty;
                    model.DestinationAddress =
                                      string.Format(
                                          "{0}, {1} {2}", GetFieldValue("Dest City", headerRow, attributes) ?? string.Empty,
                                          GetFieldValue("Dest State", headerRow, attributes) ?? string.Empty,
                                         GetFieldValue("Dest Zip", headerRow, attributes) ?? string.Empty);
                    model.Quantity = GetFieldValue("Quantity", headerRow, attributes) ?? string.Empty;
                    model.Weight = GetFieldValue("Weight", headerRow, attributes) ?? string.Empty;
                    model.Mode = GetFieldValue("Type", headerRow, attributes) ?? string.Empty;
                    model.CarrierScac = GetFieldValue("Carrier SCAC", headerRow, attributes) ?? string.Empty;
                    model.CarrierName = GetFieldValue("Customer Name", headerRow, attributes) ?? string.Empty;
                    model.CustomerCharges = GetFieldValue("Customer Charge", headerRow, attributes) ?? string.Empty;
                    model.PONumber = GetFieldValue("PO Number", headerRow, attributes) ?? string.Empty;
                    model.PRONumber = GetFieldValue("PRO", headerRow, attributes) ?? string.Empty;
                    model.CustomerName = GetFieldValue("Owner", headerRow, attributes) ?? string.Empty;
                    model.EstRevenue = GetFieldValue("Customer Charge", headerRow, attributes) ?? string.Empty;
                    model.EstCost = GetFieldValue("Carrier Charge", headerRow, attributes) ?? string.Empty;
                    model.Invoices = GetFieldValue("Invoices (Customer)", headerRow, attributes) ?? string.Empty;
                    shipments.Add(model);
                }
            }

            return shipments;
        }

        //Storing values in model

        public static List<ShipmentListViewModel> ReadListExtractXmlGenerateModel(XElement responseXml)
        {
            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();
            string data = responseXml.Element("Data").Value;

            if (!string.IsNullOrWhiteSpace(data))
            {
                string[] rows = data.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                rows[0] = rows[0].Replace(", ", ",");
                rows[0] = rows[0].Replace(" ,", ",");
                string headerRow = rows[0];
                foreach (string row in rows)
                {
                    string[] attributes = Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    ShipmentListViewModel model = null;

                    model = new ShipmentListViewModel();

                    model.PrimaryReference = GetFieldValue("Primary Reference", headerRow, attributes);
                    model.ActualPickup = GetFieldValue("Actual Ship", headerRow, attributes);
                    model.ActualDelivery = GetFieldValue("Actual Delivery", headerRow, attributes);
                    model.CarrierName = GetFieldValue("Carrier Name", headerRow, attributes) ?? string.Empty;
                    model.PRONumber = GetFieldValue("PRO", headerRow, attributes) ?? string.Empty;
                    model.OriginName = GetFieldValue("Origin Name", headerRow, attributes) ?? string.Empty;
                    model.OriginAddress = GetFieldValue("Origin Addr1", headerRow, attributes) ?? string.Empty;
                    model.OriginAddress2 = GetFieldValue("Origin Addr2", headerRow, attributes) ?? string.Empty;
                    model.OriginZip = GetFieldValue("Origin Zip", headerRow, attributes) ?? string.Empty;
                    model.OriginCountry = GetFieldValue("Origin Ctry", headerRow, attributes) ?? string.Empty;
                    model.OriginCity = GetFieldValue("Origin City", headerRow, attributes) ?? string.Empty;
                    model.OriginState = GetFieldValue("Origin State", headerRow, attributes) ?? string.Empty;

                    model.DestinationName = GetFieldValue("Dest Name", headerRow, attributes) ?? string.Empty;
                    model.DestinationAddress = GetFieldValue("Dest Addr1", headerRow, attributes) ?? string.Empty;
                    model.DestinationAddress2 = GetFieldValue("Dest Addr2", headerRow, attributes) ?? string.Empty;
                    model.DestinationZip = GetFieldValue("Dest Zip", headerRow, attributes) ?? string.Empty;
                    model.DestinationCountry = GetFieldValue("Dest Ctry", headerRow, attributes) ?? string.Empty;
                    model.DestinationCity = GetFieldValue("Dest City", headerRow, attributes) ?? string.Empty;
                    model.DestinationState = GetFieldValue("Dest State", headerRow, attributes) ?? string.Empty;

                    model.BillToName = GetFieldValue("BillTo Name", headerRow, attributes) ?? string.Empty;
                    model.BillToZip = GetFieldValue("BillTo Zip", headerRow, attributes) ?? string.Empty;
                    model.BillToCountry = GetFieldValue("BillTo Ctry", headerRow, attributes) ?? string.Empty;
                    model.BillToCity = GetFieldValue("BillTo City", headerRow, attributes) ?? string.Empty;
                    model.BillToState = GetFieldValue("BillTo State", headerRow, attributes) ?? string.Empty;
                    model.InternalID = GetFieldValue("Internal ID", headerRow, attributes) ?? string.Empty;
                    model.Owner = GetFieldValue("Owner", headerRow, attributes) ?? string.Empty;

                    shipments.Add(model);
                }
            }

            return shipments;
        }

        public static string GetFieldValue(string fieldName, string headerRow, string[] attributes)
        {
            int fieldIndex = -1;
            List<string> headerAttributes;
            string fieldValue = string.Empty; ;

            if (!string.IsNullOrWhiteSpace(fieldName) && !string.IsNullOrWhiteSpace(headerRow) && attributes.Length > 0)
            {
                headerAttributes = Regex.Split(headerRow, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)").ToList();
                fieldIndex = headerAttributes.IndexOf(fieldName);

                if (fieldIndex != -1)
                {
                    fieldValue = attributes[fieldIndex];
                }
            }

            return fieldValue;
        }
    }
}
