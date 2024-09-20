using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Xml.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.QuoteList;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote_List.Requote
{
    [Binding, Scope(Tag = "48512")]
    public class Re_QuoteLTL_OverlengthAccl_BindAcclToShippingFromSteps : Quotelist
    {
        string customerName = "ZZZ - GS Customer Test";
        string quoteNumber = string.Empty;
        string pickUpDate = string.Empty;

        [Given(@"the expired quote had an Overlength accessorial")]
        public void GivenTheExpiredQuoteHadAnOverlengthAccessorial()
        {
            Report.WriteLine("Expired Quote had an accessorial Overlength");
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, QuoteDetails_AdditionalServicesAndAccessorials_xpath, "ADDITIONAL SERVICES AND ACCESSORIALS");
            VerifyElementVisible(attributeName_xpath, ".//span[contains(text(),'Overlength')]", "Overlength");
        }

        [Given(@"the expired quote had an accessorial")]
        public void GivenTheExpiredQuoteHadAnAccessorial()
        {
            Report.WriteLine("Expired Quote had an accessorial other than Overlength");
            scrollpagedown();
            WaitForElementVisible(attributeName_xpath, QuoteDetails_AdditionalServicesAndAccessorials_xpath, "ADDITIONAL SERVICES AND ACCESSORIALS");
            VerifyElementVisible(attributeName_xpath, ".//*[@id='additional-services']//span", "Notification");
        }

        [Given(@"I am in the Quote Details of an expired quote")]
        public void GivenIAmInTheQuoteDetailsOfAnExpiredQuote()
        {
            string accessorial = "OVL08";
            CreateLTLExpiredQuote(accessorial);
        }

        [Given(@"I am in the Quote Details of an expired quote other than overlength")]
        public void GivenIAmInTheQuoteDetailsOfAnExpiredQuoteOtherThanOverlength()
        {
            string accessorial = "NTFY";
            CreateLTLExpiredQuote(accessorial);
        }

        [When(@"i click on the Re-quote button")]
        public void WhenIClickOnTheRe_QuoteButton()
        {
            Report.WriteLine("Click on Requote button");
            Click(attributeName_id, QuoteDetails_RequoteButton_id);
        }

        [Then(@"I will see an accessorial Overlength selected in the Shipping From section of Get Quote \(LTL\) Page")]
        public void ThenIWillSeeAnAccessorialOverlengthSelectedInTheShippingFromSectionOfGetQuoteLTLPage()
        {
            Report.WriteLine("I navigated to Get Quote(LTL) page");
            String getQuoteLTLHeadertext = Gettext(attributeName_xpath, LTLpagetitle_xpath);
            Assert.AreEqual("Get Quote (LTL)", getQuoteLTLHeadertext);
            Report.WriteLine("Verifying the Overlength binded in the Shipping From Section");
            String shippingFromAccessorial = Gettext(attributeName_xpath, LTL_SelectedAccessorialsInShipFrom_Xpath);
            Assert.AreEqual("Overlength", shippingFromAccessorial);
        }

        [Then(@"I will see the selected accessorial in the Shipping From section of Get Quote \(LTL\) Page")]
        public void ThenIWillSeeTheSelectedAccessorialInTheShippingFromSectionOfGetQuoteLTLPage()
        {
            Report.WriteLine("I navigated to Get Quote(LTL) page");
            String getQuoteLTLHeadertext = Gettext(attributeName_xpath, LTLpagetitle_xpath);
            Assert.AreEqual("Get Quote (LTL)", getQuoteLTLHeadertext);
            Report.WriteLine("Verifying the accessorial binded in the Shipping From Section");
            String shippingFromAccessorial = Gettext(attributeName_xpath, LTL_SelectedAccessorialsInShipFrom_Xpath);
            Assert.AreEqual("Notification", shippingFromAccessorial);
        }
        public void GetRandomQuoteNum()
        {
            Random rnd = new Random();
            int myRandomNo = rnd.Next(10000000, 99999999);
            quoteNumber = "QTWB" + myRandomNo.ToString();
        }
        public void CreateLTLExpiredQuote(string accessorial)
        {
            Report.WriteLine("Click on Quote Icon");
            Click(attributeName_id, QuoteIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Select Customer from dropdown");
            Click(attributeName_xpath, QuoteList_CustomerDropdown_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CustomerDropdownValues_Xpath));
            for (int i = 1; i <= DropDownList.Count; i++)
            {
                int j = i - 1;
                if (DropDownList[j].Text == customerName)
                {
                    DropDownList[j].Click();
                    break;
                }
            }

            pickUpDate = DateTime.UtcNow.AddDays(-5).ToString("MM/dd/yyyy HH:mm");
            //Generate Random quote Number
            GetRandomQuoteNum();
            //Create a Quote using API
            CreateLTLQuote createQuote = new CreateLTLQuote();
            XElement requestxml = createQuote.CreateQuoteXmlWithAccessorial(quoteNumber, pickUpDate, customerName, accessorial);
            BuildHttpClient client = new BuildHttpClient();
            HttpClient buildClient = client.BuildHttpClientWithHeaders(customerName, "application/xml");
            HttpResponseMessage responseMessage = buildClient.PostAsXmlAsync<XElement>("MercuryGate/ShipmentImport", requestxml).Result;
            if (responseMessage.IsSuccessStatusCode)
            {
                XElement responseXml = responseMessage.Content.ReadAsAsync<XElement>().Result;
                refreshBrowser();
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Quote is created");
                SendKeys(attributeName_id, QuoteList_Search_Box_Id, quoteNumber);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, QuoteList_TopGrid_expandquote_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("LTL quote is expanded");
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
