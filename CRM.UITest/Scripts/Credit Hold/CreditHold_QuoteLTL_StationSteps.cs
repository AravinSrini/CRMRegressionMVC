using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class CreditHold_QuoteLTL_StationSteps : Quotelist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        string creditHoldCustomer = string.Empty;
        string quoteNumber = string.Empty;
        string customername = "GMS Company";
        string pickUpDate = string.Empty;

        [Given(@"I am a sales, sales management, operation, or station owner user")]
        public void GivenIAmASalesSalesManagementOperationOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-CreditholdInternaluser"].ToString();
            string password = ConfigurationManager.AppSettings["password-CreditholdInternaluser"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I clicked on All Customers drop down list")]
        public void GivenIClickedOnAllCustomersDropDownList()
        {
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            Report.WriteLine("Clicked on Quote list customer dropdown list");
        }

        [Given(@"I have selected a customer that is on Credit Hold")]
        public void GivenIHaveSelectedACustomerThatIsOnCreditHold()
        {
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, "GMS Company (credit hold)");
            Report.WriteLine("Selected a Credit Hold Customer");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I expanded the Quote Details of any displayed active LTL quote")]
        public void GivenIExpandedTheQuoteDetailsOfAnyDisplayedActiveLTLQuote()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteList_NewRadioButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> gridStatusData = GlobalVariables.webDriver.FindElements(By.XPath(QuoteGridServiceColumnVal_Xpath));
            List<string> statusVal = new List<string>();

            foreach (var val in gridStatusData)
            {
                statusVal.Add(val.Text);
            }
            
            if (statusVal.Count >= 0 && statusVal.Contains("LTL  "))
            {
               // SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, "LTL");
                Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Expanded the Quote details of displayed active LTL quote");
            }
            else
            {               
                pickUpDate = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm");
                //Generate Random quote Number
                GetRandomQuoteNum();
                //Create a quote using API
                CreateQuote();
            }
            
        }
        
        [Given(@"I expanded the Quote Details of any displayed inactive LTL quote")]
        public void GivenIExpandedTheQuoteDetailsOfAnyDisplayedInactiveLTLQuote()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteList_ExpiredButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> gridStatusData = GlobalVariables.webDriver.FindElements(By.XPath(QuoteGridServiceColumnVal_Xpath));
            List<string> statusVal = new List<string>();

            foreach (var v in gridStatusData)
            {
                statusVal.Add(v.Text);
            }

            if(statusVal.Count >= 0 && statusVal.Contains("LTL  "))
            {
                Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Expanded the Quote details of displayed inactive LTL quote");
            }
            else
            {              
                pickUpDate = DateTime.UtcNow.AddDays(-5).ToString("MM/dd/yyyy HH:mm");
                //Generate Random quote Number
                GetRandomQuoteNum();
                //Create a Quote using API
                CreateQuote();
            }
        }
        
        [When(@"any associated customer has been placed on Credit Hold")]
        public void WhenAnyAssociatedCustomerHasBeenPlacedOnCreditHold()
        {
            creditHoldCustomer = "GMS Company";
            Report.WriteLine("Credit Hold Customer");
        }

        [When(@"I click on Submit Rate Request Button")]
        public void WhenIClickOnSubmitRateRequestButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, QuoteSubmitrateRequest_Button_Xpath);
            Report.WriteLine("Clicked on Submit Rate Request button");
        }

        [When(@"I click on Re-quote Button")]
        public void WhenIClickOnRe_QuoteButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteDetails_RequoteButton_id);
            Report.WriteLine("Clicked on Re quote button");
        }

        [When(@"I click on Create Shipment Button")]
        public void WhenIClickOnCreateShipmentButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteDetails_CreateShipmentButton_Id);
            Report.WriteLine("Clicked on Create Shipment button");
        }

        [Then(@"I will see an indicator that the customer is on Credit Hold")]
        public void ThenIWillSeeAnIndicatorThatTheCustomerIsOnCreditHold()
        {
            IList<IWebElement> creditHoldCustomerValUi = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownList_Xpath));
            List<string> expectedCreditHoldCustVal = new List<string>();

            foreach (var v in creditHoldCustomerValUi)
            {
                expectedCreditHoldCustVal.Add(v.Text);
            }

            if (expectedCreditHoldCustVal.Contains(creditHoldCustomer + " (credit hold)"))
            {                
               Report.WriteLine("Indicator is displayed for Credit Hold customers");             
            }

            else
            {
                Assert.Fail();
            }

        }
       
        [Then(@"I will receive a Message: '(.*)'")]
        public void ThenIWillReceiveAMessage(string SubmitRateButtonMessage)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, CreditHoldMessage_SubmitRateButton_Xpath, SubmitRateButtonMessage);
            Verifytext(attributeName_xpath, CreditHoldMessage_SubmitRateButton_Xpath, SubmitRateButtonMessage);
            Report.WriteLine("Expected message is displayed when user clicks on Submit Rate request button after selecting Credit hold customer");

        }
        public void CreateQuote()
        {
            CreateLTLQuote createQuote = new CreateLTLQuote();
            XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customername);
            BuildHttpClient client = new BuildHttpClient();
            HttpClient buildClient = client.BuildHttpClientWithHeaders(customername, "application/xml");
            HttpResponseMessage responseMessage = buildClient.PostAsXmlAsync<XElement>("MercuryGate/ShipmentImport", requestxml).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                refreshBrowser();
                Report.WriteLine("Quote is created");
                SendKeys(attributeName_id, QuoteList_Search_Box_Id, quoteNumber);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("LTL quote is expanded");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Assert.Fail();
            }
        }

        public void GetRandomQuoteNum()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            quoteNumber = "QTWB" + myRandomNo.ToString();
        }

    }
}
