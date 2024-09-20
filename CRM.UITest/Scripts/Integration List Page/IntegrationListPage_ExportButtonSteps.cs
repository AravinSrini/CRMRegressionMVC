using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;
namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationListPage_ExportButtonSteps : Integration
    {
        [Then(@"I click on the Export button available")]
        public void ThenIClickOnTheExportButtonAvailable()
        {
            Click(attributeName_id, IntegrationExportButton);
        }

        [Then(@"I click on the Export button avaialble")]
        public void ThenIClickOnTheExportButtonAvaialble()
        {

           
                
                Click(attributeName_id, IntegrationExportButton);
                
            
            
        }

        [Then(@"I will be able to see Export button in Integration List Page")]
        public void ThenIWillBeAbleToSeeExportButtonInIntegrationListPage()
        {
            Report.WriteLine("Export button in Integration List Page should be available");
            VerifyElementPresent(attributeName_id, IntegrationExportButton, "Export");

        }

        [Then(@"Verify the downloaded excel file name(.*)")]
        public void ThenVerifyTheDownloadedExcelFileName(string Filename)
        {
            Report.WriteLine("clicked on export button");

            string downloadpath = GetDownloadedFilePath(Filename);
        }

        [Then(@"Verify the data available matching in the Excel(.*)matching with the UI for Admin User for InProgress status(.*)")]
        public void ThenVerifyTheDataAvailableMatchingInTheExcelMatchingWithTheUIForAdminUserForInProgressStatus(string FileName,string expectedStatus)
        {
            Thread.Sleep(2000);
            string downloadpath = GetDownloadedFilePath(FileName);

            // List<string> UIvalue = IndividualColumnData("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr");

            List<string> columns = Excel_ReadColumnname(downloadpath);

            List<string> expectedColumnValues = new List<string>(new string[] { "Station", "Company Name", "Contact Name", "Contact Email", "Contact Phone", "It/developer contact name", "IT/developer email", "IT/developer phone", "Start date", "Type of Integration", "Year to Date shipments", "Year to Date Revenue", "Potential Revenue", "Additional Comments", "Status", "MG/CSA Total Hours", "Integration Team Total Hours" });

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

            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            int i = 0;
            for (int k = 2; k < 3; k++)
            {
                int count = i + 1;
                // Verifying Excel content and Grid content for one Account
                string _Station_Excel = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                string _Station_UI = Gettext(attributeName_xpath, IntegrationStationName);
                Assert.AreEqual(_Station_Excel, _Station_UI);

                //string StartDate_Excel = Convert.ToDateTime((xlRange.Cells[k, 9] as Excel.Range).Value2).ToString("dd/MM/yyyy"); ;
                //string _StartDate__DB = Entities.DBHelper.GetIntegrationRequestStartDate().ToString("dd/MM/yyyy");
                //Assert.AreEqual(StartDate_Excel, _StartDate__DB);

                string _CompanyName_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                string _CompanyName_UI = Gettext(attributeName_xpath, IntegrationCompanyName);
                Assert.AreEqual(_CompanyName_Excel, _CompanyName_UI);

                Click(attributeName_xpath, IntegrationExpanbutton);

                string _CompanyContactName_Excel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                string _CompanyContactName_UI = GetValue(attributeName_id, IntegrationCompanyContactName, "value");
                Assert.AreEqual(_CompanyContactName_Excel, _CompanyContactName_UI);

                string _ContactEmail_Excel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                string _ContactEmail_UI = GetValue(attributeName_id, IntegrationCompanyContactEmail, "value");
                Assert.AreEqual(_ContactEmail_Excel, _ContactEmail_UI);

                string _ContactPhone_Excel = Convert.ToString((xlRange.Cells[k, 5] as Excel.Range).Value2);
                string _ContactPhone_UI = GetValue(attributeName_id, IntegrationCompanyContactPhone, "value");
                Assert.AreEqual(_ContactPhone_Excel, _ContactPhone_UI);

                string _It_DeveloperContactName_Excel = Convert.ToString((xlRange.Cells[k, 6] as Excel.Range).Value2);
                string _It_DeveloperContactName__UI = GetValue(attributeName_id, IntegrationItDeveloperContactName, "value");
                Assert.AreEqual(_It_DeveloperContactName_Excel, _It_DeveloperContactName__UI);

                string _It_DeveloperContactEmail_Excel = Convert.ToString((xlRange.Cells[k, 7] as Excel.Range).Value2);
                string _It_DeveloperContactEmail__UI = GetValue(attributeName_id, IntegrationItDeveloperContactEmail, "value");
                Assert.AreEqual(_It_DeveloperContactEmail_Excel, _It_DeveloperContactEmail__UI);

                string _It_DeveloperContactPhone_Excel = Convert.ToString((xlRange.Cells[k, 8] as Excel.Range).Value2);
                string _It_DeveloperContactPhone__UI = GetValue(attributeName_id, IntegrationItDeveloperContactPhone, "value");
                Assert.AreEqual(_It_DeveloperContactPhone_Excel, _It_DeveloperContactPhone__UI);


                string StartDate_Excel = Convert.ToString((xlRange.Cells[k, 9] as Excel.Range).Value2);
                string _StartDate__DB = Entities.DBHelper.GetIntegrationRequestStartDate().ToString("yyyy-MM-dd");
                Assert.AreEqual(StartDate_Excel, _StartDate__DB);

                string _TypeOfIntegration_Excel = Convert.ToString((xlRange.Cells[k, 10] as Excel.Range).Value2);
                string uiTypeOfIntegration = _TypeOfIntegration_Excel == string.Empty ? "N/A" : _TypeOfIntegration_Excel;
                Assert.AreEqual(_TypeOfIntegration_Excel, uiTypeOfIntegration);


                string _YearToDateShipments_Excel = Convert.ToString((xlRange.Cells[k, 11] as Excel.Range).Value2);
                string _YearToDateShipments__UI = GetValue(attributeName_id, IntegrationYearToDateShipments, "value");
                Assert.AreEqual(_YearToDateShipments_Excel, _YearToDateShipments__UI);


                string _YearToDateRevenue_Excel = Convert.ToString((xlRange.Cells[k, 12] as Excel.Range).Value2);


                decimal dateRevenuExcel = 0.0M;
                decimal.TryParse(_YearToDateRevenue_Excel, out dateRevenuExcel);
                var dateRevenuExcelValue = dateRevenuExcel.ToString("$#,##0");
                string _YearToDateRevenue__UI = GetValue(attributeName_id, IntegrationYearToDateRevenue, "value");
                Assert.AreEqual(dateRevenuExcelValue, _YearToDateRevenue__UI);

                string _PotentialRevenue_Excel = Convert.ToString((xlRange.Cells[k, 13] as Excel.Range).Value2);
                string _PotentialRevenue__UI = GetValue(attributeName_id, IntegrationPotentialRevenue, "value");

                decimal potentialRevenueExcel = 0.0M;
                decimal.TryParse(_PotentialRevenue_Excel, out potentialRevenueExcel);
                var potentialRevenueExcelValue = potentialRevenueExcel.ToString("$#,##0");
                Assert.AreEqual(potentialRevenueExcelValue, _PotentialRevenue__UI);

                string _AdditionalComments_Excel = Convert.ToString((xlRange.Cells[k, 14] as Excel.Range).Value2).Trim();
                string _AdditionalComments__UI = GetValue(attributeName_id, IntegrationAdditionalComments, "value").Trim();
                string uiAdditionalCom = _AdditionalComments__UI == string.Empty ? "N/A" : _AdditionalComments__UI;

                Assert.AreEqual(_AdditionalComments_Excel, _AdditionalComments__UI);

                string _Status_Excel = Convert.ToString((xlRange.Cells[k, 15] as Excel.Range).Value2);
                string expectedUIStatus = expectedStatus == string.Empty ? "N/A" : expectedStatus;

                Assert.AreEqual(_Status_Excel, expectedUIStatus);

                string _MGandCSAHour_Excel = Convert.ToString((xlRange.Cells[k, 16] as Excel.Range).Value2);
                string _MGandCSAHour__UI = GetValue(attributeName_id, IntegrationMGandCSAHour, "value");
                string uiMgAndCsrHour = _MGandCSAHour__UI == string.Empty ? "N/A" : _MGandCSAHour__UI;
                Assert.AreEqual(_MGandCSAHour_Excel, uiMgAndCsrHour);

                string _IntegrationTeamTotalHours_Excel = Convert.ToString((xlRange.Cells[k, 17] as Excel.Range).Value2);
                string _IntegrationTeamTotalHours__UI = GetValue(attributeName_id, IntegrationTeamTotalHours, "value");
                string uiIntegrationTeamTotalHours = _IntegrationTeamTotalHours__UI == string.Empty ? "N/A" : _IntegrationTeamTotalHours__UI;

                Assert.AreEqual(_IntegrationTeamTotalHours_Excel, uiIntegrationTeamTotalHours);







                i++;

            }
            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
            DeleteFilesFromFolder(downloadpath);
        }


        [Then(@"Verify the data available matching in the Excel(.*)matching with the UI for the Station User for InProgress status(.*)")]
        public void ThenVerifyTheDataAvailableMatchingInTheExcelMatchingWithTheUIForTheStationUserForInProgressStatus(string FileName,string expectedStatus)
        {

            string downloadpath = GetDownloadedFilePath(FileName);

            // List<string> UIvalue = IndividualColumnData("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr");

            List<string> columns = Excel_ReadColumnname(downloadpath);

            List<string> expectedColumnValues = new List<string>(new string[] { "Station", "Company Name", "Contact Name", "Contact Email", "Contact Phone", "It/developer contact name", "IT/developer email", "IT/developer phone", "Start date", "Type of Integration", "Year to Date shipments", "Year to Date Revenue", "Potential Revenue", "Additional Comments", "Status" });

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

            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            int i = 0;
            for (int k = 2; k < 3; k++)
            {
                int count = i + 1;
                // Verifying Excel content and Grid content for one Account
                string _Station_Excel = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                string _Station_UI = Gettext(attributeName_xpath, IntegrationStationName);
                Assert.AreEqual(_Station_Excel, _Station_UI);

                string StartDate_Excel = Convert.ToDateTime((xlRange.Cells[k, 9] as Excel.Range).Value2).ToString("dd/MM/yyyy"); ;
                string _StartDate__DB = Entities.DBHelper.GetIntegrationRequestStartDate().ToString("dd/MM/yyyy");
                Assert.AreEqual(StartDate_Excel, _StartDate__DB);

                string _CompanyName_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                string _CompanyName_UI = Gettext(attributeName_xpath, IntegrationCompanyName);
                Assert.AreEqual(_CompanyName_Excel, _CompanyName_UI);

                Click(attributeName_xpath, IntegrationExpanbutton);
                string _CompanyContactName_Excel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                string _CompanyContactName_UI = GetValue(attributeName_id, IntegrationCompanyContactName, "value");
                Assert.AreEqual(_CompanyContactName_Excel, _CompanyContactName_UI);

                string _ContactEmail_Excel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                string _ContactEmail_UI = GetValue(attributeName_id, IntegrationCompanyContactEmail, "value");
                Assert.AreEqual(_ContactEmail_Excel, _ContactEmail_UI);

                string _ContactPhone_Excel = Convert.ToString((xlRange.Cells[k, 5] as Excel.Range).Value2);
                string _ContactPhone_UI = GetValue(attributeName_id, IntegrationCompanyContactPhone, "value");
                Assert.AreEqual(_ContactPhone_Excel, _ContactPhone_UI);

                string _It_DeveloperContactName_Excel = Convert.ToString((xlRange.Cells[k, 6] as Excel.Range).Value2);
                string _It_DeveloperContactName__UI = GetValue(attributeName_id, IntegrationItDeveloperContactName, "value");
                Assert.AreEqual(_It_DeveloperContactName_Excel, _It_DeveloperContactName__UI);

                string _It_DeveloperContactEmail_Excel = Convert.ToString((xlRange.Cells[k, 7] as Excel.Range).Value2);
                string _It_DeveloperContactEmail__UI = GetValue(attributeName_id, IntegrationItDeveloperContactEmail, "value");
                Assert.AreEqual(_It_DeveloperContactEmail_Excel, _It_DeveloperContactEmail__UI);

                string _It_DeveloperContactPhone_Excel = Convert.ToString((xlRange.Cells[k, 8] as Excel.Range).Value2);
                string _It_DeveloperContactPhone__UI = GetValue(attributeName_id, IntegrationItDeveloperContactPhone, "value");
                Assert.AreEqual(_It_DeveloperContactPhone_Excel, _It_DeveloperContactPhone__UI);

                string _TypeOfIntegration_Excel = Convert.ToString((xlRange.Cells[k, 10] as Excel.Range).Value2);
                string uiTypeOfIntegration = _TypeOfIntegration_Excel == string.Empty ? "N/A" : _TypeOfIntegration_Excel;
                    Assert.AreEqual(_TypeOfIntegration_Excel, uiTypeOfIntegration);
                

                string _YearToDateShipments_Excel = Convert.ToString((xlRange.Cells[k, 11] as Excel.Range).Value2);
                string _YearToDateShipments__UI = GetValue(attributeName_id, IntegrationYearToDateShipments, "value");
                Assert.AreEqual(_YearToDateShipments_Excel, _YearToDateShipments__UI);


                string _YearToDateRevenue_Excel = Convert.ToString((xlRange.Cells[k, 12] as Excel.Range).Value2);


                decimal dateRevenuExcel = 0.0M;
                decimal.TryParse(_YearToDateRevenue_Excel, out dateRevenuExcel);
                var dateRevenuExcelValue = dateRevenuExcel.ToString("$#,##0");
                string _YearToDateRevenue__UI = GetValue(attributeName_id, IntegrationYearToDateRevenue, "value");
                Assert.AreEqual(dateRevenuExcelValue, _YearToDateRevenue__UI);

                string _PotentialRevenue_Excel = Convert.ToString((xlRange.Cells[k, 13] as Excel.Range).Value2);
                string _PotentialRevenue__UI = GetValue(attributeName_id, IntegrationPotentialRevenue, "value");

                decimal potentialRevenueExcel = 0.0M;
                decimal.TryParse(_PotentialRevenue_Excel, out potentialRevenueExcel);
                var potentialRevenueExcelValue = potentialRevenueExcel.ToString("$#,##0");
                Assert.AreEqual(potentialRevenueExcelValue, _PotentialRevenue__UI);

                string _AdditionalComments_Excel = Convert.ToString((xlRange.Cells[k, 14] as Excel.Range).Value2);
                string _AdditionalComments__UI = GetValue(attributeName_id, IntegrationAdditionalComments, "value").Trim();
                string uiAdditionalCom = _AdditionalComments__UI == string.Empty ? "N/A" : _AdditionalComments__UI;

                Assert.AreEqual(_AdditionalComments_Excel, _AdditionalComments__UI);

                string _Status_Excel = Convert.ToString((xlRange.Cells[k, 15] as Excel.Range).Value2);
                string expectedUIStatus = expectedStatus == string.Empty ? "N/A" : expectedStatus;

                Assert.AreEqual(_Status_Excel, expectedUIStatus);





                i++;

            }
            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
            DeleteFilesFromFolder(downloadpath);
        }
    }
}