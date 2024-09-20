using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using System.Collections.Generic;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class CustomerInvoice_ScheduleReports_WeeklyAuto_PopulateSteps : Customer_Invoice
    {
        string email = "zzzext@user.com";
        string activeScheduledCustomReportName = "null";

        [Given(@"I selected an existing weekly custom report from dropdown list")]
        public void GivenISelectedAnExistingWeeklyCustomReportFromDropdownList()
        {
            Report.WriteLine("selecting existing weekly custom report from custom report dropdown");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string scheduledCustomReportName = DBHelper.GetNotScheduledCustomReportName(email);
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, scheduledCustomReportName);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
        }
        
        [Given(@"I selected an existing custom report from dropdown list which is active weekly scheduled")]
        public void GivenISelectedAnExistingCustomReportFromDropdownListWhichIsActiveWeeklyScheduled()
        {
            Report.WriteLine("selecting existing weekly active scheduled custom report from custom report dropdown");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            activeScheduledCustomReportName = DBHelper.GetWeeklyActiveCustomReportName(email);
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SendKeys(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//input[@type='text']", activeScheduledCustomReportName);            
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            values[0].Click();
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
        }
        
        [Given(@"I arrive on Scheduled Report weekly tab")]
        public void GivenIArriveOnScheduledReportWeeklyTab()
        {
            Report.WriteLine("Click on schedule report button on creat custom report section");
            
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
        }
        
        [When(@"I click on weekly scheduled report")]
        public void WhenIClickOnWeeklyScheduledReport()
        {
            Report.WriteLine("Click on Weekly Scheduled Report tab");
            Click(attributeName_id, scheduleReportButton_id);
        }
        
        [When(@"I click on monthly tab of the scheduled report")]
        public void WhenIClickOnMonthlyTabOfTheScheduledReport()
        {
            Report.WriteLine("Click on Monthly scheduled report Tab");
            Click(attributeName_xpath, customReportModal_MonthlyTab_Xpath);
        }
        
        [Then(@"I arrive on Scheduled Report weekly tab")]
        public void ThenIArriveOnScheduledReportWeeklyTab()
        {
            Report.WriteLine("Arriving Weekly Schedule report tab");
            WaitForElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
            VerifyElementNotVisible(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "month");
        }
        
        [Then(@"Week Day, Time, Morning or Evening designation, To, CC, Reply To, Report Format, Subject, Comment fields will display with previously selected data and editable")]
        public void ThenWeekDayTimeMorningOrEveningDesignationToCCReplyToReportFormatSubjectCommentFieldsWillDisplayWithPreviouslySelectedDataAndEditable()
        {
            Report.WriteLine("Verifying all values auto populate for weekly active scheduled custom report");
            //values from DB            
            WeeklyScheduleReportViewModel customReportDetails = DBHelper.GetWeeklyCustomReportDetails(activeScheduledCustomReportName);
                        
            //displaying values in UI
            string dayUI=Gettext(attributeName_xpath, selectday);
            Assert.AreEqual(customReportDetails.WeekDay, dayUI);
            string timeHourUI = Gettext(attributeName_xpath, selectTimeHour);            
            string timeMinuteUI = Gettext(attributeName_xpath, selectTimeMinute);
            //string designationUI = Gettext(attributeName_xpath, selectTimeAM);            
            Assert.AreEqual(customReportDetails.WeeklyReportTime.ToString(), timeHourUI+":"+timeMinuteUI+":"+"00");
            string emailToUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            Assert.AreEqual(customReportDetails.EmailTo, emailToUI);
            string emailCCUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            if (emailCCUI == "")
            {                
                Assert.IsNull(customReportDetails.EmailCC);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailCC, emailCCUI);
            }
            
            string emailReplyToUI = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            if (emailReplyToUI == "")
            {
                Assert.IsNull(customReportDetails.EmailReplyTo);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailReplyTo, emailReplyToUI);
            }            
            string reportFormatUI = Gettext(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            Assert.AreEqual(customReportDetails.ReportFormat, reportFormatUI.ToUpper());
            string subjectUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            if (subjectUI == "")
            {
                Assert.IsNull(customReportDetails.EmailSubject);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailSubject, subjectUI);
            }            
            scrollElementIntoView(attributeName_classname, ReportDeliveryOptions_Comment_classname);
            string commentUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname, "value");
            if (commentUI == "")
            {
                Assert.IsNull(customReportDetails.Comment);
            }
            else
            {
                Assert.AreEqual(customReportDetails.Comment, commentUI);
            }            
            
            //editing all fields
            Report.WriteLine("verifying edit for active scheduled custom report weekly all fields");
            Click(attributeName_xpath, selectday);
            SelectDropdownValueFromList(attributeName_xpath, selectdayValues, "Monday");
            Click(attributeName_xpath, selectTime);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeHourValues, "05");
            Click(attributeName_xpath, selectTimeMinute);
            SelectDropdownValueFromList(attributeName_xpath, selectTimeMinuteValues, "30");            
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id,"swathi@test.com");
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, "swathi@test.com");
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "swathi@test.com");
            Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, "PDF");
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, "swathi@test.com");
            scrollElementIntoView(attributeName_classname, ReportDeliveryOptions_Comment_classname);
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, "swathi@test.com");
        }
        
        [Then(@"Cancel, Delete Schedule, Schedule Report buttons are active")]
        public void ThenCancelDeleteScheduleScheduleReportButtonsAreActive()
        {
            Report.WriteLine("Verifying Cancel, Delete Schedule, Schedule Report buttons are active");
            scrollElementIntoView(attributeName_id, customReportModal_CancelButton_id);
            IsElementEnabled(attributeName_id, customReportModal_CancelButton_id, "Cancel");
            IsElementEnabled(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule");
            IsElementEnabled(attributeName_id, customReportModal_ScheduleReport_id, "Schedule Report");
        }

        [Then(@"Default values will be binded in weekly report tab")]
        public void ThenDefaultValuesWillBeBindedInWeeklyReportTab()
        {
            Report.WriteLine("Verifying all values of weekly auto populate for custom report");            
            Verifytext(attributeName_xpath, selectday,"Sunday");            
            Verifytext(attributeName_xpath, selectTimeHour,"Select hour...");
            Verifytext(attributeName_xpath, selectTimeMinute,"Select minutes...");
            Verifytext(attributeName_xpath, selectTimeAM,"AM");            
            Verifytext(attributeName_id, ReportDeliveryOptions_To_id,"");            
            Verifytext(attributeName_id, ReportDeliveryOptions_CC_id,"");            
            Verifytext(attributeName_id, ReportDeliveryOptions_ReplyTo_id,"");            
            Verifytext(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath,"Excel");
            string subjectTextUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            Assert.AreEqual(subjectTextUI,"<Report name> was processed on <Datetime>");            
            Verifytext(attributeName_classname, ReportDeliveryOptions_Comment_classname,"");         

        }

        [Then(@"Default values will be binded in monthly report tab")]
        public void ThenDefaultValuesWillBeBindedInMonthlyReportTab()
        {
            Report.WriteLine("Verifying values auto populate in monthly tab for weekly report");
            //values from DB            
            WeeklyScheduleReportViewModel customReportDetails = DBHelper.GetWeeklyCustomReportDetails(activeScheduledCustomReportName);

            //displaying default values in UI comparing with DB    
            GlobalVariables.webDriver.WaitForPageLoad();        
            string emailToUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id,"value");
            if (emailToUI == "")
            {
                Assert.IsNull(customReportDetails.EmailTo);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailTo, emailToUI);
            }            
            string emailCCUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id,"value");
            if (emailCCUI == "")
            {
                Assert.IsNull(customReportDetails.EmailCC);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailCC, emailCCUI);
            }            
            string emailReplyToUI = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id,"value");
            if (emailReplyToUI == "")
            {
                Assert.IsNull(customReportDetails.EmailReplyTo);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailReplyTo, emailReplyToUI);
            }            
            string reportFormatUI = Gettext(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            Assert.AreEqual(customReportDetails.ReportFormat, reportFormatUI.ToUpper());
            string subjectUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id,"value");
            if (subjectUI == "")
            {
                Assert.IsNull(customReportDetails.EmailSubject);
            }
            else
            {
                Assert.AreEqual(customReportDetails.EmailSubject, subjectUI);
            }            
            scrollElementIntoView(attributeName_classname, ReportDeliveryOptions_Comment_classname);
            string commentUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname,"value");
            if (commentUI == "")
            {
                Assert.IsNull(customReportDetails.Comment);
            }
            else
            {
                Assert.AreEqual(customReportDetails.Comment, commentUI);
            }            
        }
    }
}
