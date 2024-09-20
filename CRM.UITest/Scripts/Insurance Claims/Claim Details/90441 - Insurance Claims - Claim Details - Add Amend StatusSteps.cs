using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _90441___Insurance_Claims___Claim_Details___Add_Amend_StatusSteps : Objects.InsuranceClaim
    {
        string claimNumber_ClaimsList_UI;
        string GetPreviousStatus;
        InsuranceClaimHistory claimHistoryTab = null;
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
        ClickAndWaitMethods clk = new ClickAndWaitMethods();
        string userName;
        string password;

        [Given(@"I clicked on any dlsw claim reference hyper link on the Claims List page")]
        public void GivenIClickedOnAnyDlswClaimReferenceHyperLinkOnTheClaimsListPage()
        {
            clk.ClickAndWait(attributeName_id, ClaimsIcon_Id);
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");

            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (GridData == "No Results Found")
            {
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Reading First data value from Claims List page");

                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);

                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);
            }

        }

        [When(@"I clicked on the Status drop down list on the Claim Details page")]
        public void WhenIClickedOnTheStatusDropDownListOnTheClaimDetailsPage()
        {
            scrollPageup();
            scrollPageup();
            Click(attributeName_xpath, StatusClaim_Xpath);
        }

        [Then(@"I should see the option as Amend listed first in the list")]
        public void ThenIShouldSeeTheOptionAsAmendListedFirstInTheList()
        {
            string firstStatusOption = Gettext(attributeName_xpath, ".//*[@id='CarrierMode_chosen']/div/ul/li[2]");
            Assert.AreEqual(firstStatusOption, "Amend");
        }

        [Given(@"I selected the option Amend from the status drop down list")]
        public void GivenISelectedTheOptionAmendFromTheStatusDropDownList()
        {
            scrollPageup();
            scrollPageup();
            GetPreviousStatus = Gettext(attributeName_xpath, StatusClaim_Xpath);
            Click(attributeName_xpath, StatusClaim_Xpath);
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='CarrierMode_chosen']/div/ul/li"));
            for (int i = 2; i < DropDownList.Count; i++)
            {
                
                    Click(attributeName_xpath,".//*[@id='CarrierMode_chosen']/div/ul/li["+i+"]");
                    break;
                    
           
            }
            
        }

        [When(@"I clicked on the Save Claim Details button")]
        public void WhenIClickedOnTheSaveClaimDetailsButton()
        {
            MoveToElement(attributeName_id, Details_SubmitClaimDetails_Button_Id);
            Click(attributeName_id, Details_SubmitClaimDetails_Button_Id);
            Report.WriteLine("Clicked on Save Claim Details button");
        }

        [Then(@"the status of the claim will be updated to Amend")]
        public void ThenTheStatusOfTheClaimWillBeUpdatedToAmend()
        {
            scrollPageup();
            scrollPageup();
            string updatedOption = Gettext(attributeName_xpath, StatusClaim_Xpath);
            Assert.AreEqual(updatedOption, "Amend");
        }

        [Then(@"a status update entry will be made on the Status/History tab")]
        public void ThenAStatusUpdateEntryWillBeMadeOnTheStatusHistoryTab()
        {
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);

        }

        [Then(@"the details of the Amend status will include Date/Time : date/time that (.*) status was saved")]
        public void ThenTheDetailsOfTheAmendStatusWillIncludeDateTimeDateTimeThatStatusWasSaved(string p0)
        {
           
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber_ClaimsList_UI.ToString());

            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            Assert.AreEqual(ctzdate, dateTimeFromUI);
           
        }

        [Then(@"the details of the Amend status will include Updated By: Name of user that updated the claim status")]
        public void ThenTheDetailsOfTheAmendStatusWillIncludeUpdatedByNameOfUserThatUpdatedTheClaimStatus()
        {
            
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber_ClaimsList_UI.ToString());
            string nameofTheUpdatedUser = Gettext(attributeName_xpath, LatestupdatedByValue_Xpath);
            Assert.AreEqual(claimHistoryTab.UserFullName, nameofTheUpdatedUser);
            Report.WriteLine("CRM will record the first name and last name of the user");
        }

        [Then(@"the details of the Amend status will include Category: (.*)")]
        public void ThenTheDetailsOfTheAmendStatusWillIncludeCategory(string StatusUpdate)
        {
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber_ClaimsList_UI.ToString());
            string Category = DBHelper.GetInsuranceClaimCategory(Convert.ToInt32(claimHistoryTab.CategoryId));
            string CategoryUI= Gettext(attributeName_xpath, LatestCategoryValue_Xpath);
            Assert.AreEqual(Category, CategoryUI);
        }

        [Then(@"the details of the Amend status will include Comment: Amend updated from (.*)")]
        public void ThenTheDetailsOfTheAmendStatusWillIncludeCommentAmendUpdatedFrom(string previousStatus)
        {
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber_ClaimsList_UI.ToString());
            string Comments = Gettext(attributeName_xpath, LatestCommentValue_Xpath);
            Assert.AreEqual(claimHistoryTab.Comments, Comments);
        }

        [Then(@"the Claim updated is listed in Amend status")]
        public void ThenTheClaimUpdatedIsListedInAmendStatus()
        {
            clk.ClickAndWait(attributeName_xpath, BackToClaimListPage_Button_Xpath);
            //clk.ClickAndWait(attributeName_id, LeavePageWithoutSavingButton_Id);
            Click(attributeName_xpath, ClaimsList_AmendCheckbox_xpath);
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNumber_ClaimsList_UI);
            string GetClaimNumber = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);
            Assert.AreEqual(GetClaimNumber, claimNumber_ClaimsList_UI);
        }


        [Given(@"I am a sales, sales management, operations, station owner, or claim specialist user (.*)")]
        public void GivenIAmASalesSalesManagementOperationsStationOwnerOrClaimSpecialistUser(string UserType)
        {
            if (UserType.Equals("Internal"))
            {
                userName = ConfigurationManager.AppSettings["username-CurrentSprintOperations"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentSprintOperations"].ToString();
            }
            else
            {
                userName = ConfigurationManager.AppSettings["username-CurrentsprintClaimspecialist"].ToString();
                password = ConfigurationManager.AppSettings["password-CurrentsprintClaimspecialist"].ToString();
            }

            CrmLogin.LoginToCRMApplication(userName, password);
        }

       
        [Given(@"I am on the Claim Details page of a claim in Amend status")]
        public void GivenIAmOnTheClaimDetailsPageOfAClaimInAmendStatus()
        {
            clk.ClickAndWait(attributeName_id, ClaimsIcon_Id);
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");

            Click(attributeName_xpath, ClaimsList_AmendCheckbox_xpath);

            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (GridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Reading First data value from Claims List page");

                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);

                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
            }

        }

        [When(@"I arrive on the Status/History tab")]
        public void WhenIArriveOnTheStatusHistoryTab()
        {
            Click(attributeName_xpath, CustomerDetails_StatusOrHistory_Xpath);
        }

        [Then(@"I will see the Amend status update entry displayed")]
        public void ThenIWillSeeTheAmendStatusUpdateEntryDisplayed()
        {
            claimHistoryTab = DBHelper.GetInsuranceClaimHistorydetails(claimNumber_ClaimsList_UI.ToString());

            string ctzdate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(claimHistoryTab.ModifiedDate, TimeZoneInfo.Utc.Id, "Central Standard Time")
                .ToString("MM/dd/yyyy HH:mm", CultureInfo.InvariantCulture);
            string dateTimeFromUI = Gettext(attributeName_xpath, LatestDateTimeValue_Xpath);
            Assert.AreEqual(ctzdate, dateTimeFromUI);
            
        }

        [Then(@"the Amend status update entry is not editable")]
        public void ThenTheAmendStatusUpdateEntryIsNotEditable()
        {
            VerifyElementNotPresent(attributeName_xpath, ".//*[@id='InsuranceClaimHistoryGrid']/tbody/tr/td/a", "Edit Icon");
        }

















    }
}
