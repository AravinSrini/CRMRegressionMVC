using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public class GainshareCustomerPricingMarkupCalculation_ShipmentResultsSteps
    {
        [When(@"I am on the Shipment results page(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)(.*)")]
        public void WhenIAmOnTheShipmentResultsPage(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15, string p16, string p17, string p18, string p19, string p20, string p21, string p22)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Customer charges will be calculated based on Bump and Surge and verified in the Shipment results page(.*)(.*)(.*)")]
        public void ThenTheCustomerChargesWillBeCalculatedBasedOnBumpAndSurgeAndVerifiedInTheShipmentResultsPage(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
