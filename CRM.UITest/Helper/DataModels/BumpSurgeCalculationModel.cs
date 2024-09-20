using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class BumpSurgeCalculationModel
    {
        public decimal BreakOutLineHaul { get; set; }

        public decimal BreakOutAccessorialsTotal { get; set; }

        public decimal BreakOutFuel { get; set; }

        public decimal BreakOutTotal { get; set; }

        public decimal BumpLineHaul { get; set; }

        public decimal BumpFuel { get; set; }

        public decimal BumpTotal { get; set; }

        public decimal SurgeLineHaul { get; set; }

        public decimal SurgeBumpLineHaul { get; set; }

        public decimal SurgeFuel { get; set; }

        public decimal SurgeBumpFuel { get; set; }

        public decimal SurgeTotal { get; set; }

        public decimal SurgeBumpTotal { get; set; }

        public decimal Bump { get; set; }

        public decimal Surge { get; set; }

        public decimal FuelSurgeCharge { get; set; }
    }
}
