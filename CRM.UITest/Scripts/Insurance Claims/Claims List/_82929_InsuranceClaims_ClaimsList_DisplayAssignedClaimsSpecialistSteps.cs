using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class _82929_InsuranceClaims_ClaimsList_DisplayAssignedClaimsSpecialistSteps : InsuranceClaim
    {
        string Stationname = "ZZZ - Web Services Test";
        string Customername = "46948TestCustomer";
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
        string Claimrep = "Alan Burton";
        // string ClaimNumber = string.Empty;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string userName;
        string password;

        [Given(@"that I am a shp\.entry, shp\.entrynorates, shp\.inquiry, shp\.inquirynorates, sales, sales management, operations, station owner, or claims specialist (.*) user,")]
        public void GivenThatIAmAShp_EntryShp_EntrynoratesShp_InquiryShp_InquirynoratesSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser(string UserType)
        {
            if (UserType.Equals("External"))
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            }
            else if (UserType.Equals("Internal"))
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            }
            else if (UserType.Equals("ClaimSpecialist"))
            {
                userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            }
            else
            {

                userName = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
            }

            CrmLogin.LoginToCRMApplication(userName, password);
        }


        [Given(@"that I am a shp\.entry, shp\.entrynorates, shp\.inquiry, shp\.inquirynorates, sales, sales management, operations, station owner, or claims specialist user,")]
        public void GivenThatIAmAShp_EntryShp_EntrynoratesShp_InquiryShp_InquirynoratesSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }
        
        [Given(@"I am on the Submit Claim page,")]
        public void GivenIAmOnTheSubmitClaimPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigating to Submit Claim page");
            Click(attributeName_id, Submit_A_Claim_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"I have completed all required fields for (.*) user,")]
        public void GivenIHaveCompletedAllRequiredFieldsForUser(string UserType)
        {
            if (UserType != "External")
            {
                Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, Stationname);
                Thread.Sleep(5000);
                Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
                SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, Customername);
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
            //scrollpagedown();
            scrollElementIntoView(attributeName_classname, OriginFreightChargeOptionField_Class);
            SendKeys(attributeName_classname, OriginFreightChargeOptionField_Class, OriginFreightCharge);
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

        }
        
      
        
        [Given(@"I am a claim specialist user,")]
        public void GivenIAmAClaimSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            GivenIAmOnTheSubmitClaimPage();
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            Claim.Claimsubmit("ClaimSpecialist");
           // GivenIHaveCompletedAllRequiredFields();
            //WhenIClickOnTheSubmitClaimButton();
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am on the Claims List page,")]
        public void GivenIAmOnTheClaimsListPage()
        {
            Report.WriteLine("Verifying user is in Claim list page");
            IsElementVisible(attributeName_xpath, ClaimDetails_PageLebel_Xpath, "Claims List");
        }

        [When(@"I click On the Submit Claim button,")]
        public void WhenIClickOnTheSubmitClaimButton()
        {
            Report.WriteLine("Submitting Claim Form");
            Click(attributeName_id, SubmitClaimButton_Id);
        }

          
        [When(@"no DLSW Claim Specialist has been selected for the claim,")]
        public void WhenNoDLSWClaimSpecialistHasBeenSelectedForTheClaim()
        {
            ClaimNumber = DBHelper.GetClaimNumber();
            Report.WriteLine("Seraching the submitted Claim");
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimNumber.ToString());


        }
        
        [When(@"I arrive on the Claims List page,")]
        public void WhenIArriveOnTheClaimsListPage()
        {
            Report.WriteLine("Verifying user is in Claim list page");
            IsElementVisible(attributeName_xpath, ClaimDetails_PageLebel_Xpath, "Claims List");

        }
        
        [Then(@"the newly created claim will not have a DLSW Claim Specialist assigned\.")]
        public void ThenTheNewlyCreatedClaimWillNotHaveADLSWClaimSpecialistAssigned_()
        {
           
            WaitForElementVisible(attributeName_xpath, ClaimsList_Pageheading_Xpath, "Claims List");
            Click(attributeName_xpath, "//a[@id='loggedInUserName']");
            Click(attributeName_xpath, "//a[@title='Sign Out']");
            ClaimNumber = DBHelper.GetClaimNumber();
            Report.WriteLine("Login as Claim Specialist");
            //GivenIAmAClaimSpecialistUser();
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Seraching the submitted Claim");
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimNumber.ToString());
            Report.WriteLine("verifying the submitted Claim is show as blank under claimspecialist column");
            Verifytext(attributeName_xpath, ClaimListDLSWClaimSpecialist_Xpath,"");
                 


        }

        [Then(@"the DLSW Claim Specialist Field of the claim will be blank\.")]
        public void ThenTheDLSWClaimSpecialistFieldOfTheClaimWillBeBlank_()
        {
           
            Report.WriteLine("verifying the submitted Claim is show as blank under claimspecialist column");
            Verifytext(attributeName_xpath, ClaimListDLSWClaimSpecialist_Xpath, "");
        }
        
        [Then(@"I will see the name of the DLSW Claim Rep Displayed in the DLSW Claim Specialist field\.")]
        public void ThenIWillSeeTheNameOfTheDLSWClaimRepDisplayedInTheDLSWClaimSpecialistField_()
        {
            ClaimNumber = DBHelper.GetClaimNumber();
            //Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);
            Report.WriteLine("Seraching the submitted Claim");
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimNumber.ToString());
            Report.WriteLine("Navigating to Claim details page and adding claim rep");
            Click(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollPageup();
            Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath, Claimrep);
            Click(attributeName_xpath, SaveClaimDetailsButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollPageup();
            scrollPageup();
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying Claim Rep in claim list page");
            SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, ClaimNumber.ToString());
            Verifytext(attributeName_xpath, ClaimListDLSWClaimSpecialist_Xpath, Claimrep);
        }

       
    }
}
