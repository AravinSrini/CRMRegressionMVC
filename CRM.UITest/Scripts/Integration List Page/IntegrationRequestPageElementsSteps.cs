using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationRequestPageElementsSteps : Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        string rgbColorOfError = "rgba(251, 236, 237, 1)";
        [Given(@"I am a system admin, operations, sales, sales management or station owner user (.*),(.*)")]
        public void GivenIAmASystemAdminOperationsSalesSalesManagementOrStationOwnerUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }
       

        [When(@"I arrive on Integration Request page (.*)")]
        public void WhenIArriveOnIntegrationRequestPage(string IntegrationRequestPageTitle)
        {
            Click(attributeName_id, IntegrationIconLink_Dashboard_id);
            Thread.Sleep(3000);
            Click(attributeName_id, IntegrationRequestButton_Id);
            Verifytext(attributeName_xpath, IntegrationRequestPageTitle_Xpath, IntegrationRequestPageTitle);
            Report.WriteLine("Submit Integration Request Page");
        }
        
        [When(@"I do not pass any values to all the required fields - Station,CompanyName,CompanyContactName,CompanyContactEmail,CompanyContactPhone,IT/DeveloperContactName,IT/DeveloperContactEmail,IT/DeveloperContactPhone,StartDate,TypeOfIntegration")]
        public void WhenIDoNotPassAnyValuesToAllTheRequiredFields_StationCompanyNameCompanyContactNameCompanyContactEmailCompanyContactPhoneITDeveloperContactNameITDeveloperContactEmailITDeveloperContactPhoneStartDateTypeOfIntegration()
        {
            Report.WriteLine("No values are passed to any of the required fields on Integration Request page");
        }
        
        [When(@"I click on the Submit button")]
        public void WhenIClickOnTheSubmitButton()
        {
            Click(attributeName_id, IntegrationSubmitButton_Id);
            Report.WriteLine("Clicked on Submit Button");
        }

        [Then(@"I should be able to view the following fields - Station,CompanyName,CompanyContactName,CompanyContactEmail,CompanyContactPhone,IT/DeveloperContactName,IT/DeveloperContactEmail,IT/DeveloperContactPhone,StartDate,TypeOfIntegration,YearToDateShipments,YearToDateRevenue,PotentialRevenue,AdditionalComments")]
        public void ThenIShouldBeAbleToViewTheFollowingFields_StationCompanyNameCompanyContactNameCompanyContactEmailCompanyContactPhoneITDeveloperContactNameITDeveloperContactEmailITDeveloperContactPhoneStartDateTypeOfIntegrationYearToDateShipmentsYearToDateRevenuePotentialRevenueAdditionalComments()
        {
            Report.WriteLine("Verification of fields on Submit Integration Request page");
            Verifytext(attributeName_xpath, IntegrationStationLabel_Xpath, "STATION *");
            VerifyElementPresent(attributeName_id, IntegrationStaionDropdown_Id, "Station Textbox");
            Report.WriteLine("Station Field is present");
            Verifytext(attributeName_xpath, IntegrationCompanyNameLabel_Xpath, "COMPANY NAME *");
            VerifyElementPresent(attributeName_id, IntegrationCompanyName_Textbox_Id, "Company Name Textbox");
            Report.WriteLine("Company Name is present");
            Verifytext(attributeName_xpath, IntegrationCompanyContactNameLabel_Xpath, "COMPANY CONTACT NAME *");
            VerifyElementPresent(attributeName_id, IntegrationCompanyContactName_Textbox_Id, "Company Contact Name Texbox");
            Report.WriteLine("Company Contact Name Field is present");
            Verifytext(attributeName_xpath, IntegrationCompanyContactPhoneLabel_Xpath, "COMPANY CONTACT PHONE *");
            VerifyElementPresent(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "Company Contact Phone Textbox");
            Report.WriteLine("Company Contact Phone Field is present");
            Verifytext(attributeName_xpath, IntegrationCompanyContactEmailLabel_Xpath, "COMPANY CONTACT EMAIL *");
            VerifyElementPresent(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, "Company Contact Email Textbox");
            Report.WriteLine("Company Contact Email Field is present");
            Verifytext(attributeName_xpath, IntegrationDevContactNameLabel_Xpath, "IT/DEV CONTACT NAME *");
            VerifyElementPresent(attributeName_id, IntegrationDevContactName_Textbox_Id, "IT/DEV Contact Name Textbox");
            Report.WriteLine("IT/DEV Contact Name Field is present");
            Verifytext(attributeName_xpath, IntegrationDevContactPhoneLabel_Xpath, "IT/DEV CONTACT PHONE *");
            VerifyElementPresent(attributeName_id, IntegrationDevContactPhone_Textbox_Id, "IT/DEV Contact Phone Textbox");
            Report.WriteLine("IT/DEV Contact Phone Field is present");
            Verifytext(attributeName_xpath, IntegrationDevContactEmailLabel_Xpath, "IT/DEV CONTACT EMAIL *");
            VerifyElementPresent(attributeName_id, IntegrationDevContactEmail_Textbox_Id, "IT/DEV Contact Email Textbox");
            Report.WriteLine("IT/DEV Contact Email Field is present");
            Verifytext(attributeName_xpath, IntegrationStartDateLabel_Xpath, "START DATE *");
            VerifyElementPresent(attributeName_id, IntegrationStartDatePicker_Id, "Start DatePicker");
            Report.WriteLine("Start DatePicker Field is present");
            Verifytext(attributeName_xpath, IntegrationTypeOfIntegrationLabel_Xpath, "TYPE OF INTEGRATION *");
            VerifyElementPresent(attributeName_id, IntegrationTypeOfIntegration_MultiSelectBox_Id, "Type Of Integration Text box");
            Report.WriteLine("Type Of Integration Field is present");
            Verifytext(attributeName_xpath, IntegrationYearToDateShipLabel_Xpath, "YEAR TO DATE SHIPMENTS");
            VerifyElementPresent(attributeName_id, IntegrationYearToDateShip_Textbox_Id, "Year to Date Shipments Textbox");
            Report.WriteLine("Year to Date Shipments Field is present");
            Verifytext(attributeName_xpath, IntegrationYearToDateRevenueLabel_Xpath, "YEAR TO DATE REVENUE");
            VerifyElementPresent(attributeName_id, IntegrationYearToDateRevenue_Textbox_Id, "Year to date Revenue Textbox");
            Report.WriteLine("Year to date Revenue Field is present");
            Verifytext(attributeName_xpath, IntegrationPotentialValLabel_Xpath, "POTENTIAL REVENUE");
            VerifyElementPresent(attributeName_id, IntegrationPotentialVal_Textbox_Id, "Potential Revenue Textbox");
            Report.WriteLine("Potential Revenue Field is present");
            Verifytext(attributeName_xpath, IntegrationAdditionalCommentsLabel_Xpath, "ADDITIONAL COMMENTS");
            VerifyElementPresent(attributeName_id, IntegrationAdditionalComments_Textbox_Id, "Additional Comments Textbox");
            Report.WriteLine("Additional Comments Field is present");

        }


        [Then(@"I must be able to pass data upto (.*) characters to Company Name field including alpha numeric, spaces and special characters (.*)")]
        public void ThenIMustBeAbleToPassDataUptoCharactersToCompanyNameFieldIncludingAlphaNumericSpacesAndSpecialCharacters(int p0, string CompanyName)
        {
            SendKeys(attributeName_id, IntegrationCompanyName_Textbox_Id, CompanyName);
            string CompanyNameUI = GetValue(attributeName_id, IntegrationCompanyName_Textbox_Id, "value");
            Assert.AreEqual(CompanyName, CompanyNameUI);
            Report.WriteLine("Able to Pass 100 characters to Company Name field");
        }

        [Then(@"I must be able to pass data upto (.*) characters to Company Contact Name field including alpha numeric, spaces and special characters (.*)")]
        public void ThenIMustBeAbleToPassDataUptoCharactersToCompanyContactNameFieldIncludingAlphaNumericSpacesAndSpecialCharacters(int p0, string CompanyContactName)
        {
            SendKeys(attributeName_id, IntegrationCompanyContactName_Textbox_Id, CompanyContactName);
            string CompanyContactNameUI = GetValue(attributeName_id, IntegrationCompanyContactName_Textbox_Id,"value");
            Assert.AreEqual(CompanyContactName, CompanyContactNameUI);
            Report.WriteLine("Able to pass 50 characters to Company Contact Name field");
        }

        [Then(@"I should not be able to pass data more than (.*) characters to Company Name field including alpha numeric, spaces and special characters (.*)")]
        public void ThenIShouldNotBeAbleToPassDataMoreThanCharactersToCompanyNameFieldIncludingAlphaNumericSpacesAndSpecialCharacters(int p0, string CompanyName)
        {
            SendKeys(attributeName_id, IntegrationCompanyName_Textbox_Id, CompanyName);
            string UICompanyNameInvalidCheck = GetValue(attributeName_id, IntegrationCompanyName_Textbox_Id,"value");
            Assert.AreNotEqual(CompanyName, UICompanyNameInvalidCheck);
            Report.WriteLine("Company Name field validated by trying to enter more than 100 characters");
        }

        [Then(@"I should not be able to pass data more than (.*) characters to Company Contact Name field including alpha numeric, spaces and special characters (.*)")]
        public void ThenIShouldNotBeAbleToPassDataMoreThanCharactersToCompanyContactNameFieldIncludingAlphaNumericSpacesAndSpecialCharacters(int p0, string CompanyContactName)
        {
            SendKeys(attributeName_id, IntegrationCompanyContactName_Textbox_Id, CompanyContactName);
            string UICompContactNameInvalidCheck = GetValue(attributeName_id, IntegrationCompanyContactName_Textbox_Id,"value");
            Assert.AreNotEqual(CompanyContactName, UICompContactNameInvalidCheck);
            Report.WriteLine("Company Contact Name field is validated by trying to enter more than 50 characters");
        }

        [Then(@"I enter valid email id to the Company Contact Email field along with all required fields (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIEnterValidEmailIdToTheCompanyContactEmailFieldAlongWithAllRequiredFields(string Station, string CompanyName, string CompanyContactName, string CompanyContactPhone, string CompanyContactEmail, string ITDeveloperContactName, string ITDeveloperContactPhone, string ITDeveloperContactEmail, string TypeOfIntegration)
        {
            IntegrationRequestPage_Elements PassIntegrationRequestPageData = new IntegrationRequestPage_Elements();
            PassIntegrationRequestPageData.IntegrationRequstPagePassElements(Station, CompanyName,CompanyContactName, CompanyContactPhone,CompanyContactEmail,ITDeveloperContactName,ITDeveloperContactPhone, ITDeveloperContactEmail, TypeOfIntegration);
            SendKeys(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, CompanyContactEmail);
            Report.WriteLine("Passed valid Email Id to Company Contact Email Field");
            SendKeys(attributeName_id, IntegrationDevContactEmail_Textbox_Id, ITDeveloperContactEmail);
            Report.WriteLine("Passed valid Email Id to  IT/DEV Contact Email Field");

        }

        [Then(@"I enter invalid email id to the IT/developer Contact email along with all required fields (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIEnterInvalidEmailIdToTheITDeveloperContactEmailAlongWithAllRequiredFields(string Station, string CompanyName, string CompanyContactName, string CompanyContactPhone, string CompanyContactEmail, string ITDeveloperContactName, string ITDeveloperContactPhone, string ITDeveloperContactEmail, string TypeOfIntegration)
        {
            IntegrationRequestPage_Elements PassIntegrationRequestPageData = new IntegrationRequestPage_Elements();
            PassIntegrationRequestPageData.IntegrationRequstPagePassElements(Station, CompanyName, CompanyContactName, CompanyContactPhone, CompanyContactEmail, ITDeveloperContactName, ITDeveloperContactPhone, ITDeveloperContactEmail, TypeOfIntegration);
            SendKeys(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, CompanyContactEmail);
            Report.WriteLine("Passed valid Email Id to Company Contact Email Field");
            SendKeys(attributeName_id, IntegrationDevContactEmail_Textbox_Id, ITDeveloperContactEmail);
            Report.WriteLine("Passed invalid Email Id to  IT/DEV Contact Email Field");
        }


        [Then(@"I enter valid email id to the IT/developer Contact Email field along with all required fields (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIEnterValidEmailIdToTheITDeveloperContactEmailFieldAlongWithAllRequiredFields(string Station, string CompanyName, string CompanyContactName, string CompanyContactPhone, string CompanyContactEmail, string ITDeveloperContactName, string ITDeveloperContactPhone, string ITDeveloperContactEmail, string TypeOfIntegration)
        {
            IntegrationRequestPage_Elements PassIntegrationRequestPageData = new IntegrationRequestPage_Elements();
            PassIntegrationRequestPageData.IntegrationRequstPagePassElements(Station, CompanyName, CompanyContactName, CompanyContactPhone, CompanyContactEmail, ITDeveloperContactName, ITDeveloperContactPhone, ITDeveloperContactEmail, TypeOfIntegration);
            SendKeys(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, CompanyContactEmail);
            Report.WriteLine("Passed valid Email Id to Company Contact Email Field");
            SendKeys(attributeName_id, IntegrationDevContactEmail_Textbox_Id, ITDeveloperContactEmail);
            Report.WriteLine("Passed valid Email Id to  IT/DEV Contact Email Field");
        }

        [Then(@"I click on Submit Button")]
        public void ThenIClickOnSubmitButton()
        {
            Click(attributeName_id, IntegrationSubmitButton_Id);
            Report.WriteLine("Clicked on Submit Button");
            Thread.Sleep(10000);
        }
        
        [Then(@"I should be able to navigate back to Intergration list page (.*)")]
        public void ThenIShouldBeAbleToNavigateBackToIntergrationListPage(string IntegrationListPageTitle)
        {
            Verifytext(attributeName_xpath, IntegratioListPageTitle_Xpath, IntegrationListPageTitle);
        }

        [Then(@"I enter invalid email id to the Company Contact Email field along with all required fields (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIEnterInvalidEmailIdToTheCompanyContactEmailFieldAlongWithAllRequiredFields(string Station, string CompanyName, string CompanyContactName, string CompanyContactPhone, string CompanyContactEmail, string ITDeveloperContactName, string ITDeveloperContactPhone, string ITDeveloperContactEmail, string TypeOfIntegration)
        {
            IntegrationRequestPage_Elements PassIntegrationRequestPageData = new IntegrationRequestPage_Elements();
            PassIntegrationRequestPageData.IntegrationRequstPagePassElements(Station, CompanyName, CompanyContactName, CompanyContactPhone, CompanyContactEmail, ITDeveloperContactName, ITDeveloperContactPhone, ITDeveloperContactEmail, TypeOfIntegration);
            SendKeys(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, CompanyContactEmail);
            Report.WriteLine("Passed invalid Email Id to Company Contact Email Field");
            SendKeys(attributeName_id, IntegrationDevContactEmail_Textbox_Id, ITDeveloperContactEmail);
            Report.WriteLine("Passed valid Email Id to  IT/DEV Contact Email Field");
        }

        [Then(@"The Company Contact Email field should be highlighted")]
        public void ThenTheCompanyContactEmailFieldShouldBeHighlighted()
        {
            string UIInvalidCheckCompanyEmail = GetCSSValue(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, "background-color");
            Assert.AreEqual(UIInvalidCheckCompanyEmail, rgbColorOfError);
            Report.WriteLine("Company Contact Email Field is highlighted when an invalid email id is passed");
        }

        [Then(@"I pass less than (.*) digits to Company contact field (.*)")]
        public void ThenIPassLessThanDigitsToCompanyContactField(int p0, string CompanyContactPhone)
        {
            SendKeys(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, CompanyContactPhone);
            Report.WriteLine("Less than 20 digits is passed to Company Contact field");
        }


        [Then(@"The Company Contact phone field should be highlighted")]
        public void ThenTheCompanyContactPhoneFieldShouldBeHighlighted()
        {
            string UIInvalidCheckCompanyPhonenum = GetCSSValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "background-color");
            Assert.AreEqual(UIInvalidCheckCompanyPhonenum, rgbColorOfError);
            Report.WriteLine("Company Contact Email Field is highlighted when an invalid email id is passed");
        }


        [Then(@"I should be able to pass upto (.*) digits to Company Contact phone field (.*)")]
        public void ThenIShouldBeAbleToPassUptoDigitsToCompanyContactPhoneField(int p0, string CompanyContactPhone)
        {
            SendKeys(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, CompanyContactPhone);
            string CompContactPhoneUI = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id,"value");
            Assert.AreEqual(CompanyContactPhone, CompContactPhoneUI);
            Report.WriteLine("Able to pass 20 characters to Company Contact Phone Field");
        }
        
        [Then(@"I should not be able to pass more than (.*) digits to Company Contact phone field (.*)")]
        public void ThenIShouldNotBeAbleToPassMoreThanDigitsToCompanyContactPhoneField(int p0, string CompanyContactPhone)
        {
            SendKeys(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, CompanyContactPhone);
            string UICompContactPhoneInvalidCheck = GetValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id,"value");
            Assert.AreNotEqual(CompanyContactPhone, UICompContactPhoneInvalidCheck);
            Report.WriteLine("Company Contact Phone validated by trying to enter more than 20 digits");
        }
        
        [Then(@"I must be able to pass data upto (.*) characters to IT/Developer Contact name field including alpha numeric, spaces and special characters (.*)")]
        public void ThenIMustBeAbleToPassDataUptoCharactersToITDeveloperContactNameFieldIncludingAlphaNumericSpacesAndSpecialCharacters(int p0, string ITDeveloperContactName)
        {
            SendKeys(attributeName_id, IntegrationDevContactName_Textbox_Id, ITDeveloperContactName);
            string DevContactNameUI = GetValue(attributeName_id, IntegrationDevContactName_Textbox_Id,"value");
            Assert.AreEqual(ITDeveloperContactName, DevContactNameUI);
            Report.WriteLine("Able to pass 50 characters to IT/DEV Contact Name field");
        }
        
        [Then(@"I must not be able to pass data more than (.*) characters to IT/Developer Contact name field including alpha numeric, spaces and special characters (.*)")]
        public void ThenIMustNotBeAbleToPassDataMoreThanCharactersToITDeveloperContactNameFieldIncludingAlphaNumericSpacesAndSpecialCharacters(int p0, string ITDeveloperContactName)
        {
            SendKeys(attributeName_id, IntegrationDevContactName_Textbox_Id, ITDeveloperContactName);
            string UIDevContactNameInvalidCheck = GetValue(attributeName_id, IntegrationDevContactName_Textbox_Id,"value");
            Assert.AreNotEqual(ITDeveloperContactName, UIDevContactNameInvalidCheck);
            Report.WriteLine("IT/DEV Contact name field is validated by trying to enter more than 50 characters");
        }   
            
        [Then(@"The IT/developer Contact email field should be highlighted")]
        public void ThenTheITDeveloperContactEmailFieldShouldBeHighlighted()
        {
            string UIInvalidCheckDevCompanyEmail = GetCSSValue(attributeName_id, IntegrationDevContactEmail_Textbox_Id, "background-color");
            Assert.AreEqual(UIInvalidCheckDevCompanyEmail, rgbColorOfError);
            Report.WriteLine("Company Contact Email Field is highlighted when an invalid email id is passed");
        }
        
        [Then(@"I should be able to pass upto (.*) digits to IT/developer Contact phone field (.*)")]
        public void ThenIShouldBeAbleToPassUptoDigitsToITDeveloperContactPhoneField(int p0, string ITDeveloperContactPhone)
        {
            SendKeys(attributeName_id, IntegrationDevContactPhone_Textbox_Id, ITDeveloperContactPhone);
            string UIDevContactPhone = GetValue(attributeName_id, IntegrationDevContactPhone_Textbox_Id,"value");
            Assert.AreEqual(ITDeveloperContactPhone, UIDevContactPhone);
            Report.WriteLine("Able to pass 20 digits to IT/developer Contact phone field");
        }

        [Then(@"The IT/developer Contact phone field should be highlighted")]
        public void ThenTheITDeveloperContactPhoneFieldShouldBeHighlighted()
        {
            string UIInvalidITdeveloperPhonenum = GetCSSValue(attributeName_id, IntegrationDevContactPhone_Textbox_Id, "background-color");
            Assert.AreEqual(UIInvalidITdeveloperPhonenum, rgbColorOfError);
            Report.WriteLine("Company Contact Email Field is highlighted when an invalid email id is passed");
        }

        [Then(@"I pass less than (.*) digits to IT/developer Contact phone field (.*)")]
        public void ThenIPassLessThanDigitsToITDeveloperContactPhoneField(int p0, string ITDeveloperContactPhone)
        {
            SendKeys(attributeName_id, IntegrationDevContactPhone_Textbox_Id, ITDeveloperContactPhone);
            Report.WriteLine("Passed less than 20 characters to IT/developer Contact phone field");
        }


        [Then(@"I should not be able to pass more than (.*) digits to IT/developer Contact phone field (.*)")]
        public void ThenIShouldNotBeAbleToPassMoreThanDigitsToITDeveloperContactPhoneField(int p0, string ITDeveloperContactPhone)
        {
            SendKeys(attributeName_id, IntegrationDevContactPhone_Textbox_Id, ITDeveloperContactPhone);
            string UIDevContactPhoneInvalidCheck = GetValue(attributeName_id, IntegrationDevContactPhone_Textbox_Id,"value");
            Assert.AreNotEqual(ITDeveloperContactPhone, UIDevContactPhoneInvalidCheck);
            Report.WriteLine("IT/developer Contact phone field is validated by trying passing more than 20 didgits ");
        }
        
       
        [Then(@"I should be able to view the following values in the Type of Integration multi select dropdown- Rate Request,Shipment Import,Tracking,Document Extract,Invoicing")]
        public void ThenIShouldBeAbleToViewTheFollowingValuesInTheTypeOfIntegrationMultiSelectDropdown_RateRequestShipmentImportTrackingDocumentExtractInvoicing()
        {
            Click(attributeName_id, IntegrationTypeOfIntegration_MultiSelectBox_Id);
            List<string> expectedDropdownValues = new List<string>(new string[] { "Rate Request", "Shipment Import","Tracking", "Document Extract", "Invoicing"});
            IList<IWebElement> DropDownValUI = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='IntegrationType_chosen']/div/ul/li"));
            for(int i= 0; i< DropDownValUI.Count;i++)
            {
                if(expectedDropdownValues.Contains(DropDownValUI[i].Text))
                {
                    Report.WriteLine("Expected Integration Type value exists in multi select dropdown list");
                }
                else
                {
                    Report.WriteFailure("Expected Integration Type value does not exists in multi select dropdown list");
                    Assert.Fail();
                }
            }
        }

        [Then(@"I should be able to pass data with a maximum of (.*) digits to Year to Date Shipments field which includes numeric and whole numbers (.*)")]
        public void ThenIShouldBeAbleToPassDataWithAMaximumOfDigitsToYearToDateShipmentsFieldWhichIncludesNumericAndWholeNumbers(int p0, string YearToDateShipments)
        {

            SendKeys(attributeName_id, IntegrationYearToDateShip_Textbox_Id, YearToDateShipments);
            string YearToDateShipUI = GetValue(attributeName_id, IntegrationYearToDateShip_Textbox_Id,"value");
            Assert.AreEqual(YearToDateShipments, YearToDateShipUI);
            Report.WriteLine("Able to pass 6 digits to Year To Date Shipments Field");
        }

        [Then(@"I should not be able to pass more than (.*) digits to Year to Date Shipments field which includes numeric and whole numbers (.*)")]
        public void ThenIShouldNotBeAbleToPassMoreThanDigitsToYearToDateShipmentsFieldWhichIncludesNumericAndWholeNumbers(int p0, string YearToDateShipments)
        {
            SendKeys(attributeName_id, IntegrationYearToDateShip_Textbox_Id, YearToDateShipments);
            string YearToDateShipInvalidCheck = GetValue(attributeName_id, IntegrationYearToDateShip_Textbox_Id,"value");
            Assert.AreNotEqual(YearToDateShipments, YearToDateShipInvalidCheck);
            Report.WriteLine("Year To Date Shipments Field is validated by trying passing more than 6 digits");
        }

        [Then(@"I should be able to pass data with a maximum of (.*) digits to Year to Date Revenue field which includes currency with \$ and whole numbers (.*)")]
        public void ThenIShouldBeAbleToPassDataWithAMaximumOfDigitsToYearToDateRevenueFieldWhichIncludesCurrencyWithAndWholeNumbers(int p0, string YearToDateRevenue)
        {
            SendKeys(attributeName_id, IntegrationYearToDateRevenue_Textbox_Id, YearToDateRevenue);
            string YearToDateRevenueUI = GetValue(attributeName_id, IntegrationYearToDateRevenue_Textbox_Id,"value");
            Assert.AreEqual("$" + (YearToDateRevenue), YearToDateRevenueUI.Replace(",",""));
            Report.WriteLine("Able to pass 8 digits to Year to Date Revenue field");
        }

        [Then(@"I should not be able to pass more than (.*) digits Year to Date Revenue field which includes currency with \$ and whole numbers (.*)")]
        public void ThenIShouldNotBeAbleToPassMoreThanDigitsYearToDateRevenueFieldWhichIncludesCurrencyWithAndWholeNumbers(int p0, string YearToDateRevenue)
        {
            SendKeys(attributeName_id, IntegrationYearToDateRevenue_Textbox_Id, YearToDateRevenue);
            string YearToDateShipRevenueInvalidCheck = GetValue(attributeName_id, IntegrationYearToDateRevenue_Textbox_Id,"value");
            Assert.AreNotEqual("$" + (YearToDateRevenue), YearToDateShipRevenueInvalidCheck.Replace(",", ""));
            Report.WriteLine("Year To Date Field is validated by trying to pass more than 8 digits");
        }

        [Then(@"I should be able to pass data with a maximum of (.*) digits to Potential Revenue field which includes currency with \$ and whole numbers (.*)")]
        public void ThenIShouldBeAbleToPassDataWithAMaximumOfDigitsToPotentialRevenueFieldWhichIncludesCurrencyWithAndWholeNumbers(int p0, string PotentialRevenue)
        {
            SendKeys(attributeName_id, IntegrationPotentialVal_Textbox_Id, PotentialRevenue);
            string PotentialRevenueUI = GetValue(attributeName_id, IntegrationPotentialVal_Textbox_Id,"value");
            Assert.AreEqual("$" + (PotentialRevenue), PotentialRevenueUI.Replace(",", ""));
            Report.WriteLine("Able to pass 8 digits to Potential Revenue field");
        }

        [Then(@"I should not be able to pass data more than (.*) digits to Potential Revenue which includes currency with \$ and whole numbers (.*)")]
        public void ThenIShouldNotBeAbleToPassDataMoreThanDigitsToPotentialRevenueWhichIncludesCurrencyWithAndWholeNumbers(int p0, string PotentialRevenue)
        {
            SendKeys(attributeName_id, IntegrationPotentialVal_Textbox_Id, PotentialRevenue);
            string PotentialRevenueUIInvalidCheck = GetValue(attributeName_id, IntegrationPotentialVal_Textbox_Id,"value");
            Assert.AreNotEqual("$" + (PotentialRevenue), PotentialRevenueUIInvalidCheck.Replace(",", ""));
            Report.WriteLine("Potential Revenue field is validated by trying to pass more than 8 digits");
        }

        [Then(@"I must be able to pass a maximum of (.*) characters to Additional Comments field which includes alpha numeric, spaces and special characters (.*)")]
        public void ThenIMustBeAbleToPassAMaximumOfCharactersToAdditionalCommentsFieldWhichIncludesAlphaNumericSpacesAndSpecialCharacters(int p0, string AdditionalComments)
        {
            SendKeys(attributeName_id, IntegrationAdditionalComments_Textbox_Id, AdditionalComments);
            string AdditionalCommentsUI = GetValue(attributeName_id, IntegrationAdditionalComments_Textbox_Id,"value");
            Assert.AreEqual(AdditionalComments, AdditionalCommentsUI);
            Report.WriteLine("Able to pass 500 characters to Additional Comments field");
        }

        [Then(@"I should not be able to pass more than (.*) characters to Additional Comments field which includes alpha numeric, spaces and special characters (.*)")]
        public void ThenIShouldNotBeAbleToPassMoreThanCharactersToAdditionalCommentsFieldWhichIncludesAlphaNumericSpacesAndSpecialCharacters(int p0, string AdditionalComments)
        {
            SendKeys(attributeName_id, IntegrationAdditionalComments_Textbox_Id, AdditionalComments);
            string AdditionalCommentsUIInvalidCheck = GetValue(attributeName_id, IntegrationAdditionalComments_Textbox_Id,"value");
            Assert.AreNotEqual(AdditionalComments, AdditionalCommentsUIInvalidCheck);
            Report.WriteLine("Additional Comments field is validated by passing more than 500 characters");
        }


        [Then(@"All the expected required fields must be highlighted - Station,CompanyName,CompanyContactName,CompanyContactEmail,CompanyContactPhone,IT/DeveloperContactName,IT/DeveloperContactEmail,IT/DeveloperContactPhone,StartDate,TypeOfIntegration")]
        public void ThenAllTheExpectedRequiredFieldsMustBeHighlighted_StationCompanyNameCompanyContactNameCompanyContactEmailCompanyContactPhoneITDeveloperContactNameITDeveloperContactEmailITDeveloperContactPhoneStartDateTypeOfIntegration()
        {
            Click(attributeName_id, IntegrationStaionDropdown_Id);
            Thread.Sleep(3000);
            string UIRequiredStation = GetCSSValue(attributeName_xpath, ".//*[@id='StationName_chosen']/a[@class='chosen-single chosen-default selecterror']", "background-image");
            string ExpecUIRequiredStation = "url(\"http://dlsww-test.rrd.com/Content/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(UIRequiredStation, ExpecUIRequiredStation);
            Report.WriteLine("Required Station field is highlighted");
            string UIRequiredCompanyName = GetCSSValue(attributeName_id, IntegrationCompanyName_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredCompanyName, rgbColorOfError);
            Report.WriteLine("Required Company Name field is highlighted");
            string UIRequiredCompanyContactName = GetCSSValue(attributeName_id, IntegrationCompanyContactName_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredCompanyContactName, rgbColorOfError);
            Report.WriteLine("Required Company Contact Name field is highlighted");
            string UIRequiredCompanyEmail = GetCSSValue(attributeName_id, IntegrationCompanyContactEmail_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredCompanyEmail, rgbColorOfError);
            Report.WriteLine("Required Company Contact Email Field is highlighted");
            string UIRequiredCompanyContactPhone = GetCSSValue(attributeName_id, IntegrationCompanyContactPhone_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredCompanyContactPhone, rgbColorOfError);
            Report.WriteLine("Required Company Contact Phone Field is highlighted");
            string UIRequiredITDevContactName = GetCSSValue(attributeName_id, IntegrationDevContactName_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredITDevContactName, rgbColorOfError);
            Report.WriteLine("Required IT/DEV Contact Name Field is highlighted");
            string UIRequiredITDevContactEmail = GetCSSValue(attributeName_id, IntegrationDevContactEmail_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredITDevContactEmail, rgbColorOfError);
            Report.WriteLine("Required IT/DEV Contact Email Field is highlighted");
            string UIRequiredITDevContactPhone = GetCSSValue(attributeName_id, IntegrationDevContactPhone_Textbox_Id, "background-color");
            Assert.AreEqual(UIRequiredITDevContactPhone, rgbColorOfError);
            Report.WriteLine("Required IT/DEV Contact Phone Field is highlighted");
            string UIRequiredStartDate = GetCSSValue(attributeName_id, IntegrationStartDatePicker_Id, "background-image");
            string ExpecUIUIRequiredStartDate = "url(\"http://dlsww-test.rrd.com/Content/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(UIRequiredStartDate, ExpecUIUIRequiredStartDate);
            Report.WriteLine("Required Start Date Field is highlighted");
            string UIRequiredTypeOfIntegration = GetCSSValue(attributeName_xpath,".//*[@id='IntegrationType_chosen']/ul/li", "background");
            string ExpecUIUIRequiredTypeOfIntegration = "rgb(251, 236, 237) url(\"http://dlsww-test.rrd.com/Content/images/search.png\") no-repeat scroll 97% 10px / auto padding-box border-box";
            Assert.AreEqual(UIRequiredTypeOfIntegration, ExpecUIUIRequiredTypeOfIntegration);
            Report.WriteLine("Required Type of Integration Field is highlighted");
        }

        [Then(@"I must be able to view Submit Button on Integration Request page")]
        public void ThenIMustBeAbleToViewSubmitButtonOnIntegrationRequestPage()
        {
            VerifyElementPresent(attributeName_id, IntegrationSubmitButton_Id ,"Submit");
            Report.WriteLine("Submit Button is present on Integration Request page");
        }
        
        [Then(@"I must be able to view Back to Integration list button on Integration Request page")]
        public void ThenIMustBeAbleToViewBackToIntegrationListButtonOnIntegrationRequestPage()
        {
            VerifyElementPresent(attributeName_id, BackToIntegrationListPageButton_Id, "Back to Integration Request List");
            Report.WriteLine("Back to Integration Request List Button is present on Integration Request page");
        }
    }
}
