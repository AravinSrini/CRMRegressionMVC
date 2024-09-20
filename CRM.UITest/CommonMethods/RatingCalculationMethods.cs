using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.CommonMethods
{
    [Binding]
    public class RatingCalculationMethods
    {
           /*

            MIN = MinimumAmount
            GS = Gainshare
            AACC = Total Accessorials
            MACC = Master Accessorials
            MT = Minimum Threshold

          */

 


        public decimal LHBFSC_LinehaulBeforeFuelSurcharge(string type, decimal MIN, decimal GS, decimal Linehaul)
        {
            
            decimal LHBFSC;
            if (type == "MG_MINMAX_ADJ")
            {
                decimal minvalue = (MIN / 100);
                LHBFSC = Linehaul * (1 + minvalue);
            }
            else
            {
                decimal gsValue = (GS / 100);
                LHBFSC = Linehaul * (1 + gsValue);
            }

            return LHBFSC;


        }

        public decimal BMSBTL_BaseMarkupSubTotal(decimal FuelSurchargeRate, decimal LHBFSC)
        {
            
            decimal BMSBTL;
            BMSBTL = LHBFSC * (1 + (FuelSurchargeRate/100)); //FuelSurchargeRate from API response

            return BMSBTL;
        }


        public decimal BM_BaseMarkup(bool type, decimal BMSBTL, decimal AACC, decimal MACC)
        {
            decimal BM;
            if (type==true)   //Accessorials from API response
            {
                BM = BMSBTL + AACC * (1 + (MACC/100));  //MACC required from DB
            }
            else
            {
                BM = BMSBTL;
            }
            return BM;

        }


        public decimal BMAT_BaseMarkupAfterThreshold(decimal BM, decimal MT)
        {
            decimal BMAT;
            if (BM < MT)
            {
                BMAT = MT;  //MT from DB
            }
            else
            {
                BMAT = BM;
            }
            return BMAT;

        }


        public decimal BMATC_BaseMarkupAfterThresholdCalculation(decimal BMAT, decimal TotalCost)
        {
            decimal BMATC;

            BMATC = BMAT - TotalCost;
            return BMATC;


        }




        public decimal BMAA_BaseMarkupMinimumAmount(decimal BMATC, decimal BMAT, decimal TotalCost, decimal MA)
        {
            decimal BMAA;
            if (BMATC < MA)
            {
                BMAA = TotalCost + MA;
            }
            else
            {
                BMAA = BMAT;
            }


            return BMAA;
        }

        public decimal BFSC_BumpFuelSurcharge(decimal BOFSC, decimal Bump)
        {
            decimal BFSC = 0;
                
            if(Bump >0)
            {
                BFSC = BOFSC * (1 + Bump);
            }
            return BFSC;
        }

        public decimal BTTL_BumpTotal(decimal BLH, decimal BFSC, decimal BOTFACC)
        {
            decimal BTTL = BLH + BFSC + BOTFACC;
            return BTTL;
        }

        public decimal SLH_SurgeLineHaul(decimal surge, decimal bump, decimal BOLH, decimal BOTFACC, decimal BLH)
        {
            decimal SLH = 0;
            if (surge > 0 && bump == 0)
            {
                SLH = (BOLH * (1 + surge)) + (BOTFACC * surge);
            }
            else if (surge > 0)
            {
                SLH = (BLH * (1 + surge)) + (BOTFACC * surge);
            }
            return SLH;
        }

        public decimal SFSC_SurgeFuelSurcharge(decimal BOFSC, decimal surge, decimal bump, decimal BFSC)
        {
            decimal SFSC = 0;
            if (surge > 0 && bump == 0)
            {
                SFSC = BOFSC * (1 + surge);
            }
            else if (surge > 0)
            {
                SFSC = BFSC * (1 + surge);
            }
            return SFSC;
        }

        public decimal STTL_SurgeTotal(decimal SLH, decimal SFSC, decimal BOTFACC)
        {
            decimal STTL = SLH + SFSC + BOTFACC;
            return STTL;
        }

        public decimal BLH_BumpLinehaul(decimal BOLH, decimal BOTFACC, decimal bump, decimal surge)
        {
            decimal BLH = 0;
            if(bump > 0 && surge == 0)
            {
                BLH = (BOLH * (1 + bump)) + (BOTFACC * bump);
            }
            return BLH;
        }


        //---------------------- BOLH=Break Out LeneHaul
        public decimal BOLH_BaseMarkupMinimumAmount(decimal BMAA, decimal AACC, decimal MACC, decimal FSC)
        {
            decimal BOLH = 0;
            try
            {
                BOLH = (BMAA - (AACC * (1 + (MACC/100)))) / (1 + (FSC/100));
            }
            catch (DivideByZeroException e)
            {
                Report.WriteLine("Division of {0} by zero." + e);
                
            }
            return BOLH;
        }

        //-------------  BOFSC Break Out Fuel 
        public decimal BOFSC_BaseMarkupMinimumAmount(decimal BOLH, decimal FSC)
        {
            decimal BOFSC = 0;
            try
            {
                BOFSC = (BOLH * (FSC/100));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred" + e);
            }
            return BOFSC;
        }

        //--------------------  BOTTL= Break Out Total
        public decimal BOTTL_BaseMarkupMinimumAmount(decimal BOLH, decimal BOFSC, decimal BOTFACC)
        {
            decimal BOTTL = 0;
            try
            {
                BOTTL = (BOLH + BOFSC + BOTFACC);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred" + e);
            }
            return BOTTL;
        }

        //--------------------  BOIACC= Break Out Individual Accessorials
        public decimal BOIACC_BaseMakupupIndividualAccessorial(decimal MACC, decimal IACC)
        {
            decimal BOIACC = 0;
            try
            {
                BOIACC = IACC * (1 + (MACC/100));
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occurred" + e);
            }
            return BOIACC;
        }

        ////--------------------  BOIFACC= Breakout Individual Final Accessorials
        //public decimal BOIFACCBaseMakupupIndividualFinalAccessorials()
        //{
        //    decimal BOIFACC = 0;
        //    try
        //    {
        //        BOIFACC = IACC * (1 + MACC);
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine("Exception occurred" + e);
        //    }
        //    return BOIFACC;
        //}



    }
}
