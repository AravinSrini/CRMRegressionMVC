using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class CustomReportViewModel
    {
        public string UserEmail { get; set; }

        public string ReportName { get; set; }

        public string OriginCity { get; set; }

        public string DestinationCity { get; set; }

        public string ReferenceNumbers { get; set; }

        public DateTime PickUpDateStart { get; set; }

        public DateTime PickUpDateEnd { get; set; }

        public List<string> Status { get; set; }

        public List<string> ShipmentServiceTypes { get; set; }
    }
}
