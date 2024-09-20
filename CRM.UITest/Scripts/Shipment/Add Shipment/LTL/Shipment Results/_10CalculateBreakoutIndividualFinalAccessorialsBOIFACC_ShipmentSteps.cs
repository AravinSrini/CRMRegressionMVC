using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class _10CalculateBreakoutIndividualFinalAccessorialsBOIFACC_ShipmentSteps
    {
        [Then(@"the BOIFACC can be calculated for Shipment(.*)(.*)(.*)")]
        public void ThenTheBOIFACCCanBeCalculatedForShipment(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
