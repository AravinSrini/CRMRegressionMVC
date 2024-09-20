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
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class Customer_Invoice___Custom_Report___Preview_Run_Now_ButtonSteps : Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public string username;
        public string password;
        public string Reportnameselected;
        string ReportName = Guid.NewGuid().ToString() + "CustomRprtTst";

        public string EnterDaysPastDue = "80";
        public string EnterInvoiceSign = null;
        public int EnterInvoiceValue = 1099;
        public string EnterInvoiceDateRange = null;
        public string EnterStationName = "ZZZ - Web Services Test";
        public string EnterCustomerName = "ZZZ - Czar Customer Test";
        public string EnterReportName = "CreateCustomReportPreviewRunCheck";
        public string CustomReportName = "AllAccountsReport1";

        [Given(@"I am shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner, or access rrd user")]
        public void GivenIAmShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerOrAccessRrdUser()
        {
            username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();


            //username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            //password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);



        }

        [Given(@"I click on the Custom Report list drop down and Select Existing Custom Report from the list")]
        public void GivenIClickOnTheCustomReportListDropDownAndSelectExistingCustomReportFromTheList()
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


        


        //[Given(@"I expanded the Create Custom Report section")]
        //public void GivenIExpandedTheCreateCustomReportSection()
        //{
        //    Report.WriteLine("expanding the Create Custom Report section");
        //    Click(attributeName_id, createCustomReportsectionExpandArrow_id);
        //}


        [Given(@"I verify data is autopopulated in the Create Custom Section for the selected Report name")]
        public void GivenIVerifyDataIsAutopopulatedInTheCreateCustomSectionForTheSelectedReportName()
        {
            if (Reportnameselected.Contains("Scheduled"))
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
                    IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomReport_OpenRadioButton_Xpath));
                    if (am.Selected)
                    {
                        Report.WriteLine("Radio button is selected defaultly");
                    }
                    else
                    {
                        Report.WriteFailure("Radio button is not selected defaultly");
                    }

                    
                }
                else if (StatusFrom_DB == "Closed")
                {
                    IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomReport_CloseRadioButton_Xpath));
                    if (am.Selected)
                    {
                        Report.WriteLine("Radio button is selected defaultly");
                    }
                    else
                    {
                        Report.WriteFailure("Radio button is not selected defaultly");
                    }
                    

                }
                else
                {
                    Report.WriteLine("All Invocie type is selected");
                    IWebElement am = GlobalVariables.webDriver.FindElement(By.XPath(CustomReport_AllRadioButton_Xpath));
                    if (am.Selected)
                    {
                        Report.WriteLine("Radio button is selected defaultly");
                    }
                    else
                    {
                        Report.WriteFailure("Radio button is not selected defaultly");
                    }
                    
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
                if (InvoiceValue_DB == "")
                {
                    Assert.AreEqual(InvoiceValue_DB, InvocieV_UI);
                }
                else
                {

                    string InvocieVa_UI = InvocieV_UI.TrimStart('$');
                    string InvocieValue_UI = InvocieVa_UI.Replace(",", "");

                    Assert.AreEqual(InvoiceValue_DB, InvocieValue_UI);
                }

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


        [Then(@"the invoice grid will refresh and display the results of the report based on the selected Custom Report section")]
        public void ThenTheInvoiceGridWillRefreshAndDisplayTheResultsOfTheReportBasedOnTheSelectedCustomReportSection()
        {
            if (Reportnameselected.Contains("Scheduled"))
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


                }
                else if (StatusFrom_DB == "Closed")
                {
                    Report.WriteLine("Closed Invoice type is selected");
                    Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
                }
                else
                {
                    Report.WriteLine("All Invocie type is selected");
                    Click(attributeName_xpath, CustomerInvoices_FilterList_All_Xpath);
                }

                Thread.Sleep(3000);

                //station list from create custom report section
                List<string> StationName_UI = new List<string>();
                
                IList<IWebElement> StationNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationNameSelectedAll_Xpath));
                int StationNameList_UICount = StationNameList_UI.Count;
                for (int a = 0; a < StationNameList_UICount; a++)
                {
                    string Staionname_UI = StationNameList_UI[a].Text.ToString();
                    StationName_UI.Add(Staionname_UI);
                }

                StationName_UI.Sort();

                //accounts list from create custom report section
                List<string> AccountName_UI = new List<string>();
                

                IList<IWebElement> AccountNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CustomerNameSelectedAll_Xpath));
                int AccountNameList_UICount = AccountNameList_UI.Count;
                for (int a = 0; a < AccountNameList_UICount; a++)
                {
                    string Account_Name_UI = AccountNameList_UI[a].Text.ToString();
                    AccountName_UI.Add(Account_Name_UI);
                }
                AccountName_UI.Sort();

               
                //station and customer list from invoice grid
                List<string> StationNameGrid = new List<string>();
                List<string> CustomerNameGrid = new List<string>();

                Click(attributeName_xpath, ".//*[@class='dataTables_length']/label/select");
                SelectDropdownlistvalue(attributeName_xpath, ".//*[@class='table-header-row']//label/select/option", "ALL");

                string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
                int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
                if ((row >= 1) && (NoRecordFound != "No Results Found"))
                {

                    IList<IWebElement> stationColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_Station_All_xpath));
                    int StationNameList_UICount1 = stationColumn_InitialValues.Count;

                    for (int i = 0; i < StationNameList_UICount1; i++)
                    {
                        string Staionname_UI = stationColumn_InitialValues[i].Text.ToString();
                        StationNameGrid.Add(Staionname_UI);
                    }

                    for(int stationUI=0;stationUI< StationNameList_UICount; stationUI++)
                    {
                        for(int stationGrid=0; stationGrid< StationNameList_UICount1; stationGrid++)
                        {
                            if (StationNameGrid[stationGrid].Contains(StationName_UI[stationUI]))
                            {
                                Report.WriteLine("Station Name in grid is diplayed for the associated user");
                            }
                            else
                            {
                                Report.WriteLine("Station Name in grid is diplayed is not for the associated user");
                                Assert.Fail();
                            }
                        }
                    }


                    IList<IWebElement> CustomerNameColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_CustomerName_All_xpath));
                    int CustomerNameList_UICount1 = stationColumn_InitialValues.Count;

                    for (int i = 0; i < CustomerNameList_UICount1; i++)
                    {
                        string Customer_UI = CustomerNameColumn_InitialValues[i].Text.ToString();
                        CustomerNameGrid.Add(Customer_UI);
                    }

                    for (int customerUI = 0; customerUI < AccountNameList_UICount; customerUI++)
                    {
                        for (int customerGrid = 0; customerGrid < CustomerNameList_UICount1; customerGrid++)
                        {
                            if (CustomerNameGrid[customerGrid].Contains(AccountName_UI[customerUI]))
                            {
                                Report.WriteLine("Station Name in grid is diplayed for the associated user");
                            }
                            else
                            {
                                Report.WriteLine("Station Name in grid diplayed is not for the associated user");
                                Assert.Fail();
                            }
                        }
                    }



                }
                    
                    else
                    {
                        Report.WriteLine("No record found");
                    }

            }else
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


                }
                else if (StatusFrom_DB == "Closed")
                {
                    Report.WriteLine("Closed Invoice type is selected");
                    Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
                }
                else
                {
                    Report.WriteLine("All Invocie type is selected");
                    Click(attributeName_xpath, CustomerInvoices_FilterList_All_Xpath);
                }

                //station list from create custom report section
                List<string> StationName_UI = new List<string>();

                IList<IWebElement> StationNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_StationNameSelectedAll_Xpath));
                int StationNameList_UICount = StationNameList_UI.Count;
                for (int a = 0; a < StationNameList_UICount; a++)
                {
                    string Staionname_UI = StationNameList_UI[a].Text.ToString();
                    StationName_UI.Add(Staionname_UI);
                }

                StationName_UI.Sort();

                //accounts list from create custom report section
                List<string> AccountName_UI = new List<string>();

                IList<IWebElement> AccountNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CustomerNameSelectedAll_Xpath));
                int AccountNameList_UICount = AccountNameList_UI.Count;
                for (int a = 0; a < AccountNameList_UICount; a++)
                {
                    string Account_Name_UI = AccountNameList_UI[a].Text.ToString();
                    AccountName_UI.Add(Account_Name_UI);
                }
                AccountName_UI.Sort();

                //station and customer list from invoice grid
                List<string> StationNameGrid = new List<string>();
                List<string> CustomerNameGrid = new List<string>();

                Click(attributeName_xpath, CustomerInvoices_GridTop_Clik_View_Xpath);
                SelectDropdownlistvalue(attributeName_xpath, CustomerInvoices_GridTop_Options_Xpath, "ALL");

                string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
                int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
                if ((row >= 1) && (NoRecordFound != "No Results Found"))
                {

                    IList<IWebElement> stationColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_Station_All_xpath));
                    int StationNameList_UICount1 = stationColumn_InitialValues.Count;

                    for (int i = 0; i < StationNameList_UICount1; i++)
                    {
                        string Staionname_UI = stationColumn_InitialValues[i].Text.ToString();
                        StationNameGrid.Add(Staionname_UI);
                    }

                    for (int stationUI = 0; stationUI < StationNameList_UICount; stationUI++)
                    {
                        for (int stationGrid = 0; stationGrid < StationNameList_UICount1; stationGrid++)
                        {
                            if (StationNameGrid[stationGrid].Contains(StationName_UI[stationUI]))
                            {
                                Report.WriteLine("Station Name in grid is diplayed for the associated user");
                            }
                            else
                            {
                                Report.WriteLine("Station Name in grid is diplayed is not for the associated user");
                                Assert.Fail();
                            }
                        }
                    }


                    IList<IWebElement> CustomerNameColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_CustomerName_All_xpath));
                    int CustomerNameList_UICount1 = stationColumn_InitialValues.Count;

                    for (int i = 0; i < CustomerNameList_UICount1; i++)
                    {
                        string Customer_UI = CustomerNameColumn_InitialValues[i].Text.ToString();
                        CustomerNameGrid.Add(Customer_UI);
                    }

                    for (int customerUI = 0; customerUI < AccountNameList_UICount; customerUI++)
                    {
                        for (int customerGrid = 0; customerGrid < CustomerNameList_UICount1; customerGrid++)
                        {
                            if (CustomerNameGrid[customerGrid].Contains(AccountName_UI[customerUI]))
                            {
                                Report.WriteLine("Station Name in grid is diplayed for the associated user");
                            }
                            else
                            {
                                Report.WriteLine("Station Name in grid is diplayed is not for the associated user");
                                Assert.Fail();
                            }
                        }
                    }



                }

                else
                {
                    Report.WriteLine("No record found");
                }
            }
            
        }

       

        [When(@"I click on the Preview/Run Now button")]
        public void WhenIClickOnThePreviewRunNowButton()
        {
           
            Report.WriteLine("Click on the Preview Run Now button");
            Click(attributeName_id, CustomReport_Preview_Run_Button_Id);
        }

        [Then(@"the invoice grid will refresh and display the results of the report based on the values entered in the Create Custom Report section")]
        public void ThenTheInvoiceGridWillRefreshAndDisplayTheResultsOfTheReportBasedOnTheValuesEnteredInTheCreateCustomReportSection()
        {
            Thread.Sleep(2000);
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> CustomerNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath("//div/table[@role='grid']/tbody//td[4]"));
                if (CustomerNumberColumn_InitialValues.Count > 0)
                {
                    for (int i = 1; i <= CustomerNumberColumn_InitialValues.Count; i++)

                    {
                        String getAccountName = Gettext(attributeName_xpath, "//div/table[@role='grid']/tbody/tr[" + i + "]/td[4]/span[2]");
                        string getStationName = Gettext(attributeName_xpath, "//div/table[@role='grid']/tbody/tr[" + i + "]/td[3]/span");
                        string getInvoiceAmount = Gettext(attributeName_xpath, "//div/table[@role='grid']/tbody/tr[" + i + "]/td[9]");
                        string getDaysPastDue = Gettext(attributeName_xpath, "//div/table[@role='grid']/tbody/tr[" + i + "]/td[11]");

                        double OriginalAmtValD_Excel = double.Parse(getInvoiceAmount.Replace(@"$", ""));

                        Assert.AreEqual(EnterStationName, getStationName);
                        Assert.AreEqual(EnterCustomerName, getAccountName);
                        Assert.AreEqual(getDaysPastDue, EnterDaysPastDue);
                        if (OriginalAmtValD_Excel > EnterInvoiceValue)
                        {
                            Report.WriteLine("Invoive/Originla Amount is greater than the entered  value");
                        }else if (OriginalAmtValD_Excel< EnterInvoiceValue)
                        {
                            Report.WriteLine("Invoive/Originla Amount is greater than the entered  value");
                        }else
                        {
                            Assert.Fail();
                        }

                    }
                }
                else
                {
                    Report.WriteLine("No Records found");
                }
            }else
            {
                Report.WriteLine("No Records found in the grid");
            }
        }


        [Given(@"I entered all required information for a custom report")]
        public void GivenIEnteredAllRequiredInformationForACustomReport()
        {

            IList<IWebElement> StationNameList_UI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportStations_chosen']/ul/li/span"));
            int StationNameList_UICount = StationNameList_UI.Count;


            if (StationNameList_UICount > 0)
            {
                Report.WriteLine("station name is default selected");
                VerifyElementPresent(attributeName_xpath, ".//*[@id='ReportStations_chosen']//li[1]/span", "DefaultStationSelectedName");
                
            }
            else
            {
                
                Click(attributeName_xpath, CustomReport_Station_xpath);
                SelectDropdownValueFromList(attributeName_xpath, CustomReport_StationSelectionValues_xpath, "ZZZ - Web Services Test");
               
            }



            SendKeys(attributeName_id, CustomReportDaysPastDueField_Id, EnterDaysPastDue);
            SendKeys(attributeName_id, CustomReport_InvoiceValue_Input_Id, EnterInvoiceValue.ToString());
            Click(attributeName_xpath, CustomReport_Accounts_xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_AccountSelectionValues_xpath, EnterCustomerName);
            SendKeys(attributeName_id, CustomReportReportName_Id, ReportName);

            //Click(attributeName_id, CustomReport_DateRangePlaceHolder_Id);
            //SendKeys(attributeName_name, CustomReport_DateRangeStartDate_Name, "03/01/2018");
            //SendKeys(attributeName_name, CustomReport_DateRangeEndDate_Name, "04/01/2018");


        }


        [When(@"I click on the Preview/Run Now button without entering data for all required fields in the custom report section")]
        public void WhenIClickOnThePreviewRunNowButtonWithoutEnteringDataForAllRequiredFieldsInTheCustomReportSection()
        {
            Report.WriteLine("Click on the Preview Run Now button");
            Click(attributeName_id, CustomReport_Preview_Run_Button_Id);
        }



        [Then(@"I should see the message as '(.*)'")]
        public void ThenIShouldSeeTheMessageAs(string p0)
        {
            string ExpectedErrorMsg = "Please enter all required information";
            string ActualErrorMsg = Gettext(attributeName_id, CustomReportRequiredFieldValidationMsg_Id);
            Assert.AreEqual(ExpectedErrorMsg, ActualErrorMsg);
        }


        [Then(@"the required missing data fields should be highlighted")]
        public void ThenTheRequiredMissingDataFieldsShouldBeHighlighted()
        {
           
            var colorofHighlighted_account = GetCSSValue(attributeName_xpath, CustomReportAccountsfield_xpath, "background-color");
            Assert.AreEqual("rgba(251, 236, 236, 1)", colorofHighlighted_account);

            var colorofHighlighted_reportname = GetCSSValue(attributeName_id, CustomReportReportName_Id, "background-color");
            Assert.AreEqual("rgba(251, 236, 236, 1)", colorofHighlighted_reportname);

        }






    }
}
