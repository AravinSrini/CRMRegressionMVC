using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote.LTL.Quote_Results_Screen.Mobile
{
    [Binding]
    public class Quote__LTL__Result_and_Confirmation___Mobile_Screen : Quotelist
    {
        [Given(@"I am Stationowner Operations Sales management or Sales user ""(.*)"" ""(.*)""")]
        [Given(@"I am not a Stationowner Operations Sales management or Sales user ""(.*)"" ""(.*)""")]
        public void GivenIAmStationownerOperationsSalesManagementOrSalesUser(string user, string pass)
        {
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            string username = ConfigurationManager.AppSettings[user].ToString();
            string password = ConfigurationManager.AppSettings[pass].ToString();

            Report.WriteLine("Logging in as " + username);
            CrmLogin.LoginToCRMApplication(username, password);
            if(IsElementPresent(attributeName_id, "cookiescript_injected", "Cookie wrapper"))
            {
                Click(attributeName_id, "cookiescript_accept");
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I resize the window to the dimensions ""(.*)"" ""(.*)""")]
        public void GivenIResizeTheWindowToTheDimensions(int width, int height)
        {
            setBrowserSize(width, height);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I land on quote results screen with an origin zip ""(.*)"", origin city of ""(.*)"", origin state of ""(.*)"" destination zip ""(.*)"", destination city of ""(.*)"", destination state of ""(.*)"" classification ""(.*)"" and weight ""(.*)""")]
        public void WhenILandOnQuoteResultsScreen(string originZip, string originCity, string originState, string destinationZip, string destinationCity, string destinationState, string classification, string weight)
        {
            WaitForElementVisible(attributeName_cssselector, MobileNavigationButton_Selector, "Quote Icon");
            Report.WriteLine("Navigate to quote list page");
            Click(attributeName_cssselector, MobileNavigationButton_Selector);
            WaitForElementVisible(attributeName_xpath, QuoteIconModule_Xpath, "Quote Icon");
            Click(attributeName_id, QuoteIconModule_Id);
            GlobalVariables.webDriver.WaitForPageLoad();

            NavigateToQuoteResults quoteNavigation = new NavigateToQuoteResults();
            quoteNavigation.NavigateToQuoteResultsPage(originZip, originCity, originState, destinationZip, destinationCity, destinationState, classification, weight);
        }

        [When(@"I land on quote results screen as a specified user ""(.*)"" with an origin zip ""(.*)"", origin city of ""(.*)"", origin state of ""(.*)"" destination zip ""(.*)"", destination city of ""(.*)"", destination state of ""(.*)"" classification ""(.*)"" and weight ""(.*)""")]
        public void WhenILandOnQuoteResultsScreen(string customerName, string originZip, string originCity, string originState, string destinationZip, string destinationCity, string destinationState, string classification, string weight)
        {
            Report.WriteLine("Navigate to quote list page");
            WaitForElementVisible(attributeName_cssselector, MobileNavigationButton_Selector, "Navigation icon");
            Click(attributeName_cssselector, MobileNavigationButton_Selector);
            WaitForElementVisible(attributeName_xpath, QuoteIconModule_Xpath, "Quote Icon");
            Click(attributeName_xpath, QuoteIconModule_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("Selecting " + customerName + " from the dropdown");
            Click(attributeName_xpath, QuoteList_ClickCustomerDropdown_xpath);

            SelectDropdownValueFromList(attributeName_xpath, QuoteList_CustomerDropdownList_Xpath, customerName);
            
            GlobalVariables.webDriver.WaitForPageLoad();

            NavigateToQuoteResults quoteNavigation = new NavigateToQuoteResults();
            quoteNavigation.NavigateToQuoteResultsPage(originZip, originCity, originState, destinationZip, destinationCity, destinationState, classification, weight);
        }        

        [When(@"I navigate to the quote confirmation page")]
        public void WhenNavigateToTheQuoteConfirmationPage()
        {
            Report.WriteLine("Navigating to the quote confirmation page");
            Click(attributeName_cssselector, QuoteResult_SaveRateAsQuoteLinkMobile_Selector);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [When(@"I navigate to the no quote results page")]
        public void WhenINavigateToTheNoQuoteResultsPage()
        {
            string url = ConfigurationManager.AppSettings["BaseUrl"].ToString();
            GlobalVariables.webDriver.Navigate().GoToUrl(url+"/Rate/LtlNoResultsView");
        }

        [Then(@"I see Back to Quote List button")]
        public void ThenISeeBackToQuoteListButton()
        {
            VerifyElementVisible(attributeName_cssselector, BacktoQuoteListButton_Selector, "Back to Quote List Button");
        }

        [Then(@"I will not see Back to Quote List button")]
        public void ThenIWillNotSeeBackToQuoteListButton()
        {
            VerifyElementNotVisible(attributeName_cssselector, BacktoQuoteListButton_Selector, "Back to Quote List Button");
        }

        [Then(@"I will see Est Cost below fields in results grid")]
        public void ThenIWillSeeEstCostBelowFieldsInResultsGrid()
        {
            VerifyElementPresent(attributeName_cssselector, EstimatedCostCSSSelector, "Estimated Cost");
        }

        [Then(@"I will not see Est Cost below fields in results grid")]
        public void ThenIWillNotSeeEstCostBelowFieldsInResultsGrid()
        {
            VerifyElementNotPresent(attributeName_cssselector, EstimatedCostCSSSelector, "Estimated Cost");
        }

        [Then(@"I will see Est Margin below fields in results grid")]
        public void ThenIWillSeeEstMarginBelowFieldsInResultsGrid()
        {
            VerifyElementPresent(attributeName_cssselector, QuoteRestults_MobileEstMargin_Selector, "Estimated Margin");
        }

        [Then(@"I will not see Est Margin below fields in results grid")]
        public void ThenIWillNotSeeEstMarginBelowFieldsInResultsGrid()
        {
            VerifyElementNotPresent(attributeName_cssselector, QuoteRestults_MobileEstMargin_Selector, "Estimated Margin");
        }
    }
}