using CRM.UITest.Entities;
using CRM.UITest.Objects;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteDetails
{
    [Binding]
    public class QuoteDetails__All_Users_PrintQuote : Quotelist
    {


        string downloadpath = null;
        string QuoteDetails_StationCustomerName = null;

        [When(@"I expand any Quote in the Quote list page")]
        public void WhenIExpandAnyQuoteInTheQuoteListPage()
        {

            int rowcount = GetCount(attributeName_xpath, QuoteList_TotalRecords_Xpath);
            if (rowcount > 1)
            {
                Click(attributeName_xpath, QuoteDetails_Expand_FirstRecord_Xpath);
                Thread.Sleep(1000);
            }
            else
            {
                Report.WriteLine("No Records found for the LTL quotes for the logged in user");
            }
            string QuoteList_StationName = Gettext(attributeName_xpath, QuoteList_FirstQuote_StationName_xpath);
            string QuoteList_CustomerName = Gettext(attributeName_xpath, QuoteList_FirstQuote_CustomerName_xpath);
            QuoteDetails_StationCustomerName = (QuoteList_StationName + " - " + QuoteList_CustomerName);

        }

        [When(@"I click on the Print button"),Scope(Feature = "QuoteDetails _All_Users_PrintQuote")]
        public void WhenIClickOnThePrintButton()
        {
            WaitForElementVisible(attributeName_id, QuoteDetails_PrintButton_id, "Print Icon");
            Click(attributeName_id, QuoteDetails_PrintButton_id);
        }


        [Then(@"I must see the pdf is downloaded with quote details")]
        public void ThenIMustSeeThePdfIsDownloadedWithQuoteDetails()
        {
            downloadpath = GetDownloadedFilePath("Logistics _ CRM.pdf");
        }

        [Then(@"I must see the associated Station_CustomerName in the printed Quote details page")]
        public void ThenIMustSeeTheAssociatedStation_CustomerNameInThePrintedQuoteDetailsPage()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(downloadpath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

            }
            
             bool result = text.ToString().Contains(QuoteDetails_StationCustomerName);
         
        }

        [Then(@"I should see associated Station_CustomerName for (.*) in the printed Quote details page")]
        public void ThenIShouldSeeAssociatedStation_CustomerNameForInThePrintedQuoteDetailsPage(string Username)
        {
            Report.WriteLine("I should see the associated Station name and customer name in pdf for external users");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);

            String CustomerName_DB = DBHelper.GetCustomerName(value);
            String StationName_DB = DBHelper.GetStationName(CustomerName_DB);
            String Station_CustomerName = (StationName_DB + " - " + CustomerName_DB);

            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(downloadpath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

            }

            bool result = text.ToString().Contains(Station_CustomerName);
        }

        [Then(@"I should not see est cost and est margin fields in print document")]
        public void ThenIShouldNotSeeEstCostAndEstMarginFieldsInPrintDocument()
        {
            StringBuilder text = new StringBuilder();
            using (PdfReader reader = new PdfReader(downloadpath))
            {
                for (int i = 1; i <= reader.NumberOfPages; i++)
                {
                    text.Append(PdfTextExtractor.GetTextFromPage(reader, i));
                }

            }

            bool estCostResult = text.ToString().Contains("Est Cost:");
            bool estMarginResult = text.ToString().Contains("Est Margin%:");
            Assert.AreEqual(estCostResult.ToString(), "False");
            Assert.AreEqual(estMarginResult.ToString(), "False");
            Report.WriteLine("Est Cost and Est Margin fields are not displaying in printed document");
        }

        [When(@"I should be navigated to the Quote List page (.*)")]
        public void WhenIShouldBeNavigatedToTheQuoteListPage(string QuoteList_Header)
        {
            Report.WriteLine("Verfy the Quote list page header text ");
            Verifytext(attributeName_xpath, QuoteList_HeaderText_xpath, QuoteList_Header);
          
        }


    }
}

