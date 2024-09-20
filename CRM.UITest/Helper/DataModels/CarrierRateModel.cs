using System.Collections.Generic;

namespace CRM.UITest.Helper.DataModels
{
    /// <summary>
    /// View model for CarrierRate
    /// </summary>
    public class CarrierRateModel
    {
        public string Carrier { get; set; }

        public string ScacCode { get; set; }

        public string ServiceDays { get; set; }

        public string Distance { get; set; }
        
        public List<CsaChargesModel> Charges { get; set; }

        public string Total { get; set; }

        public string SubTotal { get; set; }

        public double LineHaul { get; set; }

        public double Fuel { get; set; }

        public double Accessorial { get; set; }

        public string NewMaximumLiabilityCoverage { get; set; }

        public string UsedMaximumLiabilityCoverage { get; set; }

        public string CarrierLogoPath { get; set; }
    }
}
