using CRM.UITest.Objects;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Shipment.Add_Shipment.LTL.Shipment_Confirmation_Screen__All_Users
{
    [Binding]
    public class ShipmentConfirmationLTL_MVC5_ShipmentSummarybutton_AllUsersSteps:AddShipments
    {

        [Given(@"I entered all required data (.*) and not checked the Send A Copy to My Email box")]
        public void GivenIEnteredAllRequiredDataAndNotCheckedTheSendACopyToMyEmailBox(string email)
        {
            Report.WriteLine("Enter an email address and uncheck the Send a copy to my mail check box");
            Click(attributeName_xpath, confirmation_summarybutton);
            scrollpagedown();
            Click(attributeName_xpath, confirmation_EmailShpsummary_xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);
            Click(attributeName_xpath, Emailmodal_sendcopycheck_xpath);
        }

        [Given(@"I entered required data (.*) and checked the Send A Copy to My Email box")]
        public void GivenIEnteredRequiredDataAndCheckedTheSendACopyToMyEmailBox(string email)
        {
            Report.WriteLine("Enter an Email and Send a copy check box is checked by default");
            Click(attributeName_xpath, confirmation_summarybutton);
            scrollpagedown();
            Click(attributeName_xpath, confirmation_EmailShpsummary_xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);            
        }

        [When(@"I click on the drop down arrow of the Shipment Summary button")]
        public void WhenIClickOnTheDropDownArrowOfTheShipmentSummaryButton()
        {
            Report.WriteLine("Click on Shipment summary button");
            Click(attributeName_xpath, confirmation_summarybutton);
        }

        [Then(@"I should be displaying with (.*)")]
        public void ThenIShouldBeDisplayingWith(string twooptions)
        {
            Report.WriteLine("DisplayWith two options");
            string[] values = twooptions.Split(',');
            scrollpagedown();            
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(confirmation_Shpsummarydrpdown_xpath));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {

                ExpectedVal.Add(v);
            }
            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under Shipment summary dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under Shipment summary dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }

        }

        [When(@"I click on View Shipment Summary option")]
        public void WhenIClickOnViewShipmentSummaryOption()
        {
            Report.WriteLine("Click on View Shipment Summary option");
            scrollpagedown();
            Click(attributeName_xpath, confirmation_ViewShpsummary_xpath);
        }

        [Then(@"New tab will be opened which will display the shipment summary document")]
        public void ThenNewTabWillBeOpenedWhichWillDisplayTheShipmentSummaryDocument()
        {
            string configURL = launchUrl;
            WindowHandling(configURL + "Shipment/ShipmentConfirmation#");
            string variableref = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);

            string expectedPageURL = configURL + "Shipment/ViewShipmentSummary?referenceNumber=" + variableref;

            WindowHandling(expectedPageURL);
            Report.WriteLine("User is navigated to the Shipment Summary document Creation page");
            
        }

        [When(@"I click on Email Shipment Summary option")]
        public void WhenIClickOnEmailShipmentSummaryOption()
        {
            Report.WriteLine("Click on Email Shipment Summary option");
            scrollpagedown();
            Click(attributeName_xpath, confirmation_EmailShpsummary_xpath);            
        }

        [Then(@"Email Shipment Summary modal will be displayed")]
        public void ThenEmailShipmentSummaryModalWillBeDisplayed()
        {
            Report.WriteLine("Shipment Summary pop up should be displayed");
            VerifyElementVisible(attributeName_xpath, EmailmodalPopup_xpath, "Email Shipment Summary");
        }

        [Then(@"I should be displayed with Enter an email address text box and Add Additional Email button")]
        public void ThenIShouldBeDisplayedWithEnterAnEmailAddressTextBoxAndAddAdditionalEmailButton()
        {
            Report.WriteLine("Email addresses text boxes should be displayed");
            VerifyElementVisible(attributeName_id, Emailmodal_emailtextbox_id, "Emailaddress");
            VerifyElementVisible(attributeName_id, Emailmodal_additionalemailbutton, "Addadditional email");
        }

        [Then(@"I should be displayed valid verbiage and able to edit the verbiage")]
        public void ThenIShouldBeDisplayedValidVerbiageAndAbleToEditTheVerbiage()
        {
            Report.WriteLine("Verbiage in pop should be displayed and should be able to edit");
            string BOLnumber = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            string EmailVerbiage_UI = GetValue(attributeName_id, Emailmodal_messagebox_id,"value");
            string verbiage = "Your shipment has been placed using Bill of Lading number";
            string verbiage3 = ". Please find the Bill of Lading attached to this email.";
            string verbiage2 = "Thank you for your business.";

            if (EmailVerbiage_UI.Contains(verbiage) && EmailVerbiage_UI.Contains(BOLnumber) && EmailVerbiage_UI.Contains(verbiage2) && EmailVerbiage_UI.Contains(verbiage3))
            {
                Report.WriteLine("Email Verbiage diaplying in UI is matching");
            }
            else
            {
                throw new System.Exception("Email verbiage not matching");
            }
        }

        [Then(@"I should be displayed valid verbiage and able to edit the verbiage for Shipment Summary")]
        public void ThenIShouldBeDisplayedValidVerbiageAndAbleToEditTheVerbiageForShipmentSummary()
        {
            Report.WriteLine("Verbiage in Shipment summary pop should be displayed and should be able to edit");
            string BOLnumber = Gettext(attributeName_xpath, confirmation_BOLValue_Xpath);
            string EmailVerbiage_UI = GetValue(attributeName_id, Emailmodal_messagebox_id, "value");
            string verbiage = "Your shipment has been placed using Bill of Lading number";
            string verbiage3 = ". Please find the Shipment Summary attached to this email.";
            string verbiage2 = "Thank you for your business.";

            if (EmailVerbiage_UI.Contains(verbiage) && EmailVerbiage_UI.Contains(BOLnumber) && EmailVerbiage_UI.Contains(verbiage2) && EmailVerbiage_UI.Contains(verbiage3))
            {
                Report.WriteLine("Email Verbiage diaplying in UI is matching");
            }
            else
            {
                throw new System.Exception("Email verbiage not matching");
            }
        }

        [Then(@"I should be displayed with copy check box by default checked")]
        public void ThenIShouldBeDisplayedWithCopyCheckBoxByDefaultChecked()
        {
            Report.WriteLine("Send a copy to my mail check box should be checked by default");
            VerifyElementChecked(attributeName_xpath, Emailmodal_sendcopycheckinput_xpath, "Send a copy to my email");
        }

        [Then(@"I should be able to uncheck the copy check box")]
        public void ThenIShouldBeAbleToUncheckTheCopyCheckBox()
        {
            Report.WriteLine("Send a copy to my mail check box should be uncheckable");
            Click(attributeName_xpath,Emailmodal_sendcopycheck_xpath);
            VerifyElementNotChecked(attributeName_xpath, Emailmodal_sendcopycheck_xpath,"sendcopy");
        }

        [Then(@"I should be displayed with cancel and send email options")]
        public void ThenIShouldBeDisplayedWithCancelAndSendEmailOptions()
        {
            Report.WriteLine("Cancel and Send Email buttons should be displayed");
            VerifyElementVisible(attributeName_id, Emailmodal_cancel_id, "Cancel");
            VerifyElementVisible(attributeName_id, Emailmodal_sendemail_id, "Send Email");
        }

        [When(@"I click on Add Additional Email button in Email Shipment Summary modal")]
        public void WhenIClickOnAddAdditionalEmailButtonInEmailShipmentSummaryModal()
        {
            Report.WriteLine("Click on Add additional email button");
            Click(attributeName_id, Emailmodal_additionalemailbutton);
        }

        [Then(@"I should be displayed with new email address text box and remove button")]
        public void ThenIShouldBeDisplayedWithNewEmailAddressTextBoxAndRemoveButton()
        {
            Report.WriteLine("Additional email text box and remove buttons should be displayed");
            VerifyElementVisible(attributeName_xpath, Emailmodal_additionalemailtextbox1, "Additional Email");
            VerifyElementVisible(attributeName_xpath, Emailmodal_additionalRemove1, "Remove");
        }

        [Then(@"I click on remove button")]
        public void ThenIClickOnRemoveButton()
        {
            Thread.Sleep(200);
            Report.WriteLine("Click on Remove button");
            Click(attributeName_xpath, Emailmodal_additionalRemove1);
        }

        [Then(@"the additional email address text box has been removed")]
        public void ThenTheAdditionalEmailAddressTextBoxHasBeenRemoved()
        {
            Report.WriteLine("Add additional email text box should be removed");
            VerifyElementNotPresent(attributeName_xpath, Emailmodal_additionalemailtextbox1, "emailtextbox");            
        }

        [When(@"I click on cancel button of Email shipment summary modal")]
        public void WhenIClickOnCancelButtonOfEmailShipmentSummaryModal()
        {
            Report.WriteLine("Click on Cancel button");
            Click(attributeName_id, Emailmodal_cancel_id);
        }

        [Then(@"the Email shipment summary modal will be closed")]
        public void ThenTheEmailShipmentSummaryModalWillBeClosed()
        {
            Report.WriteLine("Email Shipment Summary modal will be closed");
            VerifyElementNotVisible(attributeName_xpath, EmailmodalPopup_xpath, "Email Shipment Summary");
            VerifyElementVisible(attributeName_xpath, confirmation_BOLValue_Xpath, "BOL Number");
        }

        [Given(@"I entered invalid Email address (.*) on email shipment summary modal")]
        public void GivenIEnteredInvalidEmailAddressOnEmailShipmentSummaryModal(string email)
        {
            Report.WriteLine("Enter invalid email address");
            Click(attributeName_xpath, confirmation_summarybutton);
            scrollpagedown();
            Click(attributeName_xpath, confirmation_EmailShpsummary_xpath);
            Thread.Sleep(1000);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);
        }

        [When(@"I click on Send Email button")]
        public void WhenIClickOnSendEmailButton()
        {
            Report.WriteLine("Click on Send Email");
            Click(attributeName_id, Emailmodal_sendemail_id);
        }

        [Then(@"Email text box should highlighted in Red color and displayed with (.*)")]
        public void ThenEmailTextBoxShouldHighlightedInRedColorAndDisplayedWith(string errormessage)
        {
            Report.WriteLine("displayed with error message for invalid");
            Verifytext(attributeName_xpath, Emailmodal_errorforinvalid_xpath, errormessage);
            Thread.Sleep(1000);
            var colorofemail = GetCSSValue(attributeName_id, Emailmodal_emailtextbox_id, "background");            
            if (colorofemail.Contains("rgb(251, 236, 236)") )
            {
                Report.WriteLine("email text box should be highlighted");
            }

            else
            {
                throw new Exception("failed the validation");
            }
        }


        [Then(@"Email text box should highlighted and displayed with (.*)")]
        public void ThenEmailTextBoxShouldHighlightedAndDisplayedWith(string errormessage)
        {
            Report.WriteLine("displayed with error message for invalid");
            Verifytext(attributeName_xpath, Emailmodal_errorforinvalid_xpath, errormessage);

            var colorofemail = GetCSSValue(attributeName_id, Emailmodal_emailtextbox_id, "background");
            var coloroftheextraemail = GetCSSValue(attributeName_xpath, Emailmodal_additionalemailtextbox1, "background");
            if (colorofemail.Contains("linear-gradient(rgb(251, 236, 236)") && coloroftheextraemail.Contains("linear-gradient(rgb(251, 236, 236)"))
            {
                Report.WriteLine("email text boxes should be highlighted");
            }

            else
            {
                throw new Exception("failed the validation");
            }            
        }               

        [Then(@"modal will be closed")]
        public void ThenModalWillBeClosed()
        {
            Report.WriteLine("Shipment summary modal will be closed");
            Thread.Sleep(2000);
            VerifyElementNotVisible(attributeName_xpath, EmailmodalPopup_xpath, "Email Shipment Summary");
        }

        [Then(@"displaying with (.*)")]
        public void ThenDisplayingWith(string confirmation_message)
        {
            Report.WriteLine("will receive a confirmation popup");
            VerifyElementVisible(attributeName_xpath, Confimrationpopup_emails_xpath, "modal");
            string Confirmationmsg_UI = Gettext(attributeName_xpath, Confimrationpopup_emails_xpath);
            if (Confirmationmsg_UI.Contains(confirmation_message))
            {
                Report.WriteLine("Confirmtion pop up opened successfully");
            }
            else
            {
                Report.WriteLine("Confirmtion pop up not displayed");
            }
        }

        [Then(@"Confirmation message displays only entered (.*)")]
        public void ThenConfirmationMessageDisplaysOnlyEntered(string email)
        {
            Report.WriteLine("Confirmation popup displays only entered email in pop up");
            string email_UI = Gettext(attributeName_xpath, Confimrationpopup_email1_xpath);
            Assert.AreEqual(email, email_UI);
        }

        [Then(@"Confirmation message displays logged in user email (.*) and entered (.*)")]
        public void ThenConfirmationMessageDisplaysLoggedInUserEmailAndEntered(string Username, string email)
        {
            Report.WriteLine("Confrimation pop up displays both entered email and logged user email");
            string email_UI = Gettext(attributeName_xpath, Confimrationpopup_email1_xpath);
            Assert.AreEqual(email, email_UI);

            string Useremail_UI = Gettext(attributeName_xpath, Confimrationpopup_email2_xpath);
            Assert.AreEqual(Username, Useremail_UI);
        }


    }
}
