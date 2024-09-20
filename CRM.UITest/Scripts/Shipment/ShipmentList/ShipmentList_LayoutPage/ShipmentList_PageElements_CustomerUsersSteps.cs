using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList_LayoutPage
{
    [Binding]
    public class ShipmentList_PageElements_CustomerUsersSteps : Shipmentlist
    {
        [Given(@"I have access to Shipment Button")]
        public void GivenIHaveAccessToShipmentButton()
        {
            Report.WriteLine("Click on Shipment Button");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
        }

        [Given(@"I have access to Shipment button for external users")]
        public void GivenIHaveAccessToShipmentButtonForExternalUsers()
        {
            string ErrorPopupValues = Gettext(attributeName_xpath, ErrorMessage_Xpath);
            if (ErrorPopupValues == "Error")
            {
                Click(attributeName_xpath, ErrorPopUpClose_Button_Xpath);
                Thread.Sleep(2000);
                Click(attributeName_xpath, ShipmentIcon_Xpath);

            }
            else
            {
                Click(attributeName_xpath, ShipmentIcon_Xpath);
            }

        }


        [When(@"I arrive on Shipment list page")]
        public void WhenIArriveOnShipmentListPage()
        {
            Report.WriteLine("Shipment List page");
            Verifytext(attributeName_xpath, ShipmentList_Title_Xpath, "Shipment List");
        }

        [Then(@"I must be able to view an option to Search filtered reports")]
        public void ThenIMustBeAbleToViewAnOptionToSearchFilteredReports()
        {
            Report.WriteLine("Search Filtered Reports");
            VerifyElementPresent(attributeName_xpath, ShipmentList_FilteredReports_Xpath, "Filtered Report");
        }

        [Then(@"I must be able to view Hide report filters")]
        public void ThenIMustBeAbleToViewHideReportFilters()
        {
            Report.WriteLine("Hide filters button");
            VerifyElementPresent(attributeName_xpath, ShipmentList_HideFilters_Xpath, "Hide Filters");
            Click(attributeName_xpath, ShipmentList_HideFilters_Xpath);
        }

        [Then(@"I must be able to view Show report filters")]
        public void ThenIMustBeAbleToViewShowReportFilters()
        {
            Report.WriteLine("Show filters button");
            VerifyElementPresent(attributeName_xpath, ShipmentList_ShowFilters_Xpath, "Show Filters");
            Click(attributeName_xpath, ShipmentList_ShowFilters_Xpath);
        }

        [Then(@"I must be able to view Reference Number Lookup")]
        public void ThenIMustBeAbleToViewReferenceNumberLookup()
        {
            Report.WriteLine("Reference number lookup");
            VerifyElementPresent(attributeName_xpath, ShipmentList_ReferenceNumLookup_Xpath, "Reference Number Lookup");
        }

        [Then(@"I must have an option to search grid column data")]
        public void ThenIMustHaveAnOptionToSearchGridColumnData()
        {
            Report.WriteLine("Search grid column");
            VerifyElementPresent(attributeName_xpath, ShipmentList_SearchGridValuesTexTBox_Xpath, "Search Grid values");
        }

        [Then(@"I must be able to view clear all button")]
        public void ThenIMustBeAbleToViewClearAllButton()
        {
            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);
            VerifyElementPresent(attributeName_id, ShipmentListSearchBox_ClearAll_Button_Id, "Clear");
            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);


        }


        [Then(@"I must be able to view expected Search grid column dropdown values")]
        public void ThenIMustBeAbleToViewExpectedSearchGridColumnDropdownValues()
        {

            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);
            IList<IWebElement> ActualGridValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentListSearchBox_AllDropdownValues_Xpath));
            List<string> ExpectedHeaderValues = new List<string>(new string[] { "Select All", "REFERENCE NUMBER", "STATUS", "PICKUP", "DELIVERY", "SERVICE", "SERVICE LEVEL", "CARRIER", "", "ORIGIN", "DESTINATION", "QUANTITY", "WEIGHT", "SERVICE TYPE", "SHIPMENT CHARGE", "PO NUMBER" });
            foreach (var val in ActualGridValues)
            {
                if (ExpectedHeaderValues.Contains(val.Text))
                {
                    Report.WriteLine("Display" + val.Text + "is the Search grid values");
                }
                else
                {

                    Assert.Fail();
                    Report.WriteFailure("Value does not exists");
                }
            }

            Click(attributeName_xpath, ShipmentList_SearchBox_DropdownArrow_Xpath);


        }

        [Then(@"I must be able to view Scheduled to Deliver and Scheduled to Pickup options")]
        public void ThenIMustBeAbleToViewScheduledToDeliverAndScheduledToPickupOptions()
        {
            Report.WriteLine("Scheduled to deliver and pickup options");
            Click(attributeName_xpath, ShipmentList_FilterByDropdown_Xpath);


            string ShipDeliver = Gettext(attributeName_xpath, ShipmentList_ScheduledToDeliver_Xpath);
            Assert.AreEqual("SCHEDULED TO DELIVER", ShipDeliver);
            string ShipPickup = Gettext(attributeName_xpath, ShipmentList_ScheduledToPickup_Xpath);
            Assert.AreEqual("SCHEDULED TO PICKUP", ShipPickup);


        }

        [Then(@"I must be able to view Start Date Calender Selector")]
        public void ThenIMustBeAbleToViewStartDateCalenderSelector()
        {
            Report.WriteLine("Start date calender");
            VerifyElementPresent(attributeName_xpath, ShipmentList_StartDate_Xpath, "Start Date");
        }

        [Then(@"I must be able to view End Date Calender Selector")]
        public void ThenIMustBeAbleToViewEndDateCalenderSelector()
        {
            Report.WriteLine("End date calender");
            VerifyElementPresent(attributeName_xpath, ShipmentList_EndDate_Xpath, "End Date");
        }

        [Then(@"I must be able to view expected grid header values")]
        public void ThenIMustBeAbleToViewExpectedGridHeaderValues()
        {
            Report.WriteLine("Grid Header values");
            for (int i = 1; i <= 7; i++)
            {
                IList<IWebElement> ActualGridValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/thead/tr/th[" + i + "]"));
                List<string> ExpectedHeaderValues = new List<string>(new string[] { "REF #", "SERVICE", "STATUS", "PICKUP", "DELIVERY", "ORIGIN", "DESTINATION" });
                foreach (var val in ActualGridValues)
                {
                    if (ExpectedHeaderValues.Contains(val.Text))
                    {
                        Report.WriteLine("Display" + val.Text + "is the Shipment List grid value");
                    }
                    else
                    {
                        Assert.Fail();
                        Report.WriteFailure("Values does not exists");
                    }
                }

            }
        }

        [Then(@"I must be able to view Export button in Shipment list page")]
        public void ThenIMustBeAbleToViewExportButtonInShipmentListPage()
        {
            Report.WriteLine("Export Button");
            VerifyElementPresent(attributeName_id, ShipmentList_ExportButton_Id, "Export");
        }


        [Then(@"I must be able to view Export All and Export Displayed as export dropdown options")]
        public void ThenIMustBeAbleToViewExportAllAndExportDisplayedAsExportDropdownOptions()
        {
            Report.WriteLine("Export Options");
            Click(attributeName_id, ShipmentList_ExportButton_Id);
            IList<IWebElement> ActualExportValues = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_ExportOptions_Xpath));
            List<string> ExpectedExportValues = new List<string>(new string[] { "All", "Displayed" });
            foreach (var val in ActualExportValues)
            {
                if (ExpectedExportValues.Contains(val.Text))
                {
                    Report.WriteLine("Display" + val.Text + "is the Export dropdown values");
                    Thread.Sleep(2000);
                }
                else
                {
                    Assert.Fail();
                    Report.WriteFailure("Values does not exists");
                }
            }

        }

        [Then(@"I must be able to view Shipment details button")]
        public void ThenIMustBeAbleToViewShipmentDetailsButton()
        {
            Report.WriteLine("Shipment details button");
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                IList<IWebElement> ShipDetails = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentGrid_FirstRow_Xpath));
                VerifyElementVisible(attributeName_id, ShipmentDetails_Id, "Shipment Details Button");
            }
            else
            {
                Assert.Fail();
                Report.WriteFailure("Values does not exists");
            }
        }

        [Then(@"I must be able to view More Information button")]
        public void ThenIMustBeAbleToViewMoreInformationButton()
        {
            Report.WriteLine("More Information Button");
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                IList<IWebElement> ShipDetails = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentGrid_FirstRow_Xpath));
                VerifyElementPresent(attributeName_xpath, ShipmentListGrid_MoreInfoIcon_Xpath, "More Information");
            }
            else
            {
                Assert.Fail();
                Report.WriteFailure("Values does not exists");
            }
        }

        [Then(@"I must be able to view Add Shipment button")]
        public void ThenIMustBeAbleToViewAddShipmentButton()
        {
            Report.WriteLine("Add Shipment Button");
            VerifyElementPresent(attributeName_id, ShipmentList_AddShipmentButton_Id, "Add Shipment");
        }

        [Then(@"I must be able to view Copy icon displayed to the right of the destination column on the shipment row for LTL Shipments")]
        public void ThenIMustBeAbleToViewCopyIconDisplayedToTheRightOfTheDestinationColumnOnTheShipmentRowForLTLShipments()
        {
            Report.WriteLine("Copy Shipment Icon");
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                for (int i = 0; i <= 8; i++)
                {
                    IList<IWebElement> ServiceValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[2]"));
                    List<string> ExpectedServiceVal = new List<string>(new string[] { "LTL" });
                    foreach (var val in ServiceValue)
                    {
                        if (ExpectedServiceVal.Contains(val.Text))
                        {
                            VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[8]/a[2]", "Copy Icon");
                            Report.WriteLine("Copy Icon Exists");
                            break;
                        }

                        else
                        {
                            Report.WriteLine("Iterating to next row since service type LTL does not exists");
                        }

                    }



                }
            }
            else
            {
                Assert.Fail();
                Report.WriteFailure("Values does not exists");
            }
        }

        [Then(@"I must be able to view Return icon displayed to the right of the destination column on the shipment row for LTL Shipments")]
        public void ThenIMustBeAbleToViewReturnIconDisplayedToTheRightOfTheDestinationColumnOnTheShipmentRowForLTLShipments()
        {
            Report.WriteLine("Return Shipment Icon");
            IList<IWebElement> Rowcount = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_NoOfRows_Xpath));
            if (Rowcount.Count > 0)
            {
                for (int i = 0; i <= 8; i++)
                {
                    IList<IWebElement> ServiceValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[2]"));
                    List<string> ExpectedServiceVal = new List<string>(new string[] { "LTL" });
                    foreach (var val in ServiceValue)
                    {
                        if (ExpectedServiceVal.Contains(val.Text))
                        {
                            VerifyElementPresent(attributeName_xpath, ".//*[@id='ShipmentGrid']/tbody/tr[" + i + "]/td[8]/a[3]", "Return Icon");
                            Report.WriteLine("Copy Icon Exists");
                            break;
                        }
                        else
                        {
                            Report.WriteLine("Iterating to next row since service type LTL does not exists");
                        }
                    }


                }

            }
            else
            {
                Assert.Fail();
                Report.WriteFailure("Values does not exists");
            }
        }
    }
}

