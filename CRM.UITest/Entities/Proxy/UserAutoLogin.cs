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
    
    public partial class UserAutoLogin
    {
        public int UserAutoLoginId { get; set; }
        public Nullable<int> CustomerAccountId { get; set; }
        public string RealmValue { get; set; }
        public string SubmittedBy { get; set; }
        public System.DateTime SubmittedOn { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
    
        public virtual CustomerAccount CustomerAccount { get; set; }
    }
}
