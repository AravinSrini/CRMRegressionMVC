using CRM.UITest.Objects;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Dashboard
{
    [Binding]
    public sealed class Dashboard_DisplayStationSummarySteps_Desktop : ObjectRepository
    {
        [When(@"I am able to see the '(.*)'")]
        public void WhenIAmAbleToSeeThe(string UserDropdown)
        {
            Report.WriteLine("User can see UserDropdown");
            Verifytext(attributeName_id, UserDropdown_id, UserDropdown);
        }

        [Then(@"I should arrive on the Dashboard landing page")]
        public void ThenIShouldArriveOnTheDashboardLandingPage()
        {
            Report.WriteLine("User should navigate to the Dashboard module");
            Verifytext(attributeName_cssselector, DashboardpageTitle_css, "Dashboard");
        }

        [Then(@"I should see the PendingCSR '(.*)' section")]
        public void ThenIShouldSeeThePendingCSRSection(string PendingCSR)
        {
            Report.WriteLine("User should see the PendingCSR section");
            Verifytext(attributeName_xpath, PendingCSRSectionHeader_xpath, PendingCSR);
        }

        [Then(@"I should see the StationSummery '(.*)' section")]
        public void ThenIShouldSeeTheStationSummerySection(string StationSummery)
        {
            Report.WriteLine("User should see the StationSummery section");
            Verifytext(attributeName_xpath, StationSummerySectionHeader_xpath, StationSummery);
        }

        [Then(@"The Station Summary section should contain the '(.*)' report")]
        public void ThenTheStationSummarySectionShouldContainTheReport(string StationMonthlyBreakdown)
        {
            Report.WriteLine("The Station Summary section should contain the Station Monthly Breakdown report");
            VerifyElementPresent(attributeName_xpath, ReportsStationMonthlyBreakdown_xpath, StationMonthlyBreakdown);
        }

        [Then(@"I should see a '(.*)' button above the CSR section")]
        public void ThenIShouldSeeAButtonAboveTheCSRSection(string ViewAccountMetrics)
        {
            Report.WriteLine("User should see the View Account Metrics button above the CSR section");
            Verifytext(attributeName_xpath, ViewAccountMetricsBtn_xpath, ViewAccountMetrics);
        }

        [When(@"If Tabular URL claim is not there for logged in '(.*)'")]
        public void WhenIfTabularURLClaimIsNotThereForLoggedIn(string Username)
        {
            Report.WriteLine("User don't have Tabular URL claim");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var Claim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-role", "TableauUrl");
            if (Claim_TableauUrl == true)
            {
                Report.WriteLine("Username has Tabular URL claim");
            }
            else
            {
                Report.WriteLine("Username don't has Tabular URL claim");
            }
        }

        [Then(@"User '(.*)' should not see the StationSummery '(.*)' section")]
        public void ThenUserShouldNotSeeTheStationSummerySection(string Username, string StationSummery)
        {
            Report.WriteLine("User don't have Tabular URL claim");
            IdServerAccess IDP = new IdServerAccess(IdentityServerBaseUrl, IdentityAPIClientId, IdentityAPIClientSecret);

            var MEMStationReviewClaim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-TableauUrl", "MEM/StationReview");
            var ZZZStationReviewClaim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-TableauUrl", "ZZZ/StationReview");
            var PITStationReviewClaim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-TableauUrl", "PIT/StationReview");
            var StationDemoWeek2StationReviewClaim_TableauUrl = IDP.VerifyIfUserHasClaim(Username, "dlscrm-TableauUrl", "StationDemoWeek2/StationReview");

            if (MEMStationReviewClaim_TableauUrl == false && ZZZStationReviewClaim_TableauUrl == false && PITStationReviewClaim_TableauUrl == false && StationDemoWeek2StationReviewClaim_TableauUrl == false)
            {
                Report.WriteLine("User should not see the Station Summery section");
                VerifyElementNotPresent(attributeName_xpath, StationSummerySectionHeader_xpath, StationSummery);
            }
            else
            {
                Report.WriteLine("User should see the Station Summery section");
                Verifytext(attributeName_xpath, StationSummerySectionHeader_xpath, StationSummery);
                VerifyElementPresent(attributeName_xpath, ReportsStationMonthlyBreakdown_xpath, "StationMonthlyBreakdown");
            }
        }

        [Then(@"I should not see a '(.*)' button above the CSR section")]
        public void ThenIShouldNotSeeAButtonAboveTheCSRSection(string ViewAccountMetrics)
        {
            Report.WriteLine("User should not see the View Account Metrics button above the CSR section");
            VerifyElementNotPresent(attributeName_xpath, ViewAccountMetricsBtn_xpath, ViewAccountMetrics);
        }

        [Then(@"I should not see StationSummery '(.*)' section")]
        public void ThenIShouldNotSeeStationSummerySection(string StationSummery)
        {
            Report.WriteLine("User should not see the Station Summery section");
            VerifyElementNotPresent(attributeName_xpath, StationSummerySectionHeader_xpath, StationSummery);
        }

    }
}
