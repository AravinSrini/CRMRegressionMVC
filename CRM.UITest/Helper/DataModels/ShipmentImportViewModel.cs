using System.Collections.Generic;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentImportViewModel
    {
        public ShipmentImportEnterpriseViewModel Enterprise { get; set; }


        public List<ShipmentImportReferenceNumberViewModel> ReferenceNumbers { get; set; }


        public List<ServiceFlagViewModel> ServiceFlags { get; set; }


        public List<EquipmentViewModel> Equipments { get; set; }


        public ShipmentImportDateViewModel Dates { get; set; }


        public ShipmentImportAddressViewModel Shipper { get; set; }


        public ShipmentImportAddressViewModel Consignee { get; set; }


        public List<ShipmentImportItemViewModel> Items { get; set; }


        public ShipmentImportPaymentViewModel Payment { get; set; }


        public List<ShipmentImportPricesheetViewModel> Pricesheets { get; set; }


        public string ShipmentMode { get; set; }

        public string PrimaryReference { get; set; }

        public string Status { get; set; }
    }
}
