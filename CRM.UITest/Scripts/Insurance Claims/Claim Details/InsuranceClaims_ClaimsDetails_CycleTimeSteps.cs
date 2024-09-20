using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using System.Threading;

namespace CRM.UITest.Scripts.Insurance_Claims.Claim_Details
{
    [Binding]
    public class InsuranceClaims_ClaimsDetails_CycleTimeSteps : CRM.UITest.Objects.InsuranceClaim
    {
        bool checkCommentDLSWCategory = true;
        string claimNumber = string.Empty;
        DateTime dLSWDate;
        int cycleTime;
        string userType = string.Empty;

        [Given(@"I clicked on the hyperlink of a displayed claim on the Claims List page")]
        public void GivenIClickedOnTheHyperlinkOfADisplayedClaimOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            string gridFirstColumnHeader = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/thead/tr/th[1]");

            if (gridFirstColumnHeader == "CUSTOMER")
            {
                userType = "Internal User";
                Report.WriteLine("logged in User is Internal");
                claimNumber = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[4]/span/a");
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[4]/span/a");
            }
            else if (gridFirstColumnHeader == "STA / CUST")
            {
                Report.WriteLine("logged in User is Claim Specialist User");
                userType = "Claim Specialist User";
                claimNumber = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
            }
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }
        
        [Given(@"a comment with the category of (.*) has been saved on the History Tab")]
        public void GivenACommentWithTheCategoryOfHasBeenSavedOnTheHistoryTab(string p0)
        {
            string uiClaimNumebrs = string.Empty;
            DateTime dlswSubmittedClaimModifiedDateComparedWithDBAndUI;
            List<InsuranceClaimHistory> historyDetails = DBHelper.GetClaimHistoryOfCategoryDLSWSubmittedClaim();
            dlswSubmittedClaimModifiedDateComparedWithDBAndUI = historyDetails.Where(x => x.ClaimNumber.Equals(Convert.ToInt32(claimNumber))).Select(x => x.ModifiedDate).FirstOrDefault();
            string modifiedDateForParticularClaimNumebr = dlswSubmittedClaimModifiedDateComparedWithDBAndUI.ToString();
            if (modifiedDateForParticularClaimNumebr == "1/1/0001 12:00:00 AM")
            {
                scrollElementIntoView(attributeName_xpath, ".//*[@id='CarrierType_chosen']/a");
                scrollPageup();
                Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");
                
                if (userType == "Internal User")
                {
                    IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
                    for (int i = 2; i <= gridClaimNumbers.Count; i++)
                    {
                        uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");

                        dlswSubmittedClaimModifiedDateComparedWithDBAndUI = historyDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ModifiedDate).FirstOrDefault();
                        string actualdate = dlswSubmittedClaimModifiedDateComparedWithDBAndUI.ToString();
                        if (actualdate != "1/1/0001 12:00:00 AM")
                        {
                            dLSWDate = dlswSubmittedClaimModifiedDateComparedWithDBAndUI;
                            SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumebrs);
                            Thread.Sleep(2000);
                            Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a/span");
                            break;
                        }
                        else if (i == gridClaimNumbers.Count && actualdate == "1/1/0001 12:00:00 AM")
                        {
                            Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
                            checkCommentDLSWCategory = false;
                        }
                    }
                }
                
                else if(userType == "Claim Sepcialist User")
                {
                    
                    IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[3]/span[1]/a"));
                    for (int i = 2; i <= gridClaimNumbers.Count; i++)
                    {
                        uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");

                        dlswSubmittedClaimModifiedDateComparedWithDBAndUI = historyDetails.Where(x => x.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Select(x => x.ModifiedDate).FirstOrDefault();
                        string actualdate = dlswSubmittedClaimModifiedDateComparedWithDBAndUI.ToString();
                        if (actualdate != "1/1/0001 12:00:00 AM")
                        {
                            dLSWDate = dlswSubmittedClaimModifiedDateComparedWithDBAndUI;
                            SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumebrs);
                            Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
                            break;
                        }
                        else if (i == gridClaimNumbers.Count && actualdate == "1/1/0001 12:00:00 AM")
                        {
                            Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
                            checkCommentDLSWCategory = false;
                        }
                    }

                }
            }
            else
            {
                dLSWDate = dlswSubmittedClaimModifiedDateComparedWithDBAndUI;
            }
        }
        
        [Given(@"the claim does not have a History Tab comment with the category of (.*)")]
        public void GivenTheClaimDoesNotHaveAHistoryTabCommentWithTheCategoryOf(string p0)
        {
            string uiClaimNumebrs = string.Empty;
            List<InsuranceClaimHistory> historyDetails = DBHelper.GetClaimHistoryOfCategoryDLSWSubmittedClaim();
            bool checkFirstClaimNumberWithDLSWCategoryComment = historyDetails.Where(a => a.ClaimNumber == Convert.ToInt32(claimNumber)).Any();
            
            if (checkFirstClaimNumberWithDLSWCategoryComment)
            {
                scrollElementIntoView(attributeName_xpath, ".//*[@id='CarrierType_chosen']/a");
                scrollPageup();
                Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
                GlobalVariables.webDriver.WaitForPageLoad();
                Click(attributeName_xpath, "//label[@for='FilterByStatusPending']");
                Click(attributeName_xpath, ClaimListGrid_PageViewOption_dropdown_Xpath);
                Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_length']/label/select/option[5]");

                if (userType == "Internal User")
                {
                    
                    IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a"));
                    for (int i = 2; i <= gridClaimNumbers.Count; i++)
                    {
                        uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");
                        
                        bool checkClaimNumberWithDLSWCategoryComment = historyDetails.Where(a => a.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Any();

                        if (checkClaimNumberWithDLSWCategoryComment == false)
                        {   
                            Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
                            SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumebrs);
                            Thread.Sleep(2000);
                            Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr/td[4]/span/a/span");
                            Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
                            break;
                        }
                        else if (i == gridClaimNumbers.Count && checkClaimNumberWithDLSWCategoryComment == true)
                        {
                            Report.WriteLine("Claims have a History Tab comment with the category of DLSW Submitted Claim");
                            checkCommentDLSWCategory = false;
                        }
                    }
                }

                else if(userType == "Claim Specialist User")
                {
                    
                    IList<IWebElement> gridClaimNumbers = GlobalVariables.webDriver.FindElements(By.XPath(".//*[@id='gridInsuranceClaimList']/tbody/tr/td[3]/span[1]/a"));
                    for (int i = 2; i <= gridClaimNumbers.Count; i++)
                    {
                        uiClaimNumebrs = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[3]/span[1]/a");
                        
                        bool checkClaimNumberWithDLSWCategoryComment = historyDetails.Where(a => a.ClaimNumber == Convert.ToInt32(uiClaimNumebrs)).Any();
                        if (checkClaimNumberWithDLSWCategoryComment == false)
                        {
                            Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
                            SendKeys(attributeName_xpath, ".//*[@id='gridInsuranceClaimList_filter']/label/input", uiClaimNumebrs);
                            Thread.Sleep(2000);
                            Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[1]/td[3]/span[1]/a");
                            break;
                        }
                        else if (i == gridClaimNumbers.Count && checkClaimNumberWithDLSWCategoryComment == true)
                        {
                            Report.WriteLine("Claims have a History Tab comment with the category of DLSW Submitted Claim");
                            checkCommentDLSWCategory = false;
                        }
                    }
                }
            }
            else
            {
                Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
            }
        }
        
        [Given(@"the claim contained more than one comment with the category of (.*) saved on the History Tab")]
        public void GivenTheClaimContainedMoreThanOneCommentWithTheCategoryOfSavedOnTheHistoryTab(string dlswSubmittedClaim)
        {
            GivenACommentWithTheCategoryOfHasBeenSavedOnTheHistoryTab(dlswSubmittedClaim);
        }
        
        [When(@"I arrive on the Claim Details of the selected claim")]
        public void WhenIArriveOnTheClaimDetailsOfTheSelectedClaim()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }
        
        [Then(@"the Cycle Time will be calculated as the difference between Current date and the date of history Tab comment with the category of (.*)")]
        public void ThenTheCycleTimeWillBeCalculatedAsTheDifferenceBetweenCurrentDateAndTheDateOfHistoryTabCommentWithTheCategoryOf(string p0)
        {
            if(checkCommentDLSWCategory)
            {
                cycleTime = ((DateTime.UtcNow - dLSWDate).Days);
            }
            else
            {
                Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
            }
        }
        
        [Then(@"the Cycle Time will be displayed in days")]
        public void ThenTheCycleTimeWillBeDisplayedInDays()
        {
            string expectedCycleTime = string.Empty;
            if (checkCommentDLSWCategory)
            {
                string actualCycleTimeUI = GetValue(attributeName_id, DetailsTab_Edit_Shipper_CycleTime_Id, "value");
                if (cycleTime == 0 || cycleTime == 1)
                {
                    expectedCycleTime = cycleTime.ToString() +" "+ "day";
                }
                else
                {
                    expectedCycleTime  = cycleTime.ToString() + " " + "days";
                }
                
                Assert.AreEqual(expectedCycleTime, actualCycleTimeUI);
            }
            else
            {
                Report.WriteLine("Claim does not have a History Tab comment with the category of DLSW Submitted Claim");
            }
        }
        
        [Then(@"the Cycle Time field will be blank")]
        public void ThenTheCycleTimeFieldWillBeBlank()
        {
            if(checkCommentDLSWCategory)
            {
                string actualCycleTimeUI = GetValue(attributeName_id, DetailsTab_Edit_Shipper_CycleTime_Id, "value");
                Assert.AreEqual(string.Empty, actualCycleTimeUI);
            }
            else
            {
                Report.WriteLine("Claim have a History Tab comment with the category of DLSW Submitted Claim");
            }
        }
        
        [Then(@"the Cycle Time will be calculated using the most recent (.*) History Tab comment")]
        public void ThenTheCycleTimeWillBeCalculatedUsingTheMostRecentHistoryTabComment(string p0)
        {
            ThenTheCycleTimeWillBeCalculatedAsTheDifferenceBetweenCurrentDateAndTheDateOfHistoryTabCommentWithTheCategoryOf(p0);
            ThenTheCycleTimeWillBeDisplayedInDays();
        }
    }
}
