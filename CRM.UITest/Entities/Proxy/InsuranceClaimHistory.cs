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
    
    public partial class InsuranceClaimHistory
    {
        public int InsuranceClaimHistoryId { get; set; }
        public int ClaimNumber { get; set; }
        public int CategoryId { get; set; }
        public string Comments { get; set; }
        public string UserFullName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual InsuranceClaim InsuranceClaim { get; set; }
    }
}
