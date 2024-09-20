using System;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentImportAddressViewModel
    {
        public bool? IsResidential { get; set; }

        public DateTime? EarliestAppointmentTime { get; set; }

        public DateTime? LatestAppointmentTime { get; set; }

        public string LocationCode { get; set; }

        public string Name { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string StateProvince { get; set; }

        public string PostalCode { get; set; }

        public string CountryCode { get; set; }

        public ShipmentImportGeoLocationModel GeoLocation { get; set; }

        public string Comments { get; set; }

        public ShipmentImportContactModel Contact { get; set; }

        public string Type { get; set; }
    }
}
