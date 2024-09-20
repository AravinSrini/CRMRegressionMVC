using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using CRM.UITest.Helper;
using CRM.UITest.Helper.Common;
using System;

namespace CRM.UITest.Helper.Implementations.ShipmentExtract
{
    public class ShipmentExtract
    {
        XElement requestXml = null;
        public XElement GetOidRequest(string refNumber)
        {            
            requestXml = new XElement("service-request",
                new XElement("service-id", "OidLookup"),
                new XElement("request-id", "123456789"),
                new XElement("data",
                    new XElement("objectType", "shipment"),
                    new XElement("searchBy", "primaryReference"),
                    new XElement("searchValue", refNumber)));

            return requestXml;
        }

        public XElement ShipmentReqXml(string oidNumber)
        {
            XElement SReqXml = new XElement("service-request",
                new XElement("service-id", "ExtractShipment"),
                new XElement("request-id", "123456789"),
                new XElement("data",
                    new XElement("oid", oidNumber)));

            return SReqXml;
        }

        public ShipmentExtractViewModel getShipmentData(string uri, HttpClient client, string refNumber, string customerName)
        {
            ShipmentExtractViewModel shipmentExtractViewModels = new ShipmentExtractViewModel();
            string errorMessage = string.Empty;
            string errorvalue = string.Empty;
            string oidNumber = string.Empty;

            XElement oidRequestXml = GetOidRequest(refNumber);
            XmlDocument oidRequestXmlDoc = new XmlDocument();
            oidRequestXmlDoc.LoadXml(oidRequestXml.ToString());

            HttpResponseMessage response = client.PostAsXmlAsync(uri, oidRequestXml).Result;

            XmlDocument responseXml = new XmlDocument();
            responseXml.LoadXml(response.Content.ReadAsAsync<XElement>().Result.ToString());

            if (responseXml != null)
            {
                oidNumber = responseXml.InnerText;
                 
                if (oidNumber.Contains(','))
                {
                    string[] oidNumbers = oidNumber.Split(',');
                    oidNumber = oidNumbers[0];
                }                
            }
            
            string mgrui = $"MercuryGate/shipmentExtract";
            XElement SRequestXml = ShipmentReqXml(oidNumber);
            BuildHttpClient clientData = new BuildHttpClient();
            HttpClient headers = clientData.BuildHttpClientWithHeaders(customerName, "application/xml");

            HttpResponseMessage sResponse = headers.PostAsXmlAsync(mgrui, SRequestXml).Result;

            if (sResponse.IsSuccessStatusCode && HttpStatusCode.NoContent != sResponse.StatusCode)
            {
                
                XmlDocument responseSXml = new XmlDocument();
                responseSXml.LoadXml(sResponse.Content.ReadAsAsync<XElement>().Result.ToString());
                shipmentExtractViewModels = ReadXmlGenerateModel(responseSXml);
            }
            else
            {
                string error = sResponse.Content.ReadAsStringAsync().Result;

            }
            return shipmentExtractViewModels;
        }

        public static ShipmentExtractViewModel ReadXmlGenerateModel(XmlDocument responseXml)
        {
            ShipmentExtractViewModel model = new ShipmentExtractViewModel();

                    XmlDocument decodedXml = new XmlDocument();
                    decodedXml = responseXml;
                    model = new ShipmentExtractViewModel();

                    #region Convert Response XML to View Model

                     
                    if (decodedXml.SelectSingleNode(CommonConstants.ReferenceNumbersNode) != null)
                    {
                       
                        model.ReferenceNumbers = new List<ShipmentImportReferenceModel>();
                        XmlNodeList referenceNumberNodes = decodedXml.SelectNodes(CommonConstants.ReferenceNumberNodes);

                        if (referenceNumberNodes != null)
                        {
                            foreach (XmlNode node in referenceNumberNodes)
                            {
                                ShipmentImportReferenceModel referenceNumberViewModel = new ShipmentImportReferenceModel
                                {
                                    ReferenceNumber = node.InnerText,
                                    Type = node.Attributes[CommonConstants.TypeNode].Value,
                                    IsPrimary =
                                       !string.IsNullOrWhiteSpace(node.Attributes[CommonConstants.IsPrimaryNode].Value)
                                           ? Convert.ToBoolean(node.Attributes[CommonConstants.IsPrimaryNode].Value)
                                           : false
                                };
                                model.ReferenceNumbers.Add(referenceNumberViewModel);
                            }
                        }
                    }

                   
                    model.ShipmentMode = decodedXml.SelectSingleNode(CommonConstants.ShipmentModeTag) != null
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentModeTag).InnerText
                        : string.Empty;
                    model.Status = string.IsNullOrWhiteSpace(decodedXml.SelectSingleNode(CommonConstants.StatusNode).InnerText)
                        ? string.Empty
                        : decodedXml.SelectSingleNode(CommonConstants.StatusNode).InnerText;
                    model.EarliestPickupDate = (decodedXml.SelectSingleNode(CommonConstants.ShipmentPickUpEarliestDateTag) !=
                                                null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentPickUpEarliestDateTag).InnerText
                        : string.Empty;
                    model.LatestPickupDate = (decodedXml.SelectSingleNode(CommonConstants.ShipmentPickUpLatestDateTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentPickUpLatestDateTag).InnerText
                        : string.Empty;
                    model.EarliestDropDate = (decodedXml.SelectSingleNode(CommonConstants.ShipmentDropEarliestDateTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDropEarliestDateTag).InnerText
                        : string.Empty;
                    model.LatestDropDate = (decodedXml.SelectSingleNode(CommonConstants.ShipmentDropLatestDateTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDropLatestDateTag).InnerText
                        : string.Empty;
                    model.ActualPickupDate = (decodedXml.SelectSingleNode(CommonConstants.ShipmentActualPickUpDateTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentActualPickUpDateTag).InnerText
                        : string.Empty;
                    model.ActualDeliveryDate = (decodedXml.SelectSingleNode(CommonConstants.ShipmentActualDropDateTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentActualDropDateTag).InnerText
                        : string.Empty;

                    
                    OriginAddressViewModels addressOriginViewModel = new OriginAddressViewModels();
                    model.AddressViewModels = new List<OriginAddressViewModels>();
                    addressOriginViewModel.Name = (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginNameTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginNameTag).InnerText
                        : string.Empty;
                    addressOriginViewModel.AddressLine1 =
                        (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginAddress1Tag) != null)
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginAddress1Tag).InnerText
                            : string.Empty;
                    addressOriginViewModel.AddressLine2 =
                        (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginAddress2Tag) != null)
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginAddress2Tag).InnerText
                            : string.Empty;
                    addressOriginViewModel.City = (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginCityTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginCityTag).InnerText
                        : string.Empty;
                    addressOriginViewModel.StateProvince =
                        (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginStateTag) != null)
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginStateTag).InnerText
                            : string.Empty;
                    addressOriginViewModel.PostalCode =
                        (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginPostalCodeTag) != null)
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginPostalCodeTag).InnerText
                            : string.Empty;
                    addressOriginViewModel.CountryCode =
                        (decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginCountryCodeTag) != null)
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentOriginCountryCodeTag).InnerText
                            : string.Empty;
                    addressOriginViewModel.Type = CommonConstants.OriginType;
                    addressOriginViewModel.Comments = (decodedXml.SelectSingleNode(CommonConstants.CommentsCodeTag) != null)
                        ? decodedXml.SelectSingleNode(CommonConstants.CommentsCodeTag).InnerText
                        : string.Empty;
                    model.AddressViewModels.Add(addressOriginViewModel);

                    OriginAddressViewModels addressDestinationViewModel = new OriginAddressViewModels
                    {
                        Name =
                            decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationNameTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationNameTag).InnerText
                                : string.Empty,
                        AddressLine1 =
                            decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationAddress1Tag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationAddress1Tag).InnerText
                                : string.Empty,
                        AddressLine2 =
                            decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationAddress2Tag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationAddress2Tag).InnerText
                                : string.Empty,
                        City =
                            decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationCityTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationCityTag).InnerText
                                : string.Empty,
                        StateProvince =
                            decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationStateTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationStateTag).InnerText
                                : string.Empty,
                        PostalCode =
                            decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationPostalCodeTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationPostalCodeTag).InnerText
                                : string.Empty,
                        CountryCode = decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationCountryCodeTag) != null
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationCountryCodeTag).InnerText
                            : string.Empty,

                        Type = CommonConstants.DestinationType,

                        Comments = decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationCommentsCodeTag) != null
                            ? decodedXml.SelectSingleNode(CommonConstants.ShipmentDestinationCommentsCodeTag).InnerText
                            : string.Empty,
                    };

                    model.AddressViewModels.Add(addressDestinationViewModel);

                  
                    
                    ShipmentImportContactModel contactOriginViewModel = new ShipmentImportContactModel();
                    model.ContactViewModels = new List<ShipmentImportContactModel>();
                    contactOriginViewModel.Name = decodedXml.SelectSingleNode(CommonConstants.OriginContactNameTag) != null
                        ? decodedXml.SelectSingleNode(CommonConstants.OriginContactNameTag).InnerText
                        : string.Empty;
                    contactOriginViewModel.Phone = decodedXml.SelectSingleNode(CommonConstants.OriginPhoneTag) != null
                        ? decodedXml.SelectSingleNode(CommonConstants.OriginPhoneTag).InnerText
                        : string.Empty;
                    contactOriginViewModel.Email = decodedXml.SelectSingleNode(CommonConstants.OriginEmailTag) != null
                        ? decodedXml.SelectSingleNode(CommonConstants.OriginEmailTag).InnerText
                        : string.Empty;
                    contactOriginViewModel.Fax = decodedXml.SelectSingleNode(CommonConstants.OriginFaxTag) != null
                        ? decodedXml.SelectSingleNode(CommonConstants.OriginFaxTag).InnerText
                        : string.Empty;
                    contactOriginViewModel.ContactType = CommonConstants.OriginType;
                    model.ContactViewModels.Add(contactOriginViewModel);


                    ShipmentImportContactModel contactDestinationViewModel = new ShipmentImportContactModel
                    {
                        Name =
                            decodedXml.SelectSingleNode(CommonConstants.DestinationContactNameTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.DestinationContactNameTag).InnerText
                                : string.Empty,
                        Phone =
                            decodedXml.SelectSingleNode(CommonConstants.DestinationPhoneTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.DestinationPhoneTag).InnerText
                                : string.Empty,
                        Email =
                            decodedXml.SelectSingleNode(CommonConstants.DestinationEmailTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.DestinationEmailTag).InnerText
                                : string.Empty,
                        Fax =
                            decodedXml.SelectSingleNode(CommonConstants.DestinationFaxTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.DestinationFaxTag).InnerText
                                : string.Empty,
                        ContactType = CommonConstants.DestinationType
                    };

                    model.ContactViewModels.Add(contactDestinationViewModel);

                     
                    XmlNodeList itemNodes = decodedXml.SelectNodes(CommonConstants.ItemNodes);
                    model.ItemViewModels = new List<ItemBusinessModel>();

                    if (itemNodes != null)
                    {
                        foreach (XmlNode node in itemNodes)
                        {
                            ItemBusinessModel itemViewModel = new ItemBusinessModel
                            {
                                ItemId =
                                    node.SelectSingleNode(CommonConstants.ItemIdNode) != null
                                        ? node.SelectSingleNode(CommonConstants.ItemIdNode).InnerText
                                        : string.Empty,
                                Classification =
                                    node.SelectSingleNode(CommonConstants.FreightNode) != null
                                        ? node.SelectSingleNode(CommonConstants.FreightNode).InnerText
                                        : string.Empty,
                                DollarValue =
                                    node.SelectSingleNode(CommonConstants.DollarValue) != null
                                        ? node.SelectSingleNode(CommonConstants.DollarValue).InnerText
                                        : string.Empty,
                                NmfcCode =
                                    node.SelectSingleNode(CommonConstants.NmfcCodeNode) != null
                                        ? node.SelectSingleNode(CommonConstants.NmfcCodeNode).InnerText
                                        : string.Empty,
                                Quantity =
                                    node.SelectSingleNode(CommonConstants.QuantityNode) != null
                                        ? node.SelectSingleNode(CommonConstants.QuantityNode).InnerText
                                        : string.Empty,
                                QuantityUnit =
                                    node.SelectSingleNode(CommonConstants.QuantityUnitNode) != null
                                        ? node.SelectSingleNode(CommonConstants.QuantityUnitNode).InnerText
                                        : string.Empty,
                                Weight =
                                    (node.SelectSingleNode(CommonConstants.WeightNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.WeightNode).InnerText
                                        : string.Empty,
                                WeightUnit =
                                    (node.SelectSingleNode(CommonConstants.WeightUnitNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.WeightUnitNode).InnerText
                                        : string.Empty,
                                ItemDescription =
                                    node.SelectSingleNode(CommonConstants.ItemDescriptionNode) != null
                                        ? node.SelectSingleNode(CommonConstants.ItemDescriptionNode).InnerText
                                        : string.Empty,
                                Length = (node.SelectSingleNode(CommonConstants.LengthNode) != null)
                                    ? node.SelectSingleNode(CommonConstants.LengthNode).InnerText
                                    : string.Empty,
                                Height = (node.SelectSingleNode(CommonConstants.HeightNode) != null)
                                    ? node.SelectSingleNode(CommonConstants.HeightNode).InnerText
                                    : string.Empty,
                                Width = (node.SelectSingleNode(CommonConstants.WidthNode) != null)
                                    ? node.SelectSingleNode(CommonConstants.WidthNode).InnerText
                                    : string.Empty,
                                DimensionUnit = (node.SelectSingleNode(CommonConstants.DimensionUnit) != null)
                                    ? node.SelectSingleNode(CommonConstants.DimensionUnit).InnerText
                                    : string.Empty,
                                IsHazardous = (node.SelectSingleNode(CommonConstants.HazardousMaterialNode) != null)
                                    ? Convert.ToBoolean(node.SelectSingleNode(CommonConstants.HazardousMaterialNode).InnerText)
                                    : false,
                                ShipmentImportHazMatDetailViewModels = new ShipmentImportHazMatDetailModel
                                {
                                    ContactName = (node.SelectSingleNode(CommonConstants.ContactNameNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.ContactNameNode).InnerText
                                        : string.Empty,
                                    ContactPhone = (node.SelectSingleNode(CommonConstants.ContactPhoneNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.ContactPhoneNode).InnerText
                                        : string.Empty,
                                    PackageGroup = (node.SelectSingleNode(CommonConstants.PackageGroupNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.PackageGroupNode).InnerText
                                        : string.Empty,
                                    HazMatClass = (node.SelectSingleNode(CommonConstants.HazMatClassNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.HazMatClassNode).InnerText
                                        : string.Empty,
                                    HazMatId = (node.SelectSingleNode(CommonConstants.HazMatIdNode) != null)
                                        ? node.SelectSingleNode(CommonConstants.HazMatIdNode).InnerText
                                        : string.Empty,
                                }
                            };

                            if (itemViewModel != null)
                            {
                                model.ItemViewModels.Add(itemViewModel);
                            }

                            
                            node.RemoveAll();
                        }
                    }

                   
                    double fuelCost = 0;
                    double accessorialCost = 0;
                    XmlNode charges = decodedXml.SelectSingleNode(CommonConstants.Charges);

                    if (charges != null)
                    {
                        
                        foreach (XmlNode charge in charges)
                        {
                            string chatgeType = charge.Attributes.GetNamedItem(CommonConstants.Type).Value;
                            if (chatgeType != null && chatgeType.ToUpper().Contains(CommonConstants.Fuel))
                            {
                                XmlNode description = charge.SelectSingleNode(CommonConstants.Charge);
                                XmlNode amount = charge.SelectSingleNode(CommonConstants.ChargeAmount);
                                if (amount != null)
                                {
                                    fuelCost = Convert.ToDouble(amount.InnerText);
                                    break;
                                }
                            }
                        }
 
                        foreach (XmlNode charge in charges)
                        {
                            string chatgeType = charge.Attributes.GetNamedItem(CommonConstants.Type).Value;
                            if (chatgeType != null && chatgeType.ToUpper().Contains(CommonConstants.Accessorial) &&
                                !chatgeType.ToUpper().Contains(CommonConstants.Fuel))
                            {
                                XmlNode description = charge.SelectSingleNode(CommonConstants.Charge);
                                XmlNode amount = charge.SelectSingleNode(CommonConstants.ChargeAmount);
                                if (amount != null)
                                {
                                    accessorialCost = accessorialCost + Convert.ToDouble(amount.InnerText);
                                }
                            }
                        }
                    }

                     
                    model.CarrierRatesViewModel = new CarrierRateModel
                    {
                        Carrier =
                            decodedXml.SelectSingleNode(CommonConstants.CarrierNameTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.CarrierNameTag).InnerText
                                : string.Empty,
                        Distance =
                            decodedXml.SelectSingleNode(CommonConstants.DistaneTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.DistaneTag).InnerText
                                : string.Empty,
                        ServiceDays =
                            decodedXml.SelectSingleNode(CommonConstants.ServiceDaysTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.ServiceDaysTag).InnerText
                                : string.Empty,
                        SubTotal =
                            decodedXml.SelectSingleNode(CommonConstants.SubTotalCostTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.SubTotalCostTag).InnerText
                                : string.Empty,
                        LineHaul =
                            decodedXml.SelectSingleNode(CommonConstants.SubTotalCostTag) != null
                                ? Convert.ToDouble(decodedXml.SelectSingleNode(CommonConstants.SubTotalCostTag).InnerText)
                                : 0,
                        Total =
                            decodedXml.SelectSingleNode(CommonConstants.TotalCostTag) != null
                                ? decodedXml.SelectSingleNode(CommonConstants.TotalCostTag).InnerText
                                : string.Empty,

                        Fuel = fuelCost,
                        Accessorial = accessorialCost
                    };

                    
                    model.ShipmentDetailsViewModel = new ShipmentDetailModel
                    {
                        AdditionalServices = new List<string>(),
                        EquipmentType = new List<string>(),
                        EquipmentTypeCode = new List<string>()
                    };

                    XmlNodeList additionalServicesNode = decodedXml.SelectNodes(CommonConstants.AdditionalServicesNode);
                    if (additionalServicesNode != null)
                    {
                        foreach (XmlNode node in additionalServicesNode)
                        {
                            model.ShipmentDetailsViewModel.AdditionalServices.Add(node.InnerText);
                        }
                    }

                    XmlNodeList equipmentsNode = decodedXml.SelectNodes(CommonConstants.EquipmentTag);

                    if (equipmentsNode != null)
                    {
                        foreach (XmlNode node in equipmentsNode)
                        {
                            string equipment = node.InnerText.Trim();
                            string equipmentCode = node.Attributes["code"].Value;
                            equipment = equipment.StartsWith("(")
                                ? equipment.Replace("(", string.Empty).Replace(")", string.Empty)
                                : equipment;
                            model.ShipmentDetailsViewModel.EquipmentType.Add(equipment);
                            model.ShipmentDetailsViewModel.EquipmentTypeCode.Add(equipmentCode);
                        }
                    }

                    model.ShipmentDetailsViewModel.SpecialInstructions =
                        decodedXml.SelectSingleNode(CommonConstants.SpecialInstrumentTag) != null
                            ? decodedXml.SelectSingleNode(CommonConstants.SpecialInstrumentTag).InnerText
                            : string.Empty;

                    #endregion
            return model;
        }

    }
}
