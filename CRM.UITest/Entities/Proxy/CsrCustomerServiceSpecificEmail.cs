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
    
    public partial class CsrCustomerServiceSpecificEmail
    {
        public int Id { get; set; }
        public int CustomerAccountId { get; set; }
        public string Email { get; set; }
        public string ServiceType { get; set; }
        public string CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
    
        public virtual CsrCustomerAccount CsrCustomerAccount { get; set; }
    }
}
