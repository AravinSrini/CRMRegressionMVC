using CRM.UITest.CommonMethods;
using CRM.UITest.Entities;
using CRM.UITest.Entities.Proxy;
using CRM.UITest.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Rrd.ServiceAccessLayer;
using Rrd.SpecflowSelenium.ReportGenerator.CreateReport;
using Rrd.SpecflowSelenium.ReportGenerator.Variables;
using System;
using System.Collections.Generic;
using System.Configuration;
using TechTalk.SpecFlow;

namespace CRM.UITest.Scripts.Insurance_Claims
{
    [Binding]
    public class InsuranceClaims_ClaimDetailsPageSteps : CRM.UITest.Objects.InsuranceClaim
    {


        string claimNumber_ClaimsList_UI;
        string claimAge_ClaimsList_UI;

        string claimNumber_ClaimDetails_UI;
        string carrierName_ClaimDetails_UI;
        string insured_ClaimDetails_UI;
        string claimRep_ClaimDetails_UI;
        string claimant_ClaimDetails_UI;
        string claimAge_ClaimDetails_UI;

        decimal totalNumberOfDays;
        int convertedTotalDays;
        int compareDates;


        [Given(@"I am Sales, Sales Management, Operations, Station Owner and Claims Specialist User")]
        public void GivenIAmSalesSalesManagementOperationsStationOwnerAndClaimsSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I clicked any dlsw claim reference hyper link on the Claims List page")]
        public void GivenIClickedAnyDlswClaimReferenceHyperLinkOnTheClaimsListPage()
        {
            Click(attributeName_id, ClaimsIcon_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List Text");

            
            string GridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (GridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Reading First data value from Claims List page");


                claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
                //claimAge_ClaimsList_UI = Gettext(attributeName_xpath, FirstClaimAge_ClaimList_Xpath);



                Report.WriteLine("Clicking on the Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGrid_Xpath);
                
            }
        }

        [Given(@"I am Sales, Sales Management, Operations, Station Owner User")]
        public void GivenIAmSalesSalesManagementOperationsStationOwnerUser()
        {
            string username = ConfigurationManager.AppSettings["username-crmOperation"].ToString();
            string password = ConfigurationManager.AppSettings["password-crmOperation"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am Claim Specialist User")]
        public void GivenIAmClaimSpecialistUser()
        {
            string username = ConfigurationManager.AppSettings["username-claimspecialistClaim"].ToString();
            string password = ConfigurationManager.AppSettings["password-claimspecialistClaim"].ToString();
            CommonMethodsCrm crmLogin = new CommonMethodsCrm();
            crmLogin.LoginToCRMApplication(username, password);
            GlobalVariables.webDriver.WaitForPageLoad();
        }

        [Given(@"I am on the Claim Details page")]
        public void GivenIAmOnTheClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
            Verifytext(attributeName_cssselector, "h1", "Claim Details");
        }

        [When(@"I arrive on the Claim Details page")]
        public void WhenIArriveOnTheClaimDetailsPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }

        [When(@"I clicked on the Back to Claims List button")]
        public void WhenIClickedOnTheBackToClaimsListButton()
        {
            
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
        }

        [Then(@"I will see the page header as Claim Details")]
        public void ThenIWillSeeThePageHeaderAsClaimDetails()
        {
            Verifytext(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");
        }

        [Then(@"I will see Verbiage associated to the page header")]
        public void ThenIWillSeeVerbiageAssociatedToThePageHeader()
        {
            Verifytext(attributeName_xpath, VerbiageAssociatedToClaimHeader_ClaimDetails_Xpath, "The details for this claim are displayed below.");
        }

        [Then(@"I will see Back to Claims List button")]
        public void ThenIWillSeeBackToClaimsListButton()
        {
            Verifytext(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id, "Back to Claims List");
            VerifyElementPresent(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id, "Back to Claims List");
        }

        [Then(@"I will see Print button")]
        public void ThenIWillSeePrintButton()
        {
            VerifyElementPresent(attributeName_id, Print_Button_ClaimDetails_Id, "Print button");
        }

        [Then(@"I will see DLSW Claim \#, Carrier Name, Claim Rep, Insured, Claimant, Claim Age field values")]
        public void ThenIWillSeeDLSWClaimCarrierNameClaimRepInsuredClaimantClaimAgeFieldValues()
        {
            //claimNumber_ClaimsList_UI = "1123478912";

            int claimNumberUI = Convert.ToInt32(claimNumber_ClaimsList_UI);
            Entities.Proxy.InsuranceClaim insuranceClaim = DBHelper.GetInsuranceClaimDetails(claimNumberUI);
            Entities.Proxy.InsuranceClaimCarrier insuranceClaimCarrier = DBHelper.GetInsuranceClaimCarrierDetails(claimNumberUI);

            Verifytext(attributeName_id, DlswClaimNumber_Label_ClaimDetails_Id, "DLSW CLAIM #:");
            claimNumber_ClaimDetails_UI = Gettext(attributeName_id, DlswClaimNumber_Value_ClaimDetails_Id);
            Assert.AreEqual(claimNumber_ClaimsList_UI, claimNumber_ClaimDetails_UI);

            Verifytext(attributeName_id, CarrierName_Label_ClaimDetails_Id, "CARRIER NAME:");
            carrierName_ClaimDetails_UI = Gettext(attributeName_id, CarrierName_Value_ClaimDetails_Id);
            Assert.AreEqual((insuranceClaimCarrier.CarrierName).ToLower(), carrierName_ClaimDetails_UI.ToLower());

            Verifytext(attributeName_id, ClaimRep_Label_ClaimDetails_Id, "CLAIM REP:");
            claimRep_ClaimDetails_UI = Gettext(attributeName_id, ClaimRep_Value_ClaimDetails_Id);

            if (claimRep_ClaimDetails_UI == "N/A")
            {
                Assert.IsNull(insuranceClaim.InsuranceClaimRep.InsuranceClaimRepName);
            }

            Verifytext(attributeName_id, Insured_Label_ClaimDetails_Id, "INSURED:");
            insured_ClaimDetails_UI = Gettext(attributeName_id, Insured_Value_ClaimDetails_Id);
            if (insured_ClaimDetails_UI == "Y")
            {
                Assert.IsTrue(insuranceClaim.IsArticlesInsured);
            }
            else
            {
                Assert.IsFalse(insuranceClaim.IsArticlesInsured);
            }
            Verifytext(attributeName_id, Claimant_Label_ClaimDetails_Id, "CLAIMANT:");
            claimant_ClaimDetails_UI = Gettext(attributeName_id, Claimant_Value_ClaimDetails_Id);
            Assert.AreEqual("N/A", claimant_ClaimDetails_UI);
            
            string totalclaimAge_ClaimDetails_WithDaysVerbiage = Gettext(attributeName_id, ClaimAge_Value_ClaimDetails_Id);
            string[] totalclaimAge_ClaimDetails_WithDaysVerbiagelist = totalclaimAge_ClaimDetails_WithDaysVerbiage.Split(' ');
            claimAge_ClaimDetails_UI = totalclaimAge_ClaimDetails_WithDaysVerbiagelist[0];

            compareDates = DateTime.Compare(insuranceClaim.CreateDateTime.Date, DateTime.Now.Date);

            if (compareDates <= 0)
            {
                totalNumberOfDays = (decimal)(DateTime.Now.Date - insuranceClaim.CreateDateTime.Date).TotalDays;
                convertedTotalDays = (int)Math.Floor(totalNumberOfDays);
            }
            else
            {
                totalNumberOfDays = (decimal)(insuranceClaim.CreateDateTime.Date - DateTime.Now.Date).TotalDays;
                convertedTotalDays = (int)Math.Ceiling(totalNumberOfDays);
            }

            Assert.AreEqual(claimAge_ClaimDetails_UI, convertedTotalDays.ToString());
            
            Report.WriteLine("Navigating Back to Claims List Page");
            Click(attributeName_id, BackToClaimsList_Button_ClaimDetails_Id);
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");

            IList<IWebElement> A = GlobalVariables.webDriver.FindElements(By.XPath(ClaimNumber_ClaimListCount));
            if (A.Count > 1)
            {
                for (int i = 2; i <= 2; i++)
                {

                    claimNumber_ClaimsList_UI = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");
                    //claimAge_ClaimsList_UI = Gettext(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[10]");

                    Click(attributeName_xpath, ".//*[@id='gridInsuranceClaimList']/tbody/tr[" + i + "]/td[4]/span/a");
                    GlobalVariables.webDriver.WaitForPageLoad();
                    WaitForElementVisible(attributeName_xpath, ClaimDetailsPage_Header_Xpath, "Claim Details");


                    int claimNumberUIA = Convert.ToInt32(claimNumber_ClaimsList_UI);


                    Entities.Proxy.InsuranceClaim _insuranceClaimA = DBHelper.GetInsuranceClaimDetails(claimNumberUIA);
                    Entities.Proxy.InsuranceClaimCarrier _insuranceClaimCarrierA = DBHelper.GetInsuranceClaimCarrierDetails(claimNumberUIA);

                    Verifytext(attributeName_id, DlswClaimNumber_Label_ClaimDetails_Id, "DLSW CLAIM #:");
                    claimNumber_ClaimDetails_UI = Gettext(attributeName_id, DlswClaimNumber_Value_ClaimDetails_Id);
                    Assert.AreEqual(claimNumber_ClaimsList_UI, claimNumber_ClaimDetails_UI);

                    Verifytext(attributeName_id, CarrierName_Label_ClaimDetails_Id, "CARRIER NAME:");
                    carrierName_ClaimDetails_UI = Gettext(attributeName_id, CarrierName_Value_ClaimDetails_Id);
                    Assert.AreEqual((_insuranceClaimCarrierA.CarrierName).ToLower(), carrierName_ClaimDetails_UI.ToLower());

                    Verifytext(attributeName_id, ClaimRep_Label_ClaimDetails_Id, "CLAIM REP:");
                    claimRep_ClaimDetails_UI = Gettext(attributeName_id, ClaimRep_Value_ClaimDetails_Id);

                    if (claimRep_ClaimDetails_UI == "N/A")
                    {
                        Assert.IsNull(_insuranceClaimA.InsuranceClaimRep.InsuranceClaimRepName);
                    }

                    Verifytext(attributeName_id, Insured_Label_ClaimDetails_Id, "INSURED:");
                    insured_ClaimDetails_UI = Gettext(attributeName_id, Insured_Value_ClaimDetails_Id);
                    if (insured_ClaimDetails_UI == "Y")
                    {
                        Assert.IsTrue(_insuranceClaimA.IsArticlesInsured);
                    }
                    else
                    {
                        Assert.IsFalse(_insuranceClaimA.IsArticlesInsured);
                    }

                    Verifytext(attributeName_id, Claimant_Label_ClaimDetails_Id, "CLAIMANT:");
                    claimant_ClaimDetails_UI = Gettext(attributeName_id, Claimant_Value_ClaimDetails_Id);
                    Assert.AreEqual("N/A", claimant_ClaimDetails_UI);

                    compareDates = DateTime.Compare(_insuranceClaimA.CreateDateTime.Date, DateTime.Now.Date);
                    //compareDates = DateTime.Compare(DateTime.Now, insuranceClaim.CreateDateTime);

                    if (compareDates <= 0)
                    {
                        totalNumberOfDays = (decimal)(DateTime.Now.Date - _insuranceClaimA.CreateDateTime.Date).TotalDays;
                        convertedTotalDays = (int)Math.Floor(totalNumberOfDays);
                    }
                    else
                    {
                        totalNumberOfDays = (decimal)(_insuranceClaimA.CreateDateTime.Date - DateTime.Now.Date).TotalDays;
                        convertedTotalDays = (int)Math.Ceiling(totalNumberOfDays);
                    }

                    Verifytext(attributeName_id, ClaimAge_Label_ClaimDetails_Id, "CLAIM AGE:");
                    string claimAge_ClaimDetails_WithDaysVerbiage = Gettext(attributeName_id, ClaimAge_Value_ClaimDetails_Id);
                    string[] claimAge_ClaimDetails_WithDaysVerbiagelist = claimAge_ClaimDetails_WithDaysVerbiage.Split(' ');
                    claimAge_ClaimDetails_UI = claimAge_ClaimDetails_WithDaysVerbiagelist[0];
                    Assert.AreEqual(convertedTotalDays.ToString(), claimAge_ClaimDetails_UI);
                }
            }
        }

        [Then(@"I will not see Edit button")]
        public void ThenIWillNotSeeEditButton()
        {
            VerifyElementNotPresent(attributeName_classname, EditButton_class, "Edit button");
        }

        [Then(@"I will see Edit button")]
        public void ThenIWillSeeEditButton()
        {
            VerifyElementPresent(attributeName_classname, EditButton_class, "Edit button");
        }

        [Then(@"I will navigated back to Claims List page")]
        public void ThenIWillNavigatedBackToClaimsListPage()
        {
            GlobalVariables.webDriver.WaitForPageLoad();
            WaitForElementVisible(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
            Verifytext(attributeName_xpath, ClaimsListPage_HeaderText_Xpath, "Claims List");
        }

        [Given(@"I clicked dlsw claim reference hyper link on the Claims List page")]
        public void GivenIClickedDlswClaimReferenceHyperLinkOnTheClaimsListPage()
        {
            string firstGridData = Gettext(attributeName_xpath, ClaimListGridDataCount_Xpath);
            if (firstGridData == "No Results Found")
            {
                Report.WriteLine("No Claims List found in the Grid");
                throw new Exception("No datas found in the Claim List Grid");
            }
            else
            {
                Report.WriteLine("Clicking on the First Claim Number");
                Click(attributeName_xpath, FirstClaimNumber_ClaimsListGid_ClaimSpecialistUser_Xpath);
            }

        }
    }
}
