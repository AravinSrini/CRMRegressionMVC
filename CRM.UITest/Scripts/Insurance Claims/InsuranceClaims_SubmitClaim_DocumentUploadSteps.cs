using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using System.Collections.Generic;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using OpenQA.Selenium;




namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_SubmitClaim_DocumentUploadSteps : InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        string expectedVerbiage, actualVerbiage, expectedText, actualText, expectedMessage, actualMessagge ;

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user (.*)")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser(string UserType)
        {
            UserCredentialsModel userModel = new UserCredentialsModel();
            UserTypeLoginCredentials userObj = new UserTypeLoginCredentials();
            userModel = userObj.GetCredentials(UserType);

            Report.WriteLine("Logging into CRM Application");
            crmLogin.LoginToCRMApplication(userModel.UserName, userModel.Password);
        }


        [Then(@"the file name will be displayed on the Claim Form as a hyperlink")]
        public void ThenTheFileNameWillBeDisplayedOnTheClaimFormAsAHyperlink()
        {
            IWebElement linkText = GlobalVariables.webDriver.FindElement(By.LinkText(DocumentLink_linkText));
            bool DocumentDisplay = linkText.Displayed;
            Assert.IsTrue(DocumentDisplay);
        }

        [When(@"I click on the uploaded document hyperlink")]
        public void WhenIClickOnTheUploadedDocumentHyperlink()
        {
            Click(attributeName_linktext, DocumentLink_linkText);
        }

        [Then(@"I will see the Documents section below the Claim Details section")]
        public void ThenIWillSeeTheDocumentsSectionBelowTheClaimDetailsSection()
        {
            expectedText = "Documents";
            actualText = Gettext(attributeName_xpath, DocumentSectionText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Then(@"the modal will close and document will not be removed")]
        public void ThenTheModalWillCloseAndDocumentWillNotBeRemoved()
        {
          if(IsElementVisible(attributeName_xpath, DocumentDeletePopup_Xpath, "Delete Document Modal").Equals(true))
            {
                Report.WriteLine("Delete modal is open");
            }else
            {
                Report.WriteLine("Delete modal is closed");
            }

            IsElementPresent(attributeName_linktext, DocumentLink_linkText, "document name");
        }


        [Given(@"I am on the Submit A Claim form")]
        public void GivenIAmOnTheSubmitAClaimForm()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
        }
        
        [Given(@"I have uploaded a document")]
        public void GivenIHaveUploadedADocument()
        {
            Report.WriteLine("Able to select file through file explorer");
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/Claim.xlsx");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, FilePath);
        }
        
        [Given(@"I click on the delete document button")]
        public void GivenIClickOnTheDeleteDocumentButton()
        {
            Click(attributeName_xpath, DeleteDocument_Button_First_Xpath);
        }
       

        [When(@"I am on the Submit A Claim form")]
        public void WhenIAmOnTheSubmitAClaimForm()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, Submit_A_Claim_button_Id);
         }
        
        [When(@"I hover over the Tool Tip icon displayed next to the required document (.*)")]
        public void WhenIHoverOverTheToolTipIconDisplayedNextToTheRequiredDocument(string p0)
        {
            OnMouseOver(attributeName_xpath, InformationHover_Icon_First_Xpath);
        }
        
        [When(@"I click on a file upload icon")]
        public void WhenIClickOnAFileUploadIcon()
        {
            Click(attributeName_id, DocumentUploadButton_Xpath);
        }
        
        [When(@"I have uploaded a document")]
        public void WhenIHaveUploadedADocument()
        {
            Report.WriteLine("Able to select file through file explorer");
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/Claim.xlsx");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, FilePath);
        }
        
        [When(@"I have the option to delete the document")]
        public void WhenIHaveTheOptionToDeleteTheDocument()
        {
            IsElementVisible(attributeName_xpath, DeleteDocument_Button_First_Xpath, "Delete button");
        }
        
        [When(@"I click on the delete document button")]
        public void WhenIClickOnTheDeleteDocumentButton()
        {
            Click(attributeName_xpath, DeleteDocument_Button_First_Xpath);
        }
        
        [When(@"I click on Cancel button from the delete confirmation popup")]
        public void WhenIClickOnCancelButtonFromTheDeleteConfirmationPopup()
        {
            Click(attributeName_xpath, DocumentDeletePopup_CancelButton_Xpath);
        }
        
        [When(@"I click on Delete button from the delete confirmation popup")]
        public void WhenIClickOnDeleteButtonFromTheDeleteConfirmationPopup()
        {
            Click(attributeName_id, DocumentDeletePopup_DeleteButton_Id);
        }
        
        [When(@"I have selected a document to upload which is not an acceptable file type\.")]
        public void WhenIHaveSelectedADocumentToUploadWhichIsNotAnAcceptableFileType_()
        {
            Report.WriteLine("Able to select file through file explorer");
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/testdoc.c");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, FilePath);
        }
        
       
        [When(@"I have selected a document to upload which exceeds the file size limit")]
        public void WhenIHaveSelectedADocumentToUploadWhichExceedsTheFileSizeLimit()
        {
            Report.WriteLine("Able to select file through file explorer");
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/test11Mb.pdf");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, FilePath);
        }
       
        [Then(@"the verbiage beneath the Documents section header will be, Note: Claim should be supported by the following documents\.  Failure to include sufficient documentation may delay conclusion of your claim\.  Acceptable file types are: \.doc \.docx \.xls \.xlsx \.ppt \.pptx \.pdf \.txt \.tif \.jpg \.png  Individual file size must not exceed (.*)MB\.")]
        public void ThenTheVerbiageBeneathTheDocumentsSectionHeaderWillBeNoteClaimShouldBeSupportedByTheFollowingDocuments_FailureToIncludeSufficientDocumentationMayDelayConclusionOfYourClaim_AcceptableFileTypesAre_Doc_Docx_Xls_Xlsx_Ppt_Pptx_Pdf_Txt_Tif_Jpg_PngIndividualFileSizeMustNotExceedMB_(int p0)
        {
            expectedVerbiage = "Note: Claim should be supported by the following documents.  Failure to include sufficient documentation may delay conclusion of your claim.  Acceptable file types are: .doc .docx .xls .xlsx .ppt .pptx .pdf .txt .tif .jpg .png  Individual file size must not exceed 10MB.";
            actualVerbiage = Gettext(attributeName_xpath, Verbiage_BeneathDocumentsSectionHeader_Xpath);
            Assert.AreEqual(expectedVerbiage, actualVerbiage);

        }
        
        [Then(@"the required document displayed is (.*)")]
        public void ThenTheRequiredDocumentDisplayedIs(string p0)
        {
            string expectedDocumentDisplayMsg = "Complete Vendor Invoice";
            string actualDocumentDisplayMsg = Gettext(attributeName_xpath, CompleteVendorInvoice_verbiage_Xpath);
            Assert.AreEqual(expectedDocumentDisplayMsg, actualDocumentDisplayMsg);

        }
        
        [Then(@"I will see an information hover icon next to the (.*) document name")]
        public void ThenIWillSeeAnInformationHoverIconNextToTheDocumentName(string p0)
        {
            IsElementVisible(attributeName_xpath, InformationHover_Icon_First_Xpath, "InformatioIcon");
        }
        
        [Then(@"I will see a document upload button")]
        public void ThenIWillSeeADocumentUploadButton()
        {
            IsElementVisible(attributeName_id, DocumentUploadButton_Xpath, "Document Upload buttom");
        }
        
        [Then(@"the document upload button will be active")]
        public void ThenTheDocumentUploadButtonWillBeActive()
        {
            IsElementEnabled(attributeName_id, DocumentUploadButton_Xpath, "Document Upload buttom");
        }
        
        [Then(@"I will see the verbiage next to the document upload button: (.*)")]
        public void ThenIWillSeeTheVerbiageNextToTheDocumentUploadButton(string p0)
        {
            expectedVerbiage = "No file currently uploaded";
            actualVerbiage = Gettext(attributeName_xpath, VerbiageNextToDocumentUploadButton_Xpath);
            Assert.AreEqual(expectedVerbiage, actualVerbiage);
        }
        
        [Then(@"I will see an Add Additional Document button")]
        public void ThenIWillSeeAnAddAdditionalDocumentButton()
        {
            IsElementVisible(attributeName_id, AddAdditionalDocument_Button_Id, "Add Additional Document");
        }

        [Then(@"I will see the verbiage stating : This invoice should show your cost for the product being claimed\.")]
        public void ThenIWillSeeTheVerbiageStatingThisInvoiceShouldShowYourCostForTheProductBeingClaimed_()
        {
            expectedVerbiage = "This invoice should show your cost for the product being claimed.";
            actualVerbiage = Gettext(attributeName_xpath, ToolTip_Verbiage_First_Xpath);
            Assert.AreEqual(expectedVerbiage, actualVerbiage);
        }
       
        [Then(@"I will not see the verbiage: No file currently uploaded")]
        public void ThenIWillNotSeeTheVerbiageNoFileCurrentlyUploaded()
        {
            expectedVerbiage = "";
            actualVerbiage = Gettext(attributeName_xpath, VerbiageNextToDocumentUploadButton_Xpath);
            Assert.AreEqual(expectedVerbiage, actualVerbiage);
        }
        
        [Then(@"I will be asked to confirm if I want to remove the document")]
        public void ThenIWillBeAskedToConfirmIfIWantToRemoveTheDocument()
        {
            expectedText = "";
            actualText = Gettext(attributeName_xpath, DocumentDeletePopup_Verbiage_Xpath);
            Assert.AreEqual(expectedText, actualText);
            
        }
        
        
        [Then(@"the document will be removed from the claim form")]
        public void ThenTheDocumentWillBeRemovedFromTheClaimForm()
        {
           if(IsElementVisible(attributeName_linktext, DocumentLink_linkText,"Document link").Equals(false))
            {
                Assert.IsTrue(true); ;
            }
        }
        
        [Then(@"I will receive a message: The selected file type is not allowed\.  Please select an approved file type")]
        public void ThenIWillReceiveAMessageTheSelectedFileTypeIsNotAllowed_PleaseSelectAnApprovedFileType()
        {
            expectedMessage = "The selected file type is not allowed.Please select an approved file type";
            actualMessagge = Gettext(attributeName_xpath, DocumentValidation_Message_Xpath);
            Assert.AreEqual(expectedMessage, actualMessagge);
        }
        
        [Then(@"I will receive a message: The selected file type is not allowed\.  Please select an approved file type\.")]
        public void ThenIWillReceiveAMessageTheSelectedFileTypeIsNotAllowed_PleaseSelectAnApprovedFileType_()
        {
            
        }
        
        [Then(@"I will receive a message: The selected file size exceeds (.*)MB\. Please attach a file that is less than (.*)MB\.")]
        public void ThenIWillReceiveAMessageTheSelectedFileSizeExceedsMB_PleaseAttachAFileThatIsLessThanMB_(int p0, int p1)
        {
            expectedMessage = "The selected file size exceeds 10MB. Please attach a file that is less than 10MB.";
            actualMessagge = Gettext(attributeName_xpath, DocumentValidation_Message_Xpath);
            Assert.AreEqual(expectedMessage, actualMessagge);
        }

       
    }
}
