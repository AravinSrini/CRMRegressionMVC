using TechTalk.SpecFlow;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using CRM.UITest.CommonMethods;
using System;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimDetails_SaveHeaderSteps : Objects.InsuranceClaim
    {
        string claimNumber = null;
        string claimStatus = "Open";
        string dlswClaimRep = "Colleen McLain";
        string station = "ABC";
        string dlswRef = "95743984";
        string claimant = "Test";
        string claimReason = "Damaged";
        string carrierName = "Con-Way";
        string carrierPRO = "2311";
        string insured = "N";
        
        [Given(@"I am on ClaimDetails page")]
        public void GivenIAmOnClaimDetailsPage()
        {            
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
                Click(attributeName_xpath, ClaimsList_OpenCheckbox_xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
                DefineTimeOut(1000);
                claimNumber = Gettext(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                Click(attributeName_xpath, ClaimSpecilistFirstClaimNumber_ClaimsListGrid_Xpath);
                GlobalVariables.webDriver.WaitForPageLoad();
            }
        }

        [Given(@"I made changes in any of the fields Claim status,DLSW Claim Rep,Station,DLSW Ref \# in Claim Header section")]
        public void GivenIMadeChangesInAnyOfTheFieldsClaimStatusDLSWClaimRepStationDLSWRefInClaimHeaderSection()
        {
            //Click(attributeName_id, claimStatus);

            Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath, dlswClaimRep);

            Click(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Station_DropdownValues_ClaimDetailsPage_Xpath, station);

            SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, dlswRef);
            Report.WriteLine("updated the fileds of Claim status,DLSW Claim Rep,Station,DLSW Ref in Claim Header Section");
        }

        [Given(@"I made changes in any of the fields Claimant,Claim Reason,Carrier Name,Carrier PRO \#,Insured in Claim Header section")]
        public void GivenIMadeChangesInAnyOfTheFieldsClaimantClaimReasonCarrierNameCarrierPROInsuredInClaimHeaderSection()
        {
            SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, claimant);
            Click(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, ClaimReason_DropdownValues_ClaimDetailsPage_Xpath, claimReason);

            Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, carrierName);

            SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, carrierPRO);
            Click(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
            SelectDropdownValueFromList(attributeName_xpath, Insured_DropdownValues_ClaimDetailsPage_Xpath, insured);
            Report.WriteLine("updated the fields Claimant,Claim Reason,Carrier Name,Carrier PRO,Insured in Claim Header Section");
        }

        [Given(@"I have edited any one of the fields (.*) section of Details page")]
        public void GivenIHaveEditedAnyOneOfTheFieldsSectionOfDetailsPage(string claimHeader)
        {
            Report.WriteLine("Updated any one of the following fields of Claim Header section");
            //if (claimHeader == "Claim Status")
            //{
            //    Click(attributeName_id, claimStatus);
            //    SelectDropdownValueFromList(attributeName_id, claimStatus, claimStatus);
            //}
            if (claimHeader == "DLSW Claim Rep")
            {
                Click(attributeName_xpath, DlswClaimRep_dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, DlswClaimRep_DropdownValues_ClaimDetailsPage_Xpath, dlswClaimRep);
            }
            else if (claimHeader == "Station")
            {
                Click(attributeName_xpath, Station_Dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Station_DropdownValues_ClaimDetailsPage_Xpath, station);
            }
            else if (claimHeader == "DLSW Ref #")
            {
                SendKeys(attributeName_id, DlswRefNumber_Textbox_ClaimDetailsPage_Id, dlswRef);
            }
            else if (claimHeader == "Claimant")
            {
                SendKeys(attributeName_id, Claimant_Textbox_ClaimDetailsPage_Id, claimant);
            }
            else if (claimHeader == "Claim Reason")
            {
                Click(attributeName_xpath, ClaimReason_Dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, ClaimReason_DropdownValues_ClaimDetailsPage_Xpath, claimReason);
            }
            else if (claimHeader == "Carrier Name")
            {
                Click(attributeName_xpath, CarrierName_Dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, CarrierName_DropdownValues_ClaimDetailsPage_Xpath, carrierName);
            }
            else if (claimHeader == "Carrier PRO #")
            {
                SendKeys(attributeName_id, CarrierPro_Textbox_ClaimDetailsPage_Id, carrierPRO);
            }
            else
            {
                Click(attributeName_xpath, Insured_Dropdown_ClaimDetailsPage_Xpath);
                SelectDropdownValueFromList(attributeName_xpath, Insured_DropdownValues_ClaimDetailsPage_Xpath, insured);
            }
        }

        [Then(@"updated Claim Header values should be saved")]
        public void ThenUpdatedClaimHeaderValuesShouldBeSaved()
        {
            //string status = DBHelper.GetInsuranceStatus(claimNum).ToString();
            //Assert.AreEqual(claimStatus, status);
            InsuranceClaimRep insuranceclaimRep = DBHelper.GetInsuranceClaimRep(claimNumber);
            Assert.AreEqual(dlswClaimRep, insuranceclaimRep.InsuranceClaimRepName);
            // CustomerAccount insuranceDetails = DBHelper.GetClaimStationDetails(claimNumber);
            // Assert.AreEqual(station, insuranceDetails.StationName);
            InsuranceClaimCarrier dlswRefNumber = DBHelper.GetInsuranceCarrierDetails(claimNumber.ToString());
            Assert.AreEqual(dlswRef, dlswRefNumber.DlswRefNumber);
            InsuranceClaimPayableTo claimantDetails = DBHelper.GetClaimantDetails(claimNumber);
            Assert.AreEqual(claimant, claimantDetails.CompanyName);
            InsuranceClaimReasonCode claimReasonDetails = DBHelper.GetInsuranceClaimReason(claimNumber);
            Assert.AreEqual(claimReason, claimReasonDetails.InsuranceClaimReasonCode1);
            InsuranceClaimCarrier carrierDetails = DBHelper.GetInsuranceCarrierDetails(claimNumber);            
            Assert.AreEqual(carrierName, carrierDetails.CarrierName);
            Assert.AreEqual(carrierPRO, dlswRefNumber.CarrierProNumber);
            InsuranceClaim insuranceclaimDetails = DBHelper.GetInsuranceClaimDetails(claimNumber);
            if (insuranceclaimDetails.IsArticlesInsured == false)
            {
                Report.WriteLine("Selected Insured: N");
            }
            else
            {
                Report.WriteLine("Selected Insured: Y");
            }
            Report.WriteLine("all the above fields updated in DB for Claim Header section");
        }

        [Then(@"The updated claim header (.*) section values should be saved")]
        public void ThenTheUpdatedClaimHeaderSectionValuesShouldBeSaved(string claimHeader)
        {
            //if (claimHeader == "Claim Status")
            //{
            //    string status = DBHelper.GetInsuranceStatus(claimNum).ToString();
            //    Assert.AreEqual(claimStatus, status);
            //}
            if (claimHeader == "DLSW Claim Rep")
            {
                InsuranceClaimRep insuranceclaimRep = DBHelper.GetInsuranceClaimRep(claimNumber);
                Assert.AreEqual(dlswClaimRep, insuranceclaimRep.InsuranceClaimRepName);
            }
            //else if (claimHeader == "Station")
            //{
            //    CustomerAccount insuranceDetails = DBHelper.GetClaimStationDetails(claimNumber);
            //    Assert.AreEqual(station, insuranceDetails.StationName);
            //}
            else if (claimHeader == "DLSW Ref #")
            {
                InsuranceClaimCarrier dlswRefNumber = DBHelper.GetInsuranceCarrierDetails(claimNumber.ToString());
                Assert.AreEqual(dlswRef, dlswRefNumber.DlswRefNumber);
            }
            else if (claimHeader == "Claimant")
            {
                InsuranceClaimPayableTo claimantDetails = DBHelper.GetClaimantDetails(claimNumber);
                Assert.AreEqual(claimant, claimantDetails.CompanyName);
            }
            else if (claimHeader == "Claim Reason")
            {
                InsuranceClaimReasonCode claimReasonDetails = DBHelper.GetInsuranceClaimReason(claimNumber);
                Assert.AreEqual(claimReason, claimReasonDetails.InsuranceClaimReasonCode1);
            }
            else if (claimHeader == "Carrier Name")
            {
                InsuranceClaimCarrier carrierDetails = DBHelper.GetInsuranceCarrierDetails(claimNumber);
                Assert.AreEqual(carrierName, carrierDetails.CarrierName);
            }
            else if (claimHeader == "Carrier PRO #")
            {
                InsuranceClaimCarrier carrierDetails = DBHelper.GetInsuranceCarrierDetails(claimNumber.ToString());
                Assert.AreEqual(carrierPRO, carrierDetails.CarrierProNumber);
            }
            else
            {
                InsuranceClaim insuranceclaimDetails = DBHelper.GetInsuranceClaimDetails(claimNumber);
                if (insuranceclaimDetails.IsArticlesInsured == false)
                {
                    Report.WriteLine("Selected Insured: N");
                }
                else
                {
                    Report.WriteLine("Selected Insured: Y");
                }
            }
            Report.WriteLine("Above fields updated in DB for Claim Header section");
        }
    }
}
