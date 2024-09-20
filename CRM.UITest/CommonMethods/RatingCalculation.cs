using System.Collections.Generic;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;

namespace CRM.UITest.CommonMethods
{
    public class RatingCalculation
    {
        decimal BOLH;
        decimal BMAA;
        decimal MACC;
        decimal BOFSC;
        decimal BOTFACC;
        decimal BTTL;
        decimal Total;        
        CRMRatingCalculations ratingCalculations = new CRMRatingCalculations();         
        BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        public decimal CRMRatingLogic(string mode, string customerName, string service, string originCity, string originZip, string originState,
            string originCountry, string destinationCity, string destinationZip, string destinationState, string destinationCountry, string classification,
            double quantity, string quantityUnit, double weight, string weightUnit, string username, string oAccessorial, string dAccessorial, string carrierName, string SCAC)
        {
            //Calling BMAA method
            BMAA = ratingCalculations.GetBMAA(mode, customerName, service, originCity, originZip, originState, originCountry,
                destinationCity, destinationZip, destinationState, destinationCountry, oAccessorial, dAccessorial, classification,
                quantity, quantityUnit, weight, weightUnit, carrierName); //644.65

            //Calling Breakoout method
            MACC = ratingCalculations.GetMACC(customerName, service, originCity, originZip, originState,
                    originCountry, destinationCity, destinationZip, destinationState, destinationCountry, oAccessorial, dAccessorial,
                    classification, quantity, quantityUnit, weight, username, carrierName);

            BOLH = ratingCalculations.GetBOLH(carrierName);
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

            BOFSC = ratingCalculations.GetBOFSC(carrierName);
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

            BOTFACC = ratingCalculations.GetBOTFACC(customerName, carrierName);
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;

            decimal BOTTL = BOLH + BOFSC + BOTFACC;
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;

            //Verifying CRM Rating Logic standard with UI
            decimal standardCRMLogicBOTFACC = BOTFACC;
            decimal standardCRMLogicBOTTL = standardCRMLogicBOTFACC + BOLH + BOFSC;

            //adding bump and surge
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(SCAC, customerName);

            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            if (bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0)
            {
                SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
                FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
                BTTL = finalModel.Total;
                Total = finalModel.Total;
            }
            else
            {
                Total = standardCRMLogicBOTTL;
            }

            return Total;
        }
        public decimal CRMRatingLogicWithMGDescription(string mode, string customerName, string service, string originCity, string originZip, string originState,
            string originCountry, string destinationCity, string destinationZip, string destinationState, string destinationCountry, string classification,
            double quantity, string quantityUnit, double weight, string weightUnit, string username, string oAccessorial, string dAccessorial, string carrierName,string SCAC)
        {
            BOLH = 0;
            BMAA = 0;
            MACC = 0;
            BOFSC = 0;
            BOTFACC = 0;
            BTTL = 0;
            Total = 0;
            //Calling BMAA method
            BMAA = ratingCalculations.GetBMAA(mode, customerName, service, originCity, originZip, originState, originCountry, 
                destinationCity, destinationZip, destinationState, destinationCountry, oAccessorial, dAccessorial,classification, 
                quantity, quantityUnit, weight, weightUnit, carrierName); //644.65

            //Calling Breakoout method
            MACC = ratingCalculations.GetMACC(customerName, service, originCity, originZip, originState,
                    originCountry, destinationCity, destinationZip, destinationState, destinationCountry, oAccessorial, dAccessorial,
                    classification, quantity, quantityUnit, weight, username, carrierName); //0.00

            BOLH = ratingCalculations.GetBOLH(carrierName); //-20.57
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

            BOFSC = ratingCalculations.GetBOFSC(carrierName); //-4.42
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

            BOTFACC = ratingCalculations.GetBOTFACCWithMGDescription(customerName, carrierName);       //25.00     
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;

            decimal BOTTL = BOLH + BOFSC + BOTFACC; //0.00
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;

            //Verifying CRM Rating Logic standard with UI
            decimal standardCRMLogicBOTFACC = BOTFACC; //25.00
            decimal standardCRMLogicBOTTL = standardCRMLogicBOTFACC + BOLH + BOFSC;

            //adding bump and surge
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(SCAC, customerName);

            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            if (bumpSurgeCalculationModel.Bump > 0 || bumpSurgeCalculationModel.Surge > 0)
            {
                SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
                FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
                BTTL = finalModel.Total;
                Total = finalModel.Total;
            }
            else
            {
                Total = standardCRMLogicBOTTL; //-0.00
            }

            return Total;
        }
    }
}
