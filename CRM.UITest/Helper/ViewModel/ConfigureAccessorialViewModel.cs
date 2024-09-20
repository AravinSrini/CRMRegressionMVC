using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    class ConfigureAccessorialViewModel
    {
        public int AccessorialSetupId { get; set; }
        public string AccessorialName { get; set; }
        public string AccessorialCode { get; set; }
        public string MGAccessorialName { get; set; }
        public string CreatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string ModifiedBy { get; set; }
        public System.DateTime ModifiedDate { get; set; }
        public int AccessorialDirectionId { get; set; }

        public string AccessorialDirectionName { get; set; }
        public IList<string> ShipmentServiceName { get; set; }

        public IList<string> MG_Description { get; set; }

       
    }
}
