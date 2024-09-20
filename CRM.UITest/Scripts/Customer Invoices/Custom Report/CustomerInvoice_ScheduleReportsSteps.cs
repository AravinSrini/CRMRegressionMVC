using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;

namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class CustomerInvoice_ScheduleReportsSteps: Customer_Invoice
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();       
        
        [Given(@"I am on the Customer Invoice page")]
        public void GivenIAmOnTheCustomerInvoicePage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementVisible(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            Report.WriteLine("I have navigated to Customer Invoices list page");
        }

        [Given(@"I select on the Select Existing Custom Report drop down list which is active schedule")]
        public void GivenISelectOnTheSelectExistingCustomReportDropDownListWhichIsActiveSchedule()
        {
            Report.WriteLine("Select Existing Custom Report from drop down");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            IList<IWebElement> values = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            int listCount = values.Count;
            if (listCount > 1)
            {
               Click(attributeName_xpath, ".//*[@id='customReportSelection_chosen']//ul[@class='chosen-results']/li[2]");
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I Click Custom Report drop down list")]
        public void WhenIClickCustomReportDropDownList()
        {
            Report.WriteLine("Click Custom Report drop down list");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [When(@"I select on the Select Existing Custom Report drop down list which is active schedule")]
        public void WhenISelectOnTheSelectExistingCustomReportDropDownListWhichIsActiveSchedule()
        {
            Report.WriteLine("Select Existing Custom Report from drop down");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, "TestCustomReport2 (Scheduled - 06/04/2018)");
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I expand the Create Custom Report section")]
        public void WhenIExpandTheCreateCustomReportSection()
        {
            Report.WriteLine("expanding the Create Custom Report section");
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
        }
              
        [Then(@"I will see that the report is a scheduled report with the label (.*)")]
        public void ThenIWillSeeThatTheReportIsAScheduledReportWithTheLabel(string label)
        {
            IList<IWebElement> CustomreportsUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']//*[@class='chosen-results']/li"));
            List<string> CustomSchedulereportsUI = new List<string>();
                foreach (IWebElement element in CustomreportsUI)
                {
                     CustomSchedulereportsUI.Add((element.Text).ToString());
                }
            for (int i = 1; i < CustomreportsUI.Count; i++)
                {

                    if (CustomSchedulereportsUI[i].Contains("(Scheduled -"))
                    {
                        Assert.AreEqual(CustomSchedulereportsUI[i].Contains("(Scheduled -"), true);
                        Report.WriteLine("Scheduled custom report is showing with correct label");
                        int index = CustomSchedulereportsUI[i].IndexOf("-");
                        string Date = CustomSchedulereportsUI[i].Remove(0, index).Replace(")","").Replace("-", "").Replace(" ","");
                        DefineTimeOut(3000);
                        string ScheduledDateformatExp = Convert.ToDateTime(Date).ToString("MM/dd/yyyy");
                        Assert.AreEqual(ScheduledDateformatExp, Date);
                        Report.WriteLine("ScheduledDate is in mm/dd/yyyy correct format");
                        break;
                    }
                }
            
        }
        
        [Then(@"I have the option to Schedule Report")]
        public void ThenIHaveTheOptionToScheduleReport()
        {
            Report.WriteLine("User is displaying with the Sheduled report");
            VerifyElementPresent(attributeName_id, scheduleReportButton_id, "ScheduleReportoption");
        }
        
    }
}
