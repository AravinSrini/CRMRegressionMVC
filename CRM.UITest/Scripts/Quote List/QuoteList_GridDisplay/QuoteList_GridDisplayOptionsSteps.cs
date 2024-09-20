using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Quote_List.QuoteList_GridDisplay
{
    [Binding]
    public class QuoteList_GridDisplayOptionsSteps : Quotelist
    {
        [When(@"I click on view dropdown present in top grid of quote list page")]
        public void WhenIClickOnViewDropdownPresentInTopGridOfQuoteListPage()
        {
            Thread.Sleep(10000);
            Report.WriteLine("Clicking on View dropdown");
            Click(attributeName_xpath, QuoteList_TopGrid_DisplayListViewDropdown_Xpath);
        }
        
        [When(@"I click on view dropdown present in bottom grid of quote list page")]
        public void WhenIClickOnViewDropdownPresentInBottomGridOfQuoteListPage()
        {
            Report.WriteLine("Clicking on View dropdown");
            Click(attributeName_xpath, QuoteList_BottomGrid_DisplayListViewDropdown_Xpath);
        }
        
        [When(@"I click on right navigation icon in top grid of quote list page")]
        public void WhenIClickOnRightNavigationIconInTopGridOfQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, QuoteList_TopGrid_ViewNextIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I click on right navigation icon in bottom grid of quote list page")]
        public void WhenIClickOnRightNavigationIconInBottomGridOfQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, QuoteList_BottomGrid_ViewNextIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I click on left navigation icon in top grid of quote list page")]
        public void WhenIClickOnLeftNavigationIconInTopGridOfQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, QuoteList_TopGrid_ViewPreviousIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I click on left navigation icon in bottom grid of quote list page")]
        public void WhenIClickOnLeftNavigationIconInBottomGridOfQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, QuoteList_BottomGrid_ViewPreviousIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [When(@"I select any (.*) from view dropdown present in top grid of quote list page")]
        public void WhenISelectAnyFromViewDropdownPresentInTopGridOfQuoteListPage(string option)
        {
            Thread.Sleep(10000);
            Report.WriteLine("Select option from view dropdown");            
            SelectDropdownlistvalue(attributeName_xpath, QuoteList_TopGrid_DisplayListDropdownOptions_Xpath, option);
        }
        
        [When(@"I select any (.*) from view dropdown present in bottom grid of quote list page")]
        public void WhenISelectAnyFromViewDropdownPresentInBottomGridOfQuoteListPage(string option)
        {
            Thread.Sleep(5000);
            Report.WriteLine("Select option from view dropdown");
            SelectDropdownlistvalue(attributeName_xpath, QuoteList_BottomGrid_DisplayListViewDropdown_Xpath, option);
        }

        [Then(@"only ten records should be displayed by default")]
        public void ThenOnlyTenRecordsShouldBeDisplayedByDefault()
        {
            Report.WriteLine("Verifying the default records on the page load");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var defaultOption = executor.ExecuteScript("return $('#QuotesGrid_length :selected').val()");
            Assert.AreEqual("10", defaultOption);
            Report.WriteLine("Default 10 option is selected in the dropdown");
        }
        
        [Then(@"I should be able to see (.*)")]
        public void ThenIShouldBeAbleToSee(string options)
        {
            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(QuoteList_TopGrid_DisplayListDropdownOptions_Xpath));
            List<string> ExpectedVal = new List<string>();

            foreach(var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for(int i = 0; i < UIValues.Count; i++)
            {
                if(ExpectedVal.Contains(UIValues[i].Text))
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " is displaying under view dropdown");
                }
                else
                {
                    Report.WriteLine("Option" + UIValues[i].Text + " displaying under view dropdown is not expected");
                    Assert.IsTrue(false);
                }
            }
        }
        
        [Then(@"Next set of records should be displayed in quote list page")]
        public void ThenNextSetOfRecordsShouldBeDisplayedInQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), "20");
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }
        
        [Then(@"previous default records should be displayed in quote list page")]
        public void ThenPreviousDefaultRecordsShouldBeDisplayedInQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), "10");
                Report.WriteLine("Initial set of records are displaying in page");
            }
            else
            {
                Report.WriteLine("Unable to verify the functionality of left navigation icon as number of records are less than 10");
            }
        }

        [Then(@"Selected (.*) records should be displayed in quote list page")]
        public void ThenSelectedRecordsShouldBeDisplayedInQuoteListPage(string count)
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(count);

            if (DCount > UICount)
            {
                int rowCount = GetCount(attributeName_xpath, QuoteList_NoOfRows_Xpath);
                Assert.AreEqual(rowCount, UICount);
            }
            else
            {
                Report.WriteLine("Selected view option" + count + " is more than total number of records" + DCount + " exists for the logged in user");
            }
        }

        [Then(@"text in top grid should match with selected (.*) in quote list page")]
        public void ThenTextInTopGridShouldMatchWithSelectedInQuoteListPage(string count)
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(count);

            if (DCount > UICount)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), count);
            }
            else
            {
                Report.WriteLine("Unable to verify the text functionality");
                Report.WriteLine("Selected view option" + count + " is more than total number of records" + DCount + " exists for the logged in user");
            }
        }

        [Then(@"text in bottom grid should match with selected (.*) in quote list page")]
        public void ThenTextInBottomGridShouldMatchWithSelectedInQuoteListPage(string count)
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(count);

            if (DCount > UICount)
            {
                int toindex = totalrecords.IndexOf("-") + "- ".Length;
                int ofindex = totalrecords.LastIndexOf("OF");

                string selecteValue = totalrecords.Substring(toindex, ofindex - toindex);
                Assert.AreEqual(selecteValue.Trim(), count);
            }
            else
            {
               Report.WriteLine("Unable to verify the text functionality");
               Report.WriteLine("Selected view option" + count + " is more than total number of records" + DCount + " exists for the logged in user");
            }
        }
        
        [Then(@"right navigation icon should be disabled in top grid in quote list page")]
        public void ThenRightNavigationIconShouldBeDisabledInTopGridInQuoteListPage()
        {
            Report.WriteLine("Verifying the right navigation in quote list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_next'][@class = 'paginate_button next disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
        
        [Then(@"right navigation icon should be disabled in bottom grid in quote list page")]
        public void ThenRightNavigationIconShouldBeDisabledInBottomGridInQuoteListPage()
        {
            Report.WriteLine("Verifying the right navigation in quote list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[@class = 'paginate_button next disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
        
        [Then(@"left navigation icon should be disabled in top grid in quote list page")]
        public void ThenLeftNavigationIconShouldBeDisabledInTopGridInQuoteListPage()
        {
            Report.WriteLine("Verifying the left navigation in quote list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_previous'][@class = 'paginate_button previous disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }
        
        [Then(@"left navigation icon should be disabled in bottom grid in quote list page")]
        public void ThenLeftNavigationIconShouldBeDisabledInBottomGridInQuoteListPage()
        {
            Report.WriteLine("Verifying the left navigation in quote list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[@class = 'paginate_button previous disabled']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }

        [When(@"I see left navigation icon disabled in top grid of quote list page")]
        public void WhenISeeLeftNavigationIconDisabledInTopGridOfQuoteListPage()
        {
            Report.WriteLine("Verifying the left navigation in quote list page");
            bool value = GlobalVariables.webDriver.FindElement(By.XPath(" .//*[@id='QuotesGrid_previous'][@Class = 'paginate_button previous']")).Displayed;
            Assert.AreEqual("True", value.ToString());
        }

        [Then(@"left navigation should be enabled icon in top grid of the quote list page")]
        public void ThenLeftNavigationShouldBeEnabledIconInTopGridOfTheQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Verifying the left navigation in quote list page");
                bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_previous'][@class = 'paginate_button previous']")).Displayed;
                Assert.AreEqual("True", value.ToString());              
            }
            else
            {             
                Report.WriteLine("Unable to verify the funcitonality of previous icon as number of records are less than 10");
            }

        }

        [Then(@"right navigation icon should be disabled in top grid in quote list page when number of records are less than view (.*)")]
        public void ThenRightNavigationIconShouldBeDisabledInTopGridInQuoteListPageWhenNumberOfRecordsAreLessThanView(string option)
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            int UICount = Convert.ToInt32(option);
            if (UICount > DCount)
            {
                Report.WriteLine("Verifying the right navigation in quote list page");
                bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_next'][@class = 'paginate_button next disabled']")).Displayed;
                Assert.AreEqual("True", value.ToString());
            }
            else
            {
                Report.WriteLine("Unable to verify the right navigation functionality as view option is less than total displaying count");
            }
        }

        [Then(@"right navigation icon should be disabled in bottom grid in quote list page when number of records are less than view (.*)")]
        public void ThenRightNavigationIconShouldBeDisabledInBottomGridInQuoteListPageWhenNumberOfRecordsAreLessThanView(string option)
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_BottomGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DCount = Convert.ToInt32(displaycount);
            if (Convert.ToInt32(option) > DCount)
            {
                Report.WriteLine("Verifying the right navigation in quote list page");
                bool value = GlobalVariables.webDriver.FindElement(By.XPath(".//*[@id='QuotesGrid_wrapper']/div[2]/div/div[2]/div[2]/ul/li[@class = 'paginate_button next disabled']")).Displayed;
                Assert.AreEqual("True", value.ToString());
            }
            else
            {
                Report.WriteLine("Unable to verify the right navigation functionality as view option is less than total displaying count");
            }
        }


        [Then(@"left navigation should be enabled icon in bottom grid of the quote list page")]
        public void ThenLeftNavigationShouldBeEnabledIconInBottomGridOfTheQuoteListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, QuoteList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Verifying the left navigation in quote list page");
                bool value = IsElementEnabled(attributeName_xpath, QuoteList_BottomGrid_ViewPreviousIcon_Xpath, "Left Navigation Icon");
                Assert.AreEqual("True", value.ToString());
            }
            else
            {
                Report.WriteLine("Unable to verify the funcitonality of previous icon as number of records are less than 10");
            }
        }
    }
}
