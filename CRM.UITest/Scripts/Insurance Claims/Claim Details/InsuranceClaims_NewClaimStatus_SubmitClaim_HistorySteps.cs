using System;
using System.IO;
using System.Configuration;
using System.Globalization;
using System.Threading;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;
using OpenQA.Selenium;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_NewClaimStatus_SubmitClaim_HistorySteps : CRM.UITest.Objects.InsuranceClaim
    {
        int claimNumber = 0;
        InsuranceClaimHistory claimHistoryTab = null;
        string userType = string.Empty;

        string DLSBill = "BillLading123";
        string CarrierName = "Carrier123";
        string CarrierPRO = "123QA";
        string ShipperName = "Testing 1@3";
        string ShipperAddress = "AddressTest!123";
        string ShipperAdd2 = "Address223";
        string ShipperZip = "90001";
        string ShipperCity = "los@#$%";
        string ConsigneName = "Consigneename";
        string ConsigneAddress = "ConsigneAddress";
        string ConsigneAddress2 = "ConsigneAddress2";
        string ConsigneZip = "33126";
        string ConsigneCity = "ConsigneeCity#234";
        string ClaimCompanyName = "CompanyName";
        string ClaimAddress = "Address )**(434";
        string ClaimAddress2 = "Address2";
        string ClaimCity = "City";
        string ClaimProvince = "FL";
        string ClaimContactName = "ContactName";
        string ClaimPhone = "84324249324";
        string ClaimEmail = "dyafdyu@gmail.com";
        string ClaimWebsite = "www.shua.com";
        string InsuredAmount = "23.00";
        string ItemMode = "Itemcheck@123";
        string UnitVal = "23.00";
        string Quantity = "45";
        string Weight = "23.00";
        string ClaimDescription = "Description Test 123";
        string OriginFreightCharge = "23.00";
        string ReturnFreight = "23.00";
        string ReturnDLS = "45564321236789087654";
        string ReplaceFreightCharge = "20.00";
        string ReplaceDLS = "532756";
        string Remark = "jdhasu5535437hgd$#%^";
        string ShipperCountry = "United States";
        string ShipperState = "AL";
        string ConsigneCountry = "United States";
        string ConsigneProvince = "AL";
        string ClaimCountry = "United States";
        string DocumentType = "Repair Invoice";
        string ClaimZip = "32435";
        int ClaimNumber = 0;
        string UIDLSDate = null;
        string Fullpath = "../../Scripts/TestData/Testfiles_ClaimDocument/QuoteListCheck.txt";

        InsuranceClaims_SubmitAClaimPage_SaveInfoSteps stepsToSubmitNewClaim = new InsuranceClaims_SubmitAClaimPage_SaveInfoSteps();
        [Given(@"I'm shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates Sales, Sales Management, Operations, Station Owner user or claims Specialist user(.*)")]
        public void GivenIMShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerUserOrClaimsSpecialistUser(string loginUsertype)
        {
            userType = loginUsertype;
            string username = string.Empty;
            string password = string.Empty;
            if (userType == "Internal")
            {
                username = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            }
            if (userType == "Sales")
            {
                username = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
            }
            if (userType == "Claimspecialist")
            {
                username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            }
            if(userType == "External")
            {
                username = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            }
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"all required fields have been completed")]
        public int GivenAllRequiredFieldsHaveBeenCompleted()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            if (userType != "External")
            {
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, "ZZZ - Web Services Test");
                Thread.Sleep(5000);
                Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, "ZZZ - GS Customer Test");
            }
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, DLSBill);
            SendKeys(attributeName_id, CarrierName_Textbox_Id, CarrierName);
            Click(attributeName_id, DLSW_BOLDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);
            UIDLSDate = Gettext(attributeName_id, DLSW_BOLDate_Field_Id);
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, CarrierPRO);
            Click(attributeName_id, CarrierProDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);
            Report.WriteLine("Carrier information is passed");
            scrollpagedown();
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, ShipperName);
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, ShipperAddress);
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, ShipperAdd2);
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, ShipperZip);
            Click(attributeName_id, ShipperState_Id);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, ShipperState);
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, ShipperCity);
            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneZip);
            Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_provinceDropdown_values_Xpath, ConsigneProvince);
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, ConsigneCity);
            Report.WriteLine("Consignee information is passed");
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, ClaimCompanyName);
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, ClaimAddress);
            SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, ClaimAddress2);
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, ClaimZip);
            SendKeys(attributeName_id, ClaimPayableTo_City_Id, ClaimCity);
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, ClaimContactName);
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, ClaimPhone);
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, ClaimEmail);
            SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, ClaimWebsite);
            Report.WriteLine("Claim payable to information is passed");
            scrollpagedown();
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            SendKeys(attributeName_id, InsuredAmount_Id, InsuredAmount);
            Click(attributeName_xpath, ShortageOption_Xpath);
            Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
            SendKeys(attributeName_id, UnitValue_Id, UnitVal);
            SendKeys(attributeName_id, Quantity_Id, Quantity);
            SendKeys(attributeName_id, Weight_LBS_Id, Weight);
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, ClaimDescription);
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_classname, OriginFreightChargeOptionField_Class);
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, OriginFreightCharge);
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("$('#btn-returnFreightchargesReturnFreightCharges').click();");
            SendKeys(attributeName_classname, ReturnFreightVal_Class, ReturnFreight);
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
            executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            executor.ExecuteScript("$('#btn-replacementFreightchargesReplacementFreightCharges').click();");
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, ReplaceFreightCharge);
            SendKeys(attributeName_id, ReplaceDLS_Id, ReplaceDLS);
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, ReplaceFreightCharge);
            SendKeys(attributeName_id, ReplaceDLS_Id, ReplaceDLS);
            Report.WriteLine("Claim details are been passed");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(3000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(3000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(3000);
            File.Copy(oldPath, newPath, true);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(3000);
            File.Delete(newPath);
            scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
            Click(attributeName_id, AddAdditionalDocument_Button_Id);
            WaitForElementVisible(attributeName_xpath, DocumentDropdown_Xpath, "Doctype");
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            Thread.Sleep(3000);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, DocumentType);
            Thread.Sleep(5000);
            string oldAddPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/hacker.txt");
            string newAddPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "hacker1.txt");
            File.Copy(oldAddPath, newAddPath, true);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, newAddPath);
            Thread.Sleep(3000);
            File.Delete(newAddPath);
            Report.WriteLine("Documents are uploaded");
            SendKeys(attributeName_id, RemarksField_Id, Remark);
            ClaimNumber = DBHelper.GetClaimNumber();
            ClaimNumber++;
            return ClaimNumber;
        }

        [When(@"I Click on Submit Claim button")]
        public void WhenIClickOnSubmitClaimButton()
        {
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Clicked on Submit claim button");
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsList_InstructionalVerbiage_xpath, "Cliam list");
        }


        [Then(@"the claim will be place in ""(.*)"" status")]
        public void ThenTheClaimWillBePlaceInStatus(string submittedstatus)
        {
            //Click(attributeName_xpath, ClaimlistGridFilterbySubmittedCheckbox_Xpath);
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, ClaimNumber.ToString());
            Thread.Sleep(2000);
            if (userType == "Internal" || userType == "External")
            {
                string claimstatus = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[8]");
                if (claimstatus.Contains(submittedstatus))
                {
                    Report.WriteLine("New Claim is in Submitted Status");
                }
            }
            else if(userType == "Claimspecialist")
            {
                string claimstatus = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[10]");
                if (claimstatus.Contains(submittedstatus))
                {
                    Report.WriteLine("New Claim is in Submitted Status");
                }
            }

            
        }

        [Then(@"a record will be added to the Status/History tab")]
        public void ThenARecordWillBeAddedToTheStatusHistoryTab()
        {
            if (userType != "External")
            {
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']//*[@class= 'DlswClaimNumber']");
                GlobalVariables.webDriver.WaitForPageLoad();
                DefineTimeOut(1000);
                Report.WriteLine("I click on the History Tab");
                Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
                claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(ClaimNumber.ToString());
                string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.CreatedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                    .ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
                string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
                Assert.AreEqual(ctzdate, dateTimeFromUI);
                Report.WriteLine("Time of the Date/Time field will be Central Time Zone");

                claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(ClaimNumber.ToString());
                string nameForTheCommentAdded = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
                Assert.AreEqual(claimHistoryTab.UserFullName, nameForTheCommentAdded);
                Report.WriteLine("CRM will record the first name and last name of the user");

                string Category = Gettext(attributeName_xpath, LatestCategoryValue_Xpath);
                Assert.AreEqual(Category, "Status Update");
            }
            else
            {
                Report.WriteLine("User is External User who dont have access to Status/History tab");
            }
        }

        [Then(@"the Comment of the record will display the verbiage ""(.*)""")]
        public void ThenTheCommentOfTheRecordWillDisplayTheVerbiage(string ClaimSubmittedtoDLSW)
        {
            if (userType != "External")
            {
                string Comment = Gettext(attributeName_xpath, LatestCommentValue_Xpath);
                Assert.AreEqual(Comment, ClaimSubmittedtoDLSW);
            }
            else
            {
                Report.WriteLine("User is External who dont access to comment section in the History tab)");
            }
        }
    }
}
