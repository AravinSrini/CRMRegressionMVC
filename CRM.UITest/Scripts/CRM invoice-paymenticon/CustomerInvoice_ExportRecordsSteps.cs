using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.CRM_invoice_paymenticon 
{
    [Binding]
    public class CustomerInvoice_ExportRecordsSteps : Customer_Invoice
    {
        GetDownloadPath GetDownloadFolder = new GetDownloadPath();

        [Given(@"I click on the Export drop down")]
        public void GivenIClickOnTheExportDropDown()
        {
            Report.WriteLine("clicking on the Export drop down");
            Click(attributeName_id, customerInvoicesexportbutton_id);
        }
        
        [When(@"I click on the Export drop down arrow")]
        public void WhenIClickOnTheExportDropDownArrow()
        {
            Report.WriteLine("clicking on the Export drop down arrow");
            Click(attributeName_id, customerInvoicesexportbuttonarrow_id);
        }

        [Then(@"I will be displayed the option to select All or Displayed")]
        public void ThenIWillBeDisplayedTheOptionToSelectAllOrDisplayed()
        {
            Report.WriteLine("displayed the option to select All or Displayed");
            var exportdropdownValues = new List<string> { "All", "Displayed" };
            List<string> exportdropdownValuesUI = GetDropdownOptions(attributeName_xpath, customerInvoicesexportdropdownvalues_id, "li");
            CollectionAssert.AreEqual(exportdropdownValues, exportdropdownValuesUI);
        }


        [When(@"I select All option")]
        public void WhenISelectAllOption()
        {
            Report.WriteLine("select All option");
            Click(attributeName_xpath,customerInvoicesexportAll_xpath);
        }
        
        [When(@"I select Displayed option")]
        public void WhenISelectDisplayedOption()
        {
            Report.WriteLine("select displayed option");
            Click(attributeName_xpath, customerInvoicesexportDisplayed_xpath);
        }

        [Then(@"Verify the downloaded export file name(.*)")]
        public void ThenVerifyTheDownloadedExportFileName(string fileName)
        {
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Customer Invoice List Export.xlsx");
            Assert.IsNotNull(downloadPath);
        }

        [Then(@"report(.*) will be generated of all records of the Customer Invoices grid")]
        public void ThenReportWillBeGeneratedOfAllRecordsOfTheCustomerInvoicesGrid(string fileName)
        {
            Report.WriteLine("ReportWillBeGeneratedOfAllRecordsOfTheCustomerInvoicesGrid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\CustomerInvoiceListExport.xls");
            Report.WriteLine("CustomerInvoiceListExport.xls will be in downloaded path");
            List<string> UIvalue = IndividualColumnData(customerInvoicescolumns_xpath);
            int rowCountUi = UIvalue.Count;
            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            int rowCounts = rowCount - 2;
            if (rowCountUi == rowCounts)
            {
                Report.WriteLine("rowCount in UI matches with the Excel sheet rowCount");
            }
            else
            {
                Assert.Fail();
            }

            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
        }

        [Then(@"the customer number and name from the Invoices grid will be displayed in the Customer Number column,Customer Name column seperately on the exported report")]
        public void ThenTheCustomerNumberAndNameFromTheInvoicesGridWillBeDisplayedInTheCustomerNumberColumnCustomerNameColumnSeperatelyOnTheExportedReport()
        {
            Report.WriteLine("the Customer Number from the Customer Invoices grid will be displayed in the Customer Number column on the exported report");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\CustomerInvoiceListExport.xls");
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int i = 0;
            for (int k = 2; k < 3; k++)
            {
                int count = i + 1;
                int l = k + 1;
                string customerExcel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                Assert.AreEqual(customerExcel, "Customer #");
                string customerValExcel = Convert.ToString((xlRange.Cells[l, 3] as Excel.Range).Value2);
                string customerValUi = Gettext(attributeName_xpath, customerValUi_xpath);
                Assert.AreEqual(customerValExcel, customerValUi);

                string customerNameExcel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                Assert.AreEqual(customerNameExcel, "Customer Name");
                string customerNameValExcel = Convert.ToString((xlRange.Cells[l, 4] as Excel.Range).Value2);
                string customerNameValNameUI = Gettext(attributeName_xpath, customerNameValNameUI_xpath);
                Assert.AreEqual(customerNameValExcel, customerNameValNameUI);
                xlWorkbook.Close(0);
                xlApp.Quit();
                xlWorkbook = null;
                xlApp = null;
            }
        }

       
        [Then(@"the remaining all columns will be exported to report(.*) from Customer Invoices grid")]
        public void ThenTheRemainingAllColumnsWillBeExportedToReportFromCustomerInvoicesGrid(string fileName)
        {
            Report.WriteLine("remaining all columns will be exported to report from Customer Invoices grid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\CustomerInvoiceListExport.xls");
            List<string> rowValue = new List<string> { };
            Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int i = 0;
            for (int k = 2; k < 3; k++)
            {
                int count = i + 1;
                int l = k + 1;
                // Verifying Excel content and Grid content for one Account
                string SalesRep_Excel = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                Assert.AreEqual(SalesRep_Excel,"Sales Rep");
                string SalesRepVal_Excel = Convert.ToString((xlRange.Cells[l, 1] as Excel.Range).Value2);
                string SalesRepValUi = Gettext(attributeName_xpath, SalesRepValUi_xpath);
                Assert.AreEqual(SalesRepVal_Excel, SalesRepValUi);

                string Account_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                Assert.AreEqual(Account_Excel, "Account #");
                string AccountVal_Excel = Convert.ToString((xlRange.Cells[l, 2] as Excel.Range).Value2);
                string AccountValUi = Gettext(attributeName_xpath, AccountValUi_xpath);
                Assert.AreEqual(AccountVal_Excel, AccountValUi);

                string InvoiceNumber_Excel = Convert.ToString((xlRange.Cells[k, 5] as Excel.Range).Value2);
                Assert.AreEqual(InvoiceNumber_Excel, "Invoice Number");
                string InvoiceNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 5] as Excel.Range).Value2);
                string InvoiceNumberValUi = Gettext(attributeName_xpath, InvoiceNumberValUi_xpath);
                Assert.AreEqual(AccountVal_Excel, AccountValUi);

                string ReferenceID_Excel = Convert.ToString((xlRange.Cells[k, 6] as Excel.Range).Value2);
                Assert.AreEqual(ReferenceID_Excel, "Reference ID #");
                string ReferenceVal_Excel = Convert.ToString((xlRange.Cells[l, 6] as Excel.Range).Value2);
                string ReferenceValUi = Gettext(attributeName_xpath, ReferenceValUi_xpath);
                Assert.AreEqual(ReferenceVal_Excel, ReferenceValUi);

                string InvoiceDate_Excel = Convert.ToString((xlRange.Cells[k, 7] as Excel.Range).Value2);
                Assert.AreEqual(InvoiceDate_Excel, "Invoice Date");
                string InvoiceDateVal_Excel = Convert.ToString((xlRange.Cells[l, 7] as Excel.Range).Value2);
                string InvoiceDateValUi = Gettext(attributeName_xpath, InvoiceDateValUi_xpath);
                Assert.AreEqual(AccountVal_Excel, AccountValUi);

                string DueDate_Excel = Convert.ToString((xlRange.Cells[k, 8] as Excel.Range).Value2);
                Assert.AreEqual(DueDate_Excel, "Due Date");
                string DueDateVal_Excel = Convert.ToString((xlRange.Cells[l, 8] as Excel.Range).Value2);
                string DueDateValUi = Gettext(attributeName_xpath, DueDateValUi_xpath);
                Assert.AreEqual(DueDateVal_Excel, DueDateValUi);

                string OriginalAmt_Excel = Convert.ToString((xlRange.Cells[k, 9] as Excel.Range).Value2);
                Assert.AreEqual(OriginalAmt_Excel, "Original Amt");
                string OriginalAmtVal_Excel = Convert.ToString((xlRange.Cells[l, 9] as Excel.Range).Value2);
                double OriginalAmtValD_Excel = double.Parse(OriginalAmtVal_Excel.Replace(@"$", ""));
                string OriginalAmtValUi = Gettext(attributeName_xpath, OriginalAmtValUi_xpath);
                double OriginalAmtValDUi = double.Parse(OriginalAmtValUi.Replace(@"$", ""));
                Assert.AreEqual(OriginalAmtValD_Excel, OriginalAmtValDUi);

                string Current_Excel = Convert.ToString((xlRange.Cells[k, 10] as Excel.Range).Value2);
                Assert.AreEqual(Current_Excel, "Current");
                string CurrentVal_Excel = Convert.ToString((xlRange.Cells[l, 10] as Excel.Range).Value2);
                double CurrentValD_Excel = double.Parse(CurrentVal_Excel.Replace(@"$", ""));
                string CurrentValUi = Gettext(attributeName_xpath, CurrentValUi_xpath);
                double CurrentValDUi = double.Parse(CurrentValUi.Replace(@"$", ""));
                Assert.AreEqual(CurrentValD_Excel,CurrentValDUi);


                string DaysPastDue_Excel = Convert.ToString((xlRange.Cells[k, 11] as Excel.Range).Value2);
                Assert.AreEqual(DaysPastDue_Excel, "Days Past Due");
                string DaysPastDueVal_Excel = Convert.ToString((xlRange.Cells[l,11] as Excel.Range).Value2);
                string DaysPastDueValUi = Gettext(attributeName_xpath, DaysPastDueValUi_xpath);
                Assert.AreEqual(DaysPastDueVal_Excel, DaysPastDueValUi);

                string DisputeCode_Excel = Convert.ToString((xlRange.Cells[k, 12] as Excel.Range).Value2);
                Assert.AreEqual(DisputeCode_Excel, "Dispute Code");
                string DisputeCodeVal_Excel = Convert.ToString((xlRange.Cells[l, 12] as Excel.Range).Value2);
                string DisputeCodeValUi = Gettext(attributeName_xpath, DisputeCodeValUi_xpath);
                Assert.AreEqual(DisputeCodeVal_Excel, DisputeCodeValUi);
                i++;

            }
            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
            DeleteFilesFromFolder(downloadPath);
        }

        [Then(@"report(.*) will be generated of displayed records of the Customer Invoices grid")]
        public void ThenReportWillBeGeneratedOfDisplayedRecordsOfTheCustomerInvoicesGrid(string fileName)
        {
            Report.WriteLine("report will be generated of displayed records of the Customer Invoices grid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\CustomerInvoiceListExport.xls");
            List<string> UIvalue = IndividualColumnData(customerInvoicescolumns_xpath);
            int UIrowcout = UIvalue.Count;
            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadPath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int ExcelrowCounts = rowCount - 2;
            if (ExcelrowCounts == UIrowcout)
            {
                Report.WriteLine("rowCount in UI matches with the Excel sheet Count");
            }
            else
            {
                Assert.Fail();
            }
            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
        }
    }
}
