using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using System;
using OpenQA.Selenium.Interactions;
using CRM.UITest.Entities;
using System.Threading;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class CustomerInvoice_CustomReportSaveEditsSteps : Customer_Invoice
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        int daysPastDue = 20;
        string invoiceValue = "180";

        [Given(@"I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature")]
        public void Given_I_am_a_shp_entry_shp_entrynortes_shp_inquiry_shp_inquirynorates_operations_sales_sales_management_station_owner_or_access_rrd_user()
        {
            string Username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string Password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            Report.WriteLine("Logging into application");
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am a shp.entry, shp.entrynortes, shp.inquiry, shp.inquirynorates, operations, sales, sales management, station owner, or access rrd user who can access the save edits feature zzzext")]
        public void Given_I_am_a_shp_entry_shp_entrynortes_shp_inquiry_shp_inquirynorates_operations_sales_sales_management_station_owner_or_access_rrd_user_for_zzzext()
        {
            string Username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string Password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            Report.WriteLine("Logging into application");
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Customer Invoice page as an accepted user")]
        public void Given_I_am_on_the_Customer_Invoice_page()
        {
            Report.WriteLine("Clicking on the customer invoice icon");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            //GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected a Custom Report from the Select Standard or Existing Custom Report list")]
        public void Given_I_selected_a_Custom_Report_from_the_Select_Standard_or_Existing_Custom_Report_list()
        {
            Report.WriteLine("Selecting a custom report");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingCustomReport_SelectAny_Xpath, "TestReportForInternal_1");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected a Custom Report from the Select Standard or Existing Custom Report list for zzzext")]
        public void Given_I_selected_a_Custom_Report_from_the_Select_Standard_or_Existing_Custom_Report_list_for_zzzext()
        {
            Report.WriteLine("Selecting a custom report");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingCustomReport_SelectAny_Xpath, "NinjaSprintPrintInvoices");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I expand the Create or Edit Custom Report section")]
        [When(@"I expand the Create or Edit Custom Report section")]
        public void Given_I_expanded_the_Create_or_Edit_Custom_Report_section()
        {
            Report.WriteLine("Expanding Custom report section");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);
        }

        [Given(@"I edited Any field or sections of the CUSTOM REPORT with the exception of the following REPORT NAME")]
        public void GivenIEditedAnyFieldOrSectionsOfTheCUSTOMREPORTWithTheExceptionOfTheFollowingREPORTNAME()
        {
            Report.WriteLine("Entering value into Days Past Due input field");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, CustomReport_InvoiceValueField_Xpath, invoiceValue.ToString());
        }
                        
        [When(@"I edit the invoice type of the custom report")]
        public void When_I_edit_the_invoice_type_of_the_custom_report()
        {
            Report.WriteLine("Editing invoice type");
            Click(attributeName_xpath, CustomReport_CreateReportSection_InvoiceType_Closed_Xpath);
            Click(attributeName_xpath, CustomReport_CreateReportSection_InvoiceType_Open_Xpath);
        }
        
        [When(@"I edit the days past due of the custom report using the text field")]
        public void When_I_edit_the_days_past_due_of_the_custom_report_using_the_text_field()
        {
            Report.WriteLine("Entering value into Days Past Due input field");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, CustomReport_DaysPastDueInput_Xpath, daysPastDue.ToString());
        }
        
        [When(@"I edit the days past due of the custom report using the increase arrow")]
        public void When_I_edit_the_days_past_due_of_the_custom_report_using_the_increase_arrow()
        {
            Report.WriteLine("Editing Days past due with increase arrow");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_CreateReportSection_UpArrowDaysPastDue_Id);
        }
        
        [When(@"I edit the days past due of the custom report using the decrease arrow")]
        public void When_I_edit_the_days_past_due_of_the_custom_report_using_the_decrease_arrow()
        {
            Report.WriteLine("Editing Days past due with decrease arrow");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_CreateReportSection_DownArrowDaysPastDue_Id);
        }
        
        [When(@"I edit the date range of the custom report")]
        public void When_I_edit_the_date_range_of_the_custom_report()
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
        
        [When(@"I edit the invoice value of the custom report by using the text field")]
        public void When_I_edit_the_invoice_value_of_the_custom_report_by_using_the_text_field()
        {
            Report.WriteLine("Entering value for invoice value");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, CustomReport_InvoiceValueField_Xpath, "1000");
        }
        
        [When(@"I edit the invoice value of the custom report by using the drop down menu")]
        public void When_I_edit_the_invoice_value_of_the_custom_report_by_using_the_drop_down_menu()
        {
            Report.WriteLine("Changing selection from input value drop down");
            Click(attributeName_xpath, "//*[@id='InvoiceValueFilter_chosen']");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='InvoiceValueFilter_chosen']", ">");
            Click(attributeName_xpath, "//*[@id='InvoiceValueFilter_chosen']");
            SelectDropdownValueFromList(attributeName_xpath, "//*[@id='InvoiceValueFilter_chosen']", "<");
        }
        
        [When(@"I edit the station of the custom report by adding a station")]
        public void When_I_edit_the_station_of_the_custom_report_by_adding_a_station()
        {
            Report.WriteLine("Adding station to report");
            Thread.Sleep(2000);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, "Agile");
        }
                
        [When(@"I edit the account of the custom report by adding an account")]
        public void When_I_edit_the_account_of_the_custom_report_by_adding_an_account()
        {
            Report.WriteLine("Adding account to report");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, "Agile");
            Thread.Sleep(2000);
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "CSR july9th");
        }

        [When(@"I edit the custom Report Name field")]
        public void When_I_edit_the_Report_Name_field()
        {
            Report.WriteLine("Editing custom report name");
            Thread.Sleep(2000);
            Clear(attributeName_xpath, ReportName_Xpath); 
            SendKeys(attributeName_xpath, ReportName_Xpath, "Test Report Name");
        }
        
        [When(@"I click on the Save Edits button for the report")]
        public void When_I_click_on_the_Save_Edits_button()
        {
            Report.WriteLine("Clicking on save edits button");
            Click(attributeName_xpath, CustomReport_Save_Edits_Button);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"I will see a Save Edits button for the report")]
        public void Then_I_will_see_a_Save_Edits_button()
        {
            Report.WriteLine("Verifying that the save edits button is visible");
            VerifyElementPresent(attributeName_xpath, CustomReport_Save_Edits_Button, "Save Edits Button");
        }

        [Then(@"I will not see a Save Edits button for the  custom reports section")]
        public void ThenIWillNotSeeASaveEditsButtonForTheCustomReportsSection()
        {
            Report.WriteLine("Verifying that the save edits button is not present");
            VerifyElementNotVisible(attributeName_xpath, CustomReport_Save_Edits_Button, "Save Edits Button");            
        }


        [Then(@"the Save Edits button for the report will be inactive")]
        public void Then_the_Save_Edits_button_will_be_inactive()
        {
            Report.WriteLine("Verify that the save edits button is not enabled");
            VerifyElementNotEnabled(attributeName_xpath, CustomReport_Save_Edits_Button, "Save Edits Button");
        }
        
        [Then(@"the Save Edits button for the report will be active")]
        public void Then_the_Save_Edits_button_will_be_active()
        {
            Report.WriteLine("Verify that the save edits button is enabled");
            VerifyElementEnabled(attributeName_xpath, CustomReport_Save_Edits_Button, "Save Edits Button");
        }

        [Then(@"the edits will be saved to the custom report")]
        public void Then_the_edits_will_be_saved_to_the_custom_report()
        {
            string reportName = Gettext(attributeName_xpath, SelectedReport);

            var report = DBHelper.GetCustomReportDataBasedOnReport(reportName);

            GlobalVariables.webDriver.WaitForPageLoad();

            Assert.AreEqual(report.InvoiceValue, int.Parse(invoiceValue));
        }
        
        [Then(@"the grid will update to display invoices matching the new criteria")]
        public void Then_the_grid_will_update_to_display_invoices_matching_the_new_criteria()
        {
            Thread.Sleep(10000);
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            Assert.IsTrue((row >= 1) && (NoRecordFound != "No Results Found"));            
        }
    }    
}
