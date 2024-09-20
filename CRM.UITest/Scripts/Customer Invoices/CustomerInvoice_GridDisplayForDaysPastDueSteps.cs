using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_GridDisplayForDaysPastDueSteps : Customer_Invoice
    {
        string ReportName = Guid.NewGuid().ToString() + "open";
        string gridData = string.Empty;
        bool testDataReport;

        [Given(@"I am a RRDAccess user")]
        public void GivenIAmARRDAccessUser()
        {
            Report.WriteLine("Logging into CRM with an Access RRD user");
            string username = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
       
        [Then(@"any invoices with a due date in the future will show days past due as a negative number")]
        public void ThenAnyInvoicesWithADueDateInTheFutureWillShowDaysPastDueAsANegativeNumber()
        {
            if (gridData == "Grid Loaded with Data")
            {
                IList<IWebElement> invoiceNumberContent = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr/td[6]"));
                for (int i = 1; i <= invoiceNumberContent.Count; i++)
                {
                    string dueDate = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[9]");
                    int todatDays = (DateTime.UtcNow.Date - Convert.ToDateTime(dueDate)).Days;
                    string daysPastDue = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[12]");
                    Assert.AreEqual(todatDays.ToString(), daysPastDue);
                }
            }
            else
            {
                Report.WriteLine("No Data Found in the Customer invoice list Grid");
            }
        }

        [Given(@"I am a User who have access to select existing Custom Report from Customer Invoice Page")]
        public void GivenIAmAUserWhoHaveAccessToSelectExistingCustomReportFromCustomerInvoicePage()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I Select Station (.*)")]
        public void WhenISelectStation(string station)
        {
            station = Regex.Replace(station, @"(<|>)", "");
            Report.WriteLine("Selecting station name");
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id);
            SelectDropdownValueFromList(attributeName_id, CustomerInvoicePage_AccessRRDUser_StationsDropdown_Id, station);
        }

        [When(@"I Select Customer(.*)")]
        public void WhenISelectCustomer(string account)
        {
            account = Regex.Replace(account, @"(<|>)", "");
            Report.WriteLine("Selecting Account name");
            Click(attributeName_xpath, AccessRRDAccountsSearch_xpath);
            Thread.Sleep(2000);
            Click(attributeName_xpath, AccessRRDAccountsSearch_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='AccessRRDAccounts_chosen']/div/ul/li", account);
            Click(attributeName_id, CustomerInvoicePage_AccessRRDUser_DisplayInvoiceButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
            string gridContent = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
            if (gridContent != "No Results Found")
            {
                gridData = "Grid Loaded with Data";
            }
            else
            {
                gridData = "Grid Not Loaded with Data";
            }
        }

        [Given(@"I navigated to Customer invoice page")]
        public void GivenINavigatedToCustomerInvoicePage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }

        [Given(@"I selected any existing Custom Report")]
        public void GivenISelectedAnyExistingCustomReport()
        {
            Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CreateCustomreport_StationDropdownValue_Xpath, "ZZZ - Web Services Test");
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            string checkreport = ReportName;
            Click(attributeName_xpath, ReportAccount_Xpath);
            Thread.Sleep(2000);
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "All Accounts");
            Click(attributeName_id, CustomerInvoice_CreateNewButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SelectExistingReportDropdown_Xpath);
            SendKeys(attributeName_xpath, SelectExistingReportDropdown_SearchInputInDropdown_Xpath, checkreport);
            Click(attributeName_xpath, SelectExistingReport_SearchedDataSelectInDropdown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"the Invoice grid loads")]
        public void WhenTheInvoiceGridLoads()
        {   
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
            string gridContent = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
            if (gridContent != "No Results Found")
            {
                gridData = "Grid Loaded with Data";
            }
            else
            {
                gridData = "Grid Not Loaded with Data";
            }
        }


        [Given(@"I'm a user with access to Customer Invoice Page")]
        public void GivenIMAUserWithAccessToCustomerInvoicePage()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
        }

        [Given(@"I've selected a Station(.*) in Create Custom Report section")]
        public void GivenIVeSelectedAStationInCreateCustomReportSection(string station)
        {
            station = Regex.Replace(station, @"(<|>)", "");
            Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CreateCustomreport_StationDropdownValue_Xpath, station);
        }

        [Given(@"I've selected a Customer(.*) in Create Custom Report section")]
        public void GivenIVeSelectedACustomerInCreateCustomReportSection(string account)
        {
            account = Regex.Replace(account, @"(<|>)", "");
            Click(attributeName_xpath, ReportAccount_Xpath);
            Thread.Sleep(2000);
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            string checkreport = ReportName;
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, account);
        }

        [When(@"I Select Preview/Run button")]
        public void WhenISelectPreviewRunButton()
        {
            Click(attributeName_id, CustomReport_Preview_Run_Button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
            string gridContent = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
            if (gridContent != "No Results Found")
            {
                gridData = "Grid Loaded with Data";
            }
            else
            {
                Assert.Fail("Grid not Loaded with Data");
            }
        }



        [Given(@"I have an existing Custom Report(.*)")]
        public void GivenIHaveAnExistingCustomReport(string Report)
        {
            Report = Regex.Replace(Report, @"(<|>)", "");
            Click(attributeName_xpath, SelectExistingReportDropdown_Xpath);
            IList<IWebElement> totalReport = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']/div/ul/li"));
            testDataReport = totalReport.Select(a => a.Text).Contains(Report);
        }

        [When(@"I Select that Custom Report(.*)")]
        public void WhenISelectThatCustomReport(string Report)
        {
            if(testDataReport)
            {
                Report = Regex.Replace(Report, @"(<|>)", "");
                SendKeys(attributeName_xpath, SelectExistingReportDropdown_SearchInputInDropdown_Xpath, Report);
                Click(attributeName_xpath, SelectExistingReport_SearchedDataSelectInDropdown_Xpath);
            }
            else
            {
                Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CreateCustomreport_StationDropdownValue_Xpath, "ZZZ - Web Services Test");
                SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
                string checkreport = ReportName;
                Click(attributeName_xpath, ReportAccount_Xpath);
                Thread.Sleep(2000);
                Click(attributeName_xpath, ReportAccount_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "All Accounts");
                Click(attributeName_id, CustomerInvoice_CreateNewButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SelectExistingReportDropdown_Xpath);
                SendKeys(attributeName_xpath, SelectExistingReportDropdown_SearchInputInDropdown_Xpath, checkreport);
                Click(attributeName_xpath, SelectExistingReport_SearchedDataSelectInDropdown_Xpath);
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceGridPageViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, CustomerInvoiceGridPageViewDropdownValue_Xpath, "ALL");
            string gridContent = Gettext(attributeName_xpath, CustomerInvoiceGridContentLoadCheck_Xpath);
            if (gridContent != "No Results Found")
            {
                gridData = "Grid Loaded with Data";
            }
            else
            {
                Assert.Fail("Grid not Loaded with Data");
            }
        }

        [Then(@"the Days Past Due value will be Current Date - Due Date for all invoices")]
        public void ThenTheDaysPastDueValueWillBeCurrentDate_DueDateForAllInvoices()
        {
            if (gridData == "Grid Loaded with Data")
            {
                IList<IWebElement> invoiceNumberContent = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr/td[6]"));
                for (int i = 1; i <= invoiceNumberContent.Count; i++)
                {
                    string dueDate = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[9]");
                    int todatDays = (DateTime.UtcNow.Date - Convert.ToDateTime(dueDate)).Days;
                    string daysPastDue = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[12]");
                    Assert.AreEqual(todatDays.ToString(), daysPastDue);
                }
            }
            else
            {
                Assert.Fail("Grid not Loaded with Data");
            }
        }
    }
}
