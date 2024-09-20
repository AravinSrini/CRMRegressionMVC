using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace CRM.UITest.Scripts.Tracking.Tracking_Page___Without_Login
{
    [Binding]
    public class TrackingPage_TrackingTemplateValidations_ExternalUsersSteps:ObjectRepository
    {
        [Given(@"I arrive on Tracking details page")]
        public void GivenIArriveOnTrackingDetailsPage()
        {
            VerifyElementVisible(attributeName_xpath, TrackingPageHearder_xpath, "Tracking");
            Report.WriteLine("Navigated to Tracking page");
        }
        
        [Given(@"I clicked on Upload Template button")]
        public void GivenIClickedOnUploadTemplateButton()
        {
            Click(attributeName_id, TrackingPage_UploadTemplate_id);
            Report.WriteLine("Clicked on Upload Template button");
            WaitForElementVisible(attributeName_xpath, trackinguploadmodalheader, "Upload Shipments");
            Report.WriteLine("Upload Shipments modal header will be displaying"); 
        }

        [When(@"I click on upload shipments modal Submit button")]
        public void WhenIClickOnUploadShipmentsModalSubmitButton()
        {
            Click(attributeName_xpath, trackingsubmitbutton);
            Report.WriteLine("Clicked on Submit button in Upload shipments modal");
        }

        [When(@"I click on Cancel button in upload shipments modal")]
        public void WhenIClickOnCancelButtonInUploadShipmentsModal()
        {
            Click(attributeName_xpath, trackingcancelbutton);
            Report.WriteLine("Clicked on Cancel button in Upload shipments modal");
        }
        
        [When(@"I click on Select file button in upload shipments modal")]
        public void WhenIClickOnSelectFileButtonInUploadShipmentsModal()
        {
            Click(attributeName_xpath, trackingselectfile);
            Report.WriteLine("Clicked on Select file button in upload shipments modal");
        }

        [When(@"I uploaded a file (.*)")]
        public void WhenIUploadedAFile(string filePath)
        {
            string actualFilePath = Path.GetFullPath(filePath);
            FileUpload(attributeName_xpath, trackingselectfile, actualFilePath);
            Report.WriteLine("Uploaded file from machine");
        }

        [Then(@"upload shipments modal will close")]
        public void ThenUploadShipmentsModalWillClose()
        {
            WaitForElementNotVisible(attributeName_xpath, trackinguploadmodalheader, "Upload Shipments");
            VerifyElementNotVisible(attributeName_xpath, trackinguploadmodalheader, "Upload Shipments");
            Report.WriteLine("Upload Shipments modal will not be displaying");
        }
        
        [Then(@"I will display with '(.*)'")]
        public void ThenIWillDisplayWith(string errorMessage)
        {
            string errorMessageUI = Gettext(attributeName_xpath, trackingselectfilerrormessage);
            Assert.AreEqual(errorMessage, errorMessageUI);
            Report.WriteLine("I will be displaying with error message for not selecting file");
        }

        [Then(@"selected file should be displayed")]
        public void ThenSelectedFileShouldBeDisplayed()
        {
            VerifyElementVisible(attributeName_cssselector, filesSelectionTxt_css, "file");
            Report.WriteLine("I will be displaying with selected file in upload shipments modal popup");
        }

        [When(@"I have uploaded the invalid file (.*)")]
        public void WhenIHaveUploadedTheInvalidFile(string invalidFilePath)
        {
            string actualFilePath = Path.GetFullPath(invalidFilePath);
            FileUpload(attributeName_xpath, trackingselectfile, actualFilePath);
            Report.WriteLine("Uploaded invalid file from machine");
        }

        [Then(@"I will see an error message (.*) in popup and file will not be uploaded")]
        public void ThenIWillSeeAnErrorMessageInPopupAndFileWillNotBeUploaded(string errorMessage)
        {
            WaitForElementVisible(attributeName_xpath, trackingselectfilerrormessage, errorMessage);
            VerifyElementVisible(attributeName_xpath, trackingselectfilerrormessage, errorMessage);
            Report.WriteLine("I am displaying with an error message of Invalid File type");
        }

        [Then(@"upload shipments modal will be opened")]
        public void ThenUploadShipmentsModalWillBeOpened()
        {
            VerifyElementVisible(attributeName_xpath, trackinguploadmodalheader, "Upload Shipments");            
            Report.WriteLine("Upload shipments modal will remain open");
        }

    }
}
