using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipment_ContactInfoSection_AllUsersSteps: AddShipments
    {
        AddShipmentLTL ltl = new AddShipmentLTL();
        [When(@"I expand arrow of the Shipping from contact info in add shipment ltl page")]
        public void WhenIExpandArrowOfTheShippingFromContactInfoInAddShipmentLtlPage()
        {
            Report.WriteLine("Clicking on expand icon for shipping from contact section");
            Click(attributeName_xpath, ShippingFrom_ContactInfo_Expand_xpath);
        }
        
        [When(@"I expand arrow of the Shipping to contact info in add shipment ltl page")]
        public void WhenIExpandArrowOfTheShippingToContactInfoInAddShipmentLtlPage()
        {
            Report.WriteLine("Clicking on expand icon for shipping to contact section");
            Click(attributeName_xpath, ShippingTo_ContactInfo_Expand_xpath);
        }
        
        
        [When(@"I click on View rates button in add shipment ltl page")]
        public void WhenIClickOnViewRatesButtonInAddShipmentLtlPage()
        {
            Report.WriteLine("Clicking on view rate results button");
            scrollElementIntoView(attributeName_xpath, ViewRatesButton_xpath);
            ltl.ClickViewRates();
        }
        
        [Then(@"Shipping From Contact Info and Shipping To Contact Info sections should be collapsed")]
        public void ThenShippingFromContactInfoAndShippingToContactInfoSectionsShouldBeCollapsed()
        {
            Report.WriteLine("Verify for the collapsed section in shipping from section");
            VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactName_Id, "Shipping from contact name");
            VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactEmail_Id, "Shipping from contact email");
            VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactFax_Id, "Shipping from contact fax");
            VerifyElementNotVisible(attributeName_id, ShippingFrom_ContactPhone_Id, "Shipping from contact phone");

            Report.WriteLine("Verify for the collapsed section in shipping to section");
            VerifyElementNotVisible(attributeName_id, ShippingTo_ContactName_Id, "Shipping to contact name");
            VerifyElementNotVisible(attributeName_id, ShippingTo_ContactEmail_Id, "Shipping to contact email");
            VerifyElementNotVisible(attributeName_id, ShippingTo_ContactFax_Id, "Shipping to contact fax");
            VerifyElementNotVisible(attributeName_id, ShippingTo_ContactPhone_Id, "Shipping to contact phone");
        }
        
        [Then(@"Contact Name, Contact Phone, Contact Email and Contact fax fields should be displayed in shipping from section")]
        public void ThenContactNameContactPhoneContactEmailAndContactFaxFieldsShouldBeDisplayedInShippingFromSection()
        {
            Report.WriteLine("Verifying the displaying contacts fileds under shipping from section");
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_Id, "Shipping from contact name");
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactEmail_Id, "Shipping from contact email");
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactFax_Id, "Shipping from contact fax");
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactPhone_Id, "Shipping from contact phone");
        }
        
        [Then(@"Contact Name, Contact Phone, Contact Email and Contact fax fields should be displayed in shipping to section")]
        public void ThenContactNameContactPhoneContactEmailAndContactFaxFieldsShouldBeDisplayedInShippingToSection()
        {
            Report.WriteLine("Verifying the displaying contacts fileds under shipping to section");
            VerifyElementPresent(attributeName_id, ShippingTo_ContactName_Id, "Shipping to contact name");
            VerifyElementPresent(attributeName_id, ShippingTo_ContactEmail_Id, "Shipping to contact email");
            VerifyElementPresent(attributeName_id, ShippingTo_ContactFax_Id, "Shipping to contact fax");
            VerifyElementPresent(attributeName_id, ShippingTo_ContactPhone_Id, "Shipping to contact phone");
        }
        
        [Then(@"Contact Phone, Contact Email and Contact Fax in shipping from section should be highlighted")]
        public void ThenContactPhoneContactEmailAndContactFaxInShippingFromSectionShouldBeHighlighted()
        {
            Report.WriteLine("Verify the highlight funcitonality when invalid email, phone and fax format is passed in shipping from section");
            string emailColor = GetCSSValue(attributeName_id, ShippingFrom_ContactEmail_Id, "background");
            string phoneColor = GetCSSValue(attributeName_id, ShippingFrom_ContactPhone_Id, "background");
            string faxColor = GetCSSValue(attributeName_id, ShippingFrom_ContactFax_Id, "background");

            if(emailColor.Contains(" linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)") && phoneColor.Contains(" linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)") && faxColor.Contains(" linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)"))
            {
                Report.WriteLine("Shipping from contact phone, email and fax fields are highlighting");
            }
            else
            {
                Report.WriteFailure("Shipping from contact phone, email and fax fields are not highlighting");
                Assert.IsTrue(false);
            }

        }

        [When(@"I enter (.*), (.*), (.*) and (.*) in shipping from contact info section present in add shipment page")]
        public void WhenIEnterAndInShippingFromContactInfoSectionPresentInAddShipmentPage(string cName, string cPhone, string cEmail, string cFax)
        {
            Report.WriteLine("Passing data in shipping from contact info section");
            SendKeys(attributeName_id, ShippingFrom_ContactName_Id, cName);
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_Id, cEmail);
            SendKeys(attributeName_id, ShippingFrom_ContactFax_Id, cFax);
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_Id, cPhone);
        }

        [When(@"I enter (.*), (.*), (.*) and (.*) in shipping to contact info section present in add shipment page")]
        public void WhenIEnterAndInShippingToContactInfoSectionPresentInAddShipmentPage(string cName, string cPhone, string cEmail, string cFax)
        {
            Report.WriteLine("Passing data in shipping to contact info section");
            SendKeys(attributeName_id, ShippingTo_ContactName_Id, cName);
            SendKeys(attributeName_id, ShippingTo_ContactEmail_Id, cEmail);
            SendKeys(attributeName_id, ShippingTo_ContactFax_Id, cFax);
            SendKeys(attributeName_id, ShippingTo_ContactPhone_Id, cPhone);
        }

        
        [Then(@"Contact Phone, Contact Email and Contact Fax in shipping to section should be highlighted")]
        public void ThenContactPhoneContactEmailAndContactFaxInShippingToSectionShouldBeHighlighted()
        {
            Report.WriteLine("Verify the highlight funcitonality when invalid email, phone and fax format is passed in shipping from section");
            string emailColor = GetCSSValue(attributeName_id, ShippingTo_ContactEmail_Id, "background");
            string phoneColor = GetCSSValue(attributeName_id, ShippingTo_ContactPhone_Id, "background");
            string faxColor = GetCSSValue(attributeName_id, ShippingTo_ContactFax_Id, "background");

            if (emailColor.Contains(" linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)") && phoneColor.Contains(" linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)") && faxColor.Contains(" linear-gradient(rgb(251, 236, 236), rgb(251, 236, 236)"))
            {
                Report.WriteLine("Shipping to contact phone, email and fax fields are highlighting");
            }
            else
            {
                Report.WriteFailure("Shipping to contact phone, email and fax fields are not highlighting");
                Assert.IsTrue(false);
            }
        }

        [Then(@"max characters for Contact Phone, Contact Email and Contact Fax in shipping from section should match with the existing screen length")]
        public void ThenMaxCharactersForContactPhoneContactEmailAndContactFaxInShippingFromSectionShouldMatchWithTheExistingScreenLength()
        {
            Report.WriteLine("Verifying the max characters for contact name, email, phone and fax fields");
            string maxNameField = GetAttribute(attributeName_id, ShippingTo_ContactName_Id, "maxlength");
            Assert.AreEqual(maxNameField, "75");

            string maxEmailField = GetAttribute(attributeName_id, ShippingTo_ContactEmail_Id, "maxlength");
            Assert.AreEqual(maxEmailField, "50");

            string maxPhoneField = GetAttribute(attributeName_id, ShippingTo_ContactPhone_Id, "maxlength");
            Assert.AreEqual(maxPhoneField, "14");

            string maxFaxField = GetAttribute(attributeName_id, ShippingTo_ContactFax_Id, "maxlength");
            Assert.AreEqual(maxFaxField, "14");
        }

        [Then(@"max characters for Contact Phone, Contact Email and Contact Fax in shipping to section should match with the existing screen length")]
        public void ThenMaxCharactersForContactPhoneContactEmailAndContactFaxInShippingToSectionShouldMatchWithTheExistingScreenLength()
        {
            Report.WriteLine("Verifying the max characters for contact name, email, phone and fax fields");
            string maxNameField = GetAttribute(attributeName_id, ShippingFrom_ContactName_Id, "maxlength");
            Assert.AreEqual(maxNameField, "75");

            string maxEmailField = GetAttribute(attributeName_id, ShippingFrom_ContactEmail_Id, "maxlength");
            Assert.AreEqual(maxEmailField, "50");

            string maxPhoneField = GetAttribute(attributeName_id, ShippingFrom_ContactPhone_Id, "maxlength");
            Assert.AreEqual(maxPhoneField, "14");

            string maxFaxField = GetAttribute(attributeName_id, ShippingFrom_ContactFax_Id, "maxlength");
            Assert.AreEqual(maxFaxField, "14");
        }

        [Then(@"I should receive error popup in shipping from contact section")]
        public void ThenIShouldReceiveErrorPopupInShippingFromContactSection()
        {
            Report.WriteLine("Verify the error message displaying for shipping from invalid email, phone and fax format");
            Verifytext(attributeName_xpath, ShippingFrom_InvalidEmailError_Xpath, "Invalid Email Format");
            Verifytext(attributeName_xpath, ShippingFrom_InvalidPhoneError_Xpath, "Invalid Phone Format");
            Verifytext(attributeName_xpath, ShippingFrom_InvalidFaxError_Xpath, "Invalid Fax Format");
        }

        [Then(@"I should receive error popup in shipping to contact section")]
        public void ThenIShouldReceiveErrorPopupInShippingToContactSection()
        {
            Report.WriteLine("Verify the error message displaying for shipping from invalid email, phone and fax format");
            Verifytext(attributeName_xpath, ShippingTo_InvalidEmailError_Xpath, "Invalid Email Format");
            Verifytext(attributeName_xpath, ShippingTo_InvalidPhoneError_Xpath, "Invalid Phone Format");
            Verifytext(attributeName_xpath, ShippingTo_InvalidFaxError_Xpath, "Invalid Fax Format");
        }
    }
}
