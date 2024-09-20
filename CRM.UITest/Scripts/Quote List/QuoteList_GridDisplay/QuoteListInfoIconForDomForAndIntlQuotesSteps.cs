using System;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Interfaces.Quote;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Helper.Implementations.QuoteList;
using System.Linq;
using System.Threading;
using CRM.UITest.Helper.Implementations.GetCSAServiceType;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_GridDisplay
{
    [Binding]
    public class QuoteListInfoIconForDomForAndIntlQuotesSteps : Quotelist
    {
        string errorMessage = string.Empty;

        [When(@"I click on Information icon")]
        public void WhenIClickOnInformationIcon()
        {
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                Report.WriteLine("Click on Information Icon");
                Thread.Sleep(2000);
                IList<IWebElement> FirstRow = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_NoOfRows_Xpath));
                Click(attributeName_id, QuoteList_InfoIcon_Id);
                Click(attributeName_id, QuoteList_InfoIcon_Id);

            }
            else
            {
                Report.WriteLine("No data found");
            }

        }


        [When(@"I pass (.*) in the serach box")]
        public void WhenIPassInTheSerachBox(string RequestedNumber)
        {
            Report.WriteLine("Pass request number");
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, RequestedNumber);
        }



        [Then(@"I must be able to view Information icon displayed next to the service type in the Service column")]
        public void ThenIMustBeAbleToViewInformationIconDisplayedNextToTheServiceTypeInTheServiceColumn()
        {
            Report.WriteLine("Display of Information Icon");
            VerifyElementPresent(attributeName_id, QuoteList_InfoIcon_Id, "Information Icon");
        }

        [Then(@"I must be able to view a pop-up modal with (.*) and (.*) values")]
        public void ThenIMustBeAbleToViewAPop_UpModalWithAndValues(string ServiceType, string ServiceLevel)
        {
            Report.WriteLine("Pop up modal display");
            string ServiceTypeUI = Gettext(attributeName_xpath, QuoteList_Info_Service_Label);

            if (ServiceTypeUI.Contains(ServiceType))
            {
                Report.WriteLine("Service Type matches");
            }
            else
            {
                Report.WriteLine("Service Type does not match");
            }

            if (ServiceTypeUI.Contains(ServiceLevel))
            {
                Report.WriteLine("Service Level matches");
            }
            else
            {
                Report.WriteLine("Service Level does not match");
            }
        }

      
        [Then(@"I should not be able to view Information Icon")]
        public void ThenIShouldNotBeAbleToViewInformationIcon()
        {
            Report.WriteLine("Information Icon Should not be present");
            Thread.Sleep(1000);
            VerifyElementNotPresent(attributeName_id, QuoteList_InfoIcon_Id, "Info");
        }


        [Then(@"The values in UI should match the API values (.*)")]
        public void ThenTheValuesInUIShouldMatchTheAPIValues(string Account)
        {

            int accID = DBHelper.GetAccountIdforAccountName(Account);
            CustomerAccount value = DBHelper.GetAccountDetails(accID);
            int csaNumb = Convert.ToInt32(value.CsaCustomerNumber);

            ICsaQuoteListByLast30Days CSAQuote = new CsaQuoteListByLast30Days();
            ShipmentListReponse APIQuotes = CSAQuote.GetCsaQuoteListByLast30Days(csaNumb, out errorMessage);

            String UIQuote = Gettext(attributeName_xpath, QuoteList_RequestedNumber_FirstValue_Xpath);
            string ActSerType = Gettext(attributeName_xpath, QuoteList_Info_Service_Label);
            string[] ServiceSplit = ActSerType.Split('\r', '\n');
            string ServiceTypeVal = ServiceSplit[4].Remove(0, 16);
            string ServiceLevelVal = ServiceSplit[8].Remove(0, 17);

            string ModeValue = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIQuote)).Select(b => b.Mode).FirstOrDefault();
            string SerValue = APIQuotes.Shipments.Where(a => a.ShipQuoteNo == Convert.ToInt32(UIQuote)).Select(b => b.ServiceLevel).FirstOrDefault();

            ServiceType val = new ServiceType();
            string expServalue = val.GetCSAServiceType(SerValue);

            if (ModeValue == "Domestic")
            {
                Assert.AreEqual(expServalue.Trim(), ServiceTypeVal.Trim());
                Assert.AreEqual("N/A", ServiceLevelVal);
            }

            else
            {
                Assert.AreEqual(ServiceTypeVal.Trim(), ModeValue.Trim());
                Assert.AreEqual(ServiceLevelVal.Trim(), expServalue.Trim());
            }


        }
    }
}


