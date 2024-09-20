using System;
using System.Collections.Generic;
using System.Linq;
using CRM.UITest.Dependency_resolution;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using Unity;

namespace CRM.UITest.Helper.Implementations
{
    public class GetRatesAndCarriersUsingAPI 
    {
        public static List<RateResultCarrierViewModel> CallRateRequestApi(String CustomerName, String Service, String pickUpCityName, String pickUpZipCode, String pickUpStateCode, String pickUpCountry, String dropUpCityName, String dropUpZipCode, String dropUpStateCode, String dropUpCountry,
                                                       String freightClass, Double quantity, String quantityUnit, Double weight, String weightUnit,string userEmail, bool callProxyApiVersion2)
        //public List<string> CallRateRequestApi(RateConstraintsModel rate, RateEventModel RateEvent, List<RateItemModel> RateItemModel)
        {
            IUnityContainer container = new UnityContainer();
            UnityConfiguration unityConfiguration = new UnityConfiguration();
            container = unityConfiguration.Initialize();
            IRatesAndCarriers ratesAndCarriers = container.Resolve<RatesAndCarriers>();

            // string CustomerName = "ZZZ Sandbox DLS Worldwide";
            RateRequestViewModel req = new RateRequestViewModel();
            RateItemModel item = new RateItemModel();
            req.RatingLevel = CustomerName;
            req.Constraints = new RateConstraintsModel()
            { Mode = Service };
            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now,
                Zip = dropUpZipCode,
                State = dropUpStateCode



            };
            req.DropEvent = Drop;
            RateEventModel Pickup = new RateEventModel()
            {
                City = pickUpCityName,
                Country = pickUpCountry,
                Date = DateTime.Now,
                Zip = pickUpZipCode,
                State = pickUpStateCode

            };
            req.PickupEvent = Pickup;
            RateItemModel itemmodel = new RateItemModel()
            {
                FreightClass=freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);
            //req.Constraints.Mode = Service;
            //req.DropEvent.City = pickUpCityName;
            //req.DropEvent.Zip = pickUpZipCode;
            //req.DropEvent.State = pickUpStateCode;
            //req.DropEvent.Country = pickUpCountry;
            //req.DropEvent.Date = DateTime.Now;

            //req.PickupEvent.City = pickUpCityName;
            //req.PickupEvent.Zip = pickUpZipCode;
            //req.PickupEvent.State = pickUpStateCode;
            //req.PickupEvent.Country = pickUpCountry;
            //req.PickupEvent.Date = DateTime.Now;

            //item.FreightClass = freightClass;
            //item.Quantity = quantity;
            //item.QuantityUnits = quantityUnit;
            //item.Weight = weight;
            //item.WeightUnits = weightUnit;
            req.Items = lstItemmodel;
            List<RateResultCarrierViewModel> rateResultCarrierList = null;
            string errorMessage = null;
            rateResultCarrierList=ratesAndCarriers.GetCustomerRateResultsandCarriers(req,userEmail,
                callProxyApiVersion2, out errorMessage).ToList();

            return rateResultCarrierList;
        }
    }
}
