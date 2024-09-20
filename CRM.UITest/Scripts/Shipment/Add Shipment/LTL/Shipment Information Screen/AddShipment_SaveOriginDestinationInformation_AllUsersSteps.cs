using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class AddShipment_SaveOriginDestinationInformation_AllUsersSteps: AddShipments
    {
        string shippingFromName = null;
        string shippingToName = null;

        [When(@"I check save origin information check box in shipping from location present in add shipment page")]
        public void WhenICheckSaveOriginInformationCheckBoxInShippingFromLocationPresentInAddShipmentPage()
        {
            Report.WriteLine("Checking shipping from save origin location checkbox");
            MoveToElementClick(attributeName_id, ShippingFrom_SaveOrigin_Checkbox_Id);
        }
        
        [When(@"I check save destination information check box in shipping to location present in add shipment page")]
        public void WhenICheckSaveDestinationInformationCheckBoxInShippingToLocationPresentInAddShipmentPage()
        {
            Report.WriteLine("Checking shipping to save origin location checkbox");
            MoveToElementClick(attributeName_id, ShippingFrom_SaveDestination_Checkbox_Id);
        }

        [When(@"I pass unique (.*) (.*) (.*) (.*) in shipping from location info section present in add shipment page")]
        public string WhenIPassUniqueInShippingFromLocationInfoSectionPresentInAddShipmentPage(string account, string oZip, string oName, string oAdd)
        {
            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(account);
            shippingFromName = DBHelper.Check_AddressName_Duplicate(accountDetails.CustomerAccountId, oName);

            Report.WriteLine("Passing data in shipping from section");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, oZip);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, shippingFromName);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, oAdd);
            return shippingFromName;
        }

        [When(@"I pass unique (.*) (.*) (.*) (.*) in shipping to location info section present in add shipment page")]
        public string WhenIPassUniqueInShippingToLocationInfoSectionPresentInAddShipmentPage(string account, string dZip, string dName, string dAdd)
        {
            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(account);
            shippingToName = DBHelper.Check_AddressName_Duplicate(accountDetails.CustomerAccountId, dName);

            Report.WriteLine("Passing data in shipping to section");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, dZip);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, shippingToName);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, dAdd);
            return shippingToName;
        }

        [Then(@"passed shipping from address should be saved in database (.*) (.*) (.*) (.*)")]
        public void ThenPassedShippingFromAddressShouldBeSavedInDatabase(string account, string oZip, string oName, string oAdd)
        {
            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(account);
            List<Address> addDetails = DBHelper.GetAddressesforAccountonName(accountDetails.CustomerAccountId, shippingFromName);
            for (int i = 0; i < addDetails.Count; i++)
            {
                Assert.AreEqual(addDetails[i].Name, shippingFromName);
                Assert.AreEqual(addDetails[i].Address1, oAdd);
                Assert.AreEqual(addDetails[i].Zip, oZip);
                break;
            }
        }
        
        [Then(@"passed shipping to address should be saved in database (.*) (.*) (.*) (.*)")]
        public void ThenPassedShippingToAddressShouldBeSavedInDatabase(string account, string dZip, string dName, string dAdd)
        {
            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(account);
            List<Address> addDetails = DBHelper.GetAddressesforAccountonName(accountDetails.CustomerAccountId, shippingToName);
            for (int i = 0; i < addDetails.Count; i++)
            {
                Assert.AreEqual(addDetails[i].Name, shippingToName);
                Assert.AreEqual(addDetails[i].Address1, dAdd);
                Assert.AreEqual(addDetails[i].Zip, dZip);
                break;
            }
        }

        [Then(@"passed shipping from address should not be saved in database (.*) (.*)")]
        public void ThenPassedShippingFromAddressShouldNotBeSavedInDatabase(string account, string oName)
        {
            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(account);
            List<Address> addDetails = DBHelper.GetAddressesforAccountName(accountDetails.CustomerAccountId, oName);
            if (addDetails.Count == 1)
            {
                Report.WriteLine("Passed duplicate address is not saved in db");
            }
            else
            {
                Report.WriteFailure("Passed duplicate address is saved in db");
            }
        }

        [Then(@"passed shipping to address should not be saved in database (.*) (.*)")]
        public void ThenPassedShippingToAddressShouldNotBeSavedInDatabase(string account, string dName)
        {
            CustomerAccount accountDetails = DBHelper.GetAccountDetails_By_CustomerName(account);
            List<Address> addDetails = DBHelper.GetAddressesforAccountName(accountDetails.CustomerAccountId, dName);
            if (addDetails.Count == 1)
            {
                Report.WriteLine("Passed duplicate address is not saved in db");
            }
            else
            {
                Report.WriteFailure("Passed duplicate address is saved in db");
            }
        }


    }
}
