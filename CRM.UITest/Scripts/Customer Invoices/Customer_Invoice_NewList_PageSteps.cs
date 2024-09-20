using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class Customer_Invoice_NewList_PageSteps : Customer_Invoice
    {
        string Expected_FilterField_Verbiage = "Filter displayed invoices...";
        string Expected_Column_SalesRep = "SALES REP";
        string Expected_Column_DueDate = "DUE DATE";
        string Expected_Column_OutstandingAmount = "OUTSTANDING AMOUNT";
        string Options = "10,20,60,100,ALL";
        string ActualColumn_DaysPastDue = null;
        public string stationName = "ZZZ - Web Services Test";
        public string EnterCustomerName = "All Accounts";
        string invoiceNumber = null;


        [Given(@"I am a Ship entry user")]
        public void GivenIAmAShipEntryUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a Operation user")]
        public void GivenIAmAOperationUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I arrive on the Customer Invoices List page")]
        public void GivenIArriveOnTheCustomerInvoicesListPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I arrive on the Customer Invoices list page")]
        public void WhenIArriveOnTheCustomerInvoicesListPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click on the Customer Invoices navigation icon")]
        public void WhenIClickOnTheCustomerInvoicesNavigationIcon()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Then(@"I will arrive on the Customer Invoices list page")]
        public void ThenIWillArriveOnTheCustomerInvoicesListPage()
        {
            Report.WriteLine("I arrive on Customer Invoices List Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            WaitForElementPresent(attributeName_xpath, CustomerInvoices_SalesRep_All_Xpath, "Sales Rep value");

        }

        [Then(@"I will see following Page Elements : Page Header,Filter Field with the verbiage, Filter List Options")]
        public void ThenIWillSeeFollowingPageElementsPageHeaderFilterFieldWithTheVerbiageFilterListOptions()
        {
            Report.WriteLine("I will see the verbiage beneath the header - Review and Pay invoices ");
            Verifytext(attributeName_xpath, CustomerInvoices_Verbage_Xpath, "Review and pay invoices");

            Report.WriteLine("I will see the Filter field with the Verbiage");
            string ActualFiltedField_Verbiage = GetAttribute(attributeName_xpath, CustomerInvoices_FilterField_Verbiage_Xpath, "placeholder");
            Assert.AreEqual(Expected_FilterField_Verbiage, ActualFiltedField_Verbiage);

            Verifytext(attributeName_xpath, CustomerInvoices_FilterList_Display_Xpath, "DISPLAY");

            Verifytext(attributeName_xpath, CustomerInvoices_FilterList_Open_Xpath, "OPEN");
            Verifytext(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath, "CLOSED");
            Verifytext(attributeName_xpath, CustomerInvoices_FilterList_All_Xpath, "ALL");
        }


        [Then(@"I will see following Page Elements : Page Header,Filter Field with the verbiage")]
        public void ThenIWillSeeFollowingPageElementsPageHeaderFilterFieldWithTheVerbiage()
        {
            Report.WriteLine("I will see the verbiage beneath the header - Review and Pay invoices ");
            Verifytext(attributeName_xpath, CustomerInvoices_Verbage_Xpath, "Review and pay invoices");

            Report.WriteLine("I will see the Filter field with the Verbiage");
            string ActualFiltedField_Verbiage = GetAttribute(attributeName_xpath, CustomerInvoices_FilterField_Verbiage_Xpath, "placeholder");
            Assert.AreEqual(Expected_FilterField_Verbiage, ActualFiltedField_Verbiage);
        }


        [Then(@"I Will see the Export Button,Gird Display Option at top and bottom of Grid,Back to Dashboard button")]
        public void ThenIWillSeeTheExportButtonGirdDisplayOptionAtTopAndBottomOfGridBackToDashboardButton()
        {

            Report.WriteLine("I will see the Export Button");
            VerifyElementPresent(attributeName_id, CustomerInvoices_ExportButton_Id, "Export Button");
            Report.WriteLine("I will see the Grid Display Option at Top and Bottom of th Grid");
            // Top of the Grid
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridTop_Showing_xpath, "Showing");
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridTop_View_Xpath, "View:");

            int Totalrecords = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if (Totalrecords > 1)
            {
                string ShowingOF = Gettext(attributeName_xpath, CustomerInvoices_GridTop_Showing_xpath);
                string[] OfRecords = ShowingOF.Split();
                var TotalCountof = OfRecords[5];
                string str1 = TotalCountof.Replace(",", "");

                if (Convert.ToInt32(str1) > 10)
                {
                    Report.WriteLine("Verified Next Page button in Top of Grid");
                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridTop_NextButton_Xpath, "Next Page Button");

                    scrollElementIntoView(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath);

                    Report.WriteLine("Verified Previous Page button in Bottom of Grid");
                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridBottom_NextButton_Xpath, "Next Page Button");

                    scrollPageup();
                    scrollPageup();

                    Click(attributeName_xpath, CustomerInvoices_GridTop_NextButton_Xpath);
                    DefineTimeOut(2000);

                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridTop_PreviousButton_Xpath, "Previous Page Button");

                    scrollElementIntoView(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath);

                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridBottom_PreviousButton_Xpath, "Previous Page Button");
                }
            }
            else
            {
                Report.WriteLine("No records are presence");
            }
            // Bottom of the Grid
            scrollElementIntoView(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath);
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath, "Showing");
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridBottom_View_Xpath, "View:");

            Report.WriteLine("I will see the Back to Dashboard Button");
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_BacktoDashboard_Button_Xpath, "Back to Dashboard");
        }

        [Then(@"I will see the following Column : Sales Rep, Account Number, Customer Number/Name, Invoice Number, Reference ID Number")]
        public void ThenIWillSeeTheFollowingColumnSalesRepAccountNumberCustomerNumberNameInvoiceNumberReferenceIDNumber()
        {
            string ActualSalesRep = Gettext(attributeName_xpath, CustomerInvoices_SalesRep_Xpath);
            Assert.AreEqual(Expected_Column_SalesRep, ActualSalesRep);
            string ActualAccountNumber = Gettext(attributeName_xpath, CustomerInvoices_AccountNumber_Xpath);

            Assert.AreEqual(true, ActualAccountNumber.Contains("ACCOUNT") && ActualAccountNumber.Contains("NUMBER"));

            string ActualCustomerNumberName = Gettext(attributeName_xpath, CustomerInvoices_CustomerNumber_Name_Xpath);
            Assert.AreEqual(true, ActualCustomerNumberName.Contains("CUSTOMER") && ActualCustomerNumberName.Contains("NUMBER/") && ActualCustomerNumberName.Contains("NAME"));

            string ActualCustomerInvoiceNumber = Gettext(attributeName_xpath, CustomerInvoices_InvoiceNumber_Xpath);
            Assert.AreEqual(true, ActualCustomerInvoiceNumber.Contains("INVOICE") && ActualCustomerInvoiceNumber.Contains("NUMBER"));

            string ActualReferenceIdNumber = Gettext(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
            Assert.AreEqual(true, ActualReferenceIdNumber.Contains("REFERENCE") && ActualReferenceIdNumber.Contains("ID NUMBER"));
        }

        [Then(@"I will see the Invoice Date, Due Date, Original Amount, Outstanding Amount, Past Due, Days Past Due, Dispute Code")]
        public void ThenIWillSeeTheInvoiceDateDueDateOriginalAmountCurrentPastDueDaysPastDueDisputeCode()
        {
            string ActualColumn_InvoiceDate = Gettext(attributeName_xpath, CustomerInvoices_InvoiceDate_Xpath);
            Assert.AreEqual(true, ActualColumn_InvoiceDate.Contains("INVOICE") && ActualColumn_InvoiceDate.Contains("DATE"));

            string ActualColumn_DueDate = Gettext(attributeName_xpath, CustomerInvoices_DueDate_Xpath);
            Assert.AreEqual(Expected_Column_DueDate, ActualColumn_DueDate);

            string ActualColumn_OriginalAmount = Gettext(attributeName_xpath, CustomerInvoices_OriginalAmount_Xpath);
            Assert.AreEqual(true, ActualColumn_OriginalAmount.Contains("ORIGINAL") && ActualColumn_OriginalAmount.Contains("AMOUNT"));

            string ActualColumn_OutstandingAmount = Gettext(attributeName_xpath, CustomerInvoices_OutstandingAmount_Xpath);
            Assert.AreEqual(true, ActualColumn_OutstandingAmount.Contains("OUTSTANDING") && ActualColumn_OutstandingAmount.Contains("AMOUNT"));

            string ActualColumn_DaysPastDue = Gettext(attributeName_xpath, CustomerInvoices_DaysPastDue_Xpath);
            Assert.AreEqual(true, ActualColumn_DaysPastDue.Contains("DAYS") && ActualColumn_DaysPastDue.Contains("PAST") && ActualColumn_DaysPastDue.Contains("DUE"));

            string ActualColumn_DisputeCode = Gettext(attributeName_xpath, CustomerInvoices_DisputeCode_Xpath);
            Assert.AreEqual(true, ActualColumn_DisputeCode.Contains("DISPUTE") && ActualColumn_DisputeCode.Contains("CODE"));
        }


        [Then(@"The Following Column Formatting will apply : Invoices Date - Date Format, Due Date - Date Format")]
        public void ThenTheFollowingColumnFormattingWillApplyInvoicesDate_DateFormatDueDate_DateFormat()
        {
            int Totalrecords = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if (Totalrecords > 1)
            {

                Report.WriteLine("Verifying the Date format for the Invoices Date");
                IList<IWebElement> InvoiceDateAll = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_InvoiceDateAll_Xpath));
                int InvoiceDateAllCount = InvoiceDateAll.Count;
                for (int i = 0; i < InvoiceDateAllCount; i++)
                {

                    string Date = InvoiceDateAll[i].Text;

                    string Pattern = @"^(?:(?:(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec))(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:(?:0?2|(?:Feb))(\/|-|\.)(?:29)\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
                    Match result = Regex.Match(Date, Pattern);

                    if (result.Success)
                    {
                        Report.WriteLine("Date Format matched MM/DD/YYYY");
                    }
                    else
                    {
                        Report.WriteLine("Date Format is not matching ");
                    }
                }

                Report.WriteLine("Verifying the Date format for the Due Date");
                IList<IWebElement> DueDateAll = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DueDateAll_Xpath));
                int DueDateAllCount = DueDateAll.Count;
                for (int i = 0; i < DueDateAllCount; i++)
                {
                    string DueDate = DueDateAll[i].Text;

                    string DueDatePattern = @"^(?:(?:(?:0?[13578]|1[02]|(?:Jan|Mar|May|Jul|Aug|Oct|Dec))(\/|-|\.)31)\1|(?:(?:0?[1,3-9]|1[0-2]|(?:Jan|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec))(\/|-|\.)(?:29|30)\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:(?:0?2|(?:Feb))(\/|-|\.)(?:29)\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:(?:0?[1-9]|(?:Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep))|(?:1[0-2]|(?:Oct|Nov|Dec)))(\/|-|\.)(?:0?[1-9]|1\d|2[0-8])\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$";
                    Match result = Regex.Match(DueDate, DueDatePattern);

                    if (result.Success)
                    {
                        Report.WriteLine("Date Format matched MM/DD/YYYY");
                    }
                    else
                    {
                        Report.WriteLine("Date Format is not matching ");
                    }
                }
            }
            else
            {
                Report.WriteLine("Records are not present");
            }
        }

        [Then(@"Original Amount - Currency format, Current - Currency format")]
        public void ThenOriginalAmount_CurrencyFormatCurrent_CurrencyFormat()
        {
            Report.WriteLine("Checking currency format for the Original amount");
            IList<IWebElement> OriginalAmountAll = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_OriginalAmountAll_Xpath));
            int OriginalAmountAllCount = OriginalAmountAll.Count;
            for (int i = 0; i < OriginalAmountAllCount; i++)
            {
                string ActualOriginalAmount = OriginalAmountAll[i].Text;

                if (ActualOriginalAmount.Contains("$"))
                {
                    Report.WriteLine("Original Amount in Currency format");
                    string[] decimals = ActualOriginalAmount.Split('.');
                    int decimalvalue = decimals.Length;
                    if (decimalvalue == 2)
                    {
                        Report.WriteLine("Original Amount is have two decimal places");
                    }
                    else
                    {
                        Report.WriteLine("Invalid");
                    }
                }
                else
                {
                    Report.WriteLine("Original Amount is not in Format");
                }

            }

            Report.WriteLine("Checking Currency format for the Current ");
            IList<IWebElement> CurrentAll = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_CurrentAll_Xpath));
            int CurrentAllCount = CurrentAll.Count;
            for (int i = 0; i < CurrentAllCount; i++)
            {
                string ActualCurrentAmount = CurrentAll[i].Text;

                if (ActualCurrentAmount.Contains("$"))
                {
                    Report.WriteLine("Original Amount in Currency format");
                    string[] decimals = ActualCurrentAmount.Split('.');
                    int decimalvalue = decimals.Length;
                    if (decimalvalue == 2)
                    {
                        Report.WriteLine("Current Amount is have two decimal places");
                    }
                    else
                    {
                        Report.WriteLine("Invalid");
                    }
                }
                else
                {
                    Report.WriteLine("Current Amount is not in Format");
                }
            }
        }

        [Then(@"I will see the Make Payment Button")]
        public void ThenIWillSeeTheMakePaymentButton()
        {
            Report.WriteLine("I will see the Make Payment Button");
            VerifyElementPresent(attributeName_id, CustomerInvoices_MakePayment_Button_Id, "btnMakePayment");
        }

        [Then(@"The Grid Display will Default to ten")]
        public void ThenTheGridDisplayWillDefaultToTen()
        {
            int Expected_View = 10;
            string ActualValue = Gettext(attributeName_xpath, CustomerInvoices_GridTop_View_Xpath);
            // need to check with proper data -
            if (ActualValue == Expected_View.ToString())
            {
                //check the count from the UI
                Report.WriteLine("By Default its showing View : 10");
            }
            else
            {
                Report.WriteLine("Not showing defaulted as 10");
            }
        }

        [Then(@"I have Options to change the Grid Display")]
        public void ThenIHaveOptionsToChangeTheGridDisplay()
        {
            Report.WriteLine("Verifying the options present under view drop down for Top Grid");
            Click(attributeName_xpath, CustomerInvoices_GridTop_Clik_View_Xpath);
            string[] values = Options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_GridTop_Options_Xpath));
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
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view Drop down");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view Drop down is not expected");
                    Assert.IsTrue(false);
                }
            }

        }

        [Then(@"I have the option to advance to the next Page")]
        public void ThenIHaveTheOptionToAdvanceToTheNextPage()
        {
            Report.WriteLine("I have option to advance to the next page");

            int Totalrecords = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if (Totalrecords > 1)
            {
                string ShowingOF = Gettext(attributeName_xpath, CustomerInvoices_GridTop_Showing_xpath);
                string[] OfRecords = ShowingOF.Split();
                string TotalCountof = OfRecords[5];
                string str1 = TotalCountof.Replace(",", "");

                if (Convert.ToInt32(str1) > 10)
                {
                    Report.WriteLine("Verified Next Page button in Top of Grid");
                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridTop_NextButton_Xpath, "Next Page Button");

                }

            }
            Report.WriteLine("No records are Present");
        }

        [Then(@"I have the option to return to a previous page")]
        public void ThenIHaveTheOptionToReturnToAPreviousPage()
        {
            Report.WriteLine("I have option to Return To Previous Page");
            int Totalrecords = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if (Totalrecords > 1)
            {
                string ShowingOF = Gettext(attributeName_xpath, CustomerInvoices_GridTop_Showing_xpath);
                string[] OfRecords = ShowingOF.Split();
                string TotalCountof = OfRecords[5];
                string str1 = TotalCountof.Replace(",", "");

                if (Convert.ToInt32(str1) > 10)
                {
                    Report.WriteLine("Click on Next Page Button");
                    Click(attributeName_xpath, CustomerInvoices_GridTop_NextButton_Xpath);
                    DefineTimeOut(2000);

                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridTop_PreviousButton_Xpath, "Previous Page Button");
                    Click(attributeName_xpath, CustomerInvoices_GridTop_PreviousButton_Xpath);

                }
            }
        }

        [Then(@"The grid options are displayed at the bottom of the grid also")]
        public void ThenTheGridOptionsAreDisplayedAtTheBottomOfTheGridAlso()
        {
            Report.WriteLine("The Displayed Option are displayed at Bottom of the Grid");

            scrollElementIntoView(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath);

            Report.WriteLine("Verifying the options present under view drop down");
            Click(attributeName_xpath, CustomerInvoices_GridBottom_Click_View_Xpath);
            string[] values = Options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_GridBottom_Options_Xpath));
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
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view Drop down");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view Drop down is not expected");
                    Assert.IsTrue(false);
                }
            }


            int Totalrecords = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if (Totalrecords > 1)
            {
                string ShowingOF = Gettext(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath);
                string[] OfRecords = ShowingOF.Split();
                string TotalCountof = OfRecords[5];
                string str1 = TotalCountof.Replace(",", "");

                if (Convert.ToInt32(str1) > 10)

                {
                    Report.WriteLine("I have option to advance to the next page at Bottom of the page");
                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridBottom_NextButton_Xpath, "Next Page Button");

                    scrollPageup();
                    scrollPageup();
                    Click(attributeName_xpath, CustomerInvoices_GridTop_NextButton_Xpath);

                    scrollElementIntoView(attributeName_xpath, CustomerInvoices_GridBottom_Showing_Xpath);

                    Report.WriteLine("I have option to Return To Previous Page at Bottom of the Page");
                    VerifyElementPresent(attributeName_xpath, CustomerInvoices_GridBottom_PreviousButton_Xpath, "Previous Page Button");
                }
            }


        }



        [Then(@"the grid Display label will be hidden")]
        public void ThenTheGridDisplayLabelWillBeHidden()
        {
            VerifyElementNotPresent(attributeName_xpath, CustomerInvoices_FilterList_Display_Xpath, "Display");
        }

        [When(@"I Select Closed radio button under Display options")]
        public void WhenISelectClosedRadioButtonUnderDisplayOptions()
        {
            ActualColumn_DaysPastDue = Gettext(attributeName_xpath, CustomerInvoices_DaysPastDue_Xpath);
            Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected Closed Radio Button");           
        }

        [Then(@"I will no longer see Days Past Due column in the grid")]
        public void ThenIWillNoLongerSeeDaysPastDueColumnInTheGrid()
        {
            VerifyElementNotPresent(attributeName_xpath, CustomerInvoices_DaysPastDueUsingText_Xpath, ActualColumn_DaysPastDue);
            Report.WriteLine("Days Past Due column is removed");
        }
        
        [Then(@"the grid display radio buttons Open and Closed will be hidden")]
        public void ThenTheGridDisplayRadioButtonsOpenAndClosedWillBeHidden()
        {
            VerifyElementNotPresent(attributeName_xpath, CustomerInvoices_FilterList_Open_Xpath, "Open Button");
            VerifyElementNotPresent(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath, "Closed Button");
        }

        [Then(@"The value for this column will be the Cleared Date\(Last Payment Date from Table\) from SAP")]
        public void ThenTheValueForThisColumnWillBeTheClearedDateLastPaymentDateFromTableFromSAP()
        {
            if (Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath) == "No Results Found")
            {
                Report.WriteFailure("Invoices data not available");
            }
            else
            {
                IList<IWebElement> allInvoicesNumbers = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AllInvoiceNumbers_xpath));
                IList<IWebElement> allPaymentDates = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AllPaymentDate_xpath));

                int allInvoicesNumbersCount = allInvoicesNumbers.Count;
                for (int i = 0; i < allInvoicesNumbersCount; i++)
                {

                    invoiceNumber = allInvoicesNumbers[i].Text;
                    CustomerInvoice invoiceNumberDetails = DBHelper.GetCustomerInvoiceDetails(invoiceNumber);
                    string lastPaymentDateUIValue = allPaymentDates[i].Text;
                    if(lastPaymentDateUIValue.Equals(""))
                    {
                        Report.WriteLine("Payment Date value is not available/ blank for Invoice #: " + invoiceNumber);
                        i++;
                    }
                    else
                    {
                        DateTime expectedDdate = Convert.ToDateTime(lastPaymentDateUIValue);
                        Assert.AreEqual(expectedDdate, invoiceNumberDetails.LastPaymentDate);
                    }                                        
                }
            }
        }
    }
}





