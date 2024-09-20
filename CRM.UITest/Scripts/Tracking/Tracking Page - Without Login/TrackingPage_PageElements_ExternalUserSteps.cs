using System;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CRM.UITest.Scripts.Tracking.Tracking_Page___Without_Login
{
    [Binding]
    public class TrackingPage_PageElements_ExternalUserSteps : ObjectRepository
    {
        [Given(@"I enter the '(.*)' in the search box")]
        public void GivenIEnterTheInTheSearchBox(string validReferenceNumber)
        {
            SendKeys(attributeName_id, TrackByReference_textbox_Id, validReferenceNumber);
            Report.WriteLine("Entered Valid reference number on CRM landing page");
            Click(attributeName_xpath, TrackByReference_Arrow_Xpath);
            Report.WriteLine("Clicked on Search arrow on CRM landing page");
            
        }

        [When(@"I arrive on Tracking details page")]
        public void WhenIArriveOnTrackingDetailsPage()
        {
            VerifyElementVisible(attributeName_xpath, TrackingPageHearder_xpath, "Tracking");
            Report.WriteLine("Navigated to Tracking page");
        }

        [When(@"I click on SignIn button")]
        public void WhenIClickOnSignInButton()
        {
            Click(attributeName_id, SignIn_Id);
            Report.WriteLine("Clicked on Sign In button in tracking page");
        }

        [Then(@"I will be displaying with SignIn, Download Template, Upload Template buttons and Reference Number search field")]
        public void ThenIWillBeDisplayingWithSignInDownloadTemplateUploadTemplateButtonsAndReferenceNumberSearchField()
        {
            VerifyElementVisible(attributeName_id, SignIn_Id, "Sign In");
            Report.WriteLine("Sign In button visible on Tracking page");
            VerifyElementVisible(attributeName_xpath, trackingdownloadbutton, "Download Template");
            Report.WriteLine("Download Template button visible on Tracking page");
            VerifyElementVisible(attributeName_id, TrackingPage_UploadTemplate_id, "Upload Template");
            Report.WriteLine("Upload Template button visible on Tracking page");
            VerifyElementVisible(attributeName_id, searchbox_id, "Enter Reference Number(s) Here");
            Report.WriteLine("Reference number search box visible on Tracking page");
        }

        [Then(@"I will be displaying with (.*) above reference number field")]
        public void ThenIWillBeDisplayingWithAboveReferenceNumberField(string verbiage)
        {
            string verbiageAboveRefNumberSearchUI = Gettext(attributeName_xpath, TrackingPage_Text_aboveReferenceSearch_xpath);
            Assert.AreEqual(verbiage, verbiageAboveRefNumberSearchUI);
            Report.WriteLine("Displaying the verbiage above reference number search box");
        }

        [Then(@"searchShipments should be renamed with (.*)")]
        public void ThenSearchShipmentsShouldBeRenamedWith(string filterResults)
        {
            Report.WriteLine("Search Shipments text not visible");
            string filterResultsTextUI = GetValue(attributeName_id, SearchShipment_Textbox_Id, "placeholder");
            Assert.AreEqual(filterResults, filterResultsTextUI);
            Report.WriteLine("Filter Results displaying in place of Search Shipments");
        }

        [Then(@"Filter Results Feature is placed in date and status filters bar")]
        public void ThenFilterResultsFeatureIsPlacedInDateAndStatusFiltersBar()
        {
            VerifyElementVisible(attributeName_xpath, TrackingPage_FilterResultsPlaced_Xpath, "Filter Results...");
            Report.WriteLine("Filter Results placed in date and status filters bar");
        }

        [Then(@"I will be navigating to CRM signin page")]
        public void ThenIWillBeNavigatingToCRMSigninPage()
        {
            VerifyElementVisible(attributeName_id, IDP_Username_Id, "Username");
            VerifyElementVisible(attributeName_id, IDP_Password_Id, "Password");
            VerifyElementVisible(attributeName_xpath, IDP_Login_Xpath, "SIGN IN");
            Report.WriteLine("I am displaying with Username, password and signin buttons");
        }
    }
}
