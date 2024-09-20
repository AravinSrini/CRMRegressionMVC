using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper
{
    public class CustomerRatingLogicAuditModel
    {
        public bool OldRatingLogicValue { get; set; }
        public bool NewRatingLogicValue { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string StationName { get; set; }
        public string CustomerName { get; set; }
    }
}
