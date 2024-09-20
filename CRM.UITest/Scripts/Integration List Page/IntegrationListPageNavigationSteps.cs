using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationListPageNavigationSteps: Integration
    {
        [When(@"I click on Integration Menu")]
        public void WhenIClickOnIntegrationMenu()
        {
            try
            {
                
                Click(attributeName_xpath, IntegrationMenuIcon);
                Report.WriteLine("User see the Title Integration Request List Page ");
            }
            catch
            {
                Thread.Sleep(20000);
            }
        }

        [Then(@"I should be navigated to the Integration Request List Page with title (.*)")]
        public void ThenIShouldBeNavigatedToTheIntegrationRequestListPageWithTitle(string expectedTitle_UI)
        {
       
            Report.WriteLine("User see the Title Integration Request List Page ");
            string actualTitle_UI = Gettext(attributeName_xpath, IntegrationListPageTitle_xpath);
            Assert.AreEqual(expectedTitle_UI, actualTitle_UI);
        }

     
    }
}
