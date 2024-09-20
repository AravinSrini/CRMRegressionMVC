using System;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_GridDisplay 
{
    [Binding]
    public class QuoteListPageColumn_SortOptionSteps : Quotelist
    {
        [Then(@"I should be able to view and sort Date submitted column values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortDateSubmittedColumnValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            IList<IWebElement> DateSubmittedColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_DateSubmittedAll_Values_Xpath));
            if (DateSubmittedColumn_InitialValues.Count > 0)
            {
                List<string> InitialDateSubmittedListValues = new List<string>();
                foreach (IWebElement element in DateSubmittedColumn_InitialValues)
                {
                    InitialDateSubmittedListValues.Add((element.Text).ToString());
                }

                InitialDateSubmittedListValues.Reverse();
                Click(attributeName_xpath, QuoteList_DateSubmittedColumnClick_Xpath);
                IList<IWebElement> DateSubmittedAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_DateSubmittedAll_Values_Xpath));
                List<string> AscendingSortedDateSubmittedValues = new List<string>();
                foreach (IWebElement element in DateSubmittedAscendingValues)
                {
                    AscendingSortedDateSubmittedValues.Add((element.Text).ToString());
                }

                if (InitialDateSubmittedListValues[i].Equals(AscendingSortedDateSubmittedValues[i]))
                {
                    Report.WriteLine("Date Submitted Column is in ascending Order");

                }
                else
                {
                    Report.WriteLine("Date Submitted Column is not in ascending order");

                }

                AscendingSortedDateSubmittedValues.Reverse();
                Click(attributeName_xpath, QuoteList_DateSubmittedColumnClick_Xpath);
                IList<IWebElement> DateSubmittedDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_DateSubmittedAll_Values_Xpath));
                List<string> DescendingSortedDateSubmittedValues = new List<string>();
                foreach (IWebElement element in DateSubmittedDescendingVlaues)
                {
                    DescendingSortedDateSubmittedValues.Add((element.Text).ToString());
                }

                if (AscendingSortedDateSubmittedValues[i].Equals(DescendingSortedDateSubmittedValues[i]))
                {
                    Report.WriteLine("Date Submitted is in descending Order");

                }
                else
                {
                    Report.WriteLine("Date Submitted is not in descending order");

                }

            }

        }

        [Then(@"I should be able to view and sort Station/Customer name values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortStationCustomerNameValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            Click(attributeName_xpath, QuoteList_StationOrCustomerNameClick_Xpath);
            IList<IWebElement> StationOrCustomerColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StationOrCustomerNameAll_Values_Xpath));
            if (StationOrCustomerColumn_InitialValues.Count > 0)
            {
                List<string> InitialStationOrCustomerListValues = new List<string>();
                foreach (IWebElement element in StationOrCustomerColumn_InitialValues)
                {
                    InitialStationOrCustomerListValues.Add((element.Text).ToString());
                }

                InitialStationOrCustomerListValues.Reverse();
                Click(attributeName_xpath, QuoteList_StationOrCustomerNameClick_Xpath);
                IList<IWebElement> StationOrCustomerDescendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StationOrCustomerNameAll_Values_Xpath));
                List<string> DescendingSortedStationOrCustomerValues = new List<string>();
                foreach (IWebElement element in StationOrCustomerDescendingValues)
                {
                    DescendingSortedStationOrCustomerValues.Add((element.Text).ToString());
                }

                if (InitialStationOrCustomerListValues[i].Equals(DescendingSortedStationOrCustomerValues[i]))
                {
                    Report.WriteLine("Station/Customer Column is in descending Order");

                }
                else
                {
                    Report.WriteLine("Station/Customer Column is not in descending order");

                }

                DescendingSortedStationOrCustomerValues.Reverse();
                Click(attributeName_xpath, QuoteList_StationOrCustomerNameClick_Xpath);
                IList<IWebElement> StationOrCustomerAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StationOrCustomerNameAll_Values_Xpath));
                List<string> AscendingSortedStationOrCustomerValues = new List<string>();
                foreach (IWebElement element in StationOrCustomerAscendingVlaues)
                {
                    AscendingSortedStationOrCustomerValues.Add((element.Text).ToString());
                }

                if (DescendingSortedStationOrCustomerValues[i].Equals(AscendingSortedStationOrCustomerValues[i]))
                {
                    Report.WriteLine("Station/Customer is in ascending Order");

                }
                else
                {
                    Report.WriteLine("Station/Customerd is not in ascending order");

                }

            }
        }
        
        [Then(@"I should be able to view and sort Request Number column values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortRequestNumberColumnValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            Click(attributeName_xpath, QuoteList_RequestNumberClick_Xpath);
            IList<IWebElement> RequestedNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
            if (RequestedNumberColumn_InitialValues.Count > 0)
            {
                List<string> InitialRequestedNumberListValues = new List<string>();
                foreach (IWebElement element in RequestedNumberColumn_InitialValues)
                {
                    InitialRequestedNumberListValues.Add((element.Text).ToString());
                }

                InitialRequestedNumberListValues.Reverse();
                Click(attributeName_xpath, QuoteList_RequestNumberClick_Xpath);
                IList<IWebElement> RequestedNumberDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
                List<string> DecendingSortedRequestedNumberValues = new List<string>();
                foreach (IWebElement element in RequestedNumberDecendingValues)
                {
                    DecendingSortedRequestedNumberValues.Add((element.Text).ToString());
                }

                if (InitialRequestedNumberListValues[i].Equals(DecendingSortedRequestedNumberValues[i]))
                {
                    Report.WriteLine("Requested Number Column is in descending Order");

                }
                else
                {
                    Report.WriteLine("Requested Number Column is not in descending order");

                }

                DecendingSortedRequestedNumberValues.Reverse();
                Click(attributeName_xpath, QuoteList_RequestNumberClick_Xpath);
                IList<IWebElement> RequestedNumberAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestNumberAll_Values_Xpath));
                List<string> AscendingSortedRequestedNumberValues = new List<string>();
                foreach (IWebElement element in RequestedNumberAscendingVlaues)
                {
                    AscendingSortedRequestedNumberValues.Add((element.Text).ToString());
                }

                if (DecendingSortedRequestedNumberValues[i].Equals(AscendingSortedRequestedNumberValues[i]))
                {
                    Report.WriteLine("Requested Number is in ascending Order");

                }
                else
                {
                    Report.WriteLine("Requested Number is not in ascending order");

                }

            }
        }

        [When(@"I select display type from the '(.*)'")]
        public void WhenISelectDisplayTypeFromThe(string dropdown)
        {
            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, dropdown);

        }


        [Then(@"I should be able to view and sort Status column values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortStatusColumnValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            IList<IWebElement> StatusColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StatusAll_Values_Xpath));
            if(StatusColumn_InitialValues.Count >0)
            {
                List<string> InitialStatusListValues = new List<string>();
                foreach (IWebElement element in StatusColumn_InitialValues)
                {
                    InitialStatusListValues.Add((element.Text).ToString());
                }

                InitialStatusListValues.Sort();
                Click(attributeName_xpath, QuoteList_StatusClick_Xpath);
                IList<IWebElement> StatusAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StatusAll_Values_Xpath));
                List<string> AscendingSortedStatusValues = new List<string>();
                foreach (IWebElement element in StatusAscendingValues)
                {
                    AscendingSortedStatusValues.Add((element.Text).ToString());
                }

                if (InitialStatusListValues[i].Equals(AscendingSortedStatusValues[i]))
                {
                    Report.WriteLine("Status Column is in ascending Order");
                   
                }
                else
                {
                    Report.WriteLine("Status Column is not in ascending order");
                   
                }

                AscendingSortedStatusValues.Reverse();
                Click(attributeName_xpath, QuoteList_StatusClick_Xpath);
                IList<IWebElement> StatusDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StatusAll_Values_Xpath));
                List<string> DescendingSortedStatusValues = new List<string>();
                foreach(IWebElement element in StatusDescendingVlaues)
                {
                    DescendingSortedStatusValues.Add((element.Text).ToString());
                }

                if (AscendingSortedStatusValues[i].Equals(DescendingSortedStatusValues[i]))
                {
                    Report.WriteLine("Status Column is in descending Order");

                }
                else
                {
                    Report.WriteLine("Status Column is not in descending order");

                }

            }

        }

        [Then(@"I should be able to view and sort Service column values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortServiceColumnValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            IList<IWebElement> ServiceColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_ServiceAll_Values_Xpath));
            if (ServiceColumn_InitialValues.Count > 0)
            {
                List<string> InitialServiceListValues = new List<string>();
                foreach (IWebElement element in ServiceColumn_InitialValues)
                {
                    InitialServiceListValues.Add((element.Text).ToString());
                }

                InitialServiceListValues.Sort();
                Click(attributeName_xpath, QuoteList_ServiceClick_Xpath);
                IList<IWebElement> ServiceAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_ServiceAll_Values_Xpath));
                List<string> AscendingSortedServiceValues = new List<string>();
                foreach (IWebElement element in ServiceAscendingValues)
                {
                    AscendingSortedServiceValues.Add((element.Text).ToString());
                }

                if (InitialServiceListValues[i].Equals(AscendingSortedServiceValues[i]))
                {
                    Report.WriteLine("Service Column is in ascending Order");

                }
                else
                {
                    Report.WriteLine("Service Column is not in ascending order");

                }

                AscendingSortedServiceValues.Reverse();
                Click(attributeName_xpath, QuoteList_ServiceClick_Xpath);
                IList<IWebElement> ServiceDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_ServiceAll_Values_Xpath));
                List<string> DescendingSortedServiceValues = new List<string>();
                foreach (IWebElement element in ServiceDescendingVlaues)
                {
                    DescendingSortedServiceValues.Add((element.Text).ToString());
                }

                if (AscendingSortedServiceValues[i].Equals(DescendingSortedServiceValues[i]))
                {
                    Report.WriteLine("Service is in descending Order");

                }
                else
                {
                    Report.WriteLine("Service is not in descending order");

                }

            }
        }
        
        [Then(@"I should be able to view and sort Carrier Name column values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortCarrierNameColumnValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            IList<IWebElement> CarrierNameColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CarrierNameAll_Values_Xpath));
            if (CarrierNameColumn_InitialValues.Count > 0)
            {
                List<string> InitialCarrierNameListValues = new List<string>();
                foreach (IWebElement element in CarrierNameColumn_InitialValues)
                {
                    InitialCarrierNameListValues.Add((element.Text).ToString());
                }

                InitialCarrierNameListValues.Sort();
                Click(attributeName_xpath, QuoteList_CarrierNameClick_Xpath);
                IList<IWebElement> CarrierNameAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CarrierNameAll_Values_Xpath));
                List<string> AscendingSortedCarrierNameValues = new List<string>();
                foreach (IWebElement element in CarrierNameAscendingValues)
                {
                    AscendingSortedCarrierNameValues.Add((element.Text).ToString());
                }

                if (InitialCarrierNameListValues[i].Equals(AscendingSortedCarrierNameValues[i]))
                {
                    Report.WriteLine("Carrier Name Column is in ascending Order");

                }
                else
                {
                    Report.WriteLine("Carrier Name Column is not in ascending order");

                }

                AscendingSortedCarrierNameValues.Reverse();
                Click(attributeName_xpath, QuoteList_CarrierNameClick_Xpath);
                IList<IWebElement> CarrierNameDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_CarrierNameAll_Values_Xpath));
                List<string> DescendingSortedCarrierNameValues = new List<string>();
                foreach (IWebElement element in CarrierNameDescendingVlaues)
                {
                    DescendingSortedCarrierNameValues.Add((element.Text).ToString());
                }

                if (AscendingSortedCarrierNameValues[i].Equals(DescendingSortedCarrierNameValues[i]))
                {
                    Report.WriteLine("Carrier Name is in descending Order");

                }
                else
                {
                    Report.WriteLine("Carrier Name is not in descending order");

                }

            }
        }
        
        [Then(@"I should be able to view and sort Rates column values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortRatesColumnValuesInAscendingAndDescendingOrder()
        {
            int i = 0;
            IList<IWebElement> RatesColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RatesAll_Values_Xpath));
            if (RatesColumn_InitialValues.Count > 0)
            {
                List<string> InitialRatesListValues = new List<string>();
                foreach (IWebElement element in RatesColumn_InitialValues)
                {
                    InitialRatesListValues.Add((element.Text).ToString());
                }

                InitialRatesListValues.Sort();
                Click(attributeName_xpath, QuoteList_RatesClick_Xpath);
                IList<IWebElement> RatesAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RatesAll_Values_Xpath));
                List<string> AscendingSortedRatesValues = new List<string>();
                foreach (IWebElement element in RatesAscendingValues)
                {
                    AscendingSortedRatesValues.Add((element.Text).ToString());
                }

                if (InitialRatesListValues[i].Equals(AscendingSortedRatesValues[i]))
                {
                    Report.WriteLine("Rates Column is in ascending Order");

                }
                else
                {
                    Report.WriteLine("Rates Column is not in ascending order");

                }

                AscendingSortedRatesValues.Reverse();
                Click(attributeName_xpath, QuoteList_RatesClick_Xpath);
                IList<IWebElement> RatesDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RatesAll_Values_Xpath));
                List<string> DescendingSortedRatesValues = new List<string>();
                foreach (IWebElement element in RatesDescendingVlaues)
                {
                    DescendingSortedRatesValues.Add((element.Text).ToString());
                }

                if (AscendingSortedRatesValues[i].Equals(DescendingSortedRatesValues[i]))
                {
                    Report.WriteLine("Rates is in descending Order");

                }
                else
                {
                    Report.WriteLine("Rates is not in descending order");

                }

            }
        }
    }
}
