using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class InsAllRiskViewModel
    {
        public int DefaultInsSettingId { get; set; }

        public string DefaultcostPerHundred { get; set; }

        public string DefaultMinimumCost { get; set; }

        public string DefaultMaximumCost { get; set; }

        public List<CustomerSpecificInsAllRiskViewModel> CustomerSpecificInsAllRisk { get; set; }

        public string MinimumCost { get; set; }

        public string CostPerHundered { get; set; }
    }
}
