using System;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentImportDateViewModel
    {
        public DateTime? EarliestPickupDate { get; set; }

        public DateTime? LatestPickupDate { get; set; }

        public DateTime? EarliestDropDate { get; set; }

        public DateTime? LatestDropDate { get; set; }
    }
}
