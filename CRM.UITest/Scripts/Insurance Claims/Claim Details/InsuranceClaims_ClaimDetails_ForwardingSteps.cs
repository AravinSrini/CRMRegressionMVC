using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Configuration;
using CRM.UITest.Entities;
using System;


namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details 
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_ForwardingSteps : InsuranceClaim
    {
        string ForwardingSpecificAirline = null;
        string ForwardingDeliveryCarrier = null;
        string ForwardingSteamshipLine = null;
        string ForwardingFreightForwarder = null;
        string ForwardingWhiteGloveAgent = null;
        string ForwardingPickupCarrier = null;
        

       
        [Given(@"I have edited Forwarding-Specific Fields - Airline")]
        public void GivenIHaveEditedForwarding_SpecificFields_Airline()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, airlineDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, airlineDropdown_Xpath, "AAA Cooper");
            Report.WriteLine("edited Forwarding-Specific Fields - Airline ");
        }
        
        [Given(@"I have edited Forwarding-Specific Fields - Delivery Carrier")]
        public void GivenIHaveEditedForwarding_SpecificFields_DeliveryCarrier()
        {
            Click(attributeName_xpath, deliveryCarrierDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, deliveryCarrierDropdown_Xpath, "A & B Freight Lines Inc");
            Report.WriteLine("edited Forwarding-Specific Fields - Delivery Carrier");
        }

        [Given(@"I am on Claim Details page,")]
        public void GivenIAmOnClaimDetailsPage()
        {
            Report.WriteLine("Navigating to Claim List page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            //Entities.Proxy.InsuranceClaim  claimNumber = DBHelper.GetRecentClaimNumber();
            int claimNumber = DBHelper.GetForwardingClaimNumber();
            string claimNo = claimNumber.ToString();
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNo);
            IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a"));
            ColumnElement.Click();
           
        }
 

        [Given(@"I have edited Forwarding-Specific Fields - Steamship Line")]
        public void GivenIHaveEditedForwarding_SpecificFields_SteamshipLine()
        {
            Click(attributeName_xpath, steamShipLineDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, steamShipLineDropdown_Xpath, "A & A X-Press, Inc.");
            Report.WriteLine("edited Forwarding-Specific Fields - Steamship Line");
        }

        [Given(@"I have edited Forwarding-Specific Fields - Pickup Carrier")]
        public void GivenIHaveEditedForwarding_SpecificFields_PickupCarrier()
        {
            Click(attributeName_id, pickupCarrier_Id);
            SelectDropdownValueFromList(attributeName_id, pickupCarrier_Id, "A&B Freight Line, Inc.");
            Report.WriteLine("edited Forwarding-Specific Fields - Pickup Carrier");
        }


        [Given(@"I have edited Forwarding-Specific Fields - Freight Forwarder")]
        public void GivenIHaveEditedForwarding_SpecificFields_FreightForwarder()
        {
            Click(attributeName_xpath, freightForwarderDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, freightForwarderDropdown_Xpath, "A STERLING FREIGHT CARRIER INC");
            Report.WriteLine("edited Forwarding-Specific Fields - Freight Forwarder");
        }
        
        [Given(@"I have edited Forwarding-Specific Fields - White Glove Agent")]
        public void GivenIHaveEditedForwarding_SpecificFields_WhiteGloveAgent()
        {
            Click(attributeName_xpath, whiteGloveAgentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, whiteGloveAgentDropdown_Xpath, "A & B Freight Lines Inc");
            Report.WriteLine("edited Forwarding-Specific Fields - White Glove Agent");

        }
        
        [When(@"I click on the Save Claim Details button"), Scope(Tag ="91189")]
        public void WhenIClickOnTheSaveClaimDetailsButton()
        {
            MoveToElement(attributeName_id, Details_SubmitClaimDetails_Button_Id);
            scrollPageup();
            Click(attributeName_id, Details_SubmitClaimDetails_Button_Id);
            Report.WriteLine("Clicked on Save Claim Details button");
        }
        

        [Given(@"I have made an edit to any of the Forwarding specific fields (.*)")]
        public void GivenIHaveMadeAnEditToAnyOfTheForwardingSpecificFields(string ForwardingField)
        {
            if (ForwardingField.Equals("Airline"))
            {
                Click(attributeName_xpath, airlineDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, airlineDropdown_Xpath, "AAA Cooper");
            }
            else if(ForwardingField.Equals("Delivery Carrier")){
                Click(attributeName_xpath, deliveryCarrierDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, deliveryCarrierDropdown_Xpath, "A & B Freight Lines Inc");
            }
            else if(ForwardingField.Equals("Steamship Line"))
            {

                Click(attributeName_xpath, steamShipLineDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, steamShipLineDropdown_Xpath, "A & A X-Press, Inc.");
            }
            else if (ForwardingField.Equals("Freight Forwarder"))
            {
                Click(attributeName_xpath, freightForwarderDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, freightForwarderDropdown_Xpath, "A STERLING FREIGHT CARRIER INC");
            }
            else if (ForwardingField.Equals("White Glove Agent"))
            {
                Click(attributeName_xpath, whiteGloveAgentDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, whiteGloveAgentDropdown_Xpath, "A & B Freight Lines Inc");
            }
        }


        [Then(@"the edited forwarding specific field data should be saved")]
        public void ThenTheEditedForwardingSpecificFieldDataShouldBeSaved()
        {
            string claimNumberUI = GetAttribute(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id, "value");
            int claimNumber = Convert.ToInt32(claimNumberUI);
            ForwardingSpecificAirline = GetAttribute(attributeName_id, airline_Id, "value");
            ForwardingPickupCarrier = GetAttribute(attributeName_id, pickupCarrier_Id, "value");
            ForwardingDeliveryCarrier = GetAttribute(attributeName_id, deliveryCarrier_Id, "value");
            ForwardingSteamshipLine = GetAttribute(attributeName_id, steamshipLine_Id, "value");
            ForwardingFreightForwarder = GetAttribute(attributeName_id, freightForwarder_Id, "value");
            ForwardingWhiteGloveAgent = GetAttribute(attributeName_id, whiteGloveAgent_Id, "value");

            Entities.Proxy.InsuranceForwardingMode ForwardingSpecificData = DBHelper.GetForwardingModeDetails(claimNumber);
            Report.WriteLine("Comparing updated data from UI and DB");
            ForwardingSpecificData.Airline.Equals(ForwardingSpecificAirline);
            ForwardingSpecificData.PickupCarrier.Equals(ForwardingPickupCarrier);
            ForwardingSpecificData.DeliveryCarrier.Equals(ForwardingDeliveryCarrier);
            ForwardingSpecificData.SteamshipLine.Equals(ForwardingSteamshipLine);
            ForwardingSpecificData.WhiteGloveAgent.Equals(ForwardingWhiteGloveAgent);
        }

        [Then(@"edited data should be saved")]
        public void ThenEditedDataShouldBeSaved()
        {
            
            string  claimNumberUI = GetAttribute(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id,"value");
            int claimNumber = Convert.ToInt32(claimNumberUI);

            ForwardingSpecificAirline = GetAttribute(attributeName_id, airline_Id, "value");
            ForwardingPickupCarrier = GetAttribute(attributeName_id, pickupCarrier_Id, "value");
            ForwardingDeliveryCarrier = GetAttribute(attributeName_id, deliveryCarrier_Id, "value");
            ForwardingSteamshipLine = GetAttribute(attributeName_id, steamshipLine_Id, "value");
            ForwardingFreightForwarder = GetAttribute(attributeName_id, freightForwarder_Id, "value");
            ForwardingWhiteGloveAgent = GetAttribute(attributeName_id, whiteGloveAgent_Id, "value");

            Entities.Proxy.InsuranceForwardingMode ForwardingSpecificData = DBHelper.GetForwardingModeDetails(claimNumber);
            Report.WriteLine("Comparing updated data from UI and DB");
            ForwardingSpecificData.Airline.Equals(ForwardingSpecificAirline);
            ForwardingSpecificData.PickupCarrier.Equals(ForwardingPickupCarrier);
            ForwardingSpecificData.DeliveryCarrier.Equals(ForwardingDeliveryCarrier);
            ForwardingSpecificData.SteamshipLine.Equals(ForwardingSteamshipLine);
            ForwardingSpecificData.WhiteGloveAgent.Equals(ForwardingWhiteGloveAgent);
        }

    }
}
