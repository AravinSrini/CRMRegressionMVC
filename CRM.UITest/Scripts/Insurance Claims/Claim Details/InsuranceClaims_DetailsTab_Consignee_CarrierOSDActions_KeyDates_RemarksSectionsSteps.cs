using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using System.Threading;



namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_DetailsTab_Consignee_CarrierOSDActions_KeyDates_RemarksSectionsSteps : Objects.InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string expectedText = null;
        string actualText = null;
        string ClaimNumber = null;
        string element = null;

        [Given(@"I am a sales, sales management, operations, station owner, or claims specialist user,")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialist"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I clicked on the hyperlink of any displayed claim")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaim()
        {
            Report.WriteLine("I am on the Claims List Page");
            VerifyElementPresent(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);

            int TotalClaimNumber = GetCount(attributeName_xpath, ClaimGrid_DLSW_Total_ClaimNumber_Xpath);
            if (TotalClaimNumber > 0)
            {
                ClaimNumber = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Xpath);
                Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Xpath);
            }
            else
            {
                Report.WriteLine("No claim found in the grid");
            }

        }
        
        [Given(@"I arrive on the Details tab of the Claims Details page")]
        public void GivenIArriveOnTheDetailsTabOfTheClaimsDetailsPage()
        {
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Given(@"I clicked on the hyperlink of any displayed claim as a claim specialist")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimAsAClaimSpecialist()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);


            IList<IWebElement> RowCount = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr"));
            for (int i = 1; i < RowCount.Count; i++)
            {
                IWebElement ColumnElement = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a"));
                string columnValue = ColumnElement.Text;
                if (columnValue.Equals("2018000220"))
                {
                    ColumnElement.Click();
                    break;
                }
            }
        }


        [Given(@"I am on the Details tab of the Claims Details page")]
        public void GivenIAmOnTheDetailsTabOfTheClaimsDetailsPage()
        {
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }
        
        [When(@"I arrive on the Details tab of the Claims Details page")]
        public void WhenIArriveOnTheDetailsTabOfTheClaimsDetailsPage()
        {
            scrollpagedown();
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }
        

        [When(@"I am on the Details tab of the Claims Details page")]
        public void WhenIAmOnTheDetailsTabOfTheClaimsDetailsPage()
        {
            scrollpagedown();
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [When(@"country is selcted as United States or Canada")]
        public void WhenCountryIsSelctedAsUnitedStatesOrCanada()
        {
            string element = "UNITED STATES";
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_CountryValues_Xpath, element);
        }
        
        [When(@"country is not selected as United States or Canada")]
        public void WhenCountryIsNotSelectedAsUnitedStatesOrCanada()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            element = "TURKEY";
            Click(attributeName_xpath, Consignee_Country_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_CountryValues_Xpath, element);
        }
        
        [When(@"Country is selected as United States")]
        public void WhenCountryIsSelectedAsUnitedStates()
        {
            string element = "UNITED STATES";
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_CountryValues_Xpath, element);
        }
        
        [When(@"Country is selected as Canada")]
        public void WhenCountryIsSelectedAsCanada()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            element = "CANADA";
            Click(attributeName_xpath, Consignee_Country_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_CountryValues_Xpath, element);
        }
        
      
        
        [Then(@"I will see all the fields for the Consignee, Carrier OS&D Actions, Key Dates, and Remarks sub-sections")]
        public void ThenIWillSeeAllTheFieldsForTheConsigneeCarrierOSDActionsKeyDatesAndRemarksSub_Sections()
        {
            Report.WriteLine("fields under Consignee section");
            IsElementVisible(attributeName_id, Consignee_Name_Id, "Name");
            IsElementVisible(attributeName_id, Consignee_Address_Id, "Address");
            IsElementVisible(attributeName_id, Consignee_City_Id, "City");
            IsElementVisible(attributeName_id, Consignee_State_Id, "State/Province");
            IsElementVisible(attributeName_id, Consignee_Zip_Id, "Zip/Postal");
            IsElementVisible(attributeName_xpath, Consignee_Country_Xpath, "Country");
            Report.WriteLine("field under Carrier OS&D Actions section");
            IsElementVisible(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath, "Carrier ACK");
            IsElementVisible(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, "CarrierAckDate");
            IsElementVisible(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, "CarrierClaim#");
            Report.WriteLine("fields under Key Dates");
            IsElementVisible(attributeName_id, KeyDates_CarrierProDate_Id, "LblConsigneeCarrierProDate");
            IsElementVisible(attributeName_id, KeyDates_BOLDate_Id, "LblConsigneeBOLShipDate");
            IsElementVisible(attributeName_id, KeyDates_DeliveryDate_Id, "DeliveryDate");
            IsElementVisible(attributeName_id, Remarks_Id, "Remark");
        }
        
      
        
        [Then(@"The name field will not allow more than (.*) character")]
        public void ThenTheNameFieldWillNotAllowMoreThanCharacter(int p0)
        {
            scrollpagedown();
            scrollpagedown();
            SendKeys(attributeName_id, Consignee_Name_Id, "duedeuue ueu ehuiueuieue ueuei test test test tee test123u test 123 sdeyyuen test");
            IWebElement name = GlobalVariables.webDriver.FindElement(By.Id("ConsigneeZip"));
             actualText = GetAttribute(attributeName_id, Consignee_Name_Id,"value");
           
            expectedText = "duedeuue ueu ehuiueuieue ueuei test test test tee test123u test 123 sdeyyue";
            Assert.AreEqual(actualText, expectedText);
        }
        
        [Then(@"The address field will not allow more than (.*) character")]
        public void ThenTheAddressFieldWillNotAllowMoreThanCharacter(int p0)
        {
            string ConsigneeAddress = "duedeuue ueu ehuiueuieue ueuei test test test test test test123 huuwueywyyyy wrqterwqe 134324 AWWEWWEWEEW #$#$ ERWfwstyrswty12323hhhdhd #$#@@ e762@@#@32$%%$%%";
            SendKeys(attributeName_id, Consignee_Address_Id, ConsigneeAddress);
            actualText = GetAttribute(attributeName_id, Consignee_Address_Id, "value");
            expectedText = "duedeuue ueu ehuiueuieue ueuei test test test test test test123 huuwueywyyyy wrqterwqe 134324 AWWEWWEWEEW #$#$ ERWfwstyrswty12323hhhdhd #$#@@ e762@@#@";
            Assert.AreEqual(actualText, expectedText); 
        }
        
        [Then(@"the city field will not allow more than (.*) character")]
        public void ThenTheCityFieldWillNotAllowMoreThanCharacter(int p0)
        {
            string ConsigneeCity = "duedeuue ueu ehuiueuieue ueuei test test test test test test123";
            SendKeys(attributeName_id, Consignee_City_Id, ConsigneeCity);
            actualText = GetAttribute(attributeName_id, Consignee_City_Id, "value");
            expectedText = "duedeuue ueu ehuiueuieue ueuei test test test test";
            Assert.AreEqual(actualText, expectedText); 
        }

        [Then(@"It will allow to enter alpha numeric value to Name, address and city fields")]
        public void ThenItWillAllowToEnterAlphaNumericValueToNameAddressAndCityFields()
        {
            SendKeys(attributeName_id, Consignee_Name_Id, "ahjdiueuhed test787@#$8 test1222");
            SendKeys(attributeName_id, Consignee_Address_Id, "dguge3434 34324test@#$");
            SendKeys(attributeName_id, Consignee_City_Id, "guwu 46776ette@#$%");
        }


        [Then(@"I will be able to edit the fields from the Consignee, Carrier OS&D Actions, Key Dates, and Remarks sub-sections")]
        public void ThenIWillBeAbleToEditTheFieldsFromTheConsigneeCarrierOSDActionsKeyDatesAndRemarksSub_Sections()
        {
            element = "UNITED STATES";
            SendKeys(attributeName_id, Consignee_Name_Id, "test test@#");
            SendKeys(attributeName_id, Consignee_Address_Id, "xyz test address");
            SendKeys(attributeName_id, Consignee_City_Id, "test city");
            Click(attributeName_xpath, Consignee_Country_Xpath);
            Click(attributeName_xpath, Consignee_Country_Xpath);
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_CountryValues_Xpath, element);

        }        
        
        [Then(@"State or Province field will be a dropdown")]
        public void ThenStateOrProvinceFieldWillBeADropdown()
        {
            string element = "AR";
            Click(attributeName_xpath, Consignee_StateDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_StateValue_Xpath, element);
        }
        
        [Then(@"State or province field will allow to enter alpha numeric value")]
        public void ThenStateOrProvinceFieldWillAllowToEnterAlphaNumericValue()
        {
            SendKeys(attributeName_id, Consignee_State_Id, "test 1234 test33");
        }
        
        [Then(@"It will not allow more than (.*) character")]
        public void ThenItWillNotAllowMoreThanCharacter(int p0)
        {
            SendKeys(attributeName_id, Consignee_State_Id, "duedeuue ueu ehuiueuieue ueuei test test test test test test123");
            actualText = GetAttribute(attributeName_id, Consignee_State_Id,"value");
            expectedText = "duedeuue ueu ehuiueuieue ueuei test test test test";
            Assert.AreEqual(actualText, expectedText);
        }
        
        [Then(@"Zip or postal field will allow to enter numeric value")]
        public void ThenZipOrPostalFieldWillAllowToEnterNumericValue()
        {
            SendKeys(attributeName_id, Consignee_Zip_Id, "7878999");
        }

        [Then(@"It will enter (.*) character")]
        public void ThenItWillEnterCharacter(int p0)
        {
            SendKeys(attributeName_id, Consignee_Zip_Id, "1234567#$12rfdsaa");
            expectedText = "1234567#$12rfds";
            actualText = GetAttribute(attributeName_id, Consignee_Zip_Id, "value");
            Assert.AreEqual(expectedText, actualText);
        }


        [Then(@"It will allow (.*) character to enter")]
        public void ThenItWillAllowCharacterToEnter(int p0)
        {
            SendKeys(attributeName_id, Consignee_Zip_Id, "1234567");
            expectedText = "12345";
            actualText = GetAttribute(attributeName_id, Consignee_Zip_Id, "value");
            Assert.AreEqual(expectedText, actualText);
        }
        
        [Then(@"It will allow leading zero")]
        public void ThenItWillAllowLeadingZero()
        {
            SendKeys(attributeName_id, Consignee_Zip_Id, "09890");
        }
        
        [Then(@"Zip or postal field will allow to enter alpha numeric value")]
        public void ThenZipOrPostalFieldWillAllowToEnterAlphaNumericValue()
        {
            SendKeys(attributeName_id, Consignee_Zip_Id, "AG123");
        }
        
        [Then(@"It will allow minimum (.*) and Maximum (.*) character to enter")]
        public void ThenItWillAllowMinimumAndMaximumCharacterToEnter(int p0, int p1)
        {
            Report.WriteLine("entering less than 6 character");
            SendKeys(attributeName_id, Consignee_Zip_Id, "12345");

            var colorofHighlighted_account = GetCSSValue(attributeName_id, Consignee_Zip_Id, "background-color");
            Assert.AreEqual("rgba(251, 236, 237, 1)", colorofHighlighted_account);

            Report.WriteLine("entering more than 7 character");
            SendKeys(attributeName_id, Consignee_Zip_Id, "1234567899");
            expectedText = "1234567";
            actualText = GetAttribute(attributeName_id, Consignee_Zip_Id,"value");
            Assert.AreEqual(expectedText, actualText);
        }


        [Then(@"It will allow to enter special character")]
        public void ThenItWillAllowToEnterSpecialCharacter()
        {
            SendKeys(attributeName_id, Consignee_Zip_Id, "123$#");
        }

        [Then(@"It will contain two value in the dropdown, Y or N")]
        public void ThenItWillContainTwoValueInTheDropdownYOrN()
        {
            Report.WriteLine("Carrier ACK dropdown values");
            scrollpagedown();
            scrollpagedown();
            //string expectedFirstDropdownValue = "Y";
            //Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
            //string actualFirstDropdownValue = GetValue(attributeName_xpath, CarrierOSDActions_CarrierAck_FirstValue_Xpath, "value");
            //Assert.AreEqual(expectedFirstDropdownValue, actualFirstDropdownValue);

            //string expectedSecondDropdownValue = "N";
            //string actuaSecondDropdownValue = GetAttribute(attributeName_xpath, CarrierOSDActions_CarrierAck_SecondValue_Xpath, "value");
            //Assert.AreEqual(expectedSecondDropdownValue, actuaSecondDropdownValue);

            VerifySelectContainsOptions(attributeName_xpath, CarrierOSDActions_CarrierAck_Id, "Y", "CarrierAck");
        }
        
        [Then(@"It's default display will be blank")]
        public void ThenItSDefaultDisplayWillBeBlank()
        {
            expectedText = "Select an Option";
            actualText = GetAttribute(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath, "value");
            Assert.AreEqual(expectedText, actualText);
        }
        
        [Then(@"Carrier Ack Date will be optional field")]
        public void ThenCarrierAckDateWillBeOptionalField()
        {
            SendKeys(attributeName_id, CarrierOSDActions_CarrierAckDate_Id, "");
        }
        
        [Then(@"It will not allow to select future date")]
        public void ThenItWillNotAllowToSelectFutureDate()
        {
            Report.WriteLine("Verifying future date");
            scrollpagedown();
            scrollpagedown();
            
            Click(attributeName_id, KeyDates_CarrierProDate_Id);
            IsElementDisabled(attributeName_xpath, "//td[@class='day today new']//following::td", "datepicker");
            string actualClass = GetAttribute(attributeName_xpath, "//td[@class='day today new']//following::td", "class");
            string expectedClass = "day disabled new";
            Assert.AreEqual(actualClass, expectedClass);
        }
        
        [Then(@"Calender selection will follow the mm/dd/yyyy format")]
        public void ThenCalenderSelectionWillFollowTheMmDdYyyyFormat()
        {
            
            string CarrierAckDate = GetAttribute(attributeName_id, KeyDates_CarrierProDate_Id, "value");
            bool isValid = false;
            try
            {
                DateTime date = DateTime.ParseExact(CarrierAckDate, "d", null);
                isValid = true;
            } catch(FormatException fe){}

            Assert.IsTrue(isValid);
            
        }

        [Then(@"Carrier Claim number field will be optional")]
        public void ThenCarrierClaimNumberFieldWillBeOptional()
        {
            SendKeys(attributeName_xpath, CarrierOSDActions_CarrierClaimNumber_Id, "");
        }

     


        [Then(@"It will allow alpha-numeric values")]
        public void ThenItWillAllowAlpha_NumericValues()
        {
            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, "abc1234x");
        }
        
        [Then(@"It will allow special characters")]
        public void ThenItWillAllowSpecialCharacters()
        {
            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, "abc@123#$");
        }
        
        [Then(@"It will allow Max (.*) character it to enter")]
        public void ThenItWillAllowMaxCharacterItToEnter(int p0)
        {
            SendKeys(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id, "duedeuue ueu ehuiueuieue ueuei test test test test test test123");
            actualText = Gettext(attributeName_id, CarrierOSDActions_CarrierClaimNumber_Id);
            expectedText = "duedeuue ueu ehuiueuieue ueuei test test test tee";
            Assert.AreEqual(actualText, expectedText); 
        }
        
       

        [Then(@"Consignee data will bind in Consignee section")]
        public void ThenConsigneeDataWillBindInConsigneeSection()
        {
            Report.WriteLine("getting data from UI");
            string name = Gettext(attributeName_id, Consignee_Name_Id);
            string address = Gettext(attributeName_id, Consignee_Address_Id);
            string zip = Gettext(attributeName_id, Consignee_Zip_Id);
            string country = Gettext(attributeName_xpath, Consignee_Country_Xpath);
            string state = Gettext(attributeName_id, Consignee_State_Id);
            string city = Gettext(attributeName_id, Consignee_City_Id);
            int ClaimNumber = 2018000187;

            //Verifying data from DB
            InsuranceClaimConsigneeAddress ConsigneeAddress = DBHelper.GetConsigneeAddress(ClaimNumber);
            if (ConsigneeAddress.Equals(null))
            {
                Assert.IsTrue(false);
            } else {
                ConsigneeAddress.Name.Equals(name);
                ConsigneeAddress.Zip.Equals(zip);
                ConsigneeAddress.Country.Equals(country);
                ConsigneeAddress.StateName.Equals(state);
                ConsigneeAddress.CityName.Equals(city);
                
            }
        }

    }
}
