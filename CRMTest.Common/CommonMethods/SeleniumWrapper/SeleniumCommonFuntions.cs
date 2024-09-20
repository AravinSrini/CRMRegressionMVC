using OpenQA.Selenium;
using System;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium.Support.UI;
using Rrd.SpecflowSelenium.Service.GenericService;


namespace CRMTest.Common.CommonMethods.SeleniumWrapper
{
    public class SeleniumCommonFuntions :GenericMethods
    {

        string LocatorValue = string.Empty;
        string LocatorType = string.Empty;
        IWebDriver driver;

        public IWebElement WFindElement( string LocatorType, string LocatorValue, IWebDriver driver)
        {

            this.LocatorValue = LocatorValue;
            this.LocatorType = LocatorType;
            this.driver = driver;

            IWebElement element = null;

            try
            {

                switch (LocatorType.ToLower())
                {
                    case "id":
                        element = driver.FindElement(By.Id(LocatorValue));
                        break;
                    case "xpath":
                        element = driver.FindElement(By.XPath(LocatorValue));
                        break;
                    case "css":
                        element = GlobalVariables.webDriver.FindElement(By.CssSelector(LocatorValue));
                        break;
                    case "classname":
                        element = GlobalVariables.webDriver.FindElement(By.ClassName(LocatorValue));
                        break;
                    case "name":
                        element = GlobalVariables.webDriver.FindElement(By.Name(LocatorValue));
                        break;
                    case "linktext":
                        element = GlobalVariables.webDriver.FindElement(By.LinkText(LocatorValue));
                        break;
                    case "tagname":
                        element = GlobalVariables.webDriver.FindElement(By.TagName(LocatorValue));
                        break;
                    case "partiallinktext":
                        element = GlobalVariables.webDriver.FindElement(By.PartialLinkText(LocatorValue));
                        break;
                    default:
                        throw new ArgumentException("Check the given locator Type in POM");
                }
            }

            catch (NoSuchElementException E)
            {
                //Report.WriteLine("No such element found or dislayed" + E);

                return null;
            }
            catch (ElementNotInteractableException E)
            {

                new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.Id(LocatorValue)));
                ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Thread.Sleep(200);
                return WFindElement(LocatorType, LocatorValue, driver);
            }
            catch (StaleElementReferenceException E)
            {

                new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.Id(LocatorValue)));
                element = WFindElement(LocatorType, LocatorValue, driver);
                //Report.WriteLine(element + " Clicked Successfully");

            }

            catch (Exception E)
            {
                //Report.WriteFailure("Exception occured while finding the element. Exception is " + E);

                return null;
            }

            return element;
        }




        public void WClickElement(string LocatorType, string LocatorValue, String ElementName,IWebDriver driver)
        {
            try
            {

                IWebElement Element = WFindElement(LocatorType, LocatorValue, driver);
                Element.Click();
                //Report.WriteLine(ElementName + " Clicked Successfully");

            }


            catch (ElementClickInterceptedException E)
            {
                new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(LocatorValue)));

                IWebElement Element = WFindElement(LocatorType, LocatorValue, driver);
                Element.Click();
                
            }

            catch (Exception E)
            {
                //Report.WriteFailure("Exception occured in Webelement click Exception is " + E);

            }
        }


        public void WSendKeys(string LocatorType, string LocatorValue, string ElementName, IWebDriver driver,string Text)
        {
            try
            {

                IWebElement Element = WFindElement(LocatorType,LocatorValue,driver);
                Element.SendKeys(Text);
                //Report.WriteLine(ElementName + " Clicked Successfully");

            }


            catch (ElementClickInterceptedException E)
            {
                new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(5)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id(LocatorValue)));

                IWebElement Element = WFindElement(LocatorType, LocatorValue, driver);
                Element.Click();

            }

            catch (Exception E)
            {
                //Report.WriteFailure("Exception occured in Webelement click Exception is " + E);

            }
        }



    }
}
