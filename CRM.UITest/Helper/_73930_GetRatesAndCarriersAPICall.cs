using System;
using System.Collections.Generic;
using System.Linq;
using CRM.UITest.Dependency_resolution;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.ViewModel;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Unity;

namespace CRM.UITest.Helper
{
    public class _73930_GetRatesAndCarriersAPICall
    {
        public string accessorialcode;

        public static List<RateResultCarrierViewModel> CallRateRequestApi(String CustomerName, String Service, String pickUpCityName, String pickUpZipCode, String pickUpStateCode, String pickUpCountry, String dropUpCityName, String dropUpZipCode, String dropUpStateCode, String dropUpCountry,
                                                String freightClass, Double quantity, String quantityUnit, Double weight, String weightUnit, string userEmail, bool callProxyApiVersion2, string destinationAccessorial, string originAccessorial)

        {
            IUnityContainer container = new UnityContainer();
            UnityConfiguration unityConfiguration = new UnityConfiguration();
            container = unityConfiguration.Initialize();
            IRatesAndCarriers ratesAndCarriers = container.Resolve<_73930_RatesAndCarriers>();

            // string CustomerName = "ZZZ Sandbox DLS Worldwide";
            RateRequestViewModel req = new RateRequestViewModel();
            RateItemModel item = new RateItemModel();
            req.RatingLevel = CustomerName;
            req.Constraints = new RateConstraintsModel() { Mode = Service };

            req.Constraints.ServiceFlags = new List<ServiceFlagModel>();
            if (destinationAccessorial != "")
            {
                req.Constraints.ServiceFlags.Add(new ServiceFlagModel { ServiceCode = destinationAccessorial });
            }
            if(originAccessorial != "")
            {
                req.Constraints.ServiceFlags.Add(new ServiceFlagModel { ServiceCode = originAccessorial });
            }

            // req.ShipmentValue = Shipevalue;
            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now.AddDays(3),
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
                FreightClass = freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);

            req.Items = lstItemmodel;
            List<RateResultCarrierViewModel> rateResultCarrierList = null;
            string errorMessage = null;
            rateResultCarrierList = ratesAndCarriers.GetCustomerRateResultsandCarriers(req, userEmail, callProxyApiVersion2, out errorMessage).ToList();
            return rateResultCarrierList;
        }

        public static List<RateResultCarrierViewModel> CallRateRequestApi_WithInsuredValue(String CustomerName, String Service, String pickUpCityName, String pickUpZipCode, String pickUpStateCode, String pickUpCountry, String dropUpCityName, String dropUpZipCode, String dropUpStateCode, String dropUpCountry,
                                                String freightClass, Double quantity, String quantityUnit, Double weight, String weightUnit, string userEmail, bool callProxyApiVersion2, double Insuredvalue)
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
            req.ShipmentValue = Insuredvalue;
            // req.ShipmentValue = Shipevalue;
            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now.AddDays(3),
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
                FreightClass = freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);

            req.Items = lstItemmodel;
            List<RateResultCarrierViewModel> rateResultCarrierList = null;
            string errorMessage = null;
            rateResultCarrierList = ratesAndCarriers.GetCustomerRateResultsandCarriers(req, userEmail, callProxyApiVersion2, out errorMessage).ToList();

            return rateResultCarrierList;
        }

        public static List<IndividualAccessorialModel> BuildIndividualAccessorialModelFromCarrierPriceSheet(String CustomerName,
            String Service,
            String pickUpCityName,
            String pickUpZipCode,
            String pickUpStateCode,
            String pickUpCountry,
            String dropUpCityName,
            String dropUpZipCode,
            String dropUpStateCode,
            String dropUpCountry,
            String OAccessorial,
            String DAccessorial,
            String freightClass,
            Double quantity,
            String quantityUnit,
            Double weight,
            String weightUnit,
            string userEmail,
            bool callProxyApiVersion2)
        {

            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(CustomerName);

            IUnityContainer container = new UnityContainer();
            UnityConfiguration unityConfiguration = new UnityConfiguration();
            container = unityConfiguration.Initialize();
            IRatesAndCarriers ratesAndCarriers = container.Resolve<_73930_RatesAndCarriers>();

            // string CustomerName = "ZZZ Sandbox DLS Worldwide";
            RateRequestViewModel req = new RateRequestViewModel();
            RateItemModel item = new RateItemModel();
            if (iSCrmRatingLogic_GainshareCustomer)
            {

                req.RatingLevel = CustomerName;
            }

            req.Constraints = new RateConstraintsModel();

            string acc = "";
            if (DAccessorial == null || DAccessorial == "" && OAccessorial != null || OAccessorial == string.Empty)
            {
                acc = OAccessorial;
            }
            else if (OAccessorial == null || OAccessorial == "" && DAccessorial != null || DAccessorial == string.Empty)
            {
                acc = DAccessorial;
            }
            else
            {
                acc = OAccessorial + "," + DAccessorial;
            }


            List<string> name = new List<string>();
            string[] sp = acc.Split(',');
            foreach (var r in sp)
            {
                if (r.Contains("OVL"))
                {
                    name.Add(r);
                }
                else
                {
                    AccessorialSetUp getacc_code = DBHelper.AccessorialName_to_Acc_Code(r);
                    if (getacc_code != null)
                    {
                        string u = getacc_code.AccessorialCode;
                        name.Add(u);
                    }
                }

            }



            List<ServiceFlagModel> ServiceFlags = new List<ServiceFlagModel>();
            for (int i = 0; i < name.Count; i++)
            {

                ServiceFlagModel s = new ServiceFlagModel();
                s.ServiceCode = name[i];
                ServiceFlags.Add(s);

            }


            req.Constraints.ServiceFlags = ServiceFlags;



            req.Constraints.Mode = Service;


            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now.AddDays(3),
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
                FreightClass = freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);

            req.Items = lstItemmodel;
            List<IndividualAccessorialModel> individualAccessorialsList = null;
            string errorMessage = null;
            individualAccessorialsList = ratesAndCarriers.GetIndivudualAccessorials(req, userEmail,
                callProxyApiVersion2, out errorMessage).ToList();

            return individualAccessorialsList;

        }

        public static List<RateResultCarrierViewModel> CallRateRequestApiWithAccessorials(
            String CustomerName,
            String Service,
            String pickUpCityName,
            String pickUpZipCode,
            String pickUpStateCode,
            String pickUpCountry,
            String dropUpCityName,
            String dropUpZipCode,
            String dropUpStateCode,
            String dropUpCountry,
            String OriginAccessorial,
            String DestinationAccessorial,
            String freightClass,
            Double quantity,
            String quantityUnit,
            Double weight,
            String weightUnit,
            string userEmail,
            bool callProxyApiVersion2)

        {
            IUnityContainer container = new UnityContainer();
            UnityConfiguration unityConfiguration = new UnityConfiguration();
            container = unityConfiguration.Initialize();
            IRatesAndCarriers ratesAndCarriers = container.Resolve<RatesAndCarriers>();


            RateRequestViewModel req = new RateRequestViewModel();
            RateItemModel item = new RateItemModel();
            req.RatingLevel = CustomerName;
            req.Constraints = new RateConstraintsModel()
            { Mode = Service };

            string accessorial = null;

            if (DestinationAccessorial == string.Empty || DestinationAccessorial == null && OriginAccessorial != string.Empty)
            {
                accessorial = OriginAccessorial;
            }
            else if (OriginAccessorial == string.Empty || OriginAccessorial == null && DestinationAccessorial != string.Empty)
            {
                accessorial = DestinationAccessorial;
            }
            else if (DestinationAccessorial == string.Empty || DestinationAccessorial == null && OriginAccessorial == string.Empty || OriginAccessorial == null)
            {
                Report.WriteLine("No Accessorials");
            }
            else
            {
                accessorial = OriginAccessorial + "," + DestinationAccessorial;
            }

            //if no accessorial selected
            if (accessorial == null || accessorial == string.Empty)
            {
                Report.WriteLine("No Accessorials");
            }
            else
            {
                List<string> name = new List<string>();
                string[] splitedAccessrorial = accessorial.Split(',');
                foreach (string r in splitedAccessrorial)
                {
                    if (r.Contains("OVL"))
                    {
                        name.Add(r);
                    }
                    else
                    {
                        AccessorialSetUp getacc_code = DBHelper.AccessorialName_to_Acc_Code(r);
                        //CRM.UITest.Entities.Proxy.CodeTable values = new CRM.UITest.Entities.Proxy.CodeTable();
                        //values = DBHelper.AccessorialNameToCode(r);
                        //string u = values.Code;
                        string u = getacc_code.AccessorialCode;
                        name.Add(u);

                    }

                }

                List<ServiceFlagModel> ServiceFlags = new List<ServiceFlagModel>();
                for (int i = 0; i < name.Count; i++)
                {
                    ServiceFlagModel s = new ServiceFlagModel();
                    s.ServiceCode = name[i];
                    ServiceFlags.Add(s);

                }


                req.Constraints.ServiceFlags = ServiceFlags;
            }

            // req.Constraints.ServiceFlags = acc;

            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now.AddDays(3),
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
                FreightClass = freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);

            req.Items = lstItemmodel;
            List<RateResultCarrierViewModel> rateResultCarrierList = null;
            string errorMessage = null;
            rateResultCarrierList = ratesAndCarriers.GetCustomerRateResultsandCarriers(req, userEmail, callProxyApiVersion2, out errorMessage).ToList();

            return rateResultCarrierList;
        }

        public static List<IndividualAccessorialModel> BuildIndividualAccessorialModelFromCostPriceSheet(String CustomerName,
            String Service,
            String pickUpCityName,
            String pickUpZipCode,
            String pickUpStateCode,
            String pickUpCountry,
            String dropUpCityName,
            String dropUpZipCode,
            String dropUpStateCode,
            String dropUpCountry,
            String OAccessorial,
            String DAccessorial,
            String freightClass,
            Double quantity,
            String quantityUnit,
            Double weight,
            String weightUnit,
            string userEmail,
            bool callProxyApiVersion2)
        {

            bool iSCrmRatingLogic_GainshareCustomer = DBHelper.CheckNewCrmRatingLogic(CustomerName);

            IUnityContainer container = new UnityContainer();
            UnityConfiguration unityConfiguration = new UnityConfiguration();
            container = unityConfiguration.Initialize();
            IRatesAndCarriers ratesAndCarriers = container.Resolve<RatesAndCarriers>();

            // string CustomerName = "ZZZ Sandbox DLS Worldwide";
            RateRequestViewModel req = new RateRequestViewModel();
            RateItemModel item = new RateItemModel();
            if (iSCrmRatingLogic_GainshareCustomer)
            {

                req.RatingLevel = CustomerName;
            }

            req.Constraints = new RateConstraintsModel();

            string acc = null;
            if (DAccessorial == null || DAccessorial == "" && OAccessorial != null || OAccessorial == string.Empty)
            {
                acc = OAccessorial;
            }
            else if (OAccessorial == null || OAccessorial == "" && DAccessorial != null || DAccessorial == string.Empty)
            {
                acc = DAccessorial;
            }
            else
            {
                acc = OAccessorial + "," + DAccessorial;
            }

            List<string> name = new List<string>();
            string[] sp = acc.Split(',');
            foreach (var r in sp)
            {
                if (r.Contains("OVL"))
                {
                    name.Add(r);
                }
                else
                {
                    AccessorialSetUp getacc_code = DBHelper.AccessorialName_to_Acc_Code(r);
                    string u = getacc_code.AccessorialCode;
                    name.Add(u);
                }

            }



            List<ServiceFlagModel> ServiceFlags = new List<ServiceFlagModel>();
            for (int i = 0; i < name.Count; i++)
            {

                ServiceFlagModel s = new ServiceFlagModel();
                s.ServiceCode = name[i];
                ServiceFlags.Add(s);

            }


            req.Constraints.ServiceFlags = ServiceFlags;



            req.Constraints.Mode = Service;


            RateEventModel Drop = new RateEventModel()
            {
                City = dropUpCityName,
                Country = dropUpCountry,
                Date = DateTime.Now.AddDays(3),
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
                FreightClass = freightClass,
                Quantity = quantity,
                Weight = weight,
                WeightUnits = weightUnit,
                QuantityUnits = quantityUnit
            };
            List<RateItemModel> lstItemmodel = new List<RateItemModel>();
            lstItemmodel.Add(itemmodel);

            req.Items = lstItemmodel;
            List<IndividualAccessorialModel> individualAccessorialsList = null;
            string errorMessage = null;
            individualAccessorialsList = ratesAndCarriers.
                GetIndivudualAccessorialsCostPricesheet(req, userEmail,
                callProxyApiVersion2, out errorMessage).ToList();


            return individualAccessorialsList;

        }
    }
}
