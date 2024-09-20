using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Helper.Implementations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;


namespace CRM.UITest
{
    [Binding]
    public class _95525_InsuranceClaims_Amend_BindingSteps : Objects.InsuranceClaim
    {
        string _claimnumber = string.Empty;
        string userclaimspecialist = string.Empty;
        string previouslyboundedClaimantreferencevalue = string.Empty;
        string _claim = string.Empty;
        string claimanReferencevalue = "CRef@";
        string editedcustomerReferenceValue = string.Empty;
        InsuranceClaimViewModel ClaimDetails = null;
        int Claimnumber;
        int originalstatus;
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        GenerateRandomNumber _randomnumberGeneration = new GenerateRandomNumber();

        [Given(@"I am a user and login into application with valid (.*) and (.*),")]
        public void GivenIAmAUserAndLoginIntoApplicationWithValidAnd(string username, string password)
        {
            userclaimspecialist = username;
            string userName = ConfigurationManager.AppSettings[username].ToString();
            string passWord = ConfigurationManager.AppSettings[password].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(userName, passWord);
            Report.WriteLine("I logged into CRM application with RRD access user");
        }

        [When(@"I clicked on the Edit icon of Amend status Claim")]
        public void WhenIClickedOnTheEditIconOfAmendStatusClaim()
        {
            if (userclaimspecialist == "username-CurrentsprintClaimspecialist")
            {
                Click(attributeName_xpath, sortarrowDate_Claimlistpage_Xpath);
                Report.WriteLine("Click on Edit icon");
                string claimnumber = Gettext(attributeName_xpath, ".//tr[1]//*[@class='dlsw-claim-number']");
                string[] _ClaimNumber = claimnumber.Split(new char[0]);
                _claimnumber = _ClaimNumber[1];
                Click(attributeName_xpath, ClaimListEditIcon_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
            else
            {
                Click(attributeName_xpath, sortarrowSubmitDate_Claimlistpage_Xpath);
                Report.WriteLine("Click on Edit icon");
                _claimnumber = Gettext(attributeName_xpath, ".//tr[1]//*[@class='dlsw-claim-number']");
                Click(attributeName_xpath, ClaimListEditIcon_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Then(@"I will see the claim number displayed to the right of the Submit a Claim page header")]
        public void ThenIWillSeeTheClaimNumberDisplayedToTheRightOfTheSubmitAClaimPageHeader()
        {
            Report.WriteLine("Veirfy the claim number displayed in Submit a Claim page");
            string expHeader = "Submit a Claim (Claim # " + _claimnumber + ")";
            string actHeader = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            if (expHeader.Equals(actHeader))
            {
                Report.WriteLine("claim number displayed next to the Submit a Claim page");
            }
            else
            {
                Report.WriteFailure("claim number is not displayed next to the Submit a Claim page");
            }
        }

        [Then(@"I will be able to see the verbiage Amend a previously submitted motor carrier shortage or damage claim beneath the Submit a Claim page header")]
        public void ThenIWillBeAbleToSeeTheVerbiageAmendAPreviouslySubmittedMotorCarrierShortageOrDamageClaimBeneathTheSubmitAClaimPageHeader()
        {
            Report.WriteLine("Checking whether verbiage is present");
            VerifyElementVisible(attributeName_xpath, Submit_Claim_Page_Header_xpath, "Amend a previously submitted motor carrier shortage or damage claim");
        }

        [Then(@"I will not see the Enter DLSW Ref to Start Process field")]
        public void ThenIWillNotSeeTheEnterDLSWRefToStartProcessField()
        {
            VerifyElementNotPresent(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, "DLSW REF#");
            Report.WriteLine("DLSW Ref is not present in Claim Details");
        }

        [Then(@"I will not able to see Populate Form button")]
        public void ThenIWillNotAbleToSeePopulateFormButton()
        {
            VerifyElementNotPresent(attributeName_id, PopulateForm_button_Id, "Populate Form button");
            Report.WriteLine("Populate Form button is not present");
        }

        [Then(@"I will not see the verbiage Or fill out the form below manually")]
        public void ThenIWillNotSeeTheVerbiageOrFillOutTheFormBelowManually()
        {
            VerifyElementNotPresent(attributeName_xpath, PopulateFormButton_Verbiage_Xpath, "Or fill out the form below manually");
            Report.WriteLine("Populate Form Button Verbiage not present");

        }

        [Then(@"I will see the fields Station and Customer in the Station and Customer section")]
        public void ThenIWillSeeTheFieldsStationAndCustomerInTheStationAndCustomerSection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Verifying the Station and Customer fields");
            VerifyElementVisible(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath, "Station");
            Report.WriteLine("Station field is visible");
            VerifyElementVisible(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath, "Customer");
            Report.WriteLine("Customer field is visible");
        }

        [Then(@"these fields are auto-populated with the details of the original claim,")]
        public void ThenTheseFieldsAreAuto_PopulatedWithTheDetailsOfTheOriginalClaim()
        {
            CustomerAccount stationdetails = DBHelper.GetClaimStationDetails(_claimnumber);
            string expectedStationName = stationdetails.StationName;
            string actualStationName = Gettext(attributeName_xpath, SubmitaClaim_Stationdropdown_xpath);
            Assert.AreEqual(expectedStationName, actualStationName);

            string actualCustomerName = Gettext(attributeName_xpath, SubmitaClaim_Customerdropdown_xpath);
            string expectedCustomerName = DBHelper.GetCustomerNameForTheClaimNumber(Convert.ToInt32(_claimnumber));
            Assert.AreEqual(expectedCustomerName, actualCustomerName);
        }

        [Then(@"I am not able to edit the fields")]
        public void ThenIAmNotAbleToEditTheFields()
        {
            Report.WriteLine("Verifying the Station and Customer fields");
            string value_station = GetAttribute(attributeName_id, SubmitaClaim_StationName_id, "disabled");
            Assert.AreEqual(value_station, "true");
            Report.WriteLine("Station field is non editable");
            string value_customer = GetAttribute(attributeName_id, SubmitaClaim_CustomerName_id, "disabled");
            Assert.AreEqual(value_customer, "true");
            Report.WriteLine("Customer field is non editable");
        }



        [When(@"I arrive on the Submit A Claim page for the (.*) which is in Amend status")]
        public void WhenIArriveOnTheSubmitAClaimPageForTheWhichIsInAmendStatus(int claim)
        {

            _claimnumber = claim.ToString();
            string expHeader = "Submit a Claim" + " " + "(Claim " + "# " + _claimnumber + ")";
            string actHeader = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            if (expHeader.Equals(actHeader))
            {
                Report.WriteLine("Arrived on the Submit a Claim page of Amend claim");
            }
            else
            {
                Report.WriteFailure("Submit a Claim page of Amend claim is not displayed");
            }
        }

        [Then(@"I will see a new optional field ""(.*)"" \(editable, alpha-numeric, text, special characters, max length (.*)\)")]
        public void ThenIWillSeeANewOptionalFieldEditableAlpha_NumericTextSpecialCharactersMaxLength(string claimReferncefield, int maxcharactersallowed)
        {
            scrollElementIntoView(attributeName_xpath, submitAClaimPage_ClaimDetailsHeader_xpath);
            Verifytext(attributeName_xpath, submitAClaimPage_CustomerRefLabel_xpath, "Customer Claim Ref #");
            VerifyElementVisible(attributeName_id, customer_claim_ref_Id, "Customer Claim Reference Textbox");
            previouslyboundedClaimantreferencevalue = GetValue(attributeName_id, customer_claim_ref_Id, "value");
            Clear(attributeName_id, UnitValue_Id);
            scrollElementIntoView(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Submitting Claim Form");
            Click(attributeName_id, SubmitClaimButton_Id);
            Report.WriteLine("Validate Weight_LBS_Id Field Highlight");
            string ClaimantReferenceField = GetCSSValue(attributeName_id, customer_claim_ref_Id, "background-color");
            Assert.AreNotEqual(ClaimantReferenceField, "rgb(251, 236, 237)");

            SendKeys(attributeName_id, customer_claim_ref_Id, "2098765432 1qazxs wedc vfr &^5stop");
            string customerClaimReferenceField_UI = GetValue(attributeName_id, customer_claim_ref_Id, "value");
            Assert.AreEqual("2098765432 1qazxs we", customerClaimReferenceField_UI);
            Assert.AreEqual(20, customerClaimReferenceField_UI.Length);
            Report.WriteLine("Customer Carrier Reference field is validated for a maximum of 20 alpha-numeric, text, special characters");
        }

        [Then(@"the previously entered Customer Claim Ref \# value will be bound")]
        public void ThenThePreviouslyEnteredCustomerClaimRefValueWillBeBound()
        {
            ClaimDetails = DBHelper.GetInsuranceClaimValues(Convert.ToInt32(_claimnumber));
            Assert.AreEqual(ClaimDetails.CustomerClaimReferenceNumber, previouslyboundedClaimantreferencevalue);
            DBHelper.UpdatingOriginalstatusOfClaim(Claimnumber, originalstatus);
        }


        [When(@"I Click Resubmit a Claim button")]
        public void WhenIClickResubmitAClaimButton()
        {
            scrollElementIntoView(attributeName_xpath, ".//h2[contains(text(), 'Claim Details')]");
            editedcustomerReferenceValue = _randomnumberGeneration.Randomnumber(claimanReferencevalue);
            SendKeys(attributeName_id, customer_claim_ref_Id, editedcustomerReferenceValue);
            scrollElementIntoView(attributeName_id, Resubmit_button_Id);
            Click(attributeName_id, Resubmit_button_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
        }



        [Then(@"the ""(.*)"" of the Customer Claim Ref will be pushed to the Customer Ref column of the Claims List page for the corresponding ""(.*)"" numbers (.*)")]
        public void ThenTheOfTheCustomerClaimRefWillBePushedToTheCustomerRefColumnOfTheClaimsListPageForTheCorrespondingNumbers(string actualclaimantreferencevalue, string claimnumber, string usertype)
        {
            Report.WriteLine("Verifying Claimant Reference value");
            if (usertype != "Claimspecialist")
            {
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, _claim);
                string claimantReferenceumberfromClaimsListpage = Gettext(attributeName_id, "");
                Assert.AreEqual(claimanReferencevalue, claimantReferenceumberfromClaimsListpage);
            }

        }

        [Given(@"I Clicked on the edit icon of (.*) in Amend status")]
        public void GivenIClickedOnTheEditIconOfInAmendStatus(int claim)
        {
            Report.WriteLine("Verifyting the claim is in Submitted status from DB");
            int status = DBHelper.GetInsuranceStatus(claim);
            originalstatus = status;
            Claimnumber = claim;
            if (status != 6)
            {
                Report.WriteLine("Changing the Status to Amend");
                DBHelper.updateClaimStatusAsAmend(claim);
                refreshBrowser();
            }
            else
            {
                Report.WriteLine("The Claim is in Amend status");
            }
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath);
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claim.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimListEditIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();

        }

        [Given(@"I am on the Submit A Claim page of a (.*) in Amend status")]
        public void GivenIAmOnTheSubmitAClaimPageOfAInAmendStatus(string claimnumber)
        {
            _claimnumber = claimnumber;
            string expHeader = "Submit a Claim (Claim # " + _claimnumber + ")";
            string actHeader = Gettext(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath);
            if (expHeader.Equals(actHeader))
            {
                Report.WriteLine("Arrived on the Submit a Claim page of Amend claim");
            }
            else
            {
                Report.WriteFailure("Submit a Claim page of Amend claim is not displayed");
            }
        }

        [Then(@"the ""(.*)"" of Customer Claim Ref field will be saved for the Corresponding (.*)")]
        public void ThenTheOfCustomerClaimRefFieldWillBeSavedForTheCorresponding(string actualclaimantreferencevalue, string claimnumber)
        {
            actualclaimantreferencevalue = editedcustomerReferenceValue;
            ClaimDetails = DBHelper.GetInsuranceClaimValues(Convert.ToInt32(claimnumber));
            Assert.AreEqual(ClaimDetails.CustomerClaimReferenceNumber, actualclaimantreferencevalue);
        }

        [Then(@"the ""(.*)"" of the Customer Claim Ref will be pushed to the Customer Ref column of the Claims List page for the (.*) numbers (.*)")]
        public void ThenTheOfTheCustomerClaimRefWillBePushedToTheCustomerRefColumnOfTheClaimsListPageForTheNumbers(string actualclaimantreferencevalue, string claimnumber, string usertype)
        {
            Report.WriteLine("Verifying Claimant Reference value");
            if (usertype != "Claimspecialist")
            {
                SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimnumber);
                Thread.Sleep(2000);
                string claimantReferenceumberfromClaimsListpage = Gettext(attributeName_xpath, claimlist_customerref_xpath);
                Assert.AreEqual(editedcustomerReferenceValue, claimantReferenceumberfromClaimsListpage);
            }
            DBHelper.UpdatingOriginalstatusOfClaim(Convert.ToInt32(Claimnumber), originalstatus);
        }



    }
}

