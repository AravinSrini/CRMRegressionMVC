using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Configuration;
using System;
using CRM.UITest.CommonMethods;



namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_SubmitClaimPageFunctionsSteps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am on the Claims List page")]
        public void GivenIAmOnTheClaimsListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have logged in as a Operations user")]
        public void GivenIHaveLoggedInAsAOperationsUser()
        {

            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have logged in as a Station Owner")]
        public void GivenIHaveLoggedInAsAStationOwner()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Submit a Claim page")]
        public void GivenIAmOnTheSubmitAClaimPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();           
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
        }

        [Given(@"I am on the Submit a Claim page for external user")]
        public void GivenIAmOnTheSubmitAClaimPageForExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            string ErrorPopupValues = Gettext(attributeName_xpath, ShipmentNotFound_PopUp_Close_button_Xpath);

            if (!string.IsNullOrWhiteSpace(ErrorPopupValues))
            {
                Click(attributeName_xpath, ShipmentNotFound_PopUp_Close_button_Xpath);
            }

            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
        }
        
        [Given(@"I have entered all required fields")]
        public void GivenIHaveEnteredAllRequiredFields()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, "999077");
            SendKeys(attributeName_id, CarrierName_Textbox_Id, "carrier xyz");
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "123rtz");
            Click(attributeName_id, DLSWShipDate_Id);
            Click(attributeName_xpath, DLSWShipDate_Xpath);

            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, "Shipper name");
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, "address122");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90001");

            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, "xrsyd");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, "xyz 12/2");
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, "eyruyru");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90001");
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, "xxxx");

            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, "xxxx");
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, "address1");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "12345");
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, "contact name");
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, "9090908790");
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "test@test.com");

            Click(attributeName_id, ClaimType_Shortage_Id);
            Click(attributeName_id, ArticleType_Used_Xpath);
            SendKeys(attributeName_id, ItemMode_Number_Id, "90909");
            SendKeys(attributeName_id, UnitValue_Id, "90");
            SendKeys(attributeName_id, Quantity_Id, "30");
            SendKeys(attributeName_id, Weight_LBS_Id, "100");
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, "test description");
            SendKeys(attributeName_id, Signature_Id, "test123");

        }

        [Given(@"I have logged in as a ShipEntry")]
        public void GivenIHaveLoggedInAsAShipEntry()
        {
            string username = ConfigurationManager.AppSettings["username-Both"].ToString();
            string password = ConfigurationManager.AppSettings["password-Both"].ToString();

            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I have not completed all required fields")]
        public void GivenIHaveNotCompletedAllRequiredFields()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, "999077");
            SendKeys(attributeName_id, CarrierName_Textbox_Id, "carrier xyz");
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "123rtz");
            Click(attributeName_id, DLSWShipDate_Id);
            Click(attributeName_xpath, DLSWShipDate_Xpath);

            // SendKeys(attributeName_id, Shipper_Name_Textbox_Id, "Shipper name");
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, "address122");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90001");

            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, "xrsyd");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, "xyz 12/2");
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, "eyruyru");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90001");
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, "xxxx");

            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, "xxxx");
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, "address1");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "12345");
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, "contact name");
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, "9090908790");
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "test@test.com");

            scrollpagedown();
            Click(attributeName_xpath, ClaimType_Shortage_Xpath);
            Click(attributeName_xpath, ArticleType_Used_Xpath);
            SendKeys(attributeName_id, ItemMode_Number_Id, "90909");
            //SendKeys(attributeName_id, UnitValue_Id, "90");
            //SendKeys(attributeName_id, Quantity_Id, "30");
            //SendKeys(attributeName_id, Weight_LBS_Id, "100");
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, "test description");
            Click(attributeName_xpath, SignOff_Checkbox_Xpath);
            SendKeys(attributeName_id, Signature_Id, "test123");


        }


        [When(@"I click on the Submit a Claim button")]
        public void WhenIClickOnTheSubmitAClaimButton()
        {
            Click(attributeName_id, Submit_A_Claim_button_Id);
        }

        [When(@"I click on the Back to Claims List button,")]
        public void WhenIClickOnTheBackToClaimsListButton()
        {
            Click(attributeName_xpath, BackToClaimListPage_Button_Xpath);
        }


        [When(@"I navigate away from the claim form")]
        public void WhenINavigateAwayFromTheClaimForm()
        {
            Click(attributeName_xpath, ShipmentIcon_Xpath);
        }

        [Then(@"I arrive on the  Submit a Claim page")]
        public void ThenIArriveOnTheSubmitAClaimPage()
        {
            string expectedHeaderText = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            string actualHeaderText = "Submit a Claim";
            Assert.AreEqual(expectedHeaderText, actualHeaderText);
        }

        [Then(@"I will arrive on the Claims List")]
        public void ThenIWillArriveOnTheClaimsList()
        {
            string expectedHeaderText = Gettext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath);
            string actualHeaderText = "Claims List";
            Assert.AreEqual(expectedHeaderText, actualHeaderText);

        }

        [Then(@"I will see a message ""(.*)""")]
        public void ThenIWillSeeAMessage(string p0)
        {
            string expectedMsg = "Please complete all required fields";
            string actualMsg = Gettext(attributeName_xpath, SubmitClaimPage_validationMsg_Xpath);
            Assert.AreEqual(expectedMsg, actualMsg);
        }

        [Then(@"every required field where data is missing will be highlighted")]
        public void ThenEveryRequiredFieldWhereDataIsMissingWillBeHighlighted()
        {
            Report.WriteLine("Highlighting all required fields");
            string UIUnitValueColor = GetCSSValue(attributeName_id, UnitValue_Id, "background-color");
            string ActualUnitValueColor = "rgba(255, 240, 243, 1)";
            Assert.AreEqual(UIUnitValueColor, ActualUnitValueColor);

            string UIquantityColor = GetCSSValue(attributeName_id, Quantity_Id, "background-color");
            string ActualQuantityColor = "rgba(255, 240, 243, 1)";
            Assert.AreEqual(UIquantityColor, ActualQuantityColor);

            string UIweightColor = GetCSSValue(attributeName_id, Weight_LBS_Id, "background-color");
            string ActualWeightColor = "rgba(255, 240, 243, 1)";
            Assert.AreEqual(UIweightColor, ActualWeightColor);

            string UIshipperNameColor = GetCSSValue(attributeName_id, Shipper_Name_Textbox_Id, "background-color");
            string ActualShipperNameColor = "rgba(255, 240, 243, 1)";
            Assert.AreEqual(UIshipperNameColor, ActualShipperNameColor);
        }

        [Then(@"the page will focus to the first required field that is missing information")]
        public void ThenThePageWillFocusToTheFirstRequiredFieldThatIsMissingInformation()
        {
            // verify for ShipperName
            string ShipperName = GetValue(attributeName_id, Shipper_Name_Textbox_Id, "value");
            CrmLogin.VerifyFocus(ShipperName, Shipper_Name_Textbox_Id);

            // verify for unitValue
            string UnitValue = GetValue(attributeName_id, UnitValue_Id, "value");
            CrmLogin.VerifyFocus(UnitValue, UnitValue_Id);


        }

        [Then(@"no data will be saved")]
        public void ThenNoDataWillBeSaved()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);


            string DLSWBillOfLading = GetValue(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            if (DLSWBillOfLading.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string CarrierPro = GetValue(attributeName_id, CarrierPro_Textbox_Id, "value");
            if (CarrierPro.Length != 0)
            {
                Assert.IsTrue(false);
            }

            string CarrierName = GetValue(attributeName_id, CarrierName_Textbox_Id, "value");
            if (CarrierName.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ShipperName = GetValue(attributeName_id, Shipper_Name_Textbox_Id, "value");
            if (ShipperName.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Shipper_Address = GetValue(attributeName_id, Shipper_Address_Textbox_Id, "value");
            if (Shipper_Address.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Shipper_Address2 = GetValue(attributeName_id, Shipper_Address2_Textbox_Id, "value");
            if (Shipper_Address2.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Shipper_Zip_Postal = GetValue(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            if (Shipper_Zip_Postal.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Shipper_Country_dropdownValue = GetValue(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "value");
            if (Shipper_Country_dropdownValue.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Shipper_City = GetValue(attributeName_xpath, Shipper_City_Textbox_Id, "value");
            if (Shipper_City.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Shipper_provinceDropdown = GetValue(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, "value");
            if (Shipper_provinceDropdown.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_Name = GetValue(attributeName_id, Consignee_Name_Textbox_Id, "value");
            if (Consignee_Name.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_Address = GetValue(attributeName_id, Consignee_Address_Textbox_Id, "value");
            if (Consignee_Address.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_Address2 = GetValue(attributeName_id, Consignee_Address2_Textbox_Id, "value");
            if (Consignee_Address2.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_Zip_Postal = GetValue(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            if (Consignee_Zip_Postal.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_Country_dropdownValue = GetValue(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "value");
            if (Consignee_Country_dropdownValue.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_City = GetValue(attributeName_id, Consignee_City_Textbox_Id, "value");
            if (Consignee_City.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Consignee_State_Province = GetValue(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, "value");
            if (Consignee_State_Province.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_CompanyName = GetValue(attributeName_id, ClaimPayableTo_CompanyName_Id, "value");
            if (ClaimPayableTo_CompanyName.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_Address = GetValue(attributeName_id, ClaimPayableTo_Address_Id, "value");
            if (ClaimPayableTo_Address.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_Address2 = GetValue(attributeName_id, ClaimPayableTo_Address2_Id, "value");
            if (ClaimPayableTo_Address2.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_ZipCode = GetValue(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            if (ClaimPayableTo_ZipCode.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_City = GetValue(attributeName_id, ClaimPayableTo_City_Id, "value");
            if (ClaimPayableTo_City.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_Country = GetValue(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath, "value");
            if (ClaimPayableTo_Country.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_State_Province = GetValue(attributeName_xpath, ClaimPayableTo_State_Province_dropdown_xpath, "value");
            if (ClaimPayableTo_State_Province.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_ContactName = GetValue(attributeName_id, ClaimPayableTo_ContactName_Id, "value");
            if (ClaimPayableTo_ContactName.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_ContactPhone = GetValue(attributeName_id, ClaimPayableTo_ContactPhone_Id, "value");
            if (ClaimPayableTo_ContactPhone.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_ContactEmail = GetValue(attributeName_id, ClaimPayableTo_ContactEmail_Id, "value");
            if (ClaimPayableTo_ContactEmail.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimPayableTo_CompanyWebsite = GetValue(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "value");
            if (ClaimPayableTo_CompanyWebsite.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ItemMode_Number = GetValue(attributeName_id, ItemMode_Number_Id, "value");
            if (ItemMode_Number.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string UnitValue = GetValue(attributeName_id, UnitValue_Id, "value");
            if (UnitValue.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Quantity = GetValue(attributeName_id, Quantity_Id, "value");
            if (Quantity.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Weight = GetValue(attributeName_id, Weight_LBS_Id, "value");
            if (Weight.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string ClaimedArticle_Description = GetValue(attributeName_id, ClaimedArticle_Description_Id, "value");
            if (ClaimedArticle_Description.Length != 0)
            {
                Assert.IsTrue(false);
            }
            string Signature = GetValue(attributeName_id, Signature_Id, "value");
            if (Signature.Length != 0)
            {
                Assert.IsTrue(false);
            }
        }


    }
}
