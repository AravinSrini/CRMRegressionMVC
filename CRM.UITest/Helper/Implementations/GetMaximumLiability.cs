using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations 
{
    public class GetMaximumLiability : IGetMaximumLiability
    {
        private readonly ICalculateMaximumLiabilityCoverage _calculateMaximumLiabilityCoverage;
        private readonly IMaximumLiabilityRepository _maximumLiabilityRepository;
        private readonly IGetTotalWeights _getTotalWeights;
        private readonly ICompareMaximumLiability _compareMaximumLiability;

        public GetMaximumLiability(ICalculateMaximumLiabilityCoverage calculateMaximumLiabilityCoverage, IMaximumLiabilityRepository maximumLiabilityRepository,
            IGetTotalWeights getTotalWeights, ICompareMaximumLiability compareMaximumLiability)
        {
            _calculateMaximumLiabilityCoverage = calculateMaximumLiabilityCoverage;
            _maximumLiabilityRepository = maximumLiabilityRepository;
            _getTotalWeights = getTotalWeights;
            _compareMaximumLiability = compareMaximumLiability;
        }

        public RateResultCarrierViewModel ComputeMaximumLiability(RateResultCarrierViewModel rateResultCarrierViewModel, List<RateItemModel> items)
        {
            string MaximumLiability = string.Empty;
            double totalWeight = 0;

            //Get Total Weights
            totalWeight = _getTotalWeights.GetTotalPounds(items);

            //Get Maximum Liability from Database
            InsuredRateCarrierViewModel insuredRate = _maximumLiabilityRepository.GetMaximumLiabilites(rateResultCarrierViewModel.ScacCode);

            if (insuredRate != null)
            {
                //Calculate the MaximumLiability
                double calculatedMaximumLiabilityNew = _calculateMaximumLiabilityCoverage.CalculateMaximumLiability(totalWeight, insuredRate.NewCostPerPound);
                double calculatedMaximumLiabilityUsed = _calculateMaximumLiabilityCoverage.CalculateMaximumLiability(totalWeight, insuredRate.UsedCostPerPound);

                //Compare MaximumLiability
                if (insuredRate.NewMaximumLiabilityCoverage != null)
                {
                    rateResultCarrierViewModel.MaximumLiabilityNew = _compareMaximumLiability.GetMaximumLiability(calculatedMaximumLiabilityNew, insuredRate.NewMaximumLiabilityCoverage);
                }

                if (insuredRate.UsedMaximumLiabilityCoverage != null)
                {
                    rateResultCarrierViewModel.MaximumLiabilityUsed = _compareMaximumLiability.GetMaximumLiability(calculatedMaximumLiabilityUsed, insuredRate.UsedMaximumLiabilityCoverage);
                }
            }

            return rateResultCarrierViewModel;
        }
    }
}
