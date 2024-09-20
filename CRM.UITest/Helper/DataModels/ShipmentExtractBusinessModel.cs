using System;
using System.Collections.Generic;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentExtractBusinessModel
    {
        public string ShipmentMode { get; set; }

        public List<ShipmentImportReferenceModel> ReferenceNumbers { get; set; }

        public List<OriginAddressViewModels> AddressViewModels { get; set; }

        public List<ItemBusinessModel> ItemViewModels { get; set; }

        public DateTime? EarliestPickupDate { get; set; }

        public DateTime? EarliestDropDate { get; set; }

        public DateTime? LatestPickupDate { get; set; }

        public DateTime? LatestDropDate { get; set; }

        public DateTime? ActualPickupDate { get; set; }

        public DateTime? ActualDeliveryDate { get; set; }

        public List<ShipmentImportContactModel> ContactViewModels { get; set; }

        public ShipmentDetailModel ShipmentDetailsViewModel { get; set; }

        public CarrierRateModel CarrierRatesViewModel { get; set; }

        public string Status { get; set; }
    }
}
