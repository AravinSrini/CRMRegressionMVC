using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class _76046_AddShipmentLTL2019_ShippingFromTo_SaveOriginDestinationInfoSteps : AddShipments
    {
        string customerName = "ZZZ - GS Customer Test";
        string shipFromLocationName = "Chicago"; //unique Ship From location
        string shipFromLocName = "America";
        string shipFromAddressVal = "Test Checking";
        string shipFromAddress = "North" + Guid.NewGuid().ToString();
        string shipFromAddress2 = "mnb";
        string shipFromZipCode = "60606";
        string shipFromCity = "Florida";
        string shipFromStateProvince = "AK";
        string shipFromContactName = "aqzsw";
        string shipFromContactPhone = "5432345678";
        string shipFromContactPhoneExt = "3423";
        string shipFromContactEmail = "dhsa@gmail.com";
        string shipFromContactFax = "6543456765";
        string shipFromContactFaxExt = "9756";
        string shipFromComments = "dhgsaj jdys";
        string shipToLocationName = "Location";// unique Ship To location
        string shipToLocName = "England";
        string shipToAddressVal = "Test";
        string shipToAddress = "South" + Guid.NewGuid().ToString();
        string shipToAddress2 = "mnhb";
        string shipToZipCode = "90001";
        string shipToCity = "qwert";
        string shipToStateProvince = "AK";
        string shipToContactName = "aqzsw";
        string shipToContactPhone = "5432345678";
        string shipToContactPhoneExt = "3423";
        string shipToContactEmail = "dhsa@gmail.com";
        string shipToContactFax = "4537756543";
        string shipToContactFaxExt = "9756";
        string shipToComments = "dhgysaj jdys";
        [Given(@"I entered all required information in the Add Shipment \(LTL\) page")]
        public void GivenIEnteredAllRequiredInformationInTheAddShipmentLTLPage()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(5000);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, shipFromAddress);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, shipToAddress);
            ShipmentDetails();

        }

        [When(@"I Click on the View Rates Button")]
        public void WhenIClickOnTheViewRatesButton()
        {
            Click(attributeName_xpath, Shipping_ViewRates_Xpath);
            Report.WriteLine("Clicked on view rates button");
        }

        [Given(@"I checked the Save Origin info button in the Shipping From section")]
        public void GivenICheckedTheSaveOriginInfoButtonInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_SaveOriginInfo_Label_Xpath);
            Report.WriteLine("Clicked on Save Origin info button in the Shipping From section");
        }

        [Given(@"I checked the Save Destination info button in the Shipping To section")]
        public void GivenICheckedTheSaveDestinationInfoButtonInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingTo_SaveDestinationInfo_Label_Xpath);
            Report.WriteLine("Clicked on Save Destination info button in the Shipping To section");
        }


        [Then(@"CRM will save the following information of Shipping From section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress(.*), ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt")]
        public void ThenCRMWillSaveTheFollowingInformationOfShippingFromSectionAsASavedAddressForTheAssociatedCustomerLocationNameLocationAddressLocationAddressZipOrPostalCountryCityStateOrProvinceContactNameContactPhoneContactPhoneExtContactEmailContactFaxContactFaxExt(int p0)
        {
            Address GetShippingFromAddress = DBHelper.GetShipFromAddressDetails(customerName);
            Assert.AreEqual(shipFromLocationName, GetShippingFromAddress.Name);
            Assert.AreEqual(shipFromAddress, GetShippingFromAddress.Address1);
            Assert.AreEqual(shipFromAddress2, GetShippingFromAddress.Address2);
            Assert.AreEqual(shipFromZipCode, GetShippingFromAddress.Zip);
            Assert.AreEqual("Chicago", GetShippingFromAddress.City);
            Assert.AreEqual("IL", GetShippingFromAddress.State);
            Assert.AreEqual(shipFromContactName, GetShippingFromAddress.ContactName);
            Assert.AreEqual(shipFromContactPhone, GetShippingFromAddress.PhoneNumber);
            Assert.AreEqual(shipFromContactPhoneExt, GetShippingFromAddress.PhoneExt);
            Assert.AreEqual(shipFromContactEmail, GetShippingFromAddress.EmailId);
            Assert.AreEqual(shipFromContactFax, GetShippingFromAddress.FaxNumber);
            Assert.AreEqual(shipFromContactFaxExt, GetShippingFromAddress.FaxExt);
            Assert.AreEqual(shipFromComments, GetShippingFromAddress.Comment);
            Report.WriteLine("Shipping From section address is saved in the database");
        }

        [Then(@"CRM will save the following information of Shipping To section as a saved address for the associated customer: LocationName, LocationAddress, LocationAddress(.*), ZipOrPostal, Country, City, StateOrProvince, ContactName, ContactPhone, ContactPhoneExt, ContactEmail, ContactFax, ContactFaxExt")]
        public void ThenCRMWillSaveTheFollowingInformationOfShippingToSectionAsASavedAddressForTheAssociatedCustomerLocationNameLocationAddressLocationAddressZipOrPostalCountryCityStateOrProvinceContactNameContactPhoneContactPhoneExtContactEmailContactFaxContactFaxExt(int p0)
        {
            Address GetShippingToAddress = DBHelper.GetShipToAddressDetails(customerName);
            Assert.AreEqual(shipToLocationName, GetShippingToAddress.Name);
            Assert.AreEqual(shipToAddress, GetShippingToAddress.Address1);
            Assert.AreEqual(shipToAddress2, GetShippingToAddress.Address2);
            Assert.AreEqual(shipToZipCode, GetShippingToAddress.Zip);
            Assert.AreEqual("Los Angeles", GetShippingToAddress.City);
            Assert.AreEqual("CA", GetShippingToAddress.State);
            Assert.AreEqual(shipToContactName, GetShippingToAddress.ContactName);
            Assert.AreEqual(shipToContactPhone, GetShippingToAddress.PhoneNumber);
            Assert.AreEqual(shipToContactPhoneExt, GetShippingToAddress.PhoneExt);
            Assert.AreEqual(shipToContactEmail, GetShippingToAddress.EmailId);
            Assert.AreEqual(shipToContactFax, GetShippingToAddress.FaxNumber);
            Assert.AreEqual(shipToContactFaxExt, GetShippingToAddress.FaxExt);
            Assert.AreEqual(shipToComments, GetShippingToAddress.Comment);
            Report.WriteLine("Shipping To section address is saved in the database");
        }

        [Given(@"I duplicated already existing saved address details in the Shipping From section")]
        public void GivenIDuplicatedAlreadyExistingSavedAddressDetailsInTheShippingFromSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(4000);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, shipFromAddressVal);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, shipToAddress);
            ShipmentDetails();
        }

        [Given(@"I duplicated already existing saved address details in the Shipping To section")]
        public void GivenIDuplicatedAlreadyExistingSavedAddressDetailsInTheShippingToSection()
        {
            Click(attributeName_xpath, ShippingFrom_ClearAddress_NewScreen_Xpath);
            Click(attributeName_xpath, ShippingTo_ClearAddress_NewScreen_Xpath);
            Thread.Sleep(4000);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, shipFromAddress);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, shipToAddressVal);
            ShipmentDetails();
        }

        [Then(@"A duplicate address will not be saved to CRM_Shipping From section")]
        public void ThenADuplicateAddressWillNotBeSavedToCRM_ShippingFromSection()
        {
            List<Address> ShipFromDuplicateCheck = DBHelper.CheckDuplicateAddressShipFrom(customerName, shipFromLocationName, shipFromAddressVal, shipFromAddress2, shipFromZipCode, "Chicago", "IL", shipFromContactName, shipFromContactPhone, shipFromContactPhoneExt, shipFromContactEmail, shipFromContactFax, shipFromContactFaxExt, shipFromComments);
            if (ShipFromDuplicateCheck.Count >= 2)
            {
                Assert.Fail();
            }
            if (ShipFromDuplicateCheck.Count == 1)
            {
                Report.WriteLine("Duplicate address is not saves to CRM");
            }
        }

        [Then(@"A duplicate address will not be saved to CRM_ShippingTo sectiom")]
        public void ThenADuplicateAddressWillNotBeSavedToCRM_ShippingToSectiom()
        {
            List<Address> ShipToDuplicateCheck = DBHelper.CheckDuplicateAddressShipTo(customerName, shipToLocationName, shipToAddressVal, shipToAddress2, shipToZipCode, "Los Angeles", "CA", shipToContactName, shipToContactPhone, shipToContactPhoneExt, shipToContactEmail, shipToContactFax, shipToContactFaxExt, shipToComments);
            if (ShipToDuplicateCheck.Count >= 2)
            {
                Assert.Fail();
            }
            if (ShipToDuplicateCheck.Count == 1)
            {
                Report.WriteLine("Duplicate address is not saves to CRM");
            }
        }


        public void ShipmentDetails()
        {
            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, shipFromLocationName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, shipFromAddress2);
            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, shipFromZipCode);
            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, shipToLocationName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, shipToAddress2);
            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, shipToZipCode);
            SendKeys(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, shipFromContactName);
            SendKeys(attributeName_id, ShippingTo_ContactName_NewScreen_Id, shipToContactName);
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, shipFromContactPhone);
            SendKeys(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, shipToContactPhone);
            SendKeys(attributeName_id, ShippingFrom_ContactPhoneExt_NewScreen_Id, shipFromContactPhoneExt);
            SendKeys(attributeName_id, ShippingTo_ContactPhoneExt_NewScreen_Id, shipToContactPhoneExt);
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, shipFromContactEmail);
            SendKeys(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, shipToContactEmail);
            SendKeys(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, shipFromContactFax);
            SendKeys(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, shipToContactFax);
            SendKeys(attributeName_id, ShippingFrom_ContactFaxExt_NewScreen_Id, shipFromContactFaxExt);
            SendKeys(attributeName_id, ShippingTo_ContactFaxExt_NewScreen_Id, shipToContactFaxExt);
            scrollpagedown();
            SendKeys(attributeName_xpath, ShippingFrom_CommentsNewScreen_Xpath, shipFromComments);
            SendKeys(attributeName_xpath, ShippingTo_CommentsNewScreen_Xpath, shipToComments);
            Report.WriteLine("All the information is been entered in the Add Shipment (LTL) page");
        }
    }
}
