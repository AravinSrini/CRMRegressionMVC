using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using OpenQA.Selenium;
using Rrd.Dls.IdentityServer.Core.Dto;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report.Schedule_Reports
{
    [Binding]
    public class Customer_Invoice___Schedule_Reports___Delete_Schedule_MonthlySteps : Customer_Invoice
    {

        public string Reportnameselected;
        public string AfterDeletingReportName;
        public string Useremail_Id;
        //public string Invoicevalue = "100";
        //public string DateRangeStart = "06/12/2018";
        //public string DateRangeEnd = "07/12/2018";

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner and access rrd user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerAndAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I arrived on the Customer Invoice page")]
        public void GivenIArrivedOnTheCustomerInvoicePage()
        {
            Report.WriteLine("Click on Customer Invoices icon");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            DefineTimeOut(20000);
            WaitForElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");

            Report.WriteLine("I arrived on Customer Invoices Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
        }

        [Given(@"I selected a monthly Custom report with an active schedule associated from the drop down list")]
        public void GivenISelectedAMonthlyCustomReportWithAnActiveScheduleAssociatedFromTheDropDownList()
        {

            Useremail_Id = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();

            string ScheduledMonthlyActiveReport = DBHelper.GetMonthlyActiveCustomReportName(Useremail_Id);

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

            else if(ScheduledMonthlyActiveReport == null)
            {

                Report.WriteLine("Click on Existing Custom Report Dropdown");
                Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);
                IList<IWebElement> CustomReportDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
                int CustomReportCount = CustomReportDropdown_List.Count;

                if(CustomReportCount > 0)
                {
                    Reportnameselected = CustomReportDropdown_List[1].Text;
                    CustomReportDropdown_List[1].Click();
                }

                Report.WriteLine("Expand the Custom Report Section");
                Click(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath);

                Report.WriteLine("Click on Schedule Report Button");
                Click(attributeName_id, scheduleReportButton_id);

                Report.WriteLine("Click on Monthly Tab for monthly schedule");
                WaitForElementVisible(attributeName_xpath, CustomReport_Schedule_Monthly_Tab_Xpath, "Monthly");
                Click(attributeName_xpath, CustomReport_Schedule_Monthly_Tab_Xpath);

              
                Report.WriteLine("Select the Time");
                Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);

                IList<IWebElement> HoursDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath));
                int HoursDropdown_ListCount = HoursDropdown_List.Count;
                for (int i = 0; i < HoursDropdown_ListCount; i++)
                {
                    if (HoursDropdown_List[i].Text == "01")
                    {
                        HoursDropdown_List[i].Click();
                        break;
                    }
                }

                Click(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);

                IList<IWebElement> MinutesDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath));
                int MinutesDropdown_ListCount = MinutesDropdown_List.Count;
                for (int i = 0; i < MinutesDropdown_ListCount; i++)
                {
                    if (MinutesDropdown_List[i].Text == "00")
                    {
                        MinutesDropdown_List[i].Click();
                        break;
                    }
                }

                Report.WriteLine("Enter the email id in To field");
                SendKeys(attributeName_id, ReportDeliveryOptions_To_id, "test@test.com");

                scrollElementIntoView(attributeName_id, scheduleReportButtononmodal_id);
                Report.WriteLine("Click on Schedule Report Button");
                Click(attributeName_id, scheduleReportButtononmodal_id);

            }
        }

        [Given(@"I arrived on the associated Time Period tab of the Schedule Report page")]
        public void GivenIArrivedOnTheAssociatedTimePeriodTabOfTheScheduleReportPage()
        {
            WaitForElementVisible(attributeName_xpath, CustomReport_TimePeroid_Xpath, "Time Period");
            Report.WriteLine("I arrived on the Associated Time period Tab of the Scheduled report");
            Verifytext(attributeName_xpath, CustomReport_TimePeroid_Xpath, "Time Period");
            Verifytext(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "SELECT MONTHS *");       
           
        }

        [When(@"I click on the Delete Schedule button")]
        public void WhenIClickOnTheDeleteScheduleButton()
        {
           
            scrollElementIntoView(attributeName_id, customReportModal_DeleteSchedule_id);
            Report.WriteLine("I click on Delete Schedule Button");
            Click(attributeName_id, customReportModal_DeleteSchedule_id);
        }

        [Then(@"I have receive a message confirming that I want to delete the schedule")]
        public void ThenIHaveReceiveAMessageConfirmingThatIWantToDeleteTheSchedule()
        {
            Report.WriteLine("I will receave a message with popup");
            VerifyElementPresent(attributeName_xpath, CustomReport_Delete_Popup_Xpath, "Popup");
        }

        [Then(@"The message will be - Are you sure you want to delete this schedule\?")]
        public void ThenTheMessageWillBe_AreYouSureYouWantToDeleteThisSchedule()
        {
            WaitForElementVisible(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath,"");
            Report.WriteLine("Then the message will be Are you sure want to delete this schedule");
            string DeleteMsgText = Gettext(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath);
            Assert.AreEqual("Are you sure you want to delete this schedule?", DeleteMsgText);
        }

        [Then(@"I have the option to confirm the deletion of the schedule")]
        public void ThenIHaveTheOptionToConfirmTheDeletionOfTheSchedule()
        {
            Report.WriteLine("I have option to confirm the Deletion of the Schedule");
            Verifytext(attributeName_id, CustomReport_Delete_popup_ConfirmButton_Id, "Delete");
        }

        [Then(@"I have the option to cancel the deletion request")]
        public void ThenIHaveTheOptionToCancelTheDeletionRequest()
        {
            Report.WriteLine("I have option to cancel the Deletion request");
            Verifytext(attributeName_xpath, CustomReport_Delete_Popup_CancelButton_Xpath, "Cancel");
        }
        [Given(@"I clicked on the Delete Schedule button")]
        public void GivenIClickedOnTheDeleteScheduleButton()
        {
            DefineTimeOut(5000);
            Report.WriteLine("I click on Delete Schedule Button");
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "SELECT MONTHS *");
            scrollElementIntoView(attributeName_id, customReportModal_DeleteSchedule_id);
            Click(attributeName_id, customReportModal_DeleteSchedule_id);
        }

        [Given(@"I received a message confirming that I want to delete the schedule")]
        public void GivenIReceivedAMessageConfirmingThatIWantToDeleteTheSchedule()
        {
            WaitForElementVisible(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath, "Are you sure you want to delete this schedule?");
            Report.WriteLine("I will receave a message with popup");
            VerifyElementPresent(attributeName_xpath, CustomReport_Delete_Popup_Xpath, "Popup");

            Report.WriteLine("Then the message will be Are you sure want to delete this schedule");
            Verifytext(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath, "Are you sure you want to delete this schedule?");
        }

        [When(@"I click on cancel the deletion request option")]
        public void WhenIClickOnCancelTheDeletionRequestOption()
        {
            Report.WriteLine("Click on Cancel button");
            Click(attributeName_xpath, CustomReport_Delete_Popup_CancelButton_Xpath);
        }

        [Then(@"The message will be removed")]
        public void ThenTheMessageWillBeRemoved()
        {
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "Select month");
            Report.WriteLine("Messgae will be removed");
            VerifyElementNotVisible(attributeName_xpath, CustomReport_Delete_Popup_Message_Xpath, "Are you sure you want to delete this schedule?");
        }

        [When(@"I choose to delete the schedule")]
        public void WhenIChooseToDeleteTheSchedule()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on Delete button");
            WaitForElementVisible(attributeName_id, CustomReport_Delete_popup_ConfirmButton_Id, "");
            Click(attributeName_id, CustomReport_Delete_popup_ConfirmButton_Id);
        }

        [Then(@"The fields of the Time Period tab will be reset to the default values")]
        public void ThenTheFieldsOfTheTimePeriodTabWillBeResetToTheDefaultValues()
        {
            Report.WriteLine("The field of the Time period to will be reset to the default values");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JanuaryCheckbox_Xpath, "January");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_FebuaryCheckbox_Xpath, "February");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MarchCheckbox_Xpath, "March");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AprilCheckbox_Xpath, "April");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_MayCheckbox_Xpath, "May");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JuneCheckbox_Xpath, "June");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_JulyCheckbox_Xpath, "July");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_AugustCheckbox_Xpath, "August");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_SeptemberCheckbox_Xpath, "September");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_OctoberCheckbox_Xpath, "October");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_NovemberCheckbox_Xpath, "November");
            VerifyElementChecked(attributeName_xpath, CustomerInvoice_DecemberCheckbox_Xpath, "December");


            //Week and Week Days
            RadiobuttonChecked(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeeks_RadioButton_Xpath);

            string DefaultValue_WeekField = Gettext(attributeName_xpath, "//div[@id='MonthlyWeek_chosen']/a/span");
            string ExpectedDefaultValue_WeekField = "1st";
            Assert.AreEqual(ExpectedDefaultValue_WeekField, DefaultValue_WeekField);

            string DefaultValue_WeekDays = Gettext(attributeName_xpath, CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath);
            string ExpectedDefaultValue_WeekDays = "Sunday";
            Assert.AreEqual(ExpectedDefaultValue_WeekDays, DefaultValue_WeekDays);

           
            // Special Day of Month
            VerifyElementNotEnabled(attributeName_id, CustomerInvoice_SpecialDayofMonth_Id, "SpecificDayOfMonth");
            string DefaultValue_SpecificDayOfMonth = GetAttribute(attributeName_xpath, CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath, "value");
            string ExpectedDefaultValue_SpecificDayOfMonth = "1";
            Assert.AreEqual(ExpectedDefaultValue_SpecificDayOfMonth, DefaultValue_SpecificDayOfMonth);

            //Select Time
            string DefaultValue_Hour = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath);
            string ExpectedValue_Hour = "Select hour...";
            Assert.AreEqual(ExpectedValue_Hour, DefaultValue_Hour);

            string DefaultValue_Minutes = Gettext(attributeName_xpath, CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath);
            string ExpectedValue_Minutes = "Select minutes...";
            Assert.AreEqual(ExpectedValue_Minutes, DefaultValue_Minutes);

            IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath));
            if (am.Selected)
            {
                Report.WriteLine("Radio button is selected defaultly");
            }
            else
            {
                Report.WriteFailure("Radio button is not selected defaultly");
            }
  

            string ReportDeliveryOptions_To = GetValue(attributeName_id, ReportDeliveryOptions_To_id,"value");
            if(ReportDeliveryOptions_To == "")
            {
                Report.WriteLine("Report Delivery Options To is expected ");
            }
            else
            {
                Report.WriteFailure("Is not expected");
                Assert.Fail();
            }

            string ReportDeliveryOptions_CCEmail = GetValue(attributeName_id, ReportDeliveryOptions_CC_id,"value");
            if(ReportDeliveryOptions_CCEmail == "")
            {
                Report.WriteLine("Report Delivery Options CC Email is Expected");
            }
            else
            {
                Report.WriteFailure("Is not expected");
                Assert.Fail();
            }

            string ReportDeliveryOptions_ReplyTo = GetValue(attributeName_id, ReportDeliveryOptions_ReplyTo_id, "value");
            if(ReportDeliveryOptions_ReplyTo == "")
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
            string ExpectedReportDelivery_SubjectToEmail = "<Report name> was processed on <Datetime>";
            Assert.AreEqual(ExpectedReportDelivery_SubjectToEmail, ReportDeliveryoption_SubjectToEmail);

            string ReportDeliveryOption_Comment = Gettext(attributeName_id, ReportDeliveryOptions_Comment_classname);
            if(ReportDeliveryOption_Comment == "")
            {
                Report.WriteLine("Report Delivery Option Commnet Body is expected");
            }
            else
            {
                Report.WriteFailure("Is not expected");
                Assert.Fail();
            }

        }

        [Then(@"The Cancel button will be active")]
        public void ThenTheCancelButtonWillBeActive()
        {
            scrollElementIntoView(attributeName_id, customReportModal_CancelButton_id);
            Report.WriteLine("Cancel Button should be active");
            VerifyElementEnabled(attributeName_id, customReportModal_CancelButton_id, "Cancel");
        }

        [Then(@"The Custom Report will no longer be scheduled")]
        public void ThenTheCustomReportWillNoLongerBeScheduled()
        {
            Report.WriteLine("The Custome Report Will No Longer Be Scheduled");
            List<InvoiceCustomReport> AllScheduledCustomReport_Month = DBHelper.GetMonthlyActiveCustomReportName_All(Useremail_Id);
            for (int i =0;i< AllScheduledCustomReport_Month.Count(); i++)
            {
                if(AllScheduledCustomReport_Month[i].CustomReportName == Reportnameselected)
                {
                    Report.WriteFailure("After deleting the Report Should not exists in Records");
                    Assert.Fail();
                }

            }
        }

        [Given(@"a scheduled report for a listed Customer report has been deleted")]
        public void GivenAScheduledReportForAListedCustomerReportHasBeenDeleted()
        {

            GivenISelectedAMonthlyCustomReportWithAnActiveScheduleAssociatedFromTheDropDownList();

            CustomerInvoice_CustomReport_InvoiceTypeRadioButtonsSteps Obj = new CustomerInvoice_CustomReport_InvoiceTypeRadioButtonsSteps();
            Obj.GivenIExpandedTheCreateCustomReportSection();

            CustomerInvoice_ScheduleReports_PageElementSteps obj1 = new CustomerInvoice_ScheduleReports_PageElementSteps();
            obj1.GivenIClickedOnTheScheduleReportButton();

            GivenIClickedOnTheDeleteScheduleButton();
            WhenIChooseToDeleteTheSchedule();

          

            Report.WriteLine("Scheduled Report For a listed customer report has been deleted");
            List<InvoiceCustomReport> AllScheduledCustomReport_Month = DBHelper.GetMonthlyActiveCustomReportName_All(Useremail_Id);
            for (int i = 0; i < AllScheduledCustomReport_Month.Count(); i++)
            {
                if (AllScheduledCustomReport_Month[i].CustomReportName == Reportnameselected)
                {
                    Report.WriteFailure("Something is wrong - After Deletion also it's available in DB");
                    Assert.Fail();
                }

            }
      
            Report.WriteLine("Checking For the Report :" + Reportnameselected);

            Thread.Sleep(5000);
            Report.WriteLine("I click on Cancel Button");
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "SELECT MONTHS *");
            scrollElementIntoView(attributeName_id, scheduleReportButtononmodal_id);
            Click(attributeName_id, customReportModal_CancelButton_id);

        }


        [When(@"I click on the Select Existing Custom Report drop down list")]
        public void WhenIClickOnTheSelectExistingCustomReportDropDownList()
        {
            Thread.Sleep(5000);
            WaitForElementVisible(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath, "");
            Report.WriteLine("I click on Select Existing Custom Report Drop Down List");
            Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

            IList<IWebElement> CustomReportDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
            int CustomReportCount = CustomReportDropdown_List.Count;
            for (int i = 0; i < CustomReportCount; i++)
            {
                if (CustomReportDropdown_List[i].Text.Contains(Reportnameselected))
                {
                    int j = i + 1;
                    AfterDeletingReportName =  Gettext(attributeName_xpath, ".//*[@id='customReportSelection_chosen']/div/ul/li[" + j + "]");
                    CustomReportDropdown_List[i].Click();
                    break;
                }
            }
        }

        [Then(@"I will no longer see the scheduled and next run date label displayed next to the report name")]
        public void ThenIWillNoLongerSeeTheScheduledAndNextRunDateLabelDisplayedNextToTheReportName()
        {
            Report.WriteLine("Then I will no longer see the scheduled and next run date label displayed next to report name");
            Assert.AreEqual(Reportnameselected, AfterDeletingReportName);
        }

        [Given(@"I select a custom report from drop down which is not scheduled")]
        public void GivenISelectACustomReportFromDropDownWhichIsNotScheduled()
        {
            Report.WriteLine("I select a Custom Report from Dropdown which is Not Scheduled");
            Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 1; i < CustomerNameListCount; i++)
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
                        Report.WriteLine("Click on the Report which is not Scheduled");
                        Reportnameselected = CustomerDropdown_List[i].Text;
                        CustomerDropdown_List[i].Click();
                        break;
                    }
                }
            }

            Click(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath);
             
        }

        [When(@"I click on the Schedule Report button from custom report section")]
        public void WhenIClickOnTheScheduleReportButtonFromCustomReportSection()
        {
            WaitForElementVisible(attributeName_id, scheduleReportButton_id, "Scheduled Report");
            Report.WriteLine("Clicked on Schedule Report button");
            Click(attributeName_id, scheduleReportButton_id);
        }


        [Then(@"The Delete schedule button should be Inactive")]
        public void ThenTheDeleteScheduleButtonShouldBeInactive()
        {
            WaitForElementVisible(attributeName_xpath, CustomReport_TimePeroid_Xpath, "");
            Report.WriteLine("Select the monthly tab");
            Click(attributeName_id, tabMonthly_id);
            WaitForElementVisible(attributeName_xpath, CustomerInvoice_SelectMonths_Label_Xpath, "Select Month");
            scrollElementIntoView(attributeName_id, customReportModal_DeleteSchedule_id);
            Report.WriteLine("Delete Schedule Button should be inactive");
            IsElementDisabled(attributeName_id, customReportModal_DeleteSchedule_id, "Delete Schedule");
        }

    }
}
