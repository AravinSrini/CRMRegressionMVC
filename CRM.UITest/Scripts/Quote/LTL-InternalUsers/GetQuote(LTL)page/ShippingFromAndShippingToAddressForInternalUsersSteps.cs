using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using System.Linq;
using CRM.UITest.Entities.Proxy;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Quote.LTL_InternalUsers.GetQuote_LTL_page
{
    [Binding]
    public class ShippingFromAndShippingToAddressForInternalUsersSteps : ObjectRepository
    {
        [When(@"I select Origin Country as Canada")]
        public void WhenISelectOriginCountryAsCanada()
        {
            Report.WriteLine("Selecting Country as Canada from Origin Country dropdown");
            Click(attributeName_xpath, LTL_OriginCountryDropdown_Xpath);
            Click(attributeName_xpath, LTL_OriginCanadaCountryDropdown_Xpath);
        }


        [Then(@"selected address should be populated in the origin Address fields(.*)")]
        public void ThenSelectedAddressShouldBePopulatedInTheOriginAddressFields(string Customer_Name)
        {
            string _selectedAddress = GetValue(attributeName_id, "txt_OriginAddress_ltlQuote", "value");
            Report.WriteLine("Get the selected Address from Origin Address dropdown");
            string CityUI = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            string StateUI = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
            string CountryUI = Gettext(attributeName_xpath, LTL_OriginCountryDropdown_Xpath);
            string ZipUI = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");

            Address _addressDB = DBHelper.Get_Addresses_Name(Customer_Name, _selectedAddress);
            Assert.AreEqual((_addressDB.City), CityUI);
            Assert.AreEqual((_addressDB.State), StateUI);
            Assert.AreEqual((_addressDB.Country), CountryUI);
            Assert.AreEqual((_addressDB.Zip), ZipUI);
        }

        [Then(@"selected address should be populated in the destination Address fields(.*)")]
        public void ThenSelectedAddressShouldBePopulatedInTheDestinationAddressFields(string Customer_Name)
        {
            string _selectedAddress = GetValue(attributeName_id, "txt_DestinationAddress_ltlQuote", "value");
            Report.WriteLine("Get the selected Address from Destination Address dropdown");
            string CityUI = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            string StateUI = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
            string CountryUI = Gettext(attributeName_xpath, LTL_DestinationCountryDropdownValue_Xpath);
            string ZipUI = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");

            Address _addressDB = DBHelper.Get_Addresses_Name(Customer_Name, _selectedAddress);
            Assert.AreEqual((_addressDB.City), CityUI);
            Assert.AreEqual((_addressDB.State), StateUI);
            Assert.AreEqual((_addressDB.Country), CountryUI);
            Assert.AreEqual((_addressDB.Zip), ZipUI);
        }



        [Then(@"addresses displayed under origin saved addresses should match with database for the Customer Account Name selected(.*)")]
        public void ThenAddressesDisplayedUnderOriginSavedAddressesShouldMatchWithDatabaseForTheCustomerAccountNameSelected(string Customer_Name)
        {
            IList<IWebElement> OriginAddress = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/div/span[1]/span/div/span/div"));
            List<string> Address_DB = DBHelper.Get_Addresses(Customer_Name).ConvertAll(a => a.ToUpper());

            List<string> _originAddress = new List<string>();
            foreach (IWebElement element in OriginAddress)
            {
                _originAddress.Add((element.Text).ToString());
            }

            List<string> _originAddressUpper = _originAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _originAddressUpper);
        }

        [Then(@"addresses displayed under destination saved addresses should match with database for the Customer Account Name selected(.*)")]
        public void ThenAddressesDisplayedUnderDestinationSavedAddressesShouldMatchWithDatabaseForTheCustomerAccountNameSelected(string Customer_Name)
        {
            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(""));
            List<string> Address_DB = DBHelper.Get_Addresses(Customer_Name).ConvertAll(a => a.ToUpper());

            List<string> _DestAddress = new List<string>();
            foreach (IWebElement element in DestinationAddressList)
            {
                _DestAddress.Add((element.Text).ToString());
            }

            List<string> _DestAddressUpper = _DestAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _DestAddressUpper);
        }


        [Then(@"the top hundred addresses displayed under origin saved addresses should match with Database for the Customer Account Name selected(.*)")]
        public void ThenTheTopHundredAddressesDisplayedUnderOriginSavedAddressesShouldMatchWithDatabaseForTheCustomerAccountNameSelected(string Customer_Name)
        {
            IList<IWebElement> OriginAddress = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/div/span[1]/span/div/span/div"));
            List<string> Address_DB = (DBHelper.Get_Addresses(Customer_Name).ConvertAll(a => a.ToUpper())).Take(100).ToList();
            List<string> _originAddress = new List<string>();
            foreach (IWebElement element in OriginAddress)
            {
                _originAddress.Add((element.Text).ToString());
            }

            List<string> _originAddressUpper = _originAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _originAddressUpper);

        }

        [Then(@"the top hundred addresses displayed under destination saved addresses should match with Database for the Customer Account Name selected(.*)")]
        public void ThenTheTopHundredAddressesDisplayedUnderDestinationSavedAddressesShouldMatchWithDatabaseForTheCustomerAccountNameSelected(string Customer_Name)
        {
            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='scrollable-dropdown-menu-Destination']/div/div/span[1]/span"));
            List<string> Address_DB = (DBHelper.Get_Addresses(Customer_Name).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            List<string> _DestAddress = new List<string>();
            foreach (IWebElement element in DestinationAddressList)
            {
                _DestAddress.Add((element.Text).ToString());
            }

            List<string> _DestAddressUpper = _DestAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _DestAddressUpper);
        }



        [Then(@"selected address for the search should be populated in the origin Address fields(.*),(.*)")]
        public void ThenSelectedAddressForTheSearchShouldBePopulatedInTheOriginAddressFields(string Customer_Name, string searchText)
        {

            //Click(attributeName_xpath, FirstSavedOriginAddress);
            Address _address = DBHelper.GetAddress_By_searchedhName(Customer_Name, searchText);

            string ZipUI = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
            string CityUI = GetValue(attributeName_id, LTL_OriginCity_Id, "value");//City field Get value
            string StateUI = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);//State Gettalue
            string CountryUI = Gettext(attributeName_xpath, LTL_OriginCountryDropdown_Xpath);//Country Gettext
            Assert.AreEqual((_address.City), CityUI);
            Assert.AreEqual((_address.State), StateUI);
            Assert.AreEqual((_address.Country), CountryUI);
            Assert.AreEqual((_address.Zip), ZipUI);
        }

        [Then(@"selected address for the search should be populated in the destination Address fields(.*),(.*)")]
        public void ThenSelectedAddressForTheSearchShouldBePopulatedInTheDestinationAddressFields(string Customer_Name, string searchText)
        {
           
            string CityUI = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            string StateUI = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
            string CountryUI = Gettext(attributeName_xpath, LTL_DestinationCountryDropdownValue_Xpath);
            string ZipUI = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");

            Address _addressDB = DBHelper.Get_Addresses_Name(Customer_Name, searchText);
            Assert.AreEqual((_addressDB.City), CityUI);
            Assert.AreEqual((_addressDB.State), StateUI);
            Assert.AreEqual((_addressDB.Country), CountryUI);
            Assert.AreEqual((_addressDB.Zip), ZipUI);
        }

        


        [When(@"I select destination Country as Canada")]
        public void WhenISelectDestinationCountryAsCanada()
        {
            Report.WriteLine("Selecting Country as Canada from destination Country dropdown");
            Click(attributeName_xpath, LTL_DestinationCountryDropdownValue_Xpath);
            Click(attributeName_xpath, LTL_DestinationCanadaCountryDropdown_Xpath);
        }


        [Then(@"the Country will reset to United States in the Shipping To section")]
        public void ThenTheCountryWillResetToUnitedStatesInTheShippingToSection()
        {
            Report.WriteLine("Verifying Country is reset to United States");
            string destinationCountry_UI = Gettext(attributeName_xpath, LTL_DestinationCountryDropdownValue_Xpath);
            Assert.AreEqual("United States", destinationCountry_UI);
        }




        [Then(@"the Country will reset to United States in the Shipping From section")]
        public void ThenTheCountryWillResetToUnitedStatesInTheShippingFromSection()
        {
            Report.WriteLine("Verifying Country is reset to United States");
            string OriginCountry_UI = Gettext(attributeName_xpath, LTL_OriginCountryDropdown_Xpath);
            Assert.AreEqual("United States", OriginCountry_UI);
        }



        [Then(@"shipping saved address dropdown should be binded to default Consignee address for Internal Non-Admin Users")]
        public void ThenShippingSavedAddressDropdownShouldBeBindedToDefaultConsigneeAddressForInternalNon_AdminUsers()
        {
            ScenarioContext.Current.Pending();
        }


        [Then(@"shipping saved address dropdown should be binded to default Shipper address for Internal Non-Admin Users(.*)")]
        public void ThenShippingSavedAddressDropdownShouldBeBindedToDefaultShipperAddressForInternalNon_AdminUsers(string AccountName)
        {
            string text = GetAttribute(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(AccountName);

            var addressFormat = Addvalue.Name + " " + Addvalue.Address1 + " " + Addvalue.Address2 + " " + Addvalue.City + " " + Addvalue.State + " " + " " + Addvalue.Country + " " + Addvalue.Zip + " " + Addvalue.ContactName + " " + Addvalue.PhoneNumber + " " + Addvalue.EmailId + " " + Addvalue.FaxNumber;

            Assert.AreEqual(addressFormat, text);
            Report.WriteLine("Address displaying in saved address dropdown is matching with saved address dropdown value");
        }



        [Then(@"The address information of default Consignee address should auto-populate in the Shipping To section for Internal Non-Admin Users(.*)")]
        public void ThenTheAddressInformationOfDefaultConsigneeAddressShouldAuto_PopulateInTheShippingToSectionForInternalNon_AdminUsers(string AccountName)
        {
          
            Address Addvalue = DBHelper.Get_ConsigneeAddressInternalUsers(AccountName);

            if (Addvalue == null)
            {
                Report.WriteLine("Saved Address of the type shipper does not exists for the logged in user");
                Assert.IsTrue(false);
            }
            else
            {
                var ActualDestinationCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
                Assert.AreEqual(Addvalue.City, ActualDestinationCity);
                Report.WriteLine("Displaying Destination city in UI " + ActualDestinationCity + "is matching with DB value" + Addvalue.City);

                string ActualDestinationState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
                Assert.AreEqual(Addvalue.State, ActualDestinationState);
                Report.WriteLine("Displaying Destination state/province in UI " + ActualDestinationState + "is matching with DB value" + Addvalue.State);

                string ActualDestinationZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), ActualDestinationZipCode.ToUpper());
                Report.WriteLine("Displaying Destination zip/postal in UI " + ActualDestinationZipCode + "is matching with DB value" + Addvalue.Zip);
            }
        }


        [Then(@"Shipping saved address dropdown should be binded to default Consignee address for Internal Non-Admin Users(.*)")]
        public void ThenShippingSavedAddressDropdownShouldBeBindedToDefaultConsigneeAddressForInternalNon_AdminUsers(string AccountName)
        {
            string text = GetAttribute(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");
            Address Addvalue = DBHelper.Get_ConsigneeAddressInternalUsers(AccountName);

            var addressFormat = Addvalue.Name + " " + Addvalue.Address1 + " " + Addvalue.Address2 + " " + Addvalue.City + " " + Addvalue.State + " " + " " + Addvalue.Country + " " + Addvalue.Zip + " " + Addvalue.ContactName + " " + Addvalue.PhoneNumber + " " + Addvalue.EmailId + " " + Addvalue.FaxNumber;

            Assert.AreEqual(addressFormat, text);
            Report.WriteLine("Address displaying in saved address dropdown is matching with saved address dropdown value");
        }


       

        [Then(@"The Shipper address information section should be empty for Internal Non-Admin Users(.*)")]
        public void ThenTheShipperAddressInformationSectionShouldBeEmptyForInternalNon_AdminUsers(string AccountName)
        {
         
            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(AccountName);

            if (Addvalue == null)
            {
                var ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
                Assert.AreEqual(string.Empty, ActualOriginCity);
                Report.WriteLine("City field is empty");

                string ActualOriginState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
                Assert.AreEqual("Select state/province...", ActualOriginState);
                Report.WriteLine("State field is empty");

                string ActualOriginZipCode = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
                Assert.AreEqual(string.Empty, ActualOriginZipCode);
                Report.WriteLine("Zip Field is Empty");
            }
            else
            {
                Report.WriteLine("Saved Address of the type shipper exists for the logged in user");
                Assert.IsTrue(false);
            }

        }


        [Then(@"the address information of default Shipper address should auto-populate in the Shipping From section for Internal Non-Admin Users(.*)")]
        public void ThenTheAddressInformationOfDefaultShipperAddressShouldAuto_PopulateInTheShippingFromSectionForInternalNon_AdminUsers(string AccountName)
        {

            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(AccountName);

            if (Addvalue == null)
            {
                Report.WriteLine("Saved Address of the type shipper does not exists for the logged in user");
                Assert.IsTrue(false);
            }
            else
            {
                var ActualDestinationCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
                Assert.AreEqual(Addvalue.City, ActualDestinationCity);
                Report.WriteLine("Displaying Destination city in UI " + ActualDestinationCity + "is matching with DB value" + Addvalue.City);

                string ActualDestinationState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
                Assert.AreEqual(Addvalue.State, ActualDestinationState);
                Report.WriteLine("Displaying Destination state/province in UI " + ActualDestinationState + "is matching with DB value" + Addvalue.State);

                string ActualDestinationZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), ActualDestinationZipCode.ToUpper());
                Report.WriteLine("Displaying Destination zip/postal in UI " + ActualDestinationZipCode + "is matching with DB value" + Addvalue.Zip);
            }


        }

        [Then(@"The consignee address information section should be empty for Internal Non-Admin Users(.*)")]
        public void ThenTheConsigneeAddressInformationSectionShouldBeEmptyForInternalNon_AdminUsers(string AccountName)
        {
           
            Address Addvalue = DBHelper.Get_ConsigneeAddressInternalUsers(AccountName);

            if (Addvalue == null)
            {
                var ActualDestinationCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
                Assert.AreEqual(string.Empty, ActualDestinationCity);
                Report.WriteLine("City field is empty");

                string ActualDestinationState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
                Assert.AreEqual("Select state/province...", ActualDestinationState);
                Report.WriteLine("State field is empty");

                string ActualDestinationZipCode = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
                Assert.AreEqual(string.Empty, ActualDestinationZipCode);
                Report.WriteLine("Zip Field is Empty");
            }
            else
            {
                Report.WriteLine("Saved Address of the type consignee exists for the logged in user");
                Assert.IsTrue(false);
            }
        }



    }
}
