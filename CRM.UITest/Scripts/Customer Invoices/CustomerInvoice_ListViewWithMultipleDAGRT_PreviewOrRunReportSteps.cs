using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_ListViewWithMultipleDAGRT_PreviewOrRunReportSteps : Customer_Invoice
    {
        string stationName = "ENT - Bolingbrook IL";
        string EnterCustomerName = "All";


        [Given(@"I expand the custom report section")]
        public void GivenIExpandTheCustomReportSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomReport_CreateCustomReport_Arrow_Xpath);
            scrollpagedown();
        }
        
        [Given(@"I select a station with MULTIPLE DAGRT numbers")]
        public void GivenISelectAStationWithMULTIPLEDAGRTNumbers()
        {
            Report.WriteLine("Selecting Station from the dropdown");
            Click(attributeName_xpath, CustomReport_Stations_InputText_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_StationList_All_Xpath, "ENT - Bolingbrook IL");
        }
        
        [Given(@"I select All Accounts for the selected station")]
        public void GivenISelectAllAccountsForTheSelectedStation()
        {
            Click(attributeName_xpath, CustomReport_Accounts_InputText_Xpath);
            Click(attributeName_xpath, CustomReport_AccountDropdown_AllAccount_Xpath);
        }
        
        [Given(@"I enter a Custom Report Name")]
        public void GivenIEnterACustomReportName()
        {
            Click(attributeName_xpath, CustomeReport_CloseButton_Xpath);
            SendKeys(attributeName_id, CustomerInvoiceReportName_Id, "Test Report xx");
        }
        
        [When(@"I click the Preview / Run Button")]
        public void WhenIClickThePreviewRunButton()
        {
            Report.WriteLine("Clicking on Preview and Run button");
            Click(attributeName_id, CustomReport_Preview_Run_Button_Id);
            scrollpagedown();
            
           
        }
        
        [Then(@"the grid will display all invoices where the invoice DAGRT number matches any DAGRT number within the station DAGRT list")]
        public void ThenTheGridWillDisplayAllInvoicesWhereTheInvoiceDAGRTNumberMatchesAnyDAGRTNumberWithinTheStationDAGRTList()
        {
            scrollpagedown();

            Report.WriteLine("Selecting All records from the record count dropdown");
            IList<IWebElement> UIValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='dataTables_length']/label/select/option"));
            for (int j = 0; j < UIValue.Count; j++)
            {
                if ("ALL".Contains(UIValue[j].Text))
                {
                    Click(attributeName_xpath, ".//*[@class='dataTables_length']/label/select/option[5]");
                    break;
                }
            }
            Report.WriteLine("Getting all closed invoices for the selected station and storing clearedDate");
            List<string> invoicesDB = DBHelper.GetMultipleCustomerInvoices(stationName);
            int DBRecordCount = invoicesDB.Count;

            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(CustomReportGridDisplay_Records_Xpath));
            int UIRecordCount = UIValues.Count;
            Assert.AreEqual(DBRecordCount, UIRecordCount);
        }
        
        [Then(@"display the results of the report based on the values entered in the Create Custom Report section")]
        public void ThenDisplayTheResultsOfTheReportBasedOnTheValuesEnteredInTheCreateCustomReportSection()
        {
            
            string NoRecordFound = Gettext(attributeName_xpath, CustomerInvocies_NoResultFound_Xpath);
            int row = GetCount(attributeName_xpath, CustomerInvoives_DisplayAllRow_Xpath);
            List<string> invoicesDB = DBHelper.GetMultipleCustomerInvoices(stationName);
            
            IList<IWebElement> CustomerNumberColumn_InitialValues = GlobalVariables.webDriver.FindElements(By.XPath("//div/table[@role='grid']/tbody//td[4]"));
            for (int i = 1; i <= CustomerNumberColumn_InitialValues.Count; i++)
            {

                string getStationName = Gettext(attributeName_xpath, ".//*[@id='00000000-0000-0000-0000-000000000000']/td[4]");
                Assert.AreEqual(stationName, getStationName);
                string invoiceNumber = Gettext(attributeName_xpath, ".//*[@id='00000000-0000-0000-0000-000000000000']/td[6]");
                Assert.IsTrue(invoicesDB.Contains(invoiceNumber));
             }
         }
          
        
    }
}
