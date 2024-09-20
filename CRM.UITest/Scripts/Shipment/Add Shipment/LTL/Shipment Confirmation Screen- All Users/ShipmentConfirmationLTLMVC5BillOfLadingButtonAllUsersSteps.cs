using System;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest
{
    [Binding]
    public class ShipmentConfirmationLTLMVC5BillOfLadingButtonAllUsersSteps :AddShipments
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
         AddShipmentLTL ltl = new AddShipmentLTL();
   
        [Given(@"I am a shp\.entry, shp\.entrynorates, operations, sales, sales management,  or station user (.*) (.*)")]
        public void GivenIAmAShp_EntryShp_EntrynoratesOperationsSalesSalesManagementOrStationUser(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }
        
            
        [When(@"I click on Email Bill of Lading option")]
        public void WhenIClickOnEmailBillOfLadingOption()
        {
            Report.WriteLine("click on Email Bill of Lading option");
            Click(attributeName_xpath, confirmation_EmailBOL_xpath);
            
        }


        [When(@"I select the Email Bill of Lading option from BOL options")]
        public void WhenISelectTheEmailBillOfLadingOptionFromBOLOptions()
        {
            Report.WriteLine("Click on View BOL option");
            scrollpagedown();
            Click(attributeName_xpath, confirmation_BOLbutton);
            Click(attributeName_xpath, confirmation_EmailBOL_xpath);
        }


        [When(@"I am on  Email Bill of Lading modal")]
        public void WhenIAmOnEmailBillOfLadingModal()
        {
            Report.WriteLine("Click on View BOL option");
            scrollpagedown();
            Click(attributeName_xpath, confirmation_BOLbutton);
            Click(attributeName_xpath, confirmation_EmailBOL_xpath);
        }
        
        [When(@"I click on Add Additional Email button")]
        public void WhenIClickOnAddAdditionalEmailButton()
        {
            Report.WriteLine("click on Add Additional Email button");
            Thread.Sleep(300);
            MoveToElement(attributeName_id, Emailmodal_additionalemailbutton);
            Click(attributeName_id, Emailmodal_additionalemailbutton);
        }
        
        [When(@"I click on remove button")]
        public void WhenIClickOnRemoveButton()
        {
            Report.WriteLine("click on Add Additional Email button");
            Click(attributeName_xpath, Emailmodal_additionalRemove1);
        }
        
        [When(@"I enter invalid email '(.*)' on Email Bill of Lading modal")]
        public void WhenIEnterInvalidEmailOnEmailBillOfLadingModal(string email)
        {
            Report.WriteLine("EnterInvalidEmailOnEmailBillOfLadingModal");
            Thread.Sleep(500);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);
        }
        
        [When(@"I enter invalid email '(.*)' in additional email text box")]
        public void WhenIEnterInvalidEmailInAdditionalEmailTextBox(string email2)
        {
            Report.WriteLine("EnterInvalidEmailOnEmailBillOfLadingModal");
            Click(attributeName_id, Emailmodal_additionalemailbutton);
            Thread.Sleep(500);
            SendKeys(attributeName_xpath, Emailmodal_additionalemailtextbox1, email2);
        }
        
        [When(@"I keep email text box and additional email text box keep blank on Email Bill of Lading modal")]
        public void WhenIKeepEmailTextBoxAndAdditionalEmailTextBoxKeepBlankOnEmailBillOfLadingModal()
        {
            Report.WriteLine("EnterInvalidEmailOnEmailBillOfLadingModal");
            Clear(attributeName_id, Emailmodal_emailtextbox_id);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id,"");
            Clear(attributeName_xpath, Emailmodal_additionalemailtextbox1);
            SendKeys(attributeName_xpath, Emailmodal_additionalemailtextbox1, "");
        }

        [When(@"I entered all required information '(.*)','(.*)' on Email Bill of Lading modal")]
        public void WhenIEnteredAllRequiredInformationOnEmailBillOfLadingModal(string email, string email1)
        {
            Report.WriteLine("entered all required information on Email Bill of Lading modal");
            Thread.Sleep(500);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);
            Click(attributeName_id, Emailmodal_additionalemailbutton);
            SendKeys(attributeName_xpath, Emailmodal_additionalemailtextbox1, email1);
        }

        
        [When(@"I click on the Send Email button")]
        public void WhenIClickOnTheSendEmailButton()
        {
            Report.WriteLine("click on the Send Email button");
            Click(attributeName_id, Emailmodal_sendemail_id);
        }
        
        [When(@"I entered all required information, unchecked the copy check box on  Email Bill of Lading modal '(.*)'")]
        public void WhenIEnteredAllRequiredInformationUncheckedTheCopyCheckBoxOnEmailBillOfLadingModal(string email)
        {
            Report.WriteLine("entered all required information on Email Bill of Lading modal");
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);
            Click(attributeName_xpath, Emailmodal_sendcopycheck_xpath);
        }
        
        [Then(@"I should display with (.*)")]
        public void ThenIShouldDisplayWith(string twoptions)
        {
            Report.WriteLine("DisplayWith two options");
            string[] values = twoptions.Split(',');
            scrollpagedown();            
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(confirmation_BOLdropvalues));
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
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    
                }
            }

        }

        [Then(@"I should display cancel and send email options")]
        public void ThenIShouldDisplayCancelAndSendEmailOptions()
        {
            Report.WriteLine("displayed with CancelAndSendEmailOptions");
            VerifyElementVisible(attributeName_id, Emailmodal_cancel_id, "cancel");
            VerifyElementVisible(attributeName_id, Emailmodal_sendemail_id, "sendemail");

        }

        [Then(@"I should be displayed with Email Bill of Lading modal")]
        public void ThenIShouldBeDisplayedWithEmailBillOfLadingModal()
        {
            Report.WriteLine("displayed with Email Bill of Lading modal");
            VerifyElementVisible(attributeName_xpath, EmailmodalPopup_xpath, "modal");

        }
        
        [Then(@"I should be displayed with email address text box and add additional email addresses link")]
        public void ThenIShouldBeDisplayedWithEmailAddressTextBoxAndAddAdditionalEmailAddressesLink()
        {
            Report.WriteLine("email address text box and add additional email addresses link");
            VerifyElementVisible(attributeName_id, Emailmodal_emailtextbox_id, "emailtextbox");
            VerifyElementVisible(attributeName_id, Emailmodal_additionalemailbutton, "additionalemail");
        }
        
        [Then(@"Additional Email text box should be removed")]
        public void ThenAdditionalEmailTextBoxShouldBeRemoved()
        {
            Report.WriteLine("Additional Email text box should be removed");
            Thread.Sleep(400);
            VerifyElementNotPresent(attributeName_xpath, Emailmodal_additionalemailtextbox1, "emailtextbox");
        }
        [When(@"I click on cancel button on email modal")]
        public void WhenIClickOnCancelButtonOnEmailModal()
        {
            Report.WriteLine("ClickOnCancelButtonOnEmailModal");
            Click(attributeName_id, Emailmodal_cancel_id);
        }


        [Then(@"I should be returned to the Shipment Confirmation \(LTL\) page")]
        public void ThenIShouldBeReturnedToTheShipmentConfirmationLTLPage()
        {
            Report.WriteLine("returned to the Shipment Confirmation page");
            VerifyElementVisible(attributeName_xpath,confirmation_pageheader,"confirmationpage");
        }
        
        [Then(@"email text boxes should be highlighted and displayed with error message for invalid '(.*)'")]
        public void ThenEmailTextBoxesShouldBeHighlightedAndDisplayedWithErrorMessageForInvalid(string message)
        {
            Report.WriteLine("displayed with error message for invalid");
            Verifytext(attributeName_xpath, Emailmodal_errorforinvalid_xpath, message);

            var colorofemail = GetCSSValue(attributeName_id, Emailmodal_emailtextbox_id, "background");
            var coloroftheextraemail = GetCSSValue(attributeName_xpath, Emailmodal_additionalemailtextbox1, "background");
            if (colorofemail.Contains("rgb(251, 236, 236)") && coloroftheextraemail.Contains("rgb(251, 236, 236)"))
            {
                Report.WriteLine("email text boxes should be highlighted");

            }

            else
            {
                throw new Exception("failed the validation");


            }

        }

        [Then(@"email text boxes should be highlighted and displayed with error message for empty scenario'(.*)'")]
        public void ThenEmailTextBoxesShouldBeHighlightedAndDisplayedWithErrorMessageForEmptyScenario(string message1)
        {
            Report.WriteLine("displayed with error message for empty");
            Verifytext(attributeName_xpath, Emailmodal_errorformandatory_xpath, message1);

            var colorofemail = GetCSSValue(attributeName_id, Emailmodal_emailtextbox_id, "background");
            var coloroftheextraemail = GetCSSValue(attributeName_xpath, Emailmodal_additionalemailtextbox1, "background");
            if (colorofemail.Contains("rgb(251, 236, 236)") && coloroftheextraemail.Contains("rgb(251, 236, 236)"))
            {
                Report.WriteLine("email text boxes should be highlighted");

            }

            else
            {
                throw new Exception("failed the validation");


            }
        }
        
        [Then(@"The modal will be closed")]
        public void ThenTheModalWillBeClosed()
        {
            Report.WriteLine("The modal will be closed");
            VerifyElementNotVisible(attributeName_xpath, EmailmodalPopup_xpath, "modal");

        }


        [Then(@"pass '(.*)' value in email text box")]
        public void ThenPassValueInEmailTextBox(string email)
        {
            Report.WriteLine("PassValueInEmailTextBox");
            Thread.Sleep(500);
            SendKeys(attributeName_id, Emailmodal_emailtextbox_id, email);
        }

        [Then(@"I will receive a confirmation popup with email passed '(.*)' not the created user email")]
        public void ThenIWillReceiveAConfirmationPopupWithEmailPassedNotTheCreatedUserEmail(string email)
        {
            Report.WriteLine("will receive a confirmation popup");
            VerifyElementVisible(attributeName_xpath, Confimrationpopup_emails_xpath, "modal");
            Verifytext(attributeName_xpath, Confimrationpopup_email1_xpath, email);
            VerifyElementNotVisible(attributeName_xpath, Confimrationpopup_email2_xpath, "createduser");
        }

        [Then(@"I will receive a confirmation popup with email passed '(.*)','(.*)'")]
        public void ThenIWillReceiveAConfirmationPopupWithEmailPassed(string email, string email1)
        {
            Report.WriteLine("will receive a confirmation popup");
            Thread.Sleep(500);
            VerifyElementVisible(attributeName_xpath, Confimrationpopup_emails_xpath, "modal");
            Verifytext(attributeName_xpath, Confimrationpopup_emails_xpath, "Your email has been sent to the following addresses successfully");
            Verifytext(attributeName_xpath, Confimrationpopup_email1_xpath, email);
            Verifytext(attributeName_xpath, Confimrationpopup_email2_xpath, email1);
        }
               
    }
}
