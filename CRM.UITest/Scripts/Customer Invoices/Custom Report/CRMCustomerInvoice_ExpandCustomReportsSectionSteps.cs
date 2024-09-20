using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class CRMCustomerInvoice_ExpandCustomReportsSectionSteps: Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am Station owner, Operations or SalesManagement user")]
        public void GivenIAmStationOwnerOperationsOrSalesManagementUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();            
            CrmLogin.LoginToCRMApplication(userName, password);
        }
        
        [When(@"I navigate to the customer invoice page")]
        public void WhenINavigateToTheCustomerInvoicePage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("I arrive on Customer Invoices Page");
            Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
        }
        
        [Then(@"the Create Custom Report section will be expanded")]
        public void ThenTheCreateCustomReportSectionWillBeExpanded()
        {
            Report.WriteLine("Create Custom Report section expanded");
            VerifyElementVisible(attributeName_xpath, ReportName_Xpath, "Report Section");
        }

        [Then(@"I will no longer have the option to collapse the section")]
        public void ThenIWillNoLongerHaveTheOptionToCollapseTheSection()
        {
            Report.WriteLine("I will no longer have the option to collapse the section");
            VerifyElementNotPresent(attributeName_id, createCustomReportsectionExpandArrow_id, "expand");
            Click(attributeName_xpath, CustomReportHeaderSection_Xpath);
            Report.WriteLine("On click of Create Custom Report section, verifying other fields visibility");
            VerifyElementNotVisible(attributeName_id, CustomreportNameForHeader_Id, "Report Name");
            IsElementDisabled(attributeName_id, CustomReport_DeleteButton_Id, "Delete");
            IsElementDisabled(attributeName_xpath, CustomReport_Save_Edits_Button, "Save Edits");
            VerifyElementEnabled(attributeName_id, CustomerInvoice_CreateNewButton_Id, "Create New");
            VerifyElementEnabled(attributeName_id, CustomReport_Preview_Run_Button_Id, "Preview/Run Now");
            VerifyElementNotVisible(attributeName_id, CustomReport_ScheduleReportButton_Id, "Schedule Report");
        }
    }
}
