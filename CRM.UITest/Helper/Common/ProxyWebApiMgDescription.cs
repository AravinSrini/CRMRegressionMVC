using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.ViewModel.RateModel;
using Newtonsoft.Json;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Script.Serialization;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Common
{
    public class ProxyWebApiMgDescription
    {       
        public static List<IndividualAccessorialModel> CallRateShopApi(String CustomerName, String Service, String pickUpCityName, String pickUpZipCode, 
            String pickUpStateCode, String pickUpCountry, String dropUpCityName, String dropUpZipCode, String dropUpStateCode, String dropUpCountry,
            String freightClass, Double quantity, String quantityUnit, Double weight, String weightUnit,
            String OAccessorial, String DAccessorial)
        {
            RateRequestViewModel req = new RateRequestViewModel();            
            RateItemModel item = new RateItemModel();
            List<IndividualAccessorialModel> accessorials =new List<IndividualAccessorialModel>();
            IndividualAccessorialModel acc = new IndividualAccessorialModel();
            req.RatingLevel = CustomerName;
            req.Constraints = new RateConstraintsModel()
            { Mode = Service };
            string accessorial = null;

            if (DAccessorial == string.Empty || DAccessorial == null && DAccessorial != string.Empty)
            {
                accessorial = OAccessorial;
            }
            else if (OAccessorial == string.Empty || OAccessorial == null && DAccessorial != string.Empty)
            {
                accessorial = DAccessorial;
            }
            else if (DAccessorial == string.Empty || DAccessorial == null && OAccessorial == string.Empty || OAccessorial == null)
            {
                Report.WriteLine("No Accessorials");
            }
            else
            {
                accessorial = OAccessorial + "," + DAccessorial;
            }

            //if no accessorial selected
            if (accessorial == null || accessorial == string.Empty)
            {
                Report.WriteLine("No Accessorials");
            }

            List<string> name = new List<string>();
            string[] sp = accessorial.Split(',');
            foreach (var r in sp)
            {
                if (r.Contains("OVL"))
                {
                    name.Add(r);
                }
                else
                {
                    AccessorialSetUp getacc_code = DBHelper.AccessorialName_to_Acc_Code(r);
                    if (getacc_code != null)
                    {
                        string u = getacc_code.AccessorialCode;
                        name.Add(u);
                    }                                       
                }

            }
            List<ServiceFlagModel> ServiceFlags = new List<ServiceFlagModel>();
            for (int i = 0; i < name.Count; i++)
            {

                ServiceFlagModel s = new ServiceFlagModel();
                s.ServiceCode = name[i];
                ServiceFlags.Add(s);

            }
            req.Constraints.ServiceFlags = ServiceFlags;
            req.Constraints.Mode = Service;
            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now,
                Zip = dropUpZipCode,
                State = dropUpStateCode
            };
            req.DropEvent = Drop;
            RateEventModel Pickup = new RateEventModel()
            {
                City = pickUpCityName,
                Country = pickUpCountry,
                Date = DateTime.Now,
                Zip = pickUpZipCode,
                State = pickUpStateCode
            };
            req.PickupEvent = Pickup;
            RateItemModel itemmodel = new RateItemModel()
            {
                FreightClass = freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);            
            req.Items = lstItemmodel;

            BuildHttpClient client = new BuildHttpClient();
            HttpClient buildClient = client.BuildHttpClientWithHeadersForVersion2(CustomerName, "application/json");
            var rateRequestJson = JsonConvert.SerializeObject(req);
            HttpResponseMessage response = buildClient.PostAsync("RateShop/RateRequest", new StringContent(
            new JavaScriptSerializer().Serialize(req), Encoding.UTF8, "application/json")).Result;
            
            var responseString = response.Content.ReadAsStringAsync();
            var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString.Result);            
            for (int i = 0; i < responseJson.Count; i++)
            {   
                if (responseJson[i].Type.ToString() == "Cost" || responseJson[i].Type!=null)
                {
                    acc.carrierName = responseJson[i].CarrierName.ToString();
                    acc.TotalCost = responseJson[i].Total.ToString();
                    for (int j = 0; j < responseJson[i].Charges.Count; j++)
                    {
                        if (responseJson[i].Charges[j].Type.ToString() == "ACCESSORIAL" && responseJson[i].Charges[j].Type != null)
                        {
                            acc.amount = responseJson[i].Charges[j].Amount.ToString();                            
                            acc.discription = responseJson[i].Charges[j].Description.ToString();                                                        
                            break;
                        }                        
                    }

                }
                accessorials.Add(acc);
            }

            return accessorials;
        }        
    }
}
