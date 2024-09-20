using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;


namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_InvoiceNumberHyperlinkSteps: Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesUser()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credenatials");
        }

        [Given(@"I am on the Customer Invoices list page")]
        public void GivenIAmOnTheCustomerInvoicesListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }

        [When(@"I click on any invoice number")]
        public void WhenIClickOnAnyInvoiceNumber()
        {
            int invoicesList = 0;

            invoicesList = GetCount(attributeName_xpath, customerInvoicesGrid_xpath);
            if (invoicesList > 1)
            {
                Click(attributeName_xpath, FirstInvoiceNumber_xpath);
                Report.WriteLine("Clicked on customer invoice number");
            }
            else
            {
                Report.WriteLine("No records");
            }
        }
        
        [Then(@"Invoice will be displayed in new tab of pdf format")]
        public void ThenInvoiceWillBeDisplayedInNewTabOfPdfFormat()
        {
            string configUrl = launchUrl;            
            GlobalVariables.webDriver.WaitForPageLoad();
            WindowHandling(configUrl + "CustomerInvoice/List");
            string cusNum = Gettext(attributeName_xpath, FirstCustomerInvoiceNumber_xpath);
            string invoiceNum = Gettext(attributeName_xpath, FirstInvoiceNumber_xpath);
            string invoiceDate = Gettext(attributeName_xpath, FirstCustomerInvoiceDate_xpath).Replace(@"/", "");            
            string url = configUrl + "CustomerInvoice/ViewCustomerInvoiceDocument?" + "customerNumber=" + cusNum + "&invoiceNumber=" + invoiceNum + "&invoiceDate=" + invoiceDate;
            bool invoiceUrl = WindowHandling(url);
            if (invoiceUrl == true)
            {
                Report.WriteLine("I will be displaying with Customer Invoice Document in New Tab");
            }
            else
            {
                Report.WriteLine("I will not be displaying with Customer Invoice Document in New Tab");
            }
        }
                
        [Then(@"I will receive a message of Invoice not available")]
        public void ThenIWillReceiveAMessageOfInvoiceNotAvailable()
        {
            string configUrl = launchUrl;
            GlobalVariables.webDriver.WaitForPageLoad();
            WindowHandling(configUrl + "CustomerInvoice/List");
            string cusNum = Gettext(attributeName_xpath, FirstCustomerInvoiceNumber_xpath);
            string invoiceNum = Gettext(attributeName_xpath, FirstInvoiceNumber_xpath);
            string invoiceDate = Gettext(attributeName_xpath, FirstCustomerInvoiceDate_xpath).Replace(@"/", "");
            string url = configUrl + "CustomerInvoice/ViewCustomerInvoiceDocument?" + "customerNumber=" + cusNum + "&invoiceNumber=" + invoiceNum + "&invoiceDate=" + invoiceDate;
            bool invoiceUrl = WindowHandling(url);
            if (invoiceUrl == true)
            {
                Report.WriteLine("I will be displaying with Customer Invoice Document in New Tab");
                string errorMessageExp = "Invoice is not Available";
                string errorMessageAct = Gettext(attributeName_xpath, CustomerInvoiceErrorMessage_xpath);
                Assert.AreEqual(errorMessageExp, errorMessageAct);
                Report.WriteLine("I will be displaying with an error message for no invoice");
            }
            else
            {
                Report.WriteLine("I will not be displaying with Customer Invoice Document in New Tab");
            }
            
        }

        [When(@"I click on any invoice number which not exist")]
        public void WhenIClickOnAnyInvoiceNumberWhichNotExist()
        {
            int invoicesList = 0;

            invoicesList = GetCount(attributeName_xpath, customerInvoicesGrid_xpath);
            if (invoicesList > 1)
            {
                SendKeys(attributeName_xpath, Searchbox_xpath, "12345");
                Click(attributeName_xpath, FirstInvoiceNumber_xpath);
                Report.WriteLine("Clicked on customer invoice number");
            }
            else
            {
                Report.WriteLine("No records");
            }
        }

    }
}
