//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CRM.UITest.Entities.Proxy
{
    using System;
    using System.Collections.Generic;
    
    public partial class InsuranceClaimFreightCopy
    {
        public int InsuranceClaimFreightId { get; set; }
        public int ClaimNumber { get; set; }
        public Nullable<bool> IsOriginalFreightCharges { get; set; }
        public Nullable<decimal> OriginalFreightChargesValue { get; set; }
        public Nullable<bool> IsReturnFreightCharges { get; set; }
        public Nullable<decimal> ReturnFreightChargesValue { get; set; }
        public string ReturnFreightChargesDlswRefNumber { get; set; }
        public Nullable<bool> IsReplacementFreightCharges { get; set; }
        public Nullable<decimal> ReplacementFreightChargesValue { get; set; }
        public string ReplacementFreightDlswRefNumber { get; set; }
        public decimal SubTotalClaimValue { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDateTime { get; set; }
        public Nullable<decimal> OriginalCarrierChargesToDlswValue { get; set; }
        public Nullable<decimal> OriginalDlswChargesToCustomerValue { get; set; }
        public string OriginalFreightChargesDlswRefNumber { get; set; }
        public Nullable<decimal> ReturnCarrierChargesToDlswValue { get; set; }
        public Nullable<decimal> ReturnDlswChargesToCustomerValue { get; set; }
        public Nullable<decimal> ReplacementCarrierChargesToDlswValue { get; set; }
        public Nullable<decimal> ReplacementDlswChargesToCustomerValue { get; set; }
        public string Comments { get; set; }
    
        public virtual InsuranceClaimCopy InsuranceClaimCopy { get; set; }
    }
}
