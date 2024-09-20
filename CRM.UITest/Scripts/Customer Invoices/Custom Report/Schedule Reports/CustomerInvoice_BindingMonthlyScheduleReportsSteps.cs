using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class CustomerInvoice_BindingMonthlyScheduleReportsSteps : Customer_Invoice
    {
        string selectedCustomReport;
        string nextRunDate;
        string scheduledYear;
        DateTime incrementedScheduledYear;
        int scheduledYearInteger;
        List<string> checkRunDate = new List<string>();
        List<string> FinalReportScheduled = new List<string>();
        List<string> dropdownlists = new List<string>();

        string month;
        string week;
        string weekDay;
        string specificDay;
        string hours;
        string minutes;
        string meridiem;
        string to;
        string cc;
        string replyTo;
        string format;
        string subject;
        string Comment;
        string[] _monthSplitted;

        [Given(@"I clicked on the Monthly Time Period tab")]
        public void GivenIClickedOnTheMonthlyTimePeriodTab()
        {
            WaitForElementVisible(attributeName_xpath, ".//*[@id='modalScheduleCustomReport']//*[text()='Time Period']", "Time Period Verbiage");
            Click(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//*[@id='modalScheduleCustomReport']//*[text()='SELECT MONTHS *']", "SELECT MONTHS label");
            selectedCustomReport = Gettext(attributeName_xpath, CustomerInvoice_SelectedReportName_Monthly_Xpath);
        }


        [Given(@"I clicked on the Scheduled Report button")]
        public void GivenIClickedOnTheScheduledReportButton()
        {
            Click(attributeName_id, "btnScheduleReport");
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        


        [Then(@"I will see Cancel, Delete Schedule, Schedule Report button are in active state")]
        public void ThenIWillSeeCancelDeleteScheduleScheduleReportButtonAreInActiveState()
        {
            VerifyElementEnabled(attributeName_id, customReportModal_CancelButton_id, "Cancel button");
            VerifyElementEnabled(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule button");
            VerifyElementEnabled(attributeName_id, "btnScheduleReport", "Schedule Report button");
        }

        [Given(@"I will land on Customer Invoice list page and the scheduled Monthly Reports will be created")]
        public void GivenIWillLandOnCustomerInvoiceListPageAndTheScheduledMonthlyReportsWillBeCreated()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//h1[contains(text(), 'Customer Invoices')]", "Customer Invoice List Page");
            Thread.Sleep(2000);
        }
    }
}
