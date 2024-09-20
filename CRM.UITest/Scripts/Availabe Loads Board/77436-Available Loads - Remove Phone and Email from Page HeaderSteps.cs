using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Availabe_Loads_Board
{
    [Binding]
    public class _77436_Available_Loads___Remove_Phone_and_Email_from_Page_HeaderSteps : LoadsBoard
    {
        [Given(@"that I navigate to the CRM Available Loads web page")]
        public void GivenThatINavigateToTheCRMAvailableLoadsWebPage()
        {
            string configURL = launchUrl;
            GlobalVariables.webDriver.Navigate().GoToUrl(configURL+"availableLoads");

            bool visible = IsElementPresent(attributeName_xpath, ".//*[@id='cookiescript_accept']", "cookie");

            if (visible == true)
            {
                Click(attributeName_xpath, ".//*[@id='cookiescript_accept']");
            }
        }

        [When(@"the page loads")]
        public void WhenThePageLoads()
        {
            Verifytext(attributeName_cssselector, AvailableLoadsPageHeader_css, "Available Loads");
        }

        [Then(@"I will not see the Phone and Email text on the page header")]
        public void ThenIWillNotSeeThePhoneAndEmailTextOnThePageHeader()
        {
            VerifyElementNotPresent(attributeName_id, claimLoadsInformation_id, "PhoneandEmailText");
        }


    }
}
