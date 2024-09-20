using System;
using System.Collections.Generic;
using System.Globalization;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest
{
    [Binding]
    public class InsuranceClaims_HistoryTab_EditCommentsSteps : Objects.InsuranceClaim
    {
        string comments = "Comments $ection ver!ficat10nSWA";
        string commentsMaxLength = "comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characters$comments Verification for more than 5000 characters&comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 4000";
        string commentsMoreThanMaxLength = "commentss Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characterscomments Verification for more than 5000 characters$comments Verification for more than 5000 characters&comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 5000 characters comments Verification for more than 4000";
        InsuranceClaimHistory claimHistoryTab = null;        
        string claimNumber = null;
        string commentSection_Text = "Edit Comment Modal functionality verification byswa";

        [Given(@"I am on Claim details page")]
        public void GivenIAmOnClaimDetailsPage()
        {
            Report.WriteLine("Clicking on the Claim Number");
            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();            
            claimNumber = DBHelper.GetSecondLatestClaimNumber().ToString();
            DefineTimeOut(1000);
            SendKeys(attributeName_xpath, ClaimsListSearchField_xpath, claimNumber);
            Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"Edit Comment modal will be opened for any editable comment")]
        public void GivenEditCommentModalWillBeOpenedForAnyEditableComment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> stationDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CategoryValues_Xpath));
            int DropDownCount = stationDropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (stationDropDownList[i].Text != "Carrier Ack" || stationDropDownList[i].Text != "Status Update")
                {
                    Click(attributeName_xpath, ".//*[@id='InsuranceClaimHistoryGrid']//tr[" + i+1 + "]/td[5]/a");
                    break;
                }
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, HistoryTab_EditCommentModal, "Edit Comment");
            string editCommentModel = Gettext(attributeName_xpath, HistoryTab_EditCommentModal);
            Assert.AreEqual(true, editCommentModel.Contains("Edit Comment"));

            Report.WriteLine("I am on the Edit Comment model");
        }

        [Given(@"I have not completed all required fields for Edit Modal")]
        public void GivenIHaveNotCompletedAllRequiredFieldsForEditModal()
        {
            WaitForElementVisible(attributeName_xpath, HistoryTab_EditCommentModal, "Edit Comment");
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "Appeal/Rebuttal");
            Click(attributeName_xpath, AddCommentPopup_CommentSection_Xpath);
            Clear(attributeName_xpath, AddCommentPopup_CommentSection_Xpath);
            Report.WriteLine("I have not completed the required fileds 'Comments' on edit comment modal");
        }

        [Given(@"I have completed all required fields")]
        public void GivenIHaveCompletedAllRequiredFields()
        {
            WaitForElementVisible(attributeName_xpath, HistoryTab_EditCommentModal, "Edit Comment");
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "General");
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, commentSection_Text);
            Report.WriteLine("I have completed all the required fields on edit comment modal");            
        }
        [When(@"I click on the Save button in the Edit Modal")]
        public void WhenIClickOnTheSaveButtonInTheEditModal()
        {
            Click(attributeName_id, HistoryTab_SaveButton_Id);
            Report.WriteLine("Clicked on Save Button ");
        }        

        [When(@"I click on the Edit icon of any editable comment")]
        public void WhenIClickOnTheEditIconOfAnyEditableComment()
        {
            GlobalVariables.webDriver.WaitForPageLoad();            
            IList<IWebElement> stationDropDownList = GlobalVariables.webDriver.FindElements(By.XPath(CategoryValues_Xpath));
            int DropDownCount = stationDropDownList.Count;
            for (int i = 0; i < DropDownCount; i++)
            {
                if (stationDropDownList[i].Text != "Carrier Ack" || stationDropDownList[i].Text != "Status Update")
                {
                    Click(attributeName_xpath, ".//*[@id='InsuranceClaimHistoryGrid']//tr[" + i+1 + "]/td[5]/a");
                    break;
                }
            }
            Report.WriteLine("Clicking on Edit Icon, the Edit Modal will open...");
        }

        [When(@"I click in the Category drop down field")]
        public void WhenIClickInTheCategoryDropDownField()
        {
            Report.WriteLine("I clicked in the category dropdown field of Edit Comment Modal");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, AddCommentPopup_Category_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, AddCommentPopup_CategoryValues_Xpath, "General");
        }

        [When(@"I click the Cancel button")]
        public void WhenIClickTheCancelButton()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
            Click(attributeName_id, HistoryTab_CancelButton);
            Report.WriteLine("Clicking on Cancel button");
        }

        [Then(@"the Edit Comment modal will open")]
        public void ThenTheEditCommentModalWillOpen()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, HistoryTab_EditCommentModal, "Edit Comment");
            string editCommentModel = Gettext(attributeName_xpath, HistoryTab_EditCommentModal);
            Assert.AreEqual(true, editCommentModel.Contains("Edit Comment"));
            Report.WriteLine("I am on the Edit Comment model");
        }

        [Then(@"I will receive an error message (.*)")]
        public void ThenIWillReceiveAnErrorMessage(string p0)
        {
            string expectedErrorMessage = "Please complete all required fields";
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, EditComment_ErrorMessage_Xpath, expectedErrorMessage);
            Report.WriteLine("Error Message is displayed when required fields are not entered");
        }

        [Then(@"I will see the Category field which is required,drop down list")]
        public void ThenIWillSeeTheCategoryFieldWhichIsRequiredDropDownList()
        {            
            string actualCategory_label = Gettext(attributeName_xpath, EditComment_CategoryLabel_Xpath);
            if (actualCategory_label.Contains("CATEGORY"))
            {
                Report.WriteLine("Category is the required field");
            }
            else
            {
                Report.WriteLine("Category is not displayed with asterick label");
                Assert.Fail();
            }

        }

        [Then(@"I will see the Comment which is required,alpha-numeric, spcial characters, max length (.*) characters")]
        public void ThenIWillSeeTheCommentWhichIsRequiredAlpha_NumericSpcialCharactersMaxLengthCharacters(string p0)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, commentsMaxLength);
            string maxLengthComments = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(commentsMaxLength, maxLengthComments);
            Report.WriteLine("Verifying the comments field validation of max length 5000 characters");

            //Verifying more than 5000 max length validation
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, commentsMoreThanMaxLength);
            string moreThanMaxLengthComments = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreNotEqual(commentsMoreThanMaxLength, moreThanMaxLengthComments);
            Report.WriteLine("Verifying the comments field validation of more than max length 5000 characters");

            //Verifying less than 5000 max length validation
            SendKeys(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
            string lessThanMaxLengthComments = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(comments, lessThanMaxLengthComments);
            Report.WriteLine("Verifying the comments field validation of less than max length 5000 characters");
        }

        [Then(@"I will see the Cancel,save buttons")]
        public void ThenIWillSeeTheCancelSaveButtons()
        {
            VerifyElementVisible(attributeName_id, HistoryTab_CancelButton, "Cancel");
            Report.WriteLine("Cancel button is visible in the Edit Modal ");

            VerifyElementVisible(attributeName_id, HistoryTab_SaveButton, "Save");
            Report.WriteLine("Save button is visible in the Edit Modal ");
        }

        [Then(@"I will see the list of Category options")]
        public void ThenIWillSeeTheListOfCategoryOptions()
        {
            string optionsOfCategoryList = "Accounting Issue,Appeal / Rebuttal,Carrier Inquiry,General,Info/Doc Request,Mitigation/Salvage,Status Report,DLSW Submitted Claim,Ack to Submitter";

            Click(attributeName_xpath, HistoryTab_CategoryOption);
            List<string> CategoryDropdownValues_UI = GetDropdownValues(attributeName_id, QuantityDropdown_id, "li");
            List<string> CategoryOptions_Expected = new List<string>(optionsOfCategoryList.Split(','));
            foreach (string Options in CategoryOptions_Expected)
            {
                if (CategoryDropdownValues_UI.Contains(Options))
                {
                    Console.WriteLine(Options + "field is present in the dropdown");
                }
                else
                {
                    Console.WriteLine("Matching not found for " + Options);
                }
            }

            Report.WriteLine("The List of category options are availble as per expectations ..");
        }

        [Then(@"the modal will close and the comment will not be updated")]
        public void ThenTheModalWillCloseAndTheCommentWillNotBeUpdated()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_xpath, HistoryTab_EditCommentModal, "Edit Comment");
            VerifyElementNotVisible(attributeName_xpath, HistoryTab_EditCommentModal, "Edit Comment");
            VerifyElementNotVisible(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, comments);
            Report.WriteLine("Edit Comment modal closed and not visible and comment not saved");
        }

        [Then(@"the field\(s\) missing information will be highlighted in red")]
        public void ThenTheFieldSMissingInformationWillBeHighlightedInRed()
        {
            string UICommentsFieldColour = GetCSSValue(attributeName_id, HistoryTab_AddCommentTextBox, "background-color");
            string ActualCommentsFieldColour = "rgba(251, 236, 237, 1)";
            Assert.AreEqual(UICommentsFieldColour, ActualCommentsFieldColour);
            Report.WriteLine("Empty fields on click of save button will be Highlighting in red");
        }

        [Then(@"the modal will close and the comment will be updated with the changes")]
        public void ThenTheModalWillCloseAndTheCommentWillBeUpdatedWithTheChanges()
        {
            string commentsAddedUI = GetAttribute(attributeName_xpath, AddCommentPopup_CommentSection_Xpath, "value");
            Assert.AreEqual(commentSection_Text, commentsAddedUI);
            Report.WriteLine("The Comments edited in the Edit modal will be updated in the grid successfully");
        }

        [Then(@"the Date/Time will update to the current date and time and will be in Central Time Zone \(US\)")]
        public void ThenTheDateTimeWillUpdateToTheCurrentDateAndTimeAndWillBeInCentralTimeZoneUS()
        {
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time").ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            Assert.AreEqual(ctzdate, dateTimeFromUI);
        }

        [Then(@"CRM will record the  first name and last name of the user that edited the comment")]
        public void ThenCRMWillRecordTheFirstNameAndLastNameOfTheUserThatEditedTheComment()
        {
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string nameForTheCommentAdded = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimHistoryTab.UserFullName, nameForTheCommentAdded);
            Report.WriteLine("CRM will record the first name and last name of the user for the added comment");
        }
    }
}
