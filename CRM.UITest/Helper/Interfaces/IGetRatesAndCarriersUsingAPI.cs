using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Helper.Interfaces
{
    public interface IGetRatesAndCarriersUsingAPI
    {
        RateRequestViewModel CallRateRequestApi(String CustomerName,String Service, String pickUpCityName, String pickUpZipCode, String pickUpStateCode, String pickUpCountry, String dropUpCityName, String dropUpZipCode, String dropUpStateCode, String dropUpCountry,
                                                        String freightClass, Double quantity, String quantityUnit, Double weight, String weightUnit,string userEmail);
       // List<string> CallRateRequestApi(RateConstraintsModel rate, RateEventModel RateEvent, List<RateItemModel> RateItemModel);
    }
}
