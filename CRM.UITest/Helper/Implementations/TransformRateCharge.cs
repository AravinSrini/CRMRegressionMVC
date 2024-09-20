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
    public class TransformRateCharge : ITransformRateCharge
    {
        private readonly IReadElementWithNullCheck _readElementWithNullCheck;
        private readonly IAccessorialCosts _accessorialCosts;
        private readonly IFuelCosts _fuelCosts;

        public TransformRateCharge(IReadElementWithNullCheck readElementWithNullCheck, IAccessorialCosts accessorialCosts,
            IFuelCosts fuelCosts)
        {
            _readElementWithNullCheck = readElementWithNullCheck;
            _accessorialCosts = accessorialCosts;
            _fuelCosts = fuelCosts;
        }

        public List<CostComponents> TransformRateCharges(
            XElement priceSheetElement,
            decimal shipmentCoverageValue)
        {

            List<CostComponents> charges = new List<CostComponents>();
            CostComponents costComponents = new CostComponents();
            string nodeValue = null;
            // ***
            // *** Add the Shipment coverage value to the total cost.
            // ***
            decimal total = 0;
            costComponents.TotalCost = _readElementWithNullCheck.ReadXmlElement(priceSheetElement, "Total", out nodeValue)
                ? decimal.TryParse(nodeValue, out total) ? total + shipmentCoverageValue : 0
                : 0;

            decimal subTotal = 0;
            costComponents.LineHaul = _readElementWithNullCheck.ReadXmlElement(priceSheetElement, "SubTotal", out nodeValue)
                ? decimal.TryParse(nodeValue, out subTotal) ? subTotal : 0
                : 0;

            // *** Get Accessorial Cost

            costComponents = _accessorialCosts.GetAccessorialCosts(priceSheetElement, costComponents, nodeValue);

            // *** Add the Shipment coverage value to the Accessorial cost.

            costComponents.Assessorial += shipmentCoverageValue;

            // *** Get Fuel Cost 

            costComponents.FuelCost = _fuelCosts.GetFuelCosts(priceSheetElement, costComponents, nodeValue);

            charges.Add(costComponents);

            return charges;
        }
    }
}
