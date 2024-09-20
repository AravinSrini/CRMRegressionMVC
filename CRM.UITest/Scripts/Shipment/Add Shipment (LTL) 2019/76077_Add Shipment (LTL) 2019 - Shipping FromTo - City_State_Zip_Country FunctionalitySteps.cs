using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class _76077_Add_Shipment__LTL__2019___Shipping_FromTo___City_State_Zip_Country_FunctionalitySteps : AddShipments
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string userName;
        string password;
        [Then(@"the Country field should be defaulted to United States in the Shipping From Section")]
        public void ThenTheCountryFieldShouldBeDefaultedToUnitedStatesInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            Thread.Sleep(3000);
            string defaultCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(defaultCountry,"United States");
        }

        [Then(@"I have option to select Canada from the drop down list in the Shipping From Section")]
        public void ThenIHaveOptionToSelectCanadaFromTheDropDownListInTheShippingFromSection()
        {
            WaitForElementVisible(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath,"Country Field");
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_CountryDropDownValues_2019_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Canada")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            string selectedCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(selectedCountry, "Canada");
        }

        [Then(@"the Country field should be defaulted to United States in the Shipping To Section")]
        public void ThenTheCountryFieldShouldBeDefaultedToUnitedStatesInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Thread.Sleep(3000);
            string defaultCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(defaultCountry, "United States");
            
        }

        [Then(@"I have option to select Canada from the drop down list in the Shipping To Section")]
        public void ThenIHaveOptionToSelectCanadaFromTheDropDownListInTheShippingToSection()
        {
            WaitForElementVisible(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath, "Country Field");
            Click(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_CountryDropDownValues_2019_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Canada")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            string selectedCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(selectedCountry, "Canada");
        }

        [When(@"Country field selected is United States in the Shipping From Section")]
        public void WhenCountryFieldSelectedIsUnitedStatesInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            Thread.Sleep(3000);
            string defaultCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(defaultCountry, "United States");
         }

        [Then(@"I should have a drop down list of states to select in the Select state/province field in the Shipping From Section")]
        public void ThenIShouldHaveADropDownListOfStatesToSelectInTheSelectStateProvinceFieldInTheShippingFromSection()
        {
            List<String> statesListExpected = new List<string>();
            string statesValues = "AL,AK,AZ,AR,CA,CO,CT,DC,DE,FL,GA,HI,ID,IL,IN,IA,KS,KY,LA,ME,MD,MA,MI,MN,MS,MO,MT,NE,NV,NH,NJ,NM,NY,NC,ND,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VT,VA,WA,WV,WI,WY";
            string[] values = statesValues.Split(',');
            foreach (var v in values)
            {
                statesListExpected.Add(v);
            }

            WaitForElementVisible(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath, "State Field");
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            IList<IWebElement> statesListActualUI = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_StateDropdwon_SelectedValue_NewScreen_xpath));

            List<string> statesListActual = new List<string>();
            for (int i = 2; i <= statesListActualUI.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='ShippingFrom_State_chosen']/div/ul/li[" + i + "]");
                statesListActual.Add(k);
            }
            statesListExpected.Sort();
            statesListActual.Sort();

            CollectionAssert.AreEqual(statesListExpected, statesListActual);
     
        }

        [When(@"Country field selected is United States in the Shipping To Section")]
        public void WhenCountryFieldSelectedIsUnitedStatesInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Thread.Sleep(3000);
            string defaultCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(defaultCountry, "United States");
        }

        [Then(@"I should have a drop down list of states to select in the Select state/province field in the Shipping To Section")]
        public void ThenIShouldHaveADropDownListOfStatesToSelectInTheSelectStateProvinceFieldInTheShippingToSection()
        {
            List<String> statesListExpected = new List<string>();
            string statesValues = "AL,AK,AZ,AR,CA,CO,CT,DC,DE,FL,GA,HI,ID,IL,IN,IA,KS,KY,LA,ME,MD,MA,MI,MN,MS,MO,MT,NE,NV,NH,NJ,NM,NY,NC,ND,OH,OK,OR,PA,RI,SC,SD,TN,TX,UT,VT,VA,WA,WV,WI,WY";
            string[] values = statesValues.Split(',');
            foreach (var v in values)
            {
                statesListExpected.Add(v);
            }

            WaitForElementVisible(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath,"State field");
            Click(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            IList<IWebElement> statesListActualUI = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath));

            List<string> statesListActual = new List<string>();
            for (int i = 2; i <= statesListActualUI.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='ShippingTo_State_chosen']/div/ul/li[" + i + "]");
                statesListActual.Add(k);
            }
            statesListExpected.Sort();
            statesListActual.Sort();

            CollectionAssert.AreEqual(statesListExpected, statesListActual);
        }

        [When(@"Country field selected is Canada in the Shipping From Section")]
        public void WhenCountryFieldSelectedIsCanadaInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            Thread.Sleep(3000);
            WaitForElementVisible(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath, "Country Field");
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_CountryDropDownValues_2019_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Canada")
                {
                    DropDownList[i].Click(); 
                    break;
                }
            }
            
        }

        [Then(@"I should have a drop down list of provinces to select in the Select state/province field in the Shipping From Section")]
        public void ThenIShouldHaveADropDownListOfProvincesToSelectInTheSelectStateProvinceFieldInTheShippingFromSection()
        {
            Thread.Sleep(3000);
            List<String> provinceListExpected = new List<string>();
            string provinceValues = "AB,BC,MB,NB,NL,NT,NS,NU,ON,PE,QC,SK,YT";
            string[] values = provinceValues.Split(',');
            foreach (var v in values)
            {
                provinceListExpected.Add(v);
            }
            
            WaitForElementVisible(attributeName_xpath, ".//*[@id='ShippingFrom_State_chosen']/a", "State Field");
            Click(attributeName_xpath, ".//*[@id='ShippingFrom_State_chosen']/a");
            IList <IWebElement> provinceListActualUI = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_StateDropdwon_SelectedValue_NewScreen_xpath));

            List<string> provinceListActual = new List<string>();
            for (int i = 2; i <= provinceListActualUI.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='ShippingFrom_State_chosen']/div/ul/li[" + i + "]");
                provinceListActual.Add(k);
            }

            provinceListExpected.Sort();
            provinceListActual.Sort();
            CollectionAssert.AreEqual(provinceListExpected, provinceListActual);

        }

        [When(@"Country field selected is Canada in the Shipping To Section")]
        public void WhenCountryFieldSelectedIsCanadaInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Thread.Sleep(3000);
            WaitForElementVisible(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath, "Country Field");
            Click(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);            
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_CountryDropDownValues_2019_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Canada")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Then(@"I should have a drop down list of provinces to select in the Select state/province field in the Shipping To Section")]
        public void ThenIShouldHaveADropDownListOfProvincesToSelectInTheSelectStateProvinceFieldInTheShippingToSection()
        {
            Thread.Sleep(3000);
            List<String> provinceListExpected = new List<string>();
            string provinceValues = "AB,BC,MB,NB,NL,NS,NT,NU,ON,PE,QC,SK,YT";
            string[] values = provinceValues.Split(',');
            foreach (var v in values)
            {
                provinceListExpected.Add(v);
            }

            Click(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            IList<IWebElement> provinceListActualUI = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath));

            List<string> provinceListActual = new List<string>();
            for (int i = 2; i <= provinceListActualUI.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='ShippingTo_State_chosen']/div/ul/li[" + i + "]");
                provinceListActual.Add(k);
            }

            provinceListExpected.Sort();
            provinceListActual.Sort();

            CollectionAssert.AreEqual(provinceListExpected, provinceListActual);
        }

        [Then(@"I should be able to enter only numeric values in the Shipping From Section")]
        public void ThenIShouldBeAbleToEnterOnlyNumericValuesInTheShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "33126");
            Thread.Sleep(3000);
        }

        [Then(@"I should be able to enter a numeric value with leading zero\(s\) in the Shipping From Section")]
        public void ThenIShouldBeAbleToEnterANumericValueWithLeadingZeroSInTheShippingFromSection()
        {
            Clear(attributeName_id, ShippingFrom_zipcode_NewScreen_Id);
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "01301");//Greenfield
            Thread.Sleep(3000);
            string actualzip = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "value");
            Assert.AreEqual(actualzip, "01301");
        }

        [Then(@"the minimum field length is five in the Shipping From Section")]
        public void ThenTheMinimumFieldLengthIsFiveInTheShippingFromSection()
        {
            Clear(attributeName_id, ShippingFrom_zipcode_NewScreen_Id);
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "01342"); //Deerfield
            Thread.Sleep(3000);
            string minLength = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");           
            Assert.AreEqual(Convert.ToInt32(minLength.Length), 5);
        }

        [Then(@"the maximum field length is five in the Shipping From Section")]
        public void ThenTheMaximumFieldLengthIsFiveInTheShippingFromSection()
        {
            Clear(attributeName_id, ShippingFrom_zipcode_NewScreen_Id);
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "10001"); //New York
            Thread.Sleep(3000);
            string maxLength = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");            
            Assert.AreEqual(Convert.ToInt32(maxLength.Length), 5);
        }

        [Then(@"I should be able to enter only numeric values in the Shipping To Section")]
        public void ThenIShouldBeAbleToEnterOnlyNumericValuesInTheShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "85282");
            Thread.Sleep(3000);
            string actualzip = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "value");
            Assert.AreEqual(actualzip, "85282");
        }

        [Then(@"I should be able to enter a numeric value with leading zero\(s\) in the Shipping To Section")]
        public void ThenIShouldBeAbleToEnterANumericValueWithLeadingZeroSInTheShippingToSection()
        {
            Clear(attributeName_id, ShippingTo_zipcode_NewScreen_Id);
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "01060"); //Northampton [01027 = Eastampton]
            Thread.Sleep(3000);
            string actualzip = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "value");
            Assert.AreEqual(actualzip, "01060");
        }

        [Then(@"the minimum field length is five in the Shipping To Section")]
        public void ThenTheMinimumFieldLengthIsFiveInTheShippingToSection()
        {
            Clear(attributeName_id, ShippingTo_zipcode_NewScreen_Id);
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "23220"); //Richmond
            Thread.Sleep(3000);
            string minLength = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(minLength.Length), 5);
        }

        [Then(@"the maximum field length is five in the Shipping To Section")]
        public void ThenTheMaximumFieldLengthIsFiveInTheShippingToSection()
        {
            Clear(attributeName_id, ShippingTo_zipcode_NewScreen_Id);
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "23221"); //Richmond
            Thread.Sleep(3000);
            string maxLength = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(maxLength.Length), 5);
        }

        [Given(@"Country selected is United States in the Shipping From section")]
        public void GivenCountrySelectedIsUnitedStatesInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            Thread.Sleep(3000);
            string defaultCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(defaultCountry, "United States");
        }

        [When(@"I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is found in zip lookup")]
        public void WhenIEnterAZipcodeInTheEnterZipPostalCodeFieldInTheShippingFromSectionThatIsFoundInZipLookup()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "33126");
            Thread.Sleep(3000);
        }

        [Then(@"the city and state fields in the Shipping From section should be auto filled with the corresponding city and state associated with the zip code")]
        public void ThenTheCityAndStateFieldsInTheShippingFromSectionShouldBeAutoFilledWithTheCorrespondingCityAndStateAssociatedWithTheZipCode()
        {
            string actualCity = GetAttribute(attributeName_id, ShippingFrom_City_NewScreen_Id,"value");
            Assert.AreEqual(actualCity, "Miami");
            string actualState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(actualState, "FL");
        }

        [Then(@"I should be able to edit the city field in the Shipping From section")]
        public void ThenIShouldBeAbleToEditTheCityFieldInTheShippingFromSection()
        {
            Clear(attributeName_id, ShippingFrom_City_NewScreen_Id);
            SendKeys(attributeName_id, ShippingFrom_City_NewScreen_Id, "Doral");
            Thread.Sleep(3000);
            string actualCity = GetAttribute(attributeName_id, ShippingFrom_City_NewScreen_Id,"value");
            Assert.AreEqual(actualCity, "Doral");

        }

        [Then(@"I should be able to select the state from the drop down list in the Shipping From section")]
        public void ThenIShouldBeAbleToSelectTheStateFromTheDropDownListInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_StateDropdwon_SelectedValue_NewScreen_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "AZ")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
           
            string actualState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(actualState, "AZ");
        }

        [Given(@"Country selected is United States in the Shipping To section")]
        public void GivenCountrySelectedIsUnitedStatesInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Thread.Sleep(3000);
            string defaultCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(defaultCountry, "United States");
        }

        [When(@"I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is found in zip lookup")]
        public void WhenIEnterAZipcodeInTheEnterZipPostalCodeFieldInTheShippingToSectionThatIsFoundInZipLookup()
        {
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "85282");
            Thread.Sleep(3000);
        }

        [Then(@"the city and state fields in the Shipping To section should be auto filled with the corresponding city and state associated with the zip code")]
        public void ThenTheCityAndStateFieldsInTheShippingToSectionShouldBeAutoFilledWithTheCorrespondingCityAndStateAssociatedWithTheZipCode()
        {
            string actualCity = GetAttribute(attributeName_id, ShippingTo_City_NewScreen_Id,"value");
            Assert.AreEqual(actualCity, "Tempe");
            string actualState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(actualState, "AZ");
        }

        [Then(@"I should be able to edit the city field in the Shipping To section")]
        public void ThenIShouldBeAbleToEditTheCityFieldInTheShippingToSection()
        {
            Clear(attributeName_id, ShippingTo_City_NewScreen_Id);
            SendKeys(attributeName_id, ShippingTo_City_NewScreen_Id, "Doral");
            Thread.Sleep(3000);
            string actualCity = GetAttribute(attributeName_id, ShippingTo_City_NewScreen_Id,"value");
            Assert.AreEqual(actualCity, "Doral");
        }

        [Then(@"I should be able to select the state from the drop down list in the Shipping To section")]
        public void ThenIShouldBeAbleToSelectTheStateFromTheDropDownListInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "FL")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            
            string actualState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(actualState, "FL");
        }

        [When(@"I enter a zipcode in the Enter zip/postal code field in the Shipping From section that is not found in zip lookup")]
        public void WhenIEnterAZipcodeInTheEnterZipPostalCodeFieldInTheShippingFromSectionThatIsNotFoundInZipLookup()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "11009");
            Thread.Sleep(3000);
            Click(attributeName_id, ShippingTo_City_NewScreen_Id);
        }

        [Then(@"the zipcode field in the Shipping From section should be highlighted in red")]
        public void ThenTheZipcodeFieldInTheShippingFromSectionShouldBeHighlightedInRed()
        {
            Report.WriteLine("Highlighted in Red");
            var colorofHighlighted_ShippingFrom_Zipcode_value = GetCSSValue(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "background-color");
            Assert.AreEqual("rgba(251, 236, 236, 1)", colorofHighlighted_ShippingFrom_Zipcode_value);

        }

        [When(@"I enter a zipcode in the Enter zip/postal code field in the Shipping To section that is not found in zip lookup")]
        public void WhenIEnterAZipcodeInTheEnterZipPostalCodeFieldInTheShippingToSectionThatIsNotFoundInZipLookup()
        {
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "12002");
            Click(attributeName_id, ShippingTo_City_NewScreen_Id);
        }

        [Then(@"the zipcode field in the Shipping To section should be highlighted in red")]
        public void ThenTheZipcodeFieldInTheShippingToSectionShouldBeHighlightedInRed()
        {
            Report.WriteLine("Highlighted in Red");
            var colorofHighlighted_ShippingTo_Zipcode_value = GetCSSValue(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "background-color");
            Assert.AreEqual("rgba(251, 236, 236, 1)", colorofHighlighted_ShippingTo_Zipcode_value);
        }

        [Then(@"I should be able to enter alpha numeric value including spaces in the (.*) postal code field in the Shipping From Section")]
        public void ThenIShouldBeAbleToEnterAlphaNumericValueIncludingSpacesInThePostalCodeFieldInTheShippingFromSection(string PostalCode)
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, PostalCode);
            string actualPostalCode = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(actualPostalCode, PostalCode);
        }

        [Then(@"the minimum field length is one in the Shipping From Section")]
        public void ThenTheMinimumFieldLengthIsOneInTheShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "L");
            string minLength = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(minLength.Length), 1);
        }

        [Then(@"the maximum field length is seven in the Shipping From Section")]
        public void ThenTheMaximumFieldLengthIsSevenInTheShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "L7J 3B2");
            string maxLength = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(maxLength.Length), 7);
        }

        [Then(@"I should be able to enter alpha numeric value including spaces in the (.*) postal code field in the Shipping To Section")]
        public void ThenIShouldBeAbleToEnterAlphaNumericValueIncludingSpacesInThePostalCodeFieldInTheShippingToSection(string PostalCode)
        {
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, PostalCode);
            string actualPostalCode = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(actualPostalCode, PostalCode);
        }

        [Then(@"the minimum field length is one in the Shipping To Section")]
        public void ThenTheMinimumFieldLengthIsOneInTheShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "1");
            string minLength = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(minLength.Length), 1);
        }

        [Then(@"the maximum field length is seven in the Shipping To Section")]
        public void ThenTheMaximumFieldLengthIsSevenInTheShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "N4B 2P8");
            string maxLength = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(maxLength.Length), 7);
        }
        [Given(@"I am a shpentry shpentrynorates, sales, sales management, operations, or stationowner (.*) user")]
        public void GivenIAmAShpentryShpentrynoratesSalesSalesManagementOperationsOrStationownerUser(string UserType)
        {
            
            if (UserType.Equals("External"))
            {
                userName = ConfigurationManager.AppSettings["username-NewScreenShipEntryUser"].ToString();
                password = ConfigurationManager.AppSettings["password-NewScreenShipEntryUser"].ToString();
            }
            else if (UserType.Equals("Internal"))
            {
                userName = ConfigurationManager.AppSettings["username-NewScreenCrmOperationUser"].ToString();
                password = ConfigurationManager.AppSettings["password-NewScreenCrmOperationUser"].ToString();
            }
            else
            {

                userName = ConfigurationManager.AppSettings["username-NewScreenSalesUser"].ToString();
                password = ConfigurationManager.AppSettings["password-NewScreenSalesUser"].ToString();
            }

            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I arrive on the (.*) Add Shipment - \(LTL\) page for Internal user")]
        public void GivenIArriveOnTheAddShipment_LTLPageForInternalUser(string Customer)
        {
            Customer = "ZZZ - Czar Customer Test";
            Report.WriteLine("Customer Selection dropdown");
            AddShipments selection = new AddShipments();
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            Click(attributeName_xpath, selection.AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, selection.AllCustomerDroppdownValues_Internal_Xpath, Customer);

            Report.WriteLine("Click on Add Shipment button Internal users");
            Click(attributeName_id, selection.AddShipmentButtionInternal_Id);

            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, selection.ShipmentServiceTypeLTL_id);
        }


        [Given(@"I arrive on the (.*) Add Shipment - \(LTL\) page for (.*) user")]
        public void GivenIArriveOnTheAddShipment_LTLPageForUser(string Customer, string UserType)
        {
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            if (UserType.Equals("External"))
            {
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            if (UserType.Equals("Internal"))
            {
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            }
            else if (UserType.Equals("Sales"))
            {
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            }
                        
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }

        [Given(@"I arrive on the (.*) Add Shipment LTL page for (.*) user")]
        public void GivenIArriveOnTheAddShipmentLTLPageForUser(string Customer, string UserType)
        {
            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            if (UserType.Equals("External"))
            {
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (UserType.Equals("Internal"))
            {
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            }
            else 
            {
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            }

            
            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }


        [When(@"I enter alpha numeric value in zip code field of Shipping From section")]
        public void WhenIEnterAlphaNumericValueInZipCodeFieldOfShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "33AB6");
        }

        [Then(@"Zip code field should not accept the alphabets in the Shipping From section")]
        public void ThenZipCodeFieldShouldNotAcceptTheAlphabetsInTheShippingFromSection()
        {
            string actualzip = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");
            Assert.IsFalse(actualzip.Contains("AB"));
        }

        [When(@"I enter more than five digits in zip code field of Shipping From section")]
        public void WhenIEnterMoreThanFiveDigitsInZipCodeFieldOfShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "3312680");
        }

        [Then(@"zip code should accepts only five digits in the Shipping From section")]
        public void ThenZipCodeShouldAcceptsOnlyFiveDigitsInTheShippingFromSection()
        {
            string actualzip = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id,"value");
            Assert.AreEqual(Convert.ToInt32(actualzip.Length), 5);
        }





































    }
}
