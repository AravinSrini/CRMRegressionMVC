using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.Shipment.ShipmentList.ShipmentList_ExportOption_AllUsers
{
    [Binding]
    public sealed class ShipmentList_ExportOption_AllUsersSteps : Shipmentlist
    {

        [When(@"I click on the Export dropdown button")]
        public void WhenIClickOnTheExportDropdownButton()
        {
            Report.WriteLine("I click on the Exoprt dropdown button");
            Click(attributeName_id, ShipmentList_ExportButton_Id);
            Thread.Sleep(2000);
           
        }

        [Then(@"I will see the Options All and Displayed in the Export drop down list")]
        public void ThenIWillSeeTheOptionsAllAndDisplayedInTheExportDropDownList()
        {
            Report.WriteLine("Verified Export having the All option");
            VerifyElementPresent(attributeName_xpath, ShipmentList_ExportOption_All_Xpath, "All");
            Report.WriteLine("Verified Export having the Displayed option");
            VerifyElementPresent(attributeName_xpath, ShipmentList_ExportOption_Displayed_Xpath, "Displayed");
        }

        [When(@"I select the (.*) for the Export drop down in Shipment list page")]
        public void WhenISelectTheForTheExportDropDownInShipmentListPage(string ExportOption)
        {
            if (ExportOption == "All")
            {
                Click(attributeName_xpath, ShipmentList_ExportOption_All_Xpath);
                Thread.Sleep(2000);
            }
            else if (ExportOption == "Displayed")
            {
                Click(attributeName_xpath, ShipmentList_ExportOption_Displayed_Xpath);
                Thread.Sleep(2000);
            }
        }

        [Then(@"Excel sheet column headers should match with UI Columns in the Shipment List grid (.*)")]
        public void ThenExcelSheetColumnHeadersShouldMatchWithUIColumnsInTheShipmentListGrid(string UserType)
        {
            Report.WriteLine("clicked on export button");
            string downloadpath = GetDownloadedFilePath("ShipmentListExport.xls");
            List<string> columns = Excel_ReadColumnname(downloadpath);
            


            if (UserType.Equals("ShipEntry") || UserType.Equals("ShipInquiry") || UserType.Equals("ShipEntryNoRates") || UserType.Equals("ShipInquiryNoRates"))
            {
                List<string> expectedColumnValues = new List<string>(new string[] { "ReferenceNumber", "ReferenceCategory", "PONumber", "Service", "Status", "Pickup", "Delivery", "Origin", "Destination", "Quantity", "ServiceType", "ServiceLevel", "Weight", "ShipmentCharge", "Carrier", "Container #" });

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
                List<string> expectedColumnValues = new List<string>(new string[] { "ReferenceNumber", "Station Name", "Customer Name", "ReferenceCategory", "PONumber", "Service", "Status", "Pickup", "Delivery", "Origin", "Destination", "Quantity", "ServiceType", "ServiceLevel", "Weight", "Est Revenue", "Est Cost", "Est Margin %", "Carrier", "Container #" });

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

        [Then(@"Excel sheet count should match with the All UI count of the Shipment list grid for the (.*)")]
        public void ThenExcelSheetCountShouldMatchWithTheAllUICountOfTheShipmentListGridForThe(string UserType)
        {
            Report.WriteLine("clicked on export button");
            string downloadpath = GetDownloadedFilePath("ShipmentListExport.xls");

            Click(attributeName_xpath, ".//*[@id='ShipmentGrid_length']/label/select");
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ShipmentGrid_length']/label/select/option"));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "ALL")
                {
                    DropDownList[i].Click();
                    break;
                }
            }


            List<string> UIvalue = IndividualColumnData(".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']");
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


        [Then(@"Excel count should match with the displayed UI count of the Shipment list grid for the (.*)")]
        public void ThenExcelCountShouldMatchWithTheDisplayedUICountOfTheShipmentListGridForThe(string UserType)
        {
            Report.WriteLine("clicked on export button");
            string downloadpath = GetDownloadedFilePath("ShipmentListExport.xls");

            List<string> UIvalue = IndividualColumnData(".//*[@id='ShipmentGrid']/tbody/tr[@role = 'row']");
            int UIrowcout = UIvalue.Count;

            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int ExcelrowCounts = rowCount - 1;
            int colCount = xlRange.Columns.Count;

            string GridRowCount = Gettext(attributeName_id, "ShipmentGrid_info");
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

