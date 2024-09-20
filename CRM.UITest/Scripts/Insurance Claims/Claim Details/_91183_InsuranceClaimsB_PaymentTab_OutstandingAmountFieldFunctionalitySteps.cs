using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Threading;
using TechTalk.SpecFlow;

namespace CRM.UITest
{
    [Binding]
    public class _91183_InsuranceClaimsB_PaymentTab_OutstandingAmountFieldFunctionalitySteps : CRM.UITest.Objects.InsuranceClaim
    {
        int ClaimNumber = 0;
        string submittedClaimNumber = string.Empty;
        string getOutstandingAmountDB = string.Empty;
        string initialOutstandingAmount = string.Empty;
        string getPaymentAmountVal = string.Empty;
        string getTotalClaimedFreightVal = string.Empty;
        string getInitialTotalClaimedFreightVal = string.Empty;
        string getTTLValUI = string.Empty;

        CommonMethodsCrm crm = new CommonMethodsCrm();
        List<string> Actual = new List<string>();
        List<string> UI = new List<string>();

        string getTTLValueUI = string.Empty;
        string getOriginalUI = string.Empty;
        string getReturnUI = string.Empty;
        string getReplacementUI = string.Empty;
        string clmTyp = "Shortage";
        string artTyp = "New";
        string qty = "2";
        string item = "2";
        string desc = "Test Description";
        string unitWgt = "2";
        string unitVal = "2";
        string claimableYes = "Y";
        string claimedFreightOriginal = "2";
        string claimedReturnOriginal = "2";
        string claimedReplacementOriginal = "2";


        [Given(@"I am on the Payments tab of Claim Details")]
        public void GivenIAmOnThePaymentsTabOfClaimDetails()
        {
            GivenIAmOnClaimDetailsPage();
            Click(attributeName_xpath, ClaimDetails_PaymentTab_Xpath);
            Report.WriteLine("Navigated to Payment tab of Claim details page");
            initialOutstandingAmount = GetValue(attributeName_id, OutstandingAmount_Id, "value");
        }

        [Given(@"I clicked the Add Payment button")]
        public void GivenIClickedTheAddPaymentButton()
        {
            scrollpagedown();
            Click(attributeName_id, AddPaymentButton_Id);
            Report.WriteLine("Clicked on Add Payment button");
            WaitForElementVisible(attributeName_xpath, PaymentModalTitle_Xpath, "Add Payment");
            Verifytext(attributeName_xpath, PaymentModalTitle_Xpath, "Add Payment");
            Report.WriteLine("Add payment modal is opened");
        }

        [Given(@"I selected Payment Type as (.*) in the Add Payment modal")]
        public void GivenISelectedPaymentTypeAsInTheAddPaymentModal(string paymentType)
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
            if (paymentType == "CarrierDirectPayToClaimant")
            {
                SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Carrier Direct Pay To Claimant");
                Report.WriteLine("Selected Carrier Direct Pay To Claimant as Payment type");
            }
            if (paymentType == "CarrierPaymentToDLSW")
            {
                SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Carrier Payment To DLSW");
                Report.WriteLine("Selected Carrier Payment To DLSW Payment type");
            }
            if (paymentType == "Credit")
            {
                SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Credit");
                Report.WriteLine("Selected Credit Payment type");
            }
            if (paymentType == "Subrogation")
            {
                SelectDropdownValueFromList(attributeName_xpath, PaymentTypeDropdownValues_Xpath, "Subrogation");
                Report.WriteLine("Selected Subrogation Payment type");
            }

        }

        [Given(@"I entered all other required information in the Add Payment modal")]
        public void GivenIEnteredAllOtherRequiredInformationInTheAddPaymentModal()
        {
            SendKeys(attributeName_id, PaymentAmountModal_Id, "25");
            getPaymentAmountVal = GetValue(attributeName_id, PaymentAmountModal_Id, "value");
            Click(attributeName_xpath, PaymentDateModal_Xpath);
            DatePickerFromCalander(attributeName_xpath, PaymentDateUI_Xpath, -1, PaymentDateMonth_Xpath);
            SendKeys(attributeName_xpath, CheckNumberModal_Xpath, "45678");
            Click(attributeName_xpath, CheckDateModal_Xpath);
            DatePickerFromCalander(attributeName_xpath, PaymentDateUI_Xpath, -1, PaymentDateMonth_Xpath);
            SendKeys(attributeName_xpath, PaymentCommentModal_Xpath, "Adding Check");
            Report.WriteLine("Entered values to all required fields in the Add Payment modal");
        }

        [Given(@"I am on Claim Details Page")]
        public void GivenIAmOnClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(3000);
            Report.WriteLine("Navigated to Claim List page");
            //Submit a Claim
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            int claimNumber = Claim.Claimsubmit("InternalOrClaimSpecialist");
            submittedClaimNumber = claimNumber.ToString();
            Click(attributeName_xpath, ClaimListPageSearch_Xpath);
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, submittedClaimNumber);
            Click(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);            
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Report.WriteLine("Navigated to Claim Details page");
        }

        [When(@"I click on Add Button")]
        public void WhenIClickOnAddButton()
        {
            Click(attributeName_xpath, AddNewPaymentButtonModal_Xpath);
            Report.WriteLine("Clicked on Add Button");
        }

        [When(@"I click on Add Payment Model")]
        public void WhenIClickOnAddPaymentModel()
        {
            Click(attributeName_xpath, PaymentTypeDropdown_Xpath);
        }

        [Then(@"I should see All PaymentType in Paymenttype dropdwon list")]
        public void ThenIShouldSeeAllPaymentTypeInPaymenttypeDropdwonList()
        {
            IList<IWebElement> DropDownList = GlobalVariables.webDriver.FindElements(By.XPath("//*[@id='PaymentType_chosen']/div/ul/li"));
            for (int i = 1; i <= DropDownList.Count; i++)
            {
                string UIvalue = Gettext(attributeName_xpath, "//*[@id='PaymentType_chosen']/div/ul/li[" + i + "]");
                if (UIvalue != "Select...")
                {
                    UI.Add(UIvalue);
                }
            }
            Actual.Add("Carrier Direct Pay To Claimant");
            Actual.Add("Carrier Payment To DLSW");
            Actual.Add("Credit");
            Actual.Add("DLSW Payment to Claimant");
            Actual.Add("Expense");
            Actual.Add("Insurance Direct Pay To Claimant");
            Actual.Add("Other, See Comment");
            Actual.Add("Reimbursement to Carrier");
            Actual.Add("Subrogation");
            CollectionAssert.AreEqual(UI, Actual);

        }



        [When(@"I click on Save Claim Details button of Claim Details page")]
        public void WhenIClickOnSaveClaimDetailsButtonOfClaimDetailsPage()
        {
            scrollElementIntoView(attributeName_id, SaveClaimDetailsButton_Id);
            scrollPageup();
            scrollPageup();
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Thread.Sleep(4000);
            Report.WriteLine("Clicked on Save Claim Details button of Claim Details page");
        }

        [Given(@"I am a user with access to submit a claim '(.*)' '(.*)'")]
        public void GivenIAmAUserWithAccessToSubmitAClaim(string userName, string passWord)
        {
            string username = ConfigurationManager.AppSettings[userName].ToString();
            string password = ConfigurationManager.AppSettings[passWord].ToString();
            crm.LoginToCRMApplication(username, password);
        }


        [Given(@"The value of the Total Claimed Freight field changed")]
        public void GivenTheValueOfTheTotalClaimedFreightFieldChanged()
        {
            getTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            Assert.AreNotEqual(getTotalClaimedFreightVal, getInitialTotalClaimedFreightVal);
            Report.WriteLine("The value of the Total Claimed Freight field is changed");
        }


        [Given(@"I have made Edits to  FreightCalculations of Claim details page")]
        public void GivenIHaveMadeEditsToFreightCalculationsOfClaimDetailsPage()
        {
            Click(attributeName_xpath, ClaimDetails_PaymentTab_Xpath);
            WaitForElementPresent(attributeName_id, AddPaymentButton_Id, "Patmentbutton");
            initialOutstandingAmount = GetValue(attributeName_id, OutstandingAmount_Id, "value");//getting the initial outsatnding amount for calulation     
            Click(attributeName_xpath, ClaimDetails_DetailsTab_xpath);
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollElementIntoView(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            getInitialTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, "95");
            Report.WriteLine("Edit is made to Freight calculation section section");
        }

        [When(@"the claim has been submitted")]
        public void WhenTheClaimHasBeenSubmitted()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Submit a Claim page");
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            ClaimNumber = Claim.Claimsubmit("InternalOrClaimSpecialist");
        }

        [When(@"the claim has been submitted for external user")]
        public void WhenTheClaimHasBeenSubmittedForExternalUser()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Submit a Claim page");
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            ClaimNumber = Claim.Claimsubmit("External");
        }

        [Then(@"The value in the Outstanding Amount field of the Payments tab will be reduced by the amount entered in the Payment Amount field of the Add Payment modal")]
        public void ThenTheValueInTheOutstandingAmountFieldOfThePaymentsTabWillBeReducedByTheAmountEnteredInThePaymentAmountFieldOfTheAddPaymentModal()
        {
            string getOutstandingAmountUI = GetValue(attributeName_id, OutstandingAmount_Id, "value");
            initialOutstandingAmount = initialOutstandingAmount.Substring(1);
            decimal expectedOutstandingAmount = Convert.ToDecimal(initialOutstandingAmount) - Convert.ToDecimal(getPaymentAmountVal);
            Assert.AreEqual(expectedOutstandingAmount.ToString(), getOutstandingAmountUI.ToString());
            Report.WriteLine("The value in the Outstanding Amount field of the Payments tab is reduced by the amount entered in the Payment Amount field of the Add Payment modal");
        }

        [Then(@"The Amount value of each displayed claim will equal the value of the Total Claimed Freight field of the Claim Details page")]
        public void ThenTheAmountValueOfEachDisplayedClaimWillEqualTheValueOfTheTotalClaimedFreightFieldOfTheClaimDetailsPage()
        {
            string freightChargeSubTotal = string.Empty;
            ClaimNumber = DBHelper.GetClaimNumber();
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, ClaimNumber.ToString());
            string getAmountUI = Gettext(attributeName_xpath, ClaimListSpecialistUserAmount_Xpath);
            decimal freightChargeSubtotal = DBHelper.GetSubTotalValFreight(ClaimNumber);
            if (freightChargeSubtotal == 0)
            {
                freightChargeSubTotal = freightChargeSubtotal.ToString().Replace("0", "0.00");
                Assert.AreEqual("$" + freightChargeSubTotal.ToString(), getAmountUI);
                Report.WriteLine("The amount value displayed is equal to the value of the Total Claimed Freight field of the Claim Details page");
            }
            else
            {
                Assert.AreEqual("$" + freightChargeSubtotal.ToString(), getAmountUI);
                Report.WriteLine("The amount value displayed is equal to the value of the Total Claimed Freight field of the Claim Details page");
            }
        }

        [Then(@"The value of the Total Claimed Freight field on the Claim Details page will be added to the Outstanding Amount field of the Payments tab")]
        public void ThenTheValueOfTheTotalClaimedFreightFieldOnTheClaimDetailsPageWillBeAddedToTheOutstandingAmountFieldOfThePaymentsTab()
        {
            SendKeys(attributeName_xpath, ClaimListPageSearch_Xpath, ClaimNumber.ToString());
            string claimNumberGridVal = Gettext(attributeName_xpath, ClaimListFirstClaimNumberExternal_Xpath);
            Click(attributeName_linktext, claimNumberGridVal);
            decimal freightChargeSubtotal = DBHelper.GetSubTotalValFreight(ClaimNumber);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Claim Details page");
            Click(attributeName_xpath, ClaimDetails_PaymentTab_Xpath);
            Report.WriteLine("Navigated to Payment tab of Claim details page");
            string getOutstandingAmount = GetValue(attributeName_id, OutstandingAmount_Id, "value");
            Assert.AreEqual(freightChargeSubtotal.ToString(), getOutstandingAmount.ToString());
            Report.WriteLine("Value of Total Claimed Freight field on the Claim Details page is added to the Outstanding Amount field of the Payments tab");
        }

        [Then(@"The Outstanding Amount equals \(Updated Value of Total Claimed Freight\) - \(Previous Value of Total Claimed Freight\) \+ \(Current Value of Outstanding Amount\)")]
        public void ThenTheOutstandingAmountEqualsUpdatedValueOfTotalClaimedFreight_PreviousValueOfTotalClaimedFreightCurrentValueOfOutstandingAmount()
        {
            ScrollToTopElement(attributeName_xpath, ClaimDetails_PaymentTab_Xpath);
            Click(attributeName_xpath, ClaimDetails_PaymentTab_Xpath);
            string getOutstandingAmountUI = GetValue(attributeName_id, OutstandingAmount_Id, "value");
            getTotalClaimedFreightVal = getTotalClaimedFreightVal.Substring(1);
            getInitialTotalClaimedFreightVal = getInitialTotalClaimedFreightVal.Substring(1);
            initialOutstandingAmount = initialOutstandingAmount.Substring(1);
            decimal expectedOutstandingAmount = (decimal.Parse(getTotalClaimedFreightVal)) - (decimal.Parse(getInitialTotalClaimedFreightVal)) + (decimal.Parse(initialOutstandingAmount));
            Assert.AreEqual("$" + expectedOutstandingAmount.ToString(), getOutstandingAmountUI);
            Report.WriteLine("Outstanding amount field is displayed based on the expected calculation");
        }

        [When(@"I made Edits to Products Claimed section of Claim details page")]
        public void WhenIMadeEditsToProductsClaimedSectionOfClaimDetailsPage()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Report.WriteLine(" Get Previous Value of Total Claimed Freight");
            getInitialTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            getInitialTotalClaimedFreightVal = getInitialTotalClaimedFreightVal.Substring(1);
            Report.WriteLine("Add the item and enter the values");
            Click(attributeName_xpath,addAnotherItembutton_xpath);
            Click(attributeName_xpath, ProductClaimed_CLMTYP_LastRowValue_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ProductClaimed_CLMTYP_LastRowValue_Xpath, clmTyp);
            Click(attributeName_xpath, ProductClaimed_ARTTYP_LastRowValue_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ProductClaimed_ARTTYP_LastRowValue_Xpath, artTyp);
            Click(attributeName_xpath, ProductClaimed_QTY_LastRowValue_Xpath);
            SendKeys(attributeName_xpath, ProductClaimed_QTY_LastRowValue_Xpath, qty);
            SendKeys(attributeName_xpath, ProductClaimed_ITEM_LastRowValue_Xpath, item);
            SendKeys(attributeName_xpath, ProductClaimed_DESC_LastRowValue_Xpath, desc);
            SendKeys(attributeName_xpath, ProductClaimed_UNITWGT_LastRowValue_Xpath, unitWgt);
            SendKeys(attributeName_xpath, ProductClaimed_UNITVAL_LastRowValue_Xpath, unitVal);
            Click(attributeName_xpath, ProductClaimed_UNITWGT_LastRowValue_Xpath);

        }

        [When(@"I made Edits to existing Products Claimed section of Claim details page")]
        public void WhenIMadeEditsToExistingProductsClaimedSectionOfClaimDetailsPage()
        {
            Report.WriteLine("Get the Outstanding amount from DB");
            getOutstandingAmountDB = DBHelper.GetOustandingAmount(submittedClaimNumber);
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Report.WriteLine(" Get Previous Value of Total Claimed Freight");
            getInitialTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            getInitialTotalClaimedFreightVal = getInitialTotalClaimedFreightVal.Substring(1);
            Report.WriteLine("Edit the existing value");
            Clear(attributeName_id, ProductClaimed_QTY_Id);
            SendKeys(attributeName_id, ProductClaimed_QTY_Id, qty);
            Clear(attributeName_id, ProductClaimed_ITEM_Id);
            SendKeys(attributeName_id, ProductClaimed_ITEM_Id, item);
            Clear(attributeName_id, ProductClaimed_UNITWGT_Id);
            SendKeys(attributeName_id, ProductClaimed_UNITWGT_Id, unitWgt);
            Clear(attributeName_id, ProductClaimed_UNITVAL_Id);
            SendKeys(attributeName_id, ProductClaimed_UNITVAL_Id, unitVal);
            Click(attributeName_id, ProductClaimed_UNITWGT_Id);

        }

        [Then(@"The value of the Total Claimed Freight equals \(TTL VAL\) \+ \(Original Claimed Freight\) \+ \(Return Claimed Freight\) \+ \(Replacement Claimed Freight\)")]
        public void ThenTheValueOfTheTotalClaimedFreightEqualsTTLVALOriginalClaimedFreightReturnClaimedFreightReplacementClaimedFreight()
        {
            
            Report.WriteLine("Get the total value from the Products Claimed");
            getTTLValUI = Gettext(attributeName_xpath, Totalval_Xpath);
            getTTLValueUI = getTTLValUI.Substring(1);
            getInitialTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            getInitialTotalClaimedFreightVal = getInitialTotalClaimedFreightVal.Substring(1);
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Claimable_dropdown_Original_Xpath, claimableYes);
            Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Claimabledropdown_Return_Xpath, claimableYes);
            Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Claimabledropdown_Replacement_Xpath, claimableYes);

            Clear(attributeName_id, ClaimedFreight_Textbox_Original_Id);
            Clear(attributeName_id, ClaimedFreight_Textbox_Return_Id);
            Clear(attributeName_id, ClaimedFreight_Textbox_Replacement_Id);

            SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, claimedFreightOriginal);
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Return_Id, claimedReturnOriginal);
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, claimedReplacementOriginal);
            Click(attributeName_id, ClaimedFreight_Textbox_Return_Id);

            string getOriginalvalueUI = GetValue(attributeName_id, ClaimedFreight_Textbox_Original_Id, "value");
            string getReturnvalueUI = GetValue(attributeName_id, ClaimedFreight_Textbox_Return_Id, "value");
            string getReplacementvalueUI = GetValue(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "value");
            getOriginalUI = getOriginalvalueUI.Substring(1);
            getReturnUI = getReturnvalueUI.Substring(1);
            getReplacementUI = getReplacementvalueUI.Substring(1);
            getTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            getTotalClaimedFreightVal = getTotalClaimedFreightVal.Substring(1);
            decimal expectedtotalClaimedFreight = (decimal.Parse(getTTLValueUI)) + (decimal.Parse(getOriginalUI)) + (decimal.Parse(getReturnUI)) + (decimal.Parse(getReplacementUI));
            Assert.AreEqual("$" + expectedtotalClaimedFreight.ToString(), "$" + getTotalClaimedFreightVal.ToString());
            Report.WriteLine("Total Claimed Freight field is displayed based on the expected calculation");
        }

        [Given(@"I made Edits to Products Claimed section of Claim details page")]
        public void GivenIMadeEditsToProductsClaimedSectionOfClaimDetailsPage()
        {
            WhenIMadeEditsToExistingProductsClaimedSectionOfClaimDetailsPage();
        }

        [Given(@"The value of the Total Claimed Freight changed")]
        public void GivenTheValueOfTheTotalClaimedFreightChanged()
        {
            scrollpagedown();
            Report.WriteLine("Updated value of Total Claimed Freight field");
            getTotalClaimedFreightVal = Gettext(attributeName_xpath, ClaimDetails_TotalClaimedFreightVal_Xpath);
            getTotalClaimedFreightVal = getTotalClaimedFreightVal.Substring(1);


        }

        [Then(@"Outstanding Amount equals \(Updated Value of Total Claimed Freight\) - \(Previous Value of Total Claimed Freight\) \+ \(Current Value of Outstanding Amount\)")]
        public void ThenOutstandingAmountEqualsUpdatedValueOfTotalClaimedFreight_PreviousValueOfTotalClaimedFreightCurrentValueOfOutstandingAmount()
        {
            string getCurrentOutstandingAmountDB = DBHelper.GetOustandingAmount(submittedClaimNumber);
            decimal expectedOutstandingAmount = (decimal.Parse(getTotalClaimedFreightVal)) - (decimal.Parse(getInitialTotalClaimedFreightVal)) + (decimal.Parse(getOutstandingAmountDB));
            Assert.AreEqual("$" + expectedOutstandingAmount.ToString(), "$" + getCurrentOutstandingAmountDB.ToString());
            Report.WriteLine("Outstanding amount field is displayed based on the expected calculation");
        }

    }
}




