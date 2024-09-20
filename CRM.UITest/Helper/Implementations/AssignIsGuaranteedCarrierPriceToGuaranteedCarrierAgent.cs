using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class AssignIsGuaranteedCarrierPriceToGuaranteedCarrierAgent : IAssignIsGuaranteedCarrierPriceToGuaranteedCarrierAgent
    {
        private readonly IAssignIsGuaranteedCarrierPriceToGuaranteedCarrier _assignIsGuaranteedCarrierPriceToGuaranteedCarrier;

        public AssignIsGuaranteedCarrierPriceToGuaranteedCarrierAgent(IAssignIsGuaranteedCarrierPriceToGuaranteedCarrier assignIsGuaranteedCarrierPriceToGuaranteedCarrier)
        {
            _assignIsGuaranteedCarrierPriceToGuaranteedCarrier = assignIsGuaranteedCarrierPriceToGuaranteedCarrier;
        }

        public List<RateResultCarrierViewModel> AssignIsGuaranteedCarrierPrice(List<RateResultCarrierViewModel> carriersAndRates)
        {
            for (int i = 0; i < carriersAndRates?.Count; i++)
            {
                if (carriersAndRates[i].IsGuaranteedCarrier)
                {
                    carriersAndRates[i] = _assignIsGuaranteedCarrierPriceToGuaranteedCarrier.AssignIsGuaranteedCarrierPrice(carriersAndRates[i]);
                }
            }

            return carriersAndRates;
        }
    }
}
