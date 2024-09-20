using System;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using OpenQA.Selenium;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using System.Collections.Generic;
using System.Linq;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class InsuranceClaims_ClaimsList_NewClaimStatusOptionsSelection_98287Steps : InsuranceClaim
    {

        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        List<string> beforeSort = new List<string>();
        List<string> claimsWithAmendStatus = new List<string>();
        List<string> claimsWithSubmittedStatus = new List<string>();
        List<string> claimsWithOpenStatus = new List<string>();
        List<string> claimsWithPaidStatus = new List<string>();
        List<string> claimsWithDeniedStatus = new List<string>();
        List<string> claimsWithCancelledStatus = new List<string>();
        List<string> claimRefColumnStringValues = new List<string>();
        List<string> statusColumnValuesString = new List<string>();
        IList<IWebElement> datesColumnvalue;
        IList<string> datesColumnStringvalue;

        [Given(@"I am a CurrentSprintOperations user")]
        public void GivenIAmACurrentSprintOperationsUser()
        {
            Report.WriteLine("Login Started");
            string username = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Login Successful");
        }
        
        [Given(@"I am a CurrentsprintShpentry user")]
        public void GivenIAmACurrentsprintShpentryUser()
        {
            Report.WriteLine("Login Started");
            string username = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Login Successful");
        }

        [Given(@"I am a CurrentsprintClaimspecialist user")]
        public void GivenIAmACurrentsprintClaimspecialistUser()
        {
            Report.WriteLine("Login Started");
            string username = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Login Successful");
        }

        [Given(@"I am a CurrentsprintSales user")]
        public void GivenIAmACurrentsprintSalesUser()
        {
            Report.WriteLine("Login Started");
            string username = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
            string password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
            CrmLogin.LoginToCRMApplication(username, password);
            Report.WriteLine("Login Successful");
        }




        [Given(@"I am on the Claim List page")]
        public void GivenIAmOnTheClaimListPage()
        {
            Report.WriteLine("Open Claim Page Started");
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            Report.WriteLine("Claim Page Opened Successfully");
        }
        
        [When(@"I click the Check boxes Amend, Submitted ,Open, Paid, Denied & Cancelled")]
        public void WhenIClickTheCheckBoxesAmendSubmittedOpenPaidDeniedCancelled()
        {
            Report.WriteLine("Select Check Box Started");
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            Click(attributeName_xpath, ClaimsList_OpenStatusCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath);
            Report.WriteLine("Check Box checked Successfully");
        }
        
        [Then(@"Check box Select All has to be AutoSelected")]
        public void ThenCheckBoxSelectAllHasToBeAutoSelected()
        {
            Report.WriteLine("Verify Select All AutoSelect Started");
            IWebElement SelectCheckBox = GlobalVariables.webDriver.FindElement(By.XPath(ClaimListSelectAllCheckBox_Xpath));

            if (SelectCheckBox.Selected)
            {

                Assert.IsTrue(SelectCheckBox.Selected, "Checkbox Select All is autochecked");
                Report.WriteLine("Checkbox Select All is autochecked Successfully");
            }
            else
            {
                Report.WriteFailure("Checkbox Select All autocheck Failed");

            }

        }
        
        [Then(@"Claims associated to the user in Status Amend,Submitted,Open,Paid,Denied,Cancelled should be displayed")]
        public void ThenClaimsAssociatedToTheUserInStatusAmendSubmittedOpenPaidDeniedCancelledShouldBeDisplayed()
        {
            Report.WriteLine("Verify Record Display Started");
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("the claims list will be refreshed to display all claims of Amend,Submitted,Open,Paid,Denied,Cancelled");
            string noOfRecordsCheck = Gettext(attributeName_xpath, ClaimListGridValues_Xpath);

            int claimsListRowCount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (claimsListRowCount >= 1 && noOfRecordsCheck != "No Results Found")
            {
                string[] showStatusOptions = { "Amend", "Submitted", "Open", "Paid", "Denied", "Cancelled" };
                // GridData.ClaimsStatusList();

                IList<IWebElement> claimRefColumnValues = GlobalVariables.webDriver.FindElements(By.XPath(DLSWClaimNumberALLValUI_xpath));

                foreach (IWebElement element in claimRefColumnValues)
                {
                    claimRefColumnStringValues.Add(element.Text);
                }

                //taking list of status's
                IList<IWebElement> statusColumnValues = GlobalVariables.webDriver.FindElements(By.XPath(StatusAllValues_Xpath));

                foreach (IWebElement element in statusColumnValues)
                {
                    statusColumnValuesString.Add(element.Text);
                }


                for (int i = 0; i < claimRefColumnStringValues.Count; i++)
                {
                    //Grouping Claims as per status
                    if (statusColumnValuesString[i].Contains(showStatusOptions[0]))
                    { claimsWithAmendStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[1]))
                    { claimsWithSubmittedStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[2]))
                    { claimsWithOpenStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[3]))
                    { claimsWithPaidStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[4]))
                    { claimsWithDeniedStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[5]))
                    { claimsWithCancelledStatus.Add(claimRefColumnStringValues[i]); }
                }

                //verifying the claims with amend status
                if (claimsWithAmendStatus.Count > 0)
                { Report.WriteLine("Claims with Amend status's are present"); }
                else
                { Report.WriteFailure("Claims with Amend status's are not present"); }

                //verifying the claims with Submitted status
                if (claimsWithSubmittedStatus.Count > 0)
                { Report.WriteLine("Claims with Submitted status's are present"); }
                else
                { Report.WriteFailure("Claims with Submitted status's are not present"); }

                //verifying the claims with Open status
                if (claimsWithOpenStatus.Count > 0)
                { Report.WriteLine("Claims with Open status's are present"); }
                else
                { Report.WriteFailure("Claims with Open status's are not present"); }

                //verifying the claims with Paid status
                if (claimsWithPaidStatus.Count > 0)
                { Report.WriteLine("Claims with Paid status's are present"); }
                else
                { Report.WriteFailure("Claims with Paid status's are not present"); }

                //verifying the claims with Denied status
                if (claimsWithDeniedStatus.Count > 0)
                { Report.WriteLine("Claims with Denied status's are present"); }
                else
                { Report.WriteFailure("Claims with Denied status's are not present"); }

                //verifying the claims with Cancelled status
                if (claimsWithCancelledStatus.Count > 0)
                { Report.WriteLine("Claims with Cancelled status's are present"); }
                else
                { Report.WriteFailure("Claims with Cancelled status's are not present"); }
            }
            else
            {
                Report.WriteFailure("No Records found");
            }
            Report.WriteLine("Record Display verified Successfully");
        }
        
        [Then(@"the order of record display should be earliest date to most recent date")]
        public void ThenTheOrderOfRecordDisplayShouldBeEarliestDateToMostRecentDate()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("the claims list default sort will be by earliest Submit Date to most recent Submit Date");
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {
                Report.WriteLine("Reading the default sorted values from the Dates column");
                datesColumnvalue = GlobalVariables.webDriver.FindElements(By.XPath(ClaimListDateSortValues_Xpath)).ToList();
                foreach (IWebElement element in datesColumnvalue)
                {

                    beforeSort.Add((element.Text).Substring(5, 10));
                }

                var DescendingOrderDate = beforeSort.OrderByDescending(i => DateTime.ParseExact(i, "MM/dd/yyyy", null)).ToList();
                var AscendingOrderDate = beforeSort.OrderBy(x => DateTime.ParseExact(x, "MM/dd/yyyy", null)).ToList();


                for (int i = 0; i < AscendingOrderDate.Count; i++)
                {

                    if (beforeSort[i] == AscendingOrderDate[i])
                    {
                        Report.WriteLine("Date displayed :" + beforeSort[i] + " is equal to the Expected Date: " + AscendingOrderDate[i]);
                    }
                    else
                    {
                        Report.WriteLine("Date displayed :" + beforeSort[i] + " is not equal to the Expected Date: " + AscendingOrderDate[i]);
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No records found");
            }

            Report.WriteLine("Order of Date displayed Verified Successful");
        }

        [Then(@"the order of record display should be earliest date to most recent dates")]
        public void ThenTheOrderOfRecordDisplayShouldBeEarliestDateToMostRecentDates()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("the claims list default sort will be by earliest Submit Date to most recent Submit Date");
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {
                Report.WriteLine("Reading the default sorted values from the Dates column");
                datesColumnvalue = GlobalVariables.webDriver.FindElements(By.XPath(ClaimListDateSortValues_Xpath)).ToList();
                foreach (IWebElement element in datesColumnvalue)
                {

                    beforeSort.Add((element.Text).ToString());
                }

                var DescendingOrderDate = beforeSort.OrderByDescending(i => DateTime.ParseExact(i, "MM/dd/yyyy", null)).ToList();
                var AscendingOrderDate = beforeSort.OrderBy(x => DateTime.ParseExact(x, "MM/dd/yyyy", null)).ToList();


                for (int i = 0; i < AscendingOrderDate.Count; i++)
                {

                    if (beforeSort[i] == AscendingOrderDate[i])
                    {
                        Report.WriteLine("Date displayed :" + beforeSort[i] + " is equal to the Expected Date: " + AscendingOrderDate[i]);
                    }
                    else
                    {
                        Report.WriteLine("Date displayed :" + beforeSort[i] + " is not equal to the Expected Date: " + AscendingOrderDate[i]);
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No records found");
            }

            Report.WriteLine("Order of Date displayed Verified Successful");
        }




    }
}
