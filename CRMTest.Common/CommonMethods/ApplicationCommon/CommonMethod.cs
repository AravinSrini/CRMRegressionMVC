using CRMTest.Common.PageObjects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace CRMTest.Common.CommonMethods.ApplicationCommon
{
    public class CommonMethod : Quotelist
    {
        public static IWebDriver driver;

        public void WaitForPageLoad(IWebDriver driver)
        {
            object contentState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState");

            while (!contentState.ToString().Equals("complete") || !((IJavaScriptExecutor)driver).ExecuteScript("return $.active").ToString().Equals("0"))
            {
                Thread.Sleep(3000);
                contentState = ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState");
            }
        }

        public void Login_CRMApplication(string Username, string Password)
        {
            
            Report.WriteLine("Launch URL");
           
            driver = new ChromeDriver("C:\\Users\\aravinthan.s\\Downloads\\chromedriver_win32\\");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com");
            driver.Manage().Window.Maximize();
           
            //bool visible = IsElementPresent(attributeName_xpath, ".//*[@id='cookiescript_accept']", "cookie");

            //if (visible == true)
            //{
                //Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            //}

            //Report.WriteLine("Land on Homepage");

            WClickElement("id", SignIn_Id,"SignIn Button",driver);
            //Report.WriteLine("Enter valid Username and Password and click on Log in");
            WaitForPageLoad(driver);
            //WaitForElementVisible(attributeName_id, IDP_Username_Id, "UserName");
            WSendKeys("id", IDP_Username_Id, "Username",driver, Username);
            WSendKeys("id", IDP_Password_Id, "Password",driver, Password);

            WClickElement("xpath", IDP_Login_Xpath, "SignIn Button", driver);
     
            WaitForPageLoad(driver);
           
           
        }

   
    }

}   

