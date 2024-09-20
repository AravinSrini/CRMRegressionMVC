using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.Implementations;

namespace CRM.UITest.Helper
{
    public class ExtractShipments : IExtractShipments
    {
        /// <summary>
        /// Get all shipment details 
        /// </summary>
        /// <param name="shipmentListViewModels"></param>
        /// <param name="customerName">string</param>
        /// <returns>IEnumerable of ShipmentExtractViewModel</returns>
        public IEnumerable<ShipmentExtractViewModel> ShipmentExtract(
            IEnumerable<ShipmentExtractBusinessModel> shipmentListViewModels,
            string customerName)
        {
            IEnumerable<ShipmentExtractViewModel> shipmentViewModels = null;
            TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
            IRetrieveEquipmentTypes retrieveEquipmentTypes = new RetrieveEquipmentTypes();

            // *** 
            // *** Initialize Status Transfrom 
            // *** 
            MgStatusTransform statusTransform = new MgStatusTransform();

            // ***
            // *** Extract the data from ShipmentExtractBusinessViewModel to ShipmentExtractViewModel
            // ***
            shipmentViewModels = (from shipment in shipmentListViewModels
                                  select new ShipmentExtractViewModel
                                  {
                                      AddressViewModels = (from address in shipment.AddressViewModels
                                                           select
                                                               new OriginAddressViewModels
                                                               {
                                                                   AddressLine1 =
                                                                       string.IsNullOrWhiteSpace(address.AddressLine1)
                                                                           ? string.Empty
                                                                           : textInfo.ToTitleCase(address.AddressLine1.ToLower()),
                                                                   AddressLine2 = address.AddressLine2,
                                                                   City = string.IsNullOrWhiteSpace(address.City) ? string.Empty : address.City.ToUpper(),
                                                                   Comments = address.Comments,
                                                                   Contact = address.Contact,
                                                                   CountryCode = address.CountryCode,
                                                                   EarliestAppointmentTime = address.EarliestAppointmentTime,
                                                                   GeoLocation = address.GeoLocation,
                                                                   IsResidential = address.IsResidential,
                                                                   LatestAppointmentTime = address.LatestAppointmentTime,
                                                                   LocationCode = address.LocationCode,
                                                                   Name =
                                                                       string.IsNullOrWhiteSpace(address.Name)
                                                                           ? "N/A"
                                                                           : textInfo.ToTitleCase(address.Name.ToLower()),
                                                                   PostalCode = address.PostalCode,
                                                                   StateProvince =
                                                                       string.IsNullOrWhiteSpace(address.StateProvince)
                                                                           ? string.Empty
                                                                           : address.StateProvince.ToUpper(),
                                                                   Type = address.Type
                                                               }).ToList(),
                                      CarrierRatesViewModel = shipment.CarrierRatesViewModel,
                                      ContactViewModels = shipment.ContactViewModels,
                                      EarliestDropDate =
                                          shipment.EarliestDropDate.HasValue
                                              ? Convert.ToDateTime(shipment.EarliestDropDate).ToString("MM/dd/yy hh:mm tt")
                                              : null,
                                      EarliestPickupDate =
                                          shipment.EarliestPickupDate.HasValue
                                              ? Convert.ToDateTime(shipment.EarliestPickupDate).ToString("MM/dd/yy hh:mm tt")
                                              : null,
                                      ActualPickupDate =
                                          shipment.ActualPickupDate.HasValue
                                              ? Convert.ToDateTime(shipment.ActualPickupDate).ToString("MM/dd/yy hh:mm tt")
                                              : null,
                                      ActualDeliveryDate =
                                          shipment.ActualDeliveryDate.HasValue
                                              ? Convert.ToDateTime(shipment.ActualDeliveryDate).ToString("MM/dd/yy hh:mm tt")
                                              : null,
                                      ItemViewModels = (from items in shipment.ItemViewModels
                                                        select
                                                            new ItemBusinessModel
                                                            {
                                                                ItemId = items.ItemId,
                                                                Classification = items.Classification,
                                                                NmfcCode = items.NmfcCode,
                                                                Quantity = items.Quantity,
                                                                QuantityUnit =
                                                                    string.IsNullOrWhiteSpace(items.QuantityUnit) ? "N/A" : items.QuantityUnit,
                                                                QuantityUnitName =
                                                                    string.IsNullOrWhiteSpace(items.QuantityUnit)
                                                                        ? "N/A"
                                                                        : GetQuantityUnit(items.QuantityUnit),
                                                                Weight =
                                                                    items.Weight.Contains('.') && items.Weight.Split('.')[1].Length > 2
                                                                        ? items.Weight.Replace(
                                                                            items.Weight.Split('.')[1],
                                                                            items.Weight.Split('.')[1].Substring(0, 2))
                                                                        : items.Weight,
                                                                WeightUnit = items.WeightUnit,
                                                                DollarValue = items.DollarValue,
                                                                Length = items.Length,
                                                                Height = items.Height,
                                                                Width = items.Width,
                                                                DimensionUnit = items.DimensionUnit,
                                                                ItemDescription = items.ItemDescription,
                                                                IsHazardous = items.IsHazardous,
                                                                ShipmentImportHazMatDetailViewModels =
                                                                    items.ShipmentImportHazMatDetailViewModels != null
                                                                        ? new ShipmentImportHazMatDetailModel
                                                                        {
                                                                            HazMatId = items.ShipmentImportHazMatDetailViewModels.HazMatId,
                                                                            CcnNumber =
                                                                                !string.IsNullOrWhiteSpace(
                                                                                    items.ShipmentImportHazMatDetailViewModels.ContactPhone)
                                                                                    ? items.ShipmentImportHazMatDetailViewModels.ContactPhone.Contains(
                                                                                        "CCN")
                                                                                        ? items.ShipmentImportHazMatDetailViewModels.ContactPhone
                                                                                            .Substring(
                                                                                                items.ShipmentImportHazMatDetailViewModels.ContactPhone
                                                                                                    .IndexOf("CCN"))
                                                                                        : null
                                                                                    : null,
                                                                            PackageGroup = items.ShipmentImportHazMatDetailViewModels.PackageGroup,
                                                                            HazMatClass = items.ShipmentImportHazMatDetailViewModels.HazMatClass,
                                                                            ContactPhone =
                                                                                !string.IsNullOrWhiteSpace(
                                                                                    items.ShipmentImportHazMatDetailViewModels.ContactPhone)
                                                                                    ? items.ShipmentImportHazMatDetailViewModels.ContactPhone.Contains(
                                                                                        "CCN")
                                                                                        ? (items.ShipmentImportHazMatDetailViewModels.ContactPhone
                                                                                            .IndexOf("CCN") > 0)
                                                                                            ? items.ShipmentImportHazMatDetailViewModels.ContactPhone
                                                                                                .Substring(
                                                                                                    0,
                                                                                                    items.ShipmentImportHazMatDetailViewModels
                                                                                                        .ContactPhone.IndexOf("CCN"))
                                                                                            : null
                                                                                        : items.ShipmentImportHazMatDetailViewModels.ContactPhone
                                                                                    : null,
                                                                            ContactName = items.ShipmentImportHazMatDetailViewModels.ContactName,
                                                                        }
                                                                        : null,
                                                            }).ToList(),
                                      LatestDropDate =
                                          shipment.LatestDropDate.HasValue
                                              ? Convert.ToDateTime(shipment.LatestDropDate).ToString("MM/dd/yy hh:mm tt")
                                              : null,
                                      LatestPickupDate =
                                          shipment.LatestPickupDate.HasValue
                                              ? Convert.ToDateTime(shipment.LatestPickupDate).ToString("MM/dd/yy hh:mm tt")
                                              : null,
                                      ShipmentDetailsViewModel =
                                          shipment.ShipmentDetailsViewModel != null
                                              ? new ShipmentDetailModel()
                                              {
                                                  AdditionalServices = shipment.ShipmentDetailsViewModel.AdditionalServices,
                                                  EquipmentType =
                                                      retrieveEquipmentTypes.GetEquipmentType(
                                                          shipment.ShipmentDetailsViewModel.EquipmentTypeCode,
                                                          shipment.ShipmentMode),
                                                  ShipmentCoverage = shipment.ShipmentDetailsViewModel.ShipmentCoverage,
                                                  SpecialInstructions = shipment.ShipmentDetailsViewModel.SpecialInstructions
                                              }
                                              : null,
                                      ReferenceNumbers = shipment.ReferenceNumbers,
                                      ShipmentMode = shipment.ShipmentMode,
                                      Status = statusTransform.Transform(shipment.Status),
                                      TmsSystem = "MG"
                                  }).ToList();

            return shipmentViewModels;
        }

        private static string GetQuantityUnit(string quantityCode)
        {
            string quantityName = string.Empty;

            // ***
            // *** Get all the Quantity Unit Details
            // ***
            IQuantityUnit getQuantityUnitsHelper = new QuantityUnit();
            IEnumerable<UnitsViewModel> quantityUnitsDetails = getQuantityUnitsHelper.GetQuantityUnit();

            // ***
            // *** Get the Quantity Unit name for Quantity Code
            // ***
            quantityName =
                quantityUnitsDetails.Where(q => q.Code == quantityCode).Select(q => q.Name).ToList().FirstOrDefault();

            return quantityName;
        }

    }
    
}
