using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_SubmitAClaimPage_SaveInfoSteps : CRM.UITest.Objects.InsuranceClaim
    {
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
        int _claim = 0;
        string UIDLSDate = null;
        string Fullpath = "../../Scripts/TestData/Testfiles_ClaimDocument/QuoteListCheck.txt";
        string CustomerClaimRef = "cvdt 15 !@#$% :{_ ab";
        InsuranceClaimViewModel ClaimDetails = null;
        InsuranceClaimsubmit CreateClaim = new InsuranceClaimsubmit();

        [When(@"Data has been passed to all the fields on Submit a claim page (.*)")]
        public void WhenDataHasBeenPassedToAllTheFieldsOnSubmitAClaimPage(string user)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            _claim = CreateClaim.Claimsubmit(user);
        }

        [Given(@"Data has been passed to all the fields on Submit a claim page")]
        public void GivenDataHasBeenPassedToAllTheFieldsOnSubmitAClaimPage()
        {
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
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            //SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, ShipperCountry);
             SelectDropdownValueFromList(attributeName_xpath, Shipper_SelectingUnitedStates_Xpath, ShipperCountry);
            Click(attributeName_id, ShipperState_Id);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, ShipperState);
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, ShipperCity);
            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneZip);
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, ConsigneCountry);
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
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, ClaimCountry);
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
            Click(attributeName_xpath, ReturnCheckBox_Xpath);
            SendKeys(attributeName_classname, ReturnFreightVal_Class, ReturnFreight);
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
            Click(attributeName_xpath, ReplacementCheckBox_Xpath);
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
            WaitForElementVisible(attributeName_xpath, DocumentDropdown_Xpath,"Doctype");
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
        }


        [Then(@"All the data should get saved in DB along with the username of the user that submitted the claim, First name  and last name of the submitted user, date and time")]
        public void ThenAllTheDataShouldGetSavedInDBAlongWithTheUsernameOfTheUserThatSubmittedTheClaimFirstNameAndLastNameOfTheSubmittedUserDateAndTime()
        {
            List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimNumber);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().DlswRefNumber, DLSBill);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierName, CarrierName);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().CarrierProNumber, CarrierPRO);
            Report.WriteLine("Passed carrier information is saved in DB");
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperName, ShipperName);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAddress, ShipperAddress);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperAdd2, ShipperAdd2);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperZip, ShipperZip);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCountry, ShipperCountry);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperCity, ShipperCity);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipperState, ShipperState);
            Report.WriteLine("Passed shipper information is saved in DB");
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneName, ConsigneName);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAddress, ConsigneAddress);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneAdd2, ConsigneAddress2);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneZip, ConsigneZip);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCountry, ConsigneCountry);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneCity, ConsigneCity);
            //Assert.AreEqual(ClaimDetails.FirstOrDefault().ConsigneState, ConsigneProvince);
            Report.WriteLine("Passed consigne information is saved in DB");
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCompanyName, ClaimCompanyName);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimAddress, ClaimAddress);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimAdd2, ClaimAddress2);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimZip, ClaimZip);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCountry, ClaimCountry);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimCity, ClaimCity);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactName, ClaimContactName);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactPhone, ClaimPhone);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimContactEmail, ClaimEmail);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ClaimWebsite, ClaimWebsite);
            Report.WriteLine("Passed Claim payable to information is saved in DB");
            if (ClaimDetails.FirstOrDefault().IsArticlesIns == true)
            {
                Assert.AreEqual(ClaimDetails.FirstOrDefault().InsuredValAmount.ToString(), InsuredAmount);
            }
            else
            {
                Report.WriteFailure("Articles insured flag was not set even after selecting 'YES'");

            }

            if (ClaimDetails.FirstOrDefault().ClaimTypeId == 1)
            {
                Report.WriteLine("Claim type Shortage is inserted into DB");
            }
            else
            {
                Report.WriteFailure("Claim type shortage is nor inserted into DB");
            }

            if (ClaimDetails.FirstOrDefault().AritcleTypeId == 2)
            {
                Report.WriteLine("Articles type Used is inserted into DB");
            }
            else
            {
                Report.WriteFailure("Articles type Used is not inserted into DB");
            }
            //Assert.AreEqual(ClaimDetails.FirstOrDefault().ItemNum, ItemMode);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().UnitVal.ToString(), UnitVal);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().Quantity.ToString(), Quantity);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().Weight.ToString(), Weight);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().Description, ClaimDescription);
            Report.WriteLine("Passed claim details are saved in DB");
            Assert.AreEqual(ClaimDetails.FirstOrDefault().OriginalFreightCharge.ToString(), OriginFreightCharge);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnFreightCharge.ToString(), ReturnFreight);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplacementFreightCharge.ToString(), ReplaceFreightCharge);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ReturnDLSRefNum, ReturnDLS);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ReplaceDLSWRefNum, ReplaceDLS);
            Report.WriteLine("Passed Freight information is saved in DB");
            Assert.AreEqual(ClaimDetails.FirstOrDefault().Remarks, Remark);
            if (ClaimDetails.FirstOrDefault().CreatedBy == "zzzext")
            {
                Report.WriteLine("Username of the user who submitted the claim is inserted into DB");
            }
            else
            {
                Assert.Fail();
            }
            if (ClaimDetails.FirstOrDefault().FirstName == "Zzz")
            {
                Report.WriteLine("Firstname of the user who submitted the claim is saved in DB");
            }
            else
            {
                Assert.Fail();
            }

            if (ClaimDetails.FirstOrDefault().LastName == "Ext")
            {
                Report.WriteLine("Lastname of the user who submitted the claim is saved in DB");
            }
            else
            {
                Assert.Fail();

            }

        }


        [Then(@"Claim will be placed in Pending status\.")]
        public void ThenClaimWillBePlacedInPendingStatus_()
        {
            int StatusId = DBHelper.GetInsuranceStatus(ClaimNumber);
            if (StatusId == 4)
            {
                Report.WriteLine("Submited Insurance claim is placed in pending status");
            }
            else
            {
                Report.WriteFailure("Submited Insurance claim is not placed in pending status");
            }

        }

        [Then(@"the ""(.*)"" of Customer Claim Ref field will be saved")]
        public void ThenTheOfCustomerClaimRefFieldWillBeSaved(string actualclaimantreferencevalue)
        {
            actualclaimantreferencevalue = CustomerClaimRef;
            ClaimDetails = DBHelper.GetInsuranceClaimValues(_claim);
            Assert.AreEqual(ClaimDetails.CustomerClaimReferenceNumber, actualclaimantreferencevalue);
        }

        [Then(@"the value of the Customer Claim Ref will be pushed to the Customer Ref column of the Claims List page (.*)")]
        public void ThenTheValueOfTheCustomerClaimRefWillBePushedToTheCustomerRefColumnOfTheClaimsListPage(string usertype)
        {
            Report.WriteLine("Verifying Claimant Reference value");
            if (usertype != "Claimspecialist")
            {
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Convert.ToString(_claim));
                string claimantReferenceumberfromClaimsListpage = Gettext(attributeName_xpath, claimlist_customerref_xpath);
                Assert.AreEqual(CustomerClaimRef, claimantReferenceumberfromClaimsListpage);
            }
            else
            {
                Report.WriteLine("CustomerClaimRef column is not available for Claimspecialist user in claim list screen");
            }
        }

    }
}
