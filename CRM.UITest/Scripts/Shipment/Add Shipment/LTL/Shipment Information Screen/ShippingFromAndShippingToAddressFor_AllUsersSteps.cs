using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Information_Screen
{
    [Binding]
    public class ShippingFromAndShippingToAddressFor_AllUsersSteps : AddShipments
    {
        [When(@"I have click on Add Shipment button based on User Type(.*)")]
        public void WhenIHaveClickOnAddShipmentButtonBasedOnUserType(string UserType)
        {
            if (UserType == "External")
            {
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Click on Add shipment button");
                Click(attributeName_id, ShipmentList_AddShipmentButton_Id);
            }
            else
            {
                Report.WriteLine("Click on Add shipment button");
                Click(attributeName_id, "shipment-list");
                GlobalVariables.webDriver.WaitForPageLoad();
            }

        }

        [When(@"I Click on LTL Tile page")]
        public void WhenIClickOnLTLTilePage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, "btn_ltl");
        }

        [When(@"I will be navigated to Add Shipment LTL page")]
        public void WhenIWillBeNavigatedToAddShipmentLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[1]/div[1]/div/div/div[1]/h1", "Add Shipment (LTL)");
        }

        [When(@"I enter zip code (.*) and leave focus from the origin section in shipment request process")]
        public void WhenIEnterZipCodeAndLeaveFocusFromTheOriginSectionInShipmentRequestProcess(string Zip)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Entering origin zipcode");
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, Zip);
            Click(attributeName_id, ShippingFrom_City_Id);
        }

        [Then(@"City (.*) and State (.*) fields should be populated in origin section in shipment request process")]
        public void ThenCityAndStateFieldsShouldBePopulatedInOriginSectionInShipmentRequestProcess(string City, string State)
        {

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verify the populated data in origin city and state fields");
            string ActualCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            Assert.AreEqual(City, ActualCity);

            string ActualState = Gettext(attributeName_xpath, ".//*[@id='state_origin_select_chosen']/a");
            Assert.AreEqual(State, ActualState);
        }

        [Then(@"I will be able to edit the city in shipping from section(.*) in shipment request process")]
        public void ThenIWillBeAbleToEditTheCityInShippingFromSectionInShipmentRequestProcess(string City)
        {
            Report.WriteLine("Verifying functionality ability to edit the city in shipping from section");
            Clear(attributeName_id, ShippingFrom_City_Id);
            SendKeys(attributeName_id, ShippingFrom_City_Id, City);
            string UICity = GetAttribute(attributeName_id, ShippingFrom_City_Id, "value");
            Assert.AreEqual(City, UICity);
        }

        [Then(@"I will have the option to select a state from the state drop down list in shipping from section(.*) in shipment request process")]
        public void ThenIWillHaveTheOptionToSelectAStateFromTheStateDropDownListInShippingFromSectionInShipmentRequestProcess(string State)
        {
            Report.WriteLine("Selecting Origin State from Origin State dropdown");
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_StateDropdwon_Values_xpath, State);
        }

        [When(@"I enter zip code (.*) and leave focus from the destination section in shipment request process")]
        public void WhenIEnterZipCodeAndLeaveFocusFromTheDestinationSectionInShipmentRequestProcess(string Zip)
        {
            Report.WriteLine("Entering destination zipcode");
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, Zip);
            scrollPageup();
            Click(attributeName_id, ShippingFrom_City_Id);
        }

        [Then(@"City (.*) and State (.*) fields should be populated in destination section in shipment request process")]
        public void ThenCityAndStateFieldsShouldBePopulatedInDestinationSectionInShipmentRequestProcess(string City, string State)
        {
            Thread.Sleep(1000);
            Report.WriteLine("Verify the populated data in destination city and state fields");
            string ActualCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            Assert.AreEqual(City, ActualCity);

            string ActualState = Gettext(attributeName_xpath, "//*[@id='state_destination_select_chosen']/a");
            Assert.AreEqual(State, ActualState);
        }

        [Then(@"I will be able to edit the city in shipping to section(.*) in shipment request process")]
        public void ThenIWillBeAbleToEditTheCityInShippingToSectionInShipmentRequestProcess(string City)
        {
            Report.WriteLine("Verifying functionality ability to edit the city in shipping to section");
            Clear(attributeName_id, ShippingTo_City_Id);
            SendKeys(attributeName_id, ShippingTo_City_Id, City);
            string UICity = GetAttribute(attributeName_id, ShippingTo_City_Id, "value");
            Assert.AreEqual(City, UICity);
        }

        [Then(@"I will have the option to select a state from the state drop down list in shipping to section(.*) in shipment request process")]
        public void ThenIWillHaveTheOptionToSelectAStateFromTheStateDropDownListInShippingToSectionInShipmentRequestProcess(string State)
        {
            Report.WriteLine("Selecting Destination State from Destination State dropdown");
            Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_StateDropdwon_Values_xpath, State);
        }

        [Then(@"background color of the origin zip code text box should turn red and error message should be displayed in shipment request process")]
        public void ThenBackgroundColorOfTheOriginZipCodeTextBoxShouldTurnRedAndErrorMessageShouldBeDisplayedInShipmentRequestProcess()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, ShippingFrom_zipcode_Id, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"Origin City and State will not Auto populate  in shipment request process")]
        public void ThenOriginCityAndStateWillNotAutoPopulateInShipmentRequestProcess()
        {
            Report.WriteLine("Verifying Origin City is not Auto populating");
            string ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            if (string.IsNullOrEmpty(ActualOriginCity))
            {
                Report.WriteLine("Verified Origin City is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Origin City is Auto populated with for incorrect Zipcode");
                throw new Exception("Verified Origin City is Auto populated with for incorrect Zipcode");
            }

            Report.WriteLine("Verifying Origin State is not Auto populating");
            string ActualOriginState = GetValue(attributeName_xpath, ShippingFrom_StateDropdwon_xpath, "value");
            if (string.IsNullOrEmpty(ActualOriginState))
            {
                Report.WriteLine("Verified Origin State is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Origin State is Auto populated for incorrect Zipcode");
                throw new Exception("Verified Origin State is Auto populated for incorrect Zipcode");
            }
        }

        [Then(@"background color of the destination zip code text box should turn red and error message should be displayed in shipment request process")]
        public void ThenBackgroundColorOfTheDestinationZipCodeTextBoxShouldTurnRedAndErrorMessageShouldBeDisplayedInShipmentRequestProcess()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, ShippingTo_zipcode_Id, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"Destination City and State will not Auto populate in shipment request process")]
        public void ThenDestinationCityAndStateWillNotAutoPopulateInShipmentRequestProcess()
        {
            Report.WriteLine("Verifying Origin City is not Auto populating");
            string ActualDestCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            if (string.IsNullOrEmpty(ActualDestCity))
            {
                Report.WriteLine("Verified Destination City is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Destination City is Auto populated with for incorrect Zipcode");
                throw new Exception("Verified Destination City is Auto populated with for incorrect Zipcode");
            }

            Report.WriteLine("Verifying Destination State is not Auto populating");
            string ActualDestState = GetValue(attributeName_xpath, ShippingTo_StateDropdwon_xpath, "value");
            if (string.IsNullOrEmpty(ActualDestState))
            {
                Report.WriteLine("Verified Destination State is not Auto populated for incorrect Zipcode");
            }
            else
            {
                Report.WriteLine("Verified Destination State is Auto populated for incorrect Zipcode");
                throw new Exception("Verified Destination State is Auto populated for incorrect Zipcode");
            }
        }

        [When(@"I select Canada Country from destination country drop down  in shipment request process")]
        public void WhenISelectCanadaCountryFromDestinationCountryDropDownInShipmentRequestProcess()
        {
            Report.WriteLine("Selecting Country as Canada from Destination Country dropdown");
            Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            Click(attributeName_xpath, ShippingTo_CanadaCountryDropdown_Xpath);
        }


        [Then(@"the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section  in shipment request process")]
        public void ThenTheSelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSectionInShipmentRequestProcess()
        {
            Report.WriteLine("Verifying drop down list will be populated with a list of Canada provinces in Shipping To section");
            Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            IList<IWebElement> Destination_StateProvince_UI_list = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_StateDropdwon_Values_xpath));
            List<string> Origin_StateProvince_UI = Destination_StateProvince_UI_list.Skip(1).Select(c => c.Text).ToList();
            List<string> Origin_StateProvince_list = new List<string>
           {
               "AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"
           };
            CollectionAssert.AreEqual(Origin_StateProvince_UI, Origin_StateProvince_list);
        }

        [When(@"I select Canada Country from origin country drop down  in shipment request process")]
        public void WhenISelectCanadaCountryFromOriginCountryDropDownInShipmentRequestProcess()
        {
            Report.WriteLine("Selecting Country as Canada from Origin Country dropdown");
            Click(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            Click(attributeName_xpath, ShippingFrom_CanadaCountryDropdown_Xpath);
        }

        [Then(@"the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section in shipment request process")]
        public void ThenTheSelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSectionInShipmentRequestProcess()
        {
            Report.WriteLine("Verifying drop down list will be populated with a list of Canada provinces in Shipping From section");
            Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            IList<IWebElement> Origin_StateProvince_UI_list = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_StateDropdwon_Values_xpath));
            List<string> Origin_StateProvince_UI = Origin_StateProvince_UI_list.Skip(1).Select(c => c.Text).ToList();
            List<string> Origin_StateProvince_list = new List<string>
           {
               "AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"
           };
            CollectionAssert.AreEqual(Origin_StateProvince_UI, Origin_StateProvince_list);
        }




        [When(@"I have select any Customer Account from the drop down(.*),(.*)")]
        public void WhenIHaveSelectAnyCustomerAccountFromTheDropDown(string UserType, string Customer_Name)
        {
            Report.WriteLine("Click on Add shipment button");
            if (UserType == "Internal")
            {
                Click(attributeName_xpath, ShipmentList_Customer_dropdown_Xpath);

                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ShipmentList_Customer_dropdownValue_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == Customer_Name)
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                Thread.Sleep(500);

                WaitForElementNotVisible(attributeName_xpath, "(//span[@class='style-spin fa fa-spinner fa-spin fa-3x fa-fw'])", "MVC5 Loading Symbol");
            } 

        }

        [Then(@"the top Hundred Address loaded for the entered search(.*),(.*)")]
        public void ThenTheTopHundredAddressLoadedForTheEnteredSearch(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"the top Hundred Address loaded in the destination dropdown for the entered search(.*),(.*)")]
        public void ThenTheTopHundredAddressLoadedInTheDestinationDropdownForTheEnteredSearch(string Customer_Name, string searchText)
        {

            Thread.Sleep(1000);
            List<string> Address_DB = (DBHelper.GetTop100Address_By_searchedhName(Customer_Name, searchText).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_SelectSavedDestDropDown_Values_xpath));
            
            List<string> u = new List<string>();
            for (int i = 1; i <= DestinationAddressList.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span/div/span/div[" + i + "]");
                u.Add(k);
            }
            
            List<string> _DestAddressUpper = u.ConvertAll(a => a.ToUpper());
            Assert.AreEqual(Address_DB.Count, _DestAddressUpper.Count);
        }


        [When(@"I have selected services and accessorials from the origin section(.*)")]
        public void WhenIHaveSelectedServicesAndAccessorialsFromTheOriginSection(string Accessorials)
        {
            Click(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_Values_xpath, Accessorials);
        }
        

        [When(@"I have selected services and accessorials from the destination section(.*)")]
        public void WhenIHaveSelectedServicesAndAccessorialsFromTheDestinationSection(string Accessorials)
        {
            Click(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_Values_xpath, Accessorials);
        }


        [Then(@"the address information of default Shipper address should auto-populate in the Shipping From section of Shipments(.*)")]
        public void ThenTheAddressInformationOfDefaultShipperAddressShouldAuto_PopulateInTheShippingFromSectionOfShipments(string Customer_Name)
        {
            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(Customer_Name);

            if (Addvalue == null)
            {
                Report.WriteLine("Saved Address of the type shipper does not exists for the logged in user");
                Assert.IsTrue(false);
            }
            else
            {
                string ActualLocationName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
                Assert.AreEqual(Addvalue.Name, ActualLocationName);
                Report.WriteLine("Displaying Shipping From Location Name in UI " + ActualLocationName + "is matching with DB value" + Addvalue.Name);

                string ActualAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
                Assert.AreEqual(Addvalue.Address1, ActualAddress1);
                Report.WriteLine("Displaying Shipping From Address1 in UI " + ActualAddress1 + "is matching with DB value" + Addvalue.Address1);

                string ActualAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
                Assert.AreEqual(Addvalue.Address2, ActualAddress2);
                Report.WriteLine("Displaying Shipping From Address2 in UI " + ActualAddress2 + "is matching with DB value" + Addvalue.Address2);


                string ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
                Assert.AreEqual(Addvalue.City, ActualOriginCity);
                Report.WriteLine("Displaying Shipping From city in UI " + ActualOriginCity + "is matching with DB value" + Addvalue.City);

                string ActualOriginState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
                Assert.AreEqual(Addvalue.State, ActualOriginState);
                Report.WriteLine("Displaying Shipping From state/province in UI " + ActualOriginState + "is matching with DB value" + Addvalue.State);

                string ActualOriginZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), ActualOriginZipCode.ToUpper());
                Report.WriteLine("Displaying Shipping From zip/postal in UI " + ActualOriginZipCode + "is matching with DB value" + Addvalue.Zip);

                string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                Assert.AreEqual(Addvalue.Country, ActualOriginCountry);
                Report.WriteLine("Displaying Shipping From Country in UI " + ActualOriginCountry + "is matching with DB value" + Addvalue.Country);

                string ActaulComments = GetValue(attributeName_id, ShippingFrom_Comments_Id, "value");
                Assert.AreEqual(Addvalue.Comment, ActaulComments);
                Report.WriteLine("Displaying Shipping From Comments in UI " + ActaulComments + "is matching with DB value" + Addvalue.Comment);

                if (Addvalue.ContactName != "" || Addvalue.EmailId != "" || Addvalue.PhoneNumber != "" || Addvalue.FaxNumber != "")
                {

                    Report.WriteLine("Verifying for the Shipping From Contact Information sections are expanded");
                    VerifyElementVisible(attributeName_id, ShippingFrom_ContactName_Id, "Shipping from Contact Name");
                    VerifyElementVisible(attributeName_id, ShippingFrom_ContactEmail_Id, "Shipping from Contact Email");
                    VerifyElementVisible(attributeName_id, ShippingFrom_ContactPhone_Id, "Shipping from Contact Phone");
                    VerifyElementVisible(attributeName_id, ShippingFrom_ContactFax_Id, "Shipping from Contact Fax");


                    string ActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                    Assert.AreEqual(Addvalue.ContactName, ActualContactName);
                    Report.WriteLine("Displaying Shipping From Contact Name in UI " + ActualContactName + "is matching with DB value" + Addvalue.ContactName);

                    string ActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                    Assert.AreEqual(Addvalue.EmailId, ActualContactEmail);
                    Report.WriteLine("Displaying Shipping From Contact Email in UI " + ActualContactEmail + "is matching with DB value" + Addvalue.EmailId);

                    string ActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                    Assert.AreEqual(Addvalue.PhoneNumber, ActualContactPhone);
                    Report.WriteLine("Displaying Shipping From Contact Phone in UI " + ActualContactPhone + "is matching with DB value" + Addvalue.PhoneNumber);

                    string ActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                    Assert.AreEqual(Addvalue.FaxNumber, ActualContactFax);
                    Report.WriteLine("Displaying Shipping From Contact Fax in UI " + ActualContactFax + "is matching with DB value" + Addvalue.FaxNumber);
                }
            }
        }

        [Then(@"The address information of default Consignee address should auto-populate in the Shipping To section of Shipments(.*)")]
        public void ThenTheAddressInformationOfDefaultConsigneeAddressShouldAuto_PopulateInTheShippingToSectionOfShipments(string Customer_Name)
        {
            Address Addvalue = DBHelper.Get_ConsigneeAddressInternalUsers(Customer_Name);

            if (Addvalue == null)
            {
                Report.WriteLine("Saved Address of the type Consignee does not exists for the logged in user");
                Assert.IsTrue(false);
            }
            else
            {
                string ActualLocationName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
                Assert.AreEqual(Addvalue.Name, ActualLocationName);
                Report.WriteLine("Displaying Shipping To Location Name in UI " + ActualLocationName + "is matching with DB value" + Addvalue.Name);

                string ActualAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
                Assert.AreEqual(Addvalue.Address1, ActualAddress1);
                Report.WriteLine("Displaying Shipping To Address1 in UI " + ActualAddress1 + "is matching with DB value" + Addvalue.Address1);

                string ActualAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
                Assert.AreEqual(Addvalue.Address2, ActualAddress2);
                Report.WriteLine("Displaying Shipping To Address2 in UI " + ActualAddress2 + "is matching with DB value" + Addvalue.Address2);


                string ActualDestCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
                Assert.AreEqual(Addvalue.City, ActualDestCity);
                Report.WriteLine("Displaying Shipping To city in UI " + ActualDestCity + "is matching with DB value" + Addvalue.City);

                string ActualDestState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
                Assert.AreEqual(Addvalue.State, ActualDestState);
                Report.WriteLine("Displaying Shipping To state/province in UI " + ActualDestState + "is matching with DB value" + Addvalue.State);

                string ActualDestZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
                Assert.AreEqual(Addvalue.Zip.ToUpper(), ActualDestZipCode.ToUpper());
                Report.WriteLine("Displaying Shipping To zip/postal in UI " + ActualDestZipCode + "is matching with DB value" + Addvalue.Zip);

                string ActualDestCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                Assert.AreEqual(Addvalue.Country, ActualDestCountry);
                Report.WriteLine("Displaying Shipping To Country in UI " + ActualDestCountry + "is matching with DB value" + Addvalue.Country);

                string ActaulComments = GetValue(attributeName_id, ShippingTo_Comments_Id, "value");
                Assert.AreEqual(Addvalue.Comment, ActaulComments);
                Report.WriteLine("Displaying Shipping To Comments in UI " + ActaulComments + "is matching with DB value" + Addvalue.Comment);
                

                if (Addvalue.ContactName != "" || Addvalue.EmailId != "" || Addvalue.PhoneNumber != "" || Addvalue.FaxNumber != "")
                {
                    Report.WriteLine("Verifying for the Shipping To Contact Information sections are expanded");
                    VerifyElementVisible(attributeName_id, ShippingTo_ContactName_Id, "Shipping from Contact Name");
                    VerifyElementVisible(attributeName_id, ShippingTo_ContactEmail_Id, "Shipping from Contact Email");
                    VerifyElementVisible(attributeName_id, ShippingTo_ContactPhone_Id, "Shipping from Contact Phone");
                    VerifyElementVisible(attributeName_id, ShippingTo_ContactFax_Id, "Shipping from Contact Fax");
                }
                string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
                Assert.AreEqual(Addvalue.ContactName, ActualContactName);
                Report.WriteLine("Displaying Shipping To Contact Name in UI " + ActualContactName + "is matching with DB value" + Addvalue.ContactName);

                string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
                Assert.AreEqual(Addvalue.EmailId, ActualContactEmail);
                Report.WriteLine("Displaying Shipping To Contact Email in UI " + ActualContactEmail + "is matching with DB value" + Addvalue.EmailId);

                string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
                Assert.AreEqual(Addvalue.PhoneNumber, ActualContactPhone);
                Report.WriteLine("Displaying Shipping To Contact Phone in UI " + ActualContactPhone + "is matching with DB value" + Addvalue.PhoneNumber);

                string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
                Assert.AreEqual(Addvalue.FaxNumber, ActualContactFax);
                Report.WriteLine("Displaying Shipping To Contact Fax in UI " + ActualContactFax + "is matching with DB value" + Addvalue.FaxNumber);
                
            }
        }

        [Then(@"The Shipper address information section should be empty for Shipments(.*)")]
        public void ThenTheShipperAddressInformationSectionShouldBeEmptyForShipments(string Customer_Name)
        {
            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(Customer_Name);

            if (Addvalue == null)
            {
                string ActualLocationName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
                Assert.AreEqual(string.Empty, ActualLocationName);
                Report.WriteLine("LocationName field is empty");


                string ActualAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
                Assert.AreEqual(string.Empty, ActualAddress1);
                Report.WriteLine("Address1 field is empty");


                string ActualAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
                Assert.AreEqual(string.Empty, ActualAddress2);
                Report.WriteLine("Address2 field is empty");


                string ActualOriginCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
                Assert.AreEqual(string.Empty, ActualOriginCity);
                Report.WriteLine("City field is empty");


                string ActualOriginState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
                Assert.AreEqual("Select state/province...", ActualOriginState);
                
                string ActualOriginZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
                Assert.AreEqual(string.Empty, ActualOriginZipCode);
                Report.WriteLine("Zip field is empty");


                string ActualOriginCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
                Assert.AreEqual("United States", ActualOriginCountry);


                string ActualComments = GetValue(attributeName_id, ShippingFrom_Comments_Id, "value");
                Assert.AreEqual(string.Empty, ActualComments);
                Report.WriteLine("Shipping from Comments field is empty");

                Click(attributeName_xpath, ShippingFrom_ContactInfo_Expand_xpath);
                Thread.Sleep(1000);
                WaitForElementVisible(attributeName_id, ShippingFrom_ContactName_Id, "Shipping from Contact Name");


                string ActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactName);
                Report.WriteLine("ContactName field is empty");


                string ActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactEmail);
                Report.WriteLine("ContactEmail field is empty");

                string ActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactPhone);
                Report.WriteLine("ContactPhone field is empty");


                string ActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactFax);
                Report.WriteLine("Fax field is empty");
            }
            else
            {
                Report.WriteLine("Saved Address of the type shipper exists for the logged in user");
                Assert.IsTrue(false);
            }
        }

        [Then(@"The consignee address information section should be empty for Shipments(.*)")]
        public void ThenTheConsigneeAddressInformationSectionShouldBeEmptyForShipments(string Customer_Name)
        {
            Address Addvalue = DBHelper.Get_ConsigneeAddressInternalUsers(Customer_Name);

            if (Addvalue == null)
            {
                string ActualLocationName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
                Assert.AreEqual(string.Empty, ActualLocationName);
                Report.WriteLine("LocationName field is empty");

                string ActualAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
                Assert.AreEqual(string.Empty, ActualAddress1);
                Report.WriteLine("Address1 field is empty");

                string ActualAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
                Assert.AreEqual(string.Empty, ActualAddress2);
                Report.WriteLine("Address2 field is empty");

                string ActualDestCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
                Assert.AreEqual(string.Empty, ActualDestCity);
                Report.WriteLine("City field is empty");

                string ActualDestState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
                Assert.AreEqual("Select state/province...", ActualDestState);
                
                string ActualDestZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
                Assert.AreEqual(string.Empty, ActualDestZipCode);
                Report.WriteLine("Zip field is empty");

                string ActualDestCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                Assert.AreEqual("United States", ActualDestCountry);

                Click(attributeName_xpath, ShippingTo_ContactInfo_Expand_xpath);
                Thread.Sleep(1000);
                WaitForElementVisible(attributeName_id, ShippingTo_ContactName_Id, "Shipping To Contact Name");

                string ActualComments = GetValue(attributeName_id, ShippingTo_Comments_Id, "value");
                Assert.AreEqual(string.Empty, ActualComments);
                Report.WriteLine("Shipping To Comments field is empty");


                string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactName);
                Report.WriteLine("ContactName field is empty");

                string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactEmail);
                Report.WriteLine("ContactEmail field is empty");

                string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactPhone);
                Report.WriteLine("ContactPhone field is empty");

                string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
                Assert.AreEqual(string.Empty, ActualContactFax);
                Report.WriteLine("Fax field is empty");

            }
            else
            {
                Report.WriteLine("Saved Address of the type consignee exists for the logged in user");
                Assert.IsTrue(false);
            }
        }

        [When(@"I click on origin saved address dropdown of the Shipment")]
        public void WhenIClickOnOriginSavedAddressDropdownOfTheShipment()
        {
            Report.WriteLine("Clicking on origin address dropdown");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");//Modeified Vasanth 10092017

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ShippingFrom_ClearAddress_Id);
                Thread.Sleep(4000);
            }

            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[1]/div[1]/div[1]/h3");
            Clear(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
            Click(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id);
        }

        [When(@"I select any address from the origin saved address dropdown of the Shipment")]
        public void WhenISelectAnyAddressFromTheOriginSavedAddressDropdownOfTheShipment()
        {
            Report.WriteLine("verifying Address Counts");
            IList<IWebElement> OriginAddressList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div/p"));//Add Xpath of origin address values
            if (OriginAddressList.Count > 0)
            {
                Report.WriteLine("Selecting address from origin saved address dropdown");
                Click(attributeName_xpath, ShippingFrom_FirstSavedOriginAddress_Xpath);
                Thread.Sleep(2000);
            }
            else
            {
                Report.WriteLine("No Addresses Found in the Origin Address dropdown for the Logged in Usser Account");
                throw new Exception("No Addresses found in the Origin Address dropdown");
            }
        }

        [Then(@"clicking on Clear Address link must clear the address in the origin saved address field of the Shipment")]
        public void ThenClickingOnClearAddressLinkMustClearTheAddressInTheOriginSavedAddressFieldOfTheShipment()
        {
            Click(attributeName_id, ShippingFrom_ClearAddress_Id);
            Thread.Sleep(2000);
        }

        [Then(@"All populated fields will be cleared/reset in the Add Shipment LTL Shipping From section of the Shipment")]
        public void ThenAllPopulatedFieldsWillBeClearedResetInTheAddShipmentLTLShippingFromSectionOfTheShipment()
        {
            Report.WriteLine("Verifying saved address/Locationa name/address/address2/zip/postal/city/state/province/Country/Accessorial/Contact name/Contact Phone/Contact Email/Contact Fax are cleared in the Shipping From section");
            Verifytext(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "");
            Verifytext(attributeName_id, ShippingFrom_LocationName_Id, "");
            Verifytext(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "");
            Verifytext(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "");
            Verifytext(attributeName_id, ShippingFrom_zipcode_Id, "");
            Verifytext(attributeName_id, ShippingFrom_City_Id, "");
            Verifytext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath, "United States");
            Verifytext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath, "Select state/province...");
            Verifytext(attributeName_xpath, ShippingFrom_ServicesAccessorial_DropDown_xpath, "");
            
            Verifytext(attributeName_id, ShippingFrom_ContactName_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactEmail_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactPhone_Id, "");
            Verifytext(attributeName_id, ShippingFrom_ContactFax_Id, "");
        }

        [Then(@"the Country will reset to United States in the Shipping From section of the Shipment")]
        public void ThenTheCountryWillResetToUnitedStatesInTheShippingFromSectionOfTheShipment()
        {
            Report.WriteLine("Verifying Country is reset to United States");
            string OriginCountry_UI = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            Assert.AreEqual("United States", OriginCountry_UI);
        }

        [Then(@"the Country will reset to United States in the Shipping To section of the Shipment")]
        public void ThenTheCountryWillResetToUnitedStatesInTheShippingToSectionOfTheShipment()
        {
            Report.WriteLine("Verifying Country is reset to United States");
            string destinationCountry_UI = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            Assert.AreEqual("United States", destinationCountry_UI);
        }

        [When(@"I click on destination saved address dropdown of the Shipment")]
        public void WhenIClickOnDestinationSavedAddressDropdownOfTheShipment()
        {
            Report.WriteLine("Clicking on destination address dropdown");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");
            Thread.Sleep(1000);

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ShippingTo_ClearAddress_Id);
                Thread.Sleep(3000);
            }
            Click(attributeName_xpath, ".//*[@id='page-content-wrapper']/div[2]/div[2]/div[1]/div[2]/div[1]/div[1]/h3");
            Clear(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            Click(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            Click(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id);
            
        }

        [When(@"I select any address from the destination saved address dropdown of the Shipment")]
        public void WhenISelectAnyAddressFromTheDestinationSavedAddressDropdownOfTheShipment()
        {
            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_SelectSavedDestDropDown_Values_xpath));
            if (DestinationAddressList.Count > 0)
            {
                Click(attributeName_xpath, ShippingFrom_FirstSavedDestAddress_Xpath);
                Thread.Sleep(2000);
            }
            else
            {
                Report.WriteLine("No Addresses Found in the Destination Address dropdown for the Logged in Usser Account");
                throw new Exception("No Addresses found in the Destination Address dropdown");
            }
        }

        [Then(@"clicking on Clear Address link must clear the address in the destination saved address field of the Shipment")]
        public void ThenClickingOnClearAddressLinkMustClearTheAddressInTheDestinationSavedAddressFieldOfTheShipment()
        {
            Click(attributeName_id, ShippingTo_ClearAddress_Id);
            Thread.Sleep(1000);
        }

        [Then(@"All populated fields will cleared/reset in the Add Shipment Shipping To section of the Shipment")]
        public void ThenAllPopulatedFieldsWillClearedResetInTheAddShipmentShippingToSectionOfTheShipment()
        {
            Report.WriteLine("Verifying saved address/Locationa name/address/address2/zip/postal/city/state/province/Country/Accessorial/Contact name/Contact Phone/Contact Email/Contact Fax are cleared in the Shipping To section");
            Verifytext(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "");
            Verifytext(attributeName_id, ShippingTo_LocationName_Id, "");
            Verifytext(attributeName_id, ShippingTo_LocationAddressLine1_Id, "");
            Verifytext(attributeName_id, ShippingTo_LocationAddressLine2_Id, "");
            Verifytext(attributeName_id, ShippingTo_zipcode_Id, "");
            Verifytext(attributeName_id, ShippingTo_City_Id, "");
            Verifytext(attributeName_xpath, ShippingTo_CountryDropDown_xpath, "United States");
            Verifytext(attributeName_xpath, ShippingTo_StateDropdwon_xpath, "Select state/province...");
            Verifytext(attributeName_xpath, ShippingTo_ServicesAccessorial_DropDown_xpath, "");
            
            Verifytext(attributeName_id, ShippingTo_ContactName_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactEmail_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactPhone_Id, "");
            Verifytext(attributeName_id, ShippingTo_ContactFax_Id, "");
        }

        [Then(@"the top hundred addresses are displayed under destination saved addresses should match with Database for the Customer Account Name selected of the Shipment(.*)")]
        public void ThenTheTopHundredAddressesAreDisplayedUnderDestinationSavedAddressesShouldMatchWithDatabaseForTheCustomerAccountNameSelectedOfTheShipment(string Customer_Name)
        {
            IList<IWebElement> DestinationAddressList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingTo_SelectSavedDestDropDown_Values_xpath));
            List<string> Address_DB = (DBHelper.Get_Addresses(Customer_Name).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            List<string> _DestAddress = new List<string>();
            foreach (IWebElement element in DestinationAddressList)
            {
                _DestAddress.Add((element.Text).ToString());
            }

            List<string> _DestAddressUpper = _DestAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _DestAddressUpper);
        }

        [When(@"I enter a search criteria '(.*)' in the destination saved address field of the Shipment")]
        public void WhenIEnterASearchCriteriaInTheDestinationSavedAddressFieldOfTheShipment(string searchText)
        {
            Report.WriteLine("Entering a search criteria in destination address dropdown");
            SendKeys(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, searchText);
        }

        [When(@"I clicked on the Shipment Module will be navigated to Shipment List page (.*)")]
        public void WhenIClickedOnTheShipmentModuleWillBeNavigatedToShipmentListPage(string userType)
        {
            GlobalVariables.webDriver.WaitForPageLoad();

            if (userType == "External")
            {
                string ErrorPopupValues = Gettext(attributeName_xpath, ErrorPopUpClose_Button_Xpath);

                if (!string.IsNullOrWhiteSpace(ErrorPopupValues))
                {
                    Click(attributeName_xpath, ErrorPopUpClose_Button_Xpath);
                }
            }

            Report.WriteLine("Click on shipment icon");
            Click(attributeName_xpath, ShipmentIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Add shipment button");
        }

        [Then(@"the selected address for the search should be populated in the destination Address fields of the Shipment(.*),(.*)")]
        public void ThenTheSelectedAddressForTheSearchShouldBePopulatedInTheDestinationAddressFieldsOfTheShipment(string Customer_Name, string searchText)
        {
            string CityUI = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            string StateUI = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            string CountryUI = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            string ZipUI = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");

            Click(attributeName_xpath, ShippingTo_ContactInfo_Expand_xpath);
            Thread.Sleep(1000);
            WaitForElementVisible(attributeName_id, ShippingTo_ContactName_Id, "Shipping To Contact Name");
            
            string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
            string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
            string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
            string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");

            Address _addressDB = DBHelper.Get_Addresses_Name(Customer_Name, searchText);
            Assert.AreEqual((_addressDB.City), CityUI);
            Assert.AreEqual((_addressDB.State), StateUI);
            Assert.AreEqual((_addressDB.Country), CountryUI);
            Assert.AreEqual((_addressDB.Zip), ZipUI);
            Assert.AreEqual((_addressDB.ContactName), ActualContactName);
            Assert.AreEqual((_addressDB.EmailId), ActualContactEmail);
            Assert.AreEqual((_addressDB.PhoneNumber), ActualContactPhone);
            Assert.AreEqual((_addressDB.FaxNumber), ActualContactFax);
        }

        [Then(@"the selected address should be populated in the destination Address fields of the Shipment(.*)")]
        public void ThenTheSelectedAddressShouldBePopulatedInTheDestinationAddressFieldsOfTheShipment(string Customer_Name)
        {
            string _selectedAddress = GetValue(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");
            Report.WriteLine("Get the selected Address from Origin Address dropdown");
            string CityUI = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            string StateUI = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            string CountryUI = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            string ZipUI = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            string ActualComments = GetValue(attributeName_id, ShippingTo_Comments_Id, "value");
            
            string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
            string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
            string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
            string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");

            Address _addressDB = DBHelper.Get_Addresses_Name(Customer_Name, _selectedAddress);
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

        [Then(@"Shipping From Contact Information section will be expanded")]
        public void ThenShippingFromContactInformationSectionWillBeExpanded()
        {
            Report.WriteLine("Verifying for the Shipping From Contact Information sections are expanded");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactName_Id, "Shipping from Contact Name");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactEmail_Id, "Shipping from Contact Email");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactPhone_Id, "Shipping from Contact Phone");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactFax_Id, "Shipping from Contact Fax");
            
        }

        [Then(@"Shipping To Contact Information section will be expanded")]
        public void ThenShippingToContactInformationSectionWillBeExpanded()
        {
            Report.WriteLine("Verifying for the Shipping To Contact Information sections are expanded");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactName_Id, "Shipping from Contact Name");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactEmail_Id, "Shipping from Contact Email");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactPhone_Id, "Shipping from Contact Phone");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactFax_Id, "Shipping from Contact Fax");
        }
        [Then(@"shipping saved address dropdown should be binded to default Shipper address for Shipments(.*)")]
        public void ThenShippingSavedAddressDropdownShouldBeBindedToDefaultShipperAddressForShipments(string Customer_Name)
        {
            string text = GetAttribute(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");

            Address Addvalue = DBHelper.Get_ShipperAddressInternalUsers(Customer_Name);

            var addressFormat = Addvalue.Name + " " + Addvalue.Address1 + " " + Addvalue.Address2 + " " + Addvalue.City + " " + Addvalue.State + " " + " " + Addvalue.Country + " " + Addvalue.Zip + " " + Addvalue.ContactName + " " + Addvalue.PhoneNumber + " " + Addvalue.EmailId + " " + Addvalue.FaxNumber;

            Assert.AreEqual(addressFormat, text);
            Report.WriteLine("Address displaying in saved address dropdown is matching with saved address dropdown value");
        }

        [Then(@"shipping saved address dropdown should be binded to default Consignee address for Shipments(.*)")]
        public void ThenShippingSavedAddressDropdownShouldBeBindedToDefaultConsigneeAddressForShipments(string Customer_Name)
        {
            string text = GetAttribute(attributeName_id, ShippingTo_SelectSavedDestDropDown_Id, "value");

            Address Addvalue = DBHelper.Get_ConsigneeAddressInternalUsers(Customer_Name);

            var addressFormat = Addvalue.Name + " " + Addvalue.Address1 + " " + Addvalue.Address2 + " " + Addvalue.City + " " + Addvalue.State + " " + " " + Addvalue.Country + " " + Addvalue.Zip + " " + Addvalue.ContactName + " " + Addvalue.PhoneNumber + " " + Addvalue.EmailId + " " + Addvalue.FaxNumber;

            Assert.AreEqual(addressFormat, text);
            Report.WriteLine("Address displaying in saved address dropdown is matching with saved address dropdown value");
        }

        [Then(@"I unable to select another saved address from the destination Address dropdown")]
        public void ThenIUnableToSelectAnotherSavedAddressFromTheDestinationAddressDropdown()
        {
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Destination']/div/span[1]/span", "Saved Address Expansion");
        }

        [Then(@"I able to edit Shipping to Location and Contacts Fields(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIAbleToEditShippingToLocationAndContactsFields(string _locName, string _address1, string _address2, string _city, string _state, string Zip_PostalCode, string _country, string _comments, string _contactName, string _contactPhone, string _contactEmail, string _contactFax)
        {
            Clear(attributeName_id, ShippingTo_LocationName_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_LocationName_Id, _locName);
            Thread.Sleep(200);
            string ActualLocationName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            Assert.AreEqual(_locName.ToUpper(), ActualLocationName.ToUpper());

            Clear(attributeName_id, ShippingTo_LocationAddressLine1_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine1_Id, _address1);
            Thread.Sleep(200);
            string ActualAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            Assert.AreEqual(_address1, ActualAddress1);

            Clear(attributeName_id, ShippingTo_LocationAddressLine2_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_Id, _address2);
            Thread.Sleep(200);
            string ActualAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
            Assert.AreEqual(_address2, ActualAddress2);

            Click(attributeName_xpath, ".//*[@id='select_destination_country_chosen']/a/span");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='select_destination_country_chosen']/div/ul/li", _country);
            Thread.Sleep(300);
            string ActualDestCountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
            Assert.AreEqual(_country, ActualDestCountry);

            Clear(attributeName_id, ShippingTo_zipcode_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_zipcode_Id, Zip_PostalCode);
            Thread.Sleep(200);
            string ActualDestZipCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            Assert.AreEqual(Zip_PostalCode, ActualDestZipCode);

            Clear(attributeName_id, ShippingTo_City_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_City_Id, _city);
            Thread.Sleep(200);
            string ActualDestCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            Assert.AreEqual(_city, ActualDestCity);

            Click(attributeName_xpath, ".//*[@id='state_destination_select_chosen']/a/span");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='state_destination_select_chosen']/div/ul/li", _state);
            Thread.Sleep(300);
            string ActualDestState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
            Assert.AreEqual(_state, ActualDestState);

            Clear(attributeName_id, ShippingTo_Comments_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_Comments_Id, _comments);
            Thread.Sleep(200);
            string ActualComments = GetValue(attributeName_id, ShippingTo_Comments_Id, "value");
            Assert.AreEqual(_comments, ActualComments);


            Clear(attributeName_id, ShippingTo_ContactName_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_ContactName_Id, _contactName);
            Thread.Sleep(200);
            string ActualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
            Assert.AreEqual(_contactName, ActualContactName);

            Clear(attributeName_id, ShippingTo_ContactEmail_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_ContactEmail_Id, _contactEmail);
            Thread.Sleep(200);
            string ActualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
            Assert.AreEqual(_contactEmail, ActualContactEmail);

            var _ExpectedContactPhone = string.Format("({0}) {1}-{2}", _contactPhone.Substring(0, 3), _contactPhone.Substring(3, 3), _contactPhone.Substring(6));
            Clear(attributeName_id, ShippingTo_ContactPhone_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_ContactPhone_Id, _contactPhone);
            Thread.Sleep(200);
            string ActualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
            Assert.AreEqual(_ExpectedContactPhone, ActualContactPhone);

            var _ExpectedContactFax = string.Format("({0}) {1}-{2}", _contactFax.Substring(0, 3), _contactFax.Substring(3, 3), _contactFax.Substring(6));
            Clear(attributeName_id, ShippingTo_ContactFax_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingTo_ContactFax_Id, _contactFax);
            Thread.Sleep(200);
            string ActualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
            Assert.AreEqual(_ExpectedContactFax, ActualContactFax);
        }

        [Then(@"the Shipping To Contact Info section will be expanded and User able to see Contact Info fields")]
        public void ThenTheShippingToContactInfoSectionWillBeExpandedAndUserAbleToSeeContactInfoFields()
        {
            VerifyElementVisible(attributeName_id, ShippingTo_ContactName_Id, "Shipping to Contact Name field");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactEmail_Id, "Shipping to Contact Email field");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactPhone_Id, "Shipping to Contact Phone field");
            VerifyElementVisible(attributeName_id, ShippingTo_ContactFax_Id, "Shipping to Contact Fax field");
        }

        [Then(@"the top hundred addresses are displayed under Origin saved addresses should match with Database for the Customer Account Name selected of the Shipment(.*)")]
        public void ThenTheTopHundredAddressesAreDisplayedUnderOriginSavedAddressesShouldMatchWithDatabaseForTheCustomerAccountNameSelectedOfTheShipment(string Customer_Name)
        {
            IList<IWebElement> OriginAddressList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_SelectSavedOriginDropDown_Values_xpath));
            List<string> Address_DB = (DBHelper.Get_Addresses(Customer_Name).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            List<string> _OrgAddress = new List<string>();
            foreach (IWebElement element in OriginAddressList)
            {
                _OrgAddress.Add((element.Text).ToString());
            }

            List<string> _OrgAddressUpper = _OrgAddress.ConvertAll(a => a.ToUpper());
            CollectionAssert.AreEqual(Address_DB, _OrgAddressUpper);
        }

        [Then(@"the selected address should be populated in the Origin Address fields of the Shipment(.*)")]
        public void ThenTheSelectedAddressShouldBePopulatedInTheOriginAddressFieldsOfTheShipment(string Customer_Name)
        {
            string _selectedAddress = GetValue(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, "value");
            Report.WriteLine("Get the selected Address from Origin Address dropdown");
            string CityUI = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            string StateUI = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            string CountryUI = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            string ZipUI = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");

            string ActualComments = GetValue(attributeName_id, ShippingTo_Comments_Id, "value");

            string ActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
            string ActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
            string ActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
            string ActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");

            Address _addressDB = DBHelper.Get_Addresses_Name(Customer_Name, _selectedAddress);
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

        [Then(@"I unable to select another saved address from the Origin Address dropdown")]
        public void ThenIUnableToSelectAnotherSavedAddressFromTheOriginAddressDropdown()
        {
            VerifyElementNotVisible(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span", "Saved Address Expansion");
        }

        [Then(@"the Shipping from Contact Info section will be expanded and User able to see Contact Info fields")]
        public void ThenTheShippingFromContactInfoSectionWillBeExpandedAndUserAbleToSeeContactInfoFields()
        {
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactName_Id, "Shipping from Contact Name field");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactEmail_Id, "Shipping from Contact Email field");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactPhone_Id, "Shipping from Contact Phone field");
            VerifyElementVisible(attributeName_id, ShippingFrom_ContactFax_Id, "Shipping from Contact Fax field");
        }

        [Then(@"I able to edit Shipping from Location and Contacts Fields(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void ThenIAbleToEditShippingFromLocationAndContactsFields(string _locName, string _address1, string _address2, string _city, string _state, string Zip_PostalCode, string _country, string _comments, string _contactName, string _contactPhone, string _contactEmail, string _contactFax)
        {
            Clear(attributeName_id, ShippingFrom_LocationName_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_LocationName_Id, _locName);
            Thread.Sleep(200);
            string ActualLocationName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            Assert.AreEqual(_locName.ToUpper(), ActualLocationName.ToUpper());

            Clear(attributeName_id, ShippingFrom_LocationAddressLine1_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine1_Id, _address1);
            Thread.Sleep(200);
            string ActualAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            Assert.AreEqual(_address1, ActualAddress1);

            Clear(attributeName_id, ShippingFrom_LocationAddressLine2_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_LocationAddressLine2_Id, _address2);
            Thread.Sleep(200);
            string ActualAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
            Assert.AreEqual(_address2, ActualAddress2);

            Click(attributeName_xpath, ".//*[@id='select_origin_country_chosen']/a/span");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='select_origin_country_chosen']/div/ul/li", _country);
            Thread.Sleep(300);
            string ActualOrgCountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_xpath);
            Assert.AreEqual(_country, ActualOrgCountry);
            
            Clear(attributeName_id, ShippingFrom_zipcode_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_zipcode_Id, Zip_PostalCode);
            Thread.Sleep(200);
            string ActualDestZipCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            Assert.AreEqual(Zip_PostalCode, ActualDestZipCode);

            Clear(attributeName_id, ShippingFrom_City_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_City_Id, _city);
            Thread.Sleep(200);
            string ActualOrgCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            Assert.AreEqual(_city, ActualOrgCity);

            Click(attributeName_xpath, ".//*[@id='state_origin_select_chosen']/a/span");
            SelectDropdownValueFromList(attributeName_xpath, ".//*[@id='state_origin_select_chosen']/div/ul/li", _state);
            Thread.Sleep(300);
            string ActualOrgState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
            Assert.AreEqual(_state, ActualOrgState);

            Clear(attributeName_id, ShippingFrom_Comments_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_Comments_Id, _comments);
            Thread.Sleep(200);
            string ActualComments = GetValue(attributeName_id, ShippingFrom_Comments_Id, "value");
            Assert.AreEqual(_comments, ActualComments);

            Clear(attributeName_id, ShippingFrom_ContactName_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_ContactName_Id, _contactName);
            Thread.Sleep(200);
            string ActualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
            Assert.AreEqual(_contactName, ActualContactName);

            Clear(attributeName_id, ShippingFrom_ContactEmail_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_ContactEmail_Id, _contactEmail);
            Thread.Sleep(200);
            string ActualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
            Assert.AreEqual(_contactEmail, ActualContactEmail);

            var _ExpectedContactPhone = string.Format("({0}) {1}-{2}", _contactPhone.Substring(0, 3), _contactPhone.Substring(3, 3), _contactPhone.Substring(6));
            Clear(attributeName_id, ShippingFrom_ContactPhone_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_ContactPhone_Id, _contactPhone);
            Thread.Sleep(200);
            string ActualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
            Assert.AreEqual(_ExpectedContactPhone, ActualContactPhone);

            var _ExpectedContactFax = string.Format("({0}) {1}-{2}", _contactFax.Substring(0, 3), _contactFax.Substring(3, 3), _contactFax.Substring(6));
            Clear(attributeName_id, ShippingFrom_ContactFax_Id);
            Thread.Sleep(300);
            SendKeys(attributeName_id, ShippingFrom_ContactFax_Id, _contactFax);
            Thread.Sleep(200);
            string ActualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
            Assert.AreEqual(_ExpectedContactFax, ActualContactFax);
        }
        [When(@"I enter a search criteria '(.*)' in the Origin saved address field of the Shipment")]
        public void WhenIEnterASearchCriteriaInTheOriginSavedAddressFieldOfTheShipment(string searchText)
        {
            Report.WriteLine("Entering a search criteria in destination address dropdown");
            SendKeys(attributeName_id, ShippingFrom_SelectSavedOriginDropDown_Id, searchText);
        }

        [Then(@"the top Hundred Address loaded in the Origin dropdown for the entered search(.*),(.*)")]
        public void ThenTheTopHundredAddressLoadedInTheOriginDropdownForTheEnteredSearch(string Customer_Name, string searchText)
        {
            Thread.Sleep(1000);
            List<string> Address_DB = (DBHelper.GetTop100Address_By_searchedhName(Customer_Name, searchText).ConvertAll(a => a.ToUpper())).Take(100).ToList();

            IList<IWebElement> OrgAddressList = GlobalVariables.webDriver.FindElements(By.XPath(ShippingFrom_SelectSavedOriginDropDown_Values_xpath));

            List<string> u = new List<string>();
            for (int i = 1; i <= OrgAddressList.Count; i++)
            {
                string k = Gettext(attributeName_xpath, ".//*[@id='scrollable-dropdown-menu-Origin']/div/span[1]/span/div/span/div[" + i + "]");
                u.Add(k);
            }
            List<string> _OrgAddressUpper = u.ConvertAll(a => a.ToUpper());
            Assert.AreEqual(Address_DB.Count, _OrgAddressUpper.Count);
        }
    }
}
