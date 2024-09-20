using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class Integration_IntegrationListPageSteps : Integration
    {
        [Then(@"Submit Integration Request Button")]
        public void ThenSubmitIntegrationRequestButton()
        {
            VerifyElementPresent(attributeName_id, IntegrationList_SubmitIntegrationRequest_Button_Id, "SubmitIntegrationRequest");
        }


        [Then(@"I should be see the Export button")]
        public void ThenIShouldBeSeeTheExportButton()
        {
            VerifyElementPresent(attributeName_id, IntegrationList_Export_Button_Id, "Export");
        }

        [Then(@"I should see the search field with search text box")]
        public void ThenIShouldSeeTheSearchFieldWithSearchTextBox()
        {
            Verifytext(attributeName_xpath, IntegrationList_SearchTextBox_xpath, "Search...");
        }


        [Then(@"I should see the filter radio buttons All, Pending Approval, In Progress , Completed")]
        public void ThenIShouldSeeTheFilterRadioButtonsAllPendingApprovalInProgressCompleted()
        {
            Verifytext(attributeName_xpath, IntegrationList_Filter_All_RadioButton_xpath, "All");
            Verifytext(attributeName_xpath, IntegrationList_Filter_PendingApproval_RadioButton_xpath, "Pending Approval");
            Verifytext(attributeName_xpath, IntegrationList_Filter_InProgress_RadioButton_xpath, "In Progress");
            Verifytext(attributeName_xpath, IntegrationList_Filter_Completed_RadioButton_xpath, "Completed");

        }

        [Then(@"only ten records should be displayed by default in Integration List page")]
        public void ThenOnlyTenRecordsShouldBeDisplayedByDefaultInIntegrationListPage()
        {

            Report.WriteLine("Verifying the default records on the page load");
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var defaultOption = executor.ExecuteScript("return $('#gridIntegrationList_length :selected').val()");
            Assert.AreEqual("10", defaultOption);
            Report.WriteLine("Default 10 option is selected in the dropdown");
        }


        [Then(@"verify the options (.*) when I click on the view list top grid")]
        public void ThenVerifyTheOptionsWhenIClickOnTheViewListTopGrid(string Options)
        {
            Click(attributeName_xpath, IntegrationList_TopGrid_DisplayListViewDropdown_Xpath);

            Report.WriteLine("Verifying the options present under view dropdown");
            string[] values = Options.Split(',');
            IList<IWebElement> UIValues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_TopGrid_DisplayListDropdownOptions_Xpath));
            List<string> ExpectedVal = new List<string>();

            foreach (var v in values)
            {
                ExpectedVal.Add(v);
            }

            Assert.AreEqual(ExpectedVal.Count, UIValues.Count);
            for (int i = 0; i < UIValues.Count; i++)
            {
                if (ExpectedVal.Contains(UIValues[i].Text))
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


        [Then(@"Verify the forward navigation functionality on the top grid")]
        public void ThenVerifyTheForwardNavigationFunctionalityOnTheTopGrid()
        {
            
            string totalrecords = Gettext(attributeName_xpath, IntegrationList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewNextIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }



        [Then(@"I click on the forword navigation icon in the top grid of the Integration List page")]
        public void ThenIClickOnTheForwordNavigationIconInTheTopGridOfTheIntegrationListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, IntegrationList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on next icon");
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewNextIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }

        [Then(@"I click on the backword navigation icon in the top grid of the Integration List page")]
        public void ThenIClickOnTheBackwordNavigationIconInTheTopGridOfTheIntegrationListPage()
        {
            string totalrecords = Gettext(attributeName_xpath, IntegrationList_TopGrid_DisplayListView_Xpath);
            string displaycount = totalrecords.Substring(totalrecords.LastIndexOf("OF") + 2);
            int DC = Convert.ToInt32(displaycount);
            if (DC > 10)
            {
                Report.WriteLine("Clicking on previous or left navigation icon");
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewNextIcon_Xpath);
                Click(attributeName_xpath, IntegrationList_TopGrid_ViewPreviousIcon_Xpath);
            }
            else
            {
                Report.WriteLine("Unable to click on next icon as number of records are less than 10");
            }
        }

        [Then(@"Verify the Column names on the Integration list page")]
        public void ThenVerifyTheColumnNamesOnTheIntegrationListPage()
        {
            //IList<IWebElement> ColumnNames = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_ColumnNames_xpath));
            //List<string> ascSort = new List<string>();
            //List<string> expectedColumnValues = new List<string>(new string[] { "Station", "CompanyName", "Status", "SubmitDate", "LastDate" });

            //foreach (var s in expectedColumnValues)
            //{
            //    if (expectedColumnValues.Contains(s))
            //    {
            //        Report.WriteLine("Column name " + s + "displaying in exported excel sheet matches with UI column name");
            //    }
            //    else
            //    {
            //        Assert.Fail();
            //    }
            }
        }









    }

