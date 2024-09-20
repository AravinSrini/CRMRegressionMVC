using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment__LTL__2019
{
    [Binding]
    public class _76047_Add_Shipment__LTL__2019___Shipping_FromTo___Search_Select_Saved_AddressSteps : AddShipments
    {
        [When(@"I arrive on the (.*) Add Shipment \(LTL\) page for (.*) user")]
        public void WhenIArriveOnTheAddShipmentLTLPageForUser(string Customer, string UserType)
        {

            Report.WriteLine("Click on shipment icon");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ShipmentIcon_Xpath);

            if (UserType.Equals("External"))
            {
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else if (UserType.Equals("Internal"))
            {
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            }
            else
            {
                Click(attributeName_xpath, AllCustomerDropdown_Selection_Internal_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AllCustomerDroppdownValues_Internal_Xpath, Customer);
                Click(attributeName_id, ShipmentList_AddShipmentButtonInternalUser_Id);
            }


            Click(attributeName_id, ShipmentList_LTLtile_Id);
        }

        [Then(@"I have option to select saved address from the Select or search for a saved origin in the Shipping From section")]
        public void ThenIHaveOptionToSelectSavedAddressFromTheSelectOrSearchForASavedOriginInTheShippingFromSection()
        {
            VerifyElementPresent(attributeName_id, AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id, "ShippingFromSavedAddress");
        }

        [When(@"I click the Select or search for a saved origin field in the Shipping From section")]
        public void WhenIClickTheSelectOrSearchForASavedOriginFieldInTheShippingFromSection()
        {
            Report.WriteLine("Clicking on Shipping From address dropdown");
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SavedAdress_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            }

            Click(attributeName_id, ShippingFrom_SavedAdress_Id);
        }

        [Then(@"I should see first hundred saved addresses associated to the customer in ascending order (.*)")]
        public void ThenIShouldSeeFirstHundredSavedAddressesAssociatedToTheCustomerInAscendingOrder(string Customer)
        {

            IList<IWebElement> OriginAddressList = GlobalVariables.webDriver.FindElements(By.XPath(AddShipmentLTL_2019_ShippingFromSavedAddressDropDownValues_xpath));
            List<string> Address_DB = (DBHelper.Get_Addresses(Customer).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            List<string> _OrgAddress = new List<string>();
            foreach (IWebElement element in OriginAddressList)
            {
                _OrgAddress.Add((element.Text).ToString());
            }

            List<string> _OrgAddressUpper = _OrgAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _OrgAddressUpper);
        }

        [Then(@"I should see first hundred saved addresses in the Shipping To section associated to the customer in ascending order (.*)")]
        public void ThenIShouldSeeFirstHundredSavedAddressesInTheShippingToSectionAssociatedToTheCustomerInAscendingOrder(string Customer)
        {
            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(AddShipmentLTL_2019_ShippingToSavedAddressDropDownValues_xpath));
            List<string> Address_DB = (DBHelper.Get_Addresses(Customer).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            List<string> _DestAddress = new List<string>();
            foreach (IWebElement element in DestinationAddressList)
            {
                _DestAddress.Add((element.Text).ToString());
            }

            List<string> _DestAddressUpper = _DestAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _DestAddressUpper);
        }


        [When(@"I enter a value on the Select or search for a saved origin field as (.*) in the Shipping From section")]
        public void WhenIEnterAValueOnTheSelectOrSearchForASavedOriginFieldAsInTheShippingFromSection(string Searchtext)
        {
            Report.WriteLine("Clicking on Shipping From address dropdown");
            string _selectedAddress = GetValue(attributeName_id, AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
            }

            Click(attributeName_id, AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id);
            Report.WriteLine("Entering a search criteria in destination address dropdown");
            SendKeys(attributeName_id, AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id, Searchtext);
        }

        [Then(@"I should see the first hundred saved addresses that contains the value entered (.*),(.*)")]
        public void ThenIShouldSeeTheFirstHundredSavedAddressesThatContainsTheValueEntered(string Customer, string Searchtext)
        {
            List<string> Address_DB = (DBHelper.GetTop100Address_By_searchedhName(Customer, Searchtext).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            IList<IWebElement> OrgAddressList = GlobalVariables.webDriver.FindElements(By.XPath(AddShipmentLTL_2019_ShippingFromSavedAddressDropDownValues_xpath));

            List<string> u = new List<string>();
            for (int i = 1; i <= OrgAddressList.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + i + "]");
                u.Add(k);
            }
            List<string> _OrgAddressUpper = u.ConvertAll(a => a.ToUpper());
            Assert.AreEqual(Address_DB.Count, _OrgAddressUpper.Count);
        }

        [When(@"a saved address is selected from the Select or search for a saved origin field in the Shipping From section")]
        public void WhenASavedAddressIsSelectedFromTheSelectOrSearchForASavedOriginFieldInTheShippingFromSection()
        {
            Report.WriteLine("Clicking on Shipping From address dropdown");
            string _selectedAddress = GetValue(attributeName_id, AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_xpath, ShippingFrom_ClearAddress_Xpath);
                Thread.Sleep(3000);
            }


            Click(attributeName_id, AddShipmentLTL_2019_ShippingFromSavedAddressDropDown_Id);

            IList<IWebElement> OriginAddressList = GlobalVariables.webDriver.FindElements(By.XPath(AddShipmentLTL_2019_ShippingFromSavedAddressDropDownValues_xpath));//Add Xpath of origin address values
            if (OriginAddressList.Count > 0)
            {
                Report.WriteLine("Selecting address from origin saved address dropdown");
                Click(attributeName_xpath, AddShipmentLTL_2019_ShippingFromFirstSavedAddressValue_xpath);
                Thread.Sleep(3000);

            }
            else
            {
                Report.WriteFailure("No Addresses Found in the Origin Address dropdown for the Logged in Usser Account");
            }
        }

        [When(@"a saved address is selected from the Select or search for a saved destination field in the Shipping To section")]
        public void WhenASavedAddressIsSelectedFromTheSelectOrSearchForASavedDestinationFieldInTheShippingToSection()
        {
            Report.WriteLine("Clicking on Shipping From address dropdown");
            string _selectedAddress = GetValue(attributeName_id, AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
                Thread.Sleep(3000);
            }

            Click(attributeName_id, AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id);

            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(AddShipmentLTL_2019_ShippingToSavedAddressDropDownValues_xpath));
            if (DestinationAddressList.Count > 0)
            {
                Click(attributeName_xpath, AddShipmentLTL_2019_ShippingToFirstSavedAddressValue_xpath);
                Thread.Sleep(3000);
            }
            else
            {
                Report.WriteFailure("No Addresses Found in the Destination Address dropdown for the Logged in Usser Account");
            }
        }


        [Then(@"all the fields in the Shipping From section should be auto populated with the saved address information associated to the (.*)")]
        public void ThenAllTheFieldsInTheShippingFromSectionShouldBeAutoPopulatedWithTheSavedAddressInformationAssociatedToThe(string Customer)
        {
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SavedAdress_Id, "value");
            Report.WriteLine("Get the selected Address from Origin Address dropdown");
            string destName = GetValue(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "value");
            string CityUI = GetValue(attributeName_id, ShippingFrom_City_NewScreen_Id, "value");
            string StateUI = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            string CountryUI = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            string ZipUI = GetValue(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "value");

            string ActualComments = GetValue(attributeName_id, ShippingFrom_Comments_NewScreen_Id, "value");

            string ActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "value");
            string ActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "value");
            string ActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "value");
            string ActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "value");

            Address _addressDB = DBHelper.Get_AddressesNameNewScreen(Customer, _selectedAddress, destName);
            Assert.AreEqual((_addressDB.City), CityUI);
            Assert.AreEqual((_addressDB.State), StateUI);
            Assert.AreEqual((_addressDB.Country), CountryUI);
            Assert.AreEqual((_addressDB.Zip), ZipUI);
            Assert.AreEqual((_addressDB.Comment), ActualComments);
            Assert.AreEqual((_addressDB.ContactName), ActualContactName);
            Assert.AreEqual((_addressDB.EmailId), ActualContactEmail);
            Assert.AreEqual((_addressDB.PhoneNumber), ActualContactPhone);
            Assert.AreEqual((_addressDB.FaxNumber), ActualContactFax);
        }

        [Then(@"all the fields in the Shipping To section should be auto populated with the saved address information associated to the (.*)")]
        public void ThenAllTheFieldsInTheShippingToSectionShouldBeAutoPopulatedWithTheSavedAddressInformationAssociatedToThe(string Customer)
        {
            string _selectedAddress = GetValue(attributeName_id, ShippingTo_SavedAdress_Id, "value");
            Report.WriteLine("Get the selected Address from Origin Address dropdown");
            string destName = GetValue(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "value");
            string CityUI = GetValue(attributeName_id, ShippingTo_City_NewScreen_Id, "value");
            string ZipUI = GetValue(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "value");
            string ActualComments = GetValue(attributeName_id, ShippingTo_Comments_NewScreen_Id, "value");
            string StateUI = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            string CountryUI = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);

            string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "value");
            string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "value");
            string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "value");
            string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "value");

            Address _addressDB = DBHelper.Get_AddressesNameNewScreen(Customer, _selectedAddress, destName);
            Assert.AreEqual((_addressDB.City), CityUI);
            Assert.AreEqual((_addressDB.State), StateUI);
            Assert.AreEqual((_addressDB.Country), CountryUI);
            Assert.AreEqual((_addressDB.Zip), ZipUI);
            Assert.AreEqual((_addressDB.Comment), ActualComments);
            Assert.AreEqual((_addressDB.ContactName), ActualContactName);
            Assert.AreEqual((_addressDB.EmailId), ActualContactEmail);
            Assert.AreEqual((_addressDB.PhoneNumber), ActualContactPhone);
            Assert.AreEqual((_addressDB.FaxNumber), ActualContactFax);
        }

        [Then(@"I should be unable to select another saved address in the Shipping To section")]
        public void ThenIShouldBeUnableToSelectAnotherSavedAddressInTheShippingToSection()
        {
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span/span", "Saved Address Expansion");
        }
        
        [Then(@"I should be unable to select another saved address in the Shipping From section")]
        public void ThenIShouldBeUnableToSelectAnotherSavedAddressInTheShippingFromSection()
        {
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span/span", "Saved Address Expansion");
        }

        [Then(@"I have option to select saved address from the Select or search for a saved destination in the Shipping To section")]
        public void ThenIHaveOptionToSelectSavedAddressFromTheSelectOrSearchForASavedDestinationInTheShippingToSection()
        {
            VerifyElementPresent(attributeName_id, AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id, "ShippingToSavedAddress");
        }

        [Then(@"I am able to edit all other fields in the Shipping From section (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIAmAbleToEditAllOtherFieldsInTheShippingFromSection(string Originname, string OriginAddr1, string OriginAddr2, string Originzipcode, string OriginCity, string OriginCountry, string OriginState, string OriginContactName, string OriginContactEmail, string OriginPhoneNumber, string OriginFaxNumber)
        {
            Clear(attributeName_id, ShippingFrom_LocationName_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, Originname);

            string ActualLocationName = GetValue(attributeName_id, ShippingFrom_LocationName_NewScreen_Id, "value");
            Assert.AreEqual(Originname.ToUpper(), ActualLocationName.ToUpper());

            Clear(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, OriginAddr1);

            string ActualAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_NewScreen_Id, "value");
            Assert.AreEqual(OriginAddr1, ActualAddress1);

            Clear(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, OriginAddr2);

            string ActualAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_NewScreen_Id, "value");
            Assert.AreEqual(OriginAddr2, ActualAddress2);

            Click(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_CountryDropDownValues_2019_xpath, OriginCountry);

            string ActualOrgCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(OriginCountry, ActualOrgCountry);

            Clear(attributeName_id, ShippingFrom_zipcode_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, Originzipcode);

            string ActualOrgZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_NewScreen_Id, "value");
            Assert.AreEqual(Originzipcode, ActualOrgZipCode);

            Clear(attributeName_id, ShippingFrom_City_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_City_NewScreen_Id, OriginCity);

            string ActualOrgCity = GetValue(attributeName_id, ShippingFrom_City_NewScreen_Id, "value");
            Assert.AreEqual(OriginCity, ActualOrgCity);

            Click(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_NewScreen_xpath, OriginState);

            string ActualOrgState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(OriginState, ActualOrgState);

            //Clear(attributeName_id, ShippingFrom_Comments_NewScreen_Id);

            //SendKeys(attributeName_id, ShippingFrom_Comments_NewScreen_Id, _comments);

            //string ActualComments = GetValue(attributeName_id, ShippingFrom_Comments_NewScreen_Id, "value");
            //Assert.AreEqual(_comments, ActualComments);

            Clear(attributeName_id, ShippingFrom_ContactName_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, OriginContactName);

            string ActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_NewScreen_Id, "value");
            Assert.AreEqual(OriginContactName, ActualContactName);

            Clear(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, OriginContactEmail);

            string ActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_NewScreen_Id, "value");
            Assert.AreEqual(OriginContactEmail, ActualContactEmail);

            //var _ExpectedContactPhone = string.Format("({0}) {1}-{2}", OriginPhoneNumber.Substring(0, 3), OriginPhoneNumber.Substring(3, 3), OriginPhoneNumber.Substring(6));
            Clear(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, OriginPhoneNumber);

            string ActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_NewScreen_Id, "value");
            Assert.AreEqual(OriginPhoneNumber, ActualContactPhone);

            //var _ExpectedContactFax = string.Format("({0}) {1}-{2}", OriginFaxNumber.Substring(0, 3), OriginFaxNumber.Substring(3, 3), OriginFaxNumber.Substring(6));
            Clear(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id);

            SendKeys(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, OriginFaxNumber);

            string ActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_NewScreen_Id, "value");
            Assert.AreEqual(OriginFaxNumber, ActualContactFax);
        }

        [Then(@"I am able to edit all other fields in the Shipping To section (.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIAmAbleToEditAllOtherFieldsInTheShippingToSection(string Destname, string DestAddr1, string DestAddr2, string Destzipcode, string DestCity, string DestCountry, string DestState, string DestContactName, string DestContactEmail, string DestPhoneNumber, string DestFaxNumber, string DestComments)
        {
            Clear(attributeName_id, ShippingTo_LocationName_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_LocationName_NewScreen_Id, Destname);

            string ActualLocationName = GetValue(attributeName_id, ShippingTo_LocationName_NewScreen_Id, "value");
            Assert.AreEqual(Destname.ToUpper(), ActualLocationName.ToUpper());

            Clear(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, DestAddr1);

            string ActualAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_NewScreen_Id, "value");
            Assert.AreEqual(DestAddr1, ActualAddress1);

            Clear(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, DestAddr2);

            string ActualAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_NewScreen_Id, "value");
            Assert.AreEqual(DestAddr2, ActualAddress2);

            Click(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_CountryDropDownValues_2019_xpath, DestCountry);

            string ActualDestCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_NewScreen_xpath);
            Assert.AreEqual(DestCountry, ActualDestCountry);

            Clear(attributeName_id, ShippingTo_zipcode_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_zipcode_NewScreen_Id, Destzipcode);

            string ActualDestZipCode = GetValue(attributeName_id, ShippingTo_zipcode_NewScreen_Id, "value");
            Assert.AreEqual(Destzipcode, ActualDestZipCode);

            Clear(attributeName_id, ShippingTo_City_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_City_NewScreen_Id, DestCity);

            string ActualDestCity = GetValue(attributeName_id, ShippingTo_City_NewScreen_Id, "value");
            Assert.AreEqual(DestCity, ActualDestCity);

            Click(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_NewScreen_xpath, DestState);

            string ActualDestState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_NewScreen_Xpath);
            Assert.AreEqual(DestState, ActualDestState);

            Clear(attributeName_id, ShippingTo_Comments_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_Comments_NewScreen_Id, DestComments);

            string ActualComments = GetValue(attributeName_id, ShippingTo_Comments_NewScreen_Id, "value");
            Assert.AreEqual(DestComments, ActualComments);


            Clear(attributeName_id, ShippingTo_ContactName_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_ContactName_NewScreen_Id, DestComments);

            string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_NewScreen_Id, "value");
            Assert.AreEqual(DestComments, ActualContactName);

            Clear(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, DestContactEmail);

            string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_NewScreen_Id, "value");
            Assert.AreEqual(DestContactEmail, ActualContactEmail);

            //var _ExpectedContactPhone = string.Format("({0}) {1}-{2}", DestPhoneNumber.Substring(0, 3), DestPhoneNumber.Substring(3, 3), DestPhoneNumber.Substring(6));
            Clear(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, DestPhoneNumber);

            string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_NewScreen_Id, "value");
            Assert.AreEqual(DestPhoneNumber, ActualContactPhone);

            //var _ExpectedContactFax = string.Format("({0}) {1}-{2}", DestFaxNumber.Substring(0, 3), DestFaxNumber.Substring(3, 3), DestFaxNumber.Substring(6));
            Clear(attributeName_id, ShippingTo_ContactFax_NewScreen_Id);

            SendKeys(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, DestFaxNumber);

            string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_NewScreen_Id, "value");
            Assert.AreEqual(DestFaxNumber, ActualContactFax);
        }

        [When(@"I click the Select or search for a saved destination field in the Shipping To section")]
        public void WhenIClickTheSelectOrSearchForASavedDestinationFieldInTheShippingToSection()
        {
            Report.WriteLine("Clicking on Shipping From address dropdown");
            string _selectedAddress = GetValue(attributeName_id, ShippingTo_SavedAdress_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            }

            Click(attributeName_id, ShippingTo_SavedAdress_Id);
        }

        [When(@"I enter a value on the Select or search for a saved destination field as (.*) in the Shipping To section")]
        public void WhenIEnterAValueOnTheSelectOrSearchForASavedDestinationFieldAsInTheShippingToSection(string Searchtext)
        {
            Report.WriteLine("Clicking on Shipping From address dropdown");
            string _selectedAddress = GetValue(attributeName_id, AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_xpath, ShippingTo_ClearAddress_Xpath);
            }

            Click(attributeName_id, AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id);
            Report.WriteLine("Entering a search criteria in destination address dropdown");
            SendKeys(attributeName_id, AddShipmentLTL_2019_ShippingToSavedAddressDropDown_Id, Searchtext);
        }

        [Then(@"I should see the first hundred saved addresses in the Shipping To section that contains the value entered  (.*),(.*)")]
        public void ThenIShouldSeeTheFirstHundredSavedAddressesInTheShippingToSectionThatContainsTheValueEntered(string Customer, string Searchtext)
        {
            List<string> Address_DB = (DBHelper.GetTop100Address_By_searchedhName(Customer, Searchtext).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(AddShipmentLTL_2019_ShippingToSavedAddressDropDownValues_xpath));

            List<string> u = new List<string>();
            for (int i = 1; i <= DestinationAddressList.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div[" + i + "]");
                u.Add(k);
            }

            List<string> _DestAddressUpper = u.ConvertAll(a => a.ToUpper());
            Assert.AreEqual(Address_DB.Count, _DestAddressUpper.Count);
        }



    }
}
