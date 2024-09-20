using System.Xml;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.ShipmentExtract;
using CRM.UITest.Helper.ViewModel;

namespace CRM.UITest.CommonMethods
{
    public class GetTerminalInformation
    {
        ShipmentExtractViewModel shipmentViewModels = null;
        IDictionary<string, string> TerminalinfosfromApi = new Dictionary<string, string>();
        IInvokeTerminalByPostalCodeApi InvokeAPIMethod = new InvokeTerminalByPostalCodeApi();
        IDictionary<string, string> TerminalRequestInfos = new Dictionary<string, string>();

        string SCAC = null;
        string Pickup_postalCode = string.Empty;
        string Pickup_countryCode = string.Empty;
        string Delivery_postalCode = string.Empty;
        string Delivery_countryCode = string.Empty;

        string Pickup_serviceType = "STANDARD";
        string Pickup_terminalType = "PICKUP";
        string Pickup_serviceMethod = "LTL";
        string Delivery_serviceType = "STANDARD";
        string Delivery_terminalType = "DELIVERY";
        string Delivery_serviceMethod = "LTL";

        public TerminalInformationModel GetTerminalInformationDatas(string shipmentReferenceNumber)
        {
            IDictionary<string, string> TerminalRequestInfo = new Dictionary<string, string>();
            MgCalls callsToMG = new MgCalls();

            shipmentViewModels = callsToMG.GetShipmentFromReferenceNumber(shipmentReferenceNumber);

            SCAC = shipmentViewModels.ReferenceNumbers.Where(a => a.Type == "SCAC").Select(a => a.ReferenceNumber).FirstOrDefault();

            for (var i = 0; i < shipmentViewModels.AddressViewModels.Count; i++)
            {

                if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "origin")
                {
                    Pickup_postalCode = shipmentViewModels.AddressViewModels[i].PostalCode;

                    Pickup_countryCode = shipmentViewModels.AddressViewModels[i].CountryCode;

                }
                if (shipmentViewModels.AddressViewModels[i].Type.ToLower() == "destination")
                {
                    Delivery_postalCode = shipmentViewModels.AddressViewModels[i].PostalCode;

                    Delivery_countryCode = shipmentViewModels.AddressViewModels[i].CountryCode;

                }
            }

            string _CarrierName = shipmentViewModels.CarrierRatesViewModel.Carrier;

            TerminalRequestInfo.Add("SCAC", SCAC);
            TerminalRequestInfo.Add("Pickup_postalCode", Pickup_postalCode);
            TerminalRequestInfo.Add("Pickup_countryCode", Pickup_countryCode);
            TerminalRequestInfo.Add("Delivery_postalCode", Delivery_postalCode);
            TerminalRequestInfo.Add("Delivery_countryCode", Delivery_countryCode);

            TerminalRequestInfos = InvokeAPIMethod.GetShipmentValues(shipmentReferenceNumber);

            string requestXml = "<soapenv:Envelope xmlns:soapenv='http://schemas.xmlsoap.org/soap/envelope/' xmlns:web='http://webservices.smc.com' xmlns:ter='http://terminalsbypostalcode.requests.objects.webservice.carrierconnect.smc.com'><soapenv:Header><web:AuthenticationToken><web:licenseKey>6Twv0Ozm4mOA</web:licenseKey><web:password>BZT4ia5z</web:password><web:username>dlswintegration@rrd.com</web:username></web:AuthenticationToken></soapenv:Header><soapenv:Body><web:TerminalsByPostalCode><web:TerminalsByPostalCodeRequest><ter:arrayTerminalByPostalCode><!--Zero or more repetitions:--><ter:TerminalByPostalCode><ter:SCAC>FXFE</ter:SCAC><ter:countryCode>" + TerminalRequestInfos["Pickup_countryCode"] + "</ter:countryCode><ter:postalCode>" + TerminalRequestInfos["Pickup_postalCode"] + "</ter:postalCode><ter:serviceMethod>" + Pickup_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Pickup_serviceType + "</ter:serviceType><ter:terminalType>" + Pickup_terminalType + "</ter:terminalType></ter:TerminalByPostalCode><ter:TerminalByPostalCode><ter:SCAC>FXFE</ter:SCAC><ter:countryCode>" + TerminalRequestInfos["Delivery_countryCode"] + "</ter:countryCode><ter:postalCode>" + TerminalRequestInfos["Delivery_postalCode"] + "</ter:postalCode><ter:serviceMethod>" + Delivery_serviceMethod + "</ter:serviceMethod><ter:serviceType>" + Delivery_serviceType + "</ter:serviceType><ter:terminalType>" + Delivery_terminalType + "</ter:terminalType></ter:TerminalByPostalCode></ter:arrayTerminalByPostalCode></web:TerminalsByPostalCodeRequest></web:TerminalsByPostalCode></soapenv:Body></soapenv:Envelope>";

            string error = string.Empty;

            XmlDocument xmlDoc = InvokeAPIMethod.InvokeCarrierTerminalInformation(requestXml, out error);

            TerminalinfosfromApi = InvokeAPIMethod.getTerminalinfomethod(xmlDoc);

            XmlNodeList CarrierName = xmlDoc.GetElementsByTagName("ns2:carrierName");

            TerminalInformationModel _terminalDatas = new TerminalInformationModel
            {
                Carriername = TerminalinfosfromApi["PICKUP_CarrierName"],

                PickupTerminalName = TerminalinfosfromApi["PICKUP_TerminalName"],

                PickupAddress1 = TerminalinfosfromApi["PICKUP_Address1"],

                PickupAddress2 = TerminalinfosfromApi["PICKUP_Address2"],

                PickupCity = TerminalinfosfromApi["PICKUP_City"],

                PickupStateProvince = TerminalinfosfromApi["PICKUP_StateProvince"],

                PickupPostalCode = TerminalinfosfromApi["PICKUP_PostalCode"],

                PickupCountry = TerminalinfosfromApi["PICKUP_Country"],

                PickupContactName = TerminalinfosfromApi["PICKUP_ContactName"],

                PickupContactPhone = TerminalinfosfromApi["PICKUP_ContactPhone"],

                PickupContactEmail = TerminalinfosfromApi["PICKUP_ContactEmail"],

                DeliveryTerminalName = TerminalinfosfromApi["DELIVERY_TerminalName"],

                DeliveryAddress1 = TerminalinfosfromApi["DELIVERY_Address1"],

                DeliveryAddress2 = TerminalinfosfromApi["DELIVERY_Address2"],

                DeliveryCity = TerminalinfosfromApi["DELIVERY_City"],

                DeliveryStateProvince = TerminalinfosfromApi["DELIVERY_StateProvince"],

                DeliveryPostalCode = TerminalinfosfromApi["DELIVERY_PostalCode"],

                DeliveryCountry = TerminalinfosfromApi["DELIVERY_Country"],

                DeliveryContactName = TerminalinfosfromApi["DELIVERY_ContactName"],

                DeliveryContactPhone = TerminalinfosfromApi["DELIVERY_ContactPhone"],

                DeliveryContactEmail = TerminalinfosfromApi["DELIVERY_ContactEmail"],

                ModalHeader = "Terminal Information for" + TerminalinfosfromApi["PICKUP_CarrierName"]

            };

            return _terminalDatas;
        }
    }
}

