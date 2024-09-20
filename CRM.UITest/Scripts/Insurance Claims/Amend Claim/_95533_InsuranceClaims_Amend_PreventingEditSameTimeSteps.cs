using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Amend_Claim
{
    [Binding]
    public class _95533_InsuranceClaims_Amend_PreventingEditSameTimeSteps : Objects.InsuranceClaim
    {
        int Claimnumber;
        int originalstatus;
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        [Given(@"I clicked on the Resubmit Claim button on the Submit a Claim page")]
        public void GivenIClickedOnTheResubmitClaimButtonOnTheSubmitAClaimPage()
        {
            string claimNumberFromSubmitAClaimPage = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            string[] claimNumberFromUI = claimNumberFromSubmitAClaimPage.Split('#');
            string ClaimNumber = claimNumberFromUI[1].TrimEnd(')');
            Claimnumber = Convert.ToInt32(ClaimNumber);
            DBHelper.UpdateClaimStatusAsSubmitted(Claimnumber);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Submitting Claim Form");
            scrollElementIntoView(attributeName_id, Resubmit_button_Id);
            Click(attributeName_id, Resubmit_button_Id);
        }

        [Given(@"I am on the Error Notification Pop up")]
        public void GivenIAmOnTheErrorNotificationPopUp()
        {
            ThenIWillShowAModalPopupWithAMessageTheStatusOfThisClaimHasBeenChangedAndCannotBeAmendedAtThisTime_PleaseReturnToTheClaimsList_();
        }

        [When(@"the status of the claim has been changed,")]
        public void WhenTheStatusOfTheClaimHasBeenChanged()
        {
            Report.WriteLine("Verifyting the claim is in Submitted status from DB");
            int status = DBHelper.GetInsuranceStatus(Claimnumber);
            if (status == 4)
            {
                Report.WriteLine("The Claim is in Submitted status");
            }
            else
            {
                Report.WriteFailure("The Claim is not in Submitted status");
            }
        }

        [Then(@"I will show a modal popup with a message:The status of this claim has been changed and cannot be amended at this time\.Please return to the Claims List\.")]
        public void ThenIWillShowAModalPopupWithAMessageTheStatusOfThisClaimHasBeenChangedAndCannotBeAmendedAtThisTime_PleaseReturnToTheClaimsList_()
        {
            Report.WriteLine("Verifying the header of the pop-up modal");
            WaitForElementVisible(attributeName_xpath, "//h3[contains(text(),'Alert')]", "Alert");
            WaitForElementVisible(attributeName_xpath, "//h6[@id='submitClaimAlertText']", "The status of this claim has been changed and cannot be amended at this time. Please return to the Claims List.");
            Verifytext(attributeName_xpath, "//h6[@id='submitClaimAlertText']", "The status of this claim has been changed and cannot be amended at this time. Please return to the Claims List.");
        }

        [Then(@"I have the option to close the message")]
        public void ThenIHaveTheOptionToCloseTheMessage()
        {
            Verifytext(attributeName_id, SubmitaClaim_popup_closeButton_id, "Close");
            VerifyElementEnabled(attributeName_id, SubmitaClaim_popup_closeButton_id, "Close");
            Report.WriteLine("Reverting Back to Original Status");
            DBHelper.UpdatingOriginalstatusOfClaim(Claimnumber, originalstatus);
        }

        [Then(@"the Modal pop up will be closed\.")]
        public void ThenTheModalPopUpWillBeClosed_()
        {
            Report.WriteLine("Verifying the pop-up modal is closed");

            bool alertPopup = GlobalVariables.webDriver.FindElement(By.XPath("//h6[@id='submitClaimAlertText']")).Displayed;
            Assert.IsFalse(alertPopup);
            ScrollToTopElement(attributeName_xpath, "//p[contains(text(),'Amend a previously submitted motor carrier shortag')]");
            scrollPageup();
            VerifyElementVisible(attributeName_xpath, Submit_Claim_Page_Header_xpath, "Amend a previously submitted motor carrier shortage or damage claim");
            Report.WriteLine("Reverting Back to Original Status");
            DBHelper.UpdatingOriginalstatusOfClaim(Claimnumber, originalstatus);
        }

        [When(@"I click on close button,")]
        public void WhenIClickOnCloseButton()
        {
            Report.WriteLine("Clicking on Close Button");
            Click(attributeName_id, SubmitaClaim_popup_closeButton_id);
        }

        [Given(@"I clicked on the edit icon of a (.*) in Amend status")]
        public void GivenIClickedOnTheEditIconOfAInAmendStatus(int claim)
        {
            Report.WriteLine("Verifyting the claim is in Amended status from DB");
            int amendedstatus = DBHelper.GetInsuranceStatus(claim);
            originalstatus = amendedstatus;
            Claimnumber = claim;
            if (amendedstatus != 6)
            {
                Report.WriteLine("Changing the Status to Amend");
                DBHelper.updateClaimStatusAsAmend(claim);
                refreshBrowser();
            }
            else
            {
                Report.WriteLine("The Claim is in Amend status");
            }
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath);
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claim.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimListEditIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }



    }
}