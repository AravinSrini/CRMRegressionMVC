using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using System.Collections.Generic;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using Rrd.ServiceAccessLayer;
using System;
using System.Threading;
using CRM.UITest.Entities.Proxy;
using System.Linq;
using System.IO;
using OpenQA.Selenium.Interactions;
using System.Configuration;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class ShippingInformationScreenForDesktopSteps : ObjectRepository
    {
        [Given(@"I am a DLS user and login into application with valid Username and Password")]
        public void GivenIAmADLSUserAndLoginIntoApplicationWithValidAnd()
        {

            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"I am a DLS user and loggedin into application with valid (.*) and (.*)")]
        public void GivenIAmADLSUserAndLoggedinIntoApplicationWithValidAnd(string username, string password)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [When(@"I select Canada in the Country drop down list in the Shipping From Section(.*)")]
        public void WhenISelectCanadaInTheCountryDropDownListInTheShippingFromSection(string Country)
        {
            ScenarioContext.Current.Pending();
        }




        [Given(@"I clicked on (.*) button on the select type screen of rate request process")]
        public void GivenIClickedOnButtonOnTheSelectTypeScreenOfRateRequestProcess(string service)
        {
            Report.WriteLine("Click on quotes module");
            string ErrorPopupValues = Gettext(attributeName_xpath, ShipmentNotFound_PopUp_Close_button_Xpath);

            if (!string.IsNullOrWhiteSpace(ErrorPopupValues))
            {
                Click(attributeName_xpath, ShipmentNotFound_PopUp_Close_button_Xpath);
            }

            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_id, QuoteIcon_Id);

            Report.WriteLine("Navigate to rate request service page");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SubmitRateRequestButton_Id);

            Report.WriteLine("Selecting service from shipment service screen");
            GlobalVariables.webDriver.WaitForPageLoad();
            if (service.ToUpper() == "LTL")
            {
                Click(attributeName_id, LTL_TileLabel_Id);
            }
            else if (service.ToUpper() == "TRUCKLOAD")
            {
                //Click(attributeName_id)
            }
            else if (service.ToUpper() == "PARTIAL TRUCKLOAD")
            {
                //Click(attributeName_id);
            }
            else if (service.ToUpper() == "INTERMODAL")
            {
                //Click(attributeName_id);
            }
            else
            {

            }
        }

        [When(@"click on view quote results button")]
        public void WhenClickOnViewQuoteResultsButton()
        {
            Report.WriteLine("Clicking View Quote Results button");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
        }

        [When(@"I click on origin saved address dropdown")]
        public void WhenIClickOnOriginSavedAddressDropdown()
        {
            Report.WriteLine("Clicking on origin address dropdown");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");//Modeified Vasanth 10092017

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }

            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath);
            Click(attributeName_id, LTL_SavedOriginAddressDropdown_Id);
        }

        [When(@"I click on destination saved address dropdown")]
        public void WhenIClickOnDestinationSavedAddressDropdown()
        {
            Report.WriteLine("Clicking on destination address dropdown");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");//Modeified Vasanth 10092017

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
            Click(attributeName_xpath, LTL_ShipinformationPage_ShippingTo_Xpath);
            Click(attributeName_id, LTL_SavedDestinationAddressDropdown_Id);
            Thread.Sleep(1000);
        }

        [When(@"I select any address from the origin saved address dropdown")]
        public void WhenISelectAnyAddressFromTheOriginSavedAddressDropdown()
        {
            Report.WriteLine("Selecting address from origin saved address dropdown");
            //Verifytext(attributeName_xpath, LTL_ShipinformationPage_ShippingFrom_Xpath, "Shipping From");S
            Click(attributeName_xpath, FirstSavedOriginAddress);

            //Click(attributeName_cssselector, FirstSavedOriginAddress_CSS);

        }

        [When(@"I select any address from the destination saved address dropdown")]
        public void WhenISelectAnyAddressFromTheDestinationSavedAddressDropdown()
        {
            Report.WriteLine("Selecting address from destination saved address dropdown");
            //Click(attributeName_xpath, LTL_SavedDestinationFirstAddressDropdownValue_Xpath); changed due to UI update
            Click(attributeName_xpath, FirstSavedDestinationAddress);
        }

        [When(@"I click on origin country dropdown")]
        public void WhenIClickOnOriginCountryDropdown()
        {
            Report.WriteLine("Clicking Origin Country Dropdown");
            Click(attributeName_id, LTL_OriginCountryDropdown_Id);
        }

        [When(@"I click on destination country dropdown")]
        public void WhenIClickOnDestinationCountryDropdown()
        {
            Report.WriteLine("Clicking Destination Country Dropdown");
            Click(attributeName_id, LTL_DestinationCountryDropdown_Id);
        }

        [When(@"I select (.*) from the origin country dropdown")]
        public void WhenISelectFromTheOriginCountryDropdown(string CountryName)
        {
            Click(attributeName_id, LTL_OriginCountryDropdown_Id);
            Report.WriteLine("Selecting" + CountryName + "from the origin dropdown");

            IList<IWebElement> originCountryList = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='select_origin_country_chosen']/div/ul/li"));
            int originCountryCount = originCountryList.Count;
            for (int i = 0; i < originCountryCount; i++)
            {
                if (originCountryList[i].Text.ToUpper() == CountryName)
                {
                    originCountryList[i].Click();
                    break;
                }
            }
        }

        [When(@"I select (.*) from the destination country dropdown")]
        public void WhenISelectFromTheDestinationCountryDropdown(string CountryName)
        {
            Click(attributeName_id, LTL_DestinationCountryDropdown_Id);
            Report.WriteLine("Selecting" + CountryName + "from the destination dropdown");

            IList<IWebElement> destinationCountryList = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='select_destination_country_chosen']/div/ul/li"));
            int destinationCountryCount = destinationCountryList.Count;
            for (int i = 0; i < destinationCountryCount; i++)
            {
                if (destinationCountryList[i].Text.ToUpper() == CountryName)
                {
                    destinationCountryList[i].Click();
                    break;
                }
            }
        }

        [When(@"I click on origin postal lookup")]
        public void WhenIClickOnOriginPostalLookup()
        {
            Report.WriteLine("Clicking Origin postal lookup");
            Click(attributeName_xpath, LTL_OriginLookup_Xpath);
        }
        [When(@"I enter valid data (.*), (.*) and (.*) in origin lookup")]
        public void WhenIEnterValidDataAndInOriginLookup(string Address, string City, string State)
        {
            Report.WriteLine("Entering data in Origin postal lookup");
            SendKeys(attributeName_id, LTL_Lookup_Address_Id, Address);
            SendKeys(attributeName_id, LTL_Lookup_City_Id, City);
            Click(attributeName_id, LTL_Lookup_State_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_Lookup_StateValues_Xpath, State);
        }

        [When(@"I enter valid data (.*), (.*) and (.*) in destination lookup")]
        public void WhenIEnterValidDataAndInDestinationLookup(string Address, string City, string State)
        {
            Report.WriteLine("Entering data in destination postal lookup");
            SendKeys(attributeName_id, LTL_Lookup_Address_Id, Address);
            SendKeys(attributeName_id, LTL_Lookup_City_Id, City);
            Click(attributeName_id, LTL_Lookup_State_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_Lookup_StateValues_Xpath, State);
        }

        [When(@"I enter valid data in Origin section (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInOriginSectionAnd(string Zip, string City, string State)
        {
            Report.WriteLine("Clearing if any default Address present in Origin section");
            Thread.Sleep(1000);
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "value");

            if(_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_OriginId);
                Thread.Sleep(4000);
            }
            Report.WriteLine("Entering data in origin section");
            SendKeys(attributeName_id, LTL_OriginCity_Id, City);
            Click(attributeName_id, LTL_OriginStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, State);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, Zip);
        }

        [When(@"I enter valid data in Destination section (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInDestinationSectionAnd(string Zip, string City, string State)
        {
            Report.WriteLine("Clearing if any default Address present in Destination section");
            string _selectedAddress = GetValue(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "value");

            if (_selectedAddress != "" || _selectedAddress != string.Empty)
            {
                Click(attributeName_id, ClearAddress_DestId);
                Thread.Sleep(3000);
            }
            Report.WriteLine("Entering data in destination section");
            SendKeys(attributeName_id, LTL_DestinationCity_Id, City);
            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, State);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, Zip);
            Click(attributeName_id, LTL_DestinationCity_Id);
            Thread.Sleep(2000);
        }

        [When(@"I enter valid data in Item section (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterValidDataInItemSectionAnd(string Classification, string Weight, string Shipmentvalue, string AdditionalService)
        {
            Report.WriteLine("Enter details in item section");
            Click(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, Weight);
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Shipmentvalue);
            Click(attributeName_xpath, LTL_ServicesDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_Xpath, AdditionalService);
        }

        [When(@"I enter valid data only in Item section (.*), (.*)")]
        public void WhenIEnterValidDataOnlyInItemSection(string Classification, string Weight)
        {
            Report.WriteLine("Enter details in item section");
            Click(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == Classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, Weight);
        }

        [When(@"I click on find zipcode button")]
        public void WhenIClickOnFindZipcodeButton()
        {
            Report.WriteLine("Clicking on find zip code button");
            Click(attributeName_xpath, LTL_Lookup_FindZipCodeButton_Xpath);
        }

        [When(@"I click on destination postal lookup")]
        public void WhenIClickOnDestinationPostalLookup()
        {
            Report.WriteLine("Clicking on find zip code button");
            Click(attributeName_xpath, LTL_DestinationLookup_Xpath);
        }

        [When(@"I click on save and close button")]
        public void WhenIClickOnSaveAndCloseButton()
        {
            Report.WriteLine("Clicking on save and close button");
            Thread.Sleep(2000);
            Click(attributeName_id, LTL_Lookup_SaveCloseButton_Id);
        }

        [When(@"I click on New lookup")]
        public void WhenIClickOnNewLookup()
        {
            Report.WriteLine("Clicking on new lookup button");
            Thread.Sleep(2000);
            Click(attributeName_id, LTL_Lookup_NewLookupButton_Id);
        }

        [When(@"I click on Cancel button")]
        public void WhenIClickOnCancelButton()
        {
            Report.WriteLine("Clicking on Cancel button in lookup");
            Thread.Sleep(2000);
            Click(attributeName_xpath, LTL_Lookup_CancelButton_Xpath);
        }

        [When(@"I click on saved items dropdown")]
        public void WhenIClickOnSavedItemsDropdown()
        {
            Report.WriteLine("Click on saved item dropdown");
            Click(attributeName_id, LTL_SavedItemDropdown_Id);
        }

        [When(@"I select any item (.*)")]
        public void WhenISelectAnyItem(string ItemDescription)
        {
            //Script failing here
            //step added
            Click(attributeName_id, "Select_saveditem_0_chosen");
            SendKeys(attributeName_xpath, LTL_SavedItemDropdown_SearchBox_Xpath, ItemDescription);
            Click(attributeName_xpath, LTL_SavedItemDropdownValues_Xpath);
        }


        [When(@"I click on SHOW DENSITY CLASS TABLE link")]
        public void WhenIClickOnSHOWDENSITYCLASSTABLELink()
        {
            Report.WriteLine("Click on show density table link");
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
        }

        [When(@"I click on HIDE DENSITY CLASS TABLE")]
        public void WhenIClickOnHIDEDENSITYCLASSTABLE()
        {
            Report.WriteLine("Click on hide density table link");
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
        }

        [When(@"I enter data in estimate class popup (.*), (.*), (.*), (.*), (.*) and (.*)")]
        public void WhenIEnterDataInEstimateClassPopupAnd(string Length, string Width, string Height, string Weight, string Quantity, string ExpectedDensity)
        {
            Report.WriteLine("Passing data in esitmated class lookup");
            WaitForElementVisible(attributeName_id, LTL_EstimateClass_Length_Id, "Estimate Lookup");
            SendKeys(attributeName_id, LTL_EstimateClass_Length_Id, Length);
            SendKeys(attributeName_id, LTL_EstimateClass_Width_Id, Width);
            SendKeys(attributeName_id, LTL_EstimateClass_Height_Id, Height);
            SendKeys(attributeName_id, LTL_EstimateClass_Weight_Id, Weight);
            SendKeys(attributeName_id, LTL_EstimateClass_Quantity_Id, Quantity);
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
            Thread.Sleep(2000);
            string ActualDensity = GetValue(attributeName_id, LTL_EstimateClass_Density_Id, "value");
            Assert.AreEqual(ExpectedDensity, ActualDensity);
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
        }

        [When(@"I click on Apply class")]
        public void WhenIClickOnApplyClass()
        {
            Thread.Sleep(1000);
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
            Report.WriteLine("Clicking apply class button");
            Click(attributeName_xpath, LTL_EstimateClass_ApplyClass_Xpath);
        }

        [When(@"I click on close button in esitmate class popup")]
        public void WhenIClickOnCloseButtonInEsitmateClassPopup()
        {
            Report.WriteLine("Clicking close button");
            WaitForElementVisible(attributeName_xpath, LTL_EstimateClass_Close_Xpath, "Close Button");
            Click(attributeName_xpath, LTL_EstimateClass_Close_Xpath);
        }

        [When(@"I click on add additional item link")]
        public void WhenIClickOnAddAdditionalItemLink()
        {
            Report.WriteLine("Clicking on add additional item button");
            Click(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath);
        }

        [When(@"I click on remove additional item link")]
        public void WhenIClickOnRemoveAdditionalItemLink()
        {
            Report.WriteLine("Clicking on remove additional item button");
            Click(attributeName_xpath, LTL_RemoveAdditionalItemLink_Xpath);
        }

        [When(@"I click on question mark icon")]
        public void WhenIClickOnQuestionMarkIcon()
        {
            Report.WriteLine("Clicking on question mark icon");
            Click(attributeName_id, LTL_QuestionMarkIcon_Id);
        }

        [When(@"I enter data in (.*) field")]
        public void WhenIEnterDataInField(string Insuredvalue)
        {
            Report.WriteLine("Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, LTL_InusredRate_Id, Insuredvalue);
        }

        [When(@"I click on Terms and Conditions link")]
        public void WhenIClickOnTermsAndConditionsLink()
        {
            Click(attributeName_id, LTL_Quantity_Id);
            Report.WriteLine("Clicking on terms and conditions link");
            WaitForElementVisible(attributeName_xpath, LTL_TermsAndConditionsLink_Xpath, "Terms and Conditions");
            Click(attributeName_xpath, LTL_TermsAndConditionsLink_Xpath);
        }

        [When(@"I click on close button")]
        public void WhenIClickOnCloseButton()
        {
            Report.WriteLine("Clicking on close button in terms and conditions popup");
            WaitForElementVisible(attributeName_xpath, LTL_Terms_PopupClose_Xpath, "Close Button");
            Click(attributeName_xpath, LTL_Terms_PopupClose_Xpath);
        }


        [Then(@"I should be able to verify fields - Select a saved origin address, Origin Country, Origin Zip/Postal code, Origin City, Origin State/Province, Select a saved destination address, Destination Country, Destination Zip/Postal Code, Destination City, Destination State/Province, Select a saved item, Classification, Weight, Pickup date, Services/accessorials, Shipment value, Terms & Conditions link, Tool tip, Estimate class lookup ,Add additional item button and View Quote Results button")]
        public void ThenIShouldBeAbleToVerifyFields_SelectASavedOriginAddressOriginCountryOriginZipPostalCodeOriginCityOriginStateProvinceSelectASavedDestinationAddressDestinationCountryDestinationZipPostalCodeDestinationCityDestinationStateProvinceSelectASavedItemClassificationWeightPickupDateServicesAccessorialsShipmentValueTermsConditionsLinkToolTipEstimateClassLookupAddAdditionalItemButtonAndViewQuoteResultsButton()
        {
            Report.WriteLine("Verifing the fields present under origin section");
            VerifyElementPresent(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "Saved Origin Address dropdown");
            VerifyElementPresent(attributeName_id, LTL_OriginCountryDropdown_Id, "Origin Country dropdown");
            VerifyElementPresent(attributeName_id, LTL_OriginZipPostal_Id, "Origin Zip or Postal text box");
            VerifyElementPresent(attributeName_id, LTL_OriginStateProvince_Id, "Origin State or Province text box");
            VerifyElementPresent(attributeName_id, LTL_OriginCity_Id, "Origin city text box");
            VerifyElementPresent(attributeName_xpath, LTL_OriginLookup_Xpath, "Origin lookup");

            Report.WriteLine("Verifing the fields present under destination section");
            VerifyElementPresent(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "Saved Destination Address dropdown");
            VerifyElementPresent(attributeName_id, LTL_DestinationCountryDropdown_Id, "Destination Country dropdown");
            VerifyElementPresent(attributeName_id, LTL_DestinationZipPostal_Id, "Destination Zip or Postal text box");
            VerifyElementPresent(attributeName_id, LTL_DestinationStateProvince_Id, "Destination State or Province text box");
            VerifyElementPresent(attributeName_id, LTL_DestinationCity_Id, "Destination city text box");
            VerifyElementPresent(attributeName_xpath, LTL_DestinationLookup_Xpath, "Destination lookup");

            Report.WriteLine("Verifing the fields present under freight description section");
            VerifyElementPresent(attributeName_id, LTL_SavedItemDropdown_Id, "Saved Item dropdown");
            VerifyElementPresent(attributeName_id, LTL_Classification_Id, "Classification dropdown");
            VerifyElementPresent(attributeName_id, LTL_Weight_Id, "Weight text box");
            VerifyElementPresent(attributeName_xpath, LTL_AddAdditionalItemLink_Xpath, "Add Additional item button");
            VerifyElementPresent(attributeName_id, LTL_EnterInsuredValue_Id, "Shipment Value text box");
            VerifyElementPresent(attributeName_id, LTL_QuestionMarkIcon_Id, "Shipment Value - question mark icon");
            VerifyElementPresent(attributeName_xpath, LTL_TermsAndConditionsLink_Xpath, "Terms and Conditions link");

            Report.WriteLine("Verifing the fields present Services and Accessorials section");
            VerifyElementPresent(attributeName_xpath, LTL_ServicesDropdown_Xpath, "Additional services dropdown");
            VerifyElementPresent(attributeName_id, LTL_ViewQuoteResults_Id, "View Quote results button");
            VerifyElementPresent(attributeName_id, BackToQuoteButton_Id, "Back to quote list button");
        }

        [Then(@"error message should be displayed by highlighting required fields")]
        public void ThenErrorMessageShouldBeDisplayedByHighlightingRequiredFields()
        {
            Report.WriteLine("Verifing error message");
            string ExpectedError = "PLEASE ENTER ALL REQUIRED INFORMATION";
            string ActualError = Gettext(attributeName_id, LTL_RequiredFieldError_Id);
            Assert.AreEqual(ExpectedError, ActualError);
        }

        //-----------Sprint 62 Saved Address drop down - load 100 hundred addresses---------------
        [Then(@"the top hundred addresses must be displayed under origin saved addresses for the user with AcctNum (.*)")]
        public void ThenTheTopHundredAddressesMustBeDisplayedUnderOriginSavedAddressesForTheUserWithAcctNum(int AcctNum)
        {
            int AccNumb = DBHelper.GetAccountNumber(AcctNum);
            List<string> Addresses_DB = DBHelper.GetAddressesforAccount(AcctNum).Select(x => x.Trim()).ToList();
            List<string> Addresses_UI = GetDropdownOptions(attributeName_xpath, LTL_OriginSavedAddresses, "div").Select(x => x.Trim()).ToList();
            CollectionAssert.AreEqual(Addresses_UI, Addresses_DB);
        }

        [Then(@"the top hundred addresses must be displayed under destination saved addresses for the user with AcctNum (.*)")]
        public void ThenTheTopHundredAddressesMustBeDisplayedUnderDestinationSavedAddressesForTheUserWithAcctNum(int AcctNum)
        {
            int AccNumb = DBHelper.GetAccountNumber(AcctNum);
            List<string> Addresses_DB = DBHelper.GetAddressesforAccount(AcctNum).Select(x => x.Trim()).ToList();
            List<string> Addresses_UI = GetDropdownOptions(attributeName_xpath, LTL_DestSavedAddresses, "div").Select(x => x.Trim()).ToList();
            CollectionAssert.AreEqual(Addresses_UI, Addresses_DB);
        }

        [When(@"I enter a search criteria '(.*)' in the origin saved address field")]
        public void WhenIEnterASearchCriteriaInTheOriginSavedAddressField(string searchText)
        {
            Report.WriteLine("Entering a search criteria in origin address dropdown");
            Thread.Sleep(1000);
            SendKeys(attributeName_id, LTL_SavedOriginAddressDropdown_Id, searchText);
            //Thread.Sleep(1000);
        }


        [Then(@"the top hundred addresses must be displayed under origin saved addresses for the search criteria '(.*)' for user with AcctNum (.*)")]
        public void ThenTheTopHundredAddressesMustBeDisplayedUnderOriginSavedAddressesForTheSearchCriteriaForUserWithAcctNum(string searchText, int AcctNum)
        {
            int AccNumb = DBHelper.GetAccountNumber(AcctNum);
            List<string> Addresses_DB = DBHelper.GetAddressesforAccount_withSearchCriteria(AcctNum, searchText).Select(x => x.Trim()).ToList();
            List<string> Addresses_UI = GetDropdownOptions(attributeName_xpath, LTL_OriginSavedAddresses, "div").Select(x => x.Trim()).ToList();
            CollectionAssert.AreEqual(Addresses_UI, Addresses_DB);
        }


        [When(@"I enter a search criteria '(.*)' in the destination saved address field")]
        public void WhenIEnterASearchCriteriaInTheDestinationSavedAddressField(string searchText)
        {
            Report.WriteLine("Entering a search criteria in destination address dropdown");
            Thread.Sleep(1000);
            SendKeys(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, searchText);
            Thread.Sleep(1000);
        }


        [Then(@"the top hundred addresses must be displayed under destination saved addresses for the search criteria '(.*)' for user with AcctNum '(.*)'")]
        public void ThenTheTopHundredAddressesMustBeDisplayedUnderDestinationSavedAddressesForTheSearchCriteriaForUserWithAcctNum(string searchText, int AcctNum)
        {
            int AccNumb = DBHelper.GetAccountNumber(AcctNum);
            List<string> Addresses_DB = DBHelper.GetAddressesforAccount_withSearchCriteria(AcctNum, searchText).Select(x => x.Trim()).ToList();
            List<string> Addresses_UI = GetDropdownOptions(attributeName_xpath, LTL_DestSavedAddresses, "div").Select(x => x.Trim()).ToList();
            CollectionAssert.AreEqual(Addresses_UI, Addresses_DB);
        }

        [Then(@"I select an address from the origin saved address list")]
        public void ThenISelectAnAddressFromTheOriginSavedAddressList()
        {

            Click(attributeName_id, LTL_SavedOriginAddressDropdown_Id);
            Click(attributeName_xpath, FirstSavedOriginAddress);

        }

        [Then(@"clicking on Clear Address link must clear the address in the origin saved address field")]
        public void ThenClickingOnClearAddressLinkMustClearTheAddressInTheOriginSavedAddressField()
        {
            IsElementPresent(attributeName_id, ClearAddress_OriginId, "Clear address link"); //Verifying clear address link presence
            Click(attributeName_id, ClearAddress_OriginId);
            Verifytext(attributeName_id, LTL_SavedOriginAddressDropdown_Id, "");


        }

        [Then(@"All populated fields will cleared/reset in the Shipping From section")]
        public void ThenAllPopulatedFieldsWillClearedResetInTheShippingFromSection()
        {
            Report.WriteLine("Verifying saved address/address/zip/postal/city/state/province are cleared in the Shipping From section");
            Verifytext(attributeName_id, LTL_OriginZipPostal_Id, "");
            Verifytext(attributeName_id, LTL_OriginCity_Id, "");
            Verifytext(attributeName_xpath, LTL_OriginCountryDropdownValue_Xpath, "United States");
            Verifytext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath, "Select state/province...");
        }




        [Then(@"I select an address from the destination saved address list")]
        public void ThenISelectAnAddressFromTheDestinationSavedAddressList()
        {
            Click(attributeName_id, LTL_SavedDestinationAddressDropdown_Id);
            Click(attributeName_xpath, FirstSavedDestinationAddress);
        }

        [Then(@"clicking on Clear Address link must clear the address in the destination saved address field")]
        public void ThenClickingOnClearAddressLinkMustClearTheAddressInTheDestinationSavedAddressField()
        {
            IsElementPresent(attributeName_id, ClearAddress_DestId, "Clear address link");//Verifying clear address link presence
            Click(attributeName_id, ClearAddress_DestId);
            Verifytext(attributeName_id, LTL_SavedDestinationAddressDropdown_Id, "");

        }

        [Then(@"All populated fields will cleared/reset in the Shipping To section")]
        public void ThenAllPopulatedFieldsWillClearedResetInTheShippingToSection()
        {
            Report.WriteLine("Verifying saved address/address/zip/postal/city/state/province are cleared in the Shipping To section");
            Verifytext(attributeName_id, LTL_DestinationZipPostal_Id, "");
            Verifytext(attributeName_id, LTL_DestinationCity_Id, "");
            Verifytext(attributeName_xpath, LTL_DestinationCountryDropdownValue_Xpath, "United States");
            Verifytext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath, "Select state/province...");

        }

        //-----------End of Sprint 62 Saved Address drop down - load 100 hundred addresses---------------


        [Then(@"Number of addresses for the (.*) displaying in destination saved address dropdown should match with database")]
        public void ThenNumberOfAddressesForTheDisplayingInDestinationSavedAddressDropdownShouldMatchWithDatabase(string Username)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            int TotalAddress = DBHelper.GetAddressesforAccount(AccNumb).Count;
            int ActualValue = GetCount(attributeName_xpath, LTL_SavedDestinationAddressDropdownValues_Xpath);
            Assert.AreEqual(TotalAddress, ActualValue - 1);
        }

        [Then(@"selected address should be populated in origin fields")]
        public void ThenSelectedAddressShouldBePopulatedInOriginFields()
        {
            Click(attributeName_id, LTL_SavedOriginAddressDropdown_Id);
            string text = Gettext(attributeName_xpath, FirstSavedOriginAddress);
            string ActualText = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            ActualText.Contains(text);
        }

        [Then(@"selected address should be populated in destination fields")]
        public void ThenSelectedAddressShouldBePopulatedInDestinationFields()
        {
            Click(attributeName_id, LTL_SavedDestinationAddressDropdown_Id);
            string text = Gettext(attributeName_xpath, FirstSavedDestinationAddress);
            string ActualText = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            ActualText.Contains(text);
        }

        [Then(@"United States (.*) and Canada (.*) countries options should be displayed in origin country dropdown")]
        public void ThenUnitedStatesAndCanadaCountriesOptionsShouldBeDisplayedInOriginCountryDropdown(string Country1, string Country2)
        {
            Report.WriteLine("Verifying the options under origin country dropdown");

            IList<IWebElement> originCountryList = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='select_origin_country_chosen']/div/ul/li"));
            int originCountryCount = originCountryList.Count;
            for (int i = 0; i < originCountryCount; i++)
            {
                if (originCountryList[i].Text.ToUpper() == Country1 || originCountryList[i].Text.ToUpper() == Country2)
                {
                    Report.WriteLine("Displaying countries under origin country dropdown is verified");
                }
            }
        }

        [Then(@"United States (.*) and Canada (.*) countries options should be displayed in destination country dropdown")]
        public void ThenUnitedStatesAndCanadaCountriesOptionsShouldBeDisplayedInDestinationCountryDropdown(string Country1, string Country2)
        {
            Report.WriteLine("Verifying the options under destination country dropdown");

            IList<IWebElement> destinationCountryList = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='select_destination_country_chosen']/div/ul/li"));
            int destinationCountryCount = destinationCountryList.Count;
            for (int i = 0; i < destinationCountryCount; i++)
            {
                if (destinationCountryList[i].Text.ToUpper() == Country1 || destinationCountryList[i].Text.ToUpper() == Country2)
                {
                    destinationCountryList[i].Click();
                    break;
                }
            }
        }

        [Then(@"respective fields for the (.*) should be displayed (.*) should be displayed in origin section")]
        public void ThenRespectiveFieldsForTheUNITEDSTATESShouldBeDisplayedShouldBeDisplayedInOriginSection(string Country, string MaxLength)
        {
            if (Country == "UNITED STATES")
            {
                string ActualMaxLength = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "maxlength");
                Assert.AreEqual(MaxLength, ActualMaxLength);
            }
            else
            {
                string ActualMaxLength = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "maxlength");
                Assert.AreEqual(MaxLength, ActualMaxLength);
            }
        }

        [Then(@"respective fields for the (.*) should be displayed (.*) should be displayed in destination section")]
        public void ThenRespectiveFieldsForTheShouldBeDisplayedShouldBeDisplayedInDestinationSection(string Country, string MaxLength)
        {
            if (Country == "UNITED STATES")
            {
                string ActualMaxLength = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "maxlength");
                Assert.AreEqual(MaxLength, ActualMaxLength);
            }
            else
            {
                string ActualMaxLength = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "maxlength");
                Assert.AreEqual(MaxLength, ActualMaxLength);
            }
        }

        [Then(@"Valid Zip code (.*) should be displayed for the entered origin address")]
        public void ThenValidZipCodeShouldBeDisplayedForTheEnteredOriginAddress(string Expectedzip)
        {
            Report.WriteLine("Reading dispalyed zip value");
            Thread.Sleep(1000);
            WaitForElementVisible(attributeName_xpath, LTL_Lookup_GeneratedZip_Xpath, "Generated Zip");
            string ActualZip = Gettext(attributeName_xpath, LTL_Lookup_GeneratedZip_Xpath);
            Assert.AreEqual(Expectedzip, ActualZip);
        }

        [Then(@"Valid Zip code (.*) should be displayed for the entered destination address")]
        public void ThenValidZipCodeShouldBeDisplayedForTheEnteredDestinationAddress(string Expectedzip)
        {
            Report.WriteLine("Reading dispalyed zip value");
            Thread.Sleep(1000);
            WaitForElementVisible(attributeName_xpath, LTL_Lookup_GeneratedZip_Xpath, "Generated Zip");
            string ActualZip = Gettext(attributeName_xpath, LTL_Lookup_GeneratedZip_Xpath);
            Assert.AreEqual(Expectedzip, ActualZip);
        }

        [Then(@"entered address details in the lookup should be populated in origin fields (.*), (.*) and (.*)")]
        public void ThenEnteredAddressDetailsInTheLookupShouldBePopulatedInOriginFieldsMiamiAndFL(string zip, string city, string state)
        {
            Report.WriteLine("Verifying the populated data in origin section");

            string ActualZip = GetValue(attributeName_id, LTL_OriginZipPostal_Id, "value");
            Assert.AreEqual(ActualZip, zip);

            string ActualCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            Assert.AreEqual(ActualCity, city);

            string ActualState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(ActualState, state);
        }

        [Then(@"entered address details in the lookup should be populated in destination fields (.*), (.*) and (.*)")]
        public void ThenEnteredAddressDetailsInTheLookupShouldBePopulatedInDestinationFieldsAnd(string zip, string city, string state)
        {
            Report.WriteLine("Verifying the populated data in destination section");

            string ActualZip = GetValue(attributeName_id, LTL_DestinationZipPostal_Id, "value");
            Assert.AreEqual(ActualZip, zip);

            string ActualCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            Assert.AreEqual(ActualCity, city);

            string ActualState = Gettext(attributeName_id, LTL_DestinationStateProvince_Id);
            Assert.AreEqual(ActualState, state);
        }

        [Then(@"empty lookup should be displayed")]
        public void ThenEmptyLookupShouldBeDisplayed()
        {
            Report.WriteLine("Verify the empty lookup");
            string CityValue = GetValue(attributeName_id, LTL_Lookup_City_Id, "value");
            Assert.AreEqual(string.Empty, CityValue);
        }

        [Then(@"entered address in the lookup should not be populated in origin respective fields")]
        public void ThenEnteredAddressInTheLookupShouldNotBePopulatedInOriginRespectiveFields()
        {
            string CityValue = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            Assert.AreEqual(string.Empty, CityValue);
        }

        [Then(@"entered address in the lookup should not be populated in destination respective fields")]
        public void ThenEnteredAddressInTheLookupShouldNotBePopulatedInDestinationRespectiveFields()
        {
            string CityValue = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            Assert.AreEqual(string.Empty, CityValue);
        }



        [Then(@"selected item data should populate to respective fields for the (.*) (.*)")]
        public void ThenSelectedItemDataShouldPopulateToRespectiveFieldsForThe(string Username, string ItemDescription)
        {
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            string setupID = IDP.GetClaimValue(Username, "dlscrm-CustomerSetUpId");
            int value = Convert.ToInt32(setupID);
            int AccNumb = DBHelper.GetAccountNumber(value);
            Item ItemValue = DBHelper.GetItemDetails(AccNumb, ItemDescription);

            Report.WriteLine("Verifying displaying item details with db values");
            string ActualClassification = Gettext(attributeName_xpath, LTL_Classification_SelectedValue_Xpath);
            Assert.AreEqual(ActualClassification, ItemValue.Classification.ToString());

            string ActualWeight = GetValue(attributeName_id, LTL_Weight_Id, "value");
            Assert.AreEqual(ActualWeight, ItemValue.Weight.ToString());
        }


        [Then(@"on mouse hover on the Density Calculator icon I should be able to see the message as '(.*)'")]
        public void ThenOnMouseHoverOnTheDensityCalculatorIconIShouldBeAbleToSeeTheMessageAs(string Estimate_Class)
        {
            OnMouseOver(attributeName_id, LTL_EstimateClassButton_Id);
            string ActualHover_Message = GetAttribute(attributeName_xpath, LTL_EstimateClassButton_xpath, "data-title");
            Assert.AreEqual(Estimate_Class, ActualHover_Message);
        }

        [Then(@"Verify the warning message '(.*)' is displayed")]
        public void ThenVerifyTheWarningMessageIsDisplayed(string Warning_Message)
        {
            Report.WriteLine("Verifying the warning message");
            string var = Gettext(attributeName_id, LTL_ShipInformationPage_WarningMessage_Id);
            Verifytext(attributeName_id, LTL_ShipInformationPage_WarningMessage_Id, Warning_Message);
        }

        [Then(@"Verify the error message '(.*)' is displayed")]
        public void ThenVerifyTheErrorMessageIsDisplayed(string Error_Message)
        {
            Report.WriteLine("Verifying the error message when no data is entered in all fields in estimated lookup modal");
            Click(attributeName_id, LTL_EstimateClass_Length_Id);
            Click(attributeName_id, LTL_EstimateClass_TableLink_Id);
            Verifytext(attributeName_id, LTL_EstimatedClass_ErrorMessage_Id, Error_Message);
        }


        [Then(@"Verify the warning message '(.*)' is displayed when weight exceeds the LTL threshold value")]
        public void ThenVerifyTheWarningMessageIsDisplayedWhenWeightExceedsTheLTLThresholdValue(string Weight_Warning_Message)
        {
            Report.WriteLine("Verifying the warning message when weight exceeds the LTL threshold value");
            SendKeys(attributeName_id, LTL_EstimateClass_Weight_Id, "10001");
            string Actual_Weight_WarningMsg = Gettext(attributeName_xpath, ".//*[@id='ec-weight-error']/p");
            Assert.AreEqual(Actual_Weight_WarningMsg, Weight_Warning_Message);

        }

        [Then(@"Verify the warning message '(.*)' is displayed when quanity exceeds the LTL threshold value")]
        public void ThenVerifyTheWarningMessageIsDisplayedWhenQuanityExceedsTheLTLThresholdValue(string Quantity_Warning_Message)
        {
            Report.WriteLine("Verifying the warning message when quanity exceeds the LTL threshold value");
            SendKeys(attributeName_id, LTL_EstimateClass_Quantity_Id, "7");
            string Actual_Quantity_WarningMsg = Gettext(attributeName_xpath, LTL_EstimatedClass_Quantity_Warning_Message_Xpath);
            Assert.AreEqual(Actual_Quantity_WarningMsg, Quantity_Warning_Message);

        }



        [Then(@"pop-up model should be displayed to find estimated class")]
        public void ThenPop_UpModelShouldBeDisplayedToFindEstimatedClass()
        {
            string ExpectedText = "Estimated Class Lookup";
            string ActualText = Gettext(attributeName_xpath, LTL_EstimateClass_HeaderText_Xpath);
            Assert.AreEqual(ExpectedText, ActualText);
        }

        [Then(@"show predefined denisity table should be displayed and link should be changed to HIDE DENSITY CLASS TABLE")]
        public void ThenShowPredefinedDenisityTableShouldBeDisplayedAndLinkShouldBeChangedToHIDEDENSITYCLASSTABLE()
        {
            VerifyElementPresent(attributeName_id, LTL_EstimateClass_Table_Id, "Estimated commodity classification Table"); /* --------*/
            Verifytext(attributeName_id, LTL_EstimateClass_TableLink_Id, "HIDE DENSITY CLASS TABLE"); /* --------*/

        }

        [Then(@"show predefined denisity table should not be displayed and link should be changed to SHOW DENSITY CLASS")]
        public void ThenShowPredefinedDenisityTableShouldNotBeDisplayedAndLinkShouldBeChangedToSHOWDENSITYCLASS()
        {
            VerifyElementNotVisible(attributeName_id, LTL_EstimateClass_Table_Id, "Estimated commodity classification Table");
            Verifytext(attributeName_id, LTL_EstimateClass_TableLink_Id, "SHOW DENSITY CLASS TABLE");
        }


        [Then(@"pop-up model should be closed and passed data should be populated into respective fields '(.*)' , '(.*)' and '(.*)'")]
        public void ThenPop_UpModelShouldBeClosedAndPassedDataShouldBePopulatedIntoRespectiveFieldsAnd(string Select_Class, string Weight, string Quantity)
        {
            WaitForElementVisible(attributeName_xpath, LTL_Classification_SelectedValue_Xpath, "Select or search for a class or saved item...");

            string ActualClassification = Gettext(attributeName_xpath, LTL_Classification_SelectedValue_Xpath);
            Assert.AreEqual(Select_Class, ActualClassification);

            string ActualWeight = GetValue(attributeName_id, LTL_Weight_Id, "value");
            Assert.AreEqual(Weight, ActualWeight);

            string ActualQuantity = GetValue(attributeName_id, LTL_Quantity_Id, "value");
            Assert.AreEqual(Quantity, ActualQuantity);

        }


        [Then(@"Apply class button should be disabled till the data passed in all the required fields")]
        public void ThenApplyClassButtonShouldBeDisabledTillTheDataPassedInAllTheRequiredFields()
        {
            bool value = IsElementDisabled(attributeName_xpath, LTL_EstimateClass_ApplyClass_Xpath, "Apply Class Button");
            Assert.AreEqual(value.ToString(), "True");
        }

        [Then(@"pop-up model should be closed")]
        public void ThenPop_UpModelShouldBeClosed()
        {
            WaitForElementNotVisible(attributeName_xpath, LTL_EstimateClass_HeaderText_Xpath, "Estimate popup not visible");
        }

        [Then(@"I should be able to verify the maximum character limits for all the fields")]
        public void ThenIShouldBeAbleToVerifyTheMaximumCharacterLimitsForAllTheFields()
        {
            WaitForElementVisible(attributeName_id, LTL_EstimateClass_Length_Id, "Length Field");

            string ActualLengthChar = GetValue(attributeName_id, LTL_EstimateClass_Length_Id, "maxlength");
            Assert.AreEqual(ActualLengthChar, "6");

            string ActualWidthtChar = GetValue(attributeName_id, LTL_EstimateClass_Width_Id, "maxlength");
            Assert.AreEqual(ActualWidthtChar, "6");

            string ActualHeightChar = GetValue(attributeName_id, LTL_EstimateClass_Height_Id, "maxlength");
            Assert.AreEqual(ActualHeightChar, "6");

            string ActualWeightChar = GetValue(attributeName_id, LTL_EstimateClass_Weight_Id, "maxlength");
            Assert.AreEqual(ActualWeightChar, "5");

            string ActualQuantityChar = GetValue(attributeName_id, LTL_EstimateClass_Quantity_Id, "maxlength");
            Assert.AreEqual(ActualQuantityChar, "3");
        }


        [Then(@"another set of Select Class , Density calculator Icon, Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should be displayed")]
        public void ThenAnotherSetOfSelectClassDensityCalculatorIconWeightQuantityQuantity_TypeAddAdditionItemAndRemoveItemButtonShouldBeDisplayed()
        {
            WaitForElementVisible(attributeName_id, LTL_Additinal_Weight_Id, "Additional Weight Field");
            WaitForElementVisible(attributeName_id, LTL_Additional_DensityCalculator_Icon_Id, "Additional Density Calculator Icon");
            WaitForElementVisible(attributeName_id, LTL_Additional_Quantity_Id, "Additional Quanity Field");
            Verifytext(attributeName_xpath, LTL_Additional_QuantityType_Xpath, "Skids");
            WaitForElementVisible(attributeName_xpath, LTL_RemoveAdditionalItemLink_Xpath, "Remove Item");
            WaitForElementVisible(attributeName_id, LTL_Additional_SelectClass_Id, "Select Class");


        }


        [Then(@"another set of Select Class , Density calculator Icon, Weight, Quantity , Quantity_Type , Add Addition Item and Remove Item button should disappear")]
        public void ThenAnotherSetOfSelectClassDensityCalculatorIconWeightQuantityQuantity_TypeAddAdditionItemAndRemoveItemButtonShouldDisappear()
        {
            WaitForElementNotPresent(attributeName_id, LTL_Additinal_Weight_Id, "Additional Weight Field");
            WaitForElementNotPresent(attributeName_id, LTL_Additional_DensityCalculator_Icon_Id, "Additional Density Calculator Icon");
            WaitForElementNotPresent(attributeName_id, LTL_Additional_Quantity_Id, "Additional Quanity Field");
            WaitForElementNotPresent(attributeName_xpath, LTL_RemoveAdditionalItemLink_Xpath, "Remove Item");
            WaitForElementNotPresent(attributeName_id, LTL_Additional_SelectClass_Id, "Select Class");
            WaitForElementNotPresent(attributeName_xpath, LTL_Additional_QuantityType_Xpath, "Skids");
        }








        [Then(@"the information should be displayed")]
        public void ThenTheInformationShouldBeDisplayed()
        {
            string ExpectedInfo = " Normal method to determine insured value:  Invoice  Cost, plus  Insurance  Cost, plus any prepaid freight charges, all plus 10%";
            string ActualInfo = GetValue(attributeName_id, LTL_QuestionMarkIcon_Id, "data-title");
            Assert.AreEqual(ExpectedInfo, ActualInfo);
        }

        [Then(@"terms and conditions popup should be displayed")]
        public void ThenTermsAndConditionsPopupShouldBeDisplayed()
        {
            Report.WriteLine("Terms and Conditions pop up should be displayed");
            WaitForElementVisible(attributeName_xpath, LTL_Terms_PopupHeader_Xpath, "Terms and Conditions Popup");
        }

        [Then(@"I should display with valid text in terms and conditions popup")]
        public void ThenIShouldDisplayWithValidTextInTermsAndConditionsPopup()
        {
            Report.WriteLine("DisplayWithValidTextInTermsAndConditionsPopup");
            string actual1 = Gettext(attributeName_xpath, LTL_termsandctext);
            if (actual1.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured for All Risk coverage per the terms and conditions of the policy which are attached on page 2. The deductible is $500.00 and includes coverage on goods and/ or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts.See “Evidence of Insurance” page for special insuring conditions as well as excluded commodities."))
            {
                Console.WriteLine("first paragraph is correct");


                string actual2 = Gettext(attributeName_xpath, LTL_termsandctext);
                if (actual2.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include all supporting documentation.I.e.copy of the bill of lading, a copy of the delivery receipt, the commercial invoice that outlines the value of the shipment and a photo demonstrating that damage did occur during transit."))
                {
                    Console.WriteLine("second paragraph is correct");

                }
                string actual3 = Gettext(attributeName_xpath, LTL_termsandctext);
                if (actual3.Contains("User also understands and agrees that DLS Worldwide reserves the right to file a subrogated claim with the carrier and that DLS Worldwide also reserves the right to refuse program access due to inaccurate or fraudulent claims, excessive claims history and/ or failure to complete with recommended shipping and/ or packaging guidelines."))
                {
                    Console.WriteLine("third paragraph is correct");

                }
            }
            else
            {
                throw new System.Exception("text is not valid");
            }


        }

        [Then(@"I should display with valid text in terms and conditions popup on results page")]
        public void ThenIShouldDisplayWithValidTextInTermsAndConditionsPopupOnResultsPage()
        {
            Report.WriteLine("DisplayWithValidTextInTermsAndConditionsPopup");
            Thread.Sleep(1000);
            string actual1 = Gettext(attributeName_xpath, LTL_Rtermsandctext);
            if (actual1.Contains("User understands and agrees by selecting this option, the goods being shipped will be insured for All Risk coverage per the terms and conditions of the policy which are attached on page 2. The deductible is $500.00 and includes coverage on goods and/ or merchandise consisting of new and used general commodities, including new, used and remanufactured equipment or equipment parts.See “Evidence of Insurance” page for special insuring conditions as well as excluded commodities."))
            {
                Console.WriteLine("first paragraph is correct");


                string actual2 = Gettext(attributeName_xpath, LTL_Rtermsandctext);
                if (actual2.Contains("User understands and agrees to file any and all claims within 60 days with their DLS Worldwide account rep (or supporting operations team) as soon as possible after the claim becomes known and that when filing claims they are to include all supporting documentation.I.e.copy of the bill of lading, a copy of the delivery receipt, the commercial invoice that outlines the value of the shipment and a photo demonstrating that damage did occur during transit."))
                {
                    Console.WriteLine("second paragraph is correct");

                }
                string actual3 = Gettext(attributeName_xpath, LTL_Rtermsandctext);
                if (actual3.Contains("User also understands and agrees that DLS Worldwide reserves the right to file a subrogated claim with the carrier and that DLS Worldwide also reserves the right to refuse program access due to inaccurate or fraudulent claims, excessive claims history and/ or failure to complete with recommended shipping and/ or packaging guidelines."))
                {
                    Console.WriteLine("third paragraph is correct");

                }
            }
            else
            {
                throw new System.Exception("text is not valid");
            }
        }



        [Then(@"popup should be closed and user should remain in shipment information page")]
        public void ThenPopupShouldBeClosedAndUserShouldRemainInShipmentInformationPage()
        {
            Thread.Sleep(1000);
            VerifyElementNotVisible(attributeName_xpath, LTL_Terms_PopupHeader_Xpath, "Terms and Conditions Popup");
        }

        [Then(@"error message should be displayed for entering maximum shipment value")]
        public void ThenErrorMessageShouldBeDisplayedForEnteringMaximumShipmentValue()
        {
            string ActualError = Gettext(attributeName_xpath, LTL_MaxShipmentValue_Error_Xpath);
            string ExpectedError = "The entered shipment value exceeds $100,000. Please contact your RR Donnelley representatives.";
            Assert.AreEqual(ExpectedError, ActualError);
        }


        [Then(@"rate results page should be displayed")]
        public void ThenRateResultsPageShouldBeDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, ltlDisclaimer_xpath, "Disclaimer");
        }

        [Then(@"no rate results page should be displayed")]
        public void ThenNoRateResultsPageShouldBeDisplayed()
        {
            WaitForElementVisible(attributeName_xpath, ltlnorateresultsheader_xpath, "No rate results page");
        }

        [When(@"I enter zipcode (.*) and leave focus from the origin section")]
        public void WhenIEnterZipcodeAndLeaveFocusFromTheOriginSection(string Zip)
        {
            Report.WriteLine("Entering origin zipcode");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, Zip);
            Click(attributeName_id, LTL_DestinationCity_Id);
        }

        [Then(@"City (.*) and State (.*) fields should be populated in origin section")]
        public void ThenCityAndStateFieldsShouldBePopulatedInOriginSection(string City, string State)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verify the populated data in origin city and state fields");
            string ActualCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
            Assert.AreEqual(City, ActualCity);

            string ActualState = Gettext(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(State, ActualState);
        }

        [When(@"I enter zipcode (.*) and leave focus from the destination section")]
        public void WhenIEnterZipcodeAndLeaveFocusFromTheDestinationSection(string Zip)
        {
            Report.WriteLine("Entering destination zipcode");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, Zip);
            scrollPageup();
            Click(attributeName_id, LTL_OriginCity_Id);
        }

        [Then(@"City (.*) and State (.*) fields should be populated in destination section")]
        public void ThenCityAndStateFieldsShouldBePopulatedInDestinationSection(string City, string State)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verify the populated data in destination city and state fields");
            string ActualCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
            Assert.AreEqual(City, ActualCity);

            string ActualState = Gettext(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
            Assert.AreEqual(State, ActualState);
        }




        [Then(@"background color of the origin zip code textbox should turn red and error message should be displayed")]
        public void ThenBackgroundColorOfTheOriginZipCodeTextboxShouldTurnRedAndErrorMessageShouldBeDisplayed()
        {
            string ActualbackgroundColor = GetCSSValue(attributeName_id, LTL_OriginZipPostal_Id, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"the Origin City and State will not Auto populate")]
        public void ThenTheOriginCityAndStateWillNotAutoPopulate()
        {
            Report.WriteLine("Verifying Origin City is not Auto populating");
            string ActualOriginCity = GetValue(attributeName_id, LTL_OriginCity_Id, "value");
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
            string ActualOriginState = GetValue(attributeName_id, LTL_OriginStateProvince_Id, "value");
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

        [Then(@"the Destination City and State will not Auto populate")]
        public void ThenTheDestinationCityAndStateWillNotAutoPopulate()
        {

            Report.WriteLine("Verifying Origin City is not Auto populating");
            string ActualDestCity = GetValue(attributeName_id, LTL_DestinationCity_Id, "value");
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
            string ActualDestState = GetValue(attributeName_id, LTL_DestinationStateProvince_Id, "value");
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


        [Then(@"background color of the destination zip code textbox should turn red and error message should be displayed")]
        public void ThenBackgroundColorOfTheDestinationZipCodeTextboxShouldTurnRedAndErrorMessageShouldBeDisplayed()
        {
            //string ActualError = Gettext(attributeName_id, LTL_RequiredFieldError_Id);
            //string ExpectedError = "INCORRECT ZIP CODE";
            //Assert.AreEqual(ExpectedError, ActualError);
            string ActualbackgroundColor = GetCSSValue(attributeName_id, LTL_DestinationZipPostal_Id, "background-color");
            string ExpectedbackgroundColor = "rgba(251, 236, 236, 1)";
            Assert.AreEqual(ExpectedbackgroundColor, ActualbackgroundColor);
        }

        [Then(@"error message should be displayed inside the postal lookup popup")]
        public void ThenErrorMessageShouldBeDisplayedInsideThePostalLookupPopup()
        {
            string ExpectedMessage = "NO RESULTS FOUND. PLEASE TRY AGAIN";
            WaitForElementVisible(attributeName_id, LTL_Lookup_ErrorMessage_Id, "Error Message");
            string ActualMessage = Gettext(attributeName_id, LTL_Lookup_ErrorMessage_Id);
            Assert.AreEqual(ExpectedMessage, ActualMessage);
        }

        [When(@"I select Canada Country from destination country dropdown")]
        public void WhenISelectCanadaCountryFromDestinationCountryDropdown()
        {
            Report.WriteLine("Selecting Country as Canada from Destination Country dropdown");
            Click(attributeName_id, LTL_DestinationCountryDropdown_Id);
            Click(attributeName_xpath, LTL_DestinationCanadaCountryDropdown_Xpath);
        }

        [When(@"I select Canada Country from origin country dropdown")]
        public void WhenISelectCanadaCountryFromOriginCountryDropdown()
        {
            Report.WriteLine("Selecting Country as Canada from Origin Country dropdown");
            Click(attributeName_xpath, LTL_OriginCountryDropdown_Xpath);
            Click(attributeName_xpath, LTL_OriginCanadaCountryDropdown_Xpath);
        }


        [Then(@"Terms and Conditions link should be displayed")]
        public void ThenTermsAndConditionsLinkShouldBeDisplayed()
        {
            Click(attributeName_id, LTL_Quantity_Id);
            Report.WriteLine("Terms and Conditions link should be visible");
            VerifyElementVisible(attributeName_xpath, LTL_TermsAndConditionsLink_Xpath, "Terms and Conditions");
        }

        [When(@"Click on Download DLSW Claim Form displaying in Terms and Conditions modal")]
        public void WhenClickOnDownloadDLSWClaimFormDisplayingInTermsAndConditionsModal()
        {
            Report.WriteLine("Display Download DLSW Claim Form");
            VerifyElementPresent(attributeName_xpath, ltlDownloadDLSW_xpath, "Download DLSW Claim Form");
            Thread.Sleep(1000);
            Click(attributeName_xpath, ltlDownloadDLSW_xpath);
        }

        [Then(@"DLSW Claim Form is downloaded")]
        public void ThenDLSWClaimFormIsDownloaded()
        {
            Report.WriteLine("DLSW Claim Form will be downloaded");
            Thread.Sleep(2000);
            string downloadpath = GetDownloadedFilePath("DownloadDlswwClaimsForm.docx");
            Assert.IsTrue(File.Exists(downloadpath));
            DeleteFilesFromFolder(downloadpath);
        }

        [Then(@"Close button should be displayed in modal")]
        public void ThenCloseButtonShouldBeDisplayedInModal()
        {
            Report.WriteLine("Close button displaying in Terms and Conditions pop up");
            WaitForElementVisible(attributeName_xpath, LTL_Terms_PopupClose_Xpath, "Close Button");
        }

        [Then(@"I click on close button")]
        public void ThenIClickOnCloseButton()
        {
            Report.WriteLine("Clicking on close button in terms and conditions popup");
            WaitForElementVisible(attributeName_xpath, LTL_Terms_PopupClose_Xpath, "Close Button");
            Click(attributeName_xpath, LTL_Terms_PopupClose_Xpath);
        }

        [When(@"I have not entered the data in (.*) field of Freight Description section")]
        public void WhenIHaveNotEnteredTheDataInFieldOfFreightDescriptionSection(string Insuredvalue)
        {
            Report.WriteLine("Not Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);
        }

        [Then(@"Terms and Conditions link should not be displayed")]
        public void ThenTermsAndConditionsLinkShouldNotBeDisplayed()
        {
            Click(attributeName_id, LTL_Quantity_Id);
            Report.WriteLine("Terms and Conditions link should be visible");
            VerifyElementNotVisible(attributeName_xpath, LTL_TermsAndConditionsLink_Xpath, "Terms and Conditions");
        }


        [Then(@"I have the option to select a state from the state drop down list in shipping to section(.*)")]
        public void ThenIHaveTheOptionToSelectAStateFromTheStateDropDownListInShippingToSection(string State)
        {
            Report.WriteLine("Selecting Destination State from Destination State dropdown");
            Click(attributeName_id, LTL_DestinationStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_DestinationStateProvinceValues_Xpath, State);
        }

        [Then(@"I have the option to select a state from the state drop down list in shipping from section(.*)")]
        public void ThenIHaveTheOptionToSelectAStateFromTheStateDropDownListInShippingFromSection(string State)
        {
            Report.WriteLine("Selecting Origin State from Origin State dropdown");
            Click(attributeName_id, LTL_OriginStateProvince_Id);
            SelectDropdownValueFromList(attributeName_xpath, LTL_OriginStateProvinceValues_Xpath, State);
        }

        [Then(@"I have the ability to edit the city in shipping to section(.*)")]
        public void ThenIHaveTheAbilityToEditTheCityInShippingToSection(string City)
        {
            Report.WriteLine("Verifying functionality ability to edit the city in shipping to section");
            Clear(attributeName_id, LTL_DestinationCity_Id);
            SendKeys(attributeName_id, LTL_DestinationCity_Id, City);
            string UICity = GetAttribute(attributeName_id, LTL_DestinationCity_Id, "value");
            Assert.AreEqual(City, UICity);
        }

        [Then(@"I have the ability to edit the city in shipping from section(.*)")]
        public void ThenIHaveTheAbilityToEditTheCityInShippingFromSection(string City)
        {
            Report.WriteLine("Verifying functionality ability to edit the city in shipping from section");
            Clear(attributeName_id, LTL_OriginCity_Id);
            SendKeys(attributeName_id, LTL_OriginCity_Id, City);
            string UICity = GetAttribute(attributeName_id, LTL_OriginCity_Id, "value");
            Assert.AreEqual(City, UICity);
        }


        [Then(@"the Select State/Province drop down list will be populated with a list of Canada provinces  in Shipping To section")]
        public void ThenTheSelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingToSection()
        {
            Report.WriteLine("Verifying drop down list will be populated with a list of Canada provinces in Shipping To section");
            Click(attributeName_xpath, LTL_DestinationStateProvince_SelectedValue_Xpath);
            IList<IWebElement> Destination_StateProvince_UI_list = GlobalVariables.webDriver.FindElements(By.XPath(LTL_DestinationStateProvinceValues_Xpath));
            List<string> Origin_StateProvince_UI = Destination_StateProvince_UI_list.Skip(1).Select(c => c.Text).ToList();
            List<string> Origin_StateProvince_list = new List<string>
           {
               "AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"
           };
            CollectionAssert.AreEqual(Origin_StateProvince_UI, Origin_StateProvince_list);

        }

        [Then(@"the Select State/Province drop down list will be populated with a list of Canada provinces in Shipping From section")]
        public void ThenTheSelectStateProvinceDropDownListWillBePopulatedWithAListOfCanadaProvincesInShippingFromSection()
        {
            Report.WriteLine("Verifying drop down list will be populated with a list of Canada provinces in Shipping From section");
            Click(attributeName_xpath, LTL_OriginStateProvince_SelectedValue_Xpath);
            IList<IWebElement> Origin_StateProvince_UI_list = GlobalVariables.webDriver.FindElements(By.XPath(LTL_OriginStateProvinceValues_Xpath));
            List<string> Origin_StateProvince_UI = Origin_StateProvince_UI_list.Skip(1).Select(c => c.Text).ToList();
            List<string> Origin_StateProvince_list = new List<string>
           {
               "AB","BC","MB","NB","NL","NS","NT","NU","ON","PE","QC","SK","YT"
           };
            CollectionAssert.AreEqual(Origin_StateProvince_UI, Origin_StateProvince_list);
        }
        [When(@"I enter valid data in Shipping From Section (.*)")]
        public void WhenIEnterValidDataInShippingFromSection(string SFZiporpostal)
        {
            Report.WriteLine("Entering Zip/postal code in Shipping from section");
            Click(attributeName_id, ZipcodeforShippingFrom_id);
            SendKeys(attributeName_id, ZipcodeforShippingFrom_id, SFZiporpostal);
        }

        [When(@"I enter valid data in Shipping To Section (.*)")]
        public void WhenIEnterValidDataInShippingToSection(string STZiporPostal)
        {
            Report.WriteLine("Entering Zip/postal code in Shipping from section");
            Click(attributeName_id, ZipcodeforShippingTo_id);
            SendKeys(attributeName_id, ZipcodeforShippingTo_id, STZiporPostal);
        }

        [When(@"I enter valid data in Freight Description Section (.*), (.*)")]
        public void WhenIEnterValidDataInFreightDescriptionSection(string classification, string weight)
        {
            Report.WriteLine("Enter details in Freight Description section");
            Click(attributeName_id, LTL_Weight_Id);
            Click(attributeName_id, LTL_Classification_Id);
            Thread.Sleep(1000);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == classification)
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            Click(attributeName_id, LTL_Weight_Id);
            SendKeys(attributeName_id, LTL_Weight_Id, weight);
        }

        [When(@"I select any of the type from '(.*)' dropdown")]
        public void WhenISelectAnyOfTheTypeFromDropdown(string InsuredvalueType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredvalueType);

        }
        [When(@"I have not entered data in '(.*)' field of Freight Description section")]
        public void WhenIHaveNotEnteredDataInFieldOfFreightDescriptionSection(string Insuredvalue)
        {
            Report.WriteLine("Not Entering data in Enter Insured value text box");
            SendKeys(attributeName_id, LTL_EnterInsuredValue_Id, Insuredvalue);
        }

        [When(@"I have not selected any of the type from '(.*)' dropdown")]
        public void WhenIHaveNotSelectedAnyOfTheTypeFromDropdown(string InsuredvalueType)
        {
            Report.WriteLine("Insured type dropdown not enabled");
            Click(attributeName_xpath, InsuredType_Xpath);
        }

        [When(@"I select New insured type from '(.*)' dropdown")]
        public void WhenISelectNewInsuredTypeFromDropdown(string InsuredvalueType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredvalueType);
        }

        [When(@"I select Used insured type from '(.*)' dropdown")]
        public void WhenISelectUsedInsuredTypeFromDropdown(string InsuredvalueType)
        {
            Report.WriteLine("Select Insured type from dropdown");
            Click(attributeName_xpath, InsuredType_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, InsuredValueTypeDropDown_Xpath, InsuredvalueType);
        }

        [Then(@"I must be able to view Services & Accessorials multi select field in the Ship\.To section")]
        public void ThenIMustBeAbleToViewServicesAccessorialsMultiSelectFieldInTheShip_ToSection()
        {
            Report.WriteLine("Display of Services And Accessorials Multi Select dropdown in ShipTo Section");
            VerifyElementPresent(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath, "ShipFrom Multi select dropdown");
        }

        [Then(@"I must be able to view Services & Accessorials multi select field in the Ship\.From section")]
        public void ThenIMustBeAbleToViewServicesAccessorialsMultiSelectFieldInTheShip_FromSection()
        {

            Report.WriteLine("Display of Services And Accessorials Multi Select dropdown in ShipFrom Section");
            VerifyElementPresent(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath, "ShipFrom Multi select dropdown");

        }

        [When(@"I click services and accessorials dropdown on Ship From section")]
        public void WhenIClickServicesAndAccessorialsDropdownOnShipFromSection()
        {
            Report.WriteLine("Click on Services and Accessorials");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);

        }

        [Then(@"I should be able to select services '(.*)' and '(.*)' from Ship\.From Section")]
        public void ThenIShouldBeAbleToSelectServicesAndFromShip_FromSection(string Accessorials1, string Accessorials2)
        {
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath, Accessorials1);
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath, Accessorials2);

        }
        [When(@"I select a service '(.*)' from the Ship\.From section dropdown")]
        public void WhenISelectAServiceFromTheShip_FromSectionDropdown(string Accessorials1)
        {
            Report.WriteLine("Selection of Accessorials and Services");
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipFrom_Xpath, Accessorials1);

        }
        [Then(@"I must have an option to delete the service selected from the Ship\.From dropdown")]
        public void ThenIMustHaveAnOptionToDeleteTheServiceSelectedFromTheShip_FromDropdown()
        {
            Report.WriteLine("Deltion of Accessorials and services selected");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipFrom_Del_Xpath);

        }

        [Then(@"I should be able to view specified Ship\.From services in the dropdown")]
        public void ThenIShouldBeAbleToViewSpecifiedShip_FromServicesInTheDropdown()
        {
            Report.WriteLine("Verification of Ship.From dropdown values");
            IList<IWebElement> ShipFromDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='servicesaccessorialsfrom_chosen']/div/ul/li"));
            List<string> ShipFromValues = new List<string>(new string[] { "Appointment", "Construction Site", "Convention-Exhibition Site Pickup", "Excessive Overlength (LKVL Only)", "Hazardous Material", "Inside Pickup", "Liftgate Pickup", "Limited Access Pickup", "Origin Sort and Segregate", "Overlength", "Protect From Freeze", "Residential Pickup" });
            int ShipFromCountUI = ShipFromDropdownList.Count;

            foreach (var val in ShipFromDropdownList)
            {
                if (ShipFromValues.Contains(val.Text))
                {
                    Report.WriteLine("Display of" + val.Text + " Ship.From values");

                }
                else
                {
                    Assert.Fail();

                }
            }
        }

        [When(@"I click services and accessorials dropdown on Ship To section")]
        public void WhenIClickServicesAndAccessorialsDropdownOnShipToSection()
        {
            Report.WriteLine("Click on Services and Accessorials");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);

        }

        [Then(@"I should be able to select services '(.*)' and '(.*)' from Ship\.To Section")]
        public void ThenIShouldBeAbleToSelectServicesAndFromShip_ToSection(string Accessorials1, string Accessorials2)
        {
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, Accessorials1);
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, Accessorials2);

        }

        [When(@"I select a service '(.*)' from the Ship\.To section dropdown")]
        public void WhenISelectAServiceFromTheShip_ToSectionDropdown(string Accessorials1)
        {
            Report.WriteLine("Selection of Accessorials and Services");
            SelectDropdownValueFromList(attributeName_xpath, LTL_ServicesDropdownValues_ShipTo_Xpath, Accessorials1);

        }

        [Then(@"I must have an option to delete the service selected from the Ship\.To dropdown")]
        public void ThenIMustHaveAnOptionToDeleteTheServiceSelectedFromTheShip_ToDropdown()
        {
            Report.WriteLine("Deltion of Accessorials and services selected");
            Click(attributeName_xpath, LTL_ServicesAndAccessorials_ShipTo_Del_Xpath);

        }

        [Then(@"I should be able to view specified Ship\.To Services in the dropdown")]
        public void ThenIShouldBeAbleToViewSpecifiedShip_ToServicesInTheDropdown()
        {
            Report.WriteLine("Verification of Ship.To dropdown values");
            IList<IWebElement> ShipToDropdownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='servicesaccessorialsto_chosen']/div/ul/li"));
            List<string> ShipToValues = new List<string>(new string[] { "Appointment", "COD", "Construction Site", "Convention-Exhibition Site Delivery", "Excessive Overlength (LKVL Only)", "Hazardous Material", "Inside Delivery", "Liftgate Delivery", "Limited Access Delivery", "Overlength", "Protect From Freeze", "Residential Delivery", "Sort And Segregate", "Special Delivery" });
            int ShipToCountUI = ShipToDropdownList.Count;

            foreach (var val in ShipToDropdownList)
            {
                if (ShipToValues.Contains(val.Text))
                {
                    Report.WriteLine("Display of" + val.Text + " Ship.To values");

                }
                else
                {
                    Assert.Fail();

                }
            }
        }
    }
}
