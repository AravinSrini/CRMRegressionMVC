using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Integration_List_Page
{
    [Binding]
    public class IntegrationListpageSortSteps : Integration
    {
        CommonMethodsCrm crm = new CommonMethodsCrm();

        [Given(@"I am an system admin, operations, sales, sales management, or station owner user (.*) and (.*)")]
        public void GivenIAmAnSystemAdminOperationsSalesSalesManagementOrStationOwnerUserAnd(string Username, string Password)
        {

            crm.LoginToCRMApplication(Username, Password);

        }

        [When(@"I am on the Integration List page")]
        public void WhenIAmOnTheIntegrationListPage()
        {

          
            Click(attributeName_xpath, IntegrationMenuIcon);
                Report.WriteLine("User see the Title Integration Request List Page ");
        }

        [When(@"I select display type from the '(.*)' in the Integration List page")]
        public void WhenISelectDisplayTypeFromTheInTheIntegrationListPage(string dropdown)
        {
            Report.WriteLine("Display option dropdown");
            Click(attributeName_xpath, IntegrationList_TopGrid_DisplayListViewDropdown_Xpath);
            SelectDropdownlistvalue(attributeName_xpath, IntegrationList_TopGrid_DisplayListDropdownOptions_Xpath, dropdown);
         
            Click(attributeName_xpath, IntegrationList_Filter_All_RadioButton_xpath);
           
        }

        [Then(@"I should be able to view and sort Station values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortStationValuesInAscendingAndDescendingOrder()
        {

            int row = GetCount(attributeName_xpath, IntegrationList_StationNameAll_Values_Xpath);
            string noReocrdsCheck = Gettext(attributeName_xpath, ".//*[@id='gridIntegrationList']/tbody/tr/td");
            if ((row >= 1) && (noReocrdsCheck != "No Results Found"))
            {
             List<string> ascSort = new List<string>();
             List<string> desSort = new List<string>();
             Report.WriteLine("Clicking on sorting icon");
             Click(attributeName_xpath, IntegrationList_StationNameClick_Xpath);

             Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> stationColCount = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_StationNameAll_Values_Xpath));
                foreach (IWebElement element in stationColCount)
                {
                    ascSort.Add((element.Text).ToString());
                   
                }
                Click(attributeName_xpath, IntegrationList_StationNameClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_StationNameAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for Station column");
            }
        }



        [Then(@"I should be able to view and sort Company name values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortCompanyNameValuesInAscendingAndDescendingOrder()
        {
            int row = GetCount(attributeName_xpath, IntegrationList_RowCount_xpath);
            if (row >= 1)
            {
                List<string> ascSort = new List<string>();
                List<string> desSort = new List<string>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, IntegrationList_CompanyNameClick_Xpath);

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_CompanyNameAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                Click(attributeName_xpath, IntegrationList_CompanyNameClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_CompanyNameAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                Assert.AreEqual(companyNameColCount.Count, sortedvalues.Count);
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [Then(@"I should be able to view and sort Current Status values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortCurrentStatusValuesInAscendingAndDescendingOrder()
        {
            int row = GetCount(attributeName_xpath, IntegrationList_RowCount_xpath);
            if (row >= 1)
            {
                List<string> ascSort = new List<string>();
                List<string> desSort = new List<string>();
                Report.WriteLine("Clicking on sorting icon");
                Click(attributeName_xpath, IntegrationList_CurrentStatusClick_Xpath);

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_CurrentStatusAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                Click(attributeName_xpath, IntegrationList_CurrentStatusClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_CurrentStatusAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }

        [Then(@"I should be able to view and sort Submit Date values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortSubmitDateValuesInAscendingAndDescendingOrder()
        {
            int row = GetCount(attributeName_xpath, IntegrationList_RowCount_xpath);
            if (row >= 1)
            {
                List<string> ascSort = new List<string>();
                List<string> desSort = new List<string>();
                Report.WriteLine("Clicking on sorting icon");
                //Click(attributeName_xpath, IntegrationList_SubmitDateClick_Xpath);
               
                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_SubmitDateAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                Click(attributeName_xpath, IntegrationList_SubmitDateClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_SubmitDateAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                ascSort.Sort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }


        [Then(@"I should be able to view and sort Last Date values in ascending and descending order")]
        public void ThenIShouldBeAbleToViewAndSortLastDateValuesInAscendingAndDescendingOrder()
        {
            int row = GetCount(attributeName_xpath, IntegrationList_RowCount_xpath);
            if (row >= 1)
            {
                List<string> ascSort = new List<string>();
                List<string> desSort = new List<string>();
                Report.WriteLine("Clicking on sorting icon");
                //Click(attributeName_xpath, IntegrationList_LastDateClick_Xpath);
                

                Report.WriteLine("Reading the values from the Insured Rate columns after ascdending sorting");
                IList<IWebElement> companyNameColCount = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_LastDateAll_Values_Xpath));
                foreach (IWebElement element in companyNameColCount)
                {
                    ascSort.Add((element.Text).ToString());

                }
                Click(attributeName_xpath, IntegrationList_LastDateClick_Xpath);
                Report.WriteLine("Reading the values from the Insured Rate columns after descending sorting");
                IList<IWebElement> sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(IntegrationList_LastDateAll_Values_Xpath));
                foreach (IWebElement element in sortedvalues)
                {
                    desSort.Add((element.Text).ToString());
                }
                desSort.Sort();
                ascSort.Sort();
                Report.WriteLine("Comparing the values after sorting");
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (ascSort[i] == desSort[i])
                    {
                        Report.WriteLine("Expected value :" + ascSort[i] + " is equal to the actual value: " + desSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteLine("No records for company Name column");
            }
        }







    }
}
