using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Globalization;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_HistoryTabSteps : Objects.InsuranceClaim
    {
        string claimNumber = null;

        [Given(@"I clicked on the History Tab")]
        public void GivenIClickedOnTheHistoryTab()
        {
            Report.WriteLine("I click on the History Tab");
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
        }

        [When(@"I click on the History Tab")]
        public void WhenIClickOnTheHistoryTab()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I click on the History Tab");
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
        }

        [When(@"the Category is (.*) for any displayed history entry")]
        public void WhenTheCategoryIsForAnyDisplayedHistoryEntry(string p0)
        {
            IList<IWebElement> categoryList = GlobalVariables.webDriver.FindElements(By.XPath(CategoryValues_Xpath));
            List<string> actualCategoryListFromUI = new List<string>();
            foreach (IWebElement element in categoryList)
            {
                actualCategoryListFromUI.Add((element.Text).ToString());
            }
            for (int i = 0; i < actualCategoryListFromUI.Count; i++)
            {
                if (actualCategoryListFromUI[i].Contains("Status Update"))
                {
                    VerifyElementNotPresent(attributeName_xpath, ".//*[@id='InsuranceClaimHistoryGrid']//tr[" + i+1 + "]/td[5]/a", "edit icon");
                    Report.WriteLine("The Category 'Status Update' is displayed for history entry");
                    break;
                }
                else
                {
                    Report.WriteLine("The Category other than 'Status Update' is displayed for history entry");
                }
            }
        }

        [When(@"the claim status is edited")]
        public void WhenTheClaimStatusIsEdited()
        {
            Report.WriteLine("the claim status is edited");
            scrollPageup();
            scrollPageup();
            Click(attributeName_xpath, ClaimStatus_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimStatusDropdownValues_Xpath, "Open - 4IN");
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I will see the button (.*)")]
        public void ThenIWillSeeTheButton(string p0)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I will see the add button");
            VerifyElementVisible(attributeName_id, AddComment_Id, "Add Comment");
            string addCommentUI = Gettext(attributeName_id, AddComment_Id);
            Assert.AreEqual(addCommentUI, "Add Comment");
        }

        [Then(@"I will see an Edit icon displayed next to each Comment")]
        public void ThenIWillSeeAnEditIconDisplayedNextToEachComment()
        {
            Report.WriteLine("Edit icon will be displayed next to each comment");
            VerifyElementVisible(attributeName_xpath, editIcon_HistoryTab_Xpath, "edit icon");
        }

        [Then(@"I should not be able to edit the entry")]
        public void ThenIShouldNotBeAbleToEditTheEntry()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            IList<IWebElement> categoryList = GlobalVariables.webDriver.FindElements(By.XPath(CategoryValues_Xpath));
            List<string> actualCategoryListFromUI = new List<string>();
            foreach (IWebElement element in categoryList)
            {
                actualCategoryListFromUI.Add((element.Text).ToString());
            }
            for (int i = 0; i < actualCategoryListFromUI.Count; i++)
            {
                if (actualCategoryListFromUI[i].Contains("Status Update"))
                {                    
                    VerifyElementNotPresent(attributeName_xpath, ".//*[@id='InsuranceClaimHistoryGrid']//tr[" + i+1 + "]/td[5]/a", "edit icon");
                    Report.WriteLine("I should not able to edit Entry");
                    break;
                }
                else
                {
                    Report.WriteLine("I should able to edit Entry");
                }
            }
        }

        [Then(@"Date/Time field will be updated with new values")]
        public void ThenDateTimeFieldWillBeUpdatedWithNewValues()
        {
            Report.WriteLine("Date/Time field will be updated with new values");
            claimNumber = DBHelper.GetClaimNumber().ToString();
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            InsuranceClaimHistory claimDateTimeHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimDateTimeHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);            
            string updatedDateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            Assert.AreEqual(ctzdate, updatedDateTimeFromUI);
        }

        [Then(@"Updated By field will be updated with new values")]
        public void ThenUpdatedByFieldWillBeUpdatedWithNewValues()
        {
            Report.WriteLine("Updated By field will be updated with new values");
            claimNumber = DBHelper.GetClaimNumber().ToString();
            InsuranceClaimHistory claimUpdatedByHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string updatedByFieldValueFromUI = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimUpdatedByHistoryTab.UserFullName, updatedByFieldValueFromUI);
        }

        [Then(@"Category field will be Status update")]
        public void ThenCategoryFieldWillBeStatusUpdate()
        {
            Report.WriteLine("Category field will be Status update");
            claimNumber = DBHelper.GetClaimNumber().ToString();
            InsuranceClaimHistory claimCategoryHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string categoryFieldValueFromUI = Gettext(attributeName_xpath, LatestCategoryValue_Xpath);
            Assert.AreEqual(categoryFieldValueFromUI,"Status Update");
        }

        [Then(@"Comment field will be updated with new values")]
        public void ThenCommentFieldWillBeUpdatedWithNewValues()
        {
            Report.WriteLine("Comment field will be updated with new values");
            claimNumber = DBHelper.GetClaimNumber().ToString();
            InsuranceClaimHistory claimCommentHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber);
            string commentFieldValueFromUI = Gettext(attributeName_xpath, LatestCommentValue_Xpath);
            Assert.AreEqual(claimCommentHistoryTab.Comments, commentFieldValueFromUI);
        }

        [Then(@"I will not be displayed with the button Add Comment")]
        public void ThenIWillNotBeDisplayedWithTheButtonAddComment()
        {
            Report.WriteLine("I will not be displayed with the button Add Comment");
            VerifyElementNotPresent(attributeName_id, AddComment_Id, "Add Comment");
        }

        [Then(@"I will not be displayed an Edit icon displayed next to each Comment")]
        public void ThenIWillNotBeDisplayedAnEditIconDisplayedNextToEachComment()
        {
            Report.WriteLine("I will not be displayed an Edit icon displayed next to each Comment");
            VerifyElementNotPresent(attributeName_xpath, editIcon_HistoryTab_Xpath, "edit icon");
        }
    }
}
