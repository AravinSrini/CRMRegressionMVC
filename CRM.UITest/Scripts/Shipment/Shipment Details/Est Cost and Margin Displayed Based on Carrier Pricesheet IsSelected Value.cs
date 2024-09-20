using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.ViewModel.Shipment;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.Implementations.StandardReport;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System;

namespace CRM.UITest.Scripts.Shipment.Shipment_Details
{
    [Binding]
    public class Est_Cost_and_Margin_Displayed_Based_on_Carrier_Pricesheet_IsSelected_Value : Shipmentlist
    {
        string ShipmentListEstCost = string.Empty;
        string ShipmentListEstMargin = string.Empty;
        string ShipmentDetailsEstCost = string.Empty;
        string ShipmentDetailsEstMargin = string.Empty;

        string ReferenceNumber = string.Empty;

        IEnumerable<XElement> Pricesheets;

        [Given(@"I am an internal CRM user ""(.*)"" ""(.*)""")]
        [Given(@"I am an external CRM user ""(.*)"" ""(.*)""")]
        public void GivenIAmACRMUser(string user, string pass)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            string username = ConfigurationManager.AppSettings[user].ToString();
            string password = ConfigurationManager.AppSettings[pass].ToString();

            Report.WriteLine("Logging in as " + username);
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I search for a shipment by reference number ""(.*)""")]
        public void GivenISearchForAShipmentByReferenceNumber(string referenceNumber)
        {
            ReferenceNumber = referenceNumber;
            Report.WriteLine("Searching for the report " + referenceNumber);
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referenceNumber);
            Click(attributeName_xpath, ShipmentList_Referencenumber_searcharrow_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Getting shipment data from mercury gate");
            Pricesheets = GetShipmentFromMG(ReferenceNumber);

            if(Pricesheets == null)
            {
                Report.WriteLine("No pricesheets found for the given reference number");
                Assert.Fail();
            }
        }


        [When(@"I navigate to the shipment details page for the searched shipment")]
        public void WhenINavigateToTheShipmentDetailsPageForTheSearchedShipment()
        {
            Report.WriteLine("Navigating to the shipment details page");
            Click(attributeName_cssselector, ShipmentList_FirstReferenceNumber_Selector);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I read the estimated cost and margin values of a shipment from the shipment details")]
        public void WhenIReadTheEstimatedCostAndMarginValuesOfAShipmentFromTheShipmentDetails()
        {
            Report.WriteLine("Getting displayed estimated cost");
            ShipmentDetailsEstCost = Gettext(attributeName_cssselector, ShipmentDetails_EstCostValue_Selector);

            Report.WriteLine("Getting displayed estimated margin");
            ShipmentDetailsEstMargin = Gettext(attributeName_cssselector, ShipmentDetails_EstMarginValue_Selector);
        }
        
        [Then(@"the Est cost And Est Margin that are displayed in the shipment details are based on isSelected")]
        public void ThenTheEstCostAndEstMarginThatAreDisplayedInTheShipmentDetailsAreBasedOnIsSelected()
        {
            XElement ChargePriceSheet;
            if (ReferenceNumber.Equals("ZZX002011739"))
            {
                if (Pricesheets.Any(x => x.Attribute("type").Value.Equals("Charge") && x.Attribute("isSelected").Value.Equals("true")))
                {
                    Assert.Fail("Pricesheet has is selected true when it shouldn't");
                }

                ChargePriceSheet = Pricesheets.OrderByDescending(x => DateTime.Parse(x.Attribute("createDate").Value)).Where(x => x.Attribute("type").Value.Equals("Charge")).First();
            }
            else
            {
                var test = Pricesheets.ToList();
                ChargePriceSheet = Pricesheets.Where(x => x.Attribute("type").Value == "Charge" && x.Attribute("isSelected").Value == "true").First();
            }

            XElement CostPriceSheet = Pricesheets.Where(x => x.Attribute("type").Value.Equals("Cost") && x.Attribute("isSelected").Value.Equals("true")).First();

            double revenue = double.Parse(CostPriceSheet.Element("Total").Value);
            double estCost = double.Parse(ChargePriceSheet.Element("Total").Value);

            double estMargin =  ((revenue - estCost)/revenue)*100;

            Assert.AreEqual(estCost.ToString("C"), ShipmentDetailsEstCost);
            Assert.AreEqual(estMargin.ToString("0.##") + "%", ShipmentDetailsEstMargin);
        }
        
        private IEnumerable<XElement> GetShipmentFromMG(string refNumber)
        {
            IEnumerable<XElement> pricesheets;
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            string oid = string.Empty;

            XElement oidRequestXML = data.GetOidNumberFromReferenceNumber(refNumber);

            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("ZZZ Sandbox DLS Worldwide", "application/xml");
            List<ShipmentListViewModel> shipments = new List<ShipmentListViewModel>();
            ShipmentListViewModel shipment = new ShipmentListViewModel();

            string uri = $"MercuryGate/OidLookup";
            HttpResponseMessage response = headers.PostAsXmlAsync(uri, oidRequestXML).Result;

            if (response != null)
            {
                if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
                {
                    XElement responseData = response.Content.ReadAsAsync<XElement>().Result;
                    oid = responseData.Value;

                    uri = $"MercuryGate/ShipmentExtract";

                    XElement shimentRequestXML = data.GetShipmentFromOID(oid);

                    response = headers.PostAsXmlAsync(uri, shimentRequestXML).Result;

                    if (response != null)
                    {
                        if (response.IsSuccessStatusCode && response.StatusCode != HttpStatusCode.NoContent)
                        {
                            responseData = response.Content.ReadAsAsync<XElement>().Result;
                            pricesheets = ShipmentListScreen.GetPricesheetsListFromXML(responseData);

                            return pricesheets;
                        }
                    }
                }
            }

            return null;
        }
    }
}
