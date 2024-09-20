using CRM.UITest.Helper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class WeightUnitConvertor : IWeightUnitConvertor
    {
        public double ConvertWeightToPound(double weight)
        {
            var calculateLbs = weight * 2.2046;

            return calculateLbs;
        }
    }
}
