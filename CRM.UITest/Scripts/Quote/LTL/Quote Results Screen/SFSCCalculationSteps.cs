using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class SFSCCalculationSteps : ObjectRepository
    {

        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        decimal BOTFACC = 0;
        decimal BOLH = 0;
        decimal BOFSC = 0;
        decimal SFSC = 0;
        decimal BOTTL = 0;
        decimal fuelSurcharge = 0;
        string firstCarrierval = null;

        [Then(@"SFSC value should be calculated")]
        public decimal ThenSFSCValueShouldBeCalculated()
        {
            CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps steps = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();
            decimal BMAA = steps.ThenBMAAShouldBeCalculated("Quote", "ZZZ - GS Customer Test", "LTL", "Miami", "33126", "FL", "USA", "Tempe",
                "85282", "AZ", "USA", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "LBS", "both", "Appointment", "COD");

            BaseMarkupBreakDownCalcuation step1 = new BaseMarkupBreakDownCalcuation();
            BOTFACC = step1.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 "both", "External", "BOTFACC");
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;
            //      BaseMarkupBreakDownCalcuation step2 = new BaseMarkupBreakDownCalcuation();
            BOLH = step1.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 "both", "External", "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

            BOFSC = step1.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 "both", "External", "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

            BOTTL = step1.calculateBaseMarkDownCharges("ZZZ - GS Customer Test", "service", "Miami", "33126", "FL", "USA",
                "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids", Convert.ToDouble("3"), "Quote",
                 "both", "External", "BOTTL");
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;


            List<IndividualAccessorialModel> apirespone = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet("ZZZ - GS Customer Test",
            "service", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids",
            Convert.ToDouble("3"), "LBS", "both", false);
            firstCarrierval = Gettext(attributeName_xpath, ltlCarrierName_xpath);
            List<string> carrierNames = apirespone.Select(p => p.carrierName).ToList();
            for (int i = 0; i < carrierNames.Count; i++)
            {
                if (apirespone[i].carrierName == firstCarrierval)
                {
                    fuelSurcharge = Convert.ToDecimal(apirespone[i].amount);
                    bumpSurgeCalculationModel.FuelSurgeCharge = fuelSurcharge;
                }
            }
            string firstCarrier = null;
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet("ZZZ - GS Customer Test",
                "service", "Miami", "33126", "FL", "USA", "Tempe", "85282", "AZ", "USA", "Appointment", "COD", "50", Convert.ToDouble("2"), "skids",
                Convert.ToDouble("3"), "LBS", "both", false);
            firstCarrier = Gettext(attributeName_xpath, ltlCarrierName_xpath);
            int carriercount = 0;
            for (int j = 0; j < rlist.Count; j++)
            {
                if (rlist[j].carrierName == firstCarrier)//XPO
                {
                    carriercount += 1;
                }
            }

            string CARSCAC_COde = null;//CNWY

            for (int i = 0; i < rlist.Count; i++)//2
            {
                if (rlist[i].carrierName == firstCarrier)
                {
                    CARSCAC_COde = rlist[i].CarrierScac;
                }
            }



            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(CARSCAC_COde, "ZZZ - GS Customer Test");
            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
            SFSC = finalModel.Fuel;
            return finalModel.Fuel;
        }

        [Then(@"The displayed carrier total value in UI of quote result page should match with calculated SFSC value")]
        public void ThenTheDisplayedCarrierTotalValueInUIOfQuoteResultPageShouldMatchWithCalculatedSFSCValue()
        {
            Report.WriteLine("Calculated Surge Fuel Surcharge Value should match with the UI");
            string UIFuelSurcharge = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]");
            Report.WriteLine("Matching displayed Surge Fuel Surcharge value with UI");
            string FinalSFSC = "Fuel: $ " + Math.Round(SFSC, 2);
            Assert.AreEqual(UIFuelSurcharge, FinalSFSC);
        }
    }
}