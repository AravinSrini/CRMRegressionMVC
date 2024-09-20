using System;
using System.Collections.Generic;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Objects;
using System.Threading;
using Rrd.SpecflowSelenium.Service.GenericService;

namespace CRM.UITest.CommonMethods
{
    public class CRMRatingCalculations : ObjectRepository
    {
        List<IndividualAccessorialModel> accessorialapirespone = new List<IndividualAccessorialModel>();
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        List<IndividualAccessorialModel> accessorialModelByCarrier = null;        
        decimal MACC;
        decimal AACC;
        decimal BOLH;
        decimal BMAA;
        decimal BOFSC;
        decimal BOIFACC;
        decimal IACC_Override;
        string weightUnit = "LBS";


        public decimal GetMACC(string customerName, string service, string originCity, string originZip, string originState,
            string originCountry, string destinationCity, string destinationZip, string destinationState, string destinationCountry, string oAccessorial, string dAccessorial,
            string classification, Double quantity, string quantityUNIT, Double weight, string username, string carrierName)
        {

            int CODPresent_XML = 0;
            string CARSCAC_COde = null;//CNWY

            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == carrierName)//XPO
                {
                    string individualAccAmountDiscription = accessorialapirespone[i].chargeType;

                    if (individualAccAmountDiscription.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == carrierName)
                    {
                        CODPresent_XML += 1;
                        CARSCAC_COde = accessorialapirespone[i].CarrierScac;
                    }

                }
            }

            //MACC value from Carrier
            if (CARSCAC_COde != null)
            {
                int setUpId = DBHelper.GetCustomerSetupId(customerName);
                int accId = DBHelper.GetCustomerAccountId(setUpId);
                CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
                custValues = DBHelper.GetGainsharePricingDataByAID(accId);

                int pricingmodelid = custValues.GainsharePricingModelId;
                GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, CARSCAC_COde);

                if (carrierValues == null)
                {
                    MACC = custValues.MasterAccessorialCharge;
                }
                else
                {
                    //Taking MACC value from carrier table
                    MACC = carrierValues.MasterAccessorialCharge;
                }

            }
            else
            {
                //MACC value from Customer                
                int setUpId = DBHelper.GetCustomerSetupId(customerName);
                int accId = DBHelper.GetCustomerAccountId(setUpId);

                //customer based values from DB
                CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
                custValues = DBHelper.GetGainsharePricingDataByAID(accId);

                int pricingmodelid = custValues.GainsharePricingModelId;
                MACC = custValues.MasterAccessorialCharge;
            }

            return MACC;
        }
        public decimal GetBOLH(string carrierName)
        {
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == carrierName)
                {
                    AACC = Decimal.Parse(accessorialapirespone[i].accessorialsTotal);//adding accessorial                    


                    string dis = accessorialapirespone[i].discription;

                    if (dis.Contains("Fuel"))
                    {
                        string amount = accessorialapirespone[i].amount;
                        decimal FSCAmount = Decimal.Parse(amount);
                        BOLH = ratingCalculation.BOLH_BaseMarkupMinimumAmount(BMAA, AACC, MACC, FSCAmount);
                    }

                }
            }

            return BOLH;
        }
        public decimal GetBOFSC(string carrierName)
        {
            //decimal bOLH = GetBOLH(guaranteedCarrierName, guaranteedAccessorial);
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == carrierName)
                {
                    string dis = accessorialapirespone[i].discription;

                    if (dis.Contains("Fuel"))
                    {

                        string amount = accessorialapirespone[i].amount;
                        decimal FSCAmount = Decimal.Parse(amount);
                        BOFSC = ratingCalculation.BOFSC_BaseMarkupMinimumAmount(BOLH, FSCAmount);
                    }

                }
            }

            return BOFSC;
        }
        public decimal GetBOTFACC(string customerName, string standardCarrierName)
        {
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == standardCarrierName)
                {
                    int CODPresent_XML = 0;
                    string CARSCAC_COdeB = null;

                    string individualAccAmountDiscription = accessorialapirespone[i].chargeType;

                    if (individualAccAmountDiscription.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == standardCarrierName)
                    {

                        CODPresent_XML += 1;
                        CARSCAC_COdeB = accessorialapirespone[i].CarrierScac;
                    }

                    AccessorialSetUp GettheAssCode = null;

                    string CARSCAC = CARSCAC_COdeB;

                    accessorialModelByCarrier = DBHelper.CarrierAcc(customerName, CARSCAC);


                    if (accessorialapirespone[i].chargeType.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == standardCarrierName)
                    {
                        GettheAssCode = DBHelper.AccessorialNameToCodeUsingMgDescription(accessorialapirespone[i].discription);

                        decimal? IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == (GettheAssCode.AccessorialCode))?.Select(a => a?.AccessorialValue).FirstOrDefault();

                        if (IACC1 == null)
                        {
                            accessorialModelByCarrier = DBHelper.CustAccessor(customerName);
                            IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == GettheAssCode.AccessorialCode)?.Select(a => a?.AccessorialValue).FirstOrDefault();

                            if (IACC1 == null)
                            {
                                if (individualAccAmountDiscription.Equals("ACCESSORIAL"))
                                {
                                    string amount = accessorialapirespone[i].amount;
                                    IACC_Override = Decimal.Parse(amount);
                                    BOIFACC += IACC_Override * (1 + (MACC / 100));
                                }
                            }
                            else
                            {
                                BOIFACC += (decimal)IACC1;
                            }
                        }
                        else
                        {
                            BOIFACC += (decimal)IACC1;
                        }
                    }
                }

            }

            return BOIFACC;
        }

        public decimal GetBOTFACCWithMGDescription(string customerName, string standardCarrierName)
        {
            BOIFACC = 0;
            for (int i = 0; i < accessorialapirespone.Count; i++)
            {
                if (accessorialapirespone[i].carrierName == standardCarrierName)
                {
                    int CODPresent_XML = 0;
                    string CARSCAC_COdeB = null;

                    string individualAccAmountDiscription = accessorialapirespone[i].chargeType;
                    string individualDescription = accessorialapirespone[i].discription;
                    if (individualAccAmountDiscription.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == standardCarrierName)
                    {
                        CODPresent_XML += 1;
                        CARSCAC_COdeB = accessorialapirespone[i].CarrierScac;
                    }

                    AccessorialSetUp GettheAssCode = null;

                    string CARSCAC = CARSCAC_COdeB;

                    accessorialModelByCarrier = DBHelper.CarrierAcc(customerName, CARSCAC);


                    if (accessorialapirespone[i].chargeType.Equals("ACCESSORIAL") && accessorialapirespone[i].carrierName == standardCarrierName)
                    {
                        GettheAssCode = DBHelper.AccessorialNameToCodeUsingMgDescription(individualDescription);

                        decimal? IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == (GettheAssCode.AccessorialCode))?.Select(a => a?.AccessorialValue).FirstOrDefault();

                        if (IACC1 == null)
                        {
                            accessorialModelByCarrier = DBHelper.CustAccessor(customerName);
                            IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == GettheAssCode.AccessorialCode)?.Select(a => a?.AccessorialValue).FirstOrDefault();

                            if (IACC1 == null)
                            {
                                if (individualAccAmountDiscription.Equals("ACCESSORIAL"))
                                {
                                    string amount = accessorialapirespone[i].amount;
                                    IACC_Override = Decimal.Parse(amount);
                                    BOIFACC += IACC_Override * (1 + (MACC / 100));                                    
                                }
                            }
                            else
                            {
                                BOIFACC += (decimal)IACC1;
                            }
                        }
                        else
                        {
                            BOIFACC += (decimal)IACC1;
                        }
                    }
                }

            }

            return BOIFACC;
        }

        public decimal GetBMAA(string mode, string customerName, string service, string originCity, string originZip, string originState,
            string originCountry, string destinationCity, string destinationZip, string destinationState, string destinationCountry, string oAccessorial, string dAccessorial,
            string classification, Double quantity, string quantityUNIT, Double weight, string username, string carrierName)
        {

            RatingCalculationMethods cal = new RatingCalculationMethods();
            int setUpId = DBHelper.GetCustomerSetupId(customerName);
            int accId = DBHelper.GetCustomerAccountId(setUpId);


            CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
            custValues = DBHelper.GetGainsharePricingDataByAID(accId);

            int pricingmodelid = custValues.GainsharePricingModelId;
            decimal custMin = custValues.Minimum;
            decimal custMinAmt = Convert.ToDecimal(custValues.MinAmountAdded);
            decimal custMinThreshold = Convert.ToDecimal(custValues.MinThresholdCharge);
            decimal custGainshare = Convert.ToDecimal(custValues.Percentage);
            decimal custMasterAcc = custValues.MasterAccessorialCharge;

            accessorialapirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerName,
            service, originCity, originZip, originState, originCountry, destinationCity, destinationZip, destinationState,
            destinationCountry, oAccessorial, dAccessorial, classification, quantity, quantityUNIT, weight, weightUnit, username, false);

            List<string> carrierNames = accessorialapirespone.Select(p => p.carrierName).ToList();

            Thread.Sleep(1000);
            
            for (int i = 0; i < carrierNames.Count; i++)
            {
                bool isMin = accessorialapirespone.Where(x => x.carrierName == carrierName && x.chargeType == "MG_MINMAX_ADJ").Any();
                if (accessorialapirespone[i].carrierName == carrierName && accessorialapirespone[i].chargeType.Equals("ACCESSORIAL_FUEL"))
                {
                    string type = isMin ? "MG_MINMAX_ADJ" : accessorialapirespone[i].chargeType;
                    string linehaul = accessorialapirespone[i].TotalLineHaul;
                    decimal lh = Decimal.Parse(linehaul);
                    decimal fuelSurcharge = Convert.ToDecimal(accessorialapirespone[i].amount);
                    bool accType = accessorialapirespone[i].IsAccessorial;
                    decimal totalAccessorial = Convert.ToDecimal(accessorialapirespone[i].accessorialsTotal);
                    decimal totalCost = Convert.ToDecimal(accessorialapirespone[i].TotalCost);
                    string scaccode = accessorialapirespone[i].CarrierScac;
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

                            decimal LHBFSC = cal.LHBFSC_LinehaulBeforeFuelSurcharge(type, custMin, custGainshare, lh);//126.8125 //510.00
                            decimal BMSBTL = cal.BMSBTL_BaseMarkupSubTotal(fuelSurcharge, LHBFSC);//154.077 //619.65
                            decimal BM = cal.BM_BaseMarkup(accType, BMSBTL, totalAccessorial, custMasterAcc);//179.077 //644.65
                            decimal BMAT = cal.BMAT_BaseMarkupAfterThreshold(BM, custMinThreshold);//179.077 //644.65
                            decimal BMATC = cal.BMATC_BaseMarkupAfterThresholdCalculation(BMAT, totalCost);//31.077 //123.93
                            BMAA = cal.BMAA_BaseMarkupMinimumAmount(BMATC, BMAT, totalCost, custMinAmt);//31.077 //644.65
                        }


                    }
                    break;
                }

            }

            return BMAA;
        }
    }
}
