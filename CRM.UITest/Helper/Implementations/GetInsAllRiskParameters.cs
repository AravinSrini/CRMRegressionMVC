using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetInsAllRiskParameters : IGetInsAllRiskParameters
    {
        private readonly IGetDefaultInsAllRiskDetails _defaultInsAllRiskDetails;

        public GetInsAllRiskParameters(IGetDefaultInsAllRiskDetails defaultInsAllRiskDetails)
        {
            _defaultInsAllRiskDetails = defaultInsAllRiskDetails;
        }

        public InsAllRiskModel GetInsAllRiskCalculationParameters(CustomerSpecificInsAllRiskDetailsViewModel customerSpecificInsAllRiskDetailsViewModel)
        {
            InsAllRiskModel insAllRiskModel = new InsAllRiskModel();
            decimal insAllRiskParameter = 0M;

            if (customerSpecificInsAllRiskDetailsViewModel != null && (decimal.TryParse(customerSpecificInsAllRiskDetailsViewModel.CostPerHundered, out insAllRiskParameter) && insAllRiskParameter > 0)
                && (decimal.TryParse(customerSpecificInsAllRiskDetailsViewModel.MinimumCost, out insAllRiskParameter) && insAllRiskParameter >= 0))
            {
                insAllRiskModel.CostPerHundred = Convert.ToDecimal(customerSpecificInsAllRiskDetailsViewModel.CostPerHundered);
                insAllRiskModel.MinimumCost = Convert.ToDecimal(customerSpecificInsAllRiskDetailsViewModel.MinimumCost);
                insAllRiskModel.MaximumCost = decimal.TryParse(customerSpecificInsAllRiskDetailsViewModel.MaximumCost, out insAllRiskParameter) ? (decimal?)insAllRiskParameter : null;
            }
            else
            {
                InsAllRiskViewModel insAllRiskViewModel = _defaultInsAllRiskDetails.GetDefaultInsAllRisk();
                insAllRiskModel.CostPerHundred = Convert.ToDecimal(insAllRiskViewModel?.DefaultcostPerHundred);
                insAllRiskModel.MinimumCost = Convert.ToDecimal(insAllRiskViewModel?.DefaultMinimumCost);
                insAllRiskModel.MaximumCost = decimal.TryParse(insAllRiskViewModel?.DefaultMaximumCost, out insAllRiskParameter) ? (decimal?)insAllRiskParameter : null;
            }

            return insAllRiskModel;
        }
    }
}
