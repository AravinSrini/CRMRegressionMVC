using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.ViewModel
{
    public class CostComponents
    {
        public decimal TotalCost { get; set; }

        public decimal FuelCost { get; set; }

        public decimal LineHaul { get; set; }

        public decimal Assessorial { get; set; }

        public decimal FuelPercentage { get; set; }
    }
}
