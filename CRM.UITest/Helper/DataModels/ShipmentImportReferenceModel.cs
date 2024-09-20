using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentImportReferenceModel
    {
        public string ReferenceNumber { get; set; }

        public string Type { get; set; }

        public string CustomerType { get; set; }

        public bool? IsPrimary { get; set; }
    }
}
