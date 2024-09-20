using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CRMCustomerInvoice_RemoveLoadingInvoicesOnInitialLaunchSteps : Customer_Invoice
    {
       
        //[When(@"I navigate to the customer invoice page")]
        //public void WhenINavigateToTheCustomerInvoicePage()
        //{
        //    Click(attributeName_xpath, customerInvoiceIcon_xpath);
        //    Report.WriteLine("Clicked on Customer Invoice button");
        //    VerifyElementPresent(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
        //    Report.WriteLine("Navigated to Customer Invoice page");
        //}
        
        [Then(@"invoices will no longer load on page load")]
        public void ThenInvoicesWillNoLongerLoadOnPageLoad()
        {
            scrollpagedown();
            string GetUIVal = Gettext(attributeName_xpath, CustomerInvoiceGridEmpty_Xpath);
            Assert.AreEqual(GetUIVal, "No Results Found");
            Report.WriteLine("No invoices are loaded on page load");
            
        }
    }
}
