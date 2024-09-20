using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _40365___Insurance_Claims___Documents_Tab___DeleteSteps : InsuranceClaim
    {

        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        public string claimNumber= "2018000281";
        public int latestClaimNumber;
        public string firstDocumentName;
        public string station_Username;

        [Given(@"I am a Claims Specialist User")]
        public void GivenIAmAClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"I clicked on the hyperlink of any displayed claim on the Claim list")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimOnTheClaimList()
        {
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            int row = GetCount(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr");
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                latestClaimNumber = DBHelper.GetClaimNumber();
                string claimNumber = Convert.ToString(latestClaimNumber);
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, claimNumber);
                Click(attributeName_xpath, ClaimListClaimNumberHyperLink_xpath);

            }
            else
            {
                Report.WriteLine("No ClaimsPresent in the Claim List page");
            }
        }


        [Given(@"I clicked on the hyperlink of any displayed claim on the Claim list for station users")]
        public void GivenIClickedOnTheHyperlinkOfAnyDisplayedClaimOnTheClaimListForStationUsers()
        {
            Click(attributeName_id, ClaimsIcon_Id);

            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            int row = GetCount(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr");
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
                latestClaimNumber = DBHelper.GetClaimNumberByUsername(station_Username);
                string claimNumber = Convert.ToString(latestClaimNumber);
                SendKeys(attributeName_xpath, ClaimListSearchTextBox_xpath, claimNumber);
                Click(attributeName_xpath, ClaimListClaimNumberHyperLinkStationUsers_xpath);

            }
            else
            {
                Report.WriteLine("No ClaimsPresent in the Claim List page");
            }
        }



        [Given(@"I arrive on the Claim Details page of the selected claim")]
        public void GivenIArriveOnTheClaimDetailsPageOfTheSelectedClaim()
        {
            Verifytext(attributeName_xpath, ClaimDetails_DetailsTab_xpath, "DETAILS");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked on the Document Tab")]
        public void GivenIClickedOnTheDocumentTab()
        {
            Click(attributeName_xpath, ClaimDetails_Documenttab_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I click on the Delete Icon of any displayed document")]
        public void WhenIClickOnTheDeleteIconOfAnyDisplayedDocument()
        {
            WaitForElementVisible(attributeName_xpath, ClaimDetails_DeleteDocumentIcon_xpath, "DeleteIcon");
            Click(attributeName_xpath, ClaimDetails_DeleteDocumentIcon_xpath);
        }

        [Then(@"I will see a delete document pop up message as (.*)")]
        public void ThenIWillSeeADeleteDocumentPopUpMessageAs(string DeletePopupMessage)
        {
            WaitForElementVisible(attributeName_xpath, ClaimDetails_DeleteModalTitle_xpath, "Delete");
            string ActualDeletePopupMessage = "Are you sure you want to delete this file?";
            string expectedDeletePopupMessage = Gettext(attributeName_xpath, ClaimDetails_DeleteDocumentModalMessage_xpath);
            Assert.AreEqual(expectedDeletePopupMessage, ActualDeletePopupMessage);
        }

        [Then(@"I will see a (.*) button")]
        public void ThenIWillSeeAButton(string Cancel)
        {
            Verifytext(attributeName_xpath, ClaimDetails_DeleteDocModal_CancelButton_xpath, "Cancel");
        }

        [Then(@"I will see a (.*) button on the delete document pop up")]
        public void ThenIWillSeeAButtonOnTheDeleteDocumentPopUp(string Delete)
        {
            Verifytext(attributeName_xpath, ClaimDetails_DeleteDocModal_DeleteButton_xpath, "Delete");
        }

        [Given(@"I click on the Delete Icon of any displayed document")]
        public void GivenIClickOnTheDeleteIconOfAnyDisplayedDocument()
        {
            WaitForElementVisible(attributeName_xpath, ClaimDetails_DeleteDocumentIcon_xpath, "DeleteIcon");
            firstDocumentName = Gettext(attributeName_xpath, ClaimDetails_FirstDocumentname_xpath);
            Click(attributeName_xpath, ClaimDetails_DeleteDocumentIcon_xpath);
           
        }

        [When(@"I click on the Cancel button on the delete document pop up")]
        public void WhenIClickOnTheCancelButtonOnTheDeleteDocumentPopUp()
        {
            WaitForElementVisible(attributeName_xpath, ClaimDetails_DeleteModalTitle_xpath, "Delete");
            Click(attributeName_xpath, ClaimDetails_DeleteDocModal_CancelButton_xpath);
        }

        [Then(@"the Delete modal should close")]
        public void ThenTheDeleteModalShouldClose()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetails_Documenttab_xpath, "Documenttab");
            
        }

        [Then(@"the Document should remain attached to the document tab")]
        public void ThenTheDocumentShouldRemainAttachedToTheDocumentTab()
        {
            scrollElementIntoView(attributeName_xpath, ClaimDetails_Documenttab_xpath);
            string notDeletedFile = Gettext(attributeName_xpath, ClaimDetails_FirstDocumentname_xpath);
            Assert.AreEqual(notDeletedFile, firstDocumentName);
        }

        [When(@"I click on the Delete button on the delete document pop up")]
        public void WhenIClickOnTheDeleteButtonOnTheDeleteDocumentPopUp()
        {
            Click(attributeName_xpath, ClaimDetails_DeleteDocModal_DeleteButton_xpath);
        }


        [Then(@"the Document should be removed from the Document tab list")]
        public void ThenTheDocumentShouldBeRemovedFromTheDocumentTabList()
        {
            Verifytext(attributeName_xpath, ClaimDetails_NoFileCurrentlyUploaded_xpath, "No file currently uploaded");
        }

        [Given(@"I am a sales, sales management, operations, or station owner")]
        public void GivenIAmASalesSalesManagementOperationsOrStationOwner()
        {
            station_Username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            crmLogin.LoginToCRMApplication(station_Username, password);
        }

        //[When(@"I click on the Document tab")]
        //public void WhenIClickOnTheDocumentTab()
        //{
        //    Click(attributeName_xpath, ClaimDetails_Documenttab_xpath);
        //}


        [Then(@"I should not see the Delete Icon for the document associated with the selected claim")]
        public void ThenIShouldNotSeeTheDeleteIconForTheDocumentAssociatedWithTheSelectedClaim()
        {
            VerifyElementNotPresent(attributeName_xpath, ClaimDetails_DeleteDocModal_DeleteButton_xpath, "DeleteIcon Not Visible");
        }
















    }
}
