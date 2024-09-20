using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;

namespace CRM.UITest.CommonMethods
{
    class NavigateToQuoteResults : Quotelist
    {
        public void NavigateToQuoteResultsPage(string originZip, string destinationZip, string classification, string weight)
        {
            Report.WriteLine("Navigate to rate request submission");
            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to LTL Quote page");
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Entering origin ZipCode as " + originZip);
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, originZip);

            Report.WriteLine("Entering destination ZipCode as " + destinationZip);
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, destinationZip);

            Report.WriteLine("Entering classification as " + classification);
            //Click(attributeName_cssselector, QuoteClassification_Selector);
            Click(attributeName_cssselector, QuoteClassification_Selector);
            SendKeys(attributeName_cssselector, QuoteClassification_Selector, classification);

            Report.WriteLine("Entering weight as " + weight);
            SendKeys(attributeName_id, LTL_Weight_Id, weight);

            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        public void NavigateToQuoteResultsPage(string originZip, string originCity, string originState, string destinationZip, string destinationCity, string destinationState, string classification, string weight)
        {
            Report.WriteLine("Navigate to rate request submission");
            Click(attributeName_xpath, QuoteList_SubmitQuote_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Navigate to LTL Quote page");
            Click(attributeName_xpath, GetQuote_LtlButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Entering origin ZipCode as " + originZip);
            SendKeys(attributeName_id, QuoteDetails_Origin_AddressZip_Id, originZip);

            Report.WriteLine("Entering origin city as " + originCity);
            SendKeys(attributeName_id, GetQuote_OriginCityInput_Id, originCity);

            Report.WriteLine("Entering origin state as " + originState);
            Click(attributeName_id, stateforOrigin_id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, originState);

            Report.WriteLine("Entering destination ZipCode as " + destinationZip);
            SendKeys(attributeName_id, QuoteDetails_Destination_AddressZip_Id, destinationZip);

            Report.WriteLine("Entering destination city as " + destinationCity);
            SendKeys(attributeName_id, GetQuote_DestinationCityInput_Id, destinationCity);

            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            Report.WriteLine("Entering destination state as " + destinationState);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, destinationState);

            Report.WriteLine("Entering classification as " + classification);
            Click(attributeName_cssselector, QuoteClassification_Selector);
            SendKeys(attributeName_cssselector, QuoteClassification_Selector, classification);

            Report.WriteLine("Entering weight as " + weight);
            SendKeys(attributeName_id, LTL_Weight_Id, weight);

            Click(attributeName_id, GetQuote_ViewQuoteResult_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
    }
}
