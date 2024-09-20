using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class CalculateBreakoutTotalBOTTL_ShipmentSteps : AddShipments
    {
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        CalculateBreakoutTotalFinalAccessorialsBOTFACC_QuoteSteps botfacc = null;
        CalculateBreakoutTotalFinalAccessorialsBOTFACC_ShipmentSteps botfaccShipment = null;
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;
        RatingCalculationMethods ratingCal = null;

        [Then(@"BOTTL can be calculated and Verified in the Shipment Results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public decimal ThenBOTTLCanBeCalculatedAndVerifiedInTheShipmentResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {

            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOLH = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, "BOLH");
            decimal BOFSC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, "BOFSC");
            decimal BOTFACCValue = 0;
            botfacc = new CalculateBreakoutTotalFinalAccessorialsBOTFACC_QuoteSteps();
            botfaccShipment=new CalculateBreakoutTotalFinalAccessorialsBOTFACC_ShipmentSteps();
            if (Mode == "Quote")
            {

                BOTFACCValue = botfacc.ThenBOTFACCCanBeCalculatedAndVerifiedInTheRateResultsPage(CustomerName, Username, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, UserType, "BOTFACC");
            }
            if (Mode == "Shipment")
            {
                BOTFACCValue=botfaccShipment.ThenBOTFACCCanBeCalculatedAndVerifiedInTheShipmentResultsPage(CustomerName, Username, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, UserType, "BOTFACC");
            }
            ratingCal = new RatingCalculationMethods();
            decimal BOTTLValue = ratingCal.BOTTL_BaseMarkupMinimumAmount(BOLH, BOFSC, BOTFACCValue);



            //Frame UI verifications of BOTFACC
            if (UserType == "Internal")
            {
                string BOTTL_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[1]");
                Report.WriteLine("Verifying the BOTTL  calculation with UI value");
                string ActualBOTTL = BOTTLValue.ToString();
                string FinalBOTTL = "$" + Math.Round(BOTTLValue, 2);
          
            }
            else
            {
                string BOTTL_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[1]");
                Report.WriteLine("Verifying the BOTTL calculation with UI value");
                string ActualBOTTL = BOTTLValue.ToString();
                string FinalBOTTL = "*$" + Math.Round(BOTTLValue, 2);
            }
            return BOTTLValue;
        }

    }
}
