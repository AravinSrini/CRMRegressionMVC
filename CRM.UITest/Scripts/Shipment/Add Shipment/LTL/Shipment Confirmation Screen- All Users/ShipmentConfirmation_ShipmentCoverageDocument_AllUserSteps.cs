using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using System.Threading;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmation_ShipmentCoverageDocument_AllUserSteps : AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        string ShipmentConfirmation_Number;
        RateToShipmentLTL RTS = new RateToShipmentLTL();
        AddShipmentLTL _shipmentLTL = new AddShipmentLTL();
        QuoteToShipmentLTL QTS = new QuoteToShipmentLTL();

        string BOL_Quote;

        [When(@"I Am on the shipment confirmation of insured shipment  (.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void WhenIAmOnTheShipmentConfirmationOfInsuredShipment(string Usertype, string oAdd2, string oZip, string oName, string oAdd1, string dAdd2, string dName, string dAdd1, string Customer_Name, string oComments, string dComments, string dZip, string classification, string nmfc, string quantity, string weight, string desc)
        {
            _shipmentLTL.NaviagteToShipmentList();
            _shipmentLTL.SelectCustomerFromShipmentList(Usertype, Customer_Name);
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            _shipmentLTL.AddShipmentOriginData(oName, oAdd1, oZip);
            _shipmentLTL.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            _shipmentLTL.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);
            SendKeys(attributeName_id, InsuredValue_TextBox_Id, quantity);

            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }

            //Results page Create Shipment button Click
            ltl.ClickOnCreateInsuredShipmentButton(Usertype);

            //Navigation to Review and Submit page and Click on Submit button
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }



        [When(@"I click on the View Shipment Coverage button")]
        public void WhenIClickOnTheViewShipmentCoverageButton()
        {
            Click(attributeName_id, confirmation_ViewShipmentCoverageButton_Id);
        }

        [When(@"I Am on the shipment confirmation of insured shipment via Rate to Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAmOnTheShipmentConfirmationOfInsuredShipmentViaRateToShipment(string Usertype, string CustomerName, string ocity, string ostate, string ozip, string dcity, string dstate, string dzip, string quantity, string weight, string Item, string oname, string oadd1, string dname, string dadd1, string nmfc)
        {

            QTS.RateToShipmentShipmentInformationPage_Navigation(Usertype, CustomerName, ocity, ostate, ozip, dcity, dstate, dzip, quantity, weight, Item, oname, oadd1, dname, dadd1, nmfc);

            //added to click on view rate button
            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }

            //Results page Create Shipment button Click
            ltl.ClickOnCreateShipmentButton(Usertype);

            //Navigation to Review and Submit page and Click on Submit button
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }

        [When(@"I am on the Shipment Confirmation \(LTL\) page of insured shipment via Rate to Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAmOnTheShipmentConfirmationLTLPageOfInsuredShipmentViaRateToShipment(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7, string p8, string p9, string p10, string p11, string p12, string p13, string p14, string p15)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I Am on the shipment confirmation of insured shipment for Quote to Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void WhenIAmOnTheShipmentConfirmationOfInsuredShipmentForQuoteToShipment(string service, string Usertype, string CustomerName, string ocity, string ostate, string ozip, string dcity, string dstate, string dzip, string quantity, string weight, string Item, string oname, string oadd1, string dname, string dadd1, string nmfc)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will see the View Shipment Coverage button")]
        public void ThenIWillSeeTheViewShipmentCoverageButton()
        {
            VerifyElementPresent(attributeName_id, confirmation_ViewShipmentCoverageButton_Id, "View Shipment Coverage");
        }

        [Then(@"the Shipment Coverage document will be displayed in the new tab")]
        public void ThenTheShipmentCoverageDocumentWillBeDisplayedInTheNewTab()
        {
            Report.WriteLine("User is navigated to the Mercury Gate Login page");
            ShipmentConfirmation_Number = Gettext(attributeName_id, ShipmentConfirmationNumber_Id);
            bool n = WindowHandling("http://dlscrm-test.rrd.com/Shipment/ViewShipmentCoverageDocument?referenceNumber=" + ShipmentConfirmation_Number);
            string expectedURL = GetURL();
            expectedURL.Contains("http://dlscrm-test.rrd.com/Shipment/ViewShipmentCoverageDocument?referenceNumber=" + ShipmentConfirmation_Number);
        }

        [Then(@"I will be able to see View Shipment Coverage button")]
        public void ThenIWillBeAbleToSeeViewShipmentCoverageButton()
        {
            VerifyElementPresent(attributeName_id, confirmation_ViewShipmentCoverageButton_Id, "View Shipment Coverage");
        }

        [Then(@"I wil be able to see View Shipment Coverage button")]
        public void ThenIWilBeAbleToSeeViewShipmentCoverageButton()
        {
            VerifyElementPresent(attributeName_id, confirmation_ViewShipmentCoverageButton_Id, "View Shipment Coverage");
        }

        [Then(@"I will not see the View Shipment Coverage button")]
        public void ThenIWillNotSeeTheViewShipmentCoverageButton()
        {
            VerifyElementNotPresent(attributeName_xpath, confirmation_ViewShipmentCoverageButton_Id, "View Shipment Coverage");

        }

        [When(@"I Am on the shipment confirmation page  (.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void WhenIAmOnTheShipmentConfirmationPage(string Usertype, string oAdd2, string oZip, string oName, string oAdd1, string dAdd2, string dName, string dAdd1, string Customer_Name, string oComments, string dComments, string dZip, string classification, string nmfc, string quantity, string weight, string desc)
        {
            _shipmentLTL.NaviagteToShipmentList();
            _shipmentLTL.SelectCustomerFromShipmentList(Usertype, Customer_Name);
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            _shipmentLTL.AddShipmentOriginData(oName, oAdd1, oZip);
            _shipmentLTL.AddShipmentDestinationData(dName, dAdd1, dZip);
            scrollElementIntoView(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            Click(attributeName_id, FreightDesp_FirstItem_ClearItem_Button_Id);
            _shipmentLTL.AddShipmentFreightDescription(classification, nmfc, quantity, weight, desc);


            try
            {
                Click(attributeName_xpath, ViewRatesButton_xpath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(50000);
            }

            //Results page Create Shipment button Click
            ltl.ClickOnCreateShipmentButton(Usertype);

            //Navigation to Review and Submit page and Click on Submit button
            ltl.ReviewAndSubmit_ClickOnSubmitShipmentButton();
        }


    }
}
