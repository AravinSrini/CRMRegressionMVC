using CRM.UITest.CommonMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;


namespace CRM.UITest.Scripts.Insurance_Claims.Amend_Claim
{
    [Binding]
    public class _95531_InsuranceClaims_AmendValidationSteps : Objects.InsuranceClaim
    {

        string FieldsErrorColorCode = "rgba(251, 236, 237, 1)";
        string originFreightCharge = "2";
        string returnFreightCharge = "3";
        string replacementFreightCharge = "4";
        string Stationname = "ZZZ - Web Services Test";
        string Customername = "ZZZ - GS Customer Test";
        string DLSBill = "DLSBill";
        string CarrierName = "R & L Carriers";
        string CarrierPRO = "CarrierPRO";
        string ShipperName = "ShipperName";
        string ShipperAddress = "ShipperAddress";
        string ShipperAdd2 = "ShipperAdd2";
        string ShipperZip = "90001";
        string ConsigneName = "Consigneename";
        string ConsigneAddress = "ConsigneAddress";
        string ConsigneAddress2 = "ConsigneAddress2";
        string ConsigneZip = "33126";
        string ClaimCompanyName = "CompanyName";
        string ClaimAddress = "ClaimAddress";
        string ClaimAddress2 = "ClaimAddress2";
        string ClaimCity = "ClaimCity";
        string ClaimContactName = "ContactName";
        string ClaimPhone = "84324249324";
        string ClaimEmail = "test@g.com";
        string ClaimWebsite = "www.testsite.com";
        string InsuredAmount = "2.00";
        string UnitVal = "2.00";
        string Quantity = "4";
        string Weight = "2.00";
        string ClaimDescription = "ClaimDescription";
        string ReturnDLS = "ReturnDLS123";
        string ReplaceDLS = "532756";
        string Remark = "Remarks";
        string ClaimZip = "32435";
        string UIDLSDate = null;
        string ExpectedClaimListpageURL = "http://dlsww-test.rrd.com/InsuranceClaim";
        string ExpectedEditClaimPageURLURL = "http://dlsww-test.rrd.com/InsuranceClaim/SubmitClaim";
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        IJavaScriptExecutor javascriptexecutor = (IJavaScriptExecutor)GlobalVariables.webDriver;


        [Given(@"I have Navigated to the Claim list page")]
        public void GivenIHaveNavigatedToTheClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }



        [Given(@"I have successfully created a Claim")]
        public void GivenIHaveSuccessfullyCreatedAClaim()
        {
            Click(attributeName_id, Submit_A_Claim_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Click(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_StatiodropdownValues_xpath, Stationname);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SelectDropdownValueFromList(attributeName_xpath, SubmitaClaim_CustomerdropdownValues_xpath, Customername);
            GlobalVariables.webDriver.WaitForPageLoad();
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
            Thread.Sleep(9000);

            SendKeys(attributeName_xpath, OriginFreightChargeVal_Xpath, originFreightCharge.ToString());
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            SendKeys(attributeName_classname, ReturnFreightVal_Class, returnFreightCharge.ToString());
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            SendKeys(attributeName_classname, ReplaceFreightVal_Class, replacementFreightCharge.ToString());
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

            Report.WriteLine("Documents are uploaded");
            SendKeys(attributeName_id, RemarksField_Id, Remark);
            Thread.Sleep(3000);
            Report.WriteLine("Submitting Claim Form");
            Click(attributeName_id, SubmitClaimButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I have forwarded the claim to Amend status")]
        public void GivenIHaveForwardedTheClaimToAmendStatus()
        {
            GlobalVariables.webDriver.Manage().Window.Maximize();

            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);

            Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNum_xpath);

            javascriptexecutor.ExecuteScript("window.scrollTo(document.body.scrollHeight, -250)");

            Thread.Sleep(5000);

            javascriptexecutor.ExecuteScript("window.scrollTo(document.body.scrollHeight, -250)");

            Click(attributeName_xpath, ClaimDetails_DropDown_Xpath);

            Click(attributeName_xpath, ClaimDetails_AmendDropDown_Xpath);


            Click(attributeName_id, SaveClaimDetailsButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            javascriptexecutor.ExecuteScript("window.scrollTo(document.body.scrollHeight, 0)");
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            LogoutofCRM();

        }

        public void LogoutofCRM()
        {
            Click(attributeName_xpath, ClaimDetails_Username_Xpath);

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(ClaimDetails_SignoutList_Xpath));
            int DropDownCount = DropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (DropDownList[i].Text == "Sign Out")
                {
                    DropDownList[i].Click();
                    break;
                }
            }
        }

        [Given(@"I have clicked on the Edit Icon for Claim in Amend Status")]
        public void GivenIHaveClickedOnTheEditIconForClaimInAmendStatus()
        {
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);

            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);

            Click(attributeName_xpath, ClaimDetails_AmendEdit_Xpath);

            GlobalVariables.webDriver.WaitForPageLoad();


        }



        [When(@"I click on Resubmit Claim without entering valid details in the Claim Details")]
        public void WhenIClickOnResubmitClaimWithoutEnteringValidDetailsInTheClaimDetails()
        {


            scrollpagedown();

            scrollpagedown();

            scrollpagedown();

            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);

            IWebElement InsuredAmount = GlobalVariables.webDriver.FindElement(By.Id(InsuredAmount_Id));
            InsuredAmount.Clear();
            IWebElement UnitValue = GlobalVariables.webDriver.FindElement(By.Id(UnitValue_Id));
            IWebElement Quantity = GlobalVariables.webDriver.FindElement(By.Id(Quantity_Id));
            IWebElement Weight_LBS = GlobalVariables.webDriver.FindElement(By.Id(Weight_LBS_Id));
            IWebElement ClaimedArticle_Description = GlobalVariables.webDriver.FindElement(By.Id(ClaimedArticle_Description_Id));

            UnitValue.Clear();
            Quantity.Clear();
            Weight_LBS.Clear();
            ClaimedArticle_Description.Clear();

            scrollpagedown();


            Click(attributeName_xpath, FreightChargeNo_Xpath);
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            Thread.Sleep(9000);
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(3000);

            scrollpagedown();

            Report.WriteLine("Submitting Claim Form");
            Click(attributeName_id, SubmitClaimButton_Id);

        }

        [Then(@"Empty mandatory fields in Claim Section should be highlighted in red")]
        public void ThenEmptyMandatoryFieldsInClaimSectionShouldBeHighlightedInRed()
        {


            Report.WriteLine("Validate Insured Value Amount Field Highlight");
            string InsuredValueAmountColorCode = GetCSSValue(attributeName_id, InsuredAmount_Id, "background-color");


            Assert.AreEqual(InsuredValueAmountColorCode, FieldsErrorColorCode);

            Report.WriteLine("Validate UnitValue Field Highlight");
            string UnitValueColorCode = GetCSSValue(attributeName_id, UnitValue_Id, "background-color");
            Assert.AreEqual(UnitValueColorCode, FieldsErrorColorCode);

            Report.WriteLine("Validate Quantity Field Highlight");
            string QuantityColorCode = GetCSSValue(attributeName_id, Quantity_Id, "background-color");
            Assert.AreEqual(QuantityColorCode, FieldsErrorColorCode);

            Report.WriteLine("Validate Weight_LBS_Id Field Highlight");
            string Weight_LBSColorCode = GetCSSValue(attributeName_id, Weight_LBS_Id, "background-color");
            Assert.AreEqual(Weight_LBSColorCode, FieldsErrorColorCode);

            Report.WriteLine("Validate ClaimedArticle_Description Field Highlight");
            string ClaimedArticle_Description = GetCSSValue(attributeName_id, ClaimedArticle_Description_Id, "background-color");
            Assert.AreEqual(ClaimedArticle_Description, FieldsErrorColorCode);

            scrollpagedown();
            Thread.Sleep(3000);

            Report.WriteLine("Validate OriginFreightCharge Field Highlight");
            string OriginFreightChargeColorCode = GetCSSValue(attributeName_xpath, OriginFreightChargeVal_Xpath, "background-color");
            Assert.AreEqual(OriginFreightChargeColorCode, FieldsErrorColorCode);


            Report.WriteLine("Validate ReturnFreightVal Field Highlight");
            string ReturnFreightValColorCode = GetCSSValue(attributeName_classname, ReturnFreightVal_Class, "background-color");
            Assert.AreEqual(FieldsErrorColorCode, ReturnFreightValColorCode);


            Report.WriteLine("Validate ReturnDLS Field Highlight");
            string ReturnDLSColorCode = GetCSSValue(attributeName_id, ReturnDLS_Id, "background-color");
            Assert.AreEqual(FieldsErrorColorCode, ReturnDLSColorCode);

            Report.WriteLine("Validate ReplaceFreightVal Field Highlight");
            string ReplaceFreightValColorCode = GetCSSValue(attributeName_classname, ReplaceFreightVal_Class, "background-color");
            Assert.AreEqual(FieldsErrorColorCode, ReplaceFreightValColorCode);

            Report.WriteLine("Validate ReplaceDLS Field Highlight");
            string ReplaceDLS = GetCSSValue(attributeName_id, ReplaceDLS_Id, "background-color");
            Assert.AreEqual(FieldsErrorColorCode, ReplaceDLS);


        }



        [Then(@"the control should be focused to the first mandatory empty field")]
        public void ThenTheControlShouldBeFocusedToTheFirstMandatoryEmptyField()
        {
            IWebElement element = GlobalVariables.webDriver.FindElement(By.Id(InsuredAmount_Id));
            IWebElement element1 = GlobalVariables.webDriver.SwitchTo().ActiveElement();


            if (element.Equals(element1))
            {
                Report.WriteLine("Control is moved to First Mandatory empty field");
            }
            else
            {
                Report.WriteFailure("Control is not moved to First Mandatory empty field");
            }
        }



        [Given(@"I have made changes in the Claim Details section of the page")]
        public void GivenIHaveMadeChangesInTheClaimDetailsSectionOfThePage()
        {



            scrollpagedown();

            scrollpagedown();

            scrollpagedown();

            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);

            IWebElement InsuredAmount = GlobalVariables.webDriver.FindElement(By.Id(InsuredAmount_Id));
            InsuredAmount.Clear();
            IWebElement UnitValue = GlobalVariables.webDriver.FindElement(By.Id(UnitValue_Id));
            IWebElement Quantity = GlobalVariables.webDriver.FindElement(By.Id(Quantity_Id));
            IWebElement Weight_LBS = GlobalVariables.webDriver.FindElement(By.Id(Weight_LBS_Id));
            IWebElement ClaimedArticle_Description = GlobalVariables.webDriver.FindElement(By.Id(ClaimedArticle_Description_Id));

            UnitValue.Clear();
            Quantity.Clear();
            Weight_LBS.Clear();
            ClaimedArticle_Description.Clear();


            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            Thread.Sleep(9000);

            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);

            Click(attributeName_xpath, ReplacementFreight_Xpath);
            Click(attributeName_xpath, ReplacementFreight_Xpath);

            Report.WriteLine("Claim details are been passed");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(3000);

            scrollpagedown();

          


        }



        [Given(@"I have made changes in the Document Details section of the page")]
        public void GivenIHaveMadeChangesInTheDocumentDetailsSectionOfThePage()
        {

            scrollpagedown();

            scrollpagedown();

            scrollpagedown();

            scrollpagedown();
            
            Click(attributeName_xpath, AddAdditionalDocument_Button_Id);
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, "Concealed Damage Notification");

            Thread.Sleep(3000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(3000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(3000);
            File.Copy(oldPath, newPath, true);
            FileUpload(attributeName_xpath, AdditionalUploadButton_Xpath, newPath);
            Thread.Sleep(3000);
            File.Delete(newPath);
                       
        }






        [Given(@"I click on Back to Claims List- Button without saving the entered details")]
        public void GivenIClickOnBackToClaimsList_ButtonWithoutSavingTheEnteredDetails()
        {
            javascriptexecutor.ExecuteScript("window.scrollTo(document.body.scrollHeight, 0)");
            Thread.Sleep(5000);
            Click(attributeName_id, "btn_backToClaimListPage");

        }



        [When(@"I click on Back to Claims List- Button without saving the entered details")]
        public void WhenIClickOnBackToClaimsList_ButtonWithoutSavingTheEnteredDetails()
        {
            javascriptexecutor.ExecuteScript("window.scrollTo(document.body.scrollHeight, 0)");
            Thread.Sleep(5000);
            Click(attributeName_id, "btn_backToClaimListPage");
        }




        [Then(@"I should get a (.*) message")]
        public void ThenIShouldGetAMessage(string ErrorMessage)
        {
            WaitForElementPresent(attributeName_xpath, ClaimDetails_BackbuttonErrorMsg_Xpath, "Popup Message");
            Thread.Sleep(3000);
            String ErrortextFromPage = Gettext(attributeName_xpath, ClaimDetails_BackbuttonErrorMsg_Xpath);
            Assert.AreEqual(ErrorMessage, ErrortextFromPage);
        }

        [Given(@"I should get a (.*) message")]
        public void GivenIShouldGetAMessage(string ErrorMessage)
        {
            WaitForElementPresent(attributeName_xpath, ClaimDetails_BackbuttonErrorMsg_Xpath, "Popup Message");
            Thread.Sleep(3000);
            String ErrortextFromPage = Gettext(attributeName_xpath, ClaimDetails_BackbuttonErrorMsg_Xpath);
            Assert.AreEqual(ErrorMessage, ErrortextFromPage);
        }

        [Given(@"it should have two options yes or no")]
        public void GivenItShouldHaveTwoOptionsYesOrNo()
        {
            if (IsElementPresent(attributeName_xpath, ClaimDetails_ErrorMsgYesButton_Xpath, "Yes Button"))
            {
                Report.WriteLine("Yes Button is Present");
            }
            else
            {
                Report.WriteFailure("Yes Button is not Present");
            }

            if (IsElementPresent(attributeName_xpath, ClaimDetails_ErrorMsgNoButton_Xpath, "No Button"))
            {
                Report.WriteLine("No Button is Present");
            }
            else
            {
                Report.WriteFailure("No Button is not Present");
            }

        }

        [Then(@"it should have two options yes or no")]
        public void ThenItShouldHaveTwoOptionsYesOrNo()
        {
            if (IsElementPresent(attributeName_xpath, ClaimDetails_ErrorMsgYesButton_Xpath, "Yes Button"))
            {
                Report.WriteLine("Yes Button is Present");
            }
            else
            {
                Report.WriteFailure("Yes Button is not Present");
            }

            if (IsElementPresent(attributeName_xpath, ClaimDetails_ErrorMsgNoButton_Xpath, "No Button"))
            {
                Report.WriteLine("No Button is Present");
            }
            else
            {
                Report.WriteFailure("No Button is not Present");
            }


        }


        [When(@"I click on the Yes options")]
        public void WhenIClickOnTheYesOptions()
        {
            Click(attributeName_xpath, ClaimDetails_ErrorMsgYesButton_Xpath);
        }


        [Then(@"I should be navigated back to the Claim List page")]
        public void ThenIShouldBeNavigatedBackToTheClaimListPage()
        {
            String ClaimListpageURL = GlobalVariables.webDriver.Url;

            if (ExpectedClaimListpageURL == ClaimListpageURL)
            {
                Report.WriteLine("Navigated to claim list page successfully");
            }
            else
            {
                Report.WriteFailure("Navigation to claim list page failed");

            }
        }




        [When(@"I click on the No options")]
        public void WhenIClickOnTheNoOptions()
        {
            Click(attributeName_xpath, ClaimDetails_ErrorMsgNoButton_Xpath);
        }



        [Then(@"It should stay on the Edit claim page")]
        public void ThenItShouldStayOnTheEditClaimPage()
        {
            String EditClaimPageURL = GlobalVariables.webDriver.Url;

            if (ExpectedEditClaimPageURLURL == EditClaimPageURL)
            {
                Report.WriteLine("Navigated to claim list page successfully");
            }
            else
            {
                Report.WriteFailure("Navigation to claim list page failed");

            }
        }



    }
}
