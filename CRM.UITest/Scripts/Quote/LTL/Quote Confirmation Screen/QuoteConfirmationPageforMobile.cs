using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public sealed class QuoteConfirmationPageforMobile : ObjectRepository
    {

        string carrierName = null;
        string  carrierStandardAmount = null;
        string carrierInsuredAmount= null;
     
       

        [When(@"I enter valid data origin zip in Origin section (.*)")]
        public void WhenIEnterValidDataOriginZipInOriginSection(string OriginZip)
        {
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, OriginZip);
        }



        [When(@"I enter valid data destination zip in Destination section (.*)")]
        public void WhenIEnterValidDataDestinationZipInDestinationSection(string DestinationZip)
        {
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, DestinationZip);
        }




        [When(@"I click on save rate as quote link  for selected carrier '(.*)' in mobile device")]
        public void WhenIClickOnSaveRateAsQuoteLinkForSelectedCarrierInMobileDevice(string App_Url)
        {
            //if((Gettext(attributeName_xpath, ltlNoRateResultstxt_xpath)!= "There are no rates available for this shipment"))
            string resultPagrURL = App_Url + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                VerifyElementPresent(attributeName_xpath, ltlQuoteResultsheader_xpath, "Quote Results (LTL)");
                VerifyElementPresent(attributeName_xpath, ltlresultsgridall_xpath, "ratereults");
                Console.WriteLine("rates are displpaying for the given information");

               // WaitForElementVisible(attributeName_xpath, ltlrate_mobile_xpath, "Save Rate As Quote");
                //scrollpagedown();
                //carrierName = Gettext(attributeName_xpath, ltlcarrierName_mobile_xpath);
                //carrierStandardAmount = Gettext(attributeName_xpath, ltlrate_mobile_xpath);
                //Report.WriteLine("Creater shipment for selected carrier");

                //Click(attributeName_xpath, ltlsaverateasquotelnk_xpath);
                Click(attributeName_xpath, ltlrate_mobile_xpath);
            }
            else
            {
                Report.WriteLine("Rates are not available");
                Console.WriteLine("Rate Results are not available for the given information");
                carrierName = "N/A";
                carrierStandardAmount = "N/A";
                carrierInsuredAmount = "N/A";
                Report.WriteLine("Creater shipment for selected carrier");
                Click(attributeName_xpath, ltlsavequotenorateslink_xpath);
            }
        }


        [Then(@"dropzone will be hidden")]
        public void ThenDropzoneWillBeHidden()
        {

            VerifyElementNotVisible(attributeName_xpath, LTL_ConfirmationDropZone_Xpath, "dropzone");
        }

        [Then(@"the '(.*)' List button will be hidden")]
        public void ThenTheListButtonWillBeHidden(string BacktoQuoteList)
        {
            Report.WriteLine("Verify back to quote list button should be hidden on confirmation page in mobile device");
            VerifyElementNotVisible(attributeName_id, LTL_QC_BackToQuoteListButton_Id, BacktoQuoteList);
        }

        [Then(@"Uploadshippingdocuments '(.*)' text will be hidden")]
        public void ThenUploadshippingdocumentsTextWillBeHidden(string Uploadshippingdocuments)
        {
            Report.WriteLine("Verify back to upload shipping documents section should be hidden on confirmation page in mobile device");
            VerifyElementNotVisible(attributeName_xpath, LTL_QC_UploadShippingDocumentText_Xpath, Uploadshippingdocuments);
        }

        [Then(@"I expand the Show Quote Details link '(.*)'")]
        public void ThenIExpandTheShowQuoteDetailsLink(string ShowQuoteDetails_link)
        {
            Report.WriteLine("Verify back to show quote details link should be hidden on confirmation page in mobile device");
            string showQuotedetails_UI = Gettext(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
            Assert.AreEqual(ShowQuoteDetails_link, showQuotedetails_UI);
            Click(attributeName_id, LTL_QC_ShowQuoteDetails_Id);
        }


        [Then(@"I will be able to scroll the details")]
        public void ThenIWillBeAbleToScrollTheDetails()
        {
            Report.WriteLine("Verify scroll page functionality on confirmation page in mobile device");
            
            scrollpagedown();
            scrollPageup();
        }
    }
}
