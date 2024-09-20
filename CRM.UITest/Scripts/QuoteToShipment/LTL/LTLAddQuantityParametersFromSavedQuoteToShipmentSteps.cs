using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.ServiceAccessLayer;
using System;
using System.Threading;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Scripts.Quote.LTL;

namespace CRM.UITest.Scripts.QuoteToShipment.LTL
{
    [Binding]
    public class LTLAddQuantityParametersFromSavedQuoteToShipmentSteps: ObjectRepository
    {
        string quoteNumber = null;

        [When(@"I enter valid data in shipment information page (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInShipmentInformationPageAnd(string OriginZip, string OriginCity, string OriginState, string DestinationZip, string DestinationCity, string DestinationState, string Classification, string Weight, string Quantity, string QuantityUnit)
        {
            ShippingInformationScreenForDesktopSteps steps = new ShippingInformationScreenForDesktopSteps();
            steps.WhenIEnterValidDataInOriginSectionAnd(OriginZip, OriginCity, OriginState);
            steps.WhenIEnterValidDataInDestinationSectionAnd(DestinationZip, DestinationCity, DestinationState);
            Click(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, Weight);
            SendKeys(attributeName_id, LTL_Quantity_Id, Quantity);
            //SelectDropdownValueFromList(attributeName_xpath, LTL_QuantityUnitField_Xpath, QuantityUnit);
        }

        [When(@"I click on save rate as quote link  for selected carrier in rate result page (.*)")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierInRateResultPage(string url)
        {
            string resultPagrURL = url + "Rate/LtlResultsView";

            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
            }
            else
            {
                string expected = Gettext(attributeName_xpath, ltlNoRateResultstxt_xpath);
                Assert.AreEqual(expected, "There are no rates available for this shipment.");
                Report.WriteLine("Rate Results page is not available");
                Assert.IsTrue(false);
            }
        }

        [When(@"I will be navigated to quote confirmation page and created quote number should be displayed")]
        public string WhenIWillBeNavigatedToQuoteConfirmationPageAndCreatedQuoteNumberShouldBeDisplayed()
        {
            Report.WriteLine("Verify the LTL quote Confirmation header");
            string QuoteConfirmationPageHeader_UI = Gettext(attributeName_xpath, LTL_QuoteConfirmationPageHeader_Xpath);
            Assert.AreEqual("Quote Confirmation", QuoteConfirmationPageHeader_UI);
            quoteNumber = Gettext(attributeName_xpath, LTL_QC_requestnumber_Id);
            return quoteNumber;
        }

        [When(@"I pass created quotenumber in quote list page")]
        public void WhenIPassCreatedQuotenumberInQuoteListPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I expand the quote details")]
        public void WhenIExpandTheQuoteDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on create shipment button present in quote details")]
        public void WhenIClickOnCreateShipmentButtonPresentInQuoteDetails()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter data in remaining required fields present in shipment location page (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterDataInRemainingRequiredFieldsPresentInShipmentLocationPageAnd(string p0, string p1, string p2, string p3)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on save and continue button from shipment location and dates page")]
        public void WhenIClickOnSaveAndContinueButtonFromShipmentLocationAndDatesPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter valid data in shipment information page without quantity and unit (.*), (.*), (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInShipmentInformationPageWithoutQuantityAndUnitAnd(string p0, string p1, string p2, string p3, string p4, string p5, string p6, string p7)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I pass valid data in additional item section  (.*), (.*), (.*) and (.*)")]
        public void WhenIPassValidDataInAdditionalItemSectionAnd(string p0, string p1, string p2, string p3)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I navigate to quote list page from confirmation page and search for the quote number")]
        public void WhenINavigateToQuoteListPageFromConfirmationPageAndSearchForTheQuoteNumber()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click on create shipment button for the created quote")]
        public void WhenIClickOnCreateShipmentButtonForTheCreatedQuote()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter data in remaining required fields present in shipment item information page (.*), (.*)")]
        public void WhenIEnterDataInRemainingRequiredFieldsPresentInShipmentItemInformationPage(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on save and continue button from shipment item information page")]
        public void WhenIClickOnSaveAndContinueButtonFromShipmentItemInformationPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I click on back button from shipment rate results page")]
        public void WhenIClickOnBackButtonFromShipmentRateResultsPage()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I pass valid data in additional item section without quantity (.*), (.*)")]
        public void WhenIPassValidDataInAdditionalItemSectionWithoutQuantity(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Quantity (.*) and Quantity unit (.*) fields should display values entered before and should be non editable")]
        public void ThenQuantityAndQuantityUnitFieldsShouldDisplayValuesEnteredBeforeAndShouldBeNonEditable(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Quantity and Quantity unit fields should be empty and editable")]
        public void ThenQuantityAndQuantityUnitFieldsShouldBeEmptyAndEditable()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"passed additional Quantity (.*) and Quantity unit (.*) fields should display values entered before and should be non editable")]
        public void ThenPassedAdditionalQuantityAndQuantityUnitFieldsShouldDisplayValuesEnteredBeforeAndShouldBeNonEditable(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"passed additional Quantity and Quantity unit fields should be empty and editable")]
        public void ThenPassedAdditionalQuantityAndQuantityUnitFieldsShouldBeEmptyAndEditable()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I enter data in remaining required fields for the additional items present in shipment item information page (.*), (.*), (.*), (.*), (.*), (.*)")]
        public void WhenIEnterDataInRemainingRequiredFieldsForTheAdditionalItemsPresentInShipmentItemInformationPage(string p0, string p1, string p2, string p3, string p4, string p5)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"passed Quantity and additional fields should display the value entered before (.*), (.*), (.*), (.*)  and editable")]
        public void ThenPassedQuantityAndAdditionalFieldsShouldDisplayTheValueEnteredBeforeAndEditable(string p0, string p1, string p2, string p3)
        {
            ScenarioContext.Current.Pending();
        }

    }
}
