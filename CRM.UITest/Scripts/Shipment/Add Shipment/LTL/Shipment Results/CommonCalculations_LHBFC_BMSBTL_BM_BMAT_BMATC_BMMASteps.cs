using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.CommonMethods;
using System.Threading;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps : AddShipments
    {
        List<IndividualAccessorialModel> rlist = null;
       
        public decimal min,gs;

        //CommonMethodsCrm crm = new CommonMethodsCrm();
        AddQuoteLTL ltl = new AddQuoteLTL();

        [When(@"I enter all valid required data on the Get Quote LTL page (.*) , (.*), (.*), (.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*)")]
        public void WhenIEnterAllValidRequiredDataOnTheGetQuoteLTLPage(string userType, string CustomerAccName, string OriginZip, string originAccessorials, string DestinationZip, string destinationAccessorials, string Classification, string Quantity, string QuantityUNIT, string Weight, string WeightUnit)
        {
            ltl.NaviagteToQuoteList();
            ltl.Add_QuoteLTL(userType, CustomerAccName);
            try
            {
                Thread.Sleep(10000);
                Click(attributeName_id, ClearAddress_OriginId);

            }
            catch (Exception)
            {
                Thread.Sleep(50000);
                Console.WriteLine("error occurred");
            }

            ltl.EnterOriginZip(OriginZip);

            Click(attributeName_id, ClearAddress_DestId);
            ltl.EnterDestinationZip(DestinationZip);            
            
            ltl.selectShippingfromServices(originAccessorials);
            ltl.selectShippingToServices(destinationAccessorials);
            
            Click(attributeName_id, LTL_ClearItem_Id);
            ltl.EnterItemdata(Classification, Weight);
            SendKeys(attributeName_id, "quantity-0", "6");
        }

        [Then(@"BMAA should be calculated (.*), (.*), (.*) ,(.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*),(.*),(.*), (.*), (.*),(.*),(.*),(.*),(.*)")]
        public decimal ThenBMAAShouldBeCalculated(string userType, string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string Classification, double Quantity, string QuantityUNIT, double Weight, string WeightUnit, string Username, string originAccessorials, string destinationAccessorials)
        {

            RatingCalculationMethods cal = new RatingCalculationMethods();
            decimal BMAA = 0;
            string firstCarrier = null;


            if (userType == "Quote")
            {
                firstCarrier = Gettext(attributeName_xpath, ltlCarrierName_xpath);
            }
            else
            {
                firstCarrier = Gettext(attributeName_xpath, ShipResults_FC_CarrierName_Xpath);
            }

            //InsuredRateCarrier scacCodeCarrier = DBHelper.insuredCarrier("Fedex LTL Priority");
            //string carrierScacCode = scacCodeCarrier.CarrierCode;

            int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
            int accId = DBHelper.GetCustomerAccountId(setUpId);


            CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
            custValues = DBHelper.GetGainsharePricingDataByAID(accId);

            int pricingmodelid = custValues.GainsharePricingModelId;
            decimal custMin = custValues.Minimum;
            decimal custMinAmt = Convert.ToDecimal(custValues.MinAmountAdded);
            decimal custMinThreshold = Convert.ToDecimal(custValues.MinThresholdCharge);
            decimal custGainshare = Convert.ToDecimal(custValues.Percentage);
            decimal custMasterAcc = custValues.MasterAccessorialCharge;
           


            List<IndividualAccessorialModel> apirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName, 
                Service, 
                OriginCity,
                OriginZip,
                OriginState,
                OriginCountry,
                DestinationCity, 
                DestinationZip,
                DestinationState, 
                DestinationCountry, 
                originAccessorials,
                destinationAccessorials,
                Classification,
                Quantity,
                QuantityUNIT, 
                Weight,
                WeightUnit,
                Username,
                false);
            List<string> carrierNames = apirespone.Select(p => p.carrierName).ToList();
            
            Thread.Sleep(1000);
            for (int i = 0; i < carrierNames.Count; i++)
            {
                if (apirespone[i].carrierName == firstCarrier && apirespone[i].chargeType.Equals("ACCESSORIAL_FUEL"))
                {
                    string type = apirespone[i].chargeType;
                    string linehaul = apirespone[i].TotalLineHaul;
                    decimal lh = Decimal.Parse(linehaul);
                    decimal fuelSurcharge = Convert.ToDecimal(apirespone[i].amount);
                    bool accType = apirespone[i].IsAccessorial;
                    decimal totalAccessorial = Convert.ToDecimal(apirespone[i].accessorialsTotal);
                    decimal totalCost = Convert.ToDecimal(apirespone[i].TotalCost);
                    string scaccode = apirespone[i].CarrierScac;
                    GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, scaccode);

                    
                    {
                        if (carrierValues != null)
                        {
                            decimal carrierMin = carrierValues.Minimum;
                            decimal carrierMinAmt = Convert.ToDecimal(carrierValues.CarrierSpecificMinimumAmount);
                            decimal carrierMinThreshold = Convert.ToDecimal(carrierValues.CarrierSpecificMinimumThreshold);
                            decimal carrierGainshare = Convert.ToDecimal(carrierValues.GainsharePercentage);
                            double cgs = Convert.ToDouble(carrierValues.GainsharePercentage);
                            decimal carrierMasterAcc = carrierValues.MasterAccessorialCharge;

                            decimal LHBFSC = cal.LHBFSC_LinehaulBeforeFuelSurcharge(type, carrierMin, carrierGainshare, lh);
                            decimal BMSBTL = cal.BMSBTL_BaseMarkupSubTotal(fuelSurcharge, LHBFSC);
                            decimal BM = cal.BM_BaseMarkup(accType, BMSBTL, totalAccessorial, carrierMasterAcc);
                            decimal BMAT = cal.BMAT_BaseMarkupAfterThreshold(BM, carrierMinThreshold);
                            decimal BMATC = cal.BMATC_BaseMarkupAfterThresholdCalculation(BMAT, totalCost);
                            BMAA = cal.BMAA_BaseMarkupMinimumAmount(BMATC, BMAT, totalCost, carrierMinAmt);

                        }
                        else
                        {

                            decimal LHBFSC= cal.LHBFSC_LinehaulBeforeFuelSurcharge(type, custMin, custGainshare, lh);
                            decimal BMSBTL = cal.BMSBTL_BaseMarkupSubTotal(fuelSurcharge, LHBFSC);
                            decimal BM = cal.BM_BaseMarkup(accType, BMSBTL, totalAccessorial, custMasterAcc);
                            decimal BMAT = cal.BMAT_BaseMarkupAfterThreshold(BM, custMinThreshold);
                            decimal BMATC = cal.BMATC_BaseMarkupAfterThresholdCalculation(BMAT, totalCost);
                            BMAA = cal.BMAA_BaseMarkupMinimumAmount(BMATC, BMAT, totalCost, custMinAmt);
                        }


                    }
                    break;
                }
                
            }


            return BMAA;
           
        }





    }


}

