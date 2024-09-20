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
using OpenQA.Selenium;
using CRM.UITest.Entities.Proxy;
using System.Linq;
using System.Globalization;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_ReportingOptionsSteps : Customer_Invoice
    {
        string actualReportName, expectedReportName;
        string ReportList = null;
        string emailId = "stationown@stage.com";
        string actualText, expectedText;
        string invoiceType = null;
        string selectedReportName = null;

        WebElementOperations ObjWebElementOperations = new WebElementOperations();
        CommonMethodsCrm crm = new CommonMethodsCrm();
        //Make sure the Useremailid is same as the logged in user
        public string Useremailid = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner, or access rrd user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerOrAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();

            crm.LoginToCRMApplication(username, password);
        }

       

        [Given(@"I arrive on the Customer Invoice page")]
        public void GivenIArriveOnTheCustomerInvoicePage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I clicked in the Select Existing Custom Report field")]
        public void GivenIClickedInTheSelectExistingCustomReportField()
        {
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
        }

        [When(@"I selected a Custom report which wil return no invoice record")]
        public void WhenISelectedACustomReportWhichWilReturnNoInvoiceRecord()
        {

            GlobalVariables.webDriver.WaitForPageLoad();
          
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, "123");
        }


        [When(@"I arrive on the Customer Invoice page")]
        public void WhenIArriveOnTheCustomerInvoicePage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
        }
        
        [When(@"I click in the Select Existing Custom Report field")]
        public void WhenIClickInTheSelectExistingCustomReportField()
        {
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
        }

        [When(@"I select a Custom report for valid data")]
        public void WhenISelectACustomReportForValidData()
        {
            
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, "123");
        }


        [When(@"I select a Custom Report from the Select Existing Custom Report list")]
        public void WhenISelectACustomReportFromTheSelectExistingCustomReportList()
        {
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdown_xpath, "InvoiceValueLessThan129");
        }
        
        [Then(@"I have the option to Select a Custom report from a drop down list")]
        public void ThenIHaveTheOptionToSelectACustomReportFromADropDownList()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            selectedReportName = Gettext(attributeName_xpath, CustomReportNameIndexFour_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReportNameIndexFour_Xpath, selectedReportName);
        }
        
        [Then(@"I have the option to Create Custom Report")]
        public void ThenIHaveTheOptionToCreateCustomReport()
        {
            IsElementPresent(attributeName_id, CustomerInvoice_CreateNewButton_Id, "Create New Button");
        }
        
        [Then(@"I will see a list of my Custom reports")]
        public void ThenIWillSeeAListOfMyCustomReports()
        {

            List<string> reportDropdown = (from i in GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath))
                                           where !i.GetAttribute("innerHTML").Equals("Select...")
                                           select i.GetAttribute("innerHTML")).ToList();




            List<string> listOfReportsFromDB = DBHelper.UserSpecificCustomReportList(emailId)
                                               .Select(i => i).ToList();

            CollectionAssert.Equals(reportDropdown, listOfReportsFromDB);


        }

        [Then(@"the Custom reports will be displayed in alphabetical order")]
        public void ThenTheCustomReportsWillBeDisplayedInAlphabeticalOrder()
        {

            List<string> actualReportList = new List<string>();
            IList<IWebElement> ReportDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            for (int i = 0; i < ReportDropdownList.Count; i++) { 
                IWebElement element = ReportDropdownList.ElementAt(i);
                string elementText = element.Text.ToString().Trim();
                    if (!elementText.Contains("Select..."))
                    {
                        actualReportList.Add(elementText);
                    }
            }

            List<string> clonedList = new List<string>(actualReportList);
            clonedList.Sort();
            CollectionAssert.AreEqual(actualReportList, clonedList);

        }

        [Then(@"the customer invoice grid will update to display the message (.*)")]
        public void ThenTheCustomerInvoiceGridWillUpdateToDisplayTheMessage(string p0)
        {
            actualText = Gettext(attributeName_xpath, CustomerGrid_NoResultFoundMessage_Xpath);
            expectedText = "No Results Found";
            Assert.AreEqual(actualText, expectedText);
        }


        [Then(@"the Customer Invoice grid will refresh to display the data related to the report selected")]
        public void ThenTheCustomerInvoiceGridWillRefreshToDisplayTheDataRelatedToTheReportSelected()
        {
            //getting data from custom report
            Click(attributeName_xpath, CustomReport_CreateCustomReport_Arrow_Xpath);
            string invoiceTypeValue = "";
            IList<IWebElement> InvoiceTypes = GlobalVariables.webDriver.FindElements(By.Name("FilterByPaid"));
            foreach(IWebElement i in InvoiceTypes)
            {
                if(i.Selected)
                {
                    invoiceTypeValue = i.GetAttribute("value");
                    break;
                }
            }

            string daysPastDue = GlobalVariables.webDriver.FindElement(By.Id(DaysPastDue_Id)).GetAttribute("value");
            int dueDaysAsInt = -1;
            if(daysPastDue.Length != 0)
            {
                dueDaysAsInt = Convert.ToInt32(daysPastDue);
            }
            bool isLessThan = GlobalVariables.webDriver.FindElement(By.XPath(InvoiceValueMaxLimit_Xpath)) != null ? true : false;
            
            decimal invoiceValue = Convert.ToDecimal(GlobalVariables.webDriver.FindElement(By.XPath("//input[@id='InvoiceValue']")).GetAttribute("value").Substring(1));
            string selectedStationName = GlobalVariables.webDriver.FindElement(By.XPath(ReportStationName_Xpath)).GetAttribute("value");
       
            string dateRange = GlobalVariables.webDriver.FindElement(By.XPath(DateRange_Xpath)).GetAttribute("value");
            DateTime startDate = new DateTime();
            DateTime endDate = new DateTime();
            if (dateRange.Length != 0)
            {
                string[] dateRanges = dateRange.Split('-');
                foreach (string s in dateRanges) {

                }
                string xx = dateRanges[0].Trim();
                startDate = DateTime.ParseExact(dateRanges[0].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture);
                endDate = DateTime.ParseExact(dateRanges[1].Trim(), "MM/dd/yyyy", CultureInfo.CurrentCulture);
            }
          
            //Data getting from Grid
            IList<IWebElement> gridDataUI = GlobalVariables.webDriver.FindElements(By.XPath("CustomerInvoice_GridColum_Xpath"));
            if(gridDataUI.Count > 0)
            {
                List<string> gridColumnValues = ObjWebElementOperations.GetListFromIWebElement(gridDataUI);
                int rowCount = gridColumnValues.Count;
                for(int i = 0; i < rowCount; i++)
                {
                    int j = i + 1;
                    string stationRowValues = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceList3908201804391339']/tbody/tr[" + j + "]/td[3]");
                    Assert.Equals(selectedStationName, stationRowValues);

                    string daysPastDueRowValue = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceList3908201804391339']/tbody/tr[" + j + "]/td[11]");
                    if(dueDaysAsInt != -1)
                    {
                        int daysPastDueRowValueAsInt = Convert.ToInt32(daysPastDueRowValue);
                        Assert.IsTrue(daysPastDueRowValueAsInt <= dueDaysAsInt);
                    }

                    decimal OriginalAmountRowValue = Convert.ToDecimal(Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceList3908201804391339']/tbody/tr[" + j + "]/td[9]").Replace("$", ""));
                    if (isLessThan)
                    {
                        Assert.IsTrue(OriginalAmountRowValue < invoiceValue);
                    } else
                    {
                        Assert.IsTrue(OriginalAmountRowValue > invoiceValue);
                    }

                    if (dateRange.Length != 0)
                    {
                        DateTime InvoiceDateRowValue = Convert.ToDateTime(Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceList3908201804391339']/tbody/tr[" + j + "]/td[7]"));
                        Assert.IsTrue(InvoiceDateRowValue >= startDate && InvoiceDateRowValue <= endDate);
                    }
                    
                    

                }
            }
        }

        public int CalculateTotalNumberOfDay(DateTime dateTime)
        {
            int totalNumberOfDays = (dateTime.Date - DateTime.UtcNow.Date).Days;
            if (totalNumberOfDays < 0)
                return Math.Abs(totalNumberOfDays);

            return totalNumberOfDays;
        }

        [Then(@"the selected report name will be displayed in the Create Custom Report section header")]
        public void ThenTheSelectedReportNameWillBeDisplayedInTheCreateCustomReportSectionHeader()
        {
            actualReportName = Gettext(attributeName_id, CustomreportNameForHeader_Id);
            expectedReportName = "(123)";
            Assert.AreEqual(actualReportName, expectedReportName);
        }
    }
}
