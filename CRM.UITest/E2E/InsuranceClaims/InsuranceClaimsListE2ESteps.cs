using System;
using TechTalk.SpecFlow;
using CRM.UITest.Scripts.Insurance_Claims;

namespace CRM.UITest.E2E.InsuranceClaims
{
    [Binding]
    public class InsuranceClaimsListE2ESteps
    {
        [Given(@"I am a Logged in ClaimSpecialist User and on ClaimList Page")]
        public void GivenIAmALoggedInClaimSpecialistUserAndOnClaimListPage()
        {
            InsuranceClaims_Claim_DetailsFreightCalculations_Stpes ins = new InsuranceClaims_Claim_DetailsFreightCalculations_Stpes();
            ins.WhenIClickOnTheSaveClaimDetailsButtonOnClaimDetailsPage();
        }

        [When(@"I arrive on the page and see all the displayed data")]
        public void WhenIArriveOnThePageAndSeeAllTheDisplayedData()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"verify the data displayed is correct")]
        public void ThenVerifyTheDataDisplayedIsCorrect()
        {
            ScenarioContext.Current.Pending();
        }


    }
}
