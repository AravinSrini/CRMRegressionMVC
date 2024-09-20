using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class Insurance_Claims___Confirmation_of_Accuracy_Section___Verbiage_Configurable_Steps : InsuranceClaim
    {
        CommonMethodsCrm CrmLogin = new CommonMethodsCrm();

        [Given(@"I am on Claim List page")]
        public void GivenIAmOnClaimListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [When(@"I click on Submit a Claim button")]
        public void WhenIClickOnSubmitAClaimButton()
        {
            Click(attributeName_id, Submit_A_Claim_button_Id);
           
        }

        [Then(@"Cofigurable verbiage should be displayed in confirmation of accuracy section")]
        public void ThenCofigurableVerbiageShouldBeDisplayedInConfirmationOfAccuracySection()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollElementIntoView(attributeName_id, SubmitClaimButton_Id);
            string accuracySectionVerbiage= DBHelper.ConfirmationOfAccuracySectionVerbiage();
            string accuracySectionVerbiageUI=Gettext(attributeName_xpath, ConfirmationVerbiage_Xpath);

            Assert.AreEqual(accuracySectionVerbiageUI, accuracySectionVerbiage);
        }

    }
}
