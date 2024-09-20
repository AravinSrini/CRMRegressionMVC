using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Helper.Interfaces;

using System.Collections.Generic;

namespace CRM.UITest.Helper.ViewModel
{
    public class ShipmentExtractViewModel
    {
        public string ShipmentMode { get; set; }

        public string ServiceType { get; set; }

        public List<ShipmentImportReferenceModel> ReferenceNumbers { get; set; }

        public List<OriginAddressViewModels> AddressViewModels { get; set; }

        public List<OriginAddressViewModels> OriginAddressViewModels { get; set; }

        public List<ItemBusinessModel> ItemViewModels { get; set; }

        public string EarliestPickupDate { get; set; }

        public string EarliestDropDate { get; set; }

        public string LatestPickupDate { get; set; }

        public string LatestDropDate { get; set; }

        public string ActualPickupDate { get; set; }

        public string ActualDeliveryDate { get; set; }

        public List<ShipmentImportContactModel> ContactViewModels { get; set; }

        public ShipmentDetailModel ShipmentDetailsViewModel { get; set; }

        public CarrierRateModel CarrierRatesViewModel { get; set; }

        public string Status { get; set; }

        public string TmsSystem { get; set; }

       // public List<TrackingViewModel> TrackingDetails { get; set; }

        public string ControllingCustomerNumber { get; set; }

        public string PriceSheet { get; set; }
    }
}
