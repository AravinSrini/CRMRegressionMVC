using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.Quote_Results_Screen_InternalUsers
{
    [Binding]
    public class Quote_Results__LTL____Export_Results___Station_Users_Steps : ObjectRepository
    {

        [Then(@"I will be able to see the columns header")]
        public void ThenIWillBeAbleToSeeTheColumnsHeader()
        {
            string downloadpath = GetDownloadedFilePath("RateAndCarrier.xls");
            List<string> columns = Excel_ReadColumnname(downloadpath);
            List<string> expectedColumnValues = new List<string>(new string[] { "Carrier", "ServiceDays", "Distance", "EstCostFuelCharge", "EstCostLineHaulCharge", "EstAccessorialCharge", "EstCost", "FuelCharge", "LineHaulCharge", "AccessorialCharge", "StandardCharge", "InsuredFuelCharge", "InsuredLineHaulCharge", "InsuredAccessorialCharge", "InsuredCharge" });

            foreach (var s in columns)
            {
                if (expectedColumnValues.Contains(s))
                {
                    Report.WriteLine("Column name " + s + "displaying in exported excel sheet");
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        [Then(@"I click on export button and excel file should be downloaded")]
        public void ThenIClickOnExportButtonAndExcelFileShouldBeDownloaded()
        {
            Report.WriteLine("clicked on export button");

            Click(attributeName_xpath, ltlExportBtn_xpath);

            string downloadpath = GetDownloadedFilePath("RateAndCarrier.xls");

        }

        [Then(@"excel details should be match with UI")]
        public void ThenExcelDetailsShouldBeMatchWithUI()
        {
            string downloadpath = GetDownloadedFilePath("RateAndCarrier.xls");

            // List<string> UIvalue = IndividualColumnData("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr");


            List<string> rowValue = new List<string> { };
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            int c = 1;  //using this variable reading values from UI
            for (int k = 2; k <= 2; k++)
            {
                for (int j = 1; j <= 7; j++)
                {

                    if (c < 4)
                    {

                        string UIMoreInfo = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]")).Text;
                        string refValue = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);

                        UIMoreInfo.Contains(refValue);
                        c++;
                    }
                    else
                    {
                        string UIMoreInfo = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[2]")).Text;
                        if (UIMoreInfo.Contains("N/A"))
                        {
                            string refValue = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            UIMoreInfo.Contains(refValue);
                        }
                        else
                        {
                            string refValue = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            string UIMoreInfo11 = Regex.Replace(UIMoreInfo, @"[^0-9.]+", "");
                            string refValue11 = Regex.Replace(refValue, @"[^0-9.]+", "");
                            double UIMoreinforValue = double.Parse(UIMoreInfo11);
                            double refValueExcel = double.Parse(refValue11);
                            UIMoreinforValue.Equals(refValueExcel);
                        }

                        j++;

                        string UIMoreInfo1 = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[3]")).Text;
                        if (UIMoreInfo1.Contains("N/A"))
                        {
                            string refValue1 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            UIMoreInfo1.Contains(refValue1);
                        }
                        else
                        {
                            string refValue1 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            string UIMoreInfo12 = Regex.Replace(UIMoreInfo1, @"[^0-9.]+", "");
                            string refValue12 = Regex.Replace(refValue1, @"[^0-9.]+", "");
                            double UIMoreinforValue2 = double.Parse(UIMoreInfo12);
                            double refValueExcel2 = double.Parse(refValue12);
                            UIMoreinforValue2.Equals(refValueExcel2);
                        }
                        j++;

                        string UIMoreInfo2 = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[4]")).Text;
                        if (UIMoreInfo2.Contains("N/A"))
                        {
                            string refValue2 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            UIMoreInfo2.Contains(refValue2);
                        }
                        else
                        {
                            string refValue2 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            string UIMoreInfo13 = Regex.Replace(UIMoreInfo2, @"[^0-9.]+", "");
                            string refValue13 = Regex.Replace(refValue2, @"[^0-9.]+", "");
                            double UIMoreinforValue3 = double.Parse(UIMoreInfo13);
                            double refValueExcel3 = double.Parse(refValue13);
                            UIMoreinforValue3.Equals(refValueExcel3);
                        }

                        j++;
                        string UIMoreInfo3 = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[2]")).Text;

                        if (UIMoreInfo3.Contains("N/A"))
                        {
                            string refValue3 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            UIMoreInfo3.Contains(refValue3);
                        }
                        else
                        {

                        string refValue3 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                        string UIMoreInfo14 = Regex.Replace(UIMoreInfo3, @"[^0-9.]+", "");
                        string refValue14 = Regex.Replace(refValue3, @"[^0-9.]+", "");
                        double UIMoreinforValue4 = double.Parse(UIMoreInfo14);
                        double refValueExcel4 = double.Parse(refValue14);
                        UIMoreinforValue4.Equals(refValueExcel4);

                        }


                        j++;
                        c++;
                        string UIMoreInfo4 = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[2]")).Text;
                        string refValue4 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);

                        string UIMoreInfo15 = Regex.Replace(UIMoreInfo4, @"[^0-9.]+", "");
                        string refValue15 = Regex.Replace(refValue4, @"[^0-9.]+", "");
                        double UIMoreinforValue5 = double.Parse(UIMoreInfo15);
                        double refValueExcel5 = double.Parse(refValue15);
                        UIMoreinforValue5.Equals(refValueExcel5);

                        j++;
                        string UIMoreInfo5 = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[3]")).Text;
                        string refValue5 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);

                        string UIMoreInfo16 = Regex.Replace(UIMoreInfo5, @"[^0-9.]+", "");
                        string refValue16 = Regex.Replace(refValue5, @"[^0-9.]+", "");
                        double UIMoreinforValue6 = double.Parse(UIMoreInfo16);
                        double refValueExcel6 = double.Parse(refValue16);
                        UIMoreinforValue6.Equals(refValueExcel6);

                        j++;
                        string UIMoreInfo6 = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[" + c + "]/ul[1]/li[4]")).Text;
                        string refValue6 = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);

                        string UIMoreInfo17 = Regex.Replace(UIMoreInfo6, @"[^0-9.]+", "");
                        string refValue17 = Regex.Replace(refValue6, @"[^0-9.]+", "");
                        double UIMoreinforValue7 = double.Parse(UIMoreInfo17);
                        double refValueExcel7 = double.Parse(refValue17);
                        UIMoreinforValue7.Equals(refValueExcel7);

                    }

                }
                xlWorkbook.Close(0);
                xlApp.Quit();
            }
            DeleteFilesFromFolder(downloadpath);
        }
    }
}
