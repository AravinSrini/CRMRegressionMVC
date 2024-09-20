using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Amend_Claim
{
    [Binding]
    public class InsuranceClaims_AmendClaimsDocumentSectionDeleteIconSteps : InsuranceClaim
    {
        string ExpFileName;
        public List<string> associated_documentsfromUI = new List<string>();
        public List<string> associated_documentsAfterDeletefromUI = new List<string>();

        [Given(@"I click on Delete Icon of any displayed document")]
        [When(@"I click on Delete Icon of any displayed document")]
        public void IClickOnTheDeleteIconOfAnyDisplayedDocument()
        {
            IList<IWebElement> documentsAddedToClaimFromUI = GlobalVariables.webDriver.FindElements(By.XPath(AdditionalUploadedFile_Xpath));
            for (int i = 0; i < documentsAddedToClaimFromUI.Count; i++)
            {
                Report.WriteLine("Document associated to Claim : " + documentsAddedToClaimFromUI[i].Text);
                associated_documentsfromUI.Add(documentsAddedToClaimFromUI[i].Text);

            }
            Report.WriteLine("Click on Delete Icon of any displayed document");
            Click(attributeName_xpath, "(.//a[contains(@class,'deleteSavedDocument')])[1]");
            Thread.Sleep(2000);
        }

        [Given(@"I will see a delete confirmation popup")]
        public void GivenIWillSeeADeleteConfirmationPopup()
        {
            Report.WriteLine("I will see a delete confirmation popup");
            WaitForElementVisible(attributeName_xpath, AmendClaim_DeleteDocIcon_Xpath, "Delete File");
            VerifyElementPresent(attributeName_xpath, AmendClaim_DeleteDocIcon_Xpath, "Delete File");
        }

        [When(@"I click on Cancel button of the modal popup")]
        public void WhenIClickOnCancelButtonOfTheModalPopup()
        {
            Report.WriteLine("I click on Cancel button of the modal popup");
            Click(attributeName_id, AmendClaim_DeleteModal_Cancel_Id);
            Thread.Sleep(2000);
        }

        [When(@"I click on Delete button of the modal popup")]
        public void WhenIClickOnDeleteButtonOfTheModalPopup()
        {
            Report.WriteLine("I click on Delete button of the modal popup");
            Click(attributeName_id, AmendClaim_DeleteModal_Delete_Id);
            Thread.Sleep(2000);
        }

        [Then(@"I will see a confirmation popup dialog with text - Are you sure you want to delete this file\?")]
        public void ThenIWillSeeAConfirmationPopupDialogWithText_AreYouSureYouWantToDeleteThisFile()
        {
            Report.WriteLine("I will see a confirmation popup dialog with text - Are you sure you want to delete this file?");
            string expectedText = "Are you sure you want to delete this file?";
            string actualText = Gettext(attributeName_xpath, DocumentDeletePopup_Verbiage_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Then(@"I will see Cancel and Delete buttons")]
        public void ThenIWillSeeCancelAndDeleteButtons()
        {
            Report.WriteLine("I will see Cancel and Delete buttons");
            VerifyElementVisible(attributeName_id, AmendClaim_DeleteModal_Cancel_Id, "Cancel");
            VerifyElementVisible(attributeName_id, AmendClaim_DeleteModal_Delete_Id, "Delete");
        }

        [Then(@"the delete popup will close")]
        public void ThenTheDeletePopupWillClose()
        {
            Report.WriteLine("the delete popup will close");
            VerifyElementNotVisible(attributeName_xpath, AmendClaim_DeleteDocIcon_Xpath, "Delete File");
        }

        [Then(@"document will not be deleted")]
        public void ThenDocumentWillNotBeDeleted()
        {
            Report.WriteLine("document will not be deleted");
            VerifyElementVisible(attributeName_xpath, AmendClaim_DocumentLink_Xpath, "Doc");
        }

        [Then(@"document will be deleted")]
        public void ThenDocumentWillBeDeleted()
        {
            Report.WriteLine("Document will be deleted");
            IList<IWebElement> listOfDocumentsAfterDeleteFromClaim = GlobalVariables.webDriver.FindElements(By.XPath(AdditionalUploadedFile_Xpath));
            for (int i = 0; i < listOfDocumentsAfterDeleteFromClaim.Count; i++)
            {
                Report.WriteLine("Document associated to Claim : " + listOfDocumentsAfterDeleteFromClaim[i].Text);
                associated_documentsAfterDeletefromUI.Add(listOfDocumentsAfterDeleteFromClaim[i].Text);
            }
            CollectionAssert.AreNotEqual(associated_documentsfromUI, associated_documentsAfterDeletefromUI);            
        }

        [Then(@"Document type should not be deleted")]
        public void ThenDocumentTypeShouldNotBeDeleted()
        {
            Report.WriteLine("Document type should not be deleted");
            VerifyElementVisible(attributeName_xpath, AmendClaim_DocumentName_Xpath, "DocType");
        }

        [Then(@"Upload Document icon should be active")]
        public void ThenUploadDocumentIconShouldBeActive()
        {
            Report.WriteLine("Upload Document icon should be active");
            VerifyElementEnabled(attributeName_xpath, AmendClaim_DocumentUpload_Xpath, "uploaddoc");
        }

        [Then(@"No File Currently uploaded should be displayed")]
        public void ThenNoFileCurrentlyUploadedShouldBeDisplayed()
        {
            Report.WriteLine("No File Currently uploaded should be displayed");
            VerifyElementEnabled(attributeName_xpath, AmendClaim_UploadDocumentIcon_Xpath, "uploaddoc");
        }

        [Then(@"User should be able to upload another document")]
        public void ThenUserShouldBeAbleToUploadAnotherDocument()
        {
            Report.WriteLine("User should be able to upload another document");
            ExpFileName = "Claim.xlsx";
            string ExpectedFileName = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/" + ExpFileName + " ");
            FileUpload(attributeName_xpath, AmendClaim_DocumentUpload_Xpath, ExpectedFileName);
            Thread.Sleep(2000);
        }
    }
}
