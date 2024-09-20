using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System.Configuration;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_InternalUsers
{
    [Binding]
    public class QuoteList_SubmitRateRequestSteps : Quotelist
    {
        string Quotes_StationCustomerName = null;
        
        [Given(@"I am a Operations, Sales, Sales Management, or Station Owner user")]
        public void GivenIAmAOperationsSalesSalesManagementOrStationOwnerUser()
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            crm.LoginToCRMApplication(username, password);
        }
        
        [When(@"I see the Quote module in the left navigation bar")]
        public void WhenISeeTheQuoteModuleInTheLeftNavigationBar()
        {
            Report.WriteLine("I must be able to see the Quote module in left navigation bar");
            VerifyElementVisible(attributeName_xpath, Deshboard_QuoteText_xpath, "Quote List");
        }

        [When(@"I should be navigated to the Quote List(.*)page")]
        public void WhenIShouldBeNavigatedToTheQuoteListpage(string QuoteList_Header)
        {
            Report.WriteLine("Verify the header text from quote list page");
            Verifytext(attributeName_xpath, QuoteList_HeaderText_xpath, QuoteList_Header);
        }

        [When(@"All Customers option is selected by default")]
        public void WhenAllCustomersOptionIsSelectedByDefault()
        {
            Report.WriteLine("By default it selected All Customer option ");
            String ByDefaultSelected = Gettext(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);
            Assert.AreEqual("All Customers", ByDefaultSelected);
        }

        [When(@"I click Submit Rate Request button")]
        public void WhenIClickSubmitRateRequestButton()
        {
            Report.WriteLine("Click on the Submit rate request Button");
            Click(attributeName_id, SubmitRateRequestButton_Id);
        }


        [When(@"I choose any customeraccount (.*) from the dropdown")]
        public void WhenIChooseAnyCustomeraccountFromTheDropdown(string Account)
        {            
              
            Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);
            Report.WriteLine("Selecting" + Account + "from the Customer dropdown list");

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CategoryType_chosen']/div/ul/li"));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
               if(CustomerDropdown_List[i].Text == Account)
                {
                    CustomerDropdown_List[i].Click();
                    break;
                }
            }
            Quotes_StationCustomerName = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
        }

        [Then(@"I must be able to see the (.*) Button is Visible")]
        public void ThenIMustBeAbleToSeeTheButtonIsVisible(string SubmitRateRequest)
        {
            Report.WriteLine("I able to see the Submit Rate Request button");
            String SubmitRateButton_Text = Gettext(attributeName_id, SubmitRateRequestButton_Id);
            Assert.AreEqual(SubmitRateRequest, SubmitRateButton_Text);
        }


        [Then(@"I should not be able to see the (.*) Button")]
        public void ThenIShouldNotBeAbleToSeeTheButton(string SubmitRateRequest)
        {
            Report.WriteLine("Submit rate request button should not be visible");
            VerifyElementNotVisible(attributeName_id, SubmitRateRequestButton_Id, SubmitRateRequest);

        }

        [Then(@"I must be navagated to the (.*) Landing Page")]
        public void ThenIMustBeNavagatedToTheLandingPage(string GetQuote)
        {
            Report.WriteLine("I must be on Get Quote Landing page");
            String GetQuoteLandingPage_Text = Gettext(attributeName_xpath, LTLpagetitle_xpath);
            Assert.AreEqual(GetQuote, GetQuoteLandingPage_Text);
            
        }
        [Then(@"I must be able to see the (.*) tiles on Get Quote Landing Page")]
        public void ThenIMustBeAbleToSeeTheTilesOnGetQuoteLandingPage(string ServiceType)
        {
            Report.WriteLine("Get Quote landing page have service type as LTL tiles");
            String GetQuoteServiceLTLtilesText = Gettext(attributeName_id, LTL_TileLabel_Id);
            Assert.AreEqual(ServiceType, GetQuoteServiceLTLtilesText);

        }

        [When(@"I click on LTL tile on Get Quote landing page")]
        public void WhenIClickOnLTLTileOnGetQuoteLandingPage()
        {
            Report.WriteLine("Click on the LTL tiles");
            Click(attributeName_id, LTL_TileLabel_Id);
        }

        [Then(@"I must be navigated to the (.*) page")]
        public void ThenIMustBeNavigatedToThePage(string Get_Quote_LTL)
        {
            Report.WriteLine("I must see the Get Quote(LTL) page");
            String GetQuoteLTL_Headertext = Gettext(attributeName_xpath, LTLpagetitle_xpath);
            Assert.AreEqual(Get_Quote_LTL, GetQuoteLTL_Headertext);
        }

        [Then(@"Verify the associated Station and Customer name label should be displayed on Get Quote LTL page")]
        public void ThenVerifyTheAssociatedStationAndCustomerNameLabelShouldBeDisplayedOnGetQuoteLTLPage()
        {
            Report.WriteLine("Verifying the Selected Station Customer Name is displaying as label on Get Qute (LTL) page");
            string GetQuote_LTL_Station_CustomerNameLabel = Gettext(attributeName_id, GetQuote_LTL_StationCustomerName_Label_id);
            Assert.AreEqual(Quotes_StationCustomerName, GetQuote_LTL_Station_CustomerNameLabel);
        }

    }
}
