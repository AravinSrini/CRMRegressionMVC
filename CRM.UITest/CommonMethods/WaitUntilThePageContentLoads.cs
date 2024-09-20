using System.Threading;
using OpenQA.Selenium;

namespace CRM.UITest.CommonMethods
{
    public static class WaitUntilThePageContentLoads 
    {
        public static void WaitForPageLoad(this IWebDriver driver)
        {
            object contentState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState");

            while (!contentState.ToString().Equals("complete") || !((IJavaScriptExecutor)driver).ExecuteScript("return $.active").ToString().Equals("0"))
            {
                Thread.Sleep(3000);
                contentState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState");
            }
        } 
    }
}
