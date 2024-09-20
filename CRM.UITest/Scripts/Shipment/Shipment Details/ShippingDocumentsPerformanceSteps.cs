using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Diagnostics;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Shipment_Details
{
    [Binding]
    public sealed class ShippingDocumentsPerformanceSteps : Shipmentlist
    {
        Stopwatch stopwatch = new Stopwatch();

        [Given(@"I search for the shipment shipref using the shipment reference lookup (.*)")]
        public void GivenISearchForTheShipmentShiprefUsingTheShipmentReferenceLookup(string referenceNumber)
        {
            Report.WriteLine("Filtering Shipment results for " + referenceNumber);
            SendKeys(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, referenceNumber);
            Report.WriteLine("Clicking  refernce number lookup search button");
            Click(attributeName_xpath, ShipmentList_ReferenceNumLookupButton_Xpath);
            WaitForElementNotVisible(attributeName_xpath, ShipmentList_LoadingIcon_Xpath, "loading icon");
        }
        [Given(@"I have clicked on the View Shipment Details button of any displayed shipment on Shipment List Page")]
        public void GivenIClickedOnTheViewShipmentDetailsButtonOfAnyDisplayedShipmentOnShipmentListPage()
        {
            Report.WriteLine("Clicking Shipment list icon");
            Click(attributeName_xpath, ShipmentListGrid_RefNumAllValues_Xpath);
            Report.WriteLine("Waiting for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I expand the Shipping Documents section,")]
        public void WhenIExpandTheShippingDocumentsSection()
        {
            Report.WriteLine("Waiting for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ShipmentDetailsPageHeadingBOL, "BOL Reference Number");
            scrollElementIntoView(attributeName_xpath, ShipmentDetails_DocumentDropDown);
            Report.WriteLine("Starting stopwatch");
            stopwatch.Start();
            Report.WriteLine("Clicking Document Drop Down");
            Click(attributeName_xpath, ShipmentDetails_DocumentDropDown);
        }

        [Then(@"the search for documents will be completed within (.*) seconds")]
        public void ThenTheSearchForDocumentsWillBeCompletedWithinSeconds(int maxTimeAllowed)
        {
            Report.WriteLine("Waiting for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, "dvLoading", "loading icon"); 
            Report.WriteLine("Stopping stopwatch");
            stopwatch.Stop();
            TimeSpan elapsedTime = stopwatch.Elapsed;
            Report.WriteLine("Assert elapsed time less than 15 seconds");
            Report.WriteLine("Elapsed Time " + elapsedTime.Seconds);
            if (elapsedTime.Seconds > 15)
                Report.WriteLine("Warning - Action took longer than 15 seconds");
            Assert.IsTrue(elapsedTime.Seconds < maxTimeAllowed, "Elapsed Time was " + elapsedTime.Seconds);
            Report.WriteLine("Assert we have actually loaded files");
            int downloadedFiles = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='downloadfiles-div']//span[@id='fileName']")).Count;
            Assert.IsTrue(downloadedFiles > 0,"No files found for shipment");
        }
    }
}
