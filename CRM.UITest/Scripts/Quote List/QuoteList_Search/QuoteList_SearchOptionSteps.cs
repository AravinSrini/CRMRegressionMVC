using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Threading;
using System.Configuration;
using CRM.UITest.CommonMethods;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_Search
{
    [Binding]
    public class QuoteList_SearchOptionSteps : Quotelist
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am a DLS user and login into application with valid crmOperation@user\.com and Te\$t(.*)")]
        public void GivenIAmADLSUserAndLoginIntoApplicationWithValidCrmOperationUser_ComAndTeT(int p0)
        {
            string username = ConfigurationManager.AppSettings["username-OperationsCrm"].ToString();
            string password = ConfigurationManager.AppSettings["password-OperationsCrm"].ToString();
            crm.LoginToCRMApplication(username, password);
        }

        [Given(@"I am a DLS user and login into application with valid SurShipEntry@user\.com and Te\$t(.*)")]
        public void GivenIAmADLSUserAndLoginIntoApplicationWithValidSurShipEntryUser_ComAndTeT(int p0)
        {
            string username = ConfigurationManager.AppSettings["username-shipentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-shipentry"].ToString();
            crm.LoginToCRMApplication(username, password);
        }


        [When(@"I click on dropdown arrow in the search field")]
        public void WhenIClickOnDropdownArrowInTheSearchField()
        {
            Report.WriteLine("Click on dropdown");
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);
            Thread.Sleep(4000);
        }

        [When(@"I do select display account type from the '(.*)'")]
        public void WhenIDoSelectDisplayAccountTypeFromThe(string optionType)
        {
            Click(attributeName_id, "CategoryType_chosen");

            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath("//div[@id='CategoryType_chosen']//ul/li"));
            int DropDownCount = DropDownList.Count;
            for (int i = 1; i <= DropDownCount; i++)
            {
                int j = i - 1;
                if (DropDownList[j].Text == "ZZZ - Web Services Test")
                {
                    DropDownList[j].Click();
                    break;
                }
            }
            Report.WriteLine("Display option dropdown");
            //Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
            //SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, optionType);
        }


        [Then(@"I must be able to click on select all checkbox and unselect all the selected fields")]
        public void ThenIMustBeAbleToClickOnSelectAllCheckboxAndUnselectAllTheSelectedFields()
        {
            Report.WriteLine("Unselect Select all");
            Click(attributeName_xpath, QuoteList_Search_SelectAll_Checkbox_Xpath);
        }

       

        [Then(@"I must be able to select fields such as - DateSubmitted,Requested Number,Status from the dropdown")]
        public void ThenIMustBeAbleToSelectFieldsSuchAs_DateSubmittedRequestedNumberStatusFromTheDropdown()
        {
            Report.WriteLine("Select specified fields");
            Click(attributeName_xpath, QuoteList_Search_DateSubmitted_Checkbox_Xpath);
            Click(attributeName_xpath, Quote_List_Search_Status_Checkbox_Xpath);
            Click(attributeName_xpath, Quote_List_Search_RequestedNumber_Checkbox_Xpath);
        }


        [Then(@"I must be able to search quotes by typing Datesubmitted values in the search quote field and it should get highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchQuotesByTypingDatesubmittedValuesInTheSearchQuoteFieldAndItShouldGetHighlightedInTheGrid_(string Datesubmitted)
        {
            Report.WriteLine("Verify searched Date in grid");
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, Datesubmitted);
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);

            IList<IWebElement> SearchedDateSubmittedhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(QuotleList_DateSubmittedColumn_Highlighted_Xpath));
            int HighlightedDateCount = SearchedDateSubmittedhighlightedValues.Count;
            foreach (var val in SearchedDateSubmittedhighlightedValues)
            {
                if (Datesubmitted.Contains(val.Text))
                {
                    var colorofHighlighted_DateSubmitted_Value = GetCSSValue(attributeName_classname, QuoteListGrid_Highlight_Class, "background-color");
                    Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_DateSubmitted_Value);
                    Report.WriteLine("Highlighted Date values are appropriate");
                }

                else
                {
                    Assert.Fail();
                }

            }
            Click(attributeName_xpath, QuoteList_SearchboxClose_Xpath);
        }


        [Then(@"I must be able to search quotes by typing RequestedNumber values in the search quote field and it should get highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchQuotesByTypingRequestedNumberValuesInTheSearchQuoteFieldAndItShouldGetHighlightedInTheGrid_(string RequestedNumber)
        {
            Report.WriteLine("Verify searched Requested number in grid");
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, RequestedNumber);
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);

            IList<IWebElement> SearchedRequestedNumberhighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_RequestedNumberColumn_Highlighted_Xpath));
            int HighlightedDateCount = SearchedRequestedNumberhighlightedValues.Count;
            foreach (var val in SearchedRequestedNumberhighlightedValues)
            {
                if (RequestedNumber.Contains(val.Text))
                {
                    var colorofHighlighted_DateSubmitted_Value = GetCSSValue(attributeName_classname, QuoteListGrid_Highlight_Class, "background-color");
                    Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_DateSubmitted_Value);
                    Report.WriteLine("Highlighted Requested number values are appropriate");
                }

                else
                {
                    Assert.Fail();
                }

            }

            Click(attributeName_xpath, QuoteList_SearchboxClose_Xpath);
        }

        [Then(@"I must be able to search quotes by typing Status values in the search quote field and it should get highlighted in the grid- '(.*)'")]
        public void ThenIMustBeAbleToSearchQuotesByTypingStatusValuesInTheSearchQuoteFieldAndItShouldGetHighlightedInTheGrid_(string Status)
        {
            Report.WriteLine("Verify searched Status in grid");
            SendKeys(attributeName_xpath, QuoteList_SearchBox_Xpath, Status);
            Click(attributeName_xpath, QuoteList_SearchBox_DropdownArrow_Xpath);

            IList<IWebElement> SearchedStatushighlightedValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_StatusColumn_Highlighted_Xpath));
            int HighlightedDateCount = SearchedStatushighlightedValues.Count;
            foreach (var val in SearchedStatushighlightedValues)
            {
                if (Status.Contains(val.Text))
                {
                    var colorofHighlighted_DateSubmitted_Value = GetCSSValue(attributeName_classname, QuoteListGrid_Highlight_Class, "background-color");
                    Assert.AreEqual("rgba(81, 123, 207, 0.4)", colorofHighlighted_DateSubmitted_Value);
                    Report.WriteLine("Highlighted Status values are appropriate");
                }

                else
                {
                    Assert.Fail();
                }

            }
            Click(attributeName_xpath, QuoteList_SearchboxClose_Xpath);
        }

       


        [When(@"I click on Clear All button")]
        public void WhenIClickOnClearAllButton()
        {
            Report.WriteLine("Click on Clear Button");
            Click(attributeName_id, QuoteList_Search_ClearButton_Id);
            
        }

        [When(@"I do click on Clear All button")]
        public void WhenIDoClickOnClearAllButton()
        {
            Report.WriteLine("Click on Clear Button");
            Click(attributeName_id, QuoteList_Search_ClearButton_Id);

        }

        [Then(@"I should be able to view expected header values for internal users in search dropdown")]
        public void ThenIShouldBeAbleToViewExpectedHeaderValuesForInternalUsersInSearchDropdown()
        {
            IList<IWebElement> ActualSearchValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_SearchBox_AllDropdownValues_Xpath));
            List<string> ExpectedSearchValues = new List<string>(new string[] { "Select All", "DATE SUBMITTED", "STATION NAME", "CUSTOMER NAME", "STATUS", "SERVICE TYPE", "CARRIER NAME", "REQUESTED NUMEBR", "SERVICE", "SERVICE LEVEL", "QUOTE", "EST COST", "EST MARGIN %" });
            foreach (var val in ActualSearchValues)
            {
                if (ExpectedSearchValues.Contains(val.Text))
                {
                    Report.WriteLine("Display" + val.Text + "is the Quote List search value");
                }
                else
                {
                    Report.WriteLine("Values does not exists");
                }
            }

        }

        
       
        [Then(@"I must be able to view Clear button in the Search dropdown")]
        public void ThenIMustBeAbleToViewClearButtonInTheSearchDropdown()
        {
            Report.WriteLine("View Clear Button");
            VerifyElementPresent(attributeName_id, QuoteList_Search_ClearButton_Id, "ClearButton");
        }

        [Then(@"All the selected options must get cleared in the search quote field dropdown")]
        public void ThenAllTheSelectedOptionsMustGetClearedInTheSearchQuoteFieldDropdown()
        {
            Report.WriteLine("Clear Functionality");
            VerifyElementNotChecked(attributeName_xpath, QuoteList_SearchBox_AllDropdownValues_Xpath, "SearchValues");
        }

        [Then(@"I must be able to view expected search dropdown values for External Users")]
        public void ThenIMustBeAbleToViewExpectedSearchDropdownValuesForExternalUsers()
        {
            IList<IWebElement> ActualSearchValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_SearchBox_AllDropdownValues_Xpath));
            List<string> ExpectedSearchValues = new List<string>(new string[] { "Select All", "DATE SUBMITTED", "STATUS", "SERVICE TYPE", "CARRIER NAME", "REQUEST NUMEBR", "SERVICE", "SERVICE LEVEL", "QUOTE AMOUNT"});
            foreach (var val in ActualSearchValues)
            {
                if (ExpectedSearchValues.Contains(val.Text))
                {
                    Report.WriteLine("Display" + val.Text + "is the Quote List search value");
                }
                else
                {
                    Report.WriteLine("Values does not exists");
                }
            }
        }

        [Then(@"I must be able to view note within Search dropdown")]
        public void ThenIMustBeAbleToViewNoteWithinSearchDropdown()
        {
            Report.WriteLine("Display of Note section");
            Verifytext(attributeName_id, QuoteList_SearchDropdown_NoteSection_Id, "Note: To search multiple quotes, select search criteria and enter keyword.");
        }


       
    }
}