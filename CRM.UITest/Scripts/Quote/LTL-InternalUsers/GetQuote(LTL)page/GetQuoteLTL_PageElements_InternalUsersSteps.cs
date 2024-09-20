using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Data;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.GetQuote_LTL_page
{
    [Binding]
    public class GetQuoteLTL_PageElements_InternalUsersSteps:ObjectRepository
    {
        [Given(@"I click on the Quote Icon")]
        public void GivenIClickOnTheQuoteIcon()
        {
            Report.WriteLine("Clicking on quote module icon");
            Thread.Sleep(5000);
            Click(attributeName_xpath, QuoteModule_Xpath);
        }

        [When(@"I  keep Shipping From zip is blank")]
        public void WhenIKeepShippingFromZipIsBlank()
        {
            Report.WriteLine("KeepShippingFromZipIsBlank");
            SendKeys(attributeName_id, ZipcodeforShippingFrom_id, "");
        }
        
        [When(@"I  keep Shipping To zip is blank")]
        public void WhenIKeepShippingToZipIsBlank()
        {
            Report.WriteLine("KeepShippingFromZipIsBlank");
            SendKeys(attributeName_id, ZipcodeforShippingTo_id, "");
        }
        
        [When(@"I keep Weight field is blank")]
        public void WhenIKeepWeightFieldIsBlank()
        {
            Report.WriteLine("KeepShippingFromZipIsBlank");
            SendKeys(attributeName_id, weight_id, "");
        }
        [When(@"I click on viewquote results button")]
        public void WhenIClickOnViewquoteResultsButton()
        {
            Report.WriteLine("ClickOnViewquoteResultsButton");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
        }

        [Then(@"I should be displayed with shipfrom section")]
        public void ThenIShouldBeDisplayedWithShipfromSection()
        {
            Report.WriteLine("User Displayed With ShipfromSection");
            VerifyElementPresent(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath,"shipfromsection");
        }
        
        [Then(@"I should be displayed with the saved address ship from drop down")]
        public void ThenIShouldBeDisplayedWithTheSavedAddressShipFromDropDown()
        {
            Report.WriteLine("User Displayed With TheSavedAddressShipFromDropDown");
            VerifyElementPresent(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "ShipFromDropDown");
           
        }
        
        [Then(@"I should be displayed with the clear address option")]
        public void ThenIShouldBeDisplayedWithTheClearAddressOption()
        {
            Report.WriteLine("User Displayed With TheClearAddressOption");
            VerifyElementPresent(attributeName_id, ClearAddress_OriginId, "ClearAddressOption");
        }
        
        [Then(@"I should be displayed Shipping From zip")]
        public void ThenIShouldBeDisplayedShippingFromZip()
        {
            Report.WriteLine("User Displayed With ShippingFromZip");
            VerifyElementPresent(attributeName_id, ZipcodeforShippingFrom_id, "ShippingFromZip");
            
        }
        
        [Then(@"I should be displayed with Shipping From city")]
        public void ThenIShouldBeDisplayedWithShippingFromCity()
        {
            Report.WriteLine("User Displayed With Shipping From city");
            VerifyElementPresent(attributeName_id, cityforOrigin_id, "ShippingFromCity");
                   
        }
        
        [Then(@"I should be displayed with Shipping From country")]
        public void ThenIShouldBeDisplayedWithShippingFromCountry()
        {
            Report.WriteLine("User Displayed With Shipping From country");
            VerifyElementPresent(attributeName_id, LTL_OriginCountryDropdown_Id, "ShippingFromCountry");
        }
        
        [Then(@"I should be displayed with state/province")]
        public void ThenIShouldBeDisplayedWithStateProvince()
        {
            Report.WriteLine("User Displayed With Shipping From country");
            VerifyElementPresent(attributeName_xpath, stateforOrigin_xpath, "StateProvince");
        }
        
        [Then(@"I should be displayed with Shipping From services & accessorial")]
        public void ThenIShouldBeDisplayedWithShippingFromServicesAccessorial()
        {
            Report.WriteLine("User Displayed With Shipping From country");
            VerifyElementPresent(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "FromServicesAccessorials");
        }
        
        [Then(@"I should be displayed US state by default in Shipping From country")]
        public void ThenIShouldBeDisplayedUSStateByDefaultInShippingFromCountry()
        {
            Report.WriteLine("User Displayed With Shipping From country as US");
            string expected = Gettext(attributeName_id, LTL_OriginCountryDropdown_Id);
            string actual = "United States";
            Assert.AreEqual(expected, actual);

        }
        
        [Then(@"I should be displayed with shipto section")]
        public void ThenIShouldBeDisplayedWithShiptoSection()
        {
            Report.WriteLine("User Displayed With with shipto section");
            VerifyElementPresent(attributeName_xpath, ShippingToText_xpath, "shippingtosection");
        }
        
        [Then(@"I should be displayed with the saved address ship To drop down")]
        public void ThenIShouldBeDisplayedWithTheSavedAddressShipToDropDown()
        {
            Report.WriteLine("User Displayed With with saved address ship To drop down");
            VerifyElementPresent(attributeName_id, SearchboxforDestination_id, "TheSavedAddressShipToDropDown");
        }
        
        [Then(@"I should be displayed Shipping To zip")]
        public void ThenIShouldBeDisplayedShippingToZip()
        {
            Report.WriteLine("User Displayed With with Shipping To zip");
            VerifyElementPresent(attributeName_id, ZipcodeforShippingTo_id, "ShippingToZip");
            
        }
        
        [Then(@"I should be displayed with Shipping To city")]
        public void ThenIShouldBeDisplayedWithShippingToCity()
        {
            Report.WriteLine("User Displayed With with Shipping To city");
            VerifyElementPresent(attributeName_id, cityforDestination_id, "ShippingToCity");
        }
        
        [Then(@"I should be displayed with Shipping To country")]
        public void ThenIShouldBeDisplayedWithShippingToCountry()
        {
            Report.WriteLine("User Displayed With with Shipping To country");
            VerifyElementPresent(attributeName_xpath, countryforDestination_xpath, "ShippingToCountry");
        }
        
        [Then(@"I should be displayed with Shipping To services & accessorial")]
        public void ThenIShouldBeDisplayedWithShippingToServicesAccessorials()
        {
            Report.WriteLine("User Displayed With with Shipping To services & accessorials");
            VerifyElementPresent(attributeName_id, servicesforDestination_id, "ShippingToServicesAccessorials");
        }
        
        [Then(@"I should be displayed US state by default in Shipping To country")]
        public void ThenIShouldBeDisplayedUSStateByDefaultInShippingToCountry()
        {
            Report.WriteLine("User Displayed With Shipping From country as US");
            string expected = Gettext(attributeName_id, LTL_DestinationCountryDropdown_Id);
            string actual = "United States";
            Assert.AreEqual(expected, actual);
        }
        
        [Then(@"I should be displayed Select Class")]
        public void ThenIShouldBeDisplayedSelectClass()
        {
            Report.WriteLine("User Displayed With with  Select Class");
            VerifyElementPresent(attributeName_id, LTL_SavedItemDropdown_Id, "SelectClass");
            
        }
        
        [Then(@"I should be displayed Enter a Weight")]
        public void ThenIShouldBeDisplayedEnterAWeight()
        {
            Report.WriteLine("User Displayed With with  Enter a Weight");
            VerifyElementPresent(attributeName_id, LTL_SavedItemDropdown_Id, "EnterAWeight");
           
        }
        
        [Then(@"I should be displayed with Quantity")]
        public void ThenIShouldBeDisplayedWithQuantity()
        {

            Report.WriteLine("User Displayed With with  Enter Quantity");
            VerifyElementPresent(attributeName_id, LTL_Quantity_Id, "Quantity");
            
        }
        
        [Then(@"I should be displayed with Quantity Type")]
        public void ThenIShouldBeDisplayedWithQuantityType()
        {
            Report.WriteLine("User Displayed With with QuantityType");
            VerifyElementPresent(attributeName_xpath, LTL_QuantityUnitField_Xpath, "QuantityType");
            
        }
        
        [Then(@"I should be displayed with Insured Value")]
        public void ThenIShouldBeDisplayedWithInsuredValue()
        {
            Report.WriteLine("User Displayed With with InsuredValue");
            VerifyElementPresent(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, "InsuredValue");
            
        }
        
        [Then(@"I should be displayed with Insured Value New or Used selection")]
        public void ThenIShouldBeDisplayedWithInsuredValueNewOrUsedSelection()
        {
            Report.WriteLine("User Displayed With with NewOrUsedSelection");
            VerifyElementPresent(attributeName_xpath,InsuredType_Xpath, "NewOrUsedSelection");
            
        }
        
        [Then(@"Quantity Type should be default to skids")]
        public void ThenQuantityTypeShouldBeDefaultToSkids()
        {
            Report.WriteLine("Quantity Type should be default to skids");
            string expected = Gettext(attributeName_xpath, LTL_QuantityUnitField_Xpath);
            string actual = "Skids";
            Assert.AreEqual(expected, actual);

        }
        
        [Then(@"Insured Value New or Used selection dropdown is binded with default value '(.*)'")]
        public void ThenInsuredValueNewOrUsedSelectionDropdownIsBindedWithDefaultValue(string New)
        {
            Report.WriteLine("Quantity Type should be default to skids");
            string expected = Gettext(attributeName_xpath, InsuredType_Xpath);
            string Actual = "New";
            Assert.AreEqual(expected, Actual);
            
        }
        
        [Then(@"I should be displayed with pickup date")]
        public void ThenIShouldBeDisplayedWithPickupDate()
        {
            Report.WriteLine("User Displayed With with PickupDate");
            VerifyElementPresent(attributeName_id, Pickupdate_id, "PickupDate");
            
        }
        
        [Then(@"I pickup date should be binded with by default todays date")]
        public void ThenIPickupDateShouldBeBindedWithByDefaultTodaysDate()
        {

            Report.WriteLine("Pickup date should be displayed as current date by default");
             DateTime today = DateTime.Today;
            string s_today = today.ToString("MM/dd/yyyy");
            var PickupDate_UI = GetAttribute(attributeName_id, Pickupdate_id, "value");
            Assert.AreEqual(PickupDate_UI, s_today);
          
        }
        
        [Then(@"I should be displayed density calculator button next to class selection")]
        public void ThenIShouldBeDisplayedDenistyCalculatorButtonNextToClassSelection()
        {
            Report.WriteLine("User Displayed With with DensityCalculatorIcon");
            VerifyElementPresent(attributeName_id, DensityCalculatorIcon_id, "DensityCalculatorIcon");
        }
        
        [Then(@"I should be displayed with Add Additional Item button")]
        public void ThenIShouldBeDisplayedWithAddAdditionalItemButton()
        {
            Report.WriteLine("User Displayed With with Additional Item button");
           VerifyElementPresent(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath, "Additional Item button");
        }
        
        [Then(@"I should be displayed with Calendar icon in pickup date selection field")]
        public void ThenIShouldBeDisplayedWithCalendarIconInPickupDateSelectionField()
        {
            Report.WriteLine("User Displayed With with Calander icon");
            Click(attributeName_id, Pickupdate_id);
            Thread.Sleep(100);
            VerifyElementPresent(attributeName_xpath, calendarininformation, "Calander icon");
        }
        
        [Then(@"I should be displayed with tool tip next to insured type selection field")]
        public void ThenIShouldBeDisplayedWithToolTipNextToInsuredTypeSelectionField()
        {
            Report.WriteLine("User Displayed With with insured type");
           
            VerifyElementPresent(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath, "insured type");
        }
        
        [Then(@"I should be displayed back to quote list button")]
        public void ThenIShouldBeDisplayedBackToQuoteListButton()
        {
            Report.WriteLine("User Displayed With with BackToQuoteListButton");
            VerifyElementPresent(attributeName_id, BackToQuoteButton_Id, "BackToQuoteListButton");
        }
        
        [Then(@"I should be displayed with View Quote Results button")]
        public void ThenIShouldBeDisplayedWithViewQuoteResultsButton()
        {
            Report.WriteLine("User Displayed With with ViewQuoteResultsButton");
            VerifyElementPresent(attributeName_id, LTL_ViewQuoteResults_Id, "ViewQuoteResultsButton");
        }
    }
}
