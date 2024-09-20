using System;
using TechTalk.SpecFlow;
using System.Text.RegularExpressions;
using CRM.UITest.CommonMethods;
using CRM.UITest.Objects;
using Microsoft.IdentityModel.Protocols;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System.Configuration;
using System.Threading;
using System.Collections.Generic;
using CRM.UITest.Entities;
using System.IO;



namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ClaimNumberingMethodologySteps : InsuranceClaim
    {

        [Given(@"I am a shp\.inquiry, shp\.inquirynorates, shp\.entry, shp\.entrynorates, Sales, Sales Management, Operations, Station Owner, or Claims Specialist")]
        public void GivenIAmAShp_InquiryShp_InquirynoratesShp_EntryShp_EntrynoratesSalesSalesManagementOperationsStationOwnerOrClaimsSpecialist()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm CrmLogin = new CommonMethodsCrm();
            CrmLogin.LoginToCRMApplication(username, password);
        }


       
        [Given(@"All the required data has been passed in Submit Claim page")]
        public void GivenAllTheRequiredDataHasBeenPassedInSubmitClaimPage()
        {
            

            SendKeys(attributeName_id, DLSWBillOfLading_Textbox_Id, "999077");
            SendKeys(attributeName_id, CarrierName_Textbox_Id, "carrier xyz");
            SendKeys(attributeName_id, CarrierPro_Textbox_Id, "123rtz");
            Click(attributeName_id, DLSWShipDate_Id);
            Click(attributeName_xpath, DLSWShipDate_Xpath);

            SendKeys(attributeName_id, Shipper_Name_Textbox_Id, "Shipper name");
            SendKeys(attributeName_id, Shipper_Address_Textbox_Id, "address122");
            SendKeys(attributeName_id, Shipper_Zip_Postal_Textbox_Id, "90001");

            SendKeys(attributeName_id, Consignee_Name_Textbox_Id, "xrsyd");
            SendKeys(attributeName_id, Consignee_Address_Textbox_Id, "xyz 12/2");
            SendKeys(attributeName_id, Consignee_Address2_Textbox_Id, "eyruyru");
            SendKeys(attributeName_id, Consignee_Zip_Postal_Textbox_Id, "90001");
            SendKeys(attributeName_id, Consignee_City_Textbox_Id, "xxxx");

            SendKeys(attributeName_id, ClaimPayableTo_CompanyName_Id, "xxxx");
            SendKeys(attributeName_id, ClaimPayableTo_Address_Id, "address1");
            SendKeys(attributeName_id, ClaimPayableTo_ZipCode_Id, "12345");
            SendKeys(attributeName_id, ClaimPayableTo_ContactName_Id, "contact name");
            SendKeys(attributeName_id, ClaimPayableTo_ContactPhone_Id, "9090908790");
            SendKeys(attributeName_id, ClaimPayableTo_ContactEmail_Id, "test@test.com");

            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ClaimType_Shortage_xpath);
            Click(attributeName_xpath, ArticleType_Used_Xpath);
            SendKeys(attributeName_id, ItemMode_Number_Id, "90909");
            SendKeys(attributeName_id, UnitValue_Id, "90");
            SendKeys(attributeName_id, Quantity_Id, "30");
            SendKeys(attributeName_id, Weight_LBS_Id, "100");
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/Claim.xlsx");
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "Claim1.xlsx");
            File.Copy(oldPath, newPath, true);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(3000);
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, "test description");
            
        }
       
        [When(@"I click on the Submit Claim button")]
        public void WhenIClickOnTheSubmitClaimButton()
        {
            Thread.Sleep(3000);
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_id, SubmitClaimButton_Id);
        }
        
        [Then(@"CRM will create a unique (.*) digit claim number")]
        public void ThenCRMWillCreateAUniqueDigitClaimNumber(int p0)
        {
            string ClaimNumber = DBHelper.LatestClaimNumber().ToString();  //getting from db
            Regex regex = new Regex("[0-9]{10,10}");
            bool isPresent = regex.Matches(ClaimNumber).Count != 0 ? true : false;
            Assert.IsTrue(isPresent);
            
        }
        
        [Then(@"the first four digits of claim number will contain the year in which the claim was submitted")]
        public void ThenTheFirstFourDigitsOfClaimNumberWillContainTheYearInWhichTheClaimWasSubmitted()
        {

            string currentYear = DateTime.Now.Year.ToString();
            string ClaimNumber = DBHelper.LatestClaimNumber().ToString();
            string ClaimYear = ClaimNumber.Substring(0, 4);

            Assert.AreEqual(currentYear, ClaimYear);
        }

        [Then(@"the last (.*) digits of the claim number will contain a value which will be assigned incrementally and it will be beginning with (.*)")]
        public void ThenTheLastDigitsOfTheClaimNumberWillContainAValueWhichWillBeAssignedIncrementallyAndItWillBeBeginningWith(int p0, int p1)
        {
            List<int> ClaimNumbers = new List<int>();
            ClaimNumbers = DBHelper.LastNClaimNumber(2);
           
            bool IsDifferenceOne = true;
            // int i = 1;
            for (int i = 1; i < ClaimNumbers.Count; i++)
            {
                int claimNumberFirst = ClaimNumbers[i];
                int ClaimNumberSecond = ClaimNumbers[i - 1];
                if ((ClaimNumbers[i-1] - ClaimNumbers[i]) != 1)
                {
                    IsDifferenceOne = false;
                    break;
                }
            }

            Assert.IsTrue(IsDifferenceOne);
        }


        [Then(@"the last (.*) digits will reset to (.*) beginning on January (.*)st every year")]
        public void ThenTheLastDigitsWillResetToBeginningOnJanuaryStEveryYear(int p0, int p1, int p2)
        {
            DateTime today = DateTime.Today;
            int currentYear = today.Year;
            int claimNumber = DBHelper.MinClaimNumberOfYear(currentYear);
            int incr = claimNumber % 1000000;
            Assert.AreEqual(incr, 1);
        }

    }
}
