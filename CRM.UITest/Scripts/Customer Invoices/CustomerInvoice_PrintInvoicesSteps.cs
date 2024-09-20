using System.Configuration;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_PrintInvoices : Customer_Invoice
    {
        [Given("I am a user with access to Customer Invoices")]
        public void GivenIAmAUserWithAccessToCustomerInvoices()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given("I am on the Customer Invoices page")]
        public void GivenIAmOnTheCustomerInvoicesPage()
        {
            Report.WriteLine("Clicking on customer invoice link");
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected (.*) displayed invoices")]
        public void GivenISelectedDisplayedInvoices(int maxSelected)
        {
            Report.WriteLine("Populating grid with items");
            WhenTheGridIsPopulatedWithInvoices();

            Report.WriteLine("Selecting first "+maxSelected+" items in the grid");
            Thread.Sleep(3000);
            if(maxSelected > 0)
            {
                Click(attributeName_xpath, CustomerInvoice_FirstRowCheckbox);
            }
            if(maxSelected > 1)
            {
                Click(attributeName_xpath, CustomerInvoice_SecondRowCheckbox);
            }
            if (maxSelected > 2)
            {
                Click(attributeName_xpath, CustomerInvoice_ThirdRowCheckbox);
            }
        }

        [When("the grid is not populated with invoices")]
        public void GivenTheGridIsNotPopulatedWithInvoices()
        {
            Report.WriteLine("Clicking report that will give 0 invoices");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            var items = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            var report = items.FirstOrDefault(x => x.Text == "NinjaSprintPrintInvoicesNoResults");
            report.Click();
            
        }

        [Given("the grid is populated with invoices")]
        [When("the grid is populated with invoices")]
        public void WhenTheGridIsPopulatedWithInvoices()
        {
            Report.WriteLine("Clicking report that will give me items in the grid");
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            var items = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            var report = items.FirstOrDefault(x => x.Text == "NinjaSprintPrintInvoices");
            report.Click();
        }
        
        [When("There are no invoices selected in the grid")]
        public void WhenThereAreNoInvoicesSelectedInTheGrid()
        {
            Report.WriteLine("Clicking if any items in grid selected and if true then unselecting");
            bool areAnyChecked = GlobalVariables.webDriver.FindElement(By.XPath(CustomerInvoices_SelectAllInvoiceCheckBoxes_Xpath)).Selected;
            if (areAnyChecked)
            {
                Click(attributeName_xpath, CustomerInvoices_SelectAllInvoiceCheckBoxesLabel_Xpath);
            }
        }

        [When(@"I have selected invoices from the customer invoice grid")]
        public void WhenIHaveSelectedInvoicesFromTheCustomerInvoiceGrid()
        {
            Report.WriteLine("Selecting first item in the grid");
            Thread.Sleep(2000);
            Click(attributeName_xpath, CustomerInvoice_FirstRowCheckbox);
        }

        [When(@"I click on the button print invoices")]
        public void WhenIClickOnTheButtonPrintInvoices()
        {
            Report.WriteLine("Clicking print invoices button");
            Click(attributeName_xpath, CustomerInvoices_PrintInvoicesButton_Xpath);
        }

        [Then("I will not see the print invoices button")]
        public void ThenIWillNotSeeThePrintInvoicesButton()
        {
            Report.WriteLine("Checking if print invoices button is visible");
            Thread.Sleep(2000);
            VerifyElementNotPresent(attributeName_id, CustomerInvoices_PrintInvoicesButton_Id, "btnPrintCustomerInvoiceList");
        }

        [Then("I will have the option to select any displayed invoice")]
        public void ThenIWillHaveTheOptionToSelectAnyDisplayedInvoice()
        {
            Report.WriteLine("Checking if invoices are selectable");
            VerifyElementVisible(attributeName_xpath, CustomerInvoices_SelectInvoiceCheckBoxes_Xpath, "CheckBoxFirstColumn");
        }

        [Then("I will see a Print Invoices button")]
        public void ThenIWillSeeAPrintInvoicesButton()
        {
            Report.WriteLine("Checking if I can see print invoices button");
            VerifyElementPresent(attributeName_id, CustomerInvoices_PrintInvoicesButton_Id, "btnPrintCustomerInvoiceList");
        }

        [Then("the Print Invoices button is inactive")]
        public void ThenThePrintInvoicesButtonIsInactive()
        {
            Report.WriteLine("Checking if the print invoices button is disabled");
            VerifyElementVisible(attributeName_xpath, CustomerInvoices_PrintInvoicesButtonDisabled_Xpath, "DisabledPrintCustomerInvoiceList");
        }

        [Then("the Print Invoices button is active")]
        public void ThenThePrintInvoicesButtonIsactive()
        {
            Report.WriteLine("Checking if print invoices button is active");
            VerifyElementVisible(attributeName_xpath, CustomerInvoices_PrintInvoicesButtonEnabled_Xpath, "EnabledPrintCustomerInvoiceList");
        }

        [Then(@"a new tab will open")]
        public void ThenANewTabWillOpen()
        {
            Report.WriteLine("Checking if a new tab has opened");
            var amountOfTabs = GlobalVariables.webDriver.WindowHandles;
            GlobalVariables.webDriver.SwitchTo().Window(amountOfTabs[1]);            
        }

        [Then(@"the selected invoice\(s\) will download into a zip folder in the new tab")]
        public void ThenTheSelectedInvoiceSWillDownloadIntoAZipFolderInTheNewTab()
        {
            Report.WriteLine("Checking if file has downloaded");
            Thread.Sleep(8000);

            string downloadPath = GetDownloadedFilePath("SelectedInvoices.zip");
            VerifyFilePresence(".zip", "SelectedInvoices");
            DeleteFilesFromFolder(downloadPath);

        }

        [Then(@"I will have the option to select all of the displayed invoices,")]
        public void ThenIWillHaveTheOptionToSelectAllOfTheDisplayedInvoices()
        {
            Report.WriteLine("Checking if invoices are selectable");
            IsHtmlElementIsExist(attributeName_xpath, CustomerInvoices_AllInvoiceCheckBox_Xpath);
        }

    }
}