
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Implementations
{
    public class GetEstMargin : IGetEstMargin
    {
        private readonly IConvertToTwoPlaceOfDecimal _convertToTwoPlaceOfDecimal;

        public GetEstMargin(IConvertToTwoPlaceOfDecimal convertToTwoPlaceOfDecimal)
        {
            _convertToTwoPlaceOfDecimal = convertToTwoPlaceOfDecimal;
        }

        public string CalculateEstMargin(RateResultCarrierViewModel rateResultCarrierModel)
        {
            double estMarginValue = 0.00;

            double quoteAmount = Convert.ToDouble(rateResultCarrierModel?.Charges?[0]?.TotalCost);

            double estCost = Convert.ToDouble(rateResultCarrierModel?.EstCharges?[0]?.TotalCost);

            if (quoteAmount != 0)
            {
                estMarginValue = Math.Round((((quoteAmount - estCost) / quoteAmount) * 100), 2);
            }

            string estMargin = _convertToTwoPlaceOfDecimal.ConvertToTwoPlace(Convert.ToString(estMarginValue));

            return estMargin;
        }
    }
}
