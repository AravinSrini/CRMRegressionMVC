using CRM.UITest.Objects;

using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using TechTalk.SpecFlow;


namespace CRM.UITest.CommonMethods
{
    class InsuranceClaimsubmit : InsuranceClaim
    {
        string originFreightCharge = "65";
        string returnFreightCharge = "54";
        string replacementFreightCharge = "65";
        string Stationname = "ZZZ - Web Services Test";
        string Customername = "46948TestCustomer";
        string DLSBill = "BillLading123";
        string CarrierName = "R & L Carriers";
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
        string Claimrep = "Alan Burton";
        string CustomerClaimRef = "cvdt 15 !@#$% :{_ ab";
        public int Claimsubmit(string UserType)
        {
            if (UserType != "External")
            {
                Click(attributeName_xpath, SubmitClaimButton_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, Stationname);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                if (UserType == "Sales")
                { SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, "VVV-36865-Primary-a"); }
                else
                { SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, Customername); }
                GlobalVariables.webDriver.WaitForPageLoad();
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

            Thread.Sleep(5000);

            Report.WriteLine("Shipper information is passed");
            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, ConsigneName);
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, ConsigneAddress);
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, ConsigneAddress2);
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, ConsigneZip);

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
            SendKeys(attributeName_id, customer_claim_ref_Id, CustomerClaimRef);
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
            Thread.Sleep(3000);
            SendKeys(attributeName_xpath, OriginFreightChargeVal_Xpath, originFreightCharge.ToString());
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            SendKeys(attributeName_id, ReturnFreightVal_Id, returnFreightCharge.ToString());
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            SendKeys(attributeName_xpath, ReplaceFreightVal_Xpath, replacementFreightCharge.ToString());
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
            FileUpload(attributeName_cssselector, AdditionalUploadButton_Css, newAddPath);
            Thread.Sleep(3000);
            File.Delete(newAddPath);
            Report.WriteLine("Documents are uploaded");
            SendKeys(attributeName_id, RemarksField_Id, Remark);
            Thread.Sleep(3000);
            Report.WriteLine("Submitting Claim Form");
            Click(attributeName_id, SubmitClaimButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            ClaimNumber = DBHelper.GetClaimNumber();
            return ClaimNumber;
        }
       
    }
}
