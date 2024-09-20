using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class InsuranceClaimDetailsHeaderViewModel
    {
        public int ClaimNumber { get; set; }
        public string Claimant { get; set; }
        public string Carriername { get; set; }
        public string CarrierPro { get; set; }
        public string ClaimRep { get; set; }
        public string ClaimReason { get; set; }
        public DateTime ClaimCreatedDate { get; set; }
        public string DLSWReferenceNumber { get; set; }
        public bool IsClaimInsured { get; set; }

    }
}
