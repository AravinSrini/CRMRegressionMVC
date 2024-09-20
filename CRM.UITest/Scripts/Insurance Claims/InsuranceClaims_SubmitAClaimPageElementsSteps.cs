using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_SubmitAClaimPageElementsSteps : InsuranceClaim
    {
        string actual_DLSWRef;
        string DLSWRefNum = "zzx002013764";

        [Given(@"I am an external user who have access to the application")]
        public void GivenIAmAnExternalUserWhoHaveAccessToTheApplication()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I click on Insurance claim icon")]
        public void GivenIClickOnInsuranceClaimIcon()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Claims icon");
        }

        [Given(@"I am an internal user who have access to the application")]
        public void GivenIAmAnInternalUserWhoHaveAccessToTheApplication()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I click on Submit a claim button on claim list page")]
        public void GivenIClickOnSubmitAClaimButtonOnClaimListPage()
        {
            Click(attributeName_id, Submit_A_Claim_button_Id);
            Report.WriteLine("Clicked on Submit a Claim button");
        }

        [Given(@"I am a DLS user who have access to Insurance Claims")]
        public void GivenIAmADLSUserWhoHaveAccessToInsuranceClaims()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I arrive on Submit a Claim page")]
        public void GivenIArriveOnSubmitAClaimPage()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            Report.WriteLine("Submit a Claim page");
        }

        [Given(@"I enter a valid DLSW shipment reference number \(with station reference in lower case\) in the Enter DLSW Ref \# to Start Process field")]
        public void GivenIEnterAValidDLSWShipmentReferenceNumberWithStationReferenceInLowerCaseInTheEnterDLSWRefToStartProcessField()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, DLSWRefNum);
            Report.WriteLine("Entered a valid DLSW Shipment reference number in Enter DLSW Ref # to start Process field");
        }

        [Given(@"I enter a valid DLSW shipment reference number \(with station reference in lower case\) in the DLSW Ref \# field in Carrier Information section")]
        public void GivenIEnterAValidDLSWShipmentReferenceNumberWithStationReferenceInLowerCaseInTheDLSWRefFieldInCarrierInformationSection()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSWRefNum);
            Report.WriteLine("Entered a valid DLSW shipment reference number in the DLSW Ref # field");
        }

        [Given(@"I enter a valid DLSW shipment reference number \(with station reference in upper case\) in the Enter DLSW Ref \# to Start Process field")]
        public void GivenIEnterAValidDLSWShipmentReferenceNumberWithStationReferenceInUpperCaseInTheEnterDLSWRefToStartProcessField()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, DLSWRefNum.ToUpper());
            Report.WriteLine("Entered a valid DLSW Shipment reference number in Enter DLSW Ref # to start Process field");
        }

        [Given(@"I enter a valid DLSW shipment reference number \(with station reference in upper case\) in the DLSW Ref \# field in Carrier Information section")]
        public void GivenIEnterAValidDLSWShipmentReferenceNumberWithStationReferenceInUpperCaseInTheDLSWRefFieldInCarrierInformationSection()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSWRefNum.ToUpper());
            Report.WriteLine("Entered a valid DLSW shipment reference number in the DLSW Ref # field");
        }

        [Given(@"I enter valid data in the Weight \(LBS\) in the Claim Details section")]
        public void GivenIEnterValidDataInTheWeightLBSInTheClaimDetailsSection()
        {
            SendKeys(attributeName_id, Weight_LBS_Id, "23.5");
            Report.WriteLine("Entered a valid weight value in the Weight (LBS) field");
        }

        [Given(@"I Click on Add Another Item button")]
        public void GivenIClickOnAddAnotherItemButton()
        {
            Click(attributeName_id, AddAditionalClaim_btn_Id);
            Report.WriteLine("Clicked on Add Additional Item link");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I enter weight value along with \# character in the Weight \(LBS\) in the Claim Details section")]
        public void GivenIEnterWeightValueAlongWithCharacterInTheWeightLBSInTheClaimDetailsSection()
        {
            SendKeys(attributeName_id, Weight_LBS_Id, "22.44#");
            Report.WriteLine("Entered a valid weight value in the Weight (LBS) field");
        }

        [When(@"I Click on Populate Form button")]
        public void WhenIClickOnPopulateFormButton()
        {
            Click(attributeName_id, PopulateForm_button_Id);
            Report.WriteLine("Clicked on Populate Form button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [When(@"I tab out of the DLSW Ref \# field")]
        public void WhenITabOutOfTheDLSWRefFie()
        {
            IWebElement DLSW_RefField = GlobalVariables.webDriver.SwitchTo().ActiveElement();
            Report.WriteLine("Tabbing out of the DLSW Ref # field");
            DLSW_RefField.SendKeys(Keys.Tab);
        }

        [When(@"I click anywhere outside DLSW Ref \# field")]
        public void WhenIClickAnywhereOutsideDLSWRefField()
        {
            Click(attributeName_id, CarrierName_Textbox_Id);
            Report.WriteLine("Clicked on Carrier Name field after entering Shipment Reference in lower case in the DLSW Ref # field");
        }

        [When(@"I click anywhere outside Weight \(LBS\) field")]
        public void WhenIClickAnywhereOutsideWeightLBSField()
        {
            Click(attributeName_id, ClaimedArticle_Description_Id);
            Report.WriteLine("Clicked outside the weight field");
        }

        [When(@"I click on Submit a claim button on claim list page")]
        public void WhenIClickOnSubmitAClaimButtonOnClaimListPage()
        {
            Click(attributeName_id, Submit_A_Claim_button_Id);
            Report.WriteLine("Clicked on Submit a Claim button");
        }

        [When(@"I arrive on Submit a Claim page")]
        public void WhenIArriveOnSubmitAClaimPage()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            Report.WriteLine("Submit a Claim page");
        }

        [When(@"I arrive on Submit a Claim page and click on submit button")]
        public void WhenIArriveOnSubmitAClaimPageAndClickOnSubmitButton()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            Report.WriteLine("Submit a Claim page");
            scrollElementIntoView(attributeName_id, SubmitClaimButton_Id);
            Click(attributeName_id, SubmitClaimButton_Id);
        }

        [When(@"I arrive on Submit a Claim page and clcik on submit button")]
        public void WhenIArriveOnSubmitAClaimPageAndClcikOnSubmitButton()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"I arrive on Submit a Claim page i pass an invalid Email id to Contact email field of Claim Payable To section and click on submit button")]
        public void WhenIArriveOnSubmitAClaimPageIPassAnInvalidEmailIdToContactEmailFieldOfClaimPayableToSectionAndClickOnSubmitButton()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            Report.WriteLine("Submit a Claim page");
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "dhgsj");
            Report.WriteLine("Passed email to email field");

        }

        [When(@"I select '(.*)' as Articles Insured")]
        public void WhenISelectAsArticlesInsured(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            Report.WriteLine("Articles Insured is selectes as 'Yes'");
        }

        [When(@"I hover over the Claim Payable To Tool Tip/Information icon")]
        public void WhenIHoverOverTheClaimPayableToToolTipInformationIcon()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            OnMouseOver(attributeName_id, ToolTipInfo_Icon_ClaimPayable_Id);
        }

        [When(@"I hover over the Freight Charges Tool Tip/Information icon")]
        public void WhenIHoverOverTheFreightChargesToolTipInformationIcon()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            OnMouseOver(attributeName_xpath, FreightTootTip_Xpath);

        }

        [When(@"I click on Add Another Item hyperlink")]
        public void WhenIClickOnAddAnotherItemHyperlink()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, AddAditionalClaim_btn_Id);
        }

        [Then(@"the three letter station reference in the DLSW Ref \# should be displayed in Uppercase alphabets")]
        public void ThenTheThreeLetterStationReferenceInTheDLSWRefShouldBeDisplayedInUppercaseAlphabets()
        {
            actual_DLSWRef = GetAttribute(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            Assert.AreEqual(DLSWRefNum.ToUpper(), actual_DLSWRef);
            Report.WriteLine("Station reference in " + actual_DLSWRef + " is in Uppercase alphabets");
        }

        [Then(@"the \# character should not be displayed in the Weight \(LBS\) field")]
        public void ThenTheCharacterShouldNotBeDisplayedInTheWeightLBSField()
        {
            string actualWeightVal = GetAttribute(attributeName_id, Weight_LBS_Id, "value");
            if (actualWeightVal.Contains("#"))
            {
                Report.WriteLine("# (pound) character still displays");
                Assert.Fail();
            }
            else
            {
                Report.WriteLine("# (pound) character doesn't display");
            }
        }

        [Then(@"the \# character should be removed from the Weight \(LBS\) field")]
        public void ThenTheCharacterShouldBeRemovedFromTheWeightLBSField()
        {
            string actualWeightVal = GetAttribute(attributeName_id, Weight_LBS_Id, "value");
            if (actualWeightVal.Contains("#"))
            {
                Report.WriteLine("# (pound) character still displays");
                Assert.Fail();
            }
            else
            {
                Report.WriteLine("# (pound) character doesn't display");
            }
        }

        [Then(@"I must be navigated to Submit a Claim page")]
        public void ThenIMustBeNavigatedToSubmitAClaimPage()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            Report.WriteLine("Navigated to Submit a Claim page");
        }

        [Then(@"I must be able to see Submit a Claim header with verbiage - Submit a motor carrier shortage or damage claim")]
        public void ThenIMustBeAbleToSeeSubmitAClaimHeaderWithVerbiage_SubmitAMotorCarrierShortageOrDamageClaim()
        {
            Verifytext(attributeName_xpath, ClaimPage_Header_Verbiage_xpath, "Submit a motor carrier shortage or damage claim");
            Report.WriteLine("Submit a Claim header verbiage exists");
        }

        [Then(@"I must be able to see Back to Claim list button")]
        public void ThenIMustBeAbleToSeeBackToClaimListButton()
        {
            VerifyElementVisible(attributeName_xpath, BackToClaimListPage_Button_Xpath, "Back to Claims List");
            Report.WriteLine("Back to Claims List button exists");
        }

        [Then(@"I must be able to see a field named - Enter DLSW Ref \# to Start Process")]
        public void ThenIMustBeAbleToSeeAFieldNamed_EnterDLSWRefToStartProcess()
        {
            Verifytext(attributeName_xpath, Enter_DLSW_BOLNumber_Textbox_Label_Xpath, "Enter DLSW Ref # to Start Process");
            Report.WriteLine("Enter DLSW Ref # to Start Process field exists");
        }

        [Then(@"I must be able to see Prefill form button")]
        public void ThenIMustBeAbleToSeePrefillFormButton()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, "Test123");
            VerifyElementVisible(attributeName_id, PopulateForm_button_Id, "Populate Form");
            Report.WriteLine("Populate Form button exists");
        }

        [Then(@"I must be able to see a verbiage stating - Or fill out the form below manually")]
        public void ThenIMustBeAbleToSeeAVerbiageStating_OrFillOutTheFormBelowManually()
        {
            Verifytext(attributeName_xpath, PopulateFormButton_Verbiage_Xpath, "Or fill out the form below manually");
            Report.WriteLine("Populate Form Button Verbiage exists");
        }

        [Then(@"I must be able to see the following fields in the Carrier Information section - DLSW Ref, DLSW Ship Date, Carrier Name, Carrier PRO \#, Carrier PRO Date")]
        public void ThenIMustBeAbleToSeeTheFollowingFieldsInTheCarrierInformationSection_DLSWRefDLSWShipDateCarrierNameCarrierPROCarrierPRODate()
        {
            VerifyElementPresent(attributeName_id, DLSWBillOfLading_Textbox_Id, "DLSW Ref #");
            VerifyElementPresent(attributeName_id, CarrierName_Textbox_Id, "Carrier Name");
            VerifyElementPresent(attributeName_id, DLSW_BOLDate_Field_Id, "DLSW Ship Date");
            VerifyElementPresent(attributeName_id, CarrierPro_Textbox_Id, "Carrier Pro Textbox");
            VerifyElementPresent(attributeName_id, CarrierProDate_Field_Id, "Carrier Pro Date");
            Report.WriteLine("Carrier Information fields exists");
        }

        [Then(@"DLSW Ref, DLSW Ship Date, Carrier Name, Carrier PRO \# fields of Carrier Information section should be highlighted")]
        public void ThenDLSWRefDLSWShipDateCarrierNameCarrierPROFieldsOfCarrierInformationSectionShouldBeHighlighted()
        {
            ScrollToTopElement(attributeName_id, DLSWBillOfLading_Textbox_Id);
            string DLSWRefNum = GetCSSValue(attributeName_id, DLSWBillOfLading_Textbox_Id, "background-color");
            string ExpDLSWRefNum = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(DLSWRefNum, ExpDLSWRefNum);
            string CarrierName = GetCSSValue(attributeName_id, CarrierName_Textbox_Id, "background-color");
            string ExpCarrierName = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(CarrierName, ExpCarrierName);
            string DLSWShipDate = GetCSSValue(attributeName_id, DLSW_BOLDate_Field_Id, "background-image");
            string ExpDLSWShipDate = "url(\"http://dlsww-test.rrd.com/Content/images/formicons.png\"), linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236))";
            Assert.AreEqual(DLSWShipDate, ExpDLSWShipDate);
            string CarrierProNum = GetCSSValue(attributeName_id, CarrierPro_Textbox_Id, "background-color");
            string ExpCarrierProNum = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(CarrierProNum, ExpCarrierProNum);
            Report.WriteLine("All the required fields in the carrier information section is highlighted");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric characters")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericCharacters(int p0)
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, "23rtaerwQW1234RTopiy");
            string GetUIVal = GetAttribute(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            Assert.AreEqual("23rtaerwQW1234RTopiy", GetUIVal);
            Report.WriteLine("DLSW Ref # field is validated for a maximum of 20 alpha numeric characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric characters to DLSW Ref \# field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericCharactersToDLSWRefField(int p0)
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, "23rtaerwQW1234RTopiy8763486");
            string GetUIVal = GetAttribute(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            Assert.AreNotEqual("23rtaerwQW1234RTopiy8763486", GetUIVal);
            Report.WriteLine("DLSW Ref # field is validated bt trying to pass more than 20 alpha numeric characters");

        }

        [Then(@"I must be able to see DLSW Ship Date selected prior to current date")]
        public void ThenIMustBeAbleToSeeDLSWShipDateSelectedPriorToCurrentDate()
        {
            Report.WriteLine("Should be able to select prior date to current date");
            Click(attributeName_id, DLSW_BOLDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric, text and special characters to Carrier Name field")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericTextAndSpecialCharactersToCarrierNameField(int p0)
        {
            string CarrierName = "23rtaerwQW1234RTopiy !@#$%^&* UHGFDSWERT%^&76543 cxzsa1 ;'[m njuyt678_(+:qw";
            SendKeys(attributeName_id, CarrierName_Textbox_Id, CarrierName);
            string GetUIVal = GetAttribute(attributeName_id, CarrierName_Textbox_Id, "value");
            Assert.AreEqual(CarrierName, GetUIVal);
            Report.WriteLine("Carrier Name field is validated for a maximum of 75 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass a maximum of (.*) alpha numeric, text and special characters to Carrier Name field")]
        public void ThenIShouldNotBeAbleToPassAMaximumOfAlphaNumericTextAndSpecialCharactersToCarrierNameField(int p0)
        {

            SendKeys(attributeName_id, CarrierName_Textbox_Id, "23rtaerwQW1234RTopiy !@#$%^&* UHGFDSWERT%^&76543 cxzsa1 ;'[m njuyt678_(+:qwert0987 ");
            string GetUIVal = GetAttribute(attributeName_id, CarrierName_Textbox_Id, "value");
            Assert.AreNotEqual("23rtaerwQW1234RTopiy !@#$%^&* UHGFDSWERT%^&76543 cxzsa1 ;'[m njuyt678_(+:qwert0987 ", GetUIVal);
            Report.WriteLine("Carrier Name field is validated by trying to pass more than 75 alpha-numeric, text, special characters");
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric, text and special characters to Carrier PRO \# field")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericTextAndSpecialCharactersToCarrierPROField(int p0)
        {
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "2098765432 1qazxs wedc vfr &^5");
            string GetUIVal = GetAttribute(attributeName_id, CarrierPro_Textbox_Id, "value");
            Assert.AreEqual("2098765432 1qazxs wedc vfr &^5", GetUIVal);
            Report.WriteLine("Carrier Pro # field is validated for a maximum of 30 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric, text and special characters Carrier PRO \# field")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericTextAndSpecialCharactersCarrierPROField(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not be able to pass a maximum of (.*) alpha numeric, text and special characters to Carrier PRO \# field")]
        public void ThenIShouldNotBeAbleToPassAMaximumOfAlphaNumericTextAndSpecialCharactersToCarrierPROField(int p0)
        {
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "2098765432 1qazxs wedc vfr &^5123");
            string GetUIVal = GetAttribute(attributeName_id, CarrierPro_Textbox_Id, "value");
            Assert.AreNotEqual("2098765432 1qazxs wedc vfr &^5123", GetUIVal);
            Report.WriteLine("Carrier Pro # field is validated by trying to pass more than 30 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to see Carrier PRO Date selected prior to current date")]
        public void ThenIMustBeAbleToSeeCarrierPRODateSelectedPriorToCurrentDate()
        {
            Report.WriteLine("Should be able to select prior date to current date");
            Click(attributeName_id, CarrierProDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);

        }

        [Then(@"I must be able to see the following expected fields in the Shipper information page - Name, Address, Address(.*), City, StateOrProvince, ZipOrPostal, Country")]
        public void ThenIMustBeAbleToSeeTheFollowingExpectedFieldsInTheShipperInformationPage_NameAddressAddressCityStateOrProvinceZipOrPostalCountry(int p0)
        {
            scrollpagedown();
            VerifyElementPresent(attributeName_id, Shipper_Name_Textbox_Id, "ShipName");
            VerifyElementPresent(attributeName_id, Shipper_Address_Textbox_Id, "ShipAddress");
            VerifyElementPresent(attributeName_id, Shipper_Address2_Textbox_Id, "ShipAddress2");
            VerifyElementPresent(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "ShipZip");
            VerifyElementPresent(attributeName_xpath, Shipper_Country_dropdown_Xpath, "ShipCountry");
            VerifyElementPresent(attributeName_id, Shipper_City_Textbox_Id, "ShipCity");
            VerifyElementPresent(attributeName_id, ShipperState_Id, "ShipProvince");
            Report.WriteLine("All the expected fields of shipper information section exists");

        }

        [Then(@"I must see the following fields highlighted in the Shipper Information section -  Name, Address, City, StateOrProvince, ZipOrPostal, Country")]
        public void ThenIMustSeeTheFollowingFieldsHighlightedInTheShipperInformationSection_NameAddressCityStateOrProvinceZipOrPostalCountry()
        {
            scrollpagedown();
            string ShipperName = GetCSSValue(attributeName_id, Shipper_Name_Textbox_Id, "background-color");
            string ExpShipperName = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ShipperName, ExpShipperName);
            string ShipAddress = GetCSSValue(attributeName_id, Shipper_Address_Textbox_Id, "background-color");
            string ExpShipAddress = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ShipAddress, ExpShipAddress);
            string ShipCity = GetCSSValue(attributeName_id, Shipper_City_Textbox_Id, "background-color");
            string ExpShipCity = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ShipCity, ExpShipCity);
            string ShipState = GetCSSValue(attributeName_id, ShipperState_Id, "background");
            string ExpShipState = "rgba(0, 0, 0, 0) none repeat scroll 0px 0px / auto padding-box border-box";
            Assert.AreEqual(ShipState, ExpShipState);
            string ShipZip = GetCSSValue(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "background-color");
            string ExpShipZip = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ShipZip, ExpShipZip);
            Report.WriteLine("All the required fields in the Shipper information section is highlighted");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the name field of shipper information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheNameFieldOfShipperInformationSection(int p0)
        {
            scrollpagedown();
            string ShipperName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT";
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, ShipperName);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Name_Textbox_Id, "value");
            Assert.AreEqual(ShipperName, GetUIVal);
            Report.WriteLine("Shipper name field is validated by passing a maximum of 75 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the name field of shipper information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheNameFieldOfShipperInformationSection(int p0)
        {
            scrollpagedown();
            string ShipperName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT1234";
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, ShipperName);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Name_Textbox_Id, "value");
            Assert.AreNotEqual(ShipperName, GetUIVal);
            Report.WriteLine("Shipper name field is validated by trying to pass more than 75 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the address field of shipper information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheAddressFieldOfShipperInformationSection(int p0)
        {
            scrollpagedown();
            string ShipperAddress = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436";
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, ShipperAddress);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Address_Textbox_Id, "value");
            Assert.AreEqual(ShipperAddress, GetUIVal);
            Report.WriteLine("Shipper Address field is validated by passing a maximum of 150 alpha-numeric, text, special characters");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the address field of shipper information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheAddressFieldOfShipperInformationSection(int p0)
        {
            scrollpagedown();
            string ShipperAddress = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436mnb";
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, ShipperAddress);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Address_Textbox_Id, "value");
            Assert.AreNotEqual(ShipperAddress, GetUIVal);
            Report.WriteLine("Shipper Address field is validated by trying to pass more 150 alpha-numeric, text, special characters");
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the address(.*) field of shipper information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheAddressFieldOfShipperInformationSection(int p0, int p1)
        {
            scrollpagedown();
            string ShipperAddress2 = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436";
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, ShipperAddress2);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Address2_Textbox_Id, "value");
            Assert.AreEqual(ShipperAddress2, GetUIVal);
            Report.WriteLine("Shipper Address2 field is validated by passing a maximum of 150 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the address(.*) field of shipper information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheAddressFieldOfShipperInformationSection(int p0, int p1)
        {
            scrollpagedown();
            string ShipperAddress2 = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436mnb";
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, ShipperAddress2);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Address2_Textbox_Id, "value");
            Assert.AreNotEqual(ShipperAddress2, GetUIVal);
            Report.WriteLine("Shipper Address2 field is validated by trying to pass more than 150 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the city field of shipper information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheCityFieldOfShipperInformationSection(int p0)
        {
            scrollpagedown();
            string ShipperCity = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertg";
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, ShipperCity);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_City_Textbox_Id, "value");
            Assert.AreEqual(ShipperCity, GetUIVal);
            Report.WriteLine("Shipper city field is validated by passing a maximum of 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the city field of shipper information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheCityFieldOfShipperInformationSection(int p0)
        {
            scrollpagedown();
            string ShipperCity = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertg123";
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, ShipperCity);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_City_Textbox_Id, "value");
            Assert.AreNotEqual(ShipperCity, GetUIVal);
            Report.WriteLine("Shipper city field is validated by trying to pass more than 50 alpha-numeric, text, special characters");
        }

        [Then(@"I should be able to pass a maximum of (.*) text to State or Province field of shipper information section when the country is either United states or Canada")]
        public void ThenIShouldBeAbleToPassAMaximumOfTextToStateOrProvinceFieldOfShipperInformationSectionWhenTheCountryIsEitherUnitedStatesOrCanada(int p0)
        {
            scrollpagedown();
            string CountryVal = Gettext(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            if (CountryVal == "United States")
            {
                Click(attributeName_id, ShipperState_Id);
                SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, "AL");
                string GetUIVal = Gettext(attributeName_xpath, Shiper_State_Province_dropdown_Xpath);
                Assert.AreEqual("AL", GetUIVal);
                Report.WriteLine("State/Province field is validated when country is United States");
            }
            else if (CountryVal == "Canada")
            {
                Click(attributeName_id, ShipperState_Id);
                SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, "AB");
                string GetUIVal = Gettext(attributeName_xpath, Shiper_State_Province_dropdown_Xpath);
                Assert.AreEqual("AB", GetUIVal);
                Report.WriteLine("State/Province field is validated when country is Canada");
            }
            else
            {
                string ShipStateProvince = "das yduwt 74326748 FSAGHD DSGEF 74326 DFSJEG DUEWU";
                SendKeys(attributeName_id, ShipperState_Id, ShipStateProvince);
                string GetUIVal = GetAttribute(attributeName_xpath, Shiper_State_Province_dropdown_Xpath, "value");
                Assert.AreEqual(ShipStateProvince, GetUIVal);
                Report.WriteLine("State/Province field is validated by passing a maximum of 50 alpha numeric characters when country is neither United States nor Canada");
            }
        }

        [Then(@"I should not be able to pass more than (.*) text to State or Province field of shipper information section when country is either United states or Cannada")]
        public void ThenIShouldNotBeAbleToPassMoreThanTextToStateOrProvinceFieldOfShipperInformationSectionWhenCountryIsEitherUnitedStatesOrCannada(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text to State or Province field of shipper information section when country is neither United states nor Canada")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextToStateOrProvinceFieldOfShipperInformationSectionWhenCountryIsNeitherUnitedStatesNorCanada(int p0)
        {
            scrollpagedown();
            string ShipStateProvince = "dasyduwt74326748FSAGHDDSGEF74326DFSJEGDUEWU43244";
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ShipperProvince_Id, ShipStateProvince);
            string GetUIVal = GetAttribute(attributeName_id, ShipperProvince_Id, "value");
            Assert.AreEqual(ShipStateProvince, GetUIVal);
            Report.WriteLine("State/Province field is validated by passing a maximum of 50 alpha numeric characters when country is neither United States nor Canada");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text to State or Province field of shipper information section when country is neither United states nor Canada")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextToStateOrProvinceFieldOfShipperInformationSectionWhenCountryIsNeitherUnitedStatesNorCanada(int p0)
        {
            scrollpagedown();
            string ShipStateProvince = "dasyduwt74326748FSAGHDDSGEF74326DFSJEGDUEWU4324423q";
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ShipperProvince_Id, ShipStateProvince);
            string GetUIVal = GetAttribute(attributeName_id, ShipperProvince_Id, "value");
            Assert.AreNotEqual(ShipStateProvince, GetUIVal);
            Report.WriteLine("State/Province field is validated by trying to pass more than 50 alpha numeric characters when country is neither United States nor Canada");

        }

        [Then(@"I must be able to pass a maximum of (.*) digits including leading zeros to Zip or Postal field of shipper information section when country is United states")]
        public void ThenIMustBeAbleToPassAMaximumOfDigitsIncludingLeadingZerosToZipOrPostalFieldOfShipperInformationSectionWhenCountryIsUnitedStates(int p0)
        {
            scrollpagedown();
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90000");
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual("90000", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated");
        }

        [Then(@"I should not be able to pass more than or less than (.*) digits to Zip or Postal field of Shipper information section when country is United states")]
        public void ThenIShouldNotBeAbleToPassMoreThanOrLessThanDigitsToZipOrPostalFieldOfShipperInformationSectionWhenCountryIsUnitedStates(int p0)
        {
            scrollpagedown();
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "900001");
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreNotEqual("900001", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by trying to pass more than 5 numeric values");
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric characters to Zip or Postal field of shipper information section when a space is used after first (.*) characters and the country is Canada")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericCharactersToZipOrPostalFieldOfShipperInformationSectionWhenASpaceIsUsedAfterFirstCharactersAndTheCountryIsCanada(int p0, int p1)
        {
            scrollpagedown();
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "QA12ln");
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual("QA12ln", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated when country is canada");

        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric characters to Zip or Postal field when country is Canada")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericCharactersToZipOrPostalFieldWhenCountryIsCanada(int p0)
        {
            scrollpagedown();
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "QA12ln123");
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreNotEqual("QA12ln123", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by trying to pass more than 7 alpha numeric characters when country is canada");
        }

        [Then(@"I should not be able to pass less than (.*) alpha numeric characters to Zip or Postal field when country is Canada")]
        public void ThenIShouldNotBeAbleToPassLessThanAlphaNumericCharactersToZipOrPostalFieldWhenCountryIsCanada(int p0)
        {
            scrollpagedown();
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "QA12");
            string ZipPostal = GetCSSValue(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "background-color");
            string ExpZipPostal = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ZipPostal, ExpZipPostal);
            Report.WriteLine("Zip/Postal field is validated by passing less than 6 alpha numeric characters when country is canada");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric , text, special characters to Zip or Postal field of shipper information section when country is neither Canada nor United states for external users")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfShipperInformationSectionWhenCountryIsNeitherCanadaNorUnitedStatesForExternalUsers(int p0)
        {
            scrollpagedown();
            string ShipZipPostal = "ertyu nbvc !@#5";
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, ShipZipPostal);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual(ShipZipPostal, GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by passing a maximum of 15 alpha-numeric, text, special characters");
        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric , text, special characters to Zip or Postal field when country is neither Canada nor United states")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericTextSpecialCharactersToZipOrPostalFieldWhenCountryIsNeitherCanadaNorUnitedStates(int p0)
        {
            scrollpagedown();
            string ShipZipPostal = "ertyu nbvc !@#5123";
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, ShipZipPostal);
            string GetUIVal = GetAttribute(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreNotEqual(ShipZipPostal, GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by trying to pass more than 15 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass less than (.*) alpha numeric , text, special characters to Zip or Postal field when country is neither Canada nor United states")]
        public void ThenIShouldNotBeAbleToPassLessThanAlphaNumericTextSpecialCharactersToZipOrPostalFieldWhenCountryIsNeitherCanadaNorUnitedStates(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to pass a maximum of (.*) text to Country field of shipper information section")]
        public void ThenIMustBeAbleToPassAMaximumOfTextToCountryFieldOfShipperInformationSection(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not be able to pass a more than (.*) text to Country field of shipper information section")]
        public void ThenIShouldNotBeAbleToPassAMoreThanTextToCountryFieldOfShipperInformationSection(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to see the following expected fields in the Consignee information page - Name, Address, Address(.*), City, StateOrProvince, ZipOrPostal, Country")]
        public void ThenIMustBeAbleToSeeTheFollowingExpectedFieldsInTheConsigneeInformationPage_NameAddressAddressCityStateOrProvinceZipOrPostalCountry(int p0)
        {
            scrollpagedown();
            VerifyElementPresent(attributeName_id, Consignee_Name_Textbox_Id, "ConsigneName");
            VerifyElementPresent(attributeName_id, Consignee_Address_Textbox_Id, "ConsigneAddress");
            VerifyElementPresent(attributeName_id, Consignee_Address2_Textbox_Id, "ConsigneAddress2");
            VerifyElementPresent(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "ConsigneZip");
            VerifyElementPresent(attributeName_xpath, Consignee_Country_dropdown_Xpath, "ConsigneCountry");
            VerifyElementPresent(attributeName_id, Consignee_City_Textbox_Id, "ConsigneCity");
            VerifyElementPresent(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, "ConsigneProvince");
            Report.WriteLine("All the expected fields of Consigne information section exists");
        }

        [Then(@"I must see the following fields highlighted in the Consignee Information section -  Name, Address, City, StateOrProvince, ZipOrPostal, Country")]
        public void ThenIMustSeeTheFollowingFieldsHighlightedInTheConsigneeInformationSection_NameAddressCityStateOrProvinceZipOrPostalCountry()
        {

            scrollpagedown();
            string ConsigneeName = GetCSSValue(attributeName_id, Consignee_Name_Textbox_Id, "background-color");
            string ExpConsigneeName = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ConsigneeName, ExpConsigneeName);
            string ConsigneeAddress = GetCSSValue(attributeName_id, Consignee_Address_Textbox_Id, "background-color");
            string ExpConsigneeAddress = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ConsigneeAddress, ExpConsigneeAddress);
            string ConsigneeCity = GetCSSValue(attributeName_id, Consignee_City_Textbox_Id, "background-color");
            string ExpConsigneeCity = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ConsigneeCity, ExpConsigneeCity);
            string ConsigneeState = GetCSSValue(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, "background");
            string ExpConsigneeState = "url(\"http://dlsww-test.rrd.com/Content/images/formicons.png\") no-repeat scroll 100% -388px / auto padding-box border-box, rgba(0, 0, 0, 0) linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)) repeat scroll 0% 0% / auto padding-box border-box";
            Assert.AreEqual(ConsigneeState, ExpConsigneeState);
            string ConsigneeZip = GetCSSValue(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "background-color");
            string ExpConsigneeZip = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ConsigneeZip, ExpConsigneeZip);
            Report.WriteLine("All the required fields in the Consigne information section is highlighted");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the name field of Consignee information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheNameFieldOfConsigneeInformationSection(int p0)
        {
            scrollpagedown();
            string ConsigneName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT";
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Name_Textbox_Id, "value");
            Assert.AreEqual(ConsigneName, GetUIVal);
            Report.WriteLine("Consigne name field is validated by passing a maximum of 75 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the name field of Consignee information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheNameFieldOfConsigneeInformationSection(int p0)
        {
            scrollpagedown();
            string ConsigneName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT1234";
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Name_Textbox_Id, "value");
            Assert.AreNotEqual(ConsigneName, GetUIVal);
            Report.WriteLine("Consigne name field is validated by trying to pass more than 75 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the address field of Consignee information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheAddressFieldOfConsigneeInformationSection(int p0)
        {
            scrollpagedown();
            string ConsigneAddress = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436";
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Address_Textbox_Id, "value");
            Assert.AreEqual(ConsigneAddress, GetUIVal);
            Report.WriteLine("Consigne Address field is validated by passing a maximum of 150 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the address field of Consignee information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheAddressFieldOfConsigneeInformationSection(int p0)
        {
            scrollpagedown();
            string ConsigneAddress = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436opi";
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Address_Textbox_Id, "value");
            Assert.AreNotEqual(ConsigneAddress, GetUIVal);
            Report.WriteLine("Consigne Address field is validated by trying to pass more than 150 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the address(.*) field of Consignee information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheAddressFieldOfConsigneeInformationSection(int p0, int p1)
        {
            scrollpagedown();
            string ConsigneAddress2 = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436";
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Address2_Textbox_Id, "value");
            Assert.AreEqual(ConsigneAddress2, GetUIVal);
            Report.WriteLine("Consigne Address2 field is validated by passing a maximum of 150 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the address(.*) field of Consignee information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheAddressFieldOfConsigneeInformationSection(int p0, int p1)
        {
            scrollpagedown();
            string ConsigneAddress2 = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436mnb";
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Address2_Textbox_Id, "value");
            Assert.AreNotEqual(ConsigneAddress2, GetUIVal);
            Report.WriteLine("Consigne Address2 field is validated by trying to pass more than 150 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the city field of Consignee information section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheCityFieldOfConsigneeInformationSection(int p0)
        {
            scrollpagedown();
            string ConsigneCity = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertg";
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, ConsigneCity);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_City_Textbox_Id, "value");
            Assert.AreEqual(ConsigneCity, GetUIVal);
            Report.WriteLine("Consigne city field is validated by passing a maximum of 50 alpha-numeric, text, special characters");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the city field of Consignee information section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheCityFieldOfConsigneeInformationSection(int p0)
        {
            scrollpagedown();
            string ConsigneCity = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertg123 ";
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, ConsigneCity);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_City_Textbox_Id, "value");
            Assert.AreNotEqual(ConsigneCity, GetUIVal);
            Report.WriteLine("Consigne city field is validated by trying to pass more than 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should be able to pass a maximum of (.*) text to State or Province field of Consignee information section when country is either United states or Canada")]
        public void ThenIShouldBeAbleToPassAMaximumOfTextToStateOrProvinceFieldOfConsigneeInformationSectionWhenCountryIsEitherUnitedStatesOrCanada(int p0)
        {
            scrollpagedown();
            string CountryVal = Gettext(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            if (CountryVal == "United States")
            {
                Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Consignee_provinceDropdown_values_Xpath, "AL");
                string GetUIVal = Gettext(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
                Assert.AreEqual("AL", GetUIVal);
                Report.WriteLine("State/Province field is validated when country is United States");
            }
            else if (CountryVal == "Canada")
            {
                Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Consignee_provinceDropdown_values_Xpath, "AB");
                string GetUIVal = Gettext(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
                Assert.AreEqual("AB", GetUIVal);
                Report.WriteLine("State/Province field is validated when country is Canada");
            }
            else
            {
                string ConsigneStateProvince = "das yduwt 74326748 FSAGHD DSGEF 74326 DFSJEG DUEWU";
                SendKeys(attributeName_id, ConsigneProvince_Id, ConsigneStateProvince);
                string GetUIVal = GetAttribute(attributeName_id, ConsigneProvince_Id, "value");
                Assert.AreEqual(ConsigneStateProvince, GetUIVal);
                Report.WriteLine("State/Province field is validated by passing a maximum of 50 alpha numeric characters when country is neither United States nor Canada");
            }
        }




        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text to State or Province field of Consignee information section when country is neither United states nor Cannada")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextToStateOrProvinceFieldOfConsigneeInformationSectionWhenCountryIsNeitherUnitedStatesNorCannada(int p0)
        {
            scrollpagedown();
            string ConsigneStateProvince = "dasyduwt74326748FSAGHDDSGEF74326DFSJEGDUEWU43244";
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ConsigneProvince_Id, ConsigneStateProvince);
            string GetUIVal = GetAttribute(attributeName_id, ConsigneProvince_Id, "value");
            Assert.AreEqual(ConsigneStateProvince, GetUIVal);
            Report.WriteLine("State/Province field is validated by passing a maximum of 50 alpha numeric characters when country is neither United States nor Canada");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text to State or Province field of Consignee information section when country is neither United states nor Cannada")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextToStateOrProvinceFieldOfConsigneeInformationSectionWhenCountryIsNeitherUnitedStatesNorCannada(int p0)
        {
            scrollpagedown();
            string ConsigneStateProvince = "dasyduwt74326748FSAGHDDSGEF74326DFSJEGDUEWU43244q12";
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ConsigneProvince_Id, ConsigneStateProvince);
            string GetUIVal = GetAttribute(attributeName_id, ConsigneProvince_Id, "value");
            Assert.AreNotEqual(ConsigneStateProvince, GetUIVal);
            Report.WriteLine("State/Province field is validated by trying to pass more than 50 alpha numeric characters when country is neither United States nor Canada");

        }

        [Then(@"I must be able to pass a maximum of (.*) digits including leading zeros to Zip or Postal field of Consignee information section when country is United states")]
        public void ThenIMustBeAbleToPassAMaximumOfDigitsIncludingLeadingZerosToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsUnitedStates(int p0)
        {
            scrollpagedown();
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90000");
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual("90000", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated");
        }

        [Then(@"I should not be able to pass more than or less than (.*) digits to Zip or Postal field of Consignee information section when country is United states")]
        public void ThenIShouldNotBeAbleToPassMoreThanOrLessThanDigitsToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsUnitedStates(int p0)
        {
            scrollpagedown();
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "900001");
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreNotEqual("900001", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by trying to pass more than 5 numeric values");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric characters to Zip or Postal field of Consignee information section when a space is used after first (.*) characters and the country is Canada")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericCharactersToZipOrPostalFieldOfConsigneeInformationSectionWhenASpaceIsUsedAfterFirstCharactersAndTheCountryIsCanada(int p0, int p1)
        {
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "QA12ln");
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual("QA12ln", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated when country is canada");

        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericCharactersToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsCanada(int p0)
        {
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "QA12ln123");
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreNotEqual("QA12ln123", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by trying to pass more than 7 alpha numeric characters when country is canada");

        }

        [Then(@"I should not be able to pass less than (.*) alpha numeric characters to Zip or Postal field of Consignee information section when country is Canada")]
        public void ThenIShouldNotBeAbleToPassLessThanAlphaNumericCharactersToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsCanada(int p0)
        {
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "QA12");
            string ZipPostal = GetCSSValue(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "background-color");
            string ExpZipPostal = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ZipPostal, ExpZipPostal);
            Report.WriteLine("Zip/Postal field is validated by passing less than 6 alpha numeric characters when country is canada");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states for external users")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsNeitherCanadaNorUnitedStatesForExternalUsers(int p0)
        {
            scrollpagedown();
            string ConsigneeZipPostal = "ertyu nbvc !@#5";
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneeZipPostal);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual(ConsigneeZipPostal, GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by passing a maximum of 15 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsNeitherCanadaNorUnitedStates(int p0)
        {
            scrollpagedown();
            string ConsigneeZipPostal = "ertyu nbvc !@#5123";
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneeZipPostal);
            string GetUIVal = GetAttribute(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreNotEqual(ConsigneeZipPostal, GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by trying to pass more than 15 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass less than (.*) alpha numeric , text, special characters to Zip or Postal field of Consignee information section when country is neither Canada nor United states")]
        public void ThenIShouldNotBeAbleToPassLessThanAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfConsigneeInformationSectionWhenCountryIsNeitherCanadaNorUnitedStates(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to pass a maximum of (.*) text to Country field of Consignee information section")]
        public void ThenIMustBeAbleToPassAMaximumOfTextToCountryFieldOfConsigneeInformationSection(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not be able to pass a more than (.*) text to Country field of Consignee information section")]
        public void ThenIShouldNotBeAbleToPassAMoreThanTextToCountryFieldOfConsigneeInformationSection(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to see a verbiage beneath the claim payable section header stating - Claim must be made payable to party on the bill of lading")]
        public void ThenIMustBeAbleToSeeAVerbiageBeneathTheClaimPayableSectionHeaderStating_ClaimMustBeMadePayableToPartyOnTheBillOfLading()
        {
            scrollpagedown();
            scrollpagedown();
            Verifytext(attributeName_xpath, ClaimPayableToVerbiage_Xpath, "Claim must be made payable to party on the bill of lading");
            Report.WriteLine("Claim Payable To Verbiage exists");
        }

        [Then(@"I must be able to see the following fields in the Claim payable To section - Company Name, Address, Address(.*), City, StateOrProvince, ZipOrPostal, Country, Contact Name, Contact Phone, Contact Email, Contact Website")]
        public void ThenIMustBeAbleToSeeTheFollowingFieldsInTheClaimPayableToSection_CompanyNameAddressAddressCityStateOrProvinceZipOrPostalCountryContactNameContactPhoneContactEmailContactWebsite(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_id, ClaimPayableTo_CompanyName_Id, "CompanyName");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_Address_Id, "Address");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_Address2_Id, "Address2");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_City_Id, "City");
            VerifyElementPresent(attributeName_xpath, ClaimPayableTo_State_Province_dropdown_xpath, "State");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_ZipCode_Id, "Zip");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_Country_dropdown_Id, "Country");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_ContactName_Id, "ContactName");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_ContactPhone_Id, "ContactPhone");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_ContactEmail_Id, "ContactEmail");
            VerifyElementPresent(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "CompanyWebsite");
            Report.WriteLine("All the expected fields of Claim payable to section exists");
        }

        [Then(@"I should be able to view the following fields getting highlighted - Company Name, Address, City, StateOrProvince, ZipOrPostal, Country, Contact Name, Contact Phone, Contact Email")]
        public void ThenIShouldBeAbleToViewTheFollowingFieldsGettingHighlighted_CompanyNameAddressCityStateOrProvinceZipOrPostalCountryContactNameContactPhoneContactEmail()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            ScrollToTopElement(attributeName_id, ClaimPayableTo_CompanyName_Id);
            string ClaimName = GetCSSValue(attributeName_id, ClaimPayableTo_CompanyName_Id, "background-color");
            string ExpClaimName = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimName, ExpClaimName);
            string ClaimAddress = GetCSSValue(attributeName_id, ClaimPayableTo_Address_Id, "background-color");
            string ExpClaimAddress = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimAddress, ExpClaimAddress);
            string ClaimCity = GetCSSValue(attributeName_id, ClaimPayableTo_City_Id, "background-color");
            string ExpClaimCity = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimCity, ExpClaimCity);
            string ClaimState = GetCSSValue(attributeName_id, ClaimState_Id, "background");
            string ExpClaimState = "rgba(0, 0, 0, 0) none repeat scroll 0px 0px / auto padding-box border-box";
            Assert.AreEqual(ClaimState, ExpClaimState);
            string ClaimZip = GetCSSValue(attributeName_id, ClaimPayableTo_ZipCode_Id, "background-color");
            string ExpClaimZip = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimZip, ExpClaimZip);
            string ClaimContactName = GetCSSValue(attributeName_id, ClaimPayableTo_ContactName_Id, "background-color");
            string ExpClaimContactName = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimContactName, ExpClaimContactName);
            string ClaimContactPhone = GetCSSValue(attributeName_id, ClaimPayableTo_ContactPhone_Id, "background-color");
            string ExpClaimContactPhone = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimContactPhone, ExpClaimContactPhone);
            string ClaimContactEmail = GetCSSValue(attributeName_id, ClaimPayableTo_ContactEmail_Id, "background-color");
            string ExpClaimContactEmail = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimContactEmail, ExpClaimContactEmail);
            Report.WriteLine("All the required fields in the Claim Payable To section is highlighted");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the Company name field of Claim Payable To section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheCompanyNameFieldOfClaimPayableToSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimCompanyName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT";
            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, ClaimCompanyName);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_CompanyName_Id, "value");
            Assert.AreEqual(ClaimCompanyName, GetUIVal);
            Report.WriteLine("Company name field is validated by passing a maximum of 75 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the Company name field of Claim Payable To section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheCompanyNameFieldOfClaimPayableToSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimCompanyName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT1234";
            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, ClaimCompanyName);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_CompanyName_Id, "value");
            Assert.AreNotEqual(ClaimCompanyName, GetUIVal);
            Report.WriteLine("Shipper name field is validated by trying to pass more than 75 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the Address field of Claim Payable To section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheAddressFieldOfClaimPayableToSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimPayableToAddress = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436";
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, ClaimPayableToAddress);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_Address_Id, "value");
            Assert.AreEqual(ClaimPayableToAddress, GetUIVal);
            Report.WriteLine("ClaimPayableTo Address field is validated by passing a maximum of 150 alpha-numeric, text, special characters");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the Address field of Claim Payable To section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheAddressFieldOfClaimPayableToSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimPayableToAddress = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436mnb";
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, ClaimPayableToAddress);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_Address_Id, "value");
            Assert.AreNotEqual(ClaimPayableToAddress, GetUIVal);
            Report.WriteLine("ClaimPayableTo Address field is validated by trying to pass more 150 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the Address(.*) field of Claim Payable To section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheAddressFieldOfClaimPayableToSection(int p0, int p1)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimPayableToAddress2 = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436";
            SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, ClaimPayableToAddress2);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_Address2_Id, "value");
            Assert.AreEqual(ClaimPayableToAddress2, GetUIVal);
            Report.WriteLine("ClaimPayableTo Address2 field is validated by passing a maximum of 150 alpha-numeric, text, special characters");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the Address(.*) field of Claim Payable To section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheAddressFieldOfClaimPayableToSection(int p0, int p1)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimPayableToAddress2 = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb ASWERTG HY789 MNBVCDEWRT gdauyd 67432784 yfewdf 76gdsa 67324 @#$%^ dgs  YGSH YTREW FJGEJ DJYE 76436mnb";
            SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, ClaimPayableToAddress2);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_Address2_Id, "value");
            Assert.AreNotEqual(ClaimPayableToAddress2, GetUIVal);
            Report.WriteLine("ClaimPayableTo Address2 field is validated by trying to pass more than 150 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to the city field of Claim Payable To Section")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToTheCityFieldOfClaimPayableToSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimPayableToCity = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertg ";
            SendKeys(attributeName_id, ClaimPayableTo_City_Id, ClaimPayableToCity);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_City_Id, "value");
            Assert.AreEqual(ClaimPayableToCity, GetUIVal);
            Report.WriteLine("ClaimPayableTo city field is validated by passing a maximum of 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to the city field of Claim Payable To Section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToTheCityFieldOfClaimPayableToSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimPayableToCity = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertg123 ";
            SendKeys(attributeName_id, ClaimPayableTo_City_Id, ClaimPayableToCity);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_City_Id, "value");
            Assert.AreNotEqual(ClaimPayableToCity, GetUIVal);
            Report.WriteLine("ClaimPayableTo city field is validated by trying to pass more than 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should be able to pass a maximum of (.*) text to State or Province field of Claim Payable To Section when country is either United states or Cannada")]
        public void ThenIShouldBeAbleToPassAMaximumOfTextToStateOrProvinceFieldOfClaimPayableToSectionWhenCountryIsEitherUnitedStatesOrCannada(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not be able to pass more than (.*) text to State or Province field of Claim Payable To Section when country is either United states or Cannada")]
        public void ThenIShouldNotBeAbleToPassMoreThanTextToStateOrProvinceFieldOfClaimPayableToSectionWhenCountryIsEitherUnitedStatesOrCannada(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text to State or Province field of Claim Payable To Section when country is neither United states nor Canada")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextToStateOrProvinceFieldOfClaimPayableToSectionWhenCountryIsNeitherUnitedStatesNorCanada(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimStateProvince = "dasyduwt74326748FSAGHDDSGEF74326DFSJEGDUEWU43244";
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ClaimProvince_Id, ClaimStateProvince);
            string GetUIVal = GetAttribute(attributeName_id, ClaimProvince_Id, "value");
            Assert.AreEqual(ClaimStateProvince, GetUIVal);
            Report.WriteLine("State/Province field is validated by passing a maximum of 50 alpha numeric characters when country is neither United States nor Canada");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text to State or Province field of Claim Payable To Section when country is neither United states nor Canada")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextToStateOrProvinceFieldOfClaimPayableToSectionWhenCountryIsNeitherUnitedStatesNorCanada(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimStateProvince = "dasyduwt74326748FSAGHDDSGEF74326DFSJEGDUEWU43244ljk";
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ClaimProvince_Id, ClaimStateProvince);
            string GetUIVal = GetAttribute(attributeName_id, ClaimProvince_Id, "value");
            Assert.AreNotEqual(ClaimStateProvince, GetUIVal);
            Report.WriteLine("State/Province field is validated by trying to pass more than 50 alpha numeric characters when country is neither United States nor Canada");

        }

        [Then(@"I must be able to pass a maximum of (.*) digits including leading zeros to Zip or Postal field of Claim Payable To Section when country is United states")]
        public void ThenIMustBeAbleToPassAMaximumOfDigitsIncludingLeadingZerosToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsUnitedStates(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "90000");
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreEqual("90000", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated");
        }

        [Then(@"I should not be able to pass more than or less than (.*) digits to Zip or Postal field of Claim Payable To Section when country is United states")]
        public void ThenIShouldNotBeAbleToPassMoreThanOrLessThanDigitsToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsUnitedStates(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "9000023");
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreNotEqual("9000023", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated");
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric characters to Zip or Postal field of Claim Payable To Section when a space is used after first (.*) characters and the country is Canada")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericCharactersToZipOrPostalFieldOfClaimPayableToSectionWhenASpaceIsUsedAfterFirstCharactersAndTheCountryIsCanada(int p0, int p1)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "QA12ln");
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreEqual("QA12ln", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated when country is canada");

        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric characters to Zip or Postal field of Claim Payable To Section when country is Canada")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericCharactersToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsCanada(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "Canada");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "QA12ln78");
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreNotEqual("QA12ln78", GetUIVal);
            Report.WriteLine("Zip/Postal field is validated when country is canada");

        }

        [Then(@"I should not be able to pass less than (.*) alpha numeric characters to Zip or Postal field of Claim Payable To Section when country is Canada")]
        public void ThenIShouldNotBeAbleToPassLessThanAlphaNumericCharactersToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsCanada(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states for external users")]
        public void ThenIMustBeAbleToPassAMaximumOfAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsNeitherCanadaNorUnitedStatesForExternalUsers(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimZipPostal = "ertyu nbvc !@#5";
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, ClaimZipPostal);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreEqual(ClaimZipPostal, GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by passing a maximum of 15 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsNeitherCanadaNorUnitedStates(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimZipPostal = "ertyu nbvc !@#589";
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "Turkey");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, ClaimZipPostal);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreNotEqual(ClaimZipPostal, GetUIVal);
            Report.WriteLine("Zip/Postal field is validated by passing a maximum of 15 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass less than (.*) alpha numeric , text, special characters to Zip or Postal field of Claim Payable To Section when country is neither Canada nor United states")]
        public void ThenIShouldNotBeAbleToPassLessThanAlphaNumericTextSpecialCharactersToZipOrPostalFieldOfClaimPayableToSectionWhenCountryIsNeitherCanadaNorUnitedStates(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to pass a maximum of (.*) text to Country field of Claim Payable To Section")]
        public void ThenIMustBeAbleToPassAMaximumOfTextToCountryFieldOfClaimPayableToSection(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should not be able to pass a more than (.*) text to Country field of Claim Payable To Section")]
        public void ThenIShouldNotBeAbleToPassAMoreThanTextToCountryFieldOfClaimPayableToSection(int p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to Contact Name field")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToContactNameField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb";
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, ClaimContactName);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ContactName_Id, "value");
            Assert.AreEqual(ClaimContactName, GetUIVal);
            Report.WriteLine("Contact name field is validated by passing a maximum of 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to Contact Name field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToContactNameField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactName = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb76";
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, ClaimContactName);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ContactName_Id, "value");
            Assert.AreNotEqual(ClaimContactName, GetUIVal);
            Report.WriteLine("Contact name field is validated by trying to pass more than 50 alpha-numeric, text, special characters");

        }

        [Then(@"I must be able to pass a maximum of (.*) numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field")]
        public void ThenIMustBeAbleToPassAMaximumOfNumericSpecialCharactersSpaceHyphenOpenParenthesisCloseParenthesisToContactPhoneField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactPhone = "2345678876(1234)";
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, ClaimContactPhone);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ContactPhone_Id, "value");
            Assert.AreEqual(ClaimContactPhone, GetUIVal);
            Report.WriteLine("Contact phone field is validated by passing 20 characters");

        }

        [Then(@"I should not be able to pass more than (.*) numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field")]
        public void ThenIShouldNotBeAbleToPassMoreThanNumericSpecialCharactersSpaceHyphenOpenParenthesisCloseParenthesisToContactPhoneField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactPhone = "2345678876(1234)-564646464644774";
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, ClaimContactPhone);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_ContactPhone_Id, "value");
            Assert.AreNotEqual(ClaimContactPhone, GetUIVal);
            Report.WriteLine("Contact phone field is validated by trying to pass more than 20 characters");

        }

        [Then(@"I should not be able to pass less than (.*) numeric, special characters space, hyphen, open parenthesis, close parenthesis to Contact Phone field")]
        public void ThenIShouldNotBeAbleToPassLessThanNumericSpecialCharactersSpaceHyphenOpenParenthesisCloseParenthesisToContactPhoneField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactPhone = "2345678";
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, ClaimContactPhone);
            string ClaimAddress = GetCSSValue(attributeName_id, ClaimPayableTo_ContactPhone_Id, "background-color");
            string ExpClaimContactPhones = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimAddress, ExpClaimContactPhones);
            Report.WriteLine("Contact phone is validated by thrying to pass less than 10 values");
        }

        [Then(@"I must be able to see Contact email field of Claim Payable To section getting highlighted")]
        public void ThenIMustBeAbleToSeeContactEmailFieldOfClaimPayableToSectionGettingHighlighted()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "dshdg");
            string ClaimEmail = GetCSSValue(attributeName_id, ClaimPayableTo_ContactEmail_Id, "background-color");
            string ExpClaimEmail = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ClaimEmail, ExpClaimEmail);
            Report.WriteLine("Email field is highlighted when an invalid data is entered");
        }

        [Then(@"I must be able to pass a maximum of (.*) alpha-numeric, text, special characters to Contact Website field")]
        public void ThenIMustBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToContactWebsiteField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactWebsite = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb";
            SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, ClaimContactWebsite);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "value");
            Assert.AreEqual(ClaimContactWebsite, GetUIVal);
            Report.WriteLine("Contact website field is validated by passing 50 characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to Contact Website field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToContactWebsiteField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ClaimContactWebsite = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb86876";
            SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, ClaimContactWebsite);
            string GetUIVal = GetAttribute(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "value");
            Assert.AreNotEqual(ClaimContactWebsite, GetUIVal);
            Report.WriteLine("Contact website field is validated by trying to pass more than 50 characters");

        }

        [Then(@"I must be able to see a verbiage beneath claim details section as - Claims must be supported by a detailed statement showing how the amount of your claim was determined\. Please include a complete description of the damaged or lost items and include item numbers or model numbers which should coincide with the invoice you are submitting\.")]
        public void ThenIMustBeAbleToAVerbiageBeneathClaimDetailsSectionAs_ClaimsMustBeSupportedByADetailedStatementShowingHowTheAmountOfYourClaimWasDetermined_PleaseIncludeACompleteDescriptionOfTheDamagedOrLostItemsAndIncludeItemNumbersOrModelNumbersWhichShouldCoincideWithTheInvoiceYouAreSubmitting_()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Verifytext(attributeName_xpath, ClaimDetailsVerbiage_Xpath, "Claims must be supported by a detailed statement showing how the amount of your claim was determined. Please include a complete description of the damaged or lost items and include item numbers or model numbers which should coincide with the invoice you are submitting.");
            Report.WriteLine("Cliam Details verbiage exists");
        }

        [Then(@"I must be able to see Articles Insured field and it should be defaulted to NO\.")]
        public void ThenIMustBeAbleToSeeArticlesInsuredFieldAndItShouldBeDefaultedToNO_()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_xpath, ArticlesInsured_Label_Xpath, "Articles Insured");
            Report.WriteLine("Articles Insured label is available");
            VerifyElementChecked(attributeName_id, ArticlesInsuredNo_Id, "ArticlesInsured Option");
            Report.WriteLine("No is selected by default for Articles Insured field");
        }

        [Then(@"I should be able to view Insured value amount as a required field")]
        public void ThenIShouldBeAbleToViewInsuredValueAmountAsARequiredField()
        {
            VerifyElementPresent(attributeName_id, InsuredAmount_Id, "Insured Value Amount");
            Report.WriteLine("Insured value amount field is present");
        }

        [Then(@"I should be able to pass value to Insured Value amount field")]
        public void ThenIShouldBeAbleToPassValueToInsuredValueAmountField()
        {
            SendKeys(attributeName_id, InsuredAmount_Id, "462534");
            Report.WriteLine("Able to pass values to Insured value amount field");
        }

        [Then(@"The data entered in Insured value amount field should be in currency format")]
        public void ThenTheDataEnteredInInsuredValueAmountFieldShouldBeInCurrencyFormat()
        {
            SendKeys(attributeName_id, InsuredAmount_Id, "23");
            Click(attributeName_xpath, ArticlesInsured_Label_Xpath);
            string GetUIVal = GetAttribute(attributeName_id, InsuredAmount_Id, "value");
            Assert.AreEqual("$23.00", GetUIVal);
            Report.WriteLine("Insures value amount field is currency formatted");
        }

        [When(@"'(.*)' is selected as Articles Insured by default")]
        public void WhenIsSelectedAsArticlesInsuredByDefault(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementChecked(attributeName_id, ArticlesInsuredNo_Id, "Articles Insured No");
            Report.WriteLine("No is selected by default for Articles insured field");
        }


        [Then(@"The Insured value amount field should be hidden")]
        public void ThenTheInsuredValueAmountFieldShouldBeHidden()
        {
            VerifyElementNotVisible(attributeName_id, InsuredAmount_Id, "Insures value");
            Report.WriteLine("Insured value amount field is not visible when articles insured field is selected as NO");
        }

        [Then(@"I should be able to view Claim type label with Damage and Shortage as options to select")]
        public void ThenIShouldBeAbleToViewClaimTypeLabelWithDamageAndShortageAsOptionsToSelect()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Verifytext(attributeName_xpath, ClaimTypeField_Xpath, "Claim Type *");
            VerifyElementPresent(attributeName_xpath, ShortageOption_Xpath, "Shortage");
            VerifyElementPresent(attributeName_xpath, DamageOption_Xpath, "Damage");
            Report.WriteLine("Claim type label and options to select are present");
        }

        [Then(@"No option should be selected by default")]
        public void ThenNoOptionShouldBeSelectedByDefault()
        {
            VerifyElementNotChecked(attributeName_id, Shortage_Id, "Shortage");
            VerifyElementNotChecked(attributeName_id, Damage_Id, "Damage");
            Report.WriteLine("No options are selected by default for Claim type");
        }

        [Then(@"No option should be selected by default for articles type")]
        public void ThenNoOptionShouldBeSelectedByDefaultForArticlesType()
        {
            VerifyElementNotChecked(attributeName_id, ArticlesUsed_Id, "Used");
            VerifyElementNotChecked(attributeName_id, ArticlesNew_Id, "New");
            Report.WriteLine("No options are selected by default for Articles type");
        }


        [Then(@"I should be able to select either Damage or Shortage option")]
        public void ThenIShouldBeAbleToSelectEitherDamageOrShortageOption()
        {
            Click(attributeName_xpath, ShortageOption_Xpath);
            VerifyElementChecked(attributeName_id, Shortage_Id, "Shortage");
            Report.WriteLine("Able to select Claim type option");
        }

        [Then(@"I should be able to view Article type label with New and Used as options to select")]
        public void ThenIShouldBeAbleToViewArticleTypeLabelWithNewAndUsedAsOptionsToSelect()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Verifytext(attributeName_xpath, ArticlesTypeLabel_Xpath, "Articles Type *");
            VerifyElementPresent(attributeName_xpath, ArticlesTypeUsed_Xpath, "Used");
            VerifyElementPresent(attributeName_xpath, ArticlesTypeNew_Xpath, "New");
            Report.WriteLine("Articles type label and options to select are present");

        }

        [Then(@"I should be able to select either New or Used option")]
        public void ThenIShouldBeAbleToSelectEitherNewOrUsedOption()
        {
            Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
            VerifyElementChecked(attributeName_id, ArticlesUsed_Id, "Used");
            Report.WriteLine("Able to select Articles type option");
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text, special characters to Item or Model number field")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToItemOrModelNumberField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ItemModel = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb";
            SendKeys(attributeName_id, ItemMode_Number_Id, ItemModel);
            string GetUIVal = GetAttribute(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreEqual(ItemModel, GetUIVal);
            Report.WriteLine("Item model field is validated by passing a maximum of 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to Item or Model number field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToItemOrModelNumberField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string ItemModel = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb123";
            SendKeys(attributeName_id, ItemMode_Number_Id, ItemModel);
            string GetUIVal = GetAttribute(attributeName_id, ItemMode_Number_Id, "value");
            Assert.AreNotEqual(ItemModel, GetUIVal);
            Report.WriteLine("Item model field is validated by trying to pass more than 50 alpha-numeric, text, special characters");

        }

        [Then(@"I should be able to pass value to Unit value field and the format should be currency")]
        public void ThenIShouldBeAbleToPassValueToUnitValueFieldAndTheFormatShouldBeCurrency()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, UnitValue_Id, "23");
            Click(attributeName_xpath, ArticlesTypeLabel_Xpath);
            string GetUIVal = GetAttribute(attributeName_id, UnitValue_Id, "value");
            Assert.AreEqual("$23.00", GetUIVal);
            Report.WriteLine("Able to pass value to Unit value field and the format is currency");
        }

        [Then(@"I should be able to pass a value greater than zero to Quantity field of claim details section")]
        public void ThenIShouldBeAbleToPassAValueGreaterThanZeroToQuantityFieldOfClaimDetailsSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, Quantity_Id, "45");
            Report.WriteLine("Able to pass value greater than zero in the quantity field");
        }

        [Then(@"I should not be able to pass zero to Quantity field of claim details section")]
        public void ThenIShouldNotBeAbleToPassZeroToQuantityFieldOfClaimDetailsSection()
        {
            SendKeys(attributeName_id, Quantity_Id, "0");
            string GetUIVal = GetAttribute(attributeName_id, Quantity_Id, "value");
            Assert.AreNotEqual("0", GetUIVal);
            Report.WriteLine("Quantity field is validated by trying to pass zero");
        }

        [Then(@"I should be able to pass value to weight field and \# should be displayed after value, two decimal places")]
        public void ThenIShouldBeAbleToPassValueToWeightFieldAndShouldBeDisplayedAfterValueTwoDecimalPlaces()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, Weight_LBS_Id, "23");
            Click(attributeName_xpath, ArticlesTypeLabel_Xpath);
            string GrtUIVal = GetAttribute(attributeName_id, Weight_LBS_Id, "value");
            Assert.AreEqual("23.00#", GrtUIVal);
            Report.WriteLine("Able to pass value to value to Weight field and the value is ending with #");
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text, special characters to Description of Claimed Articles field")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToDescriptionOfClaimedArticlesField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string Description = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb chdsf fhmndsf dsfjesfsd fjeyfs f756b cfu75wegfb dsj4y6wsb x@#$%^&*( fdhtfsd fsyrt fuy7ety7832674832 sduyetdgjwtrw fjhew6537rbd asfy3w4trgfjhrt5rfygbestruewf eu3564gdb cxsry3wtrfuwet yrewtr7uwj@$#$#^&*(^&%&FJDSGJFGES7R FUYEF SERUEWF ESRUEWF SE753F CSDR7WUF SDRU4E875346587236 7EWRFGSJDRGWESF 458734ERFBSMRF RESUIRYHESB MR783RFS DFUW4YRFBSDBTR784EF SJERYWEJF EW895YRHEWIT834YWEFN E57834EWFB DSRUIWYEHDJMDSFUJMV FBEWR7TFUVBDSE78RFUCJFGDBCDFJKCJU6gdgddd";
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, Description);
            string GetUIVal = GetAttribute(attributeName_id, ClaimedArticle_Description_Id, "value");
            Assert.AreEqual(Description, GetUIVal);
            Report.WriteLine("Able to pass a maximum of 500 alpha-numeric, text, special characters to Description field");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to Description of Claimed Articles field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToDescriptionOfClaimedArticlesField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string Description = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb chdsf fhmndsf dsfjesfsd fjeyfs f756b cfu75wegfb dsj4y6wsb x@#$%^&*( fdhtfsd fsyrt fuy7ety7832674832 sduyetdgjwtrw fjhew6537rbd asfy3w4trgfjhrt5rfygbestruewf eu3564gdb cxsry3wtrfuwet yrewtr7uwj@$#$#^&*(^&%&FJDSGJFGES7R FUYEF SERUEWF ESRUEWF SE753F CSDR7WUF SDRU4E875346587236 7EWRFGSJDRGWESF 458734ERFBSMRF RESUIRYHESB MR783RFS DFUW4YRFBSDBTR784EF SJERYWEJF EW895YRHEWIT834YWEFN E57834EWFB DSRUIWYEHDJMDSFUJMV FBEWR7TFUVBDSE78RFUCJFGDBCDFJKCJU6gdgddd 789";
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, Description);
            string GetUIVal = GetAttribute(attributeName_id, ClaimedArticle_Description_Id, "value");
            Assert.AreNotEqual(Description, GetUIVal);
            Report.WriteLine("Validated Description field by trying to pass more than 500 alpha-numeric, text, special characters to Description field");
        }

        [Then(@"I should be able to view Add Another Item hyperlink on claim details section")]
        public void ThenIShouldBeAbleToViewAddAnotherItemHyperlinkOnClaimDetailsSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_id, AddAditionalClaim_btn_Id, "Button");
            Report.WriteLine("Add Another Item hyperlink exists ");
        }

        [Then(@"I should be able to view '(.*)' as default selection for Do you wish to add freight charges\? field")]
        public void ThenIShouldBeAbleToViewAsDefaultSelectionForDoYouWishToAddFreightChargesField(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Verifytext(attributeName_xpath, FreightChargeLabel_Xpath, "Do you wish to add freight charges? *");
            VerifyElementChecked(attributeName_id, FreightChargeNo_Id, "No");
            Report.WriteLine("No is selected by default for Freight charges");
        }

        [Then(@"I should be able to select '(.*)' or '(.*)' option")]
        public void ThenIShouldBeAbleToSelectOrOption(string p0, string p1)
        {
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementChecked(attributeName_id, FreightChargeYes_Id, "Yes");
            Report.WriteLine("Able to select Yes or No for Freight charges");
        }

        [Then(@"I should be able to view Original Freight Charges option field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewOriginalFreightChargesOptionFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_xpath, OriginFreightChargeOption_Xpath, "FreightOption");
            Report.WriteLine("Original Freight Charges option field is present");
        }

        [Then(@"I should be able to pass value to Original Freight Charges option field")]
        public void ThenIShouldBeAbleToPassValueToOriginalFreightChargesOptionField()
        {
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, "23");
            Report.WriteLine("Able to pass value to Original Freight Charges option field");
        }

        [Then(@"I should be able to Click Original Freight Charges option field")]
        public void ThenIShouldBeAbleToClickOriginalFreightChargesOptionField()
        {
            Thread.Sleep(3000);
            Click(attributeName_xpath, OriginFreightChargeOption_Xpath);
            Report.WriteLine("Able to select Original Freight Charges option");
        }


        [Then(@"I should be able to view Original Freight Charges Value field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewOriginalFreightChargesValueFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_classname, OriginFreightChargeOptionField_Class, "Option");
            Report.WriteLine("Able to view Original Freight Charges Value field ");
        }

        [Then(@"I should be able to pass value to Original Freight Charges Value field and format should be currency")]
        public void ThenIShouldBeAbleToPassValueToOriginalFreightChargesValueFieldAndFormatShouldBeCurrency()
        {
            Thread.Sleep(3000);
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, "23");
            Click(attributeName_xpath, OptionFreight_Xpath);
            string GetUIVal = GetAttribute(attributeName_classname, OriginFreightChargeOptionField_Class, "value");
            Assert.AreEqual("$23.00", GetUIVal);
            Report.WriteLine("Able to pass value to Original Freight Charges option field and the format is currency");
        }

        [Then(@"I should be able to select Return Freight Charges option field")]
        public void ThenIShouldBeAbleToClickReturnFreightChargesOptionField()
        {
            Thread.Sleep(3000);
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            Report.WriteLine("Able to select Return Freight Charges option");
        }

        [Then(@"I should be able to view Return Freight Charges option field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewReturnFreightChargesOptionFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_xpath, ReturnFreightCharge_Xpath, "Return");
            Report.WriteLine("Able to view Return Freight Charges option ");
        }

        [Then(@"I should be able to pass value to Return Freight Charges option field")]
        public void ThenIShouldBeAbleToPassValueToReturnFreightChargesOptionField()
        {
            SendKeys(attributeName_classname, ReturnFreightVal_Class, "23");
            Click(attributeName_xpath, OptionFreight_Xpath);
            string GetUIVal = GetAttribute(attributeName_classname, ReturnFreightVal_Class, "value");
            Assert.AreEqual("$23.00", GetUIVal);
            Report.WriteLine("Able to pass Value to Return Freight Charges option field ");
        }

        [Then(@"I should be able to view Return Freight Charges Value field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewReturnFreightChargesValueFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_classname, ReturnFreightVal_Class, "ReturnVal");
            Report.WriteLine("Able to view Return Freight Charges Value field");
        }

        [Then(@"I should be able to pass value to Return Freight Charges Value field and format should be currency")]
        public void ThenIShouldBeAbleToPassValueToReturnFreightChargesValueFieldAndFormatShouldBeCurrency()
        {
            Thread.Sleep(3000);
            SendKeys(attributeName_classname, ReturnFreightVal_Class, "23");
            Click(attributeName_xpath, OptionFreight_Xpath);
            string GetUIVal = GetAttribute(attributeName_classname, ReturnFreightVal_Class, "value");
            Assert.AreEqual("$23.00", GetUIVal);
            Report.WriteLine("Able to pass Value to Return Freight Charges option field ");

        }

        [Then(@"I should be able to view DLSW Ref \# field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewDLSWRefFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_id, ReturnDLS_Id, "ReturnDLS");
            VerifyElementPresent(attributeName_id, ReplaceDLS_Id, "ReplaceDLS");
            Report.WriteLine("Able to view DLSW Ref # field");
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric value to DLSW Ref \# field")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericValueToDLSWRefField(int p0)
        {
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ReturnDLS_Id, "45564321236789087654");
            Report.WriteLine("Able to pass 20 digits ");
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric value to DLSW Ref \# field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericValueToDLSWRefField(int p0)
        {
            Thread.Sleep(1000);
            string ReturnVal = "4556432123678908765476";
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnVal);
            string GetUIVal = GetAttribute(attributeName_id, ReturnDLS_Id, "value");
            Assert.AreNotEqual(ReturnVal, GetUIVal);
            Report.WriteLine("Validated DLSW Ref field by trying to pass more than 20 digits");
        }

        [Then(@"I should be able to view Replacement Freight Charges option field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewReplacementFreightChargesOptionFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_xpath, ReplacementFreight_Xpath, "Replacement");
            Report.WriteLine("Able to view Replacement Freight Charges option ");
        }

        [Then(@"I should be able to select Replacement Freight Charges option field")]
        public void ThenIShouldBeAbleToSelectReplacementFreightChargesOptionField()
        {
            Thread.Sleep(2000);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            Report.WriteLine("Able to select Replacement Freight Charges option ");
        }


        [Then(@"I should be able to pass value to Replacement Freight Charges option field")]
        public void ThenIShouldBeAbleToPassValueToReplacementFreightChargesOptionField()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to view Replacement Freight Charges Value field when Do you wish to add freight charges is equal to '(.*)'")]
        public void ThenIShouldBeAbleToViewReplacementFreightChargesValueFieldWhenDoYouWishToAddFreightChargesIsEqualTo(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to pass value to Replacement Freight Charges Value field and the format should be currency")]
        public void ThenIShouldBeAbleToPassValueToReplacementFreightChargesValueFieldAndTheFormatShouldBeCurrency()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to view Subtotal All Claim Value field")]
        public void ThenIShouldBeAbleToViewSubtotalAllClaimValueField()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            VerifyElementPresent(attributeName_id, Subtotal_Id, "Subtotal");
        }



        [Then(@"Subtotal All Claim Value field should display sum of Original Freight Charges\+Return Freight Charges\+Replacement Freight Charges values")]
        public void ThenSubtotalAllClaimValueFieldShouldDisplaySumOfOriginalFreightChargesReturnFreightChargesReplacementFreightChargesValues()
        {
            decimal OriginFreight = 12;
            decimal ReturnFreight = 8;
            decimal ReplaceFreight = 10;
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, OriginFreight.ToString());
            SendKeys(attributeName_classname, ReturnFreightVal_Class, ReturnFreight.ToString());
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, ReplaceFreight.ToString());
            decimal Total = OriginFreight + ReturnFreight + ReplaceFreight;
            string ExpTotal = "$" + Total + ".00";
            string GetUIVal = GetAttribute(attributeName_id, Subtotal_Id, "value");
            Assert.AreEqual(GetUIVal, ExpTotal);
            Report.WriteLine("Sum is displayed");
        }

        [Then(@"Subtotal All Claim Value field format should be currency")]
        public void ThenSubtotalAllClaimValueFieldFormatShouldBeCurrency()
        {
            Click(attributeName_id, Subtotal_Id);
            string GetUIVal = GetAttribute(attributeName_id, Subtotal_Id, "value");
            Assert.AreEqual("$30.00", GetUIVal);
            Report.WriteLine("Sub total is displayed in currency format");

        }

        [Then(@"I must be able to see the following required fields getting highlighted - Unit Value, Quantity, Weight, Description of Claimed Articles, Do you wish to add freight charges\?")]
        public void ThenIMustBeAbleToSeeTheFollowingRequiredFieldsGettingHighlighted_UnitValueQuantityWeightDescriptionOfClaimedArticlesDoYouWishToAddFreightCharges()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I must be able to see the following required fields getting highlighted - Claim Type, Articles Type, Unit Value, Quantity, Weight, Description of Claimed Articles, Do you wish to add freight charges\?")]
        public void ThenIMustBeAbleToSeeTheFollowingRequiredFieldsGettingHighlighted_ClaimTypeArticlesTypeUnitValueQuantityWeightDescriptionOfClaimedArticlesDoYouWishToAddFreightCharges()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I choose '(.*)' for Do you wish to add freight charges field")]
        public void ThenIChooseForDoYouWishToAddFreightChargesField(string p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, FreightChargeYes_Xpath);
        }

        [Then(@"I choose '(.*)' for Articles Insured field")]
        public void ThenIChooseForArticlesInsuredField(string p0)
        {
            scrollPageup();
            scrollPageup();
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
        }

        [Then(@"I click on submit button")]
        public void ThenIClickOnSubmitButton()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
        }

        [Then(@"I should see the following fields getting highlighted -Insured Value Amount, Original Freight Charges Value, Return Freight Charges Value, Replacement Freight Charges Value, Subtotal All Claim Value")]
        public void ThenIShouldSeeTheFollowingFieldsGettingHighlighted_InsuredValueAmountOriginalFreightChargesValueReturnFreightChargesValueReplacementFreightChargesValueSubtotalAllClaimValue()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string InsuranceAmount = GetCSSValue(attributeName_id, InsuredAmount_Id, "background-color");
            string ExpInsuranceAmount = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(InsuranceAmount, ExpInsuranceAmount);
            scrollpagedown();
            string OriginFreight = GetCSSValue(attributeName_classname, OriginFreightChargeOptionField_Class, "background-color");
            string ExpOriginFreight = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(OriginFreight, ExpOriginFreight);
            string ReturnFreight = GetCSSValue(attributeName_classname, ReturnFreightVal_Class, "background-color");
            string ExpReturnFreight = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(ReturnFreight, ExpReturnFreight);



        }

        [Then(@"I should be able to view remarks field on sign off section")]
        public void ThenIShouldBeAbleToViewRemarksFieldOnSignOffSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_id, RemarksField_Id, "Remarks");
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text, special characters to sign off section")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToSignOffSection(int p0)
        {
            string Remarks = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb chdsf fhmndsf dsfjesfsd fjeyfs f756b cfu75wegfb dsj4y6wsb x@#$%^&*( fdhtfsd fsyrt fuy7ety7832674832 sduyetdgjwtrw fjhew6537rbd asfy3w4trgfjhrt5rfygbestruewf eu3564gdb cxsry3wtrfuwet yrewtr7uwj@$#$#^&*(^&%&FJDSGJFGES7R FUYEF SERUEWF ESRUEWF SE753F CSDR7WUF SDRU4E875346587236 7EWRFGSJDRGWESF 458734ERFBSMRF RESUIRYHESB MR783RFS DFUW4YRFBSDBTR784EF SJERYWEJF EW895YRHEWIT834YWEFN E57834EWFB DSRUIWYEHDJMDSFUJMV FBEWR7TFUVBDSE78RFUCJFGDBCDFJKCJU6gdgddd";
            SendKeys(attributeName_id, RemarksField_Id, Remarks);
            string GetUIVal = GetAttribute(attributeName_id, RemarksField_Id, "value");
            Assert.AreEqual(GetUIVal, Remarks);
            Report.WriteLine("Remark field is validated");

        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to sign off section")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToSignOffSection(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string Remarks = "cvdert 12345 !@#$% :{_ vbnmjhgfd tr56789 zaqwertgb chdsf fhmndsf dsfjesfsd fjeyfs f756b cfu75wegfb dsj4y6wsb x@#$%^&*( fdhtfsd fsyrt fuy7ety7832674832 sduyetdgjwtrw fjhew6537rbd asfy3w4trgfjhrt5rfygbestruewf eu3564gdb cxsry3wtrfuwet yrewtr7uwj@$#$#^&*(^&%&FJDSGJFGES7R FUYEF SERUEWF ESRUEWF SE753F CSDR7WUF SDRU4E875346587236 7EWRFGSJDRGWESF 458734ERFBSMRF RESUIRYHESB MR783RFS DFUW4YRFBSDBTR784EF SJERYWEJF EW895YRHEWIT834YWEFN E57834EWFB DSRUIWYEHDJMDSFUJMV FBEWR7TFUVBDSE78RFUCJFGDBCDFJKCJU6gdgddd12345";
            SendKeys(attributeName_id, RemarksField_Id, Remarks);
            string GetUIVal = GetAttribute(attributeName_id, RemarksField_Id, "value");
            Assert.AreNotEqual(GetUIVal, Remarks);
            Report.WriteLine("Remark field is validated by trying to pass more than 500 characters");
        }

        [Then(@"I should be able to view a verbiage next to remarks field label stating - Please describe what prompted your claim\. Try to be as detailed as possible\.")]
        public void ThenIShouldBeAbleToViewAVerbiageNextToRemarksFieldLabelStating_PleaseDescribeWhatPromptedYourClaim_TryToBeAsDetailedAsPossible_()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Verifytext(attributeName_xpath, RemarkVerbiage_Xpath, "Remarks (Please describe what prompted your claim. Try to be as detailed as possible.)");
            Report.WriteLine("Remarks Verbiage exists");
        }




        [Then(@"I should be able to view a verbiage next to accuracy confirmation box of sign off section stating - It is the claimants responsibility to mitigate claim down to the lowest possible dollar amount\.  All damaged commodities and packaging must be kept for carrier inspection and or salvage if claim is being honored\. Per National Motor Freight Classification item \# (.*) carriers have (.*) days to conclude a claim\.  DLSW will acknowledge your freight claim within (.*) days of submission and if more information is needed we will ask at that time\.  I acknowledge the foregoing statement of facts as being correct\.")]
        public void ThenIShouldBeAbleToViewAVerbiageNextToAccuracyConfirmationBoxOfSignOffSectionStating_ItIsTheClaimantsResponsibilityToMitigateClaimDownToTheLowestPossibleDollarAmount_AllDamagedCommoditiesAndPackagingMustBeKeptForCarrierInspectionAndOrSalvageIfClaimIsBeingHonored_PerNationalMotorFreightClassificationItemCarriersHaveDaysToConcludeAClaim_DLSWWillAcknowledgeYourFreightClaimWithinDaysOfSubmissionAndIfMoreInformationIsNeededWeWillAskAtThatTime_IAcknowledgeTheForegoingStatementOfFactsAsBeingCorrect_(int p0, int p1, int p2)
        {
            string ActualVerbiage = Gettext(attributeName_xpath, SignOffVerbiageText_Xpath);
            string ExpectedVerbiage = "It is the claimants responsibility to mitigate claim down to the lowest possible dollar amount.  All damaged commodities and packaging must be kept for carrier inspection and or salvage if claim is being honored. Per National Motor Freight Classification item # 300120 carriers have 120 days to conclude a claim.  DLSW will acknowledge your freight claim within 30 days of submission and if more information is needed we will ask at that time.  I acknowledge the foregoing statement of facts as being correct.";
            Assert.AreEqual(ActualVerbiage, ExpectedVerbiage);
        }

        [Then(@"I should be able to pass a maximum of (.*) alpha-numeric, text, special characters to signature field")]
        public void ThenIShouldBeAbleToPassAMaximumOfAlpha_NumericTextSpecialCharactersToSignatureField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string EnterText = "sadyyuyuy dyuwe heyye uiui@whu iu12du dvtegte hehu";
            SendKeys(attributeName_id, Signature_Id, EnterText);
            string DisplayText = GetAttribute(attributeName_id, Signature_Id, "value");
            Assert.AreEqual(EnterText, DisplayText);
        }

        [Then(@"I should not be able to pass more than (.*) alpha-numeric, text, special characters to signature field")]
        public void ThenIShouldNotBeAbleToPassMoreThanAlpha_NumericTextSpecialCharactersToSignatureField(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string EnterText = "sadyyuyuy dyuwe heyye uiuiewhu iucedu dvtegte hehuwhyu hewyuuery";
            SendKeys(attributeName_id, Signature_Id, EnterText);
            string DisplayText = Gettext(attributeName_id, Signature_Id);
            Assert.AreNotEqual(EnterText, DisplayText);
        }

        [Then(@"I should be able to view Submit Claim buttton on Submit a claim page")]
        public void ThenIShouldBeAbleToViewSubmitClaimButttonOnSubmitAClaimPage()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            VerifyElementPresent(attributeName_id, SubmitClaimButton_Id, "submit claim button");
        }

        [Then(@"I will see the verbiage - If you are not the beneficial owner of the goods we may require proof of payment to the beneficial owner of the goods prior to payment of the claim to you\.")]
        public void ThenIWillSeeTheVerbiage_IfYouAreNotTheBeneficialOwnerOfTheGoodsWeMayRequireProofOfPaymentToTheBeneficialOwnerOfTheGoodsPriorToPaymentOfTheClaimToYou_()
        {
            string ActualMessage = GetAttribute(attributeName_id, ToolTipInfo_Icon_ClaimPayable_Id, "data-title");
            string expectedMessage = "If you are not the beneficial owner of the goods we may require proof of payment to the beneficial owner of the goods prior to payment of the claim to you.";
            Assert.AreEqual(ActualMessage, expectedMessage);
        }

        [Then(@"I will see the verbiage - If shipment is not a total loss, freight charges will be pro rated based on weight of the affected commodity\.")]
        public void ThenIWillSeeTheVerbiage_IfShipmentIsNotATotalLossFreightChargesWillBeProRatedBasedOnWeightOfTheAffectedCommodity_()
        {
            string ActualMessage = GetAttribute(attributeName_xpath, FreightTootTip_Xpath, "data-title");
            string expectedMessage = "If shipment is not a total loss, freight charges will be pro rated based on weight of the affected commodity.";
            Assert.AreEqual(ActualMessage, expectedMessage);
        }

        [Then(@"The font size will be (.*),")]
        public void ThenTheFontSizeWillBe(int p0)
        {
            string UIFontsize = GetCSSValue(attributeName_xpath, ClaimPage_Header_Verbiage_xpath, "font-size");
            string ExpFontsize = "20px";
            Assert.AreEqual(UIFontsize, ExpFontsize);
            Report.WriteLine("Font Size is 20");
        }

        [Then(@"The font size of inline labels should be (.*)px")]
        public void ThenTheFontSizeOfInlineLabelsShouldBePx(int p0)
        {
            string UIInlineFontsize = GetCSSValue(attributeName_xpath, ClaimPageInlineLabelFont_Xpath, "font-size");
            string ExpInlineFontsize = "12px";
            Assert.AreEqual(UIInlineFontsize, ExpInlineFontsize);
            Report.WriteLine("Font Size is 12px");
        }

        [Then(@"The font color will be black\.")]
        public void ThenTheFontColorWillBeBlack_()
        {
            string UIFontColour = GetCSSValue(attributeName_xpath, ClaimPage_Header_Verbiage_xpath, "color");
            string ExpFontcolour = "rgba(0, 0, 0, 1)";
            Assert.AreEqual(UIFontColour, ExpFontcolour);
            Report.WriteLine("Font colour is black");
        }

        [Then(@"I should see the following fields - Claim Type, Articles Type, Item/Model\#, Unit Value, Quantity, Weight, Description of Claimed Articles")]
        public void ThenIShouldSeeTheFollowingFields_ClaimTypeArticlesTypeItemModelUnitValueQuantityWeightDescriptionOfClaimedArticles()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to view a Remove button")]
        public void ThenIShouldBeAbleToViewARemoveButton()
        {
            VerifyElementPresent(attributeName_id, AddAdditionalRemove_btn_Id, "remove button");
        }

        [Then(@"When I click on Remove button then the additional Another Item fields should be removed")]
        public void ThenWhenIClickOnRemoveButtonThenTheAdditionalAnotherItemFieldsShouldBeRemoved()
        {
            Thread.Sleep(3000);
            MoveToElement(attributeName_xpath, RemoveButtonAddAdditionalItem_Xpath);
            Click(attributeName_xpath, RemoveButtonAddAdditionalItem_Xpath);
            VerifyElementNotPresent(attributeName_id, AddAdditionalRemove_btn_Id, "remove button");
        }

        [Then(@"I should not be able to see Confirmation of accuracy check box in sign off section")]
        public void ThenIShouldNotBeAbleToSeeConfirmationOfAccuracyCheckBoxInSignOffSection()
        {
            VerifyElementNotPresent(attributeName_xpath, SignOff_Checkbox_Xpath, "signOff checkbox");

        }

        [Then(@"I should not be able to see Signature level and field")]
        public void ThenIShouldNotBeAbleToSeeSignatureLevelAndField()
        {
            VerifyElementNotPresent(attributeName_id, Signature_Id, "Signature");

        }

        [Then(@"I will be able to see the verbiage after the Remarks field and prior to the Submit Claim button")]
        public void ThenIWillBeAbleToSeeTheVerbiageAfterTheRemarksFieldAndPriorToTheSubmitClaimButton()
        {
            string expectedVerbiage = "By submitting this claim, I acknowledge that all statements are certified correct. I understand that it is the claimant's responsibility to mitigate the claim down to the lowest possible dollar amount. All damaged commodities, as well as the packaging, must be kept for carrier inspection. If the claim is honored, the carrier has salvage rights to the product. Donnelley Logistic Services Worldwide will acknowledge your freight claim within 30 days of submission and if more information is needed we will ask at that time. Per the National Motor Freight Classification item # 300120 carriers have 120 days to conclude a claim.";
            string actualVerbiage = Gettext(attributeName_xpath, SignOffRemark_verbiage_Xpath);
            Assert.AreEqual(expectedVerbiage, actualVerbiage);
        }

        [Then(@"Quantity Field Should be Empty")]
        public void ThenQuantityFieldShouldbeEmpty()
        {
            string GetUIVal = GetAttribute(attributeName_id, Quantity_Id, "value");
            Assert.AreEqual(string.Empty, GetUIVal);
            Report.WriteLine("Quantity Field is Empty");
        }

        [Then(@"I will see a new optional field Customer Claim Ref \# \(editable,alpha-numeric, text, special characters, max length (.*)\)")]
        public void ThenIWillSeeANewOptionalFieldCustomerClaimRefEditableAlpha_NumericTextSpecialCharactersMaxLength(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            Report.WriteLine("Verifying Customer Claim Ref field is editable");
            VerifyElementEnabled(attributeName_id, customer_claim_ref_Id, "Customer Claim Ref #");
            Report.WriteLine("Customer Claim Ref field is editable");

            string CustomerClaimRef = "cvdt 15 !@#$% :{_ ab";
            SendKeys(attributeName_id, customer_claim_ref_Id, CustomerClaimRef);
            string CustomerClaimRef_UIVal = GetAttribute(attributeName_id, customer_claim_ref_Id, "value");
            Assert.AreEqual(CustomerClaimRef, CustomerClaimRef_UIVal);
            Report.WriteLine("Customer Claim Ref # field is validated by passing a maximum of 20 alpha-numeric, text, special characters");

            Clear(attributeName_id, customer_claim_ref_Id);
            Click(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Validate Customer Claim Ref # Field Highlight");
            string ClaimantReferenceField = GetCSSValue(attributeName_id, customer_claim_ref_Id, "background-color");
            Assert.AreNotEqual(ClaimantReferenceField, "rgba(251, 236, 237, 1)");
        }


    }
}
