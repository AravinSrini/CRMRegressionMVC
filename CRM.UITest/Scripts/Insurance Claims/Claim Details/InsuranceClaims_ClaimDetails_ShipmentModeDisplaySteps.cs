using CRM.UITest.CommonMethods;
using CRM.UITest.CsaServiceReference;
using CRM.UITest.Entities;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.Implementations.CustomReportXML;
using CRM.UITest.Helper.Implementations.ShipmentList;
using CRM.UITest.Helper.ViewModel.Shipment;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_ShipmentModeDisplaySteps : CRM.UITest.Objects.InsuranceClaim
    {
        List<ShipmentListViewModel> Sdata;
        string Mode = null;
        string ModeCSA = null;
        int ClaimNumber = 0;
        string UIDLSDate = null;
        
        [Given(@"I have manually completed all required fields")]
        public void GivenIHaveManuallyCompletedAllRequiredFields()
        {
            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, "BillLading123");
            SendKeys(attributeName_id, CarrierName_Textbox_Id, "Carrier123");
            Click(attributeName_id, DLSW_BOLDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);
            UIDLSDate = Gettext(attributeName_id, DLSW_BOLDate_Field_Id);
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "123QA");
            Click(attributeName_id, CarrierProDate_Field_Id);
            AnyNextDatePickerFromDoubleGridCalander(attributeName_xpath, CarrierProDate_Field_Values_Xpath, -1, CarrierProDate_Field_LeftArrow_Xpath);
            Report.WriteLine("Carrier information is passed");
            ClaimPageValues();

        }
        
        [Given(@"I have populated form using DLSW REF")]
        public void GivenIHavePopulatedFormUsingDLSWREF()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, "ZZX00208760");
            InsuranceClaims_ClaimDetails_ShipmentModeDisplaySteps SubmitClaimPageVal = new InsuranceClaims_ClaimDetails_ShipmentModeDisplaySteps();
            SubmitClaimPageVal.ClaimPageValues();
        }
        
        [Given(@"Hyperlink of any displayed claim on Claims List page is clicked")]
        public void GivenHyperlinkOfAnyDisplayedClaimOnClaimsListPageIsClicked()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListPendingStatus_Xpath);
            Click(attributeName_xpath, ClaimListDLSWREF_HyperLink_Xpath);
            Report.WriteLine("Hyperlink of displayed claim on Claims List page is clicked");
        }

        [Given(@"I have populated form using DLSW REF number")]
        public void GivenIHavePopulatedFormUsingDLSWREFNumber()
        {
            SendKeys(attributeName_id, Enter_DLSW_BOLNumber_Textbox_Id, "9920495");
            ClaimPageValues();

        }


        [Then(@"The mode of the claim should be defaulted to LTL in DB")]
        public void ThenTheModeOfTheClaimShouldBeDefaultedToLTL()
        {
            List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimNumber);
            Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipmentMode, "LTL");
            Report.WriteLine("The mode of Claim is updated to LTL in DB when values are entered manually");
        }

        [Then(@"The mode of the claim should be updated with FTL in DB for carrier mode TL, PTL, IL")]
        public void ThenTheModeOfTheClaimShouldBeUpdatedWithFTLForCarrierModeTLPTLIL()
        {
            BuildHttpClient objBuildHttpClient = new BuildHttpClient();
            HttpClient headers = objBuildHttpClient.BuildHttpClientWithHeaders("Admin", "application/xml");
            GetCustomReportXML _CustXml = new GetCustomReportXML();
            XElement resuestXML = _CustXml.getListExtractRequestXML("ZZX00208760");
            Report.WriteLine("MG shipment is passed");

            string uri = $"MercuryGate/ListScreenExtract";
            ShipmentListScreen Slist = new ShipmentListScreen();
            Sdata = Slist.CallListScreenAutopopulate(uri, headers, resuestXML);
            Mode = Sdata[1].Mode;
            if(Mode == "TL"|| Mode == "PTL" || Mode == "IL")
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimNumber);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipmentMode, "FTL");
                Report.WriteLine("The mode of the claim is updated as FTL for carrier mode TL, PTL, IL");

            }
            else
            {
                Assert.Fail();
            }

        }

        [Then(@"The mode of the claim will updated with LTL in DB, if carrier mode is not TL, PTL, IL")]
        public void ThenTheModeOfTheClaimWillUpdatedWithLTLIfCarrierModeIsNotTLPTLIL()
        {
            ShipmentInquiryOutputV3 result = null;

            using (ShipmentsSoapClient csaClient = new ShipmentsSoapClient())
            {

                result = csaClient.ShipmentInquiryV3("", "9920495");
                Report.WriteLine("CSA shipment Number is passed");


                ModeCSA = result.ShipInqOutput[0].ShipmentMode;
            }

            if(ModeCSA != "TL" || ModeCSA != "PTL" || ModeCSA != "IL")
            {
                List<InsuranceClaimViewModel> ClaimDetails = DBHelper.GetInsuranceClaimVal(ClaimNumber);
                Assert.AreEqual(ClaimDetails.FirstOrDefault().ShipmentMode, "LTL");
                Report.WriteLine("The mode of the claim is updated as LTL when carrier mode is not TL, PTL, IL");
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Then(@"The mode of claim should be displayed")]
        public void ThenTheModeOfClaimShouldBeDisplayed()
        {
            string GetModeVal = Gettext(attributeName_xpath, ClaimDetailsMode_Xpath);
            if(GetModeVal != null)
            {
                Report.WriteLine("Mode of Claim is displayed");
            }
            else
            {
                Assert.Fail();
            }
        }
        
        [Then(@"The mode of the claim is non-editable\.")]
        public void ThenTheModeOfTheClaimIsNon_Editable_()
        {
            IsElementDisabled(attributeName_xpath, ClaimDetailsMode_Xpath,"Mode");
            Report.WriteLine("Mode of Claim is not editable");
        }
        
        [Then(@"I have the option to select a different claim mode")]
        public void ThenIHaveTheOptionToSelectADifferentClaimMode()
        {
            Click(attributeName_xpath, ClaimDetailsMode_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
            Report.WriteLine("Able to select different claim mode");
        }
        
        [Then(@"The options are: LTL, FTL, Forwarding")]
        public void ThenTheOptionsAreLTLFTLForwarding()
        {
            List<string> UIModes = new List<string>();
            Click(attributeName_xpath, ClaimDetailsMode_Xpath);
            List<string> ExpectedModeOptions = new List<string>(new string[] { "LTL", "FTL", "Forwarding" });
            IList<IWebElement> ModeTypes = GlobalVariables.webDriver.FindElements(By.XPath(ClaimDetailsModeDropdown_Xpath));
            foreach(IWebElement Val in ModeTypes)
            {
                UIModes.Add(Val.Text);
            }
            if (ExpectedModeOptions.ToString().Equals(UIModes.ToString()))
            {
                Report.WriteLine("Expected Mode options are displayed");
            }
            else
            {
                Assert.Fail();
            }
        }

        public void ClaimPageValues()
        {
            Report.WriteLine("MG Shipment is passed");
            Click(attributeName_id, PopulateForm_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollpagedown();
            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, "Testing 1@3");
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, "AddressTest!123");
            SendKeys(attributeName_id, Shipper_Address2_Textbox_Id, "Address223");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90001");
            Click(attributeName_xpath, Shipper_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_Country_dropdownValue_Xpath, "United States");
            Click(attributeName_id, ShipperState_Id);
            SelectDropdownValueFromList(attributeName_xpath, Shipper_provinceDropdown_values_Xpath, "AL");
            SendKeys(attributeName_id, Shipper_City_Textbox_Id, "los@#$%");
            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, "Consigneename");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, "ConsigneAddress");
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, "ConsigneAddress2");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "33126");
            Click(attributeName_xpath, Consignee_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_Country_dropdownValue_Xpath, "United States");
            Click(attributeName_xpath, Consignee_State_Province_dropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Consignee_provinceDropdown_values_Xpath, "AL");
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, "ConsigneeCity#234");
            Report.WriteLine("Consignee information is passed");
            scrollpagedown();
            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, "CompanyName");
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, "Address )**(434");
            SendKeys(attributeName_id, ClaimPayableTo_Address2_Id, "Address2");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "32435");
            SendKeys(attributeName_id, ClaimPayableTo_City_Id, "City");
            Click(attributeName_xpath, ClaimPayableTo_Country_dropdown_Xpath);
            Thread.Sleep(5000);
            SelectDropdownValueFromList(attributeName_xpath, ClaimPayableTo_Country_dropdownValue_Xpath, "United States");
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, "ContactName");
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, "84324249324");
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "dyafdyu@gmail.com");
            SendKeys(attributeName_id, ClaimPayableTo_CompanyWebsite_Id, "www.shua.com");
            Report.WriteLine("Claim payable to information is passed");
            scrollpagedown();
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            SendKeys(attributeName_id, InsuredAmount_Id, "23.00");
            Click(attributeName_xpath, ShortageOption_Xpath);
            Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
            SendKeys(attributeName_id, UnitValue_Id, "23.00");
            SendKeys(attributeName_id, Quantity_Id, "45");
            SendKeys(attributeName_id, Weight_LBS_Id, "23.00");
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, "Description Test 123");
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_classname, OriginFreightChargeOptionField_Class);
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, "23.00");
            SendKeys(attributeName_classname, ReturnFreightVal_Class, "23.00");
            SendKeys(attributeName_id, ReturnDLS_Id, "45564321236789087654");
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, "20.00");
            SendKeys(attributeName_id, ReplaceDLS_Id, "532756");
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
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Repair Invoice");
            Thread.Sleep(5000);
            string oldAddPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/hacker.txt"); ;
            string newAddPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "hacker1.txt"); ;
            File.Copy(oldAddPath, newAddPath, true);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, newAddPath);
            Thread.Sleep(3000);
            File.Delete(newAddPath);
            Report.WriteLine("Documents are uploaded");
            SendKeys(attributeName_id, RemarksField_Id, "jdhasu5535437hgd$#%^");
            ClaimNumber = DBHelper.GetClaimNumber();
            ClaimNumber++;
        }
    }
}
