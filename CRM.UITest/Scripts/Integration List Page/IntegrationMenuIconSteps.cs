using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationMenuIconSteps: Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();
        [Given(@"I am a System admin, operations, sales, sales management or station owner user - (.*) and (.*)")]
        public void GivenIAmASystemAdminOperationsSalesSalesManagementOrStationOwnerUser_And(string Username, string Password)
        {
            crm.LoginToCRMApplication(Username, Password);
        }

        [When(@"I Mouse hover the Integration Menu Icon available for the user")]
        public void WhenIMouseHoverTheIntegrationMenuIconAvailableForTheUser()
        {
            OnMouseOver(attributeName_xpath,IntegrationMenuIcon);
           
        }

        [Then(@"I should not see the Integration Menu Icon available for the user")]
        public void ThenIShouldNotSeeTheIntegrationMenuIconAvailableForTheUser()
        {
            Report.WriteLine("As user is not having claims it should not see Integration icon in the left navigation menu of Landing Page");
            VerifyElementNotPresent(attributeName_xpath, IntegrationMenuIcon, "Integration");
        }

        [Then(@"I should see the Integration Menu Icon available for the user(.*)")]
        public void ThenIShouldSeeTheIntegrationMenuIconAvailableForTheUser(string Username)
        {
            Report.WriteLine("User should see Integration Icon in the left navigation menu of Landing Page");
            VerifyElementPresent(attributeName_xpath, IntegrationMenuIcon, "Integration");
           
        }
        
          [Then(@"I should see the text(.*) Customer Integration")]
        public void ThenIShouldSeeTheTextCustomerIntegration(string expectedTextonMouseOver)
        {
            Report.WriteLine("User should see the text as Customer Integration ");
            string actualTextonMouseOver = Gettext(attributeName_xpath, CustomerIntegrationText);
            Assert.AreEqual(expectedTextonMouseOver, actualTextonMouseOver);
        }

    }
}

