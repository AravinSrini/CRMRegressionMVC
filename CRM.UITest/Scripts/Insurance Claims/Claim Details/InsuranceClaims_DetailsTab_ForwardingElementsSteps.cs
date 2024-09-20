using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_DetailsTab_ForwardingElementsSteps : CRM.UITest.Objects.InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();

        [Given(@"I have clicked on a Claim reference number of ShipmentMode Forwarding in Claim List page")]
        public void GivenIHaveClickedOnAClaimReferenceNumberOfShipmentModeForwardingInClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string shipmentMode = "Forwarding";

            string gridDataOfClaimListPage = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (gridDataOfClaimListPage == "No Results Found")
            {
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Click on Forwarding Shipment mode claim refernce number");
                IList<IWebElement> dlswClaimNumberList = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClaimNumberALLValUI_xpath));
                List<string> dlswClaimNumberListFromUI = new List<string>();
                foreach (IWebElement element in dlswClaimNumberList)
                {
                    dlswClaimNumberListFromUI.Add((element.Text).ToString());
                }
                for (int i = 0; i <= dlswClaimNumberListFromUI.Count; i++)
                {
                    InsuranceClaim claimDetailsOfForwardingType = DBHelper.GetInsuranceClaimDetails(dlswClaimNumberListFromUI[i]);
                    if (claimDetailsOfForwardingType.ShipmentMode == shipmentMode)
                    {
                        int j = i + 1;
                        Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[@role = 'row'][" + j + "]/td[4]/span/a");                        
                        break;
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
                WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            }
        }

        [Given(@"I am on the Details tab of Claim Details page of (.*)")]
        public void GivenIAmOnTheDetailsTabOfClaimDetailsPageOf(string shipmentMode)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            string gridDataOfClaimListPage = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (gridDataOfClaimListPage == "No Results Found")
            {
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Click on any claim refernce number which is not of shipment mode FORWARDING");
                IList<IWebElement> dlswClaimNumberList = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClmRefNoListCount_Xpath));
                List<string> dlswClaimNumberListFromUI = new List<string>();
                foreach (IWebElement element in dlswClaimNumberList)
                {
                    dlswClaimNumberListFromUI.Add((element.Text).ToString());
                }
                GlobalVariables.webDriver.WaitForPageLoad();
                for (int i = 0; i <= dlswClaimNumberListFromUI.Count; i++)
                {
                    InsuranceClaim claimDetailsOfNonForwardingType = DBHelper.GetInsuranceClaimDetails(dlswClaimNumberListFromUI[i]);
                    if (claimDetailsOfNonForwardingType.ShipmentMode == shipmentMode)
                    {
                        int j = i + 1;
                        Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]/td[3]/span/a");
                        break;
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
                WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            }
        }

        [Given(@"I have clicked on a Claim ref number of ShipmentMode Forwarding in ClaimList page")]
        public void GivenIHaveClickedOnAClaimRefNumberOfShipmentModeForwardingInClaimListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string shipmentMode = "Forwarding";

            string gridDataOfClaimListPage = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (gridDataOfClaimListPage == "No Results Found")
            {
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Click on Forwarding Shipment mode claim refernce number");
                IList<IWebElement> dlswClaimNumberList = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClmRefNoListCount_Xpath));
                List<string> dlswClaimNumberListFromUI = new List<string>();
                foreach (IWebElement element in dlswClaimNumberList)
                {
                    dlswClaimNumberListFromUI.Add((element.Text).ToString());
                }
                for (int i = 0; i <= dlswClaimNumberListFromUI.Count; i++)
                {
                    InsuranceClaim claimDetailsOfForwardingType = DBHelper.GetInsuranceClaimDetails(dlswClaimNumberListFromUI[i]);
                    if (claimDetailsOfForwardingType.ShipmentMode == shipmentMode)
                    {
                        int j = i + 1;
                        Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]/td[3]/span/a");
                        break;
                    }
                }
                GlobalVariables.webDriver.WaitForPageLoad();
                WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            }
        }

        [Given(@"I am a sales, sales management, operations, station owner user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            crmLogin.LoginToCRMApplication(userName, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on Claim Details page")]
        public void WhenIArriveOnClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string claimDetailsHeader = Gettext(attributeName_xpath, ClaimDetailsPage_Header_Xpath);
            Assert.AreEqual(claimDetailsHeader, "Claim Details");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I arrived on Claim Details page");
        }

        [When(@"I change the Shipment mode to Forwarding")]
        public void WhenIChangeTheShipmentModeToForwarding()
        {            
            Click(attributeName_xpath, shipmentMode_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "Forwarding");
            Report.WriteLine("Changed the Shipment Mode to Forwarding");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"Forwarding Shipment mode will be pre selected in Claim Details Page")]
        public void ThenForwardingShipmentModeWillBePreSelectedInClaimDetailsPage()
        {
            string preSelectedShipmentMode = Gettext(attributeName_xpath, shipmentMode_Xpath);
            Assert.AreEqual(preSelectedShipmentMode, "Forwarding");
            Report.WriteLine("Forwarding shipment mode is pre selected");
        }

        [Then(@"AirLine, Pickup Carrier, Delivery Carrier, Steamship Line, Freight Forwarder and White Glove Agent will be displayed under Forwarding-Specific fields")]
        public void ThenAirLinePickupCarrierDeliveryCarrierSteamshipLineFreightForwarderAndWhiteGloveAgentWillBeDisplayedUnderForwarding_SpecificFields()
        {
            Report.WriteLine("Verifying AirLine, Pickup Carrier, Delivery Carrier, Steamship Line, Freight Forwarder and White Glove Agent fields");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            VerifyElementVisible(attributeName_xpath, airline_label_Xpath, "AIRLINE");
            VerifyElementVisible(attributeName_xpath, pickupCarrier_label_Xpath, "PICKUP CARRIER");
            VerifyElementVisible(attributeName_xpath, deliveryCarrier_label_Xpath, "DELIVERY CARRIER");
            VerifyElementVisible(attributeName_xpath, steamShipLine_label_Xpath, "STEAMSHIPLINE");
            VerifyElementVisible(attributeName_xpath, freightForwarder_label_Xpath, "FREIGHT FORWARDER");
            VerifyElementVisible(attributeName_xpath, whiteGloveAgent_label_Xpath, "WHITE GLOVE AGENT");
        }

        [Then(@"I should be able edit Airline, Delivery Carrier, Freight Forwarder, Pickup Carrier, Steamship Line and White Glove Agent")]
        public void ThenIShouldBeAbleEditAirlineDeliveryCarrierFreightForwarderPickupCarrierSteamshipLineAndWhiteGloveAgent()
        {
            Report.WriteLine("select value from AirLine dropdown");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Click(attributeName_xpath, airlineDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, airline_values_Xpath, "A & A X-Press, Inc.");

            Report.WriteLine("select value from Delivery Carrier dropdown");
            Click(attributeName_xpath, deliveryCarrierDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, deliveryCarrier_values_Xpath, "Aim Transportation Services Llc");

            Report.WriteLine("select value from Freight Forwarder dropdown");
            Click(attributeName_xpath, freightForwarderDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, freightForwarder_values_Xpath, "Chicago Suburban Express");

            Report.WriteLine("select value from Pickup Carrier dropdown");
            Click(attributeName_xpath, pickupCarrierDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, pickupCarrier_values_Xpath, "BUCEPHAL USA LLC");

            Report.WriteLine("select value from SteamShip Line dropdown");
            Click(attributeName_xpath, steamShipLineDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, steamShipLine_values_Xpath, "Dependable Air Cargo Express");

            Report.WriteLine("select value from White glove agent dropdown");
            Click(attributeName_xpath, whiteGloveAgentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, whiteGloveAgent_values_Xpath, "Hotline Delivery Systems");
        }

        [Then(@"I should not be able edit Airline, Delivery Carrier, Freight Forwarder, Pickup Carrier, Steamship Line and White Glove Agent")]
        public void ThenIShouldNotBeAbleEditAirlineDeliveryCarrierFreightForwarderPickupCarrierSteamshipLineAndWhiteGloveAgent()
        {
            Report.WriteLine("AirLine, Delivery Carrier, Freight Forwarder, Pickup Carrier, Steamship Line and White Glove Agent dropdown values non editable");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            IsElementDisabled(attributeName_xpath, airlineDropdown_Xpath, "airline");

            IsElementDisabled(attributeName_xpath, pickupCarrierDropdown_Xpath, "Pickup Carrier");

            IsElementDisabled(attributeName_xpath, deliveryCarrierDropdown_Xpath, "Delivery Carrier");

            IsElementDisabled(attributeName_xpath, steamShipLineDropdown_Xpath, "Steam Ship Line");

            IsElementDisabled(attributeName_xpath, freightForwarderDropdown_Xpath, "Freight Forwarder");

            IsElementDisabled(attributeName_xpath, whiteGloveAgentDropdown_Xpath, "White Glove Agent");
        }
    }
}
