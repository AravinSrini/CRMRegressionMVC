using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class CalculateBreakoutFuelSurchargeBOFSC_QuoteSteps : AddShipments

    {
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        List<RateResultCarrierViewModel> rlist = null;
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;



        [Then(@"BOFSC can be calculated and Verified in the Rate Results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenBOFSCCanBeCalculatedAndVerifiedInTheRateResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {

            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOFSC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);

            // Verifying calculated BOLH value with UI

            if (UserType == "Internal")
            {
                string firstCarrierInternalFuel_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]");//BOLH Internal
                Report.WriteLine("Verifying the BFSC calculation with UI value");
                string ActualBOTFACC = BOFSC.ToString();
                string FinalBOTFACC = "Fuel: $ " + Math.Round(BOFSC, 2);
                Assert.AreEqual(firstCarrierInternalFuel_UI, FinalBOTFACC);
                //Assert.AreEqual(firstCarrierInternalFuel, BOFSC.ToString());
            }
            else
            {
                string firstCarrierInternalFuel_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[2]"); //BOLH External
                Report.WriteLine("Verifying the BFSC calculation with UI value");
                Report.WriteLine("Verifying the BFSC calculation with UI value");
                string ActualBOTFACC = BOFSC.ToString();
                string FinalBOTFACC = "Fuel: $ " + Math.Round(BOFSC, 2);
                Assert.AreEqual(firstCarrierInternalFuel_UI, FinalBOTFACC);
                // Assert.AreEqual(firstCarrierFuel, BOFSC.ToString());
            }

        }

    }
}
