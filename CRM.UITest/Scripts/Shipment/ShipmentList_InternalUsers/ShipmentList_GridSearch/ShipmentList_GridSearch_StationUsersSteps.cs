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

namespace CRM.UITest.Scripts.Shipment.ShipmentList_InternalUsers.ShipmentList_GridSearch
{
    [Binding]
    public class ShipmentList_GridSearch_StationUsersSteps : Shipmentlist
    {

        [Then(@"I must see the expected drop down values for station Users")]
        public void ThenIMustSeeTheExpectedDropDownValuesForStationUsers()
        {
            IList<IWebElement> ActualSearchValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListSearchBox_AllDropdownValues_Xpath));
            List<string> ExpectedSearchValues = new List<string>(new string[] { "Select All", "REFERENCE NUMBER", "STATION NAME", "CUSTOMER NAME", "STATUS", "PICKUP", "DELIVERY", "SERVICE", "SERVICE LEVEL", "CARRIER NAME", "", "ORIGIN", "DESTINATION", "QUANTITY", "WEIGHT", "SERVICE TYPE", "EST REVENUE", "EST COST", "EST MARGIN %", "PO NUMBER" });
            foreach (var val in ActualSearchValues)
            {
                if (ExpectedSearchValues.Contains(val.Text))
                {
                    Report.WriteLine("Displayed" + val.Text + "drop down value is the Shipment List search value");
                }
                else
                {
                    Report.WriteLine("Search drop down Value does not exists");
                }
            }
            Verifytext(attributeName_id, ShipmentListSearchBox_ClearAll_Button_Id, "Clear All");
        }


        [When(@"I select the multiple fields as Staion Name, Customer Name, PickUp Date from the drop down")]
        public void WhenISelectTheMultipleFieldsAsStaionNameCustomerNamePickUpDateFromTheDropDown()
        {
            Report.WriteLine("Select specified multiple fields");
            Click(attributeName_xpath, ShipmentList_Search_StationName_StationUsers_xpath);
            Click(attributeName_xpath, ShipmentList_Search_CustomerName_StationUsers_xpath);
            Click(attributeName_xpath, ShipmentList_Search_PickUp_StationUsers_xpath);
            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);
        }

        [Then(@"I must be able to search the shipment by entering the Staion Name values in the search field and it should be highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchTheShipmentByEnteringTheStaionNameValuesInTheSearchFieldAndItShouldBeHighlightedInTheGrid_(string StationName)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, StationName);
            

            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1)
            {
                IList<IWebElement> SearchedStationNamehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_StationNameColumn_Highlighted_StationUsers_Xpath));
                int HighlightedStationNameCount = SearchedStationNamehighlightedValues.Count;
                foreach (var val in SearchedStationNamehighlightedValues)
                {
                    if (StationName.Contains(val.Text))
                    {
                        var colorofHighlighted_StationName_Value = GetCSSValue(attributeName_classname, ShipmentListGrid_Highlight_Class, "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_StationName_Value);
                        Report.WriteLine("Highlighted Reference Number values are appropriate");
                    }

                    else
                    {
                        Assert.Fail();
                    }

                }


            }
            else
            {
                Report.WriteLine("No Records found for the Shipment List for the logged in user so unable to test the scenario");
            }
        }

        [Then(@"I must be able to search the shipment by entering the Customer Name values in the search field and it should be highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchTheShipmentByEnteringTheCustomerNameValuesInTheSearchFieldAndItShouldBeHighlightedInTheGrid_(string CustomerName)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, CustomerName);

            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1)
            {
                IList<IWebElement> SearchedStationNamehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_CustomerNameColumn_Highlighted_StationUsers_Xpath));
                int HighlightedStationNameCount = SearchedStationNamehighlightedValues.Count;
                foreach (var val in SearchedStationNamehighlightedValues)
                {
                    if (CustomerName.Contains(val.Text))
                    {
                        var colorofHighlighted_CustomerName_Value = GetCSSValue(attributeName_classname, ShipmentListGrid_Highlight_Class, "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_CustomerName_Value);
                        Report.WriteLine("Highlighted Reference Number values are appropriate");
                    }

                    else
                    {
                        Assert.Fail();
                    }

                }


            }
            else
            {
                Report.WriteLine("No Records found for the Shipment List for the logged in user so unable to test the scenario");
            }
        }

        [Then(@"I must be able to search the shipment by entering the PickUp Date values in the search field and it should be highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchTheShipmentByEnteringThePickUpDateValuesInTheSearchFieldAndItShouldBeHighlightedInTheGrid_(string PickUpDate)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, PickUpDate);

            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1 )
            {
                IList<IWebElement> SearchedPickUpDatehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_PickUpColumn_Highlighted_StationUsers_Xpath));
                int HighlightedPickUpDateCount = SearchedPickUpDatehighlightedValues.Count;
                foreach (var val in SearchedPickUpDatehighlightedValues)
                {
                    if (PickUpDate.Contains(val.Text))
                    {
                        var colorofHighlighted_PickUpDate_Value = GetCSSValue(attributeName_classname, ShipmentListGrid_Highlight_Class, "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_PickUpDate_Value);
                        Report.WriteLine("Highlighted Reference Number values are appropriate");
                    }

                    else
                    {
                        Assert.Fail();
                    }

                }


            }
            else
            {
                Report.WriteLine("No Records found for the Shipment List for the logged in user so unable to test the scenario");
            }
        }





    }
}
