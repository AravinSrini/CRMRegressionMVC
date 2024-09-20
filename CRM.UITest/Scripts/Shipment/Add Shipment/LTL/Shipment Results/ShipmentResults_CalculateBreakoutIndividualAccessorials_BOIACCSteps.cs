using CRM.UITest.Objects;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class ShipmentResults_CalculateBreakoutIndividualAccessorials_BOIACCSteps : AddShipments
    {
        BaseMarkupBreakDownCalcuation baseMarkupDown = null;

        [Then(@"BOIACC can be calculated for Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenBOIACCCanBeCalculatedForShipment(string CustomerName, string Service, string OriginCity, string OriginZip, string OriginState, string OriginCountry, string DestinationCity, string DestinationZip, string DestinationState, string DestinationCountry, string OAccessorial, string DAccessorial, string Classification, double Quantity, string QuantityUNIT, double Weight, string Mode, string UserType, string CalculationType)
        {
            string Username = null;
            if (UserType == "External")
            {
                Username = "both";
            }
            else if (UserType == "Internal")
            {
                Username = "salesmanager@stage.com";
            }

            baseMarkupDown = new BaseMarkupBreakDownCalcuation();
            decimal BOIACC = baseMarkupDown.calculateBaseMarkDownCharges(CustomerName, Service, OriginCity, OriginZip, OriginState, OriginCountry, DestinationCity, DestinationZip, DestinationState, DestinationCountry, OAccessorial, DAccessorial, Classification, Quantity, QuantityUNIT, Weight, Mode, Username, UserType, CalculationType);
        }

    }
}
