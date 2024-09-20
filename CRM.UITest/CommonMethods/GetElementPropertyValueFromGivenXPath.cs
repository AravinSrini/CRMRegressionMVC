using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.CommonMethods
{
    public static class GetElementPropertyValueFromGivenXPath
    {
        public static string GetBackgroundColorFromGivenXPath(string xPath)
        {
            string elementBackgroundColor = "";
            var ElementWithBackgroundColour = GlobalVariables.webDriver.FindElement(By.XPath(xPath));
            elementBackgroundColor = ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color');", ElementWithBackgroundColour).ToString();
            return elementBackgroundColor;
        }
    }
}
