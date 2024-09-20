using CRM.UITest.Entities;
using CRM.UITest.Objects;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;

namespace CRM.UITest.CommonMethods
{
    class Submit_AmendClaim : InsuranceClaim
    {
        int claimNumber = 0;
        
        public void ClaimSubmitAmend(string UserType)
        {
            Click(attributeName_xpath, SubmitClaimButton_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();
            Report.WriteLine("Navigated to Submit a Claim page");
            InsuranceClaimsubmit Claim = new InsuranceClaimsubmit();
            claimNumber = Claim.Claimsubmit(UserType);
            DBHelper.updateClaimStatusAsAmend(claimNumber);
            refreshBrowser();
            Click(attributeName_xpath, ClaimsList_AmendStatusCheckBox_Xpath);
            SendKeys(attributeName_xpath, ClaimList_ClaimNumberSearchBox_Xpath, claimNumber.ToString());
            Click(attributeName_xpath, ClaimListEditIcon_Xpath);
            GlobalVariables.webDriver.WaitForPageLoad();            
        }
    }
}
