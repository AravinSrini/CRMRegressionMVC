using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Common;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MoreLinq;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using TechTalk.SpecFlow;
using Proxy = CRM.UITest.Entities.Proxy;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ClaimAcknowledgementLetterToCustomerFunctionalitySteps : CRM.UITest.Objects.InsuranceClaim
    {
        CommonMethodsCrm crmLogin = new CommonMethodsCrm();
        string userName;
        string password;
        string claimNumber_ClaimList;
        string selectedDateAckToClaimant;
        InsuranceDlswOsdAction InsuranceDlswOsdaction;
        string dateAckToClaimant;
        string ack_DatesColumn;
        List<int> allClaimNumbersWithAckDate;

        private string ackIconColumn_xpath;
        private IEnumerable<string> allAckDatesInGrid;
        private IEnumerable<string> allIconsInTheGrid;
        private List<string> allClaimNumbers;
        private string claimListTableRows_xpath = "//*[@id='gridInsuranceClaimList']/tbody/tr";
        private string insuranceClaimNoInTableSubXpath= "td[4]/span[1]/a";
        private string ClaimsList_ClaimAcknowledgementIcon_xpath;
        private List<int> allClaimNumbersWithOutAckDate;
        

        

        [Given(@"I am on the Details Tab of Claim Details page")]
        public void GivenIAmOnTheDetailsTabOfClaimDetailsPage()
        {
            string gridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (gridData == "No Results Found")
            {
                Report.WriteFailure("No Claims available in the Claims List Grid");
            }
            else
            {
                claimNumber_ClaimList = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
                Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
                WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
                Verifytext(attributeName_cssselector, "h1", "Claim Details");
                Verifytext(attributeName_xpath, ClaimDetailsTabText_Xpath, "DETAILS");
                Report.WriteLine("I am on the Details Tab of Claim Details page");
            }
        }

        [Given(@"I selected a date in the Date Ack To Claimant field")]
        public void GivenISelectedADateInTheDateAckToClaimantField()
        {
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            DatePickerFromCalander(attributeName_xpath, DLSDate_Xpath, 1, DLSDateMonth_Xpath);
            Report.WriteLine("Selected a date in the Date Ack to Claimant field");
            selectedDateAckToClaimant= GetAttribute(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, "value");
        }

        [Then(@"the date will be saved to the claim")]
        public void ThenTheDateWillBeSavedToTheClaim()
        {
            InsuranceDlswOsdaction = DBHelper.GetDlswOsdActionsdetails(claimNumber_ClaimList);
            dateAckToClaimant = InsuranceDlswOsdaction?.DateAckToClaimant?.ToString("MM/dd/yyyy");            
            Assert.AreEqual(selectedDateAckToClaimant, dateAckToClaimant);
            Report.WriteLine("the Date will be saved to the claim");
        }

        [Given(@"the Date Ack To Claimant information from the Details tab of the Claim Details page has been saved to the claim")]
        [When(@"the Date Ack To Claimant information from the Details tab of the Claim Details page has been saved to the claim")]
        public void TheDateAckToClaimantInformationFromTheDetailsTabOfTheClaimDetailsPageHasBeenSavedToTheClaim()
        {
            //Select first claim number
            claimNumber_ClaimList = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);

            //navigating to claim details page
            Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Verifytext(attributeName_cssselector, "h1", "Claim Details");

            UpdateAckDateAndSearchForClaim(claimNumber_ClaimList);            
        }

        [Given(@"the Date Ack To Claimant information from the Details tab of the Claim Details page has been saved to the claim for non claimSpecialist User")]
        public void GivenTheDateAckToClaimantInformationFromTheDetailsTabOfTheClaimDetailsPageHasBeenSavedToTheClaimForNonClaimSpecialistUser()
        {
            //Select first claim number
            claimNumber_ClaimList = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Non_ClaimSpecialist_Xpath);

            //navigating to claim details page
            Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_Non_ClaimSpecialist_Xpath);
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Verifytext(attributeName_cssselector, "h1", "Claim Details");


            UpdateAckDateAndSearchForClaim(claimNumber_ClaimList);
        }


        [Then(@"I will see the date that was saved in the Ack field of the Dates column")]
        public void ThenIWillSeeTheDateThatWasSavedInTheAckFieldOfTheDatesColumn()
        {
            ack_DatesColumn = Gettext(attributeName_xpath, ClaimList_Grid_First_Row_AckDate_Xpath);
            Assert.AreEqual(dateAckToClaimant, ack_DatesColumn);
            Report.WriteLine("Saved Date Ack To Claimant displaying under the dates Column for the Claim");
        }

        [Then(@"the date in the Ack field will displayed as a link")]
        public void ThenTheDateInTheAckFieldWillDisplayedAsALink()
        {
            //Clear the entered text in the search box using backspace
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, "a");
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Keys.Backspace);

            //Select All from the dropdown in the grid
            Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdownAnchor_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimListGrid_PageViewOption_dropdownSelectlabel_Xpath, "ALL");
            IList<IWebElement> listOfDateSpans = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='gridInsuranceClaimList']/tbody/tr/td[2]/span"));

            foreach (var span in listOfDateSpans)
            {
                if (span.FindElements(By.TagName("a")).Count == 1)
                {
                    Report.WriteLine("Date in the Ack field displayed as a hyperlink");
                }
                else
                {
                    Report.WriteFailure("Date in the Ack field not displayed with hyperlink");
                }
            }
        }

        [When(@"I hover over the Ack date in the Dates column")]
        public void WhenIHoverOverTheAckDateInTheDatesColumn()
        {
            Report.WriteLine("Mouse hover on the Ack date field in the Dates column");
            OnMouseOver(attributeName_xpath, ClaimList_Ack_HoverSpan_Xpath);
        }

        [Then(@"I will see a rollover message ""(.*)""")]
        public void ThenIWillSeeARolloverMessage(string message)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I will see a rollover message: Open Claim Acknowledgement Letter PDF");
            string actualMessage = Gettext(attributeName_xpath, ClaimList_Ack_HoverMessage_ClaimSpecialist_Xpath);
            Assert.AreEqual(message, actualMessage);
        }

        [Then(@"I will see a rollover message for non ClaimSpecialist User as ""(.*)""")]
        public void ThenIWillSeeARolloverMessageForNonClaimSpecialistUserAs(string message)
        {
            Report.WriteLine("I will see a rollover message: Open Claim Acknowledgement Letter PDF");
            string actualMessage = Gettext(attributeName_xpath, ClaimList_Ack_HoverMessage_NonClaimSpecialist_Xpath);
            Assert.AreEqual(message, actualMessage);
        }


        [When(@"I click on the link in the Ack field of Dates Column")]
        public void WhenIClickOnTheLinkInTheAckFieldOfDatesColumn()
        {
            Click(attributeName_xpath, ClaimList_Ack_Link_Xpath);
            Report.WriteLine("Clicked on the Ack field of Dates Column");
        }

        [Then(@"I will see a copy of the Acknowledgement Letter to the customer in a new tab")]
        public void ThenIWillSeeACopyOfTheAcknowledgementLetterToTheCustomerInANewTab()
        {
            string url = launchUrl + "InsuranceClaim/ClaimAcknowledgementLetter?insuranceClaimNumber=" + claimNumber_ClaimList;
            Report.WriteLine("I will be navigateing to new tab");            
            bool val = WindowHandling(url);
            Report.WriteLine("Checking if the Acknowledgement Letter is opened in new tab");
            Assert.IsTrue(val);
        }

        [Given(@"I Click on Claim number which already have Ack value")]
        public void GivenIClickOnClaimNumberWhichAlreadyHaveAckValue()
        {
            claimNumber_ClaimList = Gettext(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
            Click(attributeName_xpath, ClaimGrid_DLSW_First_ClaimNumber_ClaimSpecialist_Xpath);
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Verifytext(attributeName_cssselector, "h1", "Claim Details");
            Report.WriteLine("Click on the claim which already have Ack value");
        }
        [Given(@"I update Date Ack To Claimant to another date in Claim Details page")]
        public void GivenIUpdateDateAckToClaimantToAnotherDateInClaimDetailsPage()
        {
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            DatePickerFromCalander(attributeName_xpath, DLSDate_Xpath, -2, DLSDateMonth_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            selectedDateAckToClaimant = GetAttribute(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, "value");
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            Report.WriteLine("Updated Date Ack to Claimant to another date in the Claim Details page");
        }

        [When(@"the Date Ack To Claimant from the Details tab of the Claim Details page has been saved to the claim")]
        public void WhenTheDateAckToClaimantFromTheDetailsTabOfTheClaimDetailsPageHasBeenSavedToTheClaim()
        {
            InsuranceDlswOsdaction = DBHelper.GetDlswOsdActionsdetails(claimNumber_ClaimList);
            dateAckToClaimant = InsuranceDlswOsdaction?.DateAckToClaimant?.ToString("MM/dd/yyyy");
        }

        [Then(@"I will see the updated date that was saved in the Ack field of the Dates column")]
        public void ThenIWillSeeTheUpdatedDateThatWasSavedInTheAckFieldOfTheDatesColumn()
        {            
            Assert.AreEqual(selectedDateAckToClaimant, dateAckToClaimant);
            Report.WriteLine("the Date will be saved to the claim");            
        }

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, sales, sales management, operations, or station owner (.*)")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsOrStationOwner(string UserType)
        {
            if (UserType == "Internal")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            }
            else if (UserType == "Sales")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintSales"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintSales"].ToString();
            }
            else if (UserType == "External")
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintshpentry"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintshpentry"].ToString();
            }
            crmLogin.LoginToCRMApplication(userName, password);
        }

        [When(@"the Date Ack To Claimant has been saved to the claim")]
        public void WhenTheDateAckToClaimantHasBeenSavedToTheClaim()
        {
            FetchAllClaims(true);
        }

        [Then(@"I will see the Claim Acknowledgement icon displayed next to the customer name in the Customer column")]
        public void ThenIWillSeeTheClaimAcknowledgementIconDisplayedNextToTheCustomerNameInTheCustomerColumn()
        {
            var allRowsInGrid = GlobalVariables.webDriver.FindElements(By.XPath(claimListTableRows_xpath));
            foreach (var row in allRowsInGrid)
            {
                int claimNumber = Convert.ToInt32(row.FindElement(By.XPath(insuranceClaimNoInTableSubXpath)).Text);
                if (allClaimNumbersWithAckDate.Contains(claimNumber))
                {
                    Assert.IsNotNull(row.FindElement(By.XPath("td/a/img")));
                }
            }
        }

        [When(@"the Date Ack To Claimant has not been saved to the claim")]
        public void WhenTheDateAckToClaimantHasNotBeenSavedToTheClaim()
        {
            FetchAllClaims(false);
        }

        [Then(@"I will not see the Claim Acknowledgement icon displayed next to the customer name in the Customer column")]
        public void ThenIWillNotSeeTheClaimAcknowledgementIconDisplayedNextToTheCustomerNameInTheCustomerColumn()
        {
            var allRowsInGrid = GlobalVariables.webDriver.FindElements(By.XPath(claimListTableRows_xpath));
            foreach (var row in allRowsInGrid)
            {
                int claimNumber = Convert.ToInt32(row.FindElement(By.XPath(insuranceClaimNoInTableSubXpath)).Text);
                if (allClaimNumbersWithOutAckDate.Contains(claimNumber))
                {                    
                    Assert.IsTrue(row.FindElements(By.XPath("td/a/img")).Count==0,"Image Doesn't Exist for Claim Number: " + claimNumber);               }
            }
        }

        [Given(@"the Date Ack To Claimant has been saved to the claim")]
        public void GivenTheDateAckToClaimantHasBeenSavedToTheClaim()
        {
            FetchAllClaims(true);            
        }

        private void FetchAllClaims(bool withAckDate)
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdownAnchor_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimListGrid_PageViewOption_dropdownSelectlabel_Xpath, "ALL");
            var allClaimNumberElementsInGrid = GlobalVariables.webDriver.FindElements(By.XPath(ClaimList_Grid_ClaimNumbers));
            allClaimNumbers = allClaimNumberElementsInGrid.Select(a => a.Text).ToList();

            List<InsuranceDlswOsdAction> insuranceDlswOsdActionWithAckDate;
            if (withAckDate)
            {
                insuranceDlswOsdActionWithAckDate = GenericDBHelper<InsuranceDlswOsdAction>
                                                                            .FindAll(a => allClaimNumbers.Contains(a.ClaimNumber.ToString()) &&
                                                                            a.DateAckToClaimant != null);
                allClaimNumbersWithAckDate = insuranceDlswOsdActionWithAckDate.Select(a => a.ClaimNumber).ToList();
            }
            else
            {
                insuranceDlswOsdActionWithAckDate = GenericDBHelper<InsuranceDlswOsdAction>
                                                                            .FindAll(a => allClaimNumbers.Contains(a.ClaimNumber.ToString()) &&
                                                                            a.DateAckToClaimant == null);
                allClaimNumbersWithOutAckDate = insuranceDlswOsdActionWithAckDate.Select(a => a.ClaimNumber).ToList();
            }
            
        }

        [Given(@"the Claim Acknowledgement icon is displayed next to the customer name in the Customer column")]
        public void GivenTheClaimAcknowledgementIconIsDisplayedNextToTheCustomerNameInTheCustomerColumn()
        {
            //This was tested in another scenario
        }

        [When(@"I hover over the Claim Acknowledgement icon")]
        public void WhenIHoverOverTheClaimAcknowledgementIcon()
        {
            Report.WriteLine("Mouse hover on the Claim Acknowledgment Icon");
            OnMouseOver(attributeName_xpath, ClaimList_Grid_First_Acknowledgement_Icon);
        }

        [When(@"I clicked on the Claim Acknowledgement icon in the Customer column")]
        public void WhenIClickedOnTheClaimAcknowledgementIconInTheCustomerColumn()
        {
            Report.WriteLine("Mouse hover on the Claim Acknowledgment Icon");
            Click(attributeName_xpath, ClaimList_Grid_First_Acknowledgement_Icon);
        }


        [Given(@"I have a claim with Date Ack To Claimant")]
        public void GivenIHaveAClaimWithDateAckToClaimant()
        {
            FetchAllClaims(true);
            int claimNumberWithAckDate = allClaimNumbersWithAckDate.FirstOrDefault();
            claimNumber_ClaimList = claimNumberWithAckDate.ToString();
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNumberWithAckDate.ToString());
        }

        private void UpdateAckDateAndSearchForClaim(string claimNumber)
        {
            //selecting date from the Date Ack to Claimant
            WaitForElementVisible(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id, "InsuranceDlswOsdActions.DateAckToClaimant");
            Click(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            WaitUntilThePageContentLoads.WaitForPageLoad(GlobalVariables.webDriver);
            DatePickerFromCalander(attributeName_xpath, DLSDate_Xpath, -1, DLSDateMonth_Xpath);
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            selectedDateAckToClaimant = Gettext(attributeName_id, DetailsTab_Edit_Shipper_DateAckToClaimant_Click_Id);
            scrollPageup();

            //Date will be saved to the claim
            InsuranceDlswOsdaction = DBHelper.GetDlswOsdActionsdetails(claimNumber_ClaimList);
            dateAckToClaimant = InsuranceDlswOsdaction?.DateAckToClaimant?.ToString("MM/dd/yyyy");
            Report.WriteLine("the Date will be saved to the claim");

            GlobalVariables.webDriver.WaitForPageLoad();
            scrollPageup();
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath);
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNumber);
        }

    }

}
