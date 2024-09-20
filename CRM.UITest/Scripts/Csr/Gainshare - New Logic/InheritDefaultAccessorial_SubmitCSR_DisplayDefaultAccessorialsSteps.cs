using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Helper.Implementations;
using CRM.UITest.Helper.Implementations.CSR;
using CRM.UITest.Helper.Implementations.Default_Accessorials;
using CRM.UITest.Helper.Interfaces;
using CRM.UITest.Helper.Interfaces.Default_Accessorials;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Csr.Gainshare___New_Logic
{
    [Binding]
    public class InheritDefaultAccessorial_SubmitCSR_DisplayDefaultAccessorialsSteps : Submit_CSR
    {
        IGetCustomerAccountId getCustomerAccountId = new GetCustomerAccountId();
        IGetStationCarrierDefaultAccessorials getStationCarrierDefaultAccessorials = new GetStationCarrierDefaultAccessorials();
        IGetStationIndividualDefaultAccessorials getStationIndividualDefaultAccessorials = new GetStationIndividualDefaultAccessorials();
        IGetCorporateIndividualDefaultAccessorials getCorporateIndividualDefaultAccessorials = new GetCorporateIndividualDefaultAccessorials();
        IGetCorporateCarrierDefaultAccessorials getCorporateCarrierDefaultAccessorials = new GetCorporateCarrierDefaultAccessorials();
        IGetPrimaryCustomerAccountIndividualAccessorials getPrimaryIndividualAccessorials = new GetPrimaryCustomerAccountIndividualAccessorials();
        IGetPrimaryCustomerCarrierAccessorials getPrimaryCarrierAccessorials = new GetPrimaryCustomerCarrierAccessorials();
        AccessorialHelpers accessorialHelpers = new AccessorialHelpers(); 

        [Given(@"I choose Gainshare from the Select A Pricing Type drop down list")]
        public void GivenIChooseGainshareFromTheSelectAPricingTypeDropDownList()
        {
            Report.WriteLine("Selecting Gainshare as the pricing type");
            Click(attributeName_xpath, PricingType_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, PricingType_DropDownDropDownList_Xpath, "Gainshare");
            GlobalVariables.webDriver.WaitForPageLoad();

            Thread.Sleep(1000);
            Report.WriteLine("Setting gainshare pricing values");
            WaitForElementVisible(attributeName_id, Gainshare_percentage_Id, "Gainshare %");
            SendKeys(attributeName_id, Gainshare_percentage_Id, "50");
            SendKeys(attributeName_xpath, Gainshare_Minimum_Textbox_xpath, "50");
            SendKeys(attributeName_xpath, Gainshare_Master_Accessorial_Charge_Textbox_Xpath, "50");

            Report.WriteLine("Setting Carriers Excluded to no");
            IWebElement carriersExcludedNo = GlobalVariables.webDriver.FindElement(By.XPath(Gainshare_carriersExcluded_No_Radiobutton_Xpath));
            WebDriverHelpers.SetAttribute(carriersExcludedNo, "checked", "true");
            Report.WriteLine("Setting Household Goods to no");
            IWebElement householdGoodsNo = GlobalVariables.webDriver.FindElement(By.XPath(Gainshare_Household_Goods_No_Radiobutton_Xpath));
            WebDriverHelpers.SetAttribute(householdGoodsNo, "checked", "true");
        }

        [Given(@"I have selected the station ""(.*)"" that has default accessorials")]
        public void GivenIHaveSelectedTheStation(string stationID)
        {
            Report.WriteLine("Selecting " + stationID + " from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, stationID);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected Primary Customer Account")]
        public void GivenISelectedPrimaryCustomerAccount()
        {
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Clicking primary account");
            Click(attributeName_xpath, Primary_CSR_Type_Xpath);
        }

        [Given(@"I have entered valid information on the Account information page after station ID and customer account type")]
        public void GivenIHaveEnteredValidInformationOnTheAccountInformationPageAfterStationIDAndCustomerAccountType()
        {
            Report.WriteLine("Clicking MG as TMS type");
            WebDriverHelpers.CheckRadioButton(GlobalVariables.webDriver.FindElement(By.XPath(TMS_System_MG_Input_Xpath)));

            Report.WriteLine("Entering customer account name as 96964 customer");
            SendKeys(attributeName_xpath, Customer_Account_Name_Xpath, "96964 customer");

            Report.WriteLine("Selecting No Invoice");
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Customer_Invoice_Method_Xpath, "No Invoice");

            Report.WriteLine("Clicking Save and Continue");
            Click(attributeName_xpath, Save_And_Continue_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I enter valid information to the Locations and Contacts page")]
        public void GivenIEnterValidInformationToTheLocationsAndContactsPage()
        {
            Report.WriteLine("Entering 97682 as the location name");
            SendKeys(attributeName_xpath, CustomerLocation_Name_Textbox_Xpath, "97682");
            Report.WriteLine("Entering 97682 as Address line 1");
            SendKeys(attributeName_xpath, CustomerLocation_Address1_Textbox_Xpath, "97682");
            Report.WriteLine("Entering Chicago as the city");
            SendKeys(attributeName_xpath, CustomerLocation_City_Textbox_Xpath, "Chicago");

            Report.WriteLine("Selecting AL as the state");
            Click(attributeName_xpath, CustomerLocation_StateDropDown_Xpath);
            IWebElement stateFromDropdown = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='state-customer-location-select_listbox']/li[3]"));
            WebDriverHelpers.ClickElementFromDropDown(stateFromDropdown);

            Report.WriteLine("Entering 60606 as the zip code");
            SendKeys(attributeName_xpath, CustomerLocation_Zip_Textbox_Xpath, "60606");

            Report.WriteLine("Entering 97682 as the contact name");
            SendKeys(attributeName_xpath, CustomerContactInformation_Name_Textbox_Xpath, "97682");
            Report.WriteLine("Entering 9999999999 as the phone number");
            SendKeys(attributeName_xpath, CustomerContactInformation_PhoneNumber_Textbox_Xpath, "9999999999");
            Report.WriteLine("Entering 97682@97682.com as the email address");
            SendKeys(attributeName_xpath, CustomerContactInformation_Email_Textbox_Xpath, "97682@97682.com");

            Report.WriteLine("Clicking on the use customer location and contact info for bill to location and contact details");
            Click(attributeName_xpath, CheckBox_UseCustomerLocation_ContactInformation_for_BillToLocation_Contact_Details);

            Report.WriteLine("Clicking on save and continue");
            Click(attributeName_xpath, LocationsAndContacts_SaveAndContinueButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            string currentURL = GlobalVariables.webDriver.Url;

            Report.WriteLine("Verifying User is navigated ot the customer pricing page");

            VerifyElementVisible(attributeName_xpath, PricingPage_Text_Xpath, "Pricing Header");
        }

        [Given(@"I am submitting a revised csr for the account name ""(.*)""")]
        public void GivenIAmSubmittingARevisedCsrForTheAccountName(string customerName)
        {
            Report.WriteLine("Navigating to Usermanagement page");
            string baseURL = ConfigurationManager.AppSettings["BaseUrl"];
            GlobalVariables.webDriver.Url = baseURL + "/L/UserManagement/Index";

            Report.WriteLine("Searching " + customerName + " in the customer profiles");
            SendKeys(attributeName_id, SearchCustomer_id, customerName);

            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Navigating to " + customerName + "'s customer details");
            Click(attributeName_xpath, string.Format("//a[contains(.,'" + customerName + "')]"));
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have selected the station ""(.*)"" that does not have default accessorials")]
        public void GivenIHaveSelectedTheStationThatDoesNotHaveDefaultAccessorials(string stationID)
        {
            Report.WriteLine("Selecting " + stationID + " from station id dropdown");
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_Id_DropDown_Xpath, stationID);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I selected Sub Account")]
        public void GivenISelectedSubAccount()
        {
            WaitForElementNotVisible(attributeName_id, Loading_Icon_Id, "Loading Icon");
            Report.WriteLine("Clicking sub account");
            Click(attributeName_xpath, Sub_CSR_Type_Xpath);
        }

        [Given(@"I have selected ""(.*)"" for the Primary Customer Account that contains default accessorials")]
        [Given(@"I have selected ""(.*)"" for the Primary Customer Account that does not contain default accessorials")]
        public void GivenIHaveSelectedForThePrimaryCustomerAccountThatDoesNotContainDefaultAccessorials(string primaryAccount)
        {
            Report.WriteLine("Selecting " + primaryAccount + " as the primary account for the CSR.");
            Click(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath);
            Click(attributeName_xpath, "//li[contains(text(), '" + primaryAccount + "')]");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will see ""(.*)"" for the accessorial values")]
        public void ThenIWillSeeForTheAccessorialValues(string expectedAccessorialValues)
        {
            Thread.Sleep(500);
            Report.WriteLine("Verifying carrier accessorials are shown in the Gainshare menu.");
            string actualAccessorialValues = Gettext(attributeName_id, "AccType1");
            Assert.AreEqual(expectedAccessorialValues, actualAccessorialValues);
        }

        [Then(@"I wIll see ""(.*)"" for the individual accessorials")]
        public void ThenIWIllSeeForTheIndividualAccessorials(string expectedAccessorialValues)
        {
            Thread.Sleep(500);
            Report.WriteLine("Verifying individual accessorials are shown in the Gainshare menu");
            string actualAccessorialValues = Gettext(attributeName_id, "AccType0");
            Assert.AreEqual(expectedAccessorialValues, actualAccessorialValues);
        }

        [Then(@"I will see the station level default accessorials for station ""(.*)""")]
        public void ThenIWillSeeStationLevelDefaultAccessorialsForStation(string stationId)
        {
            Thread.Sleep(500);
            Report.WriteLine("Getting Station Level Individual Default Accessorials");
            List<DefaultAccessorialSetupModel> stationLevelIndividualDefaultAccessorials = getStationIndividualDefaultAccessorials.GetDefaultIndividualAccessorialsForStation(stationId);

            Report.WriteLine("Getting station level carrier default accessorials");
            List<DefaultAccessorialSetupModel> stationLevelCarrierDefaultAccessorials = getStationCarrierDefaultAccessorials.GetCarrierDefaultAccessorialsForStation(stationId);

            if(stationLevelIndividualDefaultAccessorials.Count == 0 && stationLevelCarrierDefaultAccessorials.Count == 0)
            {
                Report.WriteFailure("There are no station level default accessorials");
            }

            List<CsrCustomerAccessorial> individualAccessorialsFromScreen = accessorialHelpers.getIndividualAccessorialsFromScreen();
            List<CsrCustomerAccessorial> carrierAccessorialsFromScreen = accessorialHelpers.getCarrierAccessorialsFromScreen();

            Report.WriteLine("Comparting Count of accessorials from screen to in DB first");
            if(individualAccessorialsFromScreen.Count != stationLevelIndividualDefaultAccessorials.Count && 
                carrierAccessorialsFromScreen.Count != stationLevelCarrierDefaultAccessorials.Count)
            {
                Report.WriteFailure("There is a different amount of accessorials on screen compared to DB");
            }

            Report.WriteLine("Comparing individual accessorials on screen to ones in DB");
            accessorialHelpers.compareIndividualAccessorials(stationLevelIndividualDefaultAccessorials, individualAccessorialsFromScreen);

            Report.WriteLine("Comparing carrier accessorials on screen to ones in DB");
            accessorialHelpers.compareCarrierAccessorials(stationLevelCarrierDefaultAccessorials, carrierAccessorialsFromScreen);
        }

        [Then(@"I will see the Corporate level default accessorials")]
        public void ThenIWillSeeCorporateLevelDefaultAccessorials()
        {
            Thread.Sleep(500);
            Report.WriteLine("Getting Corproate Level Individual Default Accessorials");
            List<DefaultAccessorialSetupModel> corporateIndividualDefaultAccessorials = getCorporateIndividualDefaultAccessorials.GetDefaultIndividualAccessorialsForCorporate();

            Report.WriteLine("Getting Corproate level carrier default accessorials");
            List<DefaultAccessorialSetupModel> corporateCarrierDefaultAccessorials = getCorporateCarrierDefaultAccessorials.GetCarrierDefaultAccessorialsForCorporate();

            if (corporateIndividualDefaultAccessorials.Count == 0 && corporateCarrierDefaultAccessorials.Count == 0)
            {
                Report.WriteFailure("There are no corporate level default accessorials");
            }

            List<CsrCustomerAccessorial> individualAccessorialsFromScreen = accessorialHelpers.getIndividualAccessorialsFromScreen();
            List<CsrCustomerAccessorial> carrierAccessorialsFromScreen = accessorialHelpers.getCarrierAccessorialsFromScreen();

            Report.WriteLine("Comparting Count of accessorials from screen to in DB first");
            if (individualAccessorialsFromScreen.Count != corporateIndividualDefaultAccessorials.Count &&
                carrierAccessorialsFromScreen.Count != corporateCarrierDefaultAccessorials.Count)
            {
                Report.WriteFailure("There is a different amount of accessorials on screen compared to DB");
            }

            Report.WriteLine("Comparing individual accessorials on screen to ones in DB");
            accessorialHelpers.compareIndividualAccessorials(corporateIndividualDefaultAccessorials, individualAccessorialsFromScreen);

            Report.WriteLine("Comparing carrier accessorials on screen to ones in DB");
            accessorialHelpers.compareCarrierAccessorials(corporateCarrierDefaultAccessorials, carrierAccessorialsFromScreen);
        }

        [Then(@"I will see the default accessorials for the primary account ""(.*)""")]
        public void ThenIWillSeeTheDefaultAccessorialsForThePrimaryAccount(string primaryAccountName)
        {
            Thread.Sleep(500);
            
            int primaryAccountId = getCustomerAccountId.GetCustomerAccountIdFromDb(primaryAccountName);
            Report.WriteLine("Getting Primary Customer Level Individual Default Accessorials");
            List<DefaultAccessorialSetupModel> primaryAccountIndividualAccessorials = getPrimaryIndividualAccessorials.GetAccessorialsFromCsrStage(primaryAccountId);

            Report.WriteLine("Getting Corproate level carrier default accessorials");
            List<DefaultAccessorialSetupModel> primaryAccountCarrierAccessorials = getPrimaryCarrierAccessorials.GetCarrierAccessorialsFromCsrStage(primaryAccountId);

            if (primaryAccountIndividualAccessorials.Count == 0 && primaryAccountCarrierAccessorials.Count == 0)
            {
                Report.WriteFailure("There are no station level default accessorials");
            }

            List<CsrCustomerAccessorial> individualAccessorialsFromScreen = accessorialHelpers.getIndividualAccessorialsFromScreen();
            List<CsrCustomerAccessorial> carrierAccessorialsFromScreen = accessorialHelpers.getCarrierAccessorialsFromScreen();

            Report.WriteLine("Comparing Count of accessorials from screen to in DB first");
            if (individualAccessorialsFromScreen.Count != primaryAccountIndividualAccessorials.Count &&
                carrierAccessorialsFromScreen.Count != primaryAccountCarrierAccessorials.Count)
            {
                Report.WriteFailure("There is a different amount of accessorials on screen compared to DB");
            }

            Report.WriteLine("Comparing individual accessorials on screen to ones in DB");
            accessorialHelpers.compareIndividualAccessorials(primaryAccountIndividualAccessorials, individualAccessorialsFromScreen);

            Report.WriteLine("Comparing carrier accessorials on screen to ones in DB");
            accessorialHelpers.compareCarrierAccessorials(primaryAccountCarrierAccessorials, carrierAccessorialsFromScreen);
        }
    }
}
