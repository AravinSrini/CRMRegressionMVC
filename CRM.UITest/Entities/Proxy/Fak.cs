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
    
    public partial class Fak
    {
        public int FakId { get; set; }
        public int TariffPricingModelId { get; set; }
        public Nullable<decimal> FakNo { get; set; }
        public Nullable<decimal> MinRange { get; set; }
        public Nullable<decimal> MaxRange { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual TariffPricingModel TariffPricingModel { get; set; }
    }
}
