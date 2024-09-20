using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.CommonMethods
{
    class CommonmethodFocus
    {
        public  Boolean IsElementFocused(string Xpath)
        {
            IWebElement _activeElement = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            string ElementXpath = _activeElement.GetAttribute("Xpath");
            return ElementXpath.Equals(Xpath);
        }

        public void VerifyFocus(string element, string elementXpath)
        {
            if (string.IsNullOrEmpty(element))
            {
                if (IsElementFocused(elementXpath))
                {
                    Assert.IsTrue(true);
                }
                else
                {
                    Assert.IsFalse(false);
                }

            }
        }


    }
}
