using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class _76034_AddShipmentLTL2019_ShippingToSectionElementsSteps : AddShipments
    {
        string contactPhoneExt = "3245";
        string contactFaxExt = "6543";
        string shipToComments = "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja";
        string contactPhoneExtension = "123456";
        string contactPhoneExten = "123";
        string contactFaxExtension = "87654";
        string contactFaxExten = "432";
        string commentsValidation = "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja43";
        string commentValidation = "dgsh dhgwdha uydas 7 jdas";
        string shipToInvalidEmail = "awwe.com";
        string shipToComment = "hgyy vhghg";


        [Given(@"I am a shp\.entry, shp\.entrynorates user\tWhen I arrive on the Add Shipment \(LTL\) page")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUserWhenIArriveOnTheAddShipmentLTLPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I arrive on the Add Shipment \(LTL\) page")]
        public void GivenIArriveOnTheAddShipmentLTLPage()
        {        
            Verifytext(attributeName_xpath, CopyAddShipmentTitle_Xpath, "Add Shipment (LTL)");
            Report.WriteLine("Add Shipment page");

        }

        [Given(@"Comments field field in the Shipping To section contains more characters than can be displayed in the field")]
        public void GivenCommentsFieldFieldInTheShippingToSectionContainsMoreCharactersThanCanBeDisplayedInTheField()
        {
            SendKeys(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, shipToComments);
            Report.WriteLine("Comments field in the Shipping To section contains more characters than can be displayed in the field");

        }

        [Given(@"Comments field in the Shipping To section does not contain more characters than can be displayed in the field")]
        public void GivenCommentsFieldInTheShippingToSectionDoesNotContainMoreCharactersThanCanBeDisplayedInTheField()
        {
            SendKeys(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, shipToComment);
            Report.WriteLine("Comments field in the Shipping To section does not contains more characters than the displayed in the field");

        }

        [Given(@"I entered an invalid phone format to Contact Phone field of Shipping To section")]
        public void GivenIEnteredAnInvalidPhoneFormatToContactPhoneFieldOfShippingToSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "Chicago");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "North");
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "60606");
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "Chicago");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "North");
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "60606");
            SendKeys(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "y543");
            Report.WriteLine("Entered an invalid Phone format to Contact Phone field of Shipping To section");
        }

        [Then(@"The field with the invalid phone format will be highlighted in the Ship To section")]
        public void ThenTheFieldWithTheInvalidPhoneFormatWillBeHighlightedInTheShipToSection()
        {
            string getShipToContactPhoneCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "border-bottom-color");
            Assert.AreEqual(getShipToContactPhoneCSSVal, "rgba(209, 211, 212, 1)");
            Report.WriteLine("The field with invalid phone format is highlighted in the Shipping To section");

        }

        [Then(@"I will receive an Error message indicating an Invalid phone format")]
        public void ThenIWillReceiveAnErrorMessageIndicatingAnInvalidPhoneFormat()
        {
            scrollpagedown();
            Verifytext(attributeName_xpath, ShippingTo_ErrorMessage_NewScreen_Xpath, "Invalid phone format");
            Report.WriteLine("Error message is displayed indicating an invalid Phone format");

        }

        [Then(@"I will receive an Error message indicating an Invalid fax format")]
        public void ThenIWillReceiveAnErrorMessageIndicatingAnInvalidFaxFormat()
        {
            Verifytext(attributeName_xpath, ShippingTo_FaxError_NewScreen_Xpath, "Invalid fax format");
            Report.WriteLine("Error message is displayed indicating an invalid Fax format");

        }

        [Then(@"I will receive an Error message indicating an Invalid email format")]
        public void ThenIWillReceiveAnErrorMessageIndicatingAnInvalidEmailFormat()
        {
            Verifytext(attributeName_xpath, ShippingTo_EmailError_NewScreen_Xpath, "Invalid email format");
            Report.WriteLine("Error message is displayed indicating an invalid Email format");

        }

        [Then(@"The field with the invalid fax format will be highlighted in the Ship To section")]
        public void ThenTheFieldWithTheInvalidFaxFormatWillBeHighlightedInTheShipToSection()
        {
            string getShipToContactFaxCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "border-bottom-color");
            Assert.AreEqual(getShipToContactFaxCSSVal, "rgba(209, 211, 212, 1)");
            Report.WriteLine("The field with invalid fax format is highlighted in the Shipping To section");

        }

        [Given(@"I entered an invalid fax format to Contact fax field of Shipping To section")]
        public void GivenIEnteredAnInvalidFaxFormatToContactFaxFieldOfShippingToSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "Chicago");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "North");
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "60606");
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "Chicago");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "North");
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "60606");
            SendKeys(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "t543");
            Report.WriteLine("Entered an invalid Phone format to Contact Fax field of Shipping To section");

        }

        [Given(@"I entered an invalid Email format in the Contact email field in the Shipping To section")]
        public void GivenIEnteredAnInvalidEmailFormatInTheContactEmailFieldInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "Chicago");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "North");
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "60606");
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "Chicago");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "North");
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "60606");
            SendKeys(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, shipToInvalidEmail);
            Report.WriteLine("Entered an invalid email to Shipping To section");

        }

        [Then(@"Contact Email field will be highlighted in the Ship From section")]
        public void ThenContactEmailFieldWillBeHighlightedInTheShipFromSection()
        {
            string getShipToContactEmailCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "border-bottom-color");
            Assert.AreEqual(getShipToContactEmailCSSVal, "rgba(209, 211, 212, 1)");
            Report.WriteLine("The field with invalid email format is highlighted in the Shipping To section");

        }

        [When(@"I Pass more than four numeric values to Contact Phone Ext\. field  of Shipping To section")]
        public void WhenIPassMoreThanFourNumericValuesToContactPhoneExt_FieldOfShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, contactPhoneExtension);
            Report.WriteLine("Passed more than 4 numeric values to Contact Phone Ext field of Shipping To section");

        }

        [When(@"I Pass less than four numeric values to Contact Phone Ext\. field  of Shipping To section")]
        public void WhenIPassLessThanFourNumericValuesToContactPhoneExt_FieldOfShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, contactPhoneExten);
            Report.WriteLine("Passed less than 4 numeric values to Contact Phone Ext field of Shipping To section");

        }

        [When(@"I Pass more than four numeric values to Contact Fax Ext\. field  of Shipping To section")]
        public void WhenIPassMoreThanFourNumericValuesToContactFaxExt_FieldOfShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, contactFaxExtension);
            Report.WriteLine("Passed more than 4 numeric values to Contact Fax Ext field of Shipping To section");

        }

        [When(@"I Pass less than four numeric values to Contact Fax Ext\. field  of Shipping To section")]
        public void WhenIPassLessThanFourNumericValuesToContactFaxExt_FieldOfShippingToSection()
        {
            SendKeys(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, contactFaxExten);
            Report.WriteLine("Passed less than 4 numeric values to Contact Fax Ext field of Shipping To section");

        }

        [When(@"I pass more than (.*) characters to Comments field of Shipping To section")]
        public void WhenIPassMoreThanCharactersToCommentsFieldOfShippingToSection(int commentsValidation)
        {
            SendKeys(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja43");
            Report.WriteLine("Passed more than 250 characters to Shipping To comments section");
        }

        [When(@"I pass less than (.*) characters to Comments field of Shipping To section")]
        public void WhenIPassLessThanCharactersToCommentsFieldOfShippingToSection(int commentValidation)
        {
            SendKeys(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "dgsh dhgwdha uydas 7 jdas");
            Report.WriteLine("Passed less than 250 characters to Shipping To comments section");
        }

        [When(@"I hover over the text of Comments field in the Shipping To section")]
        public void WhenIHoverOverTheTextOfCommentsFieldInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath);
            OnMouseOver(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath);
            Report.WriteLine("Hovered over the text in the comments field in the shipping To section");
        }

        [Then(@"A popup box will not get displayed in the Ship To section")]
        public void ThenAPopupBoxWillNotGetDisplayedInTheShipToSection()
        {
            VerifyElementNotPresent(attributeName_xpath, ShippingTo_CommentsPopup_Xpath, "Comment Popup");
            Report.WriteLine("No popup box is displayed");
        }

        [Then(@"A popup box will display the entire text in the Ship To section")]
        public void ThenAPopupBoxWillDisplayTheEntireTextInTheShipToSection()
        {
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, ShippingTo_CommentsPopup_Xpath, "Comment Popup");
            string getShipToMouseHoverCommentsVal = GetAttribute(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "value");
            Assert.AreEqual(getShipToMouseHoverCommentsVal, shipToComments);
            Report.WriteLine("Popup box is displayed with entire text");
        }

        [Then(@"I will see the following in the Shipping To Section : '(.*)', '(.*)',  '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenIWillSeeTheFollowingInTheShippingToSection(string savedDestination, string clearAddressShipTo, string shipToLocationName, string shipToAddress1, string shipToAddress2, string shipToZipCode, string shipToCountry, string shipToCity, string shipToState, string shipToOriginInfo, string shipToMap, string shipToServiceAccessorial, string shipToComments)
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            VerifyElementPresent(attributeName_xpath, ShippingTo_SavedDestination_NewScreen_Xpath, "SavedOrigin");
            string getSavedDestinationUI = GetAttribute(attributeName_xpath, ShippingTo_SavedDestination_NewScreen_Xpath, "placeholder");
            Assert.AreEqual(savedDestination, getSavedDestinationUI);
            VerifyElementPresent(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath, "ClearAddress");
            string getClearAddressShipToUI = Gettext(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Assert.AreEqual(clearAddressShipTo, getClearAddressShipToUI);
            VerifyElementPresent(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "LocationName");
            string getShipToLocationNameUI = GetAttribute(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToLocationName, getShipToLocationNameUI);
            VerifyElementPresent(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "ShipFromAddress1");
            string getShipToAddress1UI = GetAttribute(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToAddress1, getShipToAddress1UI);
            VerifyElementPresent(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "ShipFromAddress2");
            string getShipToAddress2UI = GetAttribute(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToAddress2, getShipToAddress2UI);
            VerifyElementPresent(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "Zipcode");
            string getShipToZipCodeUI = GetAttribute(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToZipCode, getShipToZipCodeUI);
            VerifyElementPresent(attributeName_id, ShippingTo_CountryDropDown_NewScreen_Id, "Country");
            VerifyElementPresent(attributeName_id, ShippingTo_City_NewScreen_Id, "city");
            string getShippingToCityUI = GetAttribute(attributeName_id, ShippingTo_City_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToCity, getShippingToCityUI);
            VerifyElementPresent(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath, "StateOrProvince");
            string getShippingToStateUI = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(shipToState, getShippingToStateUI);
            VerifyElementPresent(attributeName_xpath, ShippingTo_SaveDestinationInfo_Checkbox_Xpath, "SaveDestination");
            Verifytext(attributeName_xpath, ShippingTo_SaveDestinationInfo_Label_Xpath, "Save Destination Info");
            VerifyElementPresent(attributeName_xpath, ShippingTo_Map_NewScreen_Xpath, "ShipFromMap");
            Verifytext(attributeName_xpath, ShippingTo_MapLabel_NewScreen_Xpath, "View Destination on Map");
            VerifyElementPresent(attributeName_id, ShippingTo_AccessorialDropdown_Id, "ServiceAndAccessorials");
            string getShipToServiceAccessorialUI = GetAttribute(attributeName_xpath, ShippingTo_Accessorial_Xpath, "placeholder");
            Assert.AreEqual(shipToServiceAccessorial, getShipToServiceAccessorialUI);
            VerifyElementPresent(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "Comments");
            string getShipToCommentsUI = GetAttribute(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "placeholder");
            Assert.AreEqual(shipToComments, getShipToCommentsUI);
            Report.WriteLine("The expected fields are displayed in the Shipping To section of Add Shipment (LTL) page");

        }

        [Then(@"I Will see the following in the Shipping To Contact Info Section : '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenIWillSeeTheFollowingInTheShippingToContactInfoSection(string shipToContactName, string shipToContactPhone, string shipToContactPhoneExt, string shipToContactEmail, string shipToContactFax, string shipToContactFaxExt)
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            VerifyElementPresent(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "ContactName");
            string getShipToContactNameUI = GetAttribute(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToContactName, getShipToContactNameUI);
            VerifyElementPresent(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "ContactPhone");
            string getShipToContactPhoneUI = GetAttribute(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToContactPhone, getShipToContactPhoneUI);
            VerifyElementPresent(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "ContactPhoneExt");
            string getShipToContactPhoneExtUI = GetAttribute(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "placeholder");
            Assert.AreEqual("Ext.", getShipToContactPhoneExtUI);
            VerifyElementPresent(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "Email");
            string getShipToContactEmailUI = GetAttribute(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToContactEmail, getShipToContactEmailUI);
            VerifyElementPresent(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "ContactFax");
            string getShipToContactFaxUI = GetAttribute(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipToContactFax, getShipToContactFaxUI);
            VerifyElementPresent(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "ContactFaxExt");
            string getShipToContactFaxExtUI = GetAttribute(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "placeholder");
            Assert.AreEqual("Ext.", getShipToContactFaxExtUI);
            Report.WriteLine("The expected fields are displayed in the Shipping from contact information section of Add Shipment (LTL) page");

        }


        [Then(@"I will see the following as required fields on Shipping To section - Enter location name\.\.\., Enter location address\.\.\., Enter zip/postal code\.\.\.\., Country, Enter city\.\.\., Select state/province\.\.\.")]
        public void ThenIWillSeeTheFollowingAsRequiredFieldsOnShippingToSection_EnterLocationName_EnterLocationAddress_EnterZipPostalCode_CountryEnterCity_SelectStateProvince_()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            scrollpagedown();
            Click(attributeName_xpath, Shipping_ViewRates_Xpath);
            scrollPageup();
            string getShipToLocationNumCSSVal = GetCSSValue(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "background-color");
            Assert.AreEqual(getShipToLocationNumCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToLocationAddressCSSVal = GetCSSValue(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "background-color");
            Assert.AreEqual(getShipToLocationAddressCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToZipPostalCSSVal = GetCSSValue(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "background-color");
            Assert.AreEqual(getShipToZipPostalCSSVal, "rgba(251, 236, 236, 1)");
            Report.WriteLine("The expected required fields are displayed");
        }

        [Then(@"I will see the following as optional fields on Shipping To section - Select or search for a saved origin\.\.\., Enter location address line (.*)\.\.\., Save Origin info, Contact name\.\.\., Contact phone\.\.\., Contact phone Ext\., Contact email\.\.\., Contact fax\.\.\., Contact fax Ext\., Click to add services & accessorials\.\.\., Enter comments\.\.\.")]
        public void ThenIWillSeeTheFollowingAsOptionalFieldsOnShippingToSection_SelectOrSearchForASavedOrigin_EnterLocationAddressLine_SaveOriginInfoContactName_ContactPhone_ContactPhoneExt_ContactEmail_ContactFax_ContactFaxExt_ClickToAddServicesAccessorials_EnterComments_(int p0)
        {
            string getShipToSavedOriginCSSVal = GetCSSValue(attributeName_xpath, ShippingTo_SavedDestination_NewScreen_Xpath, "background");
            Assert.AreNotEqual(getShipToSavedOriginCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToLocationAddress2CSSVal = GetCSSValue(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToLocationAddress2CSSVal, "rgba(251, 236, 236, 1)");
            string getShipToSaveOriginInfoCSSVal = GetCSSValue(attributeName_xpath, ShippingTo_SaveDestinationInfo_Label_Xpath, "background");
            Assert.AreNotEqual(getShipToSaveOriginInfoCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToContactNameCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToContactNameCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToContactPhoneCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToContactPhoneCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToContactPhoneExtCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToContactPhoneExtCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToContactEmailCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToContactPhoneCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToContactFaxCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToContactFaxCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToFaxExtCSSVal = GetCSSValue(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipToFaxExtCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToServiceAccessCSSVal = GetCSSValue(attributeName_id, ShippingTo_AccessorialDropdown_Id, "background");
            Assert.AreNotEqual(getShipToServiceAccessCSSVal, "rgba(251, 236, 236, 1)");
            string getShipToCommentsCSSVal = GetCSSValue(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "background");
            Assert.AreNotEqual(getShipToCommentsCSSVal, "rgba(251, 236, 236, 1)");
            Report.WriteLine("The expected optional fields are displayed");
        }


        [Then(@"I will see '(.*)' been selected by default on Country field of Shipping To section")]
        public void ThenIWillSeeBeenSelectedByDefaultOnCountryFieldOfShippingToSection(string country)
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            string getShipToCountryVal = GetAttribute(attributeName_id, ShippingTo_CountryDropDown_NewScreen_Id, "value");
            Assert.AreEqual(getShipToCountryVal, country);
            Report.WriteLine("United States is selected by default in the Shipping To section");
        }

        [Then(@"The Contact Phone number field on Shipping To section will be Phone number formatted")]
        public void ThenTheContactPhoneNumberFieldOnShippingToSectionWillBePhoneNumberFormatted()
        {
            SendKeys(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "1234567890");
            string getShipToPhoneVal = GetAttribute(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "value");
            Assert.AreEqual(getShipToPhoneVal, "(123) 456-7890");
            Report.WriteLine("Contact Phone Number field on Shipping To is phone number formated");
        }

        [Then(@"The Contact Phone Ext\. on Shipping To Section will take a maximum of four numeric values")]
        public void ThenTheContactPhoneExt_OnShippingToSectionWillTakeAMaximumOfFourNumericValues()
        {
            SendKeys(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, contactPhoneExt);
            string getShipToContactFromExtVal = GetAttribute(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipToContactFromExtVal, contactPhoneExt);
            Report.WriteLine("Contact Phone Ext on Shipping To section takes a maximum of 4 numeric numbers");

        }

        [Then(@"The Contact Email field on Shipping To section will be email formatted")]
        public void ThenTheContactEmailFieldOnShippingToSectionWillBeEmailFormatted()
        {
            SendKeys(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "aesr@gmail.com");
            string getShipToContactEmail = GetAttribute(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "value");
            Assert.AreEqual(getShipToContactEmail, "aesr@gmail.com");
            Report.WriteLine("The Contact Email field on Shipping To section is email formatted");
        }

        [Then(@"The Contact Fax field on Shipping To section will be Phone number formatted")]
        public void ThenTheContactFaxFieldOnShippingToSectionWillBePhoneNumberFormatted()
        {
            SendKeys(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "7654567890");
            string getShipToFaxVal = GetAttribute(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "value");
            Assert.AreEqual(getShipToFaxVal, "(765) 456-7890");
            Report.WriteLine("Contact Fax Number field on Shipping To is phone number formated");

        }

        [Then(@"The Contact Fax Ext\. on Shipping To Section will take a maximum of four numeric values")]
        public void ThenTheContactFaxExt_OnShippingToSectionWillTakeAMaximumOfFourNumericValues()
        {
            SendKeys(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, contactFaxExt.ToString());
            string getShipToContactFaxExtVal = GetAttribute(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipToContactFaxExtVal, contactFaxExt);
            Report.WriteLine("Contact Fax Ext on Shipping To section takes a maximum of 4 numeric numbers");

        }

        [Then(@"The Comments field on Shipping To section will take a maximum of (.*) characters")]
        public void ThenTheCommentsFieldOnShippingToSectionWillTakeAMaximumOfCharacters(int shipToComments)
        {
            SendKeys(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja");
            OnMouseOver(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath);
            string getShipToCommentsVal = GetAttribute(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "value");
            Assert.AreEqual(getShipToCommentsVal, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja");
            Report.WriteLine("Comments field on Shipping To section takes a maximum of 250 characters");
        }

        [Then(@"The Contact Phone Ext\. field  of Shipping To Section will not allow more than four numeric values")]
        public void ThenTheContactPhoneExt_FieldOfShippingToSectionWillNotAllowMoreThanFourNumericValues()
        {
            string getShipToContactPhExt = GetAttribute(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "value");
            Assert.AreNotEqual(getShipToContactPhExt, contactPhoneExtension);
            Report.WriteLine("Contact Phone Ext field of Shipping To section does not allow more than 4 numeric values");

        }

        [Then(@"The Contact Phone Ext\. field  of Shipping To Section will allow less than four numeric values")]
        public void ThenTheContactPhoneExt_FieldOfShippingToSectionWillAllowLessThanFourNumericValues()
        {
            string getShipToContactPhExt = GetAttribute(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipToContactPhExt, contactPhoneExten);
            Report.WriteLine("Contact Phone Ext field  of Shipping To section allows less than 4 numeric values");

        }

        [Then(@"The Contact Fax Ext\. field  of Shipping To Section will not allow more than four numeric values")]
        public void ThenTheContactFaxExt_FieldOfShippingToSectionWillNotAllowMoreThanFourNumericValues()
        {
            string getShipToContactFaxExt = GetAttribute(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "value");
            Assert.AreNotEqual(getShipToContactFaxExt, contactFaxExtension);
            Report.WriteLine("Contact Fax Ext field  of Shipping To section does not allow more than 4 numeric values");

        }

        [Then(@"The Contact Fax Ext\. field  of Shipping To Section will allow less than four numeric values")]
        public void ThenTheContactFaxExt_FieldOfShippingToSectionWillAllowLessThanFourNumericValues()
        {
            string getShipToContactFaxExt = GetAttribute(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipToContactFaxExt, contactFaxExten);
            Report.WriteLine("Contact Fax Ext field  of Shipping To section allows less than 4 numeric values");

        }

        [Then(@"The Comments field of Shipping To section will not allow more than (.*) characters")]
        public void ThenTheCommentsFieldOfShippingToSectionWillNotAllowMoreThanCharacters(int commentsValidation)
        {
            OnMouseOver(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath);
            string getShipToCommentsVal = GetAttribute(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "value");
            Assert.AreNotEqual(getShipToCommentsVal, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja43");
            Report.WriteLine("Comments field of Shipping To section does not allow more than 250 characters");

        }

        [Then(@"The Comments field of Shipping To section will allow less than (.*) characters")]
        public void ThenTheCommentsFieldOfShippingToSectionWillAllowLessThanCharacters(int commentValidation)
        {
            OnMouseOver(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath);
            string getShipToCommentsVal = GetAttribute(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, "value");
            Assert.AreEqual(getShipToCommentsVal, "dgsh dhgwdha uydas 7 jdas");
            Report.WriteLine("Comments field of Shipping To section allows less than 250 characters");
        }

        [Then(@"The field with the invalid phone format will be highlighted")]
        public void ThenTheFieldWithTheInvalidPhoneFormatWillBeHighlighted()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The (.*) field will be highlighted")]
        public void ThenTheFieldWillBeHighlighted(string p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
