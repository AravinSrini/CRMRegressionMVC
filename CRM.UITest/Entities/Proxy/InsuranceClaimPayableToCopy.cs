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
    
    public partial class InsuranceClaimPayableToCopy
    {
        public int InsuranceClaimPayableToId { get; set; }
        public int ClaimNumber { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Address2 { get; set; }
        public int CountryId { get; set; }
        public string Zip { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }
        public string CompanyWebsite { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreateDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDateTime { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual InsuranceClaimCopy InsuranceClaimCopy { get; set; }
    }
}
