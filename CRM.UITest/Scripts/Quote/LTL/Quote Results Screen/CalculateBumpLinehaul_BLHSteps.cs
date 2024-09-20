using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class CalculateBumpLinehaul_BLHSteps : ObjectRepository
    {
        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        decimal BOLH = 0;
        decimal BOTFACC = 0;
        decimal BLH = 0;

        [When(@"I am on the quote results page to calculate the BLH (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public decimal WhenIAmOnTheQuoteResultsPageToCalculateTheBLHAnd(string Username, string customerAcc, string userType, string oZip,
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
            BaseMarkupBreakDownCalcuation step = new BaseMarkupBreakDownCalcuation();
           BOLH = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;
          //  BaseMarkupBreakDownCalcuation step1 = new BaseMarkupBreakDownCalcuation();
            BOTFACC = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOTFACC");
            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;

           // BaseMarkupBreakDownCalcuation step3 = new BaseMarkupBreakDownCalcuation();
            decimal BOFSC = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;

           
            return BOTFACC;

        }


        [Then(@"The Bump Linehaul value will be calculated (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public decimal ThenTheBumpLinehaulValueWillBeCalculated(string Username, string customerAcc, string userType, string oZip,
            string oCity, string oState,
            string dZip, string dCity, string dState,
            string classification, string quantity, string weight, string oServices, string dServices)
        {

            Report.WriteLine("Calculating Bump Linehaul");
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

            CustomerAccount acc = DBHelper.GetAccountDetails_By_CustomerName(customerAcc);
            BumpSurgeCustomerSetUp setup = DBHelper.GetBumpSurgeDetails(CARSCAC_COde, customerAcc);
            bumpSurgeCalculationModel.Bump = (setup?.Bump) / 100 ?? 0;
            bumpSurgeCalculationModel.Surge = (setup?.Surge) / 100 ?? 0;

            SurgeAndBumpCaluclationsClass _surgeAndBumpCaluclationsClass = new SurgeAndBumpCaluclationsClass();
            FinalBumpSurgeCalculationModel finalModel = _surgeAndBumpCaluclationsClass.SurgeBumpCaluclation(bumpSurgeCalculationModel);
            BLH = finalModel.LineHaul;
            return finalModel.LineHaul;
        }

        [Then(@"The calculated Bump value should match with the value in UI of quotes results page")]
        public void ThenTheCalculatedBumpValueShouldMatchWithTheValueInUIOfQuotesResultsPage()
        {
            Report.WriteLine("Calculated Bump Value should match with the UI");
            string UIBumpLineHaul = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[3]");
            Report.WriteLine("Matching displayed Bump Linehaul value with UI");
            string FinalBLH = "Line Haul: $ " + Math.Round(BLH, 2);
            Assert.AreEqual(UIBumpLineHaul, FinalBLH);
        }

    }
}

