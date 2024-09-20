using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;


namespace CRM.UITest.Scripts.Customer_Invoices.Custom_Report
{
    [Binding]
    public class _74958_CustomerInvoice_CustomReport_SortedStationsListSteps : Customer_Invoice
    {
        string userType = string.Empty;
        [Given(@"I am a (.*) user with access to Customer Invoices")]
        public void GivenIAmAUserWithAccessToCustomerInvoices(string User)
        {
            userType = User;
            string userName = string.Empty;
            string password = string.Empty;
            if (userType == "AccessRRD")
            {
                userName = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
                password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
                Report.WriteLine("Logging into CRM application with RRD access user");
            }
            else if(userType == "Sales")
            {
                userName = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
                password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
                Report.WriteLine("Logging into CRM application with Sales user");
            } 
            else
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
                Report.WriteLine("Logging into CRM application with Operations user");
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }


        [Given(@"I am on the customer invoice page")]
        public void GivenIAmOnTheCustomerInvoicePage()
        {
            if (userType != "AccessRRD")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, customerInvoiceIcon_xpath);


                Report.WriteLine("I arrive on Customer Invoices Page");
                Verifytext(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoices");
            }
        }

        [When(@"I Click on the Stations field of the Create Custom Report section")]
        public void WhenIClickOnTheStationsFieldOfTheCreateCustomReportSection()
        {
            if (userType == "AccessRRD" || userType == "Sales")
            {
                Report.WriteLine("Expanding Custom report section");
                Click(attributeName_id, CustomReportSection_ExpandArror_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Thread.Sleep(3000);
                Report.WriteLine("expanding the Create Custom Report Stations field");
                Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
            }
            else
            {
                Report.WriteLine("expanding the Create Custom Report Stations field");
                Click(attributeName_xpath, CreateCustomReport_StationDropdown_Xpath);
            }
        }
        
        [Then(@"the list of stations in the dropdown should be Numerically and Alphabetically sorted")]
        public void ThenTheListOfStationsInTheDropdownShouldBeNumericallyAndAlphabeticallySorted()
        {
            List<string> UIStationList = new List<string>();
            List<string> sortedStationList = new List<string>();
            IList<IWebElement> stationDropdownCustomReport = GlobalVariables.webDriver.FindElements(By.XPath(CustomReport_Station_DropDownList));

            foreach (IWebElement element in stationDropdownCustomReport)
            {
                UIStationList.Add(element.Text);
            }
            sortedStationList = UIStationList.ToList();
            sortedStationList.Sort();


            CollectionAssert.AreEqual(UIStationList, sortedStationList);
            Report.WriteLine("The stations that I am associated with are available in Station Dropdown in numerical & alphabetical order");
        }
    }
}
