using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaimsUserAccesstoModuleSteps : InsuranceClaim
    {

        [Given(@"I am Shipment Entry User with Access to Claims Module")]
        public void GivenIAmShipmentEntryUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Shipment Entry No Rates User with Access to Claims Module")]
        public void GivenIAmShipmentEntryNoRatesUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["username-EntrynoratesCrmdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-EntrynoratesCrmdelta"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Shipment Inquiry User with Access to Claims Module")]
        public void GivenIAmShipmentInquiryUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["username-shpInquiry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shpInquiry"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Shipment Inquiry No Rates User with Access to Claims Module")]
        public void GivenIAmShipmentInquiryNoRatesUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["username-ShpInqnorts"].ToString();
            string password = ConfigurationManager.AppSettings["password-ShpInqnorts"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Sales User with Access to Claims Module")]
        public void GivenIAmSalesUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["username-salesdelta"].ToString();
            string password = ConfigurationManager.AppSettings["password-salesdelta"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Sales Management User with Access to Claims Module")]
        public void GivenIAmSalesManagementUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["username-SalesManager"].ToString();
            string password = ConfigurationManager.AppSettings["password-SalesManager"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Station Owner User with Access to Claims Module")]
        public void GivenIAmStationOwnerUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["InternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["InternalUserPassword"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [Given(@"I am Operations User with Access to Claims Module")]
        public void GivenIAmOperationsUserWithAccessToClaimsModule()
        {
            string username = ConfigurationManager.AppSettings["username-OpStage"].ToString();
            string password = ConfigurationManager.AppSettings["password-OpStage"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I log in to CRM")]
        public void WhenILogInToCRM()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
        }
        
        [When(@"I MouseOver on the Claims icon")]
        public void WhenIMouseOverOnTheClaimsIcon()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            OnMouseOver(attributeName_id, ClaimsIcon_Id);
        }
        
        [Then(@"I will able to see Claims icon in the Navigation Panel")]
        public void ThenIWillAbleToSeeClaimsIconInTheNavigationPanel()
        {
            Report.WriteLine("Verifying the presence of Claims Icon");
            VerifyElementPresent(attributeName_id, ClaimsIcon_Id, "Claims Icon");
        }
        
        [Then(@"I will be able to read the verbiage Claims")]
        public void ThenIWillBeAbleToReadTheVerbiageClaims()
        {
            Report.WriteLine("Verifying the text Claims on Mouse over of Claims Icon");
            Verifytext(attributeName_xpath, ClaimsIcon_Text_Xpath, "Claims");
        }
        
        [When(@"I clicked on the Claims icon")]
        public void WhenIClickedOnTheClaimsIcon()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Clicking on the Claims Icon");
            Click(attributeName_id, ClaimsIcon_Id);
        }

        [Then(@"I will be navigated to Claims List page")]
        public void ThenIWillBeNavigatedToClaimsListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            Report.WriteLine("Verifying User navigated to Claims List page");
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

    }
}
