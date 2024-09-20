using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_GridSearch_CustomerUsers
{
    [Binding]
    public class ShipmentList_GridSearchSteps : Shipmentlist
    {

        [When(@"I click on the drop down arrow of the search field in the Shipment List page")]
        public void WhenIClickOnTheDropDownArrowOfTheSearchFieldInTheShipmentListPage()
        {
            Report.WriteLine("Click on Search arrow dropdown");
            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);
            Thread.Sleep(2000);
        }

        [Then(@"I must see the expected drop down values")]
        public void ThenIMustSeeTheExpectedDropDownValues()
        {
            IList<IWebElement> ActualSearchValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListSearchBox_AllDropdownValues_Xpath));
            List<string> ExpectedSearchValues = new List<string>(new string[] { "Select All", "REFERENCE NUMBER", "STATUS", "PICKUP", "DELIVERY", "SERVICE", "SERVICE LEVEL", "CARRIER NAME", "", "ORIGIN", "DESTINATION", "QUANTITY", "WEIGHT", "SERVICE TYPE", "SHIPMENT CHARGE", "PO NUMBER"});
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


        [When(@"I Click on the Clear All button")]
        public void WhenIClickOnTheClearAllButton()
        {
            Report.WriteLine("Click on Clear All button");
            Click(attributeName_id, ShipmentListSearchBox_ClearAll_Button_Id);
            Thread.Sleep(2000);
        }

        [When(@"I select the multiple fields as Reference number, Service, Status from the drop down")]
        public void WhenISelectTheMultipleFieldsAsReferenceNumberServiceStatusFromTheDropDown()
        {

            Report.WriteLine("Select specified multiple fields");
            Click(attributeName_xpath, ShipmentList_Search_ReferenceNumber_Checkbox_Xpath);
            Click(attributeName_xpath, ShipmentList_Search_Status_Checkbox_Xpath);
            Click(attributeName_xpath, ShipmentList_Search_Service_Checkbox_Xpath);
            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);

        }

        [Then(@"I must be able to search the shipment by entering the Reference number values in the search field and it should be highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchTheShipmentByEnteringTheReferenceNumberValuesInTheSearchFieldAndItShouldBeHighlightedInTheGrid_(string ReferenceNumber)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, ReferenceNumber);            

            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1)
            {
                IList<IWebElement> SearchedReferenceNumberhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_ReferenceNumberColumn_Highlighted_Xpath));
                int HighlightedRefNameCount = SearchedReferenceNumberhighlightedValues.Count;
                foreach (var val in SearchedReferenceNumberhighlightedValues)
                {
                    if (ReferenceNumber.Contains(val.Text))
                    {
                        var colorofHighlighted_ReferenceNumber_Value = GetCSSValue(attributeName_classname, ShipmentListGrid_Highlight_Class, "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_ReferenceNumber_Value); 
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


        [Then(@"I must be able to search the shipment by entering the Service values in the search field and it should be highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchTheShipmentByEnteringTheServiceValuesInTheSearchFieldAndItShouldBeHighlightedInTheGrid_(string Service)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, Service);
            //Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);

            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1)
            {
                IList<IWebElement> SearchedServicehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_ServiceColumn_Highlighted_Xpath));
                int HighlightedServiceNameCount = SearchedServicehighlightedValues.Count;
                foreach (var val in SearchedServicehighlightedValues)
                {
                    if (Service.Contains(val.Text))
                    {
                        var colorofHighlighted_Service_Value = GetCSSValue(attributeName_classname, ShipmentListGrid_Highlight_Class, "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_Service_Value);
                        Report.WriteLine("Highlighted Service values are appropriate");
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

        [Then(@"I must be able to search the shipment by entering the Status values in the search field and it should be highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchTheShipmentByEnteringTheStatusValuesInTheSearchFieldAndItShouldBeHighlightedInTheGrid_(string Status)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_id, ShipmentListSearchBox_Id, Status);
            //Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);

            int Shipmentrowcount = GetCount(attributeName_xpath, ShipmentList_TotalRecords_Xpath);
            if (Shipmentrowcount > 1)
            {
                IList<IWebElement> SearchedStatushighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_StatusColumn_Highlighted_Xpath));
                int HighlightedStatusNameCount = SearchedStatushighlightedValues.Count;
                foreach (var val in SearchedStatushighlightedValues)
                {
                    string statusValue = val.Text;
                    string[] ExpectedStatus = statusValue.Split(' ');
                    if (Status.Contains(ExpectedStatus[1]))
                    {
                        var colorofHighlighted_Service_Value = GetCSSValue(attributeName_classname, ShipmentListGrid_Highlight_Class, "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_Service_Value);
                        Report.WriteLine("Highlighted Service values are appropriate");
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

        [Then(@"All the options from the search drop down should be cleared")]
        public void ThenAllTheOptionsFromTheSearchDropDownShouldBeCleared()
        {
            Report.WriteLine("Clear Functionality");
            VerifyElementNotChecked(attributeName_xpath, ShipmentList_SearchBox_AllDropdownValues_Xpath, "SearchValues");

        }

        [Then(@"I must be able to view note text within Search dropdown")]
        public void ThenIMustBeAbleToViewNoteTextWithinSearchDropdown()
        {
            Report.WriteLine("Display of Note section");
            Verifytext(attributeName_id, ShipmentList_SearchDropdown_NoteSection_Id, "Note: To search multiple shipments, select search criteria and enter keyword.");

        }


    }
}
