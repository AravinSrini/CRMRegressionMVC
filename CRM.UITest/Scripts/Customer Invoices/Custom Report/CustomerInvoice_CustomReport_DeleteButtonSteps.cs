using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using System.Collections.Generic;
using CRM.UITest.Entities;
using System.IO;
using System.Linq;
using System.Globalization;
using OpenQA.Selenium;


namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class CustomerInvoice_CustomReport_DeleteButtonSteps : Customer_Invoice
    {
        string expectedReportNameInHeader = null;
        string actualReportInNameHeader = null;
        string selectedReportName = null;
        string selectedScheduleReportName = null;
        Entities.Proxy.InvoiceCustomReport invoiceCR = null;
        string email = "stationown@stage.com";
        string activeScheduledCustomReportName;

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwner()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner")]
        public void GivenIAmShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwner()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [Given(@"I selected a Custom Report from the Select Existing Custom Report list")]
        public void GivenISelectedACustomReportFromTheSelectExistingCustomReportList()
        {
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdown_xpath, "Custom Report1");
        }
        
        [Given(@"I expanded the Create or Edit Custom Report section")]
        public void GivenIExpandedTheCreateOrEditCustomReportSection()
        {
            
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);
        }
        
        [Given(@"I selected a Custom Report which has scheduled run time")]
        public void GivenISelectedACustomReportWhichHasScheduledRunTime()
        {
            //Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            //IList<IWebElement> reportNameList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            //for(int i = 0; i < reportNameList.Count; i++)
            //{
            //    IWebElement element = reportNameList.ElementAt(i);
            //    selectedScheduleReportName = element.Text.ToString().Trim();
            //    Match match = Regex.Match(selectedScheduleReportName, @"[\w\d ]*\(Scheduled \- \d+/\d+/\d+\)$");
            //    if (match.Success)
            //        SelectByVisibleText(attributeName_xpath, SelectExistingReportDropdownValues_xpath, selectedScheduleReportName);
            //    break;

            //}

            Report.WriteLine("selecting existing weekly active scheduled custom report from custom report dropdown");
            Report.WriteLine("Navigate to Customer Invoices Page");
       
            GlobalVariables.webDriver.WaitForPageLoad();
            activeScheduledCustomReportName = DBHelper.GetMonthlyActiveCustomReportName(email);

            Click(attributeName_id, SelectExistingReportDropdown_id);

            IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            for (int i = 1; i < CustInvoiceReportList.Count; i++)
            {

                if (CustInvoiceReportList[i].Text.Contains(activeScheduledCustomReportName + " (Scheduled"))
                {
                    CustInvoiceReportList[i].Click();
                    break;

                }

            }


            Report.WriteLine("Click on schedule report button on creat custom report section");
            Click(attributeName_id, CustomReportSection_ExpandArror_Id);

        }

        [Given(@"I selected a Custom Report from the Existing Custom Report list")]
        public void GivenISelectedACustomReportFromTheExistingCustomReportList()
        {
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            selectedReportName = Gettext(attributeName_xpath, CustomReportNameIndexFour_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReportNameIndexFour_Xpath, selectedReportName);
   
        }

        [When(@"I click on the Delete button")]
        public void WhenIClickOnTheDeleteButton()
        {
             invoiceCR = DBHelper.GetInvoiceCustomReportId(selectedReportName, email);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, CustomReport_DeleteButton_Id);
        }
        
        [Then(@"the report will be deleted")]
        public void ThenTheReportWillBeDeleted()
        {
           
        //    Entities.Proxy.InvoiceCustomReport invoiceCR = DBHelper.GetInvoiceCustomReportId(selectedReportName);
            bool DeleteReport = DBHelper.isReportDeleted(invoiceCR.InvoiceCustomReportId);
            Assert.IsTrue(DeleteReport);
        }

        [Then(@"the schedule report will also be deleted")]
        public void ThenTheScheduleReportWillAlsoBeDeleted()
        {
           
            bool DeleteReport = DBHelper.isScheduleReportDeleted(selectedScheduleReportName);
            Assert.IsTrue(DeleteReport);
        }


        [Then(@"the Create or Edit Custom Report section will collapse")]
        public void ThenTheCreateOrEditCustomReportSectionWillCollapse()
        {
            VerifyElementNotVisible(attributeName_id, CustomReport_DeleteButton_Id, "Delete button");
        }

        [Then(@"the custom report name will be removed from the section header")]
        public void ThenTheCustomReportNameWillBeRemovedFromTheSectionHeader()
        {
            actualReportInNameHeader = Gettext(attributeName_id, CustomReportHeaderSection_Id);
            expectedReportNameInHeader = "";
            Assert.AreEqual(actualReportInNameHeader, expectedReportNameInHeader);
        }
        
        [Then(@"the deleted custom report will not be available to select from the report drop down list")]
        public void ThenTheDeletedCustomReportWillNotBeAvailableToSelectFromTheReportDropDownList()
        {
            IList<IWebElement> reportNameList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            for(int i = 0; i < reportNameList.Count; i++)
            { 
                IWebElement element = reportNameList.ElementAt(i);
                string elementText = element.Text.ToString().Trim();
                if (elementText.Equals(selectedReportName))
                {
                    Assert.IsTrue(false);
                }
               
            }
            Assert.IsTrue(true);
        }

        [Then(@"the deleted scheduled custom report will not be available to select from the report drop down list")]
        public void ThenTheDeletedScheduledCustomReportWillNotBeAvailableToSelectFromTheReportDropDownList()
        {
            IList<IWebElement> reportNameList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            for (int i = 0; i < reportNameList.Count; i++)
            {
                IWebElement element = reportNameList.ElementAt(i);
                string elementText = element.Text.ToString().Trim();
                if (!elementText.Contains(selectedScheduleReportName))
                {
                    Assert.IsTrue(true);
                }
                Assert.IsFalse(false);
            }
        }

     
    }
}
