using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class CustomerInvoice_ScheduleReports_WeeklyUpdationSteps: Customer_Invoice
    {
        int PreviousScheduledReportId = 0;
        int PreviousWeeklyScheduledReportId = 0;
        string email = "zzzext@user.com";
        string activeScheduledCustomReportName = null;

        [Given(@"I am on the Weekly tab page of the custom Report")]
        public void GivenIAmOnTheWeeklyTabPageOfTheCustomReport()
        {
            activeScheduledCustomReportName = DBHelper.GetNotScheduledCustomReportName(email);
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SendKeys(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//input[@type='text']", activeScheduledCustomReportName);
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            values[0].Click();
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Scheduled Report");
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_id, weeklytab_id, "Weekly");
        }
        
        [Given(@"I update all of the fields")]
        public void GivenIUpdateAllOfTheFields()
        {
            Report.WriteLine("Update all fields in weekly tab");
            Click(attributeName_xpath, selectday);
            SelectDropdownValueFromList(attributeName_xpath, selectdayValues, "Monday");
            Click(attributeName_xpath, selectTime);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeHourValues, "05");
            Click(attributeName_xpath, selectTimeMinute);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeMinuteValues, "30");
            SendKeys(attributeName_id,ReportDeliveryOptions_To_id, "updateto@test.com");
            SendKeys(attributeName_id,ReportDeliveryOptions_CC_id, "updatecc@test.com");
            SendKeys(attributeName_id,ReportDeliveryOptions_ReplyTo_id, "updatereply@test.com");
            Click(attributeName_xpath,ReportDeliveryOptions_FormatDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath,ReportDeliveryOptions_FormatDropdownValues_Xpath, "PDF");
            MoveToElement(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, "subject");
            SendKeys(attributeName_classname,ReportDeliveryOptions_Comment_classname, "bodycomment");
        }
        
        [Given(@"I am on the Weekly tab page of the Schedule weekly Report")]
        public void GivenIAmOnTheWeeklyTabPageOfTheScheduleWeeklyReport()
        {
            activeScheduledCustomReportName = DBHelper.GetWeeklyActiveCustomReportName(email);
            Report.WriteLine("Navigated to Weekly Tab of the scheduled custom Report");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SendKeys(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//input[@type='text']", activeScheduledCustomReportName);
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            values[0].Click();
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Scheduled Report");
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_id, weeklytab_id, "Weekly");
        }
        [Given(@"I am on the Weekly tab page of the Schedule weekly Report for update")]
        public void GivenIAmOnTheWeeklyTabPageOfTheScheduleWeeklyReportForUpdate()
        {
            activeScheduledCustomReportName = DBHelper.GetWeeklyActiveCustomReportName(email);
            Report.WriteLine("Navigated to Weekly Tab of the scheduled custom Report");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SendKeys(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//input[@type='text']", activeScheduledCustomReportName);
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            values[0].Click();
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Scheduled Report");
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_id, weeklytab_id, "Weekly");

            //get previous weeklyschedul id

            PreviousScheduledReportId = DBHelper.ScheduledReportId(activeScheduledCustomReportName).ScheduledReportId;
            PreviousWeeklyScheduledReportId = DBHelper.WScheduledReportId(PreviousScheduledReportId).WeeklyScheduledReportId;
        }


        [Given(@"I edit the fields")]
        public void GivenIEditTheFields()
        {
            Report.WriteLine("I Edit The Fields");
            Click(attributeName_xpath, selectday);
            SelectDropdownValueFromList(attributeName_xpath, selectdayValues, "Monday");
            Click(attributeName_xpath, selectTime);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeHourValues, "05");
            Click(attributeName_xpath, selectTimeMinute);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeMinuteValues, "30");
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, "updateto@test.com");
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, "updatecc@test.com");
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "updatereply@test.com");
            Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, "PDF");
            MoveToElement(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, "subject");
            //MoveToElement(attributeName_classname, ReportDeliveryOptions_Comment_classname);
            //SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, "bodycomment");
        }
        
        [Given(@"I click on the Monthly tab of the Schedule Report page")]
        public void GivenIClickOnTheMonthlyTabOfTheScheduleReportPage()
        {
            Report.WriteLine("click on the Monthly tab of the Schedule Report page");
            Click(attributeName_xpath,customReportModal_MonthlyTab_Xpath);
        }
        
        [Given(@"I edit any of the fields")]
        public void GivenIEditAnyOfTheFields()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("updating the shcedule fileds");
            DefineTimeOut(4000);
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath,"dropdown");
            MoveToElement(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath,"05");
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath,"30");
            MoveToElement(attributeName_id, ReportDeliveryOptions_To_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, "updateto@test.com");
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, "updatecc@test.com");
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "updatereply@test.com");
            Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, "PDF");
            MoveToElement(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, "subject");
            //SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, "bodycomment");
        }
        
        [Then(@"scheduled report with the given criteria will be created in DB")]
        public void ThenScheduledReportWithTheGivenCriteriaWillBeCreatedInDB()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(4000);
            //string reportName=Gettext(attributeName_xpath,customReportselectedvalue_xpath);
            var customReportDetails = DBHelper.GetWeeklyCustomReportDetails(activeScheduledCustomReportName);
            //verification for updating custom report as active schedule report
            Assert.IsTrue(customReportDetails.IsScheduled);
            Assert.AreEqual(customReportDetails.ReportFrequencyVal,"Weekly");
            //verification for fields inserted in DB
            Assert.AreEqual(customReportDetails.WeekDay, "Monday");
            Assert.AreEqual(customReportDetails.EmailTo, "updateto@test.com");
            Assert.AreEqual(customReportDetails.EmailCC, "updatecc@test.com");
            Assert.AreEqual(customReportDetails.EmailReplyTo,"updatereply@test.com");
            Assert.AreEqual(customReportDetails.ReportFormat, "PDF");
            Assert.AreEqual(customReportDetails.EmailSubject, "subject");
           // Assert.AreEqual(customReportDetails.Comment, "bodycomment");
        }
        
        [Then(@"the scheduled report with the previous criteria will be deleted from DB")]
        public void ThenTheScheduledReportWithThePreviousCriteriaWillBeDeletedFromDB()
        {
           //verification for deleting records for prevoius values from InvoiceCustomReporttable and ScheduledReporttable 
            var PreviousRecordschedule = DBHelper.WScheduledReport(PreviousWeeklyScheduledReportId);
            Assert.IsNull(PreviousRecordschedule);
        }


        [Then(@"Updated criteria will be updated in DB for weekly report")]
        public void ThenUpdatedCriteriaWillBeUpdatedInDBForWeeklyReport()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(4000);
            //string reportName=Gettext(attributeName_xpath,customReportselectedvalue_xpath);
            var customReportDetails = DBHelper.GetWeeklyCustomReportDetails(activeScheduledCustomReportName);
            //verification for updating custom report as active schedule report
            Assert.IsTrue(customReportDetails.IsScheduled);
            Assert.AreEqual(customReportDetails.ReportFrequencyVal, "Weekly");
            //verification for fields inserted in DB
            Assert.AreEqual(customReportDetails.WeekDay, "Monday");
            Assert.AreEqual(customReportDetails.EmailTo, "updateto@test.com");
            Assert.AreEqual(customReportDetails.EmailCC, "updatecc@test.com");
            Assert.AreEqual(customReportDetails.EmailReplyTo, "updatereply@test.com");
            Assert.AreEqual(customReportDetails.ReportFormat, "PDF");
            Assert.AreEqual(customReportDetails.EmailSubject, "subject");
            //Assert.AreEqual(customReportDetails.Comment, "bodycomment");
        }

        [Then(@"Updated criteria will be updated in DB for Monthly report")]
        public void ThenUpdatedCriteriaWillBeUpdatedInDBForMonthlyReport()
        {
            DefineTimeOut(4000);
            var MonthlyReportDetails = DBHelper.GetMonthlyCustomReportDetails(activeScheduledCustomReportName);
            //verification for updating custom report as active schedule report
            Assert.IsTrue(MonthlyReportDetails.IsScheduled);
            Assert.AreEqual(MonthlyReportDetails.ReportFrequencyVal, "Monthly");
            //verification for fields inserted in DB will use delta linq for monthly  
            Assert.AreEqual(MonthlyReportDetails.EmailTo, "updateto@test.com");
            Assert.AreEqual(MonthlyReportDetails.EmailCC, "updatecc@test.com");
            Assert.AreEqual(MonthlyReportDetails.EmailReplyTo, "updatereply@test.com");
            Assert.AreEqual(MonthlyReportDetails.ReportFormat, "PDF");
            Assert.AreEqual(MonthlyReportDetails.EmailSubject, "subject");
            Assert.AreEqual(MonthlyReportDetails.Comment, "bodycomment");
        }

    }
}
