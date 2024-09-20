using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Globalization;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_HistoryTab_StatusAndSystemCommentsSteps : Objects.InsuranceClaim
    {
        string recentSubmittedClaim = null;
        InsuranceClaimHistory claimHistory = null;
        string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();

        [Given(@"I am on Claim Detailspage of new submitted claim")]
        public void GivenIAmOnClaimDetailspageOfNewSubmittedClaim()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            recentSubmittedClaim = DBHelper.GetClaimNumber().ToString();
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            DefineTimeOut(1000);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, recentSubmittedClaim);
            Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Report.WriteLine("I am on Claim Details page of new submitted claim");
        }

        [When(@"a new claim is submitted")]
        public void WhenANewClaimIsSubmitted()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            recentSubmittedClaim = DBHelper.GetClaimNumberByUsername(username).ToString();
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            DefineTimeOut(1000);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, recentSubmittedClaim);
            Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Selected a new claim");
        }

        [When(@"the Carrier Ack (.*) field of the Claim Details tab is edited")]
        public void WhenTheCarrierAckFieldOfTheClaimDetailsTabIsEdited(string CurrentValue)
        {
            if (CurrentValue == "Yes")
            {
                scrollpagedown();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
                Thread.Sleep(1000);
                SelectDropdownValueFromList(attributeName_xpath, CarrierOSDActions_CarrierAckValues_Xpath, "Y");
                scrollElementIntoView(attributeName_id, SaveClaimDetailsButton_Id);
                scrollPageup();
                Click(attributeName_id, SaveClaimDetailsButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("The carrier Ack field of the claim details tab is edited");
            }
            else
            {
                scrollpagedown();
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, CarrierOSDActions_CarrierAck_Xpath);
                Thread.Sleep(1000);
                SelectDropdownValueFromList(attributeName_xpath, CarrierOSDActions_CarrierAckValues_Xpath, "N");
                scrollElementIntoView(attributeName_id, SaveClaimDetailsButton_Id);
                scrollPageup();
                Click(attributeName_id, SaveClaimDetailsButton_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Report.WriteLine("The carrier Ack field of the claim details tab is edited");
            }

        }

        [Then(@"a comment will be created")]
        public void ThenACommentWillBeCreated()
        {
            Report.WriteLine("Comment will be created");
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, LatestCommentValue_Xpath, "comment");
            string createdComment = Gettext(attributeName_xpath, LatestCommentValue_Xpath);
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            Assert.AreEqual(createdComment, claimHistory.Comments);
        }

        [Then(@"the Date/Time field will display the Date and Time that the claim was submitted to DLSW -US Central")]
        public void ThenTheDateTimeFieldWillDisplayTheDateAndTimeThatTheClaimWasSubmittedToDLSW_USCentral()
        {
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            string ctzdate =TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistory.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time").ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);            
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);           
            Assert.AreEqual(ctzdate, dateTimeFromUI);
            Report.WriteLine("the Date/Time field will display the Date and Time that the claim was submitted to DLSW -US Central");
        }

        [Then(@"the Updated By field will display '(.*)' of the user that submitted the claim to DLSW")]
        public void ThenTheUpdatedByFieldWillDisplayOfTheUserThatSubmittedTheClaimToDLSW(string p0)
        {
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            string updatedBy = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimHistory.UserFullName, updatedBy);
            Report.WriteLine("the Updated By field will display First Name Last Name of the user that submitted the claim to DLSW");
        }

        [Then(@"the Category will display (.*)")]
        public void ThenTheCategoryWillDisplay(string p0)
        {
            Report.WriteLine("the Category field will be displayed with Status Update");
            Verifytext(attributeName_xpath, LatestCategoryValue_Xpath, "Status Update");
        }

        [Then(@"the Comment will display (.*)")]
        public void ThenTheCommentWillDisplay(string p0)
        {
            Report.WriteLine("the Comment field will be displayed with Claim submitted to DLSW");
            Verifytext(attributeName_xpath, LatestCommentValue_Xpath, "Claim submitted to DLSW");
        }

        [Then(@"the comment will be visible on the history tab")]
        public void ThenTheCommentWillBeVisibleOnTheHistoryTab()
        {
            Report.WriteLine("the Comment will be visible on the history tab");
            VerifyElementVisible(attributeName_xpath, LatestCommentValue_Xpath, "Claim submitted to DLSW");
        }

        [Then(@"the comment will not be editable")]
        public void ThenTheCommentWillNotBeEditable()
        {
            Report.WriteLine("the Comment will be not editable");
            VerifyElementNotPresent(attributeName_xpath, editIcon_HistoryTab_Xpath, "edit icon");
        }

        [Then(@"the Date/Time field will display the Date and Time that the Carrier Ack field was updated-US Central")]
        public void ThenTheDateTimeFieldWillDisplayTheDateAndTimeThatTheCarrierAckFieldWasUpdated_USCentral()
        {
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistory.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time").ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);            
            Assert.AreEqual(ctzdate, dateTimeFromUI);
            Report.WriteLine("the Date/Time field will display the Date and Time that the Carrier Ack field was updated-US Central");
        }

        [Then(@"the Updated By field will display the First Name and Last Name of the user that edited the Carrier Ack field")]
        public void ThenTheUpdatedByFieldWillDisplayTheFirstNameAndLastNameOfTheUserThatEditedTheCarrierAckField()
        {
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            string updatedBy = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimHistory.UserFullName, updatedBy);
            Report.WriteLine("the Updated By field will display the First Name and Last Name of the user that edited the Carrier Ack field");
        }

        [Then(@"the Category in History Tab will display (.*)")]
        public void ThenTheCategoryInHistoryTabWillDisplay(string p0)
        {
            Report.WriteLine("the Category field will be displayed with CarrierAck");
            Verifytext(attributeName_xpath, LatestCategoryValue_Xpath, "Carrier Ack");
        }

        [Then(@"the Comment in History Tab will display (.*)")]
        public void ThenTheCommentInHistoryTabWillDisplay(string currentValue)
        {
            Report.WriteLine("the Category field will be displayed with currentValue");
            Verifytext(attributeName_xpath, LatestCommentValue_Xpath, currentValue);
        }
    }
}
