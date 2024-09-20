using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using Excel = Microsoft.Office.Interop.Excel;

namespace CRM.UITest.Scripts.IDP_Login
{
    [Binding]
    public class BuildLandingPage : ObjectRepository
    {
        [When(@"I am landing on DLS Worldwide homepage with RRD logo")]
        public void WhenIAmLandingOnDLSWorldwideHomepageWithRRDLogo()
        {
            Report.WriteLine("Landing on DLS Worldwide Legacy Homepage");
            //WaitForElementVisible(attributeName_cssselector, DLSWorldwideimage_css, "DLSWorldwide");
            VerifyElementPresent(attributeName_xpath, DashboardHeaderlogo_Xpath, "DLSWorldwide");
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_xpath, DashboardHeaderlogo_Xpath, "alt");
            Assert.AreEqual("DLS Worldwide", logohastext);
        }

        [Given(@"I am landing on DLS Worldwide homepage with RRD logo")]
        public void GivenIAmLandingOnDLSWorldwideHomepageWithRRDLogo()
        {
            Report.WriteLine("Landing on DLS Worldwide Legacy Homepage");
            //WaitForElementVisible(attributeName_cssselector, DLSWorldwideimage_css, "DLSWorldwide");
            VerifyElementPresent(attributeName_xpath, DashboardHeaderlogo_Xpath, "DLSWorldwide");
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_xpath, DashboardHeaderlogo_Xpath, "alt");
            Assert.AreEqual("DLS Worldwide", logohastext);
        }

        [When(@"I am landing on the signin page homepage with DLS Worldwide logo")]
        public void WhenIAmLandingOnTheSigninPageHomepageWithDLSWorldwideLogo()
        {
            Report.WriteLine("I am landing on the signin page homepage with DLS Worldwide logo");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            VerifyElementPresent(attributeName_xpath, HomepageHeaderlogo_Xpath, "RRDLogo");
        }

        [When(@"I must see the '(.*)' in the logo")]
        public void WhenIMustSeeTheInTheLogo(string DLSWorldwidetext)
        {
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_tagname, "img", "alt");
            Assert.AreEqual(DLSWorldwidetext, logohastext);
        }

        [Then(@"I must see the Sign In button must appear on the top right corner with the text '(.*)'")]
        public void ThenIMustSeeTheSignInButtonMustAppearOnTheTopRightCornerWithTheText(string SignIn)
        {
            Report.WriteLine("Verify that presence of Sign In button in DLS Worldwide Homepage");
            VerifyElementPresent(attributeName_id, NewSignIn_Id, SignIn);
            string SignIn_UI = Gettext(attributeName_id, NewSignIn_Id);
            Assert.AreEqual(SignIn, SignIn_UI);
        }

        [Then(@"I must see the '(.*)'")]
        public void ThenIMustSeeThe(string bodytext)
        {
            Report.WriteLine("Verify that text is loading in the body side of the Truck Image");
            VerifyElementPresent(attributeName_xpath, Bodytext_xpath, bodytext);
            string Bodytext_UI = Gettext(attributeName_xpath, Bodytext_xpath);
            Assert.AreEqual(bodytext, Bodytext_UI);
        }

        [Then(@"Truck image should loaded middle of the homepage")]
        public void ThenTruckImageShouldLoadedMiddleOfTheHomepage()
        {
            Report.WriteLine("Verify that Truck image loaded");
            bool Isloaded = IsElementVisible(attributeName_cssselector, TruckImage_css, "Truckload image");
            Assert.IsTrue(Isloaded);
        }

        [Then(@"I must see the Track info by Reference number heading '(.*)'")]
        public void ThenIMustSeeTheTrackInfoByReferenceNumberHeading(string TrackUpTo10ShipmentsByReferenceNumbertext)
        {
            Report.WriteLine("Verify that Tracking Shipments info by Reference Number heading");
            Thread.Sleep(3000);
            VerifyElementPresent(attributeName_xpath, TrackHeadingbyReferenceNo_xpath, TrackUpTo10ShipmentsByReferenceNumbertext);
            string TrackHeading_UI = Gettext(attributeName_xpath, TrackHeadingbyReferenceNo_xpath);
            Assert.AreEqual(TrackUpTo10ShipmentsByReferenceNumbertext, TrackHeading_UI);
        }

        [Then(@"I must see the Track info by Reference number paragraph '(.*)'")]
        public void ThenIMustSeeTheTrackInfoByReferenceNumberParagraph(string Paragraphtext)
        {
            Report.WriteLine("Verify that Tracking Shipments info by Reference Number paragraph");
            VerifyElementPresent(attributeName_xpath, TrackParagraphbyReferenceNo_xpath, Paragraphtext);
            string TrackParagraph_UI = Gettext(attributeName_xpath, TrackParagraphbyReferenceNo_xpath);
            Assert.AreEqual(Paragraphtext, TrackParagraph_UI);
        }

        [Then(@"I must see the search box button with text '(.*)'")]
        public void ThenIMustSeeTheSearchBoxButtonWithText(string EnterReferenceNumbertext)
        {
            Report.WriteLine("Verify that search box button");
            VerifyElementPresent(attributeName_id, searchbox_id, EnterReferenceNumbertext);
            string SeachBtnDefaulttext_UI = GetValue(attributeName_id, searchbox_id, "placeholder");
            Assert.AreEqual(EnterReferenceNumbertext, SeachBtnDefaulttext_UI);
        }

        [Then(@"I must able to enter '(.*)' into the search box and able to click the search button")]
        public void ThenIMustAbleToEnterIntoTheSearchBoxAndAbleToClickTheSearchButton(string ReferenceNumber)
        {
            Report.WriteLine("Verify that user can enter data in the search field");
            SendKeys(attributeName_id, searchbox_id, ReferenceNumber);
            Click(attributeName_xpath, searchbtn_xpath);
        }

        [Then(@"User  able to navigate to the '(.*)' module")]
        public void ThenUserAbleToNavigateToTheModule(string Tracking)
        {
            Report.WriteLine("User  able to navigate to the Tracking Icon");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Verifytext(attributeName_cssselector, TrackingpageTitle_css, Tracking);
        }

        [Then(@"I must see the Track info by shipments by file upload heading '(.*)'")]
        public void ThenIMustSeeTheTrackInfoByShipmentsByFileUploadHeading(string TrackMultipleShipmentsbyFileUploadtext)
        {
            Report.WriteLine("Verify that Tracking Shipments info by file upload heading");
            VerifyElementPresent(attributeName_xpath, TrackHeadingbyfileupload_xpath, TrackMultipleShipmentsbyFileUploadtext);
            string TrackHeadingbyFileupload_UI = Gettext(attributeName_xpath, TrackHeadingbyfileupload_xpath);
            Assert.AreEqual(TrackMultipleShipmentsbyFileUploadtext, TrackHeadingbyFileupload_UI);
        }

        [Then(@"I must see the Track info by shipments by file upload paragraph '(.*)'")]
        public void ThenIMustSeeTheTrackInfoByShipmentsByFileUploadParagraph(string Paragraphtext)
        {
            Report.WriteLine("Verify that Tracking Shipments info by file upload paragraph");
            VerifyElementPresent(attributeName_xpath, TrackParagraphbyfileupload_xpath, Paragraphtext);
            string TrackParagraphbyFileupload_UI = Gettext(attributeName_xpath, TrackParagraphbyfileupload_xpath);
            Assert.AreEqual(Paragraphtext, TrackParagraphbyFileupload_UI);
        }

        [Then(@"I must see the '(.*)' button and able to click the DownloadTemplate button")]
        public void ThenIMustSeeTheButtonAndAbleToClickTheDownloadTemplateButton(string DownloadTemplate)
        {
            Report.WriteLine("Verify that DownloadTemplate button in homepage");
            VerifyElementPresent(attributeName_id, DownloadTempalteBtn_id, DownloadTemplate);
            string DownloadTemplatetext_UI = Gettext(attributeName_id, DownloadTempalteBtn_id);
            Assert.AreEqual(DownloadTemplate, DownloadTemplatetext_UI);
            Click(attributeName_id, DownloadTempalteBtn_id);
        }

        [Then(@"I must see the '(.*)' button and able to click the Upload button")]
        public void ThenIMustSeeTheButtonAndAbleToClickTheUploadButton(string Upload)
        {
            Report.WriteLine("Verify that Upload button in homepage");
            VerifyElementPresent(attributeName_id, UploadBtn_id, Upload);
            string Uploadtext_UI = Gettext(attributeName_id, UploadBtn_id);
            Assert.AreEqual(Upload, Uploadtext_UI);
            Click(attributeName_id, UploadBtn_id);
        }

        [Then(@"I must see the RRD logo in the footer of the homepage")]
        public void ThenIMustSeeTheRRDLogoInTheFooterOfTheHomepage()
        {
            Report.WriteLine("User must see the RRD logo in the footer");
            VerifyElementPresent(attributeName_xpath, HomepageFooterlogo_Xpath, "Logo");
        }

        [Then(@"I must see Home '(.*)' link in the footer of the homepage")]
        public void ThenIMustSeeHomeLinkInTheFooterOfTheHomepage(string Home)
        {
            Report.WriteLine("User must see Home link in footer");
            Verifytext(attributeName_xpath, Home_xpath, Home);
        }

        [Then(@"I must see ContactUs '(.*)' link in the footer of the homepage")]
        public void ThenIMustSeeContactUsLinkInTheFooterOfTheHomepage(string ContactUs)
        {
            Report.WriteLine("User must see ContactUs link in footer");
            Verifytext(attributeName_xpath, ContactUs_xpath, ContactUs);
        }

        [Then(@"I must see PrivacyPolicy '(.*)' link in the footer of the homepage")]
        public void ThenIMustSeePrivacyPolicyLinkInTheFooterOfTheHomepage(string PrivacyPolicy)
        {
            Report.WriteLine("User must see PrivacyPolicy link in footer");
            Verifytext(attributeName_xpath, PrivacyPolicy_xpath, PrivacyPolicy);
        }

        [Then(@"I must see TemsofUse '(.*)' link in the footer of the homepage")]
        public void ThenIMustSeeTemsofUseLinkInTheFooterOfTheHomepage(string TemsofUse)
        {
            Report.WriteLine("User must see TemsofUse link in footer");
            Verifytext(attributeName_xpath, TemsofUse_xpath, TemsofUse);
        }

        [Then(@"I must see RRDInformation in the footer of the homepage")]
        public void ThenIMustSeeRRDInformationInTheFooterOfTheHomepage()
        {
            Report.WriteLine("User must see RRDInformation in the footer");
            VerifyElementPresent(attributeName_xpath, RRDInfo_xpath, "RRDInfo");
        }

        [Then(@"I click on the link available in the body of the homepage")]
        public void ThenIClickOnTheLinkAvailableInTheBodyOfTheHomepage()
        {
            Report.WriteLine("click on the Become a DLS Worldwide Partner today link");
            Click(attributeName_xpath, HomepagelinkPartner_xpath);
        }

        [Then(@"I must see the '(.*)' in the body of the homepage")]
        public void ThenIMustSeeTheInTheBodyOfTheHomepage(string linktext)
        {
            Report.WriteLine("Partner Link should be Visible in homepage");
            Verifytext(attributeName_xpath, HomepagelinkPartner_xpath, linktext);
        }

        [Then(@"I must land on the DLSW signup page '(.*)'")]
        public void ThenIMustLandOnTheDLSWSignupPage(string Title)
        {
            Report.WriteLine("I must land on the DLSW signup page");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Verifytext(attributeName_cssselector, signuppagetitle_css, Title);
        }

        [Then(@"I must see the subtitle '(.*)'")]
        public void ThenIMustSeeTheSubtitle(string SubTitle)
        {
            Report.WriteLine("I must see the subtitle");
            Verifytext(attributeName_cssselector, signuppagesubtitle_css, SubTitle);
        }

        [Then(@"I must see the Submit '(.*)' button")]
        public void ThenIMustSeeTheSubmitButton(string Submit)
        {
            Report.WriteLine("I must see the Submit button");
            Verifytext(attributeName_id, SubmitBtn_id, Submit);
        }

        [When(@"I click the Download Template button in the homepage")]
        public void WhenIClickTheDownloadTemplateButtonInTheHomepage()
        {
            Report.WriteLine("I click the Download Template button in the homepage");
            string FilePath = GetDownloadedFilePath("ShipmentTrackingTemplate.xlsx");
            DeleteFilesFromFolder(FilePath);
            Click(attributeName_id, DownloadTempalteBtn_id);
        }

        [Then(@"The file must be Downloaded with '(.*)' and open the sheet with the name '(.*)' and also with '(.*)'")]
        public void ThenTheFileMustBeDownloadedWithAndOpenTheSheetWithTheNameAndAlsoWith(string ShipmentTrackingTemplatefilename, string Sheetname, string alldata)
        {
            Report.WriteLine("The file must be Downloaded with ShipmentTrackingTemplate.xlsx file name");
            string FilePath = GetDownloadedFilePath(ShipmentTrackingTemplatefilename);
            
            List<string> data = new List<string>(alldata.Split(';'));

            string Expectedfirstrow = data[0];
            string Expectedsecondrowpart1 = data[1];
            string Expectedsecondrowpart2 = data[2];
            string Expectedthirdrow = data[3];
            string Expectedfourthrow = data[4];

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range xlrange;

            int xlRowCnt = 0;
            int xlColCnt = 0;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Open(FilePath);
            xlWorkSheet = xlWorkBook.Sheets[Sheetname];

            Excel.Range xlRange = xlWorkSheet.UsedRange;
            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;
            
                    //string firstcol = xlRange.Cells[i, j].value.tostring();
                    string Actualfirstrow = (string)(xlRange.Cells[1, 1] as Excel.Range).Value2;
                    string Actualsecondrow = (string)(xlRange.Cells[2, 1] as Excel.Range).Value2;
                    string Actualthirdrow = (string)(xlRange.Cells[3, 1] as Excel.Range).Value2;
                    string Actualfourthrow = (string)(xlRange.Cells[4, 1] as Excel.Range).Value2;

                    List<string> secondRow = new List<string>(Actualsecondrow.Split('\n'));
                    string Actualsecondrowpart1 = secondRow[0];
                    string Actualsecondrowpart2 = secondRow[1];

                    Assert.AreEqual(Actualfirstrow, Expectedfirstrow);
                    Assert.AreEqual(Actualsecondrowpart1, Expectedsecondrowpart1);
                    Assert.AreEqual(Actualsecondrowpart2, Expectedsecondrowpart2);
                    Assert.AreEqual(Actualthirdrow, Expectedthirdrow);
                    Assert.AreEqual(Actualfourthrow, Expectedfourthrow);
            
            xlrange = xlWorkSheet.UsedRange;

			xlWorkBook.Close(0);
			xlApp.Quit();
			DeleteFilesFromFolder(FilePath);
        }

        [When(@"I must see the search box button with text '(.*)'")]
        public void WhenIMustSeeTheSearchBoxButtonWithText(string EnterReferenceNumbertext)
        {
            Report.WriteLine("Verify that search box button");
            VerifyElementPresent(attributeName_id, searchbox_id, EnterReferenceNumbertext);
            string SeachBtnDefaulttext_UI = GetValue(attributeName_id, searchbox_id, "placeholder");
            Assert.AreEqual(EnterReferenceNumbertext, SeachBtnDefaulttext_UI);
        }

        [When(@"I enter '(.*)' into the search box and able to click the search button")]
        public void WhenIEnterIntoTheSearchBoxAndAbleToClickTheSearchButton(string InvalidReferenceNumber)
        {
            Report.WriteLine("Enter invalid reference number in the search text box");
            SendKeys(attributeName_id, searchbox_id, InvalidReferenceNumber);
            Click(attributeName_xpath, searchbtn_xpath);
        }

        [Then(@"I must navigate to the Tracking Details '(.*)' page")]
        public void ThenIMustNavigateToTheTrackingDetailsPage(string Tracking)
        {
            Report.WriteLine("User must to navigate to the Tracking module");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Verifytext(attributeName_cssselector, TrackingpageTitle_css, Tracking);
        }

        [Then(@"I must see the '(.*)' saying no data found for reference number")]
        public void ThenIMustSeeTheSayingNoDataFoundForReferenceNumber(string errormessage)
        {
            Report.WriteLine("I must see the error message saying that no data found for reference number");
            WaitForElementVisible(attributeName_xpath, searchErrormessage_xpath, errormessage);
            Verifytext(attributeName_xpath, searchErrorpopup_xpath, "Error");
            Verifytext(attributeName_xpath, searchErrormessage_xpath, errormessage);
            Verifytext(attributeName_xpath, CloseBtnInSearchErrorpopup_xpath, "Close");
        }

        [Then(@"I click on the close button in the error pop up")]
        public void ThenIClickOnTheCloseButtonInTheErrorPopUp()
        {
            Report.WriteLine("click on the close button in the error pop up");
            Click(attributeName_xpath, CloseBtnInSearchErrorpopup_xpath);
        }

        [Then(@"I should not see any results in the results page")]
        public void ThenIShouldNotSeeAnyResultsInTheResultsPage()
        {
            Report.WriteLine("should not see any results in the results page");
            VerifyElementNotVisible(attributeName_xpath, TrackingResults_xpath, "Results");
        }

        [When(@"I click on the Upload button in the homepage")]
        public void WhenIClickOnTheUploadButtonInTheHomepage()
        {
            Report.WriteLine("click on the Upload button in the homepage");
            Click(attributeName_id, UploadBtn_id);
        }

        [Then(@"I can able to see the '(.*)' and '(.*)' in the modal")]
        public void ThenICanAbleToSeeTheAndInTheModal(string UploadShipmentsTitle, string subtitle)
        {
            Report.WriteLine("Able to see Upload Shipment modal");
            WaitForElementVisible(attributeName_xpath, UploadShipmentpopupTitle_xpath, UploadShipmentsTitle);
            Verifytext(attributeName_xpath, UploadShipmentpopupTitle_xpath, UploadShipmentsTitle);
            Verifytext(attributeName_xpath, UploadShipmentpopupSubTitle_xpath, subtitle);
        }

        [Then(@"Upload Shipment modal should have the option to select a file '(.*)' button and '(.*)', '(.*)' buttons")]
        public void ThenUploadShipmentModalShouldHaveTheOptionToSelectAFileButtonAndButtons(string SelectFile, string Cancel, string Submit)
        {
            Report.WriteLine("Upload Shipment modal should have the option to select a file, Cacel and Submit buttons");
            Verifytext(attributeName_xpath, SelectFileUploadpopup_xpath, SelectFile);
            Verifytext(attributeName_cssselector, filesSelectionTxt_css, "no file selected");
            Verifytext(attributeName_id, CalcelBtnUploadpopup_id, Cancel);
            VerifyElementPresent(attributeName_id, SubmitBtnUploadpopup_id, Submit);
            string Submit_UI = GetValue(attributeName_id, SubmitBtnUploadpopup_id, "value");
            Assert.AreEqual(Submit, Submit_UI);
        }

        [When(@"I can able to see the '(.*)' modal")]
        public void WhenICanAbleToSeeTheModal(string UploadShipments)
        {
            Report.WriteLine("Able to see Upload Shipment modal");
            WaitForElementVisible(attributeName_xpath, UploadShipmentpopupTitle_xpath, UploadShipments);
            Verifytext(attributeName_xpath, UploadShipmentpopupTitle_xpath, UploadShipments);
        }

        [When(@"I click select file button in the Upload Shipment modal")]
        public void WhenIClickSelectFileButtonInTheUploadShipmentModal()
        {
            Report.WriteLine("click select file button in the Upload Shipment modal");
            Click(attributeName_xpath, SelectFileUploadpopup_xpath);
            Thread.Sleep(300);
        }

        [Then(@"User can able to select a valid file through file explorer")]
        public void ThenUserCanAbleToSelectAValidFileThroughFileExplorer()
        {
            Report.WriteLine("Able to select file through file explorer");
            //string FilePath = @"C:\Users\alekya.avula\Downloads\ShipmentTrackingTemplate.xlsx";
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_trackingupload/Emptyfile/ShipmentTrackingTemplate.xlsx");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, SelectFileUploadpopup_xpath, FilePath);
        }

        [Then(@"User can able to see the selected '(.*)' name in the Upload Shipments modal")]
        public void ThenUserCanAbleToSeeTheSelectedNameInTheUploadShipmentsModal(string filename)
        {
            Report.WriteLine("Able to see the selected file name in the popup");
            WaitForElementVisible(attributeName_cssselector, filesSelectionTxt_css, filename);
            Verifytext(attributeName_cssselector, filesSelectionTxt_css, filename);
        }

        [When(@"I click the Cancel button in the Upload Shipment modal")]
        public void WhenIClickTheCancelButtonInTheUploadShipmentModal()
        {
            Report.WriteLine("click the Cancel button in the Upload Shipment modal");
            Click(attributeName_id, CalcelBtnUploadpopup_id);
            WaitForElementNotVisible(attributeName_xpath, UploadShipmentpopupTitle_xpath, "UploadShipments");
        }

        [Then(@"User should not able to see the '(.*)'modal")]
        public void ThenUserShouldNotAbleToSeeTheModal(string UploadShipments)
        {
            Report.WriteLine("should not see the Upload shipment modal");
            VerifyElementNotVisible(attributeName_xpath, UploadShipmentpopupTitle_xpath, UploadShipments);
        }

        [When(@"I click on the Submit button in the Upload Shipment modal")]
        public void WhenIClickOnTheSubmitButtonInTheUploadShipmentModal()
        {
            Report.WriteLine("click on the Submit button in the Upload Shipment modal");
            Click(attributeName_id, SubmitBtnUploadpopup_id);
        }

        [Then(@"I must see the '(.*)' in the Upload Shipment modal")]
        public void ThenIMustSeeTheInTheUploadShipmentModal(string errormessage)
        {
            Report.WriteLine("Musr see the error message in the Upload Shipment modal");
            Verifytext(attributeName_id, errormsginUploadpopup_id, errormessage);
        }

        [When(@"User select a Invalid file through file explorer")]
        public void WhenUserSelectAInvalidFileThroughFileExplorer()
        {
            Report.WriteLine("Select invalid file name through file explorer");
            string FilePath = Path.GetFullPath("../../Scripts/TestData/Testfiles_trackingupload/Invalidfilename/TrackingDetails.xls");
            Thread.Sleep(3000);
            FileUpload(attributeName_xpath, SelectFileUploadpopup_xpath, FilePath);
            Thread.Sleep(3000);
        }

        [Then(@"User must see the invalid input file pop up '(.*)', '(.*)', '(.*)' button")]
        public void ThenUserMustSeeTheInvalidInputFilePopUpButton(string popuptitle, string invalidinputerrormessage, string Close)
        {
            Report.WriteLine("Must see the invalid input message in error popup");
            WaitForElementVisible(attributeName_xpath, InvalidpopupErrormessage_xpath, invalidinputerrormessage);
            Verifytext(attributeName_xpath, Invalidpopuptitle_xpath, popuptitle);
            Verifytext(attributeName_xpath, InvalidpopupErrormessage_xpath, invalidinputerrormessage);
            Verifytext(attributeName_xpath, InvalidpopupClosebtn_xpath, Close);
        }

    }
}
