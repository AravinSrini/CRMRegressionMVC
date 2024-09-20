using Microsoft.VisualStudio.TestTools.UnitTesting;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using OpenQA.Selenium;

namespace CRM.UITest.Scripts.Insurance_Claims.Amend_Claim
{
    [Binding]
    public class InsuranceClaims_Amend_BindingCarrier_Shipper_Consignee_ClaimPayableSteps : Objects.InsuranceClaim
    {
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        InsuranceClaimViewModel ClaimDetails = null;
        string userType = string.Empty;
        string _claimnumber = string.Empty;

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist User (.*),(.*),(.*)")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerUserOrClaimsSpecialistUser(string usertype, string username, string password)
        {   
            userType = usertype;
            username = ConfigurationManager.AppSettings[username].ToString();
            password = ConfigurationManager.AppSettings[password].ToString();
            Report.WriteLine("Logged in User is " + usertype);

            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"the claim is in Amend status")]
        public void GivenTheClaimIsInAmendStatus()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox and inorder to Pick Amend Status Claim");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath);
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
        }

        [When(@"I click on the Edit icon of Amend status Claim")]
        public void WhenIClickOnTheEditIconOfAmendStatusClaim()
        {
            Report.WriteLine("Click on Edit icon");
            if (userType == "Claimspecialist")
            {
                Click(attributeName_xpath, sortarrowDate_Claimlistpage_Xpath);
                string claimnumber = Gettext(attributeName_xpath, ".//tr[1]//*[@class='dlsw-claim-number']");
                string[] _ClaimNumber = claimnumber.Split(new char[0]);
                _claimnumber = _ClaimNumber[1];
                Click(attributeName_xpath, ClaimListEditIcon_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Click(attributeName_xpath, sortarrowSubmitDate_Claimlistpage_Xpath);
                _claimnumber = Gettext(attributeName_xpath, ".//tr[1]//*[@class='dlsw-claim-number']");
                Click(attributeName_xpath, ClaimListEditIcon_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            
            GlobalVariables.webDriver.WaitForPageLoad();
            string expHeader = "Submit a Claim" + " " + "(Claim " + "# " + _claimnumber + ")";
            string actHeader = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            if (expHeader.Equals(actHeader))
            {
                Report.WriteLine("Arrived on the Submit a Claim page of Amend claim");
            }
            else
            {
                Report.WriteFailure("Submit a Claim page of Amend claim is not displayed");
            }
        }

        [Then(@"the Carrier Information Section fields DLSW Ref\#, DLSW Ship Date, Carrier Name, Carrier Pro\#, Carrier Pro Date will display the data of the previously submitted claim and it is uneditable")]
        public void ThenTheCarrierInformationSectionFieldsDLSWRefDLSWShipDateCarrierNameCarrierProCarrierProDateWillDisplayTheDataOfThePreviouslySubmittedClaimAndItIsUneditable()
        {
            int claimnumber = Convert.ToInt32(_claimnumber);
            ClaimDetails = DBHelper.GetInsuranceClaimValues(claimnumber);

            Report.WriteLine("Verifying Carrier Information Field data bindings");
            string dLSWBillOfLading_UI = GetValue(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            if (!string.IsNullOrWhiteSpace(ClaimDetails.DlswRefNumber))
            {
                Assert.AreEqual(ClaimDetails.DlswRefNumber, dLSWBillOfLading_UI);
            }
            else
            {
                Assert.AreEqual(string.Empty, dLSWBillOfLading_UI);
            }
            VerifyElementNotEnabled(attributeName_id, DLSWBillOfLading_Textbox_Id, "DLSW Reference Number Textbox");

            string dLSWShipDate_UI = GetValue(attributeName_id, DLSW_BOLDate_Field_Id, "value");
            string dlswShipDatedb = Convert.ToDateTime(ClaimDetails.ShipDate).ToString("MM/dd/yyyy");
            Assert.AreEqual(dlswShipDatedb, dLSWShipDate_UI);

            string carrierName_UI = GetValue(attributeName_id, CarrierName_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.CarrierName, carrierName_UI);
            VerifyElementNotEnabled(attributeName_id, CarrierName_Textbox_Id, "Carrier Name Textbox");

            string carrierPro_UI = GetValue(attributeName_id, CarrierPro_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.CarrierProNumber, carrierPro_UI);
            VerifyElementNotEnabled(attributeName_id, CarrierPro_Textbox_Id, "Carrier Pro Textbox");

            string carrierProDate_UI = GetValue(attributeName_id, CarrierProDate_Field_Id, "value");
            VerifyElementNotEnabled(attributeName_id, CarrierProDate_Field_Id, "Carrier Pro Date");
            if (!string.IsNullOrWhiteSpace(ClaimDetails.CarriePRODate))
            {
                string carrierProDatedb = Convert.ToDateTime(ClaimDetails.CarriePRODate).ToString("MM/dd/yyyy");
                Assert.AreEqual(carrierProDatedb, carrierProDate_UI);
            }
            else
            {
                Assert.AreEqual(string.Empty, carrierProDate_UI);
            }

        }

        [Then(@"the Shipper Information Section fields Name, Address, Address(.*), Zip/Postal, City, State/Province, Country will display the data of the previously submitted claim and it is uneditable")]
        public void ThenTheShipperInformationSectionFieldsNameAddressAddressZipPostalCityStateProvinceCountryWillDisplayTheDataOfThePreviouslySubmittedClaimAndItIsUneditable(int p0)
        {
            Report.WriteLine("Verifying Shipper Information Field data bindings");
            scrollpagedown();
            string shipper_Name_UI = GetValue(attributeName_id, Shipper_Name_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ShipperName, shipper_Name_UI);
            VerifyElementNotEnabled(attributeName_id, Shipper_Name_Textbox_Id, "Shipper Name Textbox");

            string shipper_Address_UI = GetValue(attributeName_id, Shipper_Address_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ShipperAddress, shipper_Address_UI);
            VerifyElementNotEnabled(attributeName_id, Shipper_Address_Textbox_Id, "Shipper Address Textbox");

            string shipper_Address2_UI = GetValue(attributeName_id, Shipper_Address2_Textbox_Id, "value");
            if (!string.IsNullOrWhiteSpace(ClaimDetails.ShipperAdd2))
            {
                Assert.AreEqual(ClaimDetails.ShipperAdd2, shipper_Address2_UI);
            }
            else
            {
                Assert.AreEqual(string.Empty, shipper_Address2_UI);
            }
            VerifyElementNotEnabled(attributeName_id, Shipper_Address2_Textbox_Id, "Shipper Address2 Textbox");

            string shipper_Zip_Postal_UI = GetValue(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ShipperZip, shipper_Zip_Postal_UI);
            VerifyElementNotEnabled(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "Shipper Zip Textbox");

            string shipper_Country_UI = Gettext(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Assert.AreEqual(ClaimDetails.ShipperCountry, shipper_Country_UI);
            string shipperCountryField = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-disabled ShipperCountry chosen-select']", "class");
            if (shipperCountryField.Contains("disabled"))
            {
                Report.WriteLine("Shipper Country field is not editable");

            }
            else
            {
                Report.WriteFailure("Shipper Country field is editable");
            }

            string shipper_City_UI = GetValue(attributeName_id, Shipper_City_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ShipperCity, shipper_City_UI);
            VerifyElementNotEnabled(attributeName_id, Shipper_City_Textbox_Id, "Shipper City Textbox");

            string shipper_State_Province_dropdown = Gettext(attributeName_xpath, Shipper_State_Province_dropdown_Xpath);
            Assert.AreEqual(ClaimDetails.ShipperState, shipper_State_Province_dropdown);
            string shipperStatefield = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-container-single-nosearch chosen-disabled Shipperstate']", "class");
            if (shipperStatefield.Contains("disabled"))
            {
                Report.WriteLine("Shipper State field is not editable");

            }
            else
            {
                Report.WriteFailure("Shipper State field is editable");
            }
        }

        [Then(@"the Consignee Information Section fields Name, Address, Address(.*), Zip/Postal, City, State/Province, Country will display the data of the previously submitted claim and it is uneditable")]
        public void ThenTheConsigneeInformationSectionFieldsNameAddressAddressZipPostalCityStateProvinceCountryWillDisplayTheDataOfThePreviouslySubmittedClaimAndItIsUneditable(int p0)
        {
            Report.WriteLine("Verifying Consignee Information Field data bindings");
            string consignee_Name_UI = GetValue(attributeName_id, Consignee_Name_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ConsigneName, consignee_Name_UI);
            VerifyElementNotEnabled(attributeName_id, Consignee_Name_Textbox_Id, "Consignee Name Textbox");

            string consignee_Address_UI = GetValue(attributeName_id, Consignee_Address_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ConsigneAddress, consignee_Address_UI);
            VerifyElementNotEnabled(attributeName_id, Consignee_Address_Textbox_Id, "Consignee Address Textbox");


            string consignee_Address2_UI = GetValue(attributeName_id, Consignee_Address2_Textbox_Id, "value");
            if (!string.IsNullOrWhiteSpace(ClaimDetails.ConsigneAdd2))
            {
                Assert.AreEqual(ClaimDetails.ConsigneAdd2, consignee_Address2_UI);
            }
            else
            {
                Assert.AreEqual(string.Empty, consignee_Address2_UI);
            }
            VerifyElementNotEnabled(attributeName_id, Consignee_Address2_Textbox_Id, "Consignee Address2 Textbox");

            string consignee_Zip_Postal_UI = GetValue(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ConsigneZip, consignee_Zip_Postal_UI);
            VerifyElementNotEnabled(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "Consignee Zip Textbox");

            string consignee_Country_UI = Gettext(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Assert.AreEqual(ClaimDetails.ConsigneCountry.ToLower(), consignee_Country_UI.ToLower());
            string consigneeCountryField = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-disabled ConsigneeCountry chosen-select']", "class");
            if (consigneeCountryField.Contains("disabled"))
            {
                Report.WriteLine("Consignee Country field is not editable");

            }
            else
            {
                Report.WriteFailure("Consignee Country field is editable");
            }

            string consignee_City_UI = GetValue(attributeName_id, Consignee_City_Textbox_Id, "value");
            Assert.AreEqual(ClaimDetails.ConsigneCity, consignee_City_UI);
            VerifyElementNotEnabled(attributeName_id, Consignee_City_Textbox_Id, "Consignee City Textbox");

            string consignee_State_Province_dropdown = Gettext(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            Assert.AreEqual(ClaimDetails.ConsigneState, consignee_State_Province_dropdown);
            string consigneeStatefield = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-container-single-nosearch chosen-disabled Consigneestate']", "class");
            if (consigneeStatefield.Contains("disabled"))
            {
                Report.WriteLine("Consignee State field is not editable");

            }
            else
            {
                Report.WriteFailure("Consignee State field is editable");
            }
        }

        [Then(@"the Claim Payable To Section fields Company Name, Address, Address2, Zip/Postal, City, State/Province, Country, Contact Name, Contact Phone, Contact Email, Contact Website will display the data of the previously submitted claim and it is uneditable")]
        public void ThenTheClaimPayableToSectionFieldsCompanyNameAddressAddressZipPostalCityStateProvinceCountryContactNameContactPhoneContactEmailContactWebsiteWillDisplayTheDataOfThePreviouslySubmittedClaimAndItIsUneditable()
        {
            Report.WriteLine("Claim Payable To Information Field data bindings");
            scrollpagedown();
            string claimPayableTo_CompanyName = GetValue(attributeName_id, ClaimPayableTo_CompanyName_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimCompanyName, claimPayableTo_CompanyName);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_CompanyName_Id, "Claim Payable To Company Name Textbox");

            string claimPayableTo_Address = GetValue(attributeName_id, ClaimPayableTo_Address_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimAddress, claimPayableTo_Address);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_Address_Id, "Claim Payable To Address Textbox");

            string claimPayableTo_Address2 = GetValue(attributeName_id, ClaimPayableTo_Address2_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimAdd2, claimPayableTo_Address2);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_Address2_Id, "Claim Payable To Address2 Textbox");

            string claimPayableTo_Zip = GetValue(attributeName_id, ClaimPayableTo_ZipCode_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimZip, claimPayableTo_Zip);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_ZipCode_Id, "Claim Payable To Zipcode Textbox");

            string claimPayableTo_City = GetValue(attributeName_id, ClaimPayableTo_City_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimCity, claimPayableTo_City);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_City_Id, "Claim Payable To City Textbox");

            string claimPayableTo_State = Gettext(attributeName_xpath, ClaimPayableTo_State_Province_dropdown_xpath);
            Assert.AreEqual(ClaimDetails.ClaimState, claimPayableTo_State);
            string claimPayableToStatefield = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-container-single-nosearch chosen-disabled ClaimPayableState']", "class");
            if (claimPayableToStatefield.Contains("disabled"))
            {
                Report.WriteLine("Claim Payable To State field is not editable");

            }
            else
            {
                Report.WriteFailure("Claim Payable To State field editable");
            }

            string claimpayableTo_Country = Gettext(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Assert.AreEqual(ClaimDetails.ClaimCountry, claimpayableTo_Country);
            string claimPayableToCountryField = GetValue(attributeName_xpath, "//div[@class='chosen-container chosen-container-single chosen-disabled ClaimCountry chosen-select']", "class");
            if (claimPayableToCountryField.Contains("disabled"))
            {
                Report.WriteLine("Claim Payable To Country field is not editable");

            }
            else
            {
                Report.WriteFailure("Claim Payable To Country field editable");
            }

            string claimPayableTo_ContactName = GetValue(attributeName_id, ClaimPayableTo_ContactName_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimContactName, claimPayableTo_ContactName);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_ContactName_Id, "Claim Payable To Contact Name Textbox");

            string claimPayableTo_ContactPhone = GetValue(attributeName_id, ClaimPayableTo_ContactPhone_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimContactPhone, claimPayableTo_ContactPhone);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_ContactPhone_Id, "Claim Payable To Contact Phone Textbox");

            string claimPayableTo_ContactEmail = GetValue(attributeName_id, ClaimPayableTo_ContactEmail_Id, "value");
            Assert.AreEqual(ClaimDetails.ClaimContactEmail, claimPayableTo_ContactEmail);
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_ContactEmail_Id, "Claim Payable To Contact Email Textbox");


            string claimPayableTo_ContactWebsite = GetValue(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "value");
            if (!string.IsNullOrWhiteSpace(ClaimDetails.ClaimWebsite))
            {
                Assert.AreEqual(ClaimDetails.ClaimWebsite, claimPayableTo_ContactWebsite);
            }
            else
            {
                Assert.AreEqual(string.Empty, claimPayableTo_ContactWebsite);
            }
            VerifyElementNotEnabled(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "Claim Payable To Contact Website Textbox");
        }

    }
}
