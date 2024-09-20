using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using OpenQA.Selenium.Interactions;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL
{
    [Binding]
    public class Quote_InsuredValue_TermsAndConditionsModal_ShouldNotCloseOnClickingOutside: AddShipments
    {
        public string termsAndConditionPopup_Title;

        [Given(@"I am a DLS user and Login to application as a user with access to Quotes")]
        public void GivenIAmADLSUserAndLoginToApplicationAsAUserWithAccessToQuotes()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("User logged into CRM application");
        }

        [Given(@"I am on Get Quote LTL page")]
        public void GivenIAmOnGetQuoteLTLPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicked on Quotes icon");
            WaitForElementVisible(attributeName_xpath, QuoteIcon_Xpath, "Quote Icon");
            Click(attributeName_xpath, QuoteIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on Submit Rate Request button");
            WaitForElementVisible(attributeName_id, SubmitRateRequestBtn_id, "Submit Quote");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_id, SubmitRateRequestBtn_id);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Clicked on LTL tile");
            Click(attributeName_id, GetQuote_Ltlimage_id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on Quote Results LTL page")]
        public void GivenIAmOnQuoteResultsLTLPage()
        {
            Report.WriteLine("Clicked on View Quote Results button");
            Click(attributeName_id, LTL_ViewQuoteResults_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I enter a value in Enter Insured Value field (.*)")]
        public void GivenIEnterAValueInEnterInsuredValueField(string insuredValue)
        {
            Report.WriteLine("Entered a valid data in Enter Insured Value field");
            SendKeys(attributeName_xpath, ltlEnterInsuredValueTextbox_xpath, insuredValue);
        }

        [Given(@"I Click on Terms and Conditions link")]
        public void GivenIClickOnTermsAndConditionsLink()
        {
            Report.WriteLine("Cliked on Terms and Conditions link");
            Click(attributeName_xpath, LTL_TermsAndConditions_Results_xpath);

            VerifyElementPresent(attributeName_xpath, LTL_TermsAndConditionPopupTitle_Xpath, "Terms And Conditions Of Coverage");
            Report.WriteLine("Terms and Conditions pop up displays");
        }

        [When(@"I Click anywhere outside the Terms and Conditions pop up")]
        public void WhenIClickAnywhereOutsideTheTermsAndConditionsPopUp()
        {
            Report.WriteLine("Click anywhere outside the pop up");
            Click(attributeName_xpath, LTL_TermsAndConditionOverlayGetQuote_Xpath);
        }

        [When(@"I click anywhere outside the Terms and Conditions Popup")]
        public void WhenIClickAnywhereOutsideTheTermsAndConditionsPopup()
        {
            Report.WriteLine("Click anywhere outside the pop up");
            Click(attributeName_xpath, LTL_TermsAndConditionOverlayQuoteResults_Xpath);
        }

        [Then(@"Terms and Conditions pop up should not close")]
        public void ThenTermsAndConditionsPopUpShouldNotClose()
        {
            termsAndConditionPopup_Title = Gettext(attributeName_xpath, LTL_TermsAndConditionPopupTitle_Xpath);

            if (termsAndConditionPopup_Title.Contains("Terms And Conditions Of Coverage"))
            {
                Report.WriteLine("Terms and Conditions pop displays");
            }
            else
            {
                Report.WriteFailure("Terms and Conditions pop up is closed");
            }
        }
    }
}
