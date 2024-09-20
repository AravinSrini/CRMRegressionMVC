using System.Collections.Generic;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IRatesAndCarriers
    {
        IEnumerable<RateResultCarrierViewModel> GetCustomerRateResultsandCarriers(
       RateRequestViewModel rateRequest, string userEmail, bool callProxyApiVersion2,
       out string errorMessage);

        IEnumerable<IndividualAccessorialModel> GetIndivudualAccessorials(
      RateRequestViewModel rateRequest, string userEmail,bool callProxyApiVersion2,
      out string errorMessage);

        IEnumerable<IndividualAccessorialModel> GetIndivudualAccessorialsCostPricesheet(
          RateRequestViewModel rateRequest, string userEmail, bool callProxyApiVersion2,
            out string errorMessage);
    }
}
