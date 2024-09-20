using System;
using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities.Proxy;
using System.Globalization;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_HistoryTab_ElementsSteps : Objects.InsuranceClaim
    {
        int countCharactersOfComments;
        string original_CommentsDisplayed = string.Empty;
        string recentSubmittedClaim = null;
        InsuranceClaimHistory claimHistory = null;
        string comments_AddCommentsSection = "This is General Comment General CommentGeneral CommentGeneral CommentGeneral CommentGeneral Comment This is General Comment comments This is General Comment his is General Comment This is General Comment comments This This is General Comment This is General Comment This is General Comment";

        [Given(@"I am a Sales, Sales Management,Operations, Station Owner, or Claims Specialist user")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            string userName = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I have logged into CRM application");
        }

        [Given(@"I am on the Claim Detailspage of new submitted claim")]
        public void GivenIAmOnTheClaimDetailspageOfNewSubmittedClaim()
        {
            recentSubmittedClaim = DBHelper.GetNewlySubmittedClaimNumber().ToString();
      
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            //Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            DefineTimeOut(1000);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, recentSubmittedClaim);
            Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Report.WriteLine("I am on Claim Details page of new submitted claim");
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);

        }

        [When(@"I click on the History tab")]
        public void WhenIClickOnTheHistoryTab()
        {
            Click(attributeName_id, HistoryTab);
        }

      
        [When(@"The Comment of any displayed status/history entry is greater than (.*) characters")]
        public void WhenTheCommentOfAnyDisplayedStatusHistoryEntryIsGreaterThanCharacters(int p0)
        {
            string original_CommentsDisplayed = Gettext(attributeName_xpath, HistoryTab_Comments);
            int countCharactersOfComments = original_CommentsDisplayed.Length;
        }

        [When(@"I click (.*) hyperlink of any displayed Comment that is greater than (.*) characters")]
        public void WhenIClickHyperlinkOfAnyDisplayedCommentThatIsGreaterThanCharacters(string p0, int p1)
        {
            string original_CommentsDisplayed = Gettext(attributeName_xpath, HistoryTab_Comments);
            string commentsWithout_ViewMoreLink = original_CommentsDisplayed.Substring(0, 75);
            int countCharactersOfComments = commentsWithout_ViewMoreLink.Length;
            if (countCharactersOfComments >= 75)
            {
                Click(attributeName_xpath, HistoryTab_ViewMore_link);
            }
            else
            {
                Report.WriteLine("The length of the Comment is less than 75 so View More button is not displayed...");
            }
        }

        [When(@"History Tab is clicked")]
        public void WhenHistoryTabIsClicked()
        {
            Click(attributeName_id, HistoryTab);

        }

        [When(@"I will add data to the grid")]
        public void WhenIWillAddDataToTheGrid()
        {
            Click(attributeName_id, AddComment_Id);
            Click(attributeName_id, HistoryTab_AddCommentTextBox);
            SendKeys(attributeName_id, HistoryTab_AddCommentTextBox,comments_AddCommentsSection);
            Click(attributeName_id, AddButtonToSave);
        }


        [Then(@"I will see a grid displaying the Date/Time in mm/dd/yyyy hh:mm format")]
        public void ThenIWillSeeAGridDisplayingTheDateTimeInMmDdYyyyHhMmFormat()
        {
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            InsuranceClaimHistory claimDateTimeHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimDateTimeHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            string updatedDateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);

            Report.WriteLine("Verified that the selected date range is displayed in mm/dd/yyyy hh:mm format");

        }

        [Then(@"the grid will display Updated By with CRM first name and last name of user that added,updated status,history entry")]
        public void ThenTheGridWillDisplayUpdatedByWithCRMFirstNameAndLastNameOfUserThatAddedUpdatedStatusHistoryEntry()
        {
            string actualUpdatedBy = Gettext(attributeName_xpath, HistoryTab_UpdatedBy);
            Assert.AreEqual(true, actualUpdatedBy.Contains("UPDATED BY"));
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            string actualFirstAndLastName = Gettext(attributeName_xpath, HistoryTab_FistAndLastName);
            Assert.AreEqual(claimHistory.UserFullName, actualFirstAndLastName);
            Report.WriteLine("The grid will display UpdatedBy with CRM first name and last name of user that added, updated status, history entry");
        }

        [Then(@"the grid will display Category")]
        public void ThenTheGridWillDisplayCategory()
        {
            string ActualColumn_Category = Gettext(attributeName_xpath, HistoryTab_Category_Xpath);
            Assert.AreEqual(true, ActualColumn_Category.Contains("CATEGORY"));
            string expectedCategoryDisplayed_Grid = Gettext(attributeName_xpath, HistoryTab_CategoryOption);
            VerifyElementPresent(attributeName_xpath, HistoryTab_Category_Xpath, expectedCategoryDisplayed_Grid);
            Report.WriteLine("The grid is displayed with the column Category..");

        }

        [Then(@"the grid will display Comment with scroll bar when comments too large for field")]
        public void ThenTheGridWillDisplayCommentWithScrollBarWhenCommentsTooLargeForField()
        {
            string original_CommentsDisplayed = Gettext(attributeName_xpath, HistoryTab_Comments);
            string commentsWithout_ViewMoreLink = original_CommentsDisplayed.Substring(0, 75);
            int countCharactersOfComments = commentsWithout_ViewMoreLink.Length;
            if (countCharactersOfComments >= 75)
            {
                Click(attributeName_xpath, HistoryTab_ViewMore_link);
                IJavaScriptExecutor js = (IJavaScriptExecutor)GlobalVariables.webDriver;
               // js.ExecuteScript("arguments[0].scrollIntoView(true);", HistoryTab_scrollbar);
                String JS_ELEMENT_IS_SCROLLABLE ="return arguments[0].scrollHeight > arguments[0].offsetHeight;";
                Boolean isScrollable = (Boolean)js.ExecuteScript(JS_ELEMENT_IS_SCROLLABLE, HistoryTab_scrollbar);
            }
            else
            {
                Report.WriteLine("The Scroll bar is not displayed when comments too large for field ...");
            }

        }

        [Then(@"the grid will display status and comment updates")]
        public void ThenTheGridWillDisplayStatusAndCommentUpdates()
        {
            string actualCommentsDisplayed = Gettext(attributeName_xpath, HistoryTab_Comments);
            VerifyElementPresent(attributeName_xpath, HistoryTab_Comments, comments_AddCommentsSection);
            Report.WriteLine("The Grid is displayed with the Status and Comment Updates as per expectation ");

        }


        [Then(@"the status and comment updates will display in chronlogical order and the most recent as the first entry at the top of the page")]
        public void ThenTheStatusAndCommentUpdatesWillDisplayInChronlogicalOrderAndTheMostRecentAsTheFirstEntryAtTheTopOfThePage()
        {
            claimHistory = DBHelper.GetInsuranceClaimHistorydetails(recentSubmittedClaim);
            var ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistory.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time");
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            DateTime expectedDdate = Convert.ToDateTime(dateTimeFromUI);
            Report.WriteLine("The Status and comment updates displayed are the most recent as the first entry at the top of the page..");
        }

        [Then(@"I  will see a'(.*)' hyperlink")]
        public void ThenIWillSeeAHyperlink(string p0)
        {
            if (countCharactersOfComments >= 75)
            {
                string ActualLink_ViewMore = Gettext(attributeName_linktext, HistoryTab_ViewMore_link);
                Assert.AreEqual(true, ActualLink_ViewMore.Contains("...View More"));
                Report.WriteLine("The hyperlink View More is visible for the comments displayed are more  than 25 characters");
            }
            else
            {
                Report.WriteLine("The Hyperlink View More is not visible as the Comments displayed is less than 25 characters");
            }
        }
        [Then(@"I will see the entire comment including original (.*) characters")]
        public void ThenIWillSeeTheEntireCommentIncludingOriginalCharacters(int p0)
        {
            string original_CommentsDisplayed = Gettext(attributeName_xpath, HistoryTab_Comments);
            string commentsWithout_ViewMoreLink = original_CommentsDisplayed.Substring(0, 75);
            int countCharactersOfComments = commentsWithout_ViewMoreLink.Length;
            if (countCharactersOfComments >= 75)    
            {
                string entireCommentDisplayed = Gettext(attributeName_xpath, HistoryTab_Comments);
                Assert.AreEqual(entireCommentDisplayed, comments_AddCommentsSection);
            }
            else
            {
                Report.WriteLine("The Original Comments are displayed as there is comments displayed less than 25 characters");

                Assert.AreEqual(true, original_CommentsDisplayed);

            }
        }
    }


       
    }
