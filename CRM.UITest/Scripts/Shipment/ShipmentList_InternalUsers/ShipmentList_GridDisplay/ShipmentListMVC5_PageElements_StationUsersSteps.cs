using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_Standardreports_AllUser
{
    [Binding]
    public class ShipmentListMVC5_PageElements_StationUsersSteps : Shipmentlist
    {
            
        [Given(@"I click on the Shipment icon")]
        public void GivenIClickOnTheShipmentIcon()
        {
            Report.WriteLine("I click on Shipment icon");
            try
            {
                Click(attributeName_xpath, ShipmentIcon_Xpath);
            }catch(Exception e)
            {
                Console.WriteLine(e);
                Thread.Sleep(60000);
            }
        }

        [When(@"I navigate to shipmentlist page")]
        public void WhenINavigateToShipmentlistPage()
        {
            Report.WriteLine("navigate to shipmentlist page");
            VerifyElementPresent(attributeName_xpath, ShipmentList_Title_Xpath,"shipmentpage");

        }


        [When(@"I click on search option")]
        public void WhenIClickOnSearchOption()
        {
            Report.WriteLine("ClickedOnSearchOption");
            Click(attributeName_xpath, ShipmentListSearchBox_XPath);
            
        }
        
        [When(@"I should be displayed with Copy icon field for LTL services")]
        public void WhenIShouldBeDisplayedWithCopyIconFieldForLTLServices()
        {
            Report.WriteLine("DisplayedWithCopyIconFieldForLTLServices");
            VerifyElementPresent(attributeName_xpath, ShipmentListGrid_CopyIcon_Xpath, "shipmentpage");
        }
        
        [When(@"I should be displayed with Return icon for LTL services")]
        public void WhenIShouldBeDisplayedWithReturnIconForLTLServices()
        {
            Report.WriteLine("DisplayedWithReturnIconForLTLServices");
            VerifyElementPresent(attributeName_xpath, ShipmentListGrid_ReturnIcon_Xpath, "shipmentpage");
        }
        
        [When(@"I click On Station/Customer Name column sort option")]
        public void WhenIClickOnStationCustomerNameColumnSortOption()
        {
            Report.WriteLine("ClickedOnStationCustomerNameColumnSortOption");
            Click(attributeName_xpath, ShipmentListGrid_StationOrCustomerNameHeader_Xpath);
        }
        
        [When(@"I click On Rates column sort option")]
        public void WhenIClickOnRatesColumnSortOption()
        {
            Report.WriteLine("ClickedOnRatesColumnSortOption");
            Click(attributeName_xpath, ShipmentListGrid_RatesHeader_Xpath);
        }
        
        [Then(@"I should be displayed with new Customer drop down list field")]
        public void ThenIShouldBeDisplayedWithNewCustomerDropDownListField()
        {
            Report.WriteLine("DisplayedWithNewCustomerDropDownListField");
            VerifyElementPresent(attributeName_xpath, ShipmentList_CustomerSelection_Xpath, "CustomerDropDownListField");
       

        }
        
        [Then(@"I should be displayed with All Customers selection binding in Customer drop down by default")]
        public void ThenIShouldBeDisplayedWithAllCustomersSelectionBindingInCustomerDropDownByDefault()
        {
            Report.WriteLine("AllCustomersSelectionBindingInCustomerDropDownByDefault");
            Verifytext(attributeName_xpath,ShipmentList_CustomerSelection_label_Xpath, "All Customers");

        }
        
        [Then(@"I should be displayed with new StationName '(.*)' option")]
        public void ThenIShouldBeDisplayedWithNewStationNameOption(string StationName)
        {
            Report.WriteLine("DisplayedWithNewStationNameOption");
            Verifytext(attributeName_xpath, ShipmentListSearchBox_stationname_Xpath, StationName.ToUpper());


        }
        
        [Then(@"I should be displayed with new CustomerName '(.*)' option")]
        public void ThenIShouldBeDisplayedWithNewCustomerNameOption(string CustomerName)
        {
            Report.WriteLine("DisplayedWithNewCustomerNameOption");
            Verifytext(attributeName_xpath, ShipmentListSearchBox_Customername_Xpath, CustomerName.ToUpper());
        }
        
        [Then(@"I should be displayed with new EstRevenue '(.*)' option")]
        public void ThenIShouldBeDisplayedWithNewEstRevenueOption(string EstRevenue)
        {
            Report.WriteLine("DisplayedWithNewEstRevenueOption");
            Verifytext(attributeName_xpath, ShipmentListSearchBox_ESTREVENUE_Xpath, EstRevenue.ToUpper());
        }
        
        [Then(@"I should be displayed with new EstCost '(.*)' option")]
        public void ThenIShouldBeDisplayedWithNewEstCostOption(string EstCost)
        {
            Report.WriteLine("DisplayedWithNewEstRevenueOption");
            Verifytext(attributeName_xpath, ShipmentListSearchBox_ESTCOST_Xpath, EstCost.ToUpper());
        }
        
        [Then(@"I should be displayed with new EstMargin '(.*)' option")]
        public void ThenIShouldBeDisplayedWithNewEstMarginOption(string EstMargin)
        {
            Report.WriteLine("DisplayedWithNewEstRevenueOption");
            Verifytext(attributeName_xpath, ShipmentListSearchBox_ESTMARGIN_Xpath, EstMargin.ToUpper());
        }
        
        [Then(@"I should be displayed with new '(.*)' column in shipment list grid")]
        public void ThenIShouldBeDisplayedWithNewColumnInShipmentListGrid(string Rates)
        {
            Report.WriteLine("DisplayedWithNewColumnInShipmentListGrid");
            VerifyElementPresent(attributeName_xpath,ShipmentListGrid_RatesAllValues_Xpath, "Ratescolumn");
            Verifytext(attributeName_xpath, ShipmentListGrid_RatesHeader_Xpath, Rates.ToUpper());

        }

        [Then(@"I should be displayed with '(.*)' column in shipment list grid")]
        public void ThenIShouldBeDisplayedWithColumnInShipmentListGrid(string StationCustomerName)
        {
            Report.WriteLine("DisplayedWithNewEstRevenueOption");
            VerifyElementPresent(attributeName_xpath, ShipmentListGrid_StationOrCustomerNameAll_Values_Xpath, "StationCustomerNamecolumn");
            Verifytext(attributeName_xpath, ShipmentListGrid_StationOrCustomerNameHeader_Xpath, StationCustomerName.ToUpper());
        }
        

        [Then(@"Station/Customer Name column should be sorted by Customer Name")]
        public void ThenStationCustomerNameColumnShouldBeSortedByCustomerName()
        {
            int i = 0;
            IList<IWebElement> StationOrCustomerColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_CustomerNameAll_Values_Xpath));
            if (StationOrCustomerColumn_InitialValues.Count > 0)
            {
                List<string> InitialStationOrCustomerListValues = new List<string>();
                foreach (IWebElement element in StationOrCustomerColumn_InitialValues)
                {
                    InitialStationOrCustomerListValues.Add((element.Text).ToString());
                }

                InitialStationOrCustomerListValues.Reverse();
                Click(attributeName_xpath, ShipmentListGrid_StationOrCustomerNameHeader_Xpath);
                IList<IWebElement> StationOrCustomerDescendingValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_CustomerNameAll_Values_Xpath));
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
                Click(attributeName_xpath, ShipmentListGrid_StationOrCustomerNameHeader_Xpath);
                IList<IWebElement> StationOrCustomerAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListGrid_CustomerNameAll_Values_Xpath));
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
        
        [Then(@"Rates column should be sorted by Est Revenue")]
        public void ThenRatesColumnShouldBeSortedByEstRevenue()
        {
            int i = 0;
            IList<IWebElement> ESTREVENUEColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(Shipment_ESTREVENUEvalueall_Xpath));
            if (ESTREVENUEColumn_InitialValues.Count > 0)
            {
                List<string> InitialESTREVENUEListValues = new List<string>();
                foreach (IWebElement element in ESTREVENUEColumn_InitialValues)
                {
                    InitialESTREVENUEListValues.Add((element.Text).ToString());
                }

                InitialESTREVENUEListValues.Reverse();
                Click(attributeName_xpath, ShipmentListGrid_RatesHeader_Xpath);
                IList<IWebElement> ESTREVENUEDescendingValues = GlobalVariables.webDriver.FindElements(By.XPath(Shipment_ESTREVENUEvalueall_Xpath));
                List<string> DescendingSortedESTREVENUEValues = new List<string>();
                foreach (IWebElement element in ESTREVENUEDescendingValues)
                {
                    DescendingSortedESTREVENUEValues.Add((element.Text).ToString());
                }

                if (InitialESTREVENUEListValues[i].Equals(DescendingSortedESTREVENUEValues[i]))
                {
                    Report.WriteLine("ESTREVENUE Column is in descending Order");

                }
                else
                {
                    Report.WriteLine("ESTREVENUE Column is not in descending order");

                }

                DescendingSortedESTREVENUEValues.Reverse();
                Click(attributeName_xpath, ShipmentListGrid_RatesHeader_Xpath);
                IList<IWebElement> ESTREVENUEAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(Shipment_ESTREVENUEvalueall_Xpath));
                List<string> AscendingSortedESTREVENUEValues = new List<string>();
                foreach (IWebElement element in ESTREVENUEAscendingVlaues)
                {
                    AscendingSortedESTREVENUEValues.Add((element.Text).ToString());
                }

                if (DescendingSortedESTREVENUEValues[i].Equals(AscendingSortedESTREVENUEValues[i]))
                {
                    Report.WriteLine("ESTREVENUE is in ascending Order");

                }
                else
                {
                    Report.WriteLine("ESTREVENUE is not in ascending order");

                }

            }

        }
    }
}
