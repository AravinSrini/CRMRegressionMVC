using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Review_and_Submit
{
    [Binding]
    public class ReviewAndSubmitLTLMVC5_SubmitShipmentButton_AlertUserSteps : AddShipments
    {
        PrintShippingLabelsSteps obj = new PrintShippingLabelsSteps();

        [When(@"I click the Submit Shipment Button on the Review and Submit \(LTL\) page(.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void WhenIClickTheSubmitShipmentButtonOnTheReviewAndSubmitLTLPage(string Usertype,
            string oAdd2,
            string oZip,
            string oName,
            string oAdd1,
            string dAdd2,
            string dName,
            string dAdd1,
            string Customer_Name,
            string oComments,
            string dComments,
            string dZip,
            string classification,
            string nmfc,
            string quantity,
            string weight,
            string desc)
        {
            obj.GivenIAmOnTheShipmentConfirmationLTLPage(Usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, Customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc);
        }

        [Then(@"I will receive an indication that CRM is processing my shipment(.*)")]
        public void ThenIWillReceiveAnIndicationThatCRMIsProcessingMyShipment(string IndicationMessage)
        {
            string ActualAlertMessage_UI = Gettext(attributeName_id, "SubmitShipment");
            Thread.Sleep(2000);
            Assert.AreEqual(IndicationMessage, ActualAlertMessage_UI);
        }
    }
}
