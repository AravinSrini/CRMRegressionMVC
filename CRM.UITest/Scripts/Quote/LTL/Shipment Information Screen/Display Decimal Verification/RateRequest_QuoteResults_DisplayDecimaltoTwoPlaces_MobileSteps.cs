using System;
using System.Threading;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class RateRequest_QuoteResults_DisplayDecimaltoTwoPlaces_MobileSteps : ObjectRepository
    {
        [When(@"I enter decimal values in (.*)")]
        public void WhenIEnterDecimalValuesIn(string ShipmentValue)
        {
            Report.WriteLine("Shipment Value Text box should accept decimal values");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, ShipmentValue);
        }

        [Then(@"I must be displayed with two decimal places of Rate and Insured Rate")]
        public void ThenIMustBeDisplayedWithTwoDecimalPlacesOfRateAndInsuredRate()
        {
            IList<IWebElement> standardratelist = GlobalVariables.webDriver.FindElements(By.XPath(ltlrate_mobile_xpath));

            if (standardratelist.Count > 0)
            {
                List<string> standardratelist1 = new List<string>();
                foreach (IWebElement element in standardratelist)
                {
                    standardratelist1.Add((element.Text).ToString().Remove(0, 9));
                }

                int size = standardratelist1.Count;
                for (int i = 0; i < size; i++)
                {
                    string[] a = standardratelist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Report.WriteLine("Standard Rates in Rate Results page displaying with Decimal to Two Places");
                }
            }

            IList<IWebElement> insuredratelist = GlobalVariables.webDriver.FindElements(By.XPath(ltlinsuredrate_mobile_xpath));

            if (insuredratelist.Count > 0)
            {
                List<string> insuredratelist1 = new List<string>();
                foreach (IWebElement element in insuredratelist)
                {
                    insuredratelist1.Add((element.Text).ToString().Remove(0, 9));
                }

                int size = insuredratelist1.Count;
                for (int i = 0; i < size; i++)
                {
                    string[] a = insuredratelist1[i].Split(new char[] { '.' });
                    int decimals = a[1].Length;
                    int expectedlenght = 2;
                    Assert.AreEqual(decimals, expectedlenght);
                    Report.WriteLine("Insured Rates in Rate Results page displaying with Decimal to Two Places");
                }
            }
        }
    }
}
