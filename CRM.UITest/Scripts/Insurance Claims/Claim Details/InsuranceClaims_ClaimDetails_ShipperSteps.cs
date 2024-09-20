using TechTalk.SpecFlow;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_ShipperSteps : Objects.InsuranceClaim
    {
        string Name_edited = "Test";
        string Address_edited = "1000 windham parkway";
        string City_edited = "Bolingbrook";
        string State_edited = "IL";
        string Zip_edited = "60490";
        string Country_edited = "United States";
        string DateAck_edited = "8/28/2018";
        string DateFiled_edited = "8/28/2018";
        string Amount_edited = "123.09";
        string claimNumber = "2018000270";
        string shipperState_prov = string.Empty;

        [Given(@"I have updated Name, Address, City, State, Zip, Country in the Shipper Section")]
        public void GivenIHaveUpdatedNameAddressCityStateZipCountryInTheShipperSection()
        {
            Report.WriteLine(" updated Name, Address, City, State, Zip, Country in the Shipper Section");
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(10000);
            scrollElementIntoView(attributeName_xpath, DetailsTab_Shipper_ShipperSection_Xpath);
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            SendKeys(attributeName_xpath, Shipper_Country_TextBox_Xpath, Country_edited);
            Click(attributeName_xpath, Shipper_Country_SelectingFirstHighlighted_Xpath);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, Name_edited);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, Address_edited);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, Zip_edited);
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, City_edited);
            //SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, State_edited);
        }

        [Given(@"I have updated Date Ack to Claimant, Date Filed in the DLSW OS&D Actions Section")]
        public void GivenIHaveUpdatedDateAckToClaimantDateFiledInTheDLSWOSDActionsSection()
        {
            scrollPageup();
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(10000);
            Report.WriteLine("updated Date Ack to Claimant, Date Filed in the DLSW OS&D Actions Section");
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, DateAck_edited);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);

            Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, DateFiled_edited);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
        }

        [Given(@"I have updated Program,Amount,Company in the Insurance Info Section")]
        public void GivenIHaveUpdatedProgramAmountCompanyInTheInsuranceInfoSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(10000);
            Report.WriteLine("updated Program,Amount,Company in the Insurance Info Section");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DetailsTab_Edit_Shipper_Program_ListAll_Xpath, "PPP");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, Amount_edited);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Company_Click_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DetailsTab_Edit_Shipper_Company_ListAll_Xpath, "RR Donnelley");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
        }

        [Then(@"updated values should be saved in DB")]
        public void ThenUpdatedValuesShouldBeSavedInDB()
        {
            InsuranceClaimShipperAddress InsuranceClaimShipperaddress = DBHelper.GetInsuranceClaimShipperAddresses(claimNumber);
            InsuranceDlswOsdAction InsuranceDlswOsdaction = DBHelper.GetDlswOsdActionsdetails(claimNumber);
            Entities.Proxy.InsuranceClaim GetInsurancedetails = DBHelper.GetInsurancedetails(claimNumber);
            Country shipperCountry = DBHelper.GetShipperCountryNameDetails(claimNumber);
            string Name_DB = InsuranceClaimShipperaddress?.Name.ToString();
            Assert.AreEqual(Name_edited, Name_DB);
            string Address_DB = InsuranceClaimShipperaddress?.Address.ToString();
            Assert.AreEqual(Address_edited, Address_DB);
            string City_DB = InsuranceClaimShipperaddress?.CityName.ToString();
            Assert.AreEqual(City_edited, City_DB);
            string State_DB = InsuranceClaimShipperaddress?.StateName.ToString();
            Assert.AreEqual(State_edited, State_DB);
            string Zip_DB = InsuranceClaimShipperaddress?.Zip.ToString();
            Assert.AreEqual(Zip_edited, Zip_DB);
            string Country_DB = shipperCountry?.CountryName.ToString();
            Assert.AreEqual(Country_edited, Country_DB);
            string DateAck_DB = InsuranceDlswOsdaction?.DateAckToClaimant.ToString().Replace(" 12:00:00 AM", "");
            Assert.AreEqual(DateAck_edited, DateAck_DB);
            string DateFiled_DB = InsuranceDlswOsdaction?.DateFiledWithCarrier.ToString().Replace(" 12:00:00 AM", "");
            Assert.AreEqual(DateFiled_edited, DateFiled_DB);
            string Amount_DB = GetInsurancedetails?.InsuredValueAmount.ToString();
            Assert.AreEqual(Amount_edited, Amount_DB);
        }

        [Given(@"I have updated any (.*) in the Shipper Section")]
        public void GivenIHaveUpdatedAnyInTheShipperSection(string shippersectionfield)
        {            
            GlobalVariables.webDriver.WaitForPageLoad();
            DefineTimeOut(10000);
            Report.WriteLine("I have edited the any field in shipper section");
            if (shippersectionfield == "Name")
            {
                SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, Name_edited);
            }
            else if (shippersectionfield == "Address")
            {
                SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, Address_edited);
            }
            else if (shippersectionfield == "City")
            {                
                SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, City_edited);
            }
            else if (shippersectionfield == "State")
            {                
                Click(attributeName_xpath, Shipper_State_Province_dropdown_Xpath);
                SendKeys(attributeName_xpath, Shipper_State_Textbox_Xpath, State_edited);
                Click(attributeName_xpath, Shipper_State_SelectingFirstHighlighted_Xpath);
            }
            else if (shippersectionfield == "Zip")
            {                
                SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, Zip_edited);
            }
            else if (shippersectionfield == "Country")
            {                
                Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
                //SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, Country_edited);
                SendKeys(attributeName_xpath, Shipper_Country_TextBox_Xpath, Country_edited);
                Click(attributeName_xpath, Shipper_Country_SelectingFirstHighlighted_Xpath);
            }
            else if (shippersectionfield == "DateAck")
            {
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, Keys.Backspace);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, DateAck_edited);
                Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
            }
            else if (shippersectionfield == "Date Filed")
            {                
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, Keys.Backspace);
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, DateFiled_edited);
                Click(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath);
            }

            else
            {
                SendKeys(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, Amount_edited);
            }

        }

        [Then(@"updated (.*) values should be saved in DB")]
        public void ThenUpdatedValuesShouldBeSavedInDB(string shippersectionfield)
        {
            Report.WriteLine("UpdatedValuesShouldBeSavedInDB");
            InsuranceClaimShipperAddress InsuranceClaimShipperaddress = DBHelper.GetInsuranceClaimShipperAddresses(claimNumber);
            InsuranceDlswOsdAction InsuranceDlswOsdaction = DBHelper.GetDlswOsdActionsdetails(claimNumber);
            Entities.Proxy.InsuranceClaim GetInsurancedetails = DBHelper.GetInsurancedetails(claimNumber);
            Country shipperCountry = DBHelper.GetShipperCountryNameDetails(claimNumber);
            if (shippersectionfield == "Name")
            {
                string Name_DB = InsuranceClaimShipperaddress?.Name.ToString();
                Assert.AreEqual(Name_edited, Name_DB);
            }
            else if (shippersectionfield == "Address")
            {
                string Address_DB = InsuranceClaimShipperaddress?.Address.ToString();
                Assert.AreEqual(Address_edited, Address_DB);
            }
            else if (shippersectionfield == "City")
            {
                string City_DB = InsuranceClaimShipperaddress?.CityName.ToString();
                Assert.AreEqual(City_edited, City_DB);
            }
            else if (shippersectionfield == "State")
            {
                string State_DB = InsuranceClaimShipperaddress?.StateName.ToString();
                Assert.AreEqual(State_edited, State_DB);
            }
            else if (shippersectionfield == "Zip")
            {
                string Zip_DB = InsuranceClaimShipperaddress?.Zip.ToString();
                Assert.AreEqual(Zip_edited, Zip_DB);
            }
            else if (shippersectionfield == "Country")
            {
                string Country_DB = shipperCountry?.CountryName.ToString();
                Assert.AreEqual(Country_edited, Country_DB);
            }
            else if (shippersectionfield == "DateAck")
            {
                string DateAck_DB = InsuranceDlswOsdaction?.DateAckToClaimant.ToString().Replace(" 12:00:00 AM", ""); 
                Assert.AreEqual(DateAck_edited, DateAck_DB);
            }
            else if (shippersectionfield == "DateFiled")
            {
                string DateFiled_DB = InsuranceDlswOsdaction?.DateFiledWithCarrier.ToString().Replace(" 12:00:00 AM", "");
                Assert.AreEqual(DateFiled_edited, DateFiled_DB);
            }

            else
            {
                string Amount_DB = GetInsurancedetails?.InsuredValueAmount.ToString();
                Assert.AreEqual(Amount_edited, Amount_DB);
            }
        }

        [When(@"I am on the Claim Details page of existing claim submitted(.*)")]
        public void WhenIAmOnTheClaimDetailsPageOfExistingClaimSubmitted(string ClaimAvailable)
        {
            string Claimnumber_in_list;
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimAvailable);
            Claimnumber_in_list = Gettext(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
            Click(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
        }

        [Then(@"I verify the State/Prov field in Shipper Information section")]
        public void ThenIVerifyTheStateProvFieldInShipperInformationSection()
        {
           
            scrollpagedown();
            shipperState_prov = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, "value");
            if (shipperState_prov == string.Empty)
            {
                Report.WriteFailure("state/Prov field displayed on UI is blank " + shipperState_prov);
            }
            else
            {
                Report.WriteLine("state/Prov field displayed on UI is not blank" + shipperState_prov);
            }
        }

        [Then(@"I verify state field value in DB data for claim number(.*)")]
        public void ThenIVerifyStateFieldValueInDBDataForClaimNumber(string ClaimNo)
        {
            Report.WriteLine("Verify the DB data");
            InsuranceClaimShipperAddress InsuranceClaimShipperaddress = DBHelper.GetInsuranceClaimShipperAddresses(ClaimNo);
            string State_DB = InsuranceClaimShipperaddress.StateName.ToString();
            Assert.AreEqual(shipperState_prov, State_DB);
        }


    }
}
