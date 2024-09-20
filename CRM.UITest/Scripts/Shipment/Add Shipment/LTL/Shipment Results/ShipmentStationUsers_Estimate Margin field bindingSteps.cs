using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public  class ShipmentStationUsers_Estimate_Margin_field_bindingSteps : AddShipments
    {

        [Then(@"I should see the N/A is binding for the Est margin field in shipment result page if Est margin field is not available for carrier")]
        public void ThenIShouldSeeTheNAIsBindingForTheEstMarginFieldInShipmentResultPageIfEstMarginFieldIsNotAvailableForCarrier()
        {
            int row = GetCount(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td");
            if (row >= 1)
            {

                IList<IWebElement> rowEstCost = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[4]/div[1]"));
                int rowfindNA = rowEstCost.Count();

                for (int i = 0; i < rowfindNA; i++)
                {
                    if (rowEstCost[i].Text == "N/A")
                    {

                        int rowj = i + 1;
                       
                        string ActualEstCost = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + rowj + "]/td[4]/div[1]");
                     

                        IList<IWebElement> rowEstMargin = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr//*[@class='estMargin']"));
                        int rowwithNA = rowEstMargin.Count();

                        for(int j = 0; j < rowwithNA; j++)
                        {
                            if(rowEstMargin[j].Text.Contains(ActualEstCost))
                            {

                                Report.WriteLine("N/A is binding for the Est Margin");

                            }
                            break;


                        }


                    }
                    else
                    {
                        Report.WriteLine("Est Cost is Available ");
                    }

                    break;

                    
                }

            }
            else
            {
                Report.WriteLine("No records found on Results Page");
            }
        }

        [When(@"Est margin field is not available for the carrier in Shipment result page")]
        public void WhenEstMarginFieldIsNotAvailableForTheCarrierInShipmentResultPage()
        {

            int row = GetCount(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr/td");
            if (row >= 1)
            {

                IList<IWebElement> rowEstMargin = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr//*[@class='estMargin']"));
                int rowfindNA = rowEstMargin.Count();

                for(int i = 0; i< rowfindNA; i++)
                {
                    if(rowEstMargin[i].Text.Contains("N/A"))
                    {                      
                        int rowj = i + 1;                      
                        
                        Click(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + rowj + "]//*[@id='createShipment']");                   

                    }

                    else
                    {
                        Report.WriteLine("N/A is not present for Est Margin field");
                    }
                    break;
                }
               
            }
            else
            {
                Report.WriteLine("No records found on Results Page");
            }

        }

        [When(@"I arrive on Review and Submit Shipment LTL page")]
        public void WhenIArriveOnReviewAndSubmitShipmentLTLPage()
        {
            Report.WriteLine("I arrive on Review and Submit Page");
            WaitForElementVisible(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[text()='Review and Submit Shipment (LTL)']", "Review and submit Page");
            VerifyElementPresent(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[text()='Review and Submit Shipment (LTL)']", "Review and submit Page");

        }

        [Then(@"I should see the N/A is binding for the Est margin field in Review and submit page")]
        public void ThenIShouldSeeTheNAIsBindingForTheEstMarginFieldInReviewAndSubmitPage()
        {
            Report.WriteLine("I should see the Est Margin as N/A in Carrier info section");
            scrollElementIntoView(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[@class='estmarginstyle estmarginvalue']");
            string ActualEstMargin = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']//*[@class='estmarginstyle estmarginvalue']");
            Assert.AreEqual("N/A", ActualEstMargin);
        }


    }
}
