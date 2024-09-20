using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.UAT_Regression.Domestic_Forwarding
{
    [Binding]
    public class DomesticForwarding_SubmitRateRequest_SelectSavedDataSteps : Mvc4Objects
    {
        [Given(@"I am a shp\.inquiry or shp\.entry user - (.*) and (.*)")]
        public void GivenIAmAShp_InquiryOrShp_EntryUser_And(string Username, string Password)
        {
            string username = ConfigurationManager.AppSettings["username-zzzcsaStage"].ToString();
            string password = ConfigurationManager.AppSettings["password-zzzcsaStage"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);

        }

        [Given(@"I am on the Rate Request page for Domestic Forwarding")]
        public void GivenIAmOnTheRateRequestPageForDomesticForwarding()
        {
            Report.WriteLine("Click on Quote Module");
            Click(attributeName_xpath, QuoteModule_Xpath);
            Click(attributeName_id, SubmitRateRequestButton_Id);
            Report.WriteLine("Selecting service from shipment service screen");
            Click(attributeName_id, DomesticForwarding_TitleLabel_Id);
            WaitForElementVisible(attributeName_xpath, DomForwarding_TypeDropdown_Xpath, "Type dropdown");
            Thread.Sleep(2000);
            Click(attributeName_xpath, DomForwarding_TypeDropdown_Xpath);
            List<string> TypeDropDownList = GetDropdownValues(attributeName_id, "rate_domestic_forward_type_chosen", "li");
            TypeDropDownList.Remove("Select Type...");
            SelectDropdownValueFromList(attributeName_id, "rate_domestic_forward_type_chosen", TypeDropDownList.FirstOrDefault());
            Click(attributeName_id, DomForwarding_ContinueButton_Id);
        }

        [Given(@"I have selected saved address and saved item (.*), (.*) and (.*)")]
        public void GivenIHaveSelectedSavedAddressAndSavedItemAnd(string saveOAddressName, string saveDAddressName, string itemDesc)
        {
            Report.WriteLine("Selecting a saved address from the origin dropdown");
            Click(attributeName_xpath, DF_OriginAddress_Dropdown_Xpath);
            SendKeys(attributeName_xpath, DF_OriginAddress_DropdownSearch_Xpath, saveOAddressName);
            Click(attributeName_xpath, DF_OriginAddress_DropdownFirstValue_Xpath);

            Report.WriteLine("Selecting a saved address from the dropdown");
            Click(attributeName_xpath, DF_DestinationAddress_Dropdown_Xpath);
            SendKeys(attributeName_xpath, DF_DestinationAddress_DropdownSearch_Xpath, saveDAddressName);
            Click(attributeName_xpath, DF_DestinationAddress_FirstValue_Xpath);

            Report.WriteLine("Selecting a saved item from the dropdown");
            scrollElementIntoView(attributeName_xpath, DF_SavedItem_Xpath);
            Click(attributeName_xpath, DF_SavedItem_Xpath);
            SendKeys(attributeName_xpath, DF_SavedItem_Search_Xpath, itemDesc);
            Click(attributeName_xpath, DF_SavedItenDropdown_FirstValue_Xpath);

        }


        [When(@"I select a saved address from the Origin section (.*)")]
        public void WhenISelectASavedAddressFromTheOriginSection(string saveAddressName)
        {
            Report.WriteLine("Selecting a saved address from the dropdown");
            Click(attributeName_xpath, DF_OriginAddress_Dropdown_Xpath);
            SendKeys(attributeName_xpath, DF_OriginAddress_DropdownSearch_Xpath, saveAddressName);
            Click(attributeName_xpath, DF_OriginAddress_DropdownFirstValue_Xpath);
        }

        [When(@"I select a saved address from the Destination section (.*)")]
        public void WhenISelectASavedAddressFromTheDestinationSection(string saveAddressName)
        {
            Report.WriteLine("Selecting a saved address from the dropdown");
            Click(attributeName_xpath, DF_DestinationAddress_Dropdown_Xpath);
            SendKeys(attributeName_xpath, DF_DestinationAddress_DropdownSearch_Xpath, saveAddressName);
            Click(attributeName_xpath, DF_DestinationAddress_FirstValue_Xpath);
        }

        [When(@"I select a saved Item (.*)")]
        public void WhenISelectASavedItem(string itemDesc)
        {
            Report.WriteLine("Selecting a saved item from the dropdown");
            scrollElementIntoView(attributeName_xpath, DF_SavedItem_Xpath);
            Click(attributeName_xpath, DF_SavedItem_Xpath);
            SendKeys(attributeName_xpath, DF_SavedItem_Search_Xpath, itemDesc);
            Click(attributeName_xpath, DF_SavedItenDropdown_FirstValue_Xpath);
        }

        [Then(@"The following fields Pieces, Weight, Dimensions and Description must be populated (.*), (.*)")]
        public void ThenTheFollowingFieldsPiecesWeightDimensionsAndDescriptionMustBePopulated(string itemDesc, string accName)
        {
            Report.WriteLine("Verifying the populated data with database");
            int setupId = DBHelper.GetAccountIdforAccountName(accName);
            int accId = DBHelper.GetAccountNumber(setupId);
            Item itemValue = DBHelper.GetItemDetails(accId, itemDesc);

            string actQuantity = GetAttribute(attributeName_id, DF_Pieces_Id, "value");
            Assert.AreEqual(itemValue.Quantity.ToString(), actQuantity);
            Report.WriteLine("Displaying quantity " + actQuantity + " is matching with expected value " + itemValue.Quantity);

            string actWeight = GetAttribute(attributeName_id, DF_Weight_Id, "value");
            Assert.AreEqual(itemValue.Weight.ToString(), actWeight);
            Report.WriteLine("Displaying weight " + actWeight + " is matching with expected value " + itemValue.Weight);

            string actLength = GetAttribute(attributeName_id, DF_DimensionLength_Id, "value");
            Assert.AreEqual(itemValue.Length.ToString(), actLength);
            Report.WriteLine("Displaying length " + actLength + " is matching with expected value " + itemValue.Length);

            string actWidth = GetAttribute(attributeName_id, DF_DimensionWidth_Id, "value");
            Assert.AreEqual(itemValue.Width.ToString(), actWidth);
            Report.WriteLine("Displaying width " + actWidth + " is matching with expected value " + itemValue.Width);

            string actHeight = GetAttribute(attributeName_id, DF_DimensionHeight_Id, "value");
            Assert.AreEqual(itemValue.Height.ToString(), actHeight);
            Report.WriteLine("Displaying height " + actHeight + " is matching with expected value " + itemValue.Height);

            string actDesc = GetAttribute(attributeName_id, DF_Description_Id, "value");
            Assert.AreEqual(itemValue.ItemDescription.ToUpper(), actDesc.ToUpper());
            Report.WriteLine("Displaying description " + actDesc + " is matching with expected value " + itemValue.ItemDescription);
        }

        [When(@"I click on Save and Continue")]
        public void WhenIClickOnSaveAndContinue()
        {
            Report.WriteLine("Clicking on save and continue button");
            Click(attributeName_id, DF_SaveAndContinue_Button_Id);
        }

        [Then(@"The following fields LocationName, Address, Country, Zip, State and City must be populated in the Origin section (.*), (.*)")]
        public void ThenTheFollowingFieldsLocationNameAddressCountryZipStateAndCityMustBePopulatedInTheOriginSection(string searchName, string AccName)
        {
            Address addValue = DBHelper.GetAddress_By_searchedhName(AccName, searchName);
            string actName = GetAttribute(attributeName_id, DF_LocationName_Id, "value");
            Assert.AreEqual(addValue.Name.ToUpper(), actName.ToUpper());
            Report.WriteLine("Displaying Location Name " + actName + " is matching with expected value " + addValue.Name);

            string actAdd = GetAttribute(attributeName_id, DF_Address1_Id, "value");
            Assert.AreEqual(addValue.Address1, actAdd);
            Report.WriteLine("Displaying address " + actAdd + " is matching with expected value " + addValue.Address1);

            string actZip = GetAttribute(attributeName_id, DF_ZipCode_Id, "value");
            Assert.AreEqual(addValue.Zip, actZip);
            Report.WriteLine("Displaying zip " + actZip + " is matching with expected value " + addValue.Zip);

            string actCity = GetAttribute(attributeName_id, DF_City_Id, "value");
            Assert.AreEqual(addValue.City, actCity);
            Report.WriteLine("Displaying city " + actCity + " is matching with expected value " + addValue.City);

            string actState = Gettext(attributeName_xpath, DF_OriginState_Xpath);
            Assert.AreEqual(addValue.State, actState);
            Report.WriteLine("Displaying state " + actState + " is matching with expected value " + addValue.State);

            string actCountry = Gettext(attributeName_xpath, DF_OriginCountry_Xpath);
            Assert.AreEqual(addValue.Country, actCountry);
            Report.WriteLine("Displaying state " + actCountry + " is matching with expected value " + addValue.Country);

        }

        [Then(@"The following fields LocationName, Address, Country, Zip, State and City must be populated in the Destination section (.*), (.*)")]
        public void ThenTheFollowingFieldsLocationNameAddressCountryZipStateAndCityMustBePopulatedInTheDestinationSection(string searchName, string AccName)
        {
            Address addValue = DBHelper.GetAddress_By_searchedhName(AccName, searchName);
            string actName = GetAttribute(attributeName_id, DF_DesLocationName_Id, "value");
            Assert.AreEqual(addValue.Name.ToUpper(), actName.ToUpper());
            Report.WriteLine("Displaying Location Name " + actName + " is matching with expected value " + addValue.Name);

            string actAdd = GetAttribute(attributeName_id, DF_DesAddress1_Id, "value");
            Assert.AreEqual(addValue.Address1, actAdd);
            Report.WriteLine("Displaying address " + actAdd + " is matching with expected value " + addValue.Address1);

            string actZip = GetAttribute(attributeName_id, DF_DesZipcode_Id, "value");
            Assert.AreEqual(addValue.Zip, actZip);
            Report.WriteLine("Displaying zip " + actZip + " is matching with expected value " + addValue.Zip);

            string actCity = GetAttribute(attributeName_id, DF_DesCity_Id, "value");
            Assert.AreEqual(addValue.City, actCity);
            Report.WriteLine("Displaying city " + actCity + " is matching with expected value " + addValue.City);

            string actState = Gettext(attributeName_xpath, DF_DestinationState_Xpath);
            Assert.AreEqual(addValue.State, actState);
            Report.WriteLine("Displaying state " + actState + " is matching with expected value " + addValue.State);

            string actCountry = Gettext(attributeName_xpath, DF_DestinationCountry_Xpath);
            Assert.AreEqual(addValue.Country, actCountry);
            Report.WriteLine("Displaying state " + actCountry + " is matching with expected value " + addValue.Country);

        }

        [Then(@"I must land on the Review and Submit page")]
        public void ThenIMustLandOnTheReviewAndSubmitPage()
        {
            Report.WriteLine("Verify the review and submit page");
            Verifytext(attributeName_xpath, DF_ReviewPageTitle_Xpath, "Review and Submit");
        }

        [Then(@"The following fields must match the data entered while creating the rate request (.*), (.*), (.*) and (.*)")]
        public void ThenTheFollowingFieldsMustMatchTheDataEnteredWhileCreatingTheRateRequestAnd(string oAdd, string dAdd, string itemDesc, string accName)
        {
            Address originAdd = DBHelper.GetAddress_By_searchedhName(accName, oAdd);
            Address destAdd = DBHelper.GetAddress_By_searchedhName(accName, dAdd);
            int setupId = DBHelper.GetAccountIdforAccountName(accName);
            int accId = DBHelper.GetAccountNumber(setupId);
            Item itemValue = DBHelper.GetItemDetails(accId, itemDesc);

            string actAddress = Gettext(attributeName_xpath, DF_ReviewPage_OriginAddresss_Xpath);
            Assert.AreEqual(actAddress.ToUpper(), originAdd.Address1.ToUpper());
            Report.WriteLine("Passed " + actAddress.ToUpper() + "in shipping information is matching with review page" + originAdd.Address1.ToUpper());

            List<string> values = new List<string>();
            values.Add(originAdd.City);
            values.Add(originAdd.State);
            values.Add(originAdd.Zip);
            string expformat = string.Join(",", values);
            string actformat = Gettext(attributeName_xpath, DF_ReviewPage_OriginCity_State_Zip_Xpath);           
            Assert.AreEqual(actformat.Replace(" ", ""), expformat);
            Report.WriteLine("Passed " + actformat.Replace(" ", "") + "in shipping information is matching with review page" + expformat);

            string actOContactName = Gettext(attributeName_xpath, DF_ReviewPage_OriginContactName_Xpath);
            Assert.AreEqual(actOContactName.ToUpper(), originAdd.ContactName.ToUpper());
            Report.WriteLine("Passed " + actOContactName.ToUpper() + "in shipping information is matching with review page" + originAdd.ContactName.ToUpper());

            string actOContactPhone = Gettext(attributeName_xpath, DF_ReviewPage_OriginPhoneNum_Xpath);
            Assert.AreEqual(actOContactPhone, originAdd.PhoneNumber);
            Report.WriteLine("Passed " + actOContactPhone + "in shipping information is matching with review page" + originAdd.PhoneNumber);

            string actdAddress = Gettext(attributeName_xpath, DF_ReviewPage_DesAddress_Xpath);
            Assert.AreEqual(actdAddress.ToUpper(), destAdd.Address1.ToUpper());
            Report.WriteLine("Passed " + actdAddress.ToUpper() + "in shipping information is matching with review page" + destAdd.Address1.ToUpper());

            List<string> dvalues = new List<string>();
            dvalues.Add(destAdd.City);
            dvalues.Add(destAdd.State);
            dvalues.Add(destAdd.Zip);
            string expdformat = string.Join(",", dvalues);
            string actdformat = Gettext(attributeName_xpath, DF_ReviewPage_DesCity_State_Zip_Xpath);
            Assert.AreEqual(actdformat.Replace(" ", ""), expdformat);
            Report.WriteLine("Passed " + actdformat.Replace(" ", "") + "in shipping information is matching with review page" + expdformat);

            string actDContactName = Gettext(attributeName_xpath, DF_ReviewPage_DesContactName_Xpath);
            Assert.AreEqual(actDContactName.ToUpper(), destAdd.ContactName.ToUpper());
            Report.WriteLine("Passed " + actDContactName.ToUpper() + "in shipping information is matching with review page" + destAdd.ContactName.ToUpper());

            string actDContactPhone = Gettext(attributeName_xpath, DF_ReviewPage_DesPhoneNum_Xpath);
            Assert.AreEqual(actDContactPhone, destAdd.PhoneNumber);
            Report.WriteLine("Passed " + actDContactPhone + "in shipping information is matching with review page" + destAdd.PhoneNumber);

            string actQuantity = Gettext(attributeName_xpath, DF_ReviewPage_Pieces_Xpath);
            Assert.AreEqual(actQuantity, itemValue.Quantity.ToString());
            Report.WriteLine("Passed " + actQuantity + "in shipping information is matching with review page" + itemValue.Quantity.ToString());

            string actWeight = Gettext(attributeName_xpath, DF_ReviewPage_Weight_Xpath);
            Assert.AreEqual(actWeight, itemValue.Weight.ToString());
            Report.WriteLine("Passed " + actWeight + "in shipping information is matching with review page" + itemValue.Weight.ToString());

            string actDesc = Gettext(attributeName_xpath, DF_ReviewPage_Description);
            Assert.AreEqual(actDesc.ToUpper(), itemValue.ItemDescription.ToUpper());
            Report.WriteLine("Passed " + actDesc + "in shipping information is matching with review page" + itemValue.ItemDescription.ToString());

        }
    }
}
