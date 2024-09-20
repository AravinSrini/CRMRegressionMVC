using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
namespace CRM.UITest
{
    [Binding]
    public class NewCRMUser_ClaimsSpecialistSteps : InsuranceClaim
    {
        [Given(@"I am a Claims Specialist user")]
        public void GivenIAmAClaimsSpecialistUser()
        {
            string userName = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I have logged into CRM application");
        }

        [Given(@"I am a Claims Specialist user with external user roles")]
        public void GivenIAmAClaimsSpecialistUserWithExternalUserRoles()
        {
            string username = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            string password = ConfigurationManager.AppSettings["ExternalUserPassword"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("I have logged into CRM application");
        }

        [Given(@"I am a Claims Specialist user with internal user roles")]
        public void GivenIAmAClaimsSpecialistUserWithInternalUserRoles()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("I have logged into CRM application");
        }

        [When(@"I do not belong to any other CRM Roles")]
        public void WhenIDoNotBelongToAnyOtherCRMRoles()
        {
            string userName = ConfigurationManager.AppSettings["username-claimspecialist"].ToString();
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            var claim = idp.VerifyIfUserHasClaim(userName, "dlscrm-role", "ClaimsSpecialistUser");
            if (claim == true)
            {
                Report.WriteLine("I do not belong to any other CRM Roles");
            }
            else
            {
                Report.WriteLine("I belong to CRM Roles");
            }
        }

        [When(@"I belong to other CRM external user Roles")]
        public void WhenIBelongToOtherCRMExternalUserRoles()
        {
            string userName = ConfigurationManager.AppSettings["ExternalUserLogin"].ToString();
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            var claim = idp.VerifyIfUserHasClaim(userName, "group", "dlscrm-CrmShp.Entry");
            if (claim == true)
            {
                Report.WriteLine("I belong to CRM External user Roles along with claim specialist role");
            }
            else
            {
                Report.WriteLine("I do not belong to any other CRM External user Roles");
            }
        }

        [When(@"I belong to other CRM internal user Roles")]
        public void WhenIBelongToOtherCRMInternalUserRoles()
        {
            string userName = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            IdServerAccess idp = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);
            var claim = idp.VerifyIfUserHasClaim(userName, "group", "dlscrm-CrmOperations");
            if (claim == true)
            {
                Report.WriteLine("I belong to CRM Internal user Roles along with claim specialist role");
            }
            else
            {
                Report.WriteLine("I do not belong to any other CRM Internal user Roles");
            }
        }

        [Then(@"I will arrive on the Claims List page")]
        public void ThenIWillArriveOnTheClaimsListPage()
        {            
            Report.WriteLine("arrive on the Claims List page");
            VerifyElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "claims List");
        }
        
        [Then(@"I will arrive on CRM Dashboard page for shipments")]
        public void ThenIWillArriveOnCRMDashboardPageForShipments()
        {
            Mvc4Objects dashboardObjects = new Mvc4Objects();
            Report.WriteLine("arrive on CRM Dashboard page for shipments");
            VerifyElementVisible(attributeName_xpath,dashboardObjects.DasboardHeader_Xpath, "shipmentsdashboard");
        }

        [Then(@"I will arrive on CRM Dashboard page for CSR's")]
        public void ThenIWillArriveOnCRMDashboardPageForCSRS()
        {            
            Report.WriteLine("arrive on CRM Dashboard page for shipments");
            VerifyElementVisible(attributeName_xpath, NewDashboard_Header_Text_Xpath, "CSRdashboard");
        }        

    }
}
