using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class _91197_InsuranceClaimsLabels_SubmitAClaimForm_UpdateWeightLabelToUnitWeightSteps : Objects.InsuranceClaim
    {
        int Claimnumber;
        ClickAndWaitMethods crmWait = new ClickAndWaitMethods();
        [Given(@"I am on the Claims List,")]
        public void GivenIAmOnTheClaimsList()
        {
            Report.WriteLine("Clicking on Claim icon");
            crmWait.ClickAndWait(attributeName_id, ClaimsIcon_Id);
           
        }
        
        [Given(@"I clicked on the Submit a Claim button,")]
        public void GivenIClickedOnTheSubmitAClaimButton()
        {
            Report.WriteLine("Clicking on Claim submit button");
            crmWait.ClickAndWait(attributeName_xpath, SubmitClaimButton_Xpath);
        }
        
        [Given(@"in Show Status Amend box is checked")]
        public void GivenInShowStatusAmendBoxIsChecked()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("I un-check submitted checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_SubmittedStatusCheckBox_Xpath); //submitted
            Report.WriteLine("I check amend checkbox");
            crmWait.ClickAndWait(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath); //amend
            
        }

        [Given(@"I clicked on Edit button of a claim that is in Amend status for (.*)")]
        public void GivenIClickedOnEditButtonOfAClaimThatIsInAmendStatusFor(string user)
        {
            if (user == "External")
            { Claimnumber = 2019000034; }
            else if (user == "claimspecialist")
            { Claimnumber = 2019000693; }
            else
            { Claimnumber = 2019000719; }
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, Claimnumber.ToString());
            crmWait.ClickAndWait(attributeName_xpath, ClaimListEditIcon_Xpath);           
        }
        
        [When(@"I arrive on the Submit a Claim page,")]
        public void WhenIArriveOnTheSubmitAClaimPage()
        {
            Report.WriteLine("Verifying user is in Submit Claim page");
            VerifyElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
        }

        [When(@"I arrive on the Resubmit a Claim page,")]
        public void WhenIArriveOnTheResubmitAClaimPage()
        {
            Report.WriteLine("Verifying user in ReSubmit claim page");
            VerifyElementPresent(attributeName_xpath, Submit_Claim_Page_Header_xpath, "Amend a previously submitted motor carrier shortage or damage claim");
        }


        [When(@"I click on the Add Another Item button in the Claim Details section,")]
        public void WhenIClickOnTheAddAnotherItemButtonInTheClaimDetailsSection()
        {
            Report.WriteLine("Clicking on Add another Button in submit claim page");
            Click(attributeName_xpath, AddAnotherItem_Xpath);
        }
        
        [Then(@"the Weight \(LBS\) field in the Claim Details section will be renamed Unit Weight \(LBS\)\.")]
        public void ThenTheWeightLBSFieldInTheClaimDetailsSectionWillBeRenamedUnitWeightLBS_()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string UnitWeightName = Gettext(attributeName_xpath, submitAClaimPage_UnitWeightName_Xpath);

            if (UnitWeightName == "Unit Weight (LBS) *")
            { Report.WriteLine("The Unit Weight has been change from weight to Unit Weight (LBS)"); }
            else
            { Report.WriteFailure("The Unit Weight has not been changed from weight to Unit Weight (LBS)"); }
        }

        [Then(@"the Weight \(LBS\) field in the Claim Details section of resubmit page will be renamed Unit Weight \(LBS\)\.")]
        public void ThenTheWeightLBSFieldInTheClaimDetailsSectionOfResubmitPageWillBeRenamedUnitWeightLBS_()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
          
            string UnitWeightName = Gettext(attributeName_xpath, ResubmitAClaimPage_UnitWeightName_Xpath);

            if (UnitWeightName == "Unit Weight (LBS) *")
            { Report.WriteLine("The Unit Weight has been change from weight to Unit Weight (LBS)"); }
            else
            { Report.WriteFailure("The Unit Weight has not been changed from weight to Unit Weight (LBS)"); }

        }

        [Given(@"I am on the submit a Claim page,")]
        public void GivenIAmOnTheSubmitAClaimPage()
        {
            Report.WriteLine("Verifying user is in Submit Claim page");
            VerifyElementVisible(attributeName_xpath, Submit_A_Claim_Page_Header_Text_Xpath, "Submit a Claim");
        }
        [Then(@"the Weight \(LBS\) field of the additional item of resubmit page will be renamed Unit Weight \(LBS\)\.")]
        public void ThenTheWeightLBSFieldOfTheAdditionalItemOfResubmitPageWillBeRenamedUnitWeightLBS_()
        {
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            string UnitWeightName = Gettext(attributeName_xpath, ResubmitAClaimPage_UnitWeightName_Xpath);

            if (UnitWeightName == "Unit Weight (LBS) *")
            { Report.WriteLine("The Unit Weight has been change from weight to Unit Weight (LBS) in Resubmit Claim page"); }
            else
            { Report.WriteFailure("The Unit Weight has not been changed from weight to Unit Weight (LBS) in Resubmit Claim page)"); }

        }


        [Then(@"the Weight \(LBS\) field of the additional item will be renamed Unit Weight \(LBS\)\.")]
        public void ThenTheWeightLBSFieldOfTheAdditionalItemWillBeRenamedUnitWeightLBS_()
        {
            scrollpagedown();
            scrollpagedown();
            string UnitWeightName = Gettext(attributeName_xpath, ResubmitAClaimPage_UnitWeightName_Xpath);

            if (UnitWeightName == "Unit Weight (LBS) *")
            { Report.WriteLine("The Unit Weight has been change from weight to Unit Weight (LBS) in Resubmit Claim page"); }
            else
            { Report.WriteFailure("The Unit Weight has not been changed from weight to Unit Weight (LBS) in Resubmit Claim page)"); }
        }
    }
}
