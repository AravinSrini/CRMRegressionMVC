using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Tracking.Tracking_Page___Without_Login
{
    [Binding]
    public class TrackingPage_ReferenceNumberSearch_ExternalUsersSteps:ObjectRepository
    {
        [Given(@"I am on tracking page")]
        public void GivenIAmOnTrackingPage()
        {
            string configUrl = launchUrl;
            string trackingUrl = configUrl + "Tracking/TrackingDetailsExternal";
            GlobalVariables.webDriver.Navigate().GoToUrl(trackingUrl);
            if (GetURL() == trackingUrl)
            {
                Report.WriteLine("I have entered url");
                WaitForElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
            }
            VerifyElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
            Report.WriteLine("I am on Tracking page");
        }
        
        [Given(@"I have entered (.*) in reference number search field")]
        public void GivenIHaveEnteredInReferenceNumberSearchField(string validRefNumber)
        {
            SendKeys(attributeName_id, TrackByReference_textbox_Id, validRefNumber);
            Report.WriteLine("I entered valid reference number(s) on tracking page");
        }
                
        [Given(@"I entered (.*) in reference number search field")]
        public void GivenIEnteredInReferenceNumberSearchField(string invalidRefNumber)
        {
            SendKeys(attributeName_id, TrackByReference_textbox_Id, invalidRefNumber);
            Report.WriteLine("I entered invalid reference number(s) on tracking page");
        }
        
        [Given(@"I enteredboth combination of (.*) in reference number search field")]
        public void GivenIEnteredBothCombinationOfInReferenceNumberSearchField(string refNumbers)
        {
            SendKeys(attributeName_id, TrackByReference_textbox_Id, refNumbers);
            Report.WriteLine("I entered valid and invalid reference number(s) on tracking page");
        }
        
        [When(@"I browse the tracking page url")]
        public void WhenIBrowseTheTrackingPageUrl()
        {
            string configUrl = launchUrl;
            string trackingUrl = configUrl + "Tracking/TrackingDetailsExternal";            
            GlobalVariables.webDriver.Navigate().GoToUrl(trackingUrl);
            if (GetURL() == trackingUrl)
            {
                Report.WriteLine("I have entered url");
                WaitForElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
            }            
        }
        
        [When(@"I click on submit arrow")]
        public void WhenIClickOnSubmitArrow()
        {
            Click(attributeName_xpath, TrackByReference_Arrow_Xpath);
            Report.WriteLine("Clicked on Search arrow button");
        }
        
        [When(@"I enter (.*) in filter results field")]
        public void WhenIEnterInFilterResultsField(string Ref)
        {
            SendKeys(attributeName_id, SearchShipment_Textbox_Id, Ref);
            Report.WriteLine("I entered value in filter results field of tracking page");
        }
        
        [Then(@"Tracking page will display")]
        public void ThenTrackingPageWillDisplay()
        {
            VerifyElementVisible(attributeName_xpath, TrackingPage_Header_xpath, "Tracking");
            Report.WriteLine("I have navigated to tracking page");
        }
        
        [Then(@"Searched shipment information will be displayed in grid (.*)")]
        public void ThenSearchedShipmentInformationWillBeDisplayedInGrid(string validRefNumber)
        {
            Report.WriteLine("Results are displaying for the entered reference number");
            List<string> trackingNumbersUI = IndividualColumnData(TrackingRefno_xpath);

            string[] enteredRefNumbers = validRefNumber.Split(',');

            for (int i = 0; i < trackingNumbersUI.Count; i++)
            {
                int index = trackingNumbersUI[i].IndexOf(" ");
                string referenceNumbers = trackingNumbersUI[i].Substring(0, index);

                if (enteredRefNumbers.Contains(referenceNumbers))
                {
                    Report.WriteLine("Entered Reference numbers in Tracking page are displaying grid");
                }
                else
                {
                    throw new System.Exception("Entered Reference numbers in Tracking page are not displaying grid");
                }
            }
        }
        
        [Then(@"The (.*) will display")]
        public void ThenTheWillDisplay(string errorMessage)
        {
            string errorMessageUI = Gettext(attributeName_xpath, trackingwarningmessageforinvalid);
            Assert.AreEqual(errorMessage, errorMessageUI);
            Report.WriteLine("I will be displaying with an error message of no data found");
        }

        [Then(@"The(.*) will display for invalid reference numbers")]
        public void ThenTheWillDisplayForInvalidReferenceNumbers(string errorMessage)
        {
            string errorMessageUI = Gettext(attributeName_xpath, trackingwarningmessageforinvalid);
            if (errorMessageUI.Contains(errorMessage))
            {
                Report.WriteLine("I will be displaying with an error message of Tracking Details not found for the following reference numbers");
            }            
        }

        [Then(@"Searched values will highlight in grid (.*)")]
        public void ThenSearchedValuesWillHighlightInGrid(string val)
        {
            Report.WriteLine("Verify searched data in  grid");
            SendKeys(attributeName_id, SearchShipment_Textbox_Id, val);
            Click(attributeName_id, SearchShipment_Textbox_Id);

            IList<IWebElement> searchResultsForRefNumber = GlobalVariables.webDriver.FindElements(By.XPath(TrackingPage_RefColumn_Highlighted_Xpath));
            int highlightedRefNumbers = searchResultsForRefNumber.Count;
            foreach (var actval in searchResultsForRefNumber)
            {
                if (val.Contains(actval.Text))
                {
                    var colorForHighlightedRefNumbers = GetCSSValue(attributeName_classname, TrackingPage_FilterResultsGridHighlighted_classname, "background-color");
                    Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorForHighlightedRefNumbers);
                    Report.WriteLine("Highlighted Reference values are appropriate");
                }
                else
                {
                    Assert.Fail();
                }
            }
            Clear(attributeName_id, SearchShipment_Textbox_Id);
        }        
    }
}
