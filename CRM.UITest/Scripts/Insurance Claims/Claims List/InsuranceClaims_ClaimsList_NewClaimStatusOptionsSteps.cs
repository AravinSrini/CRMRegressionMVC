using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections;

namespace CRM.UITest.Scripts.Insurance_Claims.Claims_List
{
    [Binding]
    public class InsuranceClaims_ClaimsList_NewClaimStatusOptionsSteps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        string userName;
        string password;
        List<string> beforeSort = new List<string>();
        List<string> afterSort = new List<string>();
        List<string> claimsWithAmendStatus = new List<string>();
        List<string> claimsWithSubmittedStatus = new List<string>();
        List<string> claimsWithOpenStatus = new List<string>();
        List<string> claimsWithPaidStatus = new List<string>();
        List<string> claimsWithDeniedStatus = new List<string>();
        List<string> claimsWithCancelledStatus = new List<string>();
        IList<IWebElement> sortedvalues;
        IList<IWebElement> datesColumnCount;
        List<string> claimRefColumnStringValues = new List<string>();
        List<string> statusColumnValuesString = new List<string>();
        string loggedInUserType = null;

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist user, (.*)")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser(string userType)
        {
            loggedInUserType = userType;
            if (userType == "External")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            else if (userType == "Internal")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            else if (userType == "Sales")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            else
            {
                userName = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
                password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
                Report.WriteLine("Logging in as " + userName);
            }
            CrmLogin.LoginToCRMApplication(userName, password);
        }

        [Given(@"the status Select All was selected")]
        public void GivenTheStatusSelectAllWasSelected()
        {
            Report.WriteLine("the status Select All was selected");
            Click(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath);
        }

        [When(@"I clicked on Select All status option")]
        public void WhenIClickedOnSelectAllStatusOption()
        {
            Report.WriteLine("Clicked on Select All check box");
            Click(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath);
        }

        [When(@"I uncheck any of the Amend,Submitted,Open,Paid,Denied,Cancelled status's")]
        public void WhenIUncheckAnyOfTheAmendSubmittedOpenPaidDeniedCancelledStatusS()
        {
            Report.WriteLine("un checking the Amend check box");
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
        }

        [When(@"I uncheck the Select All status")]
        public void WhenIUncheckTheSelectAllStatus()
        {
            Report.WriteLine("un checked the Select All check box");
            Click(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath);
        }

        [When(@"I have selected more than one status")]
        public void WhenIHaveSelectedMoreThanOneStatus()
        {
            Report.WriteLine("Selected more than one status");
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath);
        }

        [When(@"I check all the Amend,Submitted,Open,Paid,Denied,Cancelled status's")]
        public void WhenICheckAllTheAmendSubmittedOpenPaidDeniedCancelledStatusS()
        {
            Report.WriteLine("I check all the status check box options");
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
            Click(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Click(attributeName_xpath, ClaimsList_OpenStatusCheckbox_xpath); //open
            Click(attributeName_xpath, ClaimsList_PaidCheckbox_xpath); //paid
            Click(attributeName_xpath, ClaimsList_DeniedCheckbox_xpath); //denied
            Click(attributeName_xpath, ClaimsList_Cancelled_xpath); //cancelled
        }

        [Then(@"I will see a Show Status option Pending replaced with Submitted")]
        public void ThenIWillSeeAShowStatusOptionPendingReplacedWithSubmitted()
        {
            Report.WriteLine("User will not be displayed with Pending Show Status option");
            VerifyElementNotPresent(attributeName_xpath, ClaimListPendingStatus_Xpath, "Pending");
            VerifyElementVisible(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath, "Submitted");
            Report.WriteLine("User will be displayed with Submitted Show Status option");
        }

        [Then(@"I will see Color code of Pending for Submitted status")]
        public void ThenIWillSeeColorCodeOfPendingForSubmittedStatus()
        {
            IWebElement statusLabel = GlobalVariables.webDriver.FindElement(By.XPath(ClaimsListGrid_SubmittedStatusColor_xpath));
            IJavaScriptExecutor executor = (IJavaScriptExecutor)GlobalVariables.webDriver;
            var submittedStatusColor = executor.ExecuteScript("return window.getComputedStyle(arguments[0], ':before').getPropertyValue('background-color'); ", statusLabel).ToString();

            Assert.AreEqual("rgb(103, 78, 167)", submittedStatusColor);
            Report.WriteLine("Color code for Pending (#674ea7) matching with the Submitted color code of the " + loggedInUserType);
        }

        [Then(@"I will not be displayed with Pending status")]
        public void ThenIWillNotBeDisplayedWithPendingStatus()
        {
            Report.WriteLine("User will not be displayed with Pending Show Status option");
            VerifyElementNotPresent(attributeName_xpath, ClaimListPendingStatus_Xpath, "Pending");
        }

        [Then(@"I will see a new show status option Submitted")]
        public void ThenIWillSeeANewShowStatusOptionSubmitted()
        {
            Report.WriteLine("User will be displayed with new Show Status option - Submitted");
            VerifyElementPresent(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath, "Submitted");
            string expectedStatus = Gettext(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath);
            Assert.AreEqual(expectedStatus, "Submitted");
        }

        [Then(@"I will see a new show status option Amend")]
        public void ThenIWillSeeANewShowStatusOptionAmend()
        {
            Report.WriteLine("User will be displayed with new Show Status option - Amend");
            VerifyElementPresent(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath, "Amend");
            string expectedStatus = Gettext(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            Assert.AreEqual(expectedStatus, "Amend");
        }

        [Then(@"I will see a new show status option Select All")]
        public void ThenIWillSeeANewShowStatusOptionSelectAll()
        {
            Report.WriteLine("User will be displayed with new Show Status option - Select All");
            VerifyElementPresent(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath, "Select All");
            string expectedStatus = Gettext(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath);
            Assert.AreEqual(expectedStatus, "Select All");
        }

        [Then(@"the order of Show status is Amend,Submitted,Open,Paid,Denied,Cancelled and Select All")]
        public void ThenTheOrderOfShowStatusIsAmendSubmittedOpenPaidDeniedCancelledAndSelectAll()
        {
            IList<IWebElement> showStatusOptions = GlobalVariables.webDriver.FindElements(By.XPath(ClaimList_ShowStatusAllOptions_Xpath));
            int showStatusCount = showStatusOptions.Count;            
            ArrayList expectedShowStatusValues = new ArrayList(new string[] { "Amend", "Submitted", "Open", "Paid", "Denied", "Cancelled", "Select All" });
            Report.WriteLine("The order of New Show Status options are : ");
            for (int i = 0; i < showStatusCount; i++)
            {
                Assert.AreEqual(expectedShowStatusValues[i].ToString(), showStatusOptions[i].Text);
                Report.WriteLine(showStatusOptions[i].Text);               
            }            
        }

        [Then(@"the Submitted status claims will be displayed by earlist to most recent Submit Date")]
        public void ThenTheSubmittedStatusClaimsWillBeDisplayedByEarlistToMostRecentSubmitDate()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {
                DateSort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (beforeSort[i] == afterSort[i])
                    {
                        Report.WriteLine("Expected value :" + beforeSort[i] + " is equal to the actual value: " + afterSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No records found");
            }
        }

        [Then(@"Submitted status is auto selected")]
        public void ThenSubmittedStatusIsAutoSelected()
        {
            Report.WriteLine("Submitted status is auto-selected");
            VerifyElementChecked(attributeName_xpath, ClaimListSubmittedCheckBox_Xpath, "Submitted");
        }

        [Then(@"all status options will be auto selected")]
        public void ThenAllStatusOptionsWillBeAutoSelected()
        {
            Report.WriteLine("all status options will be auto-selected");

            //verifying amend status auto-selected            
            VerifyElementChecked(attributeName_xpath, ClaimListAmendCheckBox_Xpath, "Amend");

            //verifying Submitted status auto-selected            
            VerifyElementChecked(attributeName_xpath, ClaimListSubmittedCheckBox_Xpath, "Submitted");

            //verifying Open status auto-selected            
            VerifyElementChecked(attributeName_xpath, ClaimListOpenCheckBox_Xpath, "Open");

            //verifying Paid status auto-selected            
            VerifyElementChecked(attributeName_xpath, ClaimListPaidCheckBox_Xpath, "Paid");

            //verifying Denied status auto-selected            
            VerifyElementChecked(attributeName_xpath, ClaimListDeniedCheckBox_Xpath, "Denied");

            //verifying Cancelled status auto-selected            
            VerifyElementChecked(attributeName_xpath, ClaimListCancelledCheckBox_Xpath, "Cancelled");
        }

        [Then(@"the claims list will be refreshed to display all claims of Amend,Submitted,Open,Paid,Denied,Cancelled")]
        public void ThenTheClaimsListWillBeRefreshedToDisplayAllClaimsOfAmendSubmittedOpenPaidDeniedCancelled()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("the claims list will be refreshed to display all claims of Amend,Submitted,Open,Paid,Denied,Cancelled");
            string noOfRecordsCheck = Gettext(attributeName_xpath, ClaimListGridValues_Xpath);

            int claimsListRowCount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (claimsListRowCount >= 1 && noOfRecordsCheck != "No Results Found")
            {
                string[] showStatusOptions = { "Amend", "Submitted", "Open", "Paid", "Denied", "Cancelled" };
                ClaimsStatusList();

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
        }

        [Then(@"the default sort of the status Select All will be by Submit Date of earliest date to most recent date")]
        public void ThenTheDefaultSortOfTheStatusSelectAllWillBeBySubmitDateOfEarliestDateToMostRecentDate()
        {
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {
                DateSort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (beforeSort[i] == afterSort[i])
                    {
                        Report.WriteLine("Expected value :" + beforeSort[i] + " is equal to the actual value: " + afterSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No records found");
            }
        }

        [Then(@"the Select All status will be un selected")]
        public void ThenTheSelectAllStatusWillBeUnSelected()
        {
            Report.WriteLine("Select All status will be un selected");
            VerifyElementNotChecked(attributeName_xpath, ClaimListSelectAllCheckBox_Xpath, "Select All");
        }

        [Then(@"the Claims List will refresh to display all claims associated to the user in the status's that are checked")]
        public void ThenTheClaimsListWillRefreshToDisplayAllClaimsAssociatedToTheUserInTheStatusSThatAreChecked()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("the claims list will be refreshed to display all claims of Submitted,Open,Paid,Denied,Cancelled");
            string noOfRecordsCheck = Gettext(attributeName_xpath, ClaimListGridValues_Xpath);

            int claimsListRowCount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (claimsListRowCount >= 1 && noOfRecordsCheck != "No Results Found")
            {
                ClaimsStatusList();
                string[] showStatusOptions = { "Submitted", "Open", "Paid", "Denied", "Cancelled" };
                for (int i = 0; i < claimRefColumnStringValues.Count; i++)
                {
                    //Grouping Claims as per status
                    if (statusColumnValuesString[i].Contains(showStatusOptions[0]))
                    { claimsWithSubmittedStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[1]))
                    { claimsWithOpenStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[2]))
                    { claimsWithPaidStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[3]))
                    { claimsWithDeniedStatus.Add(claimRefColumnStringValues[i]); }
                    else if (statusColumnValuesString[i].Contains(showStatusOptions[4]))
                    { claimsWithCancelledStatus.Add(claimRefColumnStringValues[i]); }
                    else
                    { Report.WriteFailure("Claims Status's contains Amend Status which was un checked"); }
                }

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
        }

        [Then(@"the default status Submitted will be selected")]
        public void ThenTheDefaultStatusSubmittedWillBeSelected()
        {
            Report.WriteLine("the default status Submitted will be selected");
            VerifyElementChecked(attributeName_xpath, ClaimListSubmittedCheckBox_Xpath, "Submitted");
        }

        [Then(@"Amend,Open,Paid,Denied,Cancelled,Select All status's will be unchecked")]
        public void ThenAmendOpenPaidDeniedCancelledSelectAllStatusSWillBeUnchecked()
        {
            Report.WriteLine("Amend,Open,Paid,Denied,Cancelled,Select All status's will be unchecked");
            //amend unchecked            
            VerifyElementNotChecked(attributeName_xpath, ClaimListAmendCheckBox_Xpath, "Amend");

            //Open unchecked            
            VerifyElementNotChecked(attributeName_xpath, ClaimListOpenCheckBox_Xpath, "Open");

            //Paid unchecked            
            VerifyElementNotChecked(attributeName_xpath, ClaimListPaidCheckBox_Xpath, "Paid");

            //Denied unchecked            
            VerifyElementNotChecked(attributeName_xpath, ClaimListDeniedCheckBox_Xpath, "Denied");

            //Cancelled unchecked            
            VerifyElementNotChecked(attributeName_xpath, ClaimListCancelledCheckBox_Xpath, "Cancelled");
        }

        [Then(@"the list will refresh to display claims in Submitted status")]
        public void ThenTheListWillRefreshToDisplayClaimsInSubmittedStatus()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();

            Report.WriteLine("the claims list will be refreshed to display all claims of Amend,Submitted,Open,Paid,Denied,Cancelled");
            string noOfRecordsCheck = Gettext(attributeName_xpath, ClaimListGridValues_Xpath);

            int claimsListRowCount = GetCount(attributeName_xpath, ClaimsList_TotalRecords_Xpath);
            if (claimsListRowCount >= 1 && noOfRecordsCheck != "No Results Found")
            {
                ClaimsStatusList();
                for (int i = 0; i < claimRefColumnStringValues.Count; i++)
                {
                    //Grouping Claims as per status
                    if (statusColumnValuesString[i].Replace(" ", "") == "Submitted")
                    { claimsWithSubmittedStatus.Add(claimRefColumnStringValues[i]); }
                    else
                    { Report.WriteFailure("Claims Status's contains the Status's other than Submitted"); }
                }

                //verifying the claims with Submitted status
                if (claimsWithSubmittedStatus.Count > 0)
                { Report.WriteLine("Claims with Submitted status's are present"); }
                else
                { Report.WriteFailure("Claims with Submitted status's are not present"); }
            }
            else
            {
                Report.WriteFailure("No Records found");
            }
        }

        [Then(@"the claims list default sort will be by earliest Submit Date to most recent Submit Date")]
        public void ThenTheClaimsListDefaultSortWillBeByEarliestSubmitDateToMostRecentSubmitDate()
        {
            Click(attributeName_xpath, ClaimsListTopGridViewOption_xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimsList_TopGrid_ViewDropdownValues_Xpath, "ALL");
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("the claims list default sort will be by earliest Submit Date to most recent Submit Date");
            int row = GetCount(attributeName_xpath, ClaimsList_RowCount_xpath);
            if (row >= 1)
            {
                DateSort();
                for (int i = 0; i < sortedvalues.Count; i++)
                {
                    if (beforeSort[i] == afterSort[i])
                    {
                        Report.WriteLine("Expected value :" + beforeSort[i] + " is equal to the actual value: " + afterSort[i]);
                    }
                    else
                    {
                        Report.WriteFailure("Sorting is not as expected");
                    }
                }
            }
            else
            {
                Report.WriteFailure("No records found");
            }
        }

        [Then(@"Select All status option will be auto selected")]
        public void ThenSelectAllStatusOptionWillBeAutoSelected()
        {
            Report.WriteLine("SelectAll status option will be auto selected");
            VerifyElementEnabled(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath, "Select All");
            VerifyElementChecked(attributeName_xpath, ClaimsList_SelectAllCheckBox_Xpath, "Select All");
        }

        public void DateSort()
        {
            //taking the List of submitted date column values before sorting
            Report.WriteLine("Reading the default sorting values from the Dates column");
            datesColumnCount = GlobalVariables.webDriver.FindElements(By.XPath(ClaimListDateSortValues_Xpath));
            foreach (IWebElement element in datesColumnCount)
            {
                beforeSort.Add((element.Text).ToString());
            }
            //taking the List of submitted date column values after click on sort arrow
            Click(attributeName_xpath, ClaimsList_SubmitDateColClick_Xpath);
            Report.WriteLine("Reading the values Dates column after click on sort arrow");
            sortedvalues = GlobalVariables.webDriver.FindElements(By.XPath(ClaimListDateSortValues_Xpath));
            foreach (IWebElement element in sortedvalues)
            {
                afterSort.Add((element.Text).ToString());
            }
            afterSort.Sort();
            Report.WriteLine("Comparing the values after sorting");
            beforeSort.Sort();
        }
        public void ClaimsStatusList()
        {
            //taking list of ref numbers
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
        }
    }
}