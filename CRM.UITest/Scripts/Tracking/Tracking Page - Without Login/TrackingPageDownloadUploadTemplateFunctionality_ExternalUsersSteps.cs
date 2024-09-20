using System.IO;
using System.Threading;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Tracking.Tracking_Page___Without_Login
{
    [Binding]
    public class TrackingPageDownloadUploadTemplateFunctionality_ExternalUsersSteps:ObjectRepository
    {
        [When(@"I click on the Download Template button")]
        public void WhenIClickOnTheDownloadTemplateButton()
        {
            Report.WriteLine("clicking on the Download Template button");
            Click(attributeName_xpath, trackingdownloadbutton);
        }
        
        [When(@"I click on the Upload Template button")]
        public void WhenIClickOnTheUploadTemplateButton()
        {
            Report.WriteLine("clicking on the Download Template button");
            Click(attributeName_id, TrackingPage_UploadTemplate_id);
        }
        
        [Then(@"Shipment Tracking template will be downloaded")]
        public void ThenShipmentTrackingTemplateWillBeDownloaded()
        {
            string downloadpath = GetDownloadedFilePath("ShipmentTrackingTemplate.xlsx");
            Thread.Sleep(10000);
            Assert.IsTrue(File.Exists(downloadpath));
            DeleteFilesFromFolder(downloadpath);

        }

        [Then(@"I should display Upload Shipments modal")]
        public void ThenIShouldDisplayUploadShipmentsModal()
        {
            Report.WriteLine("displaying Upload Shipments modal");
            WaitForElementVisible(attributeName_xpath, trackinguploadmodal, "uploadshipmentmodal");
            VerifyElementVisible(attributeName_xpath,trackinguploadmodal, "uploadshipmentmodal");
        }
        [Then(@"I should display (.*) on upload modal")]
        public void ThenIShouldDisplayOnUploadModal(string message)
        {
            Report.WriteLine("displying with message on upload modal");
            Verifytext(attributeName_xpath, trackinguploadmodalsubheader, message);
        }
        
        [Then(@"I should display the Select File button")]
        public void ThenIShouldDisplayTheSelectFileButton()
        {
            Report.WriteLine("displaying the Select File button");
            VerifyElementVisible(attributeName_xpath, trackingselectfile, "SelectFilebutton");
        }
        
        [Then(@"I should display the Cancel button")]
        public void ThenIShouldDisplayTheCancelButton()
        {
            Report.WriteLine("displaying the Cancel button");
            VerifyElementVisible(attributeName_xpath, trackingcancelbutton, "CancelButton");
        }
        
        [Then(@"I should display the Submit button")]
        public void ThenIShouldDisplayTheSubmitButton()
        {
            Report.WriteLine("displaying the Submit button");
            VerifyElementVisible(attributeName_xpath, trackingsubmitbutton, "SubmitButton");
        }
    }
}
