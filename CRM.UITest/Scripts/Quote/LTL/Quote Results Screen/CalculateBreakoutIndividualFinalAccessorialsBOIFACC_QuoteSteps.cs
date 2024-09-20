using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class CalculateBreakoutIndividualFinalAccessorialsBOIFACC_QuoteSteps : ObjectRepository
    {

        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        //List<RateResultCarrierViewModel> rlist = null;
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;
        List<IndividualAccessorialModel> rlist = null;
        List<IndividualAccessorialModel> accessorialModelByCarrier = null;
        //string CustomerName = "ZZZ - CZar Customer Test";
        //string Service = "COD";
        //string OriginCity = "Miami";
        //string OriginZip = "33126";
        //string OriginState = "FL";
        //string OriginCountry = "USA";
        //string DestinationCity = "Tempe";
        //string DestinationZip = "85282";
        //string DestinationState = "AZ";
        //string DestinationCountry = "USA";
        //string OAccessorial = "COD";
        //string DAccessorial = "APPT";
        //string Classification = "50";
        //Double Quantity = 1;
        //string QuantityUNIT = "SKD";
        //Double Weight = 3;
        //string WeightUnit = "lbs";
        //string CalculationType = "BOIFACC";

        public List<decimal> BOIFACC_Calculate(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string
            OAccessorial, string DAccessorial, string Classification, Double Quantity, string QuantityUNIT, Double Weight, string WeightUnit, string Username, string UserType, string CalculationType, string UICarrier)
        {
            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOIACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, UserType, CalculationType);


            List<decimal> BOIFACC_Output = new List<decimal>();


            //for (int j = 0; j < rlist.Count; j++)
            //{
            //    if (rlist[j].carrierName == UICarrier)
            //    {
            //        Report.WriteLine("Calculating SCACS code");
            //        InsuredRateCarrier f = DBHelper.insuredCarrier(UICarrier);
            //        string SCACs = f.CarrierCode;


            //        string acc = null;
            //        if (DAccessorial == null)
            //        {
            //            acc = OAccessorial;
            //        }
            //        else if (OAccessorial == null)
            //        {
            //            acc = DAccessorial;
            //        }
            //        else
            //        {
            //            acc = OAccessorial + "," + DAccessorial;
            //        }

            //        List<string> name = new List<string>();
            //        string[] sp = acc.Split(',');
            //        foreach (var r in sp)
            //        {
            //            string u = DBHelper.AccessorialName_to_Code(r);
            //            name.Add(u);
            //        }

            //        foreach (var x in name)
            //        {

            //            List<IndividualAccessorialModel> accessorialModelByCarrier = null;
            //            accessorialModelByCarrier = DBHelper.CarrierAcc(CustomerName, SCACs);
            //            decimal? BOIFACC = accessorialModelByCarrier?.Where(a => a.AccessorialCode == x).Select(a => a?.AccessorialValue).FirstOrDefault();
            //            if (BOIFACC == null)
            //            {
            //                accessorialModelByCarrier = DBHelper.CustAccessor(CustomerName);
            //                BOIFACC = accessorialModelByCarrier?.Where(a => a.AccessorialCode == x).Select(a => a?.AccessorialValue).FirstOrDefault();

            //                if (BOIFACC == null)
            //                {
            //                    if (x == "COD")
            //                    {

            //                        //BOIACC+= //XML read 
            //                        string Dname = rlist[j].discription;
            //                        if (Dname.Contains(x))
            //                        {
            //                            string assoccorialsAmount = rlist[j].amount;
            //                            BOIFACC = Decimal.Parse(assoccorialsAmount);
            //                            BOIFACC_Output.Add((decimal)BOIFACC);
            //                        }
            //                    }
            //                    if (x == "APPT")
            //                    {
            //                        string z = "Appointemnt";
            //                        string Dname = rlist[j].discription;
            //                        if (Dname.Contains(z))
            //                        {
            //                            string assoccorialsAmount = rlist[j].amount;
            //                            BOIFACC = Decimal.Parse(assoccorialsAmount);
            //                            BOIFACC_Output.Add((decimal)BOIFACC);
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    BOIFACC_Output.Add((decimal)BOIFACC);
            //                }
            //            }
            //            else
            //            {
            //                BOIFACC_Output.Add((decimal)BOIFACC);
            //            }

            //        }
            //        break;
            //    }

            //}

            return BOIFACC_Output;

        }


        public decimal BIOFACC_Calculations(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, Double Quantity, string QuantityUNIT, Double Weight, string Mode, string Username, string UserType, string calculationType)
        {
            string WeightUnit = "lbs";
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry,
                                                      OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, WeightUnit, Username, false);

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



            int carriercount = 0;//2
            for (int j = 0; j < rlist.Count; j++)
            {

                if (rlist[j].carrierName == firstCarrier)//XPO
                {
                    carriercount += 1;
                }
            }

            int CODPresent_XML = 0;
            string CARSCAC_COdeB = null;//CNWY

            for (int i = 0; i < rlist.Count; i++)//2
            {



                //string individualAccAmountDiscription = rlist[i].discription;
                string individualAccAmountDiscription = rlist[i].chargeType;

                if (individualAccAmountDiscription.Equals("ACCESSORIAL") && rlist[i].carrierName == firstCarrier)
                {

                    CODPresent_XML += 1;
                    CARSCAC_COdeB = rlist[i].CarrierScac;
                }
            }



            decimal IACC_Override = 0;
            decimal BOIFACC = 0;

            //InsuredRateCarrier scacCodeCarrier = DBHelper.insuredCarrier(firstCarrier);
            //string _CarrierCode = null;
            //if(scacCodeCarrier != null)
            //{
            //    _CarrierCode = scacCodeCarrier.CarrierCode;
            //}
            //vasanth code

            decimal MACC = 0;
            string carrierSCAC = null;

            int setUpId = DBHelper.GetCustomerSetupId(CustomerName);
            int accId = DBHelper.GetCustomerAccountId(setUpId);
            CRM.UITest.Entities.Proxy.GainsharePricingModel custValues = new CRM.UITest.Entities.Proxy.GainsharePricingModel();
            custValues = DBHelper.GetGainsharePricingDataByAID(accId);

            int pricingmodelid = custValues.GainsharePricingModelId;
            GainShareScacCode carrierValues = DBHelper.GetCarrierSpecificScacCode(pricingmodelid, CARSCAC_COdeB);

            if (carrierValues == null)
            {
                MACC = custValues.MasterAccessorialCharge;
            }
            else
            {

                //Taking MACC value from carrier table
                MACC = carrierValues.MasterAccessorialCharge;
            }


            //getting accessorials code
            // CRM.UITest.Entities.Proxy.CodeTable values = new CRM.UITest.Entities.Proxy.CodeTable();
            AccessorialSetUp GettheAssCode = null;





            for (int i = 0; i < rlist.Count; i++)//2
            {
                //string CARSCAC = rlist[i].CarrierScac;
                string CARSCAC = CARSCAC_COdeB;
                //accessorialModelByCarrier = DBHelper.CarrierAcc(CustomerName, _CarrierCode);
                accessorialModelByCarrier = DBHelper.CarrierAcc(CustomerName, CARSCAC);

                // decimal? IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == "COD")?.Select(a => a?.AccessorialValue).FirstOrDefault();
                //string accCode = null;
                if (rlist[i].chargeType.Equals("ACCESSORIAL") && rlist[i].carrierName == firstCarrier)
                {
                    GettheAssCode = DBHelper.AccessorialNameToCodeUsingMgDescription(rlist[i].discription);
                    //accCode = values.Code;
                    // string j=GettheAssCode.AccessorialCode;

                    decimal? IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == (GettheAssCode.AccessorialCode))?.Select(a => a?.AccessorialValue).FirstOrDefault();

                    if (IACC1 == null)
                    {
                        accessorialModelByCarrier = DBHelper.CustAccessor(CustomerName);
                        // IACC1 = accessorialModelByCarrier?.Where(a => a?.AccessorialCode == "COD")?.Select(a => a?.AccessorialValue).FirstOrDefault();
                        IACC1 = accessorialModelByCarrier?.Where(a => a.AccessorialCode == GettheAssCode.AccessorialCode)?.Select(a => a?.AccessorialValue).FirstOrDefault();

                        if (IACC1 == null)
                        {
                            string individualAccAmountDiscription = rlist[i].chargeType;

                            if (individualAccAmountDiscription.Equals("ACCESSORIAL"))
                            {
                                //RatingCalculationMethods ra = new RatingCalculationMethods();
                                //ra.BOIACC_BaseMakupupIndividualAccessorial()


                                string amount = rlist[i].amount;
                                IACC_Override = Decimal.Parse(amount);
                                BOIFACC = IACC_Override * (1 + (MACC / 100));
                                //break;

                            }
                        }
                        else
                        {
                            BOIFACC += (decimal)IACC1;
                            //break;
                        }

                    }
                    else
                    {
                        BOIFACC += (decimal)IACC1;
                       // break;
                    }


                }
            }

            return BOIFACC;

        }





        [Then(@"BOIFACC can be calculated(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenBOIFACCCanBeCalculated(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
            //string Username = null;
            //if (UserType == "External")
            //{
            //    Username = "zzzext@user.com";
            //}
            //else if (UserType == "Internal")
            //{
            //    Username = "salesmanager@stage.com";
            //}

            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOIFACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
        }



    }
}