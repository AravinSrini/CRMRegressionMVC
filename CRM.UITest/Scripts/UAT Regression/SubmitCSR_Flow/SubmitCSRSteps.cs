using System.IO;
using CRM.UITest.Objects;
using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using CRM.UITest.Entities;

namespace CRM.UITest.Scripts.UAT_Regression.SubmitCSR_Flow
{
    [Binding]
    public class SubmitCSRSteps : Submit_CSR
    {

        string StationName_UI_AccInformationPage;
        string Attached_ItemTemplate_Name;
        string Attached_AddressTemplate_Name;
        string Attached_PortalUSersTemplate_Name;
        string _custName;

        [Given(@"I arrive on Dashboard page and clicking on the create CSR button will be navigated to Account Information page(.*)")]
        public void GivenIArriveOnDashboardPageAndClickingOnTheCreateCSRButtonWillBeNavigatedToAccountInformationPage(string AccountInformation_text)
        {
            Report.WriteLine("Verifying Click Functionality of Create CSR button");
            Thread.Sleep(2000);
            WaitForElementVisible(attributeName_id, Dashboard_CreateCSR_button_Id, "Create CSR button");
            Click(attributeName_id, Dashboard_CreateCSR_button_Id);
            Thread.Sleep(8000);
            WaitForElementVisible(attributeName_xpath, SubmitCSR_AccountInformationPage_Text_Xpath, AccountInformation_text);
        }

        [Given(@"I enter the Account Information details for CSA Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterTheAccountInformationDetailsForCSATypeSubAccountAndClickOnSaveAndContinueWillBeNavigatedToLocationsAndContactPage(string Station_Id, string SalesRep, string Select_PrimaryAccount_ForThis_CSR, string EnterpriseType, string UserType, string CustomerAccountName, string CSA_CustomerNumber, string ShipmentNotification_Email, string CustomerInvoiceMethod, string CustomerInvoiceBackUp, string CreditCard)
        {
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, StationID_DropDown_List_Xpath, Station_Id);
            Thread.Sleep(4000);
            StationName_UI_AccInformationPage = GetAttribute(attributeName_xpath, StationName_Textbox_Xpath, "value");

            Click(attributeName_xpath, SalesRep_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SalesRep_DropDownList_Xpath, SalesRep);
            Click(attributeName_xpath, SubAccount_CSRType_Radiobutton_Xpath);
            Thread.Sleep(6000);
            Click(attributeName_xpath, EnterPriseType_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, EnterPrise_DropDownList_Xpath, EnterpriseType);
            Thread.Sleep(500);
            scrollpagedown();
            Thread.Sleep(500);
            Click(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath);
            
            IList<IWebElement> PrimaryAccount_ForThis_CSR_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectPrimaryAcctDropDownValues_Xpath));

            if (PrimaryAccount_ForThis_CSR_List.Count > 0)
            {
                SelectDropdownValueFromList(attributeName_xpath, SelectPrimaryAcctDropDownValues_Xpath, Select_PrimaryAccount_ForThis_CSR);
                Thread.Sleep(1000);
            }
            else
            {
                throw new Exception("No Primary Account found for this Selected Station and Please select some other station");
            }
            
            Report.WriteLine("Checking for Duplicate Customer Name");
            _custName = DBHelper.Check_CustomerName_Duplicate(CustomerAccountName);
            SendKeys(attributeName_xpath, CustomerAccountName_Textbox, _custName);

            Click(attributeName_xpath, TMS_Type_CSA_Radiobutton_Xpath);
            if (UserType == "Admin")
            {
                Thread.Sleep(2000);

                Report.WriteLine("Checking for Duplicate CSA Number");
                int CSANum = Convert.ToInt32(CSA_CustomerNumber);
                int _cSANumber = DBHelper.Check_CSANumber_Duplicate(CSANum);
                string csaNumb = _cSANumber.ToString();
                SendKeys(attributeName_xpath, CSA_CustomerNumber_Textbox_Xpath, csaNumb);

            }
            Clear(attributeName_xpath, ShipmentNotificationEmail_Textbox_Xpath);
            SendKeys(attributeName_xpath, ShipmentNotificationEmail_Textbox_Xpath, ShipmentNotification_Email);
            Thread.Sleep(500);
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceMethod_Dropdown_value_Xpath, CustomerInvoiceMethod);
            Thread.Sleep(1000);
            Click(attributeName_xpath, CustomerInvoiceBackUp_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceBackUp_Dropdown_value_Xpath, CustomerInvoiceBackUp);
            Thread.Sleep(1000);
            if (CreditCard == "No")
            {
                Click(attributeName_xpath, CreditCard_RadioButton_No_Xpath);
            }
            Click(attributeName_xpath, AccountInformation_SaveAndContinueButton_Xpath);
            Thread.Sleep(8000);

        }


        [Given(@"I enter the Account Information details for Both Type SubAccount and Click on Save and Continue will be Navigated to Locations and Contact Page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterTheAccountInformationDetailsForBothTypeSubAccountAndClickOnSaveAndContinueWillBeNavigatedToLocationsAndContactPage(string Station_Id, string SalesRep, string Select_PrimaryAccount_ForThis_CSR, string EnterpriseType, string UserType, string CustomerAccountName, string CSA_CustomerNumber, string ShipmentNotification_Email, string CustomerInvoiceMethod, string CustomerInvoiceBackUp, string CreditCard)
        {
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, StationID_DropDown_List_Xpath, Station_Id);
            Thread.Sleep(4000);
            StationName_UI_AccInformationPage = GetAttribute(attributeName_xpath, StationName_Textbox_Xpath, "value");

            Click(attributeName_xpath, SalesRep_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SalesRep_DropDownList_Xpath, SalesRep);
            Click(attributeName_xpath, SubAccount_CSRType_Radiobutton_Xpath);
            Thread.Sleep(5000);
            Click(attributeName_xpath, EnterPriseType_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, EnterPrise_DropDownList_Xpath, EnterpriseType);
            scrollpagedown();
            Click(attributeName_xpath, SelectPrimaryAcctDropDown_Xpath);
            Thread.Sleep(4000);
            IList<IWebElement> PrimaryAccount_ForThis_CSR_List = GlobalVariables.webDriver.FindElements(By.XPath(SelectPrimaryAcctDropDownValues_Xpath));

            if (PrimaryAccount_ForThis_CSR_List.Count > 0)
            {
                SelectDropdownValueFromList(attributeName_xpath, SelectPrimaryAcctDropDownValues_Xpath, Select_PrimaryAccount_ForThis_CSR);
                Thread.Sleep(1000);
            }
            else
            {
                throw new Exception("No Primary Account found for this Selected Station and Please select some other station");
            }
            
            Report.WriteLine("Checking for Duplicate Customer Name");
            string _custName = DBHelper.Check_CustomerName_Duplicate(CustomerAccountName);
            SendKeys(attributeName_xpath, CustomerAccountName_Textbox, _custName);

            Click(attributeName_xpath, TMS_Type_BOTH_Radiobutton_Xpath);
            if (UserType == "Admin")
            {
                Thread.Sleep(2000);
                
                Report.WriteLine("Checking for Duplicate CSA Number");
                int CSANum = Convert.ToInt32(CSA_CustomerNumber);
                int _cSANumber = DBHelper.Check_CSANumber_Duplicate(CSANum);
                string csaNumb = _cSANumber.ToString();
                SendKeys(attributeName_xpath, CSA_CustomerNumber_Textbox_Xpath, csaNumb);

            }
            Clear(attributeName_xpath, ShipmentNotificationEmail_Textbox_Xpath);
            SendKeys(attributeName_xpath, ShipmentNotificationEmail_Textbox_Xpath, ShipmentNotification_Email);
            Thread.Sleep(1000);
            scrollpagedown();
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceMethod_Dropdown_value_Xpath, CustomerInvoiceMethod);
            Thread.Sleep(1000);
            Click(attributeName_xpath, CustomerInvoiceBackUp_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceBackUp_Dropdown_value_Xpath, CustomerInvoiceBackUp);
            Thread.Sleep(1000);
            if (CreditCard == "No")
            {
                Click(attributeName_xpath, CreditCard_RadioButton_No_Xpath);
            }
            Click(attributeName_xpath, AccountInformation_SaveAndContinueButton_Xpath);
            Thread.Sleep(8000);
        }


        [Given(@"I enter the Locations and Contacts details and Click on Save and Continue will be Navigated to Pricing Model Page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterTheLocationsAndContactsDetailsAndClickOnSaveAndContinueWillBeNavigatedToPricingModelPage(string Name, string Address1, string Address2, string City, string State, string Zip, string Country, string PhoneNumber, string Email, string FaxNumber, string Website, string Residential_Location, string Comments)
        {
            WaitForElementVisible(attributeName_xpath, LocationsPage_Header_Xpath, "Locations and Contact Page Header");
            SendKeys(attributeName_xpath, CustomerLocation_Name_Textbox_Xpath, Name);
            SendKeys(attributeName_xpath, CustomerLocation_Address1_Textbox_Xpath, Address1);
            SendKeys(attributeName_xpath, CustomerLocation_Address2_Textbox_Xpath, Address2);
            SendKeys(attributeName_xpath, CustomerLocation_City_Textbox_Xpath, City);
            scrollpagedown();
            Click(attributeName_xpath, CustomerLocation_StateDropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerLocation_StateDropDownList_Xpath, State);
            Thread.Sleep(1000);
            Click(attributeName_xpath, CustomerLocation_CountryDropDown_Xpath);
            
            SelectDropdownValueFromList(attributeName_xpath, CustomerLocation_CountryDropdownList_Xpath, Country);
            Thread.Sleep(1000);
            SendKeys(attributeName_xpath, CustomerLocation_Zip_Textbox_Xpath, Zip);
            SendKeys(attributeName_xpath, CustomerContactInformation_Name_Textbox_Xpath, Name);
            SendKeys(attributeName_xpath, CustomerContactInformation_PhoneNumber_Textbox_Xpath, PhoneNumber);
            SendKeys(attributeName_xpath, CustomerContactInformation_Email_Textbox_Xpath, Email);
            SendKeys(attributeName_xpath, CustomerContactInformation_FaxNumber_Textbox_Xpath, FaxNumber);
            SendKeys(attributeName_xpath, CustomerContactInformation_Website_textbox_Xpath, Website);
            if (Residential_Location == "Yes")
            {
                Click(attributeName_xpath, ResidentialLocation_Checkbox_Xpath);
            }
            SendKeys(attributeName_xpath, CustomerLocation_Comments_Textbox_Xpath, Comments);
            scrollpagedown();
            Click(attributeName_xpath, CheckBox_UseCustomerLocation_ContactInformation_for_BillToLocation_Contact_Details);
            Click(attributeName_xpath, LocationsAndContacts_SaveAndContinueButton_Xpath);
            Thread.Sleep(9000);
        }

        [Given(@"I enter Gainshare pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterGainsharePricingDetailsAndClickOnSaveAndContinueWillBeNavigatedToSavedItemsAndAddressesPage(string PricingType, string percentage, string MinThreshold_Charge, string MinAmount_Added, string carriersExcluded, string Household_Goods, string Rating_Instructions)
        {
            WaitForElementVisible(attributeName_xpath, PricingPage_Text_Xpath, "Pricing Page Header");
            Click(attributeName_xpath, PricingType_DropDown_Xpath);
            
            SelectDropdownValueFromList(attributeName_xpath, PricingType_DropDownDropDownList_Xpath, PricingType);
            Thread.Sleep(800);
            SendKeys(attributeName_id, Gainshare_percentage_Id, percentage);
            Clear(attributeName_id, Gainshare_MinThreshold_Charge_Id);
            SendKeys(attributeName_id, Gainshare_MinThreshold_Charge_Id, MinThreshold_Charge);
            Thread.Sleep(500);
            Clear(attributeName_id, Gainshare_MinAmount_Added_Id);
            SendKeys(attributeName_id, Gainshare_MinAmount_Added_Id, MinAmount_Added);
            Thread.Sleep(500);
            if (carriersExcluded == "N/A")
            {
                Click(attributeName_xpath, Gainshare_carriersExcluded_No_Radiobutton_Xpath);
            }

            if (Household_Goods == "No")
            {
                Click(attributeName_xpath, Gainshare_Household_Goods_No_Radiobutton_Xpath);
            }
            SendKeys(attributeName_id, RatingInstructions_RateProvisions_Textbox_Id, Rating_Instructions);
            Thread.Sleep(500);
            Click(attributeName_xpath, PricingModel_SaveAndContinuebutton);
            Thread.Sleep(8000);
        }

        [Given(@"I Click on browse for a file to Upload link in Item section and upload Item Template(.*)")]
        public void GivenIClickOnBrowseForAFileToUploadLinkInItemSectionAndUploadItemTemplate(string ItemPath)
        {
            WaitForElementVisible(attributeName_xpath, SavetItems_Address_Page_Header_Xpath, "Saved Items and Addressess Page Header");
            string FilePath = Path.GetFullPath(ItemPath);
            FileUpload(attributeName_id, Item_Template_eDropzone_Id, FilePath);
            Thread.Sleep(3000);
            Attached_ItemTemplate_Name = Gettext(attributeName_xpath, ".//*[@id='item-container']/div/div[2]/div/div[3]/li/div/div[1]");
        }

        [Given(@"I Click on browse for a file to Upload link in Address section and upload Address Template(.*)")]
        public void GivenIClickOnBrowseForAFileToUploadLinkInAddressSectionAndUploadAddressTemplate(string AddressPath)
        {
            scrollpagedown();
            string FilePath = Path.GetFullPath(AddressPath);
            FileUpload(attributeName_id, Address_Template_Dropzone_Id, FilePath);
            Thread.Sleep(3000);
            Attached_AddressTemplate_Name = Gettext(attributeName_xpath, ".//*[@id='address-container']/div/div[2]/div/div[3]/li/div/div[1]");
        }

        [Given(@"I Click on Save and Continue button will be Navigated to Portal Users Page(.*)")]
        public void GivenIClickOnSaveAndContinueButtonWillBeNavigatedToPortalUsersPage(string PortalUsers_Text)
        {
            WaitForElementVisible(attributeName_xpath, SavetItems_Address_Page_Header_Xpath, "Saved Items and Addressess Page Header");
            Click(attributeName_xpath, SavedItemsAndAddresses_SaveAndContinue_button_Xpath);
            Thread.Sleep(8000);
            WaitForElementVisible(attributeName_xpath, PortalUsersPage_Header_Xpath, PortalUsers_Text);
        }

        [Given(@"Click on browse for a file to Upload link in Portal Users section and upload Portal Users Template(.*)")]
        public void GivenClickOnBrowseForAFileToUploadLinkInPortalUsersSectionAndUploadPortalUsersTemplate(string PortalUsersPath)
        {
            Click(attributeName_xpath, PortalUsers_Yes_Radiobutton_Xpath);
            Thread.Sleep(1000);
            scrollpagedown();
            string FilePath = Path.GetFullPath(PortalUsersPath);
            FileUpload(attributeName_xpath, PortaUsers_Template_Dropzone_Xpath, FilePath);
            Thread.Sleep(3000);
            Attached_PortalUSersTemplate_Name = Gettext(attributeName_xpath, ".//*[@id='portaluser-container']/div/div[2]/div/div[3]/li/div/div[1]");
        }
        [Given(@"I Click on Save and Continue button will be Navigated to Review and Submit Page(.*)")]
        public void GivenIClickOnSaveAndContinueButtonWillBeNavigatedToReviewAndSubmitPage(string ReviewAndSubmitText)
        {
            Click(attributeName_xpath, PortalUsers_SaveAndContinue_button_Xpath);
            Thread.Sleep(8000);
            WaitForElementVisible(attributeName_xpath, ReviewAndSubmitPage_Header_Xpath, ReviewAndSubmitText);
        }
        
        [When(@"I click on the Submit button leads to Submit the CSR")]
        public void WhenIClickOnTheSubmitButtonLeadsToSubmitTheCSR()
        {
            Click(attributeName_xpath, ReviewSubmitPage_SubmitButton_Xpath);
            Thread.Sleep(8000);
        }
        [Then(@"I will see the PopUp denotes that CSR has been submitted(.*)")]
        public void ThenIWillSeeThePopUpDenotesThatCSRHasBeenSubmitted(string CSRSubmitted_Text)
        {
            string CSR_Submitted_Successfully_Text_UI = Gettext(attributeName_xpath, CSR_Submitted_Text_Xpath);
            Assert.AreEqual(CSRSubmitted_Text, CSR_Submitted_Successfully_Text_UI);
        }

        [Then(@"I click on the close button will be navigated to CSR list page")]
        public void ThenIClickOnTheCloseButtonWillBeNavigatedToCSRListPage()
        {
            WaitForElementVisible(attributeName_xpath, CSR_Submitted_Text_Xpath, "CSR Submission Message");
            Click(attributeName_xpath, "(//a[@class = 'closeOverlay btn center'])");
            Thread.Sleep(9000);
            WaitForElementVisible(attributeName_xpath, ".//*[@id='body']/section/div[3]/div[1]/h1", "CSR List Page");
            string CSRList_Page = Gettext(attributeName_xpath, ".//h1[contains(text(), 'CSR List')]");
            Assert.AreEqual("CSR List", CSRList_Page);
        }

        [Then(@"verify for the created CSR present in CSR list page by entering the Customer Account name in the search box from CSR list page(.*)")]
        public void ThenVerifyForTheCreatedCSRPresentInCSRListPageByEnteringTheCustomerAccountNameInTheSearchBoxFromCSRListPage(string CustomerAccountName)
        {
            Report.WriteLine("entering the CSR name in the search box");
            SendKeys(attributeName_xpath, ".//*[@id='csr-list-search-input']", _custName);
            Thread.Sleep(1000);
            Report.WriteLine("Verifying the created CSR present in CSR List page");
            string createdCSR = Gettext(attributeName_xpath, ".//*[@id='csr-list-tbl']/table/tbody/tr/td[1]/p/a");
            Assert.AreEqual(_custName, createdCSR);
        }

        [Then(@"the CSR will be created successfully and saved in Database(.*)")]
        public void ThenTheCSRWillBeCreatedSuccessfullyAndSavedInDatabase(string CustomerAccountName)
        {
            
            bool CSRExistence_Verifcation = DBHelper._CheckSubmittedCSR_CSRSetups_Table(_custName);
            Thread.Sleep(1000);
            Assert.IsTrue(CSRExistence_Verifcation);
        }


        [Given(@"I enter the Account Information details for MG Type Primary Account and Click on Save and Continue will be Navigated to Locations and Contact Page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterTheAccountInformationDetailsForMGTypePrimaryAccountAndClickOnSaveAndContinueWillBeNavigatedToLocationsAndContactPage(string Station_Id, string SalesRep, string OtherValue, string EnterpriseType, string CustomerAccountName, string ShipmentNotification_Email, string CustomerInvoiceMethod, string CustomerInvoiceBackUp, string CreditCard)
        {
            Click(attributeName_xpath, StationId_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, StationID_DropDown_List_Xpath, Station_Id);
            Thread.Sleep(5000);
            StationName_UI_AccInformationPage = GetAttribute(attributeName_xpath, StationName_Textbox_Xpath, "value");
            Click(attributeName_xpath, SalesRep_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SalesRep_DropDownList_Xpath, SalesRep);
            Thread.Sleep(1000);
            SendKeys(attributeName_xpath, SalesRep_Other_Textbox_Xpath, OtherValue);

            Click(attributeName_xpath, PrimaryCustomerAccount_Radibutton_Xpath);
            Click(attributeName_xpath, TMS_Type_MG_Radiobutton_Xpath);
            Thread.Sleep(500);
            Click(attributeName_xpath, LTLShippingDocument_BOL_Radiobutton_Xpath);
            Click(attributeName_xpath, EnterPriseType_DropDown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, EnterPrise_DropDownList_Xpath, EnterpriseType);
            Thread.Sleep(800);
            scrollpagedown();
            
            _custName = DBHelper.Check_CustomerName_Duplicate(CustomerAccountName);
            SendKeys(attributeName_xpath, CustomerAccountName_Textbox, _custName);

            Clear(attributeName_xpath, ShipmentNotificationEmail_Textbox_Xpath);
            SendKeys(attributeName_xpath, ShipmentNotificationEmail_Textbox_Xpath, ShipmentNotification_Email);
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(500);
            Click(attributeName_xpath, CustomerInvoiceMethod_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceMethod_Dropdown_value_Xpath, CustomerInvoiceMethod);
            Thread.Sleep(800);
            Click(attributeName_xpath, CustomerInvoiceBackUp_Dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CustomerInvoiceBackUp_Dropdown_value_Xpath, CustomerInvoiceBackUp);
            Thread.Sleep(800);
            if (CreditCard == "No")
            {
                Click(attributeName_xpath, CreditCard_RadioButton_No_Xpath);
            }
            Click(attributeName_xpath, AccountInformation_SaveAndContinueButton_Xpath);
            Thread.Sleep(9000);
        }

        [Given(@"I enter Tariff pricing details and Click on Save and Continue will be Navigated to Saved Items and Addresses Page(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIEnterTariffPricingDetailsAndClickOnSaveAndContinueWillBeNavigatedToSavedItemsAndAddressesPage(string PricingType, string TariffType, string Discount, string Minimum, string carriersExcluded, string Household_Goods, string SpecialRate)
        {
            WaitForElementVisible(attributeName_xpath, PricingPage_Text_Xpath, "Pricing Page Header");
            Click(attributeName_xpath, PricingType_DropDown_Xpath);
            
            SelectDropdownValueFromList(attributeName_xpath, PricingType_DropDownDropDownList_Xpath, PricingType);
            Thread.Sleep(1000);
            Click(attributeName_xpath, Tariff_dropdown_Xpath);
            
            SelectDropdownValueFromList(attributeName_xpath, Tariff_dropdown_value_Xpath, TariffType);
            Thread.Sleep(1000);
            SendKeys(attributeName_xpath, Tariff_discount_Textbox_Xpath, Discount);

            SendKeys(attributeName_xpath, Tariff_Minimum_Textbox_Xpath, Minimum);

            if (carriersExcluded == "N/A")
            {
                Click(attributeName_xpath, Tariff_carriers_No_Radiobutton_Xpath);
            }

            if (Household_Goods == "No")
            {
                Click(attributeName_xpath, Tariff_HouseHold_Goods_No_Radiobutton_Xpath);
            }
            SendKeys(attributeName_xpath, Tariff_SpecialRate_Provisions_Textbox_Xpath, SpecialRate);
            Click(attributeName_xpath, PricingModel_SaveAndContinuebutton);
            Thread.Sleep(9000);
        }


        [Given(@"I Click on Create a Saved Item button and Enter Item Details(.*),(.*),(.*),(.*)")]
        public void GivenIClickOnCreateASavedItemButtonAndEnterItemDetails(string Classification, string NMFC, string ItemDescription, string HazardousMaterials)
        {
            WaitForElementVisible(attributeName_xpath, SavetItems_Address_Page_Header_Xpath, "Saved Items and Addressess Page Header");
            Click(attributeName_xpath, Create_A_SavedItem_button_Xpath);
            Thread.Sleep(1000);
            Click(attributeName_xpath, Classification_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Calssification_dropdown_Value_Xpath, Classification);
            Thread.Sleep(500);
            SendKeys(attributeName_xpath, NMFC_textbox_Xpath, NMFC);
            SendKeys(attributeName_xpath, Item_Description_textbox_Xpath, ItemDescription);
            Click(attributeName_xpath, HazardousMaterial_No_Radiobutton_Xpath);
            Click(attributeName_xpath, Save_Itembutton_Xpath);
            Thread.Sleep(1500);
        }

        

        [Given(@"I able to see Account Information details in Review and Submit Page(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeAccountInformationDetailsInReviewAndSubmitPage(string Station_Id, string SalesRep, string EnterpriseType, string CustomerInvoiceMethod, string CustomerInvoiceBackUp, string CreditCard)
        {
        
            string Review_And_Submit_Page_StationId_UI = Gettext(attributeName_xpath, ReviewSubmitPage_StationId_Value_Xpath);
            Assert.AreEqual(Station_Id.ToUpper(), Review_And_Submit_Page_StationId_UI.ToUpper());

            string Review_And_Submit_Page_StationName_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Station_Name_Value_Xpath);
            Assert.AreEqual(StationName_UI_AccInformationPage, Review_And_Submit_Page_StationName_UI);

            string Review_And_Submit_Page_SalesRep_UI = Gettext(attributeName_xpath, ReviewSubmitPage_SalesRep_Value_Text_Xpath);
            Assert.AreEqual(SalesRep, Review_And_Submit_Page_SalesRep_UI);

            string Review_And_Submit_Page_EnterpriseType_UI = Gettext(attributeName_xpath, ReviewSubmitPage_EnterpriseType_Value_Xpath);
            Assert.AreEqual(EnterpriseType, Review_And_Submit_Page_EnterpriseType_UI);

            //Invoice requirements
            string Review_And_Submit_Page_CustInvMethod_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustomerInvoiceMethod_Value_Xpath);
            Assert.AreEqual(CustomerInvoiceMethod, Review_And_Submit_Page_CustInvMethod_UI);

            string Review_And_Submit_Page_CustInvBackUp_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustomerInvoiceBackUp_Value_Xpath);
            Assert.AreEqual(CustomerInvoiceBackUp, Review_And_Submit_Page_CustInvBackUp_UI);

            string Review_And_Submit_Page_CreditCard_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CreditCard_Value_Xpath);
            Assert.AreEqual(CreditCard, Review_And_Submit_Page_CreditCard_UI);

        }

        [Given(@"I able to see Location and Contact details in Review and Submit Page(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeLocationAndContactDetailsInReviewAndSubmitPage(string Name, string Address1, string Address2, string City, string State, string Zip, string Country, string PhoneNumber, string Email, string FaxNumber, string Website, string Residential_Location, string Comments)
        {
            //Customer LocationS
            string Review_And_Submit_Page_CustLoc_Name_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustLoc_Name_Value_Xpath);
            Assert.AreEqual(Name.ToUpper(), Review_And_Submit_Page_CustLoc_Name_UI.ToUpper());



            string Review_And_Submit_Page_CustLoc_Address1_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustLoc_Address1_Value_Xpath);
            Assert.AreEqual(Address1.ToUpper(), Review_And_Submit_Page_CustLoc_Address1_UI.ToUpper());

            string Review_And_Submit_Page_CustLoc_Address2_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustLoc_Address2_Value_Xpath);
            Assert.AreEqual(Address2.ToUpper(), Review_And_Submit_Page_CustLoc_Address2_UI.ToUpper());


            string Review_And_Submit_Page_CustLoc_CityStateZip_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustLoc_CityStateZip_Value_Xpath);

            string[] b = Review_And_Submit_Page_CustLoc_CityStateZip_UI.Split(',').Select(x => x.Trim()).ToArray();
            string City_Splitted = b[0];
            Assert.AreEqual(City.ToUpper(), City_Splitted.ToUpper());

            string State_Splitted = b[1];// AL
            Assert.AreEqual(State.ToUpper(), State_Splitted);

            string Zip_Splitted = b[2];
            Assert.AreEqual(Zip, Zip_Splitted);

            string Review_And_Submit_Page_CustLoc_ResidentialLocations_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustLoc_Residential_Location_Value_Xpath);
            Assert.AreEqual(Residential_Location, Review_And_Submit_Page_CustLoc_ResidentialLocations_UI);

            string Review_And_Submit_Page_CustLoc_Comments_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustLoc_Comments_Value_Xpath);
            Assert.AreEqual(Comments.ToUpper(), Review_And_Submit_Page_CustLoc_Comments_UI.ToUpper());

            //Bill To Location

            string Review_And_Submit_Page_BillToLoc_Name_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToLoc_Name_Value_Xpath);
            Assert.AreEqual(Name.ToUpper(), Review_And_Submit_Page_BillToLoc_Name_UI.ToUpper());



            string Review_And_Submit_Page_BillToLoc_Address1_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToLoc_Address1_Value_Xpath);
            Assert.AreEqual(Address1.ToUpper(), Review_And_Submit_Page_BillToLoc_Address1_UI.ToUpper());

            string Review_And_Submit_Page_BillToLoc_Address2_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToLoc_Address2_Value_Xpath);
            Assert.AreEqual(Address2.ToUpper(), Review_And_Submit_Page_BillToLoc_Address2_UI.ToUpper());


            string Review_And_Submit_Page_BillToLoc_CityStateZip_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToLoc_CityStateZip_Value_Xpath);

            string[] C = Review_And_Submit_Page_CustLoc_CityStateZip_UI.Split(',').Select(x => x.Trim()).ToArray();
            string City_Split = C[0];
            Assert.AreEqual(City.ToUpper(), City_Split.ToUpper());

            string State_Split = C[1];
            Assert.AreEqual(State.ToUpper(), State_Split);

            string Zip_Split = C[2];
            Assert.AreEqual(Zip, Zip_Split);

            //Customer Contact Information

            string Review_And_Submit_Page_CustContactInfo_Name_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustContactInfo_Name_Value_Xpath);
            Assert.AreEqual(Name.ToUpper(), Review_And_Submit_Page_CustContactInfo_Name_UI.ToUpper());

            string Review_And_Submit_Page_CustContactInfo_Phone_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustContactInfo_PhoneNumber_Value_Xpath);
            string ContactInfoPhoneSplitted = Regex.Replace(Review_And_Submit_Page_CustContactInfo_Phone_UI, @"[^\d]", "");

            Assert.AreEqual(PhoneNumber, ContactInfoPhoneSplitted);

            string Review_And_Submit_Page_CustContactInfo_Email_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustContactInfo_Email_Value_Xpath);
            Assert.AreEqual(Email, Review_And_Submit_Page_CustContactInfo_Email_UI);

            string Review_And_Submit_Page_CustContactInfo_Fax_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustContactInfo_FaxNumber_Value_Xpah);
            string ContactInfoFaxSplitted = Regex.Replace(Review_And_Submit_Page_CustContactInfo_Fax_UI, @"[^\d]", "");
            Assert.AreEqual(FaxNumber, ContactInfoFaxSplitted);

            string Review_And_Submit_Page_CustContactInfo_Website_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustContactInfo_Website_Value_Xpath);
            Assert.AreEqual(Website, Review_And_Submit_Page_CustContactInfo_Website_UI);




            //Bill To Contact Information

            string Review_And_Submit_Page_BillToContactInfo_Name_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToContactInfo_Name_Value_Xpath);
            Assert.AreEqual(Name.ToUpper(), Review_And_Submit_Page_BillToContactInfo_Name_UI.ToUpper());

            string Review_And_Submit_Page_BillToContactInfo_Phone_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToContactInfo_Phone_Value_Xpath);
            string BillToContactInfoPhoneSplitted = Regex.Replace(Review_And_Submit_Page_BillToContactInfo_Phone_UI, @"[^\d]", "");

            Assert.AreEqual(PhoneNumber, BillToContactInfoPhoneSplitted);

            string Review_And_Submit_Page_BillToContactInfo_Email_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToContactInfo_Email_Value_Xpath);
            Assert.AreEqual(Email, Review_And_Submit_Page_BillToContactInfo_Email_UI);

            string Review_And_Submit_Page_BillToContactInfo_Fax_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToContactInfo_Fax_Value_Xpath);
            string BillToContactInfoFaxSplitted = Regex.Replace(Review_And_Submit_Page_BillToContactInfo_Fax_UI, @"[^\d]", "");

            Assert.AreEqual(FaxNumber, BillToContactInfoFaxSplitted);

            string Review_And_Submit_Page_BillToContactInfo_Website_UI = Gettext(attributeName_xpath, ReviewSubmitPage_BillToContactInfo_Website_Value_Xpath);
            Assert.AreEqual(Website, Review_And_Submit_Page_BillToContactInfo_Website_UI);
        }

        [Given(@"I able to see Gainshare Pricing details in Review and Submit Page(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeGainsharePricingDetailsInReviewAndSubmitPage(string PricingType, string percentage, string MinThreshold_Charge, string MinAmount_Added, string carriersExcluded, string Household_Goods, string Rating_Instructions)
        {
            //Pricing Model Gainshare
            string Review_And_Submit_Page_Gainshare_Header_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Gainshare_Header_Value_Xpath);
            Assert.AreEqual(PricingType.ToUpper(), Review_And_Submit_Page_Gainshare_Header_UI);

            string Review_And_Submit_Page_Gainshare_Percentage_UI = Gettext(attributeName_xpath, ReviewSubmitPage_percentage_Value_Xpath);

            string Percentagedata = percentage + ".00";
            string ExpectedPercentage = Percentagedata + "%";
            Assert.AreEqual(ExpectedPercentage, Review_And_Submit_Page_Gainshare_Percentage_UI);

            string Review_And_Submit_Page_Gainshare_MinThreshold_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Gainshare_MinThreshold_Charge_Value_Xpath);
            string MinThresholddata = "$" + MinThreshold_Charge + ".00";
            Assert.AreEqual(MinThresholddata, Review_And_Submit_Page_Gainshare_MinThreshold_UI);

            string Review_And_Submit_Page_Gainshare_MinAmount_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Gainshare_MinAmount_Added_Value_Xpath);
            string MinAmountdata = "$" + MinAmount_Added + ".00";
            Assert.AreEqual(MinAmountdata, Review_And_Submit_Page_Gainshare_MinAmount_UI);

            string Review_And_Submit_Page_Gainshare_CarriersExcluded_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Gainshare_carriersExcluded_Value_Xpath);
            Assert.AreEqual(carriersExcluded, Review_And_Submit_Page_Gainshare_CarriersExcluded_UI);

            string Review_And_Submit_Page_Gainshare_HouseholdGoods_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Gainshare_HouseholdGoods_Value_Xpath);
            Assert.AreEqual(Household_Goods, Review_And_Submit_Page_Gainshare_HouseholdGoods_UI);



            string Review_And_Submit_Page_Gainshare_RatingInstr_RateProv_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Gainshare_RatingInst_RateProvison_Value_Xpath);
            Assert.AreEqual(Rating_Instructions, Review_And_Submit_Page_Gainshare_RatingInstr_RateProv_UI);
        }

        
        [Given(@"I able to See Templates Uploaded in Review and Submit Page")]
        public void GivenIAbleToSeeTemplatesUploadedInReviewAndSubmitPage()
        {
            scrollpagedown();

            //Item Templates
            string Review_And_Submit_Page_ItemsTemplate_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Item_Template_Value_Xpath);
            Assert.AreEqual(Attached_ItemTemplate_Name, Review_And_Submit_Page_ItemsTemplate_UI);

            //Address templates
            string Review_And_Submit_Page_AddressTemplate_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Address_Template_Value_Xpath);
            Assert.AreEqual(Attached_AddressTemplate_Name, Review_And_Submit_Page_AddressTemplate_UI);

            //Portal Users Template
            string Review_And_Submit_Page_PortalUsersTemplate_UI = Gettext(attributeName_xpath, ReviewSubmitPage_PortalUsers_Template_Value_Xpath);
            Assert.AreEqual(Attached_PortalUSersTemplate_Name, Review_And_Submit_Page_PortalUsersTemplate_UI);
        }



        [When(@"I click on the Submit button leads to Submit CSR")]
        public void WhenIClickOnTheSubmitButtonLeadsToSubmitCSR()
        {
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();
            Thread.Sleep(1000);
            scrollpagedown();

            Click(attributeName_xpath, ReviewSubmitPage_SubmitButton_Xpath);
            Thread.Sleep(9000);
        }

        [Then(@"I will see the PopUp denotes that CSR been submitted(.*)")]
        public void ThenIWillSeeThePopUpDenotesThatCSRBeenSubmitted(string CSRSubmitted_Text)
        {
            WaitForElementVisible(attributeName_xpath, CSR_Submitted_Text_Xpath, "CSR Submission Message");
            string CSRSubmission_Message = Gettext(attributeName_xpath, CSR_Submitted_Text_Xpath);
            Assert.AreEqual(CSRSubmitted_Text, CSRSubmission_Message);
        }

        [Given(@"I Click Create a Saved Address button and Enter Address Details(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIClickCreateASavedAddressButtonAndEnterAddressDetails(string Name, string Address1, string Address2, string City, string Country, string State, string Zip)
        {
            Click(attributeName_xpath, Create_A_SavedAddress_button_Xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_xpath, Create_A_SavedAddress_Name_textbox_Xpath, Name);
            SendKeys(attributeName_xpath, Create_A_SavedAddress_Address1_Textbox_Xpath, Address1);
            SendKeys(attributeName_xpath, Create_A_SavedAddress_Address2_Textbox_Xpath, Address2);
            SendKeys(attributeName_xpath, Create_A_SavedAddress_City_Textbox_Xpath, City);
            Click(attributeName_xpath, Create_A_SavedAddress_Country_dropdown_Xpath);
            
            //SelectDropdownValueFromList(attributeName_xpath, Create_A_SavedAddress_Country_dropdownList_Xpath, Country);
            Thread.Sleep(500);
            Click(attributeName_xpath, Create_A_SavedAddress_State_dropdown_Xpath);
            
            SelectDropdownValueFromList(attributeName_xpath, Create_A_SavedAddress_State_dropdownList_Xpath, State);
            Thread.Sleep(500);
            SendKeys(attributeName_xpath, Create_A_SavedAddress_Zip_Xpath, Zip);
            Thread.Sleep(300);
            Click(attributeName_xpath, Create_A_SavedAddress_Save_button_Xpath);
            Thread.Sleep(1500);
        }

        [Given(@"I Click on Create a Portal User button and Enter User Details(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIClickOnCreateAPortalUserButtonAndEnterUserDetails(string FirstName, string LastName, string Email, string ExternalUserType, string TMSType, string OfficeNumber)
        {
            Click(attributeName_xpath, PortalUsers_Yes_Radiobutton_Xpath);
            Thread.Sleep(1000);
            Click(attributeName_xpath, Create_A_PortalUser_button_Xpath);
            
            SendKeys(attributeName_xpath, Create_A_PortalUser_FirstName_Textbox_Xpath, FirstName);
            SendKeys(attributeName_xpath, Create_A_PortalUser_LastName_Textbox_Xpath, LastName);
            SendKeys(attributeName_xpath, Create_A_PortalUser_EmailAddress_Textbox_Xpath, Email);
            Click(attributeName_xpath, Create_A_PortalUser_UserType_dropdown_Xpath);
            
            SelectDropdownValueFromList(attributeName_xpath, Create_A_PortalUser_UserType_dropdownList_Xpath, ExternalUserType);
            Thread.Sleep(800);
            Click(attributeName_xpath, Create_A_PortalUser_TMSType_dropdown_Xpath);
            //Thread.Sleep(500);
            SelectDropdownValueFromList(attributeName_xpath, Create_A_PortalUser_TMSType_dropdownList_Xpath, TMSType);
            Thread.Sleep(800);
            SendKeys(attributeName_xpath, Create_A_PortalUser_OfficeNumber_Textbox_Xpath, OfficeNumber);
            Click(attributeName_xpath, Create_A_PortalUser_Next_button_Xpath);
            Thread.Sleep(800);
            Click(attributeName_xpath, Create_A_PortalUser_CreateUser_button_Xpath);
            Thread.Sleep(1500);
        }

        [Given(@"I able to see Account Information details for MG TMS Type with Sales Rep Other in Review and Submit Page(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeAccountInformationDetailsForMGTMSTypeWithSalesRepOtherInReviewAndSubmitPage(string Station_Id, string OtherValue, string EnterpriseType, string CustomerInvoiceMethod, string CustomerInvoiceBackUp, string CreditCard)
        {
            string Review_And_Submit_Page_StationId_UI = Gettext(attributeName_xpath, ReviewSubmitPage_StationId_Value_Xpath);
            Assert.AreEqual(Station_Id.ToUpper(), Review_And_Submit_Page_StationId_UI.ToUpper());

            string Review_And_Submit_Page_StationName_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Station_Name_Value_Xpath);
            Assert.AreEqual(StationName_UI_AccInformationPage, Review_And_Submit_Page_StationName_UI);

            string Review_And_Submit_Page_SalesRep_UI = Gettext(attributeName_xpath, ReviewSubmitPage_SalesRep_Value_Text_Xpath);
            Assert.AreEqual(OtherValue, Review_And_Submit_Page_SalesRep_UI);

            string Review_And_Submit_Page_EnterpriseType_UI = Gettext(attributeName_xpath, ReviewSubmitPage_EnterpriseType_Value_Xpath);
            Assert.AreEqual(EnterpriseType, Review_And_Submit_Page_EnterpriseType_UI);

            //Invoice requirements
            string Review_And_Submit_Page_CustInvMethod_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustomerInvoiceMethod_Value_Xpath);
            Assert.AreEqual(CustomerInvoiceMethod, Review_And_Submit_Page_CustInvMethod_UI);

            string Review_And_Submit_Page_CustInvBackUp_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CustomerInvoiceBackUp_Value_Xpath);
            Assert.AreEqual(CustomerInvoiceBackUp, Review_And_Submit_Page_CustInvBackUp_UI);

            string Review_And_Submit_Page_CreditCard_UI = Gettext(attributeName_xpath, ReviewSubmitPage_CreditCard_Value_Xpath);
            Assert.AreEqual(CreditCard, Review_And_Submit_Page_CreditCard_UI);
        }

        [Given(@"I able to see Tariff Pricing details in Review and Submit Page(.*),(.*),(.*),(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeTariffPricingDetailsInReviewAndSubmitPage(string PricingType, string TariffType, string Discount, string Minimum, string carriersExcluded, string Household_Goods, string SpecialRate)
        {

            string Review_And_Submit_Page_Tariff_Header_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_Header_Value_Xpath);
            Assert.AreEqual(PricingType.ToUpper(), Review_And_Submit_Page_Tariff_Header_UI);

            string Review_And_Submit_Page_Tariff_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_Type_Value_Xpath);
            Assert.AreEqual(TariffType, Review_And_Submit_Page_Tariff_UI);

            string Review_And_Submit_Page_Tariff_Discount_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_Discount_Value_Xpath);
            string Discountdata = Discount + ".00";
            string ExpectedDiscount = Discountdata + "%";
            Assert.AreEqual(ExpectedDiscount, Review_And_Submit_Page_Tariff_Discount_UI);

            string Review_And_Submit_Page_Tariff_Minimum_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_Minimum_Value_Xpath);
            string ExpectedMinimum = "$" + Minimum + ".00";
            Assert.AreEqual(ExpectedMinimum, Review_And_Submit_Page_Tariff_Minimum_UI);

            string Review_And_Submit_Page_Tariff_CarriersExluded_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_carriersExcluded_Value_Xpath);
            Assert.AreEqual(carriersExcluded, Review_And_Submit_Page_Tariff_CarriersExluded_UI);

            string Review_And_Submit_Page_Tariff_HouseholdGoods_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_HouseholdGoods_Value_Xpath);
            Assert.AreEqual(Household_Goods, Review_And_Submit_Page_Tariff_HouseholdGoods_UI);

            string Review_And_Submit_Page_Tariff_SpecialRateProv_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Tariff_SpecialRatingProvisions_Value_Xpath);
            Assert.AreEqual(SpecialRate, Review_And_Submit_Page_Tariff_SpecialRateProv_UI);

        }

        [Given(@"I able to see manually created Item details in Review and Submit Page(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeManuallyCreatedItemDetailsInReviewAndSubmitPage(string Classification, string NMFC, string ItemDescription, string HazardousMaterials)
        {
            string Review_And_Submit_Page_Item_Classification_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Item_Classification_Value_Xpath);
            Assert.AreEqual(Classification, Review_And_Submit_Page_Item_Classification_Value_UI);

            string Review_And_Submit_Page_Item_NMFC_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Item_NMFC_Value_Xpath);
            Assert.AreEqual(NMFC, Review_And_Submit_Page_Item_NMFC_Value_UI);

            string Review_And_Submit_Page_Item_ItemDescription_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Item_description_Value_Xpath);
            Assert.AreEqual(ItemDescription, Review_And_Submit_Page_Item_ItemDescription_Value_UI);

            string Review_And_Submit_Page_Item_HazMat_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Item_Hazmat_Value_Xpath);
            Assert.AreEqual(HazardousMaterials, Review_And_Submit_Page_Item_HazMat_Value_UI);

        }

        [Given(@"I able to see manually created Address details in Review and Submit Page(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeManuallyCreatedAddressDetailsInReviewAndSubmitPage(string Name, string City, string State, string Zip)
        {

            string Review_And_Submit_Page_Address_Name_Values_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Address_Name_Value_Xpath);
            Assert.AreEqual(Name.ToUpper(), Review_And_Submit_Page_Address_Name_Values_UI.ToUpper());

            string Review_And_Submit_Page_Address_City_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Address_City_Value_Xpath);
            Assert.AreEqual(City, Review_And_Submit_Page_Address_City_Value_UI);

            string Review_And_Submit_Page_Address_StateProvince_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Address_State_Province_Value_Xpath);
            Assert.AreEqual(State, Review_And_Submit_Page_Address_StateProvince_Value_UI);

            string Review_And_Submit_Page_Address_Zip_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_Address_Zip_Value_Xpath);
            Assert.AreEqual(Zip, Review_And_Submit_Page_Address_Zip_Value_UI);
        }

        [Given(@"I able to see manually created Portal Users details in Review and Submit Page(.*),(.*),(.*),(.*)")]
        public void GivenIAbleToSeeManuallyCreatedPortalUsersDetailsInReviewAndSubmitPage(string FirstName, string LastName, string ExternalUserType, string TMSType)
        {
            //Portal USers Verification
            string PortalUser_Name_UI = Gettext(attributeName_xpath, ReviewSubmitPage_PortalUser_Name_Value_Xpath);
            string ExpectedName = FirstName + " " + LastName;
            Assert.AreEqual(ExpectedName.ToUpper(), PortalUser_Name_UI.ToUpper());

            string Review_And_Submit_Page_Portal_UserType_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_PortalUser_UserType_Value_Xpath);
            Assert.AreEqual(ExternalUserType, Review_And_Submit_Page_Portal_UserType_Value_UI);

            string Review_And_Submit_Page_Portal_UserTMS_Value_UI = Gettext(attributeName_xpath, ReviewSubmitPage_PortalUser_TMSType_Value_Xpath);
            Assert.AreEqual(TMSType, Review_And_Submit_Page_Portal_UserTMS_Value_UI);
        }
        
    }
}
