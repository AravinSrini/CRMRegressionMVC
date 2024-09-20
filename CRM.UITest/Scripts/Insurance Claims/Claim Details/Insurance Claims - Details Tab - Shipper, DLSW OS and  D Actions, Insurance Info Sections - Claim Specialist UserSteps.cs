using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class Insurance_Claims___Details_Tab___Shipper__DLSW_OS_and__D_Actions__Insurance_Info_Sections___Claim_Specialist_UserSteps : Objects.InsuranceClaim
    {

        public string ClaimNumber;


        //Shipper Section All fields Text
        public string ShipperHeader = "Shipper";
        public string Shipper_Name = "Name";
        public string Shipper_Address = "Address";
        public string Shipper_Zip_Postal = "Zip/Postal";
        public string Shipper_Country = "Country";
        public string Shipper_City = "City";
        public string Shipper_State_Province = "State/Prov";
        public string Shipper_DLSW_OS_D_Actions = "DLSW OS&D Actions";
        public string Shipper_Date_Ack_To_Claimant = "Date Ack to Claimant";
        public string Shipper_Date_Filed_W_Carrier = "Date Filed w/Carrier";
        public string Shipper_Cycle_Time = "Cycle Time";
        public string Shipper_Insurance_Info = "Insurance Info";
        public string Shipper_Program = "Program";
        public string Shipper_Amount = "Amount";
        public string Shipper_Company = "Company";
        public string AlphaNumeric_Text_SpecialCharacter = "ALPHA Nu - 1234567890-!@#$%^&*()_+={}[]|;:' <>,.?/";
        public string MoreThan_50_Character = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyzTotal_60";
        public string MoreThan_75_Character = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789Total_80";
        public string MoreThen_150_Character = "ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_ABCDEFGHIJKLMNOPQRSTUVWXYZ_123456789abcdefghijklmnopqrstuvwxyz_123456789_TotalCount_160";
        public string MoreThen_50_AlphaNumeric = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123458abcdefghijklmnopqrstuTOTAL60";



        [Given(@"I am a claims specialist user")]
        public void GivenIAmAClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked on the hyperlink of any displayed claim on Claims List page")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimOnClaimsListPage()
        {
            Report.WriteLine("I am on the Claims List Page");
            Click(attributeName_id, ClaimsIcon_Id);
            VerifyElementPresent(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);

            int TotalClaimNumber = GetCount(attributeName_xpath, ClaimsListColumns_xpath);
            if (TotalClaimNumber > 0)
            {
                IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']//tr//*[@class='DlswClaimNumber']"));

                for (int i = 0; i < UIValues.Count; i++)
                {
                    int j = i + 1;
                    string TocheckInsured = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr/th[4]");

                    if (TocheckInsured == "INSURED")
                    {
                        string IsInsured = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]/td[4]");
                        if (IsInsured == "Y")
                        {
                            ClaimNumber = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]//*[@class='DlswClaimNumber']");
                            Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]//*[@class='DlswClaimNumber']");
                            break;
                        }

                    }
                    else
                    {
                        string IsInsured = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]/td[3]");
                        if (IsInsured == "Y")
                        {
                            ClaimNumber = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]//*[@class='DlswClaimNumber']");
                            Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//tr[" + j + "]//*[@class='DlswClaimNumber']");
                            GlobalVariables.webDriver.WaitForPageLoad();
                            break;
                        }


                    }
                    //else
                    //{
                    //    Report.WriteLine("Click on the first Reference Number without Insured value");
                    //    ClaimNumber = Gettext(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNum_xpath);
                    //    Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNum_xpath);
                    //}


                }

            }
            else
            {
                Report.WriteLine("No claim found in the grid");
            }

        }

        [Then(@"I am unable to edit the Cycle Time field")]
        public void ThenIAmUnableToEditTheCycleTimeField()
        {
            scrollpagedown();
            Report.WriteLine("Verifing the Cycle Time Text");
            String ActualText_CycleTime = Gettext(attributeName_xpath, DetailsTab_Shipper_CycleTime_Xpath);
            Assert.AreEqual(Shipper_Cycle_Time, ActualText_CycleTime);

            Report.WriteLine("I am unable to edit the Cycle Time field");
            VerifyElementNotEnabled(attributeName_id, DetailsTab_Edit_Shipper_CycleTime_Id, "CycleTime");

        }

        [Then(@"Validate and Verify the Name field \(Optional, alpha-numeric, text, special characters, max length (.*)\)")]
        public void ThenValidateAndVerifyTheNameFieldOptionalAlpha_NumericTextSpecialCharactersMaxLength(int p0)
        {
            scrollpagedown();
            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);

            Report.WriteLine("I will see the Shipper Section Header");
            string ActualShipper_HeaderText = Gettext(attributeName_xpath, DetailsTab_Shipper_ShipperSection_Xpath);
            Assert.AreEqual(ShipperHeader, ActualShipper_HeaderText);

            //Name field will be autopopulated
            Report.WriteLine("Verifying the Autopopulated Data in fields");
            string ActualData_Shipper_NameAutopopulated = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, "value");
            string NameFromDb = AllShipperInformationfrom_DB.Name;
            Assert.AreEqual(NameFromDb, ActualData_Shipper_NameAutopopulated);


            //Name(Optional, alpha - numeric, text, special characters, max length 75)
            Report.WriteLine("Verifying the Name field");
            string ActualShipper_Name_FieldText = Gettext(attributeName_xpath, DetailsTab_Shipper_Name_Xpath);
            Assert.AreEqual(Shipper_Name, ActualShipper_Name_FieldText);


            Report.WriteLine("Name Field will allow the Alpha Numeric , text, Special Character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, AlphaNumeric_Text_SpecialCharacter);
            string ActualData_Shipper_NameField = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, "value");
            Assert.AreEqual(AlphaNumeric_Text_SpecialCharacter, ActualData_Shipper_NameField);

            Report.WriteLine("Name Field Will not allow more then 75 character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, MoreThan_75_Character);
            string Actual_Name_Text = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Name_Xpath, "value");
            int Actual_Name_TotalCount = Actual_Name_Text.Length;
            Assert.AreEqual(75, Actual_Name_TotalCount);
        }

        [Then(@"Validate and Verify the Address field \(Optional, alpha-numeric, text, special characters, max length (.*)\)")]
        public void ThenValidateAndVerifyTheAddressFieldOptionalAlpha_NumericTextSpecialCharactersMaxLength(int p0)
        {
            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);
            string Address1_Db = AllShipperInformationfrom_DB.Address;
            string Address2_Db = AllShipperInformationfrom_DB.Address2;
            string Address1_Address2_Db = Address1_Db + "," + Address2_Db;

            //Address will be Autopopulated 
            string ActualData_Shipper_AddressAutopopulated = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, "value");
            Assert.AreEqual(Address1_Address2_Db, ActualData_Shipper_AddressAutopopulated);


            //Address (Optional, alpha-numeric, text, special characters, max length 150)
            Report.WriteLine("Verifying the Address field");
            string ActualShipper_Address_FieldText = Gettext(attributeName_xpath, DetailsTab_Shipper_Address_Xpath);
            Assert.AreEqual(Shipper_Address, ActualShipper_Address_FieldText);

            Report.WriteLine("Address Field will allow the Alpha Numeric , text, Special Character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, AlphaNumeric_Text_SpecialCharacter);
            string ActualData_Shipper_AddressField = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, "value");
            Assert.AreEqual(AlphaNumeric_Text_SpecialCharacter, ActualData_Shipper_AddressField);

            Report.WriteLine("Address Field Will not allow more then 150 character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, MoreThen_150_Character);
            string Actual_Address_Text = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Address_Xpath, "value");
            int Actual_Address_TotalCount = Actual_Address_Text.Length;
            Assert.AreEqual(150, Actual_Address_TotalCount);

        }

        [Then(@"Validate and Verify the City field \(Optional, alpha-numeric, text, special characters, max length (.*)\)")]
        public void ThenValidateAndVerifyTheCityFieldOptionalAlpha_NumericTextSpecialCharactersMaxLength(int p0)
        {
            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);
            string City_Db = AllShipperInformationfrom_DB.CityName;
            // City will be auto - populated
            string ActualData_City_AddressAutopopulated = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, "value");
            Assert.AreEqual(City_Db, ActualData_City_AddressAutopopulated);


            //City(Optional, alpha - numeric, text, special characters, max length 50)
            Report.WriteLine("Verifying the City field");
            string ActualShipper_City_FieldText = Gettext(attributeName_xpath, DetailsTab_Shipper_City_Xpath);
            Assert.AreEqual(Shipper_City, ActualShipper_City_FieldText);

            Report.WriteLine("City Field will allow the Alpha Numeric , text, Special Character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, AlphaNumeric_Text_SpecialCharacter);
            string ActualData_City_AddressField = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, "value");
            Assert.AreEqual(AlphaNumeric_Text_SpecialCharacter, ActualData_City_AddressField);

            Report.WriteLine("City Field Will not allow more then 50 character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, MoreThan_50_Character);
            string Actual_City_Text = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath, "value");
            int Actual_City_TotalCount = Actual_City_Text.Length;
            Assert.AreEqual(50, Actual_City_TotalCount);

        }

        [Then(@"Validate and Verify the State/Prov \(Optional\) field If Country = United States or Canada \(drop down list, text, max length (.*)\)")]
        public void ThenValidateAndVerifyTheStateProvOptionalFieldIfCountryUnitedStatesOrCanadaDropDownListTextMaxLength(int p0)
        {
            //scrollpagedown();
            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);
            string State_Db = AllShipperInformationfrom_DB.StateName;
            //State will be auto - populated
            string ActualShipper_State_Autopopulated = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_Click_Xpath);
            Assert.AreEqual(State_Db, ActualShipper_State_Autopopulated);


            //State / Prov(Optional)
            Report.WriteLine("Verify the State / Province field");
            string ActualShipper_State_Province = Gettext(attributeName_xpath, DetailsTab_Shipper_State_Province_Xpath);
            Assert.AreEqual(Shipper_State_Province, ActualShipper_State_Province);

            //If Country = United States or Canada(drop down list, text, max length 2)
            Report.WriteLine("If Country is United States or Canada than States will have Dropdown list and Max length for State is 2");
            string ExpectedCountrySelected = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_Country_Xpath);

            string element = "UNITED STATES";
            Report.WriteLine("Checking for the United States Country");
            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryList_All_Xpath, element);
            //IList<IWebElement> UICountry_List = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_CountryList_All_Xpath));
            //for (int i = 0; i < UICountry_List.Count; i++)
            //{
            //    if (UICountry_List[i].Text == "UNITED STATES")
            //    {
            //        UICountry_List[i].Click();
            //        break;
            //    }

            //}


            Click(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_Click_Xpath);
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_state_Provice_All_Xpath));
            for (int i = 1; i < UIValues.Count; i++)
            {
                if (UIValues[i].Text.Length == 2)
                {
                    Report.WriteLine("Max Length is 2 'Expected' ");
                }
                else
                {
                    Report.WriteLine("Not expected");
                    Assert.Fail();
                }
            }

            Report.WriteLine("Checking for the Canada Country");
            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryList_All_Xpath, "CANADA");

            Click(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_Click_Xpath);
            IList<IWebElement> UIValuesCanada = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_state_Provice_All_Xpath));
            for (int i = 1; i < UIValuesCanada.Count; i++)
            {
                if (UIValuesCanada[i].Text.Length == 2)
                {
                    Report.WriteLine("Max Length is 2 'Expected' ");
                }
                else
                {
                    Report.WriteLine("Not expected");
                    Assert.Fail();
                }
            }
        }

        [Then(@"Validate and Verify the State/Prov \(Optional\) field If Country NOT United States or Canada \(alpha-numeric, text, max length (.*)\)")]
        public void ThenValidateAndVerifyTheStateProvOptionalFieldIfCountryNOTUnitedStatesOrCanadaAlpha_NumericTextMaxLength(int p0)
        {
            //If Country NOT United States or Canada(alpha - numeric, text, max length 50)
            Report.WriteLine("Checking for Other Country apart from United State and Canada");
            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryList_All_Xpath, "INDIA");

            Report.WriteLine("Accept only Alphe Numeric");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, AlphaNumeric_Text_SpecialCharacter);
            string ActualState_AcceptedValue = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, "value");
            Assert.AreEqual(Regex.IsMatch(ActualState_AcceptedValue, @"^[a-zA-Z0-9]+$"), true);

            Report.WriteLine("Accept only max length 50");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, MoreThen_50_AlphaNumeric);
            string ActualValueState = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_State_Province_TextBox_Value_Xpath, "value");
            int ActualCountState_Value = ActualValueState.Length;
            Assert.AreEqual(50, ActualCountState_Value);
        }

        [Then(@"Validate and Verify the Zip/Postal \(Optional\) field If Country is United States \(numeric, min length & max length = (.*), allow leading zero\)")]
        public void ThenValidateAndVerifyTheZipPostalOptionalFieldIfCountryIsUnitedStatesNumericMinLengthMaxLengthAllowLeadingZero(int MaxLengthAllowed)
        {
            string MinLengthLessThen_Five = "1234";
            string MaxLengthMoreThen_Five = "123456789";
            string AlphaNumeric_Special_Character = "Ab12@#$$";
            string LeadingZero = "00001";

            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);
            string Zip_Code_Db = AllShipperInformationfrom_DB.Zip;
            //Zip/Postal code will be autopopulated
            string ActualZipCode_Autopopulated = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(Zip_Code_Db, ActualZipCode_Autopopulated);

            //Zip / Postal(Optional)
            Report.WriteLine("Verify the Zip/Postal field");
            string ActualZip_Postal_Field = Gettext(attributeName_xpath, DetailsTab_Shipper_Zip_Postal_Xpath);
            Assert.AreEqual(Shipper_Zip_Postal, ActualZip_Postal_Field);

            //If Country = United States(numeric, min length & max length = 5, allow leading zero)
            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryList_All_Xpath, "UNITED STATES");

            Report.WriteLine("It will allow only Numeric");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, AlphaNumeric_Special_Character);
            string ActualAllowedValues = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(Regex.IsMatch(ActualAllowedValues, @"^[0-9]+$"), true);

            Report.WriteLine("Min Length is allowed 5 ");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, MinLengthLessThen_Five);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath);
            string ActualBackgroundColorForMinimunValidations = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", ActualBackgroundColorForMinimunValidations);

            Report.WriteLine("Max Length is allowed 5");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, MaxLengthMoreThen_Five);
            string ActualLengthAccepted = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(MaxLengthAllowed, ActualLengthAccepted.Length);

            Report.WriteLine("Its allow leading Zero");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, LeadingZero);
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_City_Xpath);
            string ActualBackgroundColorForLeadingZero = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "background-color");
            string ActualValue_LeadingZero = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual("rgba(255, 255, 255, 1)", ActualBackgroundColorForLeadingZero);
            Assert.AreEqual(LeadingZero, ActualValue_LeadingZero);


        }

        [Then(@"Validate and Verify the Zip/Postal \(Optional\) field If Country is  Canada \(alpha-numeric, min length = (.*), max length = (.*) when a space is used after first (.*) characters\)")]
        public void ThenValidateAndVerifyTheZipPostalOptionalFieldIfCountryIsCanadaAlpha_NumericMinLengthMaxLengthWhenASpaceIsUsedAfterFirstCharacters(int MinLength, int MaxLength, int SpaceUserAfterFirst_Three_Character)
        {
            string MinimunLengthLessthen_Six = "12345";
            string MaxminumLengthMoreThen_Seven = "12345678";
            string SpaceisUsedAftertheFirst_Three = "123 567";
            string AlphaNumeric_SpecialChar = "AL@123!4567";

            //If Country = Canada (alpha-numeric, min length = 6, max length = 7 when a space is used after first 3 characters)
            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryList_All_Xpath, "CANADA");

            Report.WriteLine("It will accept only Alpha Numeric");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, AlphaNumeric_SpecialChar);
            String ActualAcceptedValue = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(Regex.IsMatch(ActualAcceptedValue, @"^[a-zA-Z0-9]+$"), true);


            Report.WriteLine("It's required minimum length is 6");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, MinimunLengthLessthen_Six);
            String ActualBackgroundColorRequiredLengthAs_Six = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", ActualBackgroundColorRequiredLengthAs_Six);

            Report.WriteLine("We can enter max length is 7");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, MaxminumLengthMoreThen_Seven);
            String ActualMaxLenghtValue = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(MaxLength, ActualMaxLenghtValue.Length);

            Report.WriteLine("Value will be accepted if any space given in between");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, SpaceisUsedAftertheFirst_Three);
            String ActualValueIncludingSpace = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            String ActualBackgroundColorForSpace = GetCSSValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "background-color");
            Assert.AreEqual(MaxLength, ActualValueIncludingSpace.Length);
            Assert.AreEqual(SpaceisUsedAftertheFirst_Three, ActualValueIncludingSpace);
            Assert.AreEqual("rgba(255, 255, 255, 1)", ActualBackgroundColorForSpace);

        }

        [Then(@"Validate and Verify the Zip/Postal \(Optional\) field If Country NOT United States or Canada \(alpha-numeric, text, special characters, min length (.*), max length (.*)\)")]
        public void ThenValidateAndVerifyTheZipPostalOptionalFieldIfCountryNOTUnitedStatesOrCanadaAlpha_NumericTextSpecialCharactersMinLengthMaxLength(int MinimumLength, int MaximumLength)
        {
            string AlphaNumeric_SpecialCharacter = "AbCd234!@#$%_15";
            string AlphaNumeric_SpecialChar_Morethan_Fifteen = "AbCd234!@#$%_15_+12345_25";

            //If Country NOT United States or Canada (alpha-numeric, text, special characters, min length 1, max length 15)
            Click(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, DetailsTab_Edit_Shipper_CountryList_All_Xpath, "INDIA");

            Report.WriteLine("It will allow the alpha numeric, text, special character");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, AlphaNumeric_SpecialCharacter);
            string ActualAllowedValue = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(AlphaNumeric_SpecialCharacter, ActualAllowedValue);

            Report.WriteLine("It will allow min 1 and max legth 15");
            SendKeys(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, AlphaNumeric_SpecialChar_Morethan_Fifteen);
            string ActualAllowedValue_Length = GetValue(attributeName_xpath, DetailsTab_Edit_Shipper_Zip_Postal_Xpath, "value");
            Assert.AreEqual(MaximumLength, ActualAllowedValue_Length.Length);


        }

        [Then(@"Validate and Verify the Country field \(optional, drop down list, text\)")]
        public void ThenValidateAndVerifyTheCountryFieldOptionalDropDownListText()
        {
            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);
            string Countryname_Db = AllShipperInformationfrom_DB.Country.CountryName;

            //Country field will be autopopulated
            string ActualCountry_Autopopulated = Gettext(attributeName_xpath, DetaislTab_Edit_Shipper_Country_Click_Xpath);
            Assert.AreEqual(Countryname_Db, ActualCountry_Autopopulated);

            //Country (Optional)
            //Country(drop down list, text, max length 2)
            Report.WriteLine("Verify the Country field");
            string ActualCountry_Text = Gettext(attributeName_xpath, DetailsTab_Shipper_Country_Xpath);
            Assert.AreEqual(Shipper_Country, ActualCountry_Text);

        }


        [Then(@"Validate and Verify the Date Ack to Claimant field \(optional, calendar option, unable to select future date, field editable - format mm/dd/yyyy\)")]
        public void ThenValidateAndVerifyTheDateAckToClaimantFieldOptionalCalendarOptionUnableToSelectFutureDateFieldEditable_FormatMmDdYyyy()
        {
            //DLSW OS&D Actions
            Report.WriteLine("Verify the DLW OS&D Actions sub section");
            string ActualDLSW_OS_D_Actions = Gettext(attributeName_xpath, DetailsTab_Shipper_DLSW_OS_D_Actions_Xpath);
            Assert.AreEqual(Shipper_DLSW_OS_D_Actions, ActualDLSW_OS_D_Actions);

            //Date Ack to Claimant (optional, calendar option, unable to select future date, field editable - format mm/dd/yyyy)
            Report.WriteLine("Date Ack To Claimant Field is having Calender option");
            string ActualDateAckToClaimant_FieldText = Gettext(attributeName_xpath, DetailsTab_Shipper_DateAckToClaimant_Xpath);
            Assert.AreEqual(Shipper_Date_Ack_To_Claimant, ActualDateAckToClaimant_FieldText);

            Report.WriteLine("Verifying the Current Month and Year in Date Picker");
            string DatePresent = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            string[] Day_month_year = DatePresent.Split('/');
            string Month_Selected = Day_month_year[1];
            string Year_Selected = Day_month_year[2];
            string Month_Year_Selected = Month_Selected + "/" + Year_Selected;
            if (DatePresent != null)
            {
                Report.WriteLine("Presented Month/Year is showing showing in DatePicker");
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
                string ActualMonth_YearFrom_DatePicker = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_DateAckToClaimant_Month_Year_Xpath);
                string[] Month_Year = ActualMonth_YearFrom_DatePicker.Split();
                string Month = Month_Year[0];
                string Year = Month_Year[1];
                int MonthinDigit = DateTime.ParseExact(Month, "MMMM", CultureInfo.InvariantCulture).Month;
                string Month_Year_inDatePicker = MonthinDigit.ToString() + "/" + Year;
                Assert.AreEqual(Month_Year_Selected, Month_Year_inDatePicker);
            }
            else
            {
                Report.WriteLine("For first time select Date, Month , Year should show current Month / Year");
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
                string ActualMonth_YearFrom_DatePicker = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_DateAckToClaimant_Month_Year_Xpath);

                string currentMonth = DateTime.Now.Month.ToString();
                string currentYear = DateTime.Now.Year.ToString();
                string ExpectMonth_Year = currentMonth + " " + currentYear;
                Assert.AreEqual(ExpectMonth_Year, ActualMonth_YearFrom_DatePicker);
            }


            Report.WriteLine("I am unable to select the future Date");
            DateTime TodaysDate = DateTime.Now.Date;
            //string Tomorrows_Date = TodaysDate + 1;
            //int TomorrowDate = int.Parse(Tomorrows_Date);
            // string Tomorrow_Month_Date_Year = currentMonth + "/" + Tomorrows_Date + "/" + currentYear;
            string PreviousSelected_Date = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            FutureDisabledDate(attributeName_xpath, DetailsTab_Edit_Shipper_DateAckToClaimant_AllDate_Xpath, 1, TodaysDate);
            string AfterSelected_Date = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            Assert.AreEqual(PreviousSelected_Date, AfterSelected_Date);


            Report.WriteLine("Date field is editable");
            string PreviousDateSelected = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, "07/25/2018");
            string UpdatedDateSelected = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);

            if (PreviousDateSelected != UpdatedDateSelected)
            {
                Assert.AreEqual("07/25/2018", UpdatedDateSelected);
                Report.WriteLine("Date is editable : Expected");
            }
            else
            {
                Report.WriteLine("Date is not updating");
                Assert.Fail();
            }


        }

        [Then(@"Validate and Verify the Date Filed w/ Carrier field \(optional, calendar option, unable to select future date, field editable - format mm/dd/yyyy\)")]
        public void ThenValidateAndVerifyTheDateFiledWCarrierFieldOptionalCalendarOptionUnableToSelectFutureDateFieldEditable_FormatMmDdYyyy()
        {
            // Date Filed w/ Carrier (optional, calendar option, unable to select future date, field editable - format mm/dd/yyyy) 
            Report.WriteLine("Date Filed W/Carrier Field is having Calender option");
            string ActualDateFiledW_Carrier_FieldText = Gettext(attributeName_xpath, DetailsTab_Shipper_DateFiled_W_CarrierXpath);
            Assert.AreEqual(Shipper_Date_Filed_W_Carrier, ActualDateFiledW_Carrier_FieldText);


            Report.WriteLine("Verifying the Current Month and Year in Date Picker");
            string DatePresent = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            string[] Day_month_year = DatePresent.Split('/');
            string Month_Selected = Day_month_year[1];
            string Year_Selected = Day_month_year[2];
            string Month_Year_Selected = Month_Selected + "/" + Year_Selected;
            if (DatePresent != null)
            {
                Report.WriteLine("Presented Month/Year is showing showing in DatePicker");
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
                string ActualMonth_YearFrom_DatePicker = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_DateFiled_w_Carrier_Month_Year_Xpath);
                string[] Month_Year = ActualMonth_YearFrom_DatePicker.Split();
                string Month = Month_Year[0];
                string Year = Month_Year[1];
                int MonthinDigit = DateTime.ParseExact(Month, "MMMM", CultureInfo.InvariantCulture).Month;
                string Month_Year_inDatePicker = MonthinDigit.ToString() + "/" + Year;
                Assert.AreEqual(Month_Year_Selected, Month_Year_inDatePicker);
            }
            else
            {
                Report.WriteLine("For first time select Date, Month , Year should show current Month / Year");
                Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
                string ActualMonth_YearFrom_DatePicker = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_DateFiled_w_Carrier_Month_Year_Xpath);

                string currentMonth = DateTime.Now.Month.ToString();
                string currentYear = DateTime.Now.Year.ToString();
                string ExpectMonth_Year = currentMonth + " " + currentYear;
                Assert.AreEqual(ExpectMonth_Year, ActualMonth_YearFrom_DatePicker);
            }



            Report.WriteLine("I am unable to select the future Date");
            DateTime TodaysDate = DateTime.Now.Date;

            string PreviousSelected_Date = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            FutureDisabledDate(attributeName_xpath, DetailsTab_Edit_Shipper_DateFiled_w_Carrier_AllDate_Xpath, 1, TodaysDate);
            string AfterSelected_Date = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            Assert.AreEqual(PreviousSelected_Date, AfterSelected_Date);

            Report.WriteLine("Date field is editable");
            string PreviousDateSelected = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, Keys.Backspace);
            SendKeys(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id, "07/25/2018");
            string UpdatedDateSelected = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateFiled_W_Carrier_click_Id);

            if (PreviousDateSelected != UpdatedDateSelected)
            {
                Assert.AreEqual("07/25/2018", UpdatedDateSelected);
                Report.WriteLine("Date is editable : Expected");
            }
            else
            {
                Report.WriteLine("Date field is not editing");
                Assert.Fail();
            }


        }

        [Then(@"Validate and Verify the Cycle Time field \(not editable, system calculation\)")]
        public void ThenValidateAndVerifyTheCycleTimeFieldNotEditableSystemCalculation()
        {
            //Cycle Time (not editable; system calculation)
            Report.WriteLine("Cycle time field is disabled");
            string Actual_CycleTime_Text = Gettext(attributeName_xpath, DetailsTab_Shipper_CycleTime_Xpath);
            Assert.AreEqual(Shipper_Cycle_Time, Actual_CycleTime_Text);

            Report.WriteLine("Cycle Time field is Disabled");
            IsElementDisabled(attributeName_id, DetailsTab_Edit_Shipper_CycleTime_Id, "Cycle Time");
        }

        [Then(@"Validate and verify the Program \(optional, drop down list, list configurable\)")]
        public void ThenValidateAndVerifyTheProgramOptionalDropDownListListConfigurable()
        {
            //Insurance Info
            string ActualInsuranceInfoSectionText = Gettext(attributeName_xpath, DetailsTab_Shipper_InsuranceInfo_Xpath);
            Assert.AreEqual(Shipper_Insurance_Info, ActualInsuranceInfoSectionText);

            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);
            //Program field will be autopopulated
            string Program_DB = AllShipperInformationfrom_DB.InsuranceClaim.InsuranceClaimCarriers.Select(x => x.CarrierProNumber).FirstOrDefault();
            if (Program_DB != null)
            {
                string ActualProgram_UI = Gettext(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
                Assert.AreEqual(Program_DB, ActualProgram_UI);
            }
            else
            {
                Report.WriteLine("Program name given different while submitting the Claim");
            }


            // Program (optional, drop down list, list configurable)
            string ActualProgram_DropdownText = Gettext(attributeName_xpath, DetailsTab_Shipper_Program_Xpath);
            Assert.AreEqual(Shipper_Program, ActualProgram_DropdownText);

            List<string> ExpectedAll_Programs = new List<string>(new string[] { "All Risk", "PPP", "RRD" });

            List<string> ActualAll_Programs = new List<string>();

            Report.WriteLine("Verifying the all Insurance Info - Program data in list");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Program_Click_Xpath);
            IList<IWebElement> AllPrograms = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_Program_ListAll_Xpath));
            if (AllPrograms.Count > 1)
            {
                for (int i = 1; i < AllPrograms.Count; i++)
                {
                    string Programs = AllPrograms[i].Text;
                    ActualAll_Programs.Add(Programs);
                }

                Report.WriteLine("All Programs under the list is Expected");
                CollectionAssert.AreEqual(ExpectedAll_Programs, ActualAll_Programs);
            }
            else
            {
                Report.WriteLine("List should have the Programs");
                Assert.Fail();
            }


        }

        [Then(@"Validate and verify the Amount \(currency, allow up to (.*) decimal places and always display (.*) decimal places, auto fill \$ and (.*) decimal places; \$xx,xxx\.xx\)")]
        public void ThenValidateAndVerifyTheAmountCurrencyAllowUpToDecimalPlacesAndAlwaysDisplayDecimalPlacesAutoFillAndDecimalPlacesXxXxx_Xx(int p0, int p1, int p2)
        {
            int Claim_Number = int.Parse(ClaimNumber);
            InsuranceClaimShipperAddress AllShipperInformationfrom_DB = DBHelper.GetShipperInformation_DetailsTabBy_ClaimNumber(Claim_Number);

            if (AllShipperInformationfrom_DB.InsuranceClaim.IsArticlesInsured == true)
            {

                string AmountFrom_UI = GetValue(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, "value");
                string ActualAmountFrom_UI = AmountFrom_UI.Remove('$', ',');

                Assert.AreEqual(AllShipperInformationfrom_DB.InsuranceClaim.InsuredValueAmount, ActualAmountFrom_UI);
            }
            else
            {
                Report.WriteLine("Not Selected as IsArticlesInsured as Yes while submitting the claim");
            }

            //Amount (currency; allow up to 2 decimal places and always display 2 decimal places, auto fill $ and 2 decimal places; $xx,xxx.xx)
            Report.WriteLine("Verified the Amount Field");
            string ActualAmount_Text = Gettext(attributeName_xpath, DetailsTab_Shipper_Amount_Xpath);
            Assert.AreEqual(Shipper_Amount, ActualAmount_Text);

            Report.WriteLine("Amount will contains the $ Curency sign");
            string ActualAmountValue = GetValue(attributeName_id, DetailsTab_Edit_Shipper_Amount_Id, "value");
            string[] ActualValue_withdeciaml = ActualAmountValue.Split('.');
            string Checking_TwoDeciaml_Places = ActualValue_withdeciaml[1].ToString();
            int Checking_TwoDecial_Places_Count = Checking_TwoDeciaml_Places.Count();

            if (ActualAmountValue != null)
            {
                if (ActualAmountValue.Contains("$"))
                {
                    Report.WriteLine("Value is present with the $ Currency symbol");

                    if (Checking_TwoDecial_Places_Count == 2)
                    {
                        Report.WriteLine("Having 2 decimal places");
                    }
                    else
                    {
                        Assert.Fail("Should have 2 decimal places");
                    }


                }
                else
                {
                    Assert.Fail("Should have $ currency format");
                }
            }
            else
            {
                Report.WriteLine("Amount Value not present");
            }

        }


        [Then(@"Validate and verify the Company field \(optional, drop down list, list configurable\)")]
        public void ThenValidateAndVerifyTheCompanyFieldOptionalDropDownListListConfigurable()
        {

            // Company (optional, drop down list, list configurable)
            string ActualCompany_DropdownText = Gettext(attributeName_xpath, DetailsTab_Shipper_Company_Xpath);
            Assert.AreEqual(Shipper_Company, ActualCompany_DropdownText);

            List<string> ExpectedAll_Company = new List<string>(new string[] { "Association Business", "Chubb Insurance", "RR Donnelley", "VeriClaim, Inc." });

            List<string> ActualAll_Company = new List<string>();

            Report.WriteLine("Verifying the all Insurance Info - Program data in list");
            Click(attributeName_xpath, DetailsTab_Edit_Shipper_Company_Click_Xpath);
            IList<IWebElement> AllCompany = GlobalVariables.webDriver.FindElements(By.XPath(DetailsTab_Edit_Shipper_Company_ListAll_Xpath));
            if (AllCompany.Count > 1)
            {
                for (int i = 1; i < AllCompany.Count; i++)
                {
                    string Company = AllCompany[i].Text;
                    ActualAll_Company.Add(Company);
                }

                Report.WriteLine("All Company under the list is Expected");
                CollectionAssert.AreEqual(ExpectedAll_Company, ActualAll_Company);
            }
            else
            {
                Report.WriteLine("List should have the Company");
                Assert.Fail();
            }

        }

        [Then(@"I should see Save Claims button on the Claim Details Page")]
        public void ThenIShouldSeeSaveClaimsButtonOnTheClaimDetailsPage()
        {
            Report.WriteLine("I should see the Save Claim Details button");
            VerifyElementPresent(attributeName_id, DetailsTab_SaveClaimDetails_Button_id, "Save Claim Details");
        }

    }
}
