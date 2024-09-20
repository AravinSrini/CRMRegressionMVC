using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Shipment_Information_Screen.Get_Quote__LTL__Screen
{
    [Binding]
    public class TermsandConditions_PPPInsAllRiskCustomer_Quote_DesktopSteps : ObjectRepository
    {
        [Then(@"User should see the new '(.*)' in Terms and Conditions modal in Quote Results screen")]
        public void ThenUserShouldSeeTheNewInTermsAndConditionsModalInQuoteResultsScreen(string verbiage)
        {
            Report.WriteLine("User should see the new verbiage text in  Terms and Conditions modal in Get Quote screen");
            Thread.Sleep(500);
            var TotalVerbiagetxt = Gettext(attributeName_xpath, LTL_TermsAndConditionsPopupTextResults_Xpath);
            Assert.IsTrue(TotalVerbiagetxt.Contains(verbiage));
        }

        [Then(@"User should see the new '(.*)' in Terms and Conditions modal in Get Quote screen")]
        public void ThenUserShouldSeeTheNewInTermsAndConditionsModalInGetQuoteScreen(string verbiage)
        {
            Report.WriteLine("User should see the new verbiage text in  Terms and Conditions modal in Get Quote screen");
            Thread.Sleep(500);
            var TotalVerbiagetxt = Gettext(attributeName_xpath, LTL_TermsAndConditionsPopupText_Xpath);
            Assert.IsTrue(TotalVerbiagetxt.Contains(verbiage));
        }

        [Then(@"I should be displayed with the Terms and Conditions link in the LTL Results page")]
        public void ThenIShouldBeDisplayedWithTheTermsAndConditionsLinkInTheLTLResultsPage()
        {
            //WaitForElementVisible(attributeName_xpath, ltlTermsandConditionslnk_xpath, "Terms and Conditions");
            Report.WriteLine("Terms and Conditions link should be visible");
            VerifyElementPresent(attributeName_xpath, LTL_TermsAndConditions_Results_xpath, "Terms and Conditions");
        }

        [When(@"I clicks on the Terms and Conditions link in results page")]
        public void WhenIClicksOnTheTermsAndConditionsLinkInResultsPage()
        {
            Report.WriteLine("Click on Terms and conditions link in results page");
            Click(attributeName_xpath, LTL_TermsAndConditions_Results_xpath);
        }

    }
}
