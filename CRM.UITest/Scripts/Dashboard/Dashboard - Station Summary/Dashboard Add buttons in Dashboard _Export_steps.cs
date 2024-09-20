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

namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public sealed class Dashboard_Add_buttons_in_Dashboard__Export_steps : ObjectRepository
    {
      
        [When(@"I arrive on the Dashboard page")]
        public void WhenIArriveOnTheDashboardPage()
        {
            Report.WriteLine("Verifying dashboard landing page");
           
            VerifyElementPresent(attributeName_xpath, NewDashboard_Header_Text_Xpath, "Dashboard");
            
            
        }

        [Then(@"I will be able to see Export button in dashboard screen")]
        public void ThenIWillBeAbleToSeeExportButtonInDashboardScreen()
        {
            Report.WriteLine("Verifying Export button in dashboard screen");
            IsElementPresent(attributeName_id, Dashboard_Pending_CSR_EXport_Button_Id, "account drop down");

        }



        [Then(@"I click on the Export button")]
        public void ThenIClickOnTheExportButton()
        {
            Report.WriteLine("Verifying click button functionality");
            Click(attributeName_id, Dashboard_Pending_CSR_EXport_Button_Id);
            Thread.Sleep(6000);
        }


        [Then(@"Verify the downloaded excel file name and data with all of the Pending CSR Report(.*)")]
        public void ThenVerifyTheDownloadedExcelFileNameAndDataWithAllOfThePendingCSRReport(string File_Name)
        {

            Report.WriteLine("Verifying excel data with drop down");
            WaitForElementVisible(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath, "Select a CSR Text from Drop down");
            scrollpagedown();
            Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);
            IList<IWebElement> DropDownValue = (GlobalVariables.webDriver.FindElements(By.XPath(Dashboard_CSR_DropDown_list_Xpath)));
            string downloadpath = null;
            if (DropDownValue.Count > 0)
            {
                downloadpath = GetDownloadedFilePath(File_Name);
                List<string> rowValue = new List<string> { };
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

               // Click(attributeName_xpath, Dashboard_SelectACSR_Text_Xpath);

                for (int k = 2; k <= rowCount; k++)
                {

                    string refValue = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                   // string UIData=DropDownValue[k].Text;

                    string UIData = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='select_a_csr_chosen']/div/ul/li["+ k +"]")).Text;
                    Assert.AreEqual(refValue, UIData);

                }
                xlWorkbook.Close(0);
                xlApp.Quit();

                          }
            else
            {
                Report.WriteLine("No pending csr for this user");
            }
            DeleteFilesFromFolder(downloadpath);
        }

       
    }
}
