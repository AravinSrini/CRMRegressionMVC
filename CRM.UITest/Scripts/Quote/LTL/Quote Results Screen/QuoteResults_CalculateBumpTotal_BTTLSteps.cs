using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class QuoteResults_CalculateBumpTotal_BTTLSteps : MaintenaceTools
    {
        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        decimal BTTL = 0;
        decimal BOFSC = 0;
        decimal BOLH = 0;
        decimal BMAA = 0;
        decimal BOTFACC = 0;
        decimal BOACC = 0;
        decimal BOTTL = 0;

        [When(@"I am on the quote results page with calculation for BTTL (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public decimal WhenIAmOnTheQuoteResultsPageWithCalculationForBTTLAnd(string Username, string customerAcc, string userType, string oZip,
            string oCity, string oState,
            string dZip, string dCity, string dState,
            string classification, string quantity, string weight, string oServices, string dServices)
        {

            AddQuoteLTL quote = new AddQuoteLTL();
            quote.NaviagteToQuoteList();
            quote.Add_QuoteLTL(userType, customerAcc);
            Thread.Sleep(4000);
            quote.EnterOriginZip(oZip);
            quote.EnterDestinationZip(dZip);
            quote.selectShippingfromServices(oServices);
            quote.selectShippingToServices(dServices);
            quote.EnterItemdata(classification, weight);
            quote.ClickViewRates();

            CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps steps = new CommonCalculations_LHBFC_BMSBTL_BM_BMAT_BMATC_BMMASteps();
            decimal BMAA = steps.ThenBMAAShouldBeCalculated("Quote", customerAcc, "LTL", oCity, oZip, oState, "USA", dCity,
                dZip, dState, "USA", classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "LBS", Username, oServices, dServices);


            BaseMarkupBreakDownCalcuation step1 = new BaseMarkupBreakDownCalcuation();
            BOTFACC = step1.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOTFACC");
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;
            //      BaseMarkupBreakDownCalcuation step2 = new BaseMarkupBreakDownCalcuation();
            BOLH = step1.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

            BOFSC = step1.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

            BOTTL = step1.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
              dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
               Username, userType, "BOTTL");
            bumpSurgeCalculationModel.BreakOutTotal = BOTTL;

            return BOTTL;

        }

      

            [Then(@"Bump total value will be calculated (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public decimal ThenBumpTotalValueWillBeCalculatedAnd(string Username, string customerAcc, string userType, string oZip,
            string oCity, string oState,
            string dZip, string dCity, string dState,
            string classification, string quantity, string weight, string oServices, string dServices)
        {
           

        Report.WriteLine("Calculating Surge Linehaul");
            string firstCarrier = null;
            rlist = GetRatesAndCarriersAPICall.BuildIndividualAccessorialModelFromCarrierPriceSheet(customerAcc, "service", oCity, oZip, oState, "USA", dCity,
                dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "LBS", Username, false);

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
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(CARSCAC_COde, customerAcc);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
            BTTL = finalModel.Total;
            return finalModel.Total;

        }

        [Then(@"displaying carrier total value in UI should match with calculated BTTL value")]
        public void ThenDisplayingCarrierTotalValueInUIShouldMatchWithCalculatedBTTLValue()
        {
            Report.WriteLine("Verifying the caculated total value with UI");
            string totalCarrier = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]");
            string FinalBTTL = "* $" + Math.Round(BTTL, 2);
            Assert.AreEqual(totalCarrier, FinalBTTL);
        }
    }
}
