using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    public class BaseMarkupBreakDownCalcuation : AddShipments
    {
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        List<IndividualAccessorialModel> rlist = null;
        List<decimal> BOIFACC_Output = null;
        List<IndividualAccessorialModel> accessorialModelByCarrier = null;
        CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps BMAAMethod = null;

        public List<decimal> BOIFACC_Calculate(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string
            OAccessorial, string DAccessorial, string Classification, Double Quantity, string QuantityUNIT, Double Weight, string WeightUnit, string Username, string UserType)
        {
            string firstCarrier = "Fedex LTL Priority";

            //if (UserType == "External")
            //{
            //    UICarrier = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div");
            //}
            //else
            //{
            //    UICarrier = Gettext(attributeName_xpath, "");
            //}

            for (int j = 0; j < rlist.Count; j++)
            {
                if (rlist[j].carrierName == firstCarrier)
                {
                    InsuredRateCarrier f = DBHelper.insuredCarrier(firstCarrier);
                    string SCACs = f.CarrierCode;

                    InsuredRateCarrier scacCodeCarrier = DBHelper.insuredCarrier(firstCarrier);
                    //vasanth code
                    string carrierScacCode = scacCodeCarrier.CarrierCode;

                    string acc = null;
                    if (DAccessorial == null)
                    {
                        acc = OAccessorial;
                    }
                    else if (OAccessorial == null)
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
                        string u = DBHelper.AccessorialName_to_Code(r);
                        name.Add(u);
                    }

                    foreach (var r in sp)
                    {

                        List<IndividualAccessorialModel> accessorialModelByCarrier = null;
                        accessorialModelByCarrier = DBHelper.CarrierAcc(CustomerName, SCACs);
                        decimal? BOIFACC = accessorialModelByCarrier?.Where(a => a.AccessorialCode == r).Select(a => a?.AccessorialValue).FirstOrDefault();
                        if (BOIFACC == null)
                        {
                            accessorialModelByCarrier = DBHelper.CustAccessor(CustomerName);
                            BOIFACC = accessorialModelByCarrier?.Where(a => a.AccessorialCode == r).Select(a => a?.AccessorialValue).FirstOrDefault();

                            if (BOIFACC == null)
                            {
                                if (r == "COD")
                                {
                                    string Dname = rlist[j].discription;
                                    if (Dname.Contains(r))
                                    {
                                        string assoccorialsAmount = rlist[j].amount;
                                        decimal assoccorialsAmountD = Decimal.Parse(assoccorialsAmount);
                                        //BOIACC+= //XML read 
                                        BOIFACC_Output.Add(assoccorialsAmountD);
                                    }
                                }
                                if (r == "APPT")
                                {
                                    string z = "Appointment";
                                    string Dname = rlist[j].discription;
                                    if (Dname.Contains(z))
                                    {
                                        string assoccorialsAmount = rlist[j].amount;
                                        decimal assoccorialsAmountD = Decimal.Parse(assoccorialsAmount);
                                        //BOIACC+= //XML read 
                                        BOIFACC_Output.Add(assoccorialsAmountD);
                                    }
                                }

                                else
                                {
                                    BOIFACC_Output.Add((decimal)BOIFACC);
                                }
                            }
                            else
                            {
                                BOIFACC_Output.Add((decimal)BOIFACC);
                            }
                        }
                        break;
                    }

                }
            }
            return BOIFACC_Output;
        }


        public decimal calculateBaseMarkDownCharges(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, Double Quantity, string QuantityUNIT, Double Weight, string Mode, string Username, string UserType, string calculationType)
        {
            string WeightUnit = "lbs";
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName,
                Service, 
                OriginCity,
                OriginZip,
                OriginState,
                OriginCountry, 
                DestinationCity, 
                DestinationZip, 
                DestinationState, 
                DestinationCountry,
                OAccessorial, 
                DAccessorial, 
                Classification, 
                Quantity, 
                QuantityUNIT, 
                Weight, 
                WeightUnit, 
                Username, false);


            decimal MACC = 0; //Db call
            decimal IACC = 0;



            string firstCarrier = null; 
            if (UserType == "External" && Mode == "Quote")
            {
                firstCarrier = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[1]/ul/li[1]");
            }
            else if (UserType == "Internal" && Mode == "Quote")
            {
                firstCarrier = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[1]/ul/li[1]");
            }

            if (UserType == "External" && Mode == "Shipment")
            {
                firstCarrier = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div[1]");
            }
            else if (UserType == "Internal" && Mode == "Shipment")
            {
                firstCarrier = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[1]/div/div[1]");
            }


            decimal BMAA = 0;
            


            int carriercount = 0;//2

            
            for (int j = 0; j < rlist.Count; j++)
            {

                if (rlist[j].carrierName == firstCarrier)//XPO
                {
                    carriercount += 1;
                }
            }

            int CODPresent_XML = 0;
            string CARSCAC_COde = null;//CNWY


            for (int i = 0; i < rlist.Count; i++)
            {

                if (rlist[i].carrierName == firstCarrier)//XPO
                {
                    // for (int i = 0; i < carriercount; i++)//2
                    // {
                    //if (calculationType == "BOLH" || calculationType == "BOFSC" || calculationType == "BOTTL")
                    //{


                    //BMAAMethod = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();

                    //BMAA = BMAAMethod.ThenBMAAShouldBeCalculated(Mode, CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, OAccessorial, DAccessorial);

                    //}

                    string individualAccAmountDiscription = rlist[i].discription;

                    if (individualAccAmountDiscription.Contains("COD"))
                    {
                        string amount = rlist[i].amount;
                        IACC = Decimal.Parse(amount);
                        CODPresent_XML += 1;
                        CARSCAC_COde = rlist[i].CarrierScac;
                    }
                    CARSCAC_COde = rlist[i].CarrierScac;
                }
            }



            //MACC value from Carrier
            if (CARSCAC_COde != null)
            {
                //carrierScacCode = scacCodeCarrier.CarrierCode;
                int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
                int accId = DBHelper.GetCustomerAccountId(setUpId);
                CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
                custValues = DBHelper.GetGainsharePricingDataByAID(accId);

                int pricingmodelid = custValues.GainsharePricingModelId;
                //GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, carrierScacCode);
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
                //CustomerName = "gainsharetestswa1";
                int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
                int accId = DBHelper.GetCustomerAccountId(setUpId);

                // //customer based values from DB
                CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
                custValues = DBHelper.GetGainsharePricingDataByAID(accId);

                int pricingmodelid = custValues.GainsharePricingModelId;
                MACC = custValues.MasterAccessorialCharge;


            }



            decimal AACC = 0;//API call 
            decimal BOLH = 0;
            decimal calculatedValue = 0;

            BMAAMethod = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();

            BMAA = BMAAMethod.ThenBMAAShouldBeCalculated(Mode, CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, OAccessorial, DAccessorial);
//186.20//177.62


            //Accessorial call from Carrier and Customer for COD

            for (int i = 0; i < rlist.Count; i++)
            {
                if (rlist[i].carrierName == firstCarrier)
                {
                    AACC = Decimal.Parse(rlist[i].accessorialsTotal);

                    if (calculationType == "BOLH")
                    {
                        string dis = rlist[i].discription;

                        if (dis.Contains("Fuel"))
                        {
                            string amount = rlist[i].amount;
                            decimal FSCAmount = Decimal.Parse(amount);
                            calculatedValue = ratingCalculation.BOLH_BaseMarkupMinimumAmount(BMAA, AACC, MACC, FSCAmount);//136.61
                            break;
                        }
                    }
                    if (calculationType == "BOFSC")
                    {
                        string dis = rlist[i].discription;

                        if (dis.Contains("Fuel"))
                        {
                            CalculateBreakoutLinehaulBOLH_QuoteSteps _BOLH = new CalculateBreakoutLinehaulBOLH_QuoteSteps();
                            _7_Calculate_Breakout_Linehaul__BOLH__steps _BolhShipment = new _7_Calculate_Breakout_Linehaul__BOLH__steps();
                            string amount = rlist[i].amount;
                            decimal FSCAmount = Decimal.Parse(amount);
                            if (Mode == "Quote")
                            {
                                BOLH = _BOLH.ThenBOLHCanBeCalculatedAndVerifiedInTheRateResultsPage(CustomerName, Username, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, UserType, "BOLH");
                                calculatedValue = ratingCalculation.BOFSC_BaseMarkupMinimumAmount(BOLH, FSCAmount);
                            }

                            if (Mode == "Shipment")
                            {
                                BOLH = _BolhShipment.ThenBOLHCanBeCalculatedAndVerifiedInTheShpResultsPage(CustomerName, Username, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, UserType, "BOLH");
                                calculatedValue = ratingCalculation.BOFSC_BaseMarkupMinimumAmount(BOLH, FSCAmount);
                            }
                            break;
                        }

                    }
                    if (calculationType == "BOTTL")//taken care in separate class
                    {
                        CalculateBreakoutTotalBOTTL_QuoteSteps gg = new CalculateBreakoutTotalBOTTL_QuoteSteps();
                        CalculateBreakoutTotalBOTTL_ShipmentSteps BOTTL_Shipment = new CalculateBreakoutTotalBOTTL_ShipmentSteps();
                        if (Mode == "Quote")
                        {
                            calculatedValue = gg.ThenBOTTLCanBeCalculatedAndVerifiedInTheRateResultsPage(CustomerName, Username, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, UserType, "BOTTL");
                        }
                        if (Mode == "Shipment")
                        {
                            calculatedValue = BOTTL_Shipment.ThenBOTTLCanBeCalculatedAndVerifiedInTheShipmentResultsPage(CustomerName, Username, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, UserType, "BOTTL");
                        }
                        break;
                    }

                    if (calculationType == "BOIACC")
                    {
                        calculatedValue = ratingCalculation.BOIACC_BaseMakupupIndividualAccessorial(MACC, IACC);
                        break;
                    }

                    if (calculationType == "BOIFACC")
                    {
                        CalculateBreakoutIndividualFinalAccessorialsBOIFACC_QuoteSteps _BoiFACC = new CalculateBreakoutIndividualFinalAccessorialsBOIFACC_QuoteSteps();
                        calculatedValue = _BoiFACC.BIOFACC_Calculations(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry,
                                                      OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, "BOIFACC");
                        break;
                        //calculatedValue = BOIFACC_Out[i];
                    }

                    if (calculationType == "BOTFACC")
                    {
                        CalculateBreakoutIndividualFinalAccessorialsBOIFACC_QuoteSteps _BioFACC = new CalculateBreakoutIndividualFinalAccessorialsBOIFACC_QuoteSteps();
                        decimal BIOFACC_Calc = _BioFACC.BIOFACC_Calculations(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry,
                                                      OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, "BOTFACC");

                        calculatedValue = BIOFACC_Calc;
                        break;
                    }
                }
            }
            return calculatedValue;
        }

    }
}



