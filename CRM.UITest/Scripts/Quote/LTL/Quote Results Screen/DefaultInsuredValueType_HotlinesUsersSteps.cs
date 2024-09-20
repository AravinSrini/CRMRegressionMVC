using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen
{
    [Binding]
    public class DefaultInsuredValueType_HotlinesUsersSteps : ObjectRepository
    {
        [Then(@"Insured Value type should be default to used type in ltl quote results page")]
        public void ThenInsuredValueTypeShouldBeDefaultToUsedTypeInLtlQuoteResultsPage()
        {
            Report.WriteLine("Verifying the default selected insured type dropdown value");
            Verifytext(attributeName_xpath, InsuredValueDefault, "Used");
        }
        
        [Then(@"selected (.*) should be displayed in the insured type dropdown in quote results screen")]
        public void ThenSelectedShouldBeDisplayedInTheInsuredTypeDropdownInQuoteResultsScreen(string ExpValue)
        {
            Report.WriteLine("Verifying the selected insured type dropdown value");
            Verifytext(attributeName_xpath, InsuredValueDefault, ExpValue);
        }
    }
}
