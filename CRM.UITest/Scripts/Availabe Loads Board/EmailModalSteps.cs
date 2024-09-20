using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.Scripts.Availabe_Loads_Board
{
    [Binding]
    public class EmailModalSteps : LoadsBoard
    {
        string subjectValue = null;

        [Given(@"I am any user and on the Available Loads page(.*) ,")]
        public void GivenIAmAnyUserAndOnTheAvailableLoadsPage(string url)
        {
            GlobalVariables.webDriver.Navigate().GoToUrl(url);
            bool visible = IsElementPresent(attributeName_xpath, AcceptCookies_Xpath, "cookie");
            if (visible == true)
            {
                Click(attributeName_xpath, AcceptCookies_Xpath);
            }

        }
        
        [When(@"I click on the email button of any displayed load from the grid,")]
        public void WhenIClickOnTheEmailButtonOfAnyDisplayedLoadFromTheGrid()
        {
            WaitForElementVisible(attributeName_xpath, totalRecords_xpath, "Grid Loading");
            int count = GetCount(attributeName_xpath, totalRecords_xpath);
            if(count > 2)
            {
                string refNumb = Gettext(attributeName_xpath, columnReference_FirstValue_xpath);
                string originValue = Gettext(attributeName_xpath, columnOrigin_FirstValue_xpath);
                string destValue = Gettext(attributeName_xpath, columnDestination_FirstValue_xpath);
                subjectValue = "Available Load Inquiry " + refNumb +" "+ originValue + " to " + destValue;
                Click(attributeName_xpath, columnEmailOption_FirstValue_xpath);
            }
            else
            {
                Report.WriteLine("Unable to verify the email funcitonality as no records is displaying in page");
                Assert.IsTrue(false);
            }
        }
        
        [Then(@"an email modal will open,")]
        public void ThenAnEmailModalWillOpen()
        {
            Report.WriteLine("Verifying the header of the email popup");
            WaitForElementVisible(attributeName_xpath, firstRowEmail_Header_xpath, "Claim Load");
            Verifytext(attributeName_xpath, firstRowEmail_Header_xpath, "Claim Load");
        }
        
        [Then(@"I should see To email address non editable text box with pre filled email id (.*) as a default value")]
        public void ThenIShouldSeeToEmailAddressNonEditableTextBoxWithPreFilledEmailIdAsADefaultValue(string expEmailId)
        {
            Report.WriteLine("Verifying the display of to email text box");
            VerifyElementVisible(attributeName_id, firstRowEmail_To_id, "To email textbox");
            VerifyElementNotEnabled(attributeName_id, firstRowEmail_To_id, "To email textbox");
            Report.WriteLine("To email text box is not editable");

            string actEmail = GetValue(attributeName_id, firstRowEmail_To_id, "value");
            Assert.AreEqual(actEmail, expEmailId);
        }
        
        [Then(@"I should see From email address editable text box")]
        public void ThenIShouldSeeFromEmailAddressEditableTextBox()
        {
            Report.WriteLine("Verifying the display of from email text box");
            VerifyElementVisible(attributeName_id, firstRowEmail_From_id, "From email textbox");
            VerifyElementEnabled(attributeName_id, firstRowEmail_From_id, "From email textbox");
            Report.WriteLine("From email text box is editable");
        }
        
        [Then(@"I should see Subject non editable text box with pre filled value")]
        public void ThenIShouldSeeSubjectNonEditableTextBoxWithPreFilledValue()
        {
            Report.WriteLine("Verifying the display of subject text box");
            VerifyElementVisible(attributeName_id, firstRowEmail_Subject_id, "subject email textbox");
            VerifyElementNotEnabled(attributeName_id, firstRowEmail_Subject_id, "subject email textbox");
            Report.WriteLine("subject text box is not editable");
            string actSubject = GetValue(attributeName_id, firstRowEmail_Subject_id, "value");
            Assert.AreEqual(subjectValue, actSubject);
            Report.WriteLine("Displaying" + actSubject + "is matching with UI value " + subjectValue);
        }
        
        [Then(@"I should see the body of the email editable text box")]
        public void ThenIShouldSeeTheBodyOfTheEmailEditableTextBox()
        {
            Report.WriteLine("Verifying the display of email body text box");
            VerifyElementVisible(attributeName_id, firstRowEmail_Body_id, " email body email textbox");
            VerifyElementEnabled(attributeName_id, firstRowEmail_Body_id, " email body email textbox");
            Report.WriteLine(" email body text box is editable");
        }
        
        [Then(@"I should see a send and cancel Buttons")]
        public void ThenIShouldSeeASendAndCancelButtons()
        {
            Report.WriteLine("Verifying the display of send and cancel buttons");
            VerifyElementVisible(attributeName_id, firstRowEmail_SendButton_id, "Send Button");
            VerifyElementVisible(attributeName_xpath, firstRowEmail_Cancel_xpath, "Cancel Button");
        }

        [Then(@"I should be able to enter only (.*) alphanumeric and special characters (.*)")]
        public void ThenIShouldBeAbleToEnterOnlyAlphanumericAndSpecialCharacters(int p0, string text)
        {
            Report.WriteLine("Verifying the max length of email body text box");
            string actMaxLength = GetAttribute(attributeName_id, firstRowEmail_Body_id, "maxlength");
            Assert.AreEqual(actMaxLength, "250");
            Report.WriteLine("250 is max length for email body text box");

            SendKeys(attributeName_id, firstRowEmail_Body_id, text);
            string actText = GetValue(attributeName_id, firstRowEmail_Body_id, "value");
            Assert.AreEqual(actText, text);
            Report.WriteLine("Able to enter alphanumeric and special characters");
        }
        
        [Then(@"I enter invalid email '(.*)' in From email text box")]
        public void ThenIEnterInvalidEmailInFromEmailTextBox(string email)
        {
            Report.WriteLine("Passing invalid email in email from text box");
            SendKeys(attributeName_id, firstRowEmail_From_id, email);
        }
        
        [Then(@"I click on Send button")]
        public void ThenIClickOnSendButton()
        {
            Report.WriteLine("Clicking on send button");
            Click(attributeName_id, firstRowEmail_SendButton_id);
        }
        
        [Then(@"email text box should be highlighted and displayed with error message for invalid")]
        public void ThenEmailTextBoxShouldBeHighlightedAndDisplayedWithErrorMessageForInvalid()
        {
            Report.WriteLine("Verifying the highlight and error message functionality");
            string actError = Gettext(attributeName_xpath, firstRowEmail_ErrorMessage_xpath);
            Assert.AreEqual(actError, "Enter Valid Email Address");

            string actColor = GetCSSValue(attributeName_id, firstRowEmail_From_id, "background-color");
            Assert.AreEqual(actColor, "rgba(255, 192, 203, 0.54)");
        }

        [Then(@"I Click on cancel button within email model popup")]
        public void ThenIClickOnCancelButtonWithinEmailModelPopup()
        {
            Report.WriteLine("Clicking on cancel button");
            Click(attributeName_xpath, firstRowEmail_Cancel_xpath);
        }

    }
}
