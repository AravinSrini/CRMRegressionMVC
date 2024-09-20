using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.TL_Rating_Tool.Get_Quote__TL_.Shipping_From_And_Shipping_To
{
    [Binding]
    public class ShippingFrom_ShippingToSteps : ObjectRepository
    {
        [Given(@"I am a DLS user and login into application with valid (.*) and (.*)")]
        public void GivenIAmADLSUserAndLoginIntoApplicationWithValidAnd(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I clicked on Rating Tool icon")]
        public void GivenIClickedOnRatingToolIcon()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter required fields (.*),(.*),(.*) in rating tool page")]
        public void WhenIEnterRequiredFieldsInRatingToolPage(string p0, string p1, string p2)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Click on Get Rate button in rating tool page")]
        public void WhenClickOnGetRateButtonInRatingToolPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I have click on Get Quote New button in rating tool page")]
        public void WhenIHaveClickOnGetQuoteNewButtonInRatingToolPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I enter zipcode (.*) and leave focus from the origin section in GetQuote\(TL\) page")]
        public void WhenIEnterZipcodeAndLeaveFocusFromTheOriginSectionInGetQuoteTLPage(string Zip)
        {
            Report.WriteLine("Entering origin zipcode");
            SendKeys(attributeName_id, TL_ShippingFromZip_Textbox_ID, Zip);
            Click(attributeName_id, TL_ShippingTo_City_Textbox_ID);
        }
        
        [Then(@"City (.*) and State (.*) fields should be populated in origin section in GetQuote\(TL\) page")]
        public void ThenCityAndStateFieldsShouldBePopulatedInOriginSectionInGetQuoteTLPage(string City, string State)
        {
            Thread.Sleep(1000);
            Report.WriteLine("Verify the populated data in origin city and state fields");
            string ActualCity = GetValue(attributeName_id, TL_ShippingFrom_City_Textbox_ID, "value");
            Assert.AreEqual(City, ActualCity);

            string ActualState = Gettext(attributeName_xpath, TL_ShippingFrom_StateProvince_Dropdown_Xpath);
            Assert.AreEqual(State, ActualState);
        }
        
        [Then(@"User have the ability to edit the city in shipping from section(.*) in GetQuote \(TL\) page")]
        public void ThenUserHaveTheAbilityToEditTheCityInShippingFromSectionInGetQuoteTLPage(string ModifiedCity)
        {
            Report.WriteLine("Verifying functionality ability to edit the city in shipping from section");
            Clear(attributeName_id, TL_ShippingFrom_City_Textbox_ID);
            SendKeys(attributeName_id, TL_ShippingFrom_City_Textbox_ID, ModifiedCity);
            string UICity = GetAttribute(attributeName_id, TL_ShippingFrom_City_Textbox_ID, "value");
            Assert.AreEqual(ModifiedCity, UICity);
        }
        
        [Then(@"User have the option to select a state from the state drop down list in shipping from section(.*) in GetQuote\(TL\) page")]
        public void ThenUserHaveTheOptionToSelectAStateFromTheStateDropDownListInShippingFromSectionInGetQuoteTLPage(string ModifiedState)
        {
            Report.WriteLine("Selecting Origin State from Origin State dropdown");
            Clear(attributeName_xpath, TL_ShippingFrom_StateProvince_Dropdown_Xpath);
            Click(attributeName_id, TL_ShippingFrom_StateProvince_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, TL_ShippingFrom_StateProvince_DropdownValue_Xpath, ModifiedState);
        }

        [When(@"I enter zipcode (.*) and leave focus from the destination section in GetQuote\(TL\) page")]
        public void WhenIEnterZipcodeAndLeaveFocusFromTheDestinationSectionInGetQuoteTLPage(string Zip)
        {
            Report.WriteLine("Entering Destination zipcode");
            SendKeys(attributeName_id, TL_ShippingToZip_Textbox_ID, Zip);
            Click(attributeName_id, TL_ShippingFrom_City_Textbox_ID);
        }

        [Then(@"City (.*) and State (.*) fields should be populated in destination section in GetQuote\(TL\) page")]
        public void ThenCityAndStateFieldsShouldBePopulatedInDestinationSectionInGetQuoteTLPage(string City, string State)
        {
            Thread.Sleep(1000);
            Report.WriteLine("Verify the populated data in Destination city and state fields");
            string ActualCity = GetValue(attributeName_id, TL_ShippingTo_City_Textbox_ID, "value");
            Assert.AreEqual(City, ActualCity);

            string ActualState = Gettext(attributeName_xpath, TL_ShippingTo_StateProvince_Dropdown_Xpath);
            Assert.AreEqual(State, ActualState);
        }

        [Then(@"User have the ability to edit the city in shipping to section (.*) in GetQuote\(TL\) page")]
        public void ThenUserHaveTheAbilityToEditTheCityInShippingToSectionInGetQuoteTLPage(string ModifiedCity)
        {
            Report.WriteLine("Verifying functionality ability to edit the city in shipping from section");
            Clear(attributeName_id, TL_ShippingTo_City_Textbox_ID);
            SendKeys(attributeName_id, TL_ShippingTo_City_Textbox_ID, ModifiedCity);
            string UICity = GetAttribute(attributeName_id, TL_ShippingTo_City_Textbox_ID, "value");
            Assert.AreEqual(ModifiedCity, UICity);
        }

        [Then(@"User have the option to select a state from the state drop down list in shipping to section(.*) in GetQuote\(TL\) page")]
        public void ThenUserHaveTheOptionToSelectAStateFromTheStateDropDownListInShippingToSectionInGetQuoteTLPage(string ModifiedState)
        {
            Report.WriteLine("Selecting Destination State from Destination State dropdown");
            Clear(attributeName_xpath, TL_ShippingTo_StateProvince_Dropdown_Xpath);
            Click(attributeName_id, TL_ShippingTo_StateProvince_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, TL_ShippingTo_StateProvince_DropdownValue_Xpath, ModifiedState);
        }

        [Then(@"background color of the origin zip code textbox should turn red and error message should be displayed in GetQuote\(TL\) page")]
        public void ThenBackgroundColorOfTheOriginZipCodeTextboxShouldTurnRedAndErrorMessageShouldBeDisplayedInGetQuoteTLPage()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, TL_ShippingFromZip_Textbox_ID, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"the Origin City and State will not Auto populate in GetQuote\(TL\) page")]
        public void ThenTheOriginCityAndStateWillNotAutoPopulateInGetQuoteTLPage()
        {
            Report.WriteLine("Verifying Origin City is not Auto populating");
            string ActualOriginCity = GetValue(attributeName_id, TL_ShippingFrom_City_Textbox_ID, "value");
            if (string.IsNullOrEmpty(ActualOriginCity))
            {
                Report.WriteLine("Verified Origin City is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Origin City is Auto populated with for incorrect Zipcode");
                throw new Exception("Verified Origin City is Auto populated with for incorrect Zipcode");
            }

            Report.WriteLine("Verifying Origin State is not Auto populating");
            string ActualOriginState = GetValue(attributeName_id, TL_ShippingFrom_StateProvince_Dropdown_Xpath, "value");
            if (string.IsNullOrEmpty(ActualOriginState))
            {
                Report.WriteLine("Verified Origin State is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Origin State is Auto populated for incorrect Zipcode");
                throw new Exception("Verified Origin State is Auto populated for incorrect Zipcode");
            }
        }

        [Then(@"background color of the destination zip code textbox should turn red and error message should be displayed in GetQuote\(TL\) page")]
        public void ThenBackgroundColorOfTheDestinationZipCodeTextboxShouldTurnRedAndErrorMessageShouldBeDisplayedInGetQuoteTLPage()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, TL_ShippingToZip_Textbox_ID, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"the Destination City and State will not Auto populate in GetQuote\(TL\) page")]
        public void ThenTheDestinationCityAndStateWillNotAutoPopulateInGetQuoteTLPage()
        {
            Report.WriteLine("Verifying Origin City is not Auto populating");
            string ActualDestCity = GetValue(attributeName_id, TL_ShippingTo_City_Textbox_ID, "value");
            if (string.IsNullOrEmpty(ActualDestCity))
            {
                Report.WriteLine("Verified Destination City is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Destination City is Auto populated with for incorrect Zipcode");
                throw new Exception("Verified Destination City is Auto populated with for incorrect Zipcode");
            }

            Report.WriteLine("Verifying Destination State is not Auto populating");
            string ActualDestState = GetValue(attributeName_id, TL_ShippingTo_StateProvince_Dropdown_Xpath, "value");
            if (string.IsNullOrEmpty(ActualDestState))
            {
                Report.WriteLine("Verified Destination State is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Destination State is Auto populated for incorrect Zipcode");
                throw new Exception("Verified Destination State is Auto populated for incorrect Zipcode");
            }
        }

        [When(@"I select Canada Country from destination country dropdown in GetQuote\(TL\) page")]
        public void WhenISelectCanadaCountryFromDestinationCountryDropdownInGetQuoteTLPage()
        {
            Report.WriteLine("Selecting Country as Canada from Origin Country dropdown");
            Click(attributeName_xpath, TL_ShippingTo_Country_Dropdown_Xpath);
            Click(attributeName_xpath, TL_ShippingTo_CanadaCountry_Dropdown_Xpath);
        }

        [Then(@"the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section in GetQuote\(TL\) page")]
        public void ThenTheSelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSectionInGetQuoteTLPage()
        {
            Report.WriteLine("Verifying drop down list will be populated with a list of Canada provinces in Shipping To section");
            Click(attributeName_xpath, TL_ShippingTo_StateProvince_Dropdown_Xpath);
            IList<IWebElement> Destination_StateProvince_UI_list = GlobalVariables.webDriver.FindElements(By.XPath(TL_ShippingTo_StateProvince_DropdownValue_Xpath));
            List<string> Destination_StateProvince_UI = Destination_StateProvince_UI_list.Skip(1).Select(c => c.Text).ToList();
            List<string> Destination_StateProvince_list = new List<string>
           {
               "AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"
           };
            CollectionAssert.AreEqual(Destination_StateProvince_UI, Destination_StateProvince_list);
        }

        [When(@"I select Canada Country from origin country dropdown in GetQuote\(TL\) page")]
        public void WhenISelectCanadaCountryFromOriginCountryDropdownInGetQuoteTLPage()
        {
            Report.WriteLine("Selecting Country as Canada from Origin Country dropdown");
            Click(attributeName_xpath, TL_ShippingFrom_Country_Dropdown_Xpath);
            Click(attributeName_xpath, TL_ShippingFrom_CanadaCountry_Dropdown_Xpath);
        }

        [Then(@"the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section in GetQuote\(TL\) page")]
        public void ThenTheSelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSectionInGetQuoteTLPage()
        {
            Report.WriteLine("Verifying drop down list will be populated with a list of Canada provinces in Shipping To section");
            Click(attributeName_xpath, TL_ShippingFrom_StateProvince_Dropdown_Xpath);
            IList<IWebElement> Origin_StateProvince_UI_list = GlobalVariables.webDriver.FindElements(By.XPath(TL_ShippingFrom_StateProvince_DropdownValue_Xpath));
            List<string> Origin_StateProvince_UI = Origin_StateProvince_UI_list.Skip(1).Select(c => c.Text).ToList();
            List<string> Origin_StateProvince_list = new List<string>
           {
               "AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"
           };
            CollectionAssert.AreEqual(Origin_StateProvince_UI, Origin_StateProvince_list);
        }

    }
}
