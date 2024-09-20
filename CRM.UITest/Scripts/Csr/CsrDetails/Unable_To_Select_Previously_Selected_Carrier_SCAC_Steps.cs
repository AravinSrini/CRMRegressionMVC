using System.Linq;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;

namespace CRM.UITest.Scripts.Csr.CsrDetails
{
    [Binding]
    public class Unable_To_Select_Previously_Selected_Carrier_SCAC_Steps : Submit_CSR
    {
        [When(@"I delete the ""(.*)"" carrier")]
        public void WhenIDeleteTheCarrier(int carrierNum)
        {
            Report.WriteLine("Deleting the " + carrierNum + " carrier");
            Click(attributeName_xpath, "//*[@id='addtionalItem-" + (carrierNum - 1) + "']/div/div[7]/span/a");
            WaitForElementNotPresent(attributeName_xpath, "//*[@id='addtionalItem-" + (carrierNum - 1) + "']/div/div[7]/span/a", "Delete Carrier-Specific Gainshare Button");
        }

        [When(@"I click Add Carrier-Specific Gainshare Pricing")]
        public void WhenIClickAddCarrier_SpecificGainsharePricing()
        {
            Report.WriteLine("Clicking Add Carrier-Specific Gainshare Pricing");
            Click(attributeName_xpath, Gainshare_Add_Carrier_Pricing_Xpath);
        }

        [Then(@"the carrier ""(.*)"" will be an available SCAC option for the ""(.*)"" carrier")]
        public void ThenTheCarrierWillBeAnAvailableSCACOptionForTheCarrier(string carrierScac, int carrierNum)
        {
            bool present = false;
            Report.WriteLine("Searching for the SCAC code " + carrierScac);
            scrollElementIntoView(attributeName_xpath, "//*[@id='carrier_scac_code_" + carrierNum + "_chosen']");
            Click(attributeName_xpath, "//*[@id='carrier_scac_code_" + carrierNum + "_chosen']");
            List<IWebElement> carrierScacCodes = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='carrier_scac_code_" + carrierNum + "_chosen']")).ToList();
            string scacs = carrierScacCodes[0].Text;
            string[] availableScacOptions = scacs.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < availableScacOptions.Count(); i++)
            {
                if(availableScacOptions[i].Equals(carrierScac))
                {
                    present = true;
                    break;
                }
            }
            if(!present)
            {
                Report.WriteFailure("SCAC code " + carrierScac + " not present in Carrier Scac Code dropdown");
            }
            else
            {
                Report.WriteLine("Test Passed: SCAC code " + carrierScac + " found in SCAC dropdown");
            }
        }


    }
}
