using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading;
using TechTalk.SpecFlow;
using System.Text;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class Integration_NavigationIntegrationListFromIntegrationRequestPageSteps : Integration
    {

        [When(@"I am on Integration Request page")]
        public void WhenIAmOnIntegrationRequestPage()
        {
            Click(attributeName_id, IntegrationIconLink_Dashboard_id);
            Thread.Sleep(3000);
            Click(attributeName_id, IntegrationRequestButton_Id);
            Verifytext(attributeName_xpath, IntegrationRequestPageTitle_Xpath, "Submit Integration Request");
            Report.WriteLine("Submit Integration Request Page");
        }

        [When(@"I click the back to integration list button")]
        public void WhenIClickTheBackToIntegrationListButton()
        {


            VerifyElementPresent(attributeName_id, BackToIntegrationListPageButton_Id, "Back to Integration Request List");
            Report.WriteLine("Back to Integration Request List Button is present on Integration Request page");
            Click(attributeName_id, BackToIntegrationListPageButton_Id);
        }   
           
        

        [Then(@"I will return to the integration list page (.*)")]
        public void ThenIWillReturnToTheIntegrationListPage(string PageTitle)
        {
            
           // string expectedText = PageTitle;
            string ActualText = Gettext(attributeName_xpath, IntegrationListPageTitle_xpath);
            Assert.AreEqual(ActualText, PageTitle);
            Report.WriteLine("Integration Request page has opened");
        }
    }
}
