using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using CRM.UITest.CommonMethods;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Text.RegularExpressions;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;
using System.Collections.Specialized;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.AddShipment_PageElements_AllUsers
{
    [Binding]
    public class AddShipmentLTL2019_ShippingFromOrTo_DefaultShipperOrConsigneeSteps : AddShipments
    {
        [When(@"I arrive on the Add Shipment page")]
        public void WhenIArriveOnTheAddShipmentPage()
        {
            Click(attributeName_xpath, AddShipmentIcon_Xpath);
            Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, "ZZZ - Czar Customer Test");
            Click(attributeName_xpath, AddShipmentButton_Xpath);
            Click(attributeName_id, ShipmentServiceTypeLTL_id);
            
        }

        [Then(@"the address information will auto-populate in the following fields in the Shipping From section (.*)")]
        public void ThenTheAddressInformationWillAuto_PopulateInTheFollowingFieldsInTheShippingFromSection(string customerName)
        {
            int accountId = DBHelper.GetCustomerAccountId(customerName);
            string selectedSavedAddress = GetValue(attributeName_id, ShippingFrom_SelectedSavedAddress_Id,"value");
            string adddressName = GetValue(attributeName_id, ShippingFrom_LocationName_NewScreen_Id,"value");
            string address1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "value");
            string address2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "value");
            string zipCode = GetValue(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "value");
            string country = GetValue(attributeName_id, ShippingFrom_CountryDropDown_NewScreen_Id, "value");
            string city = GetValue(attributeName_id, ShippingFrom_City_NewScreen_Id, "value");
            string state = GetValue(attributeName_id, ShippingFrom_StateDropdwon_NewScreen_Id,"value");
            string contactName = GetValue(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "value");
            string contactPhNumber = GetValue(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "value");
            string contactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "value");
            string contactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "value");
            string contactPhNumber_Ext = GetValue(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, "value");
            string contactFax_Ext = GetValue(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, "value");

            Address shippingFromInfo = DBHelper.GetShippingFromData(accountId);
            string selectedSavedshippingToInfoFromDB = BuildSelectedSaveAddressFormatAndAddress(shippingFromInfo);

            Assert.AreEqual(selectedSavedshippingToInfoFromDB, selectedSavedAddress);
            Assert.AreEqual(shippingFromInfo.Name, adddressName);
            Assert.AreEqual(shippingFromInfo.Address1, address1);
            Assert.AreEqual(shippingFromInfo.Zip, zipCode);
            Assert.AreEqual(shippingFromInfo.Country, country);
            Assert.AreEqual(shippingFromInfo.City, city);
            Assert.AreEqual(shippingFromInfo.State, state);
            Assert.AreEqual(shippingFromInfo.ContactName, contactName);
            Assert.AreEqual(shippingFromInfo.PhoneNumber, contactPhNumber);
            Assert.AreEqual(shippingFromInfo.PhoneExt, contactPhNumber_Ext);
            Assert.AreEqual(shippingFromInfo.EmailId, contactEmail);
            Assert.AreEqual(shippingFromInfo.FaxNumber, contactFax);
            Assert.AreEqual(shippingFromInfo.FaxExt, contactFax_Ext);
        }

        [Then(@"the address information will auto-populate in the following fields in the Shipping To section (.*)")]
        public void ThenTheAddressInformationWillAuto_PopulateInTheFollowingFieldsInTheShippingToSection(string customerName)
        {
            int accountId = DBHelper.GetCustomerAccountId(customerName);
            string selectedSavedAddress = GetValue(attributeName_id, ShippingTo_SelectedSavedAddress_Id, "value");
            string adddressName = GetValue(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "value");
            string address1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "value");
            string address2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "value");
            string zipCode = GetValue(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "value");
            //string country = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            string country = GetValue(attributeName_id, ShippingTo_CountryDropDown_NewScreen_Id, "value");
            string city = GetValue(attributeName_id, ShippingTo_City_NewScreen_Id, "value");
            //string state = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            string state = GetValue(attributeName_id, ShippingTo_StateDropdwon_NewScreen_Id, "value");
            string contactName = GetValue(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "value");
            string contactPhNumber = GetValue(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "value");
            string contactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "value");
            string contactFax = GetValue(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "value");
            string contactPhNumber_Ext = GetValue(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, "value");
            string contactFax_Ext = GetValue(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, "value");

            Address shippingToInfo = DBHelper.GetShippingToData(accountId);
            string selectedSavedshippingToInfoFromDB = BuildSelectedSaveAddressFormatAndAddress(shippingToInfo);

            Assert.AreEqual(selectedSavedshippingToInfoFromDB, selectedSavedAddress);
            Assert.AreEqual(shippingToInfo.Name, adddressName);
            Assert.AreEqual(shippingToInfo.Address1, address1);
            Assert.AreEqual(shippingToInfo.Zip, zipCode);
            Assert.AreEqual(shippingToInfo.Country, country);
            Assert.AreEqual(shippingToInfo.City, city);
            Assert.AreEqual(shippingToInfo.State, state);
            Assert.AreEqual(shippingToInfo.ContactName, contactName);
            Assert.AreEqual(shippingToInfo.PhoneNumber, contactPhNumber);
            Assert.AreEqual(shippingToInfo.PhoneExt, contactPhNumber_Ext);
            Assert.AreEqual(shippingToInfo.EmailId, contactEmail);
            Assert.AreEqual(shippingToInfo.FaxNumber, contactFax);
            Assert.AreEqual(shippingToInfo.FaxExt, contactFax_Ext);
        }



        [Then(@"the address information will auto-populate in the following fields in the Shipping From section")]
        public void ThenTheAddressInformationWillAuto_PopulateInTheFollowingFieldsInTheShippingFromSection()
        {
            int accountId = DBHelper.GetCustomerAccountId("ZZZ - Czar Customer Test");
            string selectedSavedAddress = Gettext(attributeName_id, ShippingFrom_SelectedSavedAddress_Id);
            string adddressName = Gettext(attributeName_id, ShippingFrom_LocationName_NewScreen_Id);
            string address1 = Gettext(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id);
            string address2 = Gettext(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id);
            string zipCode = Gettext(attributeName_id, ShippingFrom_zipcode_NewScreen_Id);
            string country = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            string city = Gettext(attributeName_id, ShippingFrom_City_NewScreen_Id);
            string state = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_NewScreen_xpath);
            string contactName = Gettext(attributeName_id, ShippingFrom_ContactName_NewScreen_Id);
            string contactPhNumber = Gettext(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id);
            string contactEmail = Gettext(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id);
            string contactFax = Gettext(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id);
            string contactPhNumber_Ext = Gettext(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id);
            string contactFax_Ext = Gettext(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id);

            Address shippingToInfo = DBHelper.GetShippingToData(accountId);
            //Assert.AreEqual(shippingToInfo.se, adddressName);
            Assert.AreEqual(shippingToInfo.Name, adddressName);
            Assert.AreEqual(shippingToInfo.Address1, address1);
            Assert.AreEqual(shippingToInfo.Zip, zipCode);
            Assert.AreEqual(shippingToInfo.Country, country);
            Assert.AreEqual(shippingToInfo.City, city);
            Assert.AreEqual(shippingToInfo.State, state);
            Assert.AreEqual(shippingToInfo.ContactName, contactName);
            Assert.AreEqual(shippingToInfo.PhoneNumber, contactPhNumber);
            Assert.AreEqual(shippingToInfo.PhoneExt, contactPhNumber_Ext);
            Assert.AreEqual(shippingToInfo.EmailId, contactEmail);
            Assert.AreEqual(shippingToInfo.FaxNumber, contactFax);
            Assert.AreEqual(shippingToInfo.FaxExt, contactFax_Ext);

        }

        [Then(@"the address information will auto-populate in the following fields in the Shipping To section")]
        public void ThenTheAddressInformationWillAuto_PopulateInTheFollowingFieldsInTheShippingToSection()
        {
            int accountId = 5;
            string adddressName = Gettext(attributeName_id, ShippingTo_LocationName_NewScreen_Id);
            string address1 = Gettext(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id);
            string zipCode = Gettext(attributeName_id, ShippingTo_zipcode_NewScreen_Id);
            string country = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            string city = Gettext(attributeName_id, ShippingTo_City_NewScreen_Id);
            string state = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath);
            string contactName = Gettext(attributeName_id, ShippingTo_ContactName_NewScreen_Id);
            string contactPhNumber = Gettext(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id);
            string contactEmail = Gettext(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id);
            string contactFax = Gettext(attributeName_id, ShippingTo_ContactFax_NewScreen_Id);
            string contactPhNumber_Ext = Gettext(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id);
            string contactFax_Ext = Gettext(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id);

            Address shippingFromInfo = DBHelper.GetShippingFromData(accountId);
            Assert.AreEqual(shippingFromInfo.Name, adddressName);
            Assert.AreEqual(shippingFromInfo.Address1, address1);
            Assert.AreEqual(shippingFromInfo.Zip, zipCode);
            Assert.AreEqual(shippingFromInfo.Country, country);
            Assert.AreEqual(shippingFromInfo.City, city);
            Assert.AreEqual(shippingFromInfo.State, state);
            Assert.AreEqual(shippingFromInfo.ContactName, contactName);
            Assert.AreEqual(shippingFromInfo.PhoneNumber, contactPhNumber);
            Assert.AreEqual(shippingFromInfo.EmailId, contactEmail);
            Assert.AreEqual(shippingFromInfo.FaxNumber, contactFax);
            //contactPhNumber_Ext,contactFax_Ext assert needs to add. entity update required for that

        }

        public static string BuildSelectedSaveAddressFormatAndAddress(Address address)
        {
            string selectedSaveAddressFormat = string.Empty;
            string phoneFormat = "(###) ###-####";

            address.Name = address.Name.ToUpper();
            address.PhoneNumber = address.PhoneNumber ==null ? "": Convert.ToInt64(address.PhoneNumber).ToString(phoneFormat);
            address.FaxNumber = address.FaxNumber ==null ? "" :Convert.ToInt64(address.FaxNumber).ToString(phoneFormat);
            address.PhoneExt = address.PhoneExt == null ? "" : address.PhoneExt;
            address.FaxExt = address.FaxExt == null ? "" : address.FaxExt;

             selectedSaveAddressFormat = address != null ? (address.ContactName != null || address.PhoneNumber != null || address.EmailId != null || address.FaxNumber != null) ?
            address.Name + " " + address.Address1 + " " + address.Address2 + " " + address.City + " " + address.State + " " + address.Country + " " + address.Zip + " " + address.ContactName + " " + address.PhoneNumber + " " + address.EmailId + " " + address.FaxNumber
                  : address.Name + " " + address.Address1 + " " + address.Address2 + " " + address.City + " " + address.State + " " + address.Country + " " + address.Zip
                                        : string.Empty;
            return selectedSaveAddressFormat;
        }
    }
}
