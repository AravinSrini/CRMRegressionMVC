using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_PaymentTab_OutstandingAmountFieldSteps : CRM.UITest.Objects.InsuranceClaim
    {
        string GetClaimNum = null;
        string OustandingAmount = "24.00";
        [Given(@"I am a Claim Specialist user")]
        public void GivenIAmAClaimSpecialistUser()
        {
            string userName = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, password);
            Report.WriteLine("I have logged into CRM application");
        }

      
        [Given(@"I clicked on the Payments Tab")]
        public void GivenIClickedOnThePaymentsTab()
        {
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
            Report.WriteLine("Clicked on Payment tab");
        }

        [Given(@"I arrived on Payments Tab section by clicking on Payments Tab,")]
        public void GivenIArrivedOnPaymentsTabSectionByClickingOnPaymentsTab()
        {
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
            Report.WriteLine("Clicked on Payment tab");
            Verifytext(attributeName_xpath, OutstandingAmountLabel_Xpath, "Outstanding Amount");
            Report.WriteLine("Arrived on Payment Tab");
        }

        [Given(@"I have edited Outstanding Amount")]
        public void GivenIHaveEditedOutstandingAmount()
        {
            SendKeys(attributeName_id, OutstandingAmount_Id, OustandingAmount);
            Report.WriteLine("Edit is made to Outstanding Amount field");
        }

        [Given(@"I am on the Claim Details page,")]
        public void GivenIAmOnTheClaimDetailsPage()
        {
            ScenarioContext.Current.Pending();
        }

        [Given(@"I have made edit to Outstanding amount field,")]
        public void GivenIHaveMadeEditToOutstandingAmountField()
        {
            SendKeys(attributeName_id, OutstandingAmount_Id, "24");
            Report.WriteLine("Edit is made to Outstanding Amount field");
        }


        [When(@"I arrive on the Payments Tab")]
        public void WhenIArriveOnThePaymentsTab()
        {
            Verifytext(attributeName_xpath, OutstandingAmountLabel_Xpath, "Outstanding Amount");
            Report.WriteLine("Arrived on Payment Tab");
        }

        [When(@"I Click on Save Claim Details")]
        public void WhenIClickOnSaveClaimDetails()
        {
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            Report.WriteLine("Clicked on Save Claim details button");
        }

        [When(@"I navigate away from the Claim Details page")]
        public void WhenINavigateAwayFromTheClaimDetailsPage()
        {
            scrollPageup();
            Click(attributeName_xpath, BackToClaimListPage_Button_Xpath);
            Report.WriteLine("Navigated away from Claim details page without clicking on save claim details button");

        }

        [When(@"I click on Return to Claim Details button,")]
        public void WhenIClickOnReturnToClaimDetailsButton()
        {
            Click(attributeName_id, ReturnToClaimDetailsButton_Id);
            Report.WriteLine("Clicked on Return to Claim Details button");
        }
        [When(@"I click on the Leave Page Without Saving button,")]
        public void WhenIClickOnTheLeavePageWithoutSavingButton()
        {
            Click(attributeName_id, LeavePageWithoutSavingButton_Id);
            Report.WriteLine("Clicked on Leave page without saving button");
        }


        [Given(@"The '(.*)' modal is displayed,")]
        public void GivenTheModalIsDisplayed(string ModalTitle)
        {
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
            SendKeys(attributeName_id, OutstandingAmount_Id, "24");
            Click(attributeName_xpath, BackToClaimListPage_Button_Xpath);
            WaitForElementVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "ChangeNotSavedModal");
            Verifytext(attributeName_xpath, ChangesNotSavedModal_Xpath, ModalTitle);
            Report.WriteLine("Changes Not Saved Modal is displayed");
        }

        [Given(@"I am on the Claim Details page of the selected Claim")]
        public void GivenIAmOnTheClaimDetailsPageOfTheSelectedClaim()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, ClaimListGrid_PendingCheckbox_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            GetClaimNum = Gettext(attributeName_xpath, ClaimListDLSWREF_HyperLink_Xpath);
            Click(attributeName_xpath, ClaimListDLSWREF_HyperLink_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to claim details page");
        }
        [Then(@"A note should display:'(.*)'")]
        public void ThenANoteShouldDisplay(string ModalNote)
        {
            Verifytext(attributeName_xpath, ChangesNotSavedModalNoteText_Xpath, ModalNote);
            Report.WriteLine("Expected Note is displayed in the Modal");
        }

        [Then(@"The modal verbiage should display:'(.*)'")]
        public void ThenTheModalVerbiageShouldDisplay(string ModalVerbiage)
        {
            Verifytext(attributeName_xpath, ChangesNotSavedModalText_Xpath, ModalVerbiage);
            Report.WriteLine("Expected verbiage is displayed in the modal");
        }

        [Then(@"I should be able to view '(.*)' modal,")]
        public void ThenIShouldBeAbleToViewModal(string ModalTitle)
        {
            WaitForElementVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "ChangeNotSavedModal");
            Verifytext(attributeName_xpath, ChangesNotSavedModal_Xpath, ModalTitle);
            Report.WriteLine("Able to view Changes not Saved modal");
        }

        [When(@"I navigate away from the Claim Details page without clicking on Save Claim details button")]
        public void WhenINavigateAwayFromTheClaimDetailsPageWithoutClickingOnSaveClaimDetailsButton()
        {
            scrollPageup();
            Click(attributeName_xpath, BackToClaimListPage_Button_Xpath);
            Report.WriteLine("Navigated away from Claim details page without clicking on save claim details button");
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Then(@"I should have an option to edit the Outstanding Amount field,")]
        public void ThenIShouldHaveAnOptionToEditTheOutstandingAmountField()
        {
            SendKeys(attributeName_id, OutstandingAmount_Id, "324");
            Report.WriteLine("Able to edit Outstanding Amount field");
        }

        [Then(@"The Outstanding Amount field should be optional,")]
        public void ThenTheOutstandingAmountFieldShouldBeOptional()
        {
            Clear(attributeName_id, OutstandingAmount_Id);
            MoveToElement(attributeName_xpath, SaveClaimDetailsButton_Xpath);
            Click(attributeName_xpath, SaveClaimDetailsButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            VerifyElementNotPresent(attributeName_id, OutstandingAmount_Id, "Outstanding Amount");
            Report.WriteLine("The Outstanding Amount field is optional");
        }

        [Then(@"The Outstanding Amount field format should be currency,")]
        public void ThenTheOutstandingAmountFieldFormatShouldBeCurrency()
        {
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            SendKeys(attributeName_id, OutstandingAmount_Id, "52");
            Click(attributeName_xpath, CustomerDetails_PaymentTab_Xpath);
            string GetOutstandingGFieldVal = GetValue(attributeName_id, OutstandingAmount_Id,"value");
            if (GetOutstandingGFieldVal.Contains("$"))
            {
                Report.WriteLine("Outstanding Amount field format is currency");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"The Outstanding Amount field should allow upto two decimal places,")]
        public void ThenTheOutstandingAmountFieldShouldAllowUptoTwoDecimalPlaces()
        {
            SendKeys(attributeName_id, OutstandingAmount_Id, "23.43");
            string GetOutstandingGFieldVal = GetValue(attributeName_id, OutstandingAmount_Id,"value");
            Assert.AreEqual(GetOutstandingGFieldVal, "23.43");
            Report.WriteLine("Outstanding Amount field allows only 2 decimal places");
        }

        [Then(@"The Outstanding Amount field should auto fill with \$ and two decimal places")]
        public void ThenTheOutstandingAmountFieldShouldAutoFillWithAndTwoDecimalPlaces()
        {
            SendKeys(attributeName_id, OutstandingAmount_Id, "23");
            Click(attributeName_xpath, OustandingAmountLabel_Xpath);
            string GetOutstandingGFieldVal = GetValue(attributeName_id, OutstandingAmount_Id,"value");
            if ((GetOutstandingGFieldVal.Contains("$")) && (GetOutstandingGFieldVal.Contains(".00")))
            {
                Report.WriteLine("Outstanding Amount field is auto filled with $ and two decimal places.");
            }
            else
            {
                Assert.Fail();
            }
        }

        [Then(@"Entered Outstanding amount on payment tab should get updated in database")]
        public void ThenEnteredOutstandingAmountOnPaymentTabShouldGetUpdatedInDatabase()
        {
            string GetOutstandingAmount = DBHelper.GetOustandingAmount(GetClaimNum.ToString());
            Assert.AreEqual(GetOutstandingAmount, OustandingAmount);
            Report.WriteLine("Entered Outstanding amount on payment tab is updated in database ");

        }

        [Then(@"I should be able to  see (.*) modal,")]
        public void ThenIShouldBeAbleToSeeModal(string p0)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"The modal verbiage should display:""(.*)"" ""(.*)""")]
        public void ThenTheModalVerbiageShouldDisplay(string p0, string p1)
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"I should be able to view '(.*)' button")]
        public void ThenIShouldBeAbleToViewButton(string LeavePageButton)
        {
            VerifyElementVisible(attributeName_id, LeavePageWithoutSavingButton_Id, LeavePageButton);
            Verifytext(attributeName_id, LeavePageWithoutSavingButton_Id, LeavePageButton);
            Report.WriteLine("Able to view Leave Page Without Saving Button");
        }


        [Then(@"I should be able to view '(.*)' button\.")]
        public void ThenIShouldBeAbleToViewButton_(string ReturnButton)
        {
            VerifyElementPresent(attributeName_id, ReturnToClaimDetailsButton_Id, ReturnButton);
            Verifytext(attributeName_id, ReturnToClaimDetailsButton_Id, ReturnButton);
            Report.WriteLine("Able to view Return to Claim Details Button");
        }

        [Then(@"The modal should get closed\.")]
        public void ThenTheModalShouldGetClosed_()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved Modal");
            Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Report.WriteLine("Changes Not Saved Modal got closed");

        }

        [Then(@"The modal should get closed")]
        public void ThenTheModalShouldGetClosed()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementNotPresentVisible(attributeName_xpath, ChangesNotSavedModal_Xpath, "Changes Not Saved Modal");
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            Report.WriteLine("Changes Not Saved Modal got closed");
        }


        [Then(@"I should be navigated away from the Claim Details page\.")]
        public void ThenIShouldBeNavigatedAwayFromTheClaimDetailsPage_()
        {
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            Report.WriteLine("Navigated away from claim lsit page");
        }
    }
}
