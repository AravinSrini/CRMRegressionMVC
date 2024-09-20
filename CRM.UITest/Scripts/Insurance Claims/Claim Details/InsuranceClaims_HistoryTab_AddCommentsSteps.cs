using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Globalization;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_HistoryTab_AddCommentsSteps : Objects.InsuranceClaim
    {
        string comments = "Comments $ection ver!ficat10n";
        string commentsMaxLength = "comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characters$comments Verification for more than 5000 characters&comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000";
        string commentsMoreThanMaxLength = "commentss Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characters$comments Verification for more than 5000 characters&comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000";
        string errorMessage = "Please complete all required fields";
        List<string> categoryListFromDB = null;
        string claimNumber = null;
        InsuranceClaimHistory claimHistoryTab = null;
        string comment = "verifying comment popup functionality";

        [Given(@"I am on ClaimDetailspage")]
        public void GivenIAmOnClaimDetailspage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (claimListGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                DefineTimeOut(1000);                
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I click on the History Tab")]
        public void GivenIClickOnTheHistoryTab()
        {
            Report.WriteLine("I click on the History Tab");
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
        }

        [Given(@"I click on the Add Comment button")]
        public void GivenIClickOnTheAddCommentButton()
        {
            Report.WriteLine("I click on the Add Comment Button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddComment_Id);
        }

        [Given(@"I have not completed all the required (.*) on add comment modal")]
        public void GivenIHaveNotCompletedAllTheRequiredOnAddCommentModal(string fields)
        {
            if (fields == "Category")
            {
                WaitForElementVisible(attributeName_xpath, AddCommentPopupHeader_Xpath, "Add Comment");
                Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "Carrier Inquiry");
                Report.WriteLine("I have not completed the required fileds 'Comments' on add comment modal");
            }else
            {
                WaitForElementVisible(attributeName_xpath, AddCommentPopupHeader_Xpath, "Add Comment");
                SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
                Report.WriteLine("I have not completed the required fileds 'Category' on add comment modal");
            }            
        }

        [Given(@"I have completed all the required fields on add comment modal")]
        public void GivenIHaveCompletedAllTheRequiredFieldsOnAddCommentModal()
        {
            WaitForElementVisible(attributeName_xpath, AddCommentPopupHeader_Xpath, "Add Comment");
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "General");
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
            Report.WriteLine("I have completed all the required fields on add comment modal");
        }

        [When(@"I clicked on the Add Comment button")]
        public void WhenIClickedOnTheAddCommentButton()
        {
            Report.WriteLine("I click on the Add Comment Button");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, AddComment_Id);
        }

        [When(@"I click in the category drop down field on the Add Comment Modal")]
        public void WhenIClickInTheCategoryDropDownFieldOnTheAddCommentModal()
        {
            Report.WriteLine("I clicked in the category dropdown field of Add Comment Modal");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "General");
        }

        [When(@"I click on Cancel button on the Add comment modal")]
        public void WhenIClickOnCancelButtonOnTheAddCommentModal()
        {
            Report.WriteLine("I click on Cancel button on the Add Comment modal");
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comment);
            Click(attributeName_id, AddComment_CancelButton_id);
        }

        [When(@"I click on Add button")]
        public void WhenIClickOnAddButton()
        {
            Report.WriteLine("I click on Add button on the Add Comment modal");
            Click(attributeName_id, AddComment_AddButton_Id);
        }

        [When(@"I click on History Tab")]
        public void WhenIClickOnHistoryTab()
        {
            Report.WriteLine("I click on the History Tab");
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
        }

        [Then(@"Add Comment modal will be opened")]
        public void ThenAddCommentModalWillBeOpened()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, AddCommentPopupHeader_Xpath, "Add Comment");
            string addCommentModalHeader = Gettext(attributeName_xpath, AddCommentPopupHeader_Xpath);
            Assert.AreEqual(addCommentModalHeader, "Add Comment");
            Report.WriteLine("Add Comment modal will be opened");
        }

        [Then(@"the Category field will displayed")]
        public void ThenTheCategoryFieldWillDisplayed()
        {
            Report.WriteLine("the Category field will be displayed");
            VerifyElementVisible(attributeName_xpath, AddCommentPopup_Category_Xpath, "Category");
        }

        [Then(@"the Comments field will displayed")]
        public void ThenTheCommentsFieldWillDisplayed()
        {
            Report.WriteLine("the Comments field will be displayed");
            VerifyElementVisible(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "Comments");
        }

        [Then(@"Cancel button will displayed")]
        public void ThenCancelButtonWillDisplayed()
        {
            Report.WriteLine("the Cancel button will be displayed");
            VerifyElementVisible(attributeName_id, AddComment_CancelButton_id, "Cancel");
        }

        [Then(@"Add buttons will displayed")]
        public void ThenAddButtonsWillDisplayed()
        {
            Report.WriteLine("the Add button will be displayed");
            VerifyElementVisible(attributeName_id, AddComment_AddButton_Id, "Add");
        }

        [Then(@"the Category will be required field")]
        public void ThenTheCategoryWillBeRequiredField()
        {
            string categoryLabel = Gettext(attributeName_xpath, AddCommentPopup_CategoryLabel_Xpath);
            if (categoryLabel.Contains("CATEGORY"))
            {
                Report.WriteLine("Category is the required field");
            }
            else
            {
                Report.WriteLine("Category is the not required field");
                Assert.Fail();
            }
        }

        [Then(@"the Category will be a dropdown field")]
        public void ThenTheCategoryWillBeADropdownField()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "General");
        }

        [Then(@"the Comments will be required field")]
        public void ThenTheCommentsWillBeRequiredField()
        {
            string commentsLabel = Gettext(attributeName_xpath, AddCommentPopup_CommentsLabel_Xpath);
            if (commentsLabel.Contains("COMMENT"))
            {
                Report.WriteLine("Comments is the required field");
            }
            else
            {
                Report.WriteLine("Comments is the not required field");
                Assert.Fail();
            }
        }

        [Then(@"the Comments field should accept alpha numeric")]
        public void ThenTheCommentsFieldShouldAcceptAlphaNumeric()
        {
            Report.WriteLine("the Comments field should accept alpha numeric with special characters");
            //Verifying Comments field - alpha-numeric, special characters validation
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
            string commentsTextBoxValidations = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(comments, commentsTextBoxValidations);
        }

        [Then(@"the Comments field should accept max length of (.*) characters")]
        public void ThenTheCommentsFieldShouldAcceptMaxLengthOfCharacters(int p0)
        {
            //Verifying 5000 max length validation
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, commentsMaxLength);
            string maxLengthComments = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(commentsMaxLength, maxLengthComments);
            Report.WriteLine("Verifying the comments field validation of max length 5000 characters");

            //Verifying more than 5000 max length validation
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, commentsMoreThanMaxLength);
            string moreThanMaxLengthComments = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreNotEqual(commentsMoreThanMaxLength, maxLengthComments);
            Report.WriteLine("Verifying the comments field validation of more than max length 5000 characters");

            //Verifying less than 5000 max length validation
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
            string lessThanMaxLengthComments = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(comments, lessThanMaxLengthComments);
            Report.WriteLine("Verifying the comments field validation of less than max length 5000 characters");
        }

        [Then(@"I will see the list of category options")]
        public void ThenIWillSeeTheListOfCategoryOptions()
        {
            categoryListFromDB = DBHelper.GetInsuranceCategoryList();
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            IList<IWebElement> categoryListFromUI = GlobalVariables.webDriver.FindElements(By.XPath(AddCommentPopup_CategoryValues_Xpath));
            IList<string> actualCategoryValues = new List<string>();
            foreach (IWebElement category in categoryListFromUI)
            {
                actualCategoryValues.Add((category.Text).ToString());
            }
            for (int i = 0; i < actualCategoryValues.Count; i++)
            {
                if (categoryListFromDB.Contains(actualCategoryValues[i]))
                {
                    Report.WriteLine("Category List displaying in UI is matching with DB");
                }
                else
                {
                    Report.WriteLine("Category List displaying in UI is not matching with DB");
                }
            }
        }

        [Then(@"the Category list isconfigurable")]
        public void ThenTheCategoryListIsConfigurable()
        {            
            IList<IWebElement> categoryListFromUI = GlobalVariables.webDriver.FindElements(By.XPath(AddCommentPopup_CategoryValues_Xpath));
            IList<string> actualCategoryValues = new List<string>();
            foreach (IWebElement category in categoryListFromUI)
            {
                actualCategoryValues.Add((category.Text).ToString());
            }
            CollectionAssert.AreEqual(actualCategoryValues.OrderBy(q => q).ToList(), categoryListFromDB.OrderBy(q => q).ToList());
            Report.WriteLine("The category list is configurable");
        }

        [Then(@"the Add Comment modal will be closed")]
        public void ThenTheAddCommentModalWillBeClosed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_xpath, AddCommentPopupHeader_Xpath, "Add Comment");
            VerifyElementNotVisible(attributeName_xpath, AddCommentPopupHeader_Xpath, "Add Comment");
            Report.WriteLine("Add Comment modal closed and not visible");
        }

        [Then(@"no comment will be added")]
        public void ThenNoCommentWillBeAdded()
        {
            Report.WriteLine("No comment will be added");
            VerifyElementNotVisible(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comment);
        }

        [Then(@"the missing fields will be highlighted in red")]
        public void ThenTheMissingFieldsWillBeHighlightedInRed()
        {
            Report.WriteLine("Highlighted missing fields");
            string actualCommentsFieldColor = GetCSSValue(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "background-color");
            string expectedCommentsFieldColor = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(actualCommentsFieldColor, expectedCommentsFieldColor);
        }

        [Then(@"I will display with message (.*)")]
        public void ThenIWillDisplayWithMessage(string p0)
        {
            WaitForElementVisible(attributeName_xpath, AddComment_ErrorMessage_Xpath, "Please Enter all required fields");
            string errorMessageFromUI = Gettext(attributeName_xpath, AddComment_ErrorMessage_Xpath);
            Assert.AreEqual(errorMessage, errorMessageFromUI);
            Report.WriteLine("I will be displayed with an error message 'Please complete all required fields'");
        }

        [Then(@"the comment will be added to the History tab")]
        public void ThenTheCommentWillBeAddedToTheHistoryTab()
        {
            string commentsAddedUI = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(comments, commentsAddedUI);
            Report.WriteLine("The comments will be added to the History Tab");
        }

        [Then(@"the Time of the Date/Time field will be Central Time Zone")]
        public void ThenTheTimeOfTheDateTimeFieldWillBeCentralTimeZone()
        {
            claimNumber = DBHelper.GetClaimNumber().ToString();
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            Assert.AreEqual(ctzdate, dateTimeFromUI);
            Report.WriteLine("Time of the Date/Time field will be Central Time Zone");
        }

        [Then(@"CRM will record the first name and last name of the user that added the comment")]
        public void ThenCRMWillRecordTheFirstNameAndLastNameOfTheUserThatAddedTheComment()
        {
            claimNumber = DBHelper.GetClaimNumber().ToString();
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string nameForTheCommentAdded = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimHistoryTab.UserFullName, nameForTheCommentAdded);
            Report.WriteLine("CRM will record the first name and last name of the user for the added comment");
        }

        [Then(@"I should not be displayed with Add comment button")]
        public void ThenIShouldNotBeDisplayedWithAddCommentButton()
        {
            Report.WriteLine("Add comment button is not displayed");
            VerifyElementNotPresent(attributeName_id, AddComment_Id, "Add Comment");
        }
    }
}
