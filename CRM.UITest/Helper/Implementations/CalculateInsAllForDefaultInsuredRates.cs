using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    class CalculateInsAllForDefaultInsuredRates : ICalculateInsAllForDefaultInsuredRates
    {
        private readonly IGetCustomerInsuranceAllRiskByCustomerAccountId _customerInsuranceAllRiskByCustomerAccountId;
        private readonly IGetCustomerAccountId _getCustomerAccountId;
        private readonly IGetInsAllRiskParameters _getInsAllRiskParameters;
        private readonly IGetShipementCoverageForDefaultInsAllRisk _getShipementCoverageForDefaultInsAllRisk;

        public CalculateInsAllForDefaultInsuredRates(IGetCustomerInsuranceAllRiskByCustomerAccountId customerInsuranceAllRiskByCustomerAccountId,
            IGetCustomerAccountId getCustomerAccountId, IGetInsAllRiskParameters getInsAllRiskParameters, IGetShipementCoverageForDefaultInsAllRisk getShipementCoverageForDefaultInsAllRisk)
        {
            _customerInsuranceAllRiskByCustomerAccountId = customerInsuranceAllRiskByCustomerAccountId;
            _getCustomerAccountId = getCustomerAccountId;
            _getInsAllRiskParameters = getInsAllRiskParameters;
            _getShipementCoverageForDefaultInsAllRisk = getShipementCoverageForDefaultInsAllRisk;
        }

        public decimal DefaultInsAllCalculation(double shipmentValueInsure, string customerName)
        {
            decimal shipmentCoverage = 0;

            int customerAccountId = _getCustomerAccountId.GetCustomerAccountIdFromDb(customerName);
            InsAllRiskViewModel insuranceAllRiskModel = _customerInsuranceAllRiskByCustomerAccountId.GetCustomerInsuranceAllRisk(customerAccountId);

            CustomerSpecificInsAllRiskDetailsViewModel customerSpecificInsAllRiskDetailsViewModel = (insuranceAllRiskModel.CustomerSpecificInsAllRisk?.Count > 0
                && insuranceAllRiskModel.CustomerSpecificInsAllRisk[0]?.CustomerSpecificInsAllRiskDetails?.Count > 0)
                ? insuranceAllRiskModel.CustomerSpecificInsAllRisk?[0]?.CustomerSpecificInsAllRiskDetails[0] : null;

            InsAllRiskModel insAllRiskModel = _getInsAllRiskParameters.GetInsAllRiskCalculationParameters(customerSpecificInsAllRiskDetailsViewModel);

            bool isValidInsAllParameters = (insAllRiskModel?.MinimumCost == 0 && (insAllRiskModel?.MaximumCost == null || insAllRiskModel?.MaximumCost == 0));

            if (!isValidInsAllParameters)
            {
                shipmentCoverage = _getShipementCoverageForDefaultInsAllRisk.GetShipmentCoverageValue(insAllRiskModel, shipmentValueInsure);
            }

            return shipmentCoverage;
        }
    }
}
