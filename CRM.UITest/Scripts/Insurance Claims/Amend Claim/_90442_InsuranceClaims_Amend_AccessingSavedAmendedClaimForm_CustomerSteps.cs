using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Amend_Claim
{
    [Binding]
    public class _90442_InsuranceClaims_Amend_AccessingSavedAmendedClaimForm_CustomerSteps : InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        int claimNumber = 0;

        [Given(@"I am a user who have access to Claims module '(.*)' '(.*)'")]
        public void GivenIAmAUserWhoHaveAccessToClaimsModule(string userName, string passWord)
        {
            string username = ConfigurationManager.AppSettings[userName].ToString();
            string password = ConfigurationManager.AppSettings[passWord].ToString();
            crmLogin.LoginToCRMApplication(username, password);
        }

        [Given(@"A claim was amended and resubmitted")]
        public void GivenAClaimWasAmendedAndResubmitted()
        {
            WhenAClaimWasAmendedAndResubmitted();
        }

        [Given(@"The new amended saved form link is present")]
        public void GivenTheNewAmendedSavedFormLinkIsPresent()
        {
            ThenIWillSeeALinkToTheAmendedSavedFormInTheDLSWClaimNumberColumn();
        }

        [When(@"A claim was amended and resubmitted")]
        public void WhenAClaimWasAmendedAndResubmitted()
        {
            Submit_AmendClaim ClaimVal = new Submit_AmendClaim();
            ClaimVal.ClaimSubmitAmend("External");
            ResubmitClaim ClaimNum = new ResubmitClaim();
            claimNumber = ClaimNum.GetResubmitClaimNumber();
        }

        [When(@"I hover over the original saved form link")]
        public void WhenIHoverOverTheOriginalSavedFormLink()
        {
            OnMouseOver(attributeName_classname, CliamListGridOriginalSavedFormLink_ClassName);
            Report.WriteLine("Mouse hovered on  original saved form link");
        }

        [When(@"I click on amended saved form link on claim list page")]
        public void WhenIClickOnAmendedSavedFormLinkOnClaimListPage()
        {
            Click(attributeName_classname, ClaimListGridAmendSavedFormLink_ClassName);
            Report.WriteLine("Clicked on amend saved form link on claim list page");
        }

        [Then(@"I will see a link to the amended saved form in the DLSW Claim number column")]
        public void ThenIWillSeeALinkToTheAmendedSavedFormInTheDLSWClaimNumberColumn()
        {
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, claimNumber.ToString());
            VerifyElementPresent(attributeName_classname, ClaimListGridAmendSavedFormLink_ClassName, "Amend Saved Link form");
            Report.WriteLine("Amend saved form link is present in the DLSW Claim number column");
        }

        [Then(@"The formatting of the amended saved form link is DLSW Claim number \+ \(A\)")]
        public void ThenTheFormattingOfTheAmendedSavedFormLinkIsDLSWClaimNumberA()
        {
            string getAmendSavedClaimLinkVal = Gettext(attributeName_classname, ClaimListGridAmendSavedFormLink_ClassName);
            Assert.AreEqual(claimNumber.ToString() + " (A)", getAmendSavedClaimLinkVal);
            Report.WriteLine("Amended saved form link is displayed in proper format");
        }

        [Then(@"I will See a popover message '(.*)' on mouser hover on amended saved form link")]
        public void ThenIWillSeeAPopoverMessageOnMouserHoverOnAmendedSavedFormLink(string amendSavedLink)
        {
            OnMouseOver(attributeName_classname, ClaimListGridAmendSavedFormLink_ClassName);
            string getAmendFormLinkPopUpMessage = Gettext(attributeName_classname, ClaimListClaimMouseHover_ClassName);
            Assert.AreEqual(getAmendFormLinkPopUpMessage, amendSavedLink);
            Report.WriteLine("View amended claim message is displayed  when user mouse hover on Amend saved form link");
        }

        [Then(@"I will see a popover message on the claim list page: '(.*)'")]
        public void ThenIWillSeeAPopoverMessageOnTheClaimListPage(string originalFormLink)
        {
            string getOriginalSavedFormLinlVal = Gettext(attributeName_classname, ClaimListClaimMouseHover_ClassName);
            Assert.AreEqual(getOriginalSavedFormLinlVal, originalFormLink);
            Report.WriteLine("View original claim message is diplayed when user mouse hover on original saved form link");
        }

        [Then(@"a pdf of the claim form will be displayed with the most recent saved updates")]
        public void ThenAPdfOfTheClaimFormWillBeDisplayedWithTheMostRecentSavedUpdates()
        {           
                string configURL = launchUrl;
                Report.WriteLine("Verifying the Pdf opened in new tab");
                string resultPagrURL = configURL + "InsuranceClaim/ViewClaimDetailsDocument?insuranceClaimNumber=" + claimNumber;
                WindowHandling(resultPagrURL);
                string ExpectedURL = GetURL();
                Assert.AreEqual(resultPagrURL, ExpectedURL);
                Report.WriteLine("pdf of the amended claim form with the most recent data updates is opened in a new tab");
            
        }
    }
}


