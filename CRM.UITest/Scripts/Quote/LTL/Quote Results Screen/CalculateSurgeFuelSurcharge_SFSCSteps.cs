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
    public class CalculateSurgeFuelSurcharge_SFSCSteps : ObjectRepository
    {
        List<IndividualAccessorialModel> rlist = null;
        RatingCalculationMethods rateCal = new RatingCalculationMethods();
        public BumpSurgeCalculationModel bumpSurgeCalculationModel = new BumpSurgeCalculationModel();
        decimal BOFSC = 0;
        decimal SFSC = 0;
        decimal BFSC = 0;

        [When(@"I am on the quote results page to calculate SFSC (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public decimal WhenIAmOnTheQuoteResultsPageToCalculateSFSCAnd(string Username, string customerAcc, string userType, string oZip,
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
            BOFSC = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOFSC");
            bumpSurgeCalculationModel.BreakOutFuel = BOFSC;
            decimal BOLH = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOLH");
            bumpSurgeCalculationModel.BreakOutLineHaul = BOLH;

            //decimal BOTTL = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
            //   dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
            //    Username, userType, "BOTTL");
            //bumpSurgeCalculationModel.BreakOutTotal = BOTTL;

            decimal BOTFACC = step.calculateBaseMarkDownCharges(customerAcc, "service", oCity, oZip, oState, "USA",
               dCity, dZip, dState, "USA", oServices, dServices, classification, Convert.ToDouble(quantity), "skids", Convert.ToDouble(weight), "Quote",
                Username, userType, "BOTFACC");


            bumpSurgeCalculationModel.BreakOutAccessorialsTotal = BOTFACC;
            return BOFSC;

        }

        [Then(@"Surge Fuel Surcharge value will be calculated (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public decimal ThenSurgeFuelSurchargeValueWillBeCalculated(string Username, string customerAcc, string userType, string oZip,
            string oCity, string oState,
            string dZip, string dCity, string dState,
            string classification, string quantity, string weight, string oServices, string dServices)
        {
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
            SFSC = finalModel.Fuel;
            return finalModel.Fuel;
        }


        [Then(@"The calculated Surge Fuel Surcharge value should match with the UI value in quote list page")]
        public void ThenTheCalculatedSurgeFuelSurchargeValueShouldMatchWithTheUIValueInQuoteListPage()
        {
            Report.WriteLine("Calculated Surge Fuel Surcharge Value should match with the UI");
            string UIFuelSurcharge = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]");
            Report.WriteLine("Matching displayed Surge Fuel Surcharge value with UI");
            string FinalSFSC = "Fuel: $ " + Math.Round(SFSC, 2);
            Assert.AreEqual(UIFuelSurcharge, FinalSFSC);

        }



    }
}