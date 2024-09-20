using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class _90913_InsuranceClaims_AmendStatusFunctionalitySteps : InsuranceClaim
    {
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        [Given(@"a claim has been updated to the status Amend")]
        public void GivenAClaimHasBeenUpdatedToTheStatusAmend()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
        }

        [When(@"I arrive on Claims List page")]
        public void WhenIArriveOnClaimsListPage()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [Given(@"I clicked on the edit icon of a claim in Amend Claim status")]
        public void GivenIClickedOnTheEditIconOfAClaimInAmendClaimStatus()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
            Report.WriteLine("Click on Edit icon");
            crmWait.ClickAndWait(attributeName_xpath, ClaimListEditIcon_Xpath);
        }

        [When(@"I arrive on the Submit a Claim page")]
        public void WhenIArriveOnTheSubmitAClaimPage()
        {
            Verifytext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
            Report.WriteLine("User arrived on Submit a Claim page");
        }

        [Then(@"I will see Amend displayed as the status in the Status column")]
        public void ThenIWillSeeAmendDisplayedAsTheStatusInTheStatusColumn()
        {
            Report.WriteLine("User will be displayed with new Show Status option - Amend");
            VerifyElementPresent(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath, "Amend");
            string expectedStatus = Gettext(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            Assert.AreEqual(expectedStatus, "Amend");
        }

        [Then(@"the Amend status will have a unique status color code \#(.*)")]
        public void ThenTheAmendStatusWillHaveAUniqueStatusColorCode(int p0)
        {
            IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_AmendStatusColor_xpath));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var amendStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

            Assert.AreEqual("rgb(152, 0, 0)", amendStatusColor);
            Report.WriteLine("Amend status has unique status color code #980000");

        }

        [Then(@"I will see an Edit icon next to the claim number in the DLSW Claim \# column")]
        public void ThenIWillSeeAnEditIconNextToTheClaimNumberInTheDLSWClaimColumn()
        {
            VerifyElementPresent(attributeName_xpath, ClaimListEditIcon_Xpath, "Edit icon");
            Report.WriteLine("Edit icon present next to the DLSWClaimColumn ");

        }

        [Then(@"the Submit Claim button will be renamed Resubmit Claim")]
        public void ThenTheSubmitClaimButtonWillBeRenamedResubmitClaim()
        {

            VerifyElementPresent(attributeName_id, Resubmit_button_Id, "Resubmit Claim");
            string expectedStatus = Gettext(attributeName_id, Resubmit_button_Id);
            if (expectedStatus == "Resubmit Claim")
            {
                Report.WriteLine("Submit Claim button is renamed to ResubmitClaim");
            }
            else
            {
                Assert.Fail("Submit Claim button is not renamed to ResubmitClaim");
            }
        }


        [Given(@"a claim has been updated to the status other than Amend")]
        public void GivenAClaimHasBeenUpdatedToTheStatusOtherThanAmend()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I should not see an Edit icon next to the claim number in the DLSW Claim \# column")]
        public void WhenIShouldNotSeeAnEditIconNextToTheClaimNumberInTheDLSWClaimColumn()
        {
            Report.WriteLine("verify the Edit Icon when status is submitted");
            VerifyElementNotPresent(attributeName_xpath, ClaimListEditIcon_Xpath, "Edit icon");
            Report.WriteLine("Edit icon not present next to the DLSWClaimColumn ");

            Report.WriteLine("verify the Edit Icon when status is open");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath);
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_OpenCheckbox_xpath); //open
            VerifyElementNotPresent(attributeName_xpath, ClaimListEditIcon_Xpath, "Edit icon");
            Report.WriteLine("Edit icon not present next to the DLSWClaimColumn ");

            Report.WriteLine("verify the Edit Icon when status is paid");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_OpenCheckbox_xpath); //open
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_PaidCheckbox_xpath); //paid
            VerifyElementNotPresent(attributeName_xpath, ClaimListEditIcon_Xpath, "Edit icon");
            Report.WriteLine("Edit icon not present next to the DLSWClaimColumn ");

            Report.WriteLine("verify the Edit Icon when status is denied");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_PaidCheckbox_xpath); //paid
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath); //denied
            VerifyElementNotPresent(attributeName_xpath, ClaimListEditIcon_Xpath, "Edit icon");
            Report.WriteLine("Edit icon not present next to the DLSWClaimColumn ");

            Report.WriteLine("verify the Edit Icon when status is cancelled");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath); //denied
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_Cancelled_xpath); //cancelled
            VerifyElementNotPresent(attributeName_xpath, ClaimListEditIcon_Xpath, "Edit icon");
            Report.WriteLine("Edit icon not present next to the DLSWClaimColumn ");
        }
    
    }
}
