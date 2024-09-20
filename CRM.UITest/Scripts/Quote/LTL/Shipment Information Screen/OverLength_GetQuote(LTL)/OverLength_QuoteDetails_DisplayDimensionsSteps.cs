using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;

namespace CRM.UITest
{
    [Binding]
    public class OverLength_QuoteDetails_DisplayDimensionsSteps : AddShipmentLTL
    {
        AddShipmentLTL addShipment = new AddShipmentLTL();
        AddQuoteLTL getQuote = new AddQuoteLTL();
        RateToShipmentLTL rateToShipment = new RateToShipmentLTL();
        QuoteToShipmentLTL quoteToShipment = new QuoteToShipmentLTL();
        string QuoteRequestNum = null;
        string Length = "10";
        string Width = "10";
        string Height ="10";

        [When(@"I am Quote Details section of saved quote with Dimensions")]
        public void WhenIAmQuoteDetailsSectionOfSavedQuoteWithDimensions()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            getQuote.NaviagteToQuoteList();
            getQuote.Add_QuoteLTL("External","zzz");
            getQuote.EnterOriginZip("60606");
            getQuote.EnterDestinationZip("33126");
            getQuote.selectShippingfromServices("Overlength");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            getQuote.EnterItemdata("65", "1200");
            SendKeys(attributeName_id, LTL_Length_Id, Length);
            SendKeys(attributeName_id, LTL_Width_Id, Width);
            SendKeys(attributeName_id, LTL_Height_Id, Height);
            Click(attributeName_xpath, "//*[@id='Length-Additional-Warning-0']/h4/i[@class='icon-close right']");
            DefineTimeOut(6000);
            GlobalVariables.webDriver.WaitForPageLoad();
            MoveToElement(attributeName_id, LTL_ViewQuoteResults_Id);
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            quoteToShipment.ClickOnSaveRateAsQuoteLink("External");
            GlobalVariables.webDriver.WaitForPageLoad();
            QuoteRequestNum = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            int Quotelist = 0;
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, QuoteRequestNum);
            Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (Quotelist > 1)
            {
                Click(attributeName_xpath, Shipment_exandableTrigger_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Report.WriteLine("No records");
            }

        
        }
        [When(@"I am Quote Details section of saved quote without Dimensions")]
        public void WhenIAmQuoteDetailsSectionOfSavedQuoteWithoutDimensions()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            getQuote.NaviagteToQuoteList();
            getQuote.Add_QuoteLTL("External", "zzz");
            getQuote.EnterOriginZip("60606");
            getQuote.EnterDestinationZip("33126");
            scrollElementIntoView(attributeName_id, LTL_SavedItemDropdown_Id);
            getQuote.EnterItemdata("65", "1200");
            DefineTimeOut(1000);
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            quoteToShipment.ClickOnSaveRateAsQuoteLink("External");
            GlobalVariables.webDriver.WaitForPageLoad();
            QuoteRequestNum = Gettext(attributeName_id, "referenceNumber-value");
            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            int Quotelist = 0;
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, QuoteRequestNum);
            Quotelist = GetCount(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr");
            if (Quotelist > 1)
            {
                Click(attributeName_xpath, Shipment_exandableTrigger_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Report.WriteLine("No records");
            }
        }
        
        [Then(@"Dimensions column will be displayed between the Classification and NMFC")]
        public void ThenDimensionsColumnWillBeDisplayedBetweenTheClassificationAndNMFC()
        {
            Report.WriteLine("Dimensions column will be displayed between the Classification and NMFC");
            VerifyElementVisible(attributeName_xpath, ".//*[@id='freightDimensions']", "DimensionsColumn");
        }

        [Then(@"dimensions L W H will be displayed in bold in Quote Details")]
        public void ThenDimensionsLWHWillBeDisplayedInBoldInQuoteDetails()
        {
            IList<IWebElement> dimensionValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='tblFreight']/tbody/tr/td[6]/strong"));
            List<string> dimensionvaluesUI = new List<string>();
            foreach (IWebElement element in dimensionValues)
            {
                dimensionvaluesUI.Add((element.Text));
            }

            if (dimensionvaluesUI[0].Equals("L") && dimensionvaluesUI[1].Equals("W") && dimensionvaluesUI[2].Equals("H"))
            {
                Report.WriteLine("Dimension Length, width and height are displaying in bold");
            }
            else
            {
                Report.WriteLine("Dimension Length, width and height are not displaying in bold");
            }

        }

        [Then(@"the values displayed next to L W H and dimensions type in Quote Details")]
        public void ThenTheValuesDisplayedNextToLWHAndDimensionsTypeInQuoteDetails()
        {
            string dimensionValues = Gettext(attributeName_xpath, ".//*[@id='tblFreight']/tbody/tr/td[6]");
            IList<string> dimensionValuesUI = dimensionValues.Replace("L", "").Replace("B", "").Replace("H", "").Split(' ');
            Assert.AreEqual(dimensionValuesUI[1], Length);
            Assert.AreEqual(dimensionValuesUI[5], Width);
            Assert.AreEqual(dimensionValuesUI[8], Height);
            Report.WriteLine("Length, width, height values displaying as -- next to L W H");
        }

        [Then(@"'(.*)' displayed next to L W H and dimensions type in Quote Details")]
        public void ThenDisplayedNextToLWHAndDimensionsTypeInQuoteDetails(string p0)
        {
            string dimensionValues = Gettext(attributeName_xpath, ".//*[@id='tblFreight']/tbody/tr/td[6]");
            IList<string> dimensionValuesUI = dimensionValues.Replace("L", "").Replace("B", "").Replace("H", "").Split(' ');
            Assert.AreEqual(dimensionValuesUI[1], "--");
            Assert.AreEqual(dimensionValuesUI[5], "--");
            Assert.AreEqual(dimensionValuesUI[8], "--");
            Report.WriteLine("Length, width, height values displaying as -- next to L W H");
        }
        
     }
}
