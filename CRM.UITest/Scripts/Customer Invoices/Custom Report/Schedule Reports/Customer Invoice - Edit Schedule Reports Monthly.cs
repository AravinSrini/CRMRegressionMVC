using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class Customer_Invoice___Edit_Schedule_Reports_Monthly : Customer_Invoice
    {
        string email=ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();

        CommonMethodsCrm crm = new CommonMethodsCrm();
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
        string activeScheduledCustomReportName;
        List<string> checkRunDate;

        [Given(@"I selected a Custom report with an active schedule associated as monthly from drop downlist")]
        public void GivenISelectedACustomReportWithAnActiveScheduleAssociatedAsMonthlyFromDropDownlist()
        {
            Report.WriteLine("selecting existing weekly active scheduled custom report from custom report dropdown");
            Report.WriteLine("Navigate to Customer Invoices Page");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            activeScheduledCustomReportName = DBHelper.GetMonthlyActiveCustomReportName(email);
            
            Click(attributeName_id, SelectExistingReportDropdown_id);
           
            IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            for (int i = 1; i < CustInvoiceReportList.Count; i++)
            {
               
                if (CustInvoiceReportList[i].Text.Contains(activeScheduledCustomReportName+" (Scheduled"))
                {
                    CustInvoiceReportList[i].Click();
                    break;
                    
                }

            }


            Report.WriteLine("Click on schedule report button on creat custom report section");
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Click(attributeName_id, scheduleReportButton_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, customReportModalHeader_xpath, "Reportname");
        }

        [Given(@"I arrived on the Monthly tab of the Schedule Report page")]
        public void GivenIArrivedOnTheMonthlyTabOfTheScheduleReportPage()
        {
            Report.WriteLine("Verifying user is in monthly scheduled tab");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "SELECT MONTHS *");
            
        }


        [Given(@"I edited month (.*)")]
        public void GivenIEditedMonth(string testDataMonth)
        {

            month = testDataMonth;
            UnSelectMonthCheckBoxes();
            selectOneMonthCheckBox(month);


            hours = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            minutes = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);

            IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath));
            if (am.Selected)
            {
                meridiem = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyAM_Label_Xpath);
            }
            else
            {
                meridiem = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyPM_Label_Xpath);
            }


          

            IWebElement amUI = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath));
            if (amUI.Selected)
            {
                meridiem = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyAM_Label_Xpath);
            }
            else
            {
                meridiem = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyPM_Label_Xpath);
            }
          
            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectDayMonthlyWeeks_RadioButton_Xpath));
            if (element.Selected)
            {
                week = Gettext(attributeName_xpath, "//div[@id='MonthlyWeek_chosen']/a/span");
                
                weekDay = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
                checkRunDate = crm.yearSelectionBasedOnWeekAndWeekDay(month, week, weekDay, hours, minutes, meridiem);
            }
            else
            {
                specificDay = GetAttribute(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath, "value");
                checkRunDate = crm.yearSelectionBasedOnSpecificMonth(month, specificDay, hours, minutes, meridiem);
            }

        }

        [When(@"I click on the Schedule Report button on scheduled monthly page")]
        public void WhenIClickOnTheScheduleReportButtonOnScheduledMonthlyPage()
        {
            Report.WriteLine("Click on Schedule Report button");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_xpath, schedulePageScheduleReportButton_Xpath);
            Click(attributeName_xpath, schedulePageScheduleReportButton_Xpath);
        }



        [Given(@"I edited week and weekDay or specificDay (.*),(.*),(.*),(.*)")]
        public void GivenIEditedWeekAndWeekDayOrSpecificDay(string enteredMonth,string enteredWeek, string enteredWeekDay, string enteredSpecificDay)
        {
            month = enteredMonth;

            hours = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            minutes = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);


            IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath));
            if (am.Selected)
            {
                meridiem = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyAM_Label_Xpath);
            }
            else
            {
                meridiem = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyPM_Label_Xpath);
            }

          
            UnSelectMonthCheckBoxes();
            selectOneMonthCheckBox(month);
            

            IWebElement element = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectDayMonthlyWeeks_RadioButton_Xpath));
            if (element.Selected)
            {
                week = enteredWeek;
                weekDay = enteredWeekDay;

                Click(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeek_DropDown_Xpath);
               
                    IList<IWebElement> CustInvoiceMonthWeekList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectDayMonthlyWeek_DropDownValues_Xpath));
                    for (int i = 0; i < CustInvoiceMonthWeekList.Count; i++)
                    {

                        if (CustInvoiceMonthWeekList[i].Text == week)
                        {
                            CustInvoiceMonthWeekList[i].Click();
                            break;

                        }

                    }
                
                Click(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
                IList<IWebElement> CustInvoiceMonthWeekDayList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectDayMonthlyWeekDay_DropDownValues_Xpath));
                for (int i = 0; i < CustInvoiceMonthWeekDayList.Count; i++)
                {

                    if (CustInvoiceMonthWeekDayList[i].Text == weekDay)
                    {
                        CustInvoiceMonthWeekDayList[i].Click();
                        break;

                    }

                }

                
                checkRunDate = crm.yearSelectionBasedOnWeekAndWeekDay(month, week, weekDay, hours, minutes, meridiem);
            }
            else
            {
                specificDay = enteredSpecificDay;
                SendKeys(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath, specificDay);
                checkRunDate = crm.yearSelectionBasedOnSpecificMonth(month, specificDay, hours, minutes, meridiem);
            }
        }


        [Given(@"I edited week Report Details Options (.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEditedWeekReportDetailsOptions(string emailTo, string emailCC, string emailReplyTo, string emailFormat, string emailSubject, string emailComment)
        {
            to = Regex.Replace(emailTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            cc = Regex.Replace(emailCC, @"(\s+|&|'|\(|\)|<|>|#)", "");
            replyTo = Regex.Replace(emailReplyTo, @"(\s+|&|'|\(|\)|<|>|#)", "");
            format = Regex.Replace(emailFormat, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            subject = Regex.Replace(emailSubject, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            Comment = Regex.Replace(emailComment, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            

            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            if (format.ToUpper() == "EXCEL")
            {
                Click(attributeName_xpath, ".//*[@id='formatEmail_chosen']/div/ul/li[1]");
            }
            else
            {
                Click(attributeName_xpath, ".//*[@id='formatEmail_chosen']/div/ul/li[2]");
            }
           
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);


        }


        [Then(@"the scheduled report with the previous criteria will be updated")]
        public void ThenTheScheduledReportWithThePreviousCriteriaWillBeUpdated()
        {
           

            MonthyScheduledReportViewModel monthlyReportDetails = DBHelper.GetMonthlyCustomReportDetails(activeScheduledCustomReportName);
            //Verify modify values with db values
            
            
            Assert.AreEqual(monthlyReportDetails.EmailTo, to);
        
            Assert.AreEqual(monthlyReportDetails.EmailCC, cc);
            Assert.AreEqual(monthlyReportDetails.EmailReplyTo, replyTo);

            Assert.AreEqual(monthlyReportDetails.ReportFormat.ToUpper(), format.ToUpper());
            Assert.AreEqual(monthlyReportDetails.EmailSubject.ToUpper(), subject.ToUpper());
            Assert.AreEqual(monthlyReportDetails.Comment.ToUpper(), Comment.ToUpper());

        }


        [Then(@"the scheduled report with the previous criteria will be deleted")]
        public void ThenTheScheduledReportWithThePreviousCriteriaWillBeDeleted()
        {
            MonthyScheduledReportViewModel monthlyReportDetails = DBHelper.GetMonthlyCustomReportDetails(activeScheduledCustomReportName);
            //Verify modify values with db values

            //string givenWeek = week.Substring(0, 1);


            string givenWeek = null;
            if (week!=null)
            {
                givenWeek = week.Substring(0, 1);
                Assert.AreEqual(monthlyReportDetails.Week, Convert.ToInt32(givenWeek));
            }
            else
            {
               
                Assert.AreEqual(monthlyReportDetails.Week, givenWeek);
            }


            Assert.AreEqual(monthlyReportDetails.WeekDay, weekDay);


       
            if (specificDay != null)
            {
               
                Assert.AreEqual(monthlyReportDetails.DayOfMonth, Convert.ToInt32(specificDay));
            }
            else
            {

                Assert.AreEqual(monthlyReportDetails.DayOfMonth, specificDay);
            }

            string givenhours=null;
            if (monthlyReportDetails.MonthlyReportTime.Hours < 10)
            {
                givenhours = hours.Substring(1, 1);
                Assert.AreEqual(monthlyReportDetails.MonthlyReportTime.Hours, Convert.ToInt32(givenhours));
            }
            else if (monthlyReportDetails.MonthlyReportTime.Hours > 12)
            {
              
                int newtime= 12 + (Convert.ToInt32(hours));
                Assert.AreEqual(monthlyReportDetails.MonthlyReportTime.Hours, newtime);

            }else
            {
                givenhours = hours;
                Assert.AreEqual(monthlyReportDetails.MonthlyReportTime.Hours, givenhours);
            }
          

            string givenminutes = null;
            if (monthlyReportDetails.MonthlyReportTime.Minutes < 10)
            {
                givenminutes = minutes.Substring(1, 1);
            }
            else
            {
                givenminutes = minutes;
            }

            Assert.AreEqual(monthlyReportDetails.MonthlyReportTime.Minutes, Convert.ToInt32(givenminutes));
          
        }

        [Then(@"a new report will be scheduled with the updated criteria\.")]
        public void ThenANewReportWillBeScheduledWithTheUpdatedCriteria_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SelectExistingReportDropdown_id);
            bool isScheduledReportPresent;
            IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']/div/ul/li"));
            List<string> cutomReportdropdownlist = new List<string>();
            for (int i = 0; i < CustInvoiceReportList.Count; i++)
            {
                cutomReportdropdownlist.Add(CustInvoiceReportList[i].Text);
            }
            for (int i = 0; i < checkRunDate.Count; i++)
            {
                string createdReportName = (activeScheduledCustomReportName + " (Scheduled - " + checkRunDate[i] + ")");
                isScheduledReportPresent = cutomReportdropdownlist.Contains(createdReportName);
                if (isScheduledReportPresent)
                {
                    Report.WriteLine("Scheduled Report has been created and Verified in Select a Custom Report dropdown");
                    break;
                }
                
                else
                {
                    Report.WriteFailure("Scheduled Report is not created");
                }

            }
        }


        [Given(@"I edited any of the fields (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEditedAnyOfTheFields(string dayValues, string TimeHourValues, string TimeMinuteValues, string Meridiem, string email_To, string email_CC, string email_Reply, string email_Format, string email_Subject, string email_Comments)
        {


            weekDay =  Regex.Replace(dayValues, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            hours =  Regex.Replace(TimeHourValues, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            minutes =  Regex.Replace(TimeMinuteValues, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            meridiem =  Regex.Replace(Meridiem, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            to =  Regex.Replace(email_To, @"(\s+|&|'|\(|\)|<|>|#)", "");
            cc =  Regex.Replace(email_CC, @"(\s+|&|'|\(|\)|<|>|#)", "");
            replyTo =  Regex.Replace(email_Reply, @"(\s+|&|'|\(|\)|<|>|#)", "");
            format =  Regex.Replace(email_Format, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            subject =  Regex.Replace(email_Subject, @"(\s+|@|&|'|\(|\)|<|>|#)", "");
            Comment = Regex.Replace(email_Comments, @"(\s+|@|&|'|\(|\)|<|>|#)", "");

           

            Click(attributeName_xpath, selectday);
            IList<IWebElement> CustInvoiceWeeklyDayList = GlobalVariables.webDriver.FindElements(By.XPath(selectdayValues));
            for (int i = 0; i < CustInvoiceWeeklyDayList.Count; i++)
            {

                if (CustInvoiceWeeklyDayList[i].Text == weekDay)
                {
                    CustInvoiceWeeklyDayList[i].Click();
                    break;

                }

            }

           
            Click(attributeName_xpath, selectTimeHour);
            IList<IWebElement> CustInvoiceWeekHoursList = GlobalVariables.webDriver.FindElements(By.XPath(selectTimeHourValues));
            for (int i = 0; i < CustInvoiceWeekHoursList.Count; i++)
            {

                if (CustInvoiceWeekHoursList[i].Text == hours)
                {
                    CustInvoiceWeekHoursList[i].Click();
                    break;

                }

            }
            
            Click(attributeName_xpath, selectTimeMinute);
            IList<IWebElement> CustInvoiceWeekMinutesList = GlobalVariables.webDriver.FindElements(By.XPath(selectTimeMinuteValues));
            for (int i = 0; i < CustInvoiceWeekMinutesList.Count; i++)
            {

                if (CustInvoiceWeekMinutesList[i].Text == minutes)
                {
                    CustInvoiceWeekMinutesList[i].Click();
                    break;

                }

            }
            SendKeys(attributeName_id, ReportDeliveryOptions_To_id, to);
            SendKeys(attributeName_id, ReportDeliveryOptions_CC_id, cc);
            SendKeys(attributeName_id, ReportDeliveryOptions_ReplyTo_id, replyTo);
            Click(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            if (format.ToUpper() == "EXCEL")
            {
                Click(attributeName_xpath, ".//*[@id='formatEmail_chosen']/div/ul/li[1]");
            }
            else
            {
                Click(attributeName_xpath, ".//*[@id='formatEmail_chosen']/div/ul/li[2]");
            }
            SendKeys(attributeName_id, ReportDeliveryOptions_Subject_id, subject);
            SendKeys(attributeName_classname, ReportDeliveryOptions_Comment_classname, Comment);
        }


        [Then(@"Monthly schedule report will be updated to weekly report")]
        public void ThenMonthlyScheduleReportWillBeUpdatedToWeeklyReport()
        {
           bool value= DBHelper.GetScheduledReporMonthlyorWeekly(activeScheduledCustomReportName);


            WeeklyScheduleReportViewModel customReportDetails = DBHelper.GetWeeklyCustomReportDetails(activeScheduledCustomReportName);

            //displaying values in UI
            
            Assert.AreEqual(customReportDetails.WeekDay, weekDay);
           
          
            Assert.AreEqual(customReportDetails.EmailTo, to);
           
            Assert.AreEqual(customReportDetails.EmailCC, cc);
            
            Assert.AreEqual(customReportDetails.EmailReplyTo, replyTo);
           
            Assert.AreEqual(customReportDetails.ReportFormat.ToUpper(), format.ToUpper());
           
            Assert.AreEqual(customReportDetails.EmailSubject.ToUpper(), subject.ToUpper());
           
            Assert.AreEqual(customReportDetails.Comment.ToUpper(), Comment.ToUpper());
        }


        [Given(@"I arrived on the Weekly tab of the Schedule Report page")]
        public void GivenIArrivedOnTheWeeklyTabOfTheScheduleReportPage()
        {
            Click(attributeName_xpath, CustomerInvoice_WeeklyTab_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, CustomerInvoice_WeeklyTab_Xpath, "WEEKLY");
        }


        public void selectOneMonthCheckBox(string month)
        {
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

        }
        public void UnSelectMonthCheckBoxes()
        {

            MonthyScheduledReportViewModel monthlyReportDetails = DBHelper.GetMonthlyCustomReportDetails(activeScheduledCustomReportName);

            string scheduledMonth = monthlyReportDetails.Months.ToString();

            string[] s = scheduledMonth.Split(',');


           for(int i = 0; i < s.Count(); i++) {
                switch (s[i])
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
        }
    }
}
