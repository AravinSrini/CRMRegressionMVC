using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.ViewModel;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.OverLength_GetQuote_LTL_
{
    [Binding]
    public class _40948_Saved_Quote_to_Shipment___Create_Shipment___Saved_Address_Information : AddShipments
    {
        Address _addressDB;
        string savedQuoteNumber;
        string customerName= "ZZZ - Czar Customer Test";
        string dZip = "85282";
        string oZip = "85282";
        int accountid;
        string name;

        ShipmentExtractViewModel shipmentViewModels = new ShipmentExtractViewModel();
        RateToShipmentLTL rTS = new RateToShipmentLTL();
        CommonMethodsCrm crm = new CommonMethodsCrm();

        string CustomerName = null;
        [Given(@"I am a shp\.entry, operations, sales, sales management or a station user")]
        public void GivenIAmAShp_EntryOperationsSalesSalesManagementOrAStationUser()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();

            crm.LoginToCRMApplication(username, password);

            GlobalVariables.webDriver.WaitForPageLoad();

        }

       

        [Given(@"the Saved Quote contained a Saved Address in the Shipping From section")]
        public void GivenTheSavedQuoteContainedASavedAddressInTheShippingFromSection()
        {
            _addressDB = DBHelper.FirstAddress(customerName);
            name = _addressDB.Name;
            commonStepToSavedQuote(name);
        }


        [Given(@"the Saved Quote contained a Saved Default Consignee Address in the Shipping To section")]
        public void GivenTheSavedQuoteContainedASavedDefaultConsigneeAddressInTheShippingToSection()
        {
            accountid = DBHelper.GetCustomerAccountId(customerName);
            _addressDB = DBHelper.GetConsigneeAddressforAccount(accountid);
            name = _addressDB.Name;
            commonStepToSavedQuote_DefaultConsigneeAddress(name);
        }


        [Given(@"the Saved Quote contained a Saved Default Shipper Address in the Shipping From section")]
        public void GivenTheSavedQuoteContainedASavedDefaultShipperAddressInTheShippingFromSection()
        {
            accountid = DBHelper.GetCustomerAccountId(customerName);
            _addressDB = DBHelper.GetShipperAddressforAccount(accountid);
            name = _addressDB.Name;
            commonStepToSavedQuote_DefaultShipmentAddress(name);
        }


        [Given(@"the Saved Quote contained a Saved Address in the Shipping To section")]
        public void GivenTheSavedQuoteContainedASavedAddressInTheShippingToSection()
        {
            _addressDB = DBHelper.FirstAddress(customerName);
              string name = _addressDB.Name;
            //commonStepToSavedQuote(name);
            commonStepToSavedQuote_DestinationAddress(name);
        }



        [When(@"I arrive on the Add Shipment\(LTL\) page,")]
        public void WhenIArriveOnTheAddShipmentLTLPage()
        {
            
                Click(attributeName_id, "Btn_BackQuoteList");
                GlobalVariables.webDriver.WaitForPageLoad();
                SendKeys(attributeName_id, "searchbox", savedQuoteNumber);
                GlobalVariables.webDriver.WaitForPageLoad();

                Click(attributeName_xpath, QuoteExpand_Xpath);
                WaitForElementVisible(attributeName_id, QuoteCreateShipment_Id, "create Shipment button");
                Click(attributeName_id, QuoteCreateShipment_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
            
        }

        [When(@"I arrive on the Add Shipment\(LTL\) page for Default Shipper Address,")]
        public void WhenIArriveOnTheAddShipmentLTLPageForDefaultShipperAddress()
        {
            if(_addressDB.AddressTypeId == 3)
            {
                WhenIArriveOnTheAddShipmentLTLPage();
            }
            else
            {
                Report.WriteLine("No Default Shipper Address for this Customer");
            }
        }



        [Then(@"I will see Saved Address will be PrePopulated in the Shipping from section")]
        public void ThenIWillSeeSavedAddressWillBePrePopulatedInTheShippingFromSection()
        {
            string actualLocationName = GetValue(attributeName_id, ShippingFrom_LocationName_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Name))
            {

                Assert.AreEqual((_addressDB.Name).ToLower(), actualLocationName.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationName);
            }

            string actualLocationAddress1 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Address1))
            {

                Assert.AreEqual((_addressDB.Address1).ToLower(), actualLocationAddress1.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationAddress1);
            }

            string actualLocationAddress2 = GetValue(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Address2))
            {

                Assert.AreEqual((_addressDB.Address2).ToLower(), actualLocationAddress2.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationAddress2);
            }

            string actualLocationZip_PostalCode = GetValue(attributeName_id, ShippingFrom_zipcode_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Zip))
            {

                Assert.AreEqual((_addressDB.Zip).ToLower(), actualLocationZip_PostalCode);
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationZip_PostalCode);
            }

            string actualLocationCity = GetValue(attributeName_id, ShippingFrom_City_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.City))
            {

                Assert.AreEqual((_addressDB.City).ToLower(), actualLocationCity.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationCity);
            }

            string actualLocationState = Gettext(attributeName_xpath, ShippingFrom_StateDropdwon_SelectedValue_xpath);
            if (!string.IsNullOrWhiteSpace(_addressDB.State))
            {

                Assert.AreEqual((_addressDB.State).ToLower(), actualLocationState.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationState);
            }

            string actualLocationcountry = Gettext(attributeName_xpath, ShippingFrom_CountryDropDown_SelectedValue_xpath);
            if (!string.IsNullOrWhiteSpace(_addressDB.Country))
            {
                if (actualLocationcountry == "United States")
                {
                    Assert.AreEqual(_addressDB.Country, "United States");
                }
                if (actualLocationcountry == "Canada")
                {
                    Assert.AreEqual(_addressDB.Country, "Canada");
                }
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationcountry);
            }

            string actualComments = GetValue(attributeName_id, ShippingFrom_Comments_Id, "value");
            //if (_addressDB.Comment != null || _addressDB.Comment != string.Empty)
                if (!string.IsNullOrWhiteSpace(_addressDB.Comment))
            { 

                Assert.AreEqual((_addressDB.Comment).ToLower(), actualComments.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualComments);
            }

            string actualContactName = GetValue(attributeName_id, ShippingFrom_ContactName_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.ContactName))
            {

                Assert.AreEqual((_addressDB.ContactName).ToLower(), actualContactName.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactName);
            }

            string actualContactPhone = GetValue(attributeName_id, ShippingFrom_ContactPhone_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.PhoneNumber))
            {

                Assert.AreEqual(_addressDB.PhoneNumber, actualContactPhone);
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactPhone);
            }

            string actualContactFax = GetValue(attributeName_id, ShippingFrom_ContactFax_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.FaxNumber))
            {

                Assert.AreEqual(_addressDB.FaxNumber, actualContactFax);
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactFax);
            }

            string actualContactEmail = GetValue(attributeName_id, ShippingFrom_ContactEmail_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.EmailId))
            {

                Assert.AreEqual((_addressDB.EmailId).ToLower(), actualContactEmail.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactEmail);
            }

        }

        [Then(@"I will see Shipping From section fields are Non Editable")]
        public void ThenIWillSeeShippingFromSectionFieldsAreNonEditable()
        {
            if (!string.IsNullOrWhiteSpace(_addressDB.Name))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingFrom_LocationName_Id, "Location Name");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingFrom_LocationName_Id, "Location Name");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Address1))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address 1 field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingFrom_LocationAddressLine1_Id, "Address 1 field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Address2))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "Address 2field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingFrom_LocationAddressLine2_Id, "Address 2field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Zip))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingFrom_zipcode_Id, "Zip field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingFrom_zipcode_Id, "Zip field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.City))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingFrom_City_Id, "city field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingFrom_City_Id, "city field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.State))
            {

                bool elementDisabled = IsElementDisabled(attributeName_xpath, ShippingFrom_StateDropdwon_xpath, "State field");
                Assert.IsTrue(elementDisabled);
            }
            else
            {
                Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
                Click(attributeName_xpath, ".//*[@id='state_origin_select_chosen']/div/ul/li[2]");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Country))
            {

                bool elementDisabled = IsElementDisabled(attributeName_xpath, ShippingFrom_CountryDropDown_xpath, "Country field");
                Assert.IsTrue(elementDisabled);
            }
            else
            {
                Click(attributeName_xpath, ShippingFrom_StateDropdwon_xpath);
                Click(attributeName_xpath, ".//*[@id='select_origin_country_chosen']/div/ul/li[2]");
            }
        }

        [Then(@"I will see Comment field of Shipping from section is Editable")]
        public void ThenIWillSeeCommentFieldOfShippingFromSectionIsEditable()
        {
            VerifyElementEnabled(attributeName_id, ShippingFrom_Comments_Id, "Comment");
        }

        [Then(@"I will see Shipping From Contact section fields are Editable")]
        public void ThenIWillSeeShippingFromContactSectionFieldsAreEditable()
        {
            VerifyElementEnabled(attributeName_id, ShippingFrom_ContactName_Id, "ContactName");
            VerifyElementEnabled(attributeName_id, ShippingFrom_ContactPhone_Id, "ContactPhone");
            VerifyElementEnabled(attributeName_id, ShippingFrom_ContactEmail_Id, "Email");
            VerifyElementEnabled(attributeName_id, ShippingFrom_ContactFax_Id, "Fax");
        }



        [Then(@"I will see Saved Address will be PrePopulated in the Shipping To section")]
        public void ThenIWillSeeSavedAddressWillBePrePopulatedInTheShippingToSection()
        {
            //bool a = IsElementDisabled(attributeName_xpath, ".//*[@id='state_destination_select_chosen']/a/span", "statedropdow");
            //bool b = IsElementDisabled(attributeName_xpath, ".//*[@id='state_destination_select_chosen']/a", "statedropdow");

            

            string actualLocationName = GetValue(attributeName_id, ShippingTo_LocationName_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Name))
            {

                Assert.AreEqual((_addressDB.Name).ToLower(), actualLocationName.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationName);
            }

            string actualLocationAddress1 = GetValue(attributeName_id, ShippingTo_LocationAddressLine1_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Address1))
            {

                Assert.AreEqual((_addressDB.Address1).ToLower(), actualLocationAddress1.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationAddress1);
            }

            string actualLocationAddress2 = GetValue(attributeName_id, ShippingTo_LocationAddressLine2_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Address2))
            {

                Assert.AreEqual((_addressDB.Address2).ToLower(), actualLocationAddress2.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationAddress2);
            }

            string actualLocationZip_PostalCode = GetValue(attributeName_id, ShippingTo_zipcode_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Zip))
            {

                Assert.AreEqual((_addressDB.Zip).ToLower(), actualLocationZip_PostalCode);
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationZip_PostalCode);
            }

            string actualLocationCity = GetValue(attributeName_id, ShippingTo_City_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.City))
            {

                Assert.AreEqual((_addressDB.City).ToLower(), (actualLocationCity).ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationCity);
            }

            string actualLocationState = Gettext(attributeName_xpath, ShippingTo_StateDropdwon_SelectedValue_xpath);
            if (!string.IsNullOrWhiteSpace(_addressDB.State))
            {

                Assert.AreEqual((_addressDB.State).ToLower(), (actualLocationState).ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationState);
            }

            string actualLocationcountry = Gettext(attributeName_xpath, ShippingTo_CountryDropDown_SelectedValue_xpath);
            if (!string.IsNullOrWhiteSpace(_addressDB.Country))
            {
                if (actualLocationcountry == "United States")
                {
                    Assert.AreEqual(_addressDB.Country, "United States");
                }
                if (actualLocationcountry == "Canada")
                {
                    Assert.AreEqual(_addressDB.Country, "Canada");
                }
            }
            else
            {
                Assert.AreEqual(string.Empty, actualLocationcountry);
            }

            string actualComments = GetValue(attributeName_id, ShippingTo_Comments_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.Comment))
            {

                Assert.AreEqual((_addressDB.Comment).ToLower(), actualComments.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualComments);
            }

            string actualContactName = GetValue(attributeName_id, ShippingTo_ContactName_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.ContactName))
            {

                Assert.AreEqual((_addressDB.ContactName).ToLower(), actualContactName.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactName);
            }

            string actualContactPhone = GetValue(attributeName_id, ShippingTo_ContactPhone_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.PhoneNumber))
            {

                Assert.AreEqual(_addressDB.PhoneNumber, actualContactPhone);
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactPhone);
            }

            string actualContactFax = GetValue(attributeName_id, ShippingTo_ContactFax_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.FaxNumber))
            {

                Assert.AreEqual(_addressDB.FaxNumber, actualContactFax);
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactFax);
            }

            string actualContactEmail = GetValue(attributeName_id, ShippingTo_ContactEmail_Id, "value");
            if (!string.IsNullOrWhiteSpace(_addressDB.EmailId))
            {

                Assert.AreEqual((_addressDB.EmailId).ToLower(), actualContactEmail.ToLower());
            }
            else
            {
                Assert.AreEqual(string.Empty, actualContactEmail);
            }
        }

        [Then(@"I will see Shipping To section fields are Non Editable")]
        public void ThenIWillSeeShippingToSectionFieldsAreNonEditable()
        {
            if (!string.IsNullOrWhiteSpace(_addressDB.Name))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingTo_LocationName_Id, "Location Name");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingTo_LocationName_Id, "LocationName");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Address1))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingTo_LocationAddressLine1_Id, "Address 1 field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingTo_LocationAddressLine1_Id, "Address1");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Address2))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingTo_LocationAddressLine2_Id, "Address 2field");
            }
            else
            {
                //SendKeys(attributeName_id, ShippingTo_LocationAddressLine2_Id, "testAddress2");
                VerifyElementEnabled(attributeName_id, ShippingTo_LocationAddressLine2_Id, "Address 2 field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Zip))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingTo_zipcode_Id, "Zip field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingTo_zipcode_Id, "Zip field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.City))
            {

                VerifyElementNotEnabled(attributeName_id, ShippingTo_City_Id, "city field");
            }
            else
            {
                VerifyElementEnabled(attributeName_id, ShippingTo_City_Id, "City Field");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.State))
            {
                //VerifyElementNotEnabled(attributeName_xpath, ShippingTo_StateDropdwon_xpath, "State field");
                bool elementDisabled = IsElementDisabled(attributeName_xpath, ShippingTo_StateDropdwon_xpath, "statedropdown");
                Assert.IsTrue(elementDisabled);
            }
            else
            {
                Click(attributeName_xpath, ShippingTo_StateDropdwon_xpath);
                Click(attributeName_xpath, ".//*[@id='state_destination_select_chosen']/div/ul/li[2]");
            }

            if (!string.IsNullOrWhiteSpace(_addressDB.Country))
            {

                bool elementDisabled = IsElementDisabled(attributeName_xpath, ShippingTo_CountryDropDown_xpath, "Country field");
                Assert.IsTrue(elementDisabled);
            }
            else
            {
                Click(attributeName_xpath, ShippingTo_CountryDropDown_xpath);
                Click(attributeName_xpath, ".//*[@id='select_destination_country_chosen']/div/ul/li[2]");
            }
        }

        [Then(@"I will see Comment field of Shipping To section is Editable")]
        public void ThenIWillSeeCommentFieldOfShippingToSectionIsEditable()
        {
            //Clear(attributeName_id, ShippingTo_Comments_Id);
            //SendKeys(attributeName_id, ShippingTo_Comments_Id, "testComments");
            VerifyElementEnabled(attributeName_id, ShippingTo_Comments_Id, "Comments Field");
        }

        [Then(@"I will see Shipping To Contact section fields are Editable")]
        public void ThenIWillSeeShippingToContactSectionFieldsAreEditable()
        {
            //Clear(attributeName_id, ShippingTo_ContactName_Id);
            //SendKeys(attributeName_id, ShippingTo_ContactName_Id, "testContactName");
            VerifyElementEnabled(attributeName_id, ShippingTo_ContactName_Id, "ContactName");
            //Clear(attributeName_id, ShippingTo_ContactPhone_Id);
            VerifyElementEnabled(attributeName_id, ShippingTo_ContactPhone_Id, "ContactPhone");
            //Clear(attributeName_id, ShippingTo_ContactEmail_Id);
            VerifyElementEnabled(attributeName_id, ShippingTo_ContactEmail_Id, "Email");
            //Clear(attributeName_id, ShippingTo_ContactFax_Id);
            VerifyElementEnabled(attributeName_id, ShippingTo_ContactFax_Id, "Fax");
        }

        public void commonStepToSavedQuote(string addressFirstName)
        {
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Report.WriteLine("Navigated to Quote list page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

             
                
            Click(attributeName_id, ClearAddress_OriginId);


          rTS.SearchByNameInTheOriginSavedAddressField_Quote(addressFirstName);

            rTS.SelectFirstAddressFromTheOriginSavedAddressDropdown_Quote();
            //  Thread.Sleep(2000);
            Click(attributeName_id, ClearAddress_DestId);
            SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, dZip);

            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "50")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, "3");
            Report.WriteLine("Click on Quote Results");
            scrollElementIntoView(attributeName_id, LTL_ViewQuoteResults_Id);
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, "//*[text()='Quote Results (LTL)']", "Quote Results (LTL)");
            
            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                Report.WriteLine("Create shipment for selected carrier");


                WaitForElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button", "Create Shipment");

                Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");

                GlobalVariables.webDriver.WaitForPageLoad();

            }
            else
            {
                Click(attributeName_id, "no-results-save-quote");
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            savedQuoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
        }


        public void commonStepToSavedQuote_DestinationAddress(string addressFirstName)
        {
            Click(attributeName_xpath, QuoteIcon_Xpath);
            Report.WriteLine("Navigated to Quote list page");

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on Submit Rate Request");
            Click(attributeName_id, SubmitRateRequestButton_Id);

            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_id, ClearAddress_OriginId);
            Click(attributeName_id, ClearAddress_DestId);


            rTS.SearchByNameInTheDestinationSavedAddressField_Quote(addressFirstName);

            rTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
            //  Thread.Sleep(2000);
            //Click(attributeName_id, ClearAddress_DestId);
            SendKeys(attributeName_id, LTL_OriginZipPostal_Id, oZip);

            Click(attributeName_id, LTL_ClearItem_Id);
            scrollElementIntoView(attributeName_id, LTL_Classification_Id);
            Click(attributeName_id, LTL_Classification_Id);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "50")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
            SendKeys(attributeName_id, LTL_Weight_Id, "3");
            Report.WriteLine("Click on Quote Results");
            scrollElementIntoView(attributeName_id, LTL_ViewQuoteResults_Id);
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            string configURL = launchUrl;
            string resultPagrURL = configURL + "Rate/LtlResultsView";
            if (GetURL() == resultPagrURL)
            {
                Report.WriteLine("Rate Results available");
                Report.WriteLine("Create shipment for selected carrier");


                WaitForElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button", "Create Shipment");

                Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");

                GlobalVariables.webDriver.WaitForPageLoad();

            }
            else
            {
                Click(attributeName_id, "no-results-save-quote");
                GlobalVariables.webDriver.WaitForPageLoad();
            }

            savedQuoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
        }


        public void commonStepToSavedQuote_DefaultShipmentAddress(string addressFirstName)
        {

            if (_addressDB.AddressTypeId == 3)
            {

                Click(attributeName_xpath, QuoteIcon_Xpath);
                Report.WriteLine("Navigated to Quote list page");

                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Click on Submit Rate Request");
                Click(attributeName_id, SubmitRateRequestButton_Id);

                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Click on LTL tile");
                Click(attributeName_id, LTL_TileLabel_Id);
                GlobalVariables.webDriver.WaitForPageLoad();

                //if (_addressDB.AddressTypeId != 3)
                //{
                //    Click(attributeName_id, ClearAddress_OriginId);
                //    rTS.SearchByNameInTheDestinationSavedAddressField_Quote(addressFirstName);

                //    rTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
                //}
                //  Thread.Sleep(2000);
                Click(attributeName_id, ClearAddress_DestId);
                SendKeys(attributeName_id, LTL_DestinationZipPostal_Id, dZip);

                Click(attributeName_id, LTL_ClearItem_Id);
                scrollElementIntoView(attributeName_id, LTL_Classification_Id);
                Click(attributeName_id, LTL_Classification_Id);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == "50")
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                SendKeys(attributeName_id, LTL_Weight_Id, "3");
                Report.WriteLine("Click on Quote Results");
                scrollElementIntoView(attributeName_id, LTL_ViewQuoteResults_Id);
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
                GlobalVariables.webDriver.WaitForPageLoad();

                string configURL = launchUrl;
                string resultPagrURL = configURL + "Rate/LtlResultsView";
                if (GetURL() == resultPagrURL)
                {
                    Report.WriteLine("Rate Results available");
                    Report.WriteLine("Create shipment for selected carrier");


                    WaitForElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button", "Create Shipment");

                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");

                    GlobalVariables.webDriver.WaitForPageLoad();

                }
                else
                {
                    Click(attributeName_id, "no-results-save-quote");
                    GlobalVariables.webDriver.WaitForPageLoad();
                }

                savedQuoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            }
            else
            {
                Report.WriteLine("No Deafult Address for this Customer");
            }
        }

        [Then(@"I will see Default Shipper Address will be PrePopulated in the Shipping from section")]
        public void ThenIWillSeeDefaultShipperAddressWillBePrePopulatedInTheShippingFromSection()
        {
            if (_addressDB.AddressTypeId == 3)
            {
                ThenIWillSeeSavedAddressWillBePrePopulatedInTheShippingFromSection();
            }
            else
            {
                Report.WriteLine("No Default Shipper Address for this Customer");
            }
        }

        [Then(@"I will see Default Shipper Address Shipping From section fields are Non Editable")]
        public void ThenIWillSeeDefaultShipperAddressShippingFromSectionFieldsAreNonEditable()
        {
            if (_addressDB.AddressTypeId == 3)
            {
                ThenIWillSeeShippingFromSectionFieldsAreNonEditable();
            }
            else
            {
                Report.WriteLine("No Default Shipper Address for this Customer");
            }
        }

        [Then(@"I will see Default Shipper Address Comment field of Shipping from section is Editable")]
        public void ThenIWillSeeDefaultShipperAddressCommentFieldOfShippingFromSectionIsEditable()
        {
            if (_addressDB.AddressTypeId == 3)
            {
                ThenIWillSeeCommentFieldOfShippingFromSectionIsEditable();
            }
            else
            {
                Report.WriteLine("No Default Shipper Address for this Customer");
            }
        }

        [Then(@"I will see Default Shipper Address of Shipping From Contact section fields are Editable")]
        public void ThenIWillSeeDefaultShipperAddressOfShippingFromContactSectionFieldsAreEditable()
        {
            if (_addressDB.AddressTypeId == 3)
            {
                ThenIWillSeeShippingFromContactSectionFieldsAreEditable();
            }
            else
            {
                Report.WriteLine("No Default Shipper Address for this Customer");
            }
        }

        [When(@"I arrive on the Add Shipment\(LTL\) page for Default Consignee Address,")]
        public void WhenIArriveOnTheAddShipmentLTLPageForDefaultConsigneeAddress()
        {
            if (_addressDB.AddressTypeId == 4)
            {
                WhenIArriveOnTheAddShipmentLTLPage();
            }
            else
            {
                Report.WriteLine("No Default Consignee Address for this Customer");
            }
        }

        [Then(@"I will see Default Consignee Address will be PrePopulated in the Shipping To section")]
        public void ThenIWillSeeDefaultConsigneeAddressWillBePrePopulatedInTheShippingToSection()
        {
            if (_addressDB.AddressTypeId == 4)
            {
                ThenIWillSeeSavedAddressWillBePrePopulatedInTheShippingToSection();
            }
            else
            {
                Report.WriteLine("No Default Consignee Address for this Customer");
            }
        }

        [Then(@"I will see Default Consignee Address in Shipping To section fields are Non Editable")]
        public void ThenIWillSeeDefaultConsigneeAddressInShippingToSectionFieldsAreNonEditable()
        {
            if (_addressDB.AddressTypeId == 4)
            {
                ThenIWillSeeShippingToSectionFieldsAreNonEditable();
            }
            else
            {
                Report.WriteLine("No Default Consignee Address for this Customer");
            }
        }

        [Then(@"I will see Default Consignee Address in Comment field of Shipping To section is Editable")]
        public void ThenIWillSeeDefaultConsigneeAddressInCommentFieldOfShippingToSectionIsEditable()
        {
            if (_addressDB.AddressTypeId == 4)
            {
                ThenIWillSeeCommentFieldOfShippingToSectionIsEditable();
            }
            else
            {
                Report.WriteLine("No Default Consignee Address for this Customer");
            }
        }

        [Then(@"I will see Default Consignee Address in Shipping To Contact section fields are Editable")]
        public void ThenIWillSeeDefaultConsigneeAddressInShippingToContactSectionFieldsAreEditable()
        {
            if (_addressDB.AddressTypeId == 4)
            {
                ThenIWillSeeShippingToContactSectionFieldsAreEditable();
            }
            else
            {
                Report.WriteLine("No Default Consignee Address for this Customer");
            }
        }

        public void commonStepToSavedQuote_DefaultConsigneeAddress(string addressFirstName)
        {

            if (_addressDB.AddressTypeId == 4)
            {

                Click(attributeName_xpath, QuoteIcon_Xpath);
                Report.WriteLine("Navigated to Quote list page");

                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Click on Submit Rate Request");
                Click(attributeName_id, SubmitRateRequestButton_Id);

                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("Click on LTL tile");
                Click(attributeName_id, LTL_TileLabel_Id);
                GlobalVariables.webDriver.WaitForPageLoad();

                //if (_addressDB.AddressTypeId != 3)
                //{
                //    Click(attributeName_id, ClearAddress_OriginId);
                //    rTS.SearchByNameInTheDestinationSavedAddressField_Quote(addressFirstName);

                //    rTS.SelectFirstAddressFromTheDestinationSavedAddressDropdown_Quote();
                //}
                //  Thread.Sleep(2000);
                Click(attributeName_id, ClearAddress_OriginId);
                SendKeys(attributeName_id, LTL_OriginZipPostal_Id, oZip);

                Click(attributeName_id, LTL_ClearItem_Id);
                scrollElementIntoView(attributeName_id, LTL_Classification_Id);
                Click(attributeName_id, LTL_Classification_Id);
                IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(LTL_ClassificationValues_Xpath));
                int DropDownCount = DropDownList.Count;
                for (int i = 0; i < DropDownCount; i++)
                {
                    if (DropDownList[i].Text == "50")
                    {
                        DropDownList[i].Click();
                        break;
                    }
                }
                SendKeys(attributeName_id, LTL_Weight_Id, "3");
                Report.WriteLine("Click on Quote Results");
                scrollElementIntoView(attributeName_id, LTL_ViewQuoteResults_Id);
                Click(attributeName_id, LTL_ViewQuoteResults_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                
                string configURL = launchUrl;
                string resultPagrURL = configURL + "Rate/LtlResultsView";
                if (GetURL() == resultPagrURL)
                {
                    Report.WriteLine("Rate Results available");
                    Report.WriteLine("Create shipment for selected carrier");


                    WaitForElementVisible(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/button", "Create Shipment");

                    Click(attributeName_xpath, ".//*[@id='Grid-Rate-List-Large-NonGuranteed']/tbody/tr[1]/td[4]/ul[2]/li/a");

                    GlobalVariables.webDriver.WaitForPageLoad();

                }
                else
                {
                    Click(attributeName_id, "no-results-save-quote");
                    GlobalVariables.webDriver.WaitForPageLoad();
                }

                savedQuoteNumber = Gettext(attributeName_id, QC_RequestNumber_id);
            }
            else
            {
                Report.WriteLine("No Deafult Address for this Customer");
            }
        }

    }
}
