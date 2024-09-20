using System;
using TechTalk.SpecFlow;
using CRM.UITest.CommonMethods;
using CRM.UITest.Helper.Common;
using CRM.UITest.Helper.DataModels;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Collections.Generic;
using System.Threading;
using System.IO;
using System.Configuration;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_DetailsTab_ElementsSteps : InsuranceClaim
    {
        string expectedText = null;
        string actualText = null;
        string ClaimNumber = null;

        [Given(@"I arrive on the Claims Details page")]
        public void GivenIArriveOnTheClaimsDetailsPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"that I am a sales, sales management, operations, station owner, or claims specialist user")]
        public void GivenThatIAmASalesSalesManagementOperationsStationOwnerOrClaimsSpecialistUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I arrive on the Claims Details page")]
        public void WhenIArriveOnTheClaimsDetailsPage()
        {
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }
        
        [When(@"Details tab is selected")]
        public void WhenDetailsTabIsSelected()
        {
            Click(attributeName_xpath, ClaimDetailsTabText_Xpath);
        }
        
        [When(@"I click on the Back to Claims List button")]
        public void WhenIClickOnTheBackToClaimsListButton()
        {
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
        }

        [When(@"I clicked on the hyperlink of any displayed claim")]
        public void WhenIClickedOnTheHyperlinkOfAnyDisplayedClaim()
        {
            Report.WriteLine("I am on the Claims List Page");
            VerifyElementPresent(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
            Click(attributeName_xpath, ClaimsList_PendingCheckbox_xpath);

            int TotalClaimNumber = GetCount(attributeName_xpath, ClaimGrid_DLSW_Total_ClaimNumber_Xpath);
            if (TotalClaimNumber > 0)
            {
                ClaimNumber = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Xpath);
                Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Xpath);
            }
            else
            {
                Report.WriteLine("No claim found in the grid");
            }

        }

        [Then(@"I will see the page label (.*) in Claim Details page")]
        public void ThenIWillSeeThePageLabelInClaimDetailsPage(string p0)
        {
            expectedText = "Claim Details";
            actualText = Gettext(attributeName_xpath, ClaimDetails_PageLebel_Xpath);

            Assert.AreEqual(expectedText, actualText);
        }


        [Then(@"I will see the verbiage (.*) located beneath the page label")]
        public void ThenIWillSeeTheVerbiageLocatedBeneathThePageLabel(string p0)
        {
            expectedText = "The details for this claim are displayed below.";
            actualText = Gettext(attributeName_xpath, DetailsPage_verbiageBeneathPageLebel_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }
        
        [Then(@"I will see a Back to Claims List button")]
        public void ThenIWillSeeABackToClaimsListButton()
        {
            IsElementPresent(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id, "Back to Claims List");
        }
        
        [Then(@"I will see the following tabs: Details, Payments, Documents, Status/History")]
        public void ThenIWillSeeTheFollowingTabsDetailsPaymentsDocumentsStatusHistory()
        {
            IsElementPresent(attributeName_xpath, ClaimDetailsTabText_Xpath, "Details");
            IsElementPresent(attributeName_xpath, CustomerDetails_PaymentTab_Xpath, "Payment tab");
            IsElementPresent(attributeName_xpath, CustomerDetails_Documents_Xpath, "Document");
            IsElementPresent(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath, "Status or History");
        }
        
        [Then(@"By default I will be on the Details tab")]
        public void ThenByDefaultIWillBeOnTheDetailsTab()
        {
            expectedText = "DETAILS";
            actualText = Gettext(attributeName_xpath, ClaimDetailsTabText_Xpath);
            Assert.AreEqual(expectedText, actualText);
        }

        [Then(@"I will see the sections in details tab")]
        public void ThenIWillSeeTheSectionsInDetailsTab()
        {
            IsElementPresent(attributeName_xpath, Consignee_Xpath, "Consignee");
            // IsElementPresent(attributeName_xpath,, "Shipper");
            IsElementPresent(attributeName_xpath, DLSW_OSD_Actions_Xpath, "DLSW OS&D Actions");
            IsElementPresent(attributeName_xpath, InsuranceInfo_Xpath, "Insurance Info");
            IsElementPresent(attributeName_xpath, KeyDates_Xpath, "Key Date");
            IsElementPresent(attributeName_xpath, ProductClaimed_Xpath, "Product Claimed");
            IsElementPresent(attributeName_xpath, FreightCalculation_Xpath, "Freight calculation");
            IsElementPresent(attributeName_xpath, Comments_Xpath, "Comment");
        }

    }
}
