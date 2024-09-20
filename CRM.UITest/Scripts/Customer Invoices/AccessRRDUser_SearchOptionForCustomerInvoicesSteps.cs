using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Helper.DataModels.CustomerInvoice;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class AccessRRDUser_SearchOptionForCustomerInvoicesSteps : Customer_Invoice
    {       

        [Given(@"I am an Access RRD User")]
        public void GivenIAmAnAccessRRDUser()
        {
            Report.WriteLine("Logging into CRM with an Access RRD user");
            string username = ConfigurationManager.AppSettings["username-AccessRRDUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-AccessRRDUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }        
        
        [Given(@"I am on the Customer Invoices Page")]
        public void GivenIAmOnTheCustomerInvoicesPage()
        {
            Report.WriteLine("Clicking on customer invoice link");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }       
        
        [Given(@"I choose the (.*) radio button")]
        public void GivenIChooseTheRadioButton(string openOrClosedOption)
        {
            Report.WriteLine("Clicking on the " + openOrClosedOption + " radio button");
            if (openOrClosedOption == "o")
            {
                Click(attributeName_xpath, SearchAreaOpenRadioButton_xpath);
            }
            else
            {
                Click(attributeName_xpath, SearchAreaClosedRadioButton_xpath);
            }
        }

        [Given(@"I have selected an (.*) from the drop down list")]
        [When(@"I have selected an (.*) from the drop down list")]
        public void IHaveSelectedAnOptionFromTheDropDownList(string option)
        {
            Report.WriteLine("Chosen the selected option from the dropdown which is: " + option);
            Click(attributeName_xpath, SearchFieldDropDown_xpath);
            Thread.Sleep(1000);
            var items = GlobalVariables.webDriver.FindElements(By.XPath(SearchFieldDropDownOptions_xpath));
            var selectedItem = items.FirstOrDefault(x => x.Text == option);
            selectedItem.Click();
        }

        [Given(@"I enter data in the field (.*)")]
        [When(@"I enter data in the field (.*)")]
        public void IEnterDataInTheField(string searchText)
        {
            Report.WriteLine("Entering '" + searchText + "' into the search field");
            SendKeys(attributeName_xpath, SearchAreaTextInput_xpath, searchText);
        }

        [When(@"I click on the button search invoices")]
        public void WhenIClickOnTheButtonSearchInvoices()
        {
            Report.WriteLine("Clicking on the search invoices button");
            Click(attributeName_id, SearchAreaSearchInvoicesButton_id);
        }

        [Then(@"I will have search drop down selections")]
        public void ThenIWillHaveSearchDropDownSelections()
        {
            Report.WriteLine("Verifying that the drop down for search type is visiable");
            VerifyElementVisible(attributeName_xpath, SearchFieldDropDown_xpath, "DropDownForSearchType");
        }
        
        [Then(@"the search options for the drop down selection available are:")]
        public void ThenTheSearchOptionsForTheDropDownSelectionAvailableAre(Table table)
        {
            Click(attributeName_xpath, SearchFieldDropDown_xpath);
            foreach (var row in table.Rows)
	        {
                var option = row[0];
                Report.WriteLine("Verifying that the drop down option '" + option + "' is visible");
                var xpathForElement = SearchFieldDropDownOptions_xpath + "[text() = '" + option + "']";
                VerifyElementVisible(attributeName_xpath, xpathForElement, "DropdownOption-" + option);
            }
        }
        
        [Then(@"I will see a text box field next to the search options")]
        public void ThenIWillSeeATextBoxFieldNextToTheSearchOptions()
        {
            Report.WriteLine("Verifying that the search input text box is visible");
            VerifyElementVisible(attributeName_xpath, SearchAreaTextInput_xpath, "SearchInputTextBox");
        }
        
        [Then(@"there will be a radio button for open")]
        public void ThenThereWillBeARadioButtonForOpen()
        {
            Report.WriteLine("Verifying that the open radio button is visible");
            VerifyElementVisible(attributeName_xpath, SearchAreaOpenRadioButton_xpath, "OpenRadioButton");
        }
        
        [Then(@"there will be a radio button for close")]
        public void ThenThereWillBeARadioButtonForClose()
        {
            Report.WriteLine("Verifying that the closed radio button is visible");
            VerifyElementVisible(attributeName_xpath, SearchAreaClosedRadioButton_xpath, "ClosedRadioButton");
        }
        
        [Then(@"the station field is NOT required")]
        public void ThenTheStationFieldIsNOTRequired()
        {
            Report.WriteLine("Verifying that the station field is visible");
            VerifyElementVisible(attributeName_xpath, AccessRRDStationsSearchDropDown_xpath, "StationsField");
        }
        
        [Then(@"the accounts field is NOT required")]
        public void ThenTheAccountsFieldIsNOTRequired()
        {
            Report.WriteLine("Verifying that the accounts field is visible");
            VerifyElementVisible(attributeName_xpath, AccessRRDAccountsSearchDropDown_xpath, "AccountsField");
        }
        
        [Then(@"I will see a search invoices button in the access rrd search area")]
        public void ThenIWillSeeASearchInvoicesButtonInTheAccessRRDArea()
        {
            Report.WriteLine("Verifying that the search invoices button is visible");
            VerifyElementVisible(attributeName_xpath, SearchAreaSearchInvoicesButton_xpath, "SearchInvoicesButton");
        }
        
        [Then(@"the Search Invoices button will be (.*)")]
        public void ThenTheSearchInvoicesButtonWillBe(string buttonStatus)
        {
            Report.WriteLine("Verifying the search invoice button is " + buttonStatus);
            if (buttonStatus == "Enabled")
            {
                VerifyElementEnabled(attributeName_xpath, SearchAreaSearchInvoicesButton_xpath, "SearchButtonEnabled");
            }
            else
            {
                VerifyElementNotEnabled(attributeName_xpath, SearchAreaSearchInvoicesButton_xpath, "SearchButtonDisabled");
            }
        }

        [Then(@"CRM will search for invoices that contains the values entered (.*) (.*) (.*)")]
        public void ThenCRMWillSearchForInvoicesThatContainsTheValuesEntered(string option, string searchText, string openOrClosed)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            if(option== "Customer Name" && openOrClosed == "o")
            {
                IList<IWebElement> invoiceNumberContent = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr/td[6]"));
                for (int i = 1; i <= invoiceNumberContent.Count; i++)
                {
                    string dueDate = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[9]");
                    int todatDays = (DateTime.UtcNow.Date - Convert.ToDateTime(dueDate)).Days;
                    string daysPastDue = Gettext(attributeName_xpath, ".//*[@id='gridCustomerInvoiceListContainer']//tbody/tr[" + i + "]/td[12]");
                    Assert.AreEqual(todatDays.ToString(), daysPastDue);
                }
            }

            //Get invoices from invoice grid
            IList<IWebElement> invoicesGridAllValues = GlobalVariables.webDriver.FindElements(By.XPath(customerInvoiceGrid_AllResultsRow_XPath));
            IList<CustomerInvoiceListViewModel> customerInvoicesFromDB;
            if (option == "Invoice Number")
            {
                customerInvoicesFromDB = DBHelper.GetInvoicesForInvoiceNumber(searchText, openOrClosed);
            }
            else if (option == "Customer Number")
            {
                customerInvoicesFromDB = DBHelper.GetInvoicesForCustomerNumber(searchText, openOrClosed);
            }
            else if (option == "Customer Name")
            {
                customerInvoicesFromDB = DBHelper.GetInvoicesForCustomerName(searchText, openOrClosed);
            }
            else
            {
                customerInvoicesFromDB = DBHelper.GetInvoicesForDagrt(searchText, openOrClosed);
            }

            Report.WriteLine("Checking there is the same amount of values in DB as there are in grid");
            Assert.AreEqual(customerInvoicesFromDB.Count, invoicesGridAllValues.Count, "The grid and the db count do not match");

            Report.WriteLine("Checking each row in grid matches the db results");
            bool successfull = true;

            for (int i = 0; i < invoicesGridAllValues.Count; i++)
            {
                string salesRep = invoicesGridAllValues[i].FindElement(By.XPath("td[2]")).Text;
                string accountNumber = invoicesGridAllValues[i].FindElement(By.XPath("td[3]")).Text;
                string stationName = invoicesGridAllValues[i].FindElement(By.XPath("td[4]/span")).Text == "N/A" ? null : invoicesGridAllValues[i].FindElement(By.XPath("td[4]/span")).Text;
                string customerNumber = invoicesGridAllValues[i].FindElement(By.XPath("td[5]/span[1]")).Text;
                string customerName = invoicesGridAllValues[i].FindElement(By.XPath("td[5]/span[2]")).Text;
                string invoiceNumber = invoicesGridAllValues[i].FindElement(By.XPath("td[6]/a")).Text;
                string referenceIdNumber = invoicesGridAllValues[i].FindElement(By.XPath("td[7]")).Text == "" ? null : invoicesGridAllValues[i].FindElement(By.XPath("td[7]")).Text;
                string invoiceDate = invoicesGridAllValues[i].FindElement(By.XPath("td[8]")).Text;
                string dueDate = invoicesGridAllValues[i].FindElement(By.XPath("td[9]")).Text;
                string originalAmount = invoicesGridAllValues[i].FindElement(By.XPath("td[10]")).Text;
                string current = invoicesGridAllValues[i].FindElement(By.XPath("td[11]")).Text;
                string daysPastDue = invoicesGridAllValues[i].FindElement(By.XPath("td[12]")).Text;
                string disputeCode = invoicesGridAllValues[i].FindElement(By.XPath("td[13]")).Text;

                var numberFormat = (NumberFormatInfo)CultureInfo.CurrentCulture.NumberFormat.Clone();
                numberFormat.CurrencyNegativePattern = 1;

                string currentFromDb = customerInvoicesFromDB[i].Current.ToString("C");
                string originalAmountFromDb = customerInvoicesFromDB[i].OriginalAmount.ToString("C");

                if (customerInvoicesFromDB[i].Current < 0)
                    currentFromDb = customerInvoicesFromDB[i].Current.ToString("C", numberFormat);

                if(customerInvoicesFromDB[i].OriginalAmount < 0)
                    originalAmountFromDb = customerInvoicesFromDB[i].OriginalAmount.ToString("C", numberFormat);


                if (customerInvoicesFromDB[i].AccountNumber != accountNumber ||
                    currentFromDb != current ||
                    customerInvoicesFromDB[i].CustomerName != customerName ||
                    customerInvoicesFromDB[i].CustomerNumber != customerNumber ||
                    //customerInvoicesFromDB[i].DaysPastDue.ToString() != daysPastDue ||
                    customerInvoicesFromDB[i].DisputeCode != disputeCode ||
                    customerInvoicesFromDB[i].DueDate.ToString("MM/dd/yyyy") != dueDate ||
                    customerInvoicesFromDB[i].InvoiceDate.ToString("MM/dd/yyyy") != invoiceDate ||
                    customerInvoicesFromDB[i].InvoiceNumber != invoiceNumber ||
                    customerInvoicesFromDB[i].InvoiceStatus.ToLower() != openOrClosed ||
                    originalAmountFromDb != originalAmount ||
                    customerInvoicesFromDB[i].ReferenceIdNumber != referenceIdNumber ||
                    customerInvoicesFromDB[i].SalesRep != salesRep ||
                    customerInvoicesFromDB[i].StationName != stationName)
                {
                    Report.WriteFailure("Customer Invoice Grid is loaded with invalid invoices");
                    successfull = false;
                    break;
                }
            }

            if (successfull)
            {
                Report.WriteLine("Verified that the Customer Invoice Grid is loaded based on the search criteria");
            }
            
        }

    }
}
