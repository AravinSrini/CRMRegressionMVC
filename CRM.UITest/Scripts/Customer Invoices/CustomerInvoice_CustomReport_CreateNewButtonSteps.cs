using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Threading;

namespace CRM.UITest.Scripts.Customer_Invoices
{
    [Binding]
    public class CustomerInvoice_CustomReport_CreateNewButtonSteps : Customer_Invoice
    {       
        string ReportName = Guid.NewGuid().ToString() + "CustomRprtTst";
        string DBCustomReport = null;
        string customReportName = null;
        string email = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner, or an access rrd user")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerOrAnAccessRrdUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a shp\.entry, shp\.entrynortes, shp\.inquiry, shp\.inquirynorates, operations, sales, sales management, station owner, or an access rrd user\.")]
        public void GivenIAmAShp_EntryShp_EntrynortesShp_InquiryShp_InquirynoratesOperationsSalesSalesManagementStationOwnerOrAnAccessRrdUser_()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on Customer Invoice page")]
        public void GivenIAmOnCustomerInvoicePage()
        {
            Click(attributeName_xpath, customerInvoiceIcon_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementPresent(attributeName_xpath, customerInvoicesHeader_xpath, "Customer Invoice");
            Report.WriteLine("Navigated to Custom Invoice page");
        }

        [Given(@"A Custom Report has been selected from the Select Existing Custom Report dropdown")]
        public void GivenACustomReportHasBeenSelectedFromTheSelectExistingCustomReportDropdown()
        {
            customReportName = DBHelper.GetNotScheduledCustomReportName(email);
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            Thread.Sleep(3000);
            SelectDropdownValueFromList(attributeName_xpath, SelectExistingReportDropdownValues_xpath, customReportName);
            Report.WriteLine("Existing Custom Report has been selected from the dropdown");
        }
        
        [Given(@"The Create Custom Report section has been expanded")]
        public void GivenTheCreateCustomReportSectionHasBeenExpanded()
        {
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            Report.WriteLine("Create Custom Report section is expanded");
            WaitForElementVisible(attributeName_xpath, ReportName_Xpath,"Report Section");
        }
        
        [Given(@"Data is been passed to all the required fields of Create Custom report section")]
        public void GivenDataIsBeenPassedToAllTheRequiredFieldsOfCreateCustomReportSection()
        {
            SendKeys(attributeName_id, DaysPastDue_Id, "5");
            SendKeys(attributeName_id, InvoiceVal_Id, "4");
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, "ZZZ - Web Services Test");
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "2018 Agent Meeting");
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            Report.WriteLine("Values are passed to all the fields");
        }
        [Given(@"Report Name field is passed with an existing report name")]
        public void GivenReportNameFieldIsPassedWithAnExistingReportName()
        {
            customReportName = DBHelper.GetNotScheduledCustomReportName(email);
            WaitForElementPresent(attributeName_xpath, ReportName_Xpath, "Report");
            SendKeys(attributeName_xpath, ReportName_Xpath, customReportName);
            Report.WriteLine("Report Name field is passed with an existing report name");
        }

        [Then(@"An error message should get displayed")]
        public void ThenAnErrorMessageShouldGetDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, ValidationMessageCreateSection_Xpath, "Error Message");
            Verifytext(attributeName_xpath, ValidationMessageCreateSection_Xpath, "Customer Report Name already exists");
            Report.WriteLine("Error message is displayed when report name already exists");

        }

        [Given(@"Data is not passed to all the required fields")]
        public void GivenDataIsNotPassedToAllTheRequiredFields()
        {
            Click(attributeName_id, createCustomReportsectionExpandArrow_id);
            SendKeys(attributeName_id, DaysPastDue_Id, "5");
            Click(attributeName_xpath, ReportStationName_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomReport_Stations_Xpath, "ZZZ - Web Services Test");
            Click(attributeName_xpath, ReportAccount_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ReportAccountDropdownVal_Xpath, "2018 Agent Meeting");
            Report.WriteLine("Data is not passed to all the fields");
        }
        
        [Given(@"Report Name field is been edited")]
        public void GivenReportNameFieldIsBeenEdited()
        {
           
            WaitForElementPresent(attributeName_xpath, ReportName_Xpath, "Report");
            SendKeys(attributeName_xpath, ReportName_Xpath, ReportName);
            Report.WriteLine("Report Name field is edited");
            
        }

        [Given(@"Report Name field is been edited by giving an existing name")]
        public void GivenReportNameFieldIsBeenEditedByGivingAnExistingName()
        {
            
            Clear(attributeName_xpath, ReportName_Xpath);
            Thread.Sleep(2000);
            WaitForElementPresent(attributeName_xpath, ReportName_Xpath, "Report");
            SendKeys(attributeName_xpath, ReportName_Xpath, customReportName);
            Report.WriteLine("Report Name field is been edited by giving an existing name");
        }


        [When(@"I edit the Report Name field")]
        public void WhenIEditTheReportNameField()
        {
            SendKeys(attributeName_xpath, ReportName_Xpath, "CustomeTest1");
            Report.WriteLine("Report Name is edited");
        }
        
        [When(@"I click on Create New button")]
        public void WhenIClickOnCreateNewButton()
        {
            Click(attributeName_id, CreateReportNewButton_Id);
            Report.WriteLine("Create New button is clicked");
        }
        
        [Then(@"The Create New button should become active")]
        public void ThenTheCreateNewButtonShouldBecomeActive()
        {
            VerifyElementEnabled(attributeName_id, CreateReportNewButton_Id, "Create Button");
            Report.WriteLine("Create New Button is active");
        }
        
        [Then(@"The Delete button should become inactive")]
        public void ThenTheDeleteButtonShouldBecomeInactive()
        {
            VerifyElementNotEnabled(attributeName_id, DeleteReportButton_Id, "Delete Button");
            Report.WriteLine("Report Delete button is inactive");
        }
        
        [Then(@"The Custom report should get saved")]
        public void ThenTheCustomReportShouldGetSaved()
        {
            int setUpId = DBHelper.GetCustomerSetupId("2018 Agent Meeting");
            InvoiceCustomReport CustomReportValues = DBHelper.GetCustomReportDetails("ZZZ - Web Services Test", setUpId);
            Assert.AreEqual(CustomReportValues.DaysPastDue, 5);
            Assert.AreEqual(CustomReportValues.InvoiceValue, 4);
            DBCustomReport = CustomReportValues.CustomReportName;
            if (CustomReportValues.CustomReportName.Contains(ReportName))
            {
                Report.WriteLine("Created Custom Report exists in DB");
            }
            else
            {
                Assert.Fail();
            }
            if(CustomReportValues.InvoiceTypeId == 1)
            {
                Report.WriteLine("Invoice Type is in Open Status");
            }
            else
            {
                Assert.Fail();
            }

            Report.WriteLine("Created Custom report is saved");
        }

        [Then(@"The Create Custom Report section should collapse")]
        public void ThenTheCreateCustomReportSectionShouldCollapse()
        {
            WaitForElementNotVisible(attributeName_id, CreateReportNewButton_Id, "report section");
            VerifyElementNotVisible(attributeName_id, CreateReportNewButton_Id, "Button");
            Report.WriteLine("Create Custom Report section is collapsed");
        }
        
        [Then(@"The newly created report should be available to select from the Select Existing Custom Report drop down list\.")]
        public void ThenTheNewlyCreatedReportShouldBeAvailableToSelectFromTheSelectExistingCustomReportDropDownList_()
        {
            int j = 0;
            List<string> ExistingCustomReport = new List<string>();
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            IList<IWebElement> UISelectCustomReport = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            int UISelectCustomReportCount = UISelectCustomReport.Count;
            for (int i = 1; i < UISelectCustomReportCount; i++)
            {

                IList<IWebElement> UISelectCustomReportGet = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='customReportSelection_chosen']/div/ul/li[" + i + "] "));
                foreach (IWebElement element in UISelectCustomReportGet)
                {
                    ExistingCustomReport.Add((element.Text).ToString());

                }
            }
           
            if (ExistingCustomReport.Contains(ReportName))
            {
                Report.WriteLine("Newly created report exists in Select Existing Custom Report drop down list");
            }
            else
            {
                Assert.Fail();

            }

        }

        [Then(@"The report should not get saved")]
        public void ThenTheReportShouldNotGetSaved()
        {
            VerifyElementPresent(attributeName_id, CreateReportNewButton_Id, "Create Button");
            Report.WriteLine("The report is not saved hence create custom report section is not collapsed");
        }
        
        [Then(@"The missing fields should get highlighted")]
        public void ThenTheMissingFieldsShouldGetHighlighted()
        {
            //string AccountColour = GetCSSValue(attributeName_xpath, ReportAccount_Xpath, "background-color");
            //string ExpecAccountColour = "rgba(251, 236, 236, 1)";
            //Assert.AreEqual(AccountColour, ExpecAccountColour);
            string ReportNamecolour = GetCSSValue(attributeName_xpath, ReportName_Xpath, "background-color");
            string ExpecReportNamecolour = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ReportNamecolour, ExpecReportNamecolour);
            Report.WriteLine("Missing fields are highlighted");
        }
        
        [Then(@"An error message should be displayed stating - Please enter all required information")]
        public void ThenAnErrorMessageShouldBeDisplayedStating_PleaseEnterAllRequiredInformation()
        {
            Verifytext(attributeName_xpath, ValidationMessageCreateSection_Xpath, "Please enter all required information");
            Report.WriteLine("Error message is displayed when all required fields are not passed");
        }
        
        [Then(@"The new report will be saved")]
        public void ThenTheNewReportWillBeSaved()
        {
            Thread.Sleep(2000);
            List<string> GetAllCustomReport = DBHelper.GetAllCustomReports(email);
            if (GetAllCustomReport.Contains(ReportName))
            {
                Report.WriteLine("Edited Custom Report exists in DB");

            }
            else
            {
                Assert.Fail();
            }

        }


        [Then(@"The newly created custom report should be available in the Select Existing Custom Report drop down list\.")]
        public void ThenTheNewlyCreatedCustomReportShouldBeAvailableInTheSelectExistingCustomReportDropDownList_()
        {
            Click(attributeName_xpath, SelectExistingReportDropdown_xpath);
            IList<IWebElement> UISelectCustomReport = GlobalVariables.webDriver.FindElements(By.XPath(SelectExistingReportDropdownValues_xpath));
            int UISelectCustomReportCount = UISelectCustomReport.Count;
            if ("EditReportName".Contains(UISelectCustomReport.ToString()))
            {
                Report.WriteLine("Newly created report exists in Select Existing Custom Report drop down list");
            }

            else
            {
                Assert.Fail();

            }

        }
    }
}
