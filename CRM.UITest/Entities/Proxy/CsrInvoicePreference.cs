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
    
    public partial class CsrInvoicePreference
    {
        public int InvoicePreferenceId { get; set; }
        public int CustomerAccountId { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
        public Nullable<bool> IsCreditCard { get; set; }
        public string CustomerInvoiceBackup { get; set; }
        public string CustomerInvoiceMethod { get; set; }
        public string CustomerInvoiceEmail { get; set; }
    
        public virtual CsrCustomerAccount CsrCustomerAccount { get; set; }
    }
}
