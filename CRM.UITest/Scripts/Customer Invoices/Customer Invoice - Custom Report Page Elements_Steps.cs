using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
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

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public sealed class Customer_Invoice___Custom_Report_Page_Elements_Steps : Customer_Invoice
    {

        public string Reportnameselected;

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner and  access rrd user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerAndAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I arrived on Customer Invoice List page")]
        public void WhenIArrivedOnCustomerInvoiceListPage()
        {
            Report.WriteLine("Click on Customer Invoices icon");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            DefineTimeOut(20000);

            Report.WriteLine("I arrived on Customer Invoices Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            
        }

        [Then(@"I will see a section - Create Custom Report")]
        public void ThenIWillSeeASection_CreateCustomReport()
        {
            Report.WriteLine("I will see the Create Custom Report section");
            Verifytext(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath, "CREATE CUSTOM REPORT");

        }

        [Then(@"The section will be expandable/collapsable")]
        public void ThenTheSectionWillBeExpandableCollapsable()
        {
           
            Report.WriteLine("Create Custom Report Section is expandable");
            Click(attributeName_xpath, CustomReport_CreateCustomReport_Arrow_Xpath);
            Verifytext(attributeName_xpath, CustomReport_InvoiceType_Xpath, "INVOICE TYPE");

            
            Report.WriteLine("Create Custom Report Section is Collapsable");
            Click(attributeName_xpath, CustomReport_CreateCustomReport_Arrow_Xpath);
           
            WaitForElementNotVisible(attributeName_xpath, CustomReport_InvoiceType_Xpath, "INVOICE TYPE");
            VerifyElementNotVisible(attributeName_xpath, CustomReport_InvoiceType_Xpath, "INVOICE TYPE");

        }

        [Then(@"It will be collapsed by default")]
        public void ThenItWillBeCollapsedByDefault()
        {
            Report.WriteLine("By Default it is Collapsed");
            VerifyElementNotVisible(attributeName_xpath, CustomReport_InvoiceType_Xpath, "INVOICE TYPE");
        }

        [Given(@"I arrived on Customer Invoice List page")]
        public void GivenIArrivedOnCustomerInvoiceListPage()
        {
            Report.WriteLine("Click on Customer Invoices icon");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("I arrived on Customer Invoices Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");

            
        }

        
        [Then(@"I will see Criteria Section")]
        public void ThenIWillSeeCriteriaSection()
        {
            Report.WriteLine("I will see the Criteria Section");
            VerifyElementVisible(attributeName_xpath, CustomReport_EditPannel_Xpath, "Edit pannel");
        }
        [Then(@"I will see Invoice Type as required field with Open as default, Closed and All options")]
        public void ThenIWillSeeInvoiceTypeAsRequiredFieldWithOpenAsDefaultClosedAndAllOptions()
        {
            Report.WriteLine("I will see Invoice Type as required field");
            Verifytext(attributeName_xpath, CustomReport_InvoiceType_Xpath, "INVOICE TYPE");

            Report.WriteLine("Open is selected by default");
            RadiobuttonChecked(attributeName_xpath, CustomReport_OpenRadioButton_Xpath);

            Report.WriteLine("I will see the Closed Invoice type option");
            VerifyElementVisible(attributeName_xpath, CustomReport_Close_Xpath, "Closed");

            Report.WriteLine("I will see the All Invocie type option");
            VerifyElementVisible(attributeName_xpath, CustomReport_All_Xpath, "All");

        }

        [Then(@"I will see Days Past Due selector")]
        public void ThenIWillSeeDaysPastDueSelector()
        {
            Report.WriteLine("I will see the Days Past Due Selector");
            VerifyElementVisible(attributeName_xpath, CustomReport_DaysPastDueSelector_Xpath, "Days Past Due");
        }

        [Then(@"I will see Invoice Value field as optional field")]
        public void ThenIWillSeeInvoiceValueFieldAsOptionalField()
        {
            Report.WriteLine("I will see the Invoice value field as Optional");
            VerifyElementVisible(attributeName_xpath, CustomReport_InvoiceValueField_Xpath, "Invoice Value");

            string InvoiceValue = GetValue(attributeName_id, CustomReport_InvoiceValue_Input_Id, "placeholder");
            Assert.AreEqual("$", InvoiceValue);

        }

        [Then(@"I will see Date Range selector as optional field")]
        public void ThenIWillSeeDateRangeSelectorAsOptionalField()
        {
            Report.WriteLine("I will see the Date Range Selector as Optional");
            VerifyElementVisible(attributeName_xpath, CustomReport_DateRangeSelector_Xpath, "Date Range");

            string DateOptional = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "placeholder");
            Assert.AreEqual("Select...", DateOptional);
        }

        [Then(@"I will see Station selection field as required field")]
        public void ThenIWillSeeStationSelectionFieldAsRequiredField()
        {
            Report.WriteLine("I will see the Station Selection field as Required");
            Verifytext(attributeName_xpath, CustomReport_Stations_Xpath, "STATIONS *");

            string Reuiredfield = Gettext(attributeName_xpath, CustomReport_Stations_Xpath);
            string[] Required = Reuiredfield.Split(' ');
            string StationsIsRequired = Required[1];
            Assert.AreEqual("*", StationsIsRequired);

        }

        [Then(@"I will see Accounts selection field as required field")]
        public void ThenIWillSeeAccountsSelectionFieldAsRequiredField()
        {
            Report.WriteLine("I will see Account selection field as Required field");
            Verifytext(attributeName_xpath, CustomReport_Accounts_Xpath, "ACCOUNTS *");

            string Reuiredfield = Gettext(attributeName_xpath, CustomReport_Accounts_Xpath);
            string[] Required = Reuiredfield.Split(' ');
            string AccountIsRequired = Required[1];
            Assert.AreEqual("*", AccountIsRequired);

        }

        [Then(@"I will see Report Name field as required field")]
        public void ThenIWillSeeReportNameFieldAsRequiredField()
        {
            Report.WriteLine("I will see the Report Name field as Required");
            Verifytext(attributeName_xpath, CustomReport_ReportName_Xpath, "REPORT NAME *");

            string Reuiredfield = Gettext(attributeName_xpath, CustomReport_ReportName_Xpath);
            string[] Required = Reuiredfield.Split(' ');
            string ReportIsRequired = Required[2];
            Assert.AreEqual("*", ReportIsRequired);
        }

        [Then(@"I will see Delete button, Create New button, Preview/Run Now button, Schedule Report button")]
        public void ThenIWillSeeDeleteButtonCreateNewButtonPreviewRunNowButtonScheduleReportButton()
        {
            Report.WriteLine("I will see the Delete Button,Create New Button and Preview/Run button");
            VerifyElementPresent(attributeName_id, CustomReport_DeleteButton_Id, "Delete");

            VerifyElementPresent(attributeName_id, CustomerInvoice_CreateNewButton_Id, "Create New");

            VerifyElementPresent(attributeName_id, CustomReport_Preview_Run_Button_Id, "Preview/Run Now"); 
 
        }

        [Given(@"I selected a Custom Report from the Select Existing Custom Report list in customer invoice page")]
        public void GivenISelectedACustomReportFromTheSelectExistingCustomReportListInCustomerInvoicePage()
        {
            Report.WriteLine("I select a Custom Report from the Select Existing Customer Report List");
            Click(attributeName_xpath, SelectExistingCustomReport_CLick_Xpath);

            IList<IWebElement> CustomerDropdown_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingCustomReport_SelectAny_Xpath));
            int CustomerNameListCount = CustomerDropdown_List.Count;
            for (int i = 0; i < CustomerNameListCount; i++)
            {
                if (CustomerNameListCount > 0)
                {
                    Reportnameselected = CustomerDropdown_List[1].Text;
                    CustomerDropdown_List[1].Click();
                    break;
                }
            }
        }


        [Then(@"The Delete button will be active")]
        public void ThenTheDeleteButtonWillBeActive()
        {
            Report.WriteLine("Delete button will be active");
            IsElementEnabled(attributeName_id, CustomReport_DeleteButton_Id, "Delete");

        }

        [Then(@"The Preview/Run Now button will be active")]
        public void ThenThePreviewRunNowButtonWillBeActive()
        {
            Report.WriteLine("Preview / Run Button will be active");
            IsElementEnabled(attributeName_id, CustomReport_Preview_Run_Button_Id, "Preview/Run Now");
        }

        [Then(@"The Schedule Report button will be active")]
        public void ThenTheScheduleReportButtonWillBeActive()
        {
            Report.WriteLine("Schedule Report Button Will Be active");
            IsElementEnabled(attributeName_id, CustomReport_ScheduleReportButton_Id, "Schedule Report");
        }

        [Then(@"The Schedule Report button will be hidden")]
        public void ThenTheScheduleReportButtonWillBeHidden()
        {
            Report.WriteLine("Schedule Report Button Will Be Hidden");
            VerifyElementNotVisible(attributeName_id, CustomReport_ScheduleReportButton_Id, "Schedule Report");
        }



        [Then(@"The Create New button will be inactive")]
        public void ThenTheCreateNewButtonWillBeInactive()
        {
            Report.WriteLine("Create New button will be Inactive");
            IsElementDisabled(attributeName_id, CustomReport_Preview_Run_Button_Id, "Create New");
        }

        [Then(@"The Create New button will be active")]
        public void ThenTheCreateNewButtonWillBeActive()
        {
            Report.WriteLine("Create New Button will be active");
            IsElementEnabled(attributeName_id, CustomerInvoice_CreateNewButton_Id, "Create New");
        }

        [Then(@"The Delete button will be inactive")]
        public void ThenTheDeleteButtonWillBeInactive()
        {
            Report.WriteLine("Delete Button will be Inactive");
            IsElementDisabled(attributeName_id, CustomReport_DeleteButton_Id, "Delete");
        }

        [Then(@"The data for the Criteria and Report Name of the custom report will be display")]
        public void ThenTheDataForTheCriteriaAndReportNameOfTheCustomReportWillBeDisplay()
        {
            if(Reportnameselected.Contains("Scheduled"))
            {
                string[] ScheduledSelectedReport = Reportnameselected.Split('(');
                string ScheduledReport1 = ScheduledSelectedReport[0];
                string ScheduledReport = ScheduledReport1.TrimEnd();

                Report.WriteLine("Report name displayed on the Custom Report section header");
                string CustomReport1 = Gettext(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath);
                string[] customReport1_1 = CustomReport1.Split('(');
                string custom2 = customReport1_1[1];
                string CustomReportNamefromHeader = custom2.TrimEnd(')');

                Assert.AreEqual(ScheduledReport, CustomReportNamefromHeader);

                Report.WriteLine("I will see the invoice type as selected");
                Entities.Proxy.InvoiceCustomReport RecordsFromDB = DBHelper.GetCustomReportDataBasedOnReport(ScheduledReport);
                int InvoiceType_Id = RecordsFromDB.InvoiceTypeId;
                int CustomReport_ID = RecordsFromDB.InvoiceCustomReportId;

                Entities.Proxy.InvoiceType StatusRecordFrom_DB = DBHelper.GetStatusof_InvoiceType(InvoiceType_Id);
                string StatusFrom_DB = StatusRecordFrom_DB.InvoiceTypeName;

                if (StatusFrom_DB == "Open")
                {
                    Report.WriteLine("Open Invoice type is selected");
                    RadiobuttonChecked(attributeName_xpath, CustomReport_OpenRadioButton_Xpath);
                }
                else if (StatusFrom_DB == "Closed")
                {
                    Report.WriteLine("Closed Invoice type is selected");
                    RadiobuttonChecked(attributeName_xpath, CustomReport_CloseRadioButton_Xpath);

                }
                else
                {
                    Report.WriteLine("All Invocie type is selected");
                    RadiobuttonChecked(attributeName_xpath, CustomReport_AllRadioButton_Xpath);
                }

                Report.WriteLine("I will see the Days Past Due is auto-populated in Days Past Due field");
                string DaysPastDueDate_DB = RecordsFromDB.DaysPastDue.ToString();
                String DaysPastDueDate_UI = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
                Assert.AreEqual(DaysPastDueDate_DB, DaysPastDueDate_UI);

                Report.WriteLine("I will see the Invocie value is auto-populated in Invoice value field");
                string InvoiceValue_DB = RecordsFromDB.InvoiceValue.ToString();
                string InvocieV_UI = GetValue(attributeName_id, InvoiceVal_Id, "value");
                string InvocieVa_UI = InvocieV_UI.TrimStart('$');
                string InvocieValue_UI = InvocieVa_UI.Replace(",", "");
                Assert.AreEqual(InvoiceValue_DB, InvocieValue_UI);

                Report.WriteLine("I will see the DateRange is auto-populated in the Date Range selection");
                string StartDate_DB1 = RecordsFromDB.StartDate.ToString();
                string EndDate_DB1 = RecordsFromDB.EndDate.ToString();

                string[] StatDate_DB_A = StartDate_DB1.Split();
                string StartDate_DB = StatDate_DB_A[0];
                

                string[] EndDate_DB_A = EndDate_DB1.Split();
                string EndDate_DB = EndDate_DB_A[0];
               


                if (StartDate_DB != "")
                {
                    string StartDate_DBMatched = Convert.ToDateTime(StartDate_DB).ToString("MM/dd/yyyy");
                    string EndDate_DBMatched = Convert.ToDateTime(EndDate_DB).ToString("MM/dd/yyyy");

                    string DateRange_UI = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "value");
                    string[] DatRange_UI = DateRange_UI.Split('-');
                    string StartDate_UI = DatRange_UI[0].TrimEnd();
                    string EndDate_UI = DatRange_UI[1].TrimStart();

                    Assert.AreEqual(StartDate_DBMatched, StartDate_UI);
                    Assert.AreEqual(EndDate_DBMatched, EndDate_UI);
                }
                else
                {
                    Report.WriteLine("Date Range is not Present for this Report");
                }


                Report.WriteLine("I will see the Stations is auto-populated in the Stations field");
                //verify with the DB
                List<CustomReportStationMapping> StationId_DB = DBHelper.ToGetStationID(CustomReport_ID);

                List<string> Station_Name_DB = new List<string>();
                Station_Name_DB.Sort();

                int StationIdCount = StationId_DB.Count();
                for (int i = 0; i < StationIdCount; i++)
                {
                    string StationId = StationId_DB[i].StationId.ToString();
                    string StationName_DB = DBHelper.GetStationNameonStationID(StationId);
                    Station_Name_DB.Add(StationName_DB);

                }

                List<string> StationName_UI = new List<string>();
                StationName_UI.Sort();

                //from UI get all stations
                IList<IWebElement> StationNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationNameSelectedAll_Xpath));
                int StationNameList_UICount = StationNameList_UI.Count;
                for (int a = 0; a < StationNameList_UICount; a++)
                {
                    string Staionname_UI = StationNameList_UI[a].Text.ToString();
                    StationName_UI.Add(Staionname_UI);
                }
                CollectionAssert.AreEqual(Station_Name_DB, StationName_UI);


                Report.WriteLine("I will see the Accounts is auto-populated in the Accounts field");
                List<CustomReportCustomerMapping> CustomerSetupId = DBHelper.ToGetCustomerSetupID(CustomReport_ID);
                //List from DB for the Customer Account
                List<string> AccountName_DB = new List<string>();
                AccountName_DB.Sort();

                int AccountSetUpIdCount = CustomerSetupId.Count();
                for (int i = 0; i < AccountSetUpIdCount; i++)
                {
                    int CustomerSetUp_Id = CustomerSetupId[i].CustomerSetupId;
                    string Account_Name_DB = DBHelper.CustomerName(CustomerSetUp_Id);
                    AccountName_DB.Add(Account_Name_DB);

                }

                List<string> AccountName_UI = new List<string>();
                AccountName_UI.Sort();

                //from UI get all stations
                IList<IWebElement> AccountNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CustomerNameSelectedAll_Xpath));
                int AccountNameList_UICount = AccountNameList_UI.Count;
                for (int a = 0; a < AccountNameList_UICount; a++)
                {
                    string Account_Name_UI = AccountNameList_UI[a].Text.ToString();
                    AccountName_UI.Add(Account_Name_UI);
                }
                CollectionAssert.AreEqual(AccountName_DB, AccountName_UI);

                Report.WriteLine("Report Name will be autopopup in the Report name field");
                string ReportNameAutoPopup = GetValue(attributeName_id, CustomReport_ReportName_Input_Id, "value");
                Assert.AreEqual(ScheduledReport, ReportNameAutoPopup);


            }
            else
            {
                Report.WriteLine("Report name displayed on the Custom Report section header");
                string CustomReport1 = Gettext(attributeName_xpath, CustomeReport_CreateCustomReport_Text_Xpath);
                string[] customReport1_1 = CustomReport1.Split('(');
                string custom2 = customReport1_1[1];
                string CustomReportNamefromHeader = custom2.TrimEnd(')');

                Assert.AreEqual(Reportnameselected, CustomReportNamefromHeader);

                Report.WriteLine("I will see the invoice type as selected");
                Entities.Proxy.InvoiceCustomReport RecordsFromDB = DBHelper.GetCustomReportDataBasedOnReport(Reportnameselected);
                int InvoiceType_Id = RecordsFromDB.InvoiceTypeId;
                int CustomReport_ID = RecordsFromDB.InvoiceCustomReportId;

                Entities.Proxy.InvoiceType StatusRecordFrom_DB = DBHelper.GetStatusof_InvoiceType(InvoiceType_Id);
                string StatusFrom_DB = StatusRecordFrom_DB.InvoiceTypeName;

                if (StatusFrom_DB == "Open")
                {
                    Report.WriteLine("Open Invoice type is selected");
                    RadiobuttonChecked(attributeName_xpath, CustomReport_OpenRadioButton_Xpath);
                }
                else if (StatusFrom_DB == "Closed")
                {
                    Report.WriteLine("Closed Invoice type is selected");
                    RadiobuttonChecked(attributeName_xpath, CustomReport_CloseRadioButton_Xpath);

                }
                else
                {
                    Report.WriteLine("All Invocie type is selected");
                    RadiobuttonChecked(attributeName_xpath, CustomReport_AllRadioButton_Xpath);
                }

                Report.WriteLine("I will see the Days Past Due is auto-populated in Days Past Due field");
                string DaysPastDueDate_DB = RecordsFromDB.DaysPastDue.ToString();
                String DaysPastDueDate_UI = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
                Assert.AreEqual(DaysPastDueDate_DB, DaysPastDueDate_UI);

                Report.WriteLine("I will see the Invocie value is auto-populated in Invoice value field");
                string InvoiceValue_DB = RecordsFromDB.InvoiceValue.ToString();
                string InvocieV_UI = GetValue(attributeName_id, InvoiceVal_Id, "value");
                string InvocieVa_UI = InvocieV_UI.TrimStart('$');
                string InvocieValue_UI = InvocieVa_UI.Replace(",", "");
                Assert.AreEqual(InvoiceValue_DB, InvocieValue_UI);

                Report.WriteLine("I will see the DateRange is auto-populated in the Date Range selection");
                string StartDate_DB1 = RecordsFromDB.StartDate.ToString();
                string EndDate_DB1 = RecordsFromDB.EndDate.ToString();

                string[] StatDate_DB_A = StartDate_DB1.Split();
                string StartDate_DB = StatDate_DB_A[0];


                string[] EndDate_DB_A = EndDate_DB1.Split();
                string EndDate_DB = EndDate_DB_A[0];



                if (StartDate_DB != "")
                {
                    string StartDate_DBMatched = Convert.ToDateTime(StartDate_DB).ToString("MM/dd/yyyy");
                    string EndDate_DBMatched = Convert.ToDateTime(EndDate_DB).ToString("MM/dd/yyyy");

                    string DateRange_UI = GetValue(attributeName_id, CustomReport_DateRangePlaceHolder_Id, "value");
                    string[] DatRange_UI = DateRange_UI.Split('-');
                    string StartDate_UI = DatRange_UI[0].TrimEnd();
                    string EndDate_UI = DatRange_UI[1].TrimStart();

                    Assert.AreEqual(StartDate_DBMatched, StartDate_UI);
                    Assert.AreEqual(EndDate_DBMatched, EndDate_UI);
                }
                else
                {
                    Report.WriteLine("Date Range is not Present for this Report");
                }


                Report.WriteLine("I will see the Stations is auto-populated in the Stations field");
                //verify with the DB
                List<CustomReportStationMapping> StationId_DB = DBHelper.ToGetStationID(CustomReport_ID);

                List<string> Station_Name_DB = new List<string>();
                Station_Name_DB.Sort();

                int StationIdCount = StationId_DB.Count();
                for (int i = 0; i < StationIdCount; i++)
                {
                    string StationId = StationId_DB[i].StationId.ToString();
                    string StationName_DB = DBHelper.GetStationNameonStationID(StationId);
                    Station_Name_DB.Add(StationName_DB);

                }

                List<string> StationName_UI = new List<string>();
                StationName_UI.Sort();

                //from UI get all stations
                IList<IWebElement> StationNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationNameSelectedAll_Xpath));
                int StationNameList_UICount = StationNameList_UI.Count;
                for (int a = 0; a < StationNameList_UICount; a++)
                {
                    string Staionname_UI = StationNameList_UI[a].Text.ToString();
                    StationName_UI.Add(Staionname_UI);
                }
                CollectionAssert.AreEqual(Station_Name_DB, StationName_UI);


                Report.WriteLine("I will see the Accounts is auto-populated in the Accounts field");
                List<CustomReportCustomerMapping> CustomerSetupId = DBHelper.ToGetCustomerSetupID(CustomReport_ID);
                //List from DB for the Customer Account
                List<string> AccountName_DB = new List<string>();
                AccountName_DB.Sort();

                int AccountSetUpIdCount = CustomerSetupId.Count();
                for (int i = 0; i < AccountSetUpIdCount; i++)
                {
                    int CustomerSetUp_Id = CustomerSetupId[i].CustomerSetupId;
                    string Account_Name_DB = DBHelper.CustomerName(CustomerSetUp_Id);
                    AccountName_DB.Add(Account_Name_DB);

                }

                List<string> AccountName_UI = new List<string>();
                AccountName_UI.Sort();

                //from UI get all stations
                IList<IWebElement> AccountNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CustomerNameSelectedAll_Xpath));
                int AccountNameList_UICount = AccountNameList_UI.Count;
                for (int a = 0; a < AccountNameList_UICount; a++)
                {
                    string Account_Name_UI = AccountNameList_UI[a].Text.ToString();
                    AccountName_UI.Add(Account_Name_UI);
                }
                CollectionAssert.AreEqual(AccountName_DB, AccountName_UI);

                Report.WriteLine("Report Name will be autopopup in the Report name field");
                string ReportNameAutoPopup = GetValue(attributeName_id, CustomReport_ReportName_Input_Id, "value");
                Assert.AreEqual(Reportnameselected, ReportNameAutoPopup);
            }


        }
        

    }
}
