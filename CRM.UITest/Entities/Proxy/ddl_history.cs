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
    
    public partial class ddl_history
    {
        public Nullable<int> source_object_id { get; set; }
        public int object_id { get; set; }
        public Nullable<bool> required_column_update { get; set; }
        public string ddl_command { get; set; }
        public byte[] ddl_lsn { get; set; }
        public Nullable<System.DateTime> ddl_time { get; set; }
    }
}
