using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using Rrd.Dls.IdentityServer.Core.Dto;
using CRM.UITest.Entities;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public class BuildResponsiveNavigationSteps_Desktop : ObjectRepository
    {

        [Given(@"I am landing on DLS Worldwide homepage")]
        public void GivenIAmLandingOnDLSWorldwideHomepage()
        {
            Report.WriteLine("Landing on DLS Worldwide Legacy Homepage");
            //WaitForElementVisible(attributeName_cssselector, DLSWorldwideimage_css, "DLSWorldwide");
            VerifyElementPresent(attributeName_xpath, DashboardHeaderlogo_Xpath, "DLSWorldwide");
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_xpath, DashboardHeaderlogo_Xpath, "alt");
            Assert.AreEqual("DLS Worldwide", logohastext);
        }

        [Given(@"I am landing on the signin homepage with DLS Worldwide logo")]
        public void GivenIAmLandingOnTheSigninHomepageWithDLSWorldwideLogo()
        {
            //Logo changed to customized 
            Report.WriteLine("Landing on the DLS Worldwide Homepage");
            VerifyElementPresent(attributeName_xpath, HomepageHeaderlogo_Xpath, "RRDLogo");
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_tagname, "img", "alt");
            Assert.AreEqual("DLS Worldwide", logohastext);
        }


        [Given(@"I must see the '(.*)' in the logo")]
        public void GivenIMustSeeTheInTheLogo(string DLSWorldwidetext)
        {
            Report.WriteLine("Verify DLS Worldwide in logo");
            string logohastext = GetAttribute(attributeName_tagname, "img", "alt");
            Assert.AreEqual(DLSWorldwidetext, logohastext);
        }

        [When(@"I should see Dashboard icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeDashboardIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Dashboard icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var DashboardhasClaim_TableauReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauReport");
            var DashboardhasClaim_ViewCommissionReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewCommissionReport");
            var DashboardhasClaim_UsersManageAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManageAll");
            var DashboardhasClaim_Dashboard = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "Dashboard");
            var DashboardhasClaim_DashboardBasic = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DashboardBasic");
            var DashboardhasClaim_DataEntryUser = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DataEntryUser");
            var DashboardhasClaim_ShipmentListDashboard = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ShipmentListDashboard");

            if (DashboardhasClaim_Dashboard == true || DashboardhasClaim_DashboardBasic == true || DashboardhasClaim_UsersManageAll == true || DashboardhasClaim_DataEntryUser == true || DashboardhasClaim_ShipmentListDashboard == true)
            {
                VerifyElementPresent(attributeName_cssselector, DashboardIcon_css, "Dashboard");
                Console.WriteLine("Dashboad icon is present with proper claims");
            }
            else if ((DashboardhasClaim_TableauReport == true && DashboardhasClaim_ViewCommissionReport == true ) || DashboardhasClaim_UsersManageAll == false)
            {
                VerifyElementPresent(attributeName_cssselector, DashboardIcon_css, "Dashboard");
                Console.WriteLine("Dashboad icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, DashboardIcon_css, "Dashboard");
            }
        }


		[Then(@"I click on the Dashboard Menu available in the Landing Page navigate to Dashboard landing page if '(.*)' have claim")]
        public void ThenIClickOnTheDashboardMenuAvailableInTheLandingPageNavigateToDashboardLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("Click on Dashboard Menu available in the Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var DashboardhasClaim_TableauReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauReport");
            var DashboardhasClaim_ViewCommissionReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewCommissionReport");
            var DashboardhasClaim_UsersManageAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManageAll");
            var DashboardhasClaim_Dashboard = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "Dashboard");
            var DashboardhasClaim_DashboardBasic = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DashboardBasic");
            var DashboardhasClaim_DataEntryUser = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DataEntryUser");
            var DashboardhasClaim_ShipmentListDashboard = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ShipmentListDashboard");

            if (DashboardhasClaim_Dashboard == true || DashboardhasClaim_DashboardBasic == true || DashboardhasClaim_UsersManageAll == true || DashboardhasClaim_DataEntryUser == true || DashboardhasClaim_ShipmentListDashboard == true)
            {
                VerifyElementPresent(attributeName_cssselector, DashboardIcon_css, "Dashboard");
                Console.WriteLine("Dashboad icon is present with proper claims");

                Report.WriteLine("Click on the Dashboard Menu available in the Landing Page");
                Click(attributeName_cssselector, DashboardIcon_css);

                Report.WriteLine("User should navigate to the Dashboard module");
                Verifytext(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
            }
            else if ((DashboardhasClaim_TableauReport == true && DashboardhasClaim_ViewCommissionReport == true) || DashboardhasClaim_UsersManageAll == false)
            {
                VerifyElementPresent(attributeName_cssselector, DashboardIcon_css, "Dashboard");
                Console.WriteLine("Dashboad icon is present with proper claims");

                Report.WriteLine("Click on the Dashboard Menu available in the Landing Page");
                Click(attributeName_cssselector, DashboardIcon_css);

                Report.WriteLine("User should navigate to the Dashboard module");
                Verifytext(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, DashboardIcon_css, "Dashboard");
            }
        }

        [Then(@"I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '(.*)' have claim")]
        public void ThenIClickOnTheQuotesMenuAvailableInTheLandingPageNavigateToQuotesLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("Click on Quotes Menu available in the Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var QuoteshasClaim_RateRequest = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "RateRequest");
            var QuoteshasClaim_RateRequestBasic = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "RateRequestBasic");
            var QuoteshasClaim_UsersManageAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManageAll");

            if (QuoteshasClaim_RateRequest == true || QuoteshasClaim_RateRequestBasic == true || QuoteshasClaim_UsersManageAll == true)
            {
                VerifyElementPresent(attributeName_cssselector, QuotesIcon_css, "Quotes");

                Report.WriteLine("Click on the Quotes Menu available in the Landing Page");
                Click(attributeName_cssselector, QuotesIcon_css);

                Report.WriteLine("User should navigate to the Quotes landing page");
                Verifytext(attributeName_cssselector, QuotespageHeading_css, "Quotes");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, QuotesIcon_css, "Quotes");
            }
        }

        [Then(@"I click on the Shipments Menu available in the Landing Page navigate to Shipments landing page if '(.*)' have claim")]
        public void ThenIClickOnTheShipmentsMenuAvailableInTheLandingPageNavigateToShipmentsLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Shipments icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var ShipmentshasClaim_DataEntryUser = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DataEntryUser");
            var ShipmentshasClaim_ShipmentBasic = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ShipmentBasic");
            var ShipmentshasClaim_ShipmentPrivilege = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ShipmentPrivilege");
            var ShipmentshasClaim_Shipment = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "Shipment");

            if (ShipmentshasClaim_DataEntryUser == true || ShipmentshasClaim_ShipmentBasic == true || ShipmentshasClaim_ShipmentPrivilege == true || ShipmentshasClaim_Shipment == true)
            {
                VerifyElementPresent(attributeName_cssselector, ShipmentsIcon_css, "Shipments");
                Console.WriteLine("Shipments icon is present with proper claims");

                Report.WriteLine("Click on Shipments Menu available in the Landing Page");
                Click(attributeName_cssselector, ShipmentsIcon_css);

                Report.WriteLine("User should navigate to the Shipments module");
                Verifytext(attributeName_cssselector, ShipmentspageTitle_css, "Shipment List");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, ShipmentsIcon_css, "Shipments");
            }
        }

        [When(@"I should see Quotes icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeQuotesIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            VerifyElementPresent(attributeName_cssselector, QuotesIcon_css, "Quotes");
            Report.WriteLine("Quotes icon is present with proper claims");

            //Commenting the IDP verification steps as the validation halts at this step.

            //===============================================================================================================================
            //Report.WriteLine("User should see Quotes icon in the left navigation menu of Landing Page");
            //IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            //var QuoteshasClaim_RateRequest = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "RateRequest");
            //var QuoteshasClaim_RateRequestBasic = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "RateRequestBasic");
            //var QuoteshasClaim_UsersManageAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManageAll");

            //if (QuoteshasClaim_RateRequest == true || QuoteshasClaim_RateRequestBasic == true || QuoteshasClaim_UsersManageAll == true)
            //{
            //    VerifyElementPresent(attributeName_cssselector, QuotesIcon_css, "Quotes");
            //    Console.WriteLine("Quotes icon is present with proper claims");
            //}
            //else
            //{
            //    VerifyElementNotPresent(attributeName_cssselector, QuotesIcon_css, "Quotes");
            //}
            //===============================================================================================================================
        }

        [When(@"I should see Shipments icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeShipmentsIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Shipments icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var ShipmentshasClaim_DataEntryUser = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DataEntryUser");
            var ShipmentshasClaim_ShipmentBasic = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ShipmentBasic");
            var ShipmentshasClaim_ShipmentPrivilege = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ShipmentPrivilege");
            var ShipmentshasClaim_Shipment = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "Shipment");

            if (ShipmentshasClaim_DataEntryUser == true || ShipmentshasClaim_ShipmentBasic == true || ShipmentshasClaim_ShipmentPrivilege == true || ShipmentshasClaim_Shipment == true)
            {
                VerifyElementPresent(attributeName_cssselector, ShipmentsIcon_css, "Shipments");
                Console.WriteLine("Shipments icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, ShipmentsIcon_css, "Shipments");
            }
        }

        [When(@"I should see Tracking icon in the left navigation menu of Landing Page")]
        public void WhenIShouldSeeTrackingIconInTheLeftNavigationMenuOfLandingPage()
        {
            Report.WriteLine("User should see Tracking icon in the left navigation menu of Landing Page");
            VerifyElementPresent(attributeName_cssselector, TrackingIcon_css, "Tracking");
        }

        [Then(@"I Click on the Tracking icon available in the menu")]
        public void ThenIClickOnTheTrackingIconAvailableInTheMenu()
        {
            Report.WriteLine("Click on the Tracking icon available in the menu");
            WaitForElementVisible(attributeName_cssselector, TrackingIcon_css, "Tracking");
            Click(attributeName_cssselector, TrackingIcon_css);
        }

        [Then(@"I should see the text '(.*)' in the Tracking landing page")]
        public void ThenIShouldSeeTheTextInTheTrackingLandingPage(string Trackingtext)
        {
            Report.WriteLine("User should navigate to the Tracking module");
            Verifytext(attributeName_cssselector, TrackingpageTitle_css, Trackingtext);
        }

        [Then(@"I click on the Commissions Menu available in the Landing Page navigate to Commissions landing page if '(.*)' have claim")]
        public void ThenIClickOnTheCommissionsMenuAvailableInTheLandingPageNavigateToCommissionsLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Commissions icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var CommissionsClaim_ViewCommissionReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewCommissionReport");

            if (CommissionsClaim_ViewCommissionReport == true)
            {
                VerifyElementPresent(attributeName_xpath, CommissionsIcon_xpath, "Commissions");
                Console.WriteLine("Commissions icon is present with proper claims");

                Report.WriteLine("Click on the Commissions Menu available in the Landing Page");
                Click(attributeName_xpath, CommissionsIcon_xpath);

                Report.WriteLine("User should navigate to the Commissions module");
                Verifytext(attributeName_cssselector, CommissionspageTitle_css, "Commissions");
            }
            else
            {
                VerifyElementNotPresent(attributeName_xpath, CommissionsIcon_xpath, "Commissions");
            }
        }

        [Then(@"I click on the Document Repository Menu available in the Landing Page navigate to Document Repository landing page if '(.*)' have claim")]
        public void ThenIClickOnTheDocumentRepositoryMenuAvailableInTheLandingPageNavigateToDocumentRepositoryLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Document Repository icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var DocRepClaim_DocumentsView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DocumentsView");
            var DocRepClaim_DocumentsViewAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DocumentsViewAll");

            if (DocRepClaim_DocumentsView == true || DocRepClaim_DocumentsViewAll == true)
            {
                VerifyElementPresent(attributeName_xpath, DocumentRepositoryIcon_xpath, "Document Repository");
                Console.WriteLine("Document Repository icon is present with proper claims");

                Report.WriteLine("Click on the Document Repository Menu available in the Landing Page");
                Click(attributeName_xpath, DocumentRepositoryIcon_xpath);

                Report.WriteLine("User should navigate to the Document Repository module");
                Verifytext(attributeName_cssselector, DocumentRepositorypageTitle_css, "Document Repository");
            }
            else
            {
                VerifyElementNotPresent(attributeName_xpath, DocumentRepositoryIcon_xpath, "Document Repository");
            }
        }

        [Then(@"I click on the Reports Menu available in the Landing Page navigate to Reports landing page if '(.*)' have claim")]
        public void ThenIClickOnTheReportsMenuAvailableInTheLandingPageNavigateToReportsLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Reports icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var ReportsClaim_TableauReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauReport");
            var ReportsClaim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauUrl");
            var ReportsClaim_ViewCommissionReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewCommissionReport");

            if ((ReportsClaim_TableauReport == true && ReportsClaim_TableauUrl == true) || ReportsClaim_ViewCommissionReport == true)
            {
                VerifyElementPresent(attributeName_cssselector, ReportsIcon_css, "Reports");
                Console.WriteLine("Reports icon is present with proper claims");

                Report.WriteLine("Click on the Reports Menu available in the Landing page");
                Click(attributeName_cssselector, ReportsIcon_css);

                Report.WriteLine("User should navigate to the Reports module");
                if(ReportsClaim_ViewCommissionReport == true)
                {
                    Verifytext(attributeName_cssselector, ReportspageTitle_css, "Account Metrics");
                }
                else
                {
                    Verifytext(attributeName_cssselector, ReportspageTitle_css, "Reports");
                }
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, ReportsIcon_css, "Reports");
            }
        }

        [When(@"I should see Maintenance Tools icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeMaintenanceToolsIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Maintenance Tools icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var MaintenanceToolsClaim_MaintenanceToolsView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "MaintenanceToolsView");

            if (MaintenanceToolsClaim_MaintenanceToolsView == true)
            {
                VerifyElementPresent(attributeName_cssselector, MaintenanceToolIcon_css, "Maintenance Tools");
                Console.WriteLine("Maintenance Tools icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, MaintenanceToolIcon_css, "Maintenance Tools");
            }
        }

        [Then(@"I click on the Maintenance Tools Menu available in the Landing Page navigate to Maintenance Tools landing page if '(.*)' have claim")]
        public void ThenIClickOnTheMaintenanceToolsMenuAvailableInTheLandingPageNavigateToMaintenanceToolsLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Maintenance Tools icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var MaintenanceToolsClaim_MaintenanceToolsView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "MaintenanceToolsView");

            if (MaintenanceToolsClaim_MaintenanceToolsView == true)
            {
                VerifyElementPresent(attributeName_cssselector, MaintenanceToolIcon_css, "Maintenance Tools");
                Console.WriteLine("Maintenance Tools icon is present with proper claims");

                Report.WriteLine("Click on the Maintenance Tools Menu available in the Landing Page");
                Click(attributeName_cssselector, MaintenanceToolIcon_css);

                Report.WriteLine("User should navigate to the Maintenance Tools module");
                Verifytext(attributeName_cssselector, MaintenanceToolsgpageTitle_css, "Maintenance Tools");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, MaintenanceToolIcon_css, "Maintenance Tools");
            }
        }

        [When(@"I should see Training icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeTrainingIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Training icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var TrainingClaim_TrainingModuleManage = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TrainingModuleManage");
            var TrainingClaim_TrainingModuleView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TrainingModuleView");

            if (TrainingClaim_TrainingModuleManage == true || TrainingClaim_TrainingModuleView == true)
            {
                VerifyElementPresent(attributeName_cssselector, TrainingIcon_css, "Training");
                Console.WriteLine("Training icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, TrainingIcon_css, "Training");
            }
        }

        [Then(@"I click on the Training Menu available in the Landing Page navigate to Training landing page if '(.*)' have claim")]
        public void ThenIClickOnTheTrainingMenuAvailableInTheLandingPageNavigateToTrainingLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Training icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var TrainingClaim_TrainingModuleManage = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TrainingModuleManage");
            var TrainingClaim_TrainingModuleView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TrainingModuleView");

            if (TrainingClaim_TrainingModuleManage == true || TrainingClaim_TrainingModuleView == true)
            {
                VerifyElementPresent(attributeName_cssselector, TrainingIcon_css, "Training");
                Console.WriteLine("Training icon is present with proper claims");

                Report.WriteLine("Click on the Training Menu available in the Landing Page");
                Click(attributeName_cssselector, TrainingIcon_css);

                Report.WriteLine("User should navigate to the Training module");
                Verifytext(attributeName_cssselector, TrainingpageTitle_css, "Training");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, TrainingIcon_css, "Training");
            }
        }

        [When(@"I should see User Management icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeUserManagementIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see User Management icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var UsermgmtClaim_Customers = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "Customers");
            var UsermgmtClaim_UsersManage = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManage");
            var UsermgmtClaim_UsersManageAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManageAll");
            var UsermgmtClaim_ViewUsers = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewUsers");
            var UsermgmtClaim_CustomerUsersView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "CustomerUsersView");

            if (UsermgmtClaim_Customers == true || UsermgmtClaim_UsersManage == true || UsermgmtClaim_UsersManageAll == true || UsermgmtClaim_ViewUsers == true || UsermgmtClaim_CustomerUsersView == true)
            {
                VerifyElementPresent(attributeName_cssselector, UsermanagementIcon_css, "User Management");
                Console.WriteLine("User Management icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, UsermanagementIcon_css, "User Management");
            }
        }

        [Then(@"I click on the User Management Menu available in the Landing Page navigate to User Management landing page if '(.*)' have claim")]
        public void ThenIClickOnTheUserManagementMenuAvailableInTheLandingPageNavigateToUserManagementLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see User Management icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var UsermgmtClaim_Customers = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "Customers");
            var UsermgmtClaim_UsersManage = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManage");
            var UsermgmtClaim_UsersManageAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "UsersManageAll");
            var UsermgmtClaim_ViewUsers = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewUsers");
            var UsermgmtClaim_CustomerUsersView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "CustomerUsersView");

            if (UsermgmtClaim_Customers == true || UsermgmtClaim_UsersManage == true || UsermgmtClaim_UsersManageAll == true || UsermgmtClaim_ViewUsers == true || UsermgmtClaim_CustomerUsersView == true)
            {
                VerifyElementPresent(attributeName_cssselector, UsermanagementIcon_css, "User Management");
                Console.WriteLine("User Management icon is present with proper claims");

                Report.WriteLine("Click on the User Management Menu available in the Landing Page");
                Click(attributeName_cssselector, UsermanagementIcon_css);

                Report.WriteLine("User should navigate to the User Management module");
                if(UsermgmtClaim_CustomerUsersView == true)
                {
                    Verifytext(attributeName_cssselector, UserManagementpageTitle_css, "Customer Details");
                }
                else
                {
                    Verifytext(attributeName_cssselector, UserManagementpageTitle_css, "User Management");
                }
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, UsermanagementIcon_css, "User Management");
            }
        }

        [When(@"I should see Reports icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeReportsIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Reports icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var ReportsClaim_TableauReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauReport");
            var ReportsClaim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauUrl");
            var ReportsClaim_ViewCommissionReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewCommissionReport");

            if ((ReportsClaim_TableauReport == true && ReportsClaim_TableauUrl == true )|| ReportsClaim_ViewCommissionReport == true)
            {
                VerifyElementPresent(attributeName_cssselector, ReportsIcon_css, "Reports");
                Console.WriteLine("Reports icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, ReportsIcon_css, "Reports");
            }
        }

        [When(@"I should see Rating Tools icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeRatingToolsIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Rating Tools icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            List<AppUserClaimInfo> AllClaimDetails = IDP.GetUserClaimDetails(Username);
            var Email = IDP.GetClaimValue(Username, "email");
            bool IsUserEmailexistsinDB = DBHelper.UserEmailexistsinDB(Email);
            if (IsUserEmailexistsinDB == true)
            {
                VerifyElementPresent(attributeName_cssselector, RatingtoolsIcon_css, "Rating Tools");
                Console.WriteLine("Rating Tools icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, RatingtoolsIcon_css, "Rating Tools");
            }

        }

        [Then(@"I click on the Rating Tools Menu available in the Landing Page navigate to Rating Tools landing page if '(.*)' have claim")]
        public void ThenIClickOnTheRatingToolsMenuAvailableInTheLandingPageNavigateToRatingToolsLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Rating Tools icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var Email = IDP.GetClaimValue(Username, "email");
            bool IsUserEmailexistsinDB = DBHelper.UserEmailexistsinDB(Email);
            if (IsUserEmailexistsinDB == true)
            {
                VerifyElementPresent(attributeName_cssselector, RatingtoolsIcon_css, "Rating Tools");
                Console.WriteLine("Rating Tools icon is present with proper claims");

                Report.WriteLine("Click on the Rating Tools Menu available in the Landing Page");
                Click(attributeName_cssselector, RatingtoolsIcon_css);

                Report.WriteLine("User should navigate to the Rating Tools module");
                Verifytext(attributeName_cssselector, RatingToolspageTitle_css, "Projected Amount");
            }
            else
            {
                VerifyElementNotPresent(attributeName_cssselector, RatingtoolsIcon_css, "Rating Tools");
            }
        }

        [When(@"I should see Document Repository icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeDocumentRepositoryIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Document Repository icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var DocRepClaim_DocumentsView = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DocumentsView");
            var DocRepClaim_DocumentsViewAll = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "DocumentsViewAll");

            if (DocRepClaim_DocumentsView == true || DocRepClaim_DocumentsViewAll == true)
            {
                VerifyElementPresent(attributeName_xpath, DocumentRepositoryIcon_xpath, "Document Repository");
                Console.WriteLine("Document Repository icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_xpath, DocumentRepositoryIcon_xpath, "Document Repository");
            }
        }

        [When(@"I should see Commissions icon in the left navigation menu of Landing Page if '(.*)' have claim")]
        public void WhenIShouldSeeCommissionsIconInTheLeftNavigationMenuOfLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("User should see Commissions icon in the left navigation menu of Landing Page");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var CommissionsClaim_ViewCommissionReport = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "ViewCommissionReport");

            if (CommissionsClaim_ViewCommissionReport == true)
            {
                VerifyElementPresent(attributeName_xpath, CommissionsIcon_xpath, "Commissions");
                Console.WriteLine("Commissions icon is present with proper claims");
            }
            else
            {
                VerifyElementNotPresent(attributeName_xpath, CommissionsIcon_xpath, "Commissions");
            }
        }

    }
}
