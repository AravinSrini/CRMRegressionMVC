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
    
    public partial class ApiEndPoint
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ApiEndPoint()
        {
            this.CustomerEndPointMappings = new HashSet<CustomerEndPointMapping>();
        }
    
        public int ApiEndPointId { get; set; }
        public string EndPointName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public string ModifiedBy { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CustomerEndPointMapping> CustomerEndPointMappings { get; set; }
    }
}
