using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetTotalWeights : IGetTotalWeights
    {
        private const string kilos = "KG";
        private readonly IWeightUnitConvertor _weightUnitConverter;

        public GetTotalWeights(IWeightUnitConvertor weightUnitConverter)
        {
            _weightUnitConverter = weightUnitConverter;
        }

        public double GetTotalPounds(List<RateItemModel> item)
        {
            double pounds = 0;
            double totalWeight = 0;

            foreach (var weight in item)
            {
                if (weight.WeightUnits.ToUpper() == kilos)
                {
                    pounds = _weightUnitConverter.ConvertWeightToPound(weight.Weight);
                }
                else
                {
                    pounds = weight.Weight;
                }

                totalWeight += pounds;
            }

            return totalWeight;
        }
    }
}
