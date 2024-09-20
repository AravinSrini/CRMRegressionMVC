using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using System.Data;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_CustomerList_AccessRRDViewUpdateSteps:Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am an RRD Access user logged into CRM")]
        public void GivenIAmAnRRDAccessUserLoggedIntoCRM()
        {
            string userName = ConfigurationManager.AppSettings["username-claimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialist"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [When(@"I arrive on Customer Invoice List page of rrd access user")]
        public void WhenIArriveOnCustomerInvoiceListPageOfRrdAccessUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }


        [When(@"I arrive on Customer Invoice List page")]
        public void WhenIArriveOnCustomerInvoiceListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }
        
        [Then(@"Default display filter will be by Open invoices")]
        public void ThenDefaultDisplayFilterWillBeByOpenInvoices()
        {
            Report.WriteLine("The Default Display filter will be default Unpaid - (OPEN)");
            VerifyElementEnabled(attributeName_xpath, CustomerInvoices_FilterList_Open_Xpath, "Open");
            int invoiceGridRows = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((invoiceGridRows >= 1))
            {
                Report.WriteLine("Records are present in Customer Invoice List");
            }
            else
            {
                Report.WriteLine("No records in Customer Invoice list");
            }
        }

        [Then(@"Default sort will be by Invoice earliest date to latest date")]
        public void ThenDefaultSortWillBeByInvoiceEarliestDateToLatestDate()
        {
            int invoiceGridRows = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            if ((invoiceGridRows >= 1))
            {
                IList<IWebElement> DateSubmittedColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomerInvoices_InvoiceDateAll_Xpath));
                if (DateSubmittedColumn_InitialValues.Count > 0)
                {
                    List<string> InitialDateSubmittedListValues = new List<string>();
                    foreach (IWebElement element in DateSubmittedColumn_InitialValues)
                    {
                        InitialDateSubmittedListValues.Add((element.Text).ToString());
                    }
                    Assert.IsTrue(DateSubmittedColumn_InitialValues.OrderBy(c => c.Text).SequenceEqual(DateSubmittedColumn_InitialValues));
                    Report.WriteLine("Default sort of grid is Invoice earliest date to latest date");
                }
            }
        }
        

        [Then(@"Grid will display StationName column after the Account Number column and prior to the Customer Number/Name column")]
        public void ThenGridWillDisplayStationNameColumnAfterTheAccountNumberColumnAndPriorToTheCustomerNumberNameColumn()
        {
            string ActualColumn_StationName= Gettext(attributeName_xpath, CustomerInvoices_StationName_Xpath);
            string ActualColumnStationName=ActualColumn_StationName.Replace("\n",string.Empty).Replace("\t", string.Empty).Replace("\t", string.Empty).Replace("\r", string.Empty);
            Assert.AreEqual(ActualColumnStationName, "STATIONNAME");
            Report.WriteLine("Grid displaying new StationName column after the Account Number column");
        }
    }
}
