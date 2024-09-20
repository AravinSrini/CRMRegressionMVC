using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System.Xml.Linq;

namespace CRM.UITest.Helper.Implementations
{
    public class AssignIsGuaranteedCarrierPriceToGuaranteedCarrier : IAssignIsGuaranteedCarrierPriceToGuaranteedCarrier
    {
        private readonly IDecodeToBase64 _decodeToBase64;
        private readonly ICheckForGuaranteedRateNodeInPriceSheet _checkForGuaranteedRateNodeInPriceSheet;

        public AssignIsGuaranteedCarrierPriceToGuaranteedCarrier(IDecodeToBase64 decodeToBase64,
                                                                 ICheckForGuaranteedRateNodeInPriceSheet checkForGuaranteedRateNodeInPriceSheet)
        {
            _decodeToBase64 = decodeToBase64;
            _checkForGuaranteedRateNodeInPriceSheet = checkForGuaranteedRateNodeInPriceSheet;
        }

        public RateResultCarrierViewModel AssignIsGuaranteedCarrierPrice(RateResultCarrierViewModel carrier)
        {
            //Get PriceSheet for the carrier
            XElement priceSheetElement = XElement.Parse(_decodeToBase64.DecodeBase64String(carrier.Pricesheets));

            //Check whether priceSheetElement is having "Guaranteed Rate" Accessorial node in Charges element, and assign IsGuaranteedCarrierPrice for carrier
            carrier.IsGuaranteedCarrierPrice = _checkForGuaranteedRateNodeInPriceSheet.CheckIfGuaranteedRateNodeExists(priceSheetElement);

            return carrier;
        }
    }
}
