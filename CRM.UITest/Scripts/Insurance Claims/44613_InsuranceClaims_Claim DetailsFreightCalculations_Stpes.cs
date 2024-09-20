using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_Claim_DetailsFreightCalculations_Stpes : InsuranceClaim
    {
        string claimNumberUI = null;
        string ClaimedFreightOrgin = "112233";
        string CarrierChargesToDLSWOrigin = "332211";
        string DLSWChargesToCustOrigin = "99999";
        string DLSWRefNumeberOrigin = "OOO12346";

        string ClaimedFreightReturn = "7777";
        string CarrierChargesToDLSWReturn = "555555";
        string DLSWChargesToCustReturn = "88888";
        string DLSWRefNumeberReturn = "LLL45654";

        string ClaimedFreightReplacement = "44444";
        string CarrierChargesToDLSWReplacement = "454545";
        string DLSWChargesToCustReplacement = "232323";
        string DLSWRefNumeberReplacement = "MMM5656";

        string commentsUI = "Comments";


        [When(@"I click on the Save Claim Details button on Claim Details page")]
        public void WhenIClickOnTheSaveClaimDetailsButtonOnClaimDetailsPage()
        {
            Report.WriteLine("I click on the Save Claim Details button on Claim Details page");
            scrollElementIntoView(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
            Click(attributeName_id, "btnSaveClaimDetails");
            GlobalVariables.webDriver.WaitForPageLoad();
        }


        [Given(@"I am on the Claim Details page for any claim")]
        public void GivenIAmOnTheClaimDetailsPageForAnyClaim()
        {
            Report.WriteLine("I am on the Claim Details page for any claim");

            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string claimListGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (claimListGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Clicking on the Claim Number");
                claimNumberUI = Gettext(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }


        [Given(@"I have  made an edit to any of the Freight Calculations Type - Claimable\?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref \#,Total Claimed Freight,Comments (.*)")]
        public void GivenIHaveMadeAnEditToAnyOfTheFreightCalculationsType_ClaimableClaimedFreightCarrierChargesToDLSWDLSWChargesToCustDLSWRefTotalClaimedFreightComments(string freightType)
        {
            Report.WriteLine("Editing Claimable?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #,Total Claimed Freight,Comments field");

            scrollElementIntoView(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            if (freightType == "Original")
            {
                Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
                Click(attributeName_xpath, "//*[@id='ORIGINALCLAIMABLE_chosen']/div/ul/li[1]");
                SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, ClaimedFreightOrgin);
                SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, CarrierChargesToDLSWOrigin);
                SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, DLSWChargesToCustOrigin);
                SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, DLSWRefNumeberOrigin);
            }
            else if (freightType == "Return")
            {
                Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
                Click(attributeName_xpath, "//*[@id='RETURNCLAIMABLE_chosen']/div/ul/li[1]");
                SendKeys(attributeName_id, ClaimedFreight_Textbox_Return_Id, ClaimedFreightReturn);
                SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, CarrierChargesToDLSWReturn);
                SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, DLSWChargesToCustReturn);
                SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, DLSWRefNumeberReturn);
            }
            else if (freightType == "Replacement")
            {
                Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
                Click(attributeName_xpath, ".//*[@id='REPLACEMENTCLAIMABLE_chosen']/div/ul/li[1]");
                SendKeys(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, ClaimedFreightReplacement);
                SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, CarrierChargesToDLSWReplacement);
                SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, DLSWChargesToCustReplacement);
                SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, DLSWRefNumeberReplacement);
            }
            SendKeys(attributeName_id, "Comments", commentsUI);
        }

        [Given(@"I have  made edit in Freight Calculations section")]
        public void GivenIHaveMadeEditInFreightCalculationsSection()
        {
            Report.WriteLine("Editing Claimable?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #,Total Claimed Freight,Comments field");

            scrollElementIntoView(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            Click(attributeName_xpath, Claimable_dropdown_Original_Xpath);
            Click(attributeName_xpath, "//*[@id='ORIGINALCLAIMABLE_chosen']/div/ul/li[1]");
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Original_Id, ClaimedFreightOrgin);
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Original_Id, CarrierChargesToDLSWOrigin);
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Original_Id, DLSWChargesToCustOrigin);
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Original_Id, DLSWRefNumeberOrigin);

            Click(attributeName_xpath, Claimabledropdown_Return_Xpath);
            Click(attributeName_xpath, "//*[@id='RETURNCLAIMABLE_chosen']/div/ul/li[1]");
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Return_Id, ClaimedFreightReturn);
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Return_Id, CarrierChargesToDLSWReturn);
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Return_Id, DLSWChargesToCustReturn);
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Return_Id, DLSWRefNumeberReturn);

            Click(attributeName_xpath, Claimabledropdown_Replacement_Xpath);
            Click(attributeName_xpath, ".//*[@id='REPLACEMENTCLAIMABLE_chosen']/div/ul/li[1]");
            SendKeys(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, ClaimedFreightReplacement);
            SendKeys(attributeName_id, CarrierChargesToDLSW_Textbox_Replacement_Id, CarrierChargesToDLSWReplacement);
            SendKeys(attributeName_id, DLSWChargesToCust_Textbox_Replacement_Id, DLSWChargesToCustReplacement);
            SendKeys(attributeName_id, DLSWRefNumeber_Textbox_Replacement_Id, DLSWRefNumeberReplacement);
            SendKeys(attributeName_id, "Comments", commentsUI);

        }


        [Then(@"The edits will be saved (.*)")]
        public void ThenTheEditsWillBeSaved(string freightType)
        {
            Report.WriteLine("Verifying Claimable?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #,Total Claimed Freight,Comments field");

            Entities.Proxy.InsuranceClaimFreight frieghtdetails = DBHelper.GetInsuranceClaimFrieghtCalculationsDetails(claimNumberUI);
            if (freightType == "Original")
            {
                Assert.AreEqual(Convert.ToDecimal(ClaimedFreightOrgin), frieghtdetails.OriginalFreightChargesValue);
                Assert.AreEqual(Convert.ToDecimal(CarrierChargesToDLSWOrigin), frieghtdetails.OriginalCarrierChargesToDlswValue);
                Assert.AreEqual(Convert.ToDecimal(DLSWChargesToCustOrigin), frieghtdetails.OriginalDlswChargesToCustomerValue);
                Assert.AreEqual(DLSWRefNumeberOrigin, frieghtdetails.OriginalFreightChargesDlswRefNumber);
                Assert.AreEqual(commentsUI, frieghtdetails.Comments);
            }
            else if (freightType == "Return")
            {
                Assert.AreEqual(Convert.ToDecimal(ClaimedFreightReturn), frieghtdetails.ReturnFreightChargesValue);
                Assert.AreEqual(Convert.ToDecimal(CarrierChargesToDLSWReturn), frieghtdetails.ReturnCarrierChargesToDlswValue);
                Assert.AreEqual(Convert.ToDecimal(DLSWChargesToCustReturn), frieghtdetails.ReturnDlswChargesToCustomerValue);
                Assert.AreEqual(DLSWRefNumeberReturn, frieghtdetails.ReturnFreightChargesDlswRefNumber);
                Assert.AreEqual(commentsUI, frieghtdetails.Comments);

            }
            else if (freightType == "Replacement")
            {
                Assert.AreEqual(Convert.ToDecimal(ClaimedFreightReplacement), frieghtdetails.ReplacementFreightChargesValue);
                Assert.AreEqual(Convert.ToDecimal(CarrierChargesToDLSWReplacement), frieghtdetails.ReplacementCarrierChargesToDlswValue);
                Assert.AreEqual(Convert.ToDecimal(DLSWChargesToCustReplacement), frieghtdetails.ReplacementDlswChargesToCustomerValue);
                Assert.AreEqual(DLSWRefNumeberReplacement, frieghtdetails.ReplacementFreightDlswRefNumber);
                Assert.AreEqual(commentsUI, frieghtdetails.Comments);
            }

            VerifytotalClaimedFreight();

        }


        [Then(@"The edits will be saved")]
        public void ThenTheEditsWillBeSaved()
        {
            Report.WriteLine("Verifying Claimable?, Claimed Freight, Carrier Charges to DLSW, DLSW Charges to Cust, DLSW Ref #,Total Claimed Freight,Comments field");
            Entities.Proxy.InsuranceClaimFreight frieghtdetails = DBHelper.GetInsuranceClaimFrieghtCalculationsDetails(claimNumberUI);

            Assert.AreEqual(Convert.ToDecimal(ClaimedFreightOrgin), frieghtdetails.OriginalFreightChargesValue);
            Assert.AreEqual(Convert.ToDecimal(CarrierChargesToDLSWOrigin), frieghtdetails.OriginalCarrierChargesToDlswValue);
            Assert.AreEqual(Convert.ToDecimal(DLSWChargesToCustOrigin), frieghtdetails.OriginalDlswChargesToCustomerValue);
            Assert.AreEqual(DLSWRefNumeberOrigin, frieghtdetails.OriginalFreightChargesDlswRefNumber);


            Assert.AreEqual(Convert.ToDecimal(ClaimedFreightReturn), frieghtdetails.ReturnFreightChargesValue);
            Assert.AreEqual(Convert.ToDecimal(CarrierChargesToDLSWReturn), frieghtdetails.ReturnCarrierChargesToDlswValue);
            Assert.AreEqual(Convert.ToDecimal(DLSWChargesToCustReturn), frieghtdetails.ReturnDlswChargesToCustomerValue);
            Assert.AreEqual(DLSWRefNumeberReturn, frieghtdetails.ReturnFreightChargesDlswRefNumber);


            Assert.AreEqual(Convert.ToDecimal(ClaimedFreightReplacement), frieghtdetails.ReplacementFreightChargesValue);
            Assert.AreEqual(Convert.ToDecimal(CarrierChargesToDLSWReplacement), frieghtdetails.ReplacementCarrierChargesToDlswValue);
            Assert.AreEqual(Convert.ToDecimal(DLSWChargesToCustReplacement), frieghtdetails.ReplacementDlswChargesToCustomerValue);
            Assert.AreEqual(DLSWRefNumeberReplacement, frieghtdetails.ReplacementFreightDlswRefNumber);
            Assert.AreEqual(commentsUI, frieghtdetails.Comments);

            VerifytotalClaimedFreight();
        }

        public void VerifytotalClaimedFreight()
        {
            Report.WriteLine("Verifying totalClaimedFreight field");
            scrollElementIntoView(attributeName_xpath, "//label[@class='totalClaimedlbl']");
            string originClaimedFreightVlaue;
            string returnClaimedFreightVlaue;
            string replacementClaimedFreightVlaue;
            string totalClaimedFreightUIValue;

            string originClaimedFreight = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Original_Id, "value");
            string returnClaimedFreight = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Return_Id, "value");
            string replacementClaimedFreight = GetAttribute(attributeName_id, ClaimedFreight_Textbox_Replacement_Id, "value");
            string totalClaimedFreightUI = Gettext(attributeName_xpath, "//label[@class='totalClaimedlbl']");


            if (originClaimedFreight == string.Empty)
            {
                originClaimedFreightVlaue = "0.00";
            }
            else
            {
                originClaimedFreightVlaue = Regex.Replace(originClaimedFreight, @"[^0-9a-zA-Z.]+", "");
            }
            if (returnClaimedFreight == string.Empty)
            {
                returnClaimedFreightVlaue = "0.00";
            }
            else
            {
                returnClaimedFreightVlaue = Regex.Replace(returnClaimedFreight, @"[^0-9a-zA-Z.]+", "");
            }
            if (replacementClaimedFreight == string.Empty)
            {
                replacementClaimedFreightVlaue = "0.00";
            }
            else
            {
                replacementClaimedFreightVlaue = Regex.Replace(replacementClaimedFreight, @"[^0-9a-zA-Z.]+", "");
            }
            if (totalClaimedFreightUI == string.Empty)
            {
                totalClaimedFreightUIValue = "0.00";
            }
            else
            {
                totalClaimedFreightUIValue = Regex.Replace(totalClaimedFreightUI, @"[^0-9a-zA-Z.]+", "");
            }

            decimal totalClaimedFreightValue = Convert.ToDecimal(originClaimedFreightVlaue) + Convert.ToDecimal(returnClaimedFreightVlaue) + Convert.ToDecimal(replacementClaimedFreightVlaue);
            Assert.AreEqual(totalClaimedFreightValue, Convert.ToDecimal(totalClaimedFreightUIValue));
        }
    }
}
