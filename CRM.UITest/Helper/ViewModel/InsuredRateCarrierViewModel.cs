using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class InsuredRateCarrierViewModel
    {
        public string CarrierCode { get; set; }

        public string OldCarrierCode { get; set; }

        public string CarrierName { get; set; }

        public string NewCostPerPound { get; set; }

        public string UsedCostPerPound { get; set; }

        public string NewMaximumLiabilityCoverage { get; set; }

        public string UsedMaximumLiabilityCoverage { get; set; }
    }
}
