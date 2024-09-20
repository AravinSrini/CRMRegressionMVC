using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.Quote.Quote_List_InternalUsers
{
    [Binding]
    public class Quote_List__All_Users_Export_OptionSteps : Quotelist
    {

        [When(@"Click on the Export drop down button")]
        public void WhenClickOnTheExportDropDownButton()
        {
            Click(attributeName_xpath, QuoteList_ExportButton_xpath);
        }


        [Then(@"I can see the Options All and Displayed in the Export drop down list")]
        public void ThenICanSeeTheOptionsAllAndDisplayedInTheExportDropDownList()
        {
            var Actual_Export_AllOption = Gettext(attributeName_xpath, QuoteList_Export_AllOption_xpath);
            Assert.AreEqual(Actual_Export_AllOption, "All");

            var Actual_Export_DisplayedOption = Gettext(attributeName_xpath, QuoteList_Export_DisplayedOption_xpath);
            Assert.AreEqual(Actual_Export_DisplayedOption, "Displayed");

        }

        [When(@"I select the (.*) for the Export drop down")]
        public void WhenISelectTheForTheExportDropDown(string ExportOption)
        {

            if (ExportOption == "All")
            {
                Click(attributeName_xpath, QuoteList_Export_AllOption_xpath);
                Thread.Sleep(1000);
            }
            else if (ExportOption == "Displayed")
            {
                Click(attributeName_xpath, QuoteList_Export_DisplayedOption_xpath);
                Thread.Sleep(1000);
            }



        }

        [Then(@"excel sheet column headers should match with UI Columns in the Quote List grid (.*)")]
        public void ThenExcelSheetColumnHeadersShouldMatchWithUIColumnsInTheQuoteListGrid(string UserType)
        {
            Report.WriteLine("clicked on export button");
            string downloadpath = GetDownloadedFilePath("QuoteListExport.xls");
            List<string> columns = Excel_ReadColumnname(downloadpath);


            if (UserType.Equals("ShipEntry") || UserType.Equals("ShipInquiry"))
            {
                List<string> expectedColumnValues = new List<string>(new string[] { "DATE SUBMITTED", "REQUEST NUMBER", "STATUS", "SERVICE", "SERVICE TYPE", "SERVICE LEVEL", "CARRIER NAME", "QUOTE AMOUNT" });

                foreach (var s in columns)
                {
                    if (expectedColumnValues.Contains(s))
                    {
                        Report.WriteLine("Column name " + s + "displaying in exported excel sheet matches with UI column name");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
            else if (UserType.Equals("Operation") || UserType.Equals("Sales") || UserType.Equals("SalesManagement") || UserType.Equals("StationOwner"))
            {
                List<string> expectedColumnValues = new List<string>(new string[] { "DATE SUBMITTED", "Station Name", "Customer Name", "REQUEST NUMBER", "STATUS", "SERVICE", "SERVICE TYPE", "SERVICE LEVEL", "CARRIER NAME", "QUOTE AMOUNT", "EST COST", "EST MARGIN %" });

                foreach (var s in columns)
                {
                    if (expectedColumnValues.Contains(s))
                    {
                        Report.WriteLine("Column name " + s + "displaying in exported excel sheet matches with UI column name");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }

            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;      
            int colCount = xlRange.Columns.Count;

            xlWorkbook.Close(0);
            xlApp.Quit();

            DeleteFilesFromFolder(downloadpath);

        }



        [Then(@"excel sheet count should match with the All UI count of the Quote list grid for the (.*)")]
        public void ThenExcelSheetCountShouldMatchWithTheAllUICountOfTheQuoteListGridForThe(string UserType)
        {
            Report.WriteLine("clicked on export button");
            string downloadpath = GetDownloadedFilePath("QuoteListExport.xls");
           
            Click(attributeName_xpath, ".//*[@id='QuotesGrid_length']/label/select");
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='QuotesGrid_length']/label/select/option"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "ALL")
                {
                    DropDownList[i].Click();
                    break;
                }
            }

            
            List <string> UIvalue = IndividualColumnData(".//*[@id='QuotesGrid']/tbody/tr[@role = 'row']");
            int rowcout = UIvalue.Count;            
            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int rowCounts = rowCount - 1;
           
            int colCount = xlRange.Columns.Count;


            if (rowcout == rowCounts)
            {
                Report.WriteLine("rowCount in UI matches with the Excel sheet Count");
            }
            else
            {
                Assert.Fail();
            }

 
             xlWorkbook.Close(0);
             xlApp.Quit();
          
            DeleteFilesFromFolder(downloadpath);

        }

        [Then(@"excel count should match with the displayed UI count of the Quote list grid for the (.*)")]
        public void ThenExcelCountShouldMatchWithTheDisplayedUICountOfTheQuoteListGridForThe(string UserType)
        {
            Report.WriteLine("clicked on export button");
            string downloadpath = GetDownloadedFilePath("QuoteListExport.xls");

            List<string> UIvalue = IndividualColumnData(".//*[@id='QuotesGrid']/tbody/tr[@role = 'row']");
            int UIrowcout = UIvalue.Count;

            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int ExcelrowCounts = rowCount - 1;            
            int colCount = xlRange.Columns.Count;

            string GridRowCount = Gettext(attributeName_id, "QuotesGrid_info");
            string[] GridRowCountactual = GridRowCount.Split(' ');
            string actualRefno = GridRowCountactual[3];

            

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


            DeleteFilesFromFolder(downloadpath);
        }


    }
}
