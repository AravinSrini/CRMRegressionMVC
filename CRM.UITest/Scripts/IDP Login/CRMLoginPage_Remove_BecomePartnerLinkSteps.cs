using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Chrome;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;

namespace CRM.UITest.Scripts.IDP_Login
{
    [Binding]
    public class CRMLoginPage_Remove_BecomePartnerLinkSteps :ObjectRepository
    {
        [Given(@"I am any user and launch (.*)")]
        public void GivenIAmAnyUserAndLaunch(string url)
        {
           GlobalVariables.webDriver.Navigate().GoToUrl(url);
        }

        [Then(@"I will no longer see the Become a DLS Worldwide Partner Today Link (.*)")]
        public void ThenIWillNoLongerSeeTheBecomeADLSWorldwidePartnerTodayLink(string url)
        {
            if(url == "http://dls-ww-test.rrd.com/" || url == "http://dlsww-test.rrd.com/" || url == "http://dlsw-test.rrd.com/")
            {
                VerifyElementNotVisible(attributeName_xpath, DlsParter_Link_Xpath, "Become a DLS Worldwide Partner Today");
                Report.WriteLine("Become a DLS Worldwide Partner Today link is not displaying for url " + url);
            }
            else
            {
                Report.WriteFailure("Invalid URL" + url);
            }
        }
    }
}
