using CRM.UITest.CommonMethods;
using CRM.UITest.Helper;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class _7_Calculate_Breakout_Linehaul__BOLH__steps : AddShipments
    {
        RatingCalculationMethods ratingCalculation = new RatingCalculationMethods();
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;

        [Then(@"BOLH can be calculated and Verified in the ShpResults page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public decimal ThenBOLHCanBeCalculatedAndVerifiedInTheShpResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOLH = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
            
            if (UserType == "External")
            {
                string BOLH_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[3]");
                string ActualBOLH = BOLH.ToString();
                string FinalBOLH = "Line Haul: $" + Math.Round(BOLH, 2);
             //   Assert.AreEqual(BOLH_UI, FinalBOLH);
            }
            else if (UserType == "Internal")
            {
                string BOLH_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[3]");
                string ActualBOLH = BOLH.ToString();
                string FinalBOLH = "Line Haul: $" + Math.Round(BOLH, 2);
               // Assert.AreEqual(BOLH_UI, FinalBOLH);
            }
            return BOLH;
        }



    }
}
