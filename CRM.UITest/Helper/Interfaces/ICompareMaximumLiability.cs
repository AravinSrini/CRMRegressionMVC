using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Interfaces
{
    public interface ICompareMaximumLiability
    {
        string GetMaximumLiability(double calculatedLiability, string thresholdLiability);
    }
}
