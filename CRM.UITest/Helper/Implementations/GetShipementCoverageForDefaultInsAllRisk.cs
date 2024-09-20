using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetShipementCoverageForDefaultInsAllRisk : IGetShipementCoverageForDefaultInsAllRisk
    {
        public decimal GetShipmentCoverageValue(InsAllRiskModel insAllRiskModel, double shipmentValueInsure)
        {
            decimal shipmentCoverage = 0M;

            if (insAllRiskModel != null)
            {
                //Multiplier for Default InsAll Calculations
                double multiplier = Convert.ToDouble(insAllRiskModel.CostPerHundred);

                //Minimum Shipment Coverage Fee for Default InsAll Calculations
                double minimumShipmentCoverageFee = Convert.ToDouble(insAllRiskModel.MinimumCost);

                double additionalValue = Math.Ceiling(shipmentValueInsure / 100) * multiplier;

                shipmentCoverage = additionalValue > minimumShipmentCoverageFee ? (decimal)additionalValue : (decimal)minimumShipmentCoverageFee;

                if (insAllRiskModel.MaximumCost != null)
                {
                    //Maximum Shipment Coverage Fee for Default InsAll Calculations
                    double maximumShipmentCoverageFee = Convert.ToDouble(insAllRiskModel.MaximumCost);

                    shipmentCoverage = (decimal)maximumShipmentCoverageFee > shipmentCoverage ?
                    shipmentCoverage : (decimal)maximumShipmentCoverageFee;
                }
            }

            return shipmentCoverage;
        }
    }
}
