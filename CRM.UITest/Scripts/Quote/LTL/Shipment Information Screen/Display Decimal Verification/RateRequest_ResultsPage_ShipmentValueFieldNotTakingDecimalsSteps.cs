using System;
using System.Linq;
using System.Threading;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class RateRequest_ResultsPage_ShipmentValueFieldNotTakingDecimalsSteps : ObjectRepository
    {
        [When(@"I will be navigated results page with rates")]
        public void WhenIWillBeNavigatedResultsPageWithRates()
        {
            Report.WriteLine("Rate Results available");
            VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results");            
        }

        [Then(@"I should be able to enter decimal value in (.*) text box")]
        public void ThenIShouldBeAbleToEnterDecimalValueInTextBox(string ShipmentValue)
        {
            Report.WriteLine("Shipment Value Text box should accept decimal values");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, ShipmentValue);
            Thread.Sleep(1000);            
        }
        
        [Then(@"I click on Show Insured Rate button")]
        public void ThenIClickOnShowInsuredRateButton()
        {
            Report.WriteLine("Click on Show Insured Rate button");
            Click(attributeName_xpath, ltlShowInsuredRateBtn_xpath);
        }

        [Then(@"I will be displayed with (.*) in decimals")]
        public void ThenIWillBeDisplayedWithInDecimals(string ShipmentValue)
        {
            String EnteredShipmentValue = GetValue(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, "value");

            if (EnteredShipmentValue.Contains('.'))
            {
                char[] separator = new char[] { '.', ',' };
                string[] ShipmentValuestring = EnteredShipmentValue.Split(separator);
                int decimalLength = ShipmentValuestring[1].Length;
                Assert.AreEqual(decimalLength, 2);
                Report.WriteLine("Entered Shipment value contains only two decimal values");
            }
            else
            {
                throw new System.Exception("Entered Shipment value doesn't contain two decimal values");
            }
        }

        [Then(@"I will be displayed with Shipment Value of Insured Rates modal pop up")]
        public void ThenIWillBeDisplayedWithShipmentValueOfInsuredRatesModalPopUp()
        {
            Report.WriteLine("Displayed with Shipment Value of Insured Rates modal pop up");
            VerifyElementPresent(attributeName_xpath, ltlinsmodal_xpath, "ltlinsuredmodal");
            VerifyElementPresent(attributeName_id, ltlinsmdlshpmentvalue_id, "ltlinsuredmodalheader");
        }

        [Then(@"I should be able to enter decimal value in (.*) text box of modal pop up")]
        public void ThenIShouldBeAbleToEnterDecimalValueInTextBoxOfModalPopUp(string ShipmentValue)
        {
            Report.WriteLine("Shipment Value Text box in modal pop up should accept decimal values");
            Thread.Sleep(1000);
            SendKeys(attributeName_id, ltlinsmdlshpmentvalue_id, ShipmentValue);
            Thread.Sleep(1000);
            String ShipmentValueEntered = GetValue(attributeName_id, ltlinsmdlshpmentvalue_id, "value");

            if (ShipmentValueEntered.Contains('.'))
            {
                char[] separator = new char[] { '.'};
                string[] ShipmentValuestring = ShipmentValueEntered.Split(separator);
                int decimalLength_shpval = ShipmentValuestring[1].Length;
                Assert.AreEqual(decimalLength_shpval, 2);
                Report.WriteLine("Entered Shipment value in modal pop up contains only two decimal values");
            }
            else
            {
                throw new System.Exception("Entered Shipment value in modal pop up doesn't contain two decimal values");
            }
        }

        [Then(@"I click on Show Insured Rates button in the modal pop up")]
        public void ThenIClickOnShowInsuredRatesButtonInTheModalPopUp()
        {
            Report.WriteLine("Click on Show insured rates button");
            Click(attributeName_xpath, ltlinsmdlshowinsratebtn_xpath);
        }
    }
}
