using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class RateCharges : IRateCharges
    {

        private readonly IElementNullCheck _elementNullCheck;
        private readonly IAccessorialCost _accessorialCost;//Need to add implementaion
        private readonly IFuelCost _fuelCost;
        private readonly IFuelPercentage _fuelPercentage;
        private const string totalValue = "Total";
        private const string subTotalValue = "SubTotal";

        public RateCharges(IElementNullCheck elementNullCheck, IAccessorialCost accessorialCost, IFuelCost fuelCost, IFuelPercentage fuelPercentage)
        {
            _elementNullCheck = elementNullCheck;
            _accessorialCost = accessorialCost;
            _fuelCost = fuelCost;
            _fuelPercentage = fuelPercentage;
        }

        public List<CostComponents> TransformRateCharges(XElement priceSheetElement)
        {
            List<CostComponents> charges = new List<CostComponents>();
            CostComponents costComponents = new CostComponents();

            // Add the Shipment coverage value to the total cost.
            decimal total = 0;
            decimal.TryParse(_elementNullCheck.ReadElementWithNullCheck(priceSheetElement, totalValue), out total);
            costComponents.TotalCost = total;

            decimal subTotal = 0;
            decimal.TryParse(_elementNullCheck.ReadElementWithNullCheck(priceSheetElement, subTotalValue), out subTotal);
            costComponents.LineHaul = subTotal;

            // Get Accessorial Cost
            costComponents = _accessorialCost.GetAccessorialCost(priceSheetElement, costComponents);

            // Get Fuel Cost 
            costComponents.FuelCost = _fuelCost.GetFuelCost(priceSheetElement);

            costComponents.FuelPercentage = _fuelPercentage.GetFuelPercentage(priceSheetElement);

            charges.Add(costComponents);

            return charges;
        }
    }
}
