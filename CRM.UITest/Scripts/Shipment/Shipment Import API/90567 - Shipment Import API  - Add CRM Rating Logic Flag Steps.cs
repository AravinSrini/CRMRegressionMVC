using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Shipment_Import_API
{
    [Binding]
    public sealed class Shipment_Import_API____Add_CRM_Rating_Logic_Flag_Steps
    {
        string customerName = string.Empty;
        string referenceNumber = string.Empty;
        ShipmentExtractViewModel shipmentviewModel = null;

        [Given(@"I am a third party integration customer (.*)")]
        public void GivenIAmAThirdPartyIntegrationCustomerWithNewCRMRatingLogicNinjaCustomer(string name)
        {
            Report.WriteLine("setting customer name to: " + customerName);
            customerName = name;
        }

        [Given(@"I am a third party integration customer: ""(.*)""")]
        public void GivenIAmAThirdPartyIntegrationCustomer(string name)
        {
            Report.WriteLine("setting customer name to: " + customerName);
            customerName = name;
        }

        [When(@"I make a webservice call to the v1 shipment (.*) method")]
        public void WhenIMakeAWebserviceCallToTheVShipmentImportMethod(string methodToCall)
        {
            MgCalls callsToMG = new MgCalls();
            Report.WriteLine("Making call to v1: " + methodToCall);
            referenceNumber = callsToMG.GetShipmentExtractViewModelFromMG(customerName, methodToCall, "v1");
            Report.WriteLine("Got reference number from MG: " + referenceNumber);
            shipmentviewModel = callsToMG.GetShipmentFromReferenceNumber(referenceNumber);
            Report.WriteLine("Got shipment view model");
        }



        [When(@"I make a webservice call to the shipment ""(.*)"" method")]
        public void WhenIMakeAWebserviceCallToTheShipmentImportMethod(string methodToCall)
        {
            MgCalls callsToMG = new MgCalls();
            Report.WriteLine("Making call to v2: " + methodToCall);
            referenceNumber = callsToMG.GetShipmentExtractViewModelFromMG(customerName, methodToCall, "v2");
            Report.WriteLine("Got reference number from MG: " + referenceNumber);
            shipmentviewModel = callsToMG.GetShipmentFromReferenceNumber(referenceNumber);
            Report.WriteLine("Got shipment view model");
        }


        [Then(@"the shipment will be created in mercurygate with a reference type of CRMRL")]
        public void ThenTheShipmentWillBeCreatedInMercurygateWithAReferenceTypeOfCRMRL()
        {
            Report.WriteLine("Reference Numbers Available: ");

            foreach (var reference in shipmentviewModel.ReferenceNumbers)
            {
                Report.WriteLine("Type: " + reference.Type + ", Reference: " + reference.ReferenceNumber);
            }

            Assert.IsTrue(shipmentviewModel.ReferenceNumbers.Any(x => x.Type.Equals("CRMRL")));
            Report.WriteLine("Found reference number of type CRMRL");
        }

        [Then(@"the shipment will not be created in mercurygate with a reference type of CRMRL")]
        public void ThenTheShipmentWillNotBeCreatedInMercurygateWithAReferenceTypeOfCRMRL()
        {
            Report.WriteLine("Reference Numbers Available: ");

            foreach (var reference in shipmentviewModel.ReferenceNumbers)
            {
                Report.WriteLine("Type: " + reference.Type + ", Reference: " + reference.ReferenceNumber);
            }

            Assert.IsFalse(shipmentviewModel.ReferenceNumbers.Any(x => x.Type.Equals("CRMRL")));
        }

        [Then(@"the reference value will be true")]
        public void ThenTheReferenceValueWillBeTrue()
        {
            Assert.AreEqual(shipmentviewModel.ReferenceNumbers.FirstOrDefault(x => x.Type.Equals("CRMRL")).ReferenceNumber, "true");
            Report.WriteLine("CRMRL has value of true");
        }
    }
}
