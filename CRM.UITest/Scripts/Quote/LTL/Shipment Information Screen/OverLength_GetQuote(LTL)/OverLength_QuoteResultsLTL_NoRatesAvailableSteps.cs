using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class OverLength_QuoteResultsLTL_NoRatesAvailableSteps : Quotelist
    {
 
        [Given(@"I am on quote results page of a quote, which contains values for Length, Width, Height and Dimension Type")]
        public void GivenIAmOnQuoteResultsPageOfAQuoteWhichContainsValuesForLengthWidthHeightAndDimensionType()
        {
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Quote List page");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownValues_Xpath, "april23");
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            Click(attributeName_id, GetQuote_Ltlimage_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, QuoteLTLOriginZip_Xpath, "90001");
            SendKeys(attributeName_xpath, QuoteLTLDestinationZip_Xpath, "90001");
            SendKeys(attributeName_id, ClassorSavedItemField_id, "11");
            SendKeys(attributeName_id, weight_id, "4");
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "55");
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id, "44");
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id, "33");
            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Naviagted to Quote Results page");
        }

        [Given(@"I have received a notification that there are no rates available for this shipment")]
        public void GivenIHaveReceivedANotificationThatThereAreNoRatesAvailableForThisShipment()
        {
            Verifytext(attributeName_xpath, QuoteResultNoRatesUpdateLink_Xpath, "update your shipping information");
            Report.WriteLine("No rates available notification is present");
        }
        
        [When(@"I navigate to Get quote\(LTL\) page by clicking on update shipping information button")]
        public void WhenINavigateToGetQuoteLTLPageByClickingOnUpdateShippingInformationButton()
        {
            Click(attributeName_xpath, QuoteResultNoRatesUpdateLink_Xpath);
            Report.WriteLine("Clicked on update your shipping information button");
        }
        
        [Then(@"CRM will bind the dimension values of the original rate request submission")]
        public void ThenCRMWillBindTheDimensionValuesOfTheOriginalRateRequestSubmission()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string LengthVal = GetValue(attributeName_id, QuoteLTLPage_Length_Id,"value");
            string WidthVal = GetValue(attributeName_id, QuoteLTLPage_Width_Id,"value");
            string HeightVal = GetValue(attributeName_id, QuoteLTLPage_Height_Id,"value");
            string DimType = Gettext(attributeName_xpath, QuoteLTLPage_DimensionType_Xpath);
            Assert.AreEqual(LengthVal, "55");
            Assert.AreEqual(WidthVal, "44");
            Assert.AreEqual(HeightVal, "33");
            Assert.AreEqual(DimType, "IN");
            Report.WriteLine("Dimension values are binded while navigating back from Quote results page to Quote information page");
        }

        [Then(@"I have the option to edit the values\.")]
        public void ThenIHaveTheOptionToEditTheValues_()
        {
            SendKeys(attributeName_id, QuoteLTLPage_Length_Id, "99");
            SendKeys(attributeName_id, QuoteLTLPage_Width_Id, "88");
            SendKeys(attributeName_id, QuoteLTLPage_Height_Id, "77");
            Click(attributeName_xpath, QuoteLTLPage_DimensionType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteLTLPage_DimDropDown_Xpath, "FT");
            string EditLengthVal = GetValue(attributeName_id, QuoteLTLPage_Length_Id,"value");
            string EditWidthVal = GetValue(attributeName_id, QuoteLTLPage_Width_Id, "value");
            string EditHeightVal = GetValue(attributeName_id, QuoteLTLPage_Height_Id, "value");
            string EditDimType = Gettext(attributeName_xpath, QuoteLTLPage_DimensionType_Xpath);
            Assert.AreEqual(EditLengthVal, "99");
            Assert.AreEqual(EditWidthVal, "88");
            Assert.AreEqual(EditHeightVal, "77");
            Assert.AreEqual(EditDimType, "FT");
            Report.WriteLine("User is able to edit Dimension values in Get Quote LTL page");
        }
    }
}
