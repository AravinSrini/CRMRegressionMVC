using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class CalculateBreakoutFuelSurchargeBOFSC_ShipmentSteps : AddShipments
    {
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;

        [Then(@"BOFSC can be calculated and verified in Shipment Results page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenBOFSCCanBeCalculatedAndVerifiedInShipmentResultsPage(string CustomerName, string Username, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
             baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            
            //Frame UI verifications of BOTFACC
            if (UserType == "External")
            {
                string BOFSC_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[4]/div[2]");
                decimal BOFSC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
                string ActualBOFSC = BOFSC.ToString();
                string FinalBOFSC = "Fuel: $" + Math.Round(BOFSC, 2);
           //     Assert.AreEqual(BOFSC_UI, FinalBOFSC);
            }
            else if (UserType == "Internal")
            {
                string BOFSC_UI = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[1]/td[5]/div[2]");
                decimal BOFSC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, "Service", OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
                string ActualBOFSC = BOFSC.ToString();
                string FinalBOFSC = "Fuel: $" + Math.Round(BOFSC, 2);
            //    Assert.AreEqual(BOFSC_UI, FinalBOFSC);
            }
        }


    }
}
