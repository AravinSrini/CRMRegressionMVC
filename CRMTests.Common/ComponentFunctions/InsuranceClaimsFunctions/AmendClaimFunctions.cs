using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRMRegressionSuite.ApplicationWrapperMethods.SeleniumWrapperMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRMRegressionSuite.ComponentFunctions.InsuranceClaimsFunctions
{
    class AmendClaimFunctions : SeleniumCommonFuntions

    {
        public void ChooseStationNamemethod(String Stationname)
        {
            WebElementClick("Station_dropdown_xpath", "Xpath", "ChooseSationname");
            IList<IWebElement> stationValues = GlobalVariables.webDriver.FindElements(By.XPath("StatiodropdownValues_xpath"));
            int stnDropDownCount = stationValues.Count;
            for (int i = 0; i < stnDropDownCount; i++)
            {
                if (stationValues[i].Text == Stationname)
                {
                    stationValues[i].Click();
                    break;
                }
            }

        }


        public void ChooseCustomername(String CustomerName)
        {
            WebElementClick("Customerdropdown_xpath","Xpath", "ChooseCustomername");
            IList<IWebElement> customerValues = GlobalVariables.webDriver.FindElements(By.XPath("CustomerdropdownValues_xpath"));
            int custDropDownCount = customerValues.Count;
            for (int i = 0; i < custDropDownCount; i++)
            {
                if (customerValues[i].Text == CustomerName)
                {
                    customerValues[i].Click();
                    break;
                }
            }

        }


    }
}
