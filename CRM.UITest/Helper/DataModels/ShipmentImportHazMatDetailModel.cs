using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class ShipmentImportHazMatDetailModel
    {
        public string HazMatId { get; set; }

        public string ProperShippingName { get; set; }

        public string PackageGroup { get; set; }

        public string HazMatClass { get; set; }

        public string ContactName { get; set; }

        public string ContactPhone { get; set; }

        public string HazMatPlacards { get; set; }

        public string HazMatPlacardsDetails { get; set; }

        public double? HazMatFlashPointTemp { get; set; }

        public string HazMatFlashPointTempUom { get; set; }

        public double? HazMatEmsNumber { get; set; }

        public string Comments { get; set; }

        public string CcnNumber { get; set; }
    }
}
