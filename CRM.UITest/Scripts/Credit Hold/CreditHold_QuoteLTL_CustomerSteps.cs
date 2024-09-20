using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.QuoteList;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Helper.Implementations;
using System.Threading;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class CreditHold_QuoteLTL_CustomerSteps : Quotelist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        GenerateQuoteNumber getQuotenumber = new GenerateQuoteNumber();
        HttpClientHelperForCreateQuote quoteCreation = new HttpClientHelperForCreateQuote();
        string quoteNumber = string.Empty;
        string customername = string.Empty;


        [Given(@"I'm a shp\.inquiry or shp\.entry user who associated to the Credit hold Customer(.*)")]
        public void GivenIMAShp_InquiryOrShp_EntryUserWhoAssociatedToTheCreditHoldCustomer(string customer)
        {
            string username = ConfigurationManager.AppSettings["username-CreditHoldShipEntry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CreditHoldShipEntry"].ToString();
            crm.LoginToCRMApplication(username, password);
            customer = Regex.Replace(customer, @"(<|>)", string.Empty);
            customername = customer;
        }


        [Given(@"I am on my Dashboard page")]
        public void GivenIAmOnMyDashboardPage()
        {   
            bool checkCreditHoldPopUp = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='modal_CreditHold']//h3")).Displayed;
            if (checkCreditHoldPopUp)
            {
                Click(attributeName_id, "btn_CreditHoldClose");
                Thread.Sleep(2000);
            }
            WaitForElementVisible(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard Page");
            Verifytext(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard");
        }

        [Given(@"I am on Quote List Page")]
        public void GivenIAmOnQuoteListPage()
        {
            
            bool checkCreditHoldPopUp = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='modal_CreditHold']//h3")).Displayed;
            if (checkCreditHoldPopUp)
            {
                Click(attributeName_id, "btn_CreditHoldClose");
                Thread.Sleep(2000);
            }
            //scrollElementIntoView(attributeName_xpath, GetQuoteButton_Xpath);
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, "//div[@id='page-content-wrapper']//h1[@class='quotes-header']", "Quote List Page");
        }

        [When(@"I am on my Dashboard page")]
        public void WhenIAmOnMyDashboardPage()
        {
            bool checkCreditHoldPopUp = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='modal_CreditHold']//h3")).Displayed;
            if (checkCreditHoldPopUp)
            {
                Click(attributeName_id, "btn_CreditHoldClose");
                Thread.Sleep(2000);
            }
            WaitForElementVisible(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard Page");
            Verifytext(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard");
        }


        [When(@"I arrive on the Quote List Page")]
        public void WhenIArriveOnTheQuoteListPage()
        {
            bool checkCreditHoldPopUp = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='modal_CreditHold']//h3")).Displayed;
            if (checkCreditHoldPopUp)
            {
                Click(attributeName_id, "btn_CreditHoldClose");
                Thread.Sleep(2000);
            }
            Click(attributeName_id, QuoteIconClick_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, "//div[@id='page-content-wrapper']//h1[@class='quotes-header']", "Quote List Page");
        }

        [When(@"I hover Over inactive (.*) button")]
        public void WhenIHoverOverInactiveButton(string button)
        {
            button = Regex.Replace(button, @"(<|>)", string.Empty);
            if (button == "Submit Rate Request")
            {
                OnMouseOver(attributeName_id, "rate-list");
            }

            if (button == "Get Quote")
            {
                scrollElementIntoView(attributeName_xpath, GetQuoteButton_Xpath);
                OnMouseOver(attributeName_xpath, GetQuoteButton_Xpath);
            }
        }

        [When(@"I expand the Quote Details of an expired LTL quote")]
        public void WhenIExpandTheQuoteDetailsOfAnExpiredLTLQuote()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, QuoteList_ExpiredButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            string gridData = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr/td");
            if (gridData != "Please select a station or customer to view quotes")
            {
                string status = string.Empty;
                string service = string.Empty;
                IList<IWebElement> GridData = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='QuotesGrid']/tbody/tr/td[3]"));
                int i = 1;
                for (int j = 1; j <= GridData.Count; j++, i += 2)
                { 
                    status = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[" + i + "]/td[4]");
                    service = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[" + i + "]/td[5]");
                    if (status == "Expired" && service == "LTL  ")
                    {
                        Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[" + i + "]/td[8]/button");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
                    else if (j == GridData.Count)
                    {
                        quoteNumber = getQuotenumber.GetRandomQuoteNumber();
                        string pickUpDate = DateTime.UtcNow.AddDays(-5).ToString("MM/dd/yyyy HH:mm");
                        CreateLTLQuote createQuote = new CreateLTLQuote();
                        XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customername);


                        BuildHttpClient client = new BuildHttpClient();
                        HttpClient buildClient = client.BuildHttpClientWithHeaders(customername, "application/xml");
                        string requestURI = "MercuryGate/ShipmentImport";

                        //makeHttpClientRequestExpandQuote(buildClient, requestURI, requestxml);
                        HttpResponseMessage responseMessage = quoteCreation.CreateQuote(buildClient, requestURI, requestxml);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                            
                            expandQuotefromQuoteDetails();
                        }
                        else
                        {
                            Assert.Fail("Unable to create Quote");
                        }

                    }
                }
            }
            else
            {
                quoteNumber = getQuotenumber.GetRandomQuoteNumber();
                string pickUpDate = DateTime.UtcNow.AddDays(-5).ToString("MM/dd/yyyy HH:mm");
                CreateLTLQuote createQuote = new CreateLTLQuote();
                XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customername);


                BuildHttpClient client = new BuildHttpClient();
                HttpClient buildClient = client.BuildHttpClientWithHeaders(customername, "application/xml");
                string requestURI = "MercuryGate/ShipmentImport";

                //makeHttpClientRequestExpandQuote(buildClient, requestURI, requestxml);
                HttpResponseMessage responseMessage = quoteCreation.CreateQuote(buildClient, requestURI, requestxml);
                if (responseMessage.IsSuccessStatusCode)
                {
                    XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                    expandQuotefromQuoteDetails();
                }
                else
                {
                    Assert.Fail("Unable to create Quote");
                }
            }
        }


        private void expandQuotefromQuoteDetails()
        {
            refreshBrowser();
            //Click(attributeName_id, "showAll");
            SendKeys(attributeName_id, QuoteList_Search_Box_Id, quoteNumber);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Expand the first new LTL Quote in the Quote List ");
            Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[1]/td[8]/button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }



        [When(@"I expand the Quote Details of any active quote")]
        public void WhenIExpandTheQuoteDetailsOfAnyActiveQuote()
        {
            Click(attributeName_id, "showAll");
            string status = string.Empty;
            string service = string.Empty;
            string gridDataValue = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr/td");
            if (gridDataValue != "Please select a station or customer to view quotes")
            {
                IList<IWebElement> gridData = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='QuotesGrid']/tbody/tr/td[3]"));
                int i = 1;
                for (int j = 1; j <= gridData.Count; j++, i += 2)
                {
                    
                        status = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[" + i + "]/td[4]");
                        service = Gettext(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[" + i + "]/td[5]");
                    if (status != "Expired" && service == "LTL  ")
                    {
                        Click(attributeName_xpath, ".//*[@id='QuotesGrid']/tbody/tr[" + i + "]/td[8]/button");
                        GlobalVariables.webDriver.WaitForPageLoad();
                        break;
                    }
                    else if (j == gridData.Count)//i =4
                    {
                        quoteNumber = getQuotenumber.GetRandomQuoteNumber();
                        string pickUpDate = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm");
                        CreateLTLQuote createQuote = new CreateLTLQuote();
                        XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customername);


                        BuildHttpClient client = new BuildHttpClient();
                        HttpClient buildClient = client.BuildHttpClientWithHeaders(customername, "application/xml");
                        string requestURI = "MercuryGate/ShipmentImport";
                        //makeHttpClientRequestExpandQuote(buildClient, requestURI, requestxml);
                        HttpResponseMessage responseMessage = quoteCreation.CreateQuote(buildClient, requestURI, requestxml);
                        if (responseMessage.IsSuccessStatusCode)
                        {
                            XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                            expandQuotefromQuoteDetails();
                        }
                        else
                        {
                            Assert.Fail("Unable to create Quote");
                        }
                    }
                    //}
                    
                }
            }


            else
            {
                quoteNumber = getQuotenumber.GetRandomQuoteNumber();
                string pickUpDate = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm");
                CreateLTLQuote createQuote = new CreateLTLQuote();
                XElement requestxml = createQuote.CreateQuoteXml(quoteNumber, pickUpDate, customername);


                BuildHttpClient client = new BuildHttpClient();
                HttpClient buildClient = client.BuildHttpClientWithHeaders(customername, "application/xml");
                string requestURI = "MercuryGate/ShipmentImport";
                //makeHttpClientRequestExpandQuote(buildClient, requestURI, requestxml);
                HttpResponseMessage responseMessage = quoteCreation.CreateQuote(buildClient, requestURI, requestxml);
                if (responseMessage.IsSuccessStatusCode)
                {
                    XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                    expandQuotefromQuoteDetails();
                }
                else
                {
                    Assert.Fail("Unable to create Quote");
                }

            }
        }

        [Then(@"the (.*) button will be inactive")]
        public void ThenTheButtonWillBeInactive(string button)
        {
            button = Regex.Replace(button, @"(<|>)", string.Empty);
            if (button == "Get Quote")
            {
                scrollElementIntoView(attributeName_xpath, GetQuoteButton_Xpath);
                bool isCheckGetQuotebuttonActive = IsElementDisabled(attributeName_xpath, GetQuoteButton_Xpath, button);
                Assert.IsTrue(isCheckGetQuotebuttonActive);
            }
            if (button == "Submit Rate Request")
            {
                bool isCheckSubmitRateRequestbuttonActive = IsElementEnabled(attributeName_id, "rate-list", button);
                Assert.IsTrue(isCheckSubmitRateRequestbuttonActive);
                
            }
        }


        [Then(@"I will see a hover over message: (.*)")]
        public void ThenIWillSeeAHoverOverMessage(string expectedCreditHoldMessage)
        {
            expectedCreditHoldMessage = Regex.Replace(expectedCreditHoldMessage, @"(<|>)", string.Empty);
            string actualCreditHoldMessage = Gettext(attributeName_classname, "tooltipWithoutTextTransform");
            Assert.AreEqual(expectedCreditHoldMessage, actualCreditHoldMessage);
        }

        [Then(@"I will see hover over message (.*)")]
        public void ThenIWillSeeHoverOverMessage(string expectedCreditHoldMessage)
        {
            expectedCreditHoldMessage = Regex.Replace(expectedCreditHoldMessage, @"(<|>)", string.Empty);
            string actualCreditHoldMessage = Gettext(attributeName_classname, "tooltipWithoutTextTransform");
            Assert.AreEqual(expectedCreditHoldMessage, actualCreditHoldMessage);
        }

        [Then(@"I will not see the (.*) button")]
        public void ThenIWillNotSeeTheButton(string button)
        {
            button = Regex.Replace(button, @"(<|>)", string.Empty);
            if (button == "Re-quote")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                bool requoteButtonVisibility = GlobalVariables.webDriver.FindElement(By.Id("btn-quote")).Displayed;
                Assert.IsFalse(requoteButtonVisibility);
            }

            else if (button == "Create Shipment")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                bool createShipmentButtonVisibility = GlobalVariables.webDriver.FindElement(By.Id("btn-CreateShipment")).Displayed;
                Assert.IsFalse(createShipmentButtonVisibility);
            }
        }

        //[Given(@"I'm a shp\.inquiry or shp\.entry user who is not associated to the Credit hold Customer(.*)")]
        //public void GivenIMAShp_InquiryOrShp_EntryUserWhoIsNotAssociatedToTheCreditHoldCustomer(string customer)
        //{
        //    string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
        //    string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
        //    crm.LoginToCRMApplication(username, password);
        //    customer = Regex.Replace(customer, @"(<|>)", string.Empty);
        //    customername = customer;

        //}

        [Given(@"I'm a Ship\.entry or Ship\.inquiry for a customer who is not on credit hold(.*)")]
        public void GivenIMAShip_EntryOrShip_InquiryForACustomerWhoIsNotOnCreditHold(string customer)
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            crm.LoginToCRMApplication(username, password);
            customer = Regex.Replace(customer, @"(<|>)", string.Empty);
            customername = customer;
        }


        [Then(@"the (.*) button will be active")]
        public void ThenTheButtonWillBeActive(string button)
        {
            button = Regex.Replace(button, @"(<|>)", string.Empty);
            if (button == "Get Quote")
            {
                bool isCheckGetQuotebuttonActive = IsElementEnabled(attributeName_xpath, GetQuoteButton_Xpath, button);
                Assert.IsTrue(isCheckGetQuotebuttonActive);
            }
            if (button == "Submit Rate Request")
            {
                bool isCheckSubmitRateRequestbuttonActive = IsElementEnabled(attributeName_id, "rate-list", button);
                Assert.IsTrue(isCheckSubmitRateRequestbuttonActive);
            }
        }

        [Then(@"I will not see a hover over message: (.*)")]
        public void ThenIWillNotSeeAHoverOverMessage(string creditHoldMessage)
        {
            creditHoldMessage = Regex.Replace(creditHoldMessage, @"(<|>)", string.Empty);
            VerifyElementNotPresent(attributeName_classname, "tooltipWithoutTextTransform", creditHoldMessage);
        }

        [When(@"I hover Over active (.*) button")]
        public void WhenIHoverOverActiveButton(string button)
        {
            button = Regex.Replace(button, @"(<|>)", string.Empty);
            if (button == "Get Quote")
            {
                scrollElementIntoView(attributeName_xpath, GetQuoteButton_Xpath);
                OnMouseOver(attributeName_xpath, GetQuoteButton_Xpath);
            }
            else if (button == "Submit Rate Request")
            {
                OnMouseOver(attributeName_id, "rate-list");
            }
        }

        [Then(@"I will see the (.*) button")]
        public void ThenIWillSeeTheButton(string button)
        {
            button = Regex.Replace(button, @"(<|>)", string.Empty);
            if (button == "Re-quote")
            {
                VerifyElementPresent(attributeName_id, "btn-quote", "Re-quote button");
            }
            else if (button == "Create Shipment")
            {
                VerifyElementPresent(attributeName_id, "btn-CreateShipment", "Create Shipment button");
            }
        }


    }
}