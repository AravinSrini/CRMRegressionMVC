using System;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Linq;
using System.Threading;

namespace CRM.UITest.Scripts.Quote_List
{
    [Binding]
    public class QuoteListPageLayoutSteps : Quotelist
    {
        [Given(@"I have access to Quotes button")]
        public void GivenIHaveAccessToQuotesButton()
        {
            Report.WriteLine("Click on Quotes button");
            Click(attributeName_xpath, QuoteList_Icon_Xpath);
        }

        [Given(@"I have access to Quotes button for external users")]
        public void GivenIHaveAccessToQuotesButtonForExternalUsers()
        {

            string ErrorPopupValues = Gettext(attributeName_xpath, QuoteListDashboardError_Xpath);
            if (ErrorPopupValues == "Error")
            {
                Click(attributeName_xpath, ErrorPopUpClose_Button_Xpath);
                Thread.Sleep(2000);
                Click(attributeName_xpath, QuoteList_Icon_Xpath);

            }
            else
            {
                Click(attributeName_xpath, QuoteList_Icon_Xpath);
            }

        }


        [When(@"I arrive on quotes list page")]
        public void WhenIArriveOnQuotesListPage()
        {
            Report.WriteLine("Quote List page");
            Verifytext(attributeName_xpath, QuoteList_PageTitle_Xpath, "Quote List");
        }
        
        [Then(@"I must be able to view Customer selection drop down list")]
        public void ThenIMustBeAbleToViewCustomerSelectionDropDownList()
        {
            Report.WriteLine("Customer Selection Dropdown");
            VerifyElementPresent(attributeName_xpath, QuoteList_CustomerDropdown_Xpath, "Customer Dropdown");
            string DropdownActualValue = Gettext(attributeName_xpath, QuoteList_CustomerDropdown_Label_Xpath);
            Assert.AreEqual(DropdownActualValue, "All Customers");
        }
        

        [Then(@"I must be able to view Quotes label with the message - Submitted rate requests within the past thirty days are below\.")]
        public void ThenIMustBeAbleToViewQuotesLabelWithTheMessage_SubmittedRateRequestsWithinThePastThirtyDaysAreBelow_()
        {
            Report.WriteLine("Quotes Label Message");
            string ActualMessage=Gettext(attributeName_xpath, QuoteList_SubtitleInternalUser_Xpath);
            Assert.AreEqual(ActualMessage, "Submitted rate requests within the past 30 days are shown.");
        }

        [Then(@"I should not be able to view Submit Rate Request (.*)")]
        public void ThenIShouldNotBeAbleToViewSubmitRateRequest(string Button)
        {
            Report.WriteLine("Visibility of Submit Rate Request button");
            VerifyElementNotVisible(attributeName_id, SubmitRateRequestButton_Id, Button);

        }

        [Then(@"I should not be able to see Submit Rate Request Button")]
        public void ThenIShouldNotBeAbleToSeeSubmitRateRequestButton()
        {
            Report.WriteLine("Hidden functionality of Submit Rate Request button");
            VerifyElementNotVisible(attributeName_id, SubmitRateRequestButton_Id, "Submit Rate Request Button");
        }

        [Then(@"I should be able to view Submit Rate Request Button")]
        public void ThenIShouldBeAbleToViewSubmitRateRequestButton()
        {
            Report.WriteLine("Visibility of Submit Rate Request button");
            VerifyElementPresent(attributeName_id, SubmitRateRequestButton_Id, "Submit Rate Request Button");
        }


        [Then(@"I must be able to view Export button")]
        public void ThenIMustBeAbleToViewExportButton()
        {
            Report.WriteLine("Export Button");
            VerifyElementPresent(attributeName_id, QuoteList_Export_Button_Id, "Export");
        }

        [Then(@"I must be able to view a search field with dropdown and (.*) options")]
        public void ThenIMustBeAbleToViewASearchFieldWithDropdownAndOptions(string Textsearch)
        {
            Report.WriteLine("Search Field");
            VerifyElementPresent(attributeName_xpath, QuoteList_SearchBox_Xpath, "Search");
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
            Click(attributeName_xpath, QuoteList_SearchDropdown_SelectAllCheckbox_Xpath);
            Click(attributeName_xpath, QuoteList_SearchDropdownValue1_Xpath);
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, Textsearch);
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
        }

        [Then(@"I must be able to view Filters with options (.*),(.*),(.*) and (.*)")]
        public void ThenIMustBeAbleToViewFiltersWithOptionsAnd(string All, string New, string Expired, string Past24Hours)
        {
            Report.WriteLine("Filters");
            VerifyElementPresent(attributeName_id, QuoteList_AllRadioButton_Id, "All");
            //string ActualAllFilter_Value = Gettext(attributeName_xpath, QuoteList_AllLabel_Xpath);
            //Assert.AreEqual(ActualAllFilter_Value, All);
            Verifytext(attributeName_xpath, QuoteList_AllLabel_Xpath, All);
            VerifyElementPresent(attributeName_id, QuoteList_NewRadioButton_Id, "New");
            Verifytext(attributeName_xpath, QuoteList_NewLabel_Xpath, New);
            VerifyElementPresent(attributeName_id, QuoteList_ExpiredButton_Id, "Expired");
            Verifytext(attributeName_xpath, QuoteList_ExpiredLabel_Xpath, Expired);
            VerifyElementPresent(attributeName_id, QuoteList_Past24Hours_Id, "Past24Hours");
            Verifytext(attributeName_xpath, QuoteList_Past24HoursLabel_Xpath, Past24Hours);
        }
        
        [Then(@"I must be able to view quote list Grid with display list View option")]
        public void ThenIMustBeAbleToViewQuoteListGridWithDisplayListViewOption()
        {
            Report.WriteLine("Display list View");
            VerifyElementPresent(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath, "DisplayList");

        }
        [Then(@"I must have an option to select display type from the (.*)")]
        public void ThenIMustHaveAnOptionToSelectDisplayTypeFromThe(string dropdown)
        {
            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
            //SelectDropdownValueFromList(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, dropdown);
            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, dropdown);
        }


        [Then(@"I must be able to view Display list view forward and backward page options")]
        public void ThenIMustBeAbleToViewDisplayListViewForwardAndBackwardPageOptions()
        {
            Report.WriteLine("Forward and Backward display button");
            VerifyElementPresent(attributeName_xpath, QuoteList_TopGrid_ViewPreviousIcon_Xpath, "Backward Display");
            VerifyElementPresent(attributeName_xpath, QuoteList_TopGrid_ViewNextIcon_Xpath, "Forward Display");
        }

        [Then(@"The Quote List page grid should display expected header values")]
        public void ThenTheQuoteListPageGridShouldDisplayExpectedHeaderValues()
        {
            for (int i = 1; i <= 7; i++)
            {
                IList<IWebElement> ActualGridValues = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='QuotesGrid']/thead/tr/th[" + i + "]"));
                List<string> ExpectedHeaderValues = new List<string>(new string[] { "DATE SUBMITTED", "STATION / CUSTOMER NAME", "REQUEST NUMBER", "STATUS", "SERVICE", "CARRIER NAME", "RATES" });
                foreach (var val in ActualGridValues)
                {
                    if (ExpectedHeaderValues.Contains(val.Text))
                    {
                        Report.WriteLine("Display" + val.Text + "is the Quote List grid value");
                    }
                    else
                    {
                        Report.WriteLine("Values does not exists");
                    }
                }


            }

        }


        [Then(@"The Rate field in the grid should display - (.*),(.*),(.*)")]
        public void ThenTheRateFieldInTheGridShouldDisplay_(string QuoteValue, string EstCostValue, string EstMarginValue)
        {
            Report.WriteLine("Rate Field Labels");
            Verifytext(attributeName_xpath, QuoteList_Rates_QuoteLabel_Xpath, QuoteValue);
            Verifytext(attributeName_xpath, QuoteList_Rates_EstCostLabel_Xpath, EstCostValue);
            Verifytext(attributeName_xpath, QuoteList_Rates_EstMarginLabel_Xpath, EstMarginValue);

        }
        
        [Then(@"I should be able to view Quote details icon button for each row")]
        public void ThenIShouldBeAbleToViewQuoteDetailsIconButtonForEachRow()
        {
            Report.WriteLine("Quote Details Button");
            VerifyElementPresent(attributeName_xpath, QuoteList_QuoteDetailsIcon_Xpath, "Quote Details");

        }
       
        
        [Then(@"I should not be able to view Customer selection drop down list in the quote list page")]
        public void ThenIShouldNotBeAbleToViewCustomerSelectionDropDownListInTheQuoteListPage()
        {
            Report.WriteLine("Customer dropdown hidden functionality for external users");
            VerifyElementNotPresent(attributeName_xpath, QuoteList_CustomerDropdown_Xpath, "Customer dropdown");
        }
    }
}
