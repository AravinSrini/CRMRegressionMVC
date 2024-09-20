using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.Gainshare___New_Logic
{
    [Binding]
    public sealed class _96967___Inherit_Default_Accessorial___Customer_Details : Submit_CSR
    {
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();

        [Given(@"I am on the Pricing Model page for a new CSR ""(.*)""")]
        public void GivenIAmOnThePricingModalPageForANewCSR(string csrName)
        {
            Report.WriteLine("Selecting ZZZ from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            WebDriverHelpers.ClickElementFromDropDown(GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='customer-station-id_listbox']/li[text() = 'ZZZ']")));
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Clicking primary account");
            IWebElement primaryType = GlobalVariables.webDriver.FindElement(By.XPath(Primary_Csr_Type_Radio_Xpath));
            WebDriverHelpers.CheckRadioButton(primaryType);

            Report.WriteLine("Clicking MG as TMS type");
            IWebElement mg = GlobalVariables.webDriver.FindElement(By.XPath("//input[contains(@id, 'tms-systems-1')]"));
            WebDriverHelpers.SetAttribute(mg, "checked", "true");

            Report.WriteLine("Entering customer account name as " + csrName);
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, csrName);

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            IWebElement invoiceMethodSelection = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='customer-invoice-method_listbox']/li[4]"));
            WebDriverHelpers.ClickElementFromDropDown(invoiceMethodSelection);

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);

            Report.WriteLine("Entering 96964 as the location name");
            SendKeys(attributeName_xpath, CustomerLocation_Name_Textbox_Xpath, "96967");
            Report.WriteLine("Entering 96964 as Address line 1");
            SendKeys(attributeName_xpath, CustomerLocation_Address1_Textbox_Xpath, "96967");
            Report.WriteLine("Entering Chicago as the city");
            SendKeys(attributeName_xpath, CustomerLocation_City_Textbox_Xpath, "Chicago");

            Report.WriteLine("Selecting AL as the state");
            Click(attributeName_xpath, CustomerLocation_StateDropDown_Xpath);
            IWebElement stateDropdownSelection = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='state-customer-location-select_listbox']/li[2]"));
            WebDriverHelpers.ClickElementFromDropDown(stateDropdownSelection);

            Report.WriteLine("Entering 60606 as the zip code");
            SendKeys(attributeName_xpath, CustomerLocation_Zip_Textbox_Xpath, "60606");

            Report.WriteLine("Entering 96964 as the contact name");
            SendKeys(attributeName_xpath, CustomerContactInformation_Name_Textbox_Xpath, "96967");
            Report.WriteLine("Entering 9999999999 as the phone number");
            SendKeys(attributeName_xpath, CustomerContactInformation_PhoneNumber_Textbox_Xpath, "9999999999");
            Report.WriteLine("Entering 96965@96964.com as the email address");
            SendKeys(attributeName_xpath, CustomerContactInformation_Email_Textbox_Xpath, "96967@96967.com");

            Report.WriteLine("Clicking on the use customer location and contact info for bill to location and contact details");
            Click(attributeName_xpath, CheckBox_UseCustomerLocation_ContactInformation_for_BillToLocation_Contact_Details);

            Report.WriteLine("Clicking on save and continue");
            clickMethods.ClickAndWait(attributeName_xpath, LocationsAndContacts_SaveAndContinueButton_Xpath);

            Report.WriteLine("Verifying User is navigated ot the customer pricing page");

            Verifytext(attributeName_xpath, "//*[@id='main']/div[2]/div/h3", "Pricing Model");
        }

        [Given(@"I Submit and approve the CSR ""(.*)""")]
        [When(@"I Submit and approve the CSR ""(.*)""")]
        public void GivenISubmitAndApproveTheCSR(string csrName)
        {
            Report.WriteLine("Submitting the csr");
            clickMethods.ClickAndWait(attributeName_xpath, ReviewSubmitPage_Submit_Csr_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ReviewSubmitPage_Close_button_Xpath);

            Report.WriteLine("Searching " + csrName + " in the customer profiles");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Report.WriteLine("Navigating to " + csrName + "'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + csrName + "')]");
            
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Creation_Status_Approve_Button_Xpath, "Approve Button");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            clickMethods.ClickAndWait(attributeName_xpath, Creation_Status_Approve_Button_Xpath);
            WaitForElementVisible(attributeName_xpath, Confirm_Yes_Button_Xpath, "Confirm Yes Button");
            clickMethods.ClickAndWait(attributeName_xpath, Confirm_Yes_Button_Xpath);
            Thread.Sleep(1000);
            clickMethods.ClickAndWait(attributeName_xpath, waitingToProcessMoreInformationApproveButton_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Searching " + csrName + " in the customer profiles");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Report.WriteLine("Navigating to " + csrName + "'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + csrName + "')]");

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, completeCSRProcessButton_Xpath, "Approve Button");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessButton_Xpath);
            WaitForElementVisible(attributeName_xpath, completeCSRProcessSubmitButton_Xpath, "Confirmation Approve");
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessSubmitButton_Xpath);
            Thread.Sleep(2000);
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessCompleteRequestSubmitButton_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Searching " + csrName + " in the customer profiles");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Report.WriteLine("Navigating to " + csrName + "'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + csrName + "')]");

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, completeCSRProcessPricingConfigurationCompleteButton_Xpath, "Approve Button");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessPricingConfigurationCompleteButton_Xpath);
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Thread.Sleep(2000);
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessPricingConfigurationCompleteClose_Xpath);
        }

        [When(@"I Submit and approve the CSR ""(.*)"" for CSA")]
        [Given(@"I Submit and approve the CSR ""(.*)"" for CSA")]
        public void GivenISubmitAndApproveTheCSRForCSA(string csrName)
        {
            Report.WriteLine("Submitting the csr");
            clickMethods.ClickAndWait(attributeName_xpath, ReviewSubmitPage_Submit_Csr_Button_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ReviewSubmitPage_Close_button_Xpath);

            Report.WriteLine("Searching " + csrName + " in the customer profiles");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Report.WriteLine("Navigating to " + csrName + "'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + csrName + "')]");

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, Creation_Status_Approve_Button_Xpath, "Approve Button");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            clickMethods.ClickAndWait(attributeName_xpath, Creation_Status_Approve_Button_Xpath);
            WaitForElementVisible(attributeName_xpath, Confirm_Yes_Button_Xpath, "Confirm Yes Button");
            clickMethods.ClickAndWait(attributeName_xpath, Confirm_Yes_Button_Xpath);
            Thread.Sleep(1000);
            clickMethods.ClickAndWait(attributeName_xpath, waitingToProcessMoreInformationApproveButton_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Searching " + csrName + " in the customer profiles");
            SendKeys(attributeName_xpath, CSRList_Searchbox_Xpath, csrName);
            Report.WriteLine("Navigating to " + csrName + "'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + csrName + "')]");

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, completeCSRProcessButton_Xpath, "Approve Button");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessButton_Xpath);
            WaitForElementVisible(attributeName_xpath, completeCSRProcessSubmitButton_Xpath, "Confirmation Approve");
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessSubmitButton_Xpath);
            Thread.Sleep(2000);
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessCompleteRequestSubmitButton_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, completeCSRProcessPricingConfigurationCompleteClose_Xpath, "Confirmation Approve");
            Thread.Sleep(2000);
            clickMethods.ClickAndWait(attributeName_xpath, completeCSRProcessPricingConfigurationCompleteClose_Xpath);
        }

        [When(@"I navigate to the Customer Details page ""(.*)""")]
        public void WhenINavigateToTheCustomerDetailsPage(string csrName)
        {
            Report.WriteLine("Navigating to the user management page");
            clickMethods.ClickAndWait(attributeName_xpath, UserManagementIcon_Xpath);

            Report.WriteLine("Searching " + csrName + " in the customer profiles");
            SendKeys(attributeName_id, SearchCustomer_id, csrName);
            Thread.Sleep(4000);
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Navigating to " + csrName + "/'s customer details");
            clickMethods.ClickAndWait(attributeName_xpath, "//a[contains(.,'" + csrName + "')]");
            Thread.Sleep(2000);
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
        }

        [Then(@"I will see CRM Rating Logic - ""(.*)"" displayed in the banner of the Pricing Model section")]
        public void ThenIWillSeeCRMRatingLogic_DisplayedInTheBannerOfThePricingModelSection(string expectedLogicValue)
        {
            scrollpagedown();
            Report.WriteLine("Verifying Crm Rating Logic value is set to " + expectedLogicValue);
            string actualLogicValue = GlobalVariables.webDriver.FindElement(By.XPath(CustomerDetails_CRM_Rating_Logic_Value_Xpath)).Text;
            Assert.AreEqual(expectedLogicValue, actualLogicValue);
        }

        [Then(@"I cannot edit the crm rating option")]
        public void ThenIAmUnableToEditThisInformation()
        {
            Report.WriteLine("Expanding Pricing Model");
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Click(attributeName_xpath, CustomerDetails_Expand_Pricing_Model_Xpath);
            Thread.Sleep(1000);

            Report.WriteLine("Verifying edit is not there");
            VerifyElementNotPresent(attributeName_xpath, CustomerDetails_Edit_Gainshare_Span_Xpath, "Edit Pricing Section");
        }
    }
}
