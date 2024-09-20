using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.GetCSAServiceType;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Helper.Interfaces.Shipment;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_MoreInformation_CustomerUsers
{
    [Binding]
    public class ShipmentList_MoreInformation_CustomerUsersSteps : Shipmentlist
    {
        private string errorMessage;

        public object UIQuote { get; private set; }

        [When(@"I click on More Information Icon for MG Shipment")]
        public void WhenIClickOnMoreInformationIconForMGShipment()
        {
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                Report.WriteLine("Click on More Information Icon");
                IList<IWebElement> FirstrowVal = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentGrid_FirstRow_Xpath));
                Click(attributeName_xpath, ShipmentListGrid_MoreInfoIcon_Xpath);
            }
            else
            {
                Report.WriteLine("No rows found");
            }

        }

        [When(@"I click on More Information Icon for CSA Shipment")]
        public void WhenIClickOnMoreInformationIconForCSAShipment()
        {
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {

                string actualService = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceColumn_Xpath);
                if (actualService == "Domestic")
                {
                    Report.WriteLine("Click on More Information Icon");
                    Click(attributeName_id, ShipmentListGrid_MoreInfoIcon_Id);
                }
                else if (actualService == "International")
                {
                    Report.WriteLine("Click on More Information Icon");
                    Click(attributeName_id, ShipmentListGrid_MoreInfoIcon_Id);
                }
                else
                {
                    Assert.Fail();
                    Report.WriteFailure("Invalid values");

                }

            }
            else
            {
                Report.WriteLine("No rows found");
            }

        }

        [Then(@"I must be able to view the following fields - Quantity, Weight, Shipment Charge, Carrier")]
        public void ThenIMustBeAbleToViewTheFollowingFields_QuantityWeightShipmentChargeCarrier()
        {
            Report.WriteLine("More Information values for LTL,TL, PT, or IM shipment");
            Verifytext(attributeName_xpath, ShipmentListGrid_QuantityLabel_Xpath, "Quantity");
            Verifytext(attributeName_xpath, ShipmentListGrid_WeightLabel_Xpath, "Weight");
            Verifytext(attributeName_xpath, ShipmentListGrid_ShipChargeLabel_Xpath, "Shipment Charge");
            Verifytext(attributeName_xpath, ShipmentListGrid_CarrierLabel_Xpath, "Carrier");
        }



        [Then(@"I must be able to view the following fields - Quantity, Weight, Service Type, Service Level, Shipment Charge")]
        public void ThenIMustBeAbleToViewTheFollowingFields_QuantityWeightServiceTypeServiceLevelShipmentCharge()
        {
            Report.WriteLine("More Information values for Domestic Forwarding or International shipment");
            Verifytext(attributeName_xpath, ShipmentListGrid_QuantityLabel_Xpath, "Quantity");
            Verifytext(attributeName_xpath, ShipmentListGrid_WeightLabel_Xpath, "Weight");
            Verifytext(attributeName_xpath, ShipmentListGrid_ServiceTypeLabelCSA_Xpath, "Service Type");
            Verifytext(attributeName_xpath, ShipmentListGrid_ServiceLevelLabelCSA_Xpath, "Service Level");
            Verifytext(attributeName_xpath, ShipmentListGrid_ShipChargeLabelCSA_Xpath, "Shipment Charge");
        }



        [Then(@"The displayed Quantity, Weight, Shipment Charge and Carrier values should match with the API (.*)")]
        public void ThenTheDisplayedQuantityWeightShipmentChargeAndCarrierValuesShouldMatchWithTheAPI(string Account)
        {
            string UIShip = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
            string ActQuantityVal = Gettext(attributeName_xpath, ShipmentListGrid_Quantity_Xpath);
            string ActWeightVal = Gettext(attributeName_xpath, ShipmentListGrid_Weight_Xpath);
            string ActweightValue = ActWeightVal.Remove(ActWeightVal.Length - 3);
            string ActShipChargeVal = Gettext(attributeName_xpath, ShipmentListGrid_ShipCharge_Xpath);
            string ActShipChargeValue = ActShipChargeVal.Remove(0, 1);
            string ActCarrierVal = Gettext(attributeName_xpath, ShipmentListGrid_Carrier_Xpath);


            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListExternalUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent", Account);

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders(Account, "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);

            string QuantityVal = Sdata.Where(a => a.PrimaryReference == UIShip).Select(b => b.Quantity).FirstOrDefault();
            string WeightVal = Sdata.Where(a => a.PrimaryReference == UIShip).Select(b => b.Weight).FirstOrDefault();
            string ShipVal = Sdata.Where(a => a.PrimaryReference == UIShip).Select(b => b.CustomerCharges).FirstOrDefault();
            string CarrierVal = Sdata.Where(a => a.PrimaryReference == UIShip).Select(b => b.CarrierName).FirstOrDefault();


            Assert.AreEqual(ActQuantityVal, QuantityVal);
            Report.WriteLine("Quantity values from UI matches with the API response");
            Assert.AreEqual(ActweightValue, WeightVal);
            Report.WriteLine("Weight values from UI matches with the API response");
            Assert.AreEqual(ActShipChargeValue, ShipVal);
            Report.WriteLine("Shipment Charge values from UI matches with the API response");
            Assert.AreEqual(ActCarrierVal, CarrierVal);
            Report.WriteLine("Carrier values from UI matches with the API response");



        }


        [Then(@"The displayed Quantity, Weight, Service Type, Service Level and Est Cost values should match with the API (.*)")]
        public void ThenTheDisplayedQuantityWeightServiceTypeServiceLevelAndEstCostValuesShouldMatchWithTheAPI(string Account)
        {
            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);

            ICsaShipmentListByLast30Days CSAQuote = new CsaShipmentListByLast30Days();
            ShipmentListReponse APIQuotes = CSAQuote.GetCsaShipmentListByLast30Days(csaNumb, out errorMessage);


            string UIShipment = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
            string ActQuantity = Gettext(attributeName_xpath, ShipmentListGrid_Quantity_Xpath);
            string ActWeight = Gettext(attributeName_xpath, ShipmentListGrid_Weight_Xpath);
            string ActweightValue = ActWeight.Remove(ActWeight.Length - 4);
            string ActSerType = Gettext(attributeName_xpath, ShipmentListGrid_ServiceTypeCSA_Xpath);
            string ActSerLevel = Gettext(attributeName_xpath, ShipmentListGrid_ServiceLevelCSA_Xpath);
            string ActShipChargeVal = Gettext(attributeName_xpath, ShipmentListGrid_ShipChargeCSA_Xpath);



            string QuanValue = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIShipment)).Select(b => b.Pieces).ToString();
            string WeightValue = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIShipment)).Select(b => b.Weight).ToString();
            string ModeValue = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIShipment)).Select(b => b.Mode).FirstOrDefault();
            string SerValue = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIShipment)).Select(b => b.ServiceLevel).FirstOrDefault();
            string ShipCharge = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIShipment)).Select(b => b.Charges).ToString();

            ServiceType val = new ServiceType();
            string expServalue = val.GetCSAServiceType(SerValue);

            if (ModeValue == "Domestic")
            {
                Assert.AreEqual(expServalue.Trim(), ActSerType.Trim());
                Assert.AreEqual("N/A", ActSerLevel);
                Assert.AreEqual(QuanValue.Trim(), ActQuantity.Trim());
                Assert.AreEqual(WeightValue.Trim(), ActweightValue.Trim());
                Assert.AreEqual(ShipCharge.Trim(), ActShipChargeVal);
            }
            else if (ModeValue == "International")
            {
                Assert.AreEqual(ActSerType.Trim(), ModeValue.Trim());
                Assert.AreEqual(ActSerLevel.Trim(), expServalue.Trim());
                Assert.AreEqual(QuanValue.Trim(), ActQuantity.Trim());
                Assert.AreEqual(WeightValue.Trim(), ActweightValue.Trim());
                Assert.AreEqual(ShipCharge.Trim(), ActShipChargeVal);
            }
            else
            {
                Assert.Fail();
            }

        }
    }
}
