using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;

namespace CRMRegressionSuite.ApplicationWrapperMethods.SeleniumWrapperMethods
{
    class SeleniumCommonFuntions
    {
        string LocatorValue = string.Empty;
        string LocatorType = string.Empty;

        public IWebElement selectByLocatorType(string LocatorValue, string LocatorType)
        {

            this.LocatorValue = LocatorValue;
            this.LocatorType = LocatorType;
            
            
            IWebElement element = null;
            
            try
            {

                switch (LocatorType.ToLower())
                {
                    case "id":
                        element = GlobalVariables.webDriver.FindElement(By.Id(LocatorValue));
                        break;
                    case "xpath":
                        element = GlobalVariables.webDriver.FindElement(By.XPath(LocatorValue));
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
                Report.WriteLine("No such element found or dislayed"+E);
                
                return null;
            }
            catch (ElementNotInteractableException E)
            {
                
                new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("Locator")));
                ((IJavaScriptExecutor)GlobalVariables.webDriver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
                Thread.Sleep(200);
                return selectByLocatorType(LocatorValue, LocatorType);
            }


            catch (Exception E)
            {
                Report.WriteFailure("Exception occured while finding the element. Exception is " + E);

                return null;
            }

            return element;
        }




        public void WebElementClick(String LocatorValue, String LocatorType, String elementName)
        {
            try
            {

                IWebElement Element = selectByLocatorType(LocatorValue, LocatorType);
                Element.Click();


            }
            catch (StaleElementReferenceException E)
            {
                int Count = 1;
                //Try for 3 times
                if(Count<=1)
                {
                    IWebElement Element = selectByLocatorType(LocatorValue, LocatorType);
                    Element.Click();
                    Count =2;
                }
                
            }

            catch (ElementClickInterceptedException E)
            {
                new WebDriverWait(GlobalVariables.webDriver, TimeSpan.FromSeconds(20)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("Locator")));

                IWebElement Element = selectByLocatorType(LocatorValue, LocatorType);
                Element.Click();
            }

            catch (Exception E)
            {
                Report.WriteFailure("Exception occured in Webelement click Exception is " + E);

            }
        }

     
    }
}
