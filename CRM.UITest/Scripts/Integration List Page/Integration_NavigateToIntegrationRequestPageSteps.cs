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
    public class Integration_NavigateToIntegrationRequestPageSteps : Integration
    {
        [Given(@"I am on the Integration List page")]
        public void GivenIAmOnTheIntegrationListPage()
        {
            Click(attributeName_id, IntegrationIconLink_Dashboard_id);
        }
        
        [When(@"I click on the Submit Integration Request button")]
        public void WhenIClickOnTheSubmitIntegrationRequestButton()
        {
            Click(attributeName_id, IntegrationRequestButton_Id);
        }

        [Then(@"I will arrive on the Integration Request Page (.*)")]
        public void ThenIWillArriveOnTheIntegrationRequestPage(string PageTitle)
        {
            String expectedtext = PageTitle;
            String actualText = Gettext(attributeName_xpath, SubmitIntegrationRequestPage_Header_Xpath);

            Assert.AreEqual((actualText), expectedtext);
            Report.WriteLine("Integration Request page has opened");
        }


    }
}
