using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetLiabilityCostPerPound : IGetLiabilityCostPerPound
    {
        private readonly IMaximumLiabilityRepository _maximumLiabilityRepository;
        public GetLiabilityCostPerPound(IMaximumLiabilityRepository maximumLiabilityRepository)
        {
            _maximumLiabilityRepository = maximumLiabilityRepository;
        }
        public RateResultCarrierViewModel GetCostPerPound(RateResultCarrierViewModel rateResultCarrierViewModel)
        {
            InsuredRateCarrierViewModel insuredRate = _maximumLiabilityRepository.GetMaximumLiabilites(rateResultCarrierViewModel.ScacCode);
            if (insuredRate != null)
            {
                rateResultCarrierViewModel.NewCostPerPound = insuredRate.NewCostPerPound;
                rateResultCarrierViewModel.UsedCostPerPound = insuredRate.UsedCostPerPound;
            }

            return rateResultCarrierViewModel;
        }
    }
}
