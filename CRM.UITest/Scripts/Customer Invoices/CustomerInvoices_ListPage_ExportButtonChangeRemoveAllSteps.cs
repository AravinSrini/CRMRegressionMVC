using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoices_ListPage_ExportButtonChangeRemoveAllSteps : Customer_Invoice
    {
        [Given(@"I am a CRM user with access to the Customer Invoice list page")]
        public void GivenIAmACRMUserWithAccessToTheCustomerInvoiceListPage()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I arrive on the Customer Invoices list page")]
        public void GivenIArriveOnTheCustomerInvoicesListPage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I arrive on Customer Invoices List Page");
        }

        [When(@"I click on the Export button")]
        public void WhenIClickOnTheExportButton()
        {
            Report.WriteLine("I will see the Export Button");
            Click(attributeName_id, CustomerInvoices_ExportButton_Id);
        }

        [Then(@"I will no longer see the word All- before each export option\.")]
        public void ThenIWillNoLongerSeeTheWordAll_BeforeEachExportOption_()
        {
            string ExcelOption = Gettext(attributeName_xpath, "//a[@id='ExportExcel']");
            string PdfOption = Gettext(attributeName_xpath, "//a[@id='ExportPdf']");

            Assert.IsTrue(!ExcelOption.Contains("All"));
            Report.WriteLine("Option " + ExcelOption + " is displaying under view Drop down without All-");

            Assert.IsTrue(!PdfOption.Contains("All"));
            Report.WriteLine("Option " + PdfOption + " is displaying under view Drop down without All-");
        }
    }
}
