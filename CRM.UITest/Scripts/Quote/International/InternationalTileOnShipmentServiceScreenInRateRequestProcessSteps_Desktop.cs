using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using System.Collections.Generic;
using System.Threading;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote.International
{
    [Binding]
    public class InternationalTileOnShipmentServiceScreenInRateRequestProcessSteps_Desktop : ObjectRepository
    {
        [Given(@"I am able to see the '(.*)'")]
        public void GivenIAmAbleToSeeThe(string UserDropdown)
        {
            Report.WriteLine("User can see UserDropdown");
            VerifyElementPresent(attributeName_id, UserDropdown_id, UserDropdown);
            var Username = Gettext(attributeName_id, UserDropdown_id);
            Assert.AreEqual(UserDropdown.ToLower(), Username.ToLower());
        }

        [When(@"I must see the '(.*)' tile in the Quotes landing page")]
        public void WhenIMustSeeTheTileInTheQuotesLandingPage(string International)
        {
            Report.WriteLine("User must see International tile");
            Verifytext(attributeName_id, InternationalTile_id, International);
        }

        [When(@"I click on the International tile")]
        public void WhenIClickOnTheInternationalTile()
        {
            Report.WriteLine("User clicks on the International tile");
            Click(attributeName_id, InternationalTile_id);
            WaitForElementVisible(attributeName_xpath, InternationalModel_xpath, "InternationalTypetext");
        }

        [When(@"I click on the Type drop down")]
        public void WhenIClickOnTheTypeDropDown()
        {
            Report.WriteLine("User click on the Type drop down");
            Click(attributeName_id, InternationalTypedropdown_id);
        }

        [When(@"I should able to select any option in the Type drop down list")]
        public void WhenIShouldAbleToSelectAnyOptionInTheTypeDropDownList()
        {
            Report.WriteLine("User selects first option in the Type drop down list");
            List<string> ListofTypesinSelectType_UI = GetDropdownValues(attributeName_id, InternationalTypedropdown_id, TagNameforType_Dropdownoptions);
            ListofTypesinSelectType_UI.Remove("Select Type...");
            SelectDropdownValueFromList(attributeName_id, InternationalTypedropdown_id, ListofTypesinSelectType_UI.FirstOrDefault());
        }

        [Then(@"I should see the International Type '(.*)' model")]
        public void ThenIShouldSeeTheInternationalTypeModel(string InternationalTypetext)
        {
            Report.WriteLine("User see the International Type model");
            VerifyElementVisible(attributeName_xpath, InternationalModel_xpath, InternationalTypetext);
            string InternationalModelHeading_UI = Gettext(attributeName_xpath, InternationalModel_xpath);
            Assert.AreEqual(InternationalTypetext, InternationalModelHeading_UI);
        }

        [Then(@"I should see Type Drop down with '(.*)'")]
        public void ThenIShouldSeeTypeDropDownWith(string defaulttext)
        {
            Report.WriteLine("User see the Type Drop down International Type model");
            Verifytext(attributeName_id, InternationalTypedropdown_id, defaulttext);
        }

        [Then(@"I click on the Type drop down")]
        public void ThenIClickOnTheTypeDropDown()
        {
            Report.WriteLine("User click on the Type drop down");
            Click(attributeName_id, InternationalTypedropdown_id);
        }

        [Then(@"I should able to select any option in the Type drop down list")]
        public void ThenIShouldAbleToSelectAnyOptionInTheTypeDropDownList()
        {
            Report.WriteLine("User selects first option in the Type drop down list");
            List<string> ListofTypesinSelectType_UI = GetDropdownValues(attributeName_id, InternationalTypedropdown_id, TagNameforType_Dropdownoptions);
            ListofTypesinSelectType_UI.Remove("Select Type...");
            SelectDropdownValueFromList(attributeName_id, InternationalTypedropdown_id, ListofTypesinSelectType_UI.FirstOrDefault());
        }

        [Then(@"I should see Level Drop down with '(.*)'")]
        public void ThenIShouldSeeLevelDropDownWith(string defaulttext)
        {
            Report.WriteLine("User see the Level Drop down International Type model");
            WaitForElementVisible(attributeName_id, InternationalLeveldropdown_id, "LevelDropDown");
            Verifytext(attributeName_id, InternationalLeveldropdown_id, defaulttext);
        }

        [Then(@"I click on the Level drop down")]
        public void ThenIClickOnTheLevelDropDown()
        {
            Report.WriteLine("User click on the Level drop down");
            Click(attributeName_id, InternationalLeveldropdown_id);
        }

        [Then(@"I should able to select any option in the Level drop down list")]
        public void ThenIShouldAbleToSelectAnyOptionInTheLevelDropDownList()
        {
            Report.WriteLine("User selects first option in the Level drop down list");
            List<string> ListofLevelstoSelect_UI = GetDropdownValues(attributeName_id, InternationalLeveldropdown_id, TagNameforLevel_Dropdownoptions);
            ListofLevelstoSelect_UI.Remove("Select Level...");
            SelectDropdownValueFromList(attributeName_id, InternationalLeveldropdown_id, ListofLevelstoSelect_UI.FirstOrDefault());
        }

        [Then(@"I should see Continue button with '(.*)'")]
        public void ThenIShouldSeeContinueButtonWith(string defaulttext)
        {
            Report.WriteLine("User see the Continue button International Type model");
            Verifytext(attributeName_id, ContinueBtn_id, defaulttext);
        }

        [Then(@"Continue button should be in enabled")]
        public void ThenContinueButtonShouldBeInEnabled()
        {
            Report.WriteLine("Verify the state of the continue button");
            bool IsEnabled = IsElementEnabled(attributeName_id, ContinueBtn_id, "state");
            Assert.IsTrue(IsEnabled);
        }

        [Then(@"I click on the Continue button")]
        public void ThenIClickOnTheContinueButton()
        {
            Report.WriteLine("click on the Continue button");
            ImplicitWait();
            Click(attributeName_id, ContinueBtn_id);
        }

        [Then(@"I should see Cancel button with '(.*)'")]
        public void ThenIShouldSeeCancelButtonWith(string defaulttext)
        {
            Report.WriteLine("User see the Cancel button International Type model");
            Verifytext(attributeName_xpath, CancelBtn_xpath, defaulttext);
        }

        [Then(@"I click on the Cancel button")]
        public void ThenIClickOnTheCancelButton()
        {
            Report.WriteLine("click on the cancel button");
            Click(attributeName_xpath, CancelBtn_xpath);
            WaitForElementNotVisible(attributeName_xpath, CancelBtn_xpath, "Close");
        }

        [Then(@"I should not see the International Type '(.*)' model")]
        public void ThenIShouldNotSeeTheInternationalTypeModel(string InternationalTypetext)
        {
            Report.WriteLine("User not see the International Type model");
            VerifyElementNotVisible(attributeName_xpath, InternationalModel_xpath, InternationalTypetext);
        }

        [Then(@"I click on the Type drop down and select Type")]
        public void ThenIClickOnTheTypeDropDownAndSelectType()
        {
            Report.WriteLine("User select valid option in Type drop down");
            Click(attributeName_id, InternationalTypedropdown_id);
            Report.WriteLine("User selects first option in the Type drop down list");
            List<string> ListofTypesinSelectType_UI = GetDropdownValues(attributeName_id, InternationalTypedropdown_id, TagNameforType_Dropdownoptions);
            ListofTypesinSelectType_UI.Remove("Select Type...");
            SelectDropdownValueFromList(attributeName_id, InternationalTypedropdown_id, ListofTypesinSelectType_UI.FirstOrDefault());
        }


        [Then(@"I click on the Level drop down and select Level")]
        public void ThenIClickOnTheLevelDropDownAndSelectLevel()
        {
            Report.WriteLine("User select valid option in Level drop down");
            WaitForElementVisible(attributeName_id, InternationalLeveldropdown_id, "LevelDropDown");
            Click(attributeName_id, InternationalLeveldropdown_id);
            Report.WriteLine("User selects first option in the Level drop down list");
            List<string> ListofLevelstoSelect_UI = GetDropdownValues(attributeName_id, InternationalLeveldropdown_id, TagNameforLevel_Dropdownoptions);
            ListofLevelstoSelect_UI.Remove("Select Level...");
            SelectDropdownValueFromList(attributeName_id, InternationalLeveldropdown_id, ListofLevelstoSelect_UI.FirstOrDefault());
        }

        [Then(@"I should able to see the error '(.*)' message")]
        public void ThenIShouldAbleToSeeTheErrorMessage(string Errormessage)
        {
            Report.WriteLine("User should see the error message");
            Verifytext(attributeName_cssselector, errormessage_css, Errormessage);
        }

        [Then(@"I should see the text '(.*)', '(.*)' button in the Quotes landing page")]
        public void ThenIShouldSeeTheTextButtonInTheQuotesLandingPage(string GetQuotetext, string BacktoQuoteListBtn)
        {
            Report.WriteLine("Landing on the Shipment Services screen in rate request process");
            Verifytext(attributeName_cssselector, GetQuotespagetext_css, GetQuotetext);
            Verifytext(attributeName_id, BacktoQuoteListBtn_id, BacktoQuoteListBtn);
        }

        [When(@"I should see the text '(.*)', '(.*)' button in the Quotes landing page")]
        public void WhenIShouldSeeTheTextButtonInTheQuotesLandingPage(string GetQuotetext, string BacktoQuoteListBtn)
        {
            Report.WriteLine("Landing on the Shipment Services screen in rate request process");
            Verifytext(attributeName_cssselector, GetQuotespagetext_css, GetQuotetext);
            Verifytext(attributeName_id, BacktoQuoteListBtn_id, BacktoQuoteListBtn);
        }

        [When(@"I click on the Quotes Menu available in the Landing Page navigate to Quotes landing page if '(.*)' have claim")]
        public void WhenIClickOnTheQuotesMenuAvailableInTheLandingPageNavigateToQuotesLandingPageIfHaveClaim(string Username)
        {
            Report.WriteLine("click on the Quotes Menu");
            //WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading symbol"); ---> Loading symbol doesn't display. Step fails
            Thread.Sleep(3000);            
            Click(attributeName_cssselector, Quotesmenu_css);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

    }
}
