using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.Gainshare___New_Logic
{
    [Binding]
    public class Inherit_Default_Accessorial___Customer_Details_Steps : Submit_CSR
    {
        string createdCsrName = string.Empty;
        ClickAndWaitMethods clickMethods = new ClickAndWaitMethods();
        [Given(@"I have created a CSR doesn't have Gainshare - New Logic applied ""(.*)""")]
        public void GivenIHaveCreatedACSRDoesnTHaveGainshare_NewLogicApplied(string csrName)
        {
            createdCsrName = csrName;
            Report.WriteLine("Creating a new CSR from Dashboard");
            WaitForElementVisible(attributeName_id, Dashboard_CreateCSR_button_Id, "Create CSR Dashboard button");
            Click(attributeName_id, Dashboard_CreateCSR_button_Id);

            Report.WriteLine("Selecting 011 from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, "011");
            GlobalVariables.webDriver.WaitForPageLoad();

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Clicking primary account");
            Click(attributeName_xpath, Primary_CSR_Type_Xpath);
            Report.WriteLine("Clicking MG as TMS type");
            IWebElement mg = GlobalVariables.webDriver.FindElement(By.XPath("//input[contains(@id, 'tms-systems-1')]"));
            WebDriverHelpers.SetAttribute(mg, "checked", "true");
            Report.WriteLine("Entering customer account name as " + createdCsrName);
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, createdCsrName);

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");

            Report.WriteLine("Clicking Save and Continue");
            clickMethods.ClickAndWait(attributeName_xpath, Save_And_Continue_Xpath);

            Report.WriteLine("Entering Gainshare New Logic Test as the location name");
            SendKeys(attributeName_xpath, CustomerLocation_Name_Textbox_Xpath, "Gainshare New Logic Test");
            Report.WriteLine("Entering 673 as Address line 1");
            SendKeys(attributeName_xpath, CustomerLocation_Address1_Textbox_Xpath, "673");
            Report.WriteLine("Entering Chicago as the city");
            SendKeys(attributeName_xpath, CustomerLocation_City_Textbox_Xpath, "Chicago");

            Report.WriteLine("Selecting AL as the state");
            Click(attributeName_xpath, CustomerLocation_StateDropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerLocation_StateDropDownList_Xpath, "AL");

            Report.WriteLine("Entering 60606 as the zip code");
            SendKeys(attributeName_xpath, CustomerLocation_Zip_Textbox_Xpath, "60606");

            Report.WriteLine("Entering 96967 as the contact name");
            SendKeys(attributeName_xpath, CustomerContactInformation_Name_Textbox_Xpath, "96967");
            Report.WriteLine("Entering 9999999999 as the phone number");
            SendKeys(attributeName_xpath, CustomerContactInformation_PhoneNumber_Textbox_Xpath, "9999999999");
            Report.WriteLine("Entering 96967@test.com as the email address");
            SendKeys(attributeName_xpath, CustomerContactInformation_Email_Textbox_Xpath, "96967@test.com");

            Report.WriteLine("Clicking on the use customer location and contact info for bill to location and contact details");
            Click(attributeName_xpath, CheckBox_UseCustomerLocation_ContactInformation_for_BillToLocation_Contact_Details);

            Report.WriteLine("Clicking on save and continue");
            clickMethods.ClickAndWait(attributeName_xpath, LocationsAndContacts_SaveAndContinueButton_Xpath);

            Report.WriteLine("Selecting the pricing type Gainshare");
            Click(attributeName_xpath, PricingType_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PricingType_DropDownDropDownList_Xpath, "Gainshare");
            GlobalVariables.webDriver.WaitForPageLoad();

            if(!createdCsrName.Contains("No"))
            {
                Report.WriteLine("Selecting Gainshare - New Logic check box");
                Click(attributeName_xpath, PricingModel_Gainshare_New_Logic_Checkbox_Xpath);
            }
            else
            {
                Report.WriteLine("Gainshare - New Logic check box is not selected");
            }


        }

        [Given(@"I have completed the CSR approval process")]
        public void GivenIHaveCompletedTheCSRApprovalProcess()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I am on the Account Management page")]
        public void GivenIAmOnTheAccountManagementPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have searched for the CSR ""(.*)""")]
        public void GivenIHaveSearchedForTheCSR(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I am on the Customer Details screen for the customer")]
        public void WhenIAmOnTheCustomerDetailsScreenForTheCustomer()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the Pricing Model banner will read ""(.*)""")]
        public void ThenThePricingModelBannerWillRead(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the CRM Rating Logic cannot be edited")]
        public void ThenTheCRMRatingLogicCannotBeEdited()
        {
            ScenarioContext.Current.Pending();
        }

    }
}
