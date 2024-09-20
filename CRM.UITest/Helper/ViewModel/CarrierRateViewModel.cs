using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class CarrierRateViewModel
    {
        public string CarrierCode { get; set; }

        public string CarrierName { get; set; }

        public string MarkupPercentage { get; set; }

        public int? ServiceDays { get; set; }

        public string MinAmountCharge { get; set; }

        public bool IsGuaranteed { get; set; }

        public string NewMaximumLiabilityCoverage { get; set; }

        public string UsedMaximumLiabilityCoverage { get; set; }
    }
}
