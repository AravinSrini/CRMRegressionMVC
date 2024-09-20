using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_FTLSteps : CRM.UITest.Objects.InsuranceClaim
    {
        string GetClaimNum = null;
        string CarrierMC = "321377";
        string SealNum = "645348";
        string VehicleNum = "wtq6533746";

        [Given(@"I am on the Claim Details page\.")]
        public void GivenIAmOnTheClaimDetailsPage_()
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

        [Given(@"I have made edit to the following FTL specific fields : Carrier MC \#, Seal Intact, Seal \#, Vehicle \#")]
        public void GivenIHaveMadeEditToTheFollowingFTLSpecificFieldsCarrierMCSealIntactSealVehicle()
        {
            Click(attributeName_xpath, ClaimDetailsMode_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
            Report.WriteLine("Selected FTL as claim mode");
            scrollpagedown();
            SendKeys(attributeName_id, Carrier_MC_Id, CarrierMC);
            SendKeys(attributeName_id, Seal_Number_Id, SealNum);
            Click(attributeName_xpath, SealIntact_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, SealIntactValues_Xpath, "Yes");
            SendKeys(attributeName_id, VehicleNumber_Id, VehicleNum);
            Report.WriteLine("Edit is made to all FTL specific fields");
                
        }
        [Given(@"I have made an edit to any of the following FTL specific fields : Carrier MC \#, Seal Intact, Seal \#, Vehicle \# - (.*)")]
        public void GivenIHaveMadeAnEditToAnyOfTheFollowingFTLSpecificFieldsCarrierMCSealIntactSealVehicle_(string FTLField)
        {
            if(FTLField == "CarrierMC#")
            {
                Click(attributeName_xpath, ClaimDetailsMode_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
                Report.WriteLine("Selected FTL as claim mode");
                scrollpagedown();
                SendKeys(attributeName_id, Carrier_MC_Id, "3247324");
                Report.WriteLine("Carrier MC number is been passed");
            }
            else if(FTLField == "SealIntact")
            {
                Click(attributeName_xpath, ClaimDetailsMode_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
                Report.WriteLine("Selected FTL as claim mode");
                scrollpagedown();
                Click(attributeName_xpath, SealIntact_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, SealIntactValues_Xpath, "No");
                Report.WriteLine("Seal Intacct is seleted");
            }
            else if(FTLField == "Seal#")
            {
                Click(attributeName_xpath, ClaimDetailsMode_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
                Report.WriteLine("Selected FTL as claim mode");
                scrollpagedown();
                SendKeys(attributeName_id, Seal_Number_Id, "326478");
                Report.WriteLine("Seal number number is been passed");
            }
            else
            {
                Click(attributeName_xpath, ClaimDetailsMode_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimDetailsModeDropdown_Xpath, "FTL");
                Report.WriteLine("Selected FTL as claim mode");
                scrollpagedown();
                SendKeys(attributeName_id, VehicleNumber_Id, "FD434423");
                Report.WriteLine("Vehicle number is been passed");
            }
        }

        [When(@"I click on Save Claim Details button on the Claim Details page")]
        public void WhenIClickOnSaveClaimDetailsButtonOnTheClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            scrollPageup();
            scrollPageup();
            Click(attributeName_id, SaveClaimDetailsButton_Id);
            Report.WriteLine("Clicked on Save Claim details button");
        }
        

        [Then(@"The edits should get saved - (.*)")]
        public void ThenTheEditsShouldGetSaved_(string FTLField)
        {
            InusranceFtlMode FTLFielVal = DBHelper.GetFTLFieldsValClaimDetails(GetClaimNum);
            if (FTLField == "CarrierMC#")
            {
                Assert.AreEqual(FTLFielVal.CarrierMcNumber, "3247324");
                Report.WriteLine("Edited Carrier MC number is saved in DB");
            }
            else if (FTLField == "SealIntact")
            {
                Assert.AreEqual(FTLFielVal.SealIntact.ToString(), "False");
                Report.WriteLine("Edited Seal Intact is saved in DB");
            }
            else if (FTLField == "Seal#")
            {
                Assert.AreEqual(FTLFielVal.Seal, "326478");
                Report.WriteLine("Edited Seal number is saved in DB");
            }
            else
            {
                Assert.AreEqual(FTLFielVal.Vehicle, "FD434423");
                Report.WriteLine("Edited Vehicle number is saved in DB");
            }
        }


        [Then(@"The edits should get saved\.")]
        public void ThenTheEditsShouldGetSaved_()
        {
            InusranceFtlMode FTLFielVal = DBHelper.GetFTLFieldsValClaimDetails(GetClaimNum);
            Assert.AreEqual(FTLFielVal.CarrierMcNumber, CarrierMC);
            Report.WriteLine("Edited Carrier MC number is saved in DB");
            Assert.AreEqual(FTLFielVal.Seal, SealNum);
            Report.WriteLine("Edited Seal number is saved in DB");
            Assert.AreEqual(FTLFielVal.Vehicle, VehicleNum);
            Report.WriteLine("Edited Vehicle number is saved in DB");
            Assert.AreEqual(FTLFielVal.SealIntact.ToString(), "True" );
            Report.WriteLine("Edited Seal Intact is saved in DB");
        }
    }
}
