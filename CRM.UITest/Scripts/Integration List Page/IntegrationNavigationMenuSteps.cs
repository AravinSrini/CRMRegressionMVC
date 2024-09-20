using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationNavigationMenuSteps :ObjectRepository
    {
        [When(@"I Mouse hover the Integration Menu Icon available for the user")]
        public void WhenIMouseHoverTheIntegrationMenuIconAvailableForTheUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I should see the Integration Menu Icon available for the user")]
        public void ThenIShouldSeeTheIntegrationMenuIconAvailableForTheUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"i should see the textCustomer Integration Customer Integration")]
        public void ThenIShouldSeeTheTextCustomerIntegrationCustomerIntegration()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
