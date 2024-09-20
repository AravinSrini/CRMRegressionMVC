using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
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
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class Insurance_Claims_Claims_List_Page_ElementsSteps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        GetDownloadPath GetDownloadFolder = new GetDownloadPath();
        string username = null;
        string password = null;
        List<string> ascSort = new List<string>();
        List<string> desSort = new List<string>();

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales Management, Operations, Station Owner users")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesManagementOperationsStationOwnerUsers()
        {

            string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I click on the claim navigation icon")]
        public void WhenIClickOnTheClaimNavigationIcon()
        {
            if (username != ("CharlieClaimspecialist"))
            {
                Click(attributeName_id, ClaimsIcon_Id);
            }
            else
            {
                Report.WriteLine("Logged in user is claims specialist user");
            }
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }


        [Then(@"I should be navigated to the Claim List page")]
        public void ThenIShouldBeNavigatedToTheClaimListPage()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [When(@"I arrive on the claim list page")]
        public void WhenIArriveOnTheClaimListPage()
        {
            if (username != ("CharlieClaimspecialist"))
            {
                Click(attributeName_id, ClaimsIcon_Id);
            }
            else
            {
                Report.WriteLine("Logged in user is claims specialist user");
            }

            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [Then(@"Verify the page elements on the claim list page for header with instructional verbiage")]
        public void ThenVerifyThePageElementsOnTheClaimListPageForHeaderWithInstructionalVerbiage()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            Verifytext(attributeName_xpath, ClaimsList_InstructionalVerbiage_xpath, "Submit and track claims");
        }



        [Then(@"Verify a Submit a Claim button")]
        public void ThenVerifyASubmitAClaimButton()
        {
            
            VerifyElementPresent(attributeName_id, Submit_A_Claim_button_Id, "Submit a Claim");
        }


        [When(@"I click on the Submit a Claim button")]
        public void WhenIClickOnTheSubmitAClaimButton()
        {
            Click(attributeName_id, Submit_A_Claim_button_Id);
        }



        [Then(@"default Selection is Open status")]
        public void ThenDefaultSelectionIsOpenStatus()
        {
            VerifyElementEnabled(attributeName_xpath, ClaimsList_OpenCheckbox_xpath, "Open");
        }




        [Then(@"Grid View Option at top and bottom of the grid list")]
        public void ThenGridViewOptionAtTopAndBottomOfTheGridList()
        {
            VerifyElementPresent(attributeName_xpath, ClaimsListTopGridViewOption_xpath, "Top Grid Display");
            VerifyElementPresent(attributeName_xpath, ClaimsListBottonGridViewOption_xpath, "Bottom Grid Display");
        }

        [Then(@"Verify the search text box")]
        public void ThenVerifyTheSearchTextBox()
        {
            VerifyElementPresent(attributeName_xpath, ClaimsListSearchField_xpath, "Search Field");
        }

        [Then(@"Export button on the Claim list page")]
        public void ThenExportButtonOnTheClaimListPage()
        {
            VerifyElementPresent(attributeName_xpath, ClaimsListExportButton_xpath, "Export Button");
        }







        [Then(@"I should be able to view Options '(.*)' under dropdown in top grid of the cliam list page")]
        public void ThenIShouldBeAbleToViewOptionsUnderDropdownInTopGridOfTheCliamListPage(string p0)
        {
            string options = "10,20,60,100,ALL";
            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);

            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_TopGrid_ViewDropdownValues_Xpath));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }

        }

        [Then(@"I should be able to view Options (.*), (.*), (.*), (.*), and ALL under dropdown in bottom grid of the cliam list page")]
        public void ThenIShouldBeAbleToViewOptionsAndALLUnderDropdownInBottomGridOfTheCliamListPage(int p0, int p1, int p2, int p3)
        {
            string options = "10,20,60,100,ALL";
            scrollElementIntoView(attributeName_xpath, ClaimsList_BottomGrid_ViewDropdown_Xpath);
            Click(attributeName_xpath, ClaimsList_BottomGrid_ViewDropdown_Xpath);

            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_BottomGrid_ViewDropdownValues_Xpath));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }


        [Then(@"only ten records should be displayed on the claim list page load")]
        public void ThenOnlyTenRecordsShouldBeDisplayedOnTheClaimListPageLoad()
        {
            Report.WriteLine("Verifying the default records on the page load");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var defaultOption = executor.ExecuteScript("return $('#gridInsuranceClaimList_length :selected').val()");
            Assert.AreEqual("10", defaultOption);
            Report.WriteLine("Default 10 option is selected in the dropdown");
        }

        [Given(@"I arrive on the claim list page")]
        public void GivenIArriveOnTheClaimListPage()
        {
            if (username != ("CharlieClaimspecialist"))
            {
                Click(attributeName_id, ClaimsIcon_Id);
            }
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }


        [When(@"I click on the right navigation icon in the top grid on the claim list page")]
        public void WhenIClickOnTheRightNavigationIconInTheTopGridOnTheClaimListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ClaimsList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of ") + 2);
            //string displaycount = totalrecords.Remove(0, 18);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, ClaimsList_TopGrid_RightNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }

        [Then(@"Next set of records should be displayed on the claim list page")]
        public void ThenNextSetOfRecordsShouldBeDisplayedOnTheClaimListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ClaimsList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of ") + 2);
            
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("of");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), "20");
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }

        [Then(@"left navigation icon should be enabled on the claim list page")]
        public void ThenLeftNavigationIconShouldBeEnabledOnTheClaimListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ClaimsList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of ") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Verifying the left navigation in shipment list page");
                VerifyElementEnabled(attributeName_xpath, ClaimsList_TopGrid_LeftNavigationIcon_Xpath, "Left navigation icon");
                Click(attributeName_xpath, ClaimsList_TopGrid_LeftNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to verify the left navigation icon functionality as number of records are less than 10");
            }
        }


        [When(@"I click on the the left navigation icon in the top grid on the claim list page from the next set of records page")]
        public void WhenIClickOnTheTheLeftNavigationIconInTheTopGridOnTheClaimListPageFromTheNextSetOfRecordsPage()
        {

            string totalrecords = Gettext(attributeName_xpath, ClaimsList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of ") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, ClaimsList_TopGrid_RightNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }

            string totalrecords1 = Gettext(attributeName_xpath, ClaimsList_TopGrid_DisplayListView_Xpath);
            string displaycount1 = totalrecords.Substring(totalrecords.LastIndexOf("of ") + 2);
            int DC1 = Convert.ToInt32(displaycount1);
            if (DC1 > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, ClaimsList_TopGrid_LeftNavigationIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }


        [Then(@"I should see the previous default set of records on the cliam list page")]
        public void ThenIShouldSeeThePreviousDefaultSetOfRecordsOnTheCliamListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, ClaimsList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("of ") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("of");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), "10");
                Report.WriteLine("Initial set of records are displaying in page");
            }
            else
            {
                Report.WriteLine("Unable to verify the functionality of left navigation icon as number of records are less than 10");
            }
        }



        [Then(@"verify the column names on the claim list page")]
        public void ThenVerifyTheColumnNamesOnTheClaimListPage()
        {
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/thead/tr/th"));
            int colCount = totalcarriers.Count();
            for (int i = 0; i < colCount; i++)
            {
                int j = i + 1;
                List<string> expectedColumnValues = new List<string>(new string[] { "Customer", "Customer Ref #", "Insured", "DLSW Claim #", "DLSW Ref #", "Carrier", "Amount", "Status", "Submit Date", "Claim Age" });
                string colName = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[" + j + "] ");
                foreach (var s in expectedColumnValues)
                {
                    if (expectedColumnValues.Contains(s))
                    {
                        Report.WriteLine("Column name " + s + "displaying in UI column name");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
        }

        [When(@"I click on the Export dropdown arrow")]
        public void WhenIClickOnTheExportDropdownArrow()
        {
            Click(attributeName_xpath, ClaimsListExportButton_xpath);
        }

        [Then(@"I should see the dropdown options to select All or Displayed")]
        public void ThenIShouldSeeTheDropdownOptionsToSelectAllOrDisplayed()
        {
            String options = "All,Displayed";

            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_ExportButtonDropdownValues_Xpath));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }


            //Report.WriteLine("displayed the option to select All or Displayed");
            //var exportdropdownValues = new List<string> { "All", "Displayed" };
            //List<string> exportdropdownValuesUI = GetDropdownOptions(attributeName_xpath, customerInvoicesexportdropdownvalues_id, "li");
            //CollectionAssert.AreEqual(exportdropdownValues, exportdropdownValuesUI);
        }


        [When(@"I click on the Export dropdown and select All option")]
        public void WhenIClickOnTheExportDropdownAndSelectAllOption()
        {
            Click(attributeName_xpath, ClaimsListExportButton_xpath);
            Report.WriteLine("select All option");
            Click(attributeName_xpath, ClaimsList_ExportAllOption_xpath);
        }


        [Then(@"Report should be generated of all records on the claim list page")]
        public void ThenReportShouldBeGeneratedOfAllRecordsOnTheClaimListPage()
        {
            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");


            Report.WriteLine("ReportWillBeGeneratedOfAllRecordsOfTheCustomerInvoicesGrid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Claims Export Cust_Sta User.xls");
            Assert.IsNotNull(downloadPath);
            Report.WriteLine("CustomerInvoiceListExport.xls will be in downloaded path");
            //List<string> UIvalue = IndividualColumnData(customerInvoicescolumns_xpath);
            List<string> UIvalue = IndividualColumnData(ClaimsListColumns_xpath);
            int rowCountUi = UIvalue.Count;
            List<string> rowValue = new List<string> { };
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
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


        [Then(@"Report should be generated of all records on the claim list page for Claim Specialist user")]
        public void ThenReportShouldBeGeneratedOfAllRecordsOnTheClaimListPageForClaimSpecialistUser()
        {
            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");


            Report.WriteLine("ReportWillBeGeneratedOfAllRecordsOfTheCustomerInvoicesGrid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Claims Export Claims Spec User.xls");
            Assert.IsNotNull(downloadPath);
            Report.WriteLine("CustomerInvoiceListExport.xls will be in downloaded path");
            //List<string> UIvalue = IndividualColumnData(customerInvoicescolumns_xpath);
            List<string> UIvalue = IndividualColumnData(ClaimsListColumns_xpath);
            int rowCountUi = UIvalue.Count;
            List<string> rowValue = new List<string> { };
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
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



        [Then(@"all the column names and data from the claim list page should be displayed in the exported report")]
        public void ThenAllTheColumnNamesAndDataFromTheClaimListPageShouldBeDisplayedInTheExportedReport()
        {
            Report.WriteLine("remaining all columns will be exported to report from Customer Invoices grid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Claims Export Cust_Sta User.xls");
            Assert.IsNotNull(downloadPath);
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
                string Customer_Excel = Convert.ToString((xlRange.Cells[k, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                Assert.AreEqual(Customer_Excel, "Customer");
                string CustomerVal_Excel = Convert.ToString((xlRange.Cells[l, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                string CustomerValUi = Gettext(attributeName_xpath, CustomerValUi_xpath);
                Assert.AreEqual(CustomerVal_Excel, CustomerValUi);

                string CustRefNumber_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                Assert.AreEqual(CustRefNumber_Excel, "Customer Ref #");
                string CustRefNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 2] as Excel.Range).Value2);
                string CustRefNumberUi = Gettext(attributeName_xpath, CustomerRefNumberUi_xpath);
                Assert.AreEqual(CustRefNumberVal_Excel, CustRefNumberUi);

                string Insured_Excel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                Assert.AreEqual(Insured_Excel, "Insured");
                string InsuredVal_Excel = Convert.ToString((xlRange.Cells[l, 3] as Excel.Range).Value2);
                string InsuredValUi = Gettext(attributeName_xpath, InsuredValUi_xpath);
                Assert.AreEqual(InsuredVal_Excel, InsuredValUi);

                string DLSWCLaimNumber_Excel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                Assert.AreEqual(DLSWCLaimNumber_Excel, "DLSW Claim #");
                string DLSWCLaimNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 4] as Excel.Range).Value2);
                string DLSWCLaimNumberValUi = Gettext(attributeName_xpath, DLSWCLaimNumberValUi_xpath);
                Assert.AreEqual(DLSWCLaimNumberVal_Excel, DLSWCLaimNumberValUi);

                string DLSWRefNumber_Excel = Convert.ToString((xlRange.Cells[k, 5] as Excel.Range).Value2);
                Assert.AreEqual(DLSWRefNumber_Excel, "DLSW Ref #");
                string DLSWRefNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 5] as Excel.Range).Value2);
                string DLSWRefNumberValUi = Gettext(attributeName_xpath, DLSWRef_NumberValUi_xpath);
                Assert.AreEqual(DLSWRefNumberVal_Excel, DLSWRefNumberValUi);

                string CarrierName_Excel = Convert.ToString((xlRange.Cells[k, 6] as Excel.Range).Value2);
                Assert.AreEqual(CarrierName_Excel, "Carrier Name");
                string CarrierNameVal_Excel = Convert.ToString((xlRange.Cells[l, 6] as Excel.Range).Value2);
                string CarrierNameValUi = Gettext(attributeName_xpath, CarrierNameValUi_xpath);
                if (CarrierNameValUi.Contains(CarrierNameVal_Excel))
                {
                    Report.WriteLine("Carrier name from UI matches with Excel");
                }else
                {
                    Assert.Fail();
                }
                //Assert.AreEqual(CarrierNameVal_Excel, CarrierNameValUi);

                string CarrierPRO_Excel = Convert.ToString((xlRange.Cells[k, 7] as Excel.Range).Value2);
                Assert.AreEqual(CarrierPRO_Excel, "Carrier PRO");
                string CarrierPROVal_Excel = Convert.ToString((xlRange.Cells[l, 7] as Excel.Range).Value2);
                string CarrierPROValUi = Gettext(attributeName_xpath, CarrierPROValUi_xpath);
                //Assert.AreEqual(CarrierPROVal_Excel, CarrierPROValUi);
                if (CarrierPROValUi.Contains(CarrierPROVal_Excel))
                {
                    Report.WriteLine("Carrier PRO number from UI matches with Excel");
                }
                else
                {
                    Assert.Fail();
                }

                string OriginalAmt_Excel = Convert.ToString((xlRange.Cells[k, 8] as Excel.Range).Value2);
                Assert.AreEqual(OriginalAmt_Excel, "Amount");
                string OriginalAmtVal_Excel = Convert.ToString((xlRange.Cells[l, 8] as Excel.Range).Value2);
                double OriginalAmtValD_Excel = double.Parse(OriginalAmtVal_Excel.Replace(@"$", ""));
                string OriginalAmtValUi = Gettext(attributeName_xpath, OriginalAmtValUi_xpath);
                double OriginalAmtValDUi = double.Parse(OriginalAmtValUi.Replace(@"$", ""));
                Assert.AreEqual(OriginalAmtValD_Excel, OriginalAmtValDUi);

                string Status_Excel = Convert.ToString((xlRange.Cells[k, 9] as Excel.Range).Value2);
                Assert.AreEqual(Status_Excel, "Status");
                string StatusVal_Excel = Convert.ToString((xlRange.Cells[l, 9] as Excel.Range).Value2);
                string StatusValUi = Gettext(attributeName_xpath, StatusValUi_xpath);
                Assert.AreEqual(StatusVal_Excel, StatusValUi);


                string SubmitDate_Excel = Convert.ToString((xlRange.Cells[k, 10] as Excel.Range).Value2);
                Assert.AreEqual(SubmitDate_Excel, "Submit Date");
                string SubmitDateVal_Excel = Convert.ToString((xlRange.Cells[l, 10] as Excel.Range).Value2);
                string SubmitDateValUi = Gettext(attributeName_xpath, SubmitDateValUi_xpath);
                Assert.AreEqual(SubmitDateVal_Excel, SubmitDateValUi);

                string ClaimAge_Excel = Convert.ToString((xlRange.Cells[k, 11] as Excel.Range).Value2);
                Assert.AreEqual(ClaimAge_Excel, "Claim Age");
                string ClaimAgeVal_Excel = Convert.ToString((xlRange.Cells[l, 11] as Excel.Range).Value2);
                string ClaimAgeValUi = Gettext(attributeName_xpath, ClaimAgeValUi_xpath);
                Assert.AreEqual(ClaimAgeVal_Excel, ClaimAgeValUi);
                i++;

            }
            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
            DeleteFilesFromFolder(downloadPath);
        }


        [When(@"I click on the Export dropdown and select Displayed option")]
        public void WhenIClickOnTheExportDropdownAndSelectDisplayedOption()
        {
            Click(attributeName_xpath, ClaimsListExportButton_xpath);
            Report.WriteLine("select All option");
            Click(attributeName_xpath, ClaimsList_ExportDisplayedOption_xpath);
        }


        [Then(@"Report should be generated of displayed records on the claim list page")]
        public void ThenReportShouldBeGeneratedOfDisplayedRecordsOnTheClaimListPage()
        {
            Report.WriteLine("ReportWillBeGeneratedOfAllRecordsOfTheCustomerInvoicesGrid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Claims Export Cust_Sta User.xls");
            Assert.IsNotNull(downloadPath);
            Report.WriteLine("CustomerInvoiceListExport.xls will be in downloaded path");
            //List<string> UIvalue = IndividualColumnData(customerInvoicescolumns_xpath);
            List<string> UIvalue = IndividualColumnData(ClaimsListColumns_xpath);
            int rowCountUi = UIvalue.Count;
            List<string> rowValue = new List<string> { };
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
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

        [Then(@"Report should be generated of displayed records on the claim list page for Claim Specialist user")]
        public void ThenReportShouldBeGeneratedOfDisplayedRecordsOnTheClaimListPageForClaimSpecialistUser()
        {
            Report.WriteLine("ReportWillBeGeneratedOfAllRecordsOfTheCustomerInvoicesGrid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Claims Export Claims Spec User.xls");
            Assert.IsNotNull(downloadPath);
            Report.WriteLine("CustomerInvoiceListExport.xls will be in downloaded path");
            //List<string> UIvalue = IndividualColumnData(customerInvoicescolumns_xpath);
            List<string> UIvalue = IndividualColumnData(ClaimsListColumns_xpath);
            int rowCountUi = UIvalue.Count;
            List<string> rowValue = new List<string> { };
            Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
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



        [When(@"I click in the search field")]
        public void WhenIClickInTheSearchField()
        {
            VerifyElementPresent(attributeName_xpath, ClaimsListSearchField_xpath,"Search Text");
        }




        [Then(@"I have the option to type in any value '(.*)'")]
        public void ThenIHaveTheOptionToTypeInAnyValue(string p0)
        {
            string TestData = "ZZZ - Czar Customer Test";
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, TestData);
        }


        [Then(@"any rows that contain the values '(.*)' that were entered will be highlighted")]
        public void ThenAnyRowsThatContainTheValuesThatWereEnteredWillBeHighlighted(string p0)
        {
            string TestData = "ZZZ - Czar Customer Test";
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            
            int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
            {
                IList<IWebElement> SearchedStationNamehighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CustomerNameAll_Values_Xpath));
                int HighlightedStationNameCount = SearchedStationNamehighlightedValues.Count;
                foreach (var val in SearchedStationNamehighlightedValues)
                {
                    if (TestData.Contains(val.Text))
                    {
                        var colorofHighlighted_StationName_Value = GetCSSValue(attributeName_classname, "highlight", "background-color");
                        Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_StationName_Value);
                        Report.WriteLine("Highlighted Reference Number values are appropriate");
                    }

                    else
                    {
                        Assert.Fail();
                    }

                }


            }
            else
            {
                Report.WriteLine("No Records found for the Shipment List for the logged in user so unable to test the scenario");
            }
        }


        [Then(@"I will arrive on the Submit a Claim form page")]
        public void ThenIWillArriveOnTheSubmitAClaimFormPage()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
        }


        [When(@"I select the show status (.*) in the claims list page")]
        public void WhenISelectTheShowStatusInTheClaimsListPage(string options)
        {
            if (options == "Open")
            {
                VerifyElementEnabled(attributeName_xpath, ClaimsList_OpenCheckbox_xpath, "Open");
                //Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            }
            else if (options == "Paid")
            {
                Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            }
            else if (options == "Denied")
            {
                Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);

            }
            else if (options == "Cancelled")
            {
                Click(attributeName_xpath, ClaimsList_Cancelled_xpath);
            }
            else if (options == "Pending")
            {
                Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            }
        }



        [Then(@"I should see an Information Icon I displayed next to only Open, Denied, Cancelled and Paid (.*) status")]
        public void ThenIShouldSeeAnInformationIconIDisplayedNextToOnlyOpenDeniedCancelledAndPaidStatus(string options)
        {
            if (options.Equals("Open") || options.Equals("Denied") || options.Equals("Cancelled") || options.Equals("Paid"))
            {
                string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
                int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
                if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
                {
                    for (int i = 1; i <= Shipmentrowcount; i++)
                    {
                        VerifyElementPresent(attributeName_xpath, ClaimsList_InformationIcon_xpath, "InformationIcon");
                    }
                }else
                {
                    Report.WriteLine("No records found");
                }
            }
            else
            {
                VerifyElementNotPresent(attributeName_xpath, ClaimsList_InformationIcon_xpath, "InformationIcon");
            }
        }




        [When(@"I click on the sort arrow of the Customer column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheCustomerColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_CustomerNameClick_Xpath);

        }

        [Then(@"Customer column will be sorted alphabetically")]
        public void ThenCustomerColumnWillBeSortedAlphabetically()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_CustomerNameAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CustomerNameAll_Values_Xpath));
                foreach (IWebElement element in customerColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }

        [Then(@"clicking on Customer column arrow again will reverse the sort")]
        public void ThenClickingOnCustomerColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_CustomerNameAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_CustomerNameClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CustomerNameAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }



        [When(@"I click on the sort arrow of the Customer Ref Number column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheCustomerRefNumberColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_CustomerRefNumberClick_Xpath);
        }


        [Then(@"Customer Ref Number column will be sorted alphabetically")]
        public void ThenCustomerRefNumberColumnWillBeSortedAlphabetically()
        {

            int row = GetCount(attributeName_xpath, ClaimsList_CustomerRefNumberAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CustomerRefNumberAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [Then(@"Clicking on Customer Ref Number Column again will reverse the sort")]
        public void ThenClickingOnCustomerRefNumberColumnAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_CustomerNameClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CustomerRefNumberAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [When(@"I click on the sort arrow of the Insured column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheInsuredColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_InsuredColClick_Xpath);
        }

        [Then(@"Insured column will be sorted alphabetically")]
        public void ThenInsuredColumnWillBeSortedAlphabetically()
        {

            int row = GetCount(attributeName_xpath, ClaimsList_InsuredColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {


                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_InsuredColAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }

        [Then(@"clicking on Insured column arrow again will reverse the sort")]
        public void ThenClickingOnInsuredColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_InsuredColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_InsuredColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_InsuredColAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }



        [When(@"I click on the sort arrow of the DLSW Claim \# column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheDLSWClaimColumnOnTheClaimsListPage()
        {

            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_DLSWClaimNumberColClick_Xpath);
        }

        [Then(@"DLSW Claim \# column will be sorted numerically lowest to highest")]
        public void ThenDLSWClaimColumnWillBeSortedNumericallyLowestToHighest()
        {

            int row = GetCount(attributeName_xpath, ClaimsList_DLSWClaimNumberColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWClaimNumberColAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }

        [Then(@"clicking on DLSW Claim \# column arrow again will reverse the sort")]
        public void ThenClickingOnDLSWClaimColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_DLSWClaimNumberColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_DLSWClaimNumberColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWClaimNumberColAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [When(@"I click on the sort arrow of the DLSW Ref \# column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheDLSWRefColumnOnTheClaimsListPage()
        {

            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_DLSWRefNumberColClick_Xpath);
        }

        [Then(@"DLSW Ref \# column will be sorted alphabetically")]
        public void ThenDLSWRefColumnWillBeSortedAlphabetically()
        {

            int row = GetCount(attributeName_xpath, ClaimsList_DLSWRefNumberColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWRefNumberColAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }

        [Then(@"clicking on DLSW Ref \# arrow again will reverse the sort")]
        public void ThenClickingOnDLSWRefArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_DLSWRefNumberColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_DLSWRefNumberColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWRefNumberColAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }




        [When(@"I click on the sort arrow of the Amount column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheAmountColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_AmountColClick_Xpath);
        }

        [Then(@"Amount column will be sorted numerically lowest to highest and clicking on Amount column arrow again will reverse the sort")]
        public void ThenAmountColumnWillBeSortedNumericallyLowestToHighestAndClickingOnAmountColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_AmountColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_AmountColAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [Then(@"clicking on Amount column arrow again will reverse the sort")]
        public void ThenClickingOnAmountColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_AmountColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_AmountColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_AmountColAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [When(@"I click on the sort arrow of the Carrier column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheCarrierColumnOnTheClaimsListPage()
        {

            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_CarrierColClick_Xpath);
        }


        [Then(@"Carrier column will be sorted alphabetically based on Carrier Name")]
        public void ThenCarrierColumnWillBeSortedAlphabeticallyBasedOnCarrierName()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_CarrierNameColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CarrierNameColAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }

        [Then(@"clicking on Carrier column arrow again will reverse the sort")]
        public void ThenClickingOnCarrierColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_CarrierColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_CarrierNameColAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [When(@"I click on the sort arrow of the Status column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheStatusColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath);

            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");


            Click(attributeName_xpath, ClaimsList_StatusColClick_Xpath);
        }

        [Then(@"Status column will be sorted alphabetically")]
        public void ThenStatusColumnWillBeSortedAlphabetically()
        {

            int row = GetCount(attributeName_xpath, ClaimsList_StatusColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> customerRefNumberColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_StatusColAll_Values_Xpath));
                foreach (IWebElement element in customerRefNumberColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }

        [Then(@"clicking on Status column arrow again will reverse the sort")]
        public void ThenClickingOnStatusColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_StatusColAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                Click(attributeName_xpath, ClaimsList_StatusColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_StatusColAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }

            else
            {
                Report.WriteLine("No records for Station column");
            }
        }


        [When(@"I click on the sort arrow of the Submit Date column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheSubmitDateColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
        }

        [Then(@"Submit Date column will be sorted numerically from oldest to newest")]
        public void ThenSubmitDateColumnWillBeSortedNumericallyFromOldestToNewest()
        {

            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {

              
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_SubmitDateAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }

            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Submit Date column arrow again will reverse the sort")]
        public void ThenClickingOnSubmitDateColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_SubmitDateAll_Values_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_SubmitDateAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }



        [When(@"I click on the sort arrow of the Claim Age column on the Claims List page")]
        public void WhenIClickOnTheSortArrowOfTheClaimAgeColumnOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            Click(attributeName_xpath, ClaimsList_ClaimsAgeColClick_Xpath);
        }


        [Then(@"Claim Age column will be sorted numerically from lowest to highest")]
        public void ThenClaimAgeColumnWillBeSortedNumericallyFromLowestToHighest()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_ClaimAgeAll_Values_Xpath);
            if (row >= 1)
            {
           
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_ClaimAgeAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Claim Age column arrow again will reverse the sort")]
        public void ThenClickingOnClaimAgeColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_ClaimAgeAll_Values_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, ClaimsList_ClaimsAgeColClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_ClaimAgeAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }
    
    
        [Given(@"I am a claim specialist user")]
        public void GivenIAmAClaimSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Then(@"verify the column names on the claim list page for claim specialist user")]
        public void ThenVerifyTheColumnNamesOnTheClaimListPageForClaimSpecialistUser()
        {
            IList<IWebElement> totalcarriers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/thead/tr/th"));
            int colCount = totalcarriers.Count();
            for (int i = 1; i < colCount; i++)
            {
                List<string> expectedColumnValues = new List<string>(new string[] { "STA / CUST", "Dates", "Claim #s", "Insured", "Amount", "DLSW Ref #", "Carrier", "DLSW Claim Specialist", "Submitted By", "Status" });
                string colName = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[" + i + "] ");
                foreach (var s in expectedColumnValues)
                {
                    if (expectedColumnValues.Contains(s))
                    {
                        Report.WriteLine("Column name " + s + "displaying in UI column name");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }
            }
        }


        [Then(@"all the column names and data from the claim list page should be displayed in the exported report for cliam specialist user")]
        public void ThenAllTheColumnNamesAndDataFromTheClaimListPageShouldBeDisplayedInTheExportedReportForCliamSpecialistUser()
        {
            Report.WriteLine("remaining all columns will be exported to report from Customer Invoices grid");
            string downloadPath = GetDownloadFolder.GetDownloadFolderPath(@"\Claims Export Claims Spec User.xls");
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
                string station_Excel = Convert.ToString((xlRange.Cells[k, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                Assert.AreEqual(station_Excel, "Station");
                string stationVal_Excel = Convert.ToString((xlRange.Cells[l, 1] as Microsoft.Office.Interop.Excel.Range).Value2);
                string stationValUi = Gettext(attributeName_xpath, StationValUi_xpath);
                string[] stationUI = stationValUi.Split(new[] { "\r\n" }, StringSplitOptions.None);
                Assert.AreEqual(stationVal_Excel, stationUI[0]);
                

                string Customer_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                Assert.AreEqual(Customer_Excel, "Customer");
                string Customer_ExcelVal_Excel = Convert.ToString((xlRange.Cells[l, 2] as Excel.Range).Value2);
                string CustomerUi = Gettext(attributeName_xpath, CustValUIXpath);
                string[] CustUI = CustomerUi.Split(new[] { "\r\n" }, StringSplitOptions.None);
                Assert.AreEqual(Customer_ExcelVal_Excel, CustUI[1]);
                

                string Dates_Excel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                Assert.AreEqual(Dates_Excel, "Submit Date");
                string DatesVal_Excel = Convert.ToString((xlRange.Cells[l, 3] as Excel.Range).Value2);
                string DatesValUi = Gettext(attributeName_xpath, SubmitDateValUIXpath);
                string[] dates = DatesValUi.Split(new[] { "\r\n" }, StringSplitOptions.None);
                string datesUi = dates[0].Remove(0, 5);
                Assert.AreEqual(DatesVal_Excel, datesUi);
               

                //string ACKDates_Excel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                //Assert.AreEqual(ACKDates_Excel, "Ack Date");
                //string ACKDatesVal_Excel = Convert.ToString((xlRange.Cells[l, 4] as Excel.Range).Value2);
                //string ACKDatesValUi = Gettext(attributeName_xpath, ACKDateValUIXpath);
                //string[] Adates = ACKDatesValUi.Split(new[] { "\r\n" }, StringSplitOptions.None);
                //string AdatesUi = Adates[1].Remove(0, 5);
                //Assert.AreEqual(ACKDatesVal_Excel, AdatesUi);
                

                string DLSWCLaimNumber_Excel = Convert.ToString((xlRange.Cells[k, 5] as Excel.Range).Value2);
                Assert.AreEqual(DLSWCLaimNumber_Excel, "DLSW Claim #");
                string CLaimNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 5] as Excel.Range).Value2);
                string CLaimNumberValUi = Gettext(attributeName_xpath, DLSW_CLaimNumberValUi_xpath);
                Assert.AreEqual(CLaimNumberVal_Excel, CLaimNumberValUi);

                //string CarrierCLaimNumber_Excel = Convert.ToString((xlRange.Cells[k, 6] as Excel.Range).Value2);
                //Assert.AreEqual(CarrierCLaimNumber_Excel, "Carrier Claim #");
                //string CarrierCLaimNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 6] as Excel.Range).Value2);
                //string CarrierCLaimNumberValUi = Gettext(attributeName_xpath, CarrierCLaimNumberValUi_xpath);
                //Assert.AreEqual(CarrierCLaimNumberValUi, CarrierCLaimNumberVal_Excel);

                string InsuredCol_Excel = Convert.ToString((xlRange.Cells[k, 7] as Excel.Range).Value2);
                Assert.AreEqual(InsuredCol_Excel, "Insured");
                string InsuredCol_Val_Excel = Convert.ToString((xlRange.Cells[l, 7] as Excel.Range).Value2);
                string InsuredCol_ValUi = Gettext(attributeName_xpath, InsuredCol_ValUi_xpath);
                Assert.AreEqual(InsuredCol_Val_Excel, InsuredCol_ValUi);
               

                string OriginalAmt_Excel = Convert.ToString((xlRange.Cells[k, 8] as Excel.Range).Value2);
                Assert.AreEqual(OriginalAmt_Excel, "Amount");
                string OriginalAmtVal_Excel = Convert.ToString((xlRange.Cells[l, 8] as Excel.Range).Value2);
                double OriginalAmtValD_Excel = double.Parse(OriginalAmtVal_Excel.Replace(@"$", ""));
                string OriginalAmtValUi = Gettext(attributeName_xpath, OriginalAmt_ValUi_xpath);
                double OriginalAmtValDUi = double.Parse(OriginalAmtValUi.Replace(@"$", ""));
                Assert.AreEqual(OriginalAmtValD_Excel, OriginalAmtValDUi);

                string DLSWRefNumber_Excel = Convert.ToString((xlRange.Cells[k, 9] as Excel.Range).Value2);
                Assert.AreEqual(DLSWRefNumber_Excel, "DLSW Ref #");
                string DLSWRefNumberVal_Excel = Convert.ToString((xlRange.Cells[l, 9] as Excel.Range).Value2);
                string DLSWRefNumberValUi = Gettext(attributeName_xpath, DLSWRefNumberValUi_xpath);
                Assert.AreEqual(DLSWRefNumberVal_Excel, DLSWRefNumberValUi);

                string CarrierName_Excel = Convert.ToString((xlRange.Cells[k, 10] as Excel.Range).Value2);
                Assert.AreEqual(CarrierName_Excel, "Carrier Name");
                string CarrierNameVal_Excel = Convert.ToString((xlRange.Cells[l, 10] as Excel.Range).Value2);
                string CarrierNameValUi = Gettext(attributeName_xpath, Carrier_NameValUi_xpath);
                string[] CarrierName = CarrierNameValUi.Split(new[] { "\r\n" }, StringSplitOptions.None);
                Assert.AreEqual(CarrierNameVal_Excel, CarrierName[0]);

                string CarrierPRO_Excel = Convert.ToString((xlRange.Cells[k, 11] as Excel.Range).Value2);
                Assert.AreEqual(CarrierPRO_Excel, "Carrier PRO");
                string CarrierPROVal_Excel = Convert.ToString((xlRange.Cells[l, 11] as Excel.Range).Value2);
                string CarrierPROValUi = Gettext(attributeName_xpath, Carrier_PROValUI_xpath);
                string[] CarrierPro = CarrierPROValUi.Split(new[] { "\r\n" }, StringSplitOptions.None);
                string CarrierProUI = CarrierPro[1].Remove(0, 5);
                Assert.AreEqual(CarrierPROVal_Excel, CarrierProUI);


                string DLSWClaimSpec_Excel = Convert.ToString((xlRange.Cells[k, 12] as Excel.Range).Value2);
                Assert.AreEqual(DLSWClaimSpec_Excel, "DLSW Specialist");
                string DLSWClaimSpecVal_Excel = Convert.ToString((xlRange.Cells[l, 12] as Excel.Range).Value2);
                string DLSWClaimSpecValUi = Gettext(attributeName_xpath, DLSWClaimSpec_ValUi_xpath);
                Assert.AreEqual(DLSWClaimSpecVal_Excel, DLSWClaimSpecValUi);

                scrollElementIntoView(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[10]");

                string SubmittedBy_Excel = Convert.ToString((xlRange.Cells[k, 13] as Excel.Range).Value2);
                Assert.AreEqual(SubmittedBy_Excel, "Submitted By");
                string SubmittedByVal_Excel = Convert.ToString((xlRange.Cells[l, 13] as Excel.Range).Value2);
                string SubmittedByValUi = Gettext(attributeName_xpath, SubmittedBy_ValUi_xpath);
                Assert.AreEqual(SubmittedByVal_Excel, SubmittedByValUi);

                string Status_Excel = Convert.ToString((xlRange.Cells[k, 14] as Excel.Range).Value2);
                Assert.AreEqual(Status_Excel, "Status");
                string StatusVal_Excel = Convert.ToString((xlRange.Cells[l, 14] as Excel.Range).Value2);
                string StatusValUi = Gettext(attributeName_xpath, Status_valUI_xpath);
                Assert.AreEqual(StatusVal_Excel, StatusValUi);

                i++;

            }
            xlWorkbook.Close(0);
            xlApp.Quit();
            xlWorkbook = null;
            xlApp = null;
            DeleteFilesFromFolder(downloadPath);
        }


        [Then(@"I should see an Information Icon I displayed next to only Paid Status")]
        public void ThenIShouldSeeAnInformationIconIDisplayedNextToOnlyPaidStatus()
        {
               string status = "Paid";

                Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
           
                string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
                int Shipmentrowcount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
                if (Shipmentrowcount >= 1 && noReocrdsCheck != "No Results Found")
                {
                    scrollElementIntoView(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[10]");
                    for (int i = 1; i <= Shipmentrowcount; i++)
                       {
                        
                        string Actualstatus = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[10]");
                        if (Actualstatus == status)
                        {
                            VerifyElementPresent(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[10]//button[@class='icon-circle-info icon-i btn btn-info icon-circle']", "InformationIcon");
                        }
                        else
                        {
                            VerifyElementNotPresent(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr["+i+"]/td[10]//button[@class='icon-circle-info icon-i btn btn-info icon-circle']", "Information Icon");
                        }
                    }
                }
                else
                {
                    Report.WriteLine("No records found");
                }
            }
           
        
        [When(@"I click on the sort arrow of the STA/CUS column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheSTACUSColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, StationCustomerColClick_xpath);

        }

        [Then(@"STA/CUS column will be sorted alphabetically based on Customer Name")]
        public void ThenSTACUSColumnWillBeSortedAlphabeticallyBasedOnCustomerName()
        {
            
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1 && noReocrdsCheck!= "No Results Found")
            {
                
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[1]"));
                for (int i=1 ; i <= companyNameColCount.Count; i++)
                {
                    string gg = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr["+i+"]/td[1]");
                    string[] cust = gg.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    string hh = cust[1].ToString();
                    ascSort.Add(hh);
                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
           


        }


        [Then(@"clicking on STA/CUS column arrow again will reverse the sort")]
        public void ThenClickingOnSTACUSColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, StationCustomerColClick_xpath);
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']//tr[@role = 'row']/td[1]"));
                for (int i = 1; i <= companyNameColCount.Count; i++)
                {
                    string gg = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[1]");
                    string[] cust = gg.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    string hh = cust[1].ToString();
                    desSort.Add(hh);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
               
                for (int i = 0; i < companyNameColCount.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the Dates column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheDatesColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, DatesColClick_xpath);
        }


        [Then(@"Dates column will be sorted by most recent date based on Submit date")]
        public void ThenDatesColumnWillBeSortedByMostRecentDateBasedOnSubmitDate()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Dates_ALLValues_xpath));
                for (int i = 1; i <= companyNameColCount.Count; i++)
                {
                    string gg = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[2]");
                    string[] cust = gg.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    string hh = cust[0].ToString();
                    ascSort.Add(hh.Remove(0,5));
                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [Then(@"clicking on Dates column arrow again will reverse the sort")]
        public void ThenClickingOnDatesColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, DatesColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Dates_ALLValues_xpath));
                for (int i = 1; i <= sortedvalues.Count; i++)
                {
                    string gg = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[2]");
                    string[] cust = gg.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    string hh = cust[0].ToString();
                    desSort.Add(hh.Remove(0,5));
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
               
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the Claim \# column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheClaimColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, ClaimNumbersColClick_xpath);
        }


        [Then(@"Claim \# column will be sorted by lowest to highest based on DLSW Claim \#")]
        public void ThenClaimColumnWillBeSortedByLowestToHighestBasedOnDLSWClaim()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWClaimsNumber_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Claim \# column arrow again will reverse the sort")]
        public void ThenClickingOnClaimColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, ClaimNumbersColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWClaimsNumber_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
               
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the Carrier column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheCarrierColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, CarrierColClick_xpath);
        }


        [Then(@"Carrier column should be sorted alphabetically based on Carrier Name")]
        public void ThenCarrierColumnShouldBeSortedAlphabeticallyBasedOnCarrierName()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Clicking on sorting icon");
                

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Carrier_ALLValues_xpath));
                for (int i = 1; i <= companyNameColCount.Count; i++)
                {
                    string gg = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[7]");
                    string[] cust = gg.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    string hh = cust[0].ToString();
                    ascSort.Add(hh);
                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Carrier column arrow again should reverse the sort")]
        public void ThenClickingOnCarrierColumnArrowAgainShouldReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, CarrierColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Carrier_ALLValues_xpath));
                for (int i = 1; i <= sortedvalues.Count; i++)
                {
                    string gg = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + i + "]/td[7]");
                    string[] cust = gg.Split(new[] { "\r\n" }, StringSplitOptions.None);
                    string hh = cust[0].ToString();
                    desSort.Add(hh);
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [When(@"I click on the sort arrow of the Insured column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheInsuredColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, InsuredColClick_xpath);
        }

        [Then(@"Insured column should be sorted alphabetically")]
        public void ThenInsuredColumnShouldBeSortedAlphabetically()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Insured_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Insured column arrow again should reverse the sort")]
        public void ThenClickingOnInsuredColumnArrowAgainShouldReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, InsuredColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Insured_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the Amount column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheAmountColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, AmountColClick_xpath);
        }

        [Then(@"Amount column will be sorted lowest to highest")]
        public void ThenAmountColumnWillBeSortedLowestToHighest()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Amount_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Amount column arrow again should reverse the sort")]
        public void ThenClickingOnAmountColumnArrowAgainShouldReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, AmountColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Amount_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the DLSW Ref \# column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheDLSWRefColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, DLSWRefNumColClick_xpath);
        }

        [Then(@"DLSW Ref \# column should be sorted alphabetically")]
        public void ThenDLSWRefColumnShouldBeSortedAlphabetically()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWRefNumber_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [Then(@"clicking on DLSW Ref \# column arrow again will reverse the sort")]
        public void ThenClickingOnDLSWRefColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, DLSWRefNumColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWRefNumber_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the DLSW Claim Specialist column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheDLSWClaimSpecialistColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, DLSWClaimSpecColClick_xpath);
        }

        [Then(@"DLSW Claim Specialist column will be sorted alphabetically")]
        public void ThenDLSWClaimSpecialistColumnWillBeSortedAlphabetically()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

               
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWClaimSpec_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on DLSW Claim Specialist column arrow again will reverse the sort")]
        public void ThenClickingOnDLSWClaimSpecialistColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, DLSWClaimSpecColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_DLSWClaimSpec_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [When(@"I click on the sort arrow of the Submitted By column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheSubmittedByColumnOnTheClaimListPage()
        {
            Click(attributeName_xpath, SubmittedByColClick_xpath);
        }

        [Then(@"Submitted By column will be sorted alphabetically")]
        public void ThenSubmittedByColumnWillBeSortedAlphabetically()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_SubmittedBy_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Submitted By column arrow again will reverse the sort")]
        public void ThenClickingOnSubmittedByColumnArrowAgainWillReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, SubmittedByColClick_xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_SubmittedBy_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [When(@"I click on the sort arrow of the Status column on the claim list page")]
        public void WhenIClickOnTheSortArrowOfTheStatusColumnOnTheClaimListPage()
        {

            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath);

            Click(attributeName_xpath, ClaimsList_TopGrid_ViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");



            Click(attributeName_xpath, statusColClick_xptah);
        }

        [Then(@"Status column should be sorted alphabetically")]
        public void ThenStatusColumnShouldBeSortedAlphabetically()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {

                Report.WriteLine("Clicking on sorting icon");
                //Click(attributeName_xpath, IntegrationList_SubmitDateClick_Xpath);

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Status_ALLValues_xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                ascSort.Sort();
            }

            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"clicking on Status column arrow again should reverse the sort")]
        public void ThenClickingOnStatusColumnArrowAgainShouldReverseTheSort()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1)
            {
                Click(attributeName_xpath, statusColClick_xptah);
                //Click(attributeName_xpath, statusColClick_xptah);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimsList_Status_ALLValues_xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [Then(@"I will see the status and associated code for Open, Denied and Cancelled status on the claim list page")]
        public void ThenIWillSeeTheStatusAndAssociatedCodeForOpenDeniedAndCancelledStatusOnTheClaimListPage()
        {
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            int row = GetCount(attributeName_xpath, ClaimsList_Station_ALLValues_Xpath);
            if (row >= 1 && noReocrdsCheck != "No Results Found")
            {
                string claimNumberUI = Gettext(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNum_xpath);
                string StatusCodeDB = DBHelper.GetInsuranceStatusCode(Convert.ToInt32(claimNumberUI));

                if (StatusCodeDB == null)
                {
                    Report.WriteLine("Claim Number entered does not have the status code");
                }
                else
                {
                    scrollElementIntoView(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[10]");
                    SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, claimNumberUI);

                    string StatusValUi = Gettext(attributeName_xpath, Status_valUI_xpath);
                    if (StatusValUi.Contains(StatusCodeDB))
                    {
                        Report.WriteLine("Status code is matching with Db");
                    }
                    else
                    {
                        Assert.Fail();
                    }
                }

            }
            else
            {
                Report.WriteLine("No Records found");
            }
        }

        


        [When(@"the grid is larger than the screen size on the claim list page")]
        public void WhenTheGridIsLargerThanTheScreenSizeOnTheClaimListPage()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }


        [Then(@"I will have the horizontal scroll to view the  remaining columns")]
        public void ThenIWillHaveTheHorizontalScrollToViewTheRemainingColumns()
        {
            VerifyElementPresent(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[10]", "Scroll");
        }



    }
}
