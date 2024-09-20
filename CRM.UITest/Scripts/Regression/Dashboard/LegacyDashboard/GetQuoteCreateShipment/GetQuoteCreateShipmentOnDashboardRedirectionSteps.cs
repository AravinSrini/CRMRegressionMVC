using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Regression.Dashboard.LegacyDashboard.GetQuoteCreateShipment
{
    [Binding]
    public sealed class GetQuoteCreateShipmentOnDashboardRedirectionSteps : ObjectRepository
    {
        [When(@"I choose (.*) radio button")]
        public void WhenIChooseLTLRadioButtonAndClickOnGetQuoteButton(string serviceOption)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='showRate']//input[@value='" + serviceOption + "']"));
            WebDriverHelpers.ClickElement(element);
        }

        [When(@"I choose Domestic Forwarding radio button and choose (.*) for domestic forwarding quote")]
        public void WhenIChooseDomesticForwardingRadioButtonAndChooseNextFlightOut(string optionType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='showRate']//input[@value='Domestic Forwarding']"));
            WebDriverHelpers.ClickElement(element);
            Thread.Sleep(500);
            Click(attributeName_id, "domesticForwardRateselect");
            Click(attributeName_xpath, "//select[@id='domesticForwardRateselect']/option[text()='" + optionType + "']");
        }

        [When(@"I choose International radio button and choose (.*) and (.*) for international quote")]
        public void WhenIChooseDomesticForwardingRadioButtonAndChooseNextFlightOutForInternalQuote(string optionType, string additionalType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath("//div[@id='showRate']//input[@value='International']"));
            WebDriverHelpers.ClickElement(element);
            Thread.Sleep(500);
            Click(attributeName_id, "internationalRateSelect");
            Click(attributeName_xpath, "//select[@id='internationalRateSelect']//option[text()='" + optionType + "']");

            if(optionType.Equals("Air - Import") || optionType.Equals("Air - Export"))
                Click(attributeName_id, "airRateSelect");
            else
                Click(attributeName_id, "oceanRateSelect");

            Click(attributeName_xpath, "//div[@id='intRate']//option[text()='" + additionalType + "']");
        }

        [When(@"click on GetQuote button on the dashboard")]
        public void WhenClickOnGetQuoteButtonOnTheDashboard()
        {
            Thread.Sleep(500);
            Click(attributeName_xpath, GetQuoteButton_Xpath);
        }

        [Then(@"I should be navigated to get quote page for the service (.*)")]
        public void ThenIShouldBeNavigatedToGetQuotePageForTheService(string quotePageHeaderName)
        {
            Report.WriteLine("Verify the Navigation to correct page for the service");
            if(quotePageHeaderName == "Get Quote (LTL)")
                Verifytext(attributeName_xpath, "//*[text()='" + quotePageHeaderName + "']", quotePageHeaderName);
            else
                Verifytext(attributeName_xpath, "//*[@id='h-mode']", "Service: " + quotePageHeaderName);
        }

        [Then(@"I will see the type for the quote as (.*)")]
        public void ThenIWillSeeTheTypeForTheQuoteAs(string quoteType)
        {
            Report.WriteLine("Verify the quote type is correct");
            Verifytext(attributeName_xpath, "//span[@class='int-dom type']", quoteType);
        }

    }
}
