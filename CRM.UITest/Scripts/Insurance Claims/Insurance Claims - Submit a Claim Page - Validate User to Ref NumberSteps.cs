using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class Insurance_Claims___Submit_a_Claim_Page___Validate_User_to_Ref_NumberSteps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        public string DLSWRefNumber = "ZZZ1000080";

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales, Sales Management, Operations, or Station Owner user")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
        }


        [When(@"I enter the DLSW Refnumber not associated to logged in User profile and click on the Populate Form button")]
        public void WhenIEnterTheDLSWRefnumberNotAssociatedToLoggedInUserProfileAndClickOnThePopulateFormButton()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, "9920495");
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I enter the DLSW Refnumber associated to logged in User profile and click on the Populate Form button")]
        public void WhenIEnterTheDLSWRefnumberAssociatedToLoggedInUserProfileAndClickOnThePopulateFormButton()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, "ZZX00208760");
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Then(@"I should see the error message '(.*)'")]
        public void ThenIShouldSeeTheErrorMessage(string p0)
        {
            string errorMessage = Gettext(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[3]/div[3]/p");
            Assert.AreEqual(errorMessage, "Please enter a DLSW Ref # associated to your customer profile or manually enter your claim information.");
        }

        [Then(@"I should not see the error message '(.*)'")]
        public void ThenIShouldNotSeeTheErrorMessage(string p0)
        {
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[3]/div[3]/p", "ErrorMessage");
        }


        [Then(@"Submit a Claim page should not be auto populated")]
        public void ThenSubmitAClaimPageShouldNotBeAutoPopulated()
        {
            string dLSWBillOfLading_UI = GetValue(attributeName_id, DLSWBillOfLading_Textbox_Id, "value");
            Assert.AreEqual(dLSWBillOfLading_UI, "");

            string dlswShipDate_UI = GetValue(attributeName_id, DLSW_BOLDate_Field_Id, "placeholder");
            Assert.AreEqual(dlswShipDate_UI, "Select...");

            string carrierProDate_UI = GetValue(attributeName_id, CarrierProDate_Field_Id, "placeholder");
            Assert.AreEqual(carrierProDate_UI, "Select...");

            string carrierName_UI = GetValue(attributeName_id, CarrierName_Textbox_Id, "value");
            Assert.AreEqual(carrierName_UI, "");

            string carrierPro_UI = GetValue(attributeName_id, CarrierPro_Textbox_Id, "value");
            Assert.AreEqual(carrierPro_UI, "");

            string shipper_Name_UI = Gettext(attributeName_id, Shipper_Name_Textbox_Id);
            Assert.AreEqual(shipper_Name_UI, "");

            string shipper_Address_UI = Gettext(attributeName_id, Shipper_Address_Textbox_Id);
            Assert.AreEqual(shipper_Address_UI, "");

            string shipper_Address2_UI = Gettext(attributeName_id, Shipper_Address2_Textbox_Id);
            Assert.AreEqual(shipper_Address2_UI, "");

            string shipper_Zip_Postal_UI = Gettext(attributeName_id, Shipper_Zip_Postal_Textbox_Id);
            Assert.AreEqual(shipper_Zip_Postal_UI, "");

            string shipper_Country_UI = Gettext(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Assert.AreEqual("United States", shipper_Country_UI);

            string shipper_City_UI = Gettext(attributeName_id, Shipper_City_Textbox_Id);
            Assert.AreEqual(shipper_City_UI, "");

            string shipper_State_Province_dropdown = Gettext(attributeName_xpath, Shipper_State_Province_dropdown_Xpath);
            Assert.AreEqual(shipper_State_Province_dropdown, "Select...");

            //Consignee - fields
            string consignee_Name_UI = Gettext(attributeName_id, Consignee_Name_Textbox_Id);
            Assert.AreEqual(consignee_Name_UI, "");

            string consignee_Address_UI = Gettext(attributeName_id, Consignee_Address_Textbox_Id);
            Assert.AreEqual(consignee_Address_UI, "");

            string consignee_Address2_UI = Gettext(attributeName_id, Consignee_Address2_Textbox_Id);
            Assert.AreEqual(consignee_Address2_UI, "");

            string consignee_Zip_Postal_UI = Gettext(attributeName_id, Consignee_Zip_Postal_Textbox_Id);
            Assert.AreEqual(consignee_Zip_Postal_UI, "");

            string consignee_Country_UI = Gettext(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Assert.AreEqual("United States", consignee_Country_UI);

            string consignee_City_UI = Gettext(attributeName_id, Consignee_City_Textbox_Id);
            Assert.AreEqual("", consignee_City_UI);

            string consignee_State_Province_dropdown = Gettext(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            Assert.AreEqual(consignee_State_Province_dropdown, "Select...");



        }

    }
}
