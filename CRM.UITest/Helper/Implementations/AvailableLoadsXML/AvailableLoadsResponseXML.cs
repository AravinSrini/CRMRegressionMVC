using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations.AvailableLoadsXML
{
    public class AvailableLoadsResponseXML
    {
        public List<AvailableLoadsViewModel> ResponseXml(string uri, HttpClient client, XElement requestXml, out string errorMessage)
        {
            errorMessage = string.Empty;
            XElement responseXml = default(XElement);
            List<AvailableLoadsViewModel> avialableModel = new List<AvailableLoadsViewModel>();

            HttpResponseMessage responseMessage = client.PostAsXmlAsync<XElement>(uri, requestXml).Result;

            if (responseMessage.IsSuccessStatusCode)
            {
                responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                avialableModel = BuildListModel(responseXml);
            }
            else
            {
                errorMessage = responseMessage.Content.ReadAsStringAsync().Result;
                responseXml = null;
            }

            return avialableModel;

        }
        public List<AvailableLoadsViewModel> BuildListModel(XElement responseXml)
        {
            List<AvailableLoadsViewModel> loadBoardList = new List<AvailableLoadsViewModel>();
            string data = responseXml.Element("Data")?.Value;
            string[] rows = data?.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);

            if (rows != null)
            {
                double weight = 0;

                for (int i = 1; i < rows.Length; i++)
                {
                    AvailableLoadsViewModel loadBoard = new AvailableLoadsViewModel();
                    string[] attributes = Regex.Split(rows[i], ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)");
                    // loadBoardList.Add(_buildLoadBoardViewModelForEachRow.BuildModel(headerIndex, rows[i].Split(',')));
                    loadBoard.PrimaryReference=GetFieldValue("Primary Reference", rows[0], attributes);
                    loadBoard.PickupRange = GetFieldValue("Target Ship (Range)",rows[0],attributes);
                    loadBoard.DeliveryRange = GetFieldValue("Target Delivery (Range)", rows[0], attributes);
                    loadBoard.Weight = Convert.ToDouble(GetFieldValue("Weight", rows[0], attributes));
                    loadBoard.OriginCity = GetFieldValue("Origin City",rows[0],attributes);
                    loadBoard.OriginState = GetFieldValue("Origin State", rows[0], attributes);
                    loadBoard.OriginZip = GetFieldValue("Origin Zip", rows[0], attributes);
                    loadBoard.DestinationCity = GetFieldValue("Dest City", rows[0], attributes);
                    loadBoard.DestinationState = GetFieldValue("Dest State", rows[0], attributes);
                    loadBoard.DestinationZip = GetFieldValue("Dest Zip", rows[0], attributes);
                    loadBoard.EquipmentType = GetFieldValue("Carrier Mode", rows[0], attributes);
                    loadBoard.NoOfPickup = GetFieldValue("Events (Pickup)", rows[0], attributes);
                    loadBoard.NoOfDrops = GetFieldValue("Events (Drop)", rows[0], attributes);
                    loadBoard.CarrierSCAC = GetFieldValue("Carrier SCAC", rows[0], attributes);
                    loadBoardList.Add(loadBoard);
                }
            }

            return loadBoardList;
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
