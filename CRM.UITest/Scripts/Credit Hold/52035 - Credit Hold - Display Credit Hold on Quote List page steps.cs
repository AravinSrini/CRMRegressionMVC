using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold.Display_Credit_Hold_Verbiage
{
    [Binding]
    public sealed class _52035___Credit_Hold___Display_Credit_Hold_Verbiage_on_Quote_List_pages_steps : Quotelist
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"that I am a sales sales management operation or station owner user ""(.*)"" ""(.*)""")]
        [Given(@"I am a shp.inquiry shp.inquirynorates shp.entry or shp.entrynorates user associated with a customer on Credit Hold ""(.*)"" ""(.*)""")]
        [Given(@"I am a shp.inquiry or shp.entry user who is associated with a customer on Credit Hold ""(.*)"" ""(.*)""")]
        [Given(@"I am a shp.inquiry shp.inquirynorates shp.entry or shp.entrynorates user associated with a customer not on Credit Hold ""(.*)"" ""(.*)""")]
        [Given(@"I am a shp.inquiry or shp.entry user who is associated with a customer not on Credit Hold ""(.*)"" ""(.*)""")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryOrShp_EntrynoratesUser(string username, string password)
        {
            string Username = ConfigurationManager.AppSettings[username].ToString();
            string Password = ConfigurationManager.AppSettings[password].ToString();

            Report.WriteLine("Logging in to CRM as crmoperation");
            CrmLogin.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I Navigate to the Quote List page")]
        [When(@"I arrive on the Quote List page")]
        [When(@"I Navigate to the Quote List page")]
        public void WhenIArriveOnTheQuoteListPage()
        {
            CloseCreditHoldWarningPopUp closeCreditHoldWarning = new CloseCreditHoldWarningPopUp();

            closeCreditHoldWarning.CloseCreditHoldPopUp();

            Report.WriteLine("Navigating to the Quote List page");
            Click(attributeName_xpath, Deshboard_QuoteText_xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
        }        

        [Given(@"I've selected a customer that is on Credit Hold from the quote customer drop down list ""(.*)""")]
        [When(@"I choose a quote customer that is on Credit Hold ""(.*)""")]
        [When(@"I choose a customer that is not on Credit Hold from the quote customer drop down list ""(.*)""")]
        [When(@"I choose no customer from the quote customer drop down list ""(.*)""")]
        public void WhenISelectACustomerThatIsOnCreditHold(string customerName)
        {
            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);
            try
            {
                SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, customerName);
            }
            catch (ArgumentOutOfRangeException)
            {
                Report.WriteLine("Customer does not exist in the customer list");
                Assert.Fail();
            }
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"The verbiage Account currently on credit hold will be displayed beneath the Quotes List label on the Quote List Page")]
        public void ThenIWillSeeTheVerbiageAccountCurrentlyOnCreditHoldDisplayedBeneathTheQuotesLabel()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementVisible(attributeName_id, "CreditHoldAccount", "Quote List verbiage");
        }

        [Then(@"I will no longer see the verbiage Account currently on credit hold displayed beneath the Quotes label on the Quote List Page")]
        [Then(@"I will not see the verbiage Account currently on credit hold displayed beneath the Quotes label on the Quote List Page")]
        public void ThenIWillNoLongerSeeTheVerbiageAccountCurrentlyOnCreditHoldDisplayedBeneathTheQuotesLabel()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementNotVisible(attributeName_id, "CreditHoldAccount", "Quote List verbiage");
        }

        [Then(@"The verbiage Account currently on credit hold will not be present beneath the Quotes label on the Quote List Page")]
        public void ThenTheVerbiageAccountCurrentlyOnCreditHoldWillNotBePresentBeneathTheQuotesLabelOnTheQuoteListPage()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementNotPresent(attributeName_id, "CreditHoldAccount", "Quote List verbiage");
        }
    }
}