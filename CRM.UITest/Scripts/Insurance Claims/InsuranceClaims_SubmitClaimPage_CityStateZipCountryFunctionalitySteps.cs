using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using CRM.UITest.Entities;
using System.Collections.Generic;


namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_SubmitClaimPage_CityStateZipCountryFunctionalitySteps : InsuranceClaim
    {
        [When(@"I am on the Submit a Claim page")]
        public void WhenIAmOnTheSubmitAClaimPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
        }
        
        
        
        [Then(@"the country default selection will be United States from Shipper Information section")]
        public void ThenTheCountryDefaultSelectionWillBeUnitedStatesFromShipperInformationSection()
        {
            scrollpagedown();
            scrollpagedown();
            
            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(Shipper_CountryDefaultSelection_Xpath));
            Assert.IsNotNull(country);
        }

        [When(@"the country default selection will be United States in Shipper Information section")]
        public void WhenTheCountryDefaultSelectionWillBeUnitedStatesInShipperInformationSection()
        {
            scrollpagedown();

            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(Shipper_CountryDefaultSelection_Xpath));
            Assert.IsNotNull(country);
        }

        [Then(@"I have the option to select another country from a drop down list in Shipper Information section")]
        public void ThenIHaveTheOptionToSelectAnotherCountryFromADropDownListInShipperInformationSection()
        {
            string Country = "Tunisia";
            scrollpagedown();
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdown_Xpath, Country);
            
        }

        [Then(@"the country default selection will be United States in Claim Payable To section")]
        public void ThenTheCountryDefaultSelectionWillBeUnitedStatesInClaimPayableToSection()
        {
            scrollpagedown();
            string expectedCountry = "United States";
            string actualCountry = Gettext(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Assert.AreEqual(expectedCountry, actualCountry);
        }

        [When(@"the country default selection is United States in Claim Payable To section")]
        public void WhenTheCountryDefaultSelectionIsUnitedStatesInClaimPayableToSection()
        {
            string expectedCountry = "United States";
            string actualCountry = Gettext(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Assert.AreEqual(expectedCountry, actualCountry);
        }

        [Then(@"I have the option to select another country from a drop down list in Claim Payable To section")]
        public void ThenIHaveTheOptionToSelectAnotherCountryFromADropDownListInClaimPayableToSection()
        {
            string country = "Canada";
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, ClaimPayableTo_Country_dropdown_Id);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath, country);
        }

        [When(@"my country selection is United States in Shipper Information section")]
        public void WhenMyCountrySelectionIsUnitedStatesInShipperInformationSection()
        {
            scrollpagedown();
            scrollpagedown();

            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(Shipper_CountryDefaultSelection_Xpath));
            Assert.IsNotNull(country);
        }

        [Then(@"I will have a drop down list of States to select the State/Province field from Shipper Information section")]
        public void ThenIWillHaveADropDownListOfStatesToSelectTheStateProvinceFieldFromShipperInformationSection()
        {
            
            string element = "AL";
            Click(attributeName_xpath, Shiper_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Shiper_State_Province_dropdown_Xpath, element);
        }

        [When(@"my country selection is United States in Consignee Information section")]
        public void WhenMyCountrySelectionIsUnitedStatesInConsigneeInformationSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();

            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(Consignee_Country_dropdown_Xpath));
            Assert.IsNotNull(country);
            
        }

        [Then(@"I will have a drop down list of States to select the State/Province field from Consignee Information section")]
        public void ThenIWillHaveADropDownListOfStatesToSelectTheStateProvinceFieldFromConsigneeInformationSection()
        {
            string element = "AL";
            Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, element);
        }

        [Given(@"my country selection is United States in Shipper Information section")]
        public void GivenMyCountrySelectionIsUnitedStatesInShipperInformationSection()
        {
            scrollpagedown();
            scrollpagedown();
            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(Shipper_Country_dropdown_Xpath));
            Assert.IsNotNull(country);
           
        }

        [When(@"I enter a valid US zip code in Shipper Information section")]
        public void WhenIEnterAValidUSZipCodeInShipperInformationSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90001");
        }

        [Then(@"the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Shipper Information section")]
        public void ThenTheCityAndStateFieldsWillAuto_FillWithTheCorrespondingCityAndStateAssociatedToTheZipCodeInShipperInformationSection()
        {
            IWebElement cityElement = GlobalVariables.webDriver.FindElement(By.Id(Shipper_City_Textbox_Id));
            string expectedCity = "Los Angeles";
            string actualCity = cityElement.GetAttribute("value");
            Assert.AreEqual(expectedCity, actualCity);
            string expectedState = "CA";
            string actualState = Gettext(attributeName_xpath, Shipper_State_Province_dropdown_Xpath);
            Assert.AreEqual(expectedState, actualState);
        }

        [Then(@"I have the ability to select a state from the drop down list from Shipper Information section")]
        public void ThenIHaveTheAbilityToSelectAStateFromTheDropDownListFromShipperInformationSection()
        {
            string selectState = "CT";
            Click(attributeName_xpath, Shiper_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Shiper_State_Province_dropdown_Xpath, selectState);
        }

        [Then(@"I have the ability to edit the city from Shipper Information section")]
        public void ThenIHaveTheAbilityToEditTheCityFromShipperInformationSection()
        {
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, "test city");
        }

        [Given(@"my country selection is United States in Consignee Information section")]
        public void GivenMyCountrySelectionIsUnitedStatesInConsigneeInformationSection()
        {
            scrollpagedown();
            string selectCountry = "United States";
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdown_Xpath, selectCountry);
        }

        [When(@"I enter a valid US zip code in Consignee Information section")]
        public void WhenIEnterAValidUSZipCodeInConsigneeInformationSection()
        {
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90001");
        }

        [Then(@"the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Consignee Information section")]
        public void ThenTheCityAndStateFieldsWillAuto_FillWithTheCorrespondingCityAndStateAssociatedToTheZipCodeInConsigneeInformationSection()
        {
            IWebElement cityElement = GlobalVariables.webDriver.FindElement(By.Id(Consignee_City_Textbox_Id));
            string expectedCity = "Los Angeles";
            string actualCity = cityElement.GetAttribute("value");
            Assert.AreEqual(expectedCity, actualCity);
            string expectedState = "CA";
            string actualState = Gettext(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            Assert.AreEqual(expectedState, actualState);
        }

        [Then(@"I have the ability to edit the city from Consignee Information section")]
        public void ThenIHaveTheAbilityToEditTheCityFromConsigneeInformationSection()
        {
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, "country1");
        }

        [When(@"the city and state fields will auto-fill with the corresponding city and state in Consignee Information section")]
        public void WhenTheCityAndStateFieldsWillAuto_FillWithTheCorrespondingCityAndStateInConsigneeInformationSection()
        {
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90001");
        }

        [Then(@"I have the ability to select a state from the drop down list in Consignee Information section")]
        public void ThenIHaveTheAbilityToSelectAStateFromTheDropDownListInConsigneeInformationSection()
        {
            string selectState = "AZ";
            Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, selectState);
        }

        [When(@"the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Consignee Information section")]
        public void WhenTheCityAndStateFieldsAreAuto_FilledWithTheCorrespondingCityAndStateAssociatedToTheZipCodeInConsigneeInformationSection()
        {
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90001");
        }


        [Then(@"I have the ability to select a state from the drop down list from Consignee Information section")]
        public void ThenIHaveTheAbilityToSelectAStateFromTheDropDownListFromConsigneeInformationSection()
        {
            string state = "AZ";
            Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_State_Province_dropdown_Xpath, state);
        }

        [Given(@"my country selection is United States in Claim Payable To section")]
        public void GivenMyCountrySelectionIsUnitedStatesInClaimPayableToSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(ClaimPayableTo_Country_dropdown_Xpath));
            Assert.IsNotNull(country);
        }

        [When(@"I enter a valid US zip code in Claim Payable To section")]
        public void WhenIEnterAValidUSZipCodeInClaimPayableToSection()
        {
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "90001");
        }

        [Then(@"the city and state fields will auto-fill with the corresponding city and state associated to the zip code in Claim Payable To section")]
        public void ThenTheCityAndStateFieldsWillAuto_FillWithTheCorrespondingCityAndStateAssociatedToTheZipCodeInClaimPayableToSection()
        {
            string expectedCity = "Los Angeles";
            IWebElement City = GlobalVariables.webDriver.FindElement(By.Id(ClaimPayableTo_City_Id));
            string actualCity = City.GetAttribute("value");
            Assert.AreEqual(expectedCity, actualCity);

            IWebElement State = GlobalVariables.webDriver.FindElement(By.XPath(ClaimPayableTo_provinceSelected_value_Xpath));
            string actualState = State.Text;
            string expectedState = "CA";
            Assert.AreEqual(expectedState, actualState);
        }

        [When(@"the city and state fields are auto-filled with the corresponding city and state associated to the zip code in Claim Payable To section")]
        public void WhenTheCityAndStateFieldsAreAuto_FilledWithTheCorrespondingCityAndStateAssociatedToTheZipCodeInClaimPayableToSection()
        {
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "90001");
        }

        [Then(@"I have the ability to edit the city from Claim Payable To section")]
        public void ThenIHaveTheAbilityToEditTheCityFromClaimPayableToSection()
        {
            SendKeys(attributeName_id, ClaimPayableTo_City_Id, "test city");
        }

        [Then(@"I have the ability to select a state from the drop down list in Claim Payable To section")]
        public void ThenIHaveTheAbilityToSelectAStateFromTheDropDownListInClaimPayableToSection()
        {
            string state = "CT";
            Click(attributeName_xpath, ClaimPayableTo_State_Province_dropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_State_Province_dropdown_xpath, state);
        }


        [When(@"I enter an invalid US zip code in shipper Information section")]
        public void WhenIEnterAnInvalidUSZipCodeInShipperInformationSection()
        {
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "99999");
        }

        [Then(@"Zip/Postal field of the Shipper Information section will be highlighted in red")]
        public void ThenZipPostalFieldOfTheShipperInformationSectionWillBeHighlightedInRed()
        {
            Report.WriteLine("Highlighting of zip field after entering invalid zip code");
            string actualZipFieldColor = GetCSSValue(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "background-color");
            string expectedZipFieldColor = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualZipFieldColor, expectedZipFieldColor);

        }

        [When(@"I enter an invalid US zip code in Consignee Information section")]
        public void WhenIEnterAnInvalidUSZipCodeInConsigneeInformationSection()
        {
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "34567");
        }

        [Then(@"the Zip/Postal field of the Consignee Information section will be highlighted in red")]
        public void ThenTheZipPostalFieldOfTheConsigneeInformationSectionWillBeHighlightedInRed()
        {
            Report.WriteLine("Highlighting of zip field after entering invalid zip code");
            string actualZipFieldColor = GetCSSValue(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "background-color");
            string expectedZipFieldColor = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualZipFieldColor, expectedZipFieldColor);
        }

        [Given(@"my country selection is United States in Claims Payable To section")]
        public void GivenMyCountrySelectionIsUnitedStatesInClaimsPayableToSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            IWebElement country = GlobalVariables.webDriver.FindElement(By.XPath(ClaimPayableTo_Country_dropdown_Xpath));
            Assert.IsNotNull(country);     
        }

        [When(@"I enter an invalid US zip code in Claims Payable To section")]
        public void WhenIEnterAnInvalidUSZipCodeInClaimsPayableToSection()
        {
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "99999");
        }

        [Then(@"the Zip/Postal field of the Claim Payable To section will be highlighted in red")]
        public void ThenTheZipPostalFieldOfTheClaimPayableToSectionWillBeHighlightedInRed()
        {
            Report.WriteLine("Highlighting of zip field after entering invalid zip code");
            string actualZipFieldColor = GetCSSValue(attributeName_id, ClaimPayableTo_ZipCode_Id, "background-color");
            string expectedZipFieldColor = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualZipFieldColor, expectedZipFieldColor);
            
        }

        [When(@"my country selection is Canada in Shipper information section")]
        public void WhenMyCountrySelectionIsCanadaInShipperInformationSection()
        {
            scrollpagedown();
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdown_Xpath, "Canada");
        }

        [Then(@"State/Province drop down list will be populated with a list of Canada provinces in Shipper information section")]
        public void ThenStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShipperInformationSection()
        {
           IList<IWebElement> actualDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Shipper_provinceDropdown_values_Xpath ));
            List<string> expectedDropdownList = new List<string> { "AB", "BC", "MB", "NB", "NL", "NS", "NT", "NU", "ON", "PE", "QC", "SK", "YT" };
            bool isSame = true;
            foreach (IWebElement e in actualDropDownList)
            {
                string value = e.Text;
                if (!expectedDropdownList.Contains(value))
                {
                    isSame = false;
                    break;
                }
                Assert.IsTrue(isSame);
            }
        }

        [When(@"my country selection is Canada in Consignee Information section")]
        public void WhenMyCountrySelectionIsCanadaInConsigneeInformationSection()
        {
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdown_Xpath, "Canada");
        }

        [Then(@"State/Province drop down list will be populated with a list of Canada provinces in Consignee Information section")]
        public void ThenStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInConsigneeInformationSection()
        {
            IList<IWebElement> actualDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(Consignee_provinceDropdown_values_Xpath));
            List<string> expectedDropdownList = new List<string> { "AB", "BC", "MB", "NB", "NL", "NS", "NT", "NU", "ON", "PE", "QC", "SK", "YT" };
            bool isSame = true;
            foreach (IWebElement e in actualDropDownList)
            {
                string value = e.Text;
                if (!expectedDropdownList.Contains(value))
                {
                    isSame = false;
                    break;
                }
                Assert.IsTrue(isSame);
            }
        }

        [When(@"my country selection is Canada in Claim Payable To section")]
        public void WhenMyCountrySelectionIsCanadaInClaimPayableToSection()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath, "Canada");

           
        }

        [Then(@"the State/Province drop down list will be populated with a list of Canada provinces in Claim Payable To section")]
        public void ThenTheStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInClaimPayableToSection()
        {
            IList<IWebElement> actualDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ClaimPayableTo_provinceDropdown_values_Xpath));
            List<string> expectedDropdownList = new List<string>{"AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"};
            bool isSame = true;
            foreach ( IWebElement e in actualDropDownList)
            {
                string value = e.Text;
                if (!expectedDropdownList.Contains(value))
                {
                    isSame = false;
                    break;
                }
                Assert.IsTrue(isSame);
            }
          
        }
    }
}
