using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaimsB_SaveClaimDetailsButtonNotSavingVariousInfoUpdatesSteps : Objects.InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a Claim specialist user")]
        public void GivenIAmAClaimSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"I click on the hyperlink of the claim which i have submitted")]
        public void GivenIClickOnTheHyperlinkOfTheClaimWhichIHaveSubmitted()
        {
            // Click on Submit Claim on Claim List page
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            // Submitting a Claim
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            int claimNumber = Claim.Claimsubmit("InternalOrClaimSpecialist");
            string submittedClaimNumber = claimNumber.ToString();

            //Search with the claim submitted
            Click(attributeName_xpath, ClaimListPageSearch_Xpath);
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, submittedClaimNumber);
            Click(attributeName_xpath,FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);
        }

        [Given(@"I have edited the (.*)")]
        public void GivenIHaveEditedThe(string section)
        {

            string dateAckToClaimant = "03/05/2019";
            string dateFiled_W_Carrier = "03/05/2019";
            string program = "PPP";
            string amount_Id = "321";
            string company = "RR Donnelley";
            string carrierAck = "Y";
            string carrierAckDate_Id = "03/05/2019";
            string carrierClaimNumber_Id = "321";
            string carrierProDate_Id = "03/05/2019";
            string bOLDate_Id = "03/05/2019";
            string deliveryDate_Id = "03/05/2019";

            if (section == "DLSWOS&DActions")
            {
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, Keys.Backspace);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, dateAckToClaimant);
                Click(attributeName_xpath, DetailsTab_Shipper_ShipperSection_Xpath);
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, Keys.Backspace);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, dateFiled_W_Carrier);
                Report.WriteLine("Updated the fields of DLSW OS&D Actions Section");
            }
            else if (section == "InsuranceInfo")
            {
                Click(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, DetailsTab_Edit_Shipper_Program_ListAll_Xpath, program);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, amount_Id);
                Click(attributeName_xpath, DetailsTab_Edit_Shipper_Company_Click_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, DetailsTab_Edit_Shipper_Company_ListAll_Xpath, company);
                Report.WriteLine("Updated the fields of Insurance Info Section");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (section == "CarrierOS&DActions")
            {
                scrollpagedown();
                Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CarrierOSDActions_CarrierAckValues_Xpath, carrierAck);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_id, CarrierOSDActions_CarrierAckDate_Id);
                SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, carrierAckDate_Id);
                SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, Keys.Backspace);
                SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, carrierClaimNumber_Id);
                Report.WriteLine("Updated the fields of Carrier OS&D Actions Section");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (section == "KeyDates")
            {
                Click(attributeName_id, KeyDates_CarrierProDate_Id);
                SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, KeyDates_CarrierProDate_Id, carrierProDate_Id);
                Click(attributeName_id, KeyDates_BOLDate_Id);
                SendKeys(attributeName_id, KeyDates_BOLDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, KeyDates_BOLDate_Id, bOLDate_Id);
                Click(attributeName_id, KeyDates_DeliveryDate_Id);
                SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, Keys.Backspace);
                SendKeys(attributeName_id, KeyDates_DeliveryDate_Id, deliveryDate_Id);
                Report.WriteLine("Updated the fields of Key Dates Section");
            }
        }


        [Given(@"I click on Save Claim Details button on the Claim Details page")]
        public void GivenIClickOnSaveClaimDetailsButtonOnTheClaimDetailsPage()
        {
            scrollPageup();
            scrollPageup();
            Report.WriteLine("I click on the Save Claim Details button on Claim Details page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, "btnSaveClaimDetails");
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollPageup();
            scrollPageup();
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"I keep all the fields of Shipper, Consignee sections blank")]
        public void GivenIKeepAllTheFieldsOfShipperConsigneeSectionsBlank()
        {
           
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, Keys.Backspace);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, Keys.Backspace);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, Keys.Backspace);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, Keys.Backspace);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Country_Xpath);
            Click(attributeName_xpath, Shipper_Country_NoCountrySelected_Xpath);
            Report.WriteLine("Keeping the fields of Shipper Section blank");

            scrollpagedown();
            Click(attributeName_id, Consignee_Name_Id);
            SendKeys(attributeName_id, Consignee_Name_Id, Keys.Backspace);
            Click(attributeName_id, Consignee_Address_Id);
            SendKeys(attributeName_id, Consignee_Address_Id, Keys.Backspace);
            Click(attributeName_id, Consignee_Zip_Id);
            SendKeys(attributeName_id, Consignee_Zip_Id, Keys.Backspace);
            Click(attributeName_id, Consignee_City_Id);
            SendKeys(attributeName_id, Consignee_City_Id, Keys.Backspace);
            Click(attributeName_xpath, Consignee_Country_Xpath); 
            Click(attributeName_xpath, Consignee_Country_NoCountrySelected_Xpath); 
            Report.WriteLine("Keeping the fields of Consignee Section blank");
        }

        [Then(@"All the required fields of Shipper, Consignee sections will be highlighted with red color")]
        public void ThenAllTheRequiredFieldsOfShipperConsigneeSectionsWillBeHighlightedWithRedColor()
        {

            string shipper_Textbox_rgbaValue = "rgba(251, 236, 237, 1)";
            string consignee_Textbox_rgbaValue = "rgba(251, 236, 236, 1)";
            string shipper_Consignee_Country_rgbValue = "rgba(251, 236, 236)";

            //shipper section
            string detailsTab_Edit_Shipper_Name_Color = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath,"background-color");
            string detailsTab_Edit_Shipper_Address_Color = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, "background-color");
            string detailsTab_Edit_Shipper_Zip_Postal_Color = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "background-color");
            string detailsTab_Edit_Shipper_City_Color = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, "background-color");
            string detailsTab_Edit_Shipper_Country_Color = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryDropdown_Xpath, "background").Split(')')[3].Substring(2)+')';
            string detailsTab_Edit_Shipper_State_Province_TextBox_ValueColor = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, "background-color");

            //Consignee section
            string consignee_Name_Color = GetCSSValue(attributeName_xpath, Consignee_Name_Xpath, "background-color");
            string consignee_Address_Color = GetCSSValue(attributeName_xpath, Consignee_Address_Xpath, "background-color");
            string consignee_City_Color = GetCSSValue(attributeName_xpath, Consignee_City_Xpath, "background-color");
            string consignee_Zip_Color = GetCSSValue(attributeName_xpath, Consignee_Zip_Xpath, "background-color");
            string consignee_Country_Color = GetCSSValue(attributeName_xpath, Consignee_Country_Xpath, "background").Split(')')[3].Substring(2) + ')';
            string consignee_State_Color = GetCSSValue(attributeName_xpath, Consignee_State_Xpath, "background-color");
            
            Assert.AreEqual(detailsTab_Edit_Shipper_Name_Color, shipper_Textbox_rgbaValue);
            Assert.AreEqual(detailsTab_Edit_Shipper_Address_Color, shipper_Textbox_rgbaValue);
            Assert.AreEqual(detailsTab_Edit_Shipper_Zip_Postal_Color, shipper_Textbox_rgbaValue);
            Assert.AreEqual(detailsTab_Edit_Shipper_City_Color, shipper_Textbox_rgbaValue);
            Assert.AreEqual(detailsTab_Edit_Shipper_Country_Color, shipper_Consignee_Country_rgbValue);
            Assert.AreEqual(detailsTab_Edit_Shipper_State_Province_TextBox_ValueColor, shipper_Textbox_rgbaValue);
            Assert.AreEqual(consignee_Name_Color, consignee_Textbox_rgbaValue);
            Assert.AreEqual(consignee_Address_Color, consignee_Textbox_rgbaValue);
            Assert.AreEqual(consignee_City_Color, consignee_Textbox_rgbaValue);
            Assert.AreEqual(consignee_State_Color, consignee_Textbox_rgbaValue);
            Assert.AreEqual(consignee_Country_Color, shipper_Consignee_Country_rgbValue);
            Assert.AreEqual(consignee_Zip_Color, consignee_Textbox_rgbaValue);

            Report.WriteLine("Color code of the fields of Shipper and Consignee section is verified");
        }
    }
}
