using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class SavedQuoteToCreateShipment_DefaultPickupDateChangeSteps :Quotelist
    {
        public static string quoteRequestNumber = "";

        [Given(@"I have created a quote")]
        public void GivenIHaveCreatedAQuote()
        {
            DateTime pickupDate = DateTime.Today.AddDays(5);
            string fulurePickupDate = pickupDate.ToShortDateString();
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Clicked on quote icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Entering all required info in Get Quote page");
            SendKeys(attributeName_xpath, QuoteOriginZip, "33126");
            SendKeys(attributeName_xpath, QuoteDestinationZip, "33126");
            SendKeys(attributeName_xpath, QuoteLTLPage_SavedItem_Xpath, "60");
            SendKeys(attributeName_xpath, QuoteWeight_Xpath, "777");
            SendKeys(attributeName_xpath, PickupDate_Xpath, fulurePickupDate);
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteResult_LTL_SaveQuoteLink_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteRequestNumber = Gettext(attributeName_xpath, QuoteConfirmation_RequestNumber_Xpath);


        }

        [Given(@"I am in the Quote Details section of a non-expired LTL quote")]
        public void GivenIAmInTheQuoteDetailsSectionOfANon_ExpiredLTLQuote()
        {
            Click(attributeName_xpath, QuoteConfirmation_BackToQuoteListButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, quoteRequestNumber);
            Click(attributeName_xpath, QuoteList_Expand_FirstRecord_Xpath);
           
        }
        
        [Given(@"I clicked on the Create Shipment button from quote list page")]
        public void GivenIClickedOnTheCreateShipmentButtonFromQuoteListPage()
        {
            Report.WriteLine("Clicking on create shipemnt button from quote deatils");
            Click(attributeName_id, QuoteDetails_CreateShipmentButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"the Pickup Date will be defaulted to the Pickup Date entered during the Get Quote \(LTL\) process")]
        public void ThenThePickupDateWillBeDefaultedToThePickupDateEnteredDuringTheGetQuoteLTLProcess()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            IWebElement element = GlobalVariables.webDriver.FindElement(By.Id(PickupDate_Id));

            //IJavascriptExecutor jse = (JavascriptExecutor)driver;
            //jse.executeScript("return arguments[0].text", element);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            string script = "$('#PickupDate').val();";
            string actualPickupDate = executor.ExecuteScript(script).ToString();
            //string actualPickupDate = GetAttribute(attributeName_id, PickupDate_Id, "PickupDateto");
            DateTime pickUpDate = DateTime.Today.AddDays(5);
            string expectedPickupDate = pickUpDate.ToShortDateString();
            Assert.AreEqual(actualPickupDate, expectedPickupDate);
        }
    }
}
