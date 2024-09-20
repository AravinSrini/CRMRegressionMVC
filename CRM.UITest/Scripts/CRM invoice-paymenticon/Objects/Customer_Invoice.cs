using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rrd.SpecflowSelenium.Service.GenericService;

namespace CRM.UITest.Objects
{
    public class Customer_Invoice : ObjectRepository
    {

        const string gridId = "gridCustomerInvoiceList";
        public string customerInvoiceIcon_xpath = ".//*[@id='customerInvoices']/i";
        public string customerInvoicesexportbutton_id = "btnExortCustomerInvoiceList";
        public string customerInvoicesexportbuttonarrow_id = "btnExortCustomerInvoiceList";
        public string customerInvoicesexportdropdownvalues_id = ".//*[@id='gridCustomerInvoiceList_wrapper']//ul";
        public string customerInvoicesexportAll_xpath = ".//*[@id='gridCustomerInvoiceList_wrapper']/div[1]//ul/li[1]/a";
        public string customerInvoicesexportDisplayed_xpath = ".//*[@id='gridCustomerInvoiceList_wrapper']/div[1]//li[2]/a ";
        public string customerInvoicesHeader_xpath = ".//*[@id='page-content-wrapper']//h1[contains(text(),'Customer Invoices')]";
        public string customerInvoicesGrid_xpath = ".//*[@id='gridCustomerInvoiceList']/tbody/tr";
        public string customerInvoicescolumns_xpath = ".//*[@id='gridCustomerInvoiceList']/tbody/tr/td[1]";
        public string customerValUi_xpath = ".//*[@id='gridCustomerInvoiceList']/tbody/tr[1]//span[1]";
        public string customerNameValNameUI_xpath = ".//*[@id='gridCustomerInvoiceList']/tbody/tr[1]//span[2]";
        public string customerInvoiceGrid_AllResultsRow_XPath = ".//*[@id='gridCustomerInvoiceListContainer']//table/tbody/tr";
        public string SalesRepValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[1]";
        public string AccountValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[2]";
        public string InvoiceNumberValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[3]";
        public string ReferenceValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[5]";
        public string InvoiceDateValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[6]";
        public string DueDateValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[7]";
        public string OriginalAmtValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[8]";
        public string CurrentValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[9]";
        public string DaysPastDueValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[10]";
        public string DisputeCodeValUi_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[11]";
        public string FirstInvoiceNumber_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[4]/a";
        public string CustomerInvoiceErrorMessage_xpath = "/html/body";
        public string FirstCustomerInvoiceNumber_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[3]/span[1]";
        public string FirstCustomerName_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[3]/span[2]";
        public string FirstCustomerInvoiceDate_xpath = ".//*[@id='gridCustomerInvoiceList']//tr[1]/td[6]";
        public string Searchbox_xpath = ".//div[@id='gridCustomerInvoiceList_filter']//input";
        public string CustomerInvoices_PageHeader_xpath = "";
        public string CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id = "AccessRRDStations_chosen";
        public string CustomerInvoicePage_AccessRRDUser_StationSearchInput_XPath = "//div[@id='AccessRRDStations_chosen']//ul[@class='chosen-choices']//li[@class='search-field']//input";
        public string CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id = "AccessRRDDisplayInvoices";
        public string CustomerInvoicePage_AccessRRDUser_AccountsDropdown_Id = "AccessRRDAccounts_chosen";
        public string CustomerInvoicePage_AccessRRDUser_StationsDropdownAllValues_Xpath = "//div[@id='AccessRRDStations_chosen']//div[@class='chosen-drop']//li";
        public string CustomerInvoicePage_AccessRRDUser_CustomerAccountsDropdownAllValues_XPath = "//div[@id='AccessRRDAccounts_chosen']//div[@class='chosen-drop']//li";
        public string CustomerInvoicePage_AccessRRDUser_CustomerAccountsSearchInput_XPath = "//div[@id='AccessRRDAccounts_chosen']//ul[@class='chosen-choices']//li[@class='search-field']//input[@value='Select one or more...']";
        public string CustomerInvoicesPage_AccountNumber_AllValues_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//tr//td[3]";
        public string CustomerInvoicesPage_InvoiceNumber_AllValues_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//tr//td[6]//a";
        public string CustomerInvoicesPage_CustomerNumber_AllValues_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//tr//td[5]//span[1]";
        public string CustomerInvoicesPage_CustomerName_AllValues_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//tr//td[5]//span[2]";
        public string CustomerInvoices_SelectAllInvoices_Id = "select_allgridCustomerInvoiceList3422201809342934Id";
        public string CustomerInvoices_SelectAllInvoices_Xpath = "//*[@id='select_allgridCustomerInvoiceList3422201809342934Id']";

        //Updated xpath for all invoice numbers
        public string CustomerInvoices_AllInvoiceNumbers_xpath = ".//*[@id='gridCustomerInvoiceListContainer']//tr/td[6]";
        //Updated xpath for all Payment date values
        public string CustomerInvoices_AllPaymentDate_xpath = ".//*[@id='gridCustomerInvoiceListContainer']//tr/td[10]";
        //Updated xpath for the first invoice number in the grid
        public string CustomerInvoices_FirstRowInvoiceNumber_xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//tr[1]//td[6]/a";
        //Need to update xpath required for the Payment Date field value
        public string CustomerInvoices_FirstRowPaymentDate_xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//tr[1]//td[10]/a";

        public string CustomerInvoices_SelectInvoiceCheckBoxes_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/tbody/tr/td/div[@class='checkbox']";
        public string CustomerInvoices_AllInvoiceCheckBox_Xpath = "//*[@id='gridCustomerInvoiceListContainer']/div[1]/table/thead/tr/th/div/input";
        public string CustomerInvoices_SelectAllInvoiceCheckBoxes_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/thead/tr/th[1]/div/input";
        public string CustomerInvoices_SelectAllInvoiceCheckBoxesLabel_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/thead/tr/th[1]/div/label";
        // public string customerInvoiceIcon_xpath = ".//*[@id='customerInvoices']/i";
        // public string customerInvoicesHeader_xpath = ".//*[@id='page-content-wrapper']//h1";
        public string CustomerInvoices_Verbage_Xpath = ".//*[@id='page-content-wrapper']//p";
        public string CustomerInvoices_FilterField_Verbiage_Xpath = ".//*[contains(@id,'gridCustomerInvoiceList')]/label/input";

        public string CustomerInvoices_FilterList_Display_Xpath = ".//*[contains(@id,'gridCustomerInvoiceListContainer')]//*[text()='Display']";
        public string CustomerInvoices_FilterList_Open_Xpath = ".//div[@id='gridCustomerInvoiceListContainer']//label[@for='FilterByUnpaid']";
        public string CustomerInvoices_FilterList_Closed_Xpath = ".//div[@id='gridCustomerInvoiceListContainer']//label[@for='FilterByPaid']";
        public string CustomerInvoices_FilterList_All_Xpath = ".//div[@id='gridCustomerInvoiceListContainer']//label[@for='FilterByAll']";

        public string CustomerInvoices_BacktoDashboard_Button_Xpath = ".//*[@id='page-content-wrapper']//button";
        public string CustomerInvoices_MakePayment_Button_Id = "btnMakePayment";
        public string CustomerInvoices_ExportButton_Id = "btnExortCustomerInvoiceList";
        public string CustomerInvoices_PrintInvoicesButton_Id = "btnPrintCustomerInvoiceList";
        public string CustomerInvoices_PrintInvoicesButton_Xpath = "//*[@id='btnPrintCustomerInvoiceList']";
        public string CustomerInvoices_PrintInvoicesButtonDisabled_Xpath = "//*[@id='btnPrintCustomerInvoiceList' and contains(@class, 'disabled')]";
        public string CustomerInvoices_PrintInvoicesButtonEnabled_Xpath = "//*[not(contains(@class, 'disabled')) and @id='btnPrintCustomerInvoiceList']";

        public string CustomerInvoices_Filter_Search_Xpath = ".//*[@id='gridCustomerInvoiceList_filter']//input";
        public string CustomerInvoives_TotalCustomerNumber_Records_Xpath = ".//*[@id='gridCustomerInvoiceList']//td[3]/span[1]";

        public string CustomerInvocies_NoResultFound_Xpath = "//div/table[@role='grid']//td[1]";

        // Customer Invoice Grid Top
        public string CustomerInvoices_GridTop_Showing_Id = "gridCustomerInvoiceList_info";
        public string CustomerInvoices_GridTop_Showing_xpath = ".//*[@class=' headerPosition']//*[@role='status']";
        public string CustomerInvoices_GridTop_View_Xpath = ".//*[@class=' headerPosition']/div[@class='dataTables_length']/label";
        public string CustomerInvoices_GridTop_PreviousButton_Xpath = ".//*[@class=' headerPosition']//li[@class='paginate_button previous']/a";
        public string CustomerInvoices_GridTop_NextButton_Xpath = ".//*[@class=' headerPosition']//*[@class='paginate_button next']/a";
        public string CustomerInvoices_GridTop_Options_Xpath = ".//*[@class='table-header-row']//label/select/option";
        public string CustomerInvoices_GridTop_Clik_View_Xpath = ".//*[@class='dataTables_length']/label/select";
        public string CustomerInvoices_GridTop_NextPageButton_Id = "gridCustomerInvoiceList_next";
        public string CustomerInvoices_GridTop_PreviousPageButton_Id = "gridCustomerInvoiceList_previous";

        //Customer Invoice Grid Bottom
        public string CustomerInvoices_GridBottom_Showing_Xpath = ".//*[@class='table-footer-row']//*[@class='dataTables_info']";
        public string CustomerInvoices_GridBottom_View_Xpath = ".//*[@class=' footerPosition']/div[@class='dataTables_length']/label";
        public string CustomerInvoices_GridBottom_PreviousButton_Xpath = ".//*[@class=' footerPosition']//li[1]/a";
        public string CustomerInvoices_GridBottom_NextButton_Xpath = ".//div[@class='table-footer-row']//ul[@class='pagination']/li[2]/a";
        public string CustomerInvoices_GridBottom_NextButton_Click_Xpath = ".//*[@id='gridCustomerInvoiceList_wrapper']//*[@class='paginate_button next']/a/span";
        public string CustomerInvoices_GridBottom_Click_View_Xpath = ".//*[@class='table-footer-row']//*[@class='form-control input-sm']";
        public string CustomerInvoices_GridBottom_Options_Xpath = ".//*[@class='table-footer-row']//*[@class='form-control input-sm']//option";

        //Columns in the Grid
        public string CustomerInvoices_SalesRep_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[2]";
        public string CustomerInvoices_AccountNumber_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[3]";
        public string CustomerInvoices_StationName_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[4]";
        public string CustomerInvoices_CustomerNumber_Name_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[5]";

        public string CustomerInvoices_InvoiceNumber_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[6]";
        public string CustomerInvoices_ReferenceIDNumber_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[7]";
        public string CustomerInvoices_InvoiceDate_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[8]";
        public string CustomerInvoices_DueDate_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[9]";
        public string CustomerInvoices_OriginalAmount_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[10]";
        public string CustomerInvoices_Current_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[11]";
        public string CustomerInvoices_DaysPastDue_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[12]";
        public string CustomerInvoices_DisputeCode_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[13]";
        //public string CustomerInvoices_InvoiceNumber_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[5]";
        //public string CustomerInvoices_ReferenceIDNumber_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[6]";
        //public string CustomerInvoices_InvoiceDate_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[7]";
        //public string CustomerInvoices_DueDate_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[8]";

        //For Customer Invoices Closed
        public string CustomerInvoices_PaymentDate_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[10]";
        //Xpath for Days Past Due using Text property. Used when Closed display option is selected
        public string CustomerInvoices_DaysPastDueUsingText_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[contains(text(),'Day')]";
        public string CustomerInvoices_OutstandingAmount_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[11]";

        //public string CustomerInvoices_DaysPastDue_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[11]";
        //public string CustomerInvoices_DisputeCode_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[12]";
        //public string CustomerInvoices_OriginalAmount_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[9]";

        public string CustomerInvoives_DisplayAllRow_Xpath = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/tbody/tr";
        public string CustomerInvoice_GridColum_Xpath = "//div[@class='calendar right']//div[@class='calendar-table']";
        public string CustomerInvoice_FirstRowCheckbox = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/tbody/tr[1]/td[1]/div";
        public string CustomerInvoice_SecondRowCheckbox = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/tbody/tr[2]/td[1]/div";
        public string CustomerInvoice_ThirdRowCheckbox = "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']/tbody/tr[3]/td[1]/div";

        //Custom report grid data
        public string CustomReportGridData_xpath = ".//*[@id='gridCustomerInvoiceList1308201802130013']/tbody/tr/td";

        // Column A
        //Sales Rep Column
        public string CustomerInvoices_SalesRep_All_Xpath = "//div/table[@role='grid']//tr/td[1]";

        //Account Number column
        public string CustomerInvoices_AccountNumber_All_Xpath = "//div/table[@role='grid']//tr/td[2]";

        public string CustomerInvoices_Station_All_xpath = "//div/table[@role='grid']//tr/td[3]";

        public string CustomerInvoices_CustomerNumber_All_xpath = "//div/table[@role='grid']//tr/td[4]";

        public string CustomerInvoices_CustomerName_All_xpath = "//div/table[@role='grid']//tr/td[4]/span[2]";

        //invoice Number column
        public string Customerinvoices_InvoiceNumber_All_Xpath = "//div/table[@role='grid']//tr/td[5]";

        //InvoiceNumberColumn 
        public string CustomerinvoicesInvoiceNumber_All_Xpath = ".//*[contains(@id,'gridCustomerInvoiceList')]//tr[@role='row']/td[6]/a";

        //Reference Number Column
        public string CustomerInvoices_ReferenceNumber_All_Xpath = "//div/table[@role='grid']//tr/td[6]";

        //Invoice Date column
        public string CustomerInvoices_InvoiceDateAll_Xpath = "//div/table[@role='grid']//tr/td[8]";

        //Due Date column
        public string CustomerInvoices_DueDateAll_Xpath = "//div/table[@role='grid']//tr/td[9]";

        //Original Amount Column
        public string CustomerInvoices_OriginalAmountAll_Xpath = "//div/table[@role='grid']//tr/td[10]";

        //Current column
        public string CustomerInvoices_CurrentAll_Xpath = "//div/table[@role='grid']//tr/td[11]";

        //DaysPast Due Column
        public string CustomerInvoices_DaysPastDue_All_Xpath = "//div/table[@role='grid']//tr/td[11]";

        //Dispute Code Column
        public string CustomerInvoices_DisputeCode_All_Xpath = "//div/table[@role='grid']//tr/td[12]";


        public string CustomerInvoice_ALLRadiobutton_xpath = ".//*[@id='gridCustomerInvoiceList_wrapper']//label[@for='FilterByAll']";

        public string CustomerInvoice_TopGrid_DisplayListViewDropdown_Xpath = ".//*[@class=' headerPosition']//label/select";
        public string CustomerInvoice_TopGrid_DisplayListDropdownOptions_Xpath = ".//*[@class=' headerPosition']//label/select/option";
        public string CustomerGrid_NoResultFoundMessage_Xpath = "//td[@valign='top']";

        //Custom report
        public string SelectExistingReportDropdown_xpath = "//a[@class='chosen-single chosen-default']//span";
        public string SelectExistingReportDropdown_id = "customReportSelection_chosen";
        public string SelectExistingReportValues_Id = "customReportSelection";
        public string SelectExistingReportDropdownValues_xpath = ".//*[@id='customReportSelection_chosen']//li";
        public string SelectedReport = "//*[@id='customReportSelection_chosen']/a/span";
        public string createCustomReportsectionExpandArrow_id = "expandCreateCustom";
        public string scheduleReportButton_id = "reportBtnSchedule";
        public string scheduleReportButtononmodal_id = "btnScheduleReport";
        public string weeklytab_id = "Tab_tabWeekly";
        public string selectday = ".//*[@id='weekDays_chosen']/a";
        public string selectdayValues = ".//*[@id='weekDays_chosen']/div/ul/li";
        public string selectTime = ".//*[@id='hours_chosen']/a";
        public string selectTimeHour = ".//*[@id='hours_chosen']/a";
        public string selectTimeHourValues = ".//*[@id='hours_chosen']/div/ul/li";
        public string selectTimeMinute = ".//*[@id='minutes_chosen']/a";
        public string selectTimeMinuteValues = ".//*[@id='minutes_chosen']/div/ul/li";
        public string selectTimeAM = ".//*[@id='Tab_tabWeekly']//div[4]//label";
        public string selectTimePM = ".//*[@id='Tab_tabWeekly']//div[4]//label";
        public string DefaultRadioCheck = ".//*[@id='Tab_tabWeekly']//div[4]//input[@type='Radio']";
        public string tabMonthly_id = "tabMonthly";
        public string ScheduleReportmodal_xpath = ".//*[@id='modalScheduleCustomReport']/div/div/div/div";
        public string errormessage_id = "ScheduleCustomReportErrMsg";
        // public string SelectExistingReportDropdown_xpath = "//SPAN[text()='Select...']";
        public string InvoiceValueMaxLimit_Xpath = "//div[@id='InvoiceValueFilter_chosen']//a[@class='chosen-single']";

        public string CustomerInvoice_CreateNewButton_Id = "reportBtnCreate";
        public string CustomerInvoice_CreateNewButton_Xpath = "//*[@id='reportBtnCreate']";
        public string CustomReportHeaderSection_Xpath = "//h4[@class='panel-title']";
        public string CustomReportHeaderSection_Id = "reportNameForHeader";
        public string CustomReportSection_ExpandArror_Id = "expandCreateCustom";
        public string CustomReport_DeleteButton_Id = "reportBtnDelete";
        public string CustomReport_CreateOrEditSection_Id = "CreateOrEditReportSection";
        public string customReportModalHeader_xpath = ".//*[@id='modalScheduleCustomReport']//h3/span";
        public string customReportModal_WeeklyTab_Xpath = ".//*[@id='tabsTimePeriod']//li[1]";
        public string customReportModal_MonthlyTab_Xpath = ".//*[@id='tabsTimePeriod']//li[2]";
        public string ReportDeliveryOptionsHeader_Xpath = ".//*[@class='row reportDeliverySection']//h3";
        public string ReportDeliveryOptionsLabel_To_Xpath = ".//*[@class='row reportDeliverySection']//label[contains(text(),'TO *')]";
        public string ReportDeliveryOptions_To_id = "toEmail";
        public string ReportDeliveryOptionsLabel_CC_Xpath = ".//*[@class='row reportDeliverySection']//label[contains(text(),'CC')]";
        public string ReportDeliveryOptions_CC_id = "ccEmail";
        public string ReportDeliveryOptionsLabel_ReplyTo_Xpath = ".//*[@class='row reportDeliverySection']//label[contains(text(),'REPLY')]";
        public string ReportDeliveryOptions_ReplyTo_id = "replyToEmail";
        public string ReportDeliveryOptionsLabel_Format_Xpath = ".//*[@class='row reportDeliverySection']//label[contains(text(),'FORMAT *')]";
        public string ReportDeliveryOptions_FormatDropdown_Xpath = ".//*[@id='formatEmail_chosen']/a[@class='chosen-single']/span";
        public string ReportDeliveryOptions_FormatDropdownValues_Xpath = ".//*[@id='formatEmail_chosen']/div/ul";
        public string ReportDeliveryOptionsLabel_Subject_Xpath = ".//*[@class='row reportDeliverySection']//label[contains(text(),'SUBJECT *')]";
        public string ReportDeliveryOptions_Subject_id = "subjectEmail";
        public string ReportDeliveryOptionsLabel_Comment_Xpath = ".//*[@class='row reportDeliverySection']//label[contains(text(),'COMMENT')]";
        public string btnCancelSchedule = "bodyEmail";
        public string ReportDeliveryOptions_Comment_classname = "bodyEmail";
        public string customReportModal_CancelButton_id = "btnCancelSchedule";
        public string customReportModal_DeleteSchedule_id = "btnDeleteSchedule";
        // public string customReportModal_ScheduleReport_id = "reportBtnSchedule";
        public string customReportselectedvalue_xpath = ".//*[@id='customReportSelection_chosen']//span";
        public string tabMonthly = ".//*[@id='hours_chosen']/div/ul/li";
        public string CustomReportNameIndexFour_Xpath = ".//*[@id='customReportSelection_chosen']/div/ul/li[4]";

        public string customReportModal_ScheduleReport_id = "btnScheduleReport";


        //Weekly schedule page elements----------------------

        public string WeeklyTabScheduleReport_SELECTDAY_xpath = ".//*[@id='Tab_tabWeekly']/div[1]/div[1]/p";
        public string Weekly_SelectDay_xpath = ".//*[@id='weekDays_chosen']/a";
        public string Weekly_SelectDay_Values_xpath = ".//*[@id='weekDays_chosen']//ul/li";
        public string Weekly_SelectTimeHours_xpath = ".//*[@id='hours_chosen']/a";
        public string Weekly_SelectTimeHours_Values_xpath = ".//*[@id='hours_chosen']//ul/li";

        public string WeeklyDefault_SelectDayValue_xpath = ".//*[@id='weekDays_chosen']/a/span";
        public string WeeklyDefault_SelectHoursvalue_xpath = ".//*[@id='hours_chosen']/a/span";
        public string WeeklyDefault_SelectMinutessvalue_xpath = ".//*[@id='minutes_chosen']/a/span";

        //Create Custom Report section
        public string CustomeReport_CreateCustomReport_Text_Xpath = ".//*[@id='CreateEditReportSectionHeader']/h4";
        public string CustomReport_CreateCustomReport_Arrow_Xpath = ".//*[@id='expandCreateCustom']/span";
        public string CustomReport_InvoiceType_Xpath = ".//*[@id='CreateOrEditReportSection']//*[text()='INVOICE TYPE']";
        public string CustomReport_EditPannel_Xpath = ".//*[@id='CreateOrEditReportSection']/div";
        public string CustomReport_Open_Xpath = ".//*[@id='CreateOrEditReportSection']//*[@class='form-group-inline radio-grey']/div[1]/label";
        public string CustomReport_OpenRadioButton_Xpath = "//*[@id='InvoiceTypeOpen']";
        public string CustomReport_Close_Xpath = ".//*[@id='CreateOrEditReportSection']//*[@class='form-group-inline radio-grey']/div[2]/label";
        public string CustomReport_CloseRadioButton_Xpath = ".//*[@id='InvoiceTypeClosed']";
        public string CustomReport_All_Xpath = ".//*[@id='CreateOrEditReportSection']//*[@class='form-group-inline radio-grey']/div[3]/label";
        public string CustomReport_AllRadioButton_Xpath = ".//*[@id='InvoiceTypeAll']";
        public string CustomReport_DaysPastDueSelector_Xpath = ".//*[@id='daysPastDueWrapper']/label";
        public string CustomReport_DaysPastDueInput_Xpath = "//*[@id='DaysPastDue']";
        public string CustomReport_InvoiceValue_Input_Id = "InvoiceValue";
        public string CustomReport_InvoiceValueField_Xpath = "//*[@id='InvoiceValue']";
        public string CustomReport_DateRangeSelector_Xpath = ".//*[@id='CreateOrEditReportSection']//div[4]/label";
        public string CustomReport_DateRangePlaceHolder_Id = "ReportDateRange";
        public string CustomReport_Stations_Xpath = ".//*[@id='CreateOrEditReportSection']//*[text()='Stations *']";
        public string CustomReport_Stations_InputText_Xpath = ".//*[@id='ReportStations_chosen']/ul/li/input";
        public string CustomReport_Accounts_Xpath = ".//*[@id='CreateOrEditReportSection']//*[text()='Accounts *']";
        public string CustomReport_Accounts_InputText_Xpath = ".//*[@id='ReportAccounts_chosen']/ul/li/input";
        public string CustomReport_PageNumberDropdown_Xpath = ".//*[@id='gridCustomerInvoiceList3819201810383538_length']/label/select";
        public string CustomReport_ReportName_Xpath = ".//*[@id='CreateOrEditReportSection']//*[text()='Report Name *']";
        public string CustomReport_Preview_Run_Button_Id = "reportBtnRun";
        public string CustomReportGridDisplay_Records_Xpath = ".//*[@id='00000000-0000-0000-0000-000000000000']/td[2]";
        public string CustomeReport_CloseButton_Xpath = ".//*[@id='CreateOrEditReportSection']/div/div[1]/div[1]/div[2]/div[2]/label";
        public string CustomReport_Preview_Run_Button_Xpath = "//*[@id='reportBtnRun']";
        public string SelectExistingCustomReport_CLick_Xpath = ".//*[@id='customReportSelection_chosen']/a";
        public string SelectExistingCustomReport_SelectAny_Xpath = ".//*[@id='customReportSelection_chosen']//ul/li";
        public string CustomReport_ScheduleReportButton_Id = "reportBtnSchedule";
        public string CustomReport_ReportName_Input_Id = "ReportName";
        public string CustomReport_DaysPastDue_Input_Id = "DaysPastDue";
        public string CustomReport_StationNameSelectedAll_Xpath = ".//*[@id='ReportStations_chosen']/ul/li/span";
        public string CustomReport_CustomerNameSelectedAll_Xpath = ".//*[@id='ReportAccounts_chosen']/ul/li/span";
        public string CustomReport_DateRange_Start_Input_Xpath = "//div[8]//div[1]//input";
        public string CustomReport_DateRange_End_Input_Xpath = "//div[8]//div[2]//input";
        public string CustomReport_DateRange_StartDate_All_Xpath = "//div[8]//div[1]//div[2]//tr/td";
        public string CustomReport_DateRange_EndDate_All_Xpath = "//div[8]/div[2]/div[2]//tr/td";
        public string CustomReport_StationList_All_Xpath = ".//*[@id='ReportStations_chosen']/div/ul/li";
        public string CustomReport_AccountList_All_Xpath = ".//*[@id='ReportAccounts_chosen']/ul/li/input";
        public string CustomReport_Schedule_Monthly_Tab_Xpath = ".//*[@id='tabMonthly']/a";
        public string CustomReport_ExistingReportSelectedName_Xpath = ".//*[@id='customReportSelection_chosen']/a/span";
        public string CustomReport_TimePeroid_Xpath = ".//*[@id='modalScheduleCustomReport']//*[text()='Time Period']";
        public string CustomReport_Delete_Popup_Xpath = ".//*[@id='modalConfirmDeleteScheduleReport']/div/div/div/div";
        public string CustomReport_Delete_Popup_Message_Xpath = ".//*[@id='modalConfirmDeleteScheduleReport']//div/p";
        public string CustomReport_Delete_popup_ConfirmButton_Id = "btnConfirmDeleteSchedule";
        public string CustomReport_Delete_Popup_CancelButton_Xpath = ".//*[@id='modalConfirmDeleteScheduleReport']//a[1]";
        public string CustomReport_Save_Edits_Button = "//*[@id='reportBtnedit']";



        public string ReportName_Xpath = "//INPUT[@id='ReportName']";
        public string CreateReportNewButton_Id = "reportBtnCreate";
        public string DeleteReportButton_Id = "reportBtnDelete";
        public string DaysPastDue_Id = "DaysPastDue";
        public string InvoiceVal_Id = "InvoiceValue";
        public string DateRange_Xpath = "//INPUT[@id='ReportDateRange']";
        public string ReportStationName_Xpath = "//div[@id='ReportStations_chosen']//ul[@class='chosen-choices']//li[@class='search-field']";
        public string ReportStationDropdownVal_Xapth = "//li[@class='result-selected']";
        public string FromDate_Xpath = "html/body/div[8]/div[1]/div[1]/input";
        public string ToDate_Xpath = "html/body/div[8]/div[2]/div[1]/input";
        public string ReportAccountDropdownVal_Xpath = "//div[@id='ReportAccounts_chosen']//ul[@class='chosen-results']/li";
        public string ReportAccount_Xpath = "//div[@id='ReportAccounts_chosen']";
        public string ValidationMessageCreateSection_Xpath = "//DIV[@id='validationWarning']";
        public string customReportInvoiceType_Xpath = "";
        public string CustomreportNameForHeader_Id = "reportNameForHeader";
        public string CustomReport_CreateReportSection_InvoiceType_Closed_Xpath = "//label[@for='InvoiceTypeClosed']";
        public string CustomReport_CreateReportSection_InvoiceType_Open_Xpath = "//label[@for='InvoiceTypeOpen']";
        //public string CustomReport_CreateReportSection_InvoiceValueRangeSelector_Xpath = ".//*[@id='InvoiceValueFilter_chosen']/div/ul/li";
        public string CustomReport_CreateReportSection_InvoiceValueRangeSelector_Xpath = "//*[@id='InvoiceValueFilter']";
        public string CustomReport_CreateReportSection_InvoiceRangeSelector_Selected_Xpath = ".//*[@id='InvoiceValueFilter_chosen']/a/span";
        public string CustomReport_CreateReportSection_InvoiceType_Open_Id = "InvoiceTypeOpen";
        public string CustomReport_CreateReportSection_InvoiceType_Closed_Id = "InvoiceTypeClosed";
        public string CustomReport_CreateReportSection_InvoiceType_All_Id = "InvoiceTypeAll";
        public string CustomReport_CreateReportSection_UpArrowDaysPastDue_Id = "upArrowDaysPastDue";
        public string CustomReport_CreateReportSection_DownArrowDaysPastDue_Id = "downArrowDaysPastDue";
        public string CustomReport_CreateReportSection_DateRangeLeftCalender_Xpath = "html/body/div[8]/div[1]/div[2]/table";
        public string CustomReport_CreateReportSection_DateRangeRightCalender_Xpath = "html/body/div[8]/div[2]/div[2]/table";
        public string CustomReport_CreateReportSection_DateRangePicker_Xpath = ".//*[@id='ReportDateRange']";
        public string CustomReport_CreateReportSection_DateRangePicker_AvailableDates_Xpath = "html/body/div[8]/div[1]/div[2]/table/tbody/tr/td";

        //-------------------------Scheduled Report Monthly Tab--------------------------------------------------//
        public string CustomerInvoice_SelectMonths_Label_Xpath = "//p[text()='SELECT MONTHS *']";
        public string CustomerInvoice_WeeklyTab_Xpath = "//a[@data-toggle='tab'][contains(text(),'Weekly')]";
        public string CustomerInvoice_MonthlyTab_Xpath = ".//*[@id='tabMonthly']/a";
        public string CustomerInvoice_JanuaryCheckbox_Xpath = "//input[@id='monthJanuary']";
        public string CustomerInvoice_FebuaryCheckbox_Xpath = "//input[@id='monthFebruary']";
        public string CustomerInvoice_MarchCheckbox_Xpath = "//input[@id='monthMarch']";
        public string CustomerInvoice_AprilCheckbox_Xpath = "//input[@id='monthApril']";
        public string CustomerInvoice_MayCheckbox_Xpath = "//input[@id='monthMay']";
        public string CustomerInvoice_JuneCheckbox_Xpath = "//input[@id='monthJune']";
        public string CustomerInvoice_JulyCheckbox_Xpath = "//input[@id='monthJuly']";
        public string CustomerInvoice_AugustCheckbox_Xpath = "//input[@id='monthAugust']";
        public string CustomerInvoice_SeptemberCheckbox_Xpath = "//input[@id='monthSeptember']";
        public string CustomerInvoice_OctoberCheckbox_Xpath = "//input[@id='monthOctober']";
        public string CustomerInvoice_NovemberCheckbox_Xpath = "//input[@id='monthNovember']";
        public string CustomerInvoice_DecemberCheckbox_Xpath = "//input[@id='monthDecember']";
        public string CustomReport_InvoiceValueSign_xpath = ".//*div[@id='InvoiceValueFilter_chosen']//span";

        public string CustomReportRequiredFieldValidationMsg_Id = "validationWarning";
        public string CustomReportReportName_Id = "ReportName";
        public string CustomReportAccountsfield_xpath = ".//*[@id='ReportAccounts_chosen']/ul/li";

        public string CustomReportDaysPastDueField_Id = "DaysPastDue";
        public string CustomReport_Accounts_xpath = "//div[@id='ReportAccounts_chosen']";
        public string CustomReport_AccountSelectionValues_xpath = "//div[@id='ReportAccounts_chosen']//ul[@class='chosen-results']/li";

        public string CustomReport_DateRangeStartDate_Name = "daterangepicker_start";

        public string CustomReport_DateRangeEndDate_Name = "daterangepicker_end";
        public string CustomReport_Station_xpath = "//div[@id='ReportStations_chosen']";
        public string CustomReport_StationSelectionValues_xpath = "//div[@id='ReportStations_chosen']//ul[@class='chosen-results']/li";
        public string CustomReport_StationSelection_Close_Button = "//*[@id='ReportStations_chosen']/ul/li[1]/a";
        public string CustomReport_AccountSelection_Close_Button = "//*[@id='ReportAccounts_chosen']/ul/li[1]/a";
        public string CustomerInvoice_JanuaryCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthJanuary']";
        public string CustomerInvoice_FebuaryCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthFebruary']";
        public string CustomerInvoice_MarchCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthMarch']";
        public string CustomerInvoice_AprilCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthApril']";
        public string CustomerInvoice_MayCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthMay']";
        public string CustomerInvoice_JuneCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthJune']";
        public string CustomerInvoice_JulyCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthJuly']";
        public string CustomerInvoice_AugustCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthAugust']";
        public string CustomerInvoice_SeptemberCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthSeptember']";
        public string CustomerInvoice_OctoberCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthOctober']";
        public string CustomerInvoice_NovemberCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthNovember']";
        public string CustomerInvoice_DecemberCheckbox_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[@for='monthDecember']";

        public string CustomerInvoice_SelectDay_Label_Xpath = "//div[@id='Tab_tabMonthly']//p[text()='SELECT DAY *']";


        public string CustomerInvoice_SelectDayMonthlyWeeks_RadioButton_Xpath = "//input[@id='radioBtnMonthlyTypeWeeks']";
        public string CustomerInvoice_SelectDayMonthlyDays_RadioButton_Xpath = "//input[@id='radioBtnMonthlyTypeDays']";
        public string CustomerInvoice_SelectDayMonthlyWeek_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='WEEK']";
        public string CustomerInvoice_SelectDayMonthlyWeek_DropDown_Xpath = "//div[@id='MonthlyWeek_chosen']";
        public string CustomerInvoice_SelectDayMonthlyWeek_DropDownValues_Xpath = "//div[@id='MonthlyWeek_chosen']//li";
        public string CustomerInvoice_SelectDayMonthlyWeekDay_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='WEEK DAY']";
        public string CustomerInvoice_SelectDayMonthlyWeekDay_DropDown_Xpath = "//div[@id='MonthlyWeekDay_chosen']";
        public string CustomerInvoice_SelectDayMonthlyWeekDay_DropDownValues_Xpath = "//div[@id='MonthlyWeekDay_chosen']//li";
        public string CustomerInvoice_SelectSpecificDayOfMonth_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='SPECIFIC DAY OF MONTH']";
        public string CustomerInvoice_SelectSpecificDayOfMonth_DropDown_Xpath = "//input[@id='monthlyDays']";
        public string CustomerInvoice_SelectSelectTimeLabelMonthly_DropDown_Xpath = "//div[@id='Tab_tabMonthly']//p[text()='SELECT TIME *']";
        public string CustomerInvoice_SelectTimeMonthlyHours_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='HOURS']";
        public string CustomerInvoice_SelectTimeMonthlyHours_DropDown_Xpath = "//div[@id='monthlyhours_chosen']";
        public string CustomerInvoice_SelectTimeMonthlyHours_DropDownValues_Xpath = "//div[@id='monthlyhours_chosen']//div[@class='chosen-drop']//li";
        public string CustomerInvoice_SelectTimeMonthlyMinutes_DropDown_Xpath = "//div[@id='monthlyminutes_chosen']";
        public string CustomerInvoice_SelectTimeMonthlyMinutes_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='MINUTES']";
        public string CustomerInvoice_SelectTimeMonthlyMinutes_DropDownValues_Xpath = "//div[@id='monthlyminutes_chosen']//li";
        public string CustomerInvoice_SelectTimeMonthlyAM_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='AM']";
        public string CustomerInvoice_SelectTimeMonthlyAM_Button_Xpath = "//input[@id='radioBtnMonthlyAmPmAM']";
        public string CustomerInvoice_SelectTimeMonthlyPM_Label_Xpath = "//div[@id='Tab_tabMonthly']//label[text()='PM']";
        public string CustomerInvoice_SelectTimeMonthlyPM_Button_Xpath = "//input[@id='radioBtnMonthlyAmPmPM']";
        public string CustomerInvoice_SpecialDayofMonth_Id = "monthlyDays";
        public string CustomerInvoice_HourByDefaultName_Xpath = ".//*[@id='monthlyhours_chosen']//*[text()='Select hour...']";
        public string CustomerInvoice_MinutesDefaultName_Xpath = ".//*[@id='monthlyminutes_chosen']//*[text()='Select minutes...']";

        public string CustomerInvoice_SelectedReportName_Monthly_Xpath = ".//*[@id='modalScheduleCustomReport']//*[@class='customReportName']";

        public string CustomReport_StationDropdownId = "ReportStations";
        public string CustomReport_CustomerDropdownId = "ReportAccounts";
        public string CustomReport_Selected_Stations = "ReportStations_chosen";
        public string CustomReport_Selected_Customers = "ReportAccounts_chosen";
        public string CustomReport_Station_DropDownList = "//div[@id='ReportStations_chosen']/div/ul/li";
        public string CustomReport_Account_DropDownList_Xpath = ".//*[@id='ReportAccounts_chosen']/div/ul/li";
        public string CustomReport_AccountDropdown_AllAccount_Xpath = ".//*[@id='ReportAccounts_chosen']/div/ul/li[1]";
        public string CustomReport_SubAccountList = ".//li[contains (@class,'level3')]";
        public string CustomReport_SubAccountListNames = "//li[@class='active-result group-option level3']";
        public string CustomReport_StationDropdown_Xpath = ".//*[@id='ReportStations_chosen']/div/ul/li";
        public string CustomReport_Input_XPath = ".//*[@id='ReportStations_chosen']";
        public string CustomReport_SearchActive_Xpath = ".//*[contains(@class,'active-result')]";
        public string CustomReport_StationInputField_Xpath = "//div[@id='ReportStations_chosen']//ul//li[@class='search-field']//input[@value='Select one or more...']";
        public string CustomReport_AccountInputField_Xpath = "//div[@id='ReportAccounts_chosen']//ul//li[@class='search-field']//input[@value='Select one or more...']";
        public string CustomReportStationDropDownRRDAccessUser = ".//*[@id='AccessRRDStations_chosen']/div[@class = 'chosen-drop']/ul[@class = 'chosen-results']/li";
        public string CustomReport_AccountList_Xpath = "//div[@id='ReportAccounts_chosen']/div/ul/li";
        public string CustomReport_Account_Xpath = ".//*[@id='ReportAccounts_chosen']";
        public string CustomReport_SearchResult_Xpath = ".//*[@id='ReportAccounts_chosen']/div/ul/li/em";
        public string CustomReport_StationList_Xpath = "//li[@class='group-result']";

        public string CustomerInvoice_ValidationErrorMessage_Xpath = "//span[@id='ScheduleCustomReportErrMsg']";

        public string schedulePageScheduleReportButton_Xpath = "//a[@id='btnScheduleReport']";

        public string CustomInvoiceExportButton_Id = "btnExortCustomerInvoiceList";
        public string CustomInvoiceExportExcel_Id = "ExportExcel";
        public string CustomInvoiceExportPDF_Id = "ExportPdf";
        public string CustomInvoiceGridAllVal_Xpath = "//html//tr/td";
        public string CustomInvoiceGridHeaderVal_Xpath = "//html//th";
        public string CustomInvoiceGridOpenFilter_Xpath = "//div[@class='dom-center']//div[@class='form-group']//div[@class='form-group-inline']//div[@class='radio inline-element']//label[@for='FilterByUnpaid']";
        public string CustomInvoiceGridClosedFilter_Xpath = " //div[@class='dom-center']//div[@class='form-group']//div[@class='form-group-inline']//div[@class='radio inline-element']//label[@for='FilterByPaid']";
        public string CustomInvoiceGridAllFilter_Xpath = "//div[@class='dom-center']//div[@class='form-group']//div[@class='form-group-inline']//div[@class='radio inline-element']//label[@for='FilterByAll']";
        public string CustomerInvoiceGridCustomerNum_Xpath = "(//TD[@class=' trible-line-header CustomerNum all'])";
        public string CustomerInvoiceReportName_Xpath = "//INPUT[@id='ReportName']";
        public string CustomerInvoiceReportName_Id = "ReportName";
        public string CustomerInvoiceGridEmpty_Xpath = "//td[@class='dataTables_empty']";
        public string CustomerInvoiceAccessRrdStation_Xpath = "//div[@id='AccessRRDStations_chosen']//li[@class='search-field']";
        public string CustomerInvoiceAccessRrdStationDropdown_Xpath = ".//*[@id='AccessRRDStations_chosen']/div[@class = 'chosen-drop']/ul/li";
        public string CustomerInvoiceAccessRrdCustomer_Xpath = "//div[@id='AccessRRDAccounts_chosen']//li[@class='search-field']";
        public string CustomerInvoiceAccessRrdCustomerDropdown_Xpath = ".//*[@id='AccessRRDAccounts_chosen']/div[@class = 'chosen-drop']/ul/li";
        public string CustomerIvoiceGridClosedOption_Xpath = "(//LABEL[@for='FilterByPaid'][text()='CLOSED'][text()='CLOSED'])[1]";

        public string CreateCustomReportDateRange_xpath = "//div[3]/div/button[@class='cancelBtn btn btn-sm btn-default']";
        public string GridCustomerInvoiceList = "//*[@id='ckb-gridCustomerInvoiceList1621201801160816-Id-'";
        public string GridCustomerInvoiceListId1 = "//*[@id='ckb-gridCustomerInvoiceList1621201801160816-Id-0']";
        public string GridCustomerInvoiceListId2 = "//*[@id='ckb-gridCustomerInvoiceList1621201801160816-Id-1']";
        public string GridCustomerInvoiceListId = "ckb-gridCustomerInvoiceList1621201801160816-Id-0";
        public string GridCustomerInvoiceListId_0 = "gridCustomerInvoiceList3422201809342934-Id-0";

        //Access RRD search options
        public string SearchFieldDropDown_xpath = "//*[@id='InvoiceSearchDDSelection_chosen']";
        public string SearchFieldDropDownOptions_xpath = "//*[@id='InvoiceSearchDDSelection_chosen']//li";
        public string SearchAreaOpenRadioButton_xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[3]/div/div[1]/label[@for='InvoiceSearchTypeOpen']";
        public string SearchAreaClosedRadioButton_xpath = "//*[@id='page-content-wrapper']/div[2]/div[2]/div[5]/div[3]/div/div[2]/label[@for='InvoiceSearchTypeClosed']";
        public string SearchAreaTextInput_xpath = "//*[@id='InvoiceSearchSelectedValue']";
        public string SearchAreaSearchInvoicesButton_xpath = "//*[@id='AccessRRDSearchInvoice']";
        public string SearchAreaSearchInvoicesButton_id = "AccessRRDSearchInvoice";
        public string AccessRRDStationsSearchDropDown_xpath = "//*[@id='AccessRRDStations_chosen']";
        public string AccessRRDAccountsSearchDropDown_xpath = "//*[@id='AccessRRDAccounts_chosen']";

        public string CreateCustomReport_StationDropdown_Xpath = "//div[@id='ReportStations_chosen']";
        public string CreateCustomreport_StationDropdownValue_Xpath = "//div[@id='ReportStations_chosen']//ul[@class='chosen-results']/li";
        public string SelectExistingReportDropdown_Xpath = ".//*[@id='customReportSelection_chosen']/a";
        public string SelectExistingReportDropdown_SearchInputInDropdown_Xpath = ".//*[@id='customReportSelection_chosen']/div/div/input";
        public string SelectExistingReport_SearchedDataSelectInDropdown_Xpath = ".//*[@id='customReportSelection_chosen']/div/ul/li";
        public string CustomerInvoiceGridHeaderElement_Xpath = ".//*[@id='gridCustomerInvoiceListContainer']//thead/tr/th[3]";
        public string CustomerInvoiceGridPageViewDropdown_Xpath = ".//*[@id='gridCustomerInvoiceListContainer']//div[@class='table-header-row']//select";
        public string CustomerInvoiceGridPageViewDropdownValue_Xpath = ".//*[@id='gridCustomerInvoiceListContainer']//div[@class='table-header-row']//select/option";
        public string CustomerInvoiceGridContentLoadCheck_Xpath = ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[1]";
        public string AccessRRDAccountsSearch_xpath = ".//*[@id='AccessRRDAccounts_chosen']/ul/li";
        public string AccountDropdownValue_AllAccount_xpath = ".//*[@id='AccessRRDAccounts_chosen']/div/ul/li[1]";


    }
}


