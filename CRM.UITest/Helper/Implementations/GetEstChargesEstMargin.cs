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
    public class GetEstChargesEstMargin : IGetEstChargesEstMargin
    {
        private readonly IRateCharges _rateCharges;
        private readonly IGetEstMargin _getEstMargin;

        public GetEstChargesEstMargin(IRateCharges rateCharges, IGetEstMargin getEstMargin)
        {
            _rateCharges = rateCharges;
            _getEstMargin = getEstMargin;
        }

        public RateResultCarrierViewModel GetEstFields(XElement priceSheetElement, RateResultCarrierViewModel rateResultCarrierModel)
        {
            if (priceSheetElement.Elements("AssociatedCarrierPricesheet")?.Elements("PriceSheet").FirstOrDefault() != null)
            {
                XElement associatedPriceSheetElement = priceSheetElement.Elements("AssociatedCarrierPricesheet")?.Elements("PriceSheet")?.FirstOrDefault();

                rateResultCarrierModel.EstCharges = _rateCharges.TransformRateCharges(associatedPriceSheetElement);

                rateResultCarrierModel.EstMargin = _getEstMargin.CalculateEstMargin(rateResultCarrierModel);
            }

            return rateResultCarrierModel;
        } 
    }
}
