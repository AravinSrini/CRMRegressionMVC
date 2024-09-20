using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class _76033_AddShipmentLTL2019_ShippingFromSectionElementsSteps : AddShipments
    {
        string contactPhoneExt = "3245";
        string contactFaxExt = "6543";
        string shipFromComments = "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja";
        string contactPhoneExtension = "123456";
        string contactPhoneExten = "123";
        string contactFaxExtension = "87654";
        string contactFaxExten = "432";
        string commentsValidation = "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja43";
        string commentValidation = "dgsh dhgwdha uydas 7 jdas";
        string shipFromInvalidEmail = "awwe.com";
        string shipFromComment = "gyt h";


        [Given(@"I am a shp\.entry, shp\.entrynorates user")]
        public void GivenIAmAShp_EntryShp_EntrynoratesUser()
        {
            string userName = ConfigurationManager.AppSettings["username-NewpageShipEntry"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewpageShipEntry"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("User logged into CRM application");
        }

        [Given(@"I am a sales management, operations, station owner user")]
        public void GivenIAmASalesManagementOperationsStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("User logged into CRM application");
        }

        [Given(@"I am on the Add Shipment \(LTL\) page for an External user")]
        public void GivenIAmOnTheAddShipmentLTLPageForAnExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Report.WriteLine("Clicked on Shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipment_Button_id);
            Report.WriteLine("Clicked on Add Shipment button");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Add Shipment LTL page");
        }


        [Given(@"I am on the Add Shipment \(LTL\) page for an internal user")]
        public void GivenIAmOnTheAddShipmentLTLPageForAnInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AddShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SendKeys(attributeName_xpath, AllCustomerDroppdownSearchBox_Internal_Xpath, "ZZZ - GS Customer Test");
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - GS Customer Test");
            Click(attributeName_xpath, AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            Report.WriteLine("Navigated to Add Shipment LTL page");

        }

        [Given(@"Comments field in the Shipping From section contains more characters than can be displayed in the field")]
        public void GivenCommentsFieldInTheShippingFromSectionContainsMoreCharactersThanCanBeDisplayedInTheField()
        {
            SendKeys(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, shipFromComments);
            Report.WriteLine("Comments field in the Shipping From section contains more characters than can be displayed in the field");

        }

        [Given(@"Comments field in the Shipping From section does not contain more characters than can be displayed in the field")]
        public void GivenCommentsFieldInTheShippingFromSectionDoesNotContainMoreCharactersThanCanBeDisplayedInTheField()
        {
            SendKeys(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, shipFromComment);
            Report.WriteLine("Comments field in the Shipping From section does not contains more characters than the displayed in the field");

        }

        [Given(@"I entered an invalid phone format to Contact Phone field of Shipping From section")]
        public void GivenIEnteredAnInvalidPhoneFormatToContactPhoneFieldOfShippingFromSection()
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
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "yt543");
            Report.WriteLine("Entered an invalid Phone format to Contact Phone field of Shipping From section");
        }

        [Then(@"I will receive an Error message indicating an invalid phone format")]
        public void ThenIWillReceiveAnErrorMessageIndicatingAnInvalidPhoneFormat()
        {
            scrollpagedown();
            Verifytext(attributeName_xpath, ShippingFrom_ErrorMessage_NewScreen_Xpath, "Invalid phone format");
            Report.WriteLine("Error message is displayed indicating an invalid Phone format");
        }

        [Then(@"I will receive an Error message indicating an invalid fax format")]
        public void ThenIWillReceiveAnErrorMessageIndicatingAnInvalidFaxFormat()
        {
            Verifytext(attributeName_xpath, ShippingFrom_FaxError_NewScreen_Xpath, "Invalid fax format");
            Report.WriteLine("Error message is displayed indicating an invalid Fax format");
        }

        [Then(@"I will receive an Error message indicating an invalid email format")]
        public void ThenIWillReceiveAnErrorMessageIndicatingAnInvalidEmailFormat()
        {
            Verifytext(attributeName_xpath, ShippingFrom_EmailError_NewScreen_Xpath, "Invalid email format");
            Report.WriteLine("Error message is displayed indicating an invalid Email format");
        }

        [Given(@"I entered an invalid fax format to Contact fax field of Shipping From section")]
        public void GivenIEnteredAnInvalidFaxFormatToContactFaxFieldOfShippingFromSection()
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
            SendKeys(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "t3-543");
            Report.WriteLine("Entered an invalid Phone format to Contact Fax field of Shipping From section");

        }

        [Given(@"I entered an invalid Email format in the Contact email field of the Shipping From section")]
        public void GivenIEnteredAnInvalidEmailFormatInTheContactEmailFieldOfTheShippingFromSection()
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
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, shipFromInvalidEmail);
            Report.WriteLine("Entered an invalid email to Shipping from section");
        }

        [When(@"I arrive on Add Shipment \(LTL\) page for an external user")]
        public void WhenIArriveOnAddShipmentLTLPageForAnExternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Report.WriteLine("Clicked on Shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddShipment_Button_id);
            Report.WriteLine("Clicked on Add Shipment button");
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Add Shipment LTL page");
        }

        [When(@"I arrive on Add Shipment \(LTL\) page for an internal user")]
        public void WhenIArriveOnAddShipmentLTLPageForAnInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AddShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SendKeys(attributeName_xpath, AllCustomerDroppdownSearchBox_Internal_Xpath, "ZZZ - GS Customer Test");
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - GS Customer Test");
            Click(attributeName_xpath, AddShipmentButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            Report.WriteLine("Navigated to Add Shipment LTL page");
        }

        [When(@"I Pass more than four numeric values to Contact Phone Ext\. field  of Shipping From section")]
        public void WhenIPassMoreThanFourNumericValuesToContactPhoneExt_FieldOfShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, contactPhoneExtension);
            Report.WriteLine("Passed more than 4 numeric values to Contact Phone Ext field of Shipping From section");
        }

        [When(@"I Pass less than four numeric values to Contact Phone Ext\. field  of Shipping From section")]
        public void WhenIPassLessThanFourNumericValuesToContactPhoneExt_FieldOfShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, contactPhoneExten);
            Report.WriteLine("Passed less than 4 numeric values to Contact Phone Ext field of Shipping From section");

        }

        [When(@"I Pass more than four numeric values to Contact Fax Ext\. field  of Shipping From section")]
        public void WhenIPassMoreThanFourNumericValuesToContactFaxExt_FieldOfShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, contactFaxExtension.ToString());
            Report.WriteLine("Passed more than 4 numeric values to Contact Fax Ext field of Shipping From section");
        }

        [When(@"I Pass less than four numeric values to Contact Fax Ext\. field  of Shipping From section")]
        public void WhenIPassLessThanFourNumericValuesToContactFaxExt_FieldOfShippingFromSection()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, contactFaxExten.ToString());
            Report.WriteLine("Passed less than 4 numeric values to Contact Fax Ext field of Shipping From section");
        }

        [When(@"I pass more than (.*) characters to Comments field of Shipping From section")]
        public void WhenIPassMoreThanCharactersToCommentsFieldOfShippingFromSection(int commentsValidation)
        {
            SendKeys(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja43");
            Report.WriteLine("Passed more than 250 characters to Shipping from comments section");
        }

        [When(@"I pass less than (.*) characters to Comments field of Shipping From section")]
        public void WhenIPassLessThanCharactersToCommentsFieldOfShippingFromSection(int commentValidation)
        {
            SendKeys(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "dgsh dhgwdha uydas 7 jdas");
            Report.WriteLine("Passed less than 250 characters to Shipping from comments section");
        }

        [When(@"I hover over the text of Comments field in the Shipping From section")]
        public void WhenIHoverOverTheTextOfCommentsFieldInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath);
            OnMouseOver(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath);
            Report.WriteLine("Hovered over the text in the comments field in the shipping from section");
        }

        [Then(@"I will see the following in the Shipping From Section : '(.*)', '(.*)',  '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenIWillSeeTheFollowingInTheShippingFromSection(string savedOrigin, string clearAddressShipFrom, string shipFronLocationName, string shipFromAddress1, string shipFromAddress2, string shipFromZipCode, string shipFromCountry, string shipFromCity, string shipFromState, string shipFromOriginInfo, string shipFromMap, string shipFromServiceAccessorial, string shipFromComments)
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            VerifyElementPresent(attributeName_xpath, ShippingFrom_SavedOrigin_NewScreen_Xpath, "SavedOrigin");
            string getSavedOriginUI = GetAttribute(attributeName_xpath, ShipppingFrom_SaveOrigin_NewScreen_Xpath, "placeholder");
            Assert.AreEqual(savedOrigin, getSavedOriginUI);
            VerifyElementPresent(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath, "ClearAddress");
            string getClearAddressShipFromUI = Gettext(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Assert.AreEqual(clearAddressShipFrom, getClearAddressShipFromUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "LocationName");
            string getShipFromLocationNameUI = GetAttribute(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFronLocationName, getShipFromLocationNameUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "ShipFromAddress1");
            string getShipFromAddress1UI = GetAttribute(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromAddress1, getShipFromAddress1UI);
            VerifyElementPresent(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "ShipFromAddress2");
            string getShipFromAddress2UI = GetAttribute(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromAddress2, getShipFromAddress2UI);
            VerifyElementPresent(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "Zipcode");
            string getShipFromZipCodeUI = GetAttribute(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromZipCode, getShipFromZipCodeUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_CountryDropDown_NewScreen_Id, "Country");
            VerifyElementPresent(attributeName_id, ShippingFrom_City_NewScreen_Id, "city");
            string getShippingFromCityUI = GetAttribute(attributeName_id, ShippingFrom_City_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromCity, getShippingFromCityUI);
            VerifyElementPresent(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath, "StateOrProvince");
            string getShippingFromStateUI = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(shipFromState, getShippingFromStateUI);
            VerifyElementPresent(attributeName_xpath, ShippingFrom_SaveOriginInfo_Checkbox_Xpath, "SaveOrigin");
            Verifytext(attributeName_xpath, ShippingFrom_SaveOriginInfo_Label_Xpath, "Save Origin Info");
            VerifyElementPresent(attributeName_xpath, ShippingFrom_MapLabel_NewScreen_Xpath, "ShipFromMap");
            Verifytext(attributeName_xpath, ShippingFrom_MapLabel_NewScreen_Xpath, "View Origin on Map");
            VerifyElementPresent(attributeName_xpath, ShippingFrom_Accessorial_Xpath, "ServiceAndAccessorials");
            string getShipFromServiceAccessorialUI = GetAttribute(attributeName_xpath, ShippingFrom_Accessorial_Xpath, "placeholder");
            Assert.AreEqual(shipFromServiceAccessorial, getShipFromServiceAccessorialUI);
            VerifyElementPresent(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "Comments");
            string getShipFromCommentsUI = GetAttribute(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "placeholder");
            Assert.AreEqual(shipFromComments, getShipFromCommentsUI);
            Report.WriteLine("The expected fields are displayed in the Shipping from section of Add Shipment (LTL) page");

        }

        [Then(@"I Will see the following in the Shipping From Contact Info Section : '(.*)', '(.*)', '(.*)', '(.*)', '(.*)', '(.*)'")]
        public void ThenIWillSeeTheFollowingInTheShippingFromContactInfoSection(string shipFromContactName, string shipFromContactPhone, string shipFromContactPhoneExt, string shipFromContactEmail, string shipFromContactFax, string shipFromContactFaxExt)
        {
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "ContactName");
            string getShipFromContactNameUI = GetAttribute(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromContactName, getShipFromContactNameUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "ContactPhone");
            string getShipFromContactPhoneUI = GetAttribute(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromContactPhone, getShipFromContactPhoneUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "ContactPhoneExt");
            string getShipFromContactPhoneExtUI = GetAttribute(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "placeholder");
            Assert.AreEqual("Ext.", getShipFromContactPhoneExtUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "Email");
            string getShipFromContactEmailUI = GetAttribute(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromContactEmail, getShipFromContactEmailUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "ContactFax");
            string getShipFromContactFaxUI = GetAttribute(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "placeholder");
            Assert.AreEqual(shipFromContactFax, getShipFromContactFaxUI);
            VerifyElementPresent(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "ContactFaxExt");
            string getShipFromContactFaxExtUI = GetAttribute(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "placeholder");
            Assert.AreEqual("Ext.", getShipFromContactFaxExtUI);
            Report.WriteLine("The expected fields are displayed in the Shipping from contact information section of Add Shipment (LTL) page");

        }

        [Then(@"I will see the following as required fields - Enter location name\.\.\., Enter location address\.\.\., Enter zip/postal code\.\.\.\., Country, Enter city\.\.\., Select state/province\.\.\.")]
        public void ThenIWillSeeTheFollowingAsRequiredFields_EnterLocationName_EnterLocationAddress_EnterZipPostalCode_CountryEnterCity_SelectStateProvince_()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(3000);
            scrollpagedown();
            Click(attributeName_xpath, Shipping_ViewRates_Xpath);
            scrollPageup();
            string getShipFromLocationNumCSSVal = GetCSSValue(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "background-color");
            Assert.AreEqual(getShipFromLocationNumCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromLocationAddressCSSVal = GetCSSValue(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "background-color");
            Assert.AreEqual(getShipFromLocationAddressCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromZipPostalCSSVal = GetCSSValue(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "background-color");
            Assert.AreEqual(getShipFromZipPostalCSSVal, "rgba(251, 236, 236, 1)");
            Report.WriteLine("The expected required fields are displayed");
        }
        [Then(@"I will see the following as optional fields - Select or search for a saved origin\.\.\., Enter location address line (.*)\.\.\., Save Origin info, Contact name\.\.\., Contact phone\.\.\., Contact phone Ext\., Contact email\.\.\., Contact fax\.\.\., Contact fax Ext\., Click to add services & accessorials\.\.\., Enter comments\.\.\.")]
        public void ThenIWillSeeTheFollowingAsOptionalFields_SelectOrSearchForASavedOrigin_EnterLocationAddressLine_SaveOriginInfoContactName_ContactPhone_ContactPhoneExt_ContactEmail_ContactFax_ContactFaxExt_ClickToAddServicesAccessorials_EnterComments_(int p0)
        {
            string getShipFromSavedOriginCSSVal = GetCSSValue(attributeName_xpath, ShippingFrom_SavedOrigin_NewScreen_Xpath, "background");
            Assert.AreNotEqual(getShipFromSavedOriginCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromLocationAddress2CSSVal = GetCSSValue(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromLocationAddress2CSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromSaveOriginInfoCSSVal = GetCSSValue(attributeName_xpath, ShippingFrom_SaveOriginInfo_Label_Xpath, "background");
            Assert.AreNotEqual(getShipFromSaveOriginInfoCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromContactNameCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromContactNameCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromContactPhoneCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromContactPhoneCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromContactPhoneExtCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromContactPhoneExtCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromContactEmailCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromContactPhoneCSSVal, "rgba(251, 236, 236, 1))");
            string getShipFromContactFaxCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromContactFaxCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromFaxExtCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "background");
            Assert.AreNotEqual(getShipFromFaxExtCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromServiceAccessCSSVal = GetCSSValue(attributeName_id, ShippingFrom_AccessorialDropdown_Id, "background");
            Assert.AreNotEqual(getShipFromServiceAccessCSSVal, "rgba(251, 236, 236, 1)");
            string getShipFromCommentsCSSVal = GetCSSValue(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "background");
            Assert.AreNotEqual(getShipFromCommentsCSSVal, "rgba(251, 236, 236, 1)");
            Report.WriteLine("The expected optional fields are displayed");
        }

        [Then(@"I will see '(.*)' been selected by default on Country field of Shipping From section")]
        public void ThenIWillSeeBeenSelectedByDefaultOnCountryFieldOfShippingFromSection(string country)
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            string getShipFromCountryVal = GetAttribute(attributeName_id, ShippingFrom_CountryDropDown_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromCountryVal, country);
            Report.WriteLine("United States is selected by default in the Shipping From section");
        }

        [Then(@"The Contact Phone number field on Shipping From section will be Phone number formatted")]
        public void ThenTheContactPhoneNumberFieldOnShippingFromSectionWillBePhoneNumberFormatted()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "1234567890");
            string getShipFromPhoneVal = GetAttribute(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromPhoneVal, "(123) 456-7890");
            Report.WriteLine("Contact Phone Number field on Shipping From is phone number formated");
        }

        [Then(@"The Contact Phone Ext\. on Shipping From section will take a Maximum of four numeric values")]
        public void ThenTheContactPhoneExt_OnShippingFromSectionWillTakeAMaximumOfFourNumericValues()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, contactPhoneExt);
            string getShipFromContactFromExtVal = GetAttribute(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromContactFromExtVal, contactPhoneExt);
            Report.WriteLine("Contact Phone Ext on Shipping From section takes a maximum of 4 numeric numbers");
        }

        [Then(@"The Contact Email field on Shipping From section will be email formatted")]
        public void ThenTheContactEmailFieldOnShippingFromSectionWillBeEmailFormatted()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "aesr@gmail.com");
            string getShipFromContactEmail = GetAttribute(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromContactEmail, "aesr@gmail.com");
            Report.WriteLine("The Contact Email field on Shipping From section is email formatted");
        }

        [Then(@"The Contact Fax field on Shipping From section will be Phone number formatted")]
        public void ThenTheContactFaxFieldOnShippingFromSectionWillBePhoneNumberFormatted()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "7654567890");
            string getShipFromFaxVal = GetAttribute(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromFaxVal, "(765) 456-7890");
            Report.WriteLine("Contact Fax Number field on Shipping From is phone number formated");
        }

        [Then(@"The Contact Fax Ext\. on Shipping From section will take a Maximum of four numeric values")]
        public void ThenTheContactFaxExt_OnShippingFromSectionWillTakeAMaximumOfFourNumericValues()
        {
            SendKeys(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, contactFaxExt.ToString());
            string getShipFromContactFaxExtVal = GetAttribute(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromContactFaxExtVal, contactFaxExt);
            Report.WriteLine("Contact Fax Ext on Shipping From section takes a maximum of 4 numeric numbers");
        }

        [Then(@"The Comments field on Shipping From section will take a maximum of (.*) characters")]
        public void ThenTheCommentsFieldOnShippingFromSectionWillTakeAMaximumOfCharacters(string shipFromComments)
        {
            SendKeys(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja");
            OnMouseOver(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath);
            string getShipFromCommentsVal = GetAttribute(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "value");
            Assert.AreEqual(getShipFromCommentsVal, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja");
            Report.WriteLine("Comments field on Shipping From section takes a maximum of 250 characters");
        }

        [Then(@"The Contact Phone Ext\. field  of Shipping From Section will not allow more than four numeric values")]
        public void ThenTheContactPhoneExt_FieldOfShippingFromSectionWillNotAllowMoreThanFourNumericValues()
        {
            string getShipFromContactPhExt = GetAttribute(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "value");
            Assert.AreNotEqual(getShipFromContactPhExt, contactPhoneExtension);
            Report.WriteLine("Contact Phone Ext field  of Shipping From section does not allow more than 4 numeric values");

        }

        [Then(@"The Contact Phone Ext\. field  of Shipping From Section will allow less than four numeric values")]
        public void ThenTheContactPhoneExt_FieldOfShippingFromSectionWillAllowLessThanFourNumericValues()
        {
            string getShipFromContactPhExt = GetAttribute(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromContactPhExt, contactPhoneExten);
            Report.WriteLine("Contact Phone Ext field  of Shipping From section allows less than 4 numeric values");

        }

        [Then(@"The Contact Fax Ext\. field  of Shipping From Section will not allow more than four numeric values")]
        public void ThenTheContactFaxExt_FieldOfShippingFromSectionWillNotAllowMoreThanFourNumericValues()
        {
            string getShipFromContactFaxExt = GetAttribute(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "value");
            Assert.AreNotEqual(getShipFromContactFaxExt, contactFaxExtension);
            Report.WriteLine("Contact Fax Ext field  of Shipping From section does not allow more than 4 numeric values");

        }

        [Then(@"The Contact Fax Ext\. field  of Shipping From Section will allow less than four numeric values")]
        public void ThenTheContactFaxExt_FieldOfShippingFromSectionWillAllowLessThanFourNumericValues()
        {
            string getShipFromContactFaxExt = GetAttribute(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "value");
            Assert.AreEqual(getShipFromContactFaxExt, contactFaxExten);
            Report.WriteLine("Contact Fax Ext field  of Shipping From section allows less than 4 numeric values");

        }

        [Then(@"The Comments field of Shipping From section will not allow more than (.*) characters")]
        public void ThenTheCommentsFieldOfShippingFromSectionWillNotAllowMoreThanCharacters(int commentsValidation)
        {
            OnMouseOver(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath);
            string getShipFromCommentsVal = GetAttribute(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "value");
            Assert.AreNotEqual(getShipFromCommentsVal, "hdas uuewty yerwu 643 htewj %$^&* jwtdw jhrtwedbewur u uyfdwe dew jdgaws uye pqur jdfasj iwqeu gjhdwq 829jddb jhsgd djqwg 90 hjast67 hdsgax yuassa xshxfsax syu dashds vshs cshcscstds cyctsgcsuycsv csyucfvs cusycvaschjasgc scyusgc asnsaasuiysbdjuy hja43");
            Report.WriteLine("Comments field of Shipping From section does not allow more than 250 characters");
        }

        [Then(@"The Comments field of Shipping From section will allow less than (.*) characters")]
        public void ThenTheCommentsFieldOfShippingFromSectionWillAllowLessThanCharacters(int commentValidation)
        {
            OnMouseOver(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath);
            string getShipFromCommentsVal = GetAttribute(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "value");
            Assert.AreEqual(getShipFromCommentsVal, "dgsh dhgwdha uydas 7 jdas");
            Report.WriteLine("Comments field of Shipping From section allows less than 250 characters");
        }

        [Then(@"A popup box will display the entire text")]
        public void ThenAPopupBoxWillDisplayTheEntireText()
        {
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, ShippingFrom_CommentsPopup_Xpath, "Comment Popup");
            string getShipFromMouseHoverCommentsVal = GetAttribute(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, "value");
            Assert.AreEqual(getShipFromMouseHoverCommentsVal, shipFromComments);
            Report.WriteLine("Popup box is displayed with entire text");
        }

        [Then(@"A popup box will not get displayed")]
        public void ThenAPopupBoxWillNotGetDisplayed()
        {
            VerifyElementNotPresent(attributeName_xpath, ShippingFrom_CommentsPopup_Xpath, "Comment Popup");
            Report.WriteLine("No popup box is displayed");
        }

        [Then(@"The field with the invalid phone format will be highlighted in the Ship From section")]
        public void ThenTheFieldWithTheInvalidPhoneFormatWillBeHighlightedInTheShipFromSection()
        {
            string getShipFromContactPhoneCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "border-bottom-color");
            Assert.AreEqual(getShipFromContactPhoneCSSVal, "rgba(209, 211, 212, 1)");
            Report.WriteLine("The field with invalid phone format is highlighted in the Shipping from section");

        }

        [Then(@"The field with the invalid fax format will be highlighted in the Ship From section")]
        public void ThenTheFieldWithTheInvalidFaxFormatWillBeHighlightedInTheShipFromSection()
        {
            string getShipFromContactFaxCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "border-bottom-color");
            Assert.AreEqual(getShipFromContactFaxCSSVal, "rgba(209, 211, 212, 1)");
            Report.WriteLine("The field with invalid fax format is highlighted in the Shipping from section");

        }

        [Then(@"Contact Email field will be highlighted")]
        public void ThenContactEmailFieldWillBeHighlighted()
        {
            string getShipFromContactEmailCSSVal = GetCSSValue(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "border-bottom-color");
            Assert.AreEqual(getShipFromContactEmailCSSVal, "rgba(209, 211, 212, 1)");
            Report.WriteLine("The field with invalid email format is highlighted in the Shipping from section");

        }

    }
}
