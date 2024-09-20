using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using OpenQA.Selenium;
using Excel = Microsoft.Office.Interop.Excel;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Tracking
{
    [Binding]
    public class TrackingDetailsPage_ExportFunctionalitySteps : ObjectRepository
    {
        
        [Given(@"I click on Tracking Details icon")]
        public void GivenIClickOnTrackingDetailsIcon()
        {
            
            Report.WriteLine("Tracking Details Icon");
            Click(attributeName_id, Tracking_Icon_Id);
           
        }

        [Given(@"I click on Tracking Details icon for mobile device")]
        public void GivenIClickOnTrackingDetailsIconForMobileDevice()
        {
            WaitForElementVisible(attributeName_xpath, MenuExpandIcon_Mobile_Xpath, "Menu Icon");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_xpath, MenuExpandIcon_Mobile_Xpath);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Report.WriteLine("Tracking Details Icon");
            WaitForElementVisible(attributeName_id, Tracking_Icon_Id, "TrackingIcon");
            Click(attributeName_id, Tracking_Icon_Id);
        }

        [Given(@"I navigate to (.*) details page")]
        public void GivenINavigateToDetailsPage(string Tracking)
        {
            Report.WriteLine("Tracking details page");
            Verifytext(attributeName_xpath, TrackingPage_Header_xpath, Tracking);
            string Tracking_Title = Gettext(attributeName_xpath, TrackingPage_Header_xpath);
            Assert.AreEqual(Tracking, Tracking_Title);
        }


        [Given(@"I enter the multi'(.*)' in the search box")]
        public void GivenIEnterTheMultiInTheSearchBox(string MultipleValidReferenceNumbers)
        {
            Report.WriteLine(" Enter multi tracking numbers in the search field");
            SendKeys(attributeName_id, SearchtextboxTrack_id, MultipleValidReferenceNumbers);
            Click(attributeName_xpath, searchbuttonTrackingLandingpage_xpath);
        }

        [When(@"I click on search button in the Tracking page")]
        public void WhenIClickOnSearchButtonInTheTrackingPage()
        {
            Report.WriteLine("Click Search Button");
            Click(attributeName_xpath, searchbuttonTrackingLandingpage_xpath);
        }

        [When(@"I enter '(.*)' in the search box")]
        public void WhenIEnterInTheSearchBox(string MultipleValidReferenceNumbers)
        {
            Report.WriteLine(" Enter multi tracking numbers in the search field");
            SendKeys(attributeName_id, SearchtextboxTrack_id, MultipleValidReferenceNumbers);
        }


        [When(@"I navigate to (.*) Details page")]
        public void WhenINavigateToDetailsPage(string Tracking)
        {
            Report.WriteLine("Tracking details page");
            Verifytext(attributeName_xpath, TrackingPage_Header_xpath, Tracking);
            string Tracking_Title = Gettext(attributeName_xpath, TrackingPage_Header_xpath);
            Assert.AreEqual(Tracking, Tracking_Title);
        }
        
        [When(@"I click on Export button")]
        public void WhenIClickOnExportButton()
        {
            Report.WriteLine("Click on Export Button");
            Click(attributeName_id, Export_Button_Id);
        }

        [When(@"I click on All option from the export dropdown")]
        public void WhenIClickOnAllOptionFromTheExportDropdown()
        {
            Report.WriteLine("Click on 'All' Dropdown Option");
            Click(attributeName_xpath, Export_All_Xpath);
        }

        [When(@"I click on Displayed option from the export dropdown")]
        public void WhenIClickOnDisplayedOptionFromTheExportDropdown()
        {
            Report.WriteLine("Click on 'Displayed' Dropdown Option");
            Click(attributeName_xpath, Export_Displayed_Xpath);
        }

        
        [Then(@"I must be able to view (.*) Button")]
        public void ThenIMustBeAbleToViewButton(string Export)
        {
            Report.WriteLine("Export Button View");
            VerifyElementPresent(attributeName_id, Export_Button_Id, Export);
        }

        [Then(@"I must be able to view a dropdown with option to select (.*) or (.*)")]
        public void ThenIMustBeAbleToViewADropdownWithOptionToSelectOr(string All, string Displayed)
        {
            Report.WriteLine("Export Dropdown View");
            VerifyElementPresent(attributeName_xpath, Export_All_Xpath, All);
            VerifyElementPresent(attributeName_xpath, Export_Displayed_Xpath, Displayed);
        }

        [Then(@"An Excel file of \.xls format containing all the tracking results should get downloaded and verified")]
        public void ThenAnExcelFileOf_XlsFormatContainingAllTheTrackingResultsShouldGetDownloadedAndVerified()
        {
            List<string> UIvalue = IndividualColumnData(Tracking_Datatable_Content_Xpath);
            string downloadpath = null;
            for (int i = 0; i < UIvalue.Count; i++)
            {
                int index = UIvalue[i].IndexOf(" ");
                string value = UIvalue[i].Substring(0, index);
                downloadpath = GetDownloadedFilePath("TrackingDetails.xls");
                List<string> rowValue = new List<string> { };
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int k = 2; k <= rowCount; k++)
                {
                    string refValue = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                    if (refValue == value)
                    {
                        int s = 2;
                        for (int j = 3; j <= 7; j++)
                        {
                            int count = i + 1;
                            string UIstatus = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='TrackingDetailGrid']/tbody/tr[@role = 'row'][" + count.ToString() + "]/td[" + s + "]")).Text;
                            string content = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            string st1 = UIstatus.Replace(" ", string.Empty);
                            string s2 = content.Replace(" ", string.Empty);
                            if (st1.Contains(s2))
                            {
                                Report.WriteLine("Value from excel" + content + "is matching with UI value");
                                s++;
                            }
                            else
                            {
                                s++;
                                j--;
                            }
                        }

                    }
                    else
                    {
                        Report.WriteLine("Iteration to next row");
                    }

                }
                xlWorkbook.Close(0);
                xlApp.Quit();
            }
            DeleteFilesFromFolder(downloadpath);
        }


        [Then(@"An Excel file of \.xls format containing all the tracking results of the current page should get downloaded and verified")]
        public void ThenAnExcelFileOf_XlsFormatContainingAllTheTrackingResultsOfTheCurrentPageShouldGetDownloadedAndVerified()
        {
            List<string> UIvalue = IndividualColumnData(Tracking_Datatable_Content_Xpath);
            string downloadpath = null;
            for (int i = 0; i < UIvalue.Count; i++)
            {
                int index = UIvalue[i].IndexOf(" ");
                string value = UIvalue[i].Substring(0, index);
                downloadpath = GetDownloadedFilePath("TrackingDetails.xls");
                List<string> rowValue = new List<string> { };
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                for (int k = 2; k <= rowCount; k++)
                {
                    string refValue = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                    if (refValue == value)
                    {
                        int s = 2;
                        for (int j = 3; j <= 7; j++)
                        {
                            int count = i + 1;
                            string UIstatus = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='TrackingDetailGrid']/tbody/tr[@role = 'row'][" + count.ToString() + "]/td[" + s + "]")).Text;
                            string content = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                            string st1 = UIstatus.Replace(" ", string.Empty);
                            string s2 = content.Replace(" ", string.Empty);
                            if (st1.Contains(s2))
                            {
                                Report.WriteLine("Value from excel" + content + "is matching with UI value");
                                s++;
                            }
                            else
                            {
                                s++;
                                j--;
                            }
                        }

                    }
                    else
                    {
                        Report.WriteLine("Iteration to next row");
                    }

                }
                xlWorkbook.Close(0);
                xlApp.Quit();
            }
            DeleteFilesFromFolder(downloadpath);
        }

        [Then(@"I should not be able to view (.*) Button in the tracking details page")]
        public void ThenIShouldNotBeAbleToViewButtonInTheTrackingDetailsPage(string Export)
        {
            Report.WriteLine("Visibility of Export Button");
            VerifyElementNotVisible(attributeName_id, Export_Button_Id, Export);
        }

        [When(@"I click on More Information Icon")]
        public void WhenIClickOnMoreInformationIcon()
        {
            Report.WriteLine("Click on More Information Icon");
            Click(attributeName_xpath, Tracking_MoreInfo_icon_xpath);
        }

        [Then(@"I should be able to compare the more information details with the exported tracking details file")]
        public void ThenIShouldBeAbleToCompareTheMoreInformationDetailsWithTheExportedTrackingDetailsFile()
        {
            List<string> UIvalue = IndividualColumnData(".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr/td[2]/span");
            string downloadpath = null;
            for (int i = 0; i < UIvalue.Count; i++)
            {
               
                downloadpath = GetDownloadedFilePath("TrackingDetails.xls");
                List<string> rowValue = new List<string> { };
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                for (int k = 2; k <= 2; k++)
                {
                    for (int j = 9; j <= 16; j++)
                    {
                        int count = i + 1;
                        string UIMoreInfo = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='TrackingDetailGrid']/tbody/tr[1]/td[8]/div/table/tbody/tr[" + count.ToString() + "]/td[2]/span")).Text;
                        string refValue = Convert.ToString((xlRange.Cells[k, j] as Excel.Range).Value2);
                        Assert.AreEqual(UIMoreInfo, refValue);
                        i++;
                    }
               
                }
                xlWorkbook.Close(0);
                xlApp.Quit();
            }
            DeleteFilesFromFolder(downloadpath);
        }
    }


    
}
