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

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_MoreInformation
{
    [Binding]
    public class ShipmentList_MoreInformation_StationUsersSteps : Shipmentlist
    {
        string errorMessage = null;

        [When(@"I search for any (.*) inside shipment search box")]
        public void WhenISearchForAnyInsideShipmentSearchBox(string data)
        {
            Report.WriteLine("Entering data inside the shipment list search box");
            SendKeys(attributeName_xpath, ShipmentList_SearchGridValuesTexTBox_Xpath, data);
        }

        [When(@"I click on information icon any MG shipment")]
        public void WhenIClickOnInformationIconAnyMGShipment()
        {
            Report.WriteLine("Clicking on more information icon for any shipment");
            Click(attributeName_xpath, Shipmentlist_FirstRow_MoreInfoIcon_Xpath);
        }

        [When(@"I click on information icon any CSA shipment")]
        public void WhenIClickOnInformationIconAnyCSAShipment()
        {
            Report.WriteLine("Clicking on more information icon for any shipment");
            Click(attributeName_xpath, Shipmentlist_FirstRow_MoreInfoIcon_Xpath);
        }

        [Then(@"the information box will be displayed with the following fields - Quantity,Weight,Carrier")]
        public void ThenTheInformationBoxWillBeDisplayedWithTheFollowingFields_QuantityWeightCarrier()
        {
            int count = GetCount(attributeName_xpath, ShipmentList_NoOfRows_Xpath);
            if (count > 1)
            {
                Report.WriteLine("Verifying the fields present under more information icon for MG shipments ");
                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_QuantityLabel_Xpath, "Quantity Field");
                string actQuanText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_QuantityLabel_Xpath);
                Assert.AreEqual("Quantity", actQuanText);

                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_WeightLabel_Xpath, "Weight Field");
                string actWeightText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_WeightLabel_Xpath);
                Assert.AreEqual("Weight", actWeightText);

                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_ServiceTypeOCarrierLabel_Xpath, "Carrier Field");
                string actCarrierText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceTypeOCarrierLabel_Xpath);
                Assert.AreEqual("Carrier", actCarrierText);
            }
            else
            {
                Report.WriteLine("Unable to verify more information fields as no records exists");
            }
        }

        [Then(@"the information box will be displayed with the following fields - Quantity,Weight,Service Type,Service Level")]
        public void ThenTheInformationBoxWillBeDisplayedWithTheFollowingFields_QuantityWeightServiceTypeServiceLevel()
        {
            int count = GetCount(attributeName_xpath, ShipmentList_NoOfRows_Xpath);
            if (count > 1)
            {
                Report.WriteLine("Verifying the fields present under more information icon for MG shipments ");
                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_QuantityLabel_Xpath, "Quantity Field");
                string actQuanText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_QuantityLabel_Xpath);
                Assert.AreEqual("Quantity", actQuanText);

                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_WeightLabel_Xpath, "Weight Field");
                string actWeightText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_WeightLabel_Xpath);
                Assert.AreEqual("Weight", actWeightText);

                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_ServiceTypeOCarrierLabel_Xpath, "service Type Field");
                string actSerTypeText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceTypeOCarrierLabel_Xpath);
                Assert.AreEqual("Service Type", actSerTypeText);

                VerifyElementPresent(attributeName_xpath, Shipmentlist_FirstRow_ServiceLevelLabel_Xpath, "service level Field");
                string actSerlevelText = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceLevelLabel_Xpath);
                Assert.AreEqual("Service Level", actSerlevelText);
            }
            else
            {
                Report.WriteLine("Unable to verify more information fields as no records exists");
            }
        }

        [Then(@"displaying data for Quantity,Weight,Carrier fields should match with API (.*)")]
        public void ThenDisplayingDataForQuantityWeightCarrierFieldsShouldMatchWithAPI(string Account)
        {
            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerSetup value = DBHelper.GetSetupDetails(accID);

            // Building request xml
            ListScreenExtractRequestXML data = new ListScreenExtractRequestXML();
            XElement reqXML = data.GetRequestXMLForShipmentListStationUser(value.MgAccountNumber, "CRM-ShpPrev30DaysAgent");

            //Building Client
            BuildHttpClient client = new BuildHttpClient();
            HttpClient headers = client.BuildHttpClientWithHeaders("Admin", "application/xml");


            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            List<ShipmentListViewModel> Sdata = Slist.CallListScreen(uri, headers, reqXML);


            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            string FirstRefNum = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
            string actQValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_Quantity_Xpath);
            string actWValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_Weight_Xpath);
            string actCValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceTypeOCarrier_Xpath);

            if (Sdata != null && UIShipments.Count > 1)
            {
                for (int j = 1; j < Sdata.Count; j++)
                {
                    if (Sdata[j].PrimaryReference == FirstRefNum)
                    {
                        string ExpQuantity = Sdata[j].Quantity;
                        string ExpWeight = Sdata[j].Weight + "lbs";
                        string ExpCarrier = Sdata[j].CarrierName;

                        Assert.AreEqual(ExpQuantity, actQValue);
                        Report.WriteLine("Displaying  quantity value " + ExpQuantity + " is matching with actual quantity value " + actQValue);

                        Assert.AreEqual(ExpWeight, actWValue);
                        Report.WriteLine("Displaying  weight value " + ExpQuantity + " is matching with weight quantity value " + actWValue);

                        Assert.AreEqual(ExpCarrier, actCValue);
                        Report.WriteLine("Displaying carrier value " + ExpQuantity + " is matching with actual quantity value " + actCValue);
                        break;
                    }
                }
            }
            else
            {
                Report.WriteLine("Not received any reposnse from API for Station ID: " + value.MgAccountNumber);
            }
        }

        [Then(@"displaying data for Quantity,Weight,Service Type and Service Level fields should match with API (.*)")]
        public void ThenDisplayingDataForQuantityWeightServiceTypeAndServiceLevelFieldsShouldMatchWithAPI(string Account)
        {
            int accID = DBHelper.GetAccountIdforAccountName(Account.Trim());
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);
            List<string> ShipList = new List<string>();

            ICsaShipmentListByLast30Days CSAShip = new CsaShipmentListByLast30Days();
            ShipmentListReponse APIShipments = CSAShip.GetCsaShipmentListByLast30Days(csaNumb, out errorMessage);

            IList<IWebElement> UIShipments = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_RefNumAllValues_Xpath));
            string FirstRefNum = Gettext(attributeName_xpath, Shipmentlist_FirstRow_RefColumn_Xpath);
            string actQValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_Quantity_Xpath);
            string actWValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_Weight_Xpath);
            string actSTValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceTypeOCarrier_Xpath);
            string actSLValue = Gettext(attributeName_xpath, Shipmentlist_FirstRow_ServiceLevel_Xpath);

            if (APIShipments != null && UIShipments.Count > 1)
            {
                string ModeValue = APIShipments.Shipments.Where(a => a.Housebill == FirstRefNum).Select(b => b.Mode).FirstOrDefault();
                string SerValue = APIShipments.Shipments.Where(a => a.Housebill == FirstRefNum).Select(b => b.ServiceLevel).FirstOrDefault();
                int ExpQuantity = APIShipments.Shipments.Where(a => a.Housebill == FirstRefNum).Select(b => b.Pieces).FirstOrDefault();
                int ExpWeight = APIShipments.Shipments.Where(a => a.Housebill == FirstRefNum).Select(b => b.Weight).FirstOrDefault();

                ServiceType val = new ServiceType();
                string expServalue = val.GetCSAServiceType(SerValue);

                if (ModeValue == "Domestic")
                {
                    Assert.AreEqual(expServalue.Trim(), actSTValue.Trim());
                    Assert.AreEqual("N/A", actSLValue);
                }
                else
                {
                    Assert.AreEqual(actSTValue.Trim(), ModeValue.Trim());
                    Report.WriteLine("Displaying service type value " + actSTValue + " is matching with actual value " + ModeValue);

                    Assert.AreEqual(actSLValue.Trim(), expServalue.Trim());
                    Report.WriteLine("Displaying service level value " + actSLValue + " is matching with actual value " + expServalue);
                }
                Assert.AreEqual(actWValue , ExpWeight.ToString() + " lbs");
                Report.WriteLine("Displaying service level value " + actSLValue + " is matching with actual value " + actWValue);

                Assert.AreEqual(ExpQuantity + " Pallets", actQValue.ToString());
                Report.WriteLine("Displaying quantity value " + ExpQuantity + " is matching with actual value " + actQValue);
            }
            else
            {
                Report.WriteLine("No Records found to verify more information icon for CSA shipments");
            }
        }
    }
}
