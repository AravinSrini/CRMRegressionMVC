using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class CarrierWebsiteLogins_BackButtonSteps : MaintenaceTools
    {
        [Given(@"the back to maintenance tools button is visible")]
        public void GivenTheBackToMaintenanceToolsButtonIsVisible()
        {
            Report.WriteLine("Verifying the display of Back to Maintenence tools button");
            VerifyElementVisible(attributeName_id, CarrierWebsite_BackToMaintanance_Id, "Back to maintenence tools button");
        }
        
        [Given(@"I am a Operations, Station Owner or System Configuration user - (.*), (.*)")]
        public void GivenIAmAOperationsStationOwnerOrSystemConfigurationUser_(string Username, string Password)
        {
            CommonMethodsCrm crm = new CommonMethodsCrm();
            crm.LoginToCRMApplication(Username, Password);
        }

        [Given(@"I am on the Admin Carrier Website Logins page")]
        public void GivenIAmOnTheAdminCarrierWebsiteLoginsPage()
        {
            Thread.Sleep(2000);
            Report.WriteLine("Clicking on Maintanence Tools icon");
            Click(attributeName_cssselector, MaintenanceToolIcon_css);
            Report.WriteLine("Clicking on Carrier website button");
            scrollElementIntoView(attributeName_id, CarrierWebsite_Button_Id);
            Click(attributeName_id, CarrierWebsite_Button_Id);
            WaitForElementVisible(attributeName_xpath, CarrierWebsite_Title_Xpath, "Carrier Website Page Header");
            Report.WriteLine("Verifying carrier website login page");
            Verifytext(attributeName_xpath, CarrierWebsite_Title_Xpath, "Admin Carrier Website Logins");
        }

        [When(@"I am on the non admin Carrier Website Logins page")]
        public void WhenIAmOnTheNonAdminCarrierWebsiteLoginsPage()
        {
            Report.WriteLine("Clicking on TMS launch icon");
            Click(attributeName_cssselector, TMS_Launch_Icon_css);
            Report.WriteLine("Clicking on Carrier website link");
            Click(attributeName_xpath, CarrierWebsite_TMSLink_Xpath);
        }

        [When(@"I click the back to maintenance tools button")]
        public void WhenIClickTheBackToMaintenanceToolsButton()
        {
            Report.WriteLine("Verify the click functionality for back to maintenance button");
            Click(attributeName_id, CarrierWebsite_BackToMaintanance_Id);
        }
        
        [Then(@"I will return to the maintenance tools page\.")]
        public void ThenIWillReturnToTheMaintenanceToolsPage_()
        {
            Report.WriteLine("Verify the navigation funcitonality to Maintenance tool page");
            Verifytext(attributeName_cssselector, MaintenanceToolsgpageTitle_css, "Maintenance Tools");
        }
        
        [Then(@"I will not see back to maintenance tools button\.")]
        public void ThenIWillNotSeeBackToMaintenanceToolsButton_()
        {
            Report.WriteLine("Verifying the display of Back to Maintenence tools button");
            VerifyElementNotPresent(attributeName_id, CarrierWebsite_BackToMaintanance_Id, "Back to maintenence tools button");
            Report.WriteLine("Back to Maintenence tools button is not displaying for non admin internal users");
        }
    }
}
