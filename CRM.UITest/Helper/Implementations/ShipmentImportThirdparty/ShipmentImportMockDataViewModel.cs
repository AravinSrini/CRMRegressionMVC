using CRM.UITest.Helper.DataModels;
using System;
using System.Collections.Generic;

namespace CRM.UITest.Helper.Implementations.ShipmentImportThirdparty
{
    public class ShipmentImportMockDataViewModel
    {
        public ShipmentImportViewModel GenerateModel()
        {
            ShipmentImportViewModel shipmentModel = new ShipmentImportViewModel();
            ServiceFlagViewModel serviceModel = new ServiceFlagViewModel();
            List<EquipmentViewModel> Equipment = new List<EquipmentViewModel>();
            EquipmentViewModel eqipment = new EquipmentViewModel();
            List<ServiceFlagViewModel> ServiceFlags = new List<ServiceFlagViewModel>();
            List<EquipmentViewModel> Equipments = new List<EquipmentViewModel>();
            List<ShipmentImportPricesheetViewModel> Pricesheets = new List<ShipmentImportPricesheetViewModel>();
            ShipmentImportPricesheetViewModel priceSheet = new ShipmentImportPricesheetViewModel();
            List<ShipmentImportItemViewModel> Items = new List<ShipmentImportItemViewModel>();
            ShipmentImportItemViewModel item = new ShipmentImportItemViewModel();
            ShipmentImportEnterpriseViewModel enterprisemodel = new ShipmentImportEnterpriseViewModel();
            ShipmentImportDateViewModel Dates = new ShipmentImportDateViewModel();
            ShipmentImportAddressViewModel Shipper = new ShipmentImportAddressViewModel();
            ShipmentImportAddressViewModel Consignee = new ShipmentImportAddressViewModel();
            ShipmentImportItemDimensionsViewModel Dimensions = new ShipmentImportItemDimensionsViewModel();
            ShipmentImportFreightClassViewModel FreightClasses = new ShipmentImportFreightClassViewModel();
            ShipmentImportMeasurementViewModel Weights = new ShipmentImportMeasurementViewModel();
            ShipmentImportMeasurementViewModel Quantities = new ShipmentImportMeasurementViewModel();
            ShipmentImportPaymentViewModel Payment = new ShipmentImportPaymentViewModel();
            ShipmentImportAddressViewModel PaymentAddress = new ShipmentImportAddressViewModel();
            enterprisemodel.Name = "ZZZ - GS Customer Test";
            serviceModel.ServiceCode = "APPT";
            eqipment.EquipmentCode = "LTL";
            shipmentModel.Status = "Pending";
            shipmentModel.Enterprise = enterprisemodel;
            Dates.EarliestPickupDate = Convert.ToDateTime("2014-05-23 08:00");
            Dates.LatestPickupDate = Convert.ToDateTime("2014-04-23 17:00");
            Dates.EarliestDropDate = Convert.ToDateTime("2014-05-27 08:00");
            Dates.LatestDropDate = Convert.ToDateTime("2014-05-27 17:00");
            
            shipmentModel.Dates = Dates;
            priceSheet.Type = "Carrier";
            priceSheet.IsSelected = true;
            priceSheet.ContractId = "(182466496431,3023,0)";
            Consignee.IsResidential = false;
            Consignee.Name = "Test";
            Consignee.AddressLine1 = "Chicago";
            Consignee.PostalCode = "A1A 1A1";
            Consignee.City = "St. john";
            Consignee.StateProvince = "NL";
            Consignee.CountryCode = "CANADA";
            shipmentModel.Consignee = Consignee;
            Shipper.IsResidential = false;
            Shipper.Name = "Check";
            Shipper.AddressLine1 = "New York";
            Shipper.PostalCode = "A1A 1A1";
            Shipper.City = "St. john";
            Shipper.StateProvince = "NL";
            Shipper.CountryCode = "CANADA";
            shipmentModel.Shipper = Shipper;
            item.Id = "CRM";
            Dimensions.Length = 10.0;
            Dimensions.Width = 11.0;
            Dimensions.Height = 12.0;
            Dimensions.Uom = "in";
            FreightClasses.FreightClass = 70;
            FreightClasses.Type = "";
            item.HazardousMaterial = false;
            Weights.Actual = 100;
            Weights.Uom = "lb";
            Quantities.Actual = 1;
            Quantities.Uom = "CRT";
            Pricesheets.Add(priceSheet);
            item.FreightClasses = FreightClasses;
            item.Dimensions = Dimensions;
            item.Quantities = Quantities;
            item.Description = "Verify";
            Weights.Actual = 100;
            item.Weights = Weights;
            Items.Add(item);
            ServiceFlags.Add(serviceModel);
            Equipments.Add(eqipment);
            shipmentModel.Equipments = Equipments;
            shipmentModel.Pricesheets = Pricesheets;
            shipmentModel.ServiceFlags = ServiceFlags;
            shipmentModel.Items = Items;
            PaymentAddress.IsResidential = false;
            PaymentAddress.PostalCode = "60504";
            Payment.Address = PaymentAddress;
            shipmentModel.Payment = Payment;

            return shipmentModel;
        }

        public ShipmentImportViewModel GenerateModel(string customerName, string serviceCode, string status, string consigneeName,
            string consigneeAddressLine1, string consigneePostalCode, string consigneeCity, string consigneeStateProvince,
            string consigneeCountryCode, string shipperName, string shipperAddressLine1, string shipperPostalCode, 
            string shipperCity, string shipperStateProvince, string shipperCountryCode, int itemClass)
        {
            #region initialisation
            ShipmentImportViewModel shipmentModel = new ShipmentImportViewModel();
            ServiceFlagViewModel serviceModel = new ServiceFlagViewModel();
            List<EquipmentViewModel> Equipment = new List<EquipmentViewModel>();
            EquipmentViewModel eqipment = new EquipmentViewModel();
            List<ServiceFlagViewModel> ServiceFlags = new List<ServiceFlagViewModel>();
            List<EquipmentViewModel> Equipments = new List<EquipmentViewModel>();
            List<ShipmentImportPricesheetViewModel> Pricesheets = new List<ShipmentImportPricesheetViewModel>();
            ShipmentImportPricesheetViewModel priceSheet = new ShipmentImportPricesheetViewModel();
            List<ShipmentImportItemViewModel> Items = new List<ShipmentImportItemViewModel>();
            ShipmentImportItemViewModel item = new ShipmentImportItemViewModel();
            ShipmentImportEnterpriseViewModel enterprisemodel = new ShipmentImportEnterpriseViewModel();
            ShipmentImportDateViewModel Dates = new ShipmentImportDateViewModel();
            ShipmentImportAddressViewModel Shipper = new ShipmentImportAddressViewModel();
            ShipmentImportAddressViewModel Consignee = new ShipmentImportAddressViewModel();
            ShipmentImportItemDimensionsViewModel Dimensions = new ShipmentImportItemDimensionsViewModel();
            ShipmentImportFreightClassViewModel FreightClasses = new ShipmentImportFreightClassViewModel();
            ShipmentImportMeasurementViewModel Weights = new ShipmentImportMeasurementViewModel();
            ShipmentImportMeasurementViewModel Quantities = new ShipmentImportMeasurementViewModel();
            ShipmentImportPaymentViewModel Payment = new ShipmentImportPaymentViewModel();
            ShipmentImportAddressViewModel PaymentAddress = new ShipmentImportAddressViewModel();
            #endregion
            enterprisemodel.Name = customerName;
            if (!string.IsNullOrEmpty(serviceCode))
                serviceModel.ServiceCode = serviceCode;
            eqipment.EquipmentCode = "LTL";
            shipmentModel.Status = status;
            shipmentModel.Enterprise = enterprisemodel;
            Dates.EarliestPickupDate = DateTime.UtcNow;
            Dates.LatestPickupDate = DateTime.UtcNow.AddDays(1);
            Dates.EarliestDropDate = DateTime.UtcNow.AddDays(3);
            Dates.LatestDropDate = DateTime.UtcNow.AddDays(3);

            shipmentModel.Dates = Dates;
            priceSheet.Type = "Carrier";
            priceSheet.IsSelected = true;
            priceSheet.ContractId = "(182466496431,3023,0)";
            Consignee.IsResidential = false;
            Consignee.Name = consigneeName;
            Consignee.AddressLine1 = consigneeAddressLine1;
            Consignee.PostalCode = consigneePostalCode;
            Consignee.City = consigneeCity;
            Consignee.StateProvince = consigneeStateProvince;
            Consignee.CountryCode = consigneeCountryCode;
            shipmentModel.Consignee = Consignee;
            Shipper.IsResidential = false;
            Shipper.Name = shipperName;
            Shipper.AddressLine1 = shipperAddressLine1;
            Shipper.PostalCode = shipperPostalCode;
            Shipper.City = shipperCity;
            Shipper.StateProvince = shipperStateProvince;
            Shipper.CountryCode = shipperCountryCode;
            shipmentModel.Shipper = Shipper;
            item.Id = "CRM";
            Dimensions.Length = 10.0;
            Dimensions.Width = 11.0;
            Dimensions.Height = 12.0;
            Dimensions.Uom = "in";
            FreightClasses.FreightClass = itemClass;
            FreightClasses.Type = "";
            item.HazardousMaterial = false;
            Weights.Actual = 100;
            Weights.Uom = "lb";
            Quantities.Actual = 1;
            Quantities.Uom = "CRT";
            Pricesheets.Add(priceSheet);
            item.FreightClasses = FreightClasses;
            item.Dimensions = Dimensions;
            item.Quantities = Quantities;
            item.Description = "Verify";
            Weights.Actual = 100;
            item.Weights = Weights;
            Items.Add(item);
            ServiceFlags.Add(serviceModel);
            Equipments.Add(eqipment);
            shipmentModel.Equipments = Equipments;
            shipmentModel.Pricesheets = Pricesheets;
            shipmentModel.ServiceFlags = ServiceFlags;
            shipmentModel.Items = Items;
            PaymentAddress.IsResidential = false;
            PaymentAddress.PostalCode = "60504";
            Payment.Address = PaymentAddress;
            shipmentModel.Payment = Payment;

            return shipmentModel;
        }
    }
}
