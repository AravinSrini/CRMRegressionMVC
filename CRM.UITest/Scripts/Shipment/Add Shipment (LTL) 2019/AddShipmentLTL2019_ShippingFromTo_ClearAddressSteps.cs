using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class AddShipmentLTL2019_ShippingFromTo_ClearAddressSteps : AddShipments
    {
        [Given(@"I fill all the empty fileds in shipping From section")]
        public void GivenIFillAllTheEmptyFiledsInShippingFromSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "testoriginname");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "testadd1");
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "testadd2");
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "90001");
            Click(attributeName_id, ShippingFrom_Checkedbox_NewScreen_Id);
            SendKeys(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "testContactName");
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "(222) 222-2222");
            SendKeys(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "(333) 333-3333");
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "test@xyz.com");
            SendKeys(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "444");
            SendKeys(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "555");
            Click(attributeName_xpath, ShippingFrom_Accessorial_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_AccessorialDropdownValues_Xpath, "48278 -Tarping");
            SendKeys(attributeName_id, ShippingFrom_Comments_NewScreen_Id, "testcomment");
        }
        
        [Given(@"I am a operations or station owner user")]
        public void GivenIAmAOperationsOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-NewScreenCrmOperationUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenCrmOperationUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }
        
        [Given(@"I am on the Add Shipment \(LTL\) page for internal user")]
        public void GivenIAmOnTheAddShipmentLTLPageForInternalUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, "ZZZ - Czar Customer Test");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Click(attributeName_id, AddShipmentLTL_Button_Id);
        }
        
        [Given(@"I am a Sales User")]
        public void GivenIAmASalesUser()
        {
            string userName = ConfigurationManager.AppSettings["username-NewScreenSalesUser"].ToString();
            string password = ConfigurationManager.AppSettings["password-NewScreenSalesUser"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }
        
        [Given(@"I am on the Add Shipment \(LTL\) page for sales user")]
        public void GivenIAmOnTheAddShipmentLTLPageForSalesUser()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ShipmentIcon_Id);
            Click(attributeName_xpath, ShipmentListInternal_CustomerDropdown_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectDropdownValueFromList(attributeName_xpath, ShipmentList_CustomerDropdownValues_Xpath, "ZZZ - Czar Customer Test");
            Click(attributeName_id, AddShipmentButtionInternal_Id);
            Click(attributeName_id, AddShipmentLTL_Button_Id);
        }
        
        [Given(@"I fill all the empty fileds in shipping To section")]
        public void GivenIFillAllTheEmptyFiledsInShippingToSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "testdestinationname");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "testadd3");
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "testadd4");
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "90002");
            Click(attributeName_id, ShippingTo_Checkedbox_NewScreen_Id);
            SendKeys(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "testContactName");
            SendKeys(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "(222) 222-2222");
            SendKeys(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "(333) 333-3333");
            SendKeys(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "test@xyz.com");
            SendKeys(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "444");
            SendKeys(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "555");
            Click(attributeName_xpath, ShippingTo_Accessorial_NewScreen_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_AccessorialDropdownValues_Xpath, "48278 -Tarping");
            SendKeys(attributeName_id, ShippingTo_Comments_NewScreen_Id, "testTocomment");
        }
        
        [When(@"I click on the Clear Address button in the Shipping From section")]
        public void WhenIClickOnTheClearAddressButtonInTheShippingFromSection()
        {
            IsElementPresent(attributeName_xpath, ShippingFrom_ClearAddress_Xpath, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            Thread.Sleep(2000);
        }
        
        [When(@"I click on the Clear Address button in the Shipping To section")]
        public void WhenIClickOnTheClearAddressButtonInTheShippingToSection()
        {
            IsElementPresent(attributeName_xpath, ShippingTo_ClearAddress_Xpath, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            Thread.Sleep(2000);
        }
        
        [Then(@"the following fields will be cleared in the Shipping From Section: \(Select or search for a saved origin\.\.\.\),\(Enter location name\.\.\.\),\(Enter location address\.\.\.\),\(Enter location address line (.*)\.\.\.\),\(Enter zip/postal code\.\.\.\),\(Country\) \(default selected \(United States\)\),\(Enter city\.\.\.\),\(Select state/province\.\.\.\),\(Contact name\.\.\.\),\(Contact phone\.\.\.\),\(Contact phone Ext\.\),\(Contact email\.\.\.\),\(Contact fax\.\.\.\),\(Contact fax Ext\.\),\(Click to add services & accessorials\.\.\.\),\(Enter comments\.\.\.\)")]
        public void ThenTheFollowingFieldsWillBeClearedInTheShippingFromSectionSelectOrSearchForASavedOrigin_EnterLocationName_EnterLocationAddress_EnterLocationAddressLine_EnterZipPostalCode_CountryDefaultSelectedUnitedStatesEnterCity_SelectStateProvince_ContactName_ContactPhone_ContactPhoneExt_ContactEmail_ContactFax_ContactFaxExt_ClickToAddServicesAccessorials_EnterComments_(int p0)
        {
            Report.WriteLine("Verifying saved address/address/zip/postal/city/state/province are cleared in the Shipping From section");
            Verifytext(attributeName_id, ShippingFrom_SavedAdress_Id, "");
            Verifytext(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_City_NewScreen_Id, "");
            string defaultcountryvalue = GetValue(attributeName_id, ShippingFrom_CountryDropDown_NewScreen_Id, "value");
            Assert.AreEqual("United States", defaultcountryvalue);
            //Verifytext(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath, "");
            Verifytext(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingFrom_Comments_NewScreen_Id, "");
            Verifytext(attributeName_xpath, ShippingFrom_Accessorial_NewScreen_Xpath, "");
            VerifyElementNotChecked(attributeName_id, ShippingFrom_Checkedbox_NewScreen_Id, "checkbox");
        }
        
        [Then(@"the following fields will be cleared in the Shipping To Section: \(Select or search for a saved origin\.\.\.\),\(Enter location name\.\.\.\),\(Enter location address\.\.\.\),\(Enter location address line (.*)\.\.\.\),\(Enter zip/postal code\.\.\.\),\(Country\) \(default selected \(United States\)\),\(Enter city\.\.\.\),\(Select state/province\.\.\.\),\(Contact name\.\.\.\),\(Contact phone\.\.\.\),\(Contact phone Ext\.\),\(Contact email\.\.\.\),\(Contact fax\.\.\.\),\(Contact fax Ext\.\),\(Click to add services & accessorials\.\.\.\),\(Enter comments\.\.\.\)")]
        public void ThenTheFollowingFieldsWillBeClearedInTheShippingToSectionSelectOrSearchForASavedOrigin_EnterLocationName_EnterLocationAddress_EnterLocationAddressLine_EnterZipPostalCode_CountryDefaultSelectedUnitedStatesEnterCity_SelectStateProvince_ContactName_ContactPhone_ContactPhoneExt_ContactEmail_ContactFax_ContactFaxExt_ClickToAddServicesAccessorials_EnterComments_(int p0)
        {
            Report.WriteLine("Verifying saved address/address/zip/postal/city/state/province are cleared in the Shipping To section");
            Verifytext(attributeName_id, ShippingTo_SavedAdress_Id, "");
            Verifytext(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_City_NewScreen_Id, "");
            string defaultcountryvalue = GetValue(attributeName_id, ShippingTo_CountryDropDown_NewScreen_Id, "value");
            Assert.AreEqual("United States", defaultcountryvalue);
            // Verifytext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath, "United States");
            Verifytext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath, "Select state/province...");
            Verifytext(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "");
            Verifytext(attributeName_id, ShippingTo_Comments_NewScreen_Id, "");
            Verifytext(attributeName_xpath, ShippingTo_Accessorial_NewScreen_Xpath, "");
            VerifyElementNotChecked(attributeName_id, ShippingTo_Checkedbox_NewScreen_Id, "checkbox");
        }
    }
}
