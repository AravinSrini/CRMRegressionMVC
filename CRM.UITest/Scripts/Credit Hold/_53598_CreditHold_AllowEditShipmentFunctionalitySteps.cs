using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class _53598_CreditHold_AllowEditShipmentFunctionalitySteps
    {
        [Given(@"I filtered the Shipment List to a customer that is on Credit Hold")]
        public void GivenIFilteredTheShipmentListToACustomerThatIsOnCreditHold()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on the (.*) button of any displayed LTL shipment")]
        public void WhenIClickOnTheButtonOfAnyDisplayedLTLShipment(string p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I will not receive a message indicating that the customer is on Credit Hold")]
        public void ThenIWillNotReceiveAMessageIndicatingThatTheCustomerIsOnCreditHold()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
