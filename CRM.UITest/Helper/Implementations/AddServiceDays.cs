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
    public class AddServiceDays:IAddServiceDays
    {
        private readonly IAddAdditionalServiceDays _additionalServiceDays;
        private readonly IElementNullCheck _elementNullCheck;
        private readonly IAssignAdditionalServiceDays _assignAdditionalServiceDays;

        public AddServiceDays(IAddAdditionalServiceDays additionalServiceDays, IElementNullCheck elementNullCheck, IAssignAdditionalServiceDays assignAdditionalServiceDays)
        {
            _additionalServiceDays = additionalServiceDays;
            _elementNullCheck = elementNullCheck;
            _assignAdditionalServiceDays = assignAdditionalServiceDays;
        }

        public RateResultCarrierViewModel AddtionalServiceDays(XElement priceSheetElement, RateResultCarrierViewModel rateResultCarrierViewModel)
        {
            double serviceDays = 0.0;
            string nodeValue = null;
            List<AddAdditionalServiceDaysModel> serviceDaysModel = null;

            serviceDaysModel = _additionalServiceDays.GetAdditionalServiceDays();
            nodeValue = _elementNullCheck.ReadElementWithNullCheck(priceSheetElement, "ServiceDays");

            double.TryParse(nodeValue, out serviceDays);

            rateResultCarrierViewModel = _assignAdditionalServiceDays.AssignServiceDays(rateResultCarrierViewModel, serviceDaysModel, serviceDays);

            return rateResultCarrierViewModel;
        }
    }
}
