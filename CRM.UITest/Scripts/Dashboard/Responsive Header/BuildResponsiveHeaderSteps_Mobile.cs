using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public class BuildResponsiveHeaderSteps_Mobile : ObjectRepository
    {

        [Then(@"I should not see Tracking icon in the left navigation menu of MVC(.*) Landing Page")]
        public void ThenIShouldNotSeeTrackingIconInTheLeftNavigationMenuOfMVCLandingPage(int p0)
        {
            Report.WriteLine("User should see Tracking icon in the left navigation menu of Landing Page");
            VerifyElementPresent(attributeName_cssselector, TrackingIcon_css, "Tracking");
        }

        [Then(@"Verify the user is not able to see the user drop down on top right side of the page")]
        public void ThenVerifyTheUserIsNotAbleToSeeTheUserDropDownOnTopRightSideOfThePage()
        {
            Report.WriteLine("User can see UserDropdown");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
            VerifyElementNotVisible(attributeName_id, UserDropdown_id, "UserDropdown");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol");
        }

        [Then(@"I should able to see the logo is displayed for the user")]
        public void ThenIShouldAbleToSeeTheLogoIsDisplayedForTheUser()
        {
            Report.WriteLine("Landing on DLS Worldwide Homepage");            
            VerifyElementPresent(attributeName_xpath, DashboardPageLogo, "RRDLogo");
        }



    }
}
