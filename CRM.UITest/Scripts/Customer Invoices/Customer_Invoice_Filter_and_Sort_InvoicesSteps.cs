using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public  class Customer_Invoice_Filter_and_Sort_InvoicesSteps : Customer_Invoice
    {
        string Search_AccountNo = "12345";
      
        [Given(@"I am on the Customer Invoices list Page")]
        public void GivenIAmOnTheCustomerInvoicesListPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("I arrive on Customer Invoices List Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");

            Click(attributeName_xpath, CustomerInvoices_GridTop_Clik_View_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_GridTop_Options_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "ALL")
                {
                    DropDownList[i].Click();
                    break;
                }
            }

        }

        [When(@"I click in the Filter displayed invoices field")]
        public void WhenIClickInTheFilterDisplayedInvoicesField()
        {
            Report.WriteLine("I have option to click on Filter displayed invoices field");
            Click(attributeName_xpath, CustomerInvoices_Filter_Search_Xpath);

        }

        [Then(@"I have option to type in any value")]
        public void ThenIHaveOptionToTypeInAnyValue()
        {
            Report.WriteLine("I enter some value in the field");
            SendKeys(attributeName_xpath, CustomerInvoices_Filter_Search_Xpath, Search_AccountNo);
        }

        [Then(@"Any Displayed rows that contain the values that were entered will be filtered")]
        public void ThenAnyDisplayedRowsThatContainTheValuesThatWereEnteredWillBeFiltered()
        {
            
            Report.WriteLine("Verify that search record should Display if records are presents");
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int records = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            {
                if((records >= 1) && (NoRecordFound != "No Results Found"))
                {
                   
                    IList<IWebElement> InvoiceDateAll = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoives_TotalCustomerNumber_Records_Xpath));
                    int InvoiceDateAllCount = InvoiceDateAll.Count;
                    for (int i = 0; i < InvoiceDateAllCount; i++)
                    {
                        string InoviceNumberFound = InvoiceDateAll[i].Text;
                        if (InoviceNumberFound.ToString().Contains(Search_AccountNo))
                        {
                            Report.WriteLine("Account no are matched with the records");
                        }
                        else
                        {
                            Report.WriteLine("Wrong match found");
                        }
                    }
                }
                else
                {
                    Report.WriteLine("No records found");
                }
            }
            
            
        }

        [Then(@"The default display filter will be by Unpaid invoices")]
        public void ThenTheDefaultDisplayFilterWillBeByUnpaidInvoices()
        {
            Report.WriteLine("The Default Display filter will be default Unpaid - (OPEN)");
            VerifyElementEnabled(attributeName_xpath, CustomerInvoices_FilterList_Open_Xpath, "Open");
        }

        [Then(@"The Default sort will be by Invoice Date and Invoice Date sort will default to earliest date to latest date")]
        public void ThenTheDefaultSortWillBeByInvoiceDateAndInvoiceDateSortWillDefaultToEarliestDateToLatestDate()
        {
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                int i = 0;
                IList<IWebElement> DateSubmittedColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_InvoiceDateAll_Xpath));
                if (DateSubmittedColumn_InitialValues.Count > 0)
                {
                    List<string> InitialDateSubmittedListValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedColumn_InitialValues)
                    {
                        InitialDateSubmittedListValues.Add((element.Text).ToString());
                    }

                    InitialDateSubmittedListValues.Reverse();
                    DefineTimeOut(2000);
                    Click(attributeName_xpath, CustomerInvoices_InvoiceDate_Xpath);
                    IList<IWebElement> DateSubmittedAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_InvoiceDateAll_Xpath));
                    List<string> AscendingSortedDateSubmittedValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedAscendingValues)
                    {
                        AscendingSortedDateSubmittedValues.Add((element.Text).ToString());
                    }

                    if (InitialDateSubmittedListValues[i].Equals(AscendingSortedDateSubmittedValues[i]))
                    {
                        Report.WriteLine("Date Submitted Column is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Date Submitted Column is not in ascending order");

                    }

                    AscendingSortedDateSubmittedValues.Reverse();
                    DefineTimeOut(2000);
                    Click(attributeName_xpath, CustomerInvoices_InvoiceDate_Xpath);
                    IList<IWebElement> DateSubmittedDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_InvoiceDateAll_Xpath));
                    List<string> DescendingSortedDateSubmittedValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedDescendingVlaues)
                    {
                        DescendingSortedDateSubmittedValues.Add((element.Text).ToString());
                    }

                    if (AscendingSortedDateSubmittedValues[i].Equals(DescendingSortedDateSubmittedValues[i]))
                    {
                        Report.WriteLine("Date Submitted is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Date Submitted is not in descending order");

                    }

                }
            }
            else
            {
                Report.WriteLine("No records in Customer Invoice list");
            }
        }



        [When(@"I click on the Paid display filter option")]
        public void WhenIClickOnThePaidDisplayFilterOption()
        {
            Report.WriteLine("Click on the Paid Display filter option");
            Click(attributeName_xpath, CustomerInvoices_FilterList_Closed_Xpath);

        }

        [Then(@"The grid will refresh to display all Paid invoices in which I am associated")]
        public void ThenTheGridWillRefreshToDisplayAllPaidInvoicesInWhichIAmAssociated()
        {
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                Report.WriteLine("Records are presence in Customer Invoice List");

            }
            else
            {
                Report.WriteLine("No records in Customer Invoice list");
            }



        }

        [When(@"I click on the All display filter option")]
        public void WhenIClickOnTheAllDisplayFilterOption()
        {
            Report.WriteLine("Click on the All Displayed filter Option");
            Click(attributeName_xpath, CustomerInvoices_FilterList_All_Xpath);
        }


        [Then(@"the grid will refresh to display all invoices in which I am associated")]
        public void ThenTheGridWillRefreshToDisplayAllInvoicesInWhichIAmAssociated()
        {
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                Report.WriteLine("Records are presence in Customer Invoice List");

            }
            else
            {
                Report.WriteLine("No records in Customer Invoice list");
            }
        }

        [When(@"I click on the sort arrow of Account number")]
        public void WhenIClickOnTheSortArrowOfAccountNumber()
        {
            Report.WriteLine("Click on the Account Number arrow");
            Click(attributeName_xpath, CustomerInvoices_AccountNumber_Xpath);
        }

        [Then(@"The Grid will be sorted as lowest to highest and clicking on Account Number column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedAsLowestToHighestAndClickingOnAccountNumberColumnArrowAgainItWillReverseTheSort()
        {
            int i = 0;
            Report.WriteLine("Verifying the sorting functionality for the Account Number column");
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> AccountNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AccountNumber_All_Xpath));
                if (AccountNumberColumn_InitialValues.Count > 0)
                {
                    List<string> InitialAccountNumberListValues = new List<string>();
                    foreach (IWebElement element in AccountNumberColumn_InitialValues)
                    {
                        InitialAccountNumberListValues.Add((element.Text).ToString());
                    }

                    InitialAccountNumberListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_AccountNumber_Xpath);
                    IList<IWebElement> AccountNumberDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AccountNumber_All_Xpath));
                    List<string> DecendingSortedAccountNumberValues = new List<string>();
                    foreach (IWebElement element in AccountNumberDecendingValues)
                    {
                        DecendingSortedAccountNumberValues.Add((element.Text).ToString());
                    }

                    if (InitialAccountNumberListValues[i].Equals(DecendingSortedAccountNumberValues[i]))
                    {
                        Report.WriteLine("Account  Number Column is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Account Number Column is not in descending order");
                    }

                    DecendingSortedAccountNumberValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_AccountNumber_Xpath);
                    IList<IWebElement> RequestedNumberAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_AccountNumber_All_Xpath));
                    List<string> AscendingSortedRequestedNumberValues = new List<string>();
                    foreach (IWebElement element in RequestedNumberAscendingVlaues)
                    {
                        AscendingSortedRequestedNumberValues.Add((element.Text).ToString());
                    }

                    if (DecendingSortedAccountNumberValues[i].Equals(AscendingSortedRequestedNumberValues[i]))
                    {
                        Report.WriteLine("Account Number is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Account Number is not in ascending order");

                    }

                }
                else
                {
                    Report.WriteLine("No record presence in the Customer Invoice list");
                }

            }
        }


        [When(@"I click on the sort arrow of Invoice number")]
        public void WhenIClickOnTheSortArrowOfInvoiceNumber()
        {
            Report.WriteLine("Click on invoice number arrow");
            Click(attributeName_xpath, CustomerInvoices_InvoiceNumber_Xpath);
        }

        [Then(@"The Grid will be sorted as lowest to highest and clicking on Invoice number column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedAsLowestToHighestAndClickingOnInvoiceNumberColumnArrowAgainItWillReverseTheSort()
        {
            int i = 0;
            Report.WriteLine("Verifying the sorting functionality for the Invoice Number column");
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> InvoiceNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(Customerinvoices_InvoiceNumber_All_Xpath));
                if (InvoiceNumberColumn_InitialValues.Count > 0)
                {
                    List<string> InitialInvoiceNumberListValues = new List<string>();
                    foreach (IWebElement element in InvoiceNumberColumn_InitialValues)
                    {
                        InitialInvoiceNumberListValues.Add((element.Text).ToString());
                    }

                    InitialInvoiceNumberListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_AccountNumber_Xpath);
                    IList<IWebElement> InvioceNumberDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(Customerinvoices_InvoiceNumber_All_Xpath));
                    List<string> DecendingSortedInvoiceNumberValues = new List<string>();
                    foreach (IWebElement element in InvioceNumberDecendingValues)
                    {
                        DecendingSortedInvoiceNumberValues.Add((element.Text).ToString());
                    }

                    if (InitialInvoiceNumberListValues[i].Equals(DecendingSortedInvoiceNumberValues[i]))
                    {
                        Report.WriteLine("Invoice  Number Column is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Invoice Number Column is not in descending order");

                    }

                    DecendingSortedInvoiceNumberValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_AccountNumber_Xpath);
                    IList<IWebElement> RequestedNumberAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(Customerinvoices_InvoiceNumber_All_Xpath));
                    List<string> AscendingSortedInvoiceNumberValues = new List<string>();
                    foreach (IWebElement element in RequestedNumberAscendingVlaues)
                    {
                        AscendingSortedInvoiceNumberValues.Add((element.Text).ToString());
                    }

                    if (DecendingSortedInvoiceNumberValues[i].Equals(AscendingSortedInvoiceNumberValues[i]))
                    {
                        Report.WriteLine("Invoice Number is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Invoice Number is not in ascending order");

                    }

                }
                else
                {
                    Report.WriteLine("No record presence in the Customer Invoice list");
                }

            }
        }


        [When(@"I click on the sort arrow of Reference number")]
        public void WhenIClickOnTheSortArrowOfReferenceNumber()
        {
            Report.WriteLine("Click on Reference number arrow ");
            Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
        }

        [Then(@"The Grid will be sorted as lowest to highest and clicking on Reference number column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedAsLowestToHighestAndClickingOnReferenceNumberColumnArrowAgainItWillReverseTheSort()
        {
            Report.WriteLine("Verifying the sort functionality of the Reference number column");
            int i = 0;
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> ReferenceNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_ReferenceNumber_All_Xpath));
                if (ReferenceNumberColumn_InitialValues.Count > 0)
                {
                    List<string> InitialReferenceNumberListValues = new List<string>();
                    foreach (IWebElement element in ReferenceNumberColumn_InitialValues)
                    {
                        InitialReferenceNumberListValues.Add((element.Text).ToString());
                    }

                    InitialReferenceNumberListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
                    IList<IWebElement> ReferenceNumberDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_ReferenceNumber_All_Xpath));
                    List<string> DecendingSortedReferenceNumberValues = new List<string>();
                    foreach (IWebElement element in ReferenceNumberDecendingValues)
                    {
                        DecendingSortedReferenceNumberValues.Add((element.Text).ToString());
                    }

                    if (InitialReferenceNumberListValues[i].Equals(DecendingSortedReferenceNumberValues[i]))
                    {
                        Report.WriteLine("Reference  Number Column is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Reference Number Column is not in descending order");

                    }

                    DecendingSortedReferenceNumberValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
                    IList<IWebElement> RequestedNumberAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_ReferenceNumber_All_Xpath));
                    List<string> AscendingSortedRequestedNumberValues = new List<string>();
                    foreach (IWebElement element in RequestedNumberAscendingVlaues)
                    {
                        AscendingSortedRequestedNumberValues.Add((element.Text).ToString());
                    }

                    if (DecendingSortedReferenceNumberValues[i].Equals(AscendingSortedRequestedNumberValues[i]))
                    {
                        Report.WriteLine("Reference Number is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Reference  Number is not in ascending order");

                    }

                }
                else
                {
                    Report.WriteLine("No record presence in the Customer Invoice list");
                }

            }

        }


        [When(@"I click on the sort arrow of Days Past Due")]
        public void WhenIClickOnTheSortArrowOfDaysPastDue()
        {
            Report.WriteLine("Click on Days Past Due column Arrow");
            Click(attributeName_xpath, CustomerInvoices_DaysPastDue_Xpath);
        }


        [Then(@"The Grid will be sorted as lowest to highest and clicking on Days Past Due column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedAsLowestToHighestAndClickingOnDaysPastDueColumnArrowAgainItWillReverseTheSort()
        {
            Report.WriteLine("Verifying the sort functionality of the Days Past Due column");
            int i = 0;
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> DaysPastDueColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DaysPastDue_All_Xpath));
                if (DaysPastDueColumn_InitialValues.Count > 0)
                {
                    List<string> InitialDaysPastDueListValues = new List<string>();
                    foreach (IWebElement element in DaysPastDueColumn_InitialValues)
                    {
                        InitialDaysPastDueListValues.Add((element.Text).ToString());
                    }

                    InitialDaysPastDueListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
                    IList<IWebElement> DaysPastDueDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DaysPastDue_All_Xpath));
                    List<string> DecendingSortedDaysPastDueValues = new List<string>();
                    foreach (IWebElement element in DaysPastDueDecendingValues)
                    {
                        DecendingSortedDaysPastDueValues.Add((element.Text).ToString());
                    }

                    if (InitialDaysPastDueListValues[i].Equals(DecendingSortedDaysPastDueValues[i]))
                    {
                        Report.WriteLine("Reference  Number Column is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Reference Number Column is not in descending order");

                    }

                    DecendingSortedDaysPastDueValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
                    IList<IWebElement> PastDueDateAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DaysPastDue_All_Xpath));
                    List<string> AscendingSortedRequestedNumberValues = new List<string>();
                    foreach (IWebElement element in PastDueDateAscendingVlaues)
                    {
                        AscendingSortedRequestedNumberValues.Add((element.Text).ToString());
                    }

                    if (DecendingSortedDaysPastDueValues[i].Equals(AscendingSortedRequestedNumberValues[i]))
                    {
                        Report.WriteLine("Reference Number is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Reference  Number is not in ascending order");

                    }

                }
                else
                {
                    Report.WriteLine("No record presence in the Customer Invoice list");
                }

            }
        }

        [When(@"I click on the sort arrow of Dispute Code")]
        public void WhenIClickOnTheSortArrowOfDisputeCode()
        {
            Report.WriteLine("Click on the Dispute Code Column arrow");
            Click(attributeName_xpath, CustomerInvoices_DisputeCode_Xpath);
        }

        [Then(@"The Grid will be sorted as lowest to highest and clicking on Dispute Code  column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedAsLowestToHighestAndClickingOnDisputeCodeColumnArrowAgainItWillReverseTheSort()
        {
            Report.WriteLine("Verifying the sort functionality of the Dispute Code column");
            int i = 0;
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> DisputeCodeColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DisputeCode_All_Xpath));
                if (DisputeCodeColumn_InitialValues.Count > 0)
                {
                    List<string> InitialDisputeCodeListValues = new List<string>();
                    foreach (IWebElement element in DisputeCodeColumn_InitialValues)
                    {
                        InitialDisputeCodeListValues.Add((element.Text).ToString());
                    }

                    InitialDisputeCodeListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
                    IList<IWebElement> DisputeCodeDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DisputeCode_All_Xpath));
                    List<string> DecendingSortedDisputeCodeValues = new List<string>();
                    foreach (IWebElement element in DisputeCodeDecendingValues)
                    {
                        DecendingSortedDisputeCodeValues.Add((element.Text).ToString());
                    }

                    if (InitialDisputeCodeListValues[i].Equals(DecendingSortedDisputeCodeValues[i]))
                    {
                        Report.WriteLine("Reference  Number Column is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Reference Number Column is not in descending order");

                    }

                    DecendingSortedDisputeCodeValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_ReferenceIDNumber_Xpath);
                    IList<IWebElement> DisputeCodeAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DisputeCode_All_Xpath));
                    List<string> AscendingSortedDisputeCodeValues = new List<string>();
                    foreach (IWebElement element in DisputeCodeAscendingVlaues)
                    {
                        AscendingSortedDisputeCodeValues.Add((element.Text).ToString());
                    }

                    if (DecendingSortedDisputeCodeValues[i].Equals(AscendingSortedDisputeCodeValues[i]))
                    {
                        Report.WriteLine("Reference Number is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Reference  Number is not in ascending order");

                    }

                }
                else
                {
                    Report.WriteLine("No record presence in the Customer Invoice list");
                }

            }
        }


        [When(@"I click on the sort arrow of Sales Rep")]
        public void WhenIClickOnTheSortArrowOfSalesRep()
        {
            Report.WriteLine("Click on Sales Rep Column arrow");
            Click(attributeName_xpath, CustomerInvoices_SalesRep_Xpath);
        }

        [Then(@"The Grid will be sorted as alphabetically and clicking on Sales Rep column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedAsAlphabeticallyAndClickingOnSalesRepColumnArrowAgainItWillReverseTheSort()
        {
            Report.WriteLine("Verifying the Sort functionality for the Sales Rep Column");
            int i = 0;
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {

                IList<IWebElement> SalesRepColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_SalesRep_All_Xpath));
                if (SalesRepColumn_InitialValues.Count > 0)
                {
                    List<string> InitialSalesRepListValues = new List<string>();
                    foreach (IWebElement element in SalesRepColumn_InitialValues)
                    {
                        InitialSalesRepListValues.Add((element.Text).ToString());
                    }

                    InitialSalesRepListValues.Sort();
                    Click(attributeName_xpath, CustomerInvoices_SalesRep_Xpath);
                    IList<IWebElement> SalesRepAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_SalesRep_All_Xpath));
                    List<string> AscendingSortedSalesRepValues = new List<string>();
                    foreach (IWebElement element in SalesRepAscendingValues)
                    {
                        AscendingSortedSalesRepValues.Add((element.Text).ToString());
                    }

                    if (InitialSalesRepListValues[i].Equals(AscendingSortedSalesRepValues[i]))
                    {
                        Report.WriteLine("Carrier Name Column is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Carrier Name Column is not in ascending order");

                    }

                    AscendingSortedSalesRepValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_SalesRep_Xpath);
                    IList<IWebElement> SalesRepDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_SalesRep_All_Xpath));
                    List<string> DescendingSortedSalesRepValues = new List<string>();
                    foreach (IWebElement element in SalesRepDescendingVlaues)
                    {
                        DescendingSortedSalesRepValues.Add((element.Text).ToString());
                    }

                    if (AscendingSortedSalesRepValues[i].Equals(DescendingSortedSalesRepValues[i]))
                    {
                        Report.WriteLine("Carrier Name is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Carrier Name is not in descending order");

                    }

                }
            }
        }


        [When(@"I click on the sort arrow of Due Date column")]
        public void WhenIClickOnTheSortArrowOfDueDateColumn()
        {
            Report.WriteLine("Click on the Due Date Column");
            Click(attributeName_xpath, CustomerInvoices_DueDate_Xpath);
        }


        [Then(@"The grid will be sorted from earliest date to latest date and clicking on Due Date Column arrow again it will reverse the sort")]
        public void ThenTheGridWillBeSortedFromEarliestDateToLatestDateAndClickingOnDueDateColumnArrowAgainItWillReverseTheSort()
        {
            Report.WriteLine("Verifying the Due Date column sort functionality");

            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                int i = 0;
                IList<IWebElement> DateSubmittedColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DueDateAll_Xpath));
                if (DateSubmittedColumn_InitialValues.Count > 0)
                {
                    List<string> InitialDateSubmittedListValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedColumn_InitialValues)
                    {
                        InitialDateSubmittedListValues.Add((element.Text).ToString());
                    }

                    InitialDateSubmittedListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_DueDate_Xpath);
                    IList<IWebElement> DateSubmittedAscendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DueDateAll_Xpath));
                    List<string> AscendingSortedDateSubmittedValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedAscendingValues)
                    {
                        AscendingSortedDateSubmittedValues.Add((element.Text).ToString());
                    }

                    if (InitialDateSubmittedListValues[i].Equals(AscendingSortedDateSubmittedValues[i]))
                    {
                        Report.WriteLine("Date Submitted Column is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Date Submitted Column is not in ascending order");

                    }

                    AscendingSortedDateSubmittedValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_DueDate_Xpath);
                    IList<IWebElement> DateSubmittedDescendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_DueDateAll_Xpath));
                    List<string> DescendingSortedDateSubmittedValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedDescendingVlaues)
                    {
                        DescendingSortedDateSubmittedValues.Add((element.Text).ToString());
                    }

                    if (AscendingSortedDateSubmittedValues[i].Equals(DescendingSortedDateSubmittedValues[i]))
                    {
                        Report.WriteLine("Date Submitted is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Date Submitted is not in descending order");

                    }

                }
            }
            else
            {
                Report.WriteLine("No records in Customer Invoice list");
            }
        }

        [When(@"I click on the Customer Number/Name column filter arrow once")]
        public void WhenIClickOnTheCustomerNumberNameColumnFilterArrowOnce()
        {
            Report.WriteLine("Click on the Customer Number / Name Arrow");
            Click(attributeName_xpath, CustomerInvoices_CustomerNumber_Name_Xpath);
        }

        [Then(@"Verify grid will be sorted as lowest to highest and clicking on Customer Number / Name arrow again it will reverse the sort")]
        public void ThenVerifyGridWillBeSortedAsLowestToHighestAndClickingOnCustomerNumberNameArrowAgainItWillReverseTheSort()
        {
            Report.WriteLine("Verifying the sort functionality of the Customer Number / Customer Name column");
            int i = 0;
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((row >= 1) && (NoRecordFound != "No Results Found"))
            {
                IList<IWebElement> CustomerNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoives_TotalCustomerNumber_Records_Xpath));
                if (CustomerNumberColumn_InitialValues.Count > 0)
                {
                    List<string> InitialCustomerNumberListValues = new List<string>();
                    foreach (IWebElement element in CustomerNumberColumn_InitialValues)
                    {
                        InitialCustomerNumberListValues.Add((element.Text).ToString());
                    }

                    InitialCustomerNumberListValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_CustomerNumber_Name_Xpath);
                    IList<IWebElement> CustomerNumberDecendingValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoives_TotalCustomerNumber_Records_Xpath));
                    List<string> DecendingSortedCustomerNumberValues = new List<string>();
                    foreach (IWebElement element in CustomerNumberDecendingValues)
                    {
                        DecendingSortedCustomerNumberValues.Add((element.Text).ToString());
                    }

                    if (InitialCustomerNumberListValues[i].Equals(DecendingSortedCustomerNumberValues[i]))
                    {
                        Report.WriteLine("Customer  Number Column is in descending Order");

                    }
                    else
                    {
                        Report.WriteLine("Customer Number Column is not in descending order");

                    }

                    DecendingSortedCustomerNumberValues.Reverse();
                    Click(attributeName_xpath, CustomerInvoices_CustomerNumber_Name_Xpath);
                    IList<IWebElement> CustomerNumberAscendingVlaues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoives_TotalCustomerNumber_Records_Xpath));
                    List<string> AscendingSortedCustomerNumberValues = new List<string>();
                    foreach (IWebElement element in CustomerNumberAscendingVlaues)
                    {
                        AscendingSortedCustomerNumberValues.Add((element.Text).ToString());
                    }

                    if (DecendingSortedCustomerNumberValues[i].Equals(AscendingSortedCustomerNumberValues[i]))
                    {
                        Report.WriteLine("Customer Number  is in ascending Order");

                    }
                    else
                    {
                        Report.WriteLine("Customer Number  is not in ascending order");

                    }

                }
                else
                {
                    Report.WriteLine("No record presence in the Customer Invoice list");
                }

            }
        }




    }
}
