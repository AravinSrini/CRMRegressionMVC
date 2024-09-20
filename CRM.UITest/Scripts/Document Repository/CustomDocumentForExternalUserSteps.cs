using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Document_Repository
{
    [Binding]
    public sealed class CustomDocumentForExternalUserSteps : Shipmentlist
    {
        string inputParameter = string.Empty;
        [Given(@"I enter (.*) in the Search Documents field")]
        [When(@"I enter (.*) in the Search Documents field")]
        public void GivenIEnterSomeValueInTheSearchDocumentsField(string input)
        {
            inputParameter = input;
            SendKeys(attributeName_xpath, DocumentRepository_CustomerFolder_Search_Xpath, input);
        }

        [Given(@"I have navigated to the Document Repository Page in CRM")]
        public void GivenIHaveNavigatedToTheDocumentRepositoryPageInCRM()
        {
            Report.WriteLine("Clicking Document Repository");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, DocumentRepositoryIcon_xpath);
            Report.WriteLine("Wait for page load");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I click on the tab for my custom documents folder")]
        [When(@"I click on the tab for my custom documents folder")]
        public void GivenIClickOnTheTabForMyCustomDocumentsFolder()
        {
            Report.WriteLine("Clicking Customer Folder");
            Click(attributeName_xpath, "//*[@id='main']/div[1]/div/div[8]");
            Report.WriteLine("Thread sleep for 0.5 seconds");
            Thread.Sleep(500);
        }

        [Given(@"I click on the Search button for the custom folder")]
        [When(@"I click on the Search button for the custom folder")]
        public void WhenIClickOnTheSearchButtonForTheCustomFolder()
        {
            Report.WriteLine("Clicking Search Button");
            Click(attributeName_xpath, DocumentRepository_CustomerFolder_Search_Button_Xpath);
        }

        [When(@"I clear the Search Documents field")]
        public void WhenIClearTheSearchDocumentsField()
        {
            Report.WriteLine("Clearing Search Field");
            SendKeys(attributeName_xpath, DocumentRepository_CustomerFolder_Search_Xpath, Keys.Backspace);
            Thread.Sleep(500);
        }

        [Then(@"I will see the Grid level loading icon")]
        public void ThenIWillSeeTheGridLevelLoadingIcon()
        {
            Report.WriteLine("Verify Loading Icon Visible");
            VerifyElementVisible(attributeName_id, LoadingSymbol_id, "loading icon");
            Report.WriteLine("Waiting for loading icon not visible");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "loading icon");
        }

        [Then(@"the Search button will be enabled")]
        public void ThenTheSearchButtonWillBeEnabled()
        {
            Report.WriteLine("Verify Search Button Enabled");
            VerifyElementEnabled(attributeName_xpath, DocumentRepository_CustomerFolder_Search_Button_Xpath, "search button");
            VerifyElementVisible(attributeName_xpath, DocumentRepository_CustomerFolder_Search_Button_Xpath, "search button");
        }

        [Then(@"the Search button is inactive")]
        public void ThenTheSearchButtonIsInactive()
        {
            Report.WriteLine("Verify Search Button Disabled");
            IWebElement searchButton = GlobalVariables.webDriver.FindElement(By.XPath(DocumentRepository_CustomerFolder_Search_Button_Xpath));
            Assert.IsTrue(searchButton.GetAttribute("class").Contains("disabled"));
        }

        [Then(@"I will see a Search button associated to the Search Documents text box")]
        public void ThenIWillSeeASearchButtonAssociatedToTheSearchDocumentsTextBox()
        {
            Report.WriteLine("Verify Serach button visible");
            VerifyElementVisible(attributeName_xpath, DocumentRepository_CustomerFolder_Search_Button_Xpath, "search button");
        }

        [Then(@"I will not see the magnifying glass icon in the Search Documents text box")]
        public void ThenIWillNotSeeTheMagnifyingGlassIconInTheSearchDocumentsTextBox()
        {
            Report.WriteLine("Verify Magnifying Glass Icon Not Visible");
            VerifyElementNotVisible(attributeName_xpath, "//*[@id='table-search']/span[1]", "magnifying glass");
        }

        [Then(@"I will see a message in the grid (.*)")]
        public void ThenIWillNotSeeAnyDocumentsLoadedInTheResultsGrid(string messageInGrid)
        {
            Report.WriteLine("Verify results grid contains '" + messageInGrid + "'");
            IWebElement gridMessage = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='docRepoTable']/table/tbody/tr/td"));
            Assert.AreEqual(messageInGrid, gridMessage.Text);
        }

        [Then(@"I will not see any documents loaded in the results grid")]
        public void ThenIWillNotSeeAnyDocumentsLoadedInTheResultsGrid()
        {
            Report.WriteLine("Verify results grid contains no documents");
            Verifytext(attributeName_xpath, "//*[@id='pager_top']/span[2]","NO ITEMS");
        }

        [Then(@"the grid will display last one year records from the custom folder that match my search parameters")]
        public void ThenTheGridWillDisplayLastOneYearRecordsFromTheCustomFolderThatMatchMySearchParameters()
        {
            Report.WriteLine("Clicking view all dropdown");
            WaitForElementNotVisible(attributeName_id, LoadingSymbol_id, "Loading icon");
            Click(attributeName_xpath, DocumentRepository_CustomerFolder_ViewAll_Xpath);
            Report.WriteLine("Selecting all from view all from dropdown");
            ReadOnlyCollection<IWebElement> dropDowns = GlobalVariables.webDriver.FindElements(By.Id("count_listbox"));
            foreach(IWebElement element in dropDowns)
            {
                ReadOnlyCollection<IWebElement> dropDownOptions = element.FindElements(By.TagName("li"));
                IWebElement[] webElements = new IWebElement[5];
                dropDownOptions.CopyTo(webElements, 0);
                try
                {
                    webElements[4].Click();
                }
                catch
                {

                }
            }
            Report.WriteLine("Clicking order by date");
            Click(attributeName_xpath, DocumentRepository_CustomerFolder_OrderByDate_Xpath);
            string lastDocDateString = Gettext(attributeName_xpath, "//div[@id='docRepoTable']//tbody/tr[1]/td[5]");
            DateTime lastDocDate = DateTime.Parse(lastDocDateString);
            Assert.IsTrue((DateTime.Now - lastDocDate).Days < 366);
            string directory = @"\\acwin-dlbp03\T3_Micro_BOLs_test";
            string searchParameter = "*" + inputParameter + "*";
            string [] fileNames = Directory.GetFiles(directory, searchParameter, SearchOption.AllDirectories);
            for(int i=0;i<fileNames.Length;i++)
            {
                string fileName = fileNames[i].ToString();
                IWebElement tableFileName = GlobalVariables.webDriver.FindElement(By.XPath("//*[@id='docRepoTable']/table/tbody/tr[" + (i + 1) + "]/td[3]/div[2]/span"));
                string trimmedFileName = fileName.Substring(41, fileName.Length - 41).Replace(" ", string.Empty);
                Assert.AreEqual(trimmedFileName, tableFileName.Text.Replace(" ", ""));
            }
        }

    }
}
