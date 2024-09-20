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
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class Customer_Invoice___Delete_Schedule_Reports___WeeklySteps : Customer_Invoice
    {

        public string Useremailid;
        public string Reportnameselected;
        public string AfterDeletingReportName;
        public string MyReport = "TestReportForInternal_1";

        [Given(@"I selected a weekly Custom report with an active schedule associated from the drop down list")]
        public void GivenISelectedAWeeklyCustomReportWithAnActiveScheduleAssociatedFromTheDropDownList()
        {
            CustomerInvoice_ReportingOptionsSteps obj = new CustomerInvoice_ReportingOptionsSteps();
            Useremailid = obj.Useremailid;
            string ScheduledMonthlyActiveReport = DBHelper.GetWeeklyActiveCustomReportName(Useremailid);

            if (ScheduledMonthlyActiveReport != null)
            {
                Report.WriteLine("I selected a monthly custom report with an active schedule associated fromthe drop down list");
                Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

                IList<IWebElement> CustomReportDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
                int CustomReportCount = CustomReportDropdown_List.Count;
                for (int i = 0; i < CustomReportCount; i++)
                {
                    if (CustomReportDropdown_List[i].Text.Contains(ScheduledMonthlyActiveReport))
                    {
                        Reportnameselected = ScheduledMonthlyActiveReport;
                        CustomReportDropdown_List[i].Click();
                        break;
                    }
                }
            }

            else if (ScheduledMonthlyActiveReport == null)
            {
                Report.WriteLine("I selected a monthly custom report with an active schedule associated fromthe drop down list");
                Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

                IList<IWebElement> CustomReportDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
                int CustomReportCount = CustomReportDropdown_List.Count;

                if (CustomReportCount > 0)
                {
                    Reportnameselected = CustomReportDropdown_List[1].Text;
                    CustomReportDropdown_List[1].Click();
                }

                Report.WriteLine("Expand the Custom Report Section");
                Click(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath);

                Report.WriteLine("Click on Schedule Report Button");
                WaitForElementVisible(attributeName_id, scheduleReportButton_id, "ScheduleReport");
                Click(attributeName_id, scheduleReportButton_id);

                Report.WriteLine("Verify the tab is defaulted to weekly timeperiod");
                
                WaitForElementVisible(attributeName_xpath, WeeklyTabScheduleReport_SELECTDAY_xpath, "Weekly");


                Report.WriteLine("Select the day");
                Click(attributeName_xpath, Weekly_SelectDay_xpath);

                IList<IWebElement> DaysDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Weekly_SelectDay_Values_xpath));
                int DaysDropdown_ListCount = DaysDropdown_List.Count;
                for (int i = 0; i < DaysDropdown_ListCount; i++)
                {
                    if (DaysDropdown_List[i].Text == "Tuesday")
                    {
                        DaysDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Select the Time");
                Click(attributeName_xpath, Weekly_SelectTimeHours_xpath);

                IList<IWebElement> HoursDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(Weekly_SelectTimeHours_Values_xpath));
                int HoursDropdown_ListCount = HoursDropdown_List.Count;
                for (int i = 0; i < HoursDropdown_ListCount; i++)
                {
                    if (HoursDropdown_List[i].Text == "01")
                    {
                        HoursDropdown_List[i].Click();
                        break;
                    }
                }

                Click(attributeName_xpath, selectTimeMinute);

                IList<IWebElement> MinutesDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(selectTimeMinuteValues));
                int MinutesDropdown_ListCount = MinutesDropdown_List.Count;
                for (int i = 0; i < MinutesDropdown_ListCount; i++)
                {
                    if (MinutesDropdown_List[i].Text == "30")
                    {
                        MinutesDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Enter the email id in To field");
                SendKeys(attributeName_id, ReportDeliveryOptions_To_id, "test@test.com");

               
                scrollElementIntoView(attributeName_id, customReportModal_ScheduleReport_id);
                Report.WriteLine("Click on Schedule Report Button");
                Click(attributeName_id, customReportModal_ScheduleReport_id);

                //------------------------------------------------------------------------------------

                string IsScheduledReport = DBHelper.GetWeeklyActiveCustomReportName(Useremailid);




            }
        }


        [Given(@"I arrived on the associated Time Period tab of the Schedule Report page when I click on the Schedule Report button")]
        public void GivenIArrivedOnTheAssociatedTimePeriodTabOfTheScheduleReportPageWhenIClickOnTheScheduleReportButton()
        {
            try
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CustomReportHeaderSection_Xpath);
            }
            catch
            {
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            Report.WriteLine("Expanded the Create Custom Report section");

            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Schedule Report");
            Report.WriteLine("Clicked on Schedule Report button");
            Click(attributeName_id, scheduleReportButton_id);


            WaitForElementVisible(attributeName_xpath, CustomReport_TimePeroid_Xpath, "Time Period");
            Report.WriteLine("I arrived on the Associated Time period Tab of the Scheduled report");
            Verifytext(attributeName_xpath, CustomReport_TimePeroid_Xpath, "Time Period");
            VerifyElementPresent(attributeName_xpath, WeeklyTabScheduleReport_SELECTDAY_xpath, "Weekly tab");
        }


        [Then(@"I should see a confirming message that I want to delete the schedule as '(.*)'")]
        public void ThenIShouldSeeAConfirmingMessageThatIWantToDeleteTheScheduleAs(string p0)
        {
            WaitForElementVisible(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath, "Delete Schedulepopup");
            Report.WriteLine("Then the message will be Are you sure want to delete this schedule");
            string DeleteMsgText = Gettext(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath);
            Assert.AreEqual("Are you sure you want to delete this schedule?", DeleteMsgText);
        }

        [Then(@"I have option to confirm and cancel the deletion of the schedule")]
        public void ThenIHaveOptionToConfirmAndCancelTheDeletionOfTheSchedule()
        {
            Report.WriteLine("I have option to confirm the Deletion of the Schedule");
            Verifytext(attributeName_id, CustomReport_Delete_popup_ConfirmButton_Id, "Delete");

            Report.WriteLine("I have option to cancel the Deletion request");
            Verifytext(attributeName_xpath, CustomReport_Delete_Popup_CancelButton_Xpath, "Cancel");
        }


        [Given(@"I received a message confirming that I want to delete the schedule - '(.*)'")]
        public void GivenIReceivedAMessageConfirmingThatIWantToDeleteTheSchedule_(string p0)
        {
            WaitForElementVisible(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath, "Delete Schedulepopup");
            Report.WriteLine("Then the message will be Are you sure want to delete this schedule");
            string DeleteMsgText = Gettext(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath);
            Assert.AreEqual("Are you sure you want to delete this schedule?", DeleteMsgText);

        }


        [Then(@"The fields of the Weekly Time Period tab will be reset to the default values")]
        public void ThenTheFieldsOfTheWeeklyTimePeriodTabWillBeResetToTheDefaultValues()
        {
            Verifytext(attributeName_xpath, CustomReport_TimePeroid_Xpath, "Time Period");

            string ExpectedDefaultValue_SelectDay = "Sunday";
            string ActualDefaultValue_SelectDay = Gettext(attributeName_xpath, WeeklyDefault_SelectDayValue_xpath);            
            Assert.AreEqual(ExpectedDefaultValue_SelectDay, ActualDefaultValue_SelectDay);

            string ExpectedDefaultValue_SelectTimeHours = "Select hour...";
            string ActualDefaultValue_SelectTimeHours = Gettext(attributeName_xpath, WeeklyDefault_SelectHoursvalue_xpath);
            Assert.AreEqual(ExpectedDefaultValue_SelectTimeHours, ActualDefaultValue_SelectTimeHours);

            string ExpectedDefaultValue_SelectTimeMinutes = "Select minutes...";
            string ActualDefaultValue_SelectTimeMinutes = Gettext(attributeName_xpath, WeeklyDefault_SelectMinutessvalue_xpath);
            Assert.AreEqual(ExpectedDefaultValue_SelectTimeMinutes, ActualDefaultValue_SelectTimeMinutes);

            IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(DefaultRadioCheck));
            if (am.Selected)
            {
                Report.WriteLine("Radio button is selected defaultly");
            }
            else
            {
                Report.WriteFailure("Radio button is not selected defaultly");
            }



            string ReportDeliveryOptions_To = GetValue(attributeName_id, ReportDeliveryOptions_To_id, "value");
            if (ReportDeliveryOptions_To == "")
            {
                Report.WriteLine("Report Delivery Options To is expected ");
            }
            else
            {
                Report.WriteFailure("Is not expected");
                Assert.Fail();
            }

            string ReportDeliveryOptions_CCEmail = GetValue(attributeName_id, ReportDeliveryOptions_CC_id, "value");
            if (ReportDeliveryOptions_CCEmail == "")
            {
                Report.WriteLine("Report Delivery Options CC Email is Expected");
            }
            else
            {
                Report.WriteFailure("Is not expected");
                Assert.Fail();
            }

            string ReportDeliveryOptions_ReplyTo = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            if (ReportDeliveryOptions_ReplyTo == "")
            {
                Report.WriteLine("Report Delivery Options Reply To is Expected");
            }
            else
            {
                Report.WriteFailure("Is not Expected");
                Assert.Fail();
            }

            string ReprotDeliveryOption_Format = Gettext(attributeName_xpath, ReportDeliveryOptions_FormatDropdown_Xpath);
            string ExpectedReportDeliveryOption_Format = "Excel";
            Assert.AreEqual(ExpectedReportDeliveryOption_Format, ReprotDeliveryOption_Format);

            string ReportDeliveryoption_SubjectToEmail = GetValue(attributeName_id, ReportDeliveryOptions_Subject_id, "value");
            if (ReportDeliveryoption_SubjectToEmail == "<Report name> was processed on <Datetime>")
            {
                Report.WriteLine("Report Subject is Expected");
            }
            else
            {
                Report.WriteFailure("Is not Expected");
                Assert.Fail();
            }

            string ReportDeliveryOption_Comment = Gettext(attributeName_id, ReportDeliveryOptions_Comment_classname);
            if (ReportDeliveryOption_Comment == "")
            {
                Report.WriteLine("Report Delivery Option Commnet Body is expected");
            }
            else
            {
                Report.WriteFailure("Is not expected");
                Assert.Fail();
            }

        }

        [Then(@"The Cancel and Schedule Report button will be active")]
        public void ThenTheCancelAndScheduleReportButtonWillBeActive()
        {
            Report.WriteLine("Cancel Button should be active");
            VerifyElementEnabled(attributeName_id, customReportModal_CancelButton_id, "Cancel");

            Report.WriteLine("Schedule Report Button Will Be active");
            VerifyElementEnabled(attributeName_id, CustomReport_ScheduleReportButton_Id, "Schedule Report");

            IsElementDisabled(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule");

           
        }


        [Then(@"The Custom Report still exists in the drop down after deleting the schedule without scheduled")]
        public void ThenTheCustomReportStillExistsInTheDropDownAfterDeletingTheScheduleWithoutScheduled()
        {
            
            Report.WriteLine("The Custome Report Will No Longer Be Scheduled");
            List<InvoiceCustomReport> AllScheduledCustomReport_Weekly = DBHelper.GetWeeklyActiveCustomReportName_All(Useremailid);
            for (int i = 0; i < AllScheduledCustomReport_Weekly.Count(); i++)
            {
                if (AllScheduledCustomReport_Weekly[i].CustomReportName == Reportnameselected)
                {
                    Report.WriteFailure("After deleting the Report Should not exists in Records");
                    Assert.Fail();
                }

            }
        }



        [Given(@"a weekly scheduled report for a listed Customer report has been deleted")]
        public void GivenAWeeklyScheduledReportForAListedCustomerReportHasBeenDeleted()
        {
            GivenISelectedAWeeklyCustomReportWithAnActiveScheduleAssociatedFromTheDropDownList();

            CustomerInvoice_CustomReport_InvoiceTypeRadioButtonsSteps Obj = new CustomerInvoice_CustomReport_InvoiceTypeRadioButtonsSteps();
            Obj.GivenIExpandedTheCreateCustomReportSection();

            CustomerInvoice_ScheduleReports_PageElementSteps obj1 = new CustomerInvoice_ScheduleReports_PageElementSteps();
            obj1.GivenIClickedOnTheScheduleReportButton();

            Report.WriteLine("I click on Delete Schedule Button");

            WaitForElementVisible(attributeName_xpath, WeeklyTabScheduleReport_SELECTDAY_xpath, "Select Day");
            scrollElementIntoView(attributeName_id, customReportModal_DeleteSchedule_id);
            Click(attributeName_id, customReportModal_DeleteSchedule_id);

            
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on Delete button");
            WaitForElementVisible(attributeName_id, CustomReport_Delete_popup_ConfirmButton_Id, "Delete");
            Click(attributeName_id, CustomReport_Delete_popup_ConfirmButton_Id);
            WaitForElementVisible(attributeName_id, customReportModal_CancelButton_id,"Cancel button");

            Click(attributeName_id, customReportModal_CancelButton_id);

            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");

            Report.WriteLine("Scheduled Report For a listed customer report has been deleted");
            List<InvoiceCustomReport> AllScheduledCustomReport_Month = DBHelper.GetWeeklyActiveCustomReportName_All(Useremailid);
            for (int i = 0; i < AllScheduledCustomReport_Month.Count(); i++)
            {
                if (AllScheduledCustomReport_Month[i].CustomReportName == Reportnameselected)
                {
                    Report.WriteFailure("Report is still Scheduled Please Pass a report which is not scheduled");
                    Assert.Fail();
                }

            }

            Report.WriteLine("Checking For the Report :" + Reportnameselected);
        }


        [When(@"I click on the Select Existing Custom Report drop down list in customer invoice page")]
        public void WhenIClickOnTheSelectExistingCustomReportDropDownListInCustomerInvoicePage()
        {
            Report.WriteLine("I click on Select Existing Custom Report Drop Down List");
            Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

            IList<IWebElement> CustomReportDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
            int CustomReportCount = CustomReportDropdown_List.Count;
            for (int i = 0; i < CustomReportCount; i++)
            {
                if (CustomReportDropdown_List[i].Text.Contains(Reportnameselected))
                {
                    int j = i + 1;
                    AfterDeletingReportName = Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/div/ul/li[" + j + "]");
                    CustomReportDropdown_List[i].Click();
                    break;
                }
            }
        }


        [Then(@"I will no longer see the scheduled and next run date label displayed next to the weekly report name")]
        public void ThenIWillNoLongerSeeTheScheduledAndNextRunDateLabelDisplayedNextToTheWeeklyReportName()
        {
            Report.WriteLine("Then I will no longer see the scheduled and next run date label displayed next to report name");
            Assert.AreEqual(Reportnameselected, AfterDeletingReportName);
        }


        [Then(@"The Delete Confirmation message will be removed")]
        public void ThenTheDeleteConfirmationMessageWillBeRemoved()
        {
            WaitForElementVisible(attributeName_xpath, WeeklyTabScheduleReport_SELECTDAY_xpath, "Select Day");

            Report.WriteLine("Messgae will be removed");
            VerifyElementNotVisible(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath, "Are you sure you want to delete this schedule?");

            VerifyElementPresent(attributeName_xpath, WeeklyTabScheduleReport_SELECTDAY_xpath, "Weekly tab");

        }


        [Given(@"I clicked on the Delete Schedule button weekly tab")]
        public void GivenIClickedOnTheDeleteScheduleButtonWeeklyTab()
        {
            DefineTimeOut(5000);
            Report.WriteLine("I click on Delete Schedule Button");
            WaitForElementVisible(attributeName_xpath, WeeklyTabScheduleReport_SELECTDAY_xpath, "Select Day");
            scrollElementIntoView(attributeName_id, customReportModal_DeleteSchedule_id);
            Click(attributeName_id, customReportModal_DeleteSchedule_id);
        }



        [Given(@"I click on the existing custom report drop down to select a custom report which is not scheduled")]
        public void GivenIClickOnTheExistingCustomReportDropDownToSelectACustomReportWhichIsNotScheduled()
        {
            Report.WriteLine("I select a Custom Report from Dropdown which is Not Scheduled");
            Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                int j = i + 1;
                string AfterDeletingReportName1 = Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/div/ul/li[" + j + "]");
                if (CustomerNameListCount > 0)
                {
                    if (AfterDeletingReportName1.Contains("Scheduled"))
                    {
                        Report.WriteLine("Report is Scheduled ");
                    }
                    else
                    {

                        Reportnameselected = CustomerDropdown_List[i].Text;
                        if (Reportnameselected == "Select...")
                        {

                        }
                        else
                        {
                            CustomerDropdown_List[i].Click();
                            break;
                        }
                    }
                }
            }

            Click(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath);

        }

        [When(@"I click on the Schedule Report button on Customer Invoices page")]
        public void WhenIClickOnTheScheduleReportButtonOnCustomerInvoicesPage()
        {
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Scheduled Report");
            Report.WriteLine("Clicked on Schedule Report button");
            Click(attributeName_id, scheduleReportButton_id);
        }

        [Then(@"the Delete schedule button should be Inactive")]
        public void ThenTheDeleteScheduleButtonShouldBeInactive()
        {
            scrollElementIntoView(attributeName_id, customReportModal_DeleteSchedule_id);
            Report.WriteLine("Delete Schedule Button should be inactive");
            IsElementDisabled(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule");
        }















    }
}
