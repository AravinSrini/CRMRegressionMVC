using CRM.UITest.Entities;
using CRM.UITest.Objects;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.Maintenance_Tools.Product_Protection_Setting
{
    [Binding]
    public class MaintenanceToolsProductProtectionFunctionality_Delete_Export_CustomersSteps : ObjectRepository
    {
      
        [Then(@"I will be able to see the presence of Delete button for Deleting the Customer Account from the Grid (.*), (.*)")]
        public void ThenIWillBeAbleToSeeThePresenceOfDeleteButtonForDeletingTheCustomerAccountFromTheGrid(string StationName, string CustomerAccount)
        {
            scrollpagedown();
            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {
                VerifyElementPresent(attributeName_xpath, DeleteButtuon1_GridList_Xpath, "Delete button");
                Click(attributeName_xpath, ".//*[@id='ShipmentService_length']/label/select");
                SelectDropdownlistvalue(attributeName_xpath, ".//*[@id='ShipmentService_length']/label/select/option", "ALL");
                IList<IWebElement> AllDeleteButton_list = (GlobalVariables.webDriver.FindElements(By.XPath(AllDeleteButton_Grid_Xpath)));
                IList<IWebElement> AllCustomerAccount_Grid_List = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
                Assert.AreEqual(AllDeleteButton_list.Count, AllCustomerAccount_Grid_List.Count);
            }
            else
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                Report.WriteLine("Verifying the Presence Delete button");
                VerifyElementPresent(attributeName_xpath, DeleteButtuon1_GridList_Xpath, "Delete button");
            }
        }

        [Then(@"I will be able to see the presence of Ok and Cancel button in the Delete confirmation popup upon click on Delete button (.*), (.*)")]
        public void ThenIWillBeAbleToSeeThePresenceOfOkAndCancelButtonInTheDeleteConfirmationPopupUponClickOnDeleteButton(string StationName, string CustomerAccount)
        {
            scrollpagedown();
            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {
                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
                VerifyElementPresent(attributeName_xpath, OkButton_DeletePopUp_Xpath, "Ok button");
                VerifyElementPresent(attributeName_xpath, CancelButton_DeletePopUp_Xpath, "Cancel button");
            }
            else
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                Report.WriteLine("Verifying Ok and Cancel button in the Delete Confirmation PopUp");
                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
                VerifyElementPresent(attributeName_xpath, OkButton_DeletePopUp_Xpath, "Ok button");
                VerifyElementPresent(attributeName_xpath, CancelButton_DeletePopUp_Xpath, "Cancel button");
            }
        }

        [Then(@"I will be able to see presence of Delete Confirmation Message in Delete Confirmation PopUp upon clicking on Delete button (.*), (.*)")]
        public void ThenIWillBeAbleToSeePresenceOfDeleteConfirmationMessageInDeleteConfirmationPopUpUponClickingOnDeleteButton(string StationName, string CustomerAccount)
        {
            scrollpagedown();
            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {
                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
                string Expected_DeleteConfirmation_Text = "Are you sure you want to delete the Product Protection Settings?";
                WaitForElementVisible(attributeName_xpath, DeleteConfirmationText_Xpath, "Are you sure you want to delete the Product Protection Settings?");
                string DeleteConfirmation_Text_UI = Gettext(attributeName_xpath, DeleteConfirmationText_Xpath);
                Assert.AreEqual(Expected_DeleteConfirmation_Text, DeleteConfirmation_Text_UI);
            }
            else
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                WaitForElementVisible(attributeName_id, PPCustomer_SaveButton_Id, "Save Button");
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                Report.WriteLine("Verifying Delete Confirmation PopUp");
                Report.WriteLine("Verifying Delete Confirmation Message");
                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
                string Expected_DeleteConfirmation_Text = "Are you sure you want to delete the Product Protection Settings?";
                WaitForElementVisible(attributeName_xpath, DeleteConfirmationText_Xpath, "Are you sure you want to delete the Product Protection Settings?");
                string DeleteConfirmation_Text_UI = Gettext(attributeName_xpath, DeleteConfirmationText_Xpath);
                Assert.AreEqual(Expected_DeleteConfirmation_Text, DeleteConfirmation_Text_UI);
            }

        }

        [Then(@"I clicked on the cancel button from the Delete Confirmation PopUp then the Corresponding Customer Account will not be deleted from the Product Protection Grid (.*), (.*)")]
        public void ThenIClickedOnTheCancelButtonFromTheDeleteConfirmationPopUpThenTheCorrespondingCustomerAccountWillNotBeDeletedFromTheProductProtectionGrid(string StationName, string CustomerAccount)
        {
            scrollpagedown();
            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {
                int i = 1;
                string CustomerAccount_A_UI = Gettext(attributeName_xpath, "//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[1]");
                Click(attributeName_xpath, ".//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[5]/button");
                WaitForElementVisible(attributeName_xpath, CancelButton_DeletePopUp_Xpath, "CancelButton");
                Click(attributeName_xpath, CancelButton_DeletePopUp_Xpath);
                string CustomerAccount_B_UI = Gettext(attributeName_xpath, "//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[1]");
                Assert.AreEqual(CustomerAccount_A_UI, CustomerAccount_B_UI);

            }
            else
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);

                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                Report.WriteLine("Verifying Delete Confirmation PopUp");
                Report.WriteLine("Verifying Delete Confirmation Message");
                int i = 1;
                WaitForElementVisible(attributeName_xpath, ".//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[5]/button", "Delete Button1");
                string CustomerAccount_A_UI = Gettext(attributeName_xpath, "//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[1]");
                Click(attributeName_xpath, ".//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[5]/button");
                WaitForElementVisible(attributeName_xpath, CancelButton_DeletePopUp_Xpath, "Cancel button");
                Click(attributeName_xpath, CancelButton_DeletePopUp_Xpath);
                string CustomerAccount_B_UI = Gettext(attributeName_xpath, "//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[1]");
                Assert.AreEqual(CustomerAccount_A_UI, CustomerAccount_B_UI);
            }
        }

        [Then(@"I clicked on the Ok button from the Delete Confirmation PopUp then the Corresponding Customer Account will be deleted from the Product Protection Grid (.*), (.*)")]
        public void ThenIClickedOnTheOkButtonFromTheDeleteConfirmationPopUpThenTheCorrespondingCustomerAccountWillBeDeletedFromTheProductProtectionGrid(string StationName, string CustomerAccount)
        {
            scrollpagedown();
            string CustomerName_UI = null;
            Click(attributeName_cssselector, StationDropdown_CSS);
            SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);

            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {
                CustomerName_UI = Gettext(attributeName_xpath, CustomerName1_GridList_Xpath);
                string _expected_Customer = CustomerName_UI;
                string StationName_UI = Gettext(attributeName_xpath, StationName1_GridList_Xpath);

                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
                WaitForElementVisible(attributeName_xpath, OkButton_DeletePopUp_Xpath, "Ok Button");
                Click(attributeName_xpath, OkButton_DeletePopUp_Xpath);
                Thread.Sleep(2000);
                scrollPageup();
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName_UI);
                Click(attributeName_xpath, CustomerAccount_SearchBox_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerName_UI);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                string _Actual_Customer = Gettext(attributeName_xpath, smallAc_Xpath);
                Report.WriteLine("Customer Deleted from PP and it can be selected as again PP");
                Assert.AreEqual(_expected_Customer, _Actual_Customer);
            }

            else
            {
                Click(attributeName_xpath, CustomerAccount_SearchBox_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                string CustomerName_Test = CustomerAccount;
                string Expected_Customer = CustomerName_Test;
                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
                WaitForElementVisible(attributeName_xpath, OkButton_DeletePopUp_Xpath, "Ok Button");
                Click(attributeName_xpath, OkButton_DeletePopUp_Xpath);
                Thread.Sleep(2000);
                scrollPageup();
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, CustomerAccount_SearchBox_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerName_Test);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                string Actual_Customer = Gettext(attributeName_xpath, smallAc_Xpath);
                Report.WriteLine("Customer Deleted from PP and it can be selected as again PP");
                Assert.AreEqual(Expected_Customer, Actual_Customer);
                Report.WriteLine("Customer Deleted from PP and it can be Used to select again as PP Customer");
            }
        }

        [Then(@"I will be able to verify the Default Insurance All value from the Database for the Deleted Customer (.*), (.*)")]
        public void ThenIWillBeAbleToVerifyTheDefaultInsuranceAllValueFromTheDatabaseForTheDeletedCustomer(string StationName, string CustomerAccount)
        {
            scrollpagedown();
            string CustomerAccount_A_UI = null;
            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {
                int i = 0;
                CustomerAccount_A_UI = Gettext(attributeName_xpath, CustomerName1_GridList_Xpath);
                Click(attributeName_xpath, DeleteButtuon1_GridList_Xpath);
				Thread.Sleep(1000);
                Click(attributeName_xpath, OkButton_DeletePopUp_Xpath);
            }
            else
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                int i = 0;
                CustomerAccount_A_UI = Gettext(attributeName_xpath, "//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[1]");
                Click(attributeName_xpath, ".//*[@id='ShipmentService']/tbody/tr[" + i + "]/td[5]/button");
                Click(attributeName_xpath, OkButton_DeletePopUp_Xpath);
            }
            CustomerAccount Acc_B = DBHelper.IsDefaultInsAll(CustomerAccount_A_UI);
            Assert.IsTrue(Acc_B.IsDefaultInsAll);
        }

        [Then(@"I will be able to see presence of Export button")]
        public void ThenIWillBeAbleToSeePresenceOfExportButton()
        {
            scrollpagedown();
            VerifyElementPresent(attributeName_xpath, PPExportButton_Text_Xpath, "Export button");
        }

        [Then(@"I able to see the Exported Customer Account count in Excel and the Grid Count same when clicking on the Export button (.*), (.*),(.*)")]
        public void ThenIAbleToSeeTheExportedCustomerAccountCountInExcelAndTheGridCountSameWhenClickingOnTheExportButton(string StationName, string CustomerAccount, string PPPCustomersExcel)
        {
            scrollpagedown();
            Click(attributeName_xpath, ".//*[@id='ShipmentService_length']/label/select");
            SelectDropdownlistvalue(attributeName_xpath, ".//*[@id='ShipmentService_length']/label/select/option", "ALL");

            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count > 0)
            {

                List<string> UIvalue = IndividualColumnData(".//*[@id='ShipmentService']/tbody/tr/td[1]");
                string downloadpath = null;
                Click(attributeName_xpath, PPExportButton_Text_Xpath);
                downloadpath = GetDownloadedFilePath(PPPCustomersExcel);
                List<string> rowValue = new List<string> { };
                Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                if (UIvalue.Count == rowCount - 1)
                {
                    Report.WriteLine("Grid Count and Excel Count are Matched");
                }
                else
                {
                    throw new Exception("Grid Count and Excel Count are not Matched");
                }
                xlWorkbook.Close(0);
                xlApp.Quit();

                DeleteFilesFromFolder(downloadpath);
            }

            else
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);

                List<string> UIvalue = IndividualColumnData(".//*[@id='ShipmentService']/tbody/tr/td[1]");
                string downloadpath = null;
                Click(attributeName_xpath, PPExportButton_Text_Xpath);

                downloadpath = GetDownloadedFilePath(PPPCustomersExcel);
                List<string> rowValue = new List<string> { };
                Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                if (UIvalue.Count == rowCount - 1)
                {
                    Console.WriteLine("Grid Count and Excel Count are Matched");
                }
                else
                {
                    throw new Exception("Grid Count and Excel Count are not Matched");
                }
                xlWorkbook.Close(0);
                xlApp.Quit();

                DeleteFilesFromFolder(downloadpath);
            }
        }

        [Then(@"I able to see the Exported Customer Account Matches with the Grid (.*), (.*),(.*)")]
        public void ThenIAbleToSeeTheExportedCustomerAccountMatchesWithTheGrid(string StationName, string CustomerAccount, string PPPCustomerscontent)
        {
            scrollpagedown();
            Click(attributeName_xpath, ".//*[@id='ShipmentService_length']/label/select");
            SelectDropdownlistvalue(attributeName_xpath, ".//*[@id='ShipmentService_length']/label/select/option", "ALL");

            IList<IWebElement> PPCustomerGridList = (GlobalVariables.webDriver.FindElements(By.XPath(PPAllCustomerName_Xpath)));
            if (PPCustomerGridList.Count == 0)
            {
                Click(attributeName_cssselector, StationDropdown_CSS);
                SelectDropdownValueFromList(attributeName_xpath, StationDropdown_values_Xpath, StationName);
                Click(attributeName_xpath, searchinput_Xpath);
                SendKeys(attributeName_xpath, searchinput_Xpath, CustomerAccount);
                Click(attributeName_xpath, searchIput1stselect_Xpath);
                Click(attributeName_id, PPCustomer_SaveButton_Id);
                Thread.Sleep(10000);
                string downloadpath = null;
                Click(attributeName_xpath, PPExportButton_Text_Xpath);

                downloadpath = GetDownloadedFilePath(PPPCustomerscontent);
                List<string> rowValue = new List<string> { };
                Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;
                int i = 0;


                for (int k = 2; k < 3; k++)
                {
                    int count = i + 1;

                    string _CustomerName_Excel = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                    string _CustomerName_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[1]")).Text;
                    Assert.AreEqual(_CustomerName_Excel, _CustomerName_UI);

                    string _StationId_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                    string _StationId_Excel_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[2]")).Text;
                    Assert.AreEqual(_StationId_Excel, _StationId_Excel_UI);


                    string _StationName_Excel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                    string _StationName_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[3]")).Text;
                    Assert.AreEqual(_StationName_Excel, _StationName_UI);

                    string _Date_Excel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                    string _Date_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[4]")).Text;
                    Assert.AreEqual(_Date_Excel, _Date_UI);

                    i++;
                }
                xlWorkbook.Close(0);
                xlApp.Quit();
                DeleteFilesFromFolder(downloadpath);
            }

            if (PPCustomerGridList.Count >= 1)
            {
                List<string> UIvalue = IndividualColumnData(".//*[@id='ShipmentService']/tbody/tr/td[1]");
                string downloadpath = null;
                Click(attributeName_xpath, PPExportButton_Text_Xpath);

                int i = 0;

                downloadpath = GetDownloadedFilePath(PPPCustomerscontent);
                List<string> rowValue = new List<string> { };
                Microsoft.Office.Interop.Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(downloadpath);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                for (int k = 2; k < 3; k++)
                {
                    int count = i + 1;
                    //Verifying Excel content and Grid content for one Account
                    string _CustomerName_Excel = Convert.ToString((xlRange.Cells[k, 1] as Excel.Range).Value2);
                    string _CustomerName_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[1]")).Text;
                    Assert.AreEqual(_CustomerName_Excel, _CustomerName_UI);

                    string _StationId_Excel = Convert.ToString((xlRange.Cells[k, 2] as Excel.Range).Value2);
                    string _StationId_Excel_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[2]")).Text;
                    Assert.AreEqual(_StationId_Excel, _StationId_Excel_UI);


                    string _StationName_Excel = Convert.ToString((xlRange.Cells[k, 3] as Excel.Range).Value2);
                    string _StationName_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[3]")).Text;
                    Assert.AreEqual(_StationName_Excel, _StationName_UI);

                    string _Date_Excel = Convert.ToString((xlRange.Cells[k, 4] as Excel.Range).Value2);
                    string _Date_UI = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='ShipmentService']/tbody/tr[" + count.ToString() + "]/td[4]")).Text;
                    Assert.AreEqual(_Date_Excel, _Date_UI);

                    i++;
                }
                xlWorkbook.Close(0);
                xlApp.Quit();
                DeleteFilesFromFolder(downloadpath);
            }
        }
    }
}
