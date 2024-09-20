using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Results
{
    [Binding]
    public  class ShipmentResults_LTL_MVC5_InsuredColumnSortArrowsSteps : AddShipments
    {
        [When(@"I must be naviagted to the Shipment Results page")]
        public void WhenIMustBeNaviagtedToTheShipmentResultsPage()
        {
            Report.WriteLine("I must be landed to the Shipment Results Page");
            WaitForElementVisible(attributeName_xpath, ShipResults_PageHeaderText_xpath, "Shipment Results (LTL)");
            VerifyElementPresent(attributeName_xpath, ShipResults_PageHeaderText_xpath, "Shipment Results (LTL)");

        }

        [When(@"I enter the (.*) and click on show Isnured Rate button")]
        public void WhenIEnterTheAndClickOnShowIsnuredRateButton(string Insured_value)
        {
            Report.WriteLine("I enter the Insured Value amount");
            SendKeys(attributeName_id, ShipResults_INsuredValue_Id, Insured_value);

            Report.WriteLine("I click on Show Insured Rate button");
            Click(attributeName_id, ShipResults_ShowInsuredRateButton_Id);
        }
        [When(@"I should see the Insured Rate column in the List")]
        public void WhenIShouldSeeTheInsuredRateColumnInTheList()
        {
            Report.WriteLine("I should see the Insured Rate column in grid");
            VerifyElementPresent(attributeName_xpath, ShipResults_RateColumn_Xpath, "Insured Rate column");

        }

        [Then(@"I should be able to sort Insured Rate column in ascending and descending order")]
        public void ThenIShouldBeAbleToSortInsuredRateColumnInAscendingAndDescendingOrder()
        {
            int row = GetCount(attributeName_xpath,ShipResults_Both_InsuredRateColumn_Xpath);
            if(row >= 1)
            {
                List<decimal> ascSort = new List<decimal>();
                List<decimal> desSort = new List<decimal>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, ShipResults_RateColumn_Xpath);

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Both_InsuredRateColumn_Xpath));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }
                Click(attributeName_xpath, ShipResults_RateColumn_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Both_InsuredRateColumn_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Insured rate column");
            }

            
        }

        [When(@"I should see the Insured Rate column in Guaranteed Rate section")]
        public void WhenIShouldSeeTheInsuredRateColumnInGuaranteedRateSection()
        {
            Report.WriteLine("I should see the Insured Rate Column in Guaranteed Rate Section");

            scrollElementIntoView(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath);

            VerifyElementPresent(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath, "Insured Rate");
        }

        [Then(@"I should be able to sort Guaranteed Insured Rate column in ascending and descending order")]
        public void ThenIShouldBeAbleToSortGuaranteedInsuredRateColumnInAscendingAndDescendingOrder()
        {
            int row = GetCount(attributeName_xpath, ShipResults_Both_GuaranteedInsuredRateColumn_Xpath);
            if (row >= 1)
            {
                List<decimal> ascSort = new List<decimal>();
                List<decimal> desSort = new List<decimal>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath);

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Both_GuaranteedInsuredRateColumn_Xpath));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }
                Click(attributeName_xpath, ShipResults_GuaranteedColumnHeader_RATE_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Both_GuaranteedInsuredRateColumn_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Insured rate column in Guaranteed Rate Section");
            }
        }



    }
}
