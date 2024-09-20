using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class CustomerInvoice_CreateScheduleReports_MonthlySteps : Customer_Invoice
    {
        string email = "zzzext@user.com";

        string selectedCustomReport;
        List<string> checkRunDate = new List<string>();
        List<string> FinalReportScheduled = new List<string>();
        List<string> dropdownlists = new List<string>();
        CommonMethodsCrm crm = new CommonMethodsCrm();
        string nextRunDate;

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
        string checkWeekData = null;
        string ReportName = Guid.NewGuid().ToString() + "VTst";

        string Email = "zzzext@user.com";

        [Given(@"I selected a Custom report from the Select Existing Custom Report drop down list in Customer Invoice page")]
        public void GivenISelectedACustomReportFromTheSelectExistingCustomReportDropDownListInCustomerInvoicePage()
        {
            Report.WriteLine("Navigate to Customer Invoices Page");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            //string customReportName = DBHelper.GetNotScheduledCustomReportName(Email);

            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']/div/ul/li"));

            if (CustInvoiceReportList.Count > 1)
            {

                for (int i = 1; i < CustInvoiceReportList.Count; i++)
                {
                    bool isScheduled = CustInvoiceReportList[i].Text.Contains("(Scheduled - ");
                    if (isScheduled == false)
                    {
                        CustInvoiceReportList[i].Click();
                        i = CustInvoiceReportList.Count;
                        break;
                    }
                    else if (i == (CustInvoiceReportList.Count - 1) && isScheduled == true)
                    {
                        Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
                        Click(attributeName_id, createCustomReportsectionExpandArrow_id);
                        Thread.Sleep(2000);
                        WaitForElementVisible(attributeName_id, CreateReportNewButton_Id, "Create New button");
                        //Report.WriteLine("Create Custom Report section is expanded");
                        //WaitForElementVisible(attributeName_xpatD:\Auto21062018\Main\CRM.UITest\Scripts\Customer Invoices\Custom Report\Customer Invoice - Custom Report - Days Past Due Field.featureh, ReportName_Xpath, "Report Section");
                        SendKeys(attributeName_id, DaysPastDue_Id, "5");
                        SendKeys(attributeName_id, InvoiceVal_Id, "4");
                        Click(attributeName_xpath, ReportAccount_Xpath);
                        SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "ZZZ - Czar Customer Test");

                        SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
                        string checkreport = ReportName;

                        Report.WriteLine("Values are passed to all the fields");
                        Click(attributeName_id, CreateReportNewButton_Id);
                        Report.WriteLine("Create New button is clicked");
                        Thread.Sleep(5000);
                        GlobalVariables.webDriver.WaitForPageLoad();
                        Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
                        SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, checkreport);
                        break;
                    }

                }
            }
            else
            {
                Thread.Sleep(2000);
                Click(attributeName_id, createCustomReportsectionExpandArrow_id);
                Thread.Sleep(2000);
                WaitForElementVisible(attributeName_id, CreateReportNewButton_Id, "Create New button");
                SendKeys(attributeName_id, DaysPastDue_Id, "5");
                SendKeys(attributeName_id, InvoiceVal_Id, "4");
                Click(attributeName_xpath, ReportAccount_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "ZZZ - Czar Customer Test");

                SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
                string checkreport = ReportName;

                Report.WriteLine("Values are passed to all the fields");
                Click(attributeName_id, CreateReportNewButton_Id);
                Report.WriteLine("Create New button is clicked");
                Thread.Sleep(5000);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, checkreport);

            }
        }

        [Given(@"I clicked on Schedule Report button will be navigated to Weekly Tab")]
        public void GivenIClickedOnScheduleReportButtonWillBeNavigatedToWeeklyTab()
        {
            WaitForElementVisible(attributeName_id, createCustomReportsectionExpandArrow_id, "Expand Arrow");
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "ScheduleReport");
            Click(attributeName_id, scheduleReportButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked on Monthly Time Period tab")]
        public void GivenIClickedOnMonthlyTimePeriodTab()
        {
            WaitForElementVisible(attributeName_xpath, ".//*[@id='modalScheduleCustomReport']//*[text()='Time Period']", "Time Period Verbiage");
            Click(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//*[@id='modalScheduleCustomReport']//*[text()='SELECT MONTHS *']", "SELECT MONTHS label");
            selectedCustomReport = Gettext(attributeName_xpath, CustomerInvoice_SelectedReportName_Monthly_Xpath);
        }

        [Given(@"I entered all the required information(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnteredAllTheRequiredInformation(string testDataMonth, string testDataSpecificDay, string testDataHours, string testDataMinutes, string testDataMeridiem, string testDataTo, string testDataCC, string testDataReplyTo, string testDataFormat, string testDataSubject, string testDataComment)
        {
            selectedCustomReport = Gettext(attributeName_xpath, CustomerInvoice_SelectedReportName_Monthly_Xpath);

            month = testDataMonth;
            specificDay = testDataSpecificDay;
            hours = testDataHours;
            minutes = testDataMinutes;
            meridiem = testDataMeridiem;

            to = testDataTo;
            cc = testDataCC;
            replyTo = testDataReplyTo;
            format = testDataFormat;
            subject = testDataSubject;
            Comment = testDataComment;


            Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);

            switch (month)
            {
                case "January":
                    {
                        Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
                        break;
                    }
                case "February":
                    {
                        Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
                        break;
                    }
                case "March":
                    {
                        Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
                        break;
                    }
                case "April":
                    {
                        Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
                        break;
                    }
                case "May":
                    {
                        Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
                        break;
                    }
                case "June":
                    {
                        Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
                        break;
                    }
                case "July":
                    {
                        Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
                        break;
                    }
                case "August":
                    {
                        Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
                        break;
                    }
                case "September":
                    {
                        Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
                        break;
                    }
                case "October":
                    {
                        Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
                        break;
                    }
                case "November":
                    {
                        Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
                        break;
                    }
                case "December":
                    {
                        Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);
                        break;
                    }
            }

            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='radioBtnMonthlyTypeDays']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("arguments[0].click();", element);
            Clear(attributeName_id, "monthlyDays");
            SendKeys(attributeName_id, "monthlyDays", specificDay);

            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath, hours);
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath, minutes);

            if (meridiem == "PM")
            {
                Click(attributeName_xpath, "//div[@id='Tab_tabMonthly']//label[text()='PM']");
            }
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Clear(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            if (format == "PDF")
            {
                Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, format);
            }
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);
            
        }

        [Then(@"the Custom Report will be Scheduled for the selected Specific Month")]
        public void ThenTheCustomReportWillBeScheduledForTheSelectedSpecificMonth()
        {




            List<string> checkRunDate = crm.yearSelectionBasedOnSpecificMonth(month, specificDay, hours, minutes, meridiem);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//h1[contains(text(), 'Customer Invoices')]", "Customer Invoice Verbiage");



            string actualCreatedScheduledreportMonthly = Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/a/span");
            string expectedcreatedReportName = (selectedCustomReport + " (Scheduled - " + checkRunDate[0] + ")");
            Assert.AreEqual(expectedcreatedReportName, actualCreatedScheduledreportMonthly);

        }

        [Given(@"I entered all the required information by selecting all the Months(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnteredAllTheRequiredInformationBySelectingAllTheMonths(string testDataSpecificDay, string testDataHours, string testDataMinutes, string testDataMeridiem, string testDataTo, string testDataCC, string testDataReplyTo, string testDataFormat, string testDataSubject, string testDataComment)
        {
            specificDay = Regex.Replace(testDataSpecificDay, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            hours = Regex.Replace(testDataHours, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            minutes = Regex.Replace(testDataMinutes, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            meridiem = Regex.Replace(testDataMeridiem, @"(\s+|@|&|'|\(|\)|<|>|#)", "");

            to = Regex.Replace(testDataTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            cc = Regex.Replace(testDataCC, @"(\s+|&|'|\(|\)|<|>|#)", "");
            replyTo = Regex.Replace(testDataReplyTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            format = Regex.Replace(testDataFormat, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            subject = Regex.Replace(testDataSubject, @"(\s+|<|>)", "");
            Comment = Regex.Replace(testDataComment, @"(\s+|<|>)", "");

            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath("//label[@for='radioBtnMonthlyTypeDays']"));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("arguments[0].click();", element);
            Clear(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath);
            SendKeys(attributeName_id, "monthlyDays", specificDay);

            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath, hours);
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath, minutes);

            if (meridiem == "PM")
            {
                Click(attributeName_xpath, "//div[@id='Tab_tabMonthly']//label[text()='PM']");
            }
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Clear(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            if (format == "PDF")
            {
                Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, format);
            }
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);
        }

        [Then(@"the Custom Report will be Scheduled for all the Months")]
        public void ThenTheCustomReportWillBeScheduledForAllTheMonths()
        {
            
            List<string> checkRunDate = crm.yearSelectionBasedOnAllMonth(month, specificDay, hours, minutes, meridiem);


            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//h1[contains(text(), 'Customer Invoices')]", "Customer Invoice Verbiage");



            string actualCreatedScheduledreportMonthly = Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/a/span");
            string expectedcreatedReportName = (selectedCustomReport + " (Scheduled - " + checkRunDate[0] + ")");
            Assert.AreEqual(expectedcreatedReportName, actualCreatedScheduledreportMonthly);

                
        }

        [Given(@"I entered the required information by selecting two months(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnteredTheRequiredInformationBySelectingTwoMonths(string testDataMonth, string testDataSpecificDay, string testDataHours, string testDataMinutes, string testDataMeridiem, string testDataTo, string testDataCC, string testDataReplyTo, string testDataFormat, string testDataSubject, string testDataComment)
        {
            string twoMonth = Regex.Replace(testDataMonth, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            string[] _monthSplitted = twoMonth.Split(',');
            specificDay = Regex.Replace(testDataSpecificDay, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            hours = Regex.Replace(testDataHours, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            minutes = Regex.Replace(testDataMinutes, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            meridiem = Regex.Replace(testDataMeridiem, @"(\s+|@|&|'|\(|\)|<|>|#)", "");

            to = Regex.Replace(testDataTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            cc = Regex.Replace(testDataCC, @"(\s+|&|'|\(|\)|<|>|#)", "");
            replyTo = Regex.Replace(testDataReplyTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            format = Regex.Replace(testDataFormat, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            subject = Regex.Replace(testDataSubject, @"(\s+|<|>)", "");
            Comment = Regex.Replace(testDataComment, @"(\s+|<|>)", "");

            Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);

            for(int i=0; i< _monthSplitted.Length; i++)
            {
                switch(_monthSplitted[i])
                {
                    case "January":
                        {
                            Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
                            break;
                        }
                    case "February":
                        {
                            Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
                            break;
                        }
                    case "March":
                        {
                            Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
                            break;
                        }
                    case "April":
                        {
                            Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
                            break;
                        }
                    case "May":
                        {
                            Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
                            break;
                        }
                    case "June":
                        {
                            Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
                            break;
                        }
                    case "July":
                        {
                            Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
                            break;
                        }
                    case "August":
                        {
                            Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
                            break;
                        }
                    case "September":
                        {
                            Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
                            break;
                        }
                    case "October":
                        {
                            Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
                            break;
                        }
                    case "November":
                        {
                            Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
                            break;
                        }
                    case "December":
                        {
                            Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);
                            break;
                        }
                }
                
            }

            Click(attributeName_xpath, "");
            Clear(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath);
            SendKeys(attributeName_xpath, specificDay, "Specific Day selector");

            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath, hours);
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath, minutes);

            if (meridiem == "PM")
            {
                Click(attributeName_xpath, "//div[@id='Tab_tabMonthly']//label[text()='PM']");
            }
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Clear(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            if (format == "PDF")
            {
                Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, format);
            }
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);
        }

        [Then(@"the Custom Report will be Scheduled for all the two Months")]
        public void ThenTheCustomReportWillBeScheduledForAllTheTwoMonths()
        {
            List<string> checkRunDate = crm.yearSelectionbasedonMultipleMonths(month, _monthSplitted, specificDay, hours, minutes, meridiem);

            //Verifying the Created Scheduled Report Monthly in Select Exiting Customer Dropdown
            GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
                bool isScheduledReportPresent;
                IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']/div/ul/li"));
                List<string> cutomReportdropdownlist = new List<string>();
                for (int k = 0; k < CustInvoiceReportList.Count; k++)
                {
                    cutomReportdropdownlist.Add(CustInvoiceReportList[k].Text);
                }
                for (int k = 0; k < checkRunDate.Count; k++)
                {
                    string createdReportName = (selectedCustomReport + " (Scheduled - " + checkRunDate[k] + ")");
                    isScheduledReportPresent = cutomReportdropdownlist.Contains(selectedCustomReport + " (Scheduled - " + checkRunDate[k] + ")");
                    if (isScheduledReportPresent)
                    {
                        Report.WriteLine("Scheduled Report has been created and Verified in Select a Custom Report dropdown");
                    }
                    else if (k == 1 && isScheduledReportPresent == false)
                    {
                        throw new Exception("Scheduled Report is not created");
                    }
                }
        }

        [Given(@"I entered the required information by Week and Weed day(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnteredTheRequiredInformationByWeekAndWeedDay(string testDataMonth, string testDataWeek, string testDataWeekDay, string testDataHours, string testDataMinutes, string testDataMeridiem, string testDataTo, string testDataCC, string testDataReplyTo, string testDataFormat, string testDataSubject, string testDataComment)
        {
            //month = Regex.Replace(testDataMonth, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            //week = Regex.Replace(testDataWeek, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            //weekDay = Regex.Replace(testDataWeekDay, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            //hours = Regex.Replace(testDataHours, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            //minutes = Regex.Replace(testDataMinutes, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            //meridiem = Regex.Replace(testDataMeridiem, @"(\s+|@|&|'|\(|\)|<|>|#)", "");

            //to = Regex.Replace(testDataTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            //cc = Regex.Replace(testDataCC, @"(\s+|&|'|\(|\)|<|>|#)", "");
            //replyTo = Regex.Replace(testDataReplyTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            //format = Regex.Replace(testDataFormat, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            //subject = Regex.Replace(testDataSubject, @"(\s+|<|>)", "");
            //Comment = Regex.Replace(testDataComment, @"(\s+|<|>)", "");

            month = testDataMonth;
            week = testDataWeek;
            checkWeekData = testDataWeek;
            weekDay = testDataWeekDay;
            hours = testDataHours;
            minutes = testDataMinutes;
            meridiem = testDataMeridiem;

            to = testDataTo;
            cc = testDataCC;
            replyTo = testDataReplyTo;
            format = testDataFormat;
            subject = testDataSubject;
            Comment = testDataComment;

            Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
            Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);

            switch (month)
            {
                case "January":
                    {
                        Click(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Label_Xpath);
                        break;
                    }
                case "February":
                    {
                        Click(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Label_Xpath);
                        break;
                    }
                case "March":
                    {
                        Click(attributeName_xpath, CustomerInvoice_MarchCheckbox_Label_Xpath);
                        break;
                    }
                case "April":
                    {
                        Click(attributeName_xpath, CustomerInvoice_AprilCheckbox_Label_Xpath);
                        break;
                    }
                case "May":
                    {
                        Click(attributeName_xpath, CustomerInvoice_MayCheckbox_Label_Xpath);
                        break;
                    }
                case "June":
                    {
                        Click(attributeName_xpath, CustomerInvoice_JuneCheckbox_Label_Xpath);
                        break;
                    }
                case "July":
                    {
                        Click(attributeName_xpath, CustomerInvoice_JulyCheckbox_Label_Xpath);
                        break;
                    }
                case "August":
                    {
                        Click(attributeName_xpath, CustomerInvoice_AugustCheckbox_Label_Xpath);
                        break;
                    }
                case "September":
                    {
                        Click(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Label_Xpath);
                        break;
                    }
                case "October":
                    {
                        Click(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Label_Xpath);
                        break;
                    }
                case "November":
                    {
                        Click(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Label_Xpath);
                        break;
                    }
                case "December":
                    {
                        Click(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Label_Xpath);
                        break;
                    }
            }

            Click(attributeName_xpath, ".//*[@id='MonthlyWeek_chosen']/a");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='MonthlyWeek_chosen']/div/ul/li", week);
            Click(attributeName_xpath, ".//*[@id='MonthlyWeekDay_chosen']/a");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='MonthlyWeekDay_chosen']/div/ul/li", weekDay);

            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath, hours);
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath, minutes);

            if (meridiem == "PM")
            {
                Click(attributeName_xpath, "//div[@id='Tab_tabMonthly']//label[text()='PM']");
            }
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Clear(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            if (format == "PDF")
            {
                Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, format);
            }
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);
        }

        [Then(@"the Custom Report will be Scheduled for the selected Week and Week day")]
        public void ThenTheCustomReportWillBeScheduledForTheSelectedWeekAndWeekDay()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//h1[contains(text(), 'Customer Invoices')]", "Customer Invoice Verbiage");
            //List<string> checkRunDate = crm.yearSelectionBasedOnWeekAndWeekDay(month, week, weekDay, hours, minutes, meridiem);

            DateTime weekDay_date = new DateTime();

            var datetimeCST = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            int currentMonth = datetimeCST.Month;
            DateTime date = new DateTime();
            int _Year;
            DateTime _date = new DateTime();
            string givenWeek = week.Substring(0, 1);
            int _week = Convert.ToInt32(givenWeek);

            string setDay;
            int setMonth;

            int _year = 0;
            string monthTrimmed = month.Substring(0, 3);
            int _currentMonthInteger = Convert.ToInt32(datetimeCST.Month.ToString("00"));
            DateTime _month = DateTime.ParseExact(monthTrimmed, "MMM", CultureInfo.InvariantCulture);
            int numericMonth = _month.Month;




            if (numericMonth < _currentMonthInteger)
            {
                if (numericMonth < currentMonth)
                {
                    _year = (datetimeCST.Year + 1);
                }
                date = new DateTime(_year, numericMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);
                    //if (temp.DayOfWeek == (DayOfWeek.Tuesday))
                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;

                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;


                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }

                        else
                        {
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }

                    }

                }
                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;

                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    //else
                    //{   
                    //    nextRunDate = (weekDay_date.Date).ToString();
                    //}
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    //else
                    //{
                    //    nextRunDate = (weekDay_date.Date).ToString();
                    //}
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }

                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date; int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    //else
                    //{
                    //    nextRunDate = (weekDay_date.Date).ToString();
                    //}
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
            }

            if (numericMonth > _currentMonthInteger)
            {
                _year = (datetimeCST.Year);
                date = new DateTime(_year, numericMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);
                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        //else
                        //{
                        //    nextRunDate = (weekDay_date.Date).ToString();
                        //}
                        else
                        {
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                }
                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
            }

            if (numericMonth == _currentMonthInteger)
            {
                _year = (datetimeCST.Year);
                if (numericMonth < currentMonth)
                {
                    _year = (datetimeCST.Year + 1);
                }
                date = new DateTime(_year, numericMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);

                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }

                    }
                }

                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        //nextRunDate = (weekDay_date.Date).ToString();
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }

                int specDay = weekDay_date.Day;
                var datetime = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
                int currentDay = datetime.Day;
                if (specDay < currentDay)
                {
                    _year = (datetimeCST.Year + 1);
                    date = new DateTime(_year, numericMonth, 1);
                    for (int i = 0; i < 7; i++)
                    {
                        DateTime temp = date.AddDays(i);
                        if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                        {
                            _date = temp.Date;
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                    if (_week == 2)
                    {
                        _date = _date.AddDays(7);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 3)
                    {
                        _date = _date.AddDays(14);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 4)
                    {
                        _date = _date.AddDays(21);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    //int v = weekDay_date.Day;
                    //int p = weekDay_date.Month;
                    //int y = weekDay_date.Year;
                    //if (p == 2 && ((v == 28) || (v == 28) || (v == 28)))
                    //{
                    //    v = 28;
                    //}
                    //string rundate = p.ToString() + "/" + v.ToString() + "/" + y.ToString();
                }
                if (specDay > currentDay)
                {
                    _year = (DateTime.Now.Year + 0);
                    date = new DateTime(_year, numericMonth, 1);
                    for (int i = 0; i < 7; i++)
                    {
                        DateTime temp = date.AddDays(i);
                        if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                        {
                            _date = temp.Date;
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                    if (_week == 2)
                    {
                        _date = _date.AddDays(7);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 3)
                    {
                        _date = _date.AddDays(14);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                    if (_week == 4)
                    {
                        _date = _date.AddDays(21);
                        weekDay_date = _date;
                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;
                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }
                        else
                        {
                            //nextRunDate = (weekDay_date.Date).ToString();
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }
                    }
                }
                if (specDay == currentDay)
                {
                    var _currentTimeCheck = datetime.ToString("hh:mm tt");
                    DateTime currentTime = Convert.ToDateTime(_currentTimeCheck);
                    var timeFormatBefore = hours + ":" + minutes + meridiem;
                    DateTime timeFormatAfter = Convert.ToDateTime(timeFormatBefore);
                    int dt = DateTime.Compare(currentTime, timeFormatAfter);
                    if (dt <= 0)
                    {
                        _year = (datetimeCST.Year);
                        date = new DateTime(_year, numericMonth, 1);
                        for (int i = 0; i < 7; i++)
                        {
                            DateTime temp = date.AddDays(i);
                            if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                            {
                                _date = temp.Date;
                                weekDay_date = _date;
                                int checkDay = weekDay_date.Day;
                                int checkMonth = weekDay_date.Month;
                                int years = weekDay_date.Year;
                                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                                {
                                    setDay = "28";
                                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                                }
                                else
                                {
                                    //nextRunDate = (weekDay_date.Date).ToString();
                                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                                }
                            }
                        }
                        if (_week == 2)
                        {
                            _date = _date.AddDays(7);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 3)
                        {
                            _date = _date.AddDays(14);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 4)
                        {
                            _date = _date.AddDays(21);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                    else
                    {
                        _year = (datetimeCST.Year + 1);
                        date = new DateTime(_year, numericMonth, 1);
                        for (int i = 0; i < 7; i++)
                        {
                            DateTime temp = date.AddDays(i);
                            if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                            {
                                _date = temp.Date;
                                weekDay_date = _date;
                                int checkDay = weekDay_date.Day;
                                int checkMonth = weekDay_date.Month;
                                int years = weekDay_date.Year;
                                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                                {
                                    setDay = "28";
                                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                                }
                                else
                                {
                                    //nextRunDate = (weekDay_date.Date).ToString();
                                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                                }
                            }

                        }
                        if (_week == 2)
                        {
                            _date = _date.AddDays(7);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 3)
                        {
                            _date = _date.AddDays(14);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;
                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                        if (_week == 4)
                        {
                            _date = _date.AddDays(21);
                            weekDay_date = _date;
                            int checkDay = weekDay_date.Day;
                            int checkMonth = weekDay_date.Month;
                            int years = weekDay_date.Year;

                            if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                            {
                                setDay = "28";
                                nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                            }
                            else
                            {
                                //nextRunDate = (weekDay_date.Date).ToString();
                                nextRunDate = FormattingDate(checkDay, checkMonth, years);
                            }
                        }
                    }
                }



            }

                string actualCreatedScheduledreportMonthly = Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/a/span");
            string expectedcreatedReportName = (selectedCustomReport + " (Scheduled - " + nextRunDate + ")");
            Assert.AreEqual(expectedcreatedReportName, actualCreatedScheduledreportMonthly);

        }

        [When(@"I click on the Monthly Time Period tab")]
        public void WhenIClickOnTheMonthlyTimePeriodTab()
        {
            WaitForElementVisible(attributeName_xpath, ".//*[@id='modalScheduleCustomReport']//*[text()='Time Period']", "Time Period Verbiage");
            Click(attributeName_xpath, CustomerInvoice_MonthlyTab_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//*[@id='modalScheduleCustomReport']//*[text()='SELECT MONTHS *']", "SELECT MONTHS label");
        }

        [Then(@"the Cancel and Schedule Report buttons will be Active")]
        public void ThenTheCancelAndScheduleReportButtonsWillBeActive()
        {
            VerifyElementEnabled(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule button");
            VerifyElementEnabled(attributeName_id, "btnScheduleReport", "Schedule Report button");
        }

        [When(@"I select this created Monthly Schedule Report from the Select Existing Custom Report from the dropdown")]
        public void WhenISelectThisCreatedMonthlyScheduleReportFromTheSelectExistingCustomReportFromTheDropdown()
        {


            Click(attributeName_id, "DaysPastDue");
            SendKeys(attributeName_id, "InvoiceValue", "1");
            Thread.Sleep(1000);
            Click(attributeName_id, scheduleReportButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will see all the information while creating the Report is now binded in the Monthly tab")]
        public void ThenIWillSeeAllTheInformationWhileCreatingTheReportIsNowBindedInTheMonthlyTab()
        {

            //ScheduledReportMonthlyData dataInput = new ScheduledReportMonthlyData();


            switch (month)
            {
                case "January":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January Month Checkbox");
                        break;
                    }
                case "February":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath, "February Month Checkbox");
                        break;
                    }
                case "March":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March Month Checkbox");
                        break;
                    }
                case "April":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath, "April Month Checkbox");
                        break;
                    }
                case "May":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May Month Checkbox");
                        break;
                    }
                case "June":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June Month Checkbox");
                        break;
                    }
                case "July":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath, "July Month Checkbox");
                        break;
                    }
                case "August":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August Month Checkbox");
                        break;
                    }
                case "September":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September Month Checkbox");
                        break;
                    }
                case "October":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October Month Checkbox");
                        break;
                    }
                case "November":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November Month Checkbox");
                        break;
                    }
                case "December":
                    {
                        VerifyElementChecked(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December Month Checkbox");
                        break;
                    }
            }

                Thread.Sleep(2000);
                string weekUI = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeek_DropDown_Xpath);
                Assert.AreEqual(weekUI, "1st");
                string weekDayUI = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
                Assert.AreEqual(weekDayUI, "Sunday");
                string specificDayUI = GetValue(attributeName_id, "monthlyDays", "value");
                Assert.AreEqual(specificDay, specificDayUI);    

            string hoursUI = Gettext(attributeName_xpath, ".//*[@id='monthlyhours_chosen']/a");
            Assert.AreEqual(hoursUI, hours);
            string minutesUI = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            Assert.AreEqual(minutesUI, minutes);
            if (meridiem == "AM")
            {
                VerifyElementChecked(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath, "AM");
            }
            else if (meridiem == "PM")
            {
                VerifyElementChecked(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyPM_Button_Xpath, "AM");
            }
            string toUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            Assert.AreEqual(toUI, to);
            string ccUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            Assert.AreEqual(ccUI, cc);
            string replyToUI = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            Assert.AreEqual(replyToUI, replyTo);

            string formatUI = Gettext(attributeName_xpath, ".//*[@id='formatEmail_chosen']/a");
            Assert.AreEqual(formatUI, format);
            
            string subjectUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            Assert.AreEqual(subjectUI, subject);

            string commetUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname, "value");
            Assert.AreEqual(commetUI, Comment);

        }

        [Given(@"I entered the required information by selecting all months Week and Weed day(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnteredTheRequiredInformationBySelectingAllMonthsWeekAndWeedDay(string testDataWeek, string testDataWeekDay, string testDataHours, string testDataMinutes, string testDataMeridiem, string testDataTo, string testDataCC, string testDataReplyTo, string testDataFormat, string testDataSubject, string testDataComment)

        {

            selectedCustomReport = Gettext(attributeName_xpath, CustomerInvoice_SelectedReportName_Monthly_Xpath);

            week = testDataWeek;
            checkWeekData = testDataWeek;
            weekDay = testDataWeekDay;
            hours = testDataHours;
            minutes = testDataMinutes;
            meridiem = testDataMeridiem;

            to = testDataTo;
            cc = testDataCC;
            replyTo = testDataReplyTo;
            format = testDataFormat;
            subject = testDataSubject;
            Comment = testDataComment;

            Click(attributeName_xpath, ".//*[@id='MonthlyWeek_chosen']/a");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='MonthlyWeek_chosen']/div/ul/li", week);
            Click(attributeName_xpath, ".//*[@id='MonthlyWeekDay_chosen']/a");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='MonthlyWeekDay_chosen']/div/ul/li", weekDay);

            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath, hours);
            Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath, minutes);

            if (meridiem == "PM")
            {
                Click(attributeName_xpath, "//div[@id='Tab_tabMonthly']//label[text()='PM']");
            }
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Clear(attributeName_id, ReportDeliveryOptions_Subject_id);
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            if (format == "PDF")
            {
                Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportDeliveryOptions_FormatDropdownValues_Xpath, format);
            }
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);
        }




        [Then(@"I will see all the information for all months Week and Weed day is autopopulated in the Monthly tab")]
        public void ThenIWillSeeAllTheInformationForAllMonthsWeekAndWeedDayIsAutopopulatedInTheMonthlyTab()
        {

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath, "February Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March Month Checkbox");


            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath, "April Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath, "July Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November Month Checkbox");

            VerifyElementChecked(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December Month Checkbox");


            Report.WriteLine("Week and Weekday existence and verification");
            string weekUI = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeek_DropDown_Xpath);
            Assert.AreEqual(weekUI, checkWeekData);
            string weekDayUI = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
            Assert.AreEqual(weekDayUI, weekDay);
            string specificDayUI = GetValue(attributeName_id, "monthlyDays", "value");
            Assert.AreEqual(specificDayUI, "1");

            string hoursUI = Gettext(attributeName_xpath, ".//*[@id='monthlyhours_chosen']/a");
            Assert.AreEqual(hoursUI, hours);
            string minutesUI = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            Assert.AreEqual(minutesUI, minutes);
            if (meridiem == "AM")
            {
                VerifyElementChecked(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath, "AM");
            }
            else if (meridiem == "PM")
            {
                VerifyElementChecked(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyPM_Button_Xpath, "AM");
            }
            string toUI = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            Assert.AreEqual(toUI, to);
            string ccUI = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            Assert.AreEqual(ccUI, cc);
            string replyToUI = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            Assert.AreEqual(replyToUI, replyTo);

            string formatUI = Gettext(attributeName_xpath, ".//*[@id='formatEmail_chosen']/a");
            Assert.AreEqual(formatUI, format);

            //string timeFormat = hours + ":" + minutes + meridiem;
            //string subjectExpected = subject + "{" + selectedCustomReport + "}" + "was processed on" + checkRunDate[0] + " " + timeFormat;


            string subjectUI = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            //Assert.AreEqual(subjectUI, subjectExpected);
            Assert.AreEqual(subjectUI, subject);

            string commetUI = GetValue(attributeName_classname, ReportDeliveryOptions_Comment_classname, "value");
            Assert.AreEqual(commetUI, Comment);
        }

        public string FormattingDate(int checkDay, int checkMonth, int years)
        {



            if (((checkMonth >= 0) && (checkMonth <= 9)) && ((checkDay >= 0) && (checkDay <= 9)))
            {
                //numericMonth.ToString();
                nextRunDate = ("0" + checkMonth).ToString() + "/" + ("0" + checkDay).ToString() + "/" + years;
            }
            else if (((checkMonth >= 0) && (checkMonth <= 9)) && !((checkDay >= 0) && (checkDay <= 9)))
            {
                //numericMonth.ToString();
                nextRunDate = ("0" + checkMonth).ToString() + "/" + (checkDay).ToString() + "/" + years;
            }
            else if (((checkDay >= 0) && (checkDay <= 9)) && !((checkMonth >= 0) && (checkMonth <= 9)))
            {
                nextRunDate = (checkMonth).ToString() + "/" + ("0" + checkDay).ToString() + "/" + years;
            }
            else
            {
                nextRunDate = checkMonth.ToString() + "/" + checkDay + "/" + years;
            }

            return nextRunDate;
        }

        [Then(@"the Custom Report will be scheduled for selected week and Weekday for the current Month")]
        public void ThenTheCustomReportWillBeScheduledForSelectedWeekAndWeekdayForTheCurrentMonth()
        {



            DateTime weekDay_date = new DateTime();

            var datetimeCST = TimeZoneInfo.ConvertTime((DateTime.Now), TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time"));
            int currentMonth = datetimeCST.Month;
            DateTime date = new DateTime();
            int _Year;
            DateTime _date = new DateTime();
            string givenWeek = week.Substring(0, 1);
            int _week = Convert.ToInt32(givenWeek);

            string setDay;
            int setMonth;

            int _year = 0;

            int CurrentMonth = datetimeCST.Month;

            _year = (datetimeCST.Year);

            date = new DateTime(_year, CurrentMonth, 1);
            for (int i = 0; i < 7; i++)
            {
                DateTime temp = date.AddDays(i);
                if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                {
                    _date = temp.Date;
                    weekDay_date = _date;

                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;


                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }

                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }

                }

            }


            if (_week == 2)
            {
                _date = _date.AddDays(7);
                weekDay_date = _date;

                int checkDay = weekDay_date.Day;
                int checkMonth = weekDay_date.Month;
                int years = weekDay_date.Year;
                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                {
                    setDay = "28";
                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                }

                else
                {
                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                }
            }
            if (_week == 3)
            {
                _date = _date.AddDays(14);
                weekDay_date = _date;
                int checkDay = weekDay_date.Day;
                int checkMonth = weekDay_date.Month;
                int years = weekDay_date.Year;
                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                {
                    setDay = "28";
                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                }

                else
                {
                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                }

            }
            if (_week == 4)
            {
                _date = _date.AddDays(21);
                weekDay_date = _date; int checkDay = weekDay_date.Day;
                int checkMonth = weekDay_date.Month;
                int years = weekDay_date.Year;
                if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                {
                    setDay = "28";
                    nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                }
                else
                {
                    nextRunDate = FormattingDate(checkDay, checkMonth, years);
                }
            }

            int revMonth;
            weekDay_date = weekDay_date.Date;
            var time = hours + ":" + minutes + ":" + meridiem;
            int hrs = Convert.ToInt32(hours);
            int hour = meridiem == "AM" ? Convert.ToInt32(hrs) : Convert.ToInt32(hrs + 12);
            //DateTime timess = new DateTime(datetimeCST.Year, datetimeCST.Month, datetimeCST.Day, hour, Convert.ToInt32(minutes), 0);
            DateTime timess = new DateTime(weekDay_date.Year, weekDay_date.Month, weekDay_date.Day, hour, Convert.ToInt32(minutes), 0);
            //  DateTime timess = Convert.ToDateTime(weekDay_date + " " + time);
            int check = DateTime.Compare(timess, datetimeCST);
            //-1 date overed
            //1 not over



            if (check <= 0)
            {
                DateTime revisedyear = datetimeCST.AddYears(0);
                _year = revisedyear.Year;
                if (datetimeCST.Month == 12)
                {
                    //revisedyear = datetimeCST.AddYears(1);
                    //int revYear = revisedyear.Year;
                    _year = _year + 1;
                    revMonth = 1;
                }
                else
                {
                    DateTime revisedMonth = datetimeCST.AddMonths(1);
                    revMonth = revisedMonth.Month;
                }
                date = new DateTime(_year, revMonth, 1);
                for (int i = 0; i < 7; i++)
                {
                    DateTime temp = date.AddDays(i);
                    if (temp.DayOfWeek == (DayOfWeek)Enum.Parse(typeof(DayOfWeek), weekDay))
                    {
                        _date = temp.Date;
                        weekDay_date = _date;

                        int checkDay = weekDay_date.Day;
                        int checkMonth = weekDay_date.Month;
                        int years = weekDay_date.Year;


                        if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                        {
                            setDay = "28";
                            nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                        }

                        else
                        {
                            nextRunDate = FormattingDate(checkDay, checkMonth, years);
                        }

                    }

                }


                if (_week == 2)
                {
                    _date = _date.AddDays(7);
                    weekDay_date = _date;

                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }

                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }
                if (_week == 3)
                {
                    _date = _date.AddDays(14);
                    weekDay_date = _date;
                    int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }

                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }

                }
                if (_week == 4)
                {
                    _date = _date.AddDays(21);
                    weekDay_date = _date; int checkDay = weekDay_date.Day;
                    int checkMonth = weekDay_date.Month;
                    int years = weekDay_date.Year;
                    if (checkMonth == 02 && ((checkDay == 29) || (checkDay == 30)))
                    {
                        setDay = "28";
                        nextRunDate = (weekDay_date.Month).ToString() + "/" + (setDay).ToString() + "/" + weekDay_date.Year;
                    }
                    else
                    {
                        nextRunDate = FormattingDate(checkDay, checkMonth, years);
                    }
                }


            }

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//h1[contains(text(), 'Customer Invoices')]", "Customer Invoice Verbiage");

            string actualCreatedScheduledreportMonthly = Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/a/span");
            string expectedcreatedReportName = (selectedCustomReport + " (Scheduled - " + nextRunDate + ")");
            Assert.AreEqual(expectedcreatedReportName, actualCreatedScheduledreportMonthly);

        }

        [When(@"I click Schedule Report button")]
        public void WhenIClickScheduleReportButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, "btnScheduleReport");
        }


    }
}