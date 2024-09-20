using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class _51328_CreditHold_UserLogin_steps : ObjectRepository
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am a shp\.inquiry, shp\.entrynorates or shp\.entry user associated to a customer that is on Credit Hold")]
        public void GivenIAmAShp_InquiryShp_EntrynoratesOrShp_EntryUserAssociatedToACustomerThatIsOnCreditHold()
        {
            string userName = ConfigurationManager.AppSettings["username-CreditHoldShipEntry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CreditHoldShipEntry"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user associated to a customer that is on Credit Hold");
        }

        [When(@"I successfully login to CRM")]
        public void WhenISuccessfullyLoginToCRM()
        {
            Report.WriteLine("User successfully logged into CRM");
            string configURL = launchUrl;
            string dashboardPagrURL = configURL + "L/Dashboard/Index";
            Assert.AreEqual(GetURL(), dashboardPagrURL);
        }


        [Then(@"I Will Receive A Message In a Modal ""(.*)""")]
        public void ThenIWillReceiveAMessageInAModal(string creditHoldMessage)
        {
            Report.WriteLine("Verifying Credit Hold modal pop message");
            VerifyElementVisible(attributeName_xpath, CreditHold_ModalTitle_Xpath, "Credit Hold");
            Verifytext(attributeName_xpath, CreditHold_ModalMessage_Xpath, creditHoldMessage);
        }

        [Then(@"I Will See An OK Button")]
        public void ThenIWillSeeAnOKButton()
        {
            Report.WriteLine("Verifying Credit Hold modal OK button");
            VerifyElementPresent(attributeName_id, CreditHold_OKButton_Id, "OK");
        }


        [Given(@"I successfully logged in to CRM")]
        public void GivenISuccessfullyLoggedInToCRM()
        {
            Report.WriteLine("User successfully logged into CRM");
            string configURL = launchUrl;
            string dashboardPagrURL = configURL + "L/Dashboard/Index";            
        }

        [When(@"I click on the OK button from the Credit Hold modal")]
        public void WhenIClickOnTheOKButtonFromTheCreditHoldModal()
        {
            Click(attributeName_id, CreditHold_OKButton_Id);
            Thread.Sleep(3000);
        }

        [Then(@"The Credit Hold modal will close")]
        public void ThenTheCreditHoldModalWillClose()
        {    
            VerifyElementNotVisible(attributeName_xpath, CreditHold_ModalTitle_Xpath, "Credit Hold");
            Report.WriteLine("Verified Credit hold modal is closed");
        }

        [Given(@"I am a shp\.inquiry, shp\.entrynorates or shp\.entry user associated to a Non-Credit Hold customer")]
        public void GivenIAmAShp_InquiryShp_EntrynoratesOrShp_EntryUserAssociatedToANon_CreditHoldCustomer()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I logged into CRM application with external user credentials");
        }

        [Then(@"I will not be presented with Credit Hold modal")]
        public void ThenIWillNotBePresentedWithCreditHoldModal()
        {   
            bool checkCreditHoldPopUp = GlobalVariables.webDriver.FindElement(By.XPath(CreditHold_ModalTitle_Xpath)).Displayed;
            Assert.IsFalse(checkCreditHoldPopUp);
            Report.WriteLine("Verified Credit hold modal is closed");
        }

    }
}
