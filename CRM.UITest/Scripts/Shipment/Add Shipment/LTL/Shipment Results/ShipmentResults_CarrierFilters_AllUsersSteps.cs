using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    public class ShipmentResults_CarrierFilters_AllUsersSteps : AddShipments
    {
        [Then(@"I will see the (.*) and (.*) carrier filter")]
        public void ThenIWillSeeTheAndCarrierFilter(string Quickest_Service, string Least_Cost)
        {
            Report.WriteLine("I will see the Quickest service and Least Cost");
            VerifyElementPresent(attributeName_xpath, ShipResults_FilterCarrierBy_Xpath, "Filter Carrier By :");

            String QuickestService = Gettext(attributeName_xpath, ShipResults_QuickestService_Xpath);
            String LeastCost = Gettext(attributeName_xpath, ShipResults_LeastCost_Xpath);
            Assert.AreEqual(Quickest_Service, QuickestService);
            Assert.AreEqual(Least_Cost, LeastCost);

        }
        [Then(@"Verified that Quickest Service carrier filter is selected by default")]
        public void ThenVerifiedThatQuickestServiceCarrierFilterIsSelectedByDefault()
        {
            Report.WriteLine("By default Quickest Service is selected");
            IsElementEnabled(attributeName_xpath, ShipResults_QuickestService_Xpath, "Quickest Service");
        }

        [Then(@"Verify that by selecting the Least cost on Result page will resort to display the carrier options begning with least cost (.*)")]
        public void ThenVerifyThatBySelectingTheLeastCostOnResultPageWillResortToDisplayTheCarrierOptionsBegningWithLeastCost(string Usertype)
        {
            if (Usertype == "Internal")
            {
                List<decimal> desSort = new List<decimal>();
                List<decimal> ascSort = new List<decimal>();

                Report.WriteLine("Reading the values from the rate columns in descending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_RateColumnValues_Xpath));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }

                desSort.Sort();

                Report.WriteLine("Click on the Quick Sort");
                Click(attributeName_xpath, ShipResults_LeastCost_Xpath);

                Report.WriteLine("Reading the values from the rate columns after ascending sorting");
                IList<IWebElement> LeastCost = GlobalVariables.webDriver.FindElements(By.XPath(ShipResults_Internal_RateColumnValues_Xpath));
                foreach (IWebElement element in LeastCost)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }

                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < totalcarriers.Count; i++)
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
                List<decimal> desSort = new List<decimal>();
                List<decimal> ascSort = new List<decimal>();

                Report.WriteLine("Reading the values from the rate columns in descending sorting");
                IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[4]/div[1]"));
                foreach (IWebElement element in totalcarriers)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    desSort.Add(value);
                }

                desSort.Sort();

                Report.WriteLine("Click on the Quick Sort");
                Click(attributeName_xpath, ShipResults_LeastCost_Xpath);

                Report.WriteLine("Reading the values from the rate columns after ascending sorting");
                IList<IWebElement> LeastCost = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentResultTable']/tbody/tr/td[4]/div[1]"));
                foreach (IWebElement element in LeastCost)
                {
                    decimal value = Convert.ToDecimal(element.Text.Replace("$", string.Empty));
                    ascSort.Add(value);
                }

                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < totalcarriers.Count; i++)
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
        }

        [Then(@"Verify that by selecting the Quickest Service on results page will resort to display the carrier options begning with the lowest number of service days and least cost (.*)")]
        public void ThenVerifyThatBySelectingTheQuickestServiceOnResultsPageWillResortToDisplayTheCarrierOptionsBegningWithTheLowestNumberOfServiceDaysAndLeastCost(string Usertype)
        {
            if (Usertype == "Internal")
            {

                List<int> nn = new List<int>();
                List<int> servicedaysd = new List<int>();

                List<decimal> sd = new List<decimal>();

                IList<IWebElement> LeastCost = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='ShipmentResultTable']/tbody/tr/td[2]/div[1]"));


                foreach (IWebElement element in LeastCost)
                {
                    decimal value = Convert.ToDecimal(element.Text);
                    sd.Add(value);
                }


                for (int i = 0; i < sd.Count; i++)
                {
                    if (sd[i] < sd[i++])
                    {

                    }
                }

                for (int i = 0; i < servicedaysd.Count; i++)
                {

                    for (int j = i + 1; j < servicedaysd.Count; j++)
                    {

                        if (servicedaysd[i] == servicedaysd[j])

                        {
                            string Ratevalue = Gettext(attributeName_xpath, ".//*[@id='ShipmentResultTable']/tbody/tr[" + j + "]/td[5]/div[1]");
                            int Ratevalueint = int.Parse(Ratevalue);
                            nn.Add(Ratevalueint);

                        }

                    }
                    for (int x = 0; x < nn.Count; x++)
                    {
                        if (nn[x] < nn[x++])
                        {
                            Report.WriteLine("Values in sorting order");
                        }
                        else
                        {
                            Console.WriteLine("results are not sorted");
                        }
                    }


                }
            }

            //***********************for external users ****************************************************************************//

            else

            {
               
                List<int> servicedaysd = new List<int>();

                List<decimal> sd = new List<decimal>();

                IList<IWebElement> LeastCost = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='ShipmentResultTable']/tbody/tr/td[2]/div[1]"));
                foreach (IWebElement element in LeastCost)
                {
                    decimal value = Convert.ToDecimal(element.Text);
                    sd.Add(value);
                }


                for (int i = 0; i < sd.Count; i++)
                {
                    if (sd[i] <= sd[i++])
                    {

                    }
                }

                for (int i = 0; i < sd.Count; i++)
                {
                    List<decimal> nn = new List<decimal>();
                    for (int j = i + 1; j < sd.Count; j++)
                    {

                            if (sd[i] == sd[j])

                        {
                            string Ratevalue = Gettext(attributeName_xpath, "//*[@id='ShipmentResultTable']/tbody/tr[" + j + "]/td[4]/div[1]");



                            decimal Ratevalueint = Convert.ToDecimal(Ratevalue.Replace("$", string.Empty));
                            nn.Add(Ratevalueint);
                        
                            i++;

                        }
                        else
                        if (nn.Count > 1)
                        {
                            for (int x = 0; x < nn.Count; x++)
                            {
                                if (nn[x] <= nn[x++])
                                {
                                    Report.WriteLine("Values in sorting order");
                                }
                                else
                                {
                                    Console.WriteLine("results are not sorted");
                                }
                            }
                            break;
                        }


                    }




                }
            }




        }
    }
} 
