using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList__Show_loading_icon
{
    [Binding]
    public class QuoteList_NavigationLoadingOverlaySteps : Quotelist
    {
        [When(@"I click the Quote List Icon on the navigation menu")]
        public void WhenIClickTheQuoteListIconOnTheNavigationMenu()
        {
            Report.WriteLine("Click on Quotes button");
            Click(attributeName_xpath, QuoteList_Icon_Xpath);
        }
        
        [Then(@"I will see a loading overlay while the page is loading in quote list screen")]
        public void ThenIWillSeeALoadingOverlayWhileThePageIsLoadingInQuoteListScreen()
        {
            WaitForElementVisible(attributeName_xpath, QuoteList_LoadingIcon_Xpath, "Loading Icon");
            VerifyElementVisible(attributeName_xpath, QuoteList_LoadingIcon_Xpath, "Loading Icon");
        }

        [When(@"the quote list page is loaded")]
        public void WhenTheQuoteListPageIsLoaded()
        {
            Report.WriteLine("Quote List page");
            VerifyElementPresent(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quote List");
        }

        [Then(@"I will no longer see the loading overlay in quote list screen")]
        public void ThenIWillNoLongerSeeTheLoadingOverlayInQuoteListScreen()
        {
            VerifyElementNotVisible(attributeName_xpath, QuoteList_LoadingIcon_Xpath, "Loading Icon");
        }
    }
}
