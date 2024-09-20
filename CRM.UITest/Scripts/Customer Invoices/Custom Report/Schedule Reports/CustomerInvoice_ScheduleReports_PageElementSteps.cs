using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using CRM.UITest.Entities;
using System.Configuration;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class CustomerInvoice_ScheduleReports_PageElementSteps : Customer_Invoice
    {
        string email = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();        
        [Given(@"I am on the Create Custom Report section for the selected custom Report")]
        public void GivenIAmOnTheCreateCustomReportSectionForTheSelectedCustomReport()
        {
            Report.WriteLine("Navigate to Customer Invoices Page");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            string customReportName = DBHelper.GetNotScheduledCustomReportName(email);
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, customReportName);            
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);
            Report.WriteLine("I am on Create Custom Report section");
        }

        [Given(@"I clicked on the Schedule Report button")]
        public void GivenIClickedOnTheScheduleReportButton()
        {
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Report.WriteLine("Clicked on Schedule Report button");
            Click(attributeName_id, scheduleReportButton_id);
        }

        [When(@"I click on the Schedule Report button")]
        public void WhenIClickOnTheScheduleReportButton()
        {
            Report.WriteLine("Click on Schedule Report button");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_xpath, schedulePageScheduleReportButton_Xpath);
            Click(attributeName_xpath, schedulePageScheduleReportButton_Xpath);            
        }

        [When(@"I click on the Schedule Report button on custom report section")]
        public void WhenIClickOnTheScheduleReportButtonOnCustomReportSection()
        {
            Report.WriteLine("Click on Schedule Report button on Custom Report section");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, scheduleReportButton_id);
        }

        [When(@"I click on Cancel button on Schedule Report modal")]
        public void WhenIClickOnCancelButtonOnScheduleReportModal()
        {
            Report.WriteLine("Click on Cancel button on Schedule Report Modal");
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
            scrollElementIntoView(attributeName_id, customReportModal_CancelButton_id);
            Click(attributeName_id, customReportModal_CancelButton_id);
        }

        [When(@"I arrive on schedule Report modal")]
        public void WhenIArriveOnScheduleReportModal()
        {
            Report.WriteLine("Arrive on Schedule Report Modal");
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Click(attributeName_id, scheduleReportButton_id);
            WaitForElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
        }

        [Then(@"I will arrive on Schedule Report modal")]
        public void ThenIWillArriveOnScheduleReportModal()
        {
            Report.WriteLine("Arrived on Schedule report modal");
            WaitForElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
        }

        [Then(@"I will display with custom report name on the top of the modal on both weekly and monthly tabs")]
        public void ThenIWillDisplayWithCustomReportNameOnTheTopOfTheModalOnBothWeeklyAndMonthlyTabs()
        {
            Report.WriteLine("Verifying Custom Report name on weekly tab");
            VerifyElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
            Report.WriteLine("Verifying Custom Report name on monthly tab");
            Click(attributeName_xpath, customReportModal_MonthlyTab_Xpath);
            VerifyElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
        }

        [Then(@"I will be displaying with Report Delivery options To, CC, Reply To, Report format selection, subject and comment on both weekly and monthly tabs")]
        public void ThenIWillBeDisplayingWithReportDeliveryOptionsToCCReplyToReportFormatSelectionSubjectAndCommentOnBothWeeklyAndMonthlyTabs()
        {
            Report.WriteLine("Verifying Report Delivery Options: To, CC, Reply To, Format, Subject and Comment on weekly tab");
            Click(attributeName_xpath, customReportModal_WeeklyTab_Xpath);
            WaitForElementVisible(attributeName_xpath, ReportDeliveryOptionsHeader_Xpath, "Report Delivery Options");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsHeader_Xpath, "Report Delivery Options");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_To_Xpath, "TO");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_CC_Xpath, "CC");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_ReplyTo_Xpath, "REPLY TO");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Format_Xpath, "FORMAT");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Subject_Xpath, "SUBJECT");
            MoveToElement(attributeName_xpath, ReportDeliveryOptionsLabel_Comment_Xpath);
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Comment_Xpath, "COMMENT");

            Report.WriteLine("Verifying Report Delivery Options: To, CC, Reply To, Format, Subject and Comment on monthly tab");
            Click(attributeName_xpath, customReportModal_MonthlyTab_Xpath);
            WaitForElementVisible(attributeName_xpath, ReportDeliveryOptionsHeader_Xpath, "Report Delivery Options");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsHeader_Xpath, "Report Delivery Options");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_To_Xpath, "TO");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_CC_Xpath, "CC");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_ReplyTo_Xpath, "REPLY TO");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Format_Xpath, "FORMAT");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Subject_Xpath, "SUBJECT");
            MoveToElement(attributeName_xpath, ReportDeliveryOptionsLabel_Comment_Xpath);
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Comment_Xpath, "COMMENT");
        }

        [Then(@"Cancel, Delete Schedule and Schedule Report buttons should be displayed on both weekly and monthly tabs")]
        public void ThenCancelDeleteScheduleAndScheduleReportButtonsShouldBeDisplayedOnBothWeeklyAndMonthlyTabs()
        {
            Report.WriteLine("Verifying Cancel, Delete and Schedule Report buttons in weekly tab");
            Click(attributeName_xpath, customReportModal_WeeklyTab_Xpath);
            scrollElementIntoView(attributeName_id, customReportModal_CancelButton_id);
            VerifyElementVisible(attributeName_id, customReportModal_CancelButton_id, "Cancel");
            VerifyElementVisible(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule");
            VerifyElementVisible(attributeName_id, customReportModal_ScheduleReport_id, "Schedule Report");

            Report.WriteLine("Verifying Cancel, Delete and Schedule Report buttonsin monthly tab");
            scrollElementIntoView(attributeName_xpath, customReportModal_MonthlyTab_Xpath);
            Click(attributeName_xpath, customReportModal_MonthlyTab_Xpath);
            scrollElementIntoView(attributeName_id, customReportModal_CancelButton_id);
            VerifyElementVisible(attributeName_id, customReportModal_CancelButton_id, "Cancel");
            VerifyElementVisible(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule");
            VerifyElementVisible(attributeName_id, customReportModal_ScheduleReport_id, "Schedule Report");
        }

        [Then(@"To is a mandatory field, should accept multiple emails with comma separation and should accept max length of (.*)")]
        public void ThenToIsAMandatoryFieldShouldAcceptMultipleEmailsWithCommaSeparationAndShouldAcceptMaxLengthOf(int p0)
        {
            //verifying TO for less than 250 characters
            WaitForElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_To_Xpath, "TO *");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_To_Xpath, "TO *");
            string emailAddressLessThanMaxLength = "swathi@123.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, emailAddressLessThanMaxLength);
            string emailAddressesLessThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            if (emailAddressesLessThanMaxLengthUI.Length < 250)
            {
                Report.WriteLine("To field accepting 250 characters");
            }
            else
            {
                Report.WriteFailure("TO field accepting more than 250 characters");
            }

            //verifying TO for max length of 250 charatcers                        
            string emailAddressesMaxLength = "swathi@123.com,swathi@234.com,swathi@345.com,swathi@456.com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swat@543.com,,swath@654.com,swati@543.com,swath@432.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, emailAddressesMaxLength);
            string emailAddressesMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            if (emailAddressesMaxLengthUI.Length == 250)
            {
                Report.WriteLine("To field accepting 250 characters");
            }
            else
            {
                Report.WriteFailure("TO field accepting more than 250 characters");
            }

            //verifying TO for more than max length of 250 charatcers                        
            string emailAddressesMoreThanMaxLength = "swathi@123.com,swathi@234.com,swathi@345.com,swathi@456.com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.com,swathiiiiiiiiiiii@432.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, emailAddressesMoreThanMaxLength);
            string emailAddressesMoreThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            if (emailAddressesMaxLengthUI.Length > 250)
            {
                Report.WriteFailure("TO field accepting more than 250 characters");
            }
        }

        [Then(@"CC is an optional field, should accept multiple emails with comma separation and should accept max length of (.*)")]
        public void ThenCCIsAnOptionalFieldShouldAcceptMultipleEmailsWithCommaSeparationAndShouldAcceptMaxLengthOf(int p0)
        {
            //verifying CC for less than 250 characters
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_CC_Xpath, "CC");
            string emailAddressesCC = "swathi@123.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, emailAddressesCC);
            string emailAddressesCCLessThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            if (emailAddressesCCLessThanMaxLengthUI.Length < 250)
            {
                Report.WriteLine("CC field accepting less than 250 characters");
            }
            else
            {
                Report.WriteLine("CC field accepting more than 250 characters");
            }

            //verifying CC for max 250 characters
            string emailAddressesCCMaxLength = "swathi@123.com,swathi@234.com,swathi@345.com,swathi@456.com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.com,sw@32.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, emailAddressesCCMaxLength);
            string emailAddressesCCMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            if (emailAddressesCCMaxLengthUI.Length == 250)
            {
                Report.WriteLine("CC field accepting max 250 characters");
            }
            else
            {
                Report.WriteLine("CC field accepting more than 250 characters");
            }

            //verifying CC for more than max 250 characters
            string emailAddressesCCMoreThanMaxLength = "swathiii@123.com,swathi@234.com,swathi@345.com,swathi@456.com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.com,swathiiiiiiiiiiii@432.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, emailAddressesCCMoreThanMaxLength);
            string emailAddressesCCMoreThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            if (emailAddressesCCMoreThanMaxLengthUI.Length > 250)
            {
                Report.WriteFailure("CC field accepting more than max 250 characters");
            }

        }

        [Then(@"Reply To is an optional field, should accept only one email and should accept max length of (.*)")]
        public void ThenReplyToIsAnOptionalFieldShouldAcceptOnlyOneEmailAndShouldAcceptMaxLengthOf(int p0)
        {
            //verifying Reply To for max 75 characters            
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_ReplyTo_Xpath, "REPLY TO");
            string emailAddressReplyToLessThanMaxLength = "swathi123comswathi234coms@test.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, emailAddressReplyToLessThanMaxLength);
            string emailAddressesReplyToLessThanMaxLength = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            if (emailAddressesReplyToLessThanMaxLength.Length < 75)
            {
                Report.WriteLine("Reply To field accepting less than max length of 75 characters");
            }
            else
            {
                Report.WriteFailure("Reply To field accepting more than max length of 75 characters");
            }

            //verifying Reply To for max 75 characters            
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_ReplyTo_Xpath, "REPLY TO");
            string emailAddressesReplyTo = "swathi123comswathi234comswathi345comswathi456dwscomswathi567987654@test.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, emailAddressesReplyTo);
            string emailAddressesReplyToMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            if (emailAddressesReplyToMaxLengthUI.Length == 75)
            {
                Report.WriteLine("Reply To field accepting max length of 75 characters");
            }
            else
            {
                Report.WriteFailure("Reply To field accepting more than max length of 75 characters");
            }

            //verifying Reply To for more than max 75 characters            
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_ReplyTo_Xpath, "REPLY TO");
            string emailAddressesReplyToMoreThanMaxLength = "swathi123comswathi234comswathi@345.com,swathi456comswathi5679876354@test.com";
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, emailAddressesReplyToMoreThanMaxLength);
            string emailAddressesReplyToMoreThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            if (emailAddressesReplyToMoreThanMaxLengthUI.Length > 75)
            {
                Report.WriteFailure("Reply To field accepting more than max length of 75 characters");
            }
        }

        [Then(@"Report format selection is a mandatory field, and should be defaulted to excel selection")]
        public void ThenReportFormatSelectionIsAMandatoryFieldAndShouldBeDefaultedToExcelSelection()
        {
            Report.WriteLine("Verifying Report Fomat field defaulted to Excel");
            VerifyElementVisible(attributeName_xpath, ReportDeliveryOptionsLabel_Subject_Xpath, "REPORT FORMAT");
            string excelDefault = Gettext(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            Assert.AreEqual("Excel", excelDefault);
        }

        [Then(@"Subject is a mandatory field and should accept alpha numeric of max length (.*)")]
        public void ThenSubjectIsAMandatoryFieldAndShouldAcceptAlphaNumericOfMaxLength(int p0)
        {
            //verifying subject for less than 250 charcters length            
            string subjectLessThanMaxLength = "swathi123com#swathi";
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subjectLessThanMaxLength);
            string subjectLessThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            if (subjectLessThanMaxLengthUI.Length < 250)
            {
                Report.WriteLine("Subject field accepting less than 250 characters");
            }
            else
            {
                Report.WriteFailure("Subject field accepting more than 250 characters");
            }

            //verifying subject for max length 250 charcters             
            string subjecttMaxLength = "swathi123com#swathi@234.com!,swathi*345.com,swathi^456&com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.comswathiiiiii";
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subjecttMaxLength);
            string subjectMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            if (subjectMaxLengthUI.Length == 250)
            {
                Report.WriteLine("Subject field accepting max length 250 characters");
            }
            else
            {
                Report.WriteFailure("Subject field accepting more than 250 characters");
            }

            //verifying subject for more than max length 
            string subjectMoreThanMaxLength = "swathi123com#swathiswathi123com#swathi@234.com!,swathi*345.com,swathi^456&com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.comswathiiiiiiiiiiii432com";
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subjectMoreThanMaxLength);
            string subjectMoreThanMaxLengthUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            if (subjectMoreThanMaxLengthUI.Length > 250)
            {
                Report.WriteFailure("Subject field accepting more than max length 250 characters");
            }

        }

        [Then(@"Subject name defaulted to Report name was processed on Datetime")]
        public void ThenSubjectNameDefaultedToReportNameWasProcessedOnDatetime()
        {
            Report.WriteLine("Verifying default subject field");            
            string subjectTextUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");            
            Assert.AreEqual(subjectTextUI, "<Report name> was processed on <Datetime>");
            Click(attributeName_xpath, customReportModal_MonthlyTab_Xpath);
            string subjectTextMonthlyUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            Assert.AreEqual(subjectTextMonthlyUI, "<Report name> was processed on <Datetime>");
        }

        [Then(@"Comment is an optional field and should accept alpha numeric of max length (.*)")]
        public void ThenCommentIsAnOptionalFieldAndShouldAcceptAlphaNumericOfMaxLength(int p0)
        {
            //verifying Comment field for less than max length of 500 characters
            string commentTexLessThanMaxLength = "swathi123com#swathi";
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, commentTexLessThanMaxLength);
            string commentTextLessThanMaxLengthUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname, "value");
            if (commentTextLessThanMaxLengthUI.Length < 500)
            {
                Report.WriteLine("Comment field accepting less than max length 500 characters");
            }
            else
            {
                Report.WriteFailure("Comment field accepting more than max length 500 characters");
            }
            //verifying Comment field for max length of 500 characters 
            string commentTextMaxLength = "swathi123com#swathi@234.com!,swathi*345.com,swathi^456&com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.comswathiiiiiiiiiiii432com328974382974wehjkhasdfukjsh832ewsyudhskjfhcewjskadruetyeruityeruityreuityeruithdjhfduihfjkds*(&(*&#@!^#&*@73828271389764323829478973298732987473222222222222222222222222228ewrui378ewrysdfhu78efuhre78dsuirfhce78dsuifyche8dsuizrdhew8suiu856t";
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, commentTextMaxLength);
            string commentTextMaxLengthUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname, "value");
            if (commentTextMaxLengthUI.Length == 500)
            {
                Report.WriteLine("Comment field accepting max length 500 characters");
            }
            else
            {
                Report.WriteFailure("Comment field accepting more than max length 500 characters");
            }
            //verifying Comment field for more than max length of 500 characters 
            string commentTextMoreThanMaxLength = "swathi123com#swathi@234.com!,swathi*345.com,swathi^456&com,swathi@567.com,swathi@678.com,swathi@789.com,swathi@890.com,swathi@098.com,swathi@987.com,swathi@876.com,swathi@765.com,swathi@654.com,swathi@543.com,,swathi@654.com,swathi@543.comswathiiiiiiiiiiii432com328974382974wehjkhasdfukjsh832ewsyudhskjfhcewjskadruetyeruityeruityreuityeruithdjhfduihfjkds*(&(*&#@!^#&*@73828271389764323829478973298732987473222222222222222222222222228ewrui378ewrysdfhu78efuhre78dsuirfhce78dsuifyche8dsuizrdhew8suiu856t89045";
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, commentTextMoreThanMaxLength);
            string commentTextMoreThanMaxLengthUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname, "value");
            if (commentTextMoreThanMaxLengthUI.Length > 500)
            {
                Report.WriteFailure("Comment field accepting more than max length 500 characters");
            }

        }

        [Then(@"I will arrive on the Customer Invoice list")]
        public void ThenIWillArriveOnTheCustomerInvoiceList()
        {
            Report.WriteLine("Navigate back to customer invoices list page");
            scrollElementIntoView(attributeName_xpath,"//html//tr[@role = 'row']//th");
            VerifyElementVisible(attributeName_xpath, "//html//tr[@role = 'row']//th", "Customer Invoice Grid");
        }

        [Then(@"I have an option to select both excel and pdf reports")]
        public void ThenIHaveAnOptionToSelectBothExcelAndPdfReports()
        {
            Report.WriteLine("Verifying pdf option in report format dropdown");
            scrollElementIntoView(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            var exportdropdownValues = new List<string> { "Excel", "PDF" };
            Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            List<string> exportdropdownValuesUI = GetDropdownOptions(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, "li");
            CollectionAssert.AreEqual(exportdropdownValues, exportdropdownValuesUI);
        }
    }
}
