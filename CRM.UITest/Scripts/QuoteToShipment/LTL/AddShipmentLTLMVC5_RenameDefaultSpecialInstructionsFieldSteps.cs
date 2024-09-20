using System;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class AddShipmentLTLMVC5_RenameDefaultSpecialInstructionsFieldSteps:AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        AddQuoteLTL qltl = new AddQuoteLTL();
        RateToShipmentLTL rsltl = new RateToShipmentLTL();
        QuoteToShipmentLTL qsltl = new QuoteToShipmentLTL();

        [When(@"I am on the Add Shipment \(LTL\) page (.*), (.*)")]
        public void WhenIAmOnTheAddShipmentLTLPage(string Usertype, string CustomerName)
        {
            //Navigate to Add shipment (LTL) page       
            ltl.NaviagteToShipmentList();
            ltl.SelectCustomerFromShipmentList(Usertype, CustomerName);
            Report.WriteLine("I am on Add shipment page");
        }

        [When(@"I am on Rate Resultspage (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIAmOnRateResultspageAnd(string userType, string customerName, string oZip, string dZip, string classification, string weight)
        {
            //navigate to quote results
            qltl.NaviagteToQuoteList();
            qltl.Add_QuoteLTL(userType, customerName);
            qltl.EnterOriginZip(oZip);
            qltl.EnterDestinationZip(dZip);
           
            qltl.EnterItemdata(classification, weight);
           
            qltl.ClickViewRates();
            Report.WriteLine("I am on Rate Results page");
        }

        [When(@"I click on save rate as quotelink for selected carrier in results page of '(.*)'")]
        public void WhenIClickOnSaveRateAsQuotelinkForSelectedCarrierInResultsPageOf(string userType)
        {
         
                qsltl.ClickOnSaveRateAsQuoteLink(userType);
                Report.WriteLine("I clicked on Save Rate as Quote Link on Rate Result page");            
        }

        [When(@"I click on createshipment for selected carrier in results page of '(.*)'")]
        public void WhenIClickOnCreateshipmentForSelectedCarrierInResultsPageOf(string userType)
        {

            rsltl.ClickOnCreateShipmentbutton_Quote(userType);
             Report.WriteLine("I clicked on Create Shipment button on Rate Results page");
        }
        [Then(@"I should  be displayed with Default Special Instructions field as ""(.*)"" on add shipment page")]
        public void ThenIShouldBeDisplayedWithDefaultSpecialInstructionsFieldAsOnAddShipmentPage(string SpecialInstructions)
        {
               
                Report.WriteLine("Veifying Special Instructions text on Add Shipment page");
                Report.WriteLine("scrolling into element");
                MoveToElement(attributeName_xpath, DefaultSpecialIntructions_HeaderText_xpath);
                string Actuallabel_Specialinstructions = Gettext(attributeName_xpath, DefaultSpecialIntructions_HeaderText_xpath);
                Assert.AreEqual(Actuallabel_Specialinstructions, SpecialInstructions);
              

        }
    }
}
