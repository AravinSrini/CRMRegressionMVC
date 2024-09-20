using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ReportOptionsAllUsers
{
    [Binding]
    public class ShipmentList_ReportOptionsAllUsersSteps : Shipmentlist
    {
        [Given(@"I clicked on the Shipment Module will be navigated to Shipment List page")]
        public void GivenIClickedOnTheShipmentModuleWillBeNavigatedToShipmentListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentModule_Xpath);            
            WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");

            bool d = IsElementPresent(attributeName_xpath, ".//*[@id='error']/h2", "Warning");
            if (d)
            {
                Click(attributeName_xpath, ".//*[@id='btn-error-Close']");
            }
        }

        [When(@"I clicked on the Select a Report dropdown")]
        public void WhenIClickedOnTheSelectAReportDropdown()
        {
            Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
        }

        [When(@"I Clicked on Show Filter link")]
        public void WhenIClickedOnShowFilterLink()
        {
            Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
        }

        //[When(@"I select any Customer Account from the drop down which has Custom Report(.*)")]
        //public void WhenISelectAnyCustomerAccountFromTheDropDownWhichHasCustomReport(string p0)
        //{
        //    ScenarioContext.Current.Pending();
        //}

        [Then(@"I will be able to see Search By Filtered Reports text(.*)")]
        public void ThenIWillBeAbleToSeeSearchByFilteredReportsText(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I will see Standard report list")]
        public void ThenIWillSeeStandardReportList()
        {

            IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath)));
            List<string> _DropdownValue_sTdReport = DropDownValue.Select(a => a.Text).ToList();


            List<string> StandardReport_expected = new List<string> { "STANDARD REPORTS", "Todays Shipments", "Yesterdays Shipments","Shipments from Current Month","Shipments from Current Week",
            "Shipments from Previous Month","Shipments from Previous Week","Shipments Booked not In Transit","Shipments In Transit",
            "Shipments Pending"};
            //,"Shipments Rated not Tendered","Shipments Scheduled not Rated","Shipments Tendered not Booked", "Shipments Unscheduled
            //StandardReport_expected.Contains(DropDownValue.ToString());
            for (int i = 0; i < StandardReport_expected.Count; i++)
            {
                if (_DropdownValue_sTdReport.Contains(StandardReport_expected[i]))
                {
                    Report.WriteLine("Standard Reports are available in the Report dropdown");
                }
                else
                {
                    throw new Exception("Standard Reports are not available in the Report dropdown");
                }
            }
        }

        [Then(@"I will be able to select any of the Standard report(.*)")]
        public void ThenIWillBeAbleToSelectAnyOfTheStandardReport(string StdReport)
        {
            SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", StdReport);
            Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
            Thread.Sleep(30000);
            bool ShipmentListNotFound_UI = IsElementPresent(attributeName_xpath, ShipmentNotFound_PopUp_Xpath, "Shipment List Not Found");
            if (ShipmentListNotFound_UI)
            {
                Click(attributeName_xpath, ShipmentNotFoud_PopUp_Close_button_Xpath);
                WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                string SelectedReport_UI = Gettext(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
                Assert.AreEqual(StdReport, SelectedReport_UI);
            }
            else
            {
                WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                string SelectedReport_UI = Gettext(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
                Assert.AreEqual(StdReport, SelectedReport_UI);
            }

        }

        //[Then(@"I will be able to see Custom report list(.*)(.*)")]
        //public void ThenIWillBeAbleToSeeCustomReportList(string p0, string p1)
        //{
        //    ScenarioContext.Current.Pending();
        //}

        [Then(@"I will be able to see Custom report list(.*)")]
        public void ThenIWillBeAbleToSeeCustomReportList(string UserEmail)
        {
            IList<IWebElement> ReportDropDownList = (GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath)));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text).ToList();

            string CustomReport_Text = "CUSTOM REPORTS";
            bool _customeReport_Text = _dropdownListReport.Contains(CustomReport_Text);
            string CustomReport_Texts = "PRIVATE CUSTOM REPORTS";
            bool _customeReport_Texts = _dropdownListReport.Contains(CustomReport_Texts);
            if (_customeReport_Text || _customeReport_Texts)
            {
                List<string> _CustomReport = DBHelper._customReport_Mapped_to_UserEmail(UserEmail);

                for (int i = 0; i < _CustomReport.Count; i++)
                {
                    if (_dropdownListReport.Contains(_CustomReport[i]))
                    {
                        Report.WriteLine("Custom Reports present in UI and Database are matched");
                    }
                    else
                    {
                        throw new Exception("Custom Reports present in UI and Database are not matched");
                    }
                }
            }
            else
            {
                Report.WriteLine("No Report found for the logged in User");
            }
        }

        [Then(@"I will be able to select any of the Custom report(.*)")]
        public void ThenIWillBeAbleToSelectAnyOfTheCustomReport(string CustomReport)
        {

            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportType_chosen']/div/ul/li"));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text.ToUpper()).ToList();
            string CustomReport_Uppercase = CustomReport.ToUpper();

            bool check = _dropdownListReport.Contains(CustomReport_Uppercase);
            if (check)
            {
                SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", CustomReport);
                Thread.Sleep(500);
                Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
                Thread.Sleep(30000);
                //bool ShipmentListNotFound_UI = IsElementPresent(attributeName_xpath, ShipmentNotFound_PopUp_Xpath, "Shipment List Not Found");
                //if (ShipmentListNotFound_UI)
                //{
                //    Click(attributeName_xpath, ShipmentNotFoud_PopUp_Close_button_Xpath);
                //    WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                //    string SelectedReport_UI = Gettext(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
                //    Assert.AreEqual(CustomReport, SelectedReport_UI);
                //}
                //else
                //{
                WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                string SelectedReport_UI = Gettext(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
                Assert.AreEqual(CustomReport.ToUpper(), SelectedReport_UI.ToUpper());
                //}
            }
            else
            {
                Report.WriteLine("No Report matches search criteria inorder to select");
            }
        }

        [Then(@"I will be able to see Date Grid section")]
        public void ThenIWillBeAbleToSeeDateGridSection()
        {
            VerifyElementPresent(attributeName_xpath, FilterSection_SchedulePickUp_Calendar_Xpath, "Date Selector");
            Click(attributeName_xpath, FilterSection_SchedulePickUp_Calendar_Xpath);
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_Leftside_Calendar_Xpath, "Leftside Calendar");
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_Rightside_Calendar_Xpath, "Rightside Calendar");
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_Lastweek_button_Xpath, "Last Week button");
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_ThisMonth_button_Xpath, "This Month button");
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_LastMonth_button_Xpath, "Last Month button");
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_CustomRange_button_Xpath, "Custom Range");
            VerifyElementPresent(attributeName_xpath, FilterSection_DateRange_Select_button_Xpath, "Select button");
        }

        [Then(@"delete and update becomes active upon selecting any Custom Report(.*)")]
        public void ThenDeleteAndUpdateBecomesActiveUponSelectingAnyCustomReport(string CustomReport)
        {
            //Click(attributeName_xpath, ShipmentList_Report_dropdown_Xpath);
            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportType_chosen']/div/ul/li"));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text.ToUpper()).ToList();
            string CustomReport_Uppercase = CustomReport.ToUpper();

            bool check = _dropdownListReport.Contains(CustomReport_Uppercase);
            if (check)
            {
                SendKeys(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/div/input", CustomReport);
                Thread.Sleep(500);

                Click(attributeName_xpath, ".//*[@id='ReportType_chosen']/div/ul/li[2]");
                Thread.Sleep(30000);
                bool ShipmentListNotFound_UI = IsElementPresent(attributeName_xpath, ShipmentNotFound_PopUp_Xpath, "Shipment List Not Found");
                if (ShipmentListNotFound_UI)
                {
                    Click(attributeName_xpath, ShipmentNotFoud_PopUp_Close_button_Xpath);
                    WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                    Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
                    Thread.Sleep(500);
                    bool _updatebutton = IsElementEnabled(attributeName_id, FilterSection_UpdateReport_button_Id, "Update Report Parameter button");
                    Assert.IsTrue(_updatebutton);
                    bool _deletebutton = IsElementEnabled(attributeName_id, FilterSection_DeleteReport_button_Id, "Delete Report Parameter button");
                    Assert.IsTrue(_deletebutton);
                }
                else
                {
                    WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                    Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
                    Thread.Sleep(500);
                    bool _updatebutton = IsElementEnabled(attributeName_id, FilterSection_UpdateReport_button_Id, "Update Report Parameter button");
                    Assert.IsTrue(_updatebutton);
                    bool _deletebutton = IsElementEnabled(attributeName_id, FilterSection_DeleteReport_button_Id, "Delete Report Parameter button");
                    Assert.IsTrue(_deletebutton);
                }
            }
            else
            {
                Report.WriteLine("No Report matches search criteria inorder to select");
            }
        }

        [Then(@"I will see UI elements in Show Filter section")]
        public void ThenIWillSeeUIElementsInShowFilterSection()
        {
            VerifyElementPresent(attributeName_xpath, FilterSection_ClearAll_button_Xpath, "Clear All button");
            VerifyElementPresent(attributeName_xpath, FilterSection_SelectAll_button_Xpath, "Select All button");
            VerifyElementPresent(attributeName_id, FilterSection_OriginCity_Textbox_Id, "Origin City Textbox");
            VerifyElementPresent(attributeName_id, FilterSection_DestCity_Textbox_Id, "Dest City Textbox");
            VerifyElementPresent(attributeName_id, FilterSection_SaveReport_button_Id, "Save as new button");
            VerifyElementPresent(attributeName_id, FilterSection_RefNumber_Textbox_Id, "Referece Number Textbox");
            VerifyElementPresent(attributeName_xpath, FilterSection_Status_dropdown_Xpath, "Status Search box");
            Click(attributeName_xpath, ".//*[@id='status_select_chosen']/ul/li/input");

            IList<IWebElement> StatusDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(FilterSection_Status_List_Xpath));
            List<string> _statusDropdownList_UI = StatusDropDownList.Select(c => c.Text).ToList();

            List<string> StatusReport_expected = new List<string> { "Appointment Scheduled", "Booked", "Delayed","Delivered","In Transit",
            "On Hand Connection","On Hand Destination","On Hand Origin","Over/ Short/ Damaged",
            "Out for Delivery","Pending","Rated","Rejected", "Tendered"};

            CollectionAssert.AreEqual(_statusDropdownList_UI, StatusReport_expected);
        }


        [Then(@"I will be able to see different Service Types(.*)")]
        public void ThenIWillBeAbleToSeeDifferentServiceTypes(string StationID)
        {
            string[] b = StationID.Split(',');
            List<string> j = new List<string>();
            foreach (var x in b)
            {
                j.Add(x);
            }
            List<string> m = DBHelper.GetCustomers_TMS(j);



            //Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
            if (m.Contains("BOTH") || (m.Contains("MG") && m.Contains("CSA")))
            {

                VerifyElementPresent(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_Xpath, "LTL Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_Xpath, "TL Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_Xpath, "PTL Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_Xpath, "IML Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_Xpath, "DomForwarding Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_Xpath, "International Checkbox");
            }


            if (m.Contains("MG"))
            {
                VerifyElementPresent(attributeName_xpath, FilterSection_LTL_ServiceType_Checkbox_Xpath, "LTL Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_TL_ServiceType_Checkbox_Xpath, "TL Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_PTL_ServiceType_Checkbox_Xpath, "PTL Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_IML_ServiceType_Checkbox_Xpath, "IML Checkbox");

            }
            if (m.Contains("CSA"))
            {
                VerifyElementPresent(attributeName_xpath, FilterSection_DomForwarding_ServiceType_Checkbox_Xpath, "DomForwarding Checkbox");
                VerifyElementPresent(attributeName_xpath, FilterSection_Intl_ServiceType_Checkbox_Xpath, "International Checkbox");

            }
        }

        [Then(@"i will be seeing standard reports to MG only(.*)")]
        public void ThenIWillBeSeeingStandardReportsToMGOnly(string StationID)
        {
            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text).ToList();

            List<string> StandardReport_expected = new List<string> { "Shipments Rated not Tendered", "Shipments Scheduled not Rated", "Shipments Tendered not Booked", "Shipments Unscheduled" };

            string[] b = StationID.Split(',');
            List<string> j = new List<string>();
            foreach (var x in b)
            {
                j.Add(x);
            }
            List<string> m = DBHelper.GetCustomers_TMS(j);

            if (m.Contains("BOTH") || (m.Contains("MG")))
            {
                for (int i = 0; i < StandardReport_expected.Count; i++)
                {
                    if (_dropdownListReport.Contains(StandardReport_expected[i]))
                    {
                        Report.WriteLine("MG only Reports are present");
                    }
                    else
                    {
                        throw new Exception("MG only Reports not Found");
                    }
                }

            }
            else
            {
                Report.WriteLine("User station mapped CSA Customer");
            }
        }






        [Then(@"I will see MG standard Reports(.*)")]
        public void ThenIWillSeeMGStandardReports(string _CustomerAccount)
        {
            IList<IWebElement> ReportDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Report_dropdown_Values_Xpath));
            List<string> _dropdownListReport = ReportDropDownList.Select(c => c.Text).ToList();

            List<string> StandardReport_expected = new List<string> { "Shipments Rated not Tendered", "Shipments Scheduled not Rated", "Shipments Tendered not Booked", "Shipments Unscheduled" };
            CustomerAccount _accDetails = DBHelper.GetAccountDetails_By_CustomerName(_CustomerAccount);
            if (_accDetails.TmsSystem == "MG" || _accDetails.TmsSystem == "BOTH")
            {
                for (int i = 0; i < StandardReport_expected.Count; i++)
                {
                    if (_dropdownListReport.Contains(StandardReport_expected[i]))
                    {
                        Report.WriteLine("MG only Reports are present");
                    }
                    else
                    {
                        throw new Exception("MG only Reports not Found");
                    }
                }
            }
            else
            {
                Report.WriteLine("User station mapped CSA Customer");
            }
        }

        [Then(@"the Report parameter of Database should match with UI(.*)")]
        public void ThenTheReportParameterOfDatabaseShouldMatchWithUI(string _CustomReport)
        {
            Thread.Sleep(34000);
            bool ShipmentListNotFound_UI = IsElementPresent(attributeName_xpath, ShipmentNotFound_PopUp_Xpath, "Shipment List Not Found");
            if (ShipmentListNotFound_UI)
            {
                Click(attributeName_xpath, ShipmentNotFoud_PopUp_Close_button_Xpath);
                WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
            }
            else
            {
                WaitForElementVisible(attributeName_xpath, ShipmentList_Header_Xpath, "Shipment List");
                //Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
            }

            CustomReport CR = DBHelper._CustomReport_Data(_CustomReport);
            Click(attributeName_id, ShipmentList_ShowFilter_link_Id);
            string OrgCityActual = GetValue(attributeName_id, FilterSection_OriginCity_Textbox_Id, "value");
            Assert.AreEqual((CR.OriginCity), OrgCityActual);

            string DestCityActual = GetValue(attributeName_id, FilterSection_DestCity_Textbox_Id, "value");
            Assert.AreEqual((CR.DestinationCity), DestCityActual);

        }

    }
}
