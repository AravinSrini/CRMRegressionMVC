using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public class BuildResponsiveNavigationSteps_Mobile : ObjectRepository
    {
        [Given(@"I should not see the '(.*)'")]
        public void GivenIShouldNotSeeThe(string UserDropdown)
        {
            Report.WriteLine("User can see UserDropdown");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            VerifyElementNotVisible(attributeName_id, UserDropdown_id, UserDropdown);
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
        }

        [Given(@"I click on the on hamburger menu icon")]
        public void GivenIClickOnTheOnHamburgerMenuIcon()
        {
            Report.WriteLine("User click on the on hamburger menu icon");
            WaitForElementVisible(attributeName_xpath, hamburgermenuIcon_xpath, "hamburger menu icon");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_xpath, hamburgermenuIcon_xpath);
           // GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(10000);
            
        }

        [Then(@"I should not see Tracking icon in the left navigation menu of Landing Page")]
        public void ThenIShouldNotSeeTrackingIconInTheLeftNavigationMenuOfLandingPage()
        {
            Report.WriteLine("User should not see Tracking icon in the left navigation menu of Landing Page");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            VerifyElementNotVisible(attributeName_cssselector, TrackingIcon_css, "Tracking");
        }

        [When(@"I click on the on hamburger menu icon in the mobile device")]
        public void WhenIClickOnTheOnHamburgerMenuIconInTheMobileDevice()
        {
            Report.WriteLine("User click on the on hamburger menu icon");
            WaitForElementVisible(attributeName_xpath, hamburgermenuIcon_xpath, "hamburger menu icon");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            Click(attributeName_xpath, hamburgermenuIcon_xpath);
        }

    }
}
