using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.DocRepo;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding, Scope(Tag = "90440")]
    public class InsuranceClaims_ClaimDetails_CreateClaimPacketForCarrierSubmissionSteps : InsuranceClaim
    {
        string claimNumber_ClaimsDetails_UI;
        List<string> associated_documentsfromDB = new List<string>();
        List<string> associated_documentsfromUI = new List<string>();
        public string downloadpath;

        [Given(@"I am an operations, sales, sales management or station owner user (.*),(.*)")]
        public void GivenIAmAnOperationsSalesSalesManagementOrStationOwnerUser(string UserName, string Password)
        {
            string username = ConfigurationManager.AppSettings[UserName].ToString();
            string password = ConfigurationManager.AppSettings[Password].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I am on the Claim List page")]
        public void GivenIAmOnTheClaimListPage()
        {
            Click(attributeName_xpath, ClaimIconExternalUser_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Claim List page displays");
        }

        [Given(@"I am on Claim Details page of a claim that was not previously amended (.*)")]
        public void GivenIAmOnClaimDetailsPageOfAClaimThatWasNotPreviouslyAmended(string claimNumber)
        {
            Click(attributeName_xpath, ClaimsListSearchField_xpath);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, claimNumber);
            Click(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Claim Details page of a non amended claim displays");
        }

        [Given(@"I am on the Claim Details page of a claim that was not previously amended")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasNotPreviouslyAmended()
        {
            Click(attributeName_xpath, ClaimsList_FirstVal_DLSWClaimNumber_stationUser_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Claim Details page of a non amended claim displays");
        }

        [Given(@"I am on the Claim Details page of a claim that was previously amended (.*)")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimThatWasPreviouslyAmended(string claimNumber)
        {
            Click(attributeName_xpath, ClaimsListSearchField_xpath);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, claimNumber);
            Click(attributeName_xpath, ClaimListClaimNumberHyperLink_AfterSearch_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Claim Details of the Amended Claim displays");
        }

        [Given(@"I am on Claim Details page of a claim that was previously amended")]
        public void GivenIAmOnClaimDetailsPageOfAClaimThatWasPreviouslyAmended()
        {
            Click(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath);
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListEditIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            string claimNumber = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            string[] _ClaimNumber = claimNumber.Split('#');
            claimNumber_ClaimsDetails_UI = _ClaimNumber[1].Replace(")", "").TrimStart();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, Resubmit_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimsListSearchField_xpath);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, claimNumber_ClaimsDetails_UI);
            Click(attributeName_xpath, ClaimListClaimNumberHyperLinkStationUsers_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Claim Details page of a non amended claim displays");
        }

        [When(@"I clicked on the Export button")]
        [Given(@"I clicked on the Export button")]
        public void IClickedOnTheExportButton()
        {
            Click(attributeName_id, DifferentTypeReportExportButton_id);
            Report.WriteLine("Clicked on the Export button from claim details page");
        }

        [When(@"I selected Claim Packet")]
        [Given(@"I selected Claim Packet")]
        public void ISelectedClaimPacket()
        {
            claimNumber_ClaimsDetails_UI = GetAttribute(attributeName_id, DlswClaimNumber_Textbox_ClaimDetailsPage_Id, "value");
            Click(attributeName_xpath, ClaimPacketFromExportButton_Xpath);
            Thread.Sleep(2000);
            Report.WriteLine("Selected Claim Packet from Claim Details page");
        }
        [When(@"I click on the Cancel button of Select Documents for Export modal")]
        public void WhenIClickOnTheCancelButtonOfSelectDocumentsForExportModal()
        {
            Report.WriteLine("Click on the Cancel button of Select Documents for Export modal");
            Click(attributeName_id, CancelButton_SelectDocumentsForExportModal_Id);
        }

        [When(@"I click on the Download button of Select Documents for Export modal")]
        public void WhenIClickOnTheDownloadButtonOfSelectDocumentsForExportModal()
        {
            Report.WriteLine("Click on the Download button of Select Documents for Export modal");
            Click(attributeName_id, DownloadButton_SelectDocumentsForExportModal_Id);
        }

        [When(@"I click anywhere outside the modal")]
        public void WhenIClickAnywhereOutsideTheModal()
        {
            Report.WriteLine("I click anywhere outside the modal");
            Click(attributeName_xpath, SelectDocumentsForExportModalOverlay_Xpath);
        }

        [Then(@"I will see Claim Packet new option")]
        public void ThenIWillSeeClaimPacketNewOption()
        {
            VerifyElementPresent(attributeName_xpath, ClaimPacketFromExportButton_Xpath, "Claim Packet Option");
            Report.WriteLine("Claim Packet option is present in the Export dropdown");
        }

        [Then(@"I will see the options listed in following order Claim Submitted By Customer, History Tab, Claim Packet and Payment Tab")]
        public void ThenIWillSeeTheOptionsListedInFollowingOrderClaimSubmittedByCustomerHistoryTabClaimPacketAndPaymentTab()
        {
            string[] expectedExportDropdownOptions = { "Claim Submitted By Customer", "History Tab", "Claim Packet", "Payment Tab" };

            Assert.AreEqual(expectedExportDropdownOptions[0], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[1]"));
            Assert.AreEqual(expectedExportDropdownOptions[1], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[2]"));
            Assert.AreEqual(expectedExportDropdownOptions[2], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[3]"));
            Assert.AreEqual(expectedExportDropdownOptions[3], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[4]"));
        }

        [Then(@"I will see the options listed in following order Claim Submitted By Customer, Claim Amended By Customer, History Tab, Claim Packet and Payment Tab")]
        public void ThenIWillSeeTheOptionsListedInFollowingOrderClaimSubmittedByCustomerClaimAmendedByCustomerHistoryTabClaimPacketAndPaymentTab()
        {
            string[] expectedExportDropdownOptions = { "Claim Submitted By Customer", "Claim Amended By Customer", "History Tab", "Claim Packet", "Payment Tab" };

            Assert.AreEqual(expectedExportDropdownOptions[0], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[1]"));
            Assert.AreEqual(expectedExportDropdownOptions[1], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[2]"));
            Assert.AreEqual(expectedExportDropdownOptions[2], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[3]"));
            Assert.AreEqual(expectedExportDropdownOptions[3], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[4]"));
            Assert.AreEqual(expectedExportDropdownOptions[4], Gettext(attributeName_xpath, "//ul[@id='export-list-profile']//li[5]"));
        }

        [Given(@"I will see a Select Documents for Export modal")]
        [Then(@"I will see a Select Documents for Export modal")]
        public void IWillSeeASelectDocumentsForExportModal()
        {
            Report.WriteLine("I will see a Select Documents for Export modal");
            VerifyElementVisible(attributeName_xpath, SelectDocumentsForExportModalHeader_Xpath, "Select Documents for Export");
            Verifytext(attributeName_xpath, SelectDocumentsForExportModalHeader_Xpath, "Select Documents for Export");
        }

        [Then(@"I will see the list of documents that have been saved to the claim include the Document type and Document Name\.extension in the modal")]
        public void ThenIWillSeeTheListOfDocumentsThatHaveBeenSavedToTheClaimIncludeTheDocumentTypeAndDocumentName_ExtensionInTheModal()
        {
            Report.WriteLine("I will see the list of documents that have been saved to the claim include the Document type and Document Name.extension in the modal");

            //verifying the documents associated to claim from DB
            List<FileInfo> FilenameListfrom_db = DBHelper.GetMetaDateFile("CLAIMNUMBER", claimNumber_ClaimsDetails_UI);

            for (int i = 0; i < FilenameListfrom_db.Count; i++)
            {
                string filename = FilenameListfrom_db[i].FileName;
                string extention1 = FilenameListfrom_db[i].FileExtension;
                string extention = "." + extention1.TrimEnd();
                string filewithextention = filename + extention;

                associated_documentsfromDB.Add(filewithextention);
            }

            //verifying same in Select Documents for Export modal
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DocumentswithExtensionList_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                Report.WriteLine("Associated Document is :" + associated_documents[i].Text);
                associated_documentsfromUI.Add(associated_documents[i].Text);
            }

            CollectionAssert.AreEqual(associated_documentsfromUI, associated_documentsfromDB);
        }

        [Then(@"Each document will have a check box, its selectable")]
        public void ThenEachDocumentWillHaveACheckBoxItsSelectable()
        {
            Report.WriteLine("Each document contains the check box");
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DocumentsList_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                VerifyElementPresent(attributeName_xpath, "(.//input[@class = 'chkdocuments'])[" + (i + 1) + "]", "checked");
            }
        }

        [Then(@"by default displayed documents will be auto-selected")]
        public void ThenByDefaultDisplayedDocumentsWillBeAuto_Selected()
        {
            Report.WriteLine("By default each displayed document will be auto selected");
            IList<IWebElement> associated_documents = GlobalVariables.webDriver.FindElements(By.XPath(DocumentsList_Xpath));
            for (int i = 0; i < associated_documents.Count; i++)
            {
                VerifyElementChecked(attributeName_xpath, "(.//input[@class = 'chkdocuments'])[" + (i + 1) + "]", "checked");
            }
        }

        [Then(@"I will see the verbiage- Note: Claim form PDF will be automatically included")]
        public void ThenIWillSeeTheVerbiage_NoteClaimFormPDFWillBeAutomaticallyIncluded()
        {
            VerifyElementPresent(attributeName_xpath, Note_SelectDocumentsForExportModal_Xpath, "Select Documents for Export footer verbiage");
            Report.WriteLine("Note: Claim form PDF will be automatically included verbiage displays");
        }

        [Then(@"I will see a Cancel, Download buttons")]
        public void ThenIWillSeeACancelDownloadButtons()
        {
            VerifyElementVisible(attributeName_id, CancelButton_SelectDocumentsForExportModal_Id, "Cancel");
            VerifyElementVisible(attributeName_id, DownloadButton_SelectDocumentsForExportModal_Id, "Download");
            Report.WriteLine("I will see a Cancel, Download buttons");
        }

        [Then(@"the modal will close")]
        public void ThenTheModalWillClose()
        {
            VerifyElementVisible(attributeName_id, DifferentTypeReportExportButton_id, "Export Button on Claim Details");
            Report.WriteLine("Select Documents for Export pop up modal is closed");
        }

        [Then(@"the modal should not close")]
        public void ThenTheModalShouldNotClose()
        {
            bool modal = IsElementPresent(attributeName_xpath, SelectDocumentsForExportModalHeader_Xpath, "Select Documents for Export");

            if (modal)
            {
                Report.WriteLine("Select Documents for Export pop up displays");
            }
            else
            {
                Report.WriteFailure("Select Documents for Export pop up Closed");
            }
        }

        [Then(@"I will not see a new option Claim Packet")]
        public void ThenIWillNotSeeANewOptionClaimPacket()
        {
            VerifyElementNotPresent(attributeName_xpath, ClaimPacketFromExportButton_Xpath, "Claim Packet Option");
            Report.WriteLine("Claim Packet option is NOT present in the Export dropdown");
        }

    }
}
