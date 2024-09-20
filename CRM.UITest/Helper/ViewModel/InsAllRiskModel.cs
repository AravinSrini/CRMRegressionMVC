using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class InsAllRiskModel
    {
        public decimal CostPerHundred { get; set; }
        public decimal MinimumCost { get; set; }
        public decimal? MaximumCost { get; set; }
        public decimal shipmentCoverage { get; set; }
    }
}
