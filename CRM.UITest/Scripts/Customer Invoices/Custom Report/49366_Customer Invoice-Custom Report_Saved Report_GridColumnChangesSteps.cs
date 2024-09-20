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

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class _49366_Customer_Invoice_Custom_Report_Saved_Report_GridColumnChangesSteps : Customer_Invoice
    {
        string stationName = "ZZZ - Web Services Test";
        List<CustomerInvoice> value = null;
        List<string> clearedDateDB = null;
        string ReportName = null;

        [Given(@"I am any user with access to the CRM Customer Invoice Page")]
        public void GivenIAmAnyUserWithAccessToTheCRMCustomerInvoicePage()
        {
            string userName = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [When(@"I Select an existing custom report from Select Existing Custom Report which was created with Invoice Type as Closed")]
        public void WhenISelectAnExistingCustomReportFromSelectExistingCustomReportWhichWasCreatedWithInvoiceTypeAsClosed()
        {
            CreateCustomReport("Closed");
            SelectCreatedReportFromTheDropDown();
            Report.WriteLine("Getting all closed invoices for the selected station and storing clearedDate");
            value = DBHelper.GetClosedCustomerInvoices(stationName);
            value.OrderBy(x => x.InvoiceNumber);
                        
                if (value.Count > 0 && value !=null)
                {
                clearedDateDB = new List<string>();
                for (int i = 0; i < value.Count; i++)
                {                    
                    clearedDateDB.Add(value[i].LastPaymentDate.ToString());
                }
                }
        }

        [When(@"I Select an existing custom report from Select Existing Custom Report which was created with Invoice Type as Open")]
        public void WhenISelectAnExistingCustomReportFromSelectExistingCustomReportWhichWasCreatedWithInvoiceTypeAsOpen()
        {
            CreateCustomReport("Open");
            SelectCreatedReportFromTheDropDown();
        }


        [Then(@"the value for this column will be the Cleared Date\(Last Payment Date from Table\) from SAP")]
        public void ThenTheValueForThisColumnWillBeTheClearedDateLastPaymentDateFromTableFromSAP()
        {
            if (Gettext(attributeName_xpath, "//div[@id='gridCustomerInvoiceListContainer']//table//tbody/tr/td") == "No Results Found")
            {
                Report.WriteFailure("No records are available");
            }
            else
            {
                
                IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@class='dataTables_length']/label/select/option"));
                for(int j = 0; j < UIValues.Count; j++)
                {
                    if ("ALL".Contains(UIValues[j].Text))
                    {
                        Click(attributeName_xpath, ".//*[@class='dataTables_length']/label/select/option[5]");
                        break;
                    }
                }
                IList<IWebElement> clearedDateUI = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='gridCustomerInvoiceListContainer']//table//tbody/tr/td[10]"));
              
                for (int i = 0; i <clearedDateDB.Count; i++)
                {
                    DateTime expectedDdate = Convert.ToDateTime(clearedDateUI[i].Text);
                    if (clearedDateDB[i]==(expectedDdate).ToString())
                    {
                        Report.WriteLine("Payment Date matching");
                    }
                    else
                    {
                        Assert.Fail();
                    }      
                    
                }
            }
        }

        [Then(@"I will no longer see the Days Past Due column in my grid results")]
        public void ThenIWillNoLongerSeeTheDaysPastDueColumnInMyGridResults()
        {
            VerifyElementNotPresent(attributeName_xpath, "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[contains(text(),'Days')]", "DaysPastDue");
            Report.WriteLine("Days Past Due column is removed");
        }

        [Then(@"I will see the Days Past Due column in my grid results")]
        public void ThenIWillSeeTheDaysPastDueColumnInMyGridResults()
        {
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_DisputeCode_Xpath, "DAYS PAST DUE");
            Report.WriteLine("Days Past Due column is present");
        }

        [Then(@"I will see a new column labeled Payment Date to the right of column Due Date")]
        public void ThenIWillSeeANewColumnLabeledPaymentDateToTheRightOfColumnDueDate()
        {
            String ActualColumn_PaymentDate = Gettext(attributeName_xpath, CustomerInvoices_PaymentDate_Xpath);
            VerifyElementPresent(attributeName_xpath, CustomerInvoices_PaymentDate_Xpath, ActualColumn_PaymentDate);
            Report.WriteLine("Payment Date Column is present");
        }

        [Then(@"I will not see a new column labeled Payment Date to the right of column Due Date")]
        public void ThenIWillNotSeeANewColumnLabeledPaymentDateToTheRightOfColumnDueDate()
        {
            //String ActualColumn_PaymentDate = Gettext(attributeName_xpath, CustomerInvoices_PaymentDate_Xpath);
            VerifyElementNotPresent(attributeName_xpath, "//div[@id='gridCustomerInvoiceListContainer']//table[@role='grid']//th[contains(text(),'Payment')]", "PaymentDate");
            Report.WriteLine("Payment Date Column is not present");
        }
        public void CreateCustomReport(string reportType)
        {
            Report.WriteLine("Creating custom Report");
            ReportName = Guid.NewGuid().ToString() + "CustomRprtTst";
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            Report.WriteLine("Create Custom Report section is expanded");
            WaitForElementVisible(attributeName_xpath, ReportName_Xpath, "Report Section");
            if (reportType == "Closed")
            {
                Click(attributeName_xpath, "//label[@for='InvoiceTypeClosed']");
            }
            SendKeys(attributeName_id, InvoiceVal_Id, "4");
            scrollElementIntoView(attributeName_id, CustomerInvoices_MakePayment_Button_Id);
            Click(attributeName_xpath, CustomReport_Stations_InputText_Xpath);
            IList<IWebElement> stationValue = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='ReportStations_chosen']//div//li"));
            int count = 0;
            for (int i = 0; i < stationValue.Count; i++)
            {
                if (stationValue[i].Text == stationName)
                {
                    stationValue[i].Click();
                    break;
                }
                count++;
            }

            //#--------------Clicking on First Station if passed station is not avilable
            if (count >= stationValue.Count)
            {
                Click(attributeName_xpath, ".//*[@id='ReportStations_chosen']/div/ul/li[1]");
                stationName = GetAttribute(attributeName_xpath, CustomReport_Stations_InputText_Xpath, "value");
            }
            Click(attributeName_xpath, ReportAccount_Xpath);
            Click(attributeName_xpath, "//div[@id='ReportAccounts_chosen']//ul[@class='chosen-results']/li[1]");
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            Report.WriteLine("Values are passed to all the fields");
            Click(attributeName_id, CreateReportNewButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        public void SelectCreatedReportFromTheDropDown()
        {
            Click(attributeName_id, SelectExistingReportDropdown_id);
            int count = 0;
            IList<IWebElement> CustInvoiceReportList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            for (int i = 0; i < CustInvoiceReportList.Count; i++)
            {
                if (CustInvoiceReportList[i].Text.Equals(ReportName))
                {
                    CustInvoiceReportList[i].Click();
                    break;
                }
                count++;
            }
                if(count>= CustInvoiceReportList.Count)
                {
                    Report.WriteFailure("Newly created report is not saved in DB");
                }
        }
    }
}
