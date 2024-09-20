using CRM.UITest.Entities.Proxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class CsrAccessorialCustomerSetUpModel
    {
        public int AccessorialCustomerSetupId { get; set; }
        public int CustomerAccountId { get; set; }
        public string AccessorialCode { get; set; }
        public decimal AccessorialValue { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public string GainShareType { get; set; }

        public virtual CsrCustomerAccount CsrCustomerAccount { get; set; }
    }
}
