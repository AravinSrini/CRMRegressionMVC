using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.Shipment_Service_Tiles_Screen
{
    [Binding]
    public class AddShipmen_ServiceSelection_DomFor_CustomerUsersSteps : AddShipments
    {
        
        [When(@"I click on the Domestic Forwarding tile in add shipment page")]
        public void WhenIClickOnTheDomesticForwardingTileInAddShipmentPage()
        {
            Report.WriteLine("Clicking on Domestic forwarding Tile");
            Click(attributeName_id, DomesticServiceTile_Id);
        }
        
        [When(@"I click on close button in service type popup")]
        public void WhenIClickOnCloseButtonInServiceTypePopup()
        {
            Report.WriteLine("Clicking on closed button in domestic forwarding type popup");
            WaitForElementVisible(attributeName_xpath, Domestic_CloseButton_Xpath, "Close Button");
            Click(attributeName_xpath, Domestic_CloseButton_Xpath);
        }
        
        [When(@"I click on continue button in service type popup")]
        public void WhenIClickOnContinueButtonInServiceTypePopup()
        {
            Report.WriteLine("Clicking on continue button in domestic forwarding type popup");
            WaitForElementVisible(attributeName_id, Domestic_ContinueButton_Id, "Continue Button");
            Click(attributeName_id, Domestic_ContinueButton_Id);
        }
        
        [When(@"I select any (.*) from the dropdown")]
        public void WhenISelectAnyFromTheDropdown(string type)
        {
            Report.WriteLine("Selecting option from the type dropdown");
            WaitForElementVisible(attributeName_xpath, Domestic_TypeDropdown_Xpath, "Type Dropdown");
            Click(attributeName_xpath, Domestic_TypeDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Domestic_TypeDropdownValues_Xpath, type);
        }
        
        [Then(@"service type option should be displayed")]
        public void ThenServiceTypeOptionShouldBeDisplayed()
        {
            Report.WriteLine("Verify the domestic forwarding type option popup");
            VerifyElementPresent(attributeName_xpath, Domestic_TypeDropdown_Xpath, "Type Dropdown");
        }

        [Then(@"I click on service type dropdown")]
        public void ThenIClickOnServiceTypeDropdown()
        {
            Report.WriteLine("Clicking on type dropdown");
            WaitForElementVisible(attributeName_xpath, Domestic_TypeDropdown_Xpath, "Type Dropdown");
            Click(attributeName_xpath, Domestic_TypeDropdown_Xpath);
        }


        [Then(@"Displaying types should match with (.*)")]
        public void ThenDisplayingTypesShouldMatchWith(string types)
        {
            string[] expTypes = types.Split(',');
            List<string> Expvalue = new List<string>();
            foreach (var v in expTypes)
            {
                Expvalue.Add(v);
            }
            IList<IWebElement> actUIValues = GlobalVariables.webDriver.FindElements(By.XPath(Domestic_TypeDropdownValues_Xpath));
            for(int i = 1; i < actUIValues.Count; i++)
            {
                if(Expvalue.Contains(actUIValues[i].Text))
                {
                    Report.WriteLine("Displaying" + actUIValues[i].Text + " option under type dropdown is matching with expected values");
                }
                else
                {
                    Report.WriteFailure("Invalid type dropdown option is displaying in UI");
                }
            }        
    }
        
        [Then(@"should have continue and close buttons")]
        public void ThenShouldHaveContinueAndCloseButtons()
        {
            Report.WriteLine("Verifying the continue and close button in domestic type popup");
            VerifyElementPresent(attributeName_id, Domestic_ContinueButton_Id, "Continue Button");
            VerifyElementPresent(attributeName_xpath, Domestic_CloseButton_Xpath, "Close Button");
        }
        
        [Then(@"popup should be closed and user should remain in add shipment page")]
        public void ThenPopupShouldBeClosedAndUserShouldRemainInAddShipmentPage()
        {
            Report.WriteLine("Verify the user landing page on closing the type popup");
            VerifyElementPresent(attributeName_xpath, AddShipmentTilepage_Header_Xpath, "Add Shipment Tile");
        }
        
        [Then(@"I should receive a message (.*)")]
        public void ThenIShouldReceiveAMessage(string expMessage)
        {
            Report.WriteLine("Verify the error message when type dropdown is not selected");
            Verifytext(attributeName_xpath, Domestic_ErrorMessage_Xpath, expMessage);
        }
        
        [Then(@"service type field should be highlighted")]
        public void ThenServiceTypeFieldShouldBeHighlighted()
        {
            Report.WriteLine("Verify the highlight functionality for type dropdown when any option is not selected");
            string color = GetCSSValue(attributeName_xpath, Domestic_TypeDropdown_Xpath, "background");
            color.Contains("http://dlsww-test.rrd.com/images/formicons.png");
            Report.WriteLine("Background error image is displaying");
        }
        
        [Then(@"I should be navigated to the Domestic Forwarding Locations and Dates page")]
        public void ThenIShouldBeNavigatedToTheDomesticForwardingLocationsAndDatesPage()
        {
            Report.WriteLine("Verify the domestic forwarding location and dates page");
            Verifytext(attributeName_xpath, DomesticShipment_LocationDatesHeader_Xpath, "Shipment Locations and Dates");
        }

        [Then(@"selected service type displayed at the top of the page (.*)")]
        public void ThenSelectedServiceTypeDisplayedAtTheTopOfThePage(string type)
        {
            Report.WriteLine("Verify the selected service in domestic forwarding location and dates page");
            Verifytext(attributeName_xpath, DomesticShipment_TypeValue_Xpath, type);
        }

    }
}
