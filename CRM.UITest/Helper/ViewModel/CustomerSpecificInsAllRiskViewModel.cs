using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class CustomerSpecificInsAllRiskViewModel
    {
        public string StationId { get; set; }

        public string StationName { get; set; }

        public int CountOfCustomer { get; set; }

        public List<CustomerSpecificInsAllRiskDetailsViewModel> CustomerSpecificInsAllRiskDetails { get; set; }
    }
}
