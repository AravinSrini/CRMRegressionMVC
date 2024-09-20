using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.CommonMethods
{
    public class GetChosenAccessorials : IGetChosenAccessorials
    {
        public IList<IWebElement> GetShippingFromChosenAccessorials()
        {
            IList<IWebElement> chosenAccessorials = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='shippingfromaccessorial_chosen']/ul/li[@class='search-choice']"));

            return chosenAccessorials;
        }

        public IList<IWebElement> GetShippingToChosenAccessorials()
        {
            IList<IWebElement> chosenAccessorials = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='shippingtoaccessorial_chosen']/ul/li[@class='search-choice']"));

            return chosenAccessorials;
        }
    }
}
