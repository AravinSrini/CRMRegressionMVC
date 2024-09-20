using System.Collections.Generic;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using System;
using System.Threading;
using System.Text.RegularExpressions;
using System.Configuration;
using System.Linq;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_CustomReport_DaysPastDueFieldSteps : Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        ClickAndWaitMethods click = new ClickAndWaitMethods();
        string ReportName = Guid.NewGuid().ToString() + "open";
        string gridData;
        bool testDataReport;
        string DaysPastDue = "509";
        string StationName = "ZZZ - Web Services Test";
        string AccountName = "All Accounts";
        int? customReportExistingDaysPastDueValue;

        [Then(@"I have the option to enter the Days Past Due using a numeric control with increments of \+ or - one")]
        public void ThenIHaveTheOptionToEnterTheDaysPastDueUsingANumericControlWithIncrementsOfOr_One()
        {
            Click(attributeName_id, CustomReport_DaysPastDue_Input_Id);
           
            //Increment the dayspastdue by 1
            string daysPastDueValue = IncrementDaysPastDueAndReturnTheValue();
            Assert.AreEqual("1", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue Control has increment of 1");

            //Decrement the dayspastdue by 1
            daysPastDueValue = DecrementDaysPastDueAndReturnTheValue();
            Assert.AreEqual("0", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue Control has decrement of 1");

            daysPastDueValue = DecrementDaysPastDueAndReturnTheValue();
            Assert.AreEqual("0", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue Control does not allow negative numbers");
        }

        [Then(@"I can only enter whole numbers with values of zero or greater")]
        public void ThenICanOnlyEnterWholeNumbersWithValuesOfZeroOrGreater()
        {
            //Check for whole numbers greater than 0
            SendKeys(attributeName_id, CustomReport_DaysPastDue_Input_Id, "1");
            string daysPastDueValue = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
            Assert.AreEqual("1", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue allows whole numbers with values greater than 0");

            //Check for whole number equal to 0
            SendKeys(attributeName_id, CustomReport_DaysPastDue_Input_Id, "0");
            daysPastDueValue = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
            Assert.AreEqual("0", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue allows whole number equal to 0");

            //Check for negative values
            SendKeys(attributeName_id, CustomReport_DaysPastDue_Input_Id, "-1");
            daysPastDueValue = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
            Assert.AreNotEqual("-1", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue does not allow values less than 0");

            //Check for decimal values
            SendKeys(attributeName_id, CustomReport_DaysPastDue_Input_Id, "2.3");
            daysPastDueValue = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
            Assert.AreNotEqual("2.3", daysPastDueValue);
            Report.WriteLine("Verified that the DaysPastDue does not allow decimal numbers");
        }

        [Then(@"I will have the option to enter a numeric Invoice Value formatted as US currency like \$x,xxx\.xx")]
        public void ThenIWillHaveTheOptionToEnterANumericInvoiceValueFormattedAsUSCurrencyLikeXXxx_Xx()
        {
            //Verify formatting for Invoicevalue 
            SendKeys(attributeName_id, CustomReport_InvoiceValue_Input_Id, "100.2");
            Click(attributeName_id, CustomReport_DaysPastDue_Input_Id);
            string invoiceValue = GetValue(attributeName_id, CustomReport_InvoiceValue_Input_Id, "value");

            if ("$100.20" == invoiceValue)
            {
                SendKeys(attributeName_id, CustomReport_InvoiceValue_Input_Id, "100");
                Click(attributeName_id, CustomReport_DaysPastDue_Input_Id);
                invoiceValue = GetValue(attributeName_id, CustomReport_InvoiceValue_Input_Id, "value");

                if ("$100.00" == invoiceValue)
                {
                    SendKeys(attributeName_id, CustomReport_InvoiceValue_Input_Id, "100.23");
                    Click(attributeName_id, CustomReport_DaysPastDue_Input_Id);
                    invoiceValue = GetValue(attributeName_id, CustomReport_InvoiceValue_Input_Id, "value");
                    Assert.AreEqual("$100.23", invoiceValue);
                    Report.WriteLine("Verified that the Invocie value is formatted to currency format");
                }
                else
                {
                    Report.WriteFailure("Verification that the Invocie value is formatted to currency format is failed");
                }
            }
            else
            {
                Report.WriteFailure("Verification that the Invocie value is formatted to currency format is failed");
            }
        }

        [Then(@"The Invoice Value will have a range selector with the following selectors GreaterThan > and LessThan <")]
        public void ThenTheInvoiceValueWillHaveARangeSelectorWithTheFollowingSelectorsGreaterThanAndLessThan()
        {
            Click(attributeName_xpath, CustomReport_CreateReportSection_InvoiceRangeSelector_Selected_Xpath);
            IList<IWebElement> invoiceRangeSelectorDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_CreateReportSection_InvoiceValueRangeSelector_Xpath));

            Assert.AreEqual(2, invoiceRangeSelectorDropdownList.Count);
            Report.WriteLine("Verified that the Invoice Range selector dropdown has 2 options");

            if (invoiceRangeSelectorDropdownList.Count == 2)
            {
                Assert.AreEqual(">", invoiceRangeSelectorDropdownList[0].Text);
                Report.WriteLine("Verified that the Invoice Range selector contains GreaterThan > in dropdown");
                Assert.AreEqual("<", invoiceRangeSelectorDropdownList[1].Text);
                Report.WriteLine("Verified that the Invoice Range selector contains LessThan < in dropdown");
            }
            else
            {
                Report.WriteFailure("Invoice Range selector does not contain > and < values in dropdown");
            }
        }

        [Then(@"Greater than symbol > is selected by default")]
        public void ThenGreaterThanSymbolIsSelectedByDefault()
        {
            string rangeSelector = Gettext(attributeName_xpath, CustomReport_CreateReportSection_InvoiceRangeSelector_Selected_Xpath);
            Assert.AreEqual(">", rangeSelector);
            Report.WriteLine("Verified that the Invoice Range selector dropdown is defaulted to GreaterThan >");
        }

        private string IncrementDaysPastDueAndReturnTheValue()
        {
            Click(attributeName_id, CustomReport_CreateReportSection_UpArrowDaysPastDue_Id);
            string daysPastDueValue = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");
            
            return daysPastDueValue;
        }

        private string DecrementDaysPastDueAndReturnTheValue()
        {
            Click(attributeName_id, CustomReport_CreateReportSection_DownArrowDaysPastDue_Id);
            string daysPastDueValue = GetValue(attributeName_id, CustomReport_DaysPastDue_Input_Id, "value");

            return daysPastDueValue;
        }

        [Given(@"I am on the Create Customer Report Section")]
        public void GivenIAmOnTheCreateCustomerReportSection()
        {            
            bool Expand = IsElementPresent(attributeName_xpath, ".//*[@id='expandCreateCustom']/span", "ExpandCreateCustomReport");
            if (Expand) 
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CustomReportHeaderSection_Xpath);
                Report.WriteLine("Expanded the Create Custom Report section");
            }
        }
        
        [Given(@"I selected Invoice type is Open")]
        public void GivenISelectedInvoiceTypeIsOpen()
        {
            Report.WriteLine("Open is selected by default");
            RadiobuttonChecked(attributeName_xpath, CustomReport_OpenRadioButton_Xpath);
        }

        [Given(@"I entered a value in the DaysPastDue field along with all required fields")]
        public void GivenIEnteredAValueInTheDaysPastDueFieldAlongWithAllRequiredFields()
        {
            scrollpagedown();
            string DaysPastDueData = Regex.Replace(DaysPastDue, @"(<|>)", "");
            Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CreateCustomreport_StationDropdownValue_Xpath, StationName);
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            Click(attributeName_xpath, ReportAccount_Xpath);
            Thread.Sleep(2000);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, AccountName);            
            ScrollToTopElement(attributeName_xpath, CustomReport_DaysPastDueInput_Xpath);
            SendKeys(attributeName_xpath, CustomReport_DaysPastDueInput_Xpath, DaysPastDueData);
        }

        [When(@"I Click on the button Preview/Run")]
        public void WhenIClickOnTheButtonPreviewRun()
        {
            click.ClickAndWait(attributeName_id, CustomReport_Preview_Run_Button_Id);
            scrollpagedown();
        }

        [Then(@"the grid should display invoices with the DaysPastDue equal to or greater than the value entered in the DaysPastDue field in Create Custom Report Section")]
        public void ThenTheGridShouldDisplayInvoicesWithTheDaysPastDueEqualToOrGreaterThanTheValueEnteredInTheDaysPastDueFieldInCreateCustomReportSection()
        {
            Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
            string gridContent = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
            if (gridContent != "No Results Found")
            {
                gridData = "Customer Invoices Grid Loaded with Data";
                IList<IWebElement> invoiceNumberContent = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr/td[6]"));
                foreach(IWebElement invoice in invoiceNumberContent)
                {
                    int i = 1;
                    string dueDate = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[9]");
                    int currentDaysPastDue = (DateTime.UtcNow.Date - Convert.ToDateTime(dueDate)).Days;
                    string daysPastDue = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[12]");
                    Assert.AreEqual(currentDaysPastDue.ToString(), daysPastDue);
                    int daysPastDueValue = Convert.ToInt32(daysPastDue);
                    if (daysPastDueValue >= Convert.ToInt32(DaysPastDue))
                    {
                        Report.WriteLine("Days Past Due value " + daysPastDue + " in the Grid is equal to or greater than " + DaysPastDue + " entered value in the report");

                    }
                    else
                    {
                        Report.WriteFailure("Days Past Due value " + daysPastDue + " in the Grid is not equal to or greater than " + DaysPastDue + " entered value in the report");
                    }

                    i++;
                }
                
            }
            else
            {
                Assert.Fail("Customer Invoices Grid not Loaded with Data");
            }            
        }

        [Given(@"I have Custom Report that includes (.*) criteria")]
        public void GivenIHaveCustomReportThatIncludesCriteria(string DaysPastDueReport)
        {
            DaysPastDueReport = Regex.Replace(DaysPastDueReport, @"(<|>)", "");
            Click(attributeName_xpath, SelectExistingReportDropdown_Xpath);
            IList<IWebElement> totalReport = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']/div/ul/li"));
            testDataReport = totalReport.Select(a => a.Text).Contains(DaysPastDueReport);
            customReportExistingDaysPastDueValue = DBHelper.GetExistingCustomReport_DaysPastDueDays(DaysPastDueReport); 
        }

        [When(@"I Select the Custome Report (.*) from the existing list")]
        public void WhenISelectTheCustomeReportFromTheExistingList(string DaysPastDueReport)
        {
            if (testDataReport)
            {
                DaysPastDueReport = Regex.Replace(DaysPastDueReport, @"(<|>)", "");
                SendKeys(attributeName_xpath, SelectExistingReportDropdown_SearchInputInDropdown_Xpath, DaysPastDueReport);
                Click(attributeName_xpath, SelectExistingReport_SearchedDataSelectInDropdown_Xpath);
            }
            else
            {
                Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CreateCustomreport_StationDropdownValue_Xpath, "ZZZ - Web Services Test");
                SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
                string checkreport = ReportName;
                Click(attributeName_xpath, ReportAccount_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "All Accounts");
                click.ClickAndWait(attributeName_id, CustomReport_Preview_Run_Button_Id);
                Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
                SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
                string grid_Content = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
                if (grid_Content != "No Results Found")
                {
                    gridData = "Customer Invoices Grid Loaded with Data";
                    string daysPastDue1 = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[1]/td[12]");
                    SendKeys(attributeName_xpath, CustomReport_DaysPastDueInput_Xpath, daysPastDue1);
                    Click(attributeName_id, CustomerInvoice_CreateNewButton_Id);
                    Click(attributeName_xpath, SelectExistingReportDropdown_Xpath);
                    SendKeys(attributeName_xpath, SelectExistingReportDropdown_SearchInputInDropdown_Xpath, checkreport);
                    Click(attributeName_xpath, SelectExistingReport_SearchedDataSelectInDropdown_Xpath);

                }
                else
                {
                    Assert.Fail("Customer Invoices Grid not Loaded with Data");
                }
                
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
            string gridContent = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
            if (gridContent != "No Results Found")
            {
                gridData = "Customer Invoices Grid Loaded with Data";
            }
            else
            {
                Assert.Fail("Customer Invoices Grid not Loaded with Data");
            }
        }

        [Then(@"the grid should display invoices with the DaysPastDue equal to or greater than the value entered in the DaysPastDue field in the existing Report Criteria")]
        public void ThenTheGridShouldDisplayInvoicesWithTheDaysPastDueEqualToOrGreaterThanTheValueEnteredInTheDaysPastDueFieldInTheExistingReportCriteria()
        {
            if (gridData == "Customer Invoices Grid Loaded with Data")
            {
                IList<IWebElement> invoiceNumberContent = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr/td[6]"));
                foreach(IWebElement inv in invoiceNumberContent)
                {
                    int i = 1;
                    string dueDate = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[9]");
                    int currentDaysPastDue = (DateTime.UtcNow.Date - Convert.ToDateTime(dueDate)).Days;
                    string daysPastDue = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[12]");
                    Assert.AreEqual(currentDaysPastDue.ToString(), daysPastDue);

                    int daysPastDueValue = Convert.ToInt32(daysPastDue);
                    if (daysPastDueValue >= Convert.ToInt32(customReportExistingDaysPastDueValue))
                    {
                        Report.WriteLine("Days Past Due value " + daysPastDue + " in the Grid is equal to or greater than " + DaysPastDue + " entered value in the report");

                    }
                    else
                    {
                        Report.WriteFailure("Days Past Due value " + daysPastDue + " in the Grid is not equal to or greater than " + DaysPastDue + " entered value in the report");
                    }
                    i++;

                }

            }
            else
            {
                Assert.Fail("Customer Invoices Grid not Loaded with Data");
            }
        }

    }
}
