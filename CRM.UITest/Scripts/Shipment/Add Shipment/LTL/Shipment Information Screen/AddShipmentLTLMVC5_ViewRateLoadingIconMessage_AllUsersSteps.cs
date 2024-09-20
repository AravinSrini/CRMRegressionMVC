using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipmentLTLMVC5_ViewRateLoadingIconMessage_AllUsersSteps : AddShipments
    {
        RateToShipmentLTL RTS = new RateToShipmentLTL();
        AddShipmentLTL _shipmentLTL = new AddShipmentLTL();
        QuoteToShipmentLTL QTS = new QuoteToShipmentLTL();

        string BOL_Quote;


        [Given(@"I am on the Add Shipment\(LTL\) page via Rate to Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAmOnTheAddShipmentLTLPageViaRateToShipment(string Usertype, string CustomerName, string ocity, string ostate, string ozip, string dcity, string dstate, string dzip, string quantity, string weight, string Item, string oname, string oadd1, string dname, string dadd1, string nmfc)
        {
            QTS.RateToShipmentShipmentInformationPage_Navigation(Usertype, CustomerName, ocity, ostate, ozip, dcity, dstate, dzip, quantity, weight, Item, oname, oadd1, dname, dadd1, nmfc);
        }

        [When(@"I am on the Add Shipment\(LTL\) page(.*), (.*), (.*),(.*), (.*), (.*),(.*),(.*),(.*), (.*),(.*), (.*), (.*),(.*), (.*), (.*), (.*)")]
        public void WhenIAmOnTheAddShipmentLTLPage(string Usertype, string oAdd2, string oZip, string oName, string oAdd1, string dAdd2, string dName, string dAdd1, string Customer_Name, string oComments, string dComments, string dZip, string classification, string nmfc, string quantity, string weight, string desc)
        {
            QTS.DirectShipmentInformationPage_Navigation(Usertype, oAdd2, oZip, oName, oAdd1, dAdd2, dName, dAdd1, Customer_Name, oComments, dComments, dZip, classification, nmfc, quantity, weight, desc);
        }

        [Given(@"I am on the Add Shipment\(LTL\) page for Quote to Shipment(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAmOnTheAddShipmentLTLPageForQuoteToShipment(string service, string Usertype, string CustomerName, string ocity, string ostate, string ozip, string dcity, string dstate, string dzip, string quantity, string weight, string Item, string oname, string oadd1, string dname, string dadd1, string nmfc)
        {
            QTS.QuoteToShipmentShipmentInformationPage_Navigation(service, Usertype, CustomerName, ocity, ostate, ozip, dcity, dstate, dzip, quantity, weight, Item, oname, oadd1, dname, dadd1, nmfc);
        }

        [Then(@"loading message will be displayed for view rates button click(.*)")]
        public void ThenLoadingMessageWillBeDisplayedForViewRatesButtonClick(string loadingMess)
        {
            Thread.Sleep(2000);
            string text = GetAttribute(attributeName_xpath, ViewRatesButton_xpath, "data-loading-text");
            Assert.IsTrue(text.Contains(loadingMess));
            
        }

    }
}
