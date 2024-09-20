using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.DataModels
{
    public class FinalBumpSurgeCalculationModel
    {
        public decimal LineHaul { get; set; }

        public decimal Fuel { get; set; }

        public decimal Total { get; set; }

        public decimal FuelSurgeCharge { get; set; }
    }
}
