using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class OverLength_Requote_BindDimensionValuesSteps : Quotelist
    {
        string Length = null;
        string Width = null;
        string Height = null;
        string DimType = null;
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a shp\.inquiry, shp\.entry, sales, sales management, operations, or a station owner user")]
        public void GivenIAmAShp_InquiryShp_EntrySalesSalesManagementOperationsOrAStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on Quote List page")]
        public void GivenIAmOnQuoteListPage()
        {
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            Report.WriteLine("Quote List page");
        }
        
        [Given(@"The Quote details section of an expired LTL quote contains the following values - Length, Width, height and Dimension type")]
        public void GivenTheQuoteDetailsSectionOfAnExpiredLTLQuoteContainsTheFollowingValues_LengthWidthHeightAndDimensionType()
        {
            Click(attributeName_id, QuoteList_ExpiredButton_Id);
            MoveToElement(attributeName_xpath, QuoteExpandIcon_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_xpath, QuoteExpandIcon_Xpath);
            scrollpagedown();
            WaitForElementVisible(attributeName_id, QuoteDetails_RequoteButton_id,"Requote Button");
            string GetUIQuoteDetails = Gettext(attributeName_xpath, QuoteDetailsDimValues_Xpath);

            if (GetUIQuoteDetails.Contains("--"))
            {
                Report.WriteLine("Length Width Height Values is Zero");
                Length = null;
                Width = null;
                Height = null;
                DimType = null;
            }
            else if (GetUIQuoteDetails!= null)
            {
                Report.WriteLine("Quote details section of an expired LTL quote contains Dimension fields");
                var DimVal = GetUIQuoteDetails.Split(new[] { " " }, StringSplitOptions.None);
                Length = DimVal[1];
                Width = DimVal[5];
                Height = DimVal[8];
                DimType = DimVal[10];
               
            }
            else
            {
                Assert.Fail();
            }
            
        }

        [When(@"I click on Requote button")]
        public void WhenIClickOnRequoteButton()
        {
            Click(attributeName_id, QuoteDetails_RequoteButton_id);
            Report.WriteLine("Navigating to Get Quote LTL page");
        }
        
        [Then(@"CRM should bind the dimension values of the original quote to the re-quote on Get Quote \(LTL\) page")]
        public void ThenCRMShouldBindTheDimensionValuesOfTheOriginalQuoteToTheRe_QuoteOnGetQuoteLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string GetLengthVal = GetValue(attributeName_id, QuoteLTLPage_Length_Id,"value");
            string GetWidthVal = GetValue(attributeName_id, QuoteLTLPage_Width_Id, "value");
            string GetHeightVal = GetValue(attributeName_id, QuoteLTLPage_Height_Id, "value");
            string GetDimVal = Gettext(attributeName_xpath, QuoteLTLPage_DimensionType_Xpath);
            Assert.AreEqual(GetLengthVal, Length);
            Assert.AreEqual(GetWidthVal, Width);
            Assert.AreEqual(GetHeightVal, Height);
            Assert.AreEqual(GetDimVal, DimType);
            Report.WriteLine("Dimension values of the original quote is binded to the re-quote on Get Quote LTL page");
        }
    }
}
