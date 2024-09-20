using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class CalculateBreakoutTotalBOTTL_QuoteSteps : AddShipments
    {

        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        CalculateBreakoutTotalFinalAccessorialsBOTFACC_QuoteSteps botfacc = null;
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;
        RatingCalculationMethods ratingCal = null;



        [Then(@"BOTTL can be calculated and Verified in the Rate Results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public decimal ThenBOTTLCanBeCalculatedAndVerifiedInTheRateResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {

            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOLH = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, "BOLH");
            decimal BOFSC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, "BOFSC");

            botfacc = new CalculateBreakoutTotalFinalAccessorialsBOTFACC_QuoteSteps();
            decimal BOTFACCValue = botfacc.ThenBOTFACCCanBeCalculatedAndVerifiedInTheRateResultsPage(CustomerName,Username,OriginCity,OriginZip,OriginState,OriginCountry,DestinationCity,DestinationZip,DestinationState,DestinationCountry,OAccessorial,DAccessorial,Classification,Quantity,QuantityUNIT,Weight,Mode,UserType, "BOTFACC");

            ratingCal = new RatingCalculationMethods();
            decimal BOTTLValue = ratingCal.BOTTL_BaseMarkupMinimumAmount(BOLH, BOFSC, BOTFACCValue);


            if (UserType == "Internal" && Mode=="Quote")
            {
                string BOTTL_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[5]/ul[1]/li[1]");
                Report.WriteLine("Verifying the BOTTL  calculation with UI value");
                string ActualBOTTL = BOTTLValue.ToString();
                string FinalBOTTL = "* $" + Math.Round(BOTTLValue, 2);
               
               
            }
            else if(UserType == "External" && Mode == "Quote")
            {
                string BOTTL_UI = Gettext(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[1]/li[1]");
                Report.WriteLine("Verifying the BOTTL calculation with UI value");
                string ActualBOTTL = BOTTLValue.ToString();
                string FinalBOTTL = "* $" + Math.Round(BOTTLValue, 2);
               
            }
            else if(UserType == "Internal" && Mode == "Shipment")
            {

            }
            else
            {

            }

            return BOTTLValue;

        }


    }
}
