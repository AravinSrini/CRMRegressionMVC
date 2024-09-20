using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.IO;
using System.Threading;

namespace CRM.UITest.CommonMethods
{
    class ResubmitClaim : InsuranceClaim
    {
        int claimNumber = 0;
        string originFreightCharge = "65";
        string returnFreightCharge = "54";
        string replacementFreightCharge = "65";
        string InsuredAmount = "23.00";
        string UnitVal = "23.00";
        string Quantity = "45";
        string Weight = "23.00";
        string ClaimDescription = "Description Test 123";
        string ReturnDLS = "45564321236789087654";
        string ReplaceDLS = "532756";
        string DocumentType = "Repair Invoice";
       
        public int GetResubmitClaimNumber()
        {
            Report.WriteLine("Claim payable to information is passed");
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            scrollpagedown();
            Click(attributeName_xpath, ArticlesInsuredYes_Xpath);
            SendKeys(attributeName_id, InsuredAmount_Id, InsuredAmount);
            Click(attributeName_xpath, ShortageOption_Xpath);
            Click(attributeName_xpath, ArticlesTypeUsed_Xpath);
            SendKeys(attributeName_id, UnitValue_Id, UnitVal);
            SendKeys(attributeName_id, Quantity_Id, Quantity);
            SendKeys(attributeName_id, Weight_LBS_Id, Weight);
            SendKeys(attributeName_id, ClaimedArticle_Description_Id, ClaimDescription);
            Click(attributeName_xpath, FreightChargeYes_Xpath);
            scrollpagedown();
            Thread.Sleep(9000);
            SendKeys(attributeName_xpath, OriginFreightChargeVal_Xpath, originFreightCharge.ToString());
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            Click(attributeName_xpath, ReturnFreightCharge_Xpath);
            SendKeys(attributeName_id, ReturnFreightVal_Id, returnFreightCharge.ToString());
            SendKeys(attributeName_id, ReturnDLS_Id, ReturnDLS);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            Click(attributeName_xpath, ReplacementFreight_Xpath);
            SendKeys(attributeName_xpath, ReplaceFreightVal_Xpath, replacementFreightCharge.ToString());
            SendKeys(attributeName_id, ReplaceDLS_Id, ReplaceDLS);
            Report.WriteLine("Claim details are been passed");
            scrollpagedown();
            scrollpagedown();
            Thread.Sleep(3000);
            string oldPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/searcherCheck.txt");
            Thread.Sleep(3000);
            string newPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "searcherCheck1.txt");
            Thread.Sleep(3000);
            File.Copy(oldPath, newPath, true);
            FileUpload(attributeName_xpath, DocumentUploadButton_Xpath, newPath);
            Thread.Sleep(3000);
            File.Delete(newPath);
            scrollElementIntoView(attributeName_id, AddAdditionalDocument_Button_Id);
            Click(attributeName_id, AddAdditionalDocument_Button_Id);
            WaitForElementVisible(attributeName_xpath, DocumentDropdown_Xpath, "Doctype");
            Click(attributeName_xpath, DocumentDropdown_Xpath);
            Thread.Sleep(3000);
            SelectDropdownValueFromList(attributeName_xpath, DocumentDropdownValues_Xpath, DocumentType);
            Thread.Sleep(5000);
            string oldAddPath = Path.GetFullPath("../../Scripts/TestData/Testfiles_ClaimDocument/hacker.txt");
            string newAddPath = Path.GetFullPath("../../Scripts/TestData/Temp/" + Guid.NewGuid().ToString() + "hacker1.txt");
            File.Copy(oldAddPath, newAddPath, true);
            FileUpload(attributeName_cssselector, AdditionalUploadButton_Css, newAddPath);
            Thread.Sleep(3000);
            File.Delete(newAddPath);
            Report.WriteLine("Documents are uploaded");
            Thread.Sleep(3000);
            Report.WriteLine("Submitting Claim Form");
            Click(attributeName_id, SubmitClaimButton_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            claimNumber = DBHelper.GetClaimNumber();
            return claimNumber;
        }
    }
}
