using System;
using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;

namespace CRM.UITest.Scripts.Credit_Hold
{
    [Binding]
    public class CreditHold_AccessingQuoteAndShipmentPages_LTLServicesSteps : ObjectRepository
    {

        IWebDriver driver = GlobalVariables.webDriver;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string actualText = null;
        string expectedText = null;


        [Given(@"I am a Credit Hold customer")]
        public void GivenIAmACreditHoldCustomer()
        {
            string userName = ConfigurationManager.AppSettings["username-ExternalCredithold"].ToString();
            string password = ConfigurationManager.AppSettings["password-ExternalCredithold"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }


        [Given(@"I am a sales management, operations, or station owner user")]
        public void GivenIAmASalesManagementOperationsOrStationOwnerUser()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [When(@"I am on Get Quote LTL page")]
        public void WhenIAmOnGetQuoteLTLPage()
        {
            Report.WriteLine("Handling credit hold popup in dashboard");
            Click(attributeName_id, Dashboard_CreditHoldpopupOK_Button_Id);
            Report.WriteLine("Navigating to GetQuote page by sending GetQuote page url");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Rate/ShipmentInformation");
        }

        [Given(@"I am on the GetQuote LTL page")]
        public void GivenIAmOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Handling credit hold popup in dashboard");
            Click(attributeName_id, Dashboard_CreditHoldpopupOK_Button_Id);
            Report.WriteLine("Navigating to GetQuote page by sending GetQuote page url");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Rate/ShipmentInformation");
        }

        [Given(@"I received the Credit Hold modal")]
        public void GivenIReceivedTheCreditHoldModal()
        {
            Report.WriteLine("credit hold modal");
            VerifyElementPresent(attributeName_xpath, GetQuotePage_CreditholdModalPopup_Xpath, "Credit Hold");
        }

        [Given(@"I received the Credit Hold modal in Get Quote page")]
        public void GivenIReceivedTheCreditHoldModalInGetQuotePage()
        {
            Report.WriteLine("credit hold modal");
            VerifyElementPresent(attributeName_xpath, GetQuotePage_CreditholdModalPopup_Xpath, "Credit Hold");
        }


        [Given(@"I received the Credit Hold modal in Add Shipment page")]
        public void GivenIReceivedTheCreditHoldModalInAddShipmentPage()
        {
            Report.WriteLine("credit hold modal from Add Shipment page");
            VerifyElementPresent(attributeName_xpath, AddShipment_CreditholdModalPopup_Xpath, "Credit Hold");
        }

        [Given(@"I am sending a credit hold customer name along with page url")]
        public void GivenIAmSendingACreditHoldCustomerNameAlongWithPageUrl()
        {

            Report.WriteLine("Navigate to Quote tiles page");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Rate/StationRateIndex?customerName=july7&tmsType=BOTH");

        }

        [Given(@"I arrive on the Get Quote LTL page")]
        public void GivenIArriveOnTheGetQuoteLTLPage()
        {
            Report.WriteLine("Click on LTL tile");
            driver.WaitForPageLoad();
            Click(attributeName_id, LTL_TileLabel_Id);
        }

        [Given(@"I am on Add Shipment LTL page")]
        public void GivenIAmOnAddShipmentLTLPage()
        {
            Report.WriteLine("Add Shipment page");
            Verifytext(attributeName_xpath, CopyAddShipmentTitle_Xpath, "Add Shipment (LTL)");
        }

        [Given(@"I am on the Add Shipment LTL page")]
        public void GivenIAmOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Handling credit hold popup in dashboard");
            Click(attributeName_id, Dashboard_CreditHoldpopupOK_Button_Id);
            Report.WriteLine("Navigate to Add Shipment page by sending Add Shipment page url");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Shipment/AddShipment?mode=LTL");
        }


        [When(@"I arrive on the Get Quote LTL page")]
        public void WhenIArriveOnTheGetQuoteLTLPage()
        {
           
            Report.WriteLine("Click on LTL tile");
            Click(attributeName_id, LTL_TileLabel_Id);
        }

        [When(@"I click on the OK button in the Credit Hold modal")]
        public void WhenIClickOnTheOKButtonInTheCreditHoldModal()
        {
            Report.WriteLine("Clicking on OK button from credit hold modal from Add Shipment page");
            Click(attributeName_id, AddShipment_CreditHoldModalpopupOK_Button_Id);
        }

        [When(@"I click on OK button in the Credit Hold modal")]
        public void WhenIClickOnOKButtonInTheCreditHoldModal()
        {
            Click(attributeName_id, GetQuote_CreditHoldModalpopupOK_Button_Id);
        }


        [When(@"arrive on the Add Shipment LTL page")]
        public void WhenArriveOnTheAddShipmentLTLPage()
        {
            Report.WriteLine("Handling credit hold popup in dashboard");
            Click(attributeName_id, Dashboard_CreditHoldpopupOK_Button_Id);
            Report.WriteLine("Navigate to AddShipment page by sending the Add Shipment page url");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Shipment/AddShipment?mode=LTL");
        }


        [Then(@"I will see a message in the modal")]
        public void ThenIWillSeeAMessageInTheModal()
        {
            Report.WriteLine("Verify the credit hold modal message from Get Quote page");
            expectedText = Gettext(attributeName_xpath, GetQuotePage_CreditHoldmodalMessage_Xpath);
            actualText = "Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.";
            Assert.AreEqual(expectedText, actualText);

        }

        [Then(@"I will see a message in the modal from Add Shipment page")]
        public void ThenIWillSeeAMessageInTheModalFromAddShipmentPage()
        {
            Report.WriteLine("Verify the credit hold modal message from Get Quote page");
            expectedText = Gettext(attributeName_xpath, AddShipment_CreditHoldpopupMessage_Xpath);
            actualText = "Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.";
            Assert.AreEqual(expectedText, actualText);
        }


        [Then(@"I will see a message in credit hold modal")]
        public void ThenIWillSeeAMessageInCreditHoldModal()
        {
            Report.WriteLine("Verify the credit hold modal message from Add Shipment page");
            expectedText = Gettext(attributeName_xpath, AddShipment_CreditHoldpopupMessage_Xpath);
            actualText = "Your account has been placed on Credit Hold. To create a Quote or Shipment, please contact your DLSW representative.";
            Assert.AreEqual(expectedText, actualText);
        }

        [When(@"I click on the OK button in the Credit Hold modal from Add Shipment page")]
        public void WhenIClickOnTheOKButtonInTheCreditHoldModalFromAddShipmentPage()
        {
            Report.WriteLine("Click on OK button from credit hold modal in Add shipment page");
            Click(attributeName_id, AddShipment_CreditHoldModalpopupOK_Button_Id);
        }

        [Given(@"I am sending a credit hold customer name along with the page url")]
        public void GivenIAmSendingACreditHoldCustomerNameAlongWithThePageUrl()
        {
            Report.WriteLine("Navigating to Tiles page");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Shipment/AddShipment?mode=LTL&selectedCustomerName=july7");
        }

        [When(@"I click on the OK button in Credit Hold modal")]
        public void WhenIClickOnTheOKButtonInCreditHoldModal()
        {
            Report.WriteLine("Click on OK button from credit hold modal in Add shipment page");
            Click(attributeName_id, AddShipment_CreditHoldModalpopupOK_Button_Id);

        }


        [Then(@"I have the option to close the credit hold modal")]
        public void ThenIHaveTheOptionToCloseTheCreditHoldModal()
        {
            Report.WriteLine("Verify if the OK button is present in credit hold modal in Add Shipment page");
            VerifyElementPresent(attributeName_id, AddShipment_CreditHoldModalpopupOK_Button_Id, "OK");
        }


        [Then(@"I have the option to close the modal")]
        public void ThenIHaveTheOptionToCloseTheModal()
        {
            Report.WriteLine("Verify the OK button from credit hold modal in Add Shipment page");
            IsElementPresent(attributeName_id, AddShipment_CreditHoldModalpopupOK_Button_Id, "OK");
        }

        [Then(@"I will arrive on the Quote List page")]
        public void ThenIWillArriveOnTheQuoteListPage()
        {
            Verifytext(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quotes");
            string currentUrl = driver.Url;
            string expectedUrl = "http://dlscrm-test.rrd.com//Rate/RateList";
            Assert.AreEqual(currentUrl, expectedUrl);
        }

        [Then(@"I arrive on the QuoteList page")]
        public void ThenIArriveOnTheQuoteListPage()
        {
            Verifytext(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quotes");
            string currentUrl = driver.Url;
            string expectedUrl = "http://dlscrm-test.rrd.com/Rate/GetQuoteListByCustomer?customerName=zzz-webservice";
            Assert.AreEqual(currentUrl, expectedUrl);
        }


        [Given(@"I am sending a credit hold customer name along with the Add Shipment page url")]
        public void GivenIAmSendingACreditHoldCustomerNameAlongWithTheAddShipmentPageUrl()
        {
            Report.WriteLine("Navigating to Tiles page");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Rate/StationRateIndex?customerName=july7&tmsType=MG");
        }

      
        [Given(@"I am on ShipmentList page")]
        public void GivenIAmOnShipmentListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on shipment icon");
            Click(attributeName_xpath, ShipmentModule_Xpath);
        }

        [When(@"I am sending a credit hold customer name along with the page url")]
        public void WhenIAmSendingACreditHoldCustomerNameAlongWithThePageUrl()
        {
            Report.WriteLine("Navigating to Tiles page");
            driver.Navigate().GoToUrl("http://dlscrm-test.rrd.com/Shipment/AddShipment?mode=LTL&selectedCustomerName=july7");
        }


        [Then(@"I will arrive on the Shipment List page")]
        public void ThenIWillArriveOnTheShipmentListPage()
        {
            Report.WriteLine("Arrive on Shhipment List page");
            Verifytext(attributeName_xpath, ShipmentList_PageTitle_Xpath, "Shipment List");
            string currentUrl = driver.Url;
            string expectedUrl = "http://dlscrm-test.rrd.com/Shipment/ShipmentListForExternalUser?customerName=5MI38bChKKpe3TV7D36T2Q%3D%3D";
            Assert.AreEqual(currentUrl, expectedUrl);
        }

        [Then(@"I will see a Credit Hold modal")]
        public void ThenIWillSeeACreditHoldModal()
        {
            VerifyElementPresent(attributeName_xpath, GetQuotePage_CreditholdModalPopup_Xpath, "Credit Hold");
        }

        [Then(@"I will see a Credit Hold modal in Add Shipment page")]
        public void ThenIWillSeeACreditHoldModalInAddShipmentPage()
        {
            driver.WaitForPageLoad();
            VerifyElementPresent(attributeName_xpath, AddShipment_CreditholdModalPopup_Xpath, "Credit Hold");
        }

        [Then(@"I will arrive on Shipment List page")]
        public void ThenIWillArriveOnShipmentListPage()
        {
            Report.WriteLine("Arrive on Shhipment List page");
            Verifytext(attributeName_xpath, ShipmentList_PageTitle_Xpath, "Shipment List");
            string currentUrl = driver.Url;
            string expectedUrl = "http://dlscrm-test.rrd.com//Shipment/ShipmentList";
            Assert.AreEqual(currentUrl, expectedUrl);
        }

    }
}
