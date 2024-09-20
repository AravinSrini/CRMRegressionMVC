using System;
using System.Collections.Generic;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class CustomerInvoice_CustomReport_DateRangeSelectorSteps : Customer_Invoice
    {
        [Given(@"I have selected only one of the two required dates")]
        public void GivenIHaveSelectedOnlyOneOfTheTwoRequiredDates()
        {
            Click(attributeName_xpath, CustomReport_CreateReportSection_DateRangePicker_Xpath);
            IList<IWebElement> datesAvailable = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CreateReportSection_DateRangePicker_AvailableDates_Xpath));

            for (int i = 0; i < datesAvailable.Count; i++)
            {
                if (datesAvailable[i].GetAttribute("class").Contains("today"))
                {
                    //Select today as the start date
                    datesAvailable[i].Click();
                    Report.WriteLine("Selected Current date as start date in DateRange picker");
                    break;
                }
            }
        }

        [When(@"I click on the Date Range box")]
        public void WhenIClickOnTheDateRangeBox()
        {
            Click(attributeName_xpath, CustomReport_CreateReportSection_DateRangePicker_Xpath);
            Report.WriteLine("Clicked on the Date Range picker");
        }

        [When(@"I have selected a starting and ending date in the Date Range field")]
        public void WhenIHaveSelectedAStartingAndEndingDateInTheDateRangeField()
        {
            int todaysDateIndex = 0;
            Click(attributeName_xpath, CustomReport_CreateReportSection_DateRangePicker_Xpath);
            IList<IWebElement> datesAvailableForStartDate = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CreateReportSection_DateRangePicker_AvailableDates_Xpath));
           
            for (int i = 0; i < datesAvailableForStartDate.Count; i++)
            {
                if (datesAvailableForStartDate[i].GetAttribute("class").Contains("today"))
                {
                    //Select today as the start date
                    datesAvailableForStartDate[i].Click();
                    Report.WriteLine("Selected Current date as start date in DateRange picker");
                    todaysDateIndex = i;
                    break;
                }
            }

            //Select tomorrow's date as end date
            IList<IWebElement> datesAvailableForEndDate = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CreateReportSection_DateRangePicker_AvailableDates_Xpath));
            datesAvailableForEndDate[todaysDateIndex + 1].Click();
            Report.WriteLine("Selected Tomorrow's date as end date in DateRange picker");
        }

        [When(@"I close the date range calendar picker")]
        public void WhenICloseTheDateRangeCalendarPicker()
        {
            Click(attributeName_id, CustomReport_DaysPastDue_Input_Id);
            Report.WriteLine("Closed the date range calender picker");
        }

        [Then(@"I have the option to select a Starting Date")]
        public void ThenIHaveTheOptionToSelectAStartingDate()
        {
            bool isLeftCalenderVisible = IsElementVisible(attributeName_xpath, CustomReport_CreateReportSection_DateRangeLeftCalender_Xpath, "Date Range Picker Left Calender");
            bool isRightCalenderVisible = IsElementVisible(attributeName_xpath, CustomReport_CreateReportSection_DateRangeLeftCalender_Xpath, "Date Range Picker Right Calender");
            bool isStartDateInputVisible = IsElementVisible(attributeName_xpath, FromDate_Xpath, "Date Range Picker StartDate selector input");

            Assert.IsTrue(isLeftCalenderVisible && isRightCalenderVisible && isStartDateInputVisible);
            Report.WriteLine("Verified that the option to select start date is available in DateRange");
        }

        [Then(@"I have the option to select an Ending Date")]
        public void ThenIHaveTheOptionToSelectAnEndingDate()
        {
            bool isLeftCalenderVisible = IsElementVisible(attributeName_xpath, CustomReport_CreateReportSection_DateRangeLeftCalender_Xpath, "Date Range Picker Left Calender");
            bool isRightCalenderVisible = IsElementVisible(attributeName_xpath, CustomReport_CreateReportSection_DateRangeLeftCalender_Xpath, "Date Range Picker Right Calender");
            bool isEndDateInputVisible = IsElementVisible(attributeName_xpath, ToDate_Xpath, "Date Range Picker EndDate selector input");

            Assert.IsTrue(isLeftCalenderVisible && isRightCalenderVisible && isEndDateInputVisible);
            Report.WriteLine("Verified that the option to select end date is available in DateRange");
        }

        [Then(@"I will see the date range displayed in the format mm/dd/yyyy - mm/dd/yyyy")]
        public void ThenIWillSeeTheDateRangeDisplayedInTheFormatMmDdYyyy_MmDdYyyy()
        {
            string dateRangeSelected = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "value");
            Assert.AreEqual(DateTime.Today.ToString("MM/dd/yyyy") + " - " + DateTime.Today.AddDays(1).ToString("MM/dd/yyyy"), dateRangeSelected);
            Report.WriteLine("Verified that the selected date range is displayed in mm/dd/yyyy format");
        }

        [Then(@"I will not see a date range displayed in the Date Range field")]
        public void ThenIWillNotSeeADateRangeDisplayedInTheDateRangeField()
        {
            string dateRangeSelected = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "value");
            Assert.AreEqual(string.Empty, dateRangeSelected);
            Report.WriteLine("Verified that the Date range is not displayed when only one of the date is selected");
        }
    }
}
